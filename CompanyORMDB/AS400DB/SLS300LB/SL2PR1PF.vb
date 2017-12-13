Namespace SLS300LB
Public Class SL2PR1PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(SL2PR1PF).Name)
	End Sub

#Region "年月 屬性:PR001"
	Private _PR001 As System.String
	''' <summary>
	''' 年月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property PR001 () As System.String
		Get
			Return _PR001
		End Get
		Set(Byval value as System.String)
			_PR001 = value
		End Set
	End Property
#End Region
#Region "銷售別 屬性:PR002"
	Private _PR002 As System.String
	''' <summary>
	''' 銷售別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property PR002 () As System.String
		Get
			Return _PR002
		End Get
		Set(Byval value as System.String)
			_PR002 = value
		End Set
	End Property
#End Region
#Region "鋼種系 屬性:PR003"
	Private _PR003 As System.String
	''' <summary>
	''' 鋼種系
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property PR003 () As System.String
		Get
			Return _PR003
		End Get
		Set(Byval value as System.String)
			_PR003 = value
		End Set
	End Property
#End Region
#Region "CR/HR 屬性:PR004"
	Private _PR004 As System.String
	''' <summary>
	''' CR/HR
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property PR004 () As System.String
		Get
			Return _PR004
		End Get
		Set(Byval value as System.String)
			_PR004 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:PR101"
	Private _PR101 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property PR101 () As System.String
		Get
			Return _PR101
		End Get
		Set(Byval value as System.String)
			_PR101 = value
		End Set
	End Property
#End Region
#Region "TYPE 屬性:PR102"
	Private _PR102 As System.String
	''' <summary>
	''' TYPE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property PR102 () As System.String
		Get
			Return _PR102
		End Get
		Set(Byval value as System.String)
			_PR102 = value
		End Set
	End Property
#End Region
#Region "附價 屬性:PR111"
	Private _PR111 As System.Single
	''' <summary>
	''' 附價
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PR111 () As System.Single
		Get
			Return _PR111
		End Get
		Set(Byval value as System.Single)
			_PR111 = value
		End Set
	End Property
#End Region
#Region "低碳附價 屬性:PR112"
	Private _PR112 As System.Single
	''' <summary>
	''' 低碳附價
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PR112 () As System.Single
		Get
			Return _PR112
		End Get
		Set(Byval value as System.Single)
			_PR112 = value
		End Set
	End Property
#End Region
#Region "廢料差價 屬性:PR113"
	Private _PR113 As System.Single
	''' <summary>
	''' 廢料差價
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PR113 () As System.Single
		Get
			Return _PR113
		End Get
		Set(Byval value as System.Single)
			_PR113 = value
		End Set
	End Property
#End Region
#Region "二級折扣 屬性:PR121"
	Private _PR121 As System.Single
	''' <summary>
	''' 二級折扣
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PR121 () As System.Single
		Get
			Return _PR121
		End Get
		Set(Byval value as System.Single)
			_PR121 = value
		End Set
	End Property
#End Region
#Region "三級折扣 屬性:PR122"
	Private _PR122 As System.Single
	''' <summary>
	''' 三級折扣
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PR122 () As System.Single
		Get
			Return _PR122
		End Get
		Set(Byval value as System.Single)
			_PR122 = value
		End Set
	End Property
#End Region
#Region "非正常品打折 屬性:PR123"
	Private _PR123 As System.Single
	''' <summary>
	''' 非正常品打折
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PR123 () As System.Single
		Get
			Return _PR123
		End Get
		Set(Byval value as System.Single)
			_PR123 = value
		End Set
	End Property
#End Region
End Class
End Namespace