Public Partial Class CoilLineWidthHeightSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal STDArgs As String) As QualityControlDataSet.CoilLineWidthHeightSearchDataTableDataTable
        Dim ReturnValue As New QualityControlDataSet.CoilLineWidthHeightSearchDataTableDataTable
        If String.IsNullOrEmpty(SQLString) OrElse SQLString.Trim.Length = 0 Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim AdapterResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList
        Dim NumberCount As Integer = 0
        Dim AddRow As QualityControlDataSet.CoilLineWidthHeightSearchDataTableRow = Nothing

        For Each EachItem As DataRow In ((From A In AdapterResult Select A Order By A.Item("BLA01"), A.Item("BLA11")).ToList)
            Dim EachItemTemp As DataRow = EachItem
            AddRow = ReturnValue.NewRow
            NumberCount += 1
            With AddRow
                .序號 = NumberCount
                .鋼捲號碼 = EachItem.Item("QDS02")
                .鋼種 = EachItem.Item("BLA02")
                .材質 = EachItem.Item("BLA18")
                .熱軋批次 = EachItem.Item("BLA11")
                .熱軋號碼 = EachItem.Item("BLA01")
                .鋼胚號碼 = EachItem.Item("BLA07")
                .鋼胚產日 = EachItem.Item("QDS04")
                .產線別 = EachItem.Item("QDS01")
                If CType(EachItem.Item("SHA33"), String).Trim.Length > 0 Then
                    .公稱厚度 = CType(EachItem.Item("SHA33"), Integer) / 100
                End If
                .厚度1 = EachItem.Item("QDS09")
                .厚度2 = EachItem.Item("QDS12")
                .厚度3 = EachItem.Item("QDS15")
                .厚度4 = EachItem.Item("QDS18")
                .厚度5 = EachItem.Item("QDS21")
                .寬度1 = EachItem.Item("QDS10")
                .寬度2 = EachItem.Item("QDS13")
                .寬度3 = EachItem.Item("QDS16")
                .寬度4 = EachItem.Item("QDS19")
                .寬度5 = EachItem.Item("QDS22")
            End With
            ReturnValue.Rows.Add(AddRow)
        Next


        '計算標準差
        If Not (String.IsNullOrEmpty(STDArgs) OrElse STDArgs.Trim.Length = 0) Then
            Dim StdWValues As New List(Of Single)
            Dim StdHValues As New List(Of Single)
            StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W1") And CType(A.寬度1, Single) > 0 Select CType(A.寬度1, Single)).ToList)
            StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W2") And CType(A.寬度2, Single) > 0 Select CType(A.寬度2, Single)).ToList)
            StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W3") And CType(A.寬度3, Single) > 0 Select CType(A.寬度3, Single)).ToList)
            StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W4") And CType(A.寬度4, Single) > 0 Select CType(A.寬度4, Single)).ToList)
            StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W5") And CType(A.寬度5, Single) > 0 Select CType(A.寬度5, Single)).ToList)
            StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H1") And CType(A.厚度1, Single) > 0 Select CType(A.厚度1, Single)).ToList)
            StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H2") And CType(A.厚度2, Single) > 0 Select CType(A.厚度2, Single)).ToList)
            StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H3") And CType(A.厚度3, Single) > 0 Select CType(A.厚度3, Single)).ToList)
            StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H4") And CType(A.厚度4, Single) > 0 Select CType(A.厚度4, Single)).ToList)
            StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H5") And CType(A.厚度5, Single) > 0 Select CType(A.厚度5, Single)).ToList)
            Dim StdWValue As Double = Math.Sqrt((From A In StdWValues Select (A - (StdWValues.Sum / StdWValues.Count)) ^ 2).Sum / StdWValues.Count)
            Dim StdHValue As Double = Math.Sqrt((From A In StdHValues Select (A - (StdHValues.Sum / StdHValues.Count)) ^ 2).Sum / StdHValues.Count)
            AddRow = ReturnValue.NewRow
            With AddRow
                .鋼胚號碼 = "厚度標準差:"
                .熱軋號碼 = Format(StdHValue, "0.000")
            End With
            ReturnValue.Rows.Add(AddRow)
            AddRow = ReturnValue.NewRow
            With AddRow
                .鋼胚號碼 = "寬度標準差:"
                .熱軋號碼 = Format(StdWValue, "0.000")
            End With
            ReturnValue.Rows.Add(AddRow)
        End If


        Return ReturnValue
    End Function

    '#Region "移除最後軋延前之品檢前資料 函式:RemovePreLastQCDatas"
    '    ''' <summary>
    '    ''' 移除最後軋延前之品檢前資料
    '    ''' </summary>
    '    ''' <param name="SourceData"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Private Function RemovePreLastQCDatas(ByVal SourceData As List(Of DataRow)) As List(Of DataRow)
    '        Dim RemoveDataRows As New List(Of DataRow)
    '        For Each EachItem As DataRow In SourceData
    '            Dim EachItemTemp As DataRow = EachItem
    '            'BLA01
    '            RemoveDataRows.AddRange((From A In SourceData Where A.Item("QDS02") = EachItemTemp.Item("QDS02") And A.Item("BLA01") = EachItemTemp.Item("BLA01") Select A).ToList)
    '        Next
    '        Return (From A In SourceData Where Not RemoveDataRows.Contains(A) Select A).ToList
    '    End Function
    '#End Region
#End Region

#Region "控制項SQL條件產生器 方法:SQLMakerToControl"
    ''' <summary>
    ''' 控制項SQL條件產生器
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SQLMakerToControl()
        Dim ReturnValue As String = Nothing

        If Not String.IsNullOrEmpty(tbSLABNumber.Text) AndAlso tbSLABNumber.Text.Trim.Length > 0 Then
            ReturnValue &= " AND C.BLA07 LIKE '" & tbSLABNumber.Text.Trim.Replace("*", "%") & "' "
        End If

        'If Not String.IsNullOrEmpty(tbLotsNumber.Text) Then
        '    tbLotsNumber.Text = tbLotsNumber.Text.Replace("'", Nothing)
        '    ReturnValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND C.BLA11  IN ('" & tbLotsNumber.Text.Replace(",", "','") & "')", Nothing)
        'End If
        If Not String.IsNullOrEmpty(tbLotsNumber.Text) Then
            tbLotsNumber.Text = tbLotsNumber.Text.Replace("'", Nothing)
            If tbLotsNumber.Text.Contains("~") Then
                ReturnValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND C.BLA11 >= '" & tbLotsNumber.Text.Split("~")(0).Trim & "' AND C.BLA11 <= '" & tbLotsNumber.Text.Split("~")(1).Trim & "'", Nothing)
            Else
                ReturnValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND C.BLA11 IN ('" & tbLotsNumber.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If




        If Not String.IsNullOrEmpty(tbCoilNumber.Text) Then
            tbCoilNumber.Text = tbCoilNumber.Text.Replace("'", Nothing)
            ReturnValue &= IIf(tbCoilNumber.Text.Trim.Length > 0, " AND (RTRIM(A.QDS02) || A.QDS03)  IN ('" & tbCoilNumber.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbStartThick.Text) AndAlso Not String.IsNullOrEmpty(tbEndThick.Text) AndAlso (tbStartThick.Text <> "0.0" OrElse tbEndThick.Text <> "9.99") Then
            tbLotsNumber.Text = tbLotsNumber.Text.Replace("'", Nothing)
            Dim StartThick As String = Format(CType(tbStartThick.Text, Single), "0.00").Replace(".", Nothing).PadLeft(4)
            Dim EndThick As String = Format(CType(tbEndThick.Text, Single), "0.00").Replace(".", Nothing).Replace("-", Nothing).PadLeft(4)
            Dim SubQry As String = "Select SHA01 || SHA02 From @#PPS100LB.PPSSHAPF  Where SHA33>='" & StartThick & "' AND SHA33<='" & EndThick & "' AND SHA08='AP1H' "
            ReturnValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND  (A.QDS02 || A.QDS03)  IN (" & SubQry & ")", Nothing)
        End If
        If Not String.IsNullOrEmpty(tbStartWidth.Text) AndAlso Not String.IsNullOrEmpty(tbEndWidth.Text) AndAlso (tbStartWidth.Text.Trim <> "0" OrElse tbEndWidth.Text.Trim <> "9999") Then
            tbLotsNumber.Text = tbLotsNumber.Text.Replace("'", Nothing)
            Dim StartWdith As Integer = CType(tbStartWidth.Text, Integer)
            Dim EndWidth As Integer = CType(tbEndWidth.Text, Integer)
            Dim SubQry As String = "Select SHA01 || SHA02 From @#PPS100LB.PPSSHAPF  Where SHA34>=" & StartWdith & " AND SHA34<=" & EndWidth & " AND SHA08='AP1H' "
            ReturnValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND  (A.QDS02 || A.QDS03)  IN (" & SubQry & ")", Nothing)
        End If
        If Not String.IsNullOrEmpty(tbSteelKindType.Text) Then
            tbSteelKindType.Text = tbSteelKindType.Text.Replace("'", Nothing)
            ReturnValue &= IIf(tbSteelKindType.Text.Trim.Length > 0, " AND (RTRIM(C.BLA02) || C.BLA18) IN ('" & tbSteelKindType.Text.Replace(",", "','") & "')", Nothing)
        End If
        'tbProductLines
        If Not String.IsNullOrEmpty(tbProductLines.Text) Then
            tbProductLines.Text = tbProductLines.Text.Replace("'", Nothing)
            ReturnValue &= IIf(tbProductLines.Text.Trim.Length > 0, " AND B.SHA08 IN ('" & tbProductLines.Text.Replace(",", "','") & "')", Nothing)
        End If
        If CheckBox1.Checked Then
            Dim SetValue As String = Nothing
            For Each EachItem As ListItem In CheckBoxList1.Items
                If EachItem.Selected Then
                    SetValue &= IIf(String.IsNullOrEmpty(SetValue), Nothing, ",") & EachItem.Value
                End If
            Next
            For Each EachItem As ListItem In CheckBoxList2.Items
                If EachItem.Selected Then
                    SetValue &= IIf(String.IsNullOrEmpty(SetValue), Nothing, ",") & EachItem.Value
                End If
            Next
            Me.hfControlSTDArgs.Value = SetValue
        Else
            Me.hfControlSTDArgs.Value = Nothing
        End If

        Me.hfControlSQLMaker.Value = "Select A.*,B.SHA33,B.SHA01,B.SHA02,B.SHA04,B.SHA08,C.* from @#PPS100LB.PPSQDSL3 A INNER JOIN @#PPS100LB.PPSSHALC B ON (A.QDS02 || A.QDS03 || A.QDS01) = (B.SHA01 || B.SHA02 || B.SHA08)  AND A.QDS04>(SHA21-30000) LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.QDS02 = C.BLA09 Where 1=1 " & ReturnValue
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SQLMakerToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearch0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch0.Click
        tbLotsNumber.Text = Nothing
        tbStartThick.Text = "0.0"
        tbEndThick.Text = "99.9"
        tbSteelKindType.Text = Nothing
        tbCoilNumber.Text = Nothing
    End Sub

    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        SQLMakerToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfControlSQLMaker.Value, Me.hfControlSTDArgs.Value), "鋼捲實際寬度查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxList1.SelectedIndexChanged, CheckBoxList2.SelectedIndexChanged
        Dim SenderControl As CheckBoxList = sender
        Dim IsAnyChecked As Boolean = False
        For Each EachItem As ListItem In SenderControl.Items
            If EachItem.Selected Then
                IsAnyChecked = EachItem.Selected
                Exit For
            End If
        Next
        If IsAnyChecked = False Then
            SenderControl.Items(0).Selected = True
        End If
    End Sub
End Class