Namespace PPS100LB
    ''' <summary>
    ''' 鋼捲缺陷記錄
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSQDEPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSQDEPF).Name)
        End Sub

#Region "線別 屬性:QDE01"
        Private _QDE01 As System.String
        ''' <summary>
        ''' 線別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDE01() As System.String
            Get
                Return _QDE01
            End Get
            Set(ByVal value As System.String)
                _QDE01 = value
            End Set
        End Property
#End Region
#Region "鋼捲號碼 屬性:QDE02"
        Private _QDE02 As System.String
        ''' <summary>
        ''' 鋼捲號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDE02() As System.String
            Get
                Return _QDE02
            End Get
            Set(ByVal value As System.String)
                _QDE02 = value
            End Set
        End Property
#End Region
#Region "鋼捲斷捲號碼 屬性:QDE03"
        Private _QDE03 As System.String
        ''' <summary>
        ''' 鋼捲斷捲號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDE03() As System.String
            Get
                Return _QDE03
            End Get
            Set(ByVal value As System.String)
                _QDE03 = value
            End Set
        End Property
#End Region
#Region "日期 屬性:QDE04"
        Private _QDE04 As System.Int32
        ''' <summary>
        ''' 日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDE04() As System.Int32
            Get
                Return _QDE04
            End Get
            Set(ByVal value As System.Int32)
                _QDE04 = value
            End Set
        End Property
#End Region
#Region "本片缺陷代碼 屬性:QDE05"
        Private _QDE05 As System.Int32
        ''' <summary>
        ''' 本片缺陷代碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDE05() As System.Int32
            Get
                Return _QDE05
            End Get
            Set(ByVal value As System.Int32)
                _QDE05 = value
            End Set
        End Property
#End Region
#Region "本片碼序號 屬性:QDE06"
        Private _QDE06 As System.Int32
        ''' <summary>
        ''' 本片碼序號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QDE06() As System.Int32
            Get
                Return _QDE06
            End Get
            Set(ByVal value As System.Int32)
                _QDE06 = value
            End Set
        End Property
#End Region
#Region "缺陷起始長度M 屬性:QDE07"
        Private _QDE07 As System.Int32
        ''' <summary>
        ''' 缺陷起始長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE07() As System.Int32
            Get
                Return _QDE07
            End Get
            Set(ByVal value As System.Int32)
                _QDE07 = value
            End Set
        End Property
#End Region
#Region "缺陷終止長度M 屬性:QDE08"
        Private _QDE08 As System.Int32
        ''' <summary>
        ''' 缺陷終止長度M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE08() As System.Int32
            Get
                Return _QDE08
            End Get
            Set(ByVal value As System.Int32)
                _QDE08 = value
            End Set
        End Property
#End Region
#Region "寬度缺陷程度 屬性:QDE09"
        Private _QDE09 As System.String
        ''' <summary>
        ''' 寬度缺陷程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE09() As System.String
            Get
                Return _QDE09
            End Get
            Set(ByVal value As System.String)
                _QDE09 = value
            End Set
        End Property
#End Region
#Region "缺陷起始寬度 屬性:QDE10"
        Private _QDE10 As System.Int32
        ''' <summary>
        ''' 缺陷起始寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE10() As System.Int32
            Get
                Return _QDE10
            End Get
            Set(ByVal value As System.Int32)
                _QDE10 = value
            End Set
        End Property
#End Region
#Region "缺陷終止寬度 屬性:QDE11"
        Private _QDE11 As System.Int32
        ''' <summary>
        ''' 缺陷終止寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE11() As System.Int32
            Get
                Return _QDE11
            End Get
            Set(ByVal value As System.Int32)
                _QDE11 = value
            End Set
        End Property
#End Region
#Region "缺陷面 屬性:QDE12"
        Private _QDE12 As System.String
        ''' <summary>
        ''' 缺陷面
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE12() As System.String
            Get
                Return _QDE12
            End Get
            Set(ByVal value As System.String)
                _QDE12 = value
            End Set
        End Property
#End Region
#Region "缺陷程度 屬性:QDE13"
        Private _QDE13 As System.String
        ''' <summary>
        ''' 缺陷程度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE13() As System.String
            Get
                Return _QDE13
            End Get
            Set(ByVal value As System.String)
                _QDE13 = value
            End Set
        End Property
#End Region
#Region "面表缺陷狀況 屬性:QDE14"
        Private _QDE14 As System.String
        ''' <summary>
        ''' 面表缺陷狀況
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE14() As System.String
            Get
                Return _QDE14
            End Get
            Set(ByVal value As System.String)
                _QDE14 = value
            End Set
        End Property
#End Region
#Region "週期MM 屬性:QDE15"
        Private _QDE15 As System.Int32
        ''' <summary>
        ''' 週期MM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE15() As System.Int32
            Get
                Return _QDE15
            End Get
            Set(ByVal value As System.Int32)
                _QDE15 = value
            End Set
        End Property
#End Region
#Region "分佈 屬性:QDE16"
        Private _QDE16 As System.Int32
        ''' <summary>
        ''' 分佈
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE16() As System.Int32
            Get
                Return _QDE16
            End Get
            Set(ByVal value As System.Int32)
                _QDE16 = value
            End Set
        End Property
#End Region
#Region "代碼-1 屬性:QDE17"
        Private _QDE17 As System.String
        ''' <summary>
        ''' 代碼-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE17() As System.String
            Get
                Return _QDE17
            End Get
            Set(ByVal value As System.String)
                _QDE17 = value
            End Set
        End Property
#End Region
#Region "代碼-2 屬性:QDE18"
        Private _QDE18 As System.String
        ''' <summary>
        ''' 代碼-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QDE18() As System.String
            Get
                Return _QDE18
            End Get
            Set(ByVal value As System.String)
                _QDE18 = value
            End Set
        End Property
#End Region

#Region "相關PPSBLAPF 屬性:AboutPPSBLAPF"

        Private _AboutPPSBLAPF As PPSBLAPF
        ''' <summary>
        ''' 相關PPSBLAPF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutPPSBLAPF() As PPSBLAPF
            Get
                If IsNothing(_AboutPPSBLAPF) Then
                    'If Not IsNothing(AboutPPSBLAPFCash) AndAlso AboutPPSBLAPFCash.Count > 0 Then
                    '    For Each EachItem As PPSBLAPF In AboutPPSBLAPFCash
                    '        If EachItem.BLA09 = Me.QDE02 AndAlso EachItem.BLA08 <= Me.QDE04 Then
                    '            _AboutPPSBLAPF = EachItem
                    '            Return _AboutPPSBLAPF
                    '        End If
                    '    Next
                    'End If


                    Dim SearchResult As List(Of PPSBLAPF) = PPSBLAPF.CDBSelect(Of PPSBLAPF)("Select * From " & (New PPSBLAPF).CDBFullAS400DBPath & " Where BLA09='" & Me.QDE02 & "' AND BLA08<=" & Me.QDE04 & " Order by BLA08 Desc", Me.CDBCurrentUseSQLQueryAdapter)
                    If SearchResult.Count > 0 Then
                        _AboutPPSBLAPF = SearchResult(0)
                    End If

                End If
                Return _AboutPPSBLAPF
            End Get
            Set(ByVal value As PPSBLAPF)
                _AboutPPSBLAPF = value
            End Set
        End Property

#End Region
        '#Region "相關PPSBLAPF快取 屬性:AboutPPSBLAPFCash"

        '        Private _AboutPPSBLAPFCash As List(Of PPSBLAPF)
        '        ''' <summary>
        '        ''' 相關PPSBLAPF快取
        '        ''' </summary>
        '        ''' <value></value>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        Public Property AboutPPSBLAPFCash() As List(Of PPSBLAPF)
        '            Get
        '                Return _AboutPPSBLAPFCash
        '            End Get
        '            Set(ByVal value As List(Of PPSBLAPF))
        '                _AboutPPSBLAPFCash = value
        '            End Set
        '        End Property

        '#End Region
    End Class
End Namespace