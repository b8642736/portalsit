Public Module FilterMenuForAuthority

#Region "驗證授權路徑 方法:IsPathAuthority"
    ''' <summary>
    ''' 驗證授權路徑
    ''' </summary>
    ''' <param name="SourceWebPage"></param>
    ''' <param name="AuthorizePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsPathAuthority(ByVal SourceWebPage As System.Web.UI.Page, ByVal AuthorizePath As String) As Boolean
        If String.IsNullOrEmpty(AuthorizePath) Then
            Return False
        End If
        If AuthorizePath.ToUpper = "PUBLIC" Then
            Return True
        End If
        Dim SystemFunctions() As String = AuthorizePath.Split(",")
        For Each EachItem As String In SystemFunctions
            Dim Temps() As String = EachItem.Split("@")
            Select Case True
                Case Temps.Length = 1
                    If AppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem(Temps(0), Nothing, SourceWebPage.Request.UserHostAddress) Then
                        Return True
                    End If
                Case Temps.Length = 2
                    If AppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem(Temps(0), Temps(1), SourceWebPage.Request.UserHostAddress) Then
                        Return True
                    End If
                Case Else
                    Continue For
            End Select
        Next
        Return False
    End Function
#End Region
End Module

