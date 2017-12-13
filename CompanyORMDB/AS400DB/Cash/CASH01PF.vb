Namespace CASH
    ''' <summary>
    ''' 出納主檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CASH01PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("CASH", GetType(CASH01PF).Name)
        End Sub

#Region "傳票編號 屬性: SHTNOO"

        Private _SHTNOO As String
        ''' <summary>
        ''' 傳票編號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHTNOO() As String
            Get
                Return _SHTNOO
            End Get
            Set(ByVal value As String)
                _SHTNOO = value
            End Set
        End Property

#End Region
#Region "單位別 屬性:DEPART"

        Private _DEPART As String
        ''' <summary>
        ''' 單位別
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPART() As String
            Get
                Return _DEPART
            End Get
            Set(ByVal value As String)
                _DEPART = value
            End Set
        End Property

#End Region
#Region "支出科目 屬性:ACITEM"

        Private _ACITEM As String
        ''' <summary>
        ''' 支出科目
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACITEM() As String
            Get
                Return _ACITEM
            End Get
            Set(ByVal value As String)
                _ACITEM = value
            End Set
        End Property

#End Region
#Region "用途 屬性:USEFOR"

        Private _USEFOR As String
        ''' <summary>
        ''' 用途
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USEFOR() As String
            Get
                Return _USEFOR
            End Get
            Set(ByVal value As String)
                _USEFOR = value
            End Set
        End Property

#End Region
#Region "受款人 屬性:RECEPR"

        Private _RECEPR As String
        ''' <summary>
        ''' 受款人
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RECEPR() As String
            Get
                Return _RECEPR
            End Get
            Set(ByVal value As String)
                _RECEPR = value
            End Set
        End Property

#End Region
#Region "支票金額 屬性:CHKAMT"

        Private _CHKAMT As Double
        ''' <summary>
        ''' 支票金額
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CHKAMT() As Double
            Get
                Return _CHKAMT
            End Get
            Set(ByVal value As Double)
                _CHKAMT = value
            End Set
        End Property

#End Region
#Region "付款日-支票日 屬性:PAYDAT"

        Private _PAYDAT As String
        ''' <summary>
        ''' 付款日-支票日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PAYDAT() As String
            Get
                Return _PAYDAT
            End Get
            Set(ByVal value As String)
                _PAYDAT = value
            End Set
        End Property

#End Region
#Region "出帳日-領取日 屬性:OUTDAT"

        Private _OUTDAT As String
        ''' <summary>
        ''' 出帳日-領取日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OUTDAT() As String
            Get
                Return _OUTDAT
            End Get
            Set(ByVal value As String)
                _OUTDAT = value
            End Set
        End Property


#End Region
#Region "逹帳日-兌現日 屬性:BANKDY"

        Private _BANKDY As String
        ''' <summary>
        ''' 逹帳日-兌現日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKDY() As String
            Get
                Return _BANKDY
            End Get
            Set(ByVal value As String)
                _BANKDY = value
            End Set
        End Property

#End Region
#Region "支票號碼 屬性:CHECK1"

        Private _CHECK1 As String
        ''' <summary>
        ''' 支票號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CHECK1() As String
            Get
                Return _CHECK1
            End Get
            Set(ByVal value As String)
                _CHECK1 = value
            End Set
        End Property

#End Region
#Region "出帳號-會計用 屬性:OUTFN1"

        Private _OUTFN1 As Integer
        ''' <summary>
        ''' 出帳號-會計用
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OUTFN1() As Integer
            Get
                Return _OUTFN1
            End Get
            Set(ByVal value As Integer)
                _OUTFN1 = value
            End Set
        End Property


#End Region
#Region "銀行別 屬性:BANKN1"

        Private _BANKN1 As String
        ''' <summary>
        ''' 銀行別
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKN1() As String
            Get
                Return _BANKN1
            End Get
            Set(ByVal value As String)
                _BANKN1 = value
            End Set
        End Property

#End Region
#Region "解款行 屬性:BANKN2"

        Private _BANKN2 As String
        ''' <summary>
        ''' 解款行
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKN2() As String
            Get
                Return _BANKN2
            End Get
            Set(ByVal value As String)
                _BANKN2 = value
            End Set
        End Property

#End Region
#Region "收款人帳號 屬性:BANKN3"

        Private _BANKN3 As String
        ''' <summary>
        ''' 收款人帳號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BANKN3() As String
            Get
                Return _BANKN3
            End Get
            Set(ByVal value As String)
                _BANKN3 = value
            End Set
        End Property

#End Region
#Region "地址 屬性:ADDRES"

        Private _ADDRES As String
        ''' <summary>
        ''' 地址
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ADDRES() As String
            Get
                Return _ADDRES
            End Get
            Set(ByVal value As String)
                _ADDRES = value
            End Set
        End Property

#End Region
#Region "發票號碼 屬性:INVENO"

        Private _INVENO As String
        ''' <summary>
        ''' 發票號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INVENO() As String
            Get
                Return _INVENO
            End Get
            Set(ByVal value As String)
                _INVENO = value
            End Set
        End Property

#End Region
#Region "匯款OR郵寄 屬性:VARITY"

        Private _VARITY As String
        ''' <summary>
        ''' 匯款OR郵寄
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property VARITY() As String
            Get
                Return _VARITY
            End Get
            Set(ByVal value As String)
                _VARITY = value
            End Set
        End Property

#End Region
#Region "統一編號 屬性:WORK10"
        Private _WORK10 As System.String
        ''' <summary>
        ''' 統一編號
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

        Private _USERNO As String
        ''' <summary>
        ''' 輸入者
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USERNO() As String
            Get
                Return _USERNO
            End Get
            Set(ByVal value As String)
                _USERNO = value
            End Set
        End Property

#End Region
#Region "輸入日期-基本 屬性:INPUT1"

        Private _INPUT1 As String
        ''' <summary>
        ''' 輸入日期-基本
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUT1() As String
            Get
                Return _INPUT1
            End Get
            Set(ByVal value As String)
                _INPUT1 = value
            End Set
        End Property

#End Region
#Region "輸入日期-異動 屬性:INPUT2"

        Private _INPUT2 As String
        ''' <summary>
        ''' 輸入日期-異動
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property INPUT2() As String
            Get
                Return _INPUT2
            End Get
            Set(ByVal value As String)
                _INPUT2 = value
            End Set
        End Property

#End Region
#Region "分行代碼 屬性:FIELD1"


        Private _FIELD1 As String
        ''' <summary>
        ''' 分行代碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FIELD1() As String
            Get
                Return _FIELD1
            End Get
            Set(ByVal value As String)
                _FIELD1 = value
            End Set
        End Property

#End Region
#Region "利息種類 屬性:FIELD3"

        Private _FIELD3 As String
        ''' <summary>
        ''' 利息種類
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FIELD3() As String
            Get
                Return _FIELD3
            End Get
            Set(ByVal value As String)
                _FIELD3 = value
            End Set
        End Property

#End Region


    End Class
End Namespace