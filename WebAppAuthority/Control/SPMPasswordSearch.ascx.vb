Public Class SPMPasswordSearch
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim SPMObject As Object
        SPMObject = Server.CreateObject("ASP_2_SPM.SSO")
        Dim PWD As String = SPMObject.GetPassword(tbEmployeeID.Text)
        lbPassword.Text = PWD
    End Sub

    Protected Sub btnGotoEIPWeb_Click(sender As Object, e As EventArgs) Handles btnGotoEIPWeb.Click
        Page.Response.Redirect("HTTP://10.1.4.12/EIP")
    End Sub
End Class