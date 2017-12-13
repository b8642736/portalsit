Public Partial Class MonitorCleintPCStatus
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.GridView1.DataBind()
        lbaLastUpdateTime.Text = Now.ToString
        Me.UpdatePanel1.Update()
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Me.GridView1.DataBind()
        lbaLastUpdateTime.Text = Now.ToString
        Me.UpdatePanel1.Update()
    End Sub

End Class