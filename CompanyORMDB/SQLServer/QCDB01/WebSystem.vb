Namespace SQLServer
	Namespace QCDB01
	Public Class WebSystem
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "SystemCode 屬性:SystemCode"
	Private _SystemCode As System.String
	''' <summary>
	''' SystemCode
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SystemCode () As System.String
		Get
			Return _SystemCode
		End Get
		Set(Byval value as System.String)
			_SystemCode = value
		End Set
	End Property
#End Region
#Region "SystemName 屬性:SystemName"
	Private _SystemName As System.String
	''' <summary>
	''' SystemName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SystemName () As System.String
		Get
			Return _SystemName
		End Get
		Set(Byval value as System.String)
			_SystemName = value
		End Set
	End Property
#End Region
#Region "Description 屬性:Description"
	Private _Description As System.String
	''' <summary>
	''' Description
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Description () As System.String
		Get
			Return _Description
		End Get
		Set(Byval value as System.String)
			_Description = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace