Namespace SQLServer
	Namespace IM
	Public Class SiteGroupToMessage
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
#Region "FK_MessageID 屬性:FK_MessageID"
	Private _FK_MessageID As System.String
	''' <summary>
	''' FK_MessageID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK_MessageID () As System.String
		Get
			Return _FK_MessageID
		End Get
		Set(Byval value as System.String)
			_FK_MessageID = value
		End Set
	End Property
#End Region
#Region "ReadWriteMode 屬性:ReadWriteMode"
	Private _ReadWriteMode As System.Int32
	''' <summary>
	''' ReadWriteMode
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ReadWriteMode () As System.Int32
		Get
			Return _ReadWriteMode
		End Get
		Set(Byval value as System.Int32)
			_ReadWriteMode = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace