Namespace SLS300LB
    ''' <summary>
    ''' 收款資料檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2RCVPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2RCVPF).Name)
        End Sub

#Region "客戶代號 屬性:RCV01"
        Private _RCV01 As System.String
        ''' <summary>
        ''' 客戶代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV01() As System.String
            Get
                Return _RCV01
            End Get
            Set(ByVal value As System.String)
                _RCV01 = value
            End Set
        End Property
#End Region
#Region "收款單編號 屬性:RCV02"
        Private _RCV02 As System.String
        ''' <summary>
        ''' 收款單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property RCV02() As System.String
            Get
                Return _RCV02
            End Get
            Set(ByVal value As System.String)
                _RCV02 = value
            End Set
        End Property
#End Region
#Region "日期 屬性:RCV03"
        Private _RCV03 As System.String
        ''' <summary>
        ''' 日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV03() As System.String
            Get
                Return _RCV03
            End Get
            Set(ByVal value As System.String)
                _RCV03 = value
            End Set
        End Property
#End Region
#Region "面額 屬性:RCV04"
        Private _RCV04 As System.Single
        ''' <summary>
        ''' 面額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV04() As System.Single
            Get
                Return _RCV04
            End Get
            Set(ByVal value As System.Single)
                _RCV04 = value
            End Set
        End Property
#End Region
#Region "己用金額 屬性:RCV05"
        Private _RCV05 As System.Single
        ''' <summary>
        ''' 己用金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV05() As System.Single
            Get
                Return _RCV05
            End Get
            Set(ByVal value As System.Single)
                _RCV05 = value
            End Set
        End Property
#End Region
#Region "INV-AMOUNT 屬性:RCV06"
        Private _RCV06 As System.Single
        ''' <summary>
        ''' INV-AMOUNT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV06() As System.Single
            Get
                Return _RCV06
            End Get
            Set(ByVal value As System.Single)
                _RCV06 = value
            End Set
        End Property
#End Region
#Region "銀行 屬性:RCV07"
        Private _RCV07 As System.String
        ''' <summary>
        ''' 銀行
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV07() As System.String
            Get
                Return _RCV07
            End Get
            Set(ByVal value As System.String)
                _RCV07 = value
            End Set
        End Property
#End Region
#Region "ACCOUNT-NO. 屬性:RCV08"
        Private _RCV08 As System.String
        ''' <summary>
        ''' ACCOUNT-NO.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV08() As System.String
            Get
                Return _RCV08
            End Get
            Set(ByVal value As System.String)
                _RCV08 = value
            End Set
        End Property
#End Region
#Region "Ｌ／Ｃ編號 屬性:RCV09"
        Private _RCV09 As System.String
        ''' <summary>
        ''' Ｌ／Ｃ編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV09() As System.String
            Get
                Return _RCV09
            End Get
            Set(ByVal value As System.String)
                _RCV09 = value
            End Set
        End Property
#End Region
#Region "有效日期 屬性:RCV10"
        Private _RCV10 As System.String
        ''' <summary>
        ''' 有效日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV10() As System.String
            Get
                Return _RCV10
            End Get
            Set(ByVal value As System.String)
                _RCV10 = value
            End Set
        End Property
#End Region
#Region "收款類別 屬性:RCV11"
        Private _RCV11 As System.String
        ''' <summary>
        ''' 收款類別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV11() As System.String
            Get
                Return _RCV11
            End Get
            Set(ByVal value As System.String)
                _RCV11 = value
            End Set
        End Property
#End Region
#Region "Ｌ／Ｃ遠期日期 屬性:RCV12"
        Private _RCV12 As System.Int32
        ''' <summary>
        ''' Ｌ／Ｃ遠期日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV12() As System.Int32
            Get
                Return _RCV12
            End Get
            Set(ByVal value As System.Int32)
                _RCV12 = value
            End Set
        End Property
#End Region
#Region "結案碼 屬性:RCV13"
        Private _RCV13 As System.String
        ''' <summary>
        ''' 結案碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV13() As System.String
            Get
                Return _RCV13
            End Get
            Set(ByVal value As System.String)
                _RCV13 = value
            End Set
        End Property
#End Region
#Region "沖銷碼 屬性:RCV14"
        Private _RCV14 As System.String
        ''' <summary>
        ''' 沖銷碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV14() As System.String
            Get
                Return _RCV14
            End Get
            Set(ByVal value As System.String)
                _RCV14 = value
            End Set
        End Property
#End Region
#Region "序號 屬性:RCV15"
        Private _RCV15 As System.Int32
        ''' <summary>
        ''' 序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV15() As System.Int32
            Get
                Return _RCV15
            End Get
            Set(ByVal value As System.Int32)
                _RCV15 = value
            End Set
        End Property
#End Region
#Region "選擇碼－１ 屬性:RCV91"
        Private _RCV91 As System.String
        ''' <summary>
        ''' 選擇碼－１
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV91() As System.String
            Get
                Return _RCV91
            End Get
            Set(ByVal value As System.String)
                _RCV91 = value
            End Set
        End Property
#End Region
#Region "選擇碼－２ 屬性:RCV92"
        Private _RCV92 As System.String
        ''' <summary>
        ''' 選擇碼－２
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV92() As System.String
            Get
                Return _RCV92
            End Get
            Set(ByVal value As System.String)
                _RCV92 = value
            End Set
        End Property
#End Region
#Region "選擇碼－３ 屬性:RCV93"
        Private _RCV93 As System.String
        ''' <summary>
        ''' 選擇碼－３
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV93() As System.String
            Get
                Return _RCV93
            End Get
            Set(ByVal value As System.String)
                _RCV93 = value
            End Set
        End Property
#End Region
#Region "選擇碼－４ 屬性:RCV94"
        Private _RCV94 As System.String
        ''' <summary>
        ''' 選擇碼－４
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RCV94() As System.String
            Get
                Return _RCV94
            End Get
            Set(ByVal value As System.String)
                _RCV94 = value
            End Set
        End Property
#End Region
    End Class
End Namespace