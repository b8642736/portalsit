Public Class CoilExamineRec
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.CoilExamineRecDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.CoilExamineRecDataTable
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        Dim SearchResult As List(Of DataRow) = (From A In Adapter.SelectQuery(SQLString) Select A).ToList
        Dim ReturnValue As New QualityControlDataSet.CoilExamineRecDataTable
        Dim AddRow As QualityControlDataSet.CoilExamineRecRow = Nothing
        Dim SerNumber As Integer = 0
        Dim PreDataRow As DataRow = Nothing
        For Each EachItem In SearchResult
            AddRow = ReturnValue.NewRow
            With AddRow
                If IsNothing(PreDataRow) OrElse (PreDataRow.Item("QDS02") & PreDataRow.Item("QDS03")) <> (EachItem.Item("QDS02") & PreDataRow.Item("QDS03")) Then
                    SerNumber += 1
                    .序號 = SerNumber
                End If
                .鋼捲號碼 = EachItem.Item("QDS02") & CType(EachItem.Item("QDS03"), String).Trim
                .鋼種 = EachItem.Item("BLA02")
                .材質 = EachItem.Item("BLA18")
                .熱軋批次 = EachItem.Item("BLA01")
                .鋼胚號碼 = EachItem.Item("BLA07")
                .熱軋號碼 = EachItem.Item("BLA11")
                .追蹤線別 = EachItem.Item("QDS01")
                .厚度 = EachItem.Item("BLA03")
                .品檢員1 = EachItem.Item("QDS07")
                .品檢員2 = EachItem.Item("QDS08")
            End With
            PreDataRow = EachItem
            ReturnValue.Rows.Add(AddRow)
        Next

        Return ReturnValue
    End Function
#End Region

#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' 控制項Where條件產生器
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlWhereMaker()
        Dim ReturnValue As New StringBuilder

        ReturnValue.Append("Select A.*,B.*" & _
            " From  @#PPS100LB.PPSBLAPF A JOIN @#PPS100LB.PPSQDSPF B ON A.BLA09=B.QDS02 AND B.QDS04 >= A.BLA08  " & _
            " WHERE  1=1 ")

        If Not String.IsNullOrEmpty(tbBatchNumers.Text) AndAlso tbBatchNumers.Text.Trim.Length > 0 Then
            ReturnValue.Append(" AND A.BLA11 in ('" & tbBatchNumers.Text.Trim.Replace(",", "','") & "')")
        End If

        Dim GetLines As String = Nothing
        For Each EachItem As ListItem In CheckBoxList1.Items
            If EachItem.Selected Then
                GetLines &= IIf(String.IsNullOrEmpty(GetLines), "", "','") & EachItem.Value
            End If
        Next
        If GetLines.Split(",").Count < CheckBoxList1.Items.Count Then
            ReturnValue.Append(" AND B.QDS01 in ('" & GetLines & "')")
        End If



        If Not String.IsNullOrEmpty(tbEmployees.Text) AndAlso tbEmployees.Text.Trim.Length > 0 Then
            ReturnValue.Append(" AND (B.QDS07 in ('" & tbEmployees.Text.Trim.Replace(",", "','") & "')")
            ReturnValue.Append(" OR B.QDS08 in ('" & tbEmployees.Text.Trim.Replace(",", "','") & "') )")
        End If



        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            ReturnValue.Append(" AND A.BLA02 in ('" & tbSteelKind.Text.Trim.Replace(",", "','") & "')")
        End If
        ReturnValue.Append(" ORDER BY B.QDS02,B.QDS03 ")
        Me.hfQry.Value = ReturnValue.ToString
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ControlWhereMaker()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        ControlWhereMaker()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel
        ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQry.Value), "鋼捲檢驗記錄資料查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class