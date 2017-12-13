Namespace SLS300LB
Public Class SL2PR2PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(SL2PR2PF).Name)
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
#Region "表面 屬性:PR201"
	Private _PR201 As System.String
	''' <summary>
	''' 表面
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property PR201 () As System.String
		Get
			Return _PR201
		End Get
		Set(Byval value as System.String)
			_PR201 = value
		End Set
	End Property
#End Region
#Region "附價 屬性:PR211"
	Private _PR211 As System.Single
	''' <summary>
	''' 附價
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PR211 () As System.Single
		Get
			Return _PR211
		End Get
		Set(Byval value as System.Single)
			_PR211 = value
		End Set
	End Property
#End Region
End Class
End Namespace