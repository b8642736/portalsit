Namespace SLS300LB
    ''' <summary>
    ''' 在製品鋼捲入有主
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2CICPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2CICPF).Name)
        End Sub

#Region "鋼捲 屬性:CIC01"
        Private _CIC01 As System.String
        ''' <summary>
        ''' 鋼捲
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIC01() As System.String
            Get
                Return _CIC01
            End Get
            Set(ByVal value As System.String)
                _CIC01 = value
            End Set
        End Property
#End Region
#Region "斷捲 屬性:CIC02"
        Private _CIC02 As System.String
        ''' <summary>
        ''' 斷捲
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIC02() As System.String
            Get
                Return _CIC02
            End Get
            Set(ByVal value As System.String)
                _CIC02 = value
            End Set
        End Property
#End Region
#Region "站 屬性:CIC03"
        Private _CIC03 As System.Int32
        ''' <summary>
        ''' 站
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIC03() As System.Int32
            Get
                Return _CIC03
            End Get
            Set(ByVal value As System.Int32)
                _CIC03 = value
            End Set
        End Property
#End Region
#Region "報價單 屬性:CIC10"
        Private _CIC10 As System.String
        ''' <summary>
        ''' 報價單
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC10() As System.String
            Get
                Return _CIC10
            End Get
            Set(ByVal value As System.String)
                _CIC10 = value
            End Set
        End Property
#End Region
#Region "鋼種 屬性:CIC11"
        Private _CIC11 As System.String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC11() As System.String
            Get
                Return _CIC11
            End Get
            Set(ByVal value As System.String)
                _CIC11 = value
            End Set
        End Property
#End Region
#Region "TYPE 屬性:CIC12"
        Private _CIC12 As System.String
        ''' <summary>
        ''' TYPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC12() As System.String
            Get
                Return _CIC12
            End Get
            Set(ByVal value As System.String)
                _CIC12 = value
            End Set
        End Property
#End Region
#Region "表面 屬性:CIC13"
        Private _CIC13 As System.String
        ''' <summary>
        ''' 表面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC13() As System.String
            Get
                Return _CIC13
            End Get
            Set(ByVal value As System.String)
                _CIC13 = value
            End Set
        End Property
#End Region
#Region "厚度 屬性:CIC14"
        Private _CIC14 As System.String
        ''' <summary>
        ''' 厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC14() As System.String
            Get
                Return _CIC14
            End Get
            Set(ByVal value As System.String)
                _CIC14 = value
            End Set
        End Property
#End Region
#Region "範圍 屬性:CIC15"
        Private _CIC15 As System.String
        ''' <summary>
        ''' 範圍
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC15() As System.String
            Get
                Return _CIC15
            End Get
            Set(ByVal value As System.String)
                _CIC15 = value
            End Set
        End Property
#End Region
#Region "銷 屬性:CIC16"
        Private _CIC16 As System.String
        ''' <summary>
        ''' 銷
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC16() As System.String
            Get
                Return _CIC16
            End Get
            Set(ByVal value As System.String)
                _CIC16 = value
            End Set
        End Property
#End Region
#Region "料 屬性:CIC17"
        Private _CIC17 As System.String
        ''' <summary>
        ''' 料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC17() As System.String
            Get
                Return _CIC17
            End Get
            Set(ByVal value As System.String)
                _CIC17 = value
            End Set
        End Property
#End Region
#Region "急需日 屬性:CIC21"
        Private _CIC21 As System.String
        ''' <summary>
        ''' 急需日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC21() As System.String
            Get
                Return _CIC21
            End Get
            Set(ByVal value As System.String)
                _CIC21 = value
            End Set
        End Property
#End Region
#Region "急需編碼 屬性:CIC22"
        Private _CIC22 As System.String
        ''' <summary>
        ''' 急需編碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC22() As System.String
            Get
                Return _CIC22
            End Get
            Set(ByVal value As System.String)
                _CIC22 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:CIC91"
        Private _CIC91 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC91() As System.String
            Get
                Return _CIC91
            End Get
            Set(ByVal value As System.String)
                _CIC91 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:CIC92"
        Private _CIC92 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC92() As System.String
            Get
                Return _CIC92
            End Get
            Set(ByVal value As System.String)
                _CIC92 = value
            End Set
        End Property
#End Region





    End Class
End Namespace