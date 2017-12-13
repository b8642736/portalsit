Public Module ChangeWebSitByAuthority

#Region "依權限取得其它系統導灠網址 方法:GoWebSitByWebAPPAuthority"
    ''' <summary>
    ''' 依權限取得其它系統導灠網址
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GoWebSitByWebAPPAuthority(ByVal SetWebPage As System.Web.UI.Page, ByVal GoSitName As String, Optional ByVal GoSitSubPath As String = Nothing)
        Dim ReturnValue As String = "Http://"
        ReturnValue &= IIf(SetWebPage.Request.ServerVariables.Item("LOCAL_ADDR").Substring(0, 2) = "::", "localhost", SetWebPage.Request.ServerVariables.Item("LOCAL_ADDR")) & "/" & GoSitName.Replace("/", "")
        ReturnValue &= IIf(IsNothing(ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber), "_Anonymous/", "/")
        If Not String.IsNullOrEmpty(GoSitSubPath) AndAlso GoSitSubPath.Length > 0 Then
            ReturnValue &= IIf(GoSitSubPath.Substring(0, 1) = "/", GoSitSubPath.Substring(1, GoSitSubPath.Length - 1), GoSitSubPath)
        End If
        SetWebPage.Response.Redirect(ReturnValue)
    End Sub

#End Region
End Module
