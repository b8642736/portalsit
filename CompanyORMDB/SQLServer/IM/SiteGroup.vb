Namespace SQLServer
	Namespace IM
	Public Class SiteGroup
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
#Region "GroupName 屬性:GroupName"
	Private _GroupName As System.String
	''' <summary>
	''' GroupName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property GroupName () As System.String
		Get
			Return _GroupName
		End Get
		Set(Byval value as System.String)
			_GroupName = value
		End Set
	End Property
#End Region
#Region "FK_SiteGroupID 屬性:FK_SiteGroupID"
	Private _FK_SiteGroupID As System.String
	''' <summary>
	''' FK_SiteGroupID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK_SiteGroupID () As System.String
		Get
			Return _FK_SiteGroupID
		End Get
		Set(Byval value as System.String)
			_FK_SiteGroupID = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace