Public Partial Class WebUserAuthority1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim EmployeeNumber As String = ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber
        If Not IsNothing(EmployeeNumber) AndAlso (EmployeeNumber.Trim = "30276" Or EmployeeNumber.Trim = "30110") Then
            Exit Sub
        Else
            ValidAuthorityModule.ValidAuthoritySystem("Auth01", "Auth0102", Me)
        End If
    End Sub

End Class