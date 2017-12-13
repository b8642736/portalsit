Public Class CoilNumberInfos
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.CoilNumberInfosDataTable
        Dim ReturnValue As New QualityControlDataSet.CoilNumberInfosDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As List(Of DataRow) = (From A In Adapter.SelectQuery(SQLString) Select A).ToList
        For Each EachItem As DataRow In SearchResult
            Dim AddItem As QualityControlDataSet.CoilNumberInfosRow = ReturnValue.NewRow
            With AddItem
                .鋼捲號碼 = EachItem.Item("CIA02")
                .分捲號碼 = EachItem.Item("CIA03")
                .表面 = EachItem.Item("CIA06")
                .鋼種 = EachItem.Item("CIA05")
                .煉鋼爐號 = Left(CType(EachItem.Item("BLA07"), String), 5)
                .鋼肧號碼 = CType(EachItem.Item("BLA07"), String)
                .報價單號碼 = EachItem.Item("CIA04")
                .會計日期 = EachItem.Item("CIA58")
                .熱軋號碼 = EachItem.Item("BLA01")
                .批號 = EachItem.Item("BLA11")
            End With
            ReturnValue.Rows.Add(AddItem)
        Next

        Return ReturnValue
    End Function
#End Region

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Dim ReturnValue As New StringBuilder
        ReturnValue.Append("Select A.*,B.BLA01,B.BLA07,B.BLA11" & _
               " From  @#PPS100LB.PPSCIAPF A INNER JOIN @#PPS100LB.PPSBLAPF B ON A.CIA02=B.BLA09 AND A.CIA55 > B.BLA08 " & _
               " WHERE A.CIA45='*' AND A.CIA46='*' AND B.BLA13=' ' ")
        ReturnValue.Append(" AND A.CIA58 >= " & New CompanyORMDB.AS400DateConverter(Me.tbStarDate.Text).TwIntegerTypeData & " AND A.CIA58 <= " & New CompanyORMDB.AS400DateConverter(Me.tbEndDate.Text).TwIntegerTypeData)
        If Not String.IsNullOrEmpty(tbCoilNumbers.Text) Then
            tbCoilNumbers.Text = tbCoilNumbers.Text.Replace("'", Nothing)
            If tbCoilNumbers.Text.Contains("~") Then
                ReturnValue.Append(IIf(tbCoilNumbers.Text.Trim.Length > 0, " AND A.CIA02 >= '" & tbCoilNumbers.Text.Split("~")(0).Trim & "' AND A.CIA02 <= '" & tbCoilNumbers.Text.Split("~")(1).Trim & "'", Nothing))
            Else
                ReturnValue.Append(IIf(tbCoilNumbers.Text.Trim.Length > 0, " AND A.CIA02 IN ('" & tbCoilNumbers.Text.Replace(",", "','") & "')", Nothing))
            End If
        End If

        If Not String.IsNullOrEmpty(tbSteelkind.Text) Then
            ReturnValue.Append(" AND A.CIA05 IN ('" & tbSteelkind.Text.Replace("'", Nothing).Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbFace.Text) Then
            ReturnValue.Append(" AND A.CIA06 IN ('" & tbFace.Text.Replace("'", Nothing).Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbStoveNumbers.Text) Then
            tbStoveNumbers.Text = tbStoveNumbers.Text.Replace("'", Nothing)
            If tbStoveNumbers.Text.Contains("~") Then
                ReturnValue.Append(IIf(tbStoveNumbers.Text.Trim.Length > 0, " AND LEFT(B.BLA07,5) >= '" & tbStoveNumbers.Text.Split("~")(0).Trim & "' AND LEFT(B.BLA07,5) <= '" & tbStoveNumbers.Text.Split("~")(1).Trim & "'", Nothing))
            Else
                ReturnValue.Append(IIf(tbStoveNumbers.Text.Trim.Length > 0, " AND LEFT(B.BLA07,5) IN ('" & tbStoveNumbers.Text.Replace(",", "','") & "')", Nothing))
            End If
        End If

        If Not String.IsNullOrEmpty(tbHotCoilNumbers.Text) Then
            tbHotCoilNumbers.Text = tbHotCoilNumbers.Text.Replace("'", Nothing)
            If tbHotCoilNumbers.Text.Contains("~") Then
                ReturnValue.Append(IIf(tbHotCoilNumbers.Text.Trim.Length > 0, " AND B.BLA01 >= '" & tbHotCoilNumbers.Text.Split("~")(0).Trim & "' AND B.BLA01 <= '" & tbHotCoilNumbers.Text.Split("~")(1).Trim & "'", Nothing))
            Else
                ReturnValue.Append(IIf(tbHotCoilNumbers.Text.Trim.Length > 0, " AND B.BLA01 IN ('" & tbHotCoilNumbers.Text.Replace(",", "','") & "')", Nothing))
            End If
        End If

        If Not String.IsNullOrEmpty(tbbatchNumbers.Text) Then
            tbbatchNumbers.Text = tbbatchNumbers.Text.Replace("'", Nothing)
            If tbbatchNumbers.Text.Contains("~") Then
                ReturnValue.Append(IIf(tbbatchNumbers.Text.Trim.Length > 0, " AND B.BLA11 >= '" & tbbatchNumbers.Text.Split("~")(0).Trim & "' AND B.BLA11 <= '" & tbbatchNumbers.Text.Split("~")(1).Trim & "'", Nothing))
            Else
                ReturnValue.Append(IIf(tbbatchNumbers.Text.Trim.Length > 0, " AND B.BLA11 IN ('" & tbbatchNumbers.Text.Replace(",", "','") & "')", Nothing))
            End If
        End If

        hfSQLString.Value = ReturnValue.ToString & " Order by A.CIA02,A.CIA03"

    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStarDate.Text = Format(Now, "yyyy/01/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub tbSearch_Click(sender As Object, e As EventArgs) Handles tbSearch.Click
        SetQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        SetQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value), "發貨鋼捲爐號查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub
End Class