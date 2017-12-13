Namespace MTS600LB
Public Class MTSV01PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("MTS600LB", GetType(MTSV01PF).Name)
	End Sub

#Region "統一編號 屬性:MTSV01"
	Private _MTSV01 As System.String
	''' <summary>
	''' 統一編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property MTSV01 () As System.String
		Get
			Return _MTSV01
		End Get
		Set(Byval value as System.String)
			_MTSV01 = value
		End Set
	End Property
#End Region
#Region "公司全名１ 屬性:MTSV02"
	Private _MTSV02 As System.String
	''' <summary>
	''' 公司全名１
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV02 () As System.String
		Get
			Return _MTSV02
		End Get
		Set(Byval value as System.String)
			_MTSV02 = value
		End Set
	End Property
#End Region
#Region "公司全名２ 屬性:MTSV03"
	Private _MTSV03 As System.String
	''' <summary>
	''' 公司全名２
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV03 () As System.String
		Get
			Return _MTSV03
		End Get
		Set(Byval value as System.String)
			_MTSV03 = value
		End Set
	End Property
#End Region
#Region "公司簡寫 屬性:MTSV04"
	Private _MTSV04 As System.String
	''' <summary>
	''' 公司簡寫
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV04 () As System.String
		Get
			Return _MTSV04
		End Get
		Set(Byval value as System.String)
			_MTSV04 = value
		End Set
	End Property
#End Region
#Region "負責人 屬性:MTSV05"
	Private _MTSV05 As System.String
	''' <summary>
	''' 負責人
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV05 () As System.String
		Get
			Return _MTSV05
		End Get
		Set(Byval value as System.String)
			_MTSV05 = value
		End Set
	End Property
#End Region
#Region "筆劃 屬性:MTSV06"
	Private _MTSV06 As System.Int32
	''' <summary>
	''' 筆劃
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV06 () As System.Int32
		Get
			Return _MTSV06
		End Get
		Set(Byval value as System.Int32)
			_MTSV06 = value
		End Set
	End Property
#End Region
#Region "電話號碼 屬性:MTSV07"
	Private _MTSV07 As System.String
	''' <summary>
	''' 電話號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV07 () As System.String
		Get
			Return _MTSV07
		End Get
		Set(Byval value as System.String)
			_MTSV07 = value
		End Set
	End Property
#End Region
#Region "電報號碼 屬性:MTSV08"
	Private _MTSV08 As System.String
	''' <summary>
	''' 電報號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV08 () As System.String
		Get
			Return _MTSV08
		End Get
		Set(Byval value as System.String)
			_MTSV08 = value
		End Set
	End Property
#End Region
#Region "傳真號碼 屬性:MTSV09"
	Private _MTSV09 As System.String
	''' <summary>
	''' 傳真號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV09 () As System.String
		Get
			Return _MTSV09
		End Get
		Set(Byval value as System.String)
			_MTSV09 = value
		End Set
	End Property
#End Region
#Region "地址１ 屬性:MTSV10"
	Private _MTSV10 As System.String
	''' <summary>
	''' 地址１
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV10 () As System.String
		Get
			Return _MTSV10
		End Get
		Set(Byval value as System.String)
			_MTSV10 = value
		End Set
	End Property
#End Region
#Region "地址２ 屬性:MTSV11"
	Private _MTSV11 As System.String
	''' <summary>
	''' 地址２
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV11 () As System.String
		Get
			Return _MTSV11
		End Get
		Set(Byval value as System.String)
			_MTSV11 = value
		End Set
	End Property
#End Region
#Region "營業項目 屬性:MTSV12"
	Private _MTSV12 As System.String
	''' <summary>
	''' 營業項目
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV12 () As System.String
		Get
			Return _MTSV12
		End Get
		Set(Byval value as System.String)
			_MTSV12 = value
		End Set
	End Property
#End Region
#Region "代理公司名稱 屬性:MTSV13"
	Private _MTSV13 As System.String
	''' <summary>
	''' 代理公司名稱
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV13 () As System.String
		Get
			Return _MTSV13
		End Get
		Set(Byval value as System.String)
			_MTSV13 = value
		End Set
	End Property
#End Region
#Region "評鑑等級 屬性:MTSV14"
	Private _MTSV14 As System.String
	''' <summary>
	''' 評鑑等級
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV14 () As System.String
		Get
			Return _MTSV14
		End Get
		Set(Byval value as System.String)
			_MTSV14 = value
		End Set
	End Property
#End Region
#Region "評鑑日期 屬性:MTSV15"
	Private _MTSV15 As System.Int32
	''' <summary>
	''' 評鑑日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV15 () As System.Int32
		Get
			Return _MTSV15
		End Get
		Set(Byval value as System.Int32)
			_MTSV15 = value
		End Set
	End Property
#End Region
#Region "不良記錄 屬性:MTSV16"
	Private _MTSV16 As System.String
	''' <summary>
	''' 不良記錄
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV16 () As System.String
		Get
			Return _MTSV16
		End Get
		Set(Byval value as System.String)
			_MTSV16 = value
		End Set
	End Property
#End Region
#Region "暫停來往起日 屬性:MTSV17"
	Private _MTSV17 As System.Int32
	''' <summary>
	''' 暫停來往起日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV17 () As System.Int32
		Get
			Return _MTSV17
		End Get
		Set(Byval value as System.Int32)
			_MTSV17 = value
		End Set
	End Property
#End Region
#Region "暫停來往訖日 屬性:MTSV18"
	Private _MTSV18 As System.Int32
	''' <summary>
	''' 暫停來往訖日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV18 () As System.Int32
		Get
			Return _MTSV18
		End Get
		Set(Byval value as System.Int32)
			_MTSV18 = value
		End Set
	End Property
#End Region
#Region "備註 屬性:MTSV19"
	Private _MTSV19 As System.String
	''' <summary>
	''' 備註
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV19 () As System.String
		Get
			Return _MTSV19
		End Get
		Set(Byval value as System.String)
			_MTSV19 = value
		End Set
	End Property
#End Region
#Region "碼１ 屬性:MTSV20"
	Private _MTSV20 As System.String
	''' <summary>
	''' 碼１
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV20 () As System.String
		Get
			Return _MTSV20
		End Get
		Set(Byval value as System.String)
			_MTSV20 = value
		End Set
	End Property
#End Region
#Region "資本額 屬性:MTSV21"
	Private _MTSV21 As System.Int32
	''' <summary>
	''' 資本額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV21 () As System.Int32
		Get
			Return _MTSV21
		End Get
		Set(Byval value as System.Int32)
			_MTSV21 = value
		End Set
	End Property
#End Region
#Region "資料建立者 屬性:MTSV22"
	Private _MTSV22 As System.String
	''' <summary>
	''' 資料建立者
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV22 () As System.String
		Get
			Return _MTSV22
		End Get
		Set(Byval value as System.String)
			_MTSV22 = value
		End Set
	End Property
#End Region
#Region "資料建立日 屬性:MTSV23"
	Private _MTSV23 As System.Int32
	''' <summary>
	''' 資料建立日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV23 () As System.Int32
		Get
			Return _MTSV23
		End Get
		Set(Byval value as System.Int32)
			_MTSV23 = value
		End Set
	End Property
#End Region
#Region "來往銀行 屬性:MTSV24"
	Private _MTSV24 As System.String
	''' <summary>
	''' 來往銀行
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV24 () As System.String
		Get
			Return _MTSV24
		End Get
		Set(Byval value as System.String)
			_MTSV24 = value
		End Set
	End Property
#End Region
#Region "銀行帳號 屬性:MTSV25"
	Private _MTSV25 As System.String
	''' <summary>
	''' 銀行帳號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV25 () As System.String
		Get
			Return _MTSV25
		End Get
		Set(Byval value as System.String)
			_MTSV25 = value
		End Set
	End Property
#End Region
#Region "連絡人 屬性:MTSV26"
	Private _MTSV26 As System.String
	''' <summary>
	''' 連絡人
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSV26 () As System.String
		Get
			Return _MTSV26
		End Get
		Set(Byval value as System.String)
			_MTSV26 = value
		End Set
	End Property
#End Region
End Class
End Namespace