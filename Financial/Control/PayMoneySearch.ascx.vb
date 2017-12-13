Public Partial Class PayMoneySearch
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox1.Text = Format(Now, "yyyy/MM/dd")
            TextBox2.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        GridView1.DataBind()
    End Sub

    Protected Sub btnConvertToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConvertToExcel.Click
        Dim SetDisplayColumns As New List(Of ConvertColumnName)
        SetDisplayColumns.Add(New ConvertColumnName("DEPART", "單位別", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("ACITEM", "支出科目", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("USEFOR", "用途", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("RECEPR", "受款人", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("CHKAMT", "支票金額", GetType(Decimal)))
        SetDisplayColumns.Add(New ConvertColumnName("DisplayPAYDAT", "付款日", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("BANKN1", "銀行別", GetType(String)))
        Dim ConvertDataTable As DataTable = ConvertColumnName.CreatDataTable(SetDisplayColumns)
        For Each EachItem As PayMoneySearchDisplayItem In (From A In PayMoneySearchDisplayItem.PayMoneySearch(Me.TextBox1.Text, TextBox2.Text) Select A).ToList
            Dim AddRow As DataRow = ConvertDataTable.NewRow
            With AddRow
                .Item("DEPART") = EachItem.DEPART
                .Item("ACITEM") = EachItem.ACITEM
                .Item("USEFOR") = EachItem.USEFOR
                .Item("RECEPR") = EachItem.RECEPR
                .Item("CHKAMT") = EachItem.CHKAMT
                .Item("DisplayPAYDAT") = EachItem.DisplayPayDay
                .Item("BANKN1") = EachItem.BANKN1
            End With
            ConvertDataTable.Rows.Add(AddRow)
        Next

        Dim ExcelConvert As New DataConvertExcel(ConvertDataTable, SetDisplayColumns, "付款記錄" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class