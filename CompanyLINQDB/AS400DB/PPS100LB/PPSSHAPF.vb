Namespace PPS100LB
    ''' <summary>
    ''' P.P.排程檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSSHAPF
        Inherits ClassDB

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSSHAPF).Name)
        End Sub

#Region "BUILD-UP NO 屬性:SHA01"
        Private _SHA01 As System.String
        ''' <summary>
        ''' BUILD-UP NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SHA01() As System.String
            Get
                Return _SHA01
            End Get
            Set(ByVal value As System.String)
                _SHA01 = value
            End Set
        End Property
#End Region
#Region "COIL BROKEN NO 屬性:SHA02"
        Private _SHA02 As System.String
        ''' <summary>
        ''' COIL BROKEN NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SHA02() As System.String
            Get
                Return _SHA02
            End Get
            Set(ByVal value As System.String)
                _SHA02 = value
            End Set
        End Property
#End Region
#Region "BUILD-UP SERIES NO 屬性:SHA03"
        Private _SHA03 As System.String
        ''' <summary>
        ''' BUILD-UP SERIES NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA03() As System.String
            Get
                Return _SHA03
            End Get
            Set(ByVal value As System.String)
                _SHA03 = value
            End Set
        End Property
#End Region
#Region "SCHEDULING SERIES 屬性:SHA04"
        Private _SHA04 As System.Int32
        ''' <summary>
        ''' SCHEDULING SERIES
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SHA04() As System.Int32
            Get
                Return _SHA04
            End Get
            Set(ByVal value As System.Int32)
                _SHA04 = value
            End Set
        End Property
#End Region
#Region "PLANNING GAUGE-M/M+ 屬性:SHA05"
        Private _SHA05 As System.String
        ''' <summary>
        ''' PLANNING GAUGE-M/M+
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA05() As System.String
            Get
                Return _SHA05
            End Get
            Set(ByVal value As System.String)
                _SHA05 = value
            End Set
        End Property
#End Region
#Region "REAL FINISH 屬性:SHA06"
        Private _SHA06 As System.String
        ''' <summary>
        ''' REAL FINISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA06() As System.String
            Get
                Return _SHA06
            End Get
            Set(ByVal value As System.String)
                _SHA06 = value
            End Set
        End Property
#End Region
#Region "PLANNING GAUGE-M/M+FOR FINAL PRODUCTS 屬性:SHA07"
        Private _SHA07 As System.String
        ''' <summary>
        ''' PLANNING GAUGE-M/M+FOR FINAL PRODUCTS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA07() As System.String
            Get
                Return _SHA07
            End Get
            Set(ByVal value As System.String)
                _SHA07 = value
            End Set
        End Property
#End Region
#Region "OPERATION LINE 屬性:SHA08"
        Private _SHA08 As System.String
        ''' <summary>
        ''' OPERATION LINE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA08() As System.String
            Get
                Return _SHA08
            End Get
            Set(ByVal value As System.String)
                _SHA08 = value
            End Set
        End Property
#End Region
#Region "CLASS 屬性:SHA09"
        Private _SHA09 As System.String
        ''' <summary>
        ''' CLASS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA09() As System.String
            Get
                Return _SHA09
            End Get
            Set(ByVal value As System.String)
                _SHA09 = value
            End Set
        End Property
#End Region
#Region "SCHEDULING NO 屬性:SHA10"
        Private _SHA10 As System.String
        ''' <summary>
        ''' SCHEDULING NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA10() As System.String
            Get
                Return _SHA10
            End Get
            Set(ByVal value As System.String)
                _SHA10 = value
            End Set
        End Property
#End Region
#Region "SCHEDULING DATE 屬性:SHA11"
        Private _SHA11 As System.Int32
        ''' <summary>
        ''' SCHEDULING DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA11() As System.Int32
            Get
                Return _SHA11
            End Get
            Set(ByVal value As System.Int32)
                _SHA11 = value
            End Set
        End Property
#End Region
#Region "GRADE 屬性:SHA12"
        Private _SHA12 As System.String
        ''' <summary>
        ''' GRADE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA12() As System.String
            Get
                Return _SHA12
            End Get
            Set(ByVal value As System.String)
                _SHA12 = value
            End Set
        End Property
#End Region
#Region "GRADE TYPE 屬性:SHA13"
        Private _SHA13 As System.String
        ''' <summary>
        ''' GRADE TYPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA13() As System.String
            Get
                Return _SHA13
            End Get
            Set(ByVal value As System.String)
                _SHA13 = value
            End Set
        End Property
#End Region
#Region "GUAGE 屬性:SHA14"
        Private _SHA14 As System.Int32
        ''' <summary>
        ''' GUAGE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA14() As System.Int32
            Get
                Return _SHA14
            End Get
            Set(ByVal value As System.Int32)
                _SHA14 = value
            End Set
        End Property
#End Region
#Region "WIDTH 屬性:SHA15"
        Private _SHA15 As System.Int32
        ''' <summary>
        ''' WIDTH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA15() As System.Int32
            Get
                Return _SHA15
            End Get
            Set(ByVal value As System.Int32)
                _SHA15 = value
            End Set
        End Property
#End Region
#Region "LENGTH 屬性:SHA16"
        Private _SHA16 As System.Int32
        ''' <summary>
        ''' LENGTH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA16() As System.Int32
            Get
                Return _SHA16
            End Get
            Set(ByVal value As System.Int32)
                _SHA16 = value
            End Set
        End Property
#End Region
#Region "WEIGHT 屬性:SHA17"
        Private _SHA17 As System.Int32
        ''' <summary>
        ''' WEIGHT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA17() As System.Int32
            Get
                Return _SHA17
            End Get
            Set(ByVal value As System.Int32)
                _SHA17 = value
            End Set
        End Property
#End Region
#Region "RETURN 屬性:SHA18"
        Private _SHA18 As System.Int32
        ''' <summary>
        ''' RETURN
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA18() As System.Int32
            Get
                Return _SHA18
            End Get
            Set(ByVal value As System.Int32)
                _SHA18 = value
            End Set
        End Property
#End Region
#Region "SCALE 屬性:SHA19"
        Private _SHA19 As System.Int32
        ''' <summary>
        ''' SCALE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA19() As System.Int32
            Get
                Return _SHA19
            End Get
            Set(ByVal value As System.Int32)
                _SHA19 = value
            End Set
        End Property
#End Region
#Region "OTHER 屬性:SHA20"
        Private _SHA20 As System.Int32
        ''' <summary>
        ''' OTHER
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA20() As System.Int32
            Get
                Return _SHA20
            End Get
            Set(ByVal value As System.Int32)
                _SHA20 = value
            End Set
        End Property
#End Region
#Region "FINISH DATE 屬性:SHA21"
        Private _SHA21 As System.Int32
        ''' <summary>
        ''' FINISH DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA21() As System.Int32
            Get
                Return _SHA21
            End Get
            Set(ByVal value As System.Int32)
                _SHA21 = value
            End Set
        End Property
#End Region
#Region "START TIME-HOUR 屬性:SHA22"
        Private _SHA22 As System.Int32
        ''' <summary>
        ''' START TIME-HOUR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA22() As System.Int32
            Get
                Return _SHA22
            End Get
            Set(ByVal value As System.Int32)
                _SHA22 = value
            End Set
        End Property
#End Region
#Region "START TIME-MINIUTE 屬性:SHA23"
        Private _SHA23 As System.Int32
        ''' <summary>
        ''' START TIME-MINIUTE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA23() As System.Int32
            Get
                Return _SHA23
            End Get
            Set(ByVal value As System.Int32)
                _SHA23 = value
            End Set
        End Property
#End Region
#Region "FINISH TIME-HOUR 屬性:SHA24"
        Private _SHA24 As System.Int32
        ''' <summary>
        ''' FINISH TIME-HOUR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA24() As System.Int32
            Get
                Return _SHA24
            End Get
            Set(ByVal value As System.Int32)
                _SHA24 = value
            End Set
        End Property
#End Region
#Region "FINISH TIME-MINIUTE 屬性:SHA25"
        Private _SHA25 As System.Int32
        ''' <summary>
        ''' FINISH TIME-MINIUTE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA25() As System.Int32
            Get
                Return _SHA25
            End Get
            Set(ByVal value As System.Int32)
                _SHA25 = value
            End Set
        End Property
#End Region
#Region "ＧＰ研磨次數 屬性:SHA26"
        Private _SHA26 As System.String
        ''' <summary>
        ''' ＧＰ研磨次數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA26() As System.String
            Get
                Return _SHA26
            End Get
            Set(ByVal value As System.String)
                _SHA26 = value
            End Set
        End Property
#End Region
#Region "NEXT OPERATION LINE 屬性:SHA27"
        Private _SHA27 As System.String
        ''' <summary>
        ''' NEXT OPERATION LINE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA27() As System.String
            Get
                Return _SHA27
            End Get
            Set(ByVal value As System.String)
                _SHA27 = value
            End Set
        End Property
#End Region
#Region "CODE1 屬性:SHA28"
        Private _SHA28 As System.String
        ''' <summary>
        ''' CODE1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA28() As System.String
            Get
                Return _SHA28
            End Get
            Set(ByVal value As System.String)
                _SHA28 = value
            End Set
        End Property
#End Region
#Region "CODE2 屬性:SHA29"
        Private _SHA29 As System.String
        ''' <summary>
        ''' CODE2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA29() As System.String
            Get
                Return _SHA29
            End Get
            Set(ByVal value As System.String)
                _SHA29 = value
            End Set
        End Property
#End Region
#Region "CODE3 屬性:SHA30"
        Private _SHA30 As System.String
        ''' <summary>
        ''' CODE3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA30() As System.String
            Get
                Return _SHA30
            End Get
            Set(ByVal value As System.String)
                _SHA30 = value
            End Set
        End Property
#End Region
#Region "子厚度範圍 屬性:SHA31"
        Private _SHA31 As System.String
        ''' <summary>
        ''' 子厚度範圍
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA31() As System.String
            Get
                Return _SHA31
            End Get
            Set(ByVal value As System.String)
                _SHA31 = value
            End Set
        End Property
#End Region
#Region "特用 屬性:SHA32"
        Private _SHA32 As System.String
        ''' <summary>
        ''' 特用("A"品管指定特殊用途鋼捲)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA32() As System.String
            Get
                Return _SHA32
            End Get
            Set(ByVal value As System.String)
                _SHA32 = value
            End Set
        End Property
#End Region
#Region "STANDARD GAUGE 屬性:SHA33"
        Private _SHA33 As System.String
        ''' <summary>
        ''' STANDARD GAUGE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA33() As System.String
            Get
                Return _SHA33
            End Get
            Set(ByVal value As System.String)
                _SHA33 = value
            End Set
        End Property
#End Region
#Region "STANDARD WIDTH 屬性:SHA34"
        Private _SHA34 As System.Int32
        ''' <summary>
        ''' STANDARD WIDTH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA34() As System.Int32
            Get
                Return _SHA34
            End Get
            Set(ByVal value As System.Int32)
                _SHA34 = value
            End Set
        End Property
#End Region
#Region "EXPORT 屬性:SHA35"
        Private _SHA35 As System.String
        ''' <summary>
        ''' EXPORT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA35() As System.String
            Get
                Return _SHA35
            End Get
            Set(ByVal value As System.String)
                _SHA35 = value
            End Set
        End Property
#End Region
#Region "PIPE 屬性:SHA36"
        Private _SHA36 As System.String
        ''' <summary>
        ''' PIPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA36() As System.String
            Get
                Return _SHA36
            End Get
            Set(ByVal value As System.String)
                _SHA36 = value
            End Set
        End Property
#End Region
#Region "TEST 屬性:SHA37"
        Private _SHA37 As System.String
        ''' <summary>
        ''' TEST("R"退回加工後交還客戶)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA37() As System.String
            Get
                Return _SHA37
            End Get
            Set(ByVal value As System.String)
                _SHA37 = value
            End Set
        End Property
#End Region
#Region "SHEET QUANTITY 屬性:SHA38"
        Private _SHA38 As System.Int32
        ''' <summary>
        ''' SHEET QUANTITY
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA38() As System.Int32
            Get
                Return _SHA38
            End Get
            Set(ByVal value As System.Int32)
                _SHA38 = value
            End Set
        End Property
#End Region
#Region "PLANNING FINISH 屬性:SHA39"
        Private _SHA39 As System.String
        ''' <summary>
        ''' PLANNING FINISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA39() As System.String
            Get
                Return _SHA39
            End Get
            Set(ByVal value As System.String)
                _SHA39 = value
            End Set
        End Property
#End Region
    End Class

End Namespace
