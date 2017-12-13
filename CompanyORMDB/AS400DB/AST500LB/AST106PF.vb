Namespace AST500LB
    Public Class AST106PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("AST500LB", GetType(AST106PF).Name)
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
#Region "序號 屬性:SEQ"
        Private _SEQ As System.Int32
        ''' <summary>
        ''' 序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SEQ() As System.Int32
            Get
                Return _SEQ
            End Get
            Set(ByVal value As System.Int32)
                _SEQ = value
            End Set
        End Property
#End Region
#Region "單位代號 屬性:DEPTSA"
        Private _DEPTSA As System.String
        ''' <summary>
        ''' 單位代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPTSA() As System.String
            Get
                Return _DEPTSA
            End Get
            Set(ByVal value As System.String)
                _DEPTSA = value
            End Set
        End Property
#End Region
#Region "入帳編號 屬性:PNO"
        Private _PNO As System.String
        ''' <summary>
        ''' 入帳編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PNO() As System.String
            Get
                Return _PNO
            End Get
            Set(ByVal value As System.String)
                _PNO = value
            End Set
        End Property
#End Region
#Region "規格1 屬性:SPEC1"
        Private _SPEC1 As System.String
        ''' <summary>
        ''' 規格1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SPEC1() As System.String
            Get
                Return _SPEC1
            End Get
            Set(ByVal value As System.String)
                _SPEC1 = value
            End Set
        End Property
#End Region
#Region "規格2 屬性:SPEC2"
        Private _SPEC2 As System.String
        ''' <summary>
        ''' 規格2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SPEC2() As System.String
            Get
                Return _SPEC2
            End Get
            Set(ByVal value As System.String)
                _SPEC2 = value
            End Set
        End Property
#End Region
#Region "供應廠商 屬性:MTSV01"
        Private _MTSV01 As System.String
        ''' <summary>
        ''' 供應廠商
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MTSV01() As System.String
            Get
                Return _MTSV01
            End Get
            Set(ByVal value As System.String)
                _MTSV01 = value
            End Set
        End Property
#End Region




    End Class
End Namespace