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
        Public Property CODE() As System.String
            Get
                Return _CODE
            End Get
            Set(ByVal value As System.String)
                _CODE = value
            End Set
        End Property
#End Region
#Region " 屬性:NUMBER"
        Private _NUMBER As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property NUMBER() As String
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As String)
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
        Public Property DEPT() As String
            Get
                Return _DEPT
            End Get
            Set(ByVal value As String)
                _DEPT = value
            End Set
        End Property
#End Region
#Region " 屬性:DATEC"
        Private _DATEC As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DATEC() As Integer
            Get
                Return _DATEC
            End Get
            Set(ByVal value As Integer)
                _DATEC = value
            End Set
        End Property
#End Region
#Region " 屬性:DATE"
        Private _DATE As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property [DATE]() As Integer
            Get
                Return _DATE
            End Get
            Set(ByVal value As Integer)
                _DATE = value
            End Set
        End Property
#End Region
#Region " 屬性:UNIT"
        Private _UNIT As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UNIT() As String
            Get
                Return _UNIT
            End Get
            Set(ByVal value As String)
                _UNIT = value
            End Set
        End Property
#End Region
#Region " 屬性:QUANT"
        Private _QUANT As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QUANT() As Integer
            Get
                Return _QUANT
            End Get
            Set(ByVal value As Integer)
                _QUANT = value
            End Set
        End Property
#End Region
#Region " 屬性:WHY"
        Private _WHY As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WHY() As String
            Get
                Return _WHY
            End Get
            Set(ByVal value As String)
                _WHY = value
            End Set
        End Property
#End Region
#Region " 屬性:DEPR"
        Private _DEPR As Double
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPR() As Double
            Get
                Return _DEPR
            End Get
            Set(ByVal value As Double)
                _DEPR = value
            End Set
        End Property
#End Region
#Region " 屬性:DEPREB"
        Private _DEPREB As Double
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPREB() As Double
            Get
                Return _DEPREB
            End Get
            Set(ByVal value As Double)
                _DEPREB = value
            End Set
        End Property
#End Region
#Region " 屬性:USLAFF"
        Private _USLAFF As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USLAFF() As Integer
            Get
                Return _USLAFF
            End Get
            Set(ByVal value As Integer)
                _USLAFF = value
            End Set
        End Property
#End Region
#Region " 屬性:PRICE"
        Private _PRICE As Double
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PRICE() As Double
            Get
                Return _PRICE
            End Get
            Set(ByVal value As Double)
                _PRICE = value
            End Set
        End Property
#End Region
#Region " 屬性:TAMOUN"
        Private _TAMOUN As Double
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TAMOUN() As Double
            Get
                Return _TAMOUN
            End Get
            Set(ByVal value As Double)
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
        Public Property CNAME() As System.String
            Get
                Return _CNAME
            End Get
            Set(ByVal value As System.String)
                _CNAME = value
            End Set
        End Property
#End Region
End Class
End Namespace