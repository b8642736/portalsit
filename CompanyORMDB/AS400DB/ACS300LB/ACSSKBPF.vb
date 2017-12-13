Namespace ACS300LB
    Public Class ACSSKBPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("ACS300LB", GetType(ACSSKBPF).Name)
        End Sub

#Region "類別 屬性:SKB00"
        Private _SKB00 As System.String
        ''' <summary>
        ''' 類別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB00() As System.String
            Get
                Return _SKB00
            End Get
            Set(ByVal value As System.String)
                _SKB00 = value
            End Set
        End Property
#End Region
#Region "鋼種 屬性:SKB01"
        Private _SKB01 As System.String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB01() As System.String
            Get
                Return _SKB01
            End Get
            Set(ByVal value As System.String)
                _SKB01 = value
            End Set
        End Property
#End Region
#Region "HR/CR 屬性:SKB02"
        Private _SKB02 As System.String
        ''' <summary>
        ''' HR/CR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB02() As System.String
            Get
                Return _SKB02
            End Get
            Set(ByVal value As System.String)
                _SKB02 = value
            End Set
        End Property
#End Region
#Region "C/S 屬性:SKB03"
        Private _SKB03 As System.String
        ''' <summary>
        ''' C/S
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB03() As System.String
            Get
                Return _SKB03
            End Get
            Set(ByVal value As System.String)
                _SKB03 = value
            End Set
        End Property
#End Region
#Region "厚度 屬性:SKB04"
        Private _SKB04 As System.String
        ''' <summary>
        ''' 厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB04() As System.String
            Get
                Return _SKB04
            End Get
            Set(ByVal value As System.String)
                _SKB04 = value
            End Set
        End Property
#End Region
#Region "型 屬性:SKB04A"
        Private _SKB04A As System.String
        ''' <summary>
        ''' 型
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB04A() As System.String
            Get
                Return _SKB04A
            End Get
            Set(ByVal value As System.String)
                _SKB04A = value
            End Set
        End Property
#End Region
#Region "表面 屬性:SKB05"
        Private _SKB05 As System.String
        ''' <summary>
        ''' 表面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB05() As System.String
            Get
                Return _SKB05
            End Get
            Set(ByVal value As System.String)
                _SKB05 = value
            End Set
        End Property
#End Region
#Region "表面等級 屬性:SKB06"
        Private _SKB06 As System.String
        ''' <summary>
        ''' 表面等級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB06() As System.String
            Get
                Return _SKB06
            End Get
            Set(ByVal value As System.String)
                _SKB06 = value
            End Set
        End Property
#End Region
#Region "銷售別 屬性:SKB13"
        Private _SKB13 As System.String
        ''' <summary>
        ''' 銷售別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB13() As System.String
            Get
                Return _SKB13
            End Get
            Set(ByVal value As System.String)
                _SKB13 = value
            End Set
        End Property
#End Region
#Region "料別 屬性:SKB12"
        Private _SKB12 As System.String
        ''' <summary>
        ''' 料別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB12() As System.String
            Get
                Return _SKB12
            End Get
            Set(ByVal value As System.String)
                _SKB12 = value
            End Set
        End Property
#End Region
#Region "產品等級 屬性:SKB07"
        Private _SKB07 As System.String
        ''' <summary>
        ''' 產品等級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SKB07() As System.String
            Get
                Return _SKB07
            End Get
            Set(ByVal value As System.String)
                _SKB07 = value
            End Set
        End Property
#End Region
#Region "重量 屬性:SKB08"
        Private _SKB08 As Double
        ''' <summary>
        ''' 重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB08() As Double
            Get
                Return _SKB08
            End Get
            Set(ByVal value As Double)
                _SKB08 = value
            End Set
        End Property
#End Region
#Region "成本 屬性:SKB09"
        Private _SKB09 As Double
        ''' <summary>
        ''' 成本
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB09() As Double
            Get
                Return _SKB09
            End Get
            Set(ByVal value As Double)
                _SKB09 = value
            End Set
        End Property
#End Region
#Region "傳票編號 屬性:SKB10"
        Private _SKB10 As System.String
        ''' <summary>
        ''' 傳票編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB10() As System.String
            Get
                Return _SKB10
            End Get
            Set(ByVal value As System.String)
                _SKB10 = value
            End Set
        End Property
#End Region
#Region "傳票日期 屬性:SKB11"
        Private _SKB11 As System.String
        ''' <summary>
        ''' 傳票日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB11() As System.String
            Get
                Return _SKB11
            End Get
            Set(ByVal value As System.String)
                _SKB11 = value
            End Set
        End Property
#End Region
#Region "變動原料 屬性:SKB20"
        Private _SKB20 As Double
        ''' <summary>
        ''' 變動原料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB20() As Double
            Get
                Return _SKB20
            End Get
            Set(ByVal value As Double)
                _SKB20 = value
            End Set
        End Property
#End Region
#Region "燃　料 屬性:SKB21"
        Private _SKB21 As Double
        ''' <summary>
        ''' 燃　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB21() As Double
            Get
                Return _SKB21
            End Get
            Set(ByVal value As Double)
                _SKB21 = value
            End Set
        End Property
#End Region
#Region "物　料 屬性:SKB22"
        Private _SKB22 As Double
        ''' <summary>
        ''' 物　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB22() As Double
            Get
                Return _SKB22
            End Get
            Set(ByVal value As Double)
                _SKB22 = value
            End Set
        End Property
#End Region
#Region "人　工 屬性:SKB23"
        Private _SKB23 As Double
        ''' <summary>
        ''' 人　工
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB23() As Double
            Get
                Return _SKB23
            End Get
            Set(ByVal value As Double)
                _SKB23 = value
            End Set
        End Property
#End Region
#Region "間接費用 屬性:SKB24"
        Private _SKB24 As Double
        ''' <summary>
        ''' 間接費用
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB24() As Double
            Get
                Return _SKB24
            End Get
            Set(ByVal value As Double)
                _SKB24 = value
            End Set
        End Property
#End Region
#Region "固定原料 屬性:SKB20A"
        Private _SKB20A As System.Single
        ''' <summary>
        ''' 固定原料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB20A() As System.Single
            Get
                Return _SKB20A
            End Get
            Set(ByVal value As System.Single)
                _SKB20A = value
            End Set
        End Property
#End Region
#Region "燃　料 屬性:SKB21A"
        Private _SKB21A As System.Single
        ''' <summary>
        ''' 燃　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB21A() As System.Single
            Get
                Return _SKB21A
            End Get
            Set(ByVal value As System.Single)
                _SKB21A = value
            End Set
        End Property
#End Region
#Region "物　料 屬性:SKB22A"
        Private _SKB22A As System.Single
        ''' <summary>
        ''' 物　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB22A() As System.Single
            Get
                Return _SKB22A
            End Get
            Set(ByVal value As System.Single)
                _SKB22A = value
            End Set
        End Property
#End Region
#Region "人　工 屬性:SKB23A"
        Private _SKB23A As System.Single
        ''' <summary>
        ''' 人　工
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB23A() As System.Single
            Get
                Return _SKB23A
            End Get
            Set(ByVal value As System.Single)
                _SKB23A = value
            End Set
        End Property
#End Region
#Region "間接費用 屬性:SKB24A"
        Private _SKB24A As System.Single
        ''' <summary>
        ''' 間接費用
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB24A() As System.Single
            Get
                Return _SKB24A
            End Get
            Set(ByVal value As System.Single)
                _SKB24A = value
            End Set
        End Property
#End Region
#Region "變動原料 屬性:SKB25"
        Private _SKB25 As Double
        ''' <summary>
        ''' 變動原料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB25() As Double
            Get
                Return _SKB25
            End Get
            Set(ByVal value As Double)
                _SKB25 = value
            End Set
        End Property
#End Region
#Region "燃　料 屬性:SKB26"
        Private _SKB26 As Double
        ''' <summary>
        ''' 燃　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB26() As Double
            Get
                Return _SKB26
            End Get
            Set(ByVal value As Double)
                _SKB26 = value
            End Set
        End Property
#End Region
#Region "物　料 屬性:SKB27"
        Private _SKB27 As Double
        ''' <summary>
        ''' 物　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB27() As Double
            Get
                Return _SKB27
            End Get
            Set(ByVal value As Double)
                _SKB27 = value
            End Set
        End Property
#End Region
#Region "人　工 屬性:SKB28"
        Private _SKB28 As Double
        ''' <summary>
        ''' 人　工
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB28() As Double
            Get
                Return _SKB28
            End Get
            Set(ByVal value As Double)
                _SKB28 = value
            End Set
        End Property
#End Region
#Region "間接費用 屬性:SKB29"
        Private _SKB29 As Double
        ''' <summary>
        ''' 間接費用
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB29() As Double
            Get
                Return _SKB29
            End Get
            Set(ByVal value As Double)
                _SKB29 = value
            End Set
        End Property
#End Region
#Region "固定原料 屬性:SKB25A"
        Private _SKB25A As System.Single
        ''' <summary>
        ''' 固定原料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB25A() As System.Single
            Get
                Return _SKB25A
            End Get
            Set(ByVal value As System.Single)
                _SKB25A = value
            End Set
        End Property
#End Region
#Region "燃　料 屬性:SKB26A"
        Private _SKB26A As System.Single
        ''' <summary>
        ''' 燃　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB26A() As System.Single
            Get
                Return _SKB26A
            End Get
            Set(ByVal value As System.Single)
                _SKB26A = value
            End Set
        End Property
#End Region
#Region "物　料 屬性:SKB27A"
        Private _SKB27A As System.Single
        ''' <summary>
        ''' 物　料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB27A() As System.Single
            Get
                Return _SKB27A
            End Get
            Set(ByVal value As System.Single)
                _SKB27A = value
            End Set
        End Property
#End Region
#Region "人　工 屬性:SKB28A"
        Private _SKB28A As System.Single
        ''' <summary>
        ''' 人　工
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB28A() As System.Single
            Get
                Return _SKB28A
            End Get
            Set(ByVal value As System.Single)
                _SKB28A = value
            End Set
        End Property
#End Region
#Region "間接費用 屬性:SKB29A"
        Private _SKB29A As System.Single
        ''' <summary>
        ''' 間接費用
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB29A() As System.Single
            Get
                Return _SKB29A
            End Get
            Set(ByVal value As System.Single)
                _SKB29A = value
            End Set
        End Property
#End Region
#Region "軋壞損耗 屬性:SKB30"
        Private _SKB30 As System.Single
        ''' <summary>
        ''' 軋壞損耗
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB30() As System.Single
            Get
                Return _SKB30
            End Get
            Set(ByVal value As System.Single)
                _SKB30 = value
            End Set
        End Property
#End Region
#Region "代軋費（含運） 屬性:SKB31"
        Private _SKB31 As Double
        ''' <summary>
        ''' 代軋費（含運）
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB31() As Double
            Get
                Return _SKB31
            End Get
            Set(ByVal value As Double)
                _SKB31 = value
            End Set
        End Property
#End Region
#Region "加／減 屬性:SKB91"
        Private _SKB91 As System.String
        ''' <summary>
        ''' 加／減
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB91() As System.String
            Get
                Return _SKB91
            End Get
            Set(ByVal value As System.String)
                _SKB91 = value
            End Set
        End Property
#End Region
#Region "CODE 屬性:SKB92"
        Private _SKB92 As System.String
        ''' <summary>
        ''' CODE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SKB92() As System.String
            Get
                Return _SKB92
            End Get
            Set(ByVal value As System.String)
                _SKB92 = value
            End Set
        End Property
#End Region

#Region "單位成本 屬性:UnitCost"
        ''' <summary>
        ''' 單位成本
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CostUnitCost As Double
            Get
                Return Me.SKB09 / Me.SKB08
            End Get
        End Property
#End Region
#Region "單位變動成本 屬性:VariableUnitCost"
        ''' <summary>
        ''' 單位變動成本
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property VariableUnitCost As Double
            Get
                Return Me.VariableCost / Me.SKB08
            End Get
        End Property
#End Region
#Region "單位固定成本 屬性:FixedUnitCost"
        ''' <summary>
        ''' 單位固定成本
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property FixedUnitCost As Double
            Get
                Return Me.FixedCost / Me.SKB08
            End Get
        End Property
#End Region
#Region "變動成本 屬性:VariableCost"
        ''' <summary>
        ''' 變動成本
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property VariableCost As Double
            Get
                Return Me.SKB20 + Me.SKB21 + Me.SKB22 + Me.SKB23 + Me.SKB24 + Me.SKB25 + Me.SKB26 + Me.SKB27 + Me.SKB28 + Me.SKB29 + Me.SKB31
            End Get
        End Property
#End Region
#Region "固定成本 屬性:FixedCost"
        ''' <summary>
        ''' 固定成本
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property FixedCost As Double
            Get
                Return Me.SKB09 - Me.VariableCost
            End Get
        End Property
#End Region

    End Class
End Namespace