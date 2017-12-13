Namespace SQLServer
	Namespace QCDB01
	Public Class PickGoodDetailQryLog
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "QueryTime 屬性:QueryTime"
	Private _QueryTime As System.DateTime
	''' <summary>
	''' QueryTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QueryTime () As System.DateTime
		Get
			Return _QueryTime
		End Get
		Set(Byval value as System.DateTime)
			_QueryTime = value
		End Set
	End Property
#End Region
#Region "LoginUserName 屬性:LoginUserName"
	Private _LoginUserName As System.String
	''' <summary>
	''' LoginUserName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property LoginUserName () As System.String
		Get
			Return _LoginUserName
		End Get
		Set(Byval value as System.String)
			_LoginUserName = value
		End Set
	End Property
#End Region
#Region "QueryUsers 屬性:QueryUsers"
	Private _QueryUsers As System.String
	''' <summary>
	''' QueryUsers
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QueryUsers () As System.String
		Get
			Return _QueryUsers
		End Get
		Set(Byval value as System.String)
			_QueryUsers = value
		End Set
	End Property
#End Region
#Region "CanQueryUsers 屬性:CanQueryUsers"
	Private _CanQueryUsers As System.String
	''' <summary>
	''' CanQueryUsers
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CanQueryUsers () As System.String
		Get
			Return _CanQueryUsers
		End Get
		Set(Byval value as System.String)
			_CanQueryUsers = value
		End Set
	End Property
#End Region
#Region "QueryLog 屬性:QueryLog"
	Private _QueryLog As System.String
	''' <summary>
	''' QueryLog
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QueryLog () As System.String
		Get
			Return _QueryLog
		End Get
		Set(Byval value as System.String)
			_QueryLog = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace