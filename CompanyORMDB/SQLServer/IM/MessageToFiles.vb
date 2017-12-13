Namespace SQLServer
	Namespace IM
	Public Class MessageToFiles
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
#Region "OrginFileName 屬性:OrginFileName"
	Private _OrginFileName As System.String
	''' <summary>
	''' OrginFileName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property OrginFileName () As System.String
		Get
			Return _OrginFileName
		End Get
		Set(Byval value as System.String)
			_OrginFileName = value
		End Set
	End Property
#End Region
#Region "SaveFileFullPath 屬性:SaveFileFullPath"
	Private _SaveFileFullPath As System.String
	''' <summary>
	''' SaveFileFullPath
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SaveFileFullPath () As System.String
		Get
			Return _SaveFileFullPath
		End Get
		Set(Byval value as System.String)
			_SaveFileFullPath = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace