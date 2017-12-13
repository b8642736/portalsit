Namespace SLS300LB
Public Class SL3X04PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(SL3X04PF).Name)
	End Sub

#Region "提貨單 屬性:SX400"
	Private _SX400 As System.String
	''' <summary>
	''' 提貨單
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SX400 () As System.String
		Get
			Return _SX400
		End Get
		Set(Byval value as System.String)
			_SX400 = value
		End Set
	End Property
#End Region
#Region "鋼捲 屬性:SX401"
	Private _SX401 As System.String
	''' <summary>
	''' 鋼捲
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SX401 () As System.String
		Get
			Return _SX401
		End Get
		Set(Byval value as System.String)
			_SX401 = value
		End Set
	End Property
#End Region
#Region "斷捲 屬性:SX402"
	Private _SX402 As System.String
	''' <summary>
	''' 斷捲
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SX402 () As System.String
		Get
			Return _SX402
		End Get
		Set(Byval value as System.String)
			_SX402 = value
		End Set
	End Property
#End Region
#Region "原因碼 屬性:SX403"
	Private _SX403 As System.String
	''' <summary>
	''' 原因碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SX403 () As System.String
		Get
			Return _SX403
		End Get
		Set(Byval value as System.String)
			_SX403 = value
		End Set
	End Property
#End Region
#Region "結退額 屬性:SX404"
	Private _SX404 As System.Int32
	''' <summary>
	''' 結退額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SX404 () As System.Int32
		Get
			Return _SX404
		End Get
		Set(Byval value as System.Int32)
			_SX404 = value
		End Set
	End Property
#End Region
#Region "日期 屬性:SX405"
	Private _SX405 As System.String
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SX405 () As System.String
		Get
			Return _SX405
		End Get
		Set(Byval value as System.String)
			_SX405 = value
		End Set
	End Property
#End Region
#Region "折扣率 屬性:SX406"
	Private _SX406 As System.Single
	''' <summary>
	''' 折扣率
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SX406 () As System.Single
		Get
			Return _SX406
		End Get
		Set(Byval value as System.Single)
			_SX406 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:SX491"
	Private _SX491 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SX491 () As System.String
		Get
			Return _SX491
		End Get
		Set(Byval value as System.String)
			_SX491 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:SX492"
	Private _SX492 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SX492 () As System.String
		Get
			Return _SX492
		End Get
		Set(Byval value as System.String)
			_SX492 = value
		End Set
	End Property
#End Region

        '#Region "結退額台幣 屬性:BackTWMoney"
        '        ''' <summary>
        '        ''' 結退額台幣
        '        ''' </summary>
        '        ''' <value></value>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        '        ReadOnly Property BackTWMoney As Double
        '            Get

        '                Return SX404
        '            End Get
        '        End Property

        '#End Region

End Class
End Namespace