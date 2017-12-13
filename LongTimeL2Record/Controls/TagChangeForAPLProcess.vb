Imports System.Net.Mail
Imports System.Threading

Public Class TagChangeForAPLProcess
    Implements ITagChangeForProcess

#Region "產線名稱 屬性:LineName"
    ''' <summary>
    ''' 產線名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LineName As String = "" Implements ITagChangeForProcess.LineName
#End Region

    Dim PreInCoilItem As L2APLInOutStoveRecord = Nothing
    Dim PreOutCoilItem As L2APLInOutStoveRecord = Nothing

    Public Function ProcessChange(AllDatas As List(Of L2RealTimeTagDisplay), ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay)) As Integer Implements ITagChangeForProcess.ProcessChange
        Dim ReturnValue As Integer = 0
        If IsNothing(ChangedDatas) OrElse String.IsNullOrEmpty(LineName) Then
            Return 0
        End If
        Static IsFirstIn As Boolean = True
        For Each EachStationName As String In (From A In ChangedDatas Where A.LineName.Trim = LineName And _
                                   (A.TagName.ToUpper.Contains("L2_TRCK_IN_FUR") Or _
                                   A.TagName.ToUpper.Contains("L2_TRCK_OUT_FUR") Or IsFirstIn) Select A.LineName.Trim).Distinct
            ReturnValue += StationConnectChangeProcess(AllDatas, ChangedDatas)
        Next

        CutbedChangeProcess(AllDatas) '處理剪床訊號

        IsFirstIn = False
        Return ReturnValue
    End Function

#Region "焊道變動資料記錄處理 函式:StationConnectChangeProcess"
    Public Shared TagChangeForAPLProcessMut As New Mutex()
    ''' <summary>
    ''' 焊道變動資料記錄處理
    ''' </summary>
    ''' <param name="AllDatas"></param>
    ''' <param name="ChangedDatas"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StationConnectChangeProcess(AllDatas As List(Of L2RealTimeTagDisplay), ChangedDatas As List(Of L2RealTimeTagDisplay)) As Boolean
        Dim ReturnValue As Integer
        Static PreInConnectID As String = "-1"
        Static PreOutConnectID As String = "-1"

        '還原預設值
        If WriteObjectRunningProcessStatus.TryGetValue("PreInConnectID", PreInConnectID) Then
            WriteObjectRunningProcessStatus.Remove("PreInConnectID")
        End If
        If WriteObjectRunningProcessStatus.TryGetValue("PreOutConnectID", PreOutConnectID) Then
            WriteObjectRunningProcessStatus.Remove("PreOutConnectID")
        End If
        If PreInConnectID <= 0 Then
            PreInConnectID = -1
        End If
        If PreOutConnectID <= 0 Then
            PreOutConnectID = -1
        End If


        Try
            TagChangeForAPLProcessMut.WaitOne()

            Dim APLChangedTags As List(Of L2RealTimeTagDisplay) = (From A In ChangedDatas Where A.LineName.Substring(0, 4) = LineName Select A).ToList
            '入口焊道編號訊號
            Dim StoveInTag As L2RealTimeTagDisplay = (From A In AllDatas Where A.LineName.Trim = LineName And A.TagName.Contains(".L2_TRCK_IN_FUR") Select A).FirstOrDefault
            '出口焊道編號訊號
            Dim StoveOutTag As L2RealTimeTagDisplay = (From A In AllDatas Where A.LineName.Trim = LineName And A.TagName.Contains(".L2_TRCK_OUT_FUR") Select A).FirstOrDefault

            If IsNothing(StoveInTag) OrElse IsNothing(StoveOutTag) Then
                Return 0
            End If
            Dim TheStationRunnionState As OperationPCRunningState = Nothing
            Select Case True
                Case LineName = "APL1"
                    TheStationRunnionState = OperationPCRunningState.GetOperationPCRunningStateForLineName(OperationPCRunningState.OperationLineNameEnum.APL1)
                Case LineName = "APL2"
                    TheStationRunnionState = OperationPCRunningState.GetOperationPCRunningStateForLineName(OperationPCRunningState.OperationLineNameEnum.APL2)
            End Select
            Dim IsLineUpRunning As Nullable(Of Boolean) = Nothing
            '入口端上/下進爐訊號
            Dim LineUpDownTag As L2RealTimeTagDisplay = (From A In AllDatas Where A.LineName.Trim = LineName And (A.TagName.Contains("L2_UP_LINE") Or A.TagName.Contains("L2_DOWN_LINE")) AndAlso A.TagIntValue <> 0 Select A).FirstOrDefault

            If Not IsNothing(LineUpDownTag) AndAlso LineUpDownTag.TagName.Contains("L2_UP_LINE") Then
                IsLineUpRunning = True
            End If
            If Not IsNothing(LineUpDownTag) AndAlso LineUpDownTag.TagName.Contains("L2_DOWN_LINE") Then
                IsLineUpRunning = False
            End If
            Dim NowTime As DateTime = Now
            'Static PreInConnectID As String = "-1"
            'Static PreOutConnectID As String = "-1"
            Dim QryString As String = Nothing

            '高可用性狀態處理(對內寫入)
            For Each EachItem As KeyValuePair(Of String, String) In WriteObjectRunningProcessStatus
                Select Case True
                    Case EachItem.Key.ToUpper = "PreInConnectID"
                        PreInConnectID = EachItem.Value
                    Case EachItem.Key.ToUpper = "PreOutConnectID"
                        PreOutConnectID = EachItem.Value
                End Select
            Next
            WriteObjectRunningProcessStatus.Remove("PreInConnectID") : WriteObjectRunningProcessStatus.Remove("PreOutConnectID")

            If CType(PreInConnectID, Long) < 0 Then
                '1.第一次啟動,只記錄現況,判斷情況,不做資料存檔處理
                PreInConnectID = CType(StoveInTag.TagIntValue, Long).ToString.Trim
                PreOutConnectID = CType(StoveOutTag.TagIntValue, Long).ToString.Trim
                If PreInConnectID = PreOutConnectID Then
                    QryString = "Select * from L2APLInOutStoveRecord Where LineName='" & LineName & "' and ConnectID='" & PreOutConnectID & "' and ConnectInStoveTime >= '" & Format(NowTime.AddDays(-3).Date, "yyyy/MM/dd") & "' Order by ConnectInStoveTime desc"
                    PreOutCoilItem = (From A In L2APLInOutStoveRecord.CDBSelect(Of L2APLInOutStoveRecord)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString) Select A).FirstOrDefault
                Else
                    QryString = "Select * from L2APLInOutStoveRecord Where LineName='" & LineName & "' and (ConnectID='" & PreOutConnectID & "' or ConnectID='" & PreInConnectID & "') and ConnectInStoveTime >= '" & Format(NowTime.AddDays(-3).Date, "yyyy/MM/dd") & "' Order by ConnectInStoveTime desc"
                    Dim SearchResult As List(Of L2APLInOutStoveRecord) = L2APLInOutStoveRecord.CDBSelect(Of L2APLInOutStoveRecord)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                    PreOutCoilItem = (From A In SearchResult Where A.ConnectID.Trim = PreOutConnectID.Trim Select A).FirstOrDefault
                    PreInCoilItem = (From A In SearchResult Where A.ConnectID.Trim = PreInConnectID.Trim Select A).FirstOrDefault
                End If

                Select Case True
                    Case PreInConnectID = PreOutConnectID AndAlso IsNothing(PreOutCoilItem)
                        PreOutCoilItem = New L2APLInOutStoveRecord
                        With PreOutCoilItem
                            .LineName = LineName
                            .ConnectID = Format(StoveOutTag.TagIntValue, "00000")
                            .ConnectInStoveTime = NowTime
                            .ConnectOutStoveTime = NowTime
                            .CoilOutStoveTime = NowTime
                            .CoilEndTime = NowTime
                            If Not IsNothing(TheStationRunnionState) AndAlso TheStationRunnionState.RunningProcessCoils.Trim.Length > 0 Then
                                .ConnectInCoilNumber = TheStationRunnionState.RunningProcessCoils.Split(";")(0).Trim
                            End If
                            ReturnValue = .CDBSave
                        End With
                        PreInCoilItem = PreOutCoilItem
                    Case PreInConnectID <> PreOutConnectID
                        If IsNothing(PreOutCoilItem) Then
                            PreOutCoilItem = New L2APLInOutStoveRecord
                            With PreOutCoilItem
                                .LineName = LineName
                                .ConnectID = Format(StoveOutTag.TagIntValue, "00000")
                                .NextConnectID = Format(StoveInTag.TagIntValue, "00000")
                                .ConnectInStoveTime = NowTime
                                .ConnectOutStoveTime = NowTime
                                .CoilOutStoveTime = NowTime
                                .CoilEndTime = NowTime
                                If Not IsNothing(TheStationRunnionState) AndAlso TheStationRunnionState.RunningProcessCoils.Trim.Length > 0 Then
                                    .ConnectInCoilNumber = TheStationRunnionState.RunningProcessCoils.Split(";")(0).Trim
                                End If
                                ReturnValue = .CDBSave
                            End With
                        End If

                        If IsNothing(PreInCoilItem) Then
                            PreInCoilItem = New L2APLInOutStoveRecord
                            With PreInCoilItem
                                .LineName = LineName
                                .ConnectID = Format(StoveInTag.TagIntValue, "00000")
                                .ConnectInStoveTime = NowTime
                                .ConnectOutStoveTime = NowTime
                                .CoilOutStoveTime = NowTime
                                .CoilEndTime = NowTime
                                If Not IsNothing(IsLineUpRunning) AndAlso Not IsNothing(TheStationRunnionState) Then
                                    Select Case True
                                        Case IsLineUpRunning = True AndAlso TheStationRunnionState.Line1WaitProcessCoils.Trim.Length > 0
                                            .ConnectInCoilNumber = TheStationRunnionState.Line1WaitProcessCoils.Split(";")(0).Trim
                                        Case IsLineUpRunning = False AndAlso TheStationRunnionState.Line2WaitProcessCoils.Trim.Length > 0
                                            .ConnectInCoilNumber = TheStationRunnionState.Line2WaitProcessCoils.Split(";")(0).Trim
                                    End Select
                                End If
                                ReturnValue = .CDBSave
                            End With
                        End If

                End Select
                Return 0
            End If

            Dim InConnectID As String = Format(CType(StoveInTag.TagIntValue, Long), "00000")
            Dim OutConnectID As String = Format(CType(StoveOutTag.TagIntValue, Long), "00000")
            If InConnectID = PreInConnectID AndAlso OutConnectID = PreOutConnectID Then
                Return 0    '焊道編號無發生變化,離開(不進行存檔處理)
            End If

            '2.焊道編號已發生變化
            If InConnectID <> OutConnectID Then
                '2.1新焊道編號進入爐區,新建立一筆焊道進入爐區資料
                Dim NewCoilItem As New L2APLInOutStoveRecord
                With NewCoilItem
                    .LineName = LineName
                    .ConnectID = Format(StoveInTag.TagIntValue, "00000")
                    .ConnectInStoveTime = NowTime
                    .ConnectOutStoveTime = NowTime
                    .CoilOutStoveTime = NowTime
                    .CoilEndTime = NowTime
                    If Not IsNothing(IsLineUpRunning) AndAlso Not IsNothing(TheStationRunnionState) Then
                        Select Case True
                            Case IsLineUpRunning = True AndAlso TheStationRunnionState.Line1WaitProcessCoils.Trim.Length > 0
                                .ConnectInCoilNumber = TheStationRunnionState.Line1WaitProcessCoils.Split(";")(0).Trim
                            Case IsLineUpRunning = False AndAlso TheStationRunnionState.Line2WaitProcessCoils.Trim.Length > 0
                                .ConnectInCoilNumber = TheStationRunnionState.Line2WaitProcessCoils.Split(";")(0).Trim
                        End Select
                    End If
                    ReturnValue = .CDBSave
                End With
                If Not IsNothing(PreOutCoilItem) Then
                    PreOutCoilItem.NextConnectID = NewCoilItem.ConnectID
                    PreOutCoilItem.CDBSave()
                End If
                PreInCoilItem = NewCoilItem
            Else
                '2.2焊道編號出爐區
                If IsNothing(PreOutCoilItem) Then
                    QryString = "Select * from L2APLInOutStoveRecord Where LineName='" & LineName & "' and ConnectID='" & PreOutConnectID & "' and NextConnectID='" & OutConnectID & "' and ConnectInStoveTime >= '" & Format(Now.AddDays(-3).Date, "yyyy/MM/dd") & "' Order by ConnectInStoveTime desc"
                    Dim SearchResult As List(Of L2APLInOutStoveRecord) = L2APLInOutStoveRecord.CDBSelect(Of L2APLInOutStoveRecord)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                    If SearchResult.Count > 0 Then
                        PreOutCoilItem = SearchResult(0)
                    End If
                End If
                If Not IsNothing(PreOutCoilItem) Then
                    With PreOutCoilItem
                        .CoilOutStoveTime = NowTime
                        ReturnValue = .CDBSave()
                    End With
                End If

                If IsNothing(PreInCoilItem) Then
                    QryString = "Select * from L2APLInOutStoveRecord Where LineName='" & LineName & "' and ConnectID='" & PreInConnectID & "' and ConnectInStoveTime >= '" & Format(Now.AddDays(-3).Date, "yyyy/MM/dd") & "' Order by ConnectInStoveTime desc"
                    Dim SearchResult As List(Of L2APLInOutStoveRecord) = L2APLInOutStoveRecord.CDBSelect(Of L2APLInOutStoveRecord)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                    If SearchResult.Count > 0 Then
                        PreInCoilItem = SearchResult(0)
                    End If
                End If
                If Not IsNothing(PreInCoilItem) Then
                    With PreInCoilItem
                        .ConnectOutStoveTime = NowTime
                        ReturnValue = .CDBSave
                    End With
                End If

                PreOutCoilItem = PreInCoilItem
            End If

        Catch ex As Exception
            Dim MailContent As New System.Text.StringBuilder
            MailContent.Append("軋鋼L2常駐程式資料異常通知" & vbNewLine & "錯誤訊息:" & ex.ToString)
            MailContent.Append(vbNewLine & "PreInCoilItem update:" & PreInCoilItem.CDBUpdateSQLString)
            MailContent.Append(vbNewLine & "PreInCoilItem insert:" & PreInCoilItem.CDBInsertSQLString)
            MailContent.Append(vbNewLine & "PreOutCoilItem update:" & PreOutCoilItem.CDBUpdateSQLString)
            MailContent.Append(vbNewLine & "PreOutCoilItem insert:" & PreOutCoilItem.CDBInsertSQLString)
            SendEmail(New MailAddress("kuku@mail.tangeng.com.tw", "系統發送"), New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"), "軋鋼L2常駐程式資料異常通知!", MailContent.ToString)
        Finally
            '高可用性狀態處理(對外輸出)
            If Not String.IsNullOrEmpty(PreInConnectID) AndAlso PreInConnectID.Trim.Length > 0 Then
                ReadObjectRunningProcessStatus.Item("PreInConnectID") = PreInConnectID
            End If
            If Not String.IsNullOrEmpty(PreOutConnectID) AndAlso PreOutConnectID.Trim.Length > 0 Then
                ReadObjectRunningProcessStatus.Item("PreOutConnectID") = PreOutConnectID
            End If
            TagChangeForAPLProcessMut.ReleaseMutex()
        End Try


        Return ReturnValue

    End Function
#End Region
#Region "剪床變動資料記錄處理 函式:CutbedChangeProcess"
    ''' <summary>
    ''' 剪床變動資料記錄處理
    ''' </summary>
    ''' <param name="AllDatas"></param>
    ''' <remarks></remarks>
    Private Sub CutbedChangeProcess(AllDatas As List(Of L2RealTimeTagDisplay))
        '剪床上升訊號
        Dim CutbedUpTag As L2RealTimeTagDisplay = (From A In AllDatas Where A.LineName.Trim = LineName And A.TagName.Contains("_XSHR_UP") Select A).FirstOrDefault

        Dim TheStationRunnionState As OperationPCRunningState = Nothing
        Select Case True
            Case LineName = "APL1"
                TheStationRunnionState = OperationPCRunningState.GetOperationPCRunningStateForLineName(OperationPCRunningState.OperationLineNameEnum.APL1)
            Case LineName = "APL2"
                TheStationRunnionState = OperationPCRunningState.GetOperationPCRunningStateForLineName(OperationPCRunningState.OperationLineNameEnum.APL2)
        End Select

        If IsNothing(CutbedUpTag) OrElse IsNothing(TheStationRunnionState) Then
            Exit Sub
        End If

        '剪床訊號處理
        Dim NowTime As DateTime = Now
        Static LastCutbedUpTime As DateTime = NowTime.AddMinutes(-3) '記錄最終剪床上升訊號之時間
        '還原預設值
        Dim DateTemp As String = ""
        If WriteObjectRunningProcessStatus.TryGetValue("LastCutbedUpTime", DateTemp) Then
            LastCutbedUpTime = CType(DateTemp, DateTime)
            WriteObjectRunningProcessStatus.Remove("LastCutbedUpTime")
        End If


        '高可用性狀態處理(對內寫入)
        Dim DataTemp As String = ""
        If WriteObjectRunningProcessStatus.TryGetValue("LastCutbedUpTime", DataTemp) Then
            LastCutbedUpTime = CType(DataTemp, DateTime)
            WriteObjectRunningProcessStatus.Remove("LastCutbedUpTime")
        End If


        If CType(CutbedUpTag.TagIntValue, Integer) <> 0 Then
            If NowTime.Subtract(LastCutbedUpTime).TotalMinutes() > 2 Then
                Dim QryString = "Select * from L2APLInOutStoveRecord Where LineName='" & LineName & "' and CoilEndTime=ConnectInStoveTime and ConnectInStoveTime<>ConnectOutStoveTime and ConnectInStoveTime<>CoilOutStoveTime and NextConnectID<>'' Order by ConnectInStoveTime desc"
                Dim SearchResult As List(Of L2APLInOutStoveRecord) = L2APLInOutStoveRecord.CDBSelect(Of L2APLInOutStoveRecord)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)

                '新的剪床訊號產生
                If Not IsNothing(PreOutCoilItem) AndAlso SearchResult.Count > 0 Then
                    SearchResult(0).CoilEndTime = NowTime
                    If TheStationRunnionState.RunningProcessCoils.Trim.Length > 0 Then
                        SearchResult(0).CoilEndCoilNumber = TheStationRunnionState.RunningProcessCoils.Split(";")(0).Trim
                    End If
                    SearchResult(0).CDBSave()
                End If
            End If
            LastCutbedUpTime = NowTime

            '高可用性狀態處理(對外輸出)
            ReadObjectRunningProcessStatus.Item("LastCutbedUpTime") = Format(LastCutbedUpTime, "yyyy/MM/dd HH:mm:ss")
        End If
    End Sub
#End Region
#Region "讀取現行處理狀態 屬性:ReadObjectRunningProcessStatus"
    Private _ReadObjectRunningProcessStatus As New Dictionary(Of String, String)
    ''' <summary>
    ''' 讀取現行處理狀態(格式:變數名稱:變數值)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>高可用性狀態下將主機之狀態輸出做為下一台接手主機之預設值</remarks>
    Property ReadObjectRunningProcessStatus As Dictionary(Of String, String) Implements ITagChangeForProcess.ReadObjectRunningProcessStatus
        Get
            Return _ReadObjectRunningProcessStatus
        End Get
        Private Set(value As Dictionary(Of String, String))
            _ReadObjectRunningProcessStatus = value
        End Set
    End Property
#End Region
#Region "寫入現行處理狀態 屬性:WriteObjectRunningProcessStatus"
    Property _WriteObjectRunningProcessStatus As New Dictionary(Of String, String)
    ''' <summary>
    ''' 現行處理狀態(格式:變數名稱:變數值)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>高可用性狀態下移至轉本機時,將前一台主機之狀態寫入做為預設值</remarks>
    Property WriteObjectRunningProcessStatus As Dictionary(Of String, String) Implements ITagChangeForProcess.WriteObjectRunningProcessStatus
        Get
            Return _WriteObjectRunningProcessStatus
        End Get
        Set(value As Dictionary(Of String, String))
            _WriteObjectRunningProcessStatus = value
        End Set
    End Property
#End Region
    '#Region "將寫入現行處理狀態預設值寫入變數 函式:SetWriteObjectRunningProcessStatusToVariable"
    '    Private Sub SetWriteObjectRunningProcessStatusToVariable(ByVal ValueableName As String, ByRef Valueable As Object)
    '        For Each EachItem As KeyValuePair(Of String, String) In WriteObjectRunningProcessStatus

    '        Next
    '        WriteObjectRunningProcessStatus.TryGetValue()
    '    End Sub
    '#End Region

    Private Sub SendEmail(ByVal FromAddress As MailAddress, ByVal ToAddress As MailAddress, ByVal Subject As String, ByVal Content As String)
        Dim MailObj As New PublicClassLibrary.MISMail
        With MailObj
            .FromMailAddress = FromAddress
            .ToMailAddress = {ToAddress}.ToList
            .SendMail(Subject, Content)
        End With
    End Sub

    Sub New(ByVal SetLineName As String)
        LineName = SetLineName
    End Sub

End Class
