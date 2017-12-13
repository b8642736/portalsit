Public Class Buy_BuyMeetEdit_SendMail
    Implements IWorkClasses

    Public Event SendMessage(Message As System.Net.Mail.MailMessage) Implements IWorkClasses.SendMessage

#Region "發送通知 函式:SendMesageToPersons"
    ''' <summary>
    ''' 發送通知
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SendMesageToPersons()
        Dim QryString As String = "Select * from @#MTS600LB.MTSBC1PF WHERE MTSB02='" & (Val(Now.AddDays(1).Year) - 1911) & Format(Now.AddDays(1), "MMdd") & "' order by MTSB03"
        'QryString = "Select * from @#MTS600LB.MTSBC1PF WHERE MTSB02='1020820' order by MTSB03"
        Dim SearchResult = CompanyORMDB.MTS600LB.MTSBC1PF.CDBSelect(Of CompanyORMDB.MTS600LB.MTSBC1PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        If SearchResult.Count = 0 Then
            Exit Sub
        End If
        Dim Column1Datas As List(Of CompanyORMDB.MTS600LB.MTSBC1PF) = (From A In SearchResult Where A.MTSB05 = 1 Select A).ToList
        Dim Column2Datas As List(Of CompanyORMDB.MTS600LB.MTSBC1PF) = (From A In SearchResult Where A.MTSB05 = 2 Select A).ToList
        Dim Column3Datas As List(Of CompanyORMDB.MTS600LB.MTSBC1PF) = (From A In SearchResult Where A.MTSB05 = 3 Select A).ToList
        Dim SendMessage As New MailMessage
        'SendMessage.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛Test"))
        SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
        SendMessage.To.Add(New MailAddress("mis@mail.tangeng.com.tw", "系統發送"))
        SendMessage.To.Add(New MailAddress("soniawu@mail.tangeng.com.tw", "吳庭汝"))
        SendMessage.To.Add(New MailAddress("leo@mail.tangeng.com.tw", "張懷陸"))
        SendMessage.To.Add(New MailAddress("shingu@mail.tangeng.com.tw", "陳瑞玉"))
        SendMessage.To.Add(New MailAddress("ljwu@mail.tangeng.com.tw", "吳麗娟"))
        SendMessage.To.Add(New MailAddress("nice@mail.tangeng.com.tw ", "蔡麗英"))
        SendMessage.To.Add(New MailAddress("joyce@mail.tangeng.com.tw ", "嚴秀娟"))
        SendMessage.To.Add(New MailAddress("tcyeh@mail.tangeng.com.tw", "葉翠娟"))
        SendMessage.To.Add(New MailAddress("wenhsin@mail.tangeng.com.tw", "許文韾"))
        SendMessage.To.Add(New MailAddress("30321@mail.tangeng.com.tw", "余諮芸"))
        SendMessage.To.Add(New MailAddress("13064@mail.tangeng.com.tw", "林仕霈"))

        If Column2Datas.Count > 0 Then
            SendMessage.To.Add(New MailAddress("chenhsiung@mail.tangeng.com.tw", "採購陳政雄"))
        End If
        If Column3Datas.Count > 0 Then
            SendMessage.To.Add(New MailAddress("tmchiu@mail.tangeng.com.tw", "邱滄敏"))
        End If

        SendMessage.Subject = "採購處開標主持人權責 系統定時通知!"
        SendMessage.IsBodyHtml = True
        Dim Content As New StringBuilder
        Dim ValueString As String = Nothing
        Content.Append("<table width='100%'><tr>")
        Content.Append("<td align='left'>開標日期:" & Format(Now.Date.AddDays(1), "yyyy\/MM\/dd") & "</td>")
        'Content.Append("<td align='left'>開標日期:2013/08/20</td>")
        Content.Append("<td><font size='5'>採購處開標主持人權責</font></td><td></td>")
        Content.Append("</tr></table>")

        Content.Append("<table border='1' width='100%'>")
        Content.Append("<tr>")
        Content.Append("<td align='center'>100萬元(不含)以下<br/>承辦人</td>")
        Content.Append("<td align='center'>100萬元~1000萬元(不含)<br/>採購處長(助理副總)</td>")
        Content.Append("<td align='center'>1000萬元以上<br/>總經理</td>")
        Content.Append("</tr>")
        For RowCount As Integer = 0 To Math.Max(Math.Max(Column1Datas.Count, Column2Datas.Count), Column3Datas.Count) - 1
            Content.Append("<tr>")
            Content.Append("<td>")
            If RowCount <= Column1Datas.Count - 1 Then
                ValueString = "時間:" & Column1Datas(RowCount).MTSB03 & "~" & Column1Datas(RowCount).MTSB04
                ValueString &= " 第" & Column1Datas(RowCount).MTSB06Descript & "開標"
                ValueString &= "<br/>" & Column1Datas(RowCount).MTSB07
                Content.Append(ValueString)
            End If
            Content.Append("</td>")


            Content.Append("<td>")
            If RowCount <= Column2Datas.Count - 1 Then
                ValueString = "時間:" & Column2Datas(RowCount).MTSB03 & "~" & Column2Datas(RowCount).MTSB04
                ValueString &= " 第" & Column2Datas(RowCount).MTSB06Descript & "開標"
                ValueString &= "<br/>" & Column2Datas(RowCount).MTSB07
                Content.Append(ValueString)
            End If
            Content.Append("</td>")


            Content.Append("<td>")
            If RowCount <= Column3Datas.Count - 1 Then
                ValueString = "時間:" & Column3Datas(RowCount).MTSB03 & "~" & Column3Datas(RowCount).MTSB04
                ValueString &= " 第" & Column3Datas(RowCount).MTSB06Descript & "開標"
                ValueString &= "<br/>" & Column3Datas(RowCount).MTSB07
                Content.Append(ValueString)
            End If
            Content.Append("</td>")

            Content.Append("</tr>")
        Next
        Content.Append("</table>")


        SendMessage.Body = Content.ToString
        RaiseEvent SendMessage(SendMessage)
    End Sub
#End Region


    Public Function StartRun() As Boolean Implements IWorkClasses.StartRun
        Dim EveryDayRunTime As DateTime = Now.Date.AddHours(9) '設定早上9:00發送明天資料之Email
        If Now < EveryDayRunTime Then
            Return True
        End If
        Try

            Dim PCIP As List(Of String) = CompanyORMDB.DeviceInformation.GetLocalIPs
            Dim SetIP As String = "0.0.0.0"
            If PCIP.Count > 0 Then
                SetIP = PCIP(0)
            End If
            Dim SaveRec As PortalsitLoopRunRec = PortalsitLoopRunRec.GetLastPortalsitLoopRunRec("Buy_BuyMeetEdit_SendMail", Now.Date)
            If IsNothing(SaveRec) Then
                SaveRec = New PortalsitLoopRunRec("Buy_BuyMeetEdit_SendMail", SetIP)
                If SaveRec.CDBSave > 0 Then
                    SendMesageToPersons()
                    SaveRec.EndRunTime = IIf(Now > SaveRec.StartRunTime.AddSeconds(1), Now, SaveRec.StartRunTime.AddSeconds(1))
                    Return SaveRec.CDBSave() > 0
                End If
                Return True
            End If


        Catch ex As Exception
            'Dim Smtp As New SmtpClient("mail.tangeng.com.tw", 25)
            'Dim ErrorMailMsg As New MailMessage("kuku@mail.tangeng.com.tw", "kuku@mail.tangeng.com.tw")
            'ErrorMailMsg.IsBodyHtml = False
            'ErrorMailMsg.Body = "PortalsitLoopRun Buy_BuyMeetEdit_SendMail發生錯誤:" & ex.ToString
            'Smtp.Send(ErrorMailMsg)

            Dim MailObject As New PublicClassLibrary.MISMail
            Dim SendBody As String
            With MailObject
                .ToMailAddress.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
                SendBody = "PortalsitLoopRun Buy_BuyMeetEdit_SendMail發生錯誤:" & ex.ToString
                .SendMail("PortalsitLoopRun Buy_BuyMeetEdit_SendMail發生錯誤", SendBody)
            End With
        End Try
        Return True
    End Function


End Class
