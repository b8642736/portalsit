Public Class StartForm


    WithEvents WorkClassesObject As IWorkClasses
    'Dim Smtp As New SmtpClient("mail.tangeng.com.tw", 25)

    Private Sub StartForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            WorkClassesObject = New Buy_BuyMeetEdit_SendMail
            WorkClassesObject.StartRun()
            WorkClassesObject = New SMP_CheckLossSQLConvertToAS400Data
            WorkClassesObject.StartRun()

        Catch ex As Exception
            'Dim ErrorMailMsg As New MailMessage
            'ErrorMailMsg.From = New MailAddress("shingu@mail.tangeng.com.tw", "系統發送")

            'ErrorMailMsg.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
            'ErrorMailMsg.To.Add(New MailAddress("renhsin@mail.tangeng.com.tw", "陳仁欣"))

            'ErrorMailMsg.Subject = "PortalsitLoopRun發生錯誤通知!"

            'ErrorMailMsg.IsBodyHtml = False
            'ErrorMailMsg.Body = "PortalsitLoopRun發生錯誤:" & ex.ToString
            'Smtp.Send(ErrorMailMsg)



            Dim MailObject As New PublicClassLibrary.MISMail
            Dim SendBody As String
            With MailObject
                .ToMailAddress.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
                .ToMailAddress.Add(New MailAddress("renhsin@mail.tangeng.com.tw", "陳仁欣"))
                .ToMailAddress.Add(New MailAddress("30327@mail.tangeng.com.tw", "梁家榮"))
                SendBody = "PortalsitLoopRun發生錯誤:" & ex.ToString
                .SendMail("PortalsitLoopRun發生錯誤通知!", SendBody)
            End With
        End Try
        Me.Close()
    End Sub

    Private Sub WorkClassesObject_SendMessage(Message As MailMessage) Handles WorkClassesObject.SendMessage
        'Smtp.Send(Message)
        Dim MailObject As New PublicClassLibrary.MISMail
        MailObject.RunSMTPClient.Send(Message)
    End Sub


End Class