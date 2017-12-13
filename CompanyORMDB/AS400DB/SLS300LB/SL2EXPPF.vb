Namespace SLS300LB
Public Class SL2EXPPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(SL2EXPPF).Name)
	End Sub

#Region "申退單編號 屬性:EXP01"
	Private _EXP01 As System.String
	''' <summary>
	''' 申退單編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property EXP01 () As System.String
		Get
			Return _EXP01
		End Get
		Set(Byval value as System.String)
			_EXP01 = value
		End Set
	End Property
#End Region
#Region "項次 屬性:EXP02"
	Private _EXP02 As System.Int32
	''' <summary>
	''' 項次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property EXP02 () As System.Int32
		Get
			Return _EXP02
		End Get
		Set(Byval value as System.Int32)
			_EXP02 = value
		End Set
	End Property
#End Region
#Region "鋼捲編號1 屬性:EXP03"
	Private _EXP03 As System.String
	''' <summary>
	''' 鋼捲編號1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP03 () As System.String
		Get
			Return _EXP03
		End Get
		Set(Byval value as System.String)
			_EXP03 = value
		End Set
	End Property
#End Region
#Region "鋼捲編號2 屬性:EXP04"
	Private _EXP04 As System.String
	''' <summary>
	''' 鋼捲編號2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP04 () As System.String
		Get
			Return _EXP04
		End Get
		Set(Byval value as System.String)
			_EXP04 = value
		End Set
	End Property
#End Region
#Region "申退日期 屬性:EXP05"
	Private _EXP05 As System.String
	''' <summary>
	''' 申退日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP05 () As System.String
		Get
			Return _EXP05
		End Get
		Set(Byval value as System.String)
			_EXP05 = value
		End Set
	End Property
#End Region
#Region "出口報單 屬性:EXP06"
	Private _EXP06 As System.String
	''' <summary>
	''' 出口報單
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP06 () As System.String
		Get
			Return _EXP06
		End Get
		Set(Byval value as System.String)
			_EXP06 = value
		End Set
	End Property
#End Region
#Region "出口日期 屬性:EXP07"
	Private _EXP07 As System.String
	''' <summary>
	''' 出口日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP07 () As System.String
		Get
			Return _EXP07
		End Get
		Set(Byval value as System.String)
			_EXP07 = value
		End Set
	End Property
#End Region
#Region "外銷品名 屬性:EXP08"
	Private _EXP08 As System.String
	''' <summary>
	''' 外銷品名
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP08 () As System.String
		Get
			Return _EXP08
		End Get
		Set(Byval value as System.String)
			_EXP08 = value
		End Set
	End Property
#End Region
#Region "外銷規格 屬性:EXP09"
	Private _EXP09 As System.Single
	''' <summary>
	''' 外銷規格
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP09 () As System.Single
		Get
			Return _EXP09
		End Get
		Set(Byval value as System.Single)
			_EXP09 = value
		End Set
	End Property
#End Region
#Region "外銷數量KG 屬性:EXP10"
	Private _EXP10 As System.Single
	''' <summary>
	''' 外銷數量KG
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP10 () As System.Single
		Get
			Return _EXP10
		End Get
		Set(Byval value as System.Single)
			_EXP10 = value
		End Set
	End Property
#End Region
#Region "使用量KG 屬性:EXP11"
	Private _EXP11 As System.Single
	''' <summary>
	''' 使用量KG
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP11 () As System.Single
		Get
			Return _EXP11
		End Get
		Set(Byval value as System.Single)
			_EXP11 = value
		End Set
	End Property
#End Region
#Region "單位價差 屬性:EXP12"
	Private _EXP12 As System.Int32
	''' <summary>
	''' 單位價差
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP12 () As System.Int32
		Get
			Return _EXP12
		End Get
		Set(Byval value as System.Int32)
			_EXP12 = value
		End Set
	End Property
#End Region
#Region "總價差 屬性:EXP13"
	Private _EXP13 As System.Int32
	''' <summary>
	''' 總價差
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP13 () As System.Int32
		Get
			Return _EXP13
		End Get
		Set(Byval value as System.Int32)
			_EXP13 = value
		End Set
	End Property
#End Region
#Region "營業稅 屬性:EXP14"
	Private _EXP14 As System.Int32
	''' <summary>
	''' 營業稅
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP14 () As System.Int32
		Get
			Return _EXP14
		End Get
		Set(Byval value as System.Int32)
			_EXP14 = value
		End Set
	End Property
#End Region
#Region "提貨單號 屬性:EXP15"
	Private _EXP15 As System.String
	''' <summary>
	''' 提貨單號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP15 () As System.String
		Get
			Return _EXP15
		End Get
		Set(Byval value as System.String)
			_EXP15 = value
		End Set
	End Property
#End Region
#Region "折讓收款單 屬性:EXP16"
	Private _EXP16 As System.String
	''' <summary>
	''' 折讓收款單
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP16 () As System.String
		Get
			Return _EXP16
		End Get
		Set(Byval value as System.String)
			_EXP16 = value
		End Set
	End Property
#End Region
#Region "出口國 屬性:EXP17"
	Private _EXP17 As System.String
	''' <summary>
	''' 出口國
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP17 () As System.String
		Get
			Return _EXP17
		End Get
		Set(Byval value as System.String)
			_EXP17 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:EXP91"
	Private _EXP91 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP91 () As System.String
		Get
			Return _EXP91
		End Get
		Set(Byval value as System.String)
			_EXP91 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:EXP92"
	Private _EXP92 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXP92 () As System.String
		Get
			Return _EXP92
		End Get
		Set(Byval value as System.String)
			_EXP92 = value
		End Set
	End Property
#End Region
End Class
End Namespace