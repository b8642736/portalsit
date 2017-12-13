Namespace SLS300LB
    ''' <summary>
    ''' 牌價基價檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL2PR0PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL2PR0PF).Name)
        End Sub

#Region "年月 屬性:PR001"
        Private _PR001 As System.String
        ''' <summary>
        ''' 年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PR001() As System.String
            Get
                Return _PR001
            End Get
            Set(ByVal value As System.String)
                _PR001 = value
            End Set
        End Property
#End Region
#Region "銷售別 屬性:PR002"
        Private _PR002 As System.String
        ''' <summary>
        ''' 銷售別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PR002() As System.String
            Get
                Return _PR002
            End Get
            Set(ByVal value As System.String)
                _PR002 = value
            End Set
        End Property
#End Region
#Region "鋼種系 屬性:PR003"
        Private _PR003 As System.String
        ''' <summary>
        ''' 鋼種系
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PR003() As System.String
            Get
                Return _PR003
            End Get
            Set(ByVal value As System.String)
                _PR003 = value
            End Set
        End Property
#End Region
#Region "CR/HR 屬性:PR004"
        Private _PR004 As System.String
        ''' <summary>
        ''' CR/HR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property PR004() As System.String
            Get
                Return _PR004
            End Get
            Set(ByVal value As System.String)
                _PR004 = value
            End Set
        End Property
#End Region
#Region "基價 屬性:PR011"
        Private _PR011 As System.Single
        ''' <summary>
        ''' 基價
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR011() As System.Single
            Get
                Return _PR011
            End Get
            Set(ByVal value As System.Single)
                _PR011 = value
            End Set
        End Property
#End Region
#Region "二級折扣 屬性:PR012"
        Private _PR012 As System.Single
        ''' <summary>
        ''' 二級折扣
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR012() As System.Single
            Get
                Return _PR012
            End Get
            Set(ByVal value As System.Single)
                _PR012 = value
            End Set
        End Property
#End Region
#Region "三級折扣 屬性:PR013"
        Private _PR013 As System.Single
        ''' <summary>
        ''' 三級折扣
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR013() As System.Single
            Get
                Return _PR013
            End Get
            Set(ByVal value As System.Single)
                _PR013 = value
            End Set
        End Property
#End Region
#Region "平片加價 屬性:PR021"
        Private _PR021 As System.Single
        ''' <summary>
        ''' 平片加價
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR021() As System.Single
            Get
                Return _PR021
            End Get
            Set(ByVal value As System.Single)
                _PR021 = value
            End Set
        End Property
#End Region
#Region "毛邊折扣 屬性:PR022"
        Private _PR022 As System.Single
        ''' <summary>
        ''' 毛邊折扣
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR022() As System.Single
            Get
                Return _PR022
            End Get
            Set(ByVal value As System.Single)
                _PR022 = value
            End Set
        End Property
#End Region
#Region "加工外銷差價 屬性:PR023"
        Private _PR023 As System.Single
        ''' <summary>
        ''' 加工外銷差價
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR023() As System.Single
            Get
                Return _PR023
            End Get
            Set(ByVal value As System.Single)
                _PR023 = value
            End Set
        End Property
#End Region
#Region "間接外銷雜費 屬性:PR024"
        Private _PR024 As System.Single
        ''' <summary>
        ''' 間接外銷雜費
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR024() As System.Single
            Get
                Return _PR024
            End Get
            Set(ByVal value As System.Single)
                _PR024 = value
            End Set
        End Property
#End Region
#Region "其他 屬性:PR025"
        Private _PR025 As System.Single
        ''' <summary>
        ''' 其他
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR025() As System.Single
            Get
                Return _PR025
            End Get
            Set(ByVal value As System.Single)
                _PR025 = value
            End Set
        End Property
#End Region
#Region "開盤匯率 屬性:PR031"
        Private _PR031 As System.Single
        ''' <summary>
        ''' 開盤匯率
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR031() As System.Single
            Get
                Return _PR031
            End Get
            Set(ByVal value As System.Single)
                _PR031 = value
            End Set
        End Property
#End Region
#Region "結算匯率 屬性:PR032"
        Private _PR032 As System.Single
        ''' <summary>
        ''' 結算匯率
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR032() As System.Single
            Get
                Return _PR032
            End Get
            Set(ByVal value As System.Single)
                _PR032 = value
            End Set
        End Property
#End Region
#Region "第１匯率 屬性:PR033"
        Private _PR033 As System.Single
        ''' <summary>
        ''' 第１匯率
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR033() As System.Single
            Get
                Return _PR033
            End Get
            Set(ByVal value As System.Single)
                _PR033 = value
            End Set
        End Property
#End Region
#Region "第２匯率 屬性:PR034"
        Private _PR034 As System.Single
        ''' <summary>
        ''' 第２匯率
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR034() As System.Single
            Get
                Return _PR034
            End Get
            Set(ByVal value As System.Single)
                _PR034 = value
            End Set
        End Property
#End Region
#Region "第３匯率 屬性:PR035"
        Private _PR035 As System.Single
        ''' <summary>
        ''' 第３匯率
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR035() As System.Single
            Get
                Return _PR035
            End Get
            Set(ByVal value As System.Single)
                _PR035 = value
            End Set
        End Property
#End Region
#Region "表面二級 屬性:PR051"
        Private _PR051 As System.Single
        ''' <summary>
        ''' 表面二級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR051() As System.Single
            Get
                Return _PR051
            End Get
            Set(ByVal value As System.Single)
                _PR051 = value
            End Set
        End Property
#End Region
#Region "表面三級 屬性:PR052"
        Private _PR052 As System.Single
        ''' <summary>
        ''' 表面三級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR052() As System.Single
            Get
                Return _PR052
            End Get
            Set(ByVal value As System.Single)
                _PR052 = value
            End Set
        End Property
#End Region
#Region "厚度二級 屬性:PR053"
        Private _PR053 As System.Single
        ''' <summary>
        ''' 厚度二級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR053() As System.Single
            Get
                Return _PR053
            End Get
            Set(ByVal value As System.Single)
                _PR053 = value
            End Set
        End Property
#End Region
#Region "厚度三級 屬性:PR054"
        Private _PR054 As System.Single
        ''' <summary>
        ''' 厚度三級
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PR054() As System.Single
            Get
                Return _PR054
            End Get
            Set(ByVal value As System.Single)
                _PR054 = value
            End Set
        End Property
#End Region

#Region "年月匯率1 屬性:YearMonthRate1"
        Shared _YearMonthRate1 As New Dictionary(Of Integer, Single)
        ''' <summary>
        ''' 年月匯率1
        ''' </summary>
        ''' <param name="GetYearMonth"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Shared ReadOnly Property YearMonthRate1(ByVal GetYearMonth As Integer) As Single
            Get
                If _YearMonthRate1.ContainsKey(GetYearMonth) Then
                    Return _YearMonthRate1(GetYearMonth)
                End If
                Dim SearchResult As List(Of SL2PR0PF) = SL2PR0PF.CDBSelect(Of SL2PR0PF)("Select * from @#SLS300LB.SL2PR0PF Where PR032>0 AND PR001='" & Format(GetYearMonth, "00000") & "' Fetch First 1 rows only", AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                If SearchResult.Count = 0 Then
                    _YearMonthRate1.Add(GetYearMonth, 1)
                Else
                    _YearMonthRate1.Add(GetYearMonth, SearchResult(0).PR032)
                End If
                Return _YearMonthRate1(GetYearMonth)
            End Get
        End Property
#End Region
    End Class
End Namespace