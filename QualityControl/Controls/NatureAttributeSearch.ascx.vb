Public Class NatureAttributeSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal PPSSHASQLString As String) As QualityControlDataSet.NatureAttributeDataTable
        Dim ReturnValue As New QualityControlDataSet.NatureAttributeDataTable
        If String.IsNullOrEmpty(SQLString) OrElse SQLString.Trim.Length = 0 Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AdapterResult As List(Of DataRow) = (From A In Adapter.SelectQuery(SQLString).Rows Select CType(A, DataRow)).ToList
        Dim PPSSHASearchResult As List(Of DataRow) = (From A In Adapter.SelectQuery(PPSSHASQLString).Rows Select CType(A, DataRow)).ToList
        Dim NumberCount As Integer = 0
        Dim AddRow As QualityControlDataSet.NatureAttributeRow = Nothing


        For Each EachItem As DataRow In (From A In AdapterResult Select A Order By A.Item("BLA01"), A.Item("BLA11")).ToList
            Dim EachItemTemp As DataRow = EachItem
            AddRow = ReturnValue.NewRow
            NumberCount += 1
            With AddRow
                .序號 = NumberCount
                .鋼捲號碼 = CType(EachItem.Item("QCG02"), String).Trim & CType(EachItem.Item("QCG03"), String).Trim
                .鋼種 = EachItem.Item("BLA02")
                .材質 = EachItem.Item("BLA18")
                .熱軋批次 = EachItem.Item("BLA11")
                .熱軋號碼 = EachItem.Item("BLA01")
                .鋼胚號碼 = EachItem.Item("BLA07")
                .檢驗日期 = EachItem.Item("QCG01")
                .產線別 = EachItem.Item("QCG04")
                'If CType(EachItem.Item("SHA33"), String).Trim.Length > 0 Then
                '    .公稱厚度 = CType(EachItem.Item("SHA33"), Integer) / 100
                'End If
                Dim GuageAndWidthData As List(Of String) = GetGuageAndWidthDatatArray(PPSSHASearchResult, .鋼捲號碼.PadRight(10))
                If GuageAndWidthData.Count >= 2 Then
                    .熱軋厚度 = GuageAndWidthData(0)
                    .熱軋寬度 = GuageAndWidthData(1)
                End If
                If GuageAndWidthData.Count >= 4 Then
                    .冷軋厚度 = GuageAndWidthData(2)
                    .冷軋寬度 = GuageAndWidthData(3)
                End If
                .方向 = EachItem.Item("QCG05")
                ._t_s = EachItem.Item("QCG12")
                ._y_s = EachItem.Item("QCG11")
                .elong = EachItem.Item("QCG13")
                .HRB = EachItem.Item("QCG14")
                .HRC = EachItem.Item("QCG21")
                .Hv = EachItem.Item("QCG20")
                ._R_VAL = EachItem.Item("QCG15")
                ._N_VAL = EachItem.Item("QCG16")
            End With
            ReturnValue.Rows.Add(AddRow)
        Next


        ''計算標準差
        'If Not (String.IsNullOrEmpty(STDArgs) OrElse STDArgs.Trim.Length = 0) Then
        '    Dim StdWValues As New List(Of Single)
        '    Dim StdHValues As New List(Of Single)
        '    StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W1") And CType(A.寬度1, Single) > 0 Select CType(A.寬度1, Single)).ToList)
        '    StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W2") And CType(A.寬度2, Single) > 0 Select CType(A.寬度2, Single)).ToList)
        '    StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W3") And CType(A.寬度3, Single) > 0 Select CType(A.寬度3, Single)).ToList)
        '    StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W4") And CType(A.寬度4, Single) > 0 Select CType(A.寬度4, Single)).ToList)
        '    StdWValues.AddRange((From A In ReturnValue Where STDArgs.Contains("W5") And CType(A.寬度5, Single) > 0 Select CType(A.寬度5, Single)).ToList)
        '    StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H1") And CType(A.厚度1, Single) > 0 Select CType(A.厚度1, Single)).ToList)
        '    StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H2") And CType(A.厚度2, Single) > 0 Select CType(A.厚度2, Single)).ToList)
        '    StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H3") And CType(A.厚度3, Single) > 0 Select CType(A.厚度3, Single)).ToList)
        '    StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H4") And CType(A.厚度4, Single) > 0 Select CType(A.厚度4, Single)).ToList)
        '    StdHValues.AddRange((From A In ReturnValue Where STDArgs.Contains("H5") And CType(A.厚度5, Single) > 0 Select CType(A.厚度5, Single)).ToList)
        '    Dim StdWValue As Double = Math.Sqrt((From A In StdWValues Select (A - (StdWValues.Sum / StdWValues.Count)) ^ 2).Sum / StdWValues.Count)
        '    Dim StdHValue As Double = Math.Sqrt((From A In StdHValues Select (A - (StdHValues.Sum / StdHValues.Count)) ^ 2).Sum / StdHValues.Count)
        '    AddRow = ReturnValue.NewRow
        '    With AddRow
        '        .鋼胚號碼 = "厚度標準差:"
        '        .熱軋號碼 = Format(StdHValue, "0.000")
        '    End With
        '    ReturnValue.Rows.Add(AddRow)
        '    AddRow = ReturnValue.NewRow
        '    With AddRow
        '        .鋼胚號碼 = "寬度標準差:"
        '        .熱軋號碼 = Format(StdWValue, "0.000")
        '    End With
        '    ReturnValue.Rows.Add(AddRow)
        'End If

        Return ReturnValue
    End Function

    Private Function GetGuageAndWidthDatatArray(ByVal SourceData As List(Of DataRow), ByVal FindCoilNumber As String) As List(Of String)
        Dim CoilNumber As String = FindCoilNumber.Substring(0, 5)
        Dim CoilBreakNumber As String = FindCoilNumber.Substring(5, 5)
        Dim ReturnValue As New List(Of String)
        Dim CoilNumberDatas As List(Of DataRow) = (From A In SourceData Where CType(A.Item("SHA01"), String) = CoilNumber Select A Order By A.Item("SHA04")).ToList
        If CoilNumberDatas.Count = 0 Then
            Return ReturnValue
        End If
        Select Case True
            Case CoilNumberDatas.Count = 0
                Return ReturnValue
            Case CoilNumberDatas.Count = 1  '只有一筆黑皮資料
                ReturnValue.Add(CoilNumberDatas(0).Item("SHA14"))
                ReturnValue.Add(CoilNumberDatas(0).Item("SHA15"))
            Case CoilNumberDatas.Count > 1 AndAlso FindCoilNumber.Trim.Length <= 5  '無分捲
                ReturnValue.Add(CoilNumberDatas(0).Item("SHA14"))
                ReturnValue.Add(CoilNumberDatas(0).Item("SHA15"))
                ReturnValue.Add(CoilNumberDatas(CoilNumberDatas.Count - 1).Item("SHA14"))
                ReturnValue.Add(CoilNumberDatas(CoilNumberDatas.Count - 1).Item("SHA15"))
            Case CoilNumberDatas.Count > 1 AndAlso FindCoilNumber.Trim.Length > 5   '有分捲
                ReturnValue.Add(CoilNumberDatas(0).Item("SHA14"))
                ReturnValue.Add(CoilNumberDatas(0).Item("SHA15"))
                Dim FullCoilNumberLastRowData As DataRow = (From A In CoilNumberDatas Where CType(A.Item("SHA02"), String) = CoilBreakNumber Select A Order By A.Item("SHA04") Descending).FirstOrDefault
                If Not IsNothing(FullCoilNumberLastRowData) Then
                    ReturnValue.Add(FullCoilNumberLastRowData.Item("SHA14"))
                    ReturnValue.Add(FullCoilNumberLastRowData.Item("SHA15"))
                End If
        End Select
        Return ReturnValue
    End Function

#End Region

#Region "控制項SQL條件產生器 方法:SQLMakerToControl"
    ''' <summary>
    ''' 控制項SQL條件產生器
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SQLMakerToControl()
        Dim ReturnWhereValue As String = Nothing
        Dim ReturnPPSSHAWhereQry As String = Nothing

        If Not String.IsNullOrEmpty(tbSLABNumber.Text) AndAlso tbSLABNumber.Text.Trim.Length > 0 Then
            ReturnWhereValue &= " AND C.BLA07 LIKE '" & tbSLABNumber.Text.Trim.Replace("*", "%") & "' "
        End If


        If Not String.IsNullOrEmpty(tbLotsNumber.Text) Then
            tbLotsNumber.Text = tbLotsNumber.Text.Replace("'", Nothing)
            If tbLotsNumber.Text.Contains("~") Then
                ReturnWhereValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND C.BLA11 >= '" & tbLotsNumber.Text.Split("~")(0).Trim & "' AND C.BLA11 <= '" & tbLotsNumber.Text.Split("~")(1).Trim & "'", Nothing)
            Else
                ReturnWhereValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND C.BLA11 IN ('" & tbLotsNumber.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If


        If Not String.IsNullOrEmpty(tbHotStartThick.Text) OrElse Not String.IsNullOrEmpty(tbHotEndThick.Text) Then
            Dim StartThick As Single = IIf(String.IsNullOrEmpty(tbHotStartThick.Text), 0, Val(tbHotStartThick.Text))
            Dim EndThick As Single = IIf(String.IsNullOrEmpty(tbHotEndThick.Text), 99.99, Val(tbHotEndThick.Text))
            ReturnPPSSHAWhereQry &= " AND (SHA08='BL'  AND SHA14>=" & StartThick & " AND SHA14<=" & EndThick & ")"
        End If

        If Not String.IsNullOrEmpty(tbHotStartWidth.Text) OrElse Not String.IsNullOrEmpty(tbHotEndWidth.Text) Then
            Dim StartWdith As Integer = IIf(String.IsNullOrEmpty(tbHotStartWidth.Text), 0, Val(tbHotStartWidth.Text))
            Dim EndWidth As Integer = IIf(String.IsNullOrEmpty(tbHotEndWidth.Text), 9999, Val(tbHotEndWidth.Text))
            ReturnPPSSHAWhereQry &= " AND (SHA08='BL' AND SHA15>=" & StartWdith & " AND SHA15<=" & EndWidth & ")"
        End If

        If Not String.IsNullOrEmpty(tbStartThick.Text) OrElse Not String.IsNullOrEmpty(tbEndThick.Text) Then
            Dim StartThick As Single = IIf(String.IsNullOrEmpty(tbStartThick.Text), 0, Val(tbStartThick.Text))
            Dim EndThick As Single = IIf(String.IsNullOrEmpty(tbEndThick.Text), 99.99, Val(tbEndThick.Text))
            ReturnPPSSHAWhereQry &= " AND (SHA08<>'BL'  AND SHA14>=" & StartThick & " AND SHA14<=" & EndThick & ")"
        End If

        If Not String.IsNullOrEmpty(tbStartWidth.Text) OrElse Not String.IsNullOrEmpty(tbEndWidth.Text) Then
            Dim StartWdith As Integer = IIf(String.IsNullOrEmpty(tbStartWidth.Text), 0, Val(tbStartWidth.Text))
            Dim EndWidth As Integer = IIf(String.IsNullOrEmpty(tbEndWidth.Text), 9999, Val(tbEndWidth.Text))
            ReturnPPSSHAWhereQry &= " AND (SHA08<>'BL' AND SHA15>=" & StartWdith & " AND SHA15<=" & EndWidth & ")"
        End If

        If Not String.IsNullOrEmpty(ReturnPPSSHAWhereQry) Then
            ReturnWhereValue &= " AND (A.QCG02 || A.QCG03)  IN (Select SHA01 || SHA02 from @#PPS100LB.PPSSHALC  Where  1=1 " & ReturnPPSSHAWhereQry & ")"
        End If

        If Not String.IsNullOrEmpty(tbSteelKindType.Text) Then
            tbSteelKindType.Text = tbSteelKindType.Text.Replace("'", Nothing)
            ReturnWhereValue &= IIf(tbSteelKindType.Text.Trim.Length > 0, " AND (RTRIM(C.BLA02) || C.BLA18) IN ('" & tbSteelKindType.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbCoilNumber.Text) Then
            tbCoilNumber.Text = tbCoilNumber.Text.Replace("'", Nothing)
            ReturnWhereValue &= IIf(tbCoilNumber.Text.Trim.Length > 0, " AND (RTRIM(A.QCG02) || A.QCG03)  IN ('" & tbCoilNumber.Text.Replace(",", "','") & "')", Nothing)
        End If
        If Not String.IsNullOrEmpty(tbProductLines.Text) Then
            tbProductLines.Text = tbProductLines.Text.Replace("'", Nothing)
            ReturnWhereValue &= IIf(tbProductLines.Text.Trim.Length > 0, " AND A.QCG04 IN ('" & tbProductLines.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbDriection.Text) Then
            tbDriection.Text = tbDriection.Text.Replace("'", Nothing)
            ReturnWhereValue &= IIf(tbDriection.Text.Trim.Length > 0, " AND A.QCG05 IN ('" & tbDriection.Text.Replace(",", "','") & "')", Nothing)
        End If


        Me.hfPPSSHAPFQry.Value = "Select SHA01,SHA02,SHA04,SHA08,SHA14,SHA15 from @#PPS100LB.PPSSHALC  Where  SHA01 || SHA02 IN (Select A.QCG02 || A.QCG03 from @#PPS100LB.PPSQCGPF A  LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.QCG02 = C.BLA09 Where 1=1 " & ReturnWhereValue & " ) "
        Me.hfControlSQLMaker.Value = "Select A.*,C.* from @#PPS100LB.PPSQCGPF A  LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.QCG02 = C.BLA09 Where 1=1 " & ReturnWhereValue
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SQLMakerToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        SQLMakerToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfControlSQLMaker.Value, Me.hfPPSSHAPFQry.Value), "性理性能查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

    Protected Sub btnClearSearchField_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearchField.Click
        tbLotsNumber.Text = Nothing
        tbStartThick.Text = "0.0"
        tbEndThick.Text = "99.9"
        tbSteelKindType.Text = Nothing
        tbCoilNumber.Text = Nothing
    End Sub
End Class