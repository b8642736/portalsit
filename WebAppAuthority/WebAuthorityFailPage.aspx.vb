Public Partial Class WebAuthorityFailPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGoBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGoBack.Click
        Response.Write("<script language=javascript>history.go(-2);</script>")
    End Sub

End Class