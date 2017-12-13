Namespace SLS300LB
    ''' <summary>
    ''' 報價單標題資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2QTAPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2QTAPF).Name)
        End Sub

#Region "客戶 屬性:QTA01"
        Private _QTA01 As System.String
        ''' <summary>
        ''' 客戶
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTA01() As System.String
            Get
                Return _QTA01
            End Get
            Set(ByVal value As System.String)
                _QTA01 = value
            End Set
        End Property
#End Region
#Region "報價單 屬性:QTA02"
        Private _QTA02 As System.String
        ''' <summary>
        ''' 報價單
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QTA02() As System.String
            Get
                Return _QTA02
            End Get
            Set(ByVal value As System.String)
                _QTA02 = value
            End Set
        End Property
#End Region
#Region "材證廠商 屬性:QTA11"
        Private _QTA11 As System.String
        ''' <summary>
        ''' 材證廠商
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA11() As System.String
            Get
                Return _QTA11
            End Get
            Set(ByVal value As System.String)
                _QTA11 = value
            End Set
        End Property
#End Region
#Region "STANDARD 屬性:QTA12"
        Private _QTA12 As System.String
        ''' <summary>
        ''' STANDARD
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA12() As System.String
            Get
                Return _QTA12
            End Get
            Set(ByVal value As System.String)
                _QTA12 = value
            End Set
        End Property
#End Region
#Region "日期1 屬性:QTA21"
        Private _QTA21 As System.String
        ''' <summary>
        ''' 日期1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA21() As System.String
            Get
                Return _QTA21
            End Get
            Set(ByVal value As System.String)
                _QTA21 = value
            End Set
        End Property
#End Region
#Region "日期2 屬性:QTA22"
        Private _QTA22 As System.String
        ''' <summary>
        ''' 日期2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA22() As System.String
            Get
                Return _QTA22
            End Get
            Set(ByVal value As System.String)
                _QTA22 = value
            End Set
        End Property
#End Region
#Region "日期3 屬性:QTA23"
        Private _QTA23 As System.String
        ''' <summary>
        ''' 日期3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA23() As System.String
            Get
                Return _QTA23
            End Get
            Set(ByVal value As System.String)
                _QTA23 = value
            End Set
        End Property
#End Region
#Region "日期4 屬性:QTA24"
        Private _QTA24 As System.String
        ''' <summary>
        ''' 日期4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA24() As System.String
            Get
                Return _QTA24
            End Get
            Set(ByVal value As System.String)
                _QTA24 = value
            End Set
        End Property
#End Region
#Region "日期5 屬性:QTA25"
        Private _QTA25 As System.String
        ''' <summary>
        ''' 日期5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA25() As System.String
            Get
                Return _QTA25
            End Get
            Set(ByVal value As System.String)
                _QTA25 = value
            End Set
        End Property
#End Region
#Region "日期6 屬性:QTA26"
        Private _QTA26 As System.String
        ''' <summary>
        ''' 日期6
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA26() As System.String
            Get
                Return _QTA26
            End Get
            Set(ByVal value As System.String)
                _QTA26 = value
            End Set
        End Property
#End Region
#Region "日期7 屬性:QTA27"
        Private _QTA27 As System.String
        ''' <summary>
        ''' 日期7
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA27() As System.String
            Get
                Return _QTA27
            End Get
            Set(ByVal value As System.String)
                _QTA27 = value
            End Set
        End Property
#End Region
#Region "日期8 屬性:QTA28"
        Private _QTA28 As System.String
        ''' <summary>
        ''' 日期8
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA28() As System.String
            Get
                Return _QTA28
            End Get
            Set(ByVal value As System.String)
                _QTA28 = value
            End Set
        End Property
#End Region
#Region "給推貿 屬性:QTA31"
        Private _QTA31 As System.String
        ''' <summary>
        ''' 給推貿
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA31() As System.String
            Get
                Return _QTA31
            End Get
            Set(ByVal value As System.String)
                _QTA31 = value
            End Set
        End Property
#End Region
#Region "給履約 屬性:QTA32"
        Private _QTA32 As System.String
        ''' <summary>
        ''' 給履約
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA32() As System.String
            Get
                Return _QTA32
            End Get
            Set(ByVal value As System.String)
                _QTA32 = value
            End Set
        End Property
#End Region
#Region "給數折 屬性:QTA33"
        Private _QTA33 As System.String
        ''' <summary>
        ''' 給數折
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA33() As System.String
            Get
                Return _QTA33
            End Get
            Set(ByVal value As System.String)
                _QTA33 = value
            End Set
        End Property
#End Region
#Region "給結退 屬性:QTA34"
        Private _QTA34 As System.String
        ''' <summary>
        ''' 給結退
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA34() As System.String
            Get
                Return _QTA34
            End Get
            Set(ByVal value As System.String)
                _QTA34 = value
            End Set
        End Property
#End Region
#Region "公稱 屬性:QTA35"
        Private _QTA35 As System.String
        ''' <summary>
        ''' 公稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA35() As System.String
            Get
                Return _QTA35
            End Get
            Set(ByVal value As System.String)
                _QTA35 = value
            End Set
        End Property
#End Region
#Region "印厚度 屬性:QTA36"
        Private _QTA36 As System.String
        ''' <summary>
        ''' 印厚度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA36() As System.String
            Get
                Return _QTA36
            End Get
            Set(ByVal value As System.String)
                _QTA36 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:QTA91"
        Private _QTA91 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA91() As System.String
            Get
                Return _QTA91
            End Get
            Set(ByVal value As System.String)
                _QTA91 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:QTA92"
        Private _QTA92 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA92() As System.String
            Get
                Return _QTA92
            End Get
            Set(ByVal value As System.String)
                _QTA92 = value
            End Set
        End Property
#End Region
#Region "CODE-3 屬性:QTA93"
        Private _QTA93 As System.String
        ''' <summary>
        ''' CODE-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA93() As System.String
            Get
                Return _QTA93
            End Get
            Set(ByVal value As System.String)
                _QTA93 = value
            End Set
        End Property
#End Region
#Region "CODE-4 屬性:QTA94"
        Private _QTA94 As System.String
        ''' <summary>
        ''' CODE-4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA94() As System.String
            Get
                Return _QTA94
            End Get
            Set(ByVal value As System.String)
                _QTA94 = value
            End Set
        End Property
#End Region
#Region "CODE-5 屬性:QTA95"
        Private _QTA95 As System.String
        ''' <summary>
        ''' CODE-5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA95() As System.String
            Get
                Return _QTA95
            End Get
            Set(ByVal value As System.String)
                _QTA95 = value
            End Set
        End Property
#End Region
#Region "CODE-6 屬性:QTA96"
        Private _QTA96 As System.String
        ''' <summary>
        ''' CODE-6
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QTA96() As System.String
            Get
                Return _QTA96
            End Get
            Set(ByVal value As System.String)
                _QTA96 = value
            End Set
        End Property
#End Region
    End Class
End Namespace