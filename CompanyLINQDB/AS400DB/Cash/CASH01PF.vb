Namespace CASH
    ''' <summary>
    ''' 出納主檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CASH01PF
        Inherits ClassDB

        Sub New()
            MyBase.New("TESTKUKU", GetType(CASH01PF).Name)
        End Sub

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

#Region "付款日 屬性:PAYDAT"

        Private _PAYDAT As DateTime
        ''' <summary>
        ''' 付款日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PAYDAT() As DateTime
            Get
                Return _PAYDAT
            End Get
            Set(ByVal value As DateTime)
                _PAYDAT = value
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

    End Class

End Namespace
