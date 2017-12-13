Namespace SLS300LB
Public Class SL2Z01PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(SL2Z01PF).Name)
	End Sub

#Region "爐號 屬性:BLT01"
	Private _BLT01 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BLT01 () As System.String
		Get
			Return _BLT01
		End Get
		Set(Byval value as System.String)
			_BLT01 = value
		End Set
	End Property
#End Region
#Region "序號 屬性:BLT02"
	Private _BLT02 As System.String
	''' <summary>
	''' 序號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BLT02 () As System.String
		Get
			Return _BLT02
		End Get
		Set(Byval value as System.String)
			_BLT02 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:BLT03"
	Private _BLT03 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT03 () As System.String
		Get
			Return _BLT03
		End Get
		Set(Byval value as System.String)
			_BLT03 = value
		End Set
	End Property
#End Region
#Region "材質 屬性:BLT04"
	Private _BLT04 As System.String
	''' <summary>
	''' 材質
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT04 () As System.String
		Get
			Return _BLT04
		End Get
		Set(Byval value as System.String)
			_BLT04 = value
		End Set
	End Property
#End Region
#Region "厚 屬性:BLT05"
	Private _BLT05 As System.Int32
	''' <summary>
	''' 厚
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT05 () As System.Int32
		Get
			Return _BLT05
		End Get
		Set(Byval value as System.Int32)
			_BLT05 = value
		End Set
	End Property
#End Region
#Region "寬 屬性:BLT06"
	Private _BLT06 As System.Int32
	''' <summary>
	''' 寬
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT06 () As System.Int32
		Get
			Return _BLT06
		End Get
		Set(Byval value as System.Int32)
			_BLT06 = value
		End Set
	End Property
#End Region
#Region "長M 屬性:BLT07"
	Private _BLT07 As System.Single
	''' <summary>
	''' 長M
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT07 () As System.Single
		Get
			Return _BLT07
		End Get
		Set(Byval value as System.Single)
			_BLT07 = value
		End Set
	End Property
#End Region
#Region "等級 屬性:BLT08"
	Private _BLT08 As System.String
	''' <summary>
	''' 等級
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT08 () As System.String
		Get
			Return _BLT08
		End Get
		Set(Byval value as System.String)
			_BLT08 = value
		End Set
	End Property
#End Region
#Region "支數 屬性:BLT09"
	Private _BLT09 As System.Int32
	''' <summary>
	''' 支數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT09 () As System.Int32
		Get
			Return _BLT09
		End Get
		Set(Byval value as System.Int32)
			_BLT09 = value
		End Set
	End Property
#End Region
#Region "理論重 屬性:BLT10"
	Private _BLT10 As System.Int32
	''' <summary>
	''' 理論重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT10 () As System.Int32
		Get
			Return _BLT10
		End Get
		Set(Byval value as System.Int32)
			_BLT10 = value
		End Set
	End Property
#End Region
#Region "出貨 屬性:BLT11"
	Private _BLT11 As System.Int32
	''' <summary>
	''' 出貨
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT11 () As System.Int32
		Get
			Return _BLT11
		End Get
		Set(Byval value as System.Int32)
			_BLT11 = value
		End Set
	End Property
#End Region
#Region "退貨 屬性:BLT12"
	Private _BLT12 As System.Int32
	''' <summary>
	''' 退貨
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT12 () As System.Int32
		Get
			Return _BLT12
		End Get
		Set(Byval value as System.Int32)
			_BLT12 = value
		End Set
	End Property
#End Region
#Region "顏色 屬性:BLT13"
	Private _BLT13 As System.String
	''' <summary>
	''' 顏色
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT13 () As System.String
		Get
			Return _BLT13
		End Get
		Set(Byval value as System.String)
			_BLT13 = value
		End Set
	End Property
#End Region
#Region "繳庫日 屬性:BLT14"
	Private _BLT14 As System.String
	''' <summary>
	''' 繳庫日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT14 () As System.String
		Get
			Return _BLT14
		End Get
		Set(Byval value as System.String)
			_BLT14 = value
		End Set
	End Property
#End Region
#Region "繳庫單號 屬性:BLT15"
	Private _BLT15 As System.String
	''' <summary>
	''' 繳庫單號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT15 () As System.String
		Get
			Return _BLT15
		End Get
		Set(Byval value as System.String)
			_BLT15 = value
		End Set
	End Property
#End Region
#Region "出貨剩餘 屬性:BLT16"
	Private _BLT16 As System.Int32
	''' <summary>
	''' 出貨剩餘
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT16 () As System.Int32
		Get
			Return _BLT16
		End Get
		Set(Byval value as System.Int32)
			_BLT16 = value
		End Set
	End Property
#End Region
#Region "儲區 屬性:BLT17"
	Private _BLT17 As System.String
	''' <summary>
	''' 儲區
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT17 () As System.String
		Get
			Return _BLT17
		End Get
		Set(Byval value as System.String)
			_BLT17 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:BLT91"
	Private _BLT91 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT91 () As System.String
		Get
			Return _BLT91
		End Get
		Set(Byval value as System.String)
			_BLT91 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:BLT92"
	Private _BLT92 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLT92 () As System.String
		Get
			Return _BLT92
		End Get
		Set(Byval value as System.String)
			_BLT92 = value
		End Set
	End Property
#End Region
End Class
End Namespace