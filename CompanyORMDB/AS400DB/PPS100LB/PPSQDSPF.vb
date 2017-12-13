Namespace PPS100LB
    ''' <summary>
    ''' 鋼捲檢驗記錄檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSQDSPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSQDSPF).Name)
        End Sub

#Region "LINE 屬性:QDS01"
        Private _QDS01 As System.String
        ''' <summary>
        ''' LINE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDS01() As System.String
            Get
                Return _QDS01
            End Get
            Set(ByVal value As System.String)
                _QDS01 = value
            End Set
        End Property
#End Region
#Region "COIL-NO 屬性:QDS02"
        Private _QDS02 As System.String
        ''' <summary>
        ''' COIL-NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDS02() As System.String
            Get
                Return _QDS02
            End Get
            Set(ByVal value As System.String)
                _QDS02 = value
            End Set
        End Property
#End Region
#Region "COIL BROKEN-NO 屬性:QDS03"
        Private _QDS03 As System.String
        ''' <summary>
        ''' COIL BROKEN-NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDS03() As System.String
            Get
                Return _QDS03
            End Get
            Set(ByVal value As System.String)
                _QDS03 = value
            End Set
        End Property
#End Region
#Region "DATE 屬性:QDS04"
        Private _QDS04 As System.Int32
        ''' <summary>
        ''' DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDS04() As System.Int32
            Get
                Return _QDS04
            End Get
            Set(ByVal value As System.Int32)
                _QDS04 = value
            End Set
        End Property
#End Region
#Region "FINISH 屬性:QDS05"
        Private _QDS05 As System.String
        ''' <summary>
        ''' FINISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS05() As System.String
            Get
                Return _QDS05
            End Get
            Set(ByVal value As System.String)
                _QDS05 = value
            End Set
        End Property
#End Region
#Region "FINISH STATUS 屬性:QDS06"
        Private _QDS06 As System.String
        ''' <summary>
        ''' FINISH STATUS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS06() As System.String
            Get
                Return _QDS06
            End Get
            Set(ByVal value As System.String)
                _QDS06 = value
            End Set
        End Property
#End Region
#Region "INSPECTOR-1 屬性:QDS07"
        Private _QDS07 As System.String
        ''' <summary>
        ''' INSPECTOR-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS07() As System.String
            Get
                Return _QDS07
            End Get
            Set(ByVal value As System.String)
                _QDS07 = value
            End Set
        End Property
#End Region
#Region "INSPECTOR-2 屬性:QDS08"
        Private _QDS08 As System.String
        ''' <summary>
        ''' INSPECTOR-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS08() As System.String
            Get
                Return _QDS08
            End Get
            Set(ByVal value As System.String)
                _QDS08 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE GUADE-1 屬性:QDS09"
        Private _QDS09 As System.Single
        ''' <summary>
        ''' ADMEASURE GUADE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS09() As System.Single
            Get
                Return _QDS09
            End Get
            Set(ByVal value As System.Single)
                _QDS09 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE WIDTH-1 屬性:QDS10"
        Private _QDS10 As System.Int32
        ''' <summary>
        ''' ADMEASURE WIDTH-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS10() As System.Int32
            Get
                Return _QDS10
            End Get
            Set(ByVal value As System.Int32)
                _QDS10 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE LENGTH-1 屬性:QDS11"
        Private _QDS11 As System.Int32
        ''' <summary>
        ''' ADMEASURE LENGTH-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS11() As System.Int32
            Get
                Return _QDS11
            End Get
            Set(ByVal value As System.Int32)
                _QDS11 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE GUADE-2 屬性:QDS12"
        Private _QDS12 As System.Single
        ''' <summary>
        ''' ADMEASURE GUADE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS12() As System.Single
            Get
                Return _QDS12
            End Get
            Set(ByVal value As System.Single)
                _QDS12 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE WIDTH-2 屬性:QDS13"
        Private _QDS13 As System.Int32
        ''' <summary>
        ''' ADMEASURE WIDTH-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS13() As System.Int32
            Get
                Return _QDS13
            End Get
            Set(ByVal value As System.Int32)
                _QDS13 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE LENGTH-2 屬性:QDS14"
        Private _QDS14 As System.Int32
        ''' <summary>
        ''' ADMEASURE LENGTH-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS14() As System.Int32
            Get
                Return _QDS14
            End Get
            Set(ByVal value As System.Int32)
                _QDS14 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE GUADE-3 屬性:QDS15"
        Private _QDS15 As System.Single
        ''' <summary>
        ''' ADMEASURE GUADE-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS15() As System.Single
            Get
                Return _QDS15
            End Get
            Set(ByVal value As System.Single)
                _QDS15 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE WIDTH-3 屬性:QDS16"
        Private _QDS16 As System.Int32
        ''' <summary>
        ''' ADMEASURE WIDTH-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS16() As System.Int32
            Get
                Return _QDS16
            End Get
            Set(ByVal value As System.Int32)
                _QDS16 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE LENGTH-3 屬性:QDS17"
        Private _QDS17 As System.Int32
        ''' <summary>
        ''' ADMEASURE LENGTH-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS17() As System.Int32
            Get
                Return _QDS17
            End Get
            Set(ByVal value As System.Int32)
                _QDS17 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE GUADE-4 屬性:QDS18"
        Private _QDS18 As System.Single
        ''' <summary>
        ''' ADMEASURE GUADE-4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS18() As System.Single
            Get
                Return _QDS18
            End Get
            Set(ByVal value As System.Single)
                _QDS18 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE WIDTH-4 屬性:QDS19"
        Private _QDS19 As System.Int32
        ''' <summary>
        ''' ADMEASURE WIDTH-4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS19() As System.Int32
            Get
                Return _QDS19
            End Get
            Set(ByVal value As System.Int32)
                _QDS19 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE LENGTH-4 屬性:QDS20"
        Private _QDS20 As System.Int32
        ''' <summary>
        ''' ADMEASURE LENGTH-4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS20() As System.Int32
            Get
                Return _QDS20
            End Get
            Set(ByVal value As System.Int32)
                _QDS20 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE GUADE-5 屬性:QDS21"
        Private _QDS21 As System.Single
        ''' <summary>
        ''' ADMEASURE GUADE-5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS21() As System.Single
            Get
                Return _QDS21
            End Get
            Set(ByVal value As System.Single)
                _QDS21 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE WIDTH-5 屬性:QDS22"
        Private _QDS22 As System.Int32
        ''' <summary>
        ''' ADMEASURE WIDTH-5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS22() As System.Int32
            Get
                Return _QDS22
            End Get
            Set(ByVal value As System.Int32)
                _QDS22 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE LENGTH-5 屬性:QDS23"
        Private _QDS23 As System.Int32
        ''' <summary>
        ''' ADMEASURE LENGTH-5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS23() As System.Int32
            Get
                Return _QDS23
            End Get
            Set(ByVal value As System.Int32)
                _QDS23 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE GUADE-6 屬性:QDS24"
        Private _QDS24 As System.Single
        ''' <summary>
        ''' ADMEASURE GUADE-6
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS24() As System.Single
            Get
                Return _QDS24
            End Get
            Set(ByVal value As System.Single)
                _QDS24 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE WIDTH-6 屬性:QDS25"
        Private _QDS25 As System.Int32
        ''' <summary>
        ''' ADMEASURE WIDTH-6
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS25() As System.Int32
            Get
                Return _QDS25
            End Get
            Set(ByVal value As System.Int32)
                _QDS25 = value
            End Set
        End Property
#End Region
#Region "ADMEASURE LENGTH-6 屬性:QDS26"
        Private _QDS26 As System.Int32
        ''' <summary>
        ''' ADMEASURE LENGTH-6
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS26() As System.Int32
            Get
                Return _QDS26
            End Get
            Set(ByVal value As System.Int32)
                _QDS26 = value
            End Set
        End Property
#End Region
#Region "Q.C JUDGEMENT STATUS 屬性:QDS27"
        Private _QDS27 As System.String
        ''' <summary>
        ''' Q.C JUDGEMENT STATUS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS27() As System.String
            Get
                Return _QDS27
            End Get
            Set(ByVal value As System.String)
                _QDS27 = value
            End Set
        End Property
#End Region
#Region "PURPOSE 屬性:QDS28"
        Private _QDS28 As System.String
        ''' <summary>
        ''' PURPOSE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS28() As System.String
            Get
                Return _QDS28
            End Get
            Set(ByVal value As System.String)
                _QDS28 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS29"
        Private _QDS29 As System.String
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS29() As System.String
            Get
                Return _QDS29
            End Get
            Set(ByVal value As System.String)
                _QDS29 = value
            End Set
        End Property
#End Region
#Region "REAL LENGTH 屬性:QDS30"
        Private _QDS30 As System.Int32
        ''' <summary>
        ''' REAL LENGTH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS30() As System.Int32
            Get
                Return _QDS30
            End Get
            Set(ByVal value As System.Int32)
                _QDS30 = value
            End Set
        End Property
#End Region
#Region "SEND STATUS 屬性:QDS31"
        Private _QDS31 As System.String
        ''' <summary>
        ''' SEND STATUS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS31() As System.String
            Get
                Return _QDS31
            End Get
            Set(ByVal value As System.String)
                _QDS31 = value
            End Set
        End Property
#End Region
#Region "MAIN JUDGEMENT-1 屬性:QDS32"
        Private _QDS32 As System.Int32
        ''' <summary>
        ''' MAIN JUDGEMENT-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS32() As System.Int32
            Get
                Return _QDS32
            End Get
            Set(ByVal value As System.Int32)
                _QDS32 = value
            End Set
        End Property
#End Region
#Region "MAIN JUDGEMENT-2 屬性:QDS33"
        Private _QDS33 As System.Int32
        ''' <summary>
        ''' MAIN JUDGEMENT-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS33() As System.Int32
            Get
                Return _QDS33
            End Get
            Set(ByVal value As System.Int32)
                _QDS33 = value
            End Set
        End Property
#End Region
#Region "MAIN JUDGEMENT-3 屬性:QDS34"
        Private _QDS34 As System.Int32
        ''' <summary>
        ''' MAIN JUDGEMENT-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS34() As System.Int32
            Get
                Return _QDS34
            End Get
            Set(ByVal value As System.Int32)
                _QDS34 = value
            End Set
        End Property
#End Region
#Region "MAIN JUDGEMENT-4 屬性:QDS35"
        Private _QDS35 As System.Int32
        ''' <summary>
        ''' MAIN JUDGEMENT-4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS35() As System.Int32
            Get
                Return _QDS35
            End Get
            Set(ByVal value As System.Int32)
                _QDS35 = value
            End Set
        End Property
#End Region
#Region "MAIN JUDGEMENT-5 屬性:QDS36"
        Private _QDS36 As System.Int32
        ''' <summary>
        ''' MAIN JUDGEMENT-5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS36() As System.Int32
            Get
                Return _QDS36
            End Get
            Set(ByVal value As System.Int32)
                _QDS36 = value
            End Set
        End Property
#End Region
#Region "REAL WEIGHT 屬性:QDS37"
        Private _QDS37 As System.Int32
        ''' <summary>
        ''' REAL WEIGHT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS37() As System.Int32
            Get
                Return _QDS37
            End Get
            Set(ByVal value As System.Int32)
                _QDS37 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:QDS38"
        Private _QDS38 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS38() As System.String
            Get
                Return _QDS38
            End Get
            Set(ByVal value As System.String)
                _QDS38 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:QDS39"
        Private _QDS39 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS39() As System.String
            Get
                Return _QDS39
            End Get
            Set(ByVal value As System.String)
                _QDS39 = value
            End Set
        End Property
#End Region
#Region "CODE-3 屬性:QDS40"
        Private _QDS40 As System.String
        ''' <summary>
        ''' CODE-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS40() As System.String
            Get
                Return _QDS40
            End Get
            Set(ByVal value As System.String)
                _QDS40 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS41"
        Private _QDS41 As System.Int32
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS41() As System.Int32
            Get
                Return _QDS41
            End Get
            Set(ByVal value As System.Int32)
                _QDS41 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS42"
        Private _QDS42 As System.Int32
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS42() As System.Int32
            Get
                Return _QDS42
            End Get
            Set(ByVal value As System.Int32)
                _QDS42 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS43"
        Private _QDS43 As System.Int32
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS43() As System.Int32
            Get
                Return _QDS43
            End Get
            Set(ByVal value As System.Int32)
                _QDS43 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS44"
        Private _QDS44 As System.Int32
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS44() As System.Int32
            Get
                Return _QDS44
            End Get
            Set(ByVal value As System.Int32)
                _QDS44 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS45"
        Private _QDS45 As System.Int32
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS45() As System.Int32
            Get
                Return _QDS45
            End Get
            Set(ByVal value As System.Int32)
                _QDS45 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS46"
        Private _QDS46 As System.Int32
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS46() As System.Int32
            Get
                Return _QDS46
            End Get
            Set(ByVal value As System.Int32)
                _QDS46 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS47"
        Private _QDS47 As System.Int32
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS47() As System.Int32
            Get
                Return _QDS47
            End Get
            Set(ByVal value As System.Int32)
                _QDS47 = value
            End Set
        End Property
#End Region
#Region "BURNISH 屬性:QDS48"
        Private _QDS48 As System.Int32
        ''' <summary>
        ''' BURNISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS48() As System.Int32
            Get
                Return _QDS48
            End Get
            Set(ByVal value As System.Int32)
                _QDS48 = value
            End Set
        End Property
#End Region
#Region "AVERAGE 屬性:QDS49"
        Private _QDS49 As System.Int32
        ''' <summary>
        ''' AVERAGE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS49() As System.Int32
            Get
                Return _QDS49
            End Get
            Set(ByVal value As System.Int32)
                _QDS49 = value
            End Set
        End Property
#End Region
#Region "DIFF 屬性:QDS50"
        Private _QDS50 As System.Int32
        ''' <summary>
        ''' DIFF
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDS50() As System.Int32
            Get
                Return _QDS50
            End Get
            Set(ByVal value As System.Int32)
                _QDS50 = value
            End Set
        End Property
#End Region
    End Class
End Namespace