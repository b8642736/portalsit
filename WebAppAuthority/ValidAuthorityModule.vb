Public Module ValidAuthorityModule

    Dim DBDataContext As New ClassDBDataContext

#Region "目前Windows登入帳號　屬性:CurrentWindowsLoginEmployeeNumber"
    ''' <summary>
    ''' 目前Windows登入帳號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentWindowsLoginEmployeeNumber() As String
        Get
            If String.IsNullOrEmpty(My.User.Name) Then
                Return Nothing
            End If
            Dim DomainUserString() As String = My.User.Name.Split("\")
            If DomainUserString.Length < 2 And DomainUserString(0).ToUpper <> "DOMAIN" And DomainUserString(0).ToUpper <> "TESSCO" Then
                Return Nothing
            End If
            Return DomainUserString(1)
        End Get
    End Property
#End Region
#Region "目前Windows登入姓名　屬性:CurrentWindowsLoginName"
    ''' <summary>
    ''' 目前Windows登入姓名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentWindowsLoginName() As String
        Get
            Dim EmployeeNumber As String = CurrentWindowsLoginEmployeeNumber
            If String.IsNullOrEmpty(EmployeeNumber) Then
                Return Nothing
            End If
            Dim GetCurrentAccount As CompanyLINQDB.WebLoginAccount = (From A In DBDataContext.WebLoginAccount Where A.WindowLoginName = EmployeeNumber Select A).FirstOrDefault
            If IsNothing(GetCurrentAccount) Then
                Return Nothing
            End If
            Return GetCurrentAccount.DisplayName
        End Get
    End Property
#End Region
#Region "目前登入授權模式  屬性:CurrentLoginMode"
    ''' <summary>
    ''' 目前登入授權模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentLoginMode() As LoginAuthorityModeType
        Get
            If Not IsNothing(CurrentWindowsLoginEmployeeNumber) Then
                Return LoginAuthorityModeType.WindowsAuthority
            End If
            Select Case True
                Case Not IsNothing(CurrentWindowsLoginEmployeeNumber)
                    Return LoginAuthorityModeType.WindowsAuthority
                Case Else
                    Return LoginAuthorityModeType.IPAuthority
            End Select
        End Get
    End Property

    Public Enum LoginAuthorityModeType
        WindowsAuthority = 0
        IPAuthority = 1
    End Enum
#End Region

#Region "驗證授權系統 函式:ValidAuthoritySystem"
    ''' <summary>
    ''' 驗證授權系統
    ''' </summary>
    ''' <param name="WebSystemCode"></param>
    ''' <param name="WebSystemFunctionCode"></param>
    ''' <remarks></remarks>
    Public Sub ValidAuthoritySystem(ByVal WebSystemCode As String, ByVal WebSystemFunctionCode As String, ByVal SourceWebPage As System.Web.UI.Page)
        If SourceWebPage.IsPostBack Then
            Exit Sub
        End If
        Dim LoginWindowAccount As String = CurrentWindowsLoginEmployeeNumber
        If Not AppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem(WebSystemCode, WebSystemFunctionCode, SourceWebPage.Request.UserHostAddress) Then
            WebAppAuthority.ChangeWebSitByAuthority.GoWebSitByWebAPPAuthority(SourceWebPage, "WebAppAuthority", "WebAuthorityFailPage.aspx")
        End If

    End Sub
#End Region

    '' 1050624 By JiaRong
    '' 解決UCAjaxServerControl1相依性問題
    '' 移動至AppAuthority之ValidAuthorityModule.vb
    '#Region "驗證是否可通過授權系統 方法:IsCanValidAuthoritySystem"
    '    ''' <summary>
    '    ''' 驗證是否可通過授權系統
    '    ''' </summary>
    '    ''' <param name="WebSystemCode"></param>
    '    ''' <param name="WebSystemFunctionCode"></param>
    '    ''' <param name="ValidClientPCIP">增加使用者IP授權</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function IsCanValidAuthoritySystem(ByVal WebSystemCode As String, Optional ByVal WebSystemFunctionCode As String = Nothing, Optional ByVal ValidClientPCIP As String = Nothing) As Boolean
    '        Static Mut As New Threading.Mutex
    '        Mut.WaitOne()
    '        '個別方式授權
    '        Dim LoginWindowAccount As String = CurrentWindowsLoginEmployeeNumber
    '        If Not IsNothing(IsNothing(LoginWindowAccount)) AndAlso (From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = LoginWindowAccount And A.FK_SystemCode = WebSystemCode And (String.IsNullOrEmpty(WebSystemFunctionCode) Or A.FK_SystemFunctionCode = WebSystemFunctionCode) Select A).Any Then
    '            Mut.ReleaseMutex()
    '            Return True
    '        End If
    '        '群組方式授權
    '        Dim WebSystemFunctionForWebGroupAuthority_GroupCodes As List(Of String) = (From A In DBDataContext.WebGroupAuthority Where A.FK_SystemCode = WebSystemCode And (String.IsNullOrEmpty(WebSystemFunctionCode) Or A.FK_SystemFunctionCode = WebSystemFunctionCode) Select A.GroupCode).ToList
    '        If Not IsNothing(IsNothing(LoginWindowAccount)) AndAlso (From A In DBDataContext.WebLoginAccountToWebGroupAccount Where A.WindowLoginName = LoginWindowAccount And WebSystemFunctionForWebGroupAuthority_GroupCodes.Contains(A.GroupCode) Select A).Any Then
    '            Mut.ReleaseMutex()
    '            Return True
    '        End If

    '        Dim ClientIP As System.Net.IPAddress = Nothing
    '        If Not IsNothing(ValidClientPCIP) AndAlso System.Net.IPAddress.TryParse(ValidClientPCIP, ClientIP) Then
    '            '個別方式授權
    '            If (From A In DBDataContext.WebClientPCAuthority Where A.FKWebClientPCAccount_ClientIP = ValidClientPCIP And A.FK_SystemCode = WebSystemCode And (String.IsNullOrEmpty(WebSystemFunctionCode) Or A.FK_SystemFunctionCode = WebSystemFunctionCode) Select A).Any Then
    '                Mut.ReleaseMutex()
    '                Return True
    '            End If
    '            '群組方式授權
    '            If (From A In DBDataContext.WebClientPCAccountTOWebGroupAccount Where A.ClientIP = ValidClientPCIP And WebSystemFunctionForWebGroupAuthority_GroupCodes.Contains(A.GroupCode) Select A).Any Then
    '                Mut.ReleaseMutex()
    '                Return True
    '            End If
    '        End If
    '        Mut.ReleaseMutex()
    '    End Function


    '#End Region

    '#Region "驗證使用者是否可通過授權系統 方法:IsUserCanValidAuthoritySystem"
    '    ''' <summary>
    '    ''' 驗證使用者是否可通過授權系統
    '    ''' </summary>
    '    ''' <param name="WebSystemCode"></param>
    '    ''' <param name="WebSystemFunctionCode"></param>
    '    ''' <param name="FindLoginWindowAccount"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function IsUserCanValidAuthoritySystem(ByVal WebSystemCode As String, ByVal WebSystemFunctionCode As String, ByVal FindLoginWindowAccount As String) As Boolean
    '        '個別方式授權
    '        Dim LoginWindowAccount As String = CurrentWindowsLoginEmployeeNumber
    '        If Not IsNothing(IsNothing(LoginWindowAccount)) AndAlso (From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = FindLoginWindowAccount And A.FK_SystemCode = WebSystemCode And A.FK_SystemFunctionCode = WebSystemFunctionCode Select A).Any Then
    '            Return True
    '        End If
    '        '群組方式授權
    '        Dim WebSystemFunctionForWebGroupAuthority_GroupCodes As List(Of String) = (From A In DBDataContext.WebGroupAuthority Where A.FK_SystemCode = WebSystemCode And A.FK_SystemFunctionCode = WebSystemFunctionCode Select A.GroupCode).ToList
    '        If Not IsNothing(IsNothing(FindLoginWindowAccount)) AndAlso (From A In DBDataContext.WebLoginAccountToWebGroupAccount Where A.WindowLoginName = FindLoginWindowAccount And WebSystemFunctionForWebGroupAuthority_GroupCodes.Contains(A.GroupCode) Select A).Any Then
    '            Return True
    '        End If
    '        Return False
    '    End Function
    '#End Region
    '#Region "驗證網路IP者是否可通過授權系統 方法:IsNetworkIPCanValidAuthoritySystem"
    '    ''' <summary>
    '    ''' 驗證網路IP者是否可通過授權系統
    '    ''' </summary>
    '    ''' <param name="WebSystemCode"></param>
    '    ''' <param name="WebSystemFunctionCode"></param>
    '    ''' <param name="ValidClientPCIP"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function IsNetworkIPCanValidAuthoritySystem(ByVal WebSystemCode As String, ByVal WebSystemFunctionCode As String, ByVal ValidClientPCIP As String) As Boolean
    '        Dim ClientIP As System.Net.IPAddress = Nothing
    '        If Not IsNothing(ValidClientPCIP) AndAlso System.Net.IPAddress.TryParse(ValidClientPCIP, ClientIP) Then
    '            '個別方式授權
    '            If (From A In DBDataContext.WebClientPCAuthority Where A.FKWebClientPCAccount_ClientIP = ValidClientPCIP And A.FK_SystemCode = WebSystemCode And A.FK_SystemFunctionCode = WebSystemFunctionCode Select A).Any Then
    '                Return True
    '            End If
    '            '群組方式授權
    '            Dim WebSystemFunctionForWebGroupAuthority_GroupCodes As List(Of String) = (From A In DBDataContext.WebGroupAuthority Where A.FK_SystemCode = WebSystemCode And A.FK_SystemFunctionCode = WebSystemFunctionCode Select A.GroupCode).ToList
    '            If (From A In DBDataContext.WebClientPCAccountTOWebGroupAccount Where A.ClientIP = ValidClientPCIP And WebSystemFunctionForWebGroupAuthority_GroupCodes.Contains(A.GroupCode) Select A).Any Then
    '                Return True
    '            End If
    '        End If
    '        Return False
    '    End Function
    '#End Region

End Module
