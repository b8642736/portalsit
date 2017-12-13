Namespace SLS300LB
    ''' <summary>
    ''' 內銷數量折扣
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SL3X11PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(SL3X11PF).Name)
        End Sub

#Region "年月 屬性:X1101"
        Private _X1101 As System.String
        ''' <summary>
        ''' 年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property X1101() As System.String
            Get
                Return _X1101
            End Get
            Set(ByVal value As System.String)
                _X1101 = value
            End Set
        End Property
#End Region
#Region "噸數 屬性:X1102"
        Private _X1102 As System.Int32
        ''' <summary>
        ''' 噸數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property X1102() As System.Int32
            Get
                Return _X1102
            End Get
            Set(ByVal value As System.Int32)
                _X1102 = value
            End Set
        End Property
#End Region
#Region "折扣 屬性:X1103"
        Private _X1103 As System.Single
        ''' <summary>
        ''' 折扣
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property X1103() As System.Single
            Get
                Return _X1103
            End Get
            Set(ByVal value As System.Single)
                _X1103 = value
            End Set
        End Property
#End Region
#Region "獎勵1 屬性:X1104"
        Private _X1104 As System.Int32
        ''' <summary>
        ''' 獎勵1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property X1104() As System.Int32
            Get
                Return _X1104
            End Get
            Set(ByVal value As System.Int32)
                _X1104 = value
            End Set
        End Property
#End Region
#Region "獎勵2 屬性:X1105"
        Private _X1105 As System.Int32
        ''' <summary>
        ''' 獎勵2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property X1105() As System.Int32
            Get
                Return _X1105
            End Get
            Set(ByVal value As System.Int32)
                _X1105 = value
            End Set
        End Property
#End Region
#Region "獎勵3 屬性:X1106"
        Private _X1106 As System.Int32
        ''' <summary>
        ''' 獎勵3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property X1106() As System.Int32
            Get
                Return _X1106
            End Get
            Set(ByVal value As System.Int32)
                _X1106 = value
            End Set
        End Property
#End Region

#Region "年月份數量折扣 MonthWeightDiscount"
        Private Shared _MonthWeightDiscount As New Dictionary(Of Integer, Integer)
        ''' <summary>
        ''' 年月份數量折扣
        ''' </summary>
        ''' <param name="GetTWYearMonth"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Shared ReadOnly Property MonthWeightDiscount(ByVal GetTWYearMonth As Integer) As Integer
            Get
                If Not _MonthWeightDiscount.ContainsKey(GetTWYearMonth) Then
                    Dim SearchResult As List(Of SL3X11PF) = SL3X11PF.CDBSelect(Of SL3X11PF)("Select * From @#SLS300LB.SL3X11PF Where X1101='" & Format(GetTWYearMonth, "00000") & "'", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count = 0 Then
                        _MonthWeightDiscount.Add(GetTWYearMonth, 0)
                    Else
                        _MonthWeightDiscount.Add(GetTWYearMonth, SearchResult(0).X1104)
                    End If
                End If
                Return _MonthWeightDiscount(GetTWYearMonth)
            End Get
        End Property
#End Region

    End Class
End Namespace