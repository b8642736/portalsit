Namespace CASH

    Public Class CashA1PF
        Inherits ClassDB
        Dim AS400DC As New PublicClassLibrary.AS400DateConverter

        Sub New()
            MyBase.New("CASH", GetType(CashA1PF).Name)
        End Sub

#Region "銀行代碼 屬性:BANKN1"

        Private _BANKN1 As String
        ''' <summary>
        ''' 銀行代碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
      Public Property BANKN1() As String
            Get
                Return _BANKN1
            End Get
            Set(ByVal value As String)
                _BANKN1 = value
            End Set
        End Property

#End Region
#Region "銀行名稱 屬性:BANKNM"

        Private _BANKNM As String
        ''' <summary>
        ''' 銀行名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKNM() As String
            Get
                Return _BANKNM
            End Get
            Set(ByVal value As String)
                _BANKNM = value
            End Set
        End Property

#End Region
#Region "綜合總額度 屬性:G10010"

        Private _G10010 As Double
        ''' <summary>
        ''' 綜合總額度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G10010() As Double
            Get
                Return _G10010
            End Get
            Set(ByVal value As Double)
                _G10010 = value
            End Set
        End Property

#End Region
#Region "綜合契約到期日 屬性:G10030"

        Private _G10030 As String
        ''' <summary>
        ''' 綜合契約到期日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G10030() As String
            Get
                Return _G10030
            End Get
            Set(ByVal value As String)
                _G10030 = value
            End Set
        End Property

#End Region
#Region "短期借款 屬性:G20010"

        Private _G20010 As Double
        ''' <summary>
        ''' 短期借款
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G20010() As Double
            Get
                Return _G20010
            End Get
            Set(ByVal value As Double)
                _G20010 = value
            End Set
        End Property

#End Region
#Region "外幣額度 屬性:G30010"

        Private _G30010 As Double
        ''' <summary>
        ''' 外幣額度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G30010() As Double
            Get
                Return _G30010
            End Get
            Set(ByVal value As Double)
                _G30010 = value
            End Set
        End Property

#End Region
#Region "現欠 屬性:G30020"

        Private _G30020 As Double
        ''' <summary>
        ''' 現欠
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G30020() As Double
            Get
                Return _G30020
            End Get
            Set(ByVal value As Double)
                _G30020 = value
            End Set
        End Property

#End Region
#Region "保證額度 屬性:G40010"

        Private _G40010 As Double
        ''' <summary>
        ''' 保證額度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G40010() As Double
            Get
                Return _G40010
            End Get
            Set(ByVal value As Double)
                _G40010 = value
            End Set
        End Property

#End Region
#Region "中長期額度 屬性:G50010"

        Private _G50010 As Double
        ''' <summary>
        ''' 中長期額度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G50010() As Double
            Get
                Return _G50010
            End Get
            Set(ByVal value As Double)
                _G50010 = value
            End Set
        End Property

#End Region
#Region "中長期契約到期日 屬性:G50030"

        Private _G50030 As String
        ''' <summary>
        ''' 中長期契約到期日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G50030() As String
            Get
                Return _G50030
            End Get
            Set(ByVal value As String)
                _G50030 = value
            End Set
        End Property

#End Region
#Region "中期攤還 屬性:G60010"

        Private _G60010 As Double
        ''' <summary>
        ''' 中期攤還
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G60010() As Double
            Get
                Return _G60010
            End Get
            Set(ByVal value As Double)
                _G60010 = value
            End Set
        End Property

#End Region
#Region "中期循環 屬性:G70010"

        Private _G70010 As Double
        ''' <summary>
        ''' 中期循環
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G70010() As Double
            Get
                Return _G70010
            End Get
            Set(ByVal value As Double)
                _G70010 = value
            End Set
        End Property

#End Region
#Region "商業本票額度 屬性:G80010"

        Private _G80010 As Double
        ''' <summary>
        ''' 商業本票額度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G80010() As Double
            Get
                Return _G80010
            End Get
            Set(ByVal value As Double)
                _G80010 = value
            End Set
        End Property

#End Region


#Region "綜合契約到期日_日期格式 屬性:G10030_DFormat"
        ''' <summary>
        ''' 綜合契約到期日_日期格式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property G10030_DFormat() As DateTime
            Get
                Return AS400DC.StringToDate(G10030)
            End Get
            Set(ByVal value As DateTime)
                AS400DC.DateValue = value
                G10030 = AS400DC.TwSevenCharsTypeData
            End Set
        End Property
#End Region
#Region "中長期契約到期日_日期格式 屬性:G50030_DFormat"
        ''' <summary>
        ''' 中長期契約到期日_日期格式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property G50030_DFormat() As DateTime
            Get
                Return AS400DC.StringToDate(G50030)
            End Get
            Set(ByVal value As DateTime)
                AS400DC.DateValue = value
                G50030 = AS400DC.TwSevenCharsTypeData

            End Set
        End Property
#End Region

        '#Region "總現欠 屬性:G10020_EX"
        '        ''' <summary>
        '        ''' 總現欠
        '        ''' </summary>
        '        ''' <value></value>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        '        ReadOnly Property G10020_EX() As Double
        '            Get
        '                 CompanyAS400DB.DEBY.DEBY03PF.FindBankDeby(Me.BANKN1,
        '            End Get
        '        End Property
        '#End Region


    End Class
End Namespace
