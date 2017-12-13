Namespace SQLServer
	Namespace IM
	Public Class SiteUser
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"IM")
	End Sub

#Region "FK_SiteID 屬性:FK_SiteID"
	Private _FK_SiteID As System.String
	''' <summary>
	''' FK_SiteID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK_SiteID () As System.String
		Get
			Return _FK_SiteID
		End Get
		Set(Byval value as System.String)
			_FK_SiteID = value
		End Set
	End Property
#End Region
#Region "ID 屬性:ID"
	Private _ID As System.String
	''' <summary>
	''' ID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ID () As System.String
		Get
			Return _ID
		End Get
		Set(Byval value as System.String)
			_ID = value
		End Set
	End Property
#End Region
#Region "UserPKeyKind 屬性:UserPKeyKind"
	Private _UserPKeyKind As System.Int32
	''' <summary>
	''' UserPKeyKind
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property UserPKeyKind () As System.Int32
		Get
			Return _UserPKeyKind
		End Get
		Set(Byval value as System.Int32)
			_UserPKeyKind = value
		End Set
	End Property
#End Region
#Region "UserPKey 屬性:UserPKey"
	Private _UserPKey As System.String
	''' <summary>
	''' UserPKey
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property UserPKey () As System.String
		Get
			Return _UserPKey
		End Get
		Set(Byval value as System.String)
			_UserPKey = value
		End Set
	End Property
#End Region
#Region "預設連線伺服器IP 屬性:DefaultUseServerIP"

            Private _DefaultUseServerIP As String
            ''' <summary>
            ''' 預設連線伺服器IP
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DefaultUseServerIP() As String
                Get
                    Return _DefaultUseServerIP
                End Get
                Set(ByVal value As String)
                    _DefaultUseServerIP = value
                End Set
            End Property

#End Region


#Region "取得所有登入使用者 方法:GetALLSiteUsers"
            ''' <summary>
            ''' 取得所有登入使用者
            ''' </summary>
            ''' <param name="SetSQLServerSQLQueryAdapter"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function GetALLSiteUsers(ByVal SetSQLServerSQLQueryAdapter As CompanyORMDB.SQLServerSQLQueryAdapter) As List(Of SiteUser)
                Return SiteUser.CDBSelect(Of SiteUser)("Select * from SiteUser ", SetSQLServerSQLQueryAdapter)
            End Function
#End Region

	End Class
	End Namespace
End Namespace