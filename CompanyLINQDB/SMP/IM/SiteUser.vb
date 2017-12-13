Partial Public Class SiteUser

    Dim WebAPPAuthorityDBDataContext As New WebAPPAuthorityDataContext
    Dim DBDataContext As New IMDataContext

#Region "使用者鍵值種類名稱 屬性:UserPKeyKindName"
    Private _UserPKeyKindName As String = Nothing
    ''' <summary>
    ''' 使用者鍵值種類名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property UserPKeyKindName() As String
        Get
            If IsNothing(_UserPKeyKindName) Then

                Select Case Me.UserPKeyKind
                    Case 1
                        _UserPKeyKindName = "電腦IP"
                    Case 2
                        _UserPKeyKindName = "Window登入帳號"
                End Select
            End If
            Return _UserPKeyKindName
        End Get
    End Property
#End Region

#Region "電腦名稱或使用者名稱 屬性:PCNameOrUserName"
    Private _PCNameOrUserName As String
    ''' <summary>
    ''' 電腦名稱或使用者名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PCNameOrUserName() As String
        Get
            If IsNothing(_PCNameOrUserName) Then
                Select Case Me.UserPKeyKind
                    Case 1
                        Dim FindObject As WebClientPCAccount = (From A In WebAPPAuthorityDBDataContext.WebClientPCAccount Where A.ClientIP = Me.UserPKey Select A).FirstOrDefault
                        If Not IsNothing(FindObject) Then
                            _PCNameOrUserName = "電腦名稱:" & FindObject.PCName.Trim & "(IP:" & FindObject.ClientIP.Trim & ")" & FindObject.Memo1.Trim
                        End If
                    Case 2
                        Dim FindObject As WebLoginAccount = (From A In WebAPPAuthorityDBDataContext.WebLoginAccount Where A.WindowLoginName = Me.UserPKey Select A).FirstOrDefault
                        If Not IsNothing(FindObject) Then
                            _PCNameOrUserName = "Window帳戶名稱:" & FindObject.DisplayName.Trim & FindObject.Memo1.Trim
                        End If
                End Select
            End If
            Return _PCNameOrUserName
        End Get
    End Property
#End Region
#Region "站台名稱 屬性:SiteName"

    Private _SiteName As String = Nothing
    ''' <summary>
    ''' 站台名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SiteName() As String
        Get
            If IsNothing(_SiteName) AndAlso Not IsNothing(AboutSite) Then
                _SiteName = AboutSite.SiteName
            End If
            Return _SiteName
        End Get
        Private Set(ByVal value As String)
            _SiteName = value
        End Set
    End Property

#End Region

#Region "相關用戶端PC帳號 屬性:AboutWebClientPCAccount"

    Private _AboutWebClientPCAccount As WebClientPCAccount = Nothing
    ''' <summary>
    ''' 相關用戶端PC帳號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutWebClientPCAccount() As WebClientPCAccount
        Get
            If Me.UserPKeyKind = 2 Then
                Return Nothing
            End If
            If IsNothing(_AboutWebClientPCAccount) Then
                _AboutWebClientPCAccount = (From A In WebAPPAuthorityDBDataContext.WebClientPCAccount Where A.ClientIP = Me.UserPKey Select A).FirstOrDefault
            End If
            Return _AboutWebClientPCAccount
        End Get
        Private Set(ByVal value As WebClientPCAccount)
            _AboutWebClientPCAccount = value
        End Set
    End Property

#End Region
#Region "相關Windows登入帳號 屬性:AboutWebLoginAccount"

    Private _AboutWebLoginAccount As WebLoginAccount = Nothing
    ''' <summary>
    ''' 相關Windows登入帳號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutWebLoginAccount() As WebLoginAccount
        Get
            If Me.UserPKeyKind = 1 Then
                Return Nothing
            End If
            If IsNothing(_AboutWebLoginAccount) Then
                _AboutWebLoginAccount = (From A In WebAPPAuthorityDBDataContext.WebLoginAccount Where A.WindowLoginName = Me.UserPKey Select A).FirstOrDefault
            End If
            Return _AboutWebLoginAccount
        End Get
        Private Set(ByVal value As WebLoginAccount)
            _AboutWebLoginAccount = value
        End Set
    End Property

#End Region
#Region "相關站台 屬性:AboutSite"

    Private _AboutSite As Site = Nothing
    ''' <summary>
    ''' 相關站台
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutSite() As Site
        Get
            If IsNothing(_AboutSite) Then
                _AboutSite = (From A In DBDataContext.Site Where A.ID = Me.FK_SiteID Select A).FirstOrDefault
            End If
            Return _AboutSite
        End Get
        Private Set(ByVal value As Site)
            _AboutSite = value
        End Set
    End Property

#End Region

End Class
