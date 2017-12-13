Public Class HotRollingSearch
    Inherits System.Web.UI.UserControl
#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As QualityControlDataSet.HotRollingSearchDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return New QualityControlDataSet.HotRollingSearchDataTable
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim SearchResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList

        Dim ReturnValue As New QualityControlDataSet.HotRollingSearchDataTable
        For Each EachItem As DataRow In SearchResult
            Dim AddRow As QualityControlDataSet.HotRollingSearchRow = ReturnValue.NewRow
            With AddRow
                .鋼捲號碼 = EachItem.Item("BLG02")
                .批號 = EachItem.Item("BLA11")
                .鋼種 = EachItem.Item("BLA02")
                .爐號 = EachItem.Item("BLG03")
                .切號 = EachItem.Item("BLG05")
                .項目 = EachItem.Item("BLG06")
                .肧重 = EachItem.Item("BLG07")
                .日期 = EachItem.Item("BLG08")
                .厚度 = EachItem.Item("BLG09")
                .平均厚度 = EachItem.Item("BLG10")
                .寬度 = EachItem.Item("BLG11")
                .平均寬度 = EachItem.Item("BLG12")
                .捲重 = EachItem.Item("BLG13")
                .軋數 = EachItem.Item("BLG18")
                .出爐溫度 = EachItem.Item("BLG19")
                .在爐時間 = EachItem.Item("BLG20")
                .捲機 = EachItem.Item("BLG24")
                .攤檢記錄 = EachItem.Item("BLG25")
                .C25 = EachItem.Item("BLG14")
                .W25 = EachItem.Item("BLG15")
                .C40 = EachItem.Item("BLG16")
                .WEDGE = EachItem.Item("BLG17")
            End With
            ReturnValue.Rows.Add(AddRow)
        Next


        Return ReturnValue
    End Function
#End Region

#Region "查詢條件產生至控制項 方法:ControlWhereMaker"
    ''' <summary>
    ''' 查詢條件產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerQryStringToControl()
        Dim ReturnValue As String = "SELECT A.*, B.BLA02 ,B.BLA11 FROM @#PPS100LB.PPSBLGPF A JOIN @#PPS100LB.PPSBLAPF B ON A.BLG02=B.BLA01 AND A.BLG03=LEFT(B.BLA07,5) "
        tbLotsNumbers.Text = tbLotsNumbers.Text.Replace("'", Nothing)
        If tbLotsNumbers.Text.Contains("~") Then
            ReturnValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BLA11 >= '" & tbLotsNumbers.Text.Split("~")(0).Trim & "' AND B.BLA11 <= '" & tbLotsNumbers.Text.Split("~")(1).Trim & "'", Nothing)
        Else
            ReturnValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BLA11 IN ('" & tbLotsNumbers.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            ReturnValue &= " AND " & " B.BLA02='" & tbSteelKind.Text.Trim & "'"
        End If

        Me.hfQry.Value = ReturnValue
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakerQryStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        MakerQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQry.Value), "中鋼熱軋品管" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub
End Class