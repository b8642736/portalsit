Namespace AST500LB
Public Class AST003PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("AST500LB", GetType(AST003PF).Name)
	End Sub

#Region " 屬性:CODE"
	Private _CODE As System.String
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CODE () As System.String
		Get
			Return _CODE
		End Get
		Set(Byval value as System.String)
			_CODE = value
		End Set
	End Property
#End Region
#Region " 屬性:NUMBER"
	Private _NUMBER As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property NUMBER () As System.Object
		Get
			Return _NUMBER
		End Get
		Set(Byval value as System.Object)
			_NUMBER = value
		End Set
	End Property
#End Region
#Region " 屬性:DEPT"
	Private _DEPT As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property DEPT () As System.Object
		Get
			Return _DEPT
		End Get
		Set(Byval value as System.Object)
			_DEPT = value
		End Set
	End Property
#End Region
#Region " 屬性:DATEC"
	Private _DATEC As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DATEC () As System.Object
		Get
			Return _DATEC
		End Get
		Set(Byval value as System.Object)
			_DATEC = value
		End Set
	End Property
#End Region
#Region " 屬性:DATE"
	Private _DATE As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property [DATE]() As System.Object
            Get
                Return _DATE
            End Get
            Set(ByVal value As System.Object)
                _DATE = value
            End Set
        End Property
#End Region
#Region " 屬性:UNIT"
	Private _UNIT As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property UNIT () As System.Object
		Get
			Return _UNIT
		End Get
		Set(Byval value as System.Object)
			_UNIT = value
		End Set
	End Property
#End Region
#Region " 屬性:QUANT"
	Private _QUANT As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QUANT () As System.Object
		Get
			Return _QUANT
		End Get
		Set(Byval value as System.Object)
			_QUANT = value
		End Set
	End Property
#End Region
#Region " 屬性:WHY"
	Private _WHY As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WHY () As System.Object
		Get
			Return _WHY
		End Get
		Set(Byval value as System.Object)
			_WHY = value
		End Set
	End Property
#End Region
#Region " 屬性:DEPR"
	Private _DEPR As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPR () As System.Object
		Get
			Return _DEPR
		End Get
		Set(Byval value as System.Object)
			_DEPR = value
		End Set
	End Property
#End Region
#Region " 屬性:DEPREB"
	Private _DEPREB As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DEPREB () As System.Object
		Get
			Return _DEPREB
		End Get
		Set(Byval value as System.Object)
			_DEPREB = value
		End Set
	End Property
#End Region
#Region " 屬性:USLAFF"
	Private _USLAFF As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property USLAFF () As System.Object
		Get
			Return _USLAFF
		End Get
		Set(Byval value as System.Object)
			_USLAFF = value
		End Set
	End Property
#End Region
#Region " 屬性:PRICE"
	Private _PRICE As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PRICE () As System.Object
		Get
			Return _PRICE
		End Get
		Set(Byval value as System.Object)
			_PRICE = value
		End Set
	End Property
#End Region
#Region " 屬性:TAMOUN"
	Private _TAMOUN As System.Object
	''' <summary>
	''' 
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property TAMOUN () As System.Object
		Get
			Return _TAMOUN
		End Get
		Set(Byval value as System.Object)
			_TAMOUN = value
		End Set
	End Property
#End Region
#Region "中文名稱 屬性:CNAME"
	Private _CNAME As System.String
	''' <summary>
	''' 中文名稱
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CNAME () As System.String
		Get
			Return _CNAME
		End Get
		Set(Byval value as System.String)
			_CNAME = value
		End Set
	End Property
#End Region
End Class
End Namespace