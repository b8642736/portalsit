Namespace PPS100LB
Public Class PPSBWDPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSBWDPF).Name)
	End Sub

#Region "熱軋號碼 屬性:BWD01"
	Private _BWD01 As System.String
	''' <summary>
	''' 熱軋號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BWD01 () As System.String
		Get
			Return _BWD01
		End Get
		Set(Byval value as System.String)
			_BWD01 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:BWD02"
	Private _BWD02 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD02 () As System.String
		Get
			Return _BWD02
		End Get
		Set(Byval value as System.String)
			_BWD02 = value
		End Set
	End Property
#End Region
#Region "公稱厚 屬性:BWD03"
	Private _BWD03 As System.Single
	''' <summary>
	''' 公稱厚
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD03 () As System.Single
		Get
			Return _BWD03
		End Get
		Set(Byval value as System.Single)
			_BWD03 = value
		End Set
	End Property
#End Region
#Region "公稱寬 屬性:BWD04"
	Private _BWD04 As System.Int32
	''' <summary>
	''' 公稱寬
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD04 () As System.Int32
		Get
			Return _BWD04
		End Get
		Set(Byval value as System.Int32)
			_BWD04 = value
		End Set
	End Property
#End Region
#Region "長度M 屬性:BWD05"
	Private _BWD05 As System.Int32
	''' <summary>
	''' 長度M
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD05 () As System.Int32
		Get
			Return _BWD05
		End Get
		Set(Byval value as System.Int32)
			_BWD05 = value
		End Set
	End Property
#End Region
#Region "重量 屬性:BWD06"
	Private _BWD06 As System.Int32
	''' <summary>
	''' 重量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD06 () As System.Int32
		Get
			Return _BWD06
		End Get
		Set(Byval value as System.Int32)
			_BWD06 = value
		End Set
	End Property
#End Region
#Region "鋼胚號 屬性:BWD07"
	Private _BWD07 As System.String
	''' <summary>
	''' 鋼胚號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD07 () As System.String
		Get
			Return _BWD07
		End Get
		Set(Byval value as System.String)
			_BWD07 = value
		End Set
	End Property
#End Region
#Region "日期 屬性:BWD08"
	Private _BWD08 As System.Int32
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD08 () As System.Int32
		Get
			Return _BWD08
		End Get
		Set(Byval value as System.Int32)
			_BWD08 = value
		End Set
	End Property
#End Region
#Region "鋼捲號 屬性:BWD09"
	Private _BWD09 As System.String
	''' <summary>
	''' 鋼捲號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD09 () As System.String
		Get
			Return _BWD09
		End Get
		Set(Byval value as System.String)
			_BWD09 = value
		End Set
	End Property
#End Region
#Region "序號 屬性:BWD10"
	Private _BWD10 As System.String
	''' <summary>
	''' 序號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD10 () As System.String
		Get
			Return _BWD10
		End Get
		Set(Byval value as System.String)
			_BWD10 = value
		End Set
	End Property
#End Region
#Region "批次 屬性:BWD11"
	Private _BWD11 As System.String
	''' <summary>
	''' 批次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BWD11 () As System.String
		Get
			Return _BWD11
		End Get
		Set(Byval value as System.String)
			_BWD11 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:BWD12"
	Private _BWD12 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD12 () As System.String
		Get
			Return _BWD12
		End Get
		Set(Byval value as System.String)
			_BWD12 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:BWD13"
	Private _BWD13 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD13 () As System.String
		Get
			Return _BWD13
		End Get
		Set(Byval value as System.String)
			_BWD13 = value
		End Set
	End Property
#End Region
#Region "CODE-3 屬性:BWD14"
	Private _BWD14 As System.String
	''' <summary>
	''' CODE-3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD14 () As System.String
		Get
			Return _BWD14
		End Get
		Set(Byval value as System.String)
			_BWD14 = value
		End Set
	End Property
#End Region
#Region "CODE-4 屬性:BWD15"
	Private _BWD15 As System.String
	''' <summary>
	''' CODE-4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD15 () As System.String
		Get
			Return _BWD15
		End Get
		Set(Byval value as System.String)
			_BWD15 = value
		End Set
	End Property
#End Region
#Region "CODE-5 屬性:BWD16"
	Private _BWD16 As System.String
	''' <summary>
	''' CODE-5
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD16 () As System.String
		Get
			Return _BWD16
		End Get
		Set(Byval value as System.String)
			_BWD16 = value
		End Set
	End Property
#End Region
#Region "計劃編號 屬性:BWD17"
	Private _BWD17 As System.String
	''' <summary>
	''' 計劃編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD17 () As System.String
		Get
			Return _BWD17
		End Get
		Set(Byval value as System.String)
			_BWD17 = value
		End Set
	End Property
#End Region
#Region "TYPE 屬性:BWD18"
	Private _BWD18 As System.String
	''' <summary>
	''' TYPE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD18 () As System.String
		Get
			Return _BWD18
		End Get
		Set(Byval value as System.String)
			_BWD18 = value
		End Set
	End Property
#End Region
#Region "表面 屬性:BWD19"
	Private _BWD19 As System.String
	''' <summary>
	''' 表面
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD19 () As System.String
		Get
			Return _BWD19
		End Get
		Set(Byval value as System.String)
			_BWD19 = value
		End Set
	End Property
#End Region
#Region "C/S 屬性:BWD20"
	Private _BWD20 As System.String
	''' <summary>
	''' C/S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD20 () As System.String
		Get
			Return _BWD20
		End Get
		Set(Byval value as System.String)
			_BWD20 = value
		End Set
	End Property
#End Region
#Region "片數 屬性:BWD21"
	Private _BWD21 As System.Int32
	''' <summary>
	''' 片數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD21 () As System.Int32
		Get
			Return _BWD21
		End Get
		Set(Byval value as System.Int32)
			_BWD21 = value
		End Set
	End Property
#End Region
#Region "實際厚 屬性:BWD22"
	Private _BWD22 As System.Single
	''' <summary>
	''' 實際厚
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD22 () As System.Single
		Get
			Return _BWD22
		End Get
		Set(Byval value as System.Single)
			_BWD22 = value
		End Set
	End Property
#End Region
#Region "實際寬 屬性:BWD23"
	Private _BWD23 As System.Int32
	''' <summary>
	''' 實際寬
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD23 () As System.Int32
		Get
			Return _BWD23
		End Get
		Set(Byval value as System.Int32)
			_BWD23 = value
		End Set
	End Property
#End Region
#Region "等級 屬性:BWD24"
	Private _BWD24 As System.String
	''' <summary>
	''' 等級
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD24 () As System.String
		Get
			Return _BWD24
		End Get
		Set(Byval value as System.String)
			_BWD24 = value
		End Set
	End Property
#End Region
#Region "內徑 屬性:BWD25"
	Private _BWD25 As System.Int32
	''' <summary>
	''' 內徑
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD25 () As System.Int32
		Get
			Return _BWD25
		End Get
		Set(Byval value as System.Int32)
			_BWD25 = value
		End Set
	End Property
#End Region
#Region "計劃厚 屬性:BWD26"
	Private _BWD26 As System.Single
	''' <summary>
	''' 計劃厚
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD26 () As System.Single
		Get
			Return _BWD26
		End Get
		Set(Byval value as System.Single)
			_BWD26 = value
		End Set
	End Property
#End Region
#Region "交貨期 屬性:BWD27"
	Private _BWD27 As System.Int32
	''' <summary>
	''' 交貨期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BWD27 () As System.Int32
		Get
			Return _BWD27
		End Get
		Set(Byval value as System.Int32)
			_BWD27 = value
		End Set
	End Property
#End Region
End Class
End Namespace