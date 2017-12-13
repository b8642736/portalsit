Namespace SQLServer
	Namespace PPS100LB
	Public Class L2APLConnectRecord
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "LineName 屬性:LineName"
	Private _LineName As System.String
	''' <summary>
	''' LineName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property LineName () As System.String
		Get
			Return _LineName
		End Get
		Set(Byval value as System.String)
			_LineName = value
		End Set
	End Property
#End Region
#Region "ConnectID 屬性:ConnectID"
	Private _ConnectID As System.String
	''' <summary>
	''' ConnectID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ConnectID () As System.String
		Get
			Return _ConnectID
		End Get
		Set(Byval value as System.String)
			_ConnectID = value
		End Set
	End Property
#End Region
#Region "ConnectInStoveTime 屬性:ConnectInStoveTime"
	Private _ConnectInStoveTime As System.DateTime
	''' <summary>
	''' ConnectInStoveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ConnectInStoveTime () As System.DateTime
		Get
			Return _ConnectInStoveTime
		End Get
		Set(Byval value as System.DateTime)
			_ConnectInStoveTime = value
		End Set
	End Property
#End Region
#Region "ConnectOutStoveTime 屬性:ConnectOutStoveTime"
	Private _ConnectOutStoveTime As System.DateTime
	''' <summary>
	''' ConnectOutStoveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ConnectOutStoveTime () As System.DateTime
		Get
			Return _ConnectOutStoveTime
		End Get
		Set(Byval value as System.DateTime)
			_ConnectOutStoveTime = value
		End Set
	End Property
#End Region
#Region "CoilOutStoveTime 屬性:CoilOutStoveTime"
	Private _CoilOutStoveTime As System.DateTime
	''' <summary>
	''' CoilOutStoveTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CoilOutStoveTime () As System.DateTime
		Get
			Return _CoilOutStoveTime
		End Get
		Set(Byval value as System.DateTime)
			_CoilOutStoveTime = value
		End Set
	End Property
#End Region
#Region "NextConnectID 屬性:NextConnectID"
	Private _NextConnectID As System.String
	''' <summary>
	''' NextConnectID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property NextConnectID () As System.String
		Get
			Return _NextConnectID
		End Get
		Set(Byval value as System.String)
			_NextConnectID = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace