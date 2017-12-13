Namespace SGA600LB
Public Class SGAU10PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SGA600LB", GetType(SGAU10PF).Name)
	End Sub

#Region "申報年月 屬性:U1000"
	Private _U1000 As System.String
	''' <summary>
	''' 申報年月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property U1000 () As System.String
		Get
			Return _U1000
		End Get
		Set(Byval value as System.String)
			_U1000 = value
		End Set
	End Property
#End Region
#Region "格式代號 屬性:U1001"
	Private _U1001 As System.String
	''' <summary>
	''' 格式代號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property U1001 () As System.String
		Get
			Return _U1001
		End Get
		Set(Byval value as System.String)
			_U1001 = value
		End Set
	End Property
#End Region
#Region "申報營業人稅籍編號 屬性:U1002"
	Private _U1002 As System.String
	''' <summary>
	''' 申報營業人稅籍編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1002 () As System.String
		Get
			Return _U1002
		End Get
		Set(Byval value as System.String)
			_U1002 = value
		End Set
	End Property
#End Region
#Region "流水號 屬性:U1003"
	Private _U1003 As System.Int32
	''' <summary>
	''' 流水號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1003 () As System.Int32
		Get
			Return _U1003
		End Get
		Set(Byval value as System.Int32)
			_U1003 = value
		End Set
	End Property
#End Region
#Region "資料所屬年月 屬性:U1004"
	Private _U1004 As System.String
	''' <summary>
	''' 資料所屬年月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1004 () As System.String
		Get
			Return _U1004
		End Get
		Set(Byval value as System.String)
			_U1004 = value
		End Set
	End Property
#End Region
#Region "買受人統編發票訖號 屬性:U1005"
	Private _U1005 As System.String
	''' <summary>
	''' 買受人統編發票訖號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1005 () As System.String
		Get
			Return _U1005
		End Get
		Set(Byval value as System.String)
			_U1005 = value
		End Set
	End Property
#End Region
#Region "銷售人統一編號 屬性:U1006"
	Private _U1006 As System.String
	''' <summary>
	''' 銷售人統一編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1006 () As System.String
		Get
			Return _U1006
		End Get
		Set(Byval value as System.String)
			_U1006 = value
		End Set
	End Property
#End Region
#Region "發票字軌 屬性:U1007"
	Private _U1007 As System.String
	''' <summary>
	''' 發票字軌
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property U1007 () As System.String
		Get
			Return _U1007
		End Get
		Set(Byval value as System.String)
			_U1007 = value
		End Set
	End Property
#End Region
#Region "發票起號 屬性:U1008"
	Private _U1008 As System.String
	''' <summary>
	''' 發票起號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property U1008 () As System.String
		Get
			Return _U1008
		End Get
		Set(Byval value as System.String)
			_U1008 = value
		End Set
	End Property
#End Region
#Region "銷售金額 屬性:U1009"
	Private _U1009 As System.Int32
	''' <summary>
	''' 銷售金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1009 () As System.Int32
		Get
			Return _U1009
		End Get
		Set(Byval value as System.Int32)
			_U1009 = value
		End Set
	End Property
#End Region
#Region "課稅別 屬性:U1010"
	Private _U1010 As System.String
	''' <summary>
	''' 課稅別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1010 () As System.String
		Get
			Return _U1010
		End Get
		Set(Byval value as System.String)
			_U1010 = value
		End Set
	End Property
#End Region
#Region "營業稅額 屬性:U1011"
	Private _U1011 As System.Int32
	''' <summary>
	''' 營業稅額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1011 () As System.Int32
		Get
			Return _U1011
		End Get
		Set(Byval value as System.Int32)
			_U1011 = value
		End Set
	End Property
#End Region
#Region "扣抵代號 屬性:U1012"
	Private _U1012 As System.String
	''' <summary>
	''' 扣抵代號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1012 () As System.String
		Get
			Return _U1012
		End Get
		Set(Byval value as System.String)
			_U1012 = value
		End Set
	End Property
#End Region
#Region "空白 屬性:U1013"
	Private _U1013 As System.String
	''' <summary>
	''' 空白
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1013 () As System.String
		Get
			Return _U1013
		End Get
		Set(Byval value as System.String)
			_U1013 = value
		End Set
	End Property
#End Region
#Region "彙加註記 屬性:U1014"
	Private _U1014 As System.String
	''' <summary>
	''' 彙加註記
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1014 () As System.String
		Get
			Return _U1014
		End Get
		Set(Byval value as System.String)
			_U1014 = value
		End Set
	End Property
#End Region
#Region "洋菸酒註記 屬性:U1015"
	Private _U1015 As System.String
	''' <summary>
	''' 洋菸酒註記
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property U1015 () As System.String
		Get
			Return _U1015
		End Get
		Set(Byval value as System.String)
			_U1015 = value
		End Set
	End Property
#End Region
#Region "序 屬性:U1091"
	Private _U1091 As System.String
	''' <summary>
	''' 序
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property U1091 () As System.String
		Get
			Return _U1091
		End Get
		Set(Byval value as System.String)
			_U1091 = value
		End Set
	End Property
#End Region
End Class
End Namespace