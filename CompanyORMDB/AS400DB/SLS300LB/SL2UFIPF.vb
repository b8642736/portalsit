Namespace SLS300LB
    ''' <summary>
    ''' 統一發票申請單檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2UFIPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2UFIPF).Name)
        End Sub

#Region "發票日期 屬性:UFI01"
        Private _UFI01 As System.String
        ''' <summary>
        ''' 發票日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI01() As System.String
            Get
                Return _UFI01
            End Get
            Set(ByVal value As System.String)
                _UFI01 = value
            End Set
        End Property
#End Region
#Region "發票申請單編號 屬性:UFI02"
        Private _UFI02 As System.String
        ''' <summary>
        ''' 發票申請單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI02() As System.String
            Get
                Return _UFI02
            End Get
            Set(ByVal value As System.String)
                _UFI02 = value
            End Set
        End Property
#End Region
#Region "報價單編號 屬性:UFI03"
        Private _UFI03 As System.String
        ''' <summary>
        ''' 報價單編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI03() As System.String
            Get
                Return _UFI03
            End Get
            Set(ByVal value As System.String)
                _UFI03 = value
            End Set
        End Property
#End Region
#Region "鋼種 屬性:UFI04"
        Private _UFI04 As System.String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI04() As System.String
            Get
                Return _UFI04
            End Get
            Set(ByVal value As System.String)
                _UFI04 = value
            End Set
        End Property
#End Region
#Region "表面 屬性:UFI05"
        Private _UFI05 As System.String
        ''' <summary>
        ''' 表面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI05() As System.String
            Get
                Return _UFI05
            End Get
            Set(ByVal value As System.String)
                _UFI05 = value
            End Set
        End Property
#End Region
#Region "厚度 屬性:UFI06"
        Private _UFI06 As System.String
        ''' <summary>
        ''' 厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI06() As System.String
            Get
                Return _UFI06
            End Get
            Set(ByVal value As System.String)
                _UFI06 = value
            End Set
        End Property
#End Region
#Region "寬度 屬性:UFI07"
        Private _UFI07 As System.Int32
        ''' <summary>
        ''' 寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI07() As System.Int32
            Get
                Return _UFI07
            End Get
            Set(ByVal value As System.Int32)
                _UFI07 = value
            End Set
        End Property
#End Region
#Region "毛邊 屬性:UFI08"
        Private _UFI08 As System.String
        ''' <summary>
        ''' 毛邊
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI08() As System.String
            Get
                Return _UFI08
            End Get
            Set(ByVal value As System.String)
                _UFI08 = value
            End Set
        End Property
#End Region
#Region "長度 屬性:UFI09"
        Private _UFI09 As System.Int32
        ''' <summary>
        ''' 長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI09() As System.Int32
            Get
                Return _UFI09
            End Get
            Set(ByVal value As System.Int32)
                _UFI09 = value
            End Set
        End Property
#End Region
#Region "鋼捲內徑 屬性:UFI10"
        Private _UFI10 As System.Int32
        ''' <summary>
        ''' 鋼捲內徑
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI10() As System.Int32
            Get
                Return _UFI10
            End Get
            Set(ByVal value As System.Int32)
                _UFI10 = value
            End Set
        End Property
#End Region
#Region "捲、片 屬性:UFI11"
        Private _UFI11 As System.String
        ''' <summary>
        ''' 捲、片
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI11() As System.String
            Get
                Return _UFI11
            End Get
            Set(ByVal value As System.String)
                _UFI11 = value
            End Set
        End Property
#End Region
#Region "本單提貨重量KG 屬性:UFI12"
        Private _UFI12 As System.Int32
        ''' <summary>
        ''' 本單提貨重量KG
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI12() As System.Int32
            Get
                Return _UFI12
            End Get
            Set(ByVal value As System.Int32)
                _UFI12 = value
            End Set
        End Property
#End Region
#Region "等級 屬性:UFI13"
        Private _UFI13 As System.String
        ''' <summary>
        ''' 等級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI13() As System.String
            Get
                Return _UFI13
            End Get
            Set(ByVal value As System.String)
                _UFI13 = value
            End Set
        End Property
#End Region
#Region "收款編號 屬性:UFI14"
        Private _UFI14 As System.String
        ''' <summary>
        ''' 收款編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI14() As System.String
            Get
                Return _UFI14
            End Get
            Set(ByVal value As System.String)
                _UFI14 = value
            End Set
        End Property
#End Region
#Region "現金價 屬性:UFI15"
        Private _UFI15 As System.Single
        ''' <summary>
        ''' 現金價
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI15() As System.Single
            Get
                Return _UFI15
            End Get
            Set(ByVal value As System.Single)
                _UFI15 = value
            End Set
        End Property
#End Region
#Region "利息 屬性:UFI16"
        Private _UFI16 As System.Single
        ''' <summary>
        ''' 利息
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI16() As System.Single
            Get
                Return _UFI16
            End Get
            Set(ByVal value As System.Single)
                _UFI16 = value
            End Set
        End Property
#End Region
#Region "營業稅 屬性:UFI17"
        Private _UFI17 As System.Single
        ''' <summary>
        ''' 營業稅
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI17() As System.Single
            Get
                Return _UFI17
            End Get
            Set(ByVal value As System.Single)
                _UFI17 = value
            End Set
        End Property
#End Region
#Region "發票號碼 屬性:UFI18"
        Private _UFI18 As System.String
        ''' <summary>
        ''' 發票號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI18() As System.String
            Get
                Return _UFI18
            End Get
            Set(ByVal value As System.String)
                _UFI18 = value
            End Set
        End Property
#End Region
#Region "提貨單號 屬性:UFI19"
        Private _UFI19 As System.String
        ''' <summary>
        ''' 提貨單號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property UFI19() As System.String
            Get
                Return _UFI19
            End Get
            Set(ByVal value As System.String)
                _UFI19 = value
            End Set
        End Property
#End Region
#Region "鋼捲號碼-1 屬性:UFI20"
        Private _UFI20 As System.String
        ''' <summary>
        ''' 鋼捲號碼-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI20() As System.String
            Get
                Return _UFI20
            End Get
            Set(ByVal value As System.String)
                _UFI20 = value
            End Set
        End Property
#End Region
#Region "重　量-1 屬性:UFI21"
        Private _UFI21 As System.Int32
        ''' <summary>
        ''' 重　量-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI21() As System.Int32
            Get
                Return _UFI21
            End Get
            Set(ByVal value As System.Int32)
                _UFI21 = value
            End Set
        End Property
#End Region
#Region "鋼捲號碼-2 屬性:UFI22"
        Private _UFI22 As System.String
        ''' <summary>
        ''' 鋼捲號碼-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI22() As System.String
            Get
                Return _UFI22
            End Get
            Set(ByVal value As System.String)
                _UFI22 = value
            End Set
        End Property
#End Region
#Region "重　量-2 屬性:UFI23"
        Private _UFI23 As System.Int32
        ''' <summary>
        ''' 重　量-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI23() As System.Int32
            Get
                Return _UFI23
            End Get
            Set(ByVal value As System.Int32)
                _UFI23 = value
            End Set
        End Property
#End Region
#Region "鋼捲號碼-3 屬性:UFI24"
        Private _UFI24 As System.String
        ''' <summary>
        ''' 鋼捲號碼-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI24() As System.String
            Get
                Return _UFI24
            End Get
            Set(ByVal value As System.String)
                _UFI24 = value
            End Set
        End Property
#End Region
#Region "重　量-3 屬性:UFI25"
        Private _UFI25 As System.Int32
        ''' <summary>
        ''' 重　量-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI25() As System.Int32
            Get
                Return _UFI25
            End Get
            Set(ByVal value As System.Int32)
                _UFI25 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:UFI91"
        Private _UFI91 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI91() As System.String
            Get
                Return _UFI91
            End Get
            Set(ByVal value As System.String)
                _UFI91 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:UFI92"
        Private _UFI92 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UFI92() As System.String
            Get
                Return _UFI92
            End Get
            Set(ByVal value As System.String)
                _UFI92 = value
            End Set
        End Property
#End Region
    End Class
End Namespace