Namespace AST500LB
    Public Class AST201PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("AST500LB", GetType(AST201PF).Name)
        End Sub


#Region "CODE 屬性:CODE"
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
#Region "FIXED 屬性:NUMBER"
        Private _NUMBER As System.String
        ''' <summary>
        ''' FIXED
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <CompanyORMDB.ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property NUMBER() As System.String
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As System.String)
                _NUMBER = value
            End Set
        End Property
#End Region
#Region "FIXED 屬性:NAME"
        Private _NAME As System.String
        ''' <summary>
        ''' FIXED
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
#Region "AMOUNT 屬性:AMOUNT"
        Private _AMOUNT As System.Single
        ''' <summary>
        ''' AMOUNT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AMOUNT() As System.Single
            Get
                Return _AMOUNT
            End Get
            Set(ByVal value As System.Single)
                _AMOUNT = value
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
#Region "DEPARTMENT 屬性:DEPT"
        Private _DEPT As System.String
        ''' <summary>
        ''' DEPARTMENT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <CompanyORMDB.ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DEPT() As System.String
            Get
                Return _DEPT
            End Get
            Set(ByVal value As System.String)
                _DEPT = value
            End Set
        End Property
#End Region
#Region "DISCOUNT 屬性:DEPR"
        Private _DEPR As System.Single
        ''' <summary>
        ''' DISCOUNT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPR() As System.Single
            Get
                Return _DEPR
            End Get
            Set(ByVal value As System.Single)
                _DEPR = value
            End Set
        End Property
#End Region
#Region "REESTIMATE 屬性:AMT"
        Private _AMT As System.Single
        ''' <summary>
        ''' REESTIMATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AMT() As System.Single
            Get
                Return _AMT
            End Get
            Set(ByVal value As System.Single)
                _AMT = value
            End Set
        End Property
#End Region
#Region "BMT(無使用) 屬性:BMT"
        Private _BMT As System.Single
        ''' <summary>
        ''' (無使用)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BMT() As System.Single
            Get
                Return _BMT
            End Get
            Set(ByVal value As System.Single)
                _BMT = value
            End Set
        End Property
#End Region
#Region "CMT(無使用) 屬性:CMT"
        Private _CMT As System.Single
        ''' <summary>
        ''' (無使用)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CMT() As System.Single
            Get
                Return _CMT
            End Get
            Set(ByVal value As System.Single)
                _CMT = value
            End Set
        End Property
#End Region
#Region "CDT(無使用) 屬性:CDT"
        Private _CDT As System.String
        ''' <summary>
        ''' (無使用)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CDT() As System.String
            Get
                Return _CDT
            End Get
            Set(ByVal value As System.String)
                _CDT = value
            End Set
        End Property
#End Region
#Region "ACD1(未知待查) 屬性:ACD1"
        Private _ACD1 As System.String
        ''' <summary>
        ''' (未知待查)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACD1() As System.String
            Get
                Return _ACD1
            End Get
            Set(ByVal value As System.String)
                _ACD1 = value
            End Set
        End Property
#End Region
#Region "ACD2 屬性:ACD2"
        Private _ACD2 As System.String
        ''' <summary>
        ''' ' ':正常 'A':閒置 'B':出租
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACD2() As System.String
            Get
                Return _ACD2
            End Get
            Set(ByVal value As System.String)
                _ACD2 = value
            End Set
        End Property
#End Region
#Region "ACD3 屬性:ACD3"
        Private _ACD3 As System.String
        ''' <summary>
        ''' '-':累計減損不提折舊
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACD3() As System.String
            Get
                Return _ACD3
            End Get
            Set(ByVal value As System.String)
                _ACD3 = value
            End Set
        End Property
#End Region
#Region "殘值金額 屬性:V7611"
        Private _V7611 As System.Single
        ''' <summary>
        ''' 殘值金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property V7611() As System.Single
            Get
                Return _V7611
            End Get
            Set(ByVal value As System.Single)
                _V7611 = value
            End Set
        End Property
#End Region
#Region "殘值重估使用年限 屬性:N7611"
        Private _N7611 As System.Int32
        ''' <summary>
        ''' 殘值重估使用年限
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property N7611() As System.Int32
            Get
                Return _N7611
            End Get
            Set(ByVal value As System.Int32)
                _N7611 = value
            End Set
        End Property
#End Region


    End Class
End Namespace