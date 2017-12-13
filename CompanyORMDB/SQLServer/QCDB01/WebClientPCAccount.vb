Namespace SQLServer
	Namespace QCDB01
	Public Class WebClientPCAccount
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM,"QCDB01")
	End Sub

#Region "ClientIP 屬性:ClientIP"
	Private _ClientIP As System.String
	''' <summary>
	''' ClientIP
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ClientIP () As System.String
		Get
			Return _ClientIP
		End Get
		Set(Byval value as System.String)
			_ClientIP = value
		End Set
	End Property
#End Region
#Region "PCName 屬性:PCName"
	Private _PCName As System.String
	''' <summary>
	''' PCName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PCName () As System.String
		Get
			Return _PCName
		End Get
		Set(Byval value as System.String)
			_PCName = value
		End Set
	End Property
#End Region
#Region "Memo1 屬性:Memo1"
	Private _Memo1 As System.String
	''' <summary>
	''' Memo1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Memo1 () As System.String
		Get
			Return _Memo1
		End Get
		Set(Byval value as System.String)
			_Memo1 = value
		End Set
	End Property
#End Region
#Region "Email 屬性:Email"
	Private _Email As System.String
	''' <summary>
	''' Email
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Email () As System.String
		Get
			Return _Email
		End Get
		Set(Byval value as System.String)
			_Email = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace