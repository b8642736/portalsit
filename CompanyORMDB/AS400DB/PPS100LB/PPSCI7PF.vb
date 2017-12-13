Namespace PPS100LB
Public Class PPSCI7PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PPS100LB", GetType(PPSCI7PF).Name)
	End Sub

#Region "年月 屬性:CI700"
	Private _CI700 As System.String
	''' <summary>
	''' 年月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CI700 () As System.String
		Get
			Return _CI700
		End Get
		Set(Byval value as System.String)
			_CI700 = value
		End Set
	End Property
#End Region
#Region "鋼種 屬性:CI701"
	Private _CI701 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CI701 () As System.String
		Get
			Return _CI701
		End Get
		Set(Byval value as System.String)
			_CI701 = value
		End Set
	End Property
#End Region
#Region "TYPE 屬性:CI702"
	Private _CI702 As System.String
	''' <summary>
	''' TYPE
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CI702 () As System.String
		Get
			Return _CI702
		End Get
		Set(Byval value as System.String)
			_CI702 = value
		End Set
	End Property
#End Region
#Region "表面 屬性:CI703"
	Private _CI703 As System.String
	''' <summary>
	''' 表面
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CI703 () As System.String
		Get
			Return _CI703
		End Get
		Set(Byval value as System.String)
			_CI703 = value
		End Set
	End Property
#End Region
#Region "厚度 屬性:CI704"
	Private _CI704 As System.String
	''' <summary>
	''' 厚度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CI704 () As System.String
		Get
			Return _CI704
		End Get
		Set(Byval value as System.String)
			_CI704 = value
		End Set
	End Property
#End Region
#Region "銷售別 屬性:CI705"
	Private _CI705 As System.String
	''' <summary>
	''' 銷售別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CI705 () As System.String
		Get
			Return _CI705
		End Get
		Set(Byval value as System.String)
			_CI705 = value
		End Set
	End Property
#End Region
#Region "料別 屬性:CI706"
	Private _CI706 As System.String
	''' <summary>
	''' 料別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CI706 () As System.String
		Get
			Return _CI706
		End Get
		Set(Byval value as System.String)
			_CI706 = value
		End Set
	End Property
#End Region
#Region "繳庫量 屬性:CI711"
	Private _CI711 As System.Int32
	''' <summary>
	''' 繳庫量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CI711 () As System.Int32
		Get
			Return _CI711
		End Get
		Set(Byval value as System.Int32)
			_CI711 = value
		End Set
	End Property
#End Region
#Region "投入量 屬性:CI712"
	Private _CI712 As System.Int32
	''' <summary>
	''' 投入量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CI712 () As System.Int32
		Get
			Return _CI712
		End Get
		Set(Byval value as System.Int32)
			_CI712 = value
		End Set
	End Property
#End Region
#Region "一級品 屬性:CI713"
	Private _CI713 As System.Int32
	''' <summary>
	''' 一級品
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CI713 () As System.Int32
		Get
			Return _CI713
		End Get
		Set(Byval value as System.Int32)
			_CI713 = value
		End Set
	End Property
#End Region

End Class
End Namespace