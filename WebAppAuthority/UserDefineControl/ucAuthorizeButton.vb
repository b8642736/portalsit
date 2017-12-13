Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<DefaultProperty("Text"), ToolboxData("<{0}:ucAuthorizeButton runat=server></{0}:ucAuthorizeButton>")> _
Public Class ucAuthorizeButton
    'By JiaRong 1060630
    '由於WebAppAuthority的button幾乎都是這個類別  
    '因此不改參考  將該類別繼承UCA專案  減少維護難易度
    Inherits UCAjaxServerControl1.ucAuthorizeButton
    'Inherits Button
    '#Region "授權路徑 屬性:AuthorizePath"

    '    Private _AuthorizePath As String
    '    ''' <summary>
    '    ''' 授權路徑
    '    ''' </summary>
    '    ''' <value></value>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    <Bindable(True), Category("Appearance"), Description("授權路徑:格式==>站名@授權代碼"), DefaultValue("PUBLIC"), Localizable(True)> _
    '    Public Property AuthorizePath() As String
    '        Get
    '            If IsNothing(ViewState("_AuthorizePath")) Then
    '                Return String.Empty
    '            End If
    '            Return CStr(ViewState("_AuthorizePath"))
    '        End Get
    '        Set(ByVal value As String)
    '            ViewState("_AuthorizePath") = value
    '        End Set
    '    End Property
    '#End Region

    '#Region "開啟控制項路徑 屬性:OpenControlPath"
    '    ''' <summary>
    '    ''' 開啟控制項路徑
    '    ''' </summary>
    '    ''' <value></value>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    <Bindable(True), Category("Appearance"), Description("開啟控制項路徑:格式==>站名@網頁名"), DefaultValue(""), Localizable(True)> _
    '    Public Property OpenControlPath() As String
    '        Get
    '            If IsNothing(ViewState("_OpenControlPath")) Then
    '                Return String.Empty
    '            End If
    '            Return CStr(ViewState("_OpenControlPath"))
    '        End Get
    '        Set(ByVal value As String)
    '            ViewState("_OpenControlPath") = value
    '        End Set
    '    End Property
    '#End Region

    '#Region "驗證後啟動或關閉 函式:VaildEnableOrDisable"
    '    ''' <summary>
    '    ''' 驗證後啟動或關閉
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public Sub VaildToEnableOrDisable()
    '        Dim EmployeeNumber As String = ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber
    '        If Not IsNothing(EmployeeNumber) AndAlso (EmployeeNumber.Trim = "30276" Or EmployeeNumber.Trim = "30110") Then
    '            Me.Enabled = True : Exit Sub
    '        End If
    '        'by JiaRong 1050624
    '        'Me.Enabled = WebAppAuthority.IsPathAuthority(Page, AuthorizePath)
    '        Me.Enabled = AppAuthority.IsPathAuthority(Page, AuthorizePath)

    '    End Sub
    '#End Region

    '#Region "驗證後顯示或移除 函式:VaildToVisible"
    '    ''' <summary>
    '    ''' 驗證後顯示或移除
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public Sub VaildShowOrRemove()
    '        Dim EmployeeNumber As String = ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber
    '        If Not IsNothing(EmployeeNumber) AndAlso (EmployeeNumber.Trim = "30276" Or EmployeeNumber.Trim = "30110") Then
    '            Me.Visible = True : Exit Sub
    '        End If

    '        'by JiaRong 1050624
    '        'Me.Visible = WebAppAuthority.IsPathAuthority(Page, AuthorizePath)
    '        Me.Visible = AppAuthority.IsPathAuthority(Page, AuthorizePath)

    '    End Sub
    '#End Region

    '#Region "驗證後導向指定網頁 函式:ValidRedirectSitePage"
    '    ''' <summary>
    '    ''' 驗證後導向指定網頁
    '    ''' </summary>
    '    ''' <returns>回傳錯誤訊息</returns>
    '    ''' <remarks></remarks>
    '    Function ValidRedirectSitePage() As String

    '        'by JiaRong 1050624
    '        'If AutoValidMode <> AutoValidModeEmum.None AndAlso WebAppAuthority.IsPathAuthority(Page, AuthorizePath) = False Then
    '        If AutoValidMode <> AutoValidModeEmum.None AndAlso AppAuthority.IsPathAuthority(Page, AuthorizePath) = False Then
    '            Return "授權驗證失敗!(" & AuthorizePath & ")"
    '        End If
    '        Try
    '            If OpenControlPath.Split("@").Count > 1 Then
    '                RedirectSitePage(OpenControlPath.Split("@")(0), OpenControlPath.Split("@")(1))
    '            Else
    '                RedirectSitePage(OpenControlPath.Split("@")(0))
    '            End If

    '        Catch ex As Exception
    '            Return ex.ToString
    '        End Try
    '        Return String.Empty
    '    End Function
    '#End Region

    '#Region "重新導向站台及開啟的網頁 函式:RedirectSitePage"
    '    ''' <summary>
    '    ''' 重新導向站台及開啟的網頁
    '    ''' </summary>
    '    ''' <param name="SiteName"></param>
    '    ''' <param name="OpenPageFullName"></param>
    '    ''' <remarks></remarks>
    '    Private Sub RedirectSitePage(ByVal SiteName As String, Optional OpenPageFullName As String = Nothing)
    '        Dim ReturnValue As String = "Http://"
    '        'ReturnValue &= IIf(Page.Request.ServerVariables.Item("LOCAL_ADDR").Substring(0, 2) = "::", "localhost", Page.Request.ServerVariables.Item("LOCAL_ADDR")) & "/" & SiteName.Replace("/", "")
    '        'If Not String.IsNullOrEmpty(OpenPageFullName) Then
    '        '    ReturnValue &= "/" & OpenPageFullName.Replace("/", Nothing)
    '        'End If

    '        Try
    '            'ReturnValue &= Page.Request.Url.Authority
    '            ReturnValue &= Page.Request.Url.Host
    '            ReturnValue &= ":" & Page.Request.Url.Port

    '            Dim ApplicationPath As String = Page.Request.ApplicationPath
    '            If ApplicationPath <> "/" Then
    '                SiteName = "/" & SiteName
    '                If (ApplicationPath.Length >= SiteName.Length) AndAlso (Mid(ApplicationPath, 1, SiteName.Length + 1) = SiteName + "_") Then
    '                    ReturnValue &= ApplicationPath
    '                Else
    '                    ReturnValue &= SiteName
    '                End If
    '            End If


    '            If Not String.IsNullOrEmpty(OpenPageFullName) Then
    '                ReturnValue &= "/" & OpenPageFullName.Replace("/", Nothing)
    '            End If
    '        Catch ex As Exception
    '            ReturnValue = "http://www.google.com.tw"
    '        End Try

    '        Page.Response.Redirect(ReturnValue)
    '    End Sub
    '#End Region

    '#Region "自動驗證模式 屬性:AutoValidMode"

    '    Public Property AutoValidMode() As AutoValidModeEmum
    '        Get
    '            If IsNothing(ViewState("_AutoValidMode")) Then
    '                Me.ViewState("_AutoValidMode") = AutoValidModeEmum.None
    '            End If
    '            Return CType(Me.ViewState("_AutoValidMode"), AutoValidModeEmum)
    '        End Get
    '        Set(ByVal value As AutoValidModeEmum)
    '            Me.ViewState("_AutoValidMode") = value
    '        End Set
    '    End Property

    '    Public Enum AutoValidModeEmum
    '        None = 0
    '        VaildToEnableOrDisable = 1
    '        VaildToVisible = 2
    '    End Enum
    '#End Region

    '#Region "錯誤訊息 屬性:ErrorMessage"
    '    ''' <summary>
    '    ''' 錯誤訊息
    '    ''' </summary>
    '    ''' <value></value>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Property ErrorMessage() As String
    '        Get
    '            If IsNothing(ViewState("_ErrorMessage")) Then
    '                Me.ViewState("_ErrorMessage") = AutoValidModeEmum.None
    '            End If
    '            Return Me.ViewState("_ErrorMessage")
    '        End Get
    '        Set(ByVal value As String)
    '            Me.ViewState("_ErrorMessage") = value
    '        End Set
    '    End Property

    '#End Region

    '    Private Sub ucAuthorizeButton_Click(sender As Object, e As System.EventArgs) Handles Me.Click
    '        ErrorMessage = ValidRedirectSitePage()
    '        If Not String.IsNullOrEmpty(ErrorMessage) Then
    '            ErrorMessage = "驗證失敗無法前往指定網頁!" & ErrorMessage
    '        End If
    '    End Sub


    '    '<Bindable(True), Category("Appearance"), DefaultValue(""), Localizable(True)> Property Text() As String
    '    '    Get
    '    '        Dim s As String = CStr(ViewState("Text"))
    '    '        If s Is Nothing Then
    '    '            Return String.Empty
    '    '        Else
    '    '            Return s
    '    '        End If
    '    '    End Get

    '    '    Set(ByVal Value As String)
    '    '        ViewState("Text") = Value
    '    '    End Set
    '    'End Property

    '    'Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
    '    '    writer.Write(Text)
    '    'End Sub

    '    Private Sub ucAuthorizeButton_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    '        If Not Me.Page.IsPostBack Then
    '            Select Case AutoValidMode
    '                Case AutoValidModeEmum.None
    '                Case AutoValidModeEmum.VaildToEnableOrDisable
    '                    Call VaildToEnableOrDisable()
    '                Case AutoValidModeEmum.VaildToVisible
    '                    Call VaildShowOrRemove()
    '            End Select
    '        End If
    '    End Sub

End Class
