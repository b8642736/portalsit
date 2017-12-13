Public Class SMP_CheckLossSQLConvertToAS400Data
    Implements IWorkClasses


    Public Event SendMessage(Message As System.Net.Mail.MailMessage) Implements IWorkClasses.SendMessage

    Public Function StartRun() As Boolean Implements IWorkClasses.StartRun
        '核對七天前之所有SQLServer成份資料AS400是否都有
        Dim QryString = "Select * from 分析資料 Where 站別='L1' AND 日期>=" & (New CompanyORMDB.AS400DateConverter(Now.AddDays(-7).Date)).TwIntegerTypeData
        Dim SQLAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim UnNormalDatas As New List(Of String)
        Dim DifferentDatas As New List(Of String)
        Dim alert_list As New List(Of String)
        For Each EachItem In CompanyORMDB.SQLServer.QCDB01.分析資料.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.分析資料)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            If IsNothing(EachItem.AboutAS400Data) Then
                ''1051128 By JiaRong
                ''LOSS註記在AS400不會有資料
                If IsDBNull(EachItem.LOSS) OrElse EachItem.LOSS.Trim = "" Then
                    UnNormalDatas.Add("爐號:" & EachItem.爐號 & " 日期:" & EachItem.日期)
                End If
            Else
                ''1051128 By JiaRong
                ''比對爐號、日期、時、分 判斷兩筆資料是否相等
                If Not alert_list.Exists(Function(x) x = EachItem.爐號) Then
                    'Debug.WriteLine(EachItem.爐號 & "已紀錄")

                    Dim record As CompanyORMDB.SQLServer.QCDB01.分析資料 = TheDataShouldToSql(EachItem.爐號, EachItem.日期)
                    If Not (record.爐號.Trim.Equals(EachItem.AboutAS400Data.QCA01.Trim) And _
                                            record.日期.Equals(EachItem.AboutAS400Data.QCA02) And _
                                            record.時間.Split(":")(0).Equals(EachItem.AboutAS400Data.QCA03.ToString("00")) And _
                                            record.時間.Split(":")(1).Equals(EachItem.AboutAS400Data.QCA04.ToString("00"))) Then
                        DifferentDatas.Add("SQL現存資料 爐號:" & record.爐號 & " 日期:" & record.日期 & _
                                           " 時間:" & record.時間 & " 站別:" & record.站別 & " 序號:" & record.序號)
                        DifferentDatas.Add("400現存資料 爐號:" & EachItem.爐號 & " 日期:" & EachItem.日期 & _
                                           " 時間:" & EachItem.AboutAS400Data.QCA03.ToString("00") & ":" & EachItem.AboutAS400Data.QCA04.ToString("00"))
                        DifferentDatas.Add("")
                        alert_list.Add(record.爐號)
                    End If
                End If
            End If

        Next
        If UnNormalDatas.Count > 0 Or DifferentDatas.Count > 0 Then

            Dim SendMessage As New MailMessage
            SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
            SendMessage.To.Add(New MailAddress("mis@mail.tangeng.com.tw", "系統發送"))
            SendMessage.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
            SendMessage.To.Add(New MailAddress("renhsin@mail.tangeng.com.tw", "陳仁欣"))
            SendMessage.To.Add(New MailAddress("yhc@mail.tangeng.com.tw", "嚴孝真"))
            SendMessage.To.Add(New MailAddress("ccc@mail.tangeng.com.tw", "陳啟川"))
            'SendMessage.To.Add(New MailAddress("chenyr@mail.tangeng.com.tw", "陳裕仁"))
            SendMessage.To.Add(New MailAddress("yen@mail.tangeng.com.tw", "顏順興"))
            SendMessage.To.Add(New MailAddress("30327@mail.tangeng.com.tw", "梁家榮"))

            SendMessage.Subject = "分光室成份轉AS400發生異常通知!"
            Dim Content As New StringBuilder
            If UnNormalDatas.Count > 0 Then
                Content.AppendLine("以下為AS400成份遺失,但SQL Server有成份之資料")
                For Each EachItem In UnNormalDatas
                    Content.AppendLine(EachItem)
                Next
            End If
            If DifferentDatas.Count > 0 Then
                Content.AppendLine("以下為AS400與SQL Server中資料不一致之資料")
                For Each EachItem In DifferentDatas
                    Content.AppendLine(EachItem)
                Next
            End If
           
            SendMessage.Body = Content.ToString
            RaiseEvent SendMessage(SendMessage)
        End If

        '核對SQLServer最新前50爐號是否連續
        QryString = "Select  TOP 12 爐號,日期,時間 from 分析資料 Where 爐號 LIKE 'A%' AND 站別 = 'A1' AND 序號=1 ORDER BY 日期 DESC,時間 DESC "
        Dim AStoves As List(Of String) = (From A In SQLAdapter.SelectQuery(QryString) Select CType(A.Item("爐號"), String).Replace("A", Nothing)).ToList
        QryString = "Select  TOP 12 爐號,日期,時間 from 分析資料 Where 爐號 LIKE 'B%' AND 站別 = 'A1' AND 序號=1 ORDER BY 日期 DESC,時間 DESC "
        Dim BStoves As List(Of String) = (From A In SQLAdapter.SelectQuery(QryString) Select CType(A.Item("爐號"), String).Replace("B", Nothing)).ToList
        AStoves = (From A In AStoves Select A Order By A).ToList
        BStoves = (From A In BStoves Select A Order By A).ToList
        Dim MissStoveNumbers As New List(Of String) '移失的爐號
        Dim ScanAllNumbers As New List(Of String)
        Dim StartNumber As String
        Dim EndNumber As String

        'If AStoves.Count > 0 Then
        '    StartNumber = AStoves(0)
        '    EndNumber = AStoves(AStoves.Count - 1)
        '    If EndNumber > StartNumber Then
        '        For EachNumber As Integer = Val(StartNumber) To Val(EndNumber)
        '            ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
        '        Next
        '    Else
        '        For EachNumber As Integer = Val(StartNumber) To 9999
        '            ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
        '        Next
        '        For EachNumber As Integer = 1 To Val(StartNumber)
        '            ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
        '        Next
        '    End If
        '    MissStoveNumbers.AddRange((From A In ScanAllNumbers Where Not AStoves.Contains(A) Select "A" & A).ToList)
        'End If

        'If BStoves.Count > 0 Then
        '    ScanAllNumbers.Clear()
        '    StartNumber = BStoves(0)
        '    EndNumber = BStoves(BStoves.Count - 1)
        '    If EndNumber > StartNumber Then
        '        For EachNumber As Integer = Val(StartNumber) To Val(EndNumber)
        '            ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
        '        Next
        '    Else
        '        For EachNumber As Integer = Val(StartNumber) To 9999
        '            ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
        '        Next
        '        For EachNumber As Integer = 1 To Val(StartNumber)
        '            ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
        '        Next
        '    End If
        '    MissStoveNumbers.AddRange((From A In ScanAllNumbers Where Not BStoves.Contains(A) Select "B" & A).ToList)
        'End If

        '103026 by renhsin，A/B爐共用同一份程式
        Dim TempStoves As List(Of String)
        Dim StovesName As String
        For II As Integer = 1 To 2
            StovesName = IIf(II = 1, "A", "B")
            TempStoves = IIf(II = 1, AStoves, BStoves)

            ScanAllNumbers.Clear()
            StartNumber = TempStoves(0)
            EndNumber = TempStoves(TempStoves.Count - 1)

            '1)爐號資料已排序：爐號小至大
            '2)資料模式
            '           A)有跨頭尾：Ex     0002~9990
            '           B)沒有跨頭尾：Ex 6450~6461
            If (StartNumber < 100 AndAlso EndNumber > 9900) Then
                EndNumber = (From A In TempStoves Where A > 9900 Order By A).FirstOrDefault
                StartNumber = (From A In TempStoves Where A < 100 Order By A Descending).FirstOrDefault

                For EachNumber As Integer = Val(EndNumber) To 9999
                    ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
                Next
                For EachNumber As Integer = 1 To Val(StartNumber)
                    ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
                Next

            Else
                For EachNumber As Integer = Val(StartNumber) To Val(EndNumber)
                    ScanAllNumbers.Add(String.Format("{0:0000}", EachNumber))
                Next
            End If

            MissStoveNumbers.AddRange((From A In ScanAllNumbers Where Not TempStoves.Contains(A) Select StovesName & A).ToList)
        Next


        If MissStoveNumbers.Count > 0 Then
            Dim SendMessage As New MailMessage
            SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
            SendMessage.To.Add(New MailAddress("mis@mail.tangeng.com.tw", "系統發送"))
            SendMessage.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
            SendMessage.To.Add(New MailAddress("renhsin@mail.tangeng.com.tw", "陳仁欣"))
            SendMessage.To.Add(New MailAddress("yhc@mail.tangeng.com.tw", "嚴孝真"))
            SendMessage.To.Add(New MailAddress("ccc@mail.tangeng.com.tw", "陳啟川"))
            'SendMessage.To.Add(New MailAddress("chenyr@mail.tangeng.com.tw", "陳裕仁"))
            SendMessage.To.Add(New MailAddress("yen@mail.tangeng.com.tw", "顏順興"))
            SendMessage.To.Add(New MailAddress("30327@mail.tangeng.com.tw", "梁家榮"))

            SendMessage.Subject = "分光室生產爐號不連續生異常通知!"
            Dim Content As New StringBuilder
            Content.AppendLine("以下為遺失之爐號號碼:")
            For Each EachItem As String In MissStoveNumbers
                Content.AppendLine("爐號:" & EachItem)
            Next
            SendMessage.Body = Content.ToString
            RaiseEvent SendMessage(SendMessage)
        End If



        '1020801 by renhsin
        '外購與委驗
        '核對七天前之所有SQLServer成份資料AS400是否都有
        QryString = "Select * from 分析資料_外購 Where 日期>=" & (New CompanyORMDB.AS400DateConverter(Now.AddDays(-7).Date)).TwIntegerTypeData
        QryString &= " ORDER BY 爐號,站別"
        SQLAdapter = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        UnNormalDatas = New List(Of String)
        For Each EachItem In CompanyORMDB.SQLServer.QCDB01.分析資料_外購.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.分析資料_外購)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            If IsNothing(EachItem.AboutAS400Data) Then
                If EachItem.爐號 = "ET" Then
                    UnNormalDatas.Add("委驗單號:" & EachItem.站別 & " 日期:" & EachItem.日期)
                Else
                    UnNormalDatas.Add("批號:" & EachItem.爐號 & " 鋼捲號碼:" & EachItem.站別 & " 日期:" & EachItem.日期)
                End If
                '                UnNormalDatas.Add("爐號:" & EachItem.爐號 & " 日期:" & EachItem.日期)
            End If
        Next
        If UnNormalDatas.Count > 0 Then
            Dim SendMessage As New MailMessage
            SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
            SendMessage.To.Add(New MailAddress("mis@mail.tangeng.com.tw", "系統發送"))
            SendMessage.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
            SendMessage.To.Add(New MailAddress("renhsin@mail.tangeng.com.tw", "陳仁欣"))
            SendMessage.To.Add(New MailAddress("yhc@mail.tangeng.com.tw", "嚴孝真"))
            SendMessage.To.Add(New MailAddress("ccc@mail.tangeng.com.tw", "陳啟川"))
            'SendMessage.To.Add(New MailAddress("chenyr@mail.tangeng.com.tw", "陳裕仁"))
            SendMessage.To.Add(New MailAddress("yen@mail.tangeng.com.tw", "顏順興"))
            SendMessage.To.Add(New MailAddress("30327@mail.tangeng.com.tw", "梁家榮"))

            SendMessage.Subject = "分光室[外購與委驗]成份轉AS400發生異常通知!"
            Dim Content As New StringBuilder
            Content.AppendLine("以下為AS400成份遺失,但SQL Server有成份之資料")
            For Each EachItem In UnNormalDatas
                Content.AppendLine(EachItem)
            Next
            SendMessage.Body = Content.ToString
            RaiseEvent SendMessage(SendMessage)
        End If

        '1051128 By JiaRong
        '提醒是否有異常資料未處理之紀錄
        QryString = "Select * from 分析資料_SQL轉400異常紀錄 Where 註記 = '未處理'"
        SQLAdapter = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        UnNormalDatas = New List(Of String)
        For Each EachItem As DataRow In SQLAdapter.SelectQuery(QryString).Rows
            UnNormalDatas.Add("爐號:" & EachItem.Item("爐號") & " 日期:" & EachItem.Item("日期"))
            UnNormalDatas.Add("語法:" & EachItem.Item("語法"))
        Next
        If UnNormalDatas.Count > 0 Then
            Dim SendMessage As New MailMessage
            SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
            SendMessage.To.Add(New MailAddress("mis@mail.tangeng.com.tw", "系統發送"))
            SendMessage.To.Add(New MailAddress("renhsin@mail.tangeng.com.tw", "陳仁欣"))
            SendMessage.To.Add(New MailAddress("30327@mail.tangeng.com.tw", "梁家榮"))

            SendMessage.Subject = "分光室成份轉AS400發生異常-錯誤清單"
            Dim Content As New StringBuilder
            Content.AppendLine("以下為註記未處理之資料")
            For Each EachItem In UnNormalDatas
                Content.AppendLine(EachItem)
            Next
            SendMessage.Body = Content.ToString
            RaiseEvent SendMessage(SendMessage)
        End If



        Return True
    End Function

    Private Function TheDataShouldToSql(ByVal 爐號 As String, ByVal 日期 As String) As CompanyORMDB.SQLServer.QCDB01.分析資料
        Dim 日期S As String = (CInt(日期.Substring(0, 3)) - 1).ToString & "0101"
        Dim 日期E As String = (CInt(日期.Substring(0, 3)) + 1).ToString & "1231"
        Dim QryString = ""
        QryString &= "Select *, 'X' + 站別 + STR(序號,2,0) AS SortKey from 分析資料 "
        QryString &= "where 爐號 = '" & 爐號 & "' AND 日期 >= " & 日期S & "AND 日期 <= " & 日期E & " AND 站別 >= 'L1' AND 站別 <= 'L9'"
        QryString &= "UNION ALL Select *, 'Y' + 站別 + STR(序號,2,0) AS SortKey from 分析資料 "
        QryString &= "where 爐號 = '" & 爐號 & "' AND 日期 >= " & 日期S & "AND 日期 <= " & 日期E & " AND 站別 >= 'C1' AND 站別 <= 'C9' "
        QryString &= "UNION ALL Select *, 'Z' + 站別 + STR(序號,2,0) AS SortKey from 分析資料 "
        QryString &= "where 爐號 = '" & 爐號 & "' AND 日期 >= " & 日期S & "AND 日期 <= " & 日期E & " AND 站別 >= 'S1' AND 站別 <= 'S9'  ORDER BY SortKey Desc"
        Dim SQLAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Return CompanyORMDB.SQLServer.QCDB01.分析資料.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.分析資料)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString).FirstOrDefault
    End Function
End Class
