Namespace SLS300LB
Public Class SL2CIWPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(SL2CIWPF).Name)
	End Sub

#Region "線別 屬性:CIW0A"
	Private _CIW0A As System.String
	''' <summary>
	''' 線別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW0A () As System.String
		Get
			Return _CIW0A
		End Get
		Set(Byval value as System.String)
			_CIW0A = value
		End Set
	End Property
#End Region
#Region "C5日期 屬性:CIW00"
	Private _CIW00 As System.Int32
	''' <summary>
	''' C5日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW00 () As System.Int32
		Get
			Return _CIW00
		End Get
		Set(Byval value as System.Int32)
			_CIW00 = value
		End Set
	End Property
#End Region
#Region "C5時間 屬性:CIW01"
	Private _CIW01 As System.Int32
	''' <summary>
	''' C5時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW01 () As System.Int32
		Get
			Return _CIW01
		End Get
		Set(Byval value as System.Int32)
			_CIW01 = value
		End Set
	End Property
#End Region
#Region "寬度 屬性:CIW02"
	Private _CIW02 As System.Int32
	''' <summary>
	''' 寬度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW02 () As System.Int32
		Get
			Return _CIW02
		End Get
		Set(Byval value as System.Int32)
			_CIW02 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:CIW03"
	Private _CIW03 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW03 () As System.String
		Get
			Return _CIW03
		End Get
		Set(Byval value as System.String)
			_CIW03 = value
		End Set
	End Property
#End Region
#Region "TYPE 屬性:CIW04"
	Private _CIW04 As System.String
	''' <summary>
	''' TYPE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW04 () As System.String
		Get
			Return _CIW04
		End Get
		Set(Byval value as System.String)
			_CIW04 = value
		End Set
	End Property
#End Region
#Region "黑皮厚 屬性:CIW05"
	Private _CIW05 As System.String
	''' <summary>
	''' 黑皮厚
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW05 () As System.String
		Get
			Return _CIW05
		End Get
		Set(Byval value as System.String)
			_CIW05 = value
		End Set
	End Property
#End Region
#Region "項 屬性:CIW06"
	Private _CIW06 As System.Int32
	''' <summary>
	''' 項
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW06 () As System.Int32
		Get
			Return _CIW06
		End Get
		Set(Byval value as System.Int32)
			_CIW06 = value
		End Set
	End Property
#End Region
#Region "目標厚 屬性:CIW11"
	Private _CIW11 As System.Single
	''' <summary>
	''' 目標厚
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIW11 () As System.Single
		Get
			Return _CIW11
		End Get
		Set(Byval value as System.Single)
			_CIW11 = value
		End Set
	End Property
#End Region
#Region "派工量 屬性:CIW12"
	Private _CIW12 As System.Single
	''' <summary>
	''' 派工量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIW12 () As System.Single
		Get
			Return _CIW12
		End Get
		Set(Byval value as System.Single)
			_CIW12 = value
		End Set
	End Property
#End Region
#Region "W4日期 屬性:CIW13"
	Private _CIW13 As System.Int32
	''' <summary>
	''' W4日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIW13 () As System.Int32
		Get
			Return _CIW13
		End Get
		Set(Byval value as System.Int32)
			_CIW13 = value
		End Set
	End Property
#End Region
#Region "W4時間 屬性:CIW14"
	Private _CIW14 As System.Int32
	''' <summary>
	''' W4時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIW14 () As System.Int32
		Get
			Return _CIW14
		End Get
		Set(Byval value as System.Int32)
			_CIW14 = value
		End Set
	End Property
#End Region
#Region "優先序 屬性:CIW15"
	Private _CIW15 As System.Int32
	''' <summary>
	''' 優先序
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIW15 () As System.Int32
		Get
			Return _CIW15
		End Get
		Set(Byval value as System.Int32)
			_CIW15 = value
		End Set
	End Property
#End Region
#Region "CODE-0 屬性:CIW90"
	Private _CIW90 As System.String
	''' <summary>
	''' CODE-0
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIW90 () As System.String
		Get
			Return _CIW90
		End Get
		Set(Byval value as System.String)
			_CIW90 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:CIW91"
	Private _CIW91 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIW91 () As System.String
		Get
			Return _CIW91
		End Get
		Set(Byval value as System.String)
			_CIW91 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:CIW92"
	Private _CIW92 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIW92 () As System.String
		Get
			Return _CIW92
		End Get
		Set(Byval value as System.String)
			_CIW92 = value
		End Set
	End Property
#End Region

End Class
End Namespace