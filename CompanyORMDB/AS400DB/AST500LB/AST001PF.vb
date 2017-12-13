Namespace AST500LB
Public Class AST001PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("AST500LB", GetType(AST001PF).Name)
	End Sub

#Region "資產編號 屬性:NUMBER"
        Private _NUMBER As System.String
        ''' <summary>
        ''' 資產編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property NUMBER() As System.String
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As System.String)
                _NUMBER = value
            End Set
        End Property
#End Region
#Region "DEPARTMENT 屬性:DEPT"
        Private _DEPT As System.String
        ''' <summary>
        ''' DEPARTMENT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DEPT() As System.String
            Get
                Return _DEPT
            End Get
            Set(ByVal value As System.String)
                _DEPT = value
            End Set
        End Property
#End Region
#Region "增減代碼 屬性:CODE"
        Private _CODE As System.String
        ''' <summary>
        ''' 增減代碼
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
#Region "資產名稱 屬性:NAME"
        Private _NAME As System.String
        ''' <summary>
        ''' 資產名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NAME() As System.String
            Get
                Return _NAME
            End Get
            Set(ByVal value As System.String)
                _NAME = value
            End Set
        End Property
#End Region
#Region "UNIT 屬性:UNIT"
        Private _UNIT As System.String
        ''' <summary>
        ''' UNIT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UNIT() As System.String
            Get
                Return _UNIT
            End Get
            Set(ByVal value As System.String)
                _UNIT = value
            End Set
        End Property
#End Region
#Region "QUANTITY 屬性:QUANT"
        Private _QUANT As System.Int32
        ''' <summary>
        ''' QUANTITY
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QUANT() As System.Int32
            Get
                Return _QUANT
            End Get
            Set(ByVal value As System.Int32)
                _QUANT = value
            End Set
        End Property
#End Region
#Region "TAMOUN 屬性:TAMOUN"
        Private _TAMOUN As System.Double
        ''' <summary>
        ''' TAMOUNT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TAMOUN() As System.Double
            Get
                Return _TAMOUN
            End Get
            Set(ByVal value As System.Double)
                _TAMOUN = value
            End Set
        End Property
#End Region
#Region "購置年月 屬性:DATE"
        Private _DATE As System.Int32
        ''' <summary>
        ''' 購置年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property [DATE]() As System.Int32
            Get
                Return _DATE
            End Get
            Set(ByVal value As System.Int32)
                _DATE = value
            End Set
        End Property
#End Region
#Region "USE 屬性:USLAFF"
        Private _USLAFF As System.Int32
        ''' <summary>
        ''' USE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USLAFF() As System.Int32
            Get
                Return _USLAFF
            End Get
            Set(ByVal value As System.Int32)
                _USLAFF = value
            End Set
        End Property
#End Region
#Region "UNIT 屬性:PRICE"
        Private _PRICE As System.Single
        ''' <summary>
        ''' UNIT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PRICE() As System.Single
            Get
                Return _PRICE
            End Get
            Set(ByVal value As System.Single)
                _PRICE = value
            End Set
        End Property
#End Region
#Region "TOTAL 屬性:DEPREC"
        Private _DEPREC As System.Single
        ''' <summary>
        ''' TOTAL
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPREC() As System.Single
            Get
                Return _DEPREC
            End Get
            Set(ByVal value As System.Single)
                _DEPREC = value
            End Set
        End Property
#End Region
#Region "發生日期 屬性:DATEN"
        Private _DATEN As System.Int32
        ''' <summary>
        ''' 發生日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DATEN() As System.Int32
            Get
                Return _DATEN
            End Get
            Set(ByVal value As System.Int32)
                _DATEN = value
            End Set
        End Property
#End Region

End Class
End Namespace