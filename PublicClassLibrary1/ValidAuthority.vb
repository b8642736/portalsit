Public Class ValidAuthority

    Dim QryAdapter As New CompanyORMDB.ORMBaseClass.ClassDBSQLServer(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM, "QCDB01")

    Sub New(ByVal SetWindowLoginFullName As String, ByVal SetClientIP As String)
        Me.WindowLoginFullName = SetWindowLoginFullName
        Me.ClientIP = SetClientIP
    End Sub

#Region "Window登入完整名稱 屬性:WindowLoginFullName"

    Private _WindowLoginFullName As String = Nothing
    ''' <summary>
    ''' Window登入完整名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WindowLoginFullName() As String
        Get
            Return _WindowLoginFullName
        End Get
        Private Set(ByVal value As String)
            _WindowLoginFullName = value
        End Set
    End Property

#End Region
#Region "Window登入名稱 屬性:WindowLoginName"
    ''' <summary>
    ''' Window登入名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WindowLoginName() As String
        Get
            If IsNothing(Me.WindowLoginFullName) Then
                Return Nothing
            End If
            Dim Names() As String = Me.WindowLoginFullName.Split("\")
            If Names.Length <= 1 OrElse Names(0).ToUpper <> "DOMAIN" Then
                Return Nothing
            End If
            Return Names(1)
        End Get
    End Property
#End Region
#Region "用戶端IP 屬性:ClientIP"


    Private _ClientIP As String = Nothing
    ''' <summary>
    ''' 用戶端IP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ClientIP() As String
        Get
            Return _ClientIP
        End Get
        Private Set(ByVal value As String)
            _ClientIP = value
        End Set
    End Property


#End Region
#Region "驗證是否可通過系統授權 方法:IsCanValidAuthoritySystem"
    ''' <summary>
    ''' 驗證是否可通過系統授權
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsCanValidAuthoritySystem(ByVal WebSystemCode As String) As Boolean
        Return IsCanValidAuthoritySystemFunction(WebSystemCode, Nothing)
    End Function
#End Region
#Region "驗證是否可通過系統功能授權 方法:IsCanValidAuthoritySystemFunction"
    ''' <summary>
    ''' 驗證是否可通過系統功能授權
    ''' </summary>
    ''' <param name="WebSystemCode"></param>
    ''' <param name="WebSystemFunctionCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsCanValidAuthoritySystemFunction(ByVal WebSystemCode As String, ByVal WebSystemFunctionCode As String) As Boolean
        Dim QryString As String = Nothing
        Dim QryString0 As String = "Select GroupCode From WebGroupAuthority Where FK_SystemCode='" & WebSystemCode & "' AND FK_SystemFunctionCode='" & WebSystemFunctionCode & "'"
        If Not IsNothing(Me.WindowLoginName) AndAlso Me.WindowLoginName.Trim.Length > 0 Then
            '個別方式授權
            QryString = "Select count(*) from WebUserAuthority Where FKWebLoginAccount_WindowLoginName='" & Me.WindowLoginName & "' AND FK_SystemCode='" & WebSystemCode & "'" & IIf(String.IsNullOrEmpty(WebSystemFunctionCode), Nothing, " AND FK_SystemFunctionCode='" & WebSystemFunctionCode & "'")
            Dim aa As DataTable = QryAdapter.CDBCurrentUseSQLQueryAdapter.SelectQuery(QryString)

            If CType(QryAdapter.CDBCurrentUseSQLQueryAdapter.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0 Then
                Return True
            End If
            '群組方式授權
            QryString = "Select count(*) from WebLoginAccountToWebGroupAccount Where WindowLoginName='" & Me.WindowLoginName & "' AND GroupCode in (" & QryString0 & ")"
            If CType(QryAdapter.CDBCurrentUseSQLQueryAdapter.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0 Then
                Return True
            End If
        End If

        If Not IsNothing(Me.ClientIP) AndAlso Me.ClientIP.Trim.Length > 0 Then
            '個別方式授權
            QryString = "Select count(*) from WebClientPCAuthority Where FKWebClientPCAccount_ClientIP='" & Me.ClientIP & "' AND FK_SystemCode='" & WebSystemCode & "'" & IIf(String.IsNullOrEmpty(WebSystemFunctionCode), Nothing, " AND FK_SystemFunctionCode='" & WebSystemFunctionCode & "'")
            If CType(QryAdapter.CDBCurrentUseSQLQueryAdapter.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0 Then
                Return True
            End If
            '群組方式授權
            QryString = "Select count(*) from WebClientPCAccountTOWebGroupAccount Where ClientIP='" & Me.ClientIP & "' AND GroupCode in (" & QryString0 & ")"
            If CType(QryAdapter.CDBCurrentUseSQLQueryAdapter.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0 Then
                Return True
            End If
        End If

        Return False
    End Function
#End Region

End Class
