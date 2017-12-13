Namespace SQLServer
	Namespace IM
	Public Class Site
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"IM")
	End Sub

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
#Region "SiteName 屬性:SiteName"
	Private _SiteName As System.String
	''' <summary>
	''' SiteName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SiteName () As System.String
		Get
			Return _SiteName
		End Get
		Set(Byval value as System.String)
			_SiteName = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace