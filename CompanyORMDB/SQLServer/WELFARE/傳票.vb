Namespace SQLServer
	Namespace WELFARE
	Public Class 傳票
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"WELFARE")
	End Sub

#Region "傳票編號 屬性:傳票編號"
	Private _傳票編號 As System.String
	''' <summary>
	''' 傳票編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 傳票編號 () As System.String
		Get
			Return _傳票編號
		End Get
		Set(Byval value as System.String)
			_傳票編號 = value
		End Set
	End Property
#End Region
#Region "傳票別 屬性:傳票別"
	Private _傳票別 As System.String
	''' <summary>
	''' 傳票別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 傳票別 () As System.String
		Get
			Return _傳票別
		End Get
		Set(Byval value as System.String)
			_傳票別 = value
		End Set
	End Property
#End Region
#Region "傳票日期 屬性:傳票日期"
	Private _傳票日期 As System.Double
	''' <summary>
	''' 傳票日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 傳票日期 () As System.Double
		Get
			Return _傳票日期
		End Get
		Set(Byval value as System.Double)
			_傳票日期 = value
		End Set
	End Property
#End Region
#Region "入帳日期 屬性:入帳日期"
	Private _入帳日期 As System.Double
	''' <summary>
	''' 入帳日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 入帳日期 () As System.Double
		Get
			Return _入帳日期
		End Get
		Set(Byval value as System.Double)
			_入帳日期 = value
		End Set
	End Property
#End Region
#Region "入帳編號 屬性:入帳編號"
	Private _入帳編號 As System.String
	''' <summary>
	''' 入帳編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 入帳編號 () As System.String
		Get
			Return _入帳編號
		End Get
		Set(Byval value as System.String)
			_入帳編號 = value
		End Set
	End Property
#End Region
#Region "摘要 屬性:摘要"
	Private _摘要 As System.String
	''' <summary>
	''' 摘要
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 摘要 () As System.String
		Get
			Return _摘要
		End Get
		Set(Byval value as System.String)
			_摘要 = value
		End Set
	End Property
#End Region

	End Class
	End Namespace
End Namespace