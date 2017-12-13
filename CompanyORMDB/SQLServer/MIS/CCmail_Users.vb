Namespace SQLServer
	Namespace MIS
	Public Class CCmail_Users
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM,"MIS")
	End Sub

#Region "uid_XML 屬性:uid_XML"
	Private _uid_XML As System.String
	''' <summary>
	''' uid_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property uid_XML () As System.String
		Get
			Return _uid_XML
		End Get
		Set(Byval value as System.String)
			_uid_XML = value
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
#Region "password_XML 屬性:password_XML"
	Private _password_XML As System.String
	''' <summary>
	''' password_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property password_XML () As System.String
		Get
			Return _password_XML
		End Get
		Set(Byval value as System.String)
			_password_XML = value
		End Set
	End Property
#End Region
#Region "email_XML 屬性:email_XML"
	Private _email_XML As System.String
	''' <summary>
	''' email_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property email_XML () As System.String
		Get
			Return _email_XML
		End Get
		Set(Byval value as System.String)
			_email_XML = value
		End Set
	End Property
#End Region
#Region "employeeNum_XML 屬性:employeeNum_XML"
	Private _employeeNum_XML As System.String
	''' <summary>
	''' employeeNum_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property employeeNum_XML () As System.String
		Get
			Return _employeeNum_XML
		End Get
		Set(Byval value as System.String)
			_employeeNum_XML = value
		End Set
	End Property
#End Region
#Region "cn_XML 屬性:cn_XML"
	Private _cn_XML As System.String
	''' <summary>
	''' cn_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property cn_XML () As System.String
		Get
			Return _cn_XML
		End Get
		Set(Byval value as System.String)
			_cn_XML = value
		End Set
	End Property
#End Region
#Region "o_XML 屬性:o_XML"
	Private _o_XML As System.String
	''' <summary>
	''' o_XML
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property o_XML () As System.String
		Get
			Return _o_XML
		End Get
		Set(Byval value as System.String)
			_o_XML = value
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
#Region "executeDate 屬性:executeDate"
	Private _executeDate As System.DateTime
	''' <summary>
	''' executeDate
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property executeDate () As System.DateTime
		Get
			Return _executeDate
		End Get
		Set(Byval value as System.DateTime)
			_executeDate = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace