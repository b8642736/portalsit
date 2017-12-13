Namespace PPS100LB
Public Class PPSBPHPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSBPHPF).Name)
	End Sub

#Region "批次 屬性:BPH00"
	Private _BPH00 As System.String
	''' <summary>
	''' 批次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BPH00 () As System.String
		Get
			Return _BPH00
		End Get
		Set(Byval value as System.String)
			_BPH00 = value
		End Set
	End Property
#End Region
#Region "來源國家 屬性:BPH01"
	Private _BPH01 As System.String
	''' <summary>
	''' 來源國家
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BPH01 () As System.String
		Get
			Return _BPH01
		End Get
		Set(Byval value as System.String)
			_BPH01 = value
		End Set
	End Property
#End Region
#Region "來源廠別 屬性:BPH02"
	Private _BPH02 As System.String
	''' <summary>
	''' 來源廠別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BPH02 () As System.String
		Get
			Return _BPH02
		End Get
		Set(Byval value as System.String)
			_BPH02 = value
		End Set
	End Property
#End Region
#Region "銷售公司 屬性:BPH03"
	Private _BPH03 As System.String
	''' <summary>
	''' 銷售公司
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BPH03 () As System.String
		Get
			Return _BPH03
		End Get
		Set(Byval value as System.String)
			_BPH03 = value
		End Set
	End Property
#End Region
#Region "銷售公司名稱 屬性:BPH04"
	Private _BPH04 As System.String
	''' <summary>
	''' 銷售公司名稱
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BPH04 () As System.String
		Get
			Return _BPH04
		End Get
		Set(Byval value as System.String)
			_BPH04 = value
		End Set
	End Property
#End Region
#Region "爐號字元數 屬性:BPH05"
	Private _BPH05 As System.Int32
	''' <summary>
	''' 爐號字元數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BPH05 () As System.Int32
		Get
			Return _BPH05
		End Get
		Set(Byval value as System.Int32)
			_BPH05 = value
		End Set
	End Property
#End Region
#Region "CODE-0 屬性:BPH90"
	Private _BPH90 As System.String
	''' <summary>
	''' CODE-0
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BPH90 () As System.String
		Get
			Return _BPH90
		End Get
		Set(Byval value as System.String)
			_BPH90 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:BPH91"
	Private _BPH91 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BPH91 () As System.String
		Get
			Return _BPH91
		End Get
		Set(Byval value as System.String)
			_BPH91 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:BPH92"
	Private _BPH92 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BPH92 () As System.String
		Get
			Return _BPH92
		End Get
		Set(Byval value as System.String)
			_BPH92 = value
		End Set
	End Property
#End Region
End Class
End Namespace