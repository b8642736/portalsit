Namespace SQLServer
	Namespace QCDB01
	Public Class WebLoginAccountToPickGoodDetail
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "WindowLoginName 屬性:WindowLoginName"
	Private _WindowLoginName As System.String
	''' <summary>
	''' WindowLoginName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WindowLoginName () As System.String
		Get
			Return _WindowLoginName
		End Get
		Set(Byval value as System.String)
			_WindowLoginName = value
		End Set
	End Property
#End Region
#Region "CUA01 屬性:CUA01"
	Private _CUA01 As System.String
	''' <summary>
	''' CUA01
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CUA01 () As System.String
		Get
			Return _CUA01
		End Get
		Set(Byval value as System.String)
			_CUA01 = value
		End Set
	End Property
#End Region
#Region "AuthorizationTime 屬性:AuthorizationTime"
	Private _AuthorizationTime As System.DateTime
	''' <summary>
	''' AuthorizationTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property AuthorizationTime () As System.DateTime
		Get
			Return _AuthorizationTime
		End Get
		Set(Byval value as System.DateTime)
			_AuthorizationTime = value
		End Set
	End Property
#End Region
#Region "AuthorizationStartTime 屬性:AuthorizationStartTime"
	Private _AuthorizationStartTime As System.DateTime
	''' <summary>
	''' AuthorizationStartTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property AuthorizationStartTime () As System.DateTime
		Get
			Return _AuthorizationStartTime
		End Get
		Set(Byval value as System.DateTime)
			_AuthorizationStartTime = value
		End Set
	End Property
#End Region
#Region "AuthorizationDueTime 屬性:AuthorizationDueTime"
	Private _AuthorizationDueTime As System.DateTime
	''' <summary>
	''' AuthorizationDueTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property AuthorizationDueTime () As System.DateTime
		Get
			Return _AuthorizationDueTime
		End Get
		Set(Byval value as System.DateTime)
			_AuthorizationDueTime = value
		End Set
	End Property
#End Region
#Region "IsCancellation 屬性:IsCancellation"
	Private _IsCancellation As System.Boolean
	''' <summary>
	''' IsCancellation
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property IsCancellation () As System.Boolean
		Get
			Return _IsCancellation
		End Get
		Set(Byval value as System.Boolean)
			_IsCancellation = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace