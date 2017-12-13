Namespace SQLServer
	Namespace QCDB01
	Public Class LabRecordA1_D
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "LAB_REPORTNO 屬性:LAB_REPORTNO"
	Private _LAB_REPORTNO As System.String
	''' <summary>
	''' LAB_REPORTNO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property LAB_REPORTNO () As System.String
		Get
			Return _LAB_REPORTNO
		End Get
		Set(Byval value as System.String)
			_LAB_REPORTNO = value
		End Set
	End Property
#End Region
#Region "鋼捲號碼 屬性:鋼捲號碼"
	Private _鋼捲號碼 As System.String
	''' <summary>
	''' 鋼捲號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 鋼捲號碼 () As System.String
		Get
			Return _鋼捲號碼
		End Get
		Set(Byval value as System.String)
			_鋼捲號碼 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:鋼種"
	Private _鋼種 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 鋼種 () As System.String
		Get
			Return _鋼種
		End Get
		Set(Byval value as System.String)
			_鋼種 = value
		End Set
	End Property
#End Region
#Region "表面 屬性:表面"
	Private _表面 As System.String
	''' <summary>
	''' 表面
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 表面 () As System.String
		Get
			Return _表面
		End Get
		Set(Byval value as System.String)
			_表面 = value
		End Set
	End Property
#End Region
#Region "厚度 屬性:厚度"
	Private _厚度 As System.Double
	''' <summary>
	''' 厚度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 厚度 () As System.Double
		Get
			Return _厚度
		End Get
		Set(Byval value as System.Double)
			_厚度 = value
		End Set
	End Property
#End Region
#Region "寬度 屬性:寬度"
	Private _寬度 As System.Double
	''' <summary>
	''' 寬度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 寬度 () As System.Double
		Get
			Return _寬度
		End Get
		Set(Byval value as System.Double)
			_寬度 = value
		End Set
	End Property
#End Region
#Region "重量 屬性:重量"
	Private _重量 As System.Double
	''' <summary>
	''' 重量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 重量 () As System.Double
		Get
			Return _重量
		End Get
		Set(Byval value as System.Double)
			_重量 = value
		End Set
	End Property
#End Region
#Region "LAB_REPORTNO2 屬性:LAB_REPORTNO2"
	Private _LAB_REPORTNO2 As System.Int32
	''' <summary>
	''' LAB_REPORTNO2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property LAB_REPORTNO2 () As System.Int32
		Get
			Return _LAB_REPORTNO2
		End Get
		Set(Byval value as System.Int32)
			_LAB_REPORTNO2 = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace