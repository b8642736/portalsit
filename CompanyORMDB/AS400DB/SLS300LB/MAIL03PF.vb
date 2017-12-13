Namespace SLS300LB
Public Class MAIL03PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(MAIL03PF).Name)
	End Sub

#Region "客戶 屬性:ML300"
	Private _ML300 As System.String
	''' <summary>
	''' 客戶
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ML300 () As System.String
		Get
			Return _ML300
		End Get
		Set(Byval value as System.String)
			_ML300 = value
		End Set
	End Property
#End Region
#Region "銀行 屬性:ML301"
	Private _ML301 As System.String
	''' <summary>
	''' 銀行
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ML301 () As System.String
		Get
			Return _ML301
		End Get
		Set(Byval value as System.String)
			_ML301 = value
		End Set
	End Property
#End Region
#Region "LC號碼 屬性:ML302"
	Private _ML302 As System.String
	''' <summary>
	''' LC號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML302 () As System.String
		Get
			Return _ML302
		End Get
		Set(Byval value as System.String)
			_ML302 = value
		End Set
	End Property
#End Region
#Region "收款金額 屬性:ML303"
	Private _ML303 As System.Int32
	''' <summary>
	''' 收款金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML303 () As System.Int32
		Get
			Return _ML303
		End Get
		Set(Byval value as System.Int32)
			_ML303 = value
		End Set
	End Property
#End Region
#Region "收款單 屬性:ML304"
	Private _ML304 As System.String
	''' <summary>
	''' 收款單
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ML304 () As System.String
		Get
			Return _ML304
		End Get
		Set(Byval value as System.String)
			_ML304 = value
		End Set
	End Property
#End Region
#Region "統一發票 屬性:ML305"
	Private _ML305 As System.String
	''' <summary>
	''' 統一發票
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ML305 () As System.String
		Get
			Return _ML305
		End Get
		Set(Byval value as System.String)
			_ML305 = value
		End Set
	End Property
#End Region
#Region "提貨單號 屬性:ML306"
	Private _ML306 As System.String
	''' <summary>
	''' 提貨單號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML306 () As System.String
		Get
			Return _ML306
		End Get
		Set(Byval value as System.String)
			_ML306 = value
		End Set
	End Property
#End Region
#Region "鋼捲編號 屬性:ML307"
	Private _ML307 As System.String
	''' <summary>
	''' 鋼捲編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML307 () As System.String
		Get
			Return _ML307
		End Get
		Set(Byval value as System.String)
			_ML307 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:ML308"
	Private _ML308 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML308 () As System.String
		Get
			Return _ML308
		End Get
		Set(Byval value as System.String)
			_ML308 = value
		End Set
	End Property
#End Region
#Region "表面 屬性:ML309"
	Private _ML309 As System.String
	''' <summary>
	''' 表面
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML309 () As System.String
		Get
			Return _ML309
		End Get
		Set(Byval value as System.String)
			_ML309 = value
		End Set
	End Property
#End Region
#Region "厚度 屬性:ML310"
	Private _ML310 As System.Single
	''' <summary>
	''' 厚度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML310 () As System.Single
		Get
			Return _ML310
		End Get
		Set(Byval value as System.Single)
			_ML310 = value
		End Set
	End Property
#End Region
#Region "寬度 屬性:ML311"
	Private _ML311 As System.Int32
	''' <summary>
	''' 寬度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML311 () As System.Int32
		Get
			Return _ML311
		End Get
		Set(Byval value as System.Int32)
			_ML311 = value
		End Set
	End Property
#End Region
#Region "等級 屬性:ML312"
	Private _ML312 As System.String
	''' <summary>
	''' 等級
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML312 () As System.String
		Get
			Return _ML312
		End Get
		Set(Byval value as System.String)
			_ML312 = value
		End Set
	End Property
#End Region
#Region "重量 屬性:ML313"
	Private _ML313 As System.Int32
	''' <summary>
	''' 重量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML313 () As System.Int32
		Get
			Return _ML313
		End Get
		Set(Byval value as System.Int32)
			_ML313 = value
		End Set
	End Property
#End Region
#Region "報價單號 屬性:ML314"
	Private _ML314 As System.String
	''' <summary>
	''' 報價單號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML314 () As System.String
		Get
			Return _ML314
		End Get
		Set(Byval value as System.String)
			_ML314 = value
		End Set
	End Property
#End Region
#Region "貨款 屬性:ML315"
	Private _ML315 As System.Int32
	''' <summary>
	''' 貨款
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML315 () As System.Int32
		Get
			Return _ML315
		End Get
		Set(Byval value as System.Int32)
			_ML315 = value
		End Set
	End Property
#End Region
#Region "利息 屬性:ML316"
	Private _ML316 As System.Int32
	''' <summary>
	''' 利息
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML316 () As System.Int32
		Get
			Return _ML316
		End Get
		Set(Byval value as System.Int32)
			_ML316 = value
		End Set
	End Property
#End Region
#Region "稅額 屬性:ML317"
	Private _ML317 As System.Int32
	''' <summary>
	''' 稅額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML317 () As System.Int32
		Get
			Return _ML317
		End Get
		Set(Byval value as System.Int32)
			_ML317 = value
		End Set
	End Property
#End Region
#Region "提貨日 屬性:ML318"
	Private _ML318 As System.String
	''' <summary>
	''' 提貨日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML318 () As System.String
		Get
			Return _ML318
		End Get
		Set(Byval value as System.String)
			_ML318 = value
		End Set
	End Property
#End Region
#Region "打單日 屬性:ML319"
	Private _ML319 As System.String
	''' <summary>
	''' 打單日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML319 () As System.String
		Get
			Return _ML319
		End Get
		Set(Byval value as System.String)
			_ML319 = value
		End Set
	End Property
#End Region
#Region "一級 屬性:ML320"
	Private _ML320 As System.Int32
	''' <summary>
	''' 一級
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML320 () As System.Int32
		Get
			Return _ML320
		End Get
		Set(Byval value as System.Int32)
			_ML320 = value
		End Set
	End Property
#End Region
#Region "二級 屬性:ML321"
	Private _ML321 As System.Int32
	''' <summary>
	''' 二級
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML321 () As System.Int32
		Get
			Return _ML321
		End Get
		Set(Byval value as System.Int32)
			_ML321 = value
		End Set
	End Property
#End Region
#Region "三級 屬性:ML322"
	Private _ML322 As System.Int32
	''' <summary>
	''' 三級
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML322 () As System.Int32
		Get
			Return _ML322
		End Get
		Set(Byval value as System.Int32)
			_ML322 = value
		End Set
	End Property
#End Region
#Region "頭尾 屬性:ML323"
	Private _ML323 As System.Int32
	''' <summary>
	''' 頭尾
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML323 () As System.Int32
		Get
			Return _ML323
		End Get
		Set(Byval value as System.Int32)
			_ML323 = value
		End Set
	End Property
#End Region
#Region "邊料 屬性:ML324"
	Private _ML324 As System.Int32
	''' <summary>
	''' 邊料
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML324 () As System.Int32
		Get
			Return _ML324
		End Get
		Set(Byval value as System.Int32)
			_ML324 = value
		End Set
	End Property
#End Region
#Region "廢料 屬性:ML325"
	Private _ML325 As System.Int32
	''' <summary>
	''' 廢料
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ML325 () As System.Int32
		Get
			Return _ML325
		End Get
		Set(Byval value as System.Int32)
			_ML325 = value
		End Set
	End Property
#End Region
#Region "一級品金額 屬性:BOL21"
	Private _BOL21 As System.Int32
	''' <summary>
	''' 一級品金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BOL21 () As System.Int32
		Get
			Return _BOL21
		End Get
		Set(Byval value as System.Int32)
			_BOL21 = value
		End Set
	End Property
#End Region
#Region "二級品金額 屬性:BOL22"
	Private _BOL22 As System.Int32
	''' <summary>
	''' 二級品金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BOL22 () As System.Int32
		Get
			Return _BOL22
		End Get
		Set(Byval value as System.Int32)
			_BOL22 = value
		End Set
	End Property
#End Region
#Region "三級品金額 屬性:BOL23"
	Private _BOL23 As System.Int32
	''' <summary>
	''' 三級品金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BOL23 () As System.Int32
		Get
			Return _BOL23
		End Get
		Set(Byval value as System.Int32)
			_BOL23 = value
		End Set
	End Property
#End Region
#Region "頭尾料金額 屬性:BOL24"
	Private _BOL24 As System.Int32
	''' <summary>
	''' 頭尾料金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BOL24 () As System.Int32
		Get
			Return _BOL24
		End Get
		Set(Byval value as System.Int32)
			_BOL24 = value
		End Set
	End Property
#End Region
#Region "邊緣料金額 屬性:BOL25"
	Private _BOL25 As System.Int32
	''' <summary>
	''' 邊緣料金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BOL25 () As System.Int32
		Get
			Return _BOL25
		End Get
		Set(Byval value as System.Int32)
			_BOL25 = value
		End Set
	End Property
#End Region
#Region "廢料金額 屬性:BOL26"
	Private _BOL26 As System.Int32
	''' <summary>
	''' 廢料金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BOL26 () As System.Int32
		Get
			Return _BOL26
		End Get
		Set(Byval value as System.Int32)
			_BOL26 = value
		End Set
	End Property
#End Region
End Class
End Namespace