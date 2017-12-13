Public Class SystemNoteEditForm_Financial_InvoiceOfReceivables
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("FIN01", "FIN0110", Me)
        If Not IsPostBack Then
            Session("defaultSYSTEM_TYPE") = HttpUtility.UrlEncode("財務_收款通知單")
        End If
    End Sub


End Class