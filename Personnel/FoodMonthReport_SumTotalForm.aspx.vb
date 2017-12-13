Public Class FoodMonthReport_SumTotalForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("PSN01", "PSN0108", Me)
    End Sub

End Class