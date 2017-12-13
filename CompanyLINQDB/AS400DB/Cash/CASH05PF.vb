Namespace CASH
    ''' <summary>
    ''' 銀行代碼檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CASH05PF
        Inherits ClassDB

        Sub New()
            MyBase.New("TESTKUKU", GetType(CASH05PF).Name)
        End Sub

#Region "銀行別 屬性:BANKN1"

        Private _BANKN1 As String
        ''' <summary>
        ''' 銀行別
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
#Region "銀行別中文說明 屬性:BANKNM"

        Private _BANKNM As String
        ''' <summary>
        ''' 銀行別中文說明
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
#Region "中文簡稱 屬性:BANK18"

        Private _BANK18 As String
        ''' <summary>
        ''' 中文簡稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANK18() As String
            Get
                Return _BANK18
            End Get
            Set(ByVal value As String)
                _BANK18 = value
            End Set
        End Property

#End Region
#Region "銀行地址 屬性:BANK62"

        Private _BANK62 As String
        ''' <summary>
        ''' 銀行地址
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANK62() As String
            Get
                Return _BANK62
            End Get
            Set(ByVal value As String)
                _BANK62 = value
            End Set
        End Property

#End Region
#Region "會計銀行對照 屬性:BANKAC"

        Private _BANKAC As String
        ''' <summary>
        ''' 會計銀行對照
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKAC() As String
            Get
                Return _BANKAC
            End Get
            Set(ByVal value As String)
                _BANKAC = value
            End Set
        End Property

#End Region
#Region "單位別 屬性:BANKDP"

        Private _BANKDP As String
        ''' <summary>
        ''' 單位別
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKDP() As String
            Get
                Return _BANKDP
            End Get
            Set(ByVal value As String)
                _BANKDP = value
            End Set
        End Property

#End Region
#Region "透支存款 屬性:BANKVR"

        Private _BANKVR As String
        ''' <summary>
        ''' 透支存款
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKVR() As String
            Get
                Return _BANKVR
            End Get
            Set(ByVal value As String)
                _BANKVR = value
            End Set
        End Property

#End Region
#Region "總行 屬性:BANKTT"

        Private _BANKTT As String
        ''' <summary>
        ''' 總行
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKTT() As String
            Get
                Return _BANKTT
            End Get
            Set(ByVal value As String)
                _BANKTT = value
            End Set
        End Property

#End Region
#Region "分行 屬性:BANKSC"

        Private _BANKSC As String
        ''' <summary>
        ''' 分行
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKSC() As String
            Get
                Return _BANKSC
            End Get
            Set(ByVal value As String)
                _BANKSC = value
            End Set
        End Property

#End Region
#Region "電話號碼 屬性:BNKTEL"

        Private _BNKTEL As String
        ''' <summary>
        ''' 電話號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKTEL() As String
            Get
                Return _BNKTEL
            End Get
            Set(ByVal value As String)
                _BNKTEL = value
            End Set
        End Property

#End Region
#Region "傳真號碼 屬性:BNKFAX"

        Private _BNKFAX As String
        ''' <summary>
        ''' 傳真號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKFAX() As String
            Get
                Return _BNKFAX
            End Get
            Set(ByVal value As String)
                _BNKFAX = value
            End Set
        End Property

#End Region
#Region "連絡人1 屬性:BNKMNA"

        Private _BNKMNA As String
        ''' <summary>
        ''' 連絡人1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKMNA() As String
            Get
                Return _BNKMNA
            End Get
            Set(ByVal value As String)
                _BNKMNA = value
            End Set
        End Property

#End Region
#Region "帳號 屬性:BNKMNB"

        Private _BNKMNB As String
        ''' <summary>
        ''' 帳號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKMNB() As String
            Get
                Return _BNKMNB
            End Get
            Set(ByVal value As String)
                _BNKMNB = value
            End Set
        End Property

#End Region
#Region "預留支票位數 屬性:BNKFLD"

        Private _BNKFLD As String
        Public Property BNKFLD() As String
            Get
                Return _BNKFLD
            End Get
            Set(ByVal value As String)
                _BNKFLD = value
            End Set
        End Property


#End Region


    End Class
End Namespace
