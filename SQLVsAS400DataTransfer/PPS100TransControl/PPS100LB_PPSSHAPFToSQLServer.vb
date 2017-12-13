Public Class PPS100LB_PPSSHAPFToSQLServer
    Implements IDBTranslater

#Region "轉換AS400資料至SQL Server資料庫 方法:ConvertAS400ToSQLServer"

    Private Function ConvertAS400ToSQLServer(Optional ByVal SchedualObject As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan = Nothing) As String
        '新增一筆資料表示已正在轉換
        Dim InsertObject As New CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlanLog
        With InsertObject
            Dim NowTime As DateTime = Now
            .JobName = "PPS100LB_PPSSHAPFToSQLServer"
            If IsNothing(SchedualObject) Then
                .SchedualType = 2   '此時間為非排程引發的轉換(特定時間轉換)
                .SchedualRunTime = NowTime
                .RunTime = NowTime
            Else
                .SchedualType = SchedualObject.SchedualType
                .SchedualRunTime = SchedualObject.SchedualRunTime
                .RunTime = CType(Format(NowTime, "yyyy/MM/dd ") & Format(SchedualObject.SchedualRunTime, "HH:mm:ss"), DateTime)
            End If
            .RunServerName = My.Computer.Name
        End With
        InsertObject.CDBInsert()

        Dim FieldNameString As String = Nothing
        For FieldNameNumber As Integer = 1 To 39
            FieldNameString &= IIf(String.IsNullOrEmpty(FieldNameString), Nothing, ",") & "SHA" & Format(FieldNameNumber, "00")
        Next


        Dim QryString As String = "Select " & FieldNameString & " From @#PPS100LB.PPSSHAPF Where SHA01 IN (Select Distinct SHA01 FROM @#PPS100LB.PPSSHAPF Where Sha28<>'*') AND SHA01<>'     ' "
        'Dim QryString As String = "Select " & FieldNameString & " From @#PPS100LB.PPSSHAPF Where SHA01 ='F7768'"
        Dim ProcStartTime As DateTime = Now
        Dim AS400Datas As DataTable = (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)).SelectQuery


        Dim InsertQryStrings As New List(Of String)
        For Each EachData As DataRow In AS400Datas.Rows
            Dim FieldValueString As String = Nothing
            For Each EachColumn As DataColumn In AS400Datas.Columns
                FieldValueString &= IIf(String.IsNullOrEmpty(FieldValueString), Nothing, ",")
                If EachColumn.DataType Is GetType(String) Then
                    FieldValueString &= "'" & CType(EachData.Item(EachColumn), String) & "'"
                Else
                    FieldValueString &= CType(EachData.Item(EachColumn), String)
                End If

            Next
            InsertQryStrings.Add("Insert into PPSSHAPF_AS400ConvertTemp (" & FieldNameString & ") Values (" & FieldValueString & ")")
        Next
        Dim ReturnValue As String = Nothing
        Dim SQLServerAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Dim ProcEndTime As DateTime = Now
        ReturnValue = "已由AS400查詢資料並清除SQLServer PPSSHAPF_AS400ConvertTemp 暫存區 合計" & SQLServerAdapter.ExecuteNonQuery("Delete From PPSSHAPF_AS400ConvertTemp") & " 筆 花費時間:" & ProcEndTime.Subtract(ProcStartTime).TotalSeconds & " 秒"
        Dim SuccessInsertCount As Integer = 0
        Dim FailInsertString As String = Nothing
        For Each EachItem As String In InsertQryStrings
            Try
                SuccessInsertCount += SQLServerAdapter.ExecuteNonQuery(EachItem)
            Catch ex As Exception
                FailInsertString &= IIf(String.IsNullOrEmpty(FailInsertString), Nothing, vbNewLine & vbNewLine) & EachItem
            End Try
        Next
        ProcStartTime = Now
        ReturnValue &= vbNewLine & "已成功將" & SuccessInsertCount & " 筆資料由 AS400 PPS100LB/PPSSHAPF 轉至 SQLServer PPSSHAPF_AS400ConvertTemp 暫存區"
        ReturnValue &= vbNewLine & "已清除SQLServer PPSSHAPF 正式區 合計" & SQLServerAdapter.ExecuteNonQuery("Delete From PPSSHAPF Where DataSourceType=1 ") & " 筆"
        ReturnValue &= vbNewLine & "已成功將" & SQLServerAdapter.ExecuteNonQuery("Insert into PPSSHAPF Select *, 1 AS IsTransToAS400, 1 AS DataSourceType, '' AS FK_ProcessSchedualID, '' AS SavePCIP  From PPSSHAPF_AS400ConvertTemp") & " 筆資料由 SQLServer PPSSHAPF_AS400ConvertTemp 暫存區 轉至 SQLServer PPSSHAPF 正式區 "
        ProcEndTime = Now : ReturnValue &= " 花費時間:" & ProcEndTime.Subtract(ProcStartTime).TotalSeconds & " 秒"
        If String.IsNullOrEmpty(FailInsertString) Then
            ReturnValue &= vbNewLine & "無發生任何資料轉換錯誤!"
        Else
            ReturnValue &= vbNewLine & "發生" & InsertQryStrings.Count - SuccessInsertCount & " 筆 資料轉換錯誤指令詳訴如下:" & vbNewLine & FailInsertString
        End If

        InsertObject.RunLog = ReturnValue.Replace("'", "''") : InsertObject.CDBSave()

        Return ReturnValue
    End Function

#End Region

#Region "排程資料 屬性:SchedualDatas"

    ''' <summary>
    ''' 排程資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property SchedualDatas() As List(Of CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan)
        Get
            'If String.IsNullOrEmpty(My.Settings.Item("SchedualTimes")) OrElse CType(My.Settings.Item("SchedualTimes"), String).Trim.Length = 0 Then
            '    My.Settings.Item("SchedualTimes") = "2000/1/1 10:30:00@2000/1/1 22:30:00"
            'End If
            Dim ReturnValue As New List(Of CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan)
            Dim GetDatas As List(Of CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan) = CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan.CDBSelect(Of CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * From SQLVsAS400DBTransferPlan Where Jobname='PPS100LB_PPSSHAPFToSQLServer' Order by JobName, SchedualRunTime")
            If GetDatas.Count = 0 Then
                Dim InsertItem As New CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan
                With InsertItem
                    .JobName = "PPS100LB_PPSSHAPFToSQLServer"
                    .SchedualType = 1
                    .SchedualRunTime = New DateTime(2000, 1, 1, 22, 0, 0)
                End With
                If InsertItem.CDBSave > 0 Then
                    ReturnValue.Add(InsertItem)
                End If
            Else
                For Each EachItem As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan In GetDatas
                    ReturnValue.Add(EachItem)
                Next
            End If
            'For Each EachItem As String In CType(My.Settings.Item("SchedualTimes"), String).Split("@")
            '    ReturnValue.Add(CType(EachItem, DateTime))
            'Next
            Return ReturnValue
        End Get
        Set(ByVal value As List(Of CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan))

            For Each EachTime As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan In value
                EachTime.CDBSave()
            Next
            'Dim SQLAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "SQLVsAS400DataTransfer")
            'SQLAdapter.ExecuteNonQuery("Delete From SQLVsAS400DBTransferPlan Where Jobname='PPS100LB_PPSSHAPFToSQLServer' ")
            'For Each EachTime As DateTime In value
            '    Dim InsertItem As New CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan
            '    With InsertItem
            '        .JobName = "PPS100LB_PPSSHAPFToSQLServer"
            '        .SchedualType = IIf(Format(EachTime, "yyyy/MM/dd") = "2000/01/01", 1, 2)
            '        .SchedualRunTime = EachTime
            '    End With
            '    InsertItem.CDBSave()
            'Next

            'Dim SetString As String = Nothing
            'For Each Eachitem As DateTime In value
            '    SetString &= IIf(String.IsNullOrEmpty(SetString), Nothing, "@") & Format(Eachitem, "yyyy/MM/dd HH:mm:ss")
            'Next
            'My.Settings.Item("SchedualTimes") = SetString
        End Set
    End Property

#End Region

#Region "重整顯示排程時間 方法:RefreshDisplaySchedualTimeList"
    ''' <summary>
    ''' 重整顯示排程時間
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDisplaySchedualTimeList()
        Dim EveryDate As New Date(2000, 1, 1)
        Me.ListBox1.Items.Clear()
        For Each EachItem As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan In SchedualDatas
            Me.ListBox1.Items.Add(IIf(EachItem.SchedualType = 1, "每日 ", Format(EachItem.SchedualRunTime, "yyyy/MM/dd ")) & Format(EachItem.SchedualRunTime, "HH:mm:ss"))
        Next
    End Sub
#End Region

#Region "核對前後幾分鐘內是否有排程 方法:CheckTimeIsSafeTime"
    ''' <summary>
    ''' 核對前後幾分鐘內是否有排程
    ''' </summary>
    ''' <param name="CheckTime"></param>
    ''' <param name="SafeMinutes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckTimeIsSafeTime(ByVal CheckTime As DateTime, ByVal SafeMinutes As Integer) As Boolean
        Dim GetTime As DateTime = CType("2000/1/1 " & Format(CheckTime, "HH:mm:ss"), DateTime)
        Dim StartTime As DateTime = GetTime.AddMinutes(-SafeMinutes)
        Dim EndTime As DateTime = GetTime.AddMinutes(SafeMinutes)
        For Each EachItem As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan In SchedualDatas
            Dim CompareTime As DateTime = CType("2000/1/1 " & Format(EachItem.SchedualRunTime, "HH:mm:ss"), DateTime)
            If CompareTime >= StartTime AndAlso CompareTime <= EndTime Then
                Return False
            End If
        Next
        Return True
    End Function
#End Region

#Region "是否已執行過排程 方法:IsRunedSchedual"
    ''' <summary>
    ''' 是否已執行過排程
    ''' </summary>
    ''' <param name="SchedualObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsRunedSchedual(ByVal SchedualObject As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan) As Boolean
        Dim SQLQry As String = Nothing
        If SchedualObject.SchedualType = 1 Then
            SQLQry = "Select Count(*) From SQLVsAS400DBTransferPlanLog Where JobName='" & SchedualObject.JobName & "' AND SchedualType=" & SchedualObject.SchedualType & " AND SchedualRunTime='" & Format(SchedualObject.SchedualRunTime, "yyyy/MM/dd HH:mm:s") & "' AND RunTime='" & Format(Now, "yyyy/MM/dd ") & Format(SchedualObject.SchedualRunTime, "HH:mm:ss") & "'"
        Else
            SQLQry = "Select Count(*) From SQLVsAS400DBTransferPlanLog Where JobName='" & SchedualObject.JobName & "' AND SchedualType=" & SchedualObject.SchedualType & " AND SchedualRunTime='" & Format(SchedualObject.SchedualRunTime, "yyyy/MM/dd HH:mm:s") & "'"
        End If
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "SQLVsAS400DataTransfer")
        Return Adapter.SelectQuery(SQLQry).Rows(0).Item(0)
    End Function
#End Region

#Region "執行資料轉換 函式:RunDataConvert"
    ''' <summary>
    ''' 執行資料轉換
    ''' </summary>
    ''' <param name="SchedualObject"></param>
    ''' <remarks></remarks>
    Private Sub RunDataConvert(Optional ByVal SchedualObject As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan = Nothing)
        If Not IsNothing(SchedualObject) AndAlso IsRunedSchedual(SchedualObject) Then
            rtbMessage.Text = "已由其它伺服器執行過此排程,本伺服器已取消執行!"
            Exit Sub
        End If
        Dim StartTime As DateTime = Now
        rtbMessage.Text = "資料轉換中請稍後(約需10分鐘)....開始時間:" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "!"
        Application.DoEvents()
        rtbMessage.Text = ConvertAS400ToSQLServer(SchedualObject)
        rtbMsgHistory.Text = "發生時間:" & Format(StartTime, "yyyy/MM/dd HH:mm:ss") & vbNewLine & rtbMessage.Text & IIf(String.IsNullOrEmpty(rtbMsgHistory.Text), Nothing, vbNewLine & vbNewLine) & rtbMsgHistory.Text
    End Sub
#End Region

    Private Sub NowRunning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NowRunning.Click
        Call RunDataConvert(Nothing)
    End Sub

    Private Sub tbAddTimeByEveryDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbAddTimeByEveryDay.Click
        Dim SetValue As New CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan
        With SetValue
            .JobName = "PPS100LB_PPSSHAPFToSQLServer"
            .SchedualType = 1
            .SchedualRunTime = CType("2000/1/1 " & Format(CType(DateTimePicker2.Value, DateTime), "HH:mm:ss"), DateTime)
        End With

        If CheckTimeIsSafeTime(SetValue.SchedualRunTime, 15) = False Then
            MsgBox("前/後十五分鐘內已有排程(無法設定時間:" & Format("HH:mm:ss") & ")")
            Exit Sub
        End If
        Dim SetValues As List(Of CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan) = SchedualDatas
        SetValues.Insert(0, SetValue)
        SchedualDatas = SetValues
        RefreshDisplaySchedualTimeList()
        Me.ListBox1.SelectedIndex = 0
    End Sub

    Private Sub tbAddTimeByOneDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbAddTimeByOneDay.Click
        Dim SetValue As New CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan
        With SetValue
            .JobName = "PPS100LB_PPSSHAPFToSQLServer"
            .SchedualType = 2
            .SchedualRunTime = CType(Format(CType(DateTimePicker1.Value, DateTime), "yyyy/MM/dd ") & Format(CType(DateTimePicker2.Value, DateTime), "HH:mm:ss"), DateTime)
        End With
        If CheckTimeIsSafeTime(SetValue.SchedualRunTime, 15) = False Then
            MsgBox("前/後十五分鐘內已有排程(無法設定時間:" & Format("HH:mm:ss") & ")")
            Exit Sub
        End If
        Dim SetValues As List(Of CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan) = SchedualDatas
        SetValues.Insert(0, SetValue)
        SchedualDatas = SetValues
        RefreshDisplaySchedualTimeList()
        Me.ListBox1.SelectedIndex = 0
    End Sub

    Private Sub PPS100LB_PPSSHAPFToSQLServer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RefreshDisplaySchedualTimeList()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        tbRemoveSet.Enabled = False
        If ListBox1.Items.Count > 0 AndAlso Not IsNothing(ListBox1.SelectedItem) Then
            tbRemoveSet.Enabled = True
        End If
    End Sub

    Private Sub tbRemoveSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRemoveSet.Click
        If Not IsNothing(ListBox1.SelectedItem) Then

            Dim SetValues As List(Of CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan) = SchedualDatas
            Dim RemoveJobName As String = "PPS100LB_PPSSHAPFToSQLServer"
            Dim RemoveSchedualType As Integer = IIf(CType(ListBox1.SelectedItem, String).Contains("每日"), 1, 2)
            Dim RemoveTime As DateTime = CType(CType(ListBox1.SelectedItem, String).Replace("每日", "2000/1/1"), DateTime)

            For Each EachItem As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan In SetValues
                If EachItem.JobName.Trim = RemoveJobName AndAlso EachItem.SchedualType = RemoveSchedualType AndAlso EachItem.SchedualRunTime = RemoveTime Then
                    EachItem.CDBDelete()
                End If
            Next
            RefreshDisplaySchedualTimeList()
        End If
        Me.ListBox1.SelectedIndex = 0
    End Sub

    Private Sub tbStartRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStartRun.Click
        Timer1.Enabled = True
        btStopRun.Visible = Timer1.Enabled
        NowRunning.Visible = Not Timer1.Enabled
        tbStartRun.Visible = Not Timer1.Enabled
        tbAddTimeByEveryDay.Visible = Not Timer1.Enabled
        tbAddTimeByOneDay.Visible = Not Timer1.Enabled
        tbRemoveSet.Visible = Not Timer1.Enabled

    End Sub

    Private Sub btStopRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btStopRun.Click
        Timer1.Enabled = False
        btStopRun.Visible = Timer1.Enabled
        NowRunning.Visible = Not Timer1.Enabled
        tbStartRun.Visible = Not Timer1.Enabled
        tbAddTimeByEveryDay.Visible = Not Timer1.Enabled
        tbAddTimeByOneDay.Visible = Not Timer1.Enabled
        tbRemoveSet.Visible = Not Timer1.Enabled
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim NowTimeString1 As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
        Dim NowTimeString2 As String = Format(Now, "HH:mm:ss")
        For Each EachItem As CompanyORMDB.SQLServer.SQLVsAS400DataTransfer.SQLVsAS400DBTransferPlan In SchedualDatas
            If EachItem.SchedualType = 1 Then
                If Format(EachItem.SchedualRunTime, "HH:mm:ss") = NowTimeString2 Then
                    Call RunDataConvert(EachItem)
                End If
            Else
                If Format(EachItem.SchedualRunTime, "yyyy/MM/dd HH:mm:ss") = NowTimeString1 Then
                    Call RunDataConvert(EachItem)
                End If
            End If
        Next
    End Sub

    Public Function StartRun() As Boolean Implements IDBTranslater.StartRun
        Call tbStartRun_Click(Nothing, Nothing)
        Return True
    End Function

    Private Sub btnClearHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearHistory.Click
        If MsgBox("是否確定清除所有記錄?", vbYesNo, "注意!") = DialogResult.No Then
            Exit Sub
        End If
        rtbMsgHistory.Text = Nothing
    End Sub

    Private Sub DBSchedualRefreshTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBSchedualRefreshTimer.Tick
        Me.RefreshDisplaySchedualTimeList()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.RefreshDisplaySchedualTimeList()
    End Sub

End Class
