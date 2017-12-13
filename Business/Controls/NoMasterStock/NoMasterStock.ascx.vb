Public Partial Class NoMasterStock
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As SLS300LB.NoMasterStockPrintDataTable

        If String.IsNullOrEmpty(SQLString) Then
            Return New SLS300LB.NoMasterStockPrintDataTable
        End If
        Dim Step1SearchResult As List(Of CompanyORMDB.PPS100LB.PPSCIALJ) = (From A In CompanyORMDB.PPS100LB.PPSCIALJ.CDBSetDataTableToObjects(Of CompanyORMDB.PPS100LB.PPSCIALJ)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Select A).ToList

        Dim ReturnValueTemp As New List(Of SLS300LB.NoMasterStockPrintRow)
        Dim ReturnValue As New SLS300LB.NoMasterStockPrintDataTable
        Dim AddItem As DataRow = Nothing
        For Each EachItem As CompanyORMDB.PPS100LB.PPSCIALJ In Step1SearchResult
            AddItem = ReturnValue.NewRow
            With AddItem
                .Item("鋼捲號碼1") = EachItem.CIA02
                .Item("鋼捲號碼2") = EachItem.CIA03
                .Item("TYPE") = EachItem.CIA36
                .Item("鋼種") = EachItem.CIA05
                .Item("表面") = EachItem.CIA06
                .Item("厚度") = EachItem.CIA07
                .Item("寬度") = EachItem.CIA08
                .Item("內外銷") = EachItem.ExportORHomeSellString
                .Item("PIPE") = EachItem.CIA33
                .Item("淨重") = EachItem.CIA13
                .Item("公稱寬度") = EachItem.CIA60
                .Item("等級") = EachItem.CIA16
                .Item("會計日期") = EachItem.CIA58
            End With
            ReturnValueTemp.Add(AddItem)
        Next
        For Each EachSteelKind As String In (From A In ReturnValueTemp Select A.鋼種).Distinct
            Dim EachSteelKindTemp As String = EachSteelKind
            For Each EachItem As DataRow In From A In ReturnValueTemp Where A.鋼種 = EachSteelKindTemp Select A
                ReturnValue.Rows.Add(EachItem)
            Next

            '加入小計
            Dim SteelKindGroupDatas As List(Of CompanyORMDB.PPS100LB.PPSCIALJ) = (From A In Step1SearchResult Where A.CIA05 = EachSteelKindTemp Select A).ToList
            Dim AddItem1 As DataRow = ReturnValue.NewRow
            With AddItem1
                .Item("鋼捲號碼1") = "小計:"
                .Item("鋼種") = EachSteelKindTemp
                .Item("內外銷") = "內:" & (From A In SteelKindGroupDatas Where A.IsHomeSell Select A).Count & "/外:" & (From A In SteelKindGroupDatas Where A.IsHomeSell = False Select A).Count
                .Item("淨重") = (From A In SteelKindGroupDatas Select A.CIA13).Sum
            End With
            ReturnValue.Rows.Add(AddItem1)
        Next

        '加入總計
        Dim AddItem2 As DataRow = ReturnValue.NewRow
        With AddItem2
            .Item("鋼捲號碼1") = "總計:"
            .Item("鋼種") = "全部"
            .Item("內外銷") = "內:" & (From A In Step1SearchResult Where A.IsHomeSell Select A).Count & "/外:" & (From A In Step1SearchResult Where A.IsHomeSell = False Select A).Count
            .Item("淨重") = (From A In Step1SearchResult Select A.CIA13).Sum
        End With
        ReturnValue.Rows.Add(AddItem2)

        Return ReturnValue

    End Function

#End Region


#Region "產生查詢至控製項 函式:MakeQryToControl"
    Private Sub MakeQryToControl()
        Dim SQLString As String = "Select * from @#PPS100LB.PPSCIALJ Where cia04='          '  and cia16<>' ' "
        Select Case RadioButtonList1.SelectedValue
            Case "HOMESELL"
                SQLString &= " AND CIA34=' ' "
            Case "EXPORTSELL"
                SQLString &= " AND CIA34='X' "
        End Select
        If RadioButtonList2.SelectedValue Then
            Dim StartTwDate As Integer = (New CompanyORMDB.AS400DateConverter(New Date(TextBox1.Text, DropDownList1.SelectedValue, 1))).TwIntegerTypeData
            Dim EndTwDate As Integer = (New CompanyORMDB.AS400DateConverter(New Date(TextBox2.Text, DropDownList2.SelectedValue, 1).AddMonths(1).AddDays(-1))).TwIntegerTypeData
            SQLString &= " AND CIA58>=" & StartTwDate & " AND CIA58<=" & EndTwDate
        End If
        If Not String.IsNullOrEmpty(Me.tbSteelKind.Text) AndAlso Me.tbSteelKind.Text.Trim.Length > 0 Then
            SQLString &= " AND CIA05 IN ('" & Me.tbSteelKind.Text.Trim.Replace(",", "','") & "')"
        End If
        If Not String.IsNullOrEmpty(Me.tbSteelFace.Text) AndAlso Me.tbSteelFace.Text.Trim.Length > 0 Then
            SQLString &= " AND CIA06 IN ('" & Me.tbSteelFace.Text.Trim.Replace(",", "','") & "')"
        End If
        If Not String.IsNullOrEmpty(Me.tbLevel.Text) AndAlso Me.tbLevel.Text.Trim.Length > 0 Then
            SQLString &= " AND CIA16 IN ('" & Me.tbLevel.Text.Trim.Replace(",", "','") & "')"
        End If
        SQLString &= " order by cia05,cia60,cia36,cia06,cia07,cia02,cia03"

        hfQry.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox1.Text = Format(Now, "yyyy")
            Me.DropDownList1.SelectedValue = Format(Now, "MM")
            TextBox2.Text = Format(Now, "yyyy")
            Me.DropDownList2.SelectedValue = Format(Now, "MM")
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class