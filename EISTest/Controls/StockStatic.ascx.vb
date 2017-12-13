Public Class StockStatic
    Inherits System.Web.UI.UserControl

#Region "查詢報價單訂購明細：Search"
    ''' <summary>
    ''' 查詢報價單訂購明細
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function Search1(ByVal SQLString As String) As EISDataSet.StockStaticDataTable
        Dim ReturnValue As EISDataSet.StockStaticDataTable = New EISDataSet.StockStaticDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As DataTable = Adapter.SelectQuery(SQLString)
        Dim PreStockDays As Integer = 0
        Dim StartDate As Integer = 0
        Dim EndDate As Integer = 0
        PreStockDays = 1

        For StockDays As Integer = -10 To -100 Step -10
            StartDate = New CompanyORMDB.AS400DateConverter(Now.AddDays(StockDays).Date).TwIntegerTypeData
            EndDate = New CompanyORMDB.AS400DateConverter(Now.AddDays(PreStockDays).Date).TwIntegerTypeData
            If StockDays = -100 Then
                StartDate = New CompanyORMDB.AS400DateConverter(Now.AddYears(-100).Date).TwIntegerTypeData
            End If
            For Each SteelKind As String In (From A In SearchResult Select CType(A.Item("CIA05"), String).Trim Distinct).ToList
                Dim SteelKindAndDaysGroupDatas As List(Of DataRow) = (From A In SearchResult Where CType(A.Item("CIA05"), String).Trim = SteelKind And CType(A.Item("CIA58"), Integer) >= StartDate And CType(A.Item("CIA58"), Integer) < EndDate Select CType(A, DataRow)).ToList
                If StockDays > -100 Then
                    AddDataRow(ReturnValue, SteelKindAndDaysGroupDatas, SteelKind & "," & Math.Abs(StockDays) & " 天")
                Else
                    AddDataRow(ReturnValue, SteelKindAndDaysGroupDatas, SteelKind & ",90 天以上")
                End If
            Next
            Dim StockDaysGroupDatas As List(Of DataRow) = (From A In SearchResult Where CType(A.Item("CIA58"), Integer) >= StartDate And CType(A.Item("CIA58"), Integer) < EndDate Select CType(A, DataRow)).ToList
            AddDataRow(ReturnValue, StockDaysGroupDatas, ",小計:")
            PreStockDays = StockDays
        Next
        For Each SteelKind As String In (From A In SearchResult Select CType(A.Item("CIA05"), String).Trim Distinct).ToList
            Dim SteelKindGroupDatas As List(Of DataRow) = (From A In SearchResult Where CType(A.Item("CIA05"), String).Trim = SteelKind.Trim Select CType(A, DataRow)).ToList
            AddDataRow(ReturnValue, SteelKindGroupDatas, SteelKind & ",合計:")
        Next
        AddDataRow(ReturnValue, (From A In SearchResult Select CType(A, DataRow)).ToList, ",總計:")
        Return ReturnValue
    End Function

    Private Shared Sub AddDataRow(ByVal ReturnValue As EISDataSet.StockStaticDataTable, ByVal DataGroup As List(Of DataRow), ByVal SteelKindAndDayArgs As String)
        If DataGroup.Count = 0 Then
            Exit Sub
        End If
        Dim SteelKind As String = Nothing
        Dim Days As String = Nothing
        If Not SteelKindAndDayArgs.Contains(",") Then
            SteelKind = SteelKindAndDayArgs
        Else
            SteelKind = SteelKindAndDayArgs.Split(",")(0)
            Days = SteelKindAndDayArgs.Split(",")(1)
        End If
        Dim AddRow As EISDataSet.StockStaticRow = ReturnValue.NewRow
        With AddRow
            .鋼種 = SteelKind
            .繳庫天數 = Days
            .有主內銷 = Format((From A In DataGroup Where CType(A.Item("CIA04"), String).Substring(3, 8).Trim <> "" And CType(A.Item("CIA34"), String).Trim = "" Select CType(A.Item("CIA13"), Double)).Sum / 1000, "0.000")
            .有主外銷 = Format((From A In DataGroup Where CType(A.Item("CIA04"), String).Substring(3, 8).Trim <> "" And CType(A.Item("CIA34"), String).Trim <> "" Select CType(A.Item("CIA13"), Double)).Sum / 1000, "0.000")
            .有主小計 = Format((From A In DataGroup Where CType(A.Item("CIA04"), String).Substring(3, 8).Trim <> "" Select CType(A.Item("CIA13"), Double)).Sum / 1000, "0")
            .無主內銷 = Format((From A In DataGroup Where CType(A.Item("CIA04"), String).Substring(3, 8).Trim = "" And CType(A.Item("CIA34"), String).Trim = "" Select CType(A.Item("CIA13"), Double)).Sum / 1000, "0.000")
            .無主外銷 = Format((From A In DataGroup Where CType(A.Item("CIA04"), String).Substring(3, 8).Trim = "" And CType(A.Item("CIA34"), String).Trim <> "" Select CType(A.Item("CIA13"), Double)).Sum / 1000, "0.000")
            .無主小計 = Format((From A In DataGroup Where CType(A.Item("CIA04"), String).Substring(3, 8).Trim = "" Select CType(A.Item("CIA13"), Double)).Sum / 1000, "0")
        End With
        ReturnValue.Rows.Add(AddRow)
    End Sub
#End Region


#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerSQLStringToControl()
        Dim ReturnValue As String = "Select A.* From @#PPS100LB.PPSCIALJ A JOIN @#SLS300LB.SL2CH2PF B ON  A.CIA06=B.CH201 WHERE  B.CH202<>'Y' "
        Me.hyfQry.Value = ReturnValue
    End Sub
#End Region




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'tbStartDate.Text = Format(Now, "yyyy/MM/01")
        'tbEndDate.Text = Format(Now, "yyyy/MM/" & Date.DaysInMonth(Now.Year, Now.Month))
        MakerSQLStringToControl()
        GridView1.DataBind()

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerSQLStringToControl()
        GridView1.DataBind()
    End Sub
End Class