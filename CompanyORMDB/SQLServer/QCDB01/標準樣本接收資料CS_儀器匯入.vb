Namespace SQLServer
	Namespace QCDB01
	Public Class 標準樣本接收資料CS_儀器匯入
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "SampleID 屬性:SampleID"
	Private _SampleID As System.String
	''' <summary>
	''' SampleID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SampleID () As System.String
		Get
			Return _SampleID
		End Get
		Set(Byval value as System.String)
			_SampleID = value
		End Set
	End Property
#End Region
#Region "日期時間 屬性:日期時間"
	Private _日期時間 As System.DateTime
	''' <summary>
	''' 日期時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 日期時間 () As System.DateTime
		Get
			Return _日期時間
		End Get
		Set(Byval value as System.DateTime)
			_日期時間 = value
		End Set
	End Property
#End Region
#Region "Method 屬性:Method"
	Private _Method As System.String
	''' <summary>
	''' Method
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Method () As System.String
		Get
			Return _Method
		End Get
		Set(Byval value as System.String)
			_Method = value
		End Set
	End Property
#End Region
#Region "C 屬性:C"
	Private _C As System.Double
	''' <summary>
	''' C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property C () As System.Double
		Get
			Return _C
		End Get
		Set(Byval value as System.Double)
			_C = value
		End Set
	End Property
#End Region
#Region "S 屬性:S"
	Private _S As System.Double
	''' <summary>
	''' S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property S () As System.Double
		Get
			Return _S
		End Get
		Set(Byval value as System.Double)
			_S = value
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
#Region "匯入日期時間 屬性:匯入日期時間"
	Private _匯入日期時間 As System.DateTime
	''' <summary>
	''' 匯入日期時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 匯入日期時間 () As System.DateTime
		Get
			Return _匯入日期時間
		End Get
		Set(Byval value as System.DateTime)
			_匯入日期時間 = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace