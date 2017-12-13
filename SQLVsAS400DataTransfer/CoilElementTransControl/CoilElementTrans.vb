Public Class CoilElementTrans
    Implements IDBTranslater

    Dim SQLAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
    Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

#Region "SQLServer資料轉換至AS400 函式:SQLServerDataConvertToAS400"
    ''' <summary>
    ''' SQLServer資料轉換至AS400
    ''' </summary>
    ''' <param name="StartTime"></param>
    ''' <param name="EndTime"></param>
    ''' <remarks></remarks>
    Private Sub SQLServerDataConvertToAS400(ByVal StartTime As DateTime, ByVal EndTime As DateTime)
        Me.rtbLog.Text = "執行起始時間:" & Format(Now, "yyyy/MM/dd HH:mm:ss")
        SetProgressBarValue(0)
        Dim StartTimeValue As Integer = (New CompanyORMDB.AS400DateConverter(StartTime)).TwIntegerTypeData
        Dim EndTimeValue As Integer = (New CompanyORMDB.AS400DateConverter(EndTime)).TwIntegerTypeData
        SetProgressBarValue(1)
        Dim AS400Qry As String = "SELECT * From @#TESTKUKU.PPSQCAPF WHERE QCA02>=" & StartTimeValue & " AND QCA02<=" & EndTimeValue
        Dim OrginAS400Datas As List(Of CompanyORMDB.PPS100LB.PPSQCAPF) = CompanyORMDB.PPS100LB.PPSQCAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSQCAPF)(AS400Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AS400DeleteQry As String = "Delete From @#TESTKUKU.PPSQCAPF WHERE QCA02>=" & StartTimeValue & " AND QCA02<=" & EndTimeValue
        Dim SearchResult As DataTable = SQLAdapter.SelectQuery("Select * From  分析資料 Where 日期>=" & StartTimeValue & " AND 日期<=" & EndTimeValue & " AND 站別 LIKE  'C%' ")
        GetRemoveNotLastStationData(SearchResult)
        AS400Adapter.ExecuteNonQuery(AS400DeleteQry)
        SetProgressBarValue(50)
        Dim SuccessSaveCount As Integer = 0
        Dim FailSaveCount As Integer = 0
        For Each EachItem As DataRow In SearchResult.Rows
            Dim InsertItem As New CompanyORMDB.PPS100LB.PPSQCAPF
            Try
                InsertItem.CDBLibraryName = "TESTKUKU"
                InsertItem.SQLQueryAdapterByThisObject = AS400Adapter
                InsertItem.SetSQLServerDataRowValueToObject(EachItem)
                SuccessSaveCount += InsertItem.CDBSave()
                AddMsgToLog("轉換資料 爐號:" & InsertItem.QCA01 & " 成功!")
                SetProgressBarValue(50 + (SuccessSaveCount / SearchResult.Rows.Count))
            Catch ex As Exception
                AddMsgToLog("轉換資料 爐號:" & InsertItem.QCA01 & " 失敗:" & ex.ToString)
                FailSaveCount += 1
                For Each EachItem1 In OrginAS400Datas
                    If EachItem1.QCA01 = EachItem.Item("爐號") And EachItem1.QCA02 = EachItem.Item("日期") Then
                        EachItem1.CDBSave() : Continue For
                    End If
                Next
            End Try
        Next
        SetProgressBarValue(100)
        tsslMsg.Text = "合計 " & SuccessSaveCount & " 筆資料資料同完成!" & IIf(FailSaveCount = 0, Nothing, " (失敗 " & FailSaveCount & " 筆)")
        AddMsgToLog(tsslMsg.Text)
        AddMsgToLog("執行結束時間:" & Format(Now, "yyyy/MM/dd HH:mm:ss"))
        If FailSaveCount > 0 Then   '如有失敗以Mail訊息通知
            SendMail(tbNoticeMail.Text, rtbLog.Text)
        End If
    End Sub

    Private Sub GetRemoveNotLastStationData(ByRef SourceData As DataTable)
        Dim AbnormalDatas As New List(Of String)
        For Each Eachitem As DataRow In SourceData.Rows
            If CType(Eachitem.Item("站別"), String).Trim.Trim > "C1" Then
                AbnormalDatas.Add(CType(Eachitem.Item("爐號"), String) & "," & Val(CType(Eachitem.Item("站別"), String).Trim.Replace("C", Nothing)) - 1)
            End If
        Next

        For Each EachItem In AbnormalDatas
            For Each EachItem1 As DataRow In SourceData.Rows
                If CType(EachItem1.Item("爐號"), String) = EachItem.Split(",")(0) AndAlso CType(EachItem1.Item("站別"), String).Trim = "C" & EachItem.Split(",")(1) Then
                    SourceData.Rows.Remove(EachItem1) : Exit For
                End If
            Next
        Next
    End Sub

    Delegate Sub SetProgressBarValueDelegate(ByVal Values() As Integer)
    Delegate Sub AddMsgToLogDelegate(ByVal Values As String)
    Private Sub SetProgressBarValue(ByVal Value As Integer)
        Dim Method As SetProgressBarValueDelegate = AddressOf SetProgressBarValueAsync
        Dim SetValues() As Integer = {Value}
        Me.Invoke(Method, SetValues)
    End Sub
    Private Sub SetProgressBarValueAsync(ByVal Values() As Integer)
        Me.ToolStripProgressBar1.Value = Values(0)
    End Sub

    Private Sub AddMsgToLog(ByVal Msg As String)
        Dim Method As AddMsgToLogDelegate = AddressOf AddMsgToLogAsync
        Dim SetValues() As String = {Msg}
        Me.Invoke(Method, SetValues)
    End Sub
    Private Sub AddMsgToLogAsync(ByVal Values As String)
        Me.rtbLog.Text = Values & IIf(String.IsNullOrEmpty(Me.rtbLog.Text), Nothing, vbNewLine) & Me.rtbLog.Text
    End Sub

#End Region

#Region "SQLServer資料是否變更 屬性:IsSQLServerDataChanged"
    Private DataVersion As Double = -1
    ''' <summary>
    ''' SQLServer資料是否變更
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsSQLServerDataChanged As Boolean
        Get
            Dim Qry As String = "Select changeId from AspNet_SqlCacheTablesForChangeNotification Where tableName='分析資料' "
            Dim NewVersionNumber As Double = SQLAdapter.SelectQuery(Qry).Rows(0).Item(0)
            Dim ReturnValue As Boolean = (DataVersion <> NewVersionNumber)
            DataVersion = NewVersionNumber
            Return ReturnValue
        End Get
    End Property
#End Region

#Region "發送Email 函式:SendEamil"
    ''' <summary>
    ''' 發送Email
    ''' </summary>
    ''' <param name="ReceiveAddress"></param>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Private Sub SendMail(ByVal ReceiveAddress As String, ByVal Message As String)
        Dim mySmtpClient As New System.Net.Mail.SmtpClient("mail.tangeng.com.tw")
        mySmtpClient.UseDefaultCredentials = True
        Dim mail As MailMessage = New MailMessage
        mail.From = New MailAddress("kuku@mail.tangeng.com.tw", "網站通知")
        For Each EachItem As String In ReceiveAddress.Split(";")
            mail.To.Add(New MailAddress(EachItem))
        Next
        mail.Subject = "鋼肧化學成份傳送AS400轉檔失敗通知!"
        mail.Body = Message
        mail.IsBodyHtml = False
        mail.Priority = MailPriority.High
        mySmtpClient.Send(mail)
    End Sub
#End Region


    Public Function StartRun() As Boolean Implements IDBTranslater.StartRun
        RadioButton1.Checked = True
        Return True
    End Function

    Private Sub btnManualRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualRun.Click
        SQLServerDataConvertToAS400(tdpStartDate.Value, tdpEndDate.Value)
    End Sub

    Private Sub DetectDataChangedTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetectDataChangedTimer.Tick
        Dim NowTime As DateTime = Now
        Dim TimeString As String = Format(NowTime, "HH:mm:ss")
        If TimeString = "08:30:00" OrElse TimeString = "12:30:00" OrElse TimeString = "22:00:00" Then
            DetectDataChangedTimer.Enabled = False
            If IsSQLServerDataChanged Then
                Try
                    SQLServerDataConvertToAS400(Now.Date.AddDays(-(NumericUpDown1.Value - 1)), Now.Date)
                Catch ex As Exception
                    rtbLog.Text = ex.ToString
                    SendMail(tbNoticeMail.Text, ex.ToString)
                End Try
            End If
            DetectDataChangedTimer.Enabled = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        DetectDataChangedTimer.Enabled = (sender Is RadioButton1)
        GroupBox2.Enabled = (sender Is RadioButton1)
        GroupBox3.Enabled = (sender Is RadioButton2)
    End Sub

End Class

