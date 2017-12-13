Namespace SQLServer
	Namespace IM
	Public Class SiteGroupToSite
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"IM")
	End Sub

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
	End Class
	End Namespace
End Namespace