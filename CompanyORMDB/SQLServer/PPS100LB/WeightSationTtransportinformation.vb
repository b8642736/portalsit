Namespace SQLServer
	Namespace PPS100LB
	Public Class WeightSationTtransportinformation
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "過磅類別 屬性:過磅類別"
	Private _過磅類別 As System.String
	''' <summary>
	''' 過磅類別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 過磅類別 () As System.String
		Get
			Return _過磅類別
		End Get
		Set(Byval value as System.String)
			_過磅類別 = value
		End Set
	End Property
#End Region
#Region "合約案號 屬性:合約案號"
	Private _合約案號 As System.String
	''' <summary>
	''' 合約案號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 合約案號 () As System.String
		Get
			Return _合約案號
		End Get
		Set(Byval value as System.String)
			_合約案號 = value
		End Set
	End Property
#End Region
#Region "物料編號 屬性:物料編號"
	Private _物料編號 As System.String
	''' <summary>
	''' 物料編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 物料編號 () As System.String
		Get
			Return _物料編號
		End Get
		Set(Byval value as System.String)
			_物料編號 = value
		End Set
	End Property
#End Region
#Region "廠商 屬性:廠商"
	Private _廠商 As System.String
	''' <summary>
	''' 廠商
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 廠商 () As System.String
		Get
			Return _廠商
		End Get
		Set(Byval value as System.String)
			_廠商 = value
		End Set
	End Property
#End Region
#Region "品名 屬性:品名"
	Private _品名 As System.String
	''' <summary>
	''' 品名
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 品名 () As System.String
		Get
			Return _品名
		End Get
		Set(Byval value as System.String)
			_品名 = value
		End Set
	End Property
#End Region
#Region "日期 屬性:日期"
	Private _日期 As System.DateTime
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 日期 () As System.DateTime
		Get
			Return _日期
		End Get
		Set(Byval value as System.DateTime)
			_日期 = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace