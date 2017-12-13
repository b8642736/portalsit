Namespace TESTKUKU
    Public Class Cash05pf
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("testkuku", GetType(Cash05pf).Name)
        End Sub

#Region "銀行別 屬性:BANKN1"
        Private _BANKN1 As System.String
        ''' <summary>
        ''' 銀行別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property BANKN1() As System.String
            Get
                Return _BANKN1
            End Get
            Set(ByVal value As System.String)
                _BANKN1 = value
            End Set
        End Property
#End Region
#Region "銀行別中文說明 屬性:BANKNM"
        Private _BANKNM As System.String
        ''' <summary>
        ''' 銀行別中文說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKNM() As System.String
            Get
                Return _BANKNM
            End Get
            Set(ByVal value As System.String)
                _BANKNM = value
            End Set
        End Property
#End Region
#Region "中文簡稱 屬性:BANK18"
        Private _BANK18 As System.String
        ''' <summary>
        ''' 中文簡稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANK18() As System.String
            Get
                Return _BANK18
            End Get
            Set(ByVal value As System.String)
                _BANK18 = value
            End Set
        End Property
#End Region
#Region "銀行地址 屬性:BANK62"
        Private _BANK62 As System.String
        ''' <summary>
        ''' 銀行地址
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANK62() As System.String
            Get
                Return _BANK62
            End Get
            Set(ByVal value As System.String)
                _BANK62 = value
            End Set
        End Property
#End Region
#Region "會計銀行對照 屬性:BANKAC"
        Private _BANKAC As System.String
        ''' <summary>
        ''' 會計銀行對照
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKAC() As System.String
            Get
                Return _BANKAC
            End Get
            Set(ByVal value As System.String)
                _BANKAC = value
            End Set
        End Property
#End Region
#Region "單位別 屬性:BANKDP"
        Private _BANKDP As System.String
        ''' <summary>
        ''' 單位別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKDP() As System.String
            Get
                Return _BANKDP
            End Get
            Set(ByVal value As System.String)
                _BANKDP = value
            End Set
        End Property
#End Region
#Region "透支、存款戶 屬性:BANKVR"
        Private _BANKVR As System.String
        ''' <summary>
        ''' 透支、存款戶
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKVR() As System.String
            Get
                Return _BANKVR
            End Get
            Set(ByVal value As System.String)
                _BANKVR = value
            End Set
        End Property
#End Region
#Region "總行 屬性:BANKTT"
        Private _BANKTT As System.String
        ''' <summary>
        ''' 總行
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKTT() As System.String
            Get
                Return _BANKTT
            End Get
            Set(ByVal value As System.String)
                _BANKTT = value
            End Set
        End Property
#End Region
#Region "分行 屬性:BANKSC"
        Private _BANKSC As System.String
        ''' <summary>
        ''' 分行
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKSC() As System.String
            Get
                Return _BANKSC
            End Get
            Set(ByVal value As System.String)
                _BANKSC = value
            End Set
        End Property
#End Region
#Region "電話號碼 屬性:BNKTEL"
        Private _BNKTEL As System.String
        ''' <summary>
        ''' 電話號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKTEL() As System.String
            Get
                Return _BNKTEL
            End Get
            Set(ByVal value As System.String)
                _BNKTEL = value
            End Set
        End Property
#End Region
#Region "傳真號碼 屬性:BNKFAX"
        Private _BNKFAX As System.String
        ''' <summary>
        ''' 傳真號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKFAX() As System.String
            Get
                Return _BNKFAX
            End Get
            Set(ByVal value As System.String)
                _BNKFAX = value
            End Set
        End Property
#End Region
#Region "聯絡人1 屬性:BNKMNA"
        Private _BNKMNA As System.String
        ''' <summary>
        ''' 聯絡人1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKMNA() As System.String
            Get
                Return _BNKMNA
            End Get
            Set(ByVal value As System.String)
                _BNKMNA = value
            End Set
        End Property
#End Region
#Region "帳號 屬性:BNKMNB"
        Private _BNKMNB As System.String
        ''' <summary>
        ''' 帳號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKMNB() As System.String
            Get
                Return _BNKMNB
            End Get
            Set(ByVal value As System.String)
                _BNKMNB = value
            End Set
        End Property
#End Region
#Region "預留－支票位數 屬性:BNKFLD"
        Private _BNKFLD As System.String
        ''' <summary>
        ''' 預留－支票位數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BNKFLD() As System.String
            Get
                Return _BNKFLD
            End Get
            Set(ByVal value As System.String)
                _BNKFLD = value
            End Set
        End Property
#End Region
    End Class
End Namespace