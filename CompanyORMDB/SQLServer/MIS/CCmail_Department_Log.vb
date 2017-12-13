Namespace SQLServer
	Namespace MIS
	Public Class CCmail_Department_Log
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM,"MIS")
	End Sub

#Region "o_XML 屬性:o_XML"
	Private _o_XML As System.String
	''' <summary>
	''' o_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property o_XML () As System.String
		Get
			Return _o_XML
		End Get
		Set(Byval value as System.String)
			_o_XML = value
		End Set
	End Property
#End Region
#Region "orgId_XML 屬性:orgId_XML"
	Private _orgId_XML As System.String
	''' <summary>
	''' orgId_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property orgId_XML () As System.String
		Get
			Return _orgId_XML
		End Get
		Set(Byval value as System.String)
			_orgId_XML = value
		End Set
	End Property
#End Region
#Region "kind 屬性:kind"
	Private _kind As System.String
	''' <summary>
	''' kind
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property kind () As System.String
		Get
			Return _kind
		End Get
		Set(Byval value as System.String)
			_kind = value
		End Set
	End Property
#End Region
#Region "sequence_XML 屬性:sequence_XML"
	Private _sequence_XML As System.Int32
	''' <summary>
	''' sequence_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property sequence_XML () As System.Int32
		Get
			Return _sequence_XML
		End Get
		Set(Byval value as System.Int32)
			_sequence_XML = value
		End Set
	End Property
#End Region
#Region "displayName_XML 屬性:displayName_XML"
	Private _displayName_XML As System.String
	''' <summary>
	''' displayName_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property displayName_XML () As System.String
		Get
			Return _displayName_XML
		End Get
		Set(Byval value as System.String)
			_displayName_XML = value
		End Set
	End Property
#End Region
#Region "parentOrgId_XML 屬性:parentOrgId_XML"
	Private _parentOrgId_XML As System.String
	''' <summary>
	''' parentOrgId_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property parentOrgId_XML () As System.String
		Get
			Return _parentOrgId_XML
		End Get
		Set(Byval value as System.String)
			_parentOrgId_XML = value
		End Set
	End Property
#End Region
#Region "deptCode 屬性:deptCode"
	Private _deptCode As System.String
	''' <summary>
	''' deptCode
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property deptCode () As System.String
		Get
			Return _deptCode
		End Get
		Set(Byval value as System.String)
			_deptCode = value
		End Set
	End Property
#End Region
#Region "deptName 屬性:deptName"
	Private _deptName As System.String
	''' <summary>
	''' deptName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property deptName () As System.String
		Get
			Return _deptName
		End Get
		Set(Byval value as System.String)
			_deptName = value
		End Set
	End Property
#End Region
#Region "status 屬性:status"
	Private _status As System.String
	''' <summary>
	''' status
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property status () As System.String
		Get
			Return _status
		End Get
		Set(Byval value as System.String)
			_status = value
		End Set
	End Property
#End Region
#Region "modiDate 屬性:modiDate"
	Private _modiDate As System.DateTime
	''' <summary>
	''' modiDate
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property modiDate () As System.DateTime
		Get
			Return _modiDate
		End Get
		Set(Byval value as System.DateTime)
			_modiDate = value
		End Set
	End Property
#End Region
#Region "stage 屬性:stage"
	Private _stage As System.String
	''' <summary>
	''' stage
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property stage () As System.String
		Get
			Return _stage
		End Get
		Set(Byval value as System.String)
			_stage = value
		End Set
	End Property
#End Region
#Region "ModifiedDate 屬性:ModifiedDate"
	Private _ModifiedDate As System.DateTime
	''' <summary>
	''' ModifiedDate
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ModifiedDate () As System.DateTime
		Get
			Return _ModifiedDate
		End Get
		Set(Byval value as System.DateTime)
			_ModifiedDate = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace