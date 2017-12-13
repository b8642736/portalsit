Public Partial Class DBConnectSwitch
    Inherits System.Web.UI.UserControl


    Dim CompanyDBChange As New CompanyWebDBChange.DBServerChangeSoapClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblNowUserServerIP.Text = CompanyLINQDB.GetCurrentDBServerIP
        Dim pingSender As New Net.NetworkInformation.Ping
        lblDBServer1Msg.Text = IIf(pingSender.Send(lblDBServer0.Text).Status = Net.NetworkInformation.IPStatus.Success, "是", "否,斷線!")
        lblDBServer2Msg.Text = IIf(pingSender.Send(lblDBServer1.Text).Status = Net.NetworkInformation.IPStatus.Success, "是", "否,斷線!")
    End Sub

    Protected Sub btnChangeDBServer1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnChangeDBServer1.Click
        lblChangeMessage.Text = "切換至主要資料庫伺服器" & IIf(CompanyDBChange.SetDBConnect(CompanyWebDBChange.DBServerNameEnum.MainDBServer), "成功!", "失敗!")
        lblNowUserServerIP.Text = CompanyLINQDB.GetCurrentDBServerIP
    End Sub

    Protected Sub btnChangeDBServer2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnChangeDBServer2.Click
        lblChangeMessage.Text = "切換至備援資料庫伺服器" & IIf(CompanyDBChange.SetDBConnect(CompanyWebDBChange.DBServerNameEnum.BackupDBServer1), "成功!", "失敗!")
        lblNowUserServerIP.Text = CompanyLINQDB.GetCurrentDBServerIP
    End Sub
End Class