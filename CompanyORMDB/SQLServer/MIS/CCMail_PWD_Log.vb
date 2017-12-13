Namespace SQLServer
	Namespace MIS
	Public Class CCMail_PWD_Log
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"MIS")
	End Sub

#Region "uid 屬性:uid"
	Private _uid As System.String
	''' <summary>
	''' uid
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property uid () As System.String
		Get
			Return _uid
		End Get
		Set(Byval value as System.String)
			_uid = value
		End Set
	End Property
#End Region
#Region "pwd 屬性:pwd"
	Private _pwd As System.String
	''' <summary>
	''' pwd
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property pwd () As System.String
		Get
			Return _pwd
		End Get
		Set(Byval value as System.String)
			_pwd = value
		End Set
	End Property
#End Region
#Region "excuteResult 屬性:excuteResult"
	Private _excuteResult As System.String
	''' <summary>
	''' excuteResult
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property excuteResult () As System.String
		Get
			Return _excuteResult
		End Get
		Set(Byval value as System.String)
			_excuteResult = value
		End Set
	End Property
#End Region
#Region "excutePeople 屬性:excutePeople"
	Private _excutePeople As System.String
	''' <summary>
	''' excutePeople
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property excutePeople () As System.String
		Get
			Return _excutePeople
		End Get
		Set(Byval value as System.String)
			_excutePeople = value
		End Set
	End Property
#End Region
#Region "excuteIP 屬性:excuteIP"
	Private _excuteIP As System.String
	''' <summary>
	''' excuteIP
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property excuteIP () As System.String
		Get
			Return _excuteIP
		End Get
		Set(Byval value as System.String)
			_excuteIP = value
		End Set
	End Property
#End Region
#Region "excuteTime 屬性:excuteTime"
	Private _excuteTime As System.DateTime
	''' <summary>
	''' excuteTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property excuteTime () As System.DateTime
		Get
			Return _excuteTime
		End Get
		Set(Byval value as System.DateTime)
			_excuteTime = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace