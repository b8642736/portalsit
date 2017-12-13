Namespace SQLServer
    Namespace PPS100LB
        ''' <summary>
        ''' P.P排程檔流程配接器
        ''' </summary>
        ''' <remarks></remarks>
        Public Class PPSSHAPFFlowAdapter
            'Dim SQLAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            Dim AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.WebService)

            Sub New(ByVal SeCoilNumber As String)
                CoilFullNumber = SeCoilNumber.Trim.Replace("-", Nothing).PadRight(10)
                FinalALLPPSSHAPFsDataSourceMode = FinalALLPPSSHAPFsModeEnum.AS400VsSQLServerMerge
            End Sub
            Sub New(ByVal SeCoilNumber As String, ByVal SetFinalALLPPSSHAPFsDataSourceMode As FinalALLPPSSHAPFsModeEnum)
                CoilFullNumber = SeCoilNumber.Trim.Replace("-", Nothing).PadRight(10)
                FinalALLPPSSHAPFsDataSourceMode = SetFinalALLPPSSHAPFsDataSourceMode
            End Sub


#Region "鋼捲完整編號 屬性:CoilFullNumber"
            Private _CoilFullNumber As String
            ''' <summary>
            ''' 鋼捲完整編號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilFullNumber() As String
                Get
                    Return _CoilFullNumber
                End Get
                Set(ByVal value As String)
                    _CoilFullNumber = value
                    FirstPPSSHAPF = Nothing
                End Set
            End Property
#End Region
#Region "鋼捲號碼 屬性:SHA01"
            ''' <summary>
            ''' 鋼捲號碼
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property SHA01 As String
                Get
                    Return CoilFullNumber.Substring(0, 5)
                End Get
            End Property
#End Region
#Region "分捲號碼 屬性:SHA02"
            ''' <summary>
            ''' 分捲號碼
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property SHA02 As String
                Get
                    Return CoilFullNumber.Substring(5, 5)
                End Get
            End Property
#End Region
#Region "鋼捲完整編號是否已有分捲行為 屬性:IsCoilFullNumberAlreadyHaveSubBreakNumber"
            ''' <summary>
            ''' 鋼捲完整編號是否已有分捲行為
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property IsCoilFullNumberAlreadyHaveSubBreakNumber As Boolean
                Get
                    Dim myCoilFullNumber As String = CoilFullNumber.Trim
                    For Each EachItem As IPPS100LB.IPPSSHAPF In Me.FinalALLPPSSHAPFs
                        Dim EachItemCoilFullNumber As String = EachItem.SHA01.Trim & EachItem.SHA02.Trim
                        If EachItemCoilFullNumber.Length > myCoilFullNumber.Length AndAlso EachItemCoilFullNumber.Substring(0, myCoilFullNumber.Length) = myCoilFullNumber Then
                            Return True
                        End If
                    Next
                    Return False
                End Get
            End Property
#End Region
#Region "伺服器時間 屬性:WebServerNowTime"
            Shared WSAdapter As SQLServerSQLQueryAdapter
            Shared PCTimeWithServerTimeSpan As TimeSpan = New TimeSpan(0)
            Shared LastGetDataTime As DateTime = New DateTime(2000, 1, 1)
            ''' <summary>
            ''' 伺服器時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property WebServerNowTime As DateTime
                Get
                    Dim ReturnValue As DateTime = Nothing
                    If Now.Subtract(LastGetDataTime) < New TimeSpan(0, 0, 5) Then
                        LastGetDataTime = Now
                        Return Now.Add(PCTimeWithServerTimeSpan)
                    End If
                    Try
                        ReturnValue = WSAdapter.WebServiceSQLQueryAdapter.GetServerTime()
                        PCTimeWithServerTimeSpan = Now.Subtract(ReturnValue)
                    Catch ex As Exception
                        Try
                            ReturnValue = WSAdapter.WebServiceSQLQueryAdapter.GetServerTime()
                            PCTimeWithServerTimeSpan = Now.Subtract(ReturnValue)
                        Catch ex1 As Exception
                            ReturnValue = Now
                        End Try
                    End Try
                    LastGetDataTime = Now
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "依鋼捲號碼第一筆PPSSHAPF 屬性:FirstPPSSHAPF"
            Private _FirstPPSSHAPF As IPPS100LB.IPPSSHAPF
            ''' <summary>
            ''' 依鋼捲號碼第一筆PPSSHAPF
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FirstPPSSHAPF() As IPPS100LB.IPPSSHAPF
                Get
                    If IsNothing(_FirstPPSSHAPF) Then
                        For Each EachItem As IPPS100LB.IPPSSHAPF In Me.FinalALLPPSSHAPFs
                            If EachItem.SHA04 = 0 AndAlso EachItem.SHA06.Trim = "BL" Then
                                _FirstPPSSHAPF = EachItem : Exit For
                            End If
                        Next
                    End If
                    Return _FirstPPSSHAPF
                End Get
                Private Set(ByVal value As IPPS100LB.IPPSSHAPF)
                    _FirstPPSSHAPF = value
                End Set
            End Property
#End Region
#Region "依鋼捲完整編號取得最終PPSSHAPF 屬性:CoilFullNumberForLastPPSSHAPF"
            Private _CoilFullNumberForLastPPSSHAPF As IPPS100LB.IPPSSHAPF
            ''' <summary>
            ''' 依鋼捲完整編號取得最終PPSSHAPF
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property CoilFullNumberForLastPPSSHAPF As IPPS100LB.IPPSSHAPF
                Get
                    Static LastAccessTime As DateTime = Now.AddSeconds(-5)
                    Dim ReturnValue As IPPS100LB.IPPSSHAPF = Nothing
                    If Now.Subtract(LastAccessTime).TotalSeconds > 1 Then
                        _CoilFullNumberForLastPPSSHAPF = Nothing
                    End If
                    If IsNothing(_CoilFullNumberForLastPPSSHAPF) Then
                        Dim MaxSha04Number As Integer = -1
                        For Each EachItem As IPPS100LB.IPPSSHAPF In Me.FinalALLPPSSHAPFs
                            If EachItem.SHA01.Trim = Me.SHA01.Trim AndAlso EachItem.SHA02.Trim = Me.SHA02.Trim AndAlso EachItem.SHA04 > MaxSha04Number Then
                                ReturnValue = EachItem
                                MaxSha04Number = EachItem.SHA04
                            End If
                        Next
                        LastAccessTime = Now
                    End If
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "依鋼捲完整編號取得計畫表面 屬性:CoilFullNumberPlanningFinish"
            ''' <summary>
            ''' 依鋼捲完整編號取得計畫表面(由鋼捲完整編號開始如找不到則往上層找)
            ''' </summary>
            ''' <param name="FindIPPSSHAPF"></param>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property CoilFullNumberPlanningFinish(Optional ByVal FindIPPSSHAPF As IPPS100LB.IPPSSHAPF = Nothing) As String
                Get
                    If Not IsNothing(FindIPPSSHAPF) Then
                        If FindIPPSSHAPF.SHA39.Trim.Length > 0 Then
                            Return FindIPPSSHAPF.SHA39.Trim
                        Else
                            Dim GetFaterPPSSHAPF = FaterPPSSHAPF(FindIPPSSHAPF)
                            If IsNothing(GetFaterPPSSHAPF) Then
                                Return Nothing
                            End If
                            Return CoilFullNumberPlanningFinish(GetFaterPPSSHAPF)
                        End If
                    End If

                    Dim GetCoilFullNumberForLastPPSSHAPF As IPPS100LB.IPPSSHAPF = Me.CoilFullNumberForLastPPSSHAPF
                    If Not IsNothing(GetCoilFullNumberForLastPPSSHAPF) Then
                        If GetCoilFullNumberForLastPPSSHAPF.SHA39.Trim.Length > 0 Then
                            Return Me.CoilFullNumberForLastPPSSHAPF.SHA39.Trim
                        Else
                            Return CoilFullNumberPlanningFinish(GetCoilFullNumberForLastPPSSHAPF)
                        End If
                    End If

                    Return Nothing
                End Get
            End Property

            Private Function FaterPPSSHAPF(ByVal SourcePPSSHAPF As IPPS100LB.IPPSSHAPF) As IPPS100LB.IPPSSHAPF
                If SourcePPSSHAPF.SHA04 <= 0 Then
                    Return Nothing
                End If
                For Each EachItem As IPPS100LB.IPPSSHAPF In FinalALLPPSSHAPFs
                    If SourcePPSSHAPF.SHA04 = EachItem.SHA04 AndAlso EachItem.SHA29.Trim = "*" AndAlso EachItem.SHA02.Trim = SourcePPSSHAPF.SHA02.Trim.Substring(0, SourcePPSSHAPF.SHA02.Trim.Length - 1) Then
                        Return EachItem
                    End If
                Next
                For Each EachItem As IPPS100LB.IPPSSHAPF In FinalALLPPSSHAPFs
                    If (SourcePPSSHAPF.SHA04 - 1) = EachItem.SHA04 AndAlso SourcePPSSHAPF.SHA02 = EachItem.SHA02 Then
                        Return EachItem
                    End If
                Next
                Return Nothing
            End Function
#End Region
#Region "已新增之PPSSHAPFs 屬性:AlreadyNewPPSSHAPFs"
            Private _AlreadyNewPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF) = Nothing
            ''' <summary>
            ''' 已新增之PPSSHAPFs
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property AlreadyNewPPSSHAPFs() As List(Of IPPS100LB.IPPSSHAPF)
                Get
                    Return _AlreadyNewPPSSHAPFs
                End Get
                Private Set(ByVal value As List(Of IPPS100LB.IPPSSHAPF))
                    _AlreadyNewPPSSHAPFs = value
                End Set
            End Property

#End Region
#Region "已新增PPSSHAPFs之前一站PPSSHAPF 屬性:PrePPSSHAPFForAlreadyNewPPSSHAPFs"
            Private _PrePPSSHAPFForAlreadyNewPPSSHAPFs As IPPS100LB.IPPSSHAPF
            ''' <summary>
            ''' 已新增PPSSHAPFs之前一站PPSSHAPF
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property PrePPSSHAPFForAlreadyNewPPSSHAPFs() As IPPS100LB.IPPSSHAPF
                Get
                    Return _PrePPSSHAPFForAlreadyNewPPSSHAPFs
                End Get
                Private Set(ByVal value As IPPS100LB.IPPSSHAPF)
                    _PrePPSSHAPFForAlreadyNewPPSSHAPFs = value
                End Set
            End Property
#End Region
#Region "重新推算重量(無使用) 方法:ReCountWeight"
            'Public Function ReCountWeight(ByVal ReCountNewPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF)) As Boolean
            '    Dim RemainPPSSHPFWeight As Double = 0
            '    Dim CurrentLastPPSSHAPF As List(Of IPPS100LB.IPPSSHAPF) = Me.CoilFullNumberForLastPPSSHAPF
            '    If CurrentLastPPSSHAPF.Count <> 1 Then
            '        Message = "鋼捲編號:" & Me.CoilFullNumber & " 最終資料必須只有一筆!"
            '        Return False
            '    Else
            '        RemainPPSSHPFWeight = CurrentLastPPSSHAPF(0).SHA17
            '    End If

            '    Dim NotReCountNewPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF) = GetNoInReCountNewPPSSHAPFs(ReCountNewPPSSHAPFs)
            '    For Each EachItem As IPPS100LB.IPPSSHAPF In NotReCountNewPPSSHAPFs
            '        RemainPPSSHPFWeight -= (EachItem.SHA17 + EachItem.SHA18 + EachItem.SHA19)
            '    Next

            '    Select Case True
            '        Case IsNothing(ReCountNewPPSSHAPFs) OrElse ReCountNewPPSSHAPFs.Count = 0
            '            Return False
            '        Case ReCountNewPPSSHAPFs.Count = 1
            '            PutTotalWeightToPPSSHAPF(RemainPPSSHPFWeight, ReCountNewPPSSHAPFs(0))
            '            Return True
            '        Case ReCountNewPPSSHAPFs.Count > 1
            '            Dim ForEachItemWeight As Double = RemainPPSSHPFWeight \ ReCountNewPPSSHAPFs.Count
            '            For Each EachItem As IPPS100LB.IPPSSHAPF In ReCountNewPPSSHAPFs

            '            Next
            '            Return True
            '    End Select

            '    Return (False)
            'End Function

            'Private Sub PutTotalWeightToPPSSHAPF(ByVal PutWeight As Double, ByRef PutPPSSHAPF As IPPS100LB.IPPSSHAPF)
            '    PutPPSSHAPF.SHA17 = PutWeight - PutPPSSHAPF.SHA18 - PutPPSSHAPF.SHA19
            'End Sub

            'Private Function GetNoInReCountNewPPSSHAPFs(ByVal ReCountNewPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF)) As List(Of IPPS100LB.IPPSSHAPF)
            '    Dim ReturnValues As New List(Of IPPS100LB.IPPSSHAPF)
            '    Dim IsInPPSSHAPFs As Boolean = False
            '    For Each EachItem As IPPS100LB.IPPSSHAPF In AlreadyNewPPSSHAPFs
            '        IsInPPSSHAPFs = False
            '        For Each EachItem1 As IPPS100LB.IPPSSHAPF In ReCountNewPPSSHAPFs
            '            If EachItem.SHA01 = EachItem.SHA01 AndAlso EachItem.SHA02 = EachItem.SHA02 AndAlso EachItem.SHA04 = EachItem.SHA04 Then
            '                IsInPPSSHAPFs = True : Exit For
            '            End If
            '        Next
            '        If IsInPPSSHAPFs = False Then
            '            ReturnValues.Add(EachItem)
            '        End If
            '    Next
            '    Return ReturnValues
            'End Function

#End Region
#Region "核對新增資料 方法:CheckAlreadyNewPPSSHAPFs"
            ''' <summary>
            ''' 核對新增資料
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function CheckAlreadyNewPPSSHAPFs() As Boolean
                If IsNothing(AlreadyNewPPSSHAPFs) OrElse AlreadyNewPPSSHAPFs.Count = 0 Then
                    Message = "沒有新增資料!"
                    Return False
                End If
                '核對重量
                Dim FatherPPSSHPFWeight As Double = 0
                Dim CurrentLastPPSSHAPF As List(Of IPPS100LB.IPPSSHAPF) = Me.CoilFullNumberForLastPPSSHAPF
                If CurrentLastPPSSHAPF.Count <> 1 Then
                    Message = "鋼捲編號:" & Me.CoilFullNumber & " 最終資料必須只有一筆!"
                    Return False
                Else
                    FatherPPSSHPFWeight = CurrentLastPPSSHAPF(0).SHA17
                    Dim NewDataTotalWeights As Double = 0
                    For Each EachItem As IPPS100LB.IPPSSHAPF In AlreadyNewPPSSHAPFs
                        NewDataTotalWeights += (EachItem.SHA17 + EachItem.SHA18 + EachItem.SHA19)
                    Next
                    If FatherPPSSHPFWeight <> NewDataTotalWeights Then
                        Message = "新增資料重量合計與前站重量不符:共" & IIf(FatherPPSSHPFWeight > NewDataTotalWeights, "短少", "多出") & Math.Abs(FatherPPSSHPFWeight - NewDataTotalWeights) & " 公斤"
                        Return False
                    End If
                End If
                '核對所有分捲後長度與重量是否合理
                For Each EachItem1 As IPPS100LB.IPPSSHAPF In AlreadyNewPPSSHAPFs
                    If (EachItem1.SHA17 + EachItem1.SHA18 + EachItem1.SHA19) <= 0 Then
                        Message = EachItem1.SHA01 & EachItem1.SHA02 & "重量不可小於或等於0!"
                        Return False
                    End If
                    For Each EachItem2 As IPPS100LB.IPPSSHAPF In AlreadyNewPPSSHAPFs
                        If EachItem1.SHA01 = EachItem2.SHA01 And EachItem1.SHA02 = EachItem2.SHA02 And EachItem1.SHA04 = EachItem2.SHA04 Then
                            Continue For
                        End If
                        If EachItem1.SHA16 >= EachItem2.SHA16 And (EachItem1.SHA17 + EachItem1.SHA18 + EachItem1.SHA19) >= (EachItem2.SHA17 + EachItem2.SHA18 + EachItem2.SHA19) Then
                            Continue For
                        End If
                        Select Case True
                            Case EachItem1.SHA16 >= EachItem2.SHA16 And (EachItem1.SHA17 + EachItem1.SHA18 + EachItem1.SHA19) >= (EachItem2.SHA17 + EachItem2.SHA18 + EachItem2.SHA19)
                                Continue For
                            Case EachItem1.SHA16 <= EachItem2.SHA16 And (EachItem1.SHA17 + EachItem1.SHA18 + EachItem1.SHA19) <= (EachItem2.SHA17 + EachItem2.SHA18 + EachItem2.SHA19)
                                Continue For
                        End Select
                        Message = EachItem1.SHA01 & EachItem1.SHA02 & " 與 " & EachItem2.SHA01 & EachItem2.SHA02 & " 之長度與重量不合理!"
                        Return False
                    Next
                Next
                Return True
            End Function

#End Region
#Region "訊息 屬性:Message"

            Private _Message As String = Nothing
            ''' <summary>
            ''' 訊息
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Message() As String
                Get
                    Return _Message
                End Get
                Private Set(ByVal value As String)
                    _Message = value
                End Set
            End Property

#End Region


#Region "依鋼捲完整編號建議下一階段所有ProcessSchedual 屬性:CoilFullNumberSuggestNextProcessScheduals"
            ''' <summary>
            ''' 依鋼捲完整編號建議下一階段所有ProcessSchedual
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property CoilFullNumberSuggestNextProcessScheduals As List(Of ProcessSchedual)
                Get
                    Return GetSuggestNextProcessScheduals()
                End Get
            End Property
#Region "取得某一P.P.排程檔建議下一階段所有ProcessSchedual 方法:GetSuggestNextProcessScheduals"
            ''' <summary>
            ''' 取得某一P.P.排程檔建議下一階段所有ProcessSchedual
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function GetSuggestNextProcessScheduals() As List(Of ProcessSchedual)
                'Dim GetSourcePPSSHAPF As IPPS100LB.IPPSSHAPF = Me.CoilFullNumberForLastPPSSHAPF
                Dim ReturnValue As New List(Of ProcessSchedual)
                Dim GetProcessSchedual As ProcessSchedual = Nothing
                GetProcessSchedual = Me.CoilFullNumberForLastPPSSHAPF.About_ProcessSchedual
                If Not IsNothing(GetProcessSchedual) Then
                    'PPSSHAPF 有記錄ProcessSchedual 故傳回建議下一站有那些
                    ReturnValue.AddRange(GetProcessSchedual.NextProcessSchedualEquipments)
                Else
                    'PPSSHAPF 無記錄ProcessSchedual, 故用反推方式推測,目前所有可能所處位置的下一站
                    For Each EachItem As ProcessSchedual In ProcessSchedual.GuessAS400DataNowInProcessScheduals(Me.CoilFullNumberForLastPPSSHAPF)
                        ReturnValue.AddRange(EachItem.NextProcessSchedualEquipments)
                    Next
                End If


                'For Each EachItem In GetAllLastPPSSHAPFs(Me.CoilFullNumberForLastPPSSHAPF)
                '    If EachItem.SHA28 = "*" Then
                '        '本筆資料作業未完成
                '        GetProcessSchedual = EachItem.About_ProcessSchedual
                '        If Not IsNothing(GetProcessSchedual) Then
                '            ''PPSSHAPF 有記錄ProcessSchedual 故傳回建議下一站有那些
                '            ReturnValue.AddRange(GetProcessSchedual.NextProcessSchedualEquipments)
                '            Continue For
                '        End If
                '        ReturnValue.AddRange(ProcessSchedual.GuessAS400DataNowInProcessScheduals(EachItem))
                '    Else
                '        '本筆資料作業已完成
                '        GetProcessSchedual = EachItem.About_ProcessSchedual
                '        If Not IsNothing(GetProcessSchedual) Then
                '            ''PPSSHAPF 有記錄ProcessSchedual 故傳回建議下一站有那些
                '            ReturnValue.AddRange(GetProcessSchedual.NextProcessSchedualEquipments)
                '            Continue For
                '        End If
                '        'PPSSHAPF 無記錄ProcessSchedual, 故用反推方式推測,目前所有可能所處位置的下一站
                '        For Each EachItem1 As ProcessSchedual In ProcessSchedual.GuessAS400DataNowInProcessScheduals(EachItem)
                '            ReturnValue.AddRange(EachItem1.NextProcessSchedualEquipments)
                '        Next
                '    End If
                'Next
                Return ReturnValue
            End Function
#End Region
#End Region
#Region "依PPSSHAPF產生新增PPSSHAFs 函式:NewPPSSHAPFs"
            ''' <summary>
            ''' 依PPSSHAPF產生新增PPSSHAFs
            ''' </summary>
            ''' <param name="RunProcessSchedual"></param>
            ''' <param name="BrokenNumber"></param>
            ''' <remarks></remarks>
            Public Function NewPPSSHAPFs(ByVal RunProcessSchedual As ProcessSchedual, Optional ByVal BrokenNumber As Integer = 0) As Boolean
                AlreadyNewPPSSHAPFs = Nothing
                If IsNothing(RunProcessSchedual) Then
                    Message = "目前製程不可為Nothing!"
                    Return False
                End If
                Dim CurrentLastPPSSHAPF As IPPS100LB.IPPSSHAPF = Me.CoilFullNumberForLastPPSSHAPF
                AlreadyNewPPSSHAPFs = RunProcessSchedual.CreateTheProcessPPSSHAPF(CurrentLastPPSSHAPF, BrokenNumber)
                If AlreadyNewPPSSHAPFs.Count > 0 Then
                    PrePPSSHAPFForAlreadyNewPPSSHAPFs = CurrentLastPPSSHAPF
                    Return True
                End If
                PrePPSSHAPFForAlreadyNewPPSSHAPFs = Nothing
                Return False
            End Function
#End Region
#Region "依RunProcessData產生新增PPSSHAFs 函式:NewPPSSHAPFs"
            ''' <summary>
            ''' 依RunProcessData產生新增PPSSHAFs
            ''' </summary>
            ''' <param name="RunProcessSchedual"></param>
            ''' <param name="RunProcessData"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function NewPPSSHAPFs(ByVal RunProcessSchedual As ProcessSchedual, ByVal RunProcessData As List(Of RunProcessData)) As Boolean
                If RunProcessData.Count = 0 OrElse NewPPSSHAPFs(RunProcessSchedual, RunProcessData.Count - 1) = False Then
                    Return False
                End If
                Dim ReturnValue As New List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF)
                Dim TransIndex As Integer = 0
                For Each EachItem As RunProcessData In RunProcessData
                    EachItem.AboutRunProcessSchedual = RunProcessSchedual
                    ReturnValue.Add(EachItem.ReplacePPSSHAPFForRunProcessData(AlreadyNewPPSSHAPFs(TransIndex)))
                    TransIndex += 1
                Next
                AlreadyNewPPSSHAPFs = ReturnValue
                Return True
            End Function
#End Region


#Region "目前正在執行的OperationPCRunningState 屬性:CurrentOperationPCRunningState"
            ''' <summary>
            ''' 目前正在執行的OperationPCRunningState
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared ReadOnly Property CurrentOperationPCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState
                Get
                    Dim ReturnValue = TheMachinePCRunningState
                    If IsNothing(ReturnValue) Then
                        Return Nothing
                    End If
                    '判斷本機狀態是否為ClientRemote狀態.如果是則回傳伺服端之OperationPCRunningState
                    If ReturnValue.ClientRunningMode = 1 Then
                        Return ReturnValue.AboutServerOperationPCRunningState
                    End If
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "本機狀態資訊 屬性:TheMachinePCRunningState"
            ''' <summary>
            ''' 本機狀態資訊
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared ReadOnly Property TheMachinePCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState
                Get
                    Dim SQLString As String = "Select * from OperationPCRunningState Where RunningPCIP='" & CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim & "'"
                    Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState) = CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
                    If SearchResult.Count = 0 Then
                        Return Nothing
                    End If
                    Return SearchResult(0)
                End Get
            End Property
#End Region


            '#Region "取某P.P.排程檔之子排程 方法:GetSubPPSSHAPFs"
            '            ''' <summary>
            '            ''' 取某P.P.排程檔之子排程(SHA29='*'分捲也算一階段排程)
            '            ''' </summary>
            '            ''' <param name="SourcePPSSHAPF"></param>
            '            ''' <returns></returns>
            '            ''' <remarks>SHA29='*'分捲也算一階段排程</remarks>
            '            Public Function GetSubPPSSHAPFs(Optional ByVal SourcePPSSHAPF As IPPS100LB.IPPSSHAPF = Nothing) As List(Of IPPS100LB.IPPSSHAPF)
            '                Dim GetSourcePPSSHAPF = SourcePPSSHAPF
            '                If IsNothing(GetSourcePPSSHAPF) Then
            '                    GetSourcePPSSHAPF = Me.FirstPPSSHAPF
            '                    If IsNothing(GetSourcePPSSHAPF) Then
            '                        Return New List(Of IPPS100LB.IPPSSHAPF)
            '                    End If
            '                End If
            '                Dim ReturnValue As New List(Of IPPS100LB.IPPSSHAPF)
            '                Dim SourcePPSSHAPFBorkenNO As String = GetSourcePPSSHAPF.SHA02.Trim
            '                If GetSourcePPSSHAPF.SHA29.Trim = "*" Then
            '                    '此筆資料為分捲資料
            '                    For Each EachItem In FinalALLPPSSHAPFs
            '                        If EachItem.SHA29.Trim <> "*" AndAlso EachItem.SHA02.Trim.PadRight(SourcePPSSHAPFBorkenNO.Length).Substring(0, SourcePPSSHAPFBorkenNO.Length) = SourcePPSSHAPFBorkenNO AndAlso EachItem.SHA04 = GetSourcePPSSHAPF.SHA04 Then
            '                            ReturnValue.Add(EachItem)
            '                        End If
            '                    Next
            '                Else
            '                    For Each EachItem In FinalALLPPSSHAPFs
            '                        If EachItem.SHA29.Trim = "*" AndAlso EachItem.SHA02.Trim.PadRight(SourcePPSSHAPFBorkenNO.Length).Substring(0, SourcePPSSHAPFBorkenNO.Length) = SourcePPSSHAPFBorkenNO AndAlso EachItem.SHA04 = (GetSourcePPSSHAPF.SHA04 + 1) Then
            '                            '子排程資料為分捲排程
            '                            ReturnValue.Add(EachItem):Exit For 
            '                        End If
            '                    Next
            '                    If ReturnValue.Count = 0 Then
            '                        '子排程資料非分捲排程
            '                        For Each EachItem In FinalALLPPSSHAPFs
            '                            If EachItem.SHA02.Trim.PadRight(SourcePPSSHAPFBorkenNO.Length).Substring(0, SourcePPSSHAPFBorkenNO.Length) = SourcePPSSHAPFBorkenNO AndAlso EachItem.SHA04 = (GetSourcePPSSHAPF.SHA04 + 1) Then
            '                                ReturnValue.Add(EachItem)
            '                            End If
            '                        Next
            '                    End If
            '                End If
            '                Return ReturnValue
            '            End Function
            '#End Region
            '#Region "取得某P.P.排程檔所有終端排程(含所有分捲) 屬性:GetAllLastPPSSHAPFs"
            '            ''' <summary>
            '            ''' 取得某P.P.排程檔所有終端排程(含所有分捲)
            '            ''' </summary>
            '            ''' <param name="SourcePPSSHAPF"></param>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            Public Function GetAllLastPPSSHAPFs(Optional ByVal SourcePPSSHAPF As IPPS100LB.IPPSSHAPF = Nothing) As List(Of IPPS100LB.IPPSSHAPF)
            '                Dim ReturnValue As New List(Of IPPS100LB.IPPSSHAPF)
            '                'For Each EachItem As IPPS100LB.IPPSSHAPF In GetSubPPSSHAPFs(SourcePPSSHAPF)
            '                '    Dim SubPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF) = GetSubPPSSHAPFs(EachItem)
            '                '    If SubPPSSHAPFs.Count > 0 Then
            '                '        For Each EachSubItem As IPPS100LB.IPPSSHAPF In SubPPSSHAPFs
            '                '            ReturnValue.AddRange(GetAllLastPPSSHAPFs(EachSubItem))
            '                '        Next
            '                '    Else
            '                '        ReturnValue.Add(EachItem)
            '                '    End If
            '                'Next
            '                Dim SubPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF) = GetSubPPSSHAPFs(SourcePPSSHAPF)
            '                If SubPPSSHAPFs.Count = 0 Then
            '                    If Not IsNothing(SourcePPSSHAPF) Then
            '                        ReturnValue.Add(SourcePPSSHAPF)
            '                    End If
            '                Else
            '                    For Each EachItem As IPPS100LB.IPPSSHAPF In GetSubPPSSHAPFs(SourcePPSSHAPF)
            '                        ReturnValue.AddRange(GetAllLastPPSSHAPFs(EachItem))
            '                    Next
            '                End If
            '                Return ReturnValue
            '            End Function
            '#End Region


#Region "依鋼捲號碼所有AS400與SQLServer合併後資料 屬性:FinalALLPPSSHAPFs"
            ''' <summary>
            ''' 依鋼捲號碼所有AS400與SQLServer合併後資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Overridable ReadOnly Property FinalALLPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF)
                Get
                    Dim AS400Datas As List(Of IPPS100LB.IPPSSHAPF) = Me.AboutAS400PPSSHAPFs
                    Dim SQLServerDatas As List(Of IPPS100LB.IPPSSHAPF) = Me.AboutSQLServerPPSSHAPFs
                    Dim RetrunValue As New List(Of IPPS100LB.IPPSSHAPF)

                    '以SQLServer資料優先為主,找不到再找AS400資料
                    Dim AddItems As New SortedDictionary(Of String, IPPS100LB.IPPSSHAPF)
                    If FinalALLPPSSHAPFsDataSourceMode = FinalALLPPSSHAPFsModeEnum.AS400VsSQLServerMerge OrElse FinalALLPPSSHAPFsDataSourceMode = FinalALLPPSSHAPFsModeEnum.SQLServerOnly Then
                        For Each EachItem As IPPS100LB.IPPSSHAPF In SQLServerDatas
                            Dim AddKey As String = EachItem.SHA01.Trim & "," & EachItem.SHA02.Trim & "," & EachItem.SHA04
                            AddItems.Add(AddKey, EachItem)
                        Next
                    End If
                    If FinalALLPPSSHAPFsDataSourceMode = FinalALLPPSSHAPFsModeEnum.AS400VsSQLServerMerge OrElse FinalALLPPSSHAPFsDataSourceMode = FinalALLPPSSHAPFsModeEnum.AS400Only Then
                        For Each EachItem As IPPS100LB.IPPSSHAPF In AS400Datas
                            Dim AddKey As String = EachItem.SHA01.Trim & "," & EachItem.SHA02.Trim & "," & EachItem.SHA04
                            '加入AS400有完成的資料且SQL Server不存在的資料
                            If AddItems.ContainsKey(AddKey) = False Then
                                AddItems.Add(AddKey, EachItem)
                            End If
                        Next
                    End If
                    RetrunValue.AddRange(AddItems.Values)
                    Return RetrunValue
                End Get
            End Property


            Public Enum FinalALLPPSSHAPFsModeEnum
                AS400VsSQLServerMerge = 0
                AS400Only = 1
                SQLServerOnly = 2
            End Enum
#End Region
#Region "依鋼捲號碼相關SQLServer PPSSHAPF資料 屬性:AboutSQLServerPPSSHAPFs"
            ''' <summary>
            ''' 相關SQLServer PPSSHAPF資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property AboutSQLServerPPSSHAPFs() As List(Of IPPS100LB.IPPSSHAPF)
                Get
                    Dim ReturnValue As New List(Of IPPS100LB.IPPSSHAPF)
                    Dim SQLString As String = "Select * from PPSSHAPF Where DataSourceType=0 AND SHA01='" & Me.SHA01 & "' Order by SHA04 "
                    For Each EachItem As IPPS100LB.IPPSSHAPF In SQLServer.PPS100LB.PPSSHAPF.CDBSelect(Of SQLServer.PPS100LB.PPSSHAPF)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
                        ReturnValue.Add(EachItem)
                    Next
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "依鋼捲號碼相關AS400 PPSSHAPF資料 屬性:AboutAS400PPSSHAPFs"
            ''' <summary>
            ''' 相關AS400 PPSSHAPF資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property AboutAS400PPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF)
                Get
                    Dim ReturnValue As New List(Of IPPS100LB.IPPSSHAPF)
                    Dim NowTime As DateTime = WebServerNowTime

                    Dim SQLString As String = Nothing
                    'AS400關機直接由SQLServer取得資料,假設AS400廿四小時無關機狀態
                    Try
                        If Me.SHA01.Substring(0, 1).ToUpper = "X" Then
                            SQLString = "Select * From @#PPS100LB.PPSSHAPF.HIPRO Where SHA01='" & Me.SHA01 & "' Order by SHA04"
                        Else
                            SQLString = "Select * From @#PPS100LB.PPSSHAPF Where SHA01='" & Me.SHA01 & "' Order by SHA04"
                        End If
                        For Each EachItem As IPPS100LB.IPPSSHAPF In CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                            ReturnValue.Add(EachItem)
                        Next
                    Catch ex As Exception
                        ReturnValue.Clear()
                    End Try

                    '假設AS400晚上有關機狀態
                    'If WebServerNowTime < WebServerNowTime.Date.AddHours(22).AddMinutes(30) OrElse WebServerNowTime > WebServerNowTime.Date.AddHours(6) Then
                    '    'AS400關機直接由SQLServer取得資料
                    '    Try
                    '        SQLString = "Select * From @#PPS100LB.PPSSHAPF Where SHA01='" & Me.SHA01 & "' Order by SHA04"
                    '        For Each EachItem As IPPS100LB.IPPSSHAPF In CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.WebService)
                    '            ReturnValue.Add(EachItem)
                    '        Next
                    '    Catch ex As Exception
                    '        ReturnValue.Clear()
                    '    End Try
                    'End If
                    'If ReturnValue.Count = 0 Then
                    '    SQLString = "Select * from PPSSHAPF Where DataSourceType=1 AND SHA01='" & Me.SHA01 & "' Order by SHA04 "
                    '    For Each EachItem As IPPS100LB.IPPSSHAPF In SQLServer.PPS100LB.PPSSHAPF.CDBSelect(Of SQLServer.PPS100LB.PPSSHAPF)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
                    '        ReturnValue.Add(EachItem)
                    '    Next
                    'End If
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "PPSSHAPF資料來源模式 屬性:FinalALLPPSSHAPFsDataSourceMode"

            Private _FinalALLPPSSHAPFsDataSourceMode As FinalALLPPSSHAPFsModeEnum = FinalALLPPSSHAPFsModeEnum.AS400VsSQLServerMerge
            ''' <summary>
            ''' PPSSHAPF資料來源模式
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FinalALLPPSSHAPFsDataSourceMode() As FinalALLPPSSHAPFsModeEnum
                Get
                    Return _FinalALLPPSSHAPFsDataSourceMode
                End Get
                Set(ByVal value As FinalALLPPSSHAPFsModeEnum)
                    _FinalALLPPSSHAPFsDataSourceMode = value
                End Set
            End Property

#End Region
#Region "相關執行中鋼捲(所有分捲)資料 屬性:AboutRunProcessDatas"
            ''' <summary>
            ''' 相關執行中鋼捲(所有分捲)資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property AboutRunProcessDatas As List(Of RunProcessData)
                Get
                    Dim LastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = Me.CoilFullNumberForLastPPSSHAPF
                    If IsNothing(LastRefPPSSHAPF) Then
                        'Throw New Exception("此鋼捲編號沒有可供參考的排程檔PPSSHAPF,固已無法編輯!")
                        Return New List(Of RunProcessData)
                    End If
                    Dim CurrentRunStationName As String = Nothing
                    If String.IsNullOrEmpty(CurrentRunStationName) Then
                        Dim GetCurrentOperationPCRunningState As OperationPCRunningState = CurrentOperationPCRunningState
                        If Not IsNothing(GetCurrentOperationPCRunningState) Then
                            CurrentRunStationName = GetCurrentOperationPCRunningState.DefaultUseStationName.Trim
                        End If
                    End If



                    Return RunProcessData.GetRunProcessDatasFromLastRefPPSSHAPF(LastRefPPSSHAPF)
                End Get
            End Property
#End Region
#Region "相關生技派工記錄 屬性:AboutCoilMoveState"
            Private _AboutCoilMoveState As CoilMoveState
            ''' <summary>
            ''' 相關生技派工記錄
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            ReadOnly Property AboutCoilMoveState As CompanyORMDB.SQLServer.PPS100LB.CoilMoveState
                Get
                    If IsNothing(_AboutCoilMoveState) Then
                        Dim LastRefPPSSHAPF As IPPS100LB.IPPSSHAPF = Me.CoilFullNumberForLastPPSSHAPF
                        If IsNothing(LastRefPPSSHAPF) Then
                            Return Nothing
                        End If
                        Dim SearchTime As Nullable(Of DateTime) = Nothing
                        If IsNothing(SearchTime) AndAlso LastRefPPSSHAPF.SHA11 <> 0 Then
                            SearchTime = New CompanyORMDB.AS400DateConverter(CType(LastRefPPSSHAPF.SHA11, Integer)).DateValue
                        End If
                        If IsNothing(SearchTime) AndAlso LastRefPPSSHAPF.SHA21 <> 0 Then
                            SearchTime = New CompanyORMDB.AS400DateConverter(CType(LastRefPPSSHAPF.SHA21, Integer)).DateValue
                        End If
                        If IsNothing(SearchTime) Then
                            SearchTime = Now
                        End If
                        Dim CleintIP As String = PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim
                        Dim QryString As String = "Select * from CoilMoveState Where RunCoilFullNumber='" & Me.CoilFullNumber.Trim & "' AND RunStationPCIP='" & CleintIP & "' AND SQLServerTime>='" & SearchTime.Value.AddYears(-2) & "' AND SQLServerTime<='" & SearchTime.Value.AddYears(2) & "'"
                        Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.CoilMoveState) = CompanyORMDB.SQLServer.PPS100LB.CoilMoveState.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.CoilMoveState)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                        If SearchResult.Count = 0 Then
                            Return Nothing
                        End If
                        _AboutCoilMoveState = SearchResult(0)
                    End If
                    Return _AboutCoilMoveState
                End Get
            End Property
#End Region



            '#Region "儲存已新增之PPSSHAPFs 方法:SavePPSSHAPFs"
            '            Public Function SavePPSSHAPFs() As Integer

            '            End Function
            '#End Region
            '#Region "刪除PPSSHAPFs 方法:DeletePPSSHAPFs"
            '            Public Function DeletePPSSHAPFs() As Integer

            '            End Function
            '#End Region

        End Class

    End Namespace
End Namespace
