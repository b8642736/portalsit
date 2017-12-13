Namespace TESTKUKU
    Public Class PPSBLAPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("TESTKUKU", GetType(PPSBLAPF).Name)
        End Sub

#Region "BLACK COIL NO-CSC NO 屬性:BLA01"
        Private _BLA01 As System.String
        ''' <summary>
        ''' BLACK COIL NO-CSC NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property BLA01() As System.String
            Get
                Return _BLA01
            End Get
            Set(ByVal value As System.String)
                _BLA01 = value
            End Set
        End Property
#End Region
#Region "GRADE 屬性:BLA02"
        Private _BLA02 As System.String
        ''' <summary>
        ''' GRADE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA02() As System.String
            Get
                Return _BLA02
            End Get
            Set(ByVal value As System.String)
                _BLA02 = value
            End Set
        End Property
#End Region
#Region "GAUGE,UNIT-M/M 屬性:BLA03"
        Private _BLA03 As System.Single
        ''' <summary>
        ''' GAUGE,UNIT-M/M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA03() As System.Single
            Get
                Return _BLA03
            End Get
            Set(ByVal value As System.Single)
                _BLA03 = value
            End Set
        End Property
#End Region
#Region "WIDTH,UNIT-M/M 屬性:BLA04"
        Private _BLA04 As System.Int32
        ''' <summary>
        ''' WIDTH,UNIT-M/M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA04() As System.Int32
            Get
                Return _BLA04
            End Get
            Set(ByVal value As System.Int32)
                _BLA04 = value
            End Set
        End Property
#End Region
#Region "LENGTH,UNIT-M 屬性:BLA05"
        Private _BLA05 As System.Int32
        ''' <summary>
        ''' LENGTH,UNIT-M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA05() As System.Int32
            Get
                Return _BLA05
            End Get
            Set(ByVal value As System.Int32)
                _BLA05 = value
            End Set
        End Property
#End Region
#Region "WEIGHT,UNIT-KG 屬性:BLA06"
        Private _BLA06 As System.Int32
        ''' <summary>
        ''' WEIGHT,UNIT-KG
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA06() As System.Int32
            Get
                Return _BLA06
            End Get
            Set(ByVal value As System.Int32)
                _BLA06 = value
            End Set
        End Property
#End Region
#Region "SLAB NO 屬性:BLA07"
        Private _BLA07 As System.String
        ''' <summary>
        ''' SLAB NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA07() As System.String
            Get
                Return _BLA07
            End Get
            Set(ByVal value As System.String)
                _BLA07 = value
            End Set
        End Property
#End Region
#Region "BLACK COIL CHECK-IN DATE 屬性:BLA08"
        Private _BLA08 As System.Int32
        ''' <summary>
        ''' BLACK COIL CHECK-IN DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA08() As System.Int32
            Get
                Return _BLA08
            End Get
            Set(ByVal value As System.Int32)
                _BLA08 = value
            End Set
        End Property
#End Region
#Region "BUILD-UP NO 屬性:BLA09"
        Private _BLA09 As System.String
        ''' <summary>
        ''' BUILD-UP NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA09() As System.String
            Get
                Return _BLA09
            End Get
            Set(ByVal value As System.String)
                _BLA09 = value
            End Set
        End Property
#End Region
#Region "BUILD-UP SEQUENCE NO 屬性:BLA10"
        Private _BLA10 As System.String
        ''' <summary>
        ''' BUILD-UP SEQUENCE NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA10() As System.String
            Get
                Return _BLA10
            End Get
            Set(ByVal value As System.String)
                _BLA10 = value
            End Set
        End Property
#End Region
#Region "LOTS NO 屬性:BLA11"
        Private _BLA11 As System.String
        ''' <summary>
        ''' LOTS NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property BLA11() As System.String
            Get
                Return _BLA11
            End Get
            Set(ByVal value As System.String)
                _BLA11 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:BLA12"
        Private _BLA12 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA12() As System.String
            Get
                Return _BLA12
            End Get
            Set(ByVal value As System.String)
                _BLA12 = value
            End Set
        End Property
#End Region
#Region "爐代 屬性:BLA13"
        Private _BLA13 As System.String
        ''' <summary>
        ''' 爐代
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA13() As System.String
            Get
                Return _BLA13
            End Get
            Set(ByVal value As System.String)
                _BLA13 = value
            End Set
        End Property
#End Region
#Region "CODE-3 屬性:BLA14"
        Private _BLA14 As System.String
        ''' <summary>
        ''' CODE-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA14() As System.String
            Get
                Return _BLA14
            End Get
            Set(ByVal value As System.String)
                _BLA14 = value
            End Set
        End Property
#End Region
#Region "CODE-4 屬性:BLA15"
        Private _BLA15 As System.String
        ''' <summary>
        ''' CODE-4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA15() As System.String
            Get
                Return _BLA15
            End Get
            Set(ByVal value As System.String)
                _BLA15 = value
            End Set
        End Property
#End Region
#Region "CODE-5 屬性:BLA16"
        Private _BLA16 As System.String
        ''' <summary>
        ''' CODE-5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA16() As System.String
            Get
                Return _BLA16
            End Get
            Set(ByVal value As System.String)
                _BLA16 = value
            End Set
        End Property
#End Region
#Region "SCHEDULE NO 屬性:BLA17"
        Private _BLA17 As System.String
        ''' <summary>
        ''' SCHEDULE NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA17() As System.String
            Get
                Return _BLA17
            End Get
            Set(ByVal value As System.String)
                _BLA17 = value
            End Set
        End Property
#End Region
#Region "GRADE SPECIAL TYPE 屬性:BLA18"
        Private _BLA18 As System.String
        ''' <summary>
        ''' GRADE SPECIAL TYPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BLA18() As System.String
            Get
                Return _BLA18
            End Get
            Set(ByVal value As System.String)
                _BLA18 = value
            End Set
        End Property
#End Region
    End Class
End Namespace