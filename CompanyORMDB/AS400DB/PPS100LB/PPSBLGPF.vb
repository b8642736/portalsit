Namespace PPS100LB
Public Class PPSBLGPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSBLGPF).Name)
	End Sub

#Region "Obs 屬性:BLG01"
	Private _BLG01 As System.Int32
	''' <summary>
	''' Obs
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BLG01 () As System.Int32
		Get
			Return _BLG01
		End Get
		Set(Byval value as System.Int32)
			_BLG01 = value
		End Set
	End Property
#End Region
#Region "鋼捲號碼 屬性:BLG02"
	Private _BLG02 As System.String
	''' <summary>
	''' 鋼捲號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BLG02 () As System.String
		Get
			Return _BLG02
		End Get
		Set(Byval value as System.String)
			_BLG02 = value
		End Set
	End Property
#End Region
#Region "爐號 屬性:BLG03"
	Private _BLG03 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG03 () As System.String
		Get
			Return _BLG03
		End Get
		Set(Byval value as System.String)
			_BLG03 = value
		End Set
	End Property
#End Region
#Region "GRADE 屬性:BLG04"
	Private _BLG04 As System.String
	''' <summary>
	''' GRADE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG04 () As System.String
		Get
			Return _BLG04
		End Get
		Set(Byval value as System.String)
			_BLG04 = value
		End Set
	End Property
#End Region
#Region "切號 屬性:BLG05"
	Private _BLG05 As System.String
	''' <summary>
	''' 切號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG05 () As System.String
		Get
			Return _BLG05
		End Get
		Set(Byval value as System.String)
			_BLG05 = value
		End Set
	End Property
#End Region
#Region "項目 屬性:BLG06"
	Private _BLG06 As System.String
	''' <summary>
	''' 項目
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BLG06 () As System.String
		Get
			Return _BLG06
		End Get
		Set(Byval value as System.String)
			_BLG06 = value
		End Set
	End Property
#End Region
#Region "胚重 屬性:BLG07"
	Private _BLG07 As System.Int32
	''' <summary>
	''' 胚重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG07 () As System.Int32
		Get
			Return _BLG07
		End Get
		Set(Byval value as System.Int32)
			_BLG07 = value
		End Set
	End Property
#End Region
#Region "日期 屬性:BLG08"
	Private _BLG08 As System.Int32
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property BLG08 () As System.Int32
		Get
			Return _BLG08
		End Get
		Set(Byval value as System.Int32)
			_BLG08 = value
		End Set
	End Property
#End Region
#Region "厚度 屬性:BLG09"
	Private _BLG09 As System.Single
	''' <summary>
	''' 厚度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG09 () As System.Single
		Get
			Return _BLG09
		End Get
		Set(Byval value as System.Single)
			_BLG09 = value
		End Set
	End Property
#End Region
#Region "平均厚度 屬性:BLG10"
	Private _BLG10 As System.Single
	''' <summary>
	''' 平均厚度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG10 () As System.Single
		Get
			Return _BLG10
		End Get
		Set(Byval value as System.Single)
			_BLG10 = value
		End Set
	End Property
#End Region
#Region "寬度 屬性:BLG11"
	Private _BLG11 As System.Int32
	''' <summary>
	''' 寬度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG11 () As System.Int32
		Get
			Return _BLG11
		End Get
		Set(Byval value as System.Int32)
			_BLG11 = value
		End Set
	End Property
#End Region
#Region "平均寬度 屬性:BLG12"
	Private _BLG12 As System.Int32
	''' <summary>
	''' 平均寬度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG12 () As System.Int32
		Get
			Return _BLG12
		End Get
		Set(Byval value as System.Int32)
			_BLG12 = value
		End Set
	End Property
#End Region
#Region "捲重 屬性:BLG13"
	Private _BLG13 As System.Int32
	''' <summary>
	''' 捲重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG13 () As System.Int32
		Get
			Return _BLG13
		End Get
		Set(Byval value as System.Int32)
			_BLG13 = value
		End Set
	End Property
#End Region
#Region "C25 屬性:BLG14"
	Private _BLG14 As System.Int32
	''' <summary>
	''' C25
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG14 () As System.Int32
		Get
			Return _BLG14
		End Get
		Set(Byval value as System.Int32)
			_BLG14 = value
		End Set
	End Property
#End Region
#Region "W25 屬性:BLG15"
	Private _BLG15 As System.Int32
	''' <summary>
	''' W25
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG15 () As System.Int32
		Get
			Return _BLG15
		End Get
		Set(Byval value as System.Int32)
			_BLG15 = value
		End Set
	End Property
#End Region
#Region "C40 屬性:BLG16"
	Private _BLG16 As System.Int32
	''' <summary>
	''' C40
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG16 () As System.Int32
		Get
			Return _BLG16
		End Get
		Set(Byval value as System.Int32)
			_BLG16 = value
		End Set
	End Property
#End Region
#Region "WEDGE 屬性:BLG17"
	Private _BLG17 As System.Int32
	''' <summary>
	''' WEDGE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG17 () As System.Int32
		Get
			Return _BLG17
		End Get
		Set(Byval value as System.Int32)
			_BLG17 = value
		End Set
	End Property
#End Region
#Region "軋數 屬性:BLG18"
	Private _BLG18 As System.Int32
	''' <summary>
	''' 軋數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG18 () As System.Int32
		Get
			Return _BLG18
		End Get
		Set(Byval value as System.Int32)
			_BLG18 = value
		End Set
	End Property
#End Region
#Region "出爐溫度 屬性:BLG19"
	Private _BLG19 As System.Int32
	''' <summary>
	''' 出爐溫度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG19 () As System.Int32
		Get
			Return _BLG19
		End Get
		Set(Byval value as System.Int32)
			_BLG19 = value
		End Set
	End Property
#End Region
#Region "在爐時間 屬性:BLG20"
	Private _BLG20 As System.Int32
	''' <summary>
	''' 在爐時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG20 () As System.Int32
		Get
			Return _BLG20
		End Get
		Set(Byval value as System.Int32)
			_BLG20 = value
		End Set
	End Property
#End Region
#Region "FET 屬性:BLG21"
	Private _BLG21 As System.Int32
	''' <summary>
	''' FET
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG21 () As System.Int32
		Get
			Return _BLG21
		End Get
		Set(Byval value as System.Int32)
			_BLG21 = value
		End Set
	End Property
#End Region
#Region "PAC 屬性:BLG22"
	Private _BLG22 As System.Int32
	''' <summary>
	''' PAC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG22 () As System.Int32
		Get
			Return _BLG22
		End Get
		Set(Byval value as System.Int32)
			_BLG22 = value
		End Set
	End Property
#End Region
#Region "EH 屬性:BLG23"
	Private _BLG23 As System.String
	''' <summary>
	''' EH
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG23 () As System.String
		Get
			Return _BLG23
		End Get
		Set(Byval value as System.String)
			_BLG23 = value
		End Set
	End Property
#End Region
#Region "捲機 屬性:BLG24"
	Private _BLG24 As System.Int32
	''' <summary>
	''' 捲機
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG24 () As System.Int32
		Get
			Return _BLG24
		End Get
		Set(Byval value as System.Int32)
			_BLG24 = value
		End Set
	End Property
#End Region
#Region "攤檢記錄 屬性:BLG25"
	Private _BLG25 As System.String
	''' <summary>
	''' 攤檢記錄
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG25 () As System.String
		Get
			Return _BLG25
		End Get
		Set(Byval value as System.String)
			_BLG25 = value
		End Set
	End Property
#End Region
#Region "CODE.1 屬性:BLG91"
	Private _BLG91 As System.String
	''' <summary>
	''' CODE.1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG91 () As System.String
		Get
			Return _BLG91
		End Get
		Set(Byval value as System.String)
			_BLG91 = value
		End Set
	End Property
#End Region
#Region "CODE.2 屬性:BLG92"
	Private _BLG92 As System.String
	''' <summary>
	''' CODE.2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BLG92 () As System.String
		Get
			Return _BLG92
		End Get
		Set(Byval value as System.String)
			_BLG92 = value
		End Set
	End Property
#End Region
End Class
End Namespace