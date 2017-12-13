Namespace TESTKUKU
Public Class FODM02PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("TESTKUKU", GetType(FODM02PF).Name)
	End Sub

#Region "編號 屬性:FD001"
	Private _FD001 As System.String
	''' <summary>
	''' 編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FD001 () As System.String
		Get
			Return _FD001
		End Get
		Set(Byval value as System.String)
			_FD001 = value
		End Set
	End Property
#End Region
#Region "姓名 屬性:FD002"
	Private _FD002 As System.String
	''' <summary>
	''' 姓名
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD002 () As System.String
		Get
			Return _FD002
		End Get
		Set(Byval value as System.String)
			_FD002 = value
		End Set
	End Property
#End Region
#Region "廠別 屬性:FD003"
	Private _FD003 As System.String
	''' <summary>
	''' 廠別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD003 () As System.String
		Get
			Return _FD003
		End Get
		Set(Byval value as System.String)
			_FD003 = value
		End Set
	End Property
#End Region
#Region "發便當處 屬性:FD004"
	Private _FD004 As System.String
	''' <summary>
	''' 發便當處
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD004 () As System.String
		Get
			Return _FD004
		End Get
		Set(Byval value as System.String)
			_FD004 = value
		End Set
	End Property
#End Region
#Region "單位 屬性:FD005"
	Private _FD005 As System.String
	''' <summary>
	''' 單位
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD005 () As System.String
		Get
			Return _FD005
		End Get
		Set(Byval value as System.String)
			_FD005 = value
		End Set
	End Property
#End Region
#Region "成本中心 屬性:FD006"
	Private _FD006 As System.String
	''' <summary>
	''' 成本中心
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD006 () As System.String
		Get
			Return _FD006
		End Get
		Set(Byval value as System.String)
			_FD006 = value
		End Set
	End Property
#End Region
#Region "輪班 屬性:FD007"
	Private _FD007 As System.String
	''' <summary>
	''' 輪班
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD007 () As System.String
		Get
			Return _FD007
		End Get
		Set(Byval value as System.String)
			_FD007 = value
		End Set
	End Property
#End Region
#Region "碼Ａ 屬性:FD008"
	Private _FD008 As System.String
	''' <summary>
	''' 碼Ａ
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD008 () As System.String
		Get
			Return _FD008
		End Get
		Set(Byval value as System.String)
			_FD008 = value
		End Set
	End Property
#End Region
#Region "碼Ｂ 屬性:FD009"
	Private _FD009 As System.String
	''' <summary>
	''' 碼Ｂ
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD009 () As System.String
		Get
			Return _FD009
		End Get
		Set(Byval value as System.String)
			_FD009 = value
		End Set
	End Property
#End Region
#Region "碼Ｃ 屬性:FD010"
	Private _FD010 As System.String
	''' <summary>
	''' 碼Ｃ
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD010 () As System.String
		Get
			Return _FD010
		End Get
		Set(Byval value as System.String)
			_FD010 = value
		End Set
	End Property
#End Region
#Region "01早 屬性:FD01A"
	Private _FD01A As System.String
	''' <summary>
	''' 01早
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD01A () As System.String
		Get
			Return _FD01A
		End Get
		Set(Byval value as System.String)
			_FD01A = value
		End Set
	End Property
#End Region
#Region "02A 屬性:FD02A"
	Private _FD02A As System.String
	''' <summary>
	''' 02A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD02A () As System.String
		Get
			Return _FD02A
		End Get
		Set(Byval value as System.String)
			_FD02A = value
		End Set
	End Property
#End Region
#Region "03A 屬性:FD03A"
	Private _FD03A As System.String
	''' <summary>
	''' 03A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD03A () As System.String
		Get
			Return _FD03A
		End Get
		Set(Byval value as System.String)
			_FD03A = value
		End Set
	End Property
#End Region
#Region "04A 屬性:FD04A"
	Private _FD04A As System.String
	''' <summary>
	''' 04A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD04A () As System.String
		Get
			Return _FD04A
		End Get
		Set(Byval value as System.String)
			_FD04A = value
		End Set
	End Property
#End Region
#Region "05A 屬性:FD05A"
	Private _FD05A As System.String
	''' <summary>
	''' 05A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD05A () As System.String
		Get
			Return _FD05A
		End Get
		Set(Byval value as System.String)
			_FD05A = value
		End Set
	End Property
#End Region
#Region "06A 屬性:FD06A"
	Private _FD06A As System.String
	''' <summary>
	''' 06A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD06A () As System.String
		Get
			Return _FD06A
		End Get
		Set(Byval value as System.String)
			_FD06A = value
		End Set
	End Property
#End Region
#Region "07A 屬性:FD07A"
	Private _FD07A As System.String
	''' <summary>
	''' 07A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD07A () As System.String
		Get
			Return _FD07A
		End Get
		Set(Byval value as System.String)
			_FD07A = value
		End Set
	End Property
#End Region
#Region "08A 屬性:FD08A"
	Private _FD08A As System.String
	''' <summary>
	''' 08A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD08A () As System.String
		Get
			Return _FD08A
		End Get
		Set(Byval value as System.String)
			_FD08A = value
		End Set
	End Property
#End Region
#Region "09A 屬性:FD09A"
	Private _FD09A As System.String
	''' <summary>
	''' 09A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD09A () As System.String
		Get
			Return _FD09A
		End Get
		Set(Byval value as System.String)
			_FD09A = value
		End Set
	End Property
#End Region
#Region "10A 屬性:FD10A"
	Private _FD10A As System.String
	''' <summary>
	''' 10A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD10A () As System.String
		Get
			Return _FD10A
		End Get
		Set(Byval value as System.String)
			_FD10A = value
		End Set
	End Property
#End Region
#Region "11A 屬性:FD11A"
	Private _FD11A As System.String
	''' <summary>
	''' 11A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD11A () As System.String
		Get
			Return _FD11A
		End Get
		Set(Byval value as System.String)
			_FD11A = value
		End Set
	End Property
#End Region
#Region "12A 屬性:FD12A"
	Private _FD12A As System.String
	''' <summary>
	''' 12A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD12A () As System.String
		Get
			Return _FD12A
		End Get
		Set(Byval value as System.String)
			_FD12A = value
		End Set
	End Property
#End Region
#Region "13A 屬性:FD13A"
	Private _FD13A As System.String
	''' <summary>
	''' 13A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD13A () As System.String
		Get
			Return _FD13A
		End Get
		Set(Byval value as System.String)
			_FD13A = value
		End Set
	End Property
#End Region
#Region "14A 屬性:FD14A"
	Private _FD14A As System.String
	''' <summary>
	''' 14A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD14A () As System.String
		Get
			Return _FD14A
		End Get
		Set(Byval value as System.String)
			_FD14A = value
		End Set
	End Property
#End Region
#Region "15A 屬性:FD15A"
	Private _FD15A As System.String
	''' <summary>
	''' 15A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD15A () As System.String
		Get
			Return _FD15A
		End Get
		Set(Byval value as System.String)
			_FD15A = value
		End Set
	End Property
#End Region
#Region "16A 屬性:FD16A"
	Private _FD16A As System.String
	''' <summary>
	''' 16A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD16A () As System.String
		Get
			Return _FD16A
		End Get
		Set(Byval value as System.String)
			_FD16A = value
		End Set
	End Property
#End Region
#Region "17A 屬性:FD17A"
	Private _FD17A As System.String
	''' <summary>
	''' 17A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD17A () As System.String
		Get
			Return _FD17A
		End Get
		Set(Byval value as System.String)
			_FD17A = value
		End Set
	End Property
#End Region
#Region "18A 屬性:FD18A"
	Private _FD18A As System.String
	''' <summary>
	''' 18A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD18A () As System.String
		Get
			Return _FD18A
		End Get
		Set(Byval value as System.String)
			_FD18A = value
		End Set
	End Property
#End Region
#Region "19A 屬性:FD19A"
	Private _FD19A As System.String
	''' <summary>
	''' 19A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD19A () As System.String
		Get
			Return _FD19A
		End Get
		Set(Byval value as System.String)
			_FD19A = value
		End Set
	End Property
#End Region
#Region "20A 屬性:FD20A"
	Private _FD20A As System.String
	''' <summary>
	''' 20A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD20A () As System.String
		Get
			Return _FD20A
		End Get
		Set(Byval value as System.String)
			_FD20A = value
		End Set
	End Property
#End Region
#Region "21A 屬性:FD21A"
	Private _FD21A As System.String
	''' <summary>
	''' 21A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD21A () As System.String
		Get
			Return _FD21A
		End Get
		Set(Byval value as System.String)
			_FD21A = value
		End Set
	End Property
#End Region
#Region "22A 屬性:FD22A"
	Private _FD22A As System.String
	''' <summary>
	''' 22A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD22A () As System.String
		Get
			Return _FD22A
		End Get
		Set(Byval value as System.String)
			_FD22A = value
		End Set
	End Property
#End Region
#Region "23A 屬性:FD23A"
	Private _FD23A As System.String
	''' <summary>
	''' 23A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD23A () As System.String
		Get
			Return _FD23A
		End Get
		Set(Byval value as System.String)
			_FD23A = value
		End Set
	End Property
#End Region
#Region "24A 屬性:FD24A"
	Private _FD24A As System.String
	''' <summary>
	''' 24A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD24A () As System.String
		Get
			Return _FD24A
		End Get
		Set(Byval value as System.String)
			_FD24A = value
		End Set
	End Property
#End Region
#Region "25A 屬性:FD25A"
	Private _FD25A As System.String
	''' <summary>
	''' 25A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD25A () As System.String
		Get
			Return _FD25A
		End Get
		Set(Byval value as System.String)
			_FD25A = value
		End Set
	End Property
#End Region
#Region "26A 屬性:FD26A"
	Private _FD26A As System.String
	''' <summary>
	''' 26A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD26A () As System.String
		Get
			Return _FD26A
		End Get
		Set(Byval value as System.String)
			_FD26A = value
		End Set
	End Property
#End Region
#Region "27A 屬性:FD27A"
	Private _FD27A As System.String
	''' <summary>
	''' 27A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD27A () As System.String
		Get
			Return _FD27A
		End Get
		Set(Byval value as System.String)
			_FD27A = value
		End Set
	End Property
#End Region
#Region "28A 屬性:FD28A"
	Private _FD28A As System.String
	''' <summary>
	''' 28A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD28A () As System.String
		Get
			Return _FD28A
		End Get
		Set(Byval value as System.String)
			_FD28A = value
		End Set
	End Property
#End Region
#Region "29A 屬性:FD29A"
	Private _FD29A As System.String
	''' <summary>
	''' 29A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD29A () As System.String
		Get
			Return _FD29A
		End Get
		Set(Byval value as System.String)
			_FD29A = value
		End Set
	End Property
#End Region
#Region "30A 屬性:FD30A"
	Private _FD30A As System.String
	''' <summary>
	''' 30A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD30A () As System.String
		Get
			Return _FD30A
		End Get
		Set(Byval value as System.String)
			_FD30A = value
		End Set
	End Property
#End Region
#Region "31A 屬性:FD31A"
	Private _FD31A As System.String
	''' <summary>
	''' 31A
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD31A () As System.String
		Get
			Return _FD31A
		End Get
		Set(Byval value as System.String)
			_FD31A = value
		End Set
	End Property
#End Region
#Region "01中 屬性:FD01B"
	Private _FD01B As System.String
	''' <summary>
	''' 01中
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD01B () As System.String
		Get
			Return _FD01B
		End Get
		Set(Byval value as System.String)
			_FD01B = value
		End Set
	End Property
#End Region
#Region "02B 屬性:FD02B"
	Private _FD02B As System.String
	''' <summary>
	''' 02B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD02B () As System.String
		Get
			Return _FD02B
		End Get
		Set(Byval value as System.String)
			_FD02B = value
		End Set
	End Property
#End Region
#Region "03B 屬性:FD03B"
	Private _FD03B As System.String
	''' <summary>
	''' 03B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD03B () As System.String
		Get
			Return _FD03B
		End Get
		Set(Byval value as System.String)
			_FD03B = value
		End Set
	End Property
#End Region
#Region "04B 屬性:FD04B"
	Private _FD04B As System.String
	''' <summary>
	''' 04B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD04B () As System.String
		Get
			Return _FD04B
		End Get
		Set(Byval value as System.String)
			_FD04B = value
		End Set
	End Property
#End Region
#Region "05B 屬性:FD05B"
	Private _FD05B As System.String
	''' <summary>
	''' 05B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD05B () As System.String
		Get
			Return _FD05B
		End Get
		Set(Byval value as System.String)
			_FD05B = value
		End Set
	End Property
#End Region
#Region "06B 屬性:FD06B"
	Private _FD06B As System.String
	''' <summary>
	''' 06B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD06B () As System.String
		Get
			Return _FD06B
		End Get
		Set(Byval value as System.String)
			_FD06B = value
		End Set
	End Property
#End Region
#Region "07B 屬性:FD07B"
	Private _FD07B As System.String
	''' <summary>
	''' 07B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD07B () As System.String
		Get
			Return _FD07B
		End Get
		Set(Byval value as System.String)
			_FD07B = value
		End Set
	End Property
#End Region
#Region "08B 屬性:FD08B"
	Private _FD08B As System.String
	''' <summary>
	''' 08B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD08B () As System.String
		Get
			Return _FD08B
		End Get
		Set(Byval value as System.String)
			_FD08B = value
		End Set
	End Property
#End Region
#Region "09B 屬性:FD09B"
	Private _FD09B As System.String
	''' <summary>
	''' 09B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD09B () As System.String
		Get
			Return _FD09B
		End Get
		Set(Byval value as System.String)
			_FD09B = value
		End Set
	End Property
#End Region
#Region "10B 屬性:FD10B"
	Private _FD10B As System.String
	''' <summary>
	''' 10B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD10B () As System.String
		Get
			Return _FD10B
		End Get
		Set(Byval value as System.String)
			_FD10B = value
		End Set
	End Property
#End Region
#Region "11B 屬性:FD11B"
	Private _FD11B As System.String
	''' <summary>
	''' 11B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD11B () As System.String
		Get
			Return _FD11B
		End Get
		Set(Byval value as System.String)
			_FD11B = value
		End Set
	End Property
#End Region
#Region "12B 屬性:FD12B"
	Private _FD12B As System.String
	''' <summary>
	''' 12B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD12B () As System.String
		Get
			Return _FD12B
		End Get
		Set(Byval value as System.String)
			_FD12B = value
		End Set
	End Property
#End Region
#Region "13B 屬性:FD13B"
	Private _FD13B As System.String
	''' <summary>
	''' 13B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD13B () As System.String
		Get
			Return _FD13B
		End Get
		Set(Byval value as System.String)
			_FD13B = value
		End Set
	End Property
#End Region
#Region "14B 屬性:FD14B"
	Private _FD14B As System.String
	''' <summary>
	''' 14B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD14B () As System.String
		Get
			Return _FD14B
		End Get
		Set(Byval value as System.String)
			_FD14B = value
		End Set
	End Property
#End Region
#Region "15B 屬性:FD15B"
	Private _FD15B As System.String
	''' <summary>
	''' 15B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD15B () As System.String
		Get
			Return _FD15B
		End Get
		Set(Byval value as System.String)
			_FD15B = value
		End Set
	End Property
#End Region
#Region "16B 屬性:FD16B"
	Private _FD16B As System.String
	''' <summary>
	''' 16B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD16B () As System.String
		Get
			Return _FD16B
		End Get
		Set(Byval value as System.String)
			_FD16B = value
		End Set
	End Property
#End Region
#Region "17B 屬性:FD17B"
	Private _FD17B As System.String
	''' <summary>
	''' 17B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD17B () As System.String
		Get
			Return _FD17B
		End Get
		Set(Byval value as System.String)
			_FD17B = value
		End Set
	End Property
#End Region
#Region "18B 屬性:FD18B"
	Private _FD18B As System.String
	''' <summary>
	''' 18B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD18B () As System.String
		Get
			Return _FD18B
		End Get
		Set(Byval value as System.String)
			_FD18B = value
		End Set
	End Property
#End Region
#Region "19B 屬性:FD19B"
	Private _FD19B As System.String
	''' <summary>
	''' 19B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD19B () As System.String
		Get
			Return _FD19B
		End Get
		Set(Byval value as System.String)
			_FD19B = value
		End Set
	End Property
#End Region
#Region "20B 屬性:FD20B"
	Private _FD20B As System.String
	''' <summary>
	''' 20B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD20B () As System.String
		Get
			Return _FD20B
		End Get
		Set(Byval value as System.String)
			_FD20B = value
		End Set
	End Property
#End Region
#Region "21B 屬性:FD21B"
	Private _FD21B As System.String
	''' <summary>
	''' 21B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD21B () As System.String
		Get
			Return _FD21B
		End Get
		Set(Byval value as System.String)
			_FD21B = value
		End Set
	End Property
#End Region
#Region "22B 屬性:FD22B"
	Private _FD22B As System.String
	''' <summary>
	''' 22B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD22B () As System.String
		Get
			Return _FD22B
		End Get
		Set(Byval value as System.String)
			_FD22B = value
		End Set
	End Property
#End Region
#Region "23B 屬性:FD23B"
	Private _FD23B As System.String
	''' <summary>
	''' 23B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD23B () As System.String
		Get
			Return _FD23B
		End Get
		Set(Byval value as System.String)
			_FD23B = value
		End Set
	End Property
#End Region
#Region "24B 屬性:FD24B"
	Private _FD24B As System.String
	''' <summary>
	''' 24B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD24B () As System.String
		Get
			Return _FD24B
		End Get
		Set(Byval value as System.String)
			_FD24B = value
		End Set
	End Property
#End Region
#Region "25B 屬性:FD25B"
	Private _FD25B As System.String
	''' <summary>
	''' 25B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD25B () As System.String
		Get
			Return _FD25B
		End Get
		Set(Byval value as System.String)
			_FD25B = value
		End Set
	End Property
#End Region
#Region "26B 屬性:FD26B"
	Private _FD26B As System.String
	''' <summary>
	''' 26B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD26B () As System.String
		Get
			Return _FD26B
		End Get
		Set(Byval value as System.String)
			_FD26B = value
		End Set
	End Property
#End Region
#Region "27B 屬性:FD27B"
	Private _FD27B As System.String
	''' <summary>
	''' 27B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD27B () As System.String
		Get
			Return _FD27B
		End Get
		Set(Byval value as System.String)
			_FD27B = value
		End Set
	End Property
#End Region
#Region "28B 屬性:FD28B"
	Private _FD28B As System.String
	''' <summary>
	''' 28B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD28B () As System.String
		Get
			Return _FD28B
		End Get
		Set(Byval value as System.String)
			_FD28B = value
		End Set
	End Property
#End Region
#Region "29B 屬性:FD29B"
	Private _FD29B As System.String
	''' <summary>
	''' 29B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD29B () As System.String
		Get
			Return _FD29B
		End Get
		Set(Byval value as System.String)
			_FD29B = value
		End Set
	End Property
#End Region
#Region "30B 屬性:FD30B"
	Private _FD30B As System.String
	''' <summary>
	''' 30B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD30B () As System.String
		Get
			Return _FD30B
		End Get
		Set(Byval value as System.String)
			_FD30B = value
		End Set
	End Property
#End Region
#Region "31B 屬性:FD31B"
	Private _FD31B As System.String
	''' <summary>
	''' 31B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD31B () As System.String
		Get
			Return _FD31B
		End Get
		Set(Byval value as System.String)
			_FD31B = value
		End Set
	End Property
#End Region
#Region "01晚 屬性:FD01C"
	Private _FD01C As System.String
	''' <summary>
	''' 01晚
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD01C () As System.String
		Get
			Return _FD01C
		End Get
		Set(Byval value as System.String)
			_FD01C = value
		End Set
	End Property
#End Region
#Region "02C 屬性:FD02C"
	Private _FD02C As System.String
	''' <summary>
	''' 02C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD02C () As System.String
		Get
			Return _FD02C
		End Get
		Set(Byval value as System.String)
			_FD02C = value
		End Set
	End Property
#End Region
#Region "03C 屬性:FD03C"
	Private _FD03C As System.String
	''' <summary>
	''' 03C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD03C () As System.String
		Get
			Return _FD03C
		End Get
		Set(Byval value as System.String)
			_FD03C = value
		End Set
	End Property
#End Region
#Region "04C 屬性:FD04C"
	Private _FD04C As System.String
	''' <summary>
	''' 04C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD04C () As System.String
		Get
			Return _FD04C
		End Get
		Set(Byval value as System.String)
			_FD04C = value
		End Set
	End Property
#End Region
#Region "05C 屬性:FD05C"
	Private _FD05C As System.String
	''' <summary>
	''' 05C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD05C () As System.String
		Get
			Return _FD05C
		End Get
		Set(Byval value as System.String)
			_FD05C = value
		End Set
	End Property
#End Region
#Region "06C 屬性:FD06C"
	Private _FD06C As System.String
	''' <summary>
	''' 06C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD06C () As System.String
		Get
			Return _FD06C
		End Get
		Set(Byval value as System.String)
			_FD06C = value
		End Set
	End Property
#End Region
#Region "07C 屬性:FD07C"
	Private _FD07C As System.String
	''' <summary>
	''' 07C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD07C () As System.String
		Get
			Return _FD07C
		End Get
		Set(Byval value as System.String)
			_FD07C = value
		End Set
	End Property
#End Region
#Region "08C 屬性:FD08C"
	Private _FD08C As System.String
	''' <summary>
	''' 08C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD08C () As System.String
		Get
			Return _FD08C
		End Get
		Set(Byval value as System.String)
			_FD08C = value
		End Set
	End Property
#End Region
#Region "09C 屬性:FD09C"
	Private _FD09C As System.String
	''' <summary>
	''' 09C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD09C () As System.String
		Get
			Return _FD09C
		End Get
		Set(Byval value as System.String)
			_FD09C = value
		End Set
	End Property
#End Region
#Region "10C 屬性:FD10C"
	Private _FD10C As System.String
	''' <summary>
	''' 10C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD10C () As System.String
		Get
			Return _FD10C
		End Get
		Set(Byval value as System.String)
			_FD10C = value
		End Set
	End Property
#End Region
#Region "11C 屬性:FD11C"
	Private _FD11C As System.String
	''' <summary>
	''' 11C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD11C () As System.String
		Get
			Return _FD11C
		End Get
		Set(Byval value as System.String)
			_FD11C = value
		End Set
	End Property
#End Region
#Region "12C 屬性:FD12C"
	Private _FD12C As System.String
	''' <summary>
	''' 12C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD12C () As System.String
		Get
			Return _FD12C
		End Get
		Set(Byval value as System.String)
			_FD12C = value
		End Set
	End Property
#End Region
#Region "13C 屬性:FD13C"
	Private _FD13C As System.String
	''' <summary>
	''' 13C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD13C () As System.String
		Get
			Return _FD13C
		End Get
		Set(Byval value as System.String)
			_FD13C = value
		End Set
	End Property
#End Region
#Region "14C 屬性:FD14C"
	Private _FD14C As System.String
	''' <summary>
	''' 14C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD14C () As System.String
		Get
			Return _FD14C
		End Get
		Set(Byval value as System.String)
			_FD14C = value
		End Set
	End Property
#End Region
#Region "15C 屬性:FD15C"
	Private _FD15C As System.String
	''' <summary>
	''' 15C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD15C () As System.String
		Get
			Return _FD15C
		End Get
		Set(Byval value as System.String)
			_FD15C = value
		End Set
	End Property
#End Region
#Region "16C 屬性:FD16C"
	Private _FD16C As System.String
	''' <summary>
	''' 16C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD16C () As System.String
		Get
			Return _FD16C
		End Get
		Set(Byval value as System.String)
			_FD16C = value
		End Set
	End Property
#End Region
#Region "17C 屬性:FD17C"
	Private _FD17C As System.String
	''' <summary>
	''' 17C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD17C () As System.String
		Get
			Return _FD17C
		End Get
		Set(Byval value as System.String)
			_FD17C = value
		End Set
	End Property
#End Region
#Region "18C 屬性:FD18C"
	Private _FD18C As System.String
	''' <summary>
	''' 18C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD18C () As System.String
		Get
			Return _FD18C
		End Get
		Set(Byval value as System.String)
			_FD18C = value
		End Set
	End Property
#End Region
#Region "19C 屬性:FD19C"
	Private _FD19C As System.String
	''' <summary>
	''' 19C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD19C () As System.String
		Get
			Return _FD19C
		End Get
		Set(Byval value as System.String)
			_FD19C = value
		End Set
	End Property
#End Region
#Region "20C 屬性:FD20C"
	Private _FD20C As System.String
	''' <summary>
	''' 20C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD20C () As System.String
		Get
			Return _FD20C
		End Get
		Set(Byval value as System.String)
			_FD20C = value
		End Set
	End Property
#End Region
#Region "21C 屬性:FD21C"
	Private _FD21C As System.String
	''' <summary>
	''' 21C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD21C () As System.String
		Get
			Return _FD21C
		End Get
		Set(Byval value as System.String)
			_FD21C = value
		End Set
	End Property
#End Region
#Region "22C 屬性:FD22C"
	Private _FD22C As System.String
	''' <summary>
	''' 22C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD22C () As System.String
		Get
			Return _FD22C
		End Get
		Set(Byval value as System.String)
			_FD22C = value
		End Set
	End Property
#End Region
#Region "23C 屬性:FD23C"
	Private _FD23C As System.String
	''' <summary>
	''' 23C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD23C () As System.String
		Get
			Return _FD23C
		End Get
		Set(Byval value as System.String)
			_FD23C = value
		End Set
	End Property
#End Region
#Region "24C 屬性:FD24C"
	Private _FD24C As System.String
	''' <summary>
	''' 24C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD24C () As System.String
		Get
			Return _FD24C
		End Get
		Set(Byval value as System.String)
			_FD24C = value
		End Set
	End Property
#End Region
#Region "25C 屬性:FD25C"
	Private _FD25C As System.String
	''' <summary>
	''' 25C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD25C () As System.String
		Get
			Return _FD25C
		End Get
		Set(Byval value as System.String)
			_FD25C = value
		End Set
	End Property
#End Region
#Region "26C 屬性:FD26C"
	Private _FD26C As System.String
	''' <summary>
	''' 26C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD26C () As System.String
		Get
			Return _FD26C
		End Get
		Set(Byval value as System.String)
			_FD26C = value
		End Set
	End Property
#End Region
#Region "27C 屬性:FD27C"
	Private _FD27C As System.String
	''' <summary>
	''' 27C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD27C () As System.String
		Get
			Return _FD27C
		End Get
		Set(Byval value as System.String)
			_FD27C = value
		End Set
	End Property
#End Region
#Region "28C 屬性:FD28C"
	Private _FD28C As System.String
	''' <summary>
	''' 28C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD28C () As System.String
		Get
			Return _FD28C
		End Get
		Set(Byval value as System.String)
			_FD28C = value
		End Set
	End Property
#End Region
#Region "29C 屬性:FD29C"
	Private _FD29C As System.String
	''' <summary>
	''' 29C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD29C () As System.String
		Get
			Return _FD29C
		End Get
		Set(Byval value as System.String)
			_FD29C = value
		End Set
	End Property
#End Region
#Region "30C 屬性:FD30C"
	Private _FD30C As System.String
	''' <summary>
	''' 30C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD30C () As System.String
		Get
			Return _FD30C
		End Get
		Set(Byval value as System.String)
			_FD30C = value
		End Set
	End Property
#End Region
#Region "31C 屬性:FD31C"
	Private _FD31C As System.String
	''' <summary>
	''' 31C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD31C () As System.String
		Get
			Return _FD31C
		End Get
		Set(Byval value as System.String)
			_FD31C = value
		End Set
	End Property
#End Region
#Region "早 屬性:FDT1A"
	Private _FDT1A As System.Int32
	''' <summary>
	''' 早
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDT1A () As System.Int32
		Get
			Return _FDT1A
		End Get
		Set(Byval value as System.Int32)
			_FDT1A = value
		End Set
	End Property
#End Region
#Region "中 屬性:FDT1B"
	Private _FDT1B As System.Int32
	''' <summary>
	''' 中
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDT1B () As System.Int32
		Get
			Return _FDT1B
		End Get
		Set(Byval value as System.Int32)
			_FDT1B = value
		End Set
	End Property
#End Region
#Region "晚 屬性:FDT1C"
	Private _FDT1C As System.Int32
	''' <summary>
	''' 晚
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDT1C () As System.Int32
		Get
			Return _FDT1C
		End Get
		Set(Byval value as System.Int32)
			_FDT1C = value
		End Set
	End Property
#End Region
#Region "應付 屬性:FDTPY"
	Private _FDTPY As System.Int32
	''' <summary>
	''' 應付
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDTPY () As System.Int32
		Get
			Return _FDTPY
		End Get
		Set(Byval value as System.Int32)
			_FDTPY = value
		End Set
	End Property
#End Region
#Region "補貼 屬性:FDTSB"
	Private _FDTSB As System.Int32
	''' <summary>
	''' 補貼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDTSB () As System.Int32
		Get
			Return _FDTSB
		End Get
		Set(Byval value as System.Int32)
			_FDTSB = value
		End Set
	End Property
#End Region
#Region "實付 屬性:FDTNP"
	Private _FDTNP As System.Int32
	''' <summary>
	''' 實付
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDTNP () As System.Int32
		Get
			Return _FDTNP
		End Get
		Set(Byval value as System.Int32)
			_FDTNP = value
		End Set
	End Property
#End Region
#Region "民國年月 屬性:FDEEEMM"
	Private _FDEEEMM As System.Int32
	''' <summary>
	''' 民國年月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FDEEEMM () As System.Int32
		Get
			Return _FDEEEMM
		End Get
		Set(Byval value as System.Int32)
			_FDEEEMM = value
		End Set
	End Property
#End Region
#Region "存檔日期時間 屬性:FDSAVEDATE"
	Private _FDSAVEDATE As System.String
	''' <summary>
	''' 存檔日期時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FDSAVEDATE () As System.String
		Get
			Return _FDSAVEDATE
		End Get
		Set(Byval value as System.String)
			_FDSAVEDATE = value
		End Set
	End Property
#End Region
#Region "存檔人員 屬性:FDSAVEOPER"
	Private _FDSAVEOPER As System.String
	''' <summary>
	''' 存檔人員
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDSAVEOPER () As System.String
		Get
			Return _FDSAVEOPER
		End Get
		Set(Byval value as System.String)
			_FDSAVEOPER = value
		End Set
	End Property
#End Region
#Region "存檔裝置 屬性:FDSAVEPC"
	Private _FDSAVEPC As System.String
	''' <summary>
	''' 存檔裝置
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDSAVEPC () As System.String
		Get
			Return _FDSAVEPC
		End Get
		Set(Byval value as System.String)
			_FDSAVEPC = value
		End Set
	End Property
#End Region
End Class
End Namespace