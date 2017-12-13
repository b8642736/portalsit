Namespace SQLServer
	Namespace QCDB01
	Public Class WebSystemFunction
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "FunctionCode 屬性:FunctionCode"
	Private _FunctionCode As System.String
	''' <summary>
	''' FunctionCode
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FunctionCode () As System.String
		Get
			Return _FunctionCode
		End Get
		Set(Byval value as System.String)
			_FunctionCode = value
		End Set
	End Property
#End Region
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
#Region "FunctionName 屬性:FunctionName"
	Private _FunctionName As System.String
	''' <summary>
	''' FunctionName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FunctionName () As System.String
		Get
			Return _FunctionName
		End Get
		Set(Byval value as System.String)
			_FunctionName = value
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