Namespace COME
    ''' <summary>
    ''' 財務-收入參考檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class COME00PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("COME", GetType(COME00PF).Name)
        End Sub

#Region "六聯單編號 屬性:SIXNO8"
        Private _SIXNO8 As System.String
        ''' <summary>
        ''' 六聯單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXNO8() As System.String
            Get
                Return _SIXNO8
            End Get
            Set(ByVal value As System.String)
                _SIXNO8 = value
            End Set
        End Property
#End Region
#Region "流水號 屬性:SIXNO1"
        Private _SIXNO1 As System.String
        ''' <summary>
        ''' 流水號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXNO1() As System.String
            Get
                Return _SIXNO1
            End Get
            Set(ByVal value As System.String)
                _SIXNO1 = value
            End Set
        End Property
#End Region
#Region "項次 屬性:NUMBER"
        Private _NUMBER As System.String
        ''' <summary>
        ''' 項次
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NUMBER() As System.String
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As System.String)
                _NUMBER = value
            End Set
        End Property
#End Region
#Region "收入項目 屬性:INITEM"
        Private _INITEM As System.String
        ''' <summary>
        ''' 收入項目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INITEM() As System.String
            Get
                Return _INITEM
            End Get
            Set(ByVal value As System.String)
                _INITEM = value
            End Set
        End Property
#End Region
#Region "預算項目 屬性:BGITEM"
        Private _BGITEM As System.String
        ''' <summary>
        ''' 預算項目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BGITEM() As System.String
            Get
                Return _BGITEM
            End Get
            Set(ByVal value As System.String)
                _BGITEM = value
            End Set
        End Property
#End Region
#Region "收入金額 屬性:DOLLAR"
        Private _DOLLAR As System.Single
        ''' <summary>
        ''' 收入金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DOLLAR() As System.Single
            Get
                Return _DOLLAR
            End Get
            Set(ByVal value As System.Single)
                _DOLLAR = value
            End Set
        End Property
#End Region
#Region "通知單撥付單傳票號 屬性:TRANSF"
        Private _TRANSF As System.String
        ''' <summary>
        ''' 通知單撥付單傳票號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TRANSF() As System.String
            Get
                Return _TRANSF
            End Get
            Set(ByVal value As System.String)
                _TRANSF = value
            End Set
        End Property
#End Region
#Region "電匯與六聯單 屬性:SIXVAR"
        Private _SIXVAR As System.String
        ''' <summary>
        ''' 電匯與六聯單
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXVAR() As System.String
            Get
                Return _SIXVAR
            End Get
            Set(ByVal value As System.String)
                _SIXVAR = value
            End Set
        End Property
#End Region
#Region "財務－收款日 屬性:COMEDT"
        Private _COMEDT As System.String
        ''' <summary>
        ''' 財務－收款日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property COMEDT() As System.String
            Get
                Return _COMEDT
            End Get
            Set(ByVal value As System.String)
                _COMEDT = value
            End Set
        End Property
#End Region
#Region "財務－製通知單日 屬性:DATEDT"
        Private _DATEDT As System.String
        ''' <summary>
        ''' 財務－製通知單日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DATEDT() As System.String
            Get
                Return _DATEDT
            End Get
            Set(ByVal value As System.String)
                _DATEDT = value
            End Set
        End Property
#End Region
#Region "會計－入帳日 屬性:ACCTDT"
        Private _ACCTDT As System.String
        ''' <summary>
        ''' 會計－入帳日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACCTDT() As System.String
            Get
                Return _ACCTDT
            End Get
            Set(ByVal value As System.String)
                _ACCTDT = value
            End Set
        End Property
#End Region
#Region "業務－製單日 屬性:USERDT"
        Private _USERDT As System.String
        ''' <summary>
        ''' 業務－製單日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USERDT() As System.String
            Get
                Return _USERDT
            End Get
            Set(ByVal value As System.String)
                _USERDT = value
            End Set
        End Property
#End Region
#Region "申撥單或通知單編號 屬性:OUTFN1"
        Private _OUTFN1 As System.Int32
        ''' <summary>
        ''' 申撥單或通知單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OUTFN1() As System.Int32
            Get
                Return _OUTFN1
            End Get
            Set(ByVal value As System.Int32)
                _OUTFN1 = value
            End Set
        End Property
#End Region
#Region "出帳號－會計用 屬性:OUTFN2"
        Private _OUTFN2 As System.Int32
        ''' <summary>
        ''' 出帳號－會計用
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OUTFN2() As System.Int32
            Get
                Return _OUTFN2
            End Get
            Set(ByVal value As System.Int32)
                _OUTFN2 = value
            End Set
        End Property
#End Region
#Region "傳票編號 屬性:SHTNO7"
        Private _SHTNO7 As System.String
        ''' <summary>
        ''' 傳票編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHTNO7() As System.String
            Get
                Return _SHTNO7
            End Get
            Set(ByVal value As System.String)
                _SHTNO7 = value
            End Set
        End Property
#End Region
#Region "銀行別 屬性:BANKN1"
        Private _BANKN1 As System.String
        ''' <summary>
        ''' 銀行別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKN1() As System.String
            Get
                Return _BANKN1
            End Get
            Set(ByVal value As System.String)
                _BANKN1 = value
            End Set
        End Property
#End Region
#Region "發票號碼、匯款機關 屬性:INVENO"
        Private _INVENO As System.String
        ''' <summary>
        ''' 發票號碼、匯款機關
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INVENO() As System.String
            Get
                Return _INVENO
            End Get
            Set(ByVal value As System.String)
                _INVENO = value
            End Set
        End Property
#End Region
#Region "摘要 屬性:MEMO26"
        Private _MEMO26 As System.String
        ''' <summary>
        ''' 摘要
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO26() As System.String
            Get
                Return _MEMO26
            End Get
            Set(ByVal value As System.String)
                _MEMO26 = value
            End Set
        End Property
#End Region
#Region "備註 屬性:MEMO62"
        Private _MEMO62 As System.String
        ''' <summary>
        ''' 備註
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO62() As System.String
            Get
                Return _MEMO62
            End Get
            Set(ByVal value As System.String)
                _MEMO62 = value
            End Set
        End Property
#End Region
#Region "工程編號 屬性:WORK10"
        Private _WORK10 As System.String
        ''' <summary>
        ''' 工程編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WORK10() As System.String
            Get
                Return _WORK10
            End Get
            Set(ByVal value As System.String)
                _WORK10 = value
            End Set
        End Property
#End Region
#Region "輸入者 屬性:USERNO"
        Private _USERNO As System.String
        ''' <summary>
        ''' 輸入者
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USERNO() As System.String
            Get
                Return _USERNO
            End Get
            Set(ByVal value As System.String)
                _USERNO = value
            End Set
        End Property
#End Region
#Region "財務－輸入日期 屬性:INPUT1"
        Private _INPUT1 As System.String
        ''' <summary>
        ''' 財務－輸入日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUT1() As System.String
            Get
                Return _INPUT1
            End Get
            Set(ByVal value As System.String)
                _INPUT1 = value
            End Set
        End Property
#End Region
#Region "會計－輸入日期 屬性:INPUT2"
        Private _INPUT2 As System.String
        ''' <summary>
        ''' 會計－輸入日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUT2() As System.String
            Get
                Return _INPUT2
            End Get
            Set(ByVal value As System.String)
                _INPUT2 = value
            End Set
        End Property
#End Region
#Region "製單日期所屬年月 屬性:FIELD6"
        Private _FIELD6 As System.String
        ''' <summary>
        ''' 製單日期所屬年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FIELD6() As System.String
            Get
                Return _FIELD6
            End Get
            Set(ByVal value As System.String)
                _FIELD6 = value
            End Set
        End Property
#End Region
#Region "達帳日 屬性:BANKDY"
        Private _BANKDY As System.String
        ''' <summary>
        ''' 達帳日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKDY() As System.String
            Get
                Return _BANKDY
            End Get
            Set(ByVal value As System.String)
                _BANKDY = value
            End Set
        End Property
#End Region
#Region "預算項目 屬性:NOITEM"
        Private _NOITEM As System.String
        ''' <summary>
        ''' 預算項目
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NOITEM() As System.String
            Get
                Return _NOITEM
            End Get
            Set(ByVal value As System.String)
                _NOITEM = value
            End Set
        End Property
#End Region
#Region "項目中文 屬性:ITEMNM"
        Private _ITEMNM As System.String
        ''' <summary>
        ''' 項目中文
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ITEMNM() As System.String
            Get
                Return _ITEMNM
            End Get
            Set(ByVal value As System.String)
                _ITEMNM = value
            End Set
        End Property
#End Region
#Region "摘要代碼 屬性:MEMO04"
        Private _MEMO04 As System.String
        ''' <summary>
        ''' 摘要代碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO04() As System.String
            Get
                Return _MEMO04
            End Get
            Set(ByVal value As System.String)
                _MEMO04 = value
            End Set
        End Property
#End Region
#Region "備註代碼 屬性:MEMO10"
        Private _MEMO10 As System.String
        ''' <summary>
        ''' 備註代碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MEMO10() As System.String
            Get
                Return _MEMO10
            End Get
            Set(ByVal value As System.String)
                _MEMO10 = value
            End Set
        End Property
#End Region
#Region "年度別 屬性:COMEYR"
        Private _COMEYR As System.Int32
        ''' <summary>
        ''' 年度別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property COMEYR() As System.Int32
            Get
                Return _COMEYR
            End Get
            Set(ByVal value As System.Int32)
                _COMEYR = value
            End Set
        End Property
#End Region
#Region "SIXVAR 與 TRANSF 屬性:VARITY"
        Private _VARITY As System.String
        ''' <summary>
        ''' SIXVAR 與 TRANSF
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property VARITY() As System.String
            Get
                Return _VARITY
            End Get
            Set(ByVal value As System.String)
                _VARITY = value
            End Set
        End Property
#End Region
#Region "收入類別說明 屬性:VARNAM"
        Private _VARNAM As System.String
        ''' <summary>
        ''' 收入類別說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property VARNAM() As System.String
            Get
                Return _VARNAM
            End Get
            Set(ByVal value As System.String)
                _VARNAM = value
            End Set
        End Property
#End Region
#Region "電匯－六聯單編號 屬性:SIXN18"
        Private _SIXN18 As System.String
        ''' <summary>
        ''' 電匯－六聯單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXN18() As System.String
            Get
                Return _SIXN18
            End Get
            Set(ByVal value As System.String)
                _SIXN18 = value
            End Set
        End Property
#End Region
#Region "電匯－流水號 屬性:SIXN11"
        Private _SIXN11 As System.String
        ''' <summary>
        ''' 電匯－流水號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXN11() As System.String
            Get
                Return _SIXN11
            End Get
            Set(ByVal value As System.String)
                _SIXN11 = value
            End Set
        End Property
#End Region
#Region "電匯－項次 屬性:NUMBE1"
        Private _NUMBE1 As System.String
        ''' <summary>
        ''' 電匯－項次
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NUMBE1() As System.String
            Get
                Return _NUMBE1
            End Get
            Set(ByVal value As System.String)
                _NUMBE1 = value
            End Set
        End Property
#End Region
#Region "六聯單編號 屬性:SIXN28"
        Private _SIXN28 As System.String
        ''' <summary>
        ''' 六聯單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXN28() As System.String
            Get
                Return _SIXN28
            End Get
            Set(ByVal value As System.String)
                _SIXN28 = value
            End Set
        End Property
#End Region
#Region "流水號 屬性:SIXN21"
        Private _SIXN21 As System.String
        ''' <summary>
        ''' 流水號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXN21() As System.String
            Get
                Return _SIXN21
            End Get
            Set(ByVal value As System.String)
                _SIXN21 = value
            End Set
        End Property
#End Region
#Region "項次 屬性:NUMBE2"
        Private _NUMBE2 As System.String
        ''' <summary>
        ''' 項次
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NUMBE2() As System.String
            Get
                Return _NUMBE2
            End Get
            Set(ByVal value As System.String)
                _NUMBE2 = value
            End Set
        End Property
#End Region
#Region "沖銷日期 屬性:SIXDAT"
        Private _SIXDAT As System.String
        ''' <summary>
        ''' 沖銷日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SIXDAT() As System.String
            Get
                Return _SIXDAT
            End Get
            Set(ByVal value As System.String)
                _SIXDAT = value
            End Set
        End Property
#End Region
    End Class
End Namespace