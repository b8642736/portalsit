Namespace PPS100LB
Public Class PPSBLFPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSBLFPF).Name)
	End Sub

#Region "軋回批次 屬性:BLF01"
	Private _BLF01 As System.String
	''' <summary>
	''' 軋回批次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BLF01 () As System.String
		Get
			Return _BLF01
		End Get
		Set(Byval value as System.String)
			_BLF01 = value
		End Set
	End Property
#End Region
#Region "熱軋號碼 屬性:BLF02"
	Private _BLF02 As System.String
	''' <summary>
	''' 熱軋號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BLF02 () As System.String
		Get
			Return _BLF02
		End Get
		Set(Byval value as System.String)
			_BLF02 = value
		End Set
	End Property
#End Region
#Region "鋼胚號碼 屬性:BLF03"
	Private _BLF03 As System.String
	''' <summary>
	''' 鋼胚號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF03 () As System.String
		Get
			Return _BLF03
		End Get
		Set(Byval value as System.String)
			_BLF03 = value
		End Set
	End Property
#End Region
#Region "上載日 屬性:BLF04"
	Private _BLF04 As System.Int32
	''' <summary>
	''' 上載日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF04 () As System.Int32
		Get
			Return _BLF04
		End Get
		Set(Byval value as System.Int32)
			_BLF04 = value
		End Set
	End Property
#End Region
#Region "送外批次 屬性:BLF05"
	Private _BLF05 As System.String
	''' <summary>
	''' 送外批次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF05 () As System.String
		Get
			Return _BLF05
		End Get
		Set(Byval value as System.String)
			_BLF05 = value
		End Set
	End Property
#End Region
#Region "合格 屬性:BLF11"
	Private _BLF11 As System.String
	''' <summary>
	''' 合格
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF11 () As System.String
		Get
			Return _BLF11
		End Get
		Set(Byval value as System.String)
			_BLF11 = value
		End Set
	End Property
#End Region
#Region "攤檢 屬性:BLF12"
	Private _BLF12 As System.String
	''' <summary>
	''' 攤檢
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF12 () As System.String
		Get
			Return _BLF12
		End Get
		Set(Byval value as System.String)
			_BLF12 = value
		End Set
	End Property
#End Region
#Region "缺陷 屬性:BLF13"
	Private _BLF13 As System.String
	''' <summary>
	''' 缺陷
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF13 () As System.String
		Get
			Return _BLF13
		End Get
		Set(Byval value as System.String)
			_BLF13 = value
		End Set
	End Property
#End Region
#Region "程度 屬性:BLF14"
	Private _BLF14 As System.String
	''' <summary>
	''' 程度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF14 () As System.String
		Get
			Return _BLF14
		End Get
		Set(Byval value as System.String)
			_BLF14 = value
		End Set
	End Property
#End Region
#Region "CODE.1 屬性:BLF91"
	Private _BLF91 As System.String
	''' <summary>
	''' CODE.1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF91 () As System.String
		Get
			Return _BLF91
		End Get
		Set(Byval value as System.String)
			_BLF91 = value
		End Set
	End Property
#End Region
#Region "CODE.2 屬性:BLF92"
	Private _BLF92 As System.String
	''' <summary>
	''' CODE.2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLF92 () As System.String
		Get
			Return _BLF92
		End Get
		Set(Byval value as System.String)
			_BLF92 = value
		End Set
	End Property
#End Region
End Class
End Namespace