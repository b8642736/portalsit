Namespace FOD100LB
Public Class FODM01PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("FOD100LB", GetType(FODM01PF).Name)
	End Sub

#Region "員工編號 屬性:FD001"
	Private _FD001 As System.String
	''' <summary>
	''' 員工編號
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
#Region "部門 屬性:FD005"
	Private _FD005 As System.String
	''' <summary>
	''' 部門
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
#Region "01 屬性:FD01A"
	Private _FD01A As System.String
	''' <summary>
	''' 01
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
#Region "02 屬性:FD02A"
	Private _FD02A As System.String
	''' <summary>
	''' 02
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
#Region "03 屬性:FD03A"
	Private _FD03A As System.String
	''' <summary>
	''' 03
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
#Region "04 屬性:FD04A"
	Private _FD04A As System.String
	''' <summary>
	''' 04
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
#Region "05 屬性:FD05A"
	Private _FD05A As System.String
	''' <summary>
	''' 05
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
#Region "06 屬性:FD06A"
	Private _FD06A As System.String
	''' <summary>
	''' 06
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
#Region "07 屬性:FD07A"
	Private _FD07A As System.String
	''' <summary>
	''' 07
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
#Region "08 屬性:FD08A"
	Private _FD08A As System.String
	''' <summary>
	''' 08
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
#Region "09 屬性:FD09A"
	Private _FD09A As System.String
	''' <summary>
	''' 09
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
#Region "10 屬性:FD10A"
	Private _FD10A As System.String
	''' <summary>
	''' 10
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
#Region "11 屬性:FD11A"
	Private _FD11A As System.String
	''' <summary>
	''' 11
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
#Region "12 屬性:FD12A"
	Private _FD12A As System.String
	''' <summary>
	''' 12
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
#Region "13 屬性:FD13A"
	Private _FD13A As System.String
	''' <summary>
	''' 13
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
#Region "14 屬性:FD14A"
	Private _FD14A As System.String
	''' <summary>
	''' 14
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
#Region "15 屬性:FD15A"
	Private _FD15A As System.String
	''' <summary>
	''' 15
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
#Region "16 屬性:FD16A"
	Private _FD16A As System.String
	''' <summary>
	''' 16
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
#Region "17 屬性:FD17A"
	Private _FD17A As System.String
	''' <summary>
	''' 17
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
#Region "18 屬性:FD18A"
	Private _FD18A As System.String
	''' <summary>
	''' 18
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
#Region "19 屬性:FD19A"
	Private _FD19A As System.String
	''' <summary>
	''' 19
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
#Region "20 屬性:FD20A"
	Private _FD20A As System.String
	''' <summary>
	''' 20
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
#Region "21 屬性:FD21A"
	Private _FD21A As System.String
	''' <summary>
	''' 21
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
#Region "22 屬性:FD22A"
	Private _FD22A As System.String
	''' <summary>
	''' 22
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
#Region "23 屬性:FD23A"
	Private _FD23A As System.String
	''' <summary>
	''' 23
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
#Region "24 屬性:FD24A"
	Private _FD24A As System.String
	''' <summary>
	''' 24
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
#Region "25 屬性:FD25A"
	Private _FD25A As System.String
	''' <summary>
	''' 25
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
#Region "26 屬性:FD26A"
	Private _FD26A As System.String
	''' <summary>
	''' 26
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
#Region "27 屬性:FD27A"
	Private _FD27A As System.String
	''' <summary>
	''' 27
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
#Region "28 屬性:FD28A"
	Private _FD28A As System.String
	''' <summary>
	''' 28
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
#Region "29 屬性:FD29A"
	Private _FD29A As System.String
	''' <summary>
	''' 29
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
#Region "30 屬性:FD30A"
	Private _FD30A As System.String
	''' <summary>
	''' 30
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
#Region "31 屬性:FD31A"
	Private _FD31A As System.String
	''' <summary>
	''' 31
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
#Region "01 屬性:FD01B"
	Private _FD01B As System.String
	''' <summary>
	''' 01
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
#Region "02 屬性:FD02B"
	Private _FD02B As System.String
	''' <summary>
	''' 02
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
#Region "03 屬性:FD03B"
	Private _FD03B As System.String
	''' <summary>
	''' 03
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
#Region "04 屬性:FD04B"
	Private _FD04B As System.String
	''' <summary>
	''' 04
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
#Region "05 屬性:FD05B"
	Private _FD05B As System.String
	''' <summary>
	''' 05
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
#Region "06 屬性:FD06B"
	Private _FD06B As System.String
	''' <summary>
	''' 06
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
#Region "07 屬性:FD07B"
	Private _FD07B As System.String
	''' <summary>
	''' 07
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
#Region "08 屬性:FD08B"
	Private _FD08B As System.String
	''' <summary>
	''' 08
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
#Region "09 屬性:FD09B"
	Private _FD09B As System.String
	''' <summary>
	''' 09
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
#Region "10 屬性:FD10B"
	Private _FD10B As System.String
	''' <summary>
	''' 10
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
#Region "11 屬性:FD11B"
	Private _FD11B As System.String
	''' <summary>
	''' 11
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
#Region "12 屬性:FD12B"
	Private _FD12B As System.String
	''' <summary>
	''' 12
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
#Region "13 屬性:FD13B"
	Private _FD13B As System.String
	''' <summary>
	''' 13
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
#Region "14 屬性:FD14B"
	Private _FD14B As System.String
	''' <summary>
	''' 14
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
#Region "15 屬性:FD15B"
	Private _FD15B As System.String
	''' <summary>
	''' 15
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
#Region "16 屬性:FD16B"
	Private _FD16B As System.String
	''' <summary>
	''' 16
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
#Region "17 屬性:FD17B"
	Private _FD17B As System.String
	''' <summary>
	''' 17
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
#Region "18 屬性:FD18B"
	Private _FD18B As System.String
	''' <summary>
	''' 18
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
#Region "19 屬性:FD19B"
	Private _FD19B As System.String
	''' <summary>
	''' 19
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
#Region "20 屬性:FD20B"
	Private _FD20B As System.String
	''' <summary>
	''' 20
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
#Region "21 屬性:FD21B"
	Private _FD21B As System.String
	''' <summary>
	''' 21
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
#Region "22 屬性:FD22B"
	Private _FD22B As System.String
	''' <summary>
	''' 22
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
#Region "23 屬性:FD23B"
	Private _FD23B As System.String
	''' <summary>
	''' 23
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
#Region "24 屬性:FD24B"
	Private _FD24B As System.String
	''' <summary>
	''' 24
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
#Region "25 屬性:FD25B"
	Private _FD25B As System.String
	''' <summary>
	''' 25
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
#Region "26 屬性:FD26B"
	Private _FD26B As System.String
	''' <summary>
	''' 26
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
#Region "27 屬性:FD27B"
	Private _FD27B As System.String
	''' <summary>
	''' 27
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
#Region "28 屬性:FD28B"
	Private _FD28B As System.String
	''' <summary>
	''' 28
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
#Region "29 屬性:FD29B"
	Private _FD29B As System.String
	''' <summary>
	''' 29
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
#Region "30 屬性:FD30B"
	Private _FD30B As System.String
	''' <summary>
	''' 30
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
#Region "31 屬性:FD31B"
	Private _FD31B As System.String
	''' <summary>
	''' 31
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
#Region "01 屬性:FD01C"
	Private _FD01C As System.String
	''' <summary>
	''' 01
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
#Region "02 屬性:FD02C"
	Private _FD02C As System.String
	''' <summary>
	''' 02
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
#Region "03 屬性:FD03C"
	Private _FD03C As System.String
	''' <summary>
	''' 03
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
#Region "04 屬性:FD04C"
	Private _FD04C As System.String
	''' <summary>
	''' 04
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
#Region "05 屬性:FD05C"
	Private _FD05C As System.String
	''' <summary>
	''' 05
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
#Region "06 屬性:FD06C"
	Private _FD06C As System.String
	''' <summary>
	''' 06
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
#Region "07 屬性:FD07C"
	Private _FD07C As System.String
	''' <summary>
	''' 07
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
#Region "08 屬性:FD08C"
	Private _FD08C As System.String
	''' <summary>
	''' 08
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
#Region "09 屬性:FD09C"
	Private _FD09C As System.String
	''' <summary>
	''' 09
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
#Region "10 屬性:FD10C"
	Private _FD10C As System.String
	''' <summary>
	''' 10
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
#Region "11 屬性:FD11C"
	Private _FD11C As System.String
	''' <summary>
	''' 11
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
#Region "12 屬性:FD12C"
	Private _FD12C As System.String
	''' <summary>
	''' 12
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
#Region "13 屬性:FD13C"
	Private _FD13C As System.String
	''' <summary>
	''' 13
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
#Region "14 屬性:FD14C"
	Private _FD14C As System.String
	''' <summary>
	''' 14
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
#Region "15 屬性:FD15C"
	Private _FD15C As System.String
	''' <summary>
	''' 15
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
#Region "16 屬性:FD16C"
	Private _FD16C As System.String
	''' <summary>
	''' 16
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
#Region "17 屬性:FD17C"
	Private _FD17C As System.String
	''' <summary>
	''' 17
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
#Region "18 屬性:FD18C"
	Private _FD18C As System.String
	''' <summary>
	''' 18
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
#Region "19 屬性:FD19C"
	Private _FD19C As System.String
	''' <summary>
	''' 19
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
#Region "20 屬性:FD20C"
	Private _FD20C As System.String
	''' <summary>
	''' 20
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
#Region "21 屬性:FD21C"
	Private _FD21C As System.String
	''' <summary>
	''' 21
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
#Region "22 屬性:FD22C"
	Private _FD22C As System.String
	''' <summary>
	''' 22
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
#Region "23 屬性:FD23C"
	Private _FD23C As System.String
	''' <summary>
	''' 23
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
#Region "24 屬性:FD24C"
	Private _FD24C As System.String
	''' <summary>
	''' 24
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
#Region "25 屬性:FD25C"
	Private _FD25C As System.String
	''' <summary>
	''' 25
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
#Region "26 屬性:FD26C"
	Private _FD26C As System.String
	''' <summary>
	''' 26
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
#Region "27 屬性:FD27C"
	Private _FD27C As System.String
	''' <summary>
	''' 27
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
#Region "28 屬性:FD28C"
	Private _FD28C As System.String
	''' <summary>
	''' 28
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
#Region "29 屬性:FD29C"
	Private _FD29C As System.String
	''' <summary>
	''' 29
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
#Region "30 屬性:FD30C"
	Private _FD30C As System.String
	''' <summary>
	''' 30
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
#Region "31 屬性:FD31C"
	Private _FD31C As System.String
	''' <summary>
	''' 31
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
#Region "早餐次數 屬性:FDT1A"
	Private _FDT1A As System.Int32
	''' <summary>
	''' 早餐次數
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
#Region "午餐次數 屬性:FDT1B"
	Private _FDT1B As System.Int32
	''' <summary>
	''' 午餐次數
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
#Region "晚餐次數 屬性:FDT1C"
	Private _FDT1C As System.Int32
	''' <summary>
	''' 晚餐次數
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
#Region "應付金額 屬性:FDTPY"
	Private _FDTPY As System.Int32
	''' <summary>
	''' 應付金額
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
#Region "補貼金額 屬性:FDTSB"
	Private _FDTSB As System.Int32
	''' <summary>
	''' 補貼金額
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
#Region "實付金額 屬性:FDTNP"
	Private _FDTNP As System.Int32
	''' <summary>
	''' 實付金額
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
#Region "1-25月結時間 屬性:FDTIM1"
        Private _FDTIM1 As System.Decimal
	''' <summary>
	''' 1-25月結時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property FDTIM1() As System.Decimal
            Get
                Return _FDTIM1
            End Get
            Set(ByVal value As System.Decimal)
                _FDTIM1 = value
            End Set
        End Property
#End Region
#Region "早餐次數 屬性:FDT1A2"
	Private _FDT1A2 As System.Int32
	''' <summary>
	''' 早餐次數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDT1A2 () As System.Int32
		Get
			Return _FDT1A2
		End Get
		Set(Byval value as System.Int32)
			_FDT1A2 = value
		End Set
	End Property
#End Region
#Region "午餐次數 屬性:FDT1B2"
	Private _FDT1B2 As System.Int32
	''' <summary>
	''' 午餐次數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDT1B2 () As System.Int32
		Get
			Return _FDT1B2
		End Get
		Set(Byval value as System.Int32)
			_FDT1B2 = value
		End Set
	End Property
#End Region
#Region "晚餐次數 屬性:FDT1C2"
	Private _FDT1C2 As System.Int32
	''' <summary>
	''' 晚餐次數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDT1C2 () As System.Int32
		Get
			Return _FDT1C2
		End Get
		Set(Byval value as System.Int32)
			_FDT1C2 = value
		End Set
	End Property
#End Region
#Region "應付金額 屬性:FDTPY2"
	Private _FDTPY2 As System.Int32
	''' <summary>
	''' 應付金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDTPY2 () As System.Int32
		Get
			Return _FDTPY2
		End Get
		Set(Byval value as System.Int32)
			_FDTPY2 = value
		End Set
	End Property
#End Region
#Region "補貼金額 屬性:FDTSB2"
	Private _FDTSB2 As System.Int32
	''' <summary>
	''' 補貼金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDTSB2 () As System.Int32
		Get
			Return _FDTSB2
		End Get
		Set(Byval value as System.Int32)
			_FDTSB2 = value
		End Set
	End Property
#End Region
#Region "實付金額 屬性:FDTNP2"
	Private _FDTNP2 As System.Int32
	''' <summary>
	''' 實付金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDTNP2 () As System.Int32
		Get
			Return _FDTNP2
		End Get
		Set(Byval value as System.Int32)
			_FDTNP2 = value
		End Set
	End Property
#End Region
#Region "25後月結時間 屬性:FDTIM2"
        Private _FDTIM2 As System.Decimal
	''' <summary>
	''' 25後月結時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property FDTIM2() As System.Decimal
            Get
                Return _FDTIM2
            End Get
            Set(ByVal value As System.Decimal)
                _FDTIM2 = value
            End Set
        End Property
#End Region
#Region "伙食年月 屬性:FDTYM - 改寫，設定值時多去呼叫queryPQDM03PF"
        Private _FDTYM As System.Int32
        ''' <summary>
        ''' 伙食年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property FDTYM() As System.Int32
            Get
                Return _FDTYM
            End Get
            Set(ByVal value As System.Int32)
                _FDTYM = value
                queryPQDM03PF()

            End Set
        End Property
#End Region
#Region "存檔日期 屬性:FDSDTE"
	Private _FDSDTE As System.Int32
	''' <summary>
	''' 存檔日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDSDTE () As System.Int32
		Get
			Return _FDSDTE
		End Get
		Set(Byval value as System.Int32)
			_FDSDTE = value
		End Set
	End Property
#End Region
#Region "存檔時間 屬性:FDSTIM"
	Private _FDSTIM As System.Int32
	''' <summary>
	''' 存檔時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDSTIM () As System.Int32
		Get
			Return _FDSTIM
		End Get
		Set(Byval value as System.Int32)
			_FDSTIM = value
		End Set
	End Property
#End Region
#Region "存檔人員 屬性:FDSOPR"
	Private _FDSOPR As System.String
	''' <summary>
	''' 存檔人員
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDSOPR () As System.String
		Get
			Return _FDSOPR
		End Get
		Set(Byval value as System.String)
			_FDSOPR = value
		End Set
	End Property
#End Region
#Region "存檔裝置 屬性:FDSDEV"
	Private _FDSDEV As System.String
	''' <summary>
	''' 存檔裝置
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FDSDEV () As System.String
		Get
			Return _FDSDEV
		End Get
		Set(Byval value as System.String)
			_FDSDEV = value
		End Set
	End Property
#End Region



#Region "出勤資訊"

        Public Sub queryPQDM03PF()
            'Dim queryCDBMemberName As String = CDBMemberName.ToUpper.Replace("FOD", "")
            'Dim queryEEEMM As Integer
            'If Integer.TryParse(queryCDBMemberName, queryEEEMM) = False Then Exit Sub
            Dim queryEEEMM As Integer = Me.FDTYM

            Dim queryEEE As Integer = -Fix(-queryEEEMM / 100)
            Dim queryMM As Integer = queryEEEMM Mod 100
            Dim SQL As New System.Text.StringBuilder
            SQL.Append("SELECT * " & vbNewLine)
            SQL.Append("FROM @#PLT000LB.PQDM03PF " & vbNewLine)
            SQL.Append("WHERE 1=1 " & vbNewLine)
            SQL.Append("   AND qd3001='" & Me.FD001 & "' " & vbNewLine)
            SQL.Append("   AND qd3007=" & queryEEE & vbNewLine)
            SQL.Append("   AND qd3008=" & queryMM & vbNewLine)

            Dim queryList As List(Of PLT000LB.PQDM03PF) = PLT000LB.PQDM03PF.CDBSelect(Of PLT000LB.PQDM03PF)(SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

            Dim show出勤時間 As String
            For Each eachItem As PLT000LB.PQDM03PF In queryList

                show出勤時間 = eachItem.QD3012.Trim
                If show出勤時間 <> "" Then show出勤時間 &= "~"
                show出勤時間 &= eachItem.QD3013.Trim

                pubClassFieldValue("出勤班別" & String.Format("{0:00}", Integer.Parse(eachItem.QD3009)), eachItem.QD3033)
                pubClassFieldValue("出勤時間" & String.Format("{0:00}", Integer.Parse(eachItem.QD3009)), show出勤時間)

            Next

        End Sub


        Private Sub pubClassFieldValue(ByVal FieldName As String, ByVal SetValue As Object, _
                                                                                                              Optional ByVal AttributeNIndex As Object() = Nothing)
            '設定資料庫類別所有'屬性'之值
            Dim myPropertyInfo As PropertyInfo = Nothing
            For Each EachItem As PropertyInfo In Me.GetType.GetProperties
                If EachItem.Name = FieldName Then
                    myPropertyInfo = EachItem
                    Exit For
                End If
            Next
            If myPropertyInfo Is Nothing Then Exit Sub

            myPropertyInfo.SetValue(Me, SetValue, AttributeNIndex)
        End Sub



        Private _出勤班別01 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別01() As System.String
            Get
                Return _出勤班別01
            End Get
            Set(ByVal value As System.String)
                _出勤班別01 = value
            End Set
        End Property

        Private _出勤時間01 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間01() As System.String
            Get
                Return _出勤時間01
            End Get
            Set(ByVal value As System.String)
                _出勤時間01 = value
            End Set
        End Property

        Private _出勤班別02 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別02() As System.String
            Get
                Return _出勤班別02
            End Get
            Set(ByVal value As System.String)
                _出勤班別02 = value
            End Set
        End Property

        Private _出勤時間02 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間02() As System.String
            Get
                Return _出勤時間02
            End Get
            Set(ByVal value As System.String)
                _出勤時間02 = value
            End Set
        End Property

        Private _出勤班別03 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別03() As System.String
            Get
                Return _出勤班別03
            End Get
            Set(ByVal value As System.String)
                _出勤班別03 = value
            End Set
        End Property

        Private _出勤時間03 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間03() As System.String
            Get
                Return _出勤時間03
            End Get
            Set(ByVal value As System.String)
                _出勤時間03 = value
            End Set
        End Property

        Private _出勤班別04 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別04() As System.String
            Get
                Return _出勤班別04
            End Get
            Set(ByVal value As System.String)
                _出勤班別04 = value
            End Set
        End Property

        Private _出勤時間04 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間04() As System.String
            Get
                Return _出勤時間04
            End Get
            Set(ByVal value As System.String)
                _出勤時間04 = value
            End Set
        End Property

        Private _出勤班別05 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別05() As System.String
            Get
                Return _出勤班別05
            End Get
            Set(ByVal value As System.String)
                _出勤班別05 = value
            End Set
        End Property

        Private _出勤時間05 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間05() As System.String
            Get
                Return _出勤時間05
            End Get
            Set(ByVal value As System.String)
                _出勤時間05 = value
            End Set
        End Property

        Private _出勤班別06 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別06() As System.String
            Get
                Return _出勤班別06
            End Get
            Set(ByVal value As System.String)
                _出勤班別06 = value
            End Set
        End Property

        Private _出勤時間06 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間06() As System.String
            Get
                Return _出勤時間06
            End Get
            Set(ByVal value As System.String)
                _出勤時間06 = value
            End Set
        End Property

        Private _出勤班別07 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別07() As System.String
            Get
                Return _出勤班別07
            End Get
            Set(ByVal value As System.String)
                _出勤班別07 = value
            End Set
        End Property

        Private _出勤時間07 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間07() As System.String
            Get
                Return _出勤時間07
            End Get
            Set(ByVal value As System.String)
                _出勤時間07 = value
            End Set
        End Property

        Private _出勤班別08 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別08() As System.String
            Get
                Return _出勤班別08
            End Get
            Set(ByVal value As System.String)
                _出勤班別08 = value
            End Set
        End Property

        Private _出勤時間08 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間08() As System.String
            Get
                Return _出勤時間08
            End Get
            Set(ByVal value As System.String)
                _出勤時間08 = value
            End Set
        End Property

        Private _出勤班別09 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別09() As System.String
            Get
                Return _出勤班別09
            End Get
            Set(ByVal value As System.String)
                _出勤班別09 = value
            End Set
        End Property

        Private _出勤時間09 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間09() As System.String
            Get
                Return _出勤時間09
            End Get
            Set(ByVal value As System.String)
                _出勤時間09 = value
            End Set
        End Property

        Private _出勤班別10 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別10() As System.String
            Get
                Return _出勤班別10
            End Get
            Set(ByVal value As System.String)
                _出勤班別10 = value
            End Set
        End Property

        Private _出勤時間10 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間10() As System.String
            Get
                Return _出勤時間10
            End Get
            Set(ByVal value As System.String)
                _出勤時間10 = value
            End Set
        End Property

        Private _出勤班別11 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別11() As System.String
            Get
                Return _出勤班別11
            End Get
            Set(ByVal value As System.String)
                _出勤班別11 = value
            End Set
        End Property

        Private _出勤時間11 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間11() As System.String
            Get
                Return _出勤時間11
            End Get
            Set(ByVal value As System.String)
                _出勤時間11 = value
            End Set
        End Property

        Private _出勤班別12 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別12() As System.String
            Get
                Return _出勤班別12
            End Get
            Set(ByVal value As System.String)
                _出勤班別12 = value
            End Set
        End Property

        Private _出勤時間12 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間12() As System.String
            Get
                Return _出勤時間12
            End Get
            Set(ByVal value As System.String)
                _出勤時間12 = value
            End Set
        End Property

        Private _出勤班別13 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別13() As System.String
            Get
                Return _出勤班別13
            End Get
            Set(ByVal value As System.String)
                _出勤班別13 = value
            End Set
        End Property

        Private _出勤時間13 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間13() As System.String
            Get
                Return _出勤時間13
            End Get
            Set(ByVal value As System.String)
                _出勤時間13 = value
            End Set
        End Property

        Private _出勤班別14 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別14() As System.String
            Get
                Return _出勤班別14
            End Get
            Set(ByVal value As System.String)
                _出勤班別14 = value
            End Set
        End Property

        Private _出勤時間14 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間14() As System.String
            Get
                Return _出勤時間14
            End Get
            Set(ByVal value As System.String)
                _出勤時間14 = value
            End Set
        End Property

        Private _出勤班別15 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別15() As System.String
            Get
                Return _出勤班別15
            End Get
            Set(ByVal value As System.String)
                _出勤班別15 = value
            End Set
        End Property

        Private _出勤時間15 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間15() As System.String
            Get
                Return _出勤時間15
            End Get
            Set(ByVal value As System.String)
                _出勤時間15 = value
            End Set
        End Property

        Private _出勤班別16 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別16() As System.String
            Get
                Return _出勤班別16
            End Get
            Set(ByVal value As System.String)
                _出勤班別16 = value
            End Set
        End Property

        Private _出勤時間16 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間16() As System.String
            Get
                Return _出勤時間16
            End Get
            Set(ByVal value As System.String)
                _出勤時間16 = value
            End Set
        End Property

        Private _出勤班別17 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別17() As System.String
            Get
                Return _出勤班別17
            End Get
            Set(ByVal value As System.String)
                _出勤班別17 = value
            End Set
        End Property

        Private _出勤時間17 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間17() As System.String
            Get
                Return _出勤時間17
            End Get
            Set(ByVal value As System.String)
                _出勤時間17 = value
            End Set
        End Property

        Private _出勤班別18 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別18() As System.String
            Get
                Return _出勤班別18
            End Get
            Set(ByVal value As System.String)
                _出勤班別18 = value
            End Set
        End Property

        Private _出勤時間18 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間18() As System.String
            Get
                Return _出勤時間18
            End Get
            Set(ByVal value As System.String)
                _出勤時間18 = value
            End Set
        End Property

        Private _出勤班別19 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別19() As System.String
            Get
                Return _出勤班別19
            End Get
            Set(ByVal value As System.String)
                _出勤班別19 = value
            End Set
        End Property

        Private _出勤時間19 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間19() As System.String
            Get
                Return _出勤時間19
            End Get
            Set(ByVal value As System.String)
                _出勤時間19 = value
            End Set
        End Property

        Private _出勤班別20 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別20() As System.String
            Get
                Return _出勤班別20
            End Get
            Set(ByVal value As System.String)
                _出勤班別20 = value
            End Set
        End Property

        Private _出勤時間20 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間20() As System.String
            Get
                Return _出勤時間20
            End Get
            Set(ByVal value As System.String)
                _出勤時間20 = value
            End Set
        End Property

        Private _出勤班別21 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別21() As System.String
            Get
                Return _出勤班別21
            End Get
            Set(ByVal value As System.String)
                _出勤班別21 = value
            End Set
        End Property

        Private _出勤時間21 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間21() As System.String
            Get
                Return _出勤時間21
            End Get
            Set(ByVal value As System.String)
                _出勤時間21 = value
            End Set
        End Property

        Private _出勤班別22 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別22() As System.String
            Get
                Return _出勤班別22
            End Get
            Set(ByVal value As System.String)
                _出勤班別22 = value
            End Set
        End Property

        Private _出勤時間22 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間22() As System.String
            Get
                Return _出勤時間22
            End Get
            Set(ByVal value As System.String)
                _出勤時間22 = value
            End Set
        End Property

        Private _出勤班別23 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別23() As System.String
            Get
                Return _出勤班別23
            End Get
            Set(ByVal value As System.String)
                _出勤班別23 = value
            End Set
        End Property

        Private _出勤時間23 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間23() As System.String
            Get
                Return _出勤時間23
            End Get
            Set(ByVal value As System.String)
                _出勤時間23 = value
            End Set
        End Property

        Private _出勤班別24 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別24() As System.String
            Get
                Return _出勤班別24
            End Get
            Set(ByVal value As System.String)
                _出勤班別24 = value
            End Set
        End Property

        Private _出勤時間24 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間24() As System.String
            Get
                Return _出勤時間24
            End Get
            Set(ByVal value As System.String)
                _出勤時間24 = value
            End Set
        End Property

        Private _出勤班別25 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別25() As System.String
            Get
                Return _出勤班別25
            End Get
            Set(ByVal value As System.String)
                _出勤班別25 = value
            End Set
        End Property

        Private _出勤時間25 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間25() As System.String
            Get
                Return _出勤時間25
            End Get
            Set(ByVal value As System.String)
                _出勤時間25 = value
            End Set
        End Property

        Private _出勤班別26 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別26() As System.String
            Get
                Return _出勤班別26
            End Get
            Set(ByVal value As System.String)
                _出勤班別26 = value
            End Set
        End Property

        Private _出勤時間26 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間26() As System.String
            Get
                Return _出勤時間26
            End Get
            Set(ByVal value As System.String)
                _出勤時間26 = value
            End Set
        End Property

        Private _出勤班別27 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別27() As System.String
            Get
                Return _出勤班別27
            End Get
            Set(ByVal value As System.String)
                _出勤班別27 = value
            End Set
        End Property

        Private _出勤時間27 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間27() As System.String
            Get
                Return _出勤時間27
            End Get
            Set(ByVal value As System.String)
                _出勤時間27 = value
            End Set
        End Property

        Private _出勤班別28 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別28() As System.String
            Get
                Return _出勤班別28
            End Get
            Set(ByVal value As System.String)
                _出勤班別28 = value
            End Set
        End Property

        Private _出勤時間28 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間28() As System.String
            Get
                Return _出勤時間28
            End Get
            Set(ByVal value As System.String)
                _出勤時間28 = value
            End Set
        End Property

        Private _出勤班別29 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別29() As System.String
            Get
                Return _出勤班別29
            End Get
            Set(ByVal value As System.String)
                _出勤班別29 = value
            End Set
        End Property

        Private _出勤時間29 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間29() As System.String
            Get
                Return _出勤時間29
            End Get
            Set(ByVal value As System.String)
                _出勤時間29 = value
            End Set
        End Property


        Private _出勤班別30 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別30() As System.String
            Get
                Return _出勤班別30
            End Get
            Set(ByVal value As System.String)
                _出勤班別30 = value
            End Set
        End Property

        Private _出勤時間30 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間30() As System.String
            Get
                Return _出勤時間30
            End Get
            Set(ByVal value As System.String)
                _出勤時間30 = value
            End Set
        End Property

        Private _出勤班別31 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤班別31() As System.String
            Get
                Return _出勤班別31
            End Get
            Set(ByVal value As System.String)
                _出勤班別31 = value
            End Set
        End Property

        Private _出勤時間31 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 出勤時間31() As System.String
            Get
                Return _出勤時間31
            End Get
            Set(ByVal value As System.String)
                _出勤時間31 = value
            End Set
        End Property











#End Region



#Region "上個月訂餐紀錄"
        Public Sub getFodM01PF_LastMonth()
            Dim as400DateConverter As New CompanyORMDB.AS400DateConverter

            Dim queryDate As Date = DateAdd(DateInterval.Month, -1, _
                                                                                as400DateConverter.StringToDate(Me.FDTYM.ToString & "01"))
            as400DateConverter.DateValue = queryDate

            Dim queryEEEMM As Integer = as400DateConverter.TwIntegerTypeData
            queryEEEMM = queryEEEMM / 100

            Dim SQL As New System.Text.StringBuilder
            SQL.Append("SELECT * " & vbNewLine)
            SQL.Append("FROM @#" & Me.CDBLibraryName & "." & Me.CDBFileName & (IIf(Me.CDBMemberName = "", "", "." & Me.CDBMemberName) & " " & vbNewLine))
            SQL.Append("WHERE 1=1 " & vbNewLine)
            SQL.Append("   AND fd001='" & Me.FD001 & "' " & vbNewLine)
            SQL.Append("   AND fdtym=" & queryEEEMM & vbNewLine)

            Dim query01PF As List(Of FOD100LB.FODM01PF) = FOD100LB.FODM01PF.CDBSelect(Of FOD100LB.FODM01PF)(SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

            If query01PF.Count = 0 Then
                上個月訂購餐別 = ""
                Exit Sub
            End If




            Dim FoodList As String

            Dim eachItem As FOD100LB.FODM01PF = query01PF(0)
            FoodList = ""
            FoodList &= eachItem.FD01A & eachItem.FD02A & eachItem.FD03A & eachItem.FD04A & eachItem.FD05A & eachItem.FD06A & eachItem.FD07A & eachItem.FD08A & eachItem.FD09A & eachItem.FD10A
            FoodList &= eachItem.FD11A & eachItem.FD12A & eachItem.FD13A & eachItem.FD14A & eachItem.FD15A & eachItem.FD16A & eachItem.FD17A & eachItem.FD18A & eachItem.FD19A & eachItem.FD20A
            FoodList &= eachItem.FD21A & eachItem.FD22A & eachItem.FD23A & eachItem.FD24A & eachItem.FD25A & eachItem.FD26A & eachItem.FD27A & eachItem.FD28A & eachItem.FD29A & eachItem.FD30A
            FoodList &= eachItem.FD31A

            FoodList &= eachItem.FD01B & eachItem.FD02B & eachItem.FD03B & eachItem.FD04B & eachItem.FD05B & eachItem.FD06B & eachItem.FD07B & eachItem.FD08B & eachItem.FD09B & eachItem.FD10B
            FoodList &= eachItem.FD11B & eachItem.FD12B & eachItem.FD13B & eachItem.FD14B & eachItem.FD15B & eachItem.FD16B & eachItem.FD17B & eachItem.FD18B & eachItem.FD19B & eachItem.FD20B
            FoodList &= eachItem.FD21B & eachItem.FD22B & eachItem.FD23B & eachItem.FD24B & eachItem.FD25B & eachItem.FD26B & eachItem.FD27B & eachItem.FD28B & eachItem.FD29B & eachItem.FD30B
            FoodList &= eachItem.FD31B

            FoodList &= eachItem.FD01C & eachItem.FD02C & eachItem.FD03C & eachItem.FD04C & eachItem.FD05C & eachItem.FD06C & eachItem.FD07C & eachItem.FD08C & eachItem.FD09C & eachItem.FD10C
            FoodList &= eachItem.FD11C & eachItem.FD12C & eachItem.FD13C & eachItem.FD14C & eachItem.FD15C & eachItem.FD16C & eachItem.FD17C & eachItem.FD18C & eachItem.FD19C & eachItem.FD20C
            FoodList &= eachItem.FD21C & eachItem.FD22C & eachItem.FD23C & eachItem.FD24C & eachItem.FD25C & eachItem.FD26C & eachItem.FD27C & eachItem.FD28C & eachItem.FD29C & eachItem.FD30C
            FoodList &= eachItem.FD31C

            FoodList = FoodList.Replace(Space(1), "")
            If FoodList = "" Then
                上個月訂購餐別 = ""
                Exit Sub
            End If


            Dim W_NowChar As String
            Dim W_NowCnt As Integer
            Dim AddItem1 As String = "", AddItem2 As String = ""
            Dim RegexObj As New Text.RegularExpressions.Regex("")

            For II = 1 To 6
                W_NowChar = Chr(64 + II)
                RegexObj = New Text.RegularExpressions.Regex(W_NowChar)
                W_NowCnt = RegexObj.Matches(FoodList).Count

                If W_NowCnt > 0 Then
                    AddItem2 &= IIf(AddItem2 = "", "", Space(2))
                    AddItem2 &= W_NowChar & ":" & W_NowCnt
                End If

            Next II


            AddItem1 = eachItem.FD001
            AddItem1 &= "," & eachItem.FDTYM

            上個月訂購餐別 = AddItem1 & "," & AddItem2
        End Sub

        Private _上個月訂購餐別 As System.String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property 上個月訂購餐別() As System.String
            Get
                getFodM01PF_LastMonth()
                Return _上個月訂購餐別
            End Get
            Set(ByVal value As System.String)
                _上個月訂購餐別 = value
            End Set
        End Property
#End Region


End Class
End Namespace