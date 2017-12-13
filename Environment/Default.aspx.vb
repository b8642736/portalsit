Public Class _Default
    Inherits System.Web.UI.Page


    Protected Sub btnECO0103_Click(sender As Object, e As EventArgs) Handles btnECO0103.Click
        Response.Write("<script>window.open('http://10.1.4.12/EIP/LogonRedirectGHG.aspx');</script>")
    End Sub
End Class