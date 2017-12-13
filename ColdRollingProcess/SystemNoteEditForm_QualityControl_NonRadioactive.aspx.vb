Public Class SystemNoteEditForm_QualityControl_NonRadioactive
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("QTYCTL01", "QTYCTL0135", Me)
        If Not IsPostBack Then
            Session("defaultSYSTEM_TYPE") = HttpUtility.UrlEncode("品保_無輻射證明")
        End If
    End Sub


End Class