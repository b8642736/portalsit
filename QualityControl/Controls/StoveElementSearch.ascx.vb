Public Partial Class StoveElementSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal DFAndMD30Range As String) As QualityControlDataSet.StoveElementSearchDataTableDataTable

        Dim ReturnValue As New QualityControlDataSet.StoveElementSearchDataTableDataTable
        Dim ShowTitleInfoKey As DataRow = Nothing

        Dim QryString As String = SQLString
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim AdapterResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList

        Dim DFAndMD30s As List(Of Single) = (From A In DFAndMD30Range.Split(",") Select CType(A, Single)).ToList
        If DFAndMD30s(0) <> -999 OrElse DFAndMD30s(1) <> 999 Then   'DF篩選
            AdapterResult = (From A In AdapterResult Where (CType(A.Item("QCA05"), String).Substring(0, 1) = "2" And CType(A.Item("DF_2"), Single) >= DFAndMD30s(0) And CType(A.Item("DF_2"), Single) <= DFAndMD30s(1)) Or CType(A.Item("QCA05"), String).Substring(0, 1) = "3" Select A).ToList
            AdapterResult = (From A In AdapterResult Where (CType(A.Item("QCA05"), String).Substring(0, 1) = "3" And CType(A.Item("DF_3"), Single) >= DFAndMD30s(0) And CType(A.Item("DF_3"), Single) <= DFAndMD30s(1)) Or CType(A.Item("QCA05"), String).Substring(0, 1) = "2" Select A).ToList
        End If
        If DFAndMD30s(2) <> -999 OrElse DFAndMD30s(3) <> 999 Then   'MD30篩選
            AdapterResult = (From A In AdapterResult Where CType(A.Item("MD30"), Single) >= DFAndMD30s(2) And CType(A.Item("MD30"), Single) <= DFAndMD30s(3) Select A).ToList
        End If

        Dim NumberCount As Integer = 0
        Dim ADDItem As QualityControlDataSet.StoveElementSearchDataTableRow = Nothing
        For Each EachItem As DataRow In AdapterResult
            Dim EachItemTemp As DataRow = EachItem
            ADDItem = ReturnValue.NewRow
            With ADDItem
                NumberCount += 1
                .序號 = NumberCount
                .批號 = EachItem.Item("SGA33")
                .爐號 = EachItem.Item("QCA01")
                .鋼種 = EachItem.Item("QCA05")
                .材質 = EachItem.Item("QCA06")
                .日期 = EachItem.Item("QCA02")
                .DF = IIf(CType(EachItem.Item("QCA05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                .MD30 = EachItem.Item("MD30")
                .C = EachItem.Item("QCA07")
                .SI = EachItem.Item("QCA08")
                .MN = EachItem.Item("QCA09")
                .P = EachItem.Item("QCA10")
                .S = EachItem.Item("QCA11")
                .CR = EachItem.Item("QCA12")
                .NI = EachItem.Item("QCA13")
                .CU = EachItem.Item("QCA14")
                .MO = EachItem.Item("QCA15")
                .CO = EachItem.Item("QCA16")
                .AL = EachItem.Item("QCA17")
                .SN = EachItem.Item("QCA18")
                .PB = EachItem.Item("QCA19")
                .TI = EachItem.Item("QCA20")
                .NB = EachItem.Item("QCA21")
                .V = EachItem.Item("QCA22")
                .W = EachItem.Item("QCA23")
                .O2 = EachItem.Item("QCA24")
                .N2 = EachItem.Item("QCA25")
                .H2 = EachItem.Item("QCA26")
                .B = EachItem.Item("QCA27")
                .Ca = EachItem.Item("QCA28") / 100
                .Mg = EachItem.Item("QCA29") / 100
                .Fe = EachItem.Item("QCA30")
                ShowTitleInfoKey = ADDItem
            End With
            ReturnValue.Rows.Add(ADDItem)
        Next

        Return ReturnValue
    End Function
#End Region
#Region "查詢格1 方法:Search1"
    ''' <summary>
    ''' 查詢格1
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search1(ByVal SQLString As String, ByVal DFAndMD30Range As String) As QualityControlDataSet.StoveElementSearchDataTableDataTable
        Dim GetDatas As QualityControlDataSet.StoveElementSearchDataTableDataTable = Search(SQLString, DFAndMD30Range)
        Dim AverageDatas As New List(Of QualityControlDataSet.StoveElementSearchDataTableRow)
        Dim TotalDatas As New List(Of QualityControlDataSet.StoveElementSearchDataTableRow)

        Dim AddItem As QualityControlDataSet.StoveElementSearchDataTableRow
        Dim AddItem2 As QualityControlDataSet.StoveElementSearchDataTableRow
        Dim ReturnValue As New QualityControlDataSet.StoveElementSearchDataTableDataTable
        Dim SteelKindMaterialSubDatas As New List(Of QualityControlDataSet.StoveElementSearchDataTableRow)
        For Each EachSteelKindMaterial As String In (From A In GetDatas Select A.鋼種 & A.材質 Distinct).ToArray
            Dim EachSteelKindMaterialTemp As String = EachSteelKindMaterial
            SteelKindMaterialSubDatas = (From A In GetDatas Where A.鋼種 & A.材質 = EachSteelKindMaterialTemp Select A Order By A.爐號).ToList
            Dim NumberCount As Integer = 0
            AverageDatas.Clear() : NumberCount = 0
            For Each EachItem As QualityControlDataSet.StoveElementSearchDataTableRow In (From A In SteelKindMaterialSubDatas Where A.爐號 Like "A*" Select A).ToArray
                AddItem = ReturnValue.NewRow
                CopyRowToNewRow(EachItem, AddItem)
                NumberCount += 1 : AddItem.序號 = NumberCount
                AverageDatas.Add(AddItem)
                TotalDatas.Add(AddItem)
                ReturnValue.Rows.Add(AddItem)
            Next
            If AverageDatas.Count > 0 Then
                AddItem = ReturnValue.NewRow
                AddItem.爐號 = "A爐平均:"
                AverageColumnVlue(AverageDatas, AddItem)
                ReturnValue.Rows.Add(AddItem)

                AddItem2 = ReturnValue.NewRow
                AddItem2.爐號 = "A爐標準差:"
                STDColumnVlue(AverageDatas, AddItem2)
                ReturnValue.Rows.Add(AddItem2)
            End If

            AverageDatas.Clear() : NumberCount = 0
            For Each EachItem As QualityControlDataSet.StoveElementSearchDataTableRow In (From A In SteelKindMaterialSubDatas Where A.爐號 Like "B*" Select A).ToList
                AddItem = ReturnValue.NewRow
                CopyRowToNewRow(EachItem, AddItem)
                NumberCount += 1 : AddItem.序號 = NumberCount
                AverageDatas.Add(AddItem)
                TotalDatas.Add(AddItem)
                ReturnValue.Rows.Add(AddItem)
            Next
            If AverageDatas.Count > 0 Then
                AddItem = ReturnValue.NewRow
                AddItem.爐號 = "B爐平均:"
                AverageColumnVlue(AverageDatas, AddItem)
                ReturnValue.Rows.Add(AddItem)

                AddItem2 = ReturnValue.NewRow
                AddItem2.爐號 = "B爐標準差:"
                STDColumnVlue(AverageDatas, AddItem2)
                ReturnValue.Rows.Add(AddItem2)
            End If

        Next
        If GetDatas.Count > 0 Then
            AddItem = ReturnValue.NewRow
            AddItem.爐號 = "總平均:"
            AverageColumnVlue(TotalDatas, AddItem)
            ReturnValue.Rows.Add(AddItem)

            AddItem2 = ReturnValue.NewRow
            AddItem2.爐號 = "總標準差:"
            STDColumnVlue(TotalDatas, AddItem2)
            ReturnValue.Rows.Add(AddItem2)
        End If


        Return ReturnValue
    End Function

    Private Sub CopyRowToNewRow(ByRef SourceRow As DataRow, ByRef ToNewRow As DataRow)
        For Each EachColumnName In (From A In SourceRow.Table.Columns Select CType(A, DataColumn).ColumnName).ToList
            ToNewRow.Item(EachColumnName) = SourceRow.Item(EachColumnName)
        Next
    End Sub

    Private Sub AverageColumnVlue(ByRef SourceRows As List(Of QualityControlDataSet.StoveElementSearchDataTableRow), ByRef ToNewRow As QualityControlDataSet.StoveElementSearchDataTableRow)
        For Each EachColumnName In (From A In ToNewRow.Table.Columns Select CType(A, DataColumn).ColumnName).ToList
            Dim EachColumnNameTemp As String = EachColumnName
            Dim NotFieldNames() As String = {"序號", "批號", "爐號", "鋼種", "材質", "日期"}
            If Not NotFieldNames.Contains(EachColumnName.Trim) Then
                Try
                    Dim GetValue As Single = (From A In SourceRows Select CType(A.Item(EachColumnNameTemp), Single)).Average
                    ToNewRow.Item(EachColumnName) = GetValue
                Catch ex As Exception
                    Stop
                End Try
            End If
        Next
    End Sub

    Private Sub STDColumnVlue(ByRef SourceRows As List(Of QualityControlDataSet.StoveElementSearchDataTableRow), ByRef ToNewRow As QualityControlDataSet.StoveElementSearchDataTableRow)
        For Each EachColumnName In (From A In ToNewRow.Table.Columns Select CType(A, DataColumn).ColumnName).ToList
            Dim EachColumnNameTemp As String = EachColumnName
            Dim NotFieldNames() As String = {"序號", "批號", "爐號", "鋼種", "材質", "日期"}
            If Not NotFieldNames.Contains(EachColumnName.Trim) Then
                Try
                    Dim GetValue As List(Of Single) = (From A In SourceRows Select CType(A.Item(EachColumnNameTemp), Single)).ToList
                    GetValue = (From A In GetValue Where A <> 0 Select A).ToList
                    Dim StdValue As Single = Math.Sqrt((From A In GetValue Select (A - GetValue.Average) ^ 2).Sum / GetValue.Count)
                    ToNewRow.Item(EachColumnName) = Format(StdValue, "0.000000")
                Catch ex As Exception
                    'ToNewRow.Item(EachColumnName) = ex.ToString
                End Try
            End If
        Next
    End Sub
#End Region

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
        End Set
    End Property
#End Region
#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Dim IsFilterBatchNumber As Boolean = (Not String.IsNullOrEmpty(tbLotsNumbers.Text)) AndAlso tbLotsNumbers.Text.Trim.Length > 0
        Dim ReturnValue As String = Nothing
        Dim WhereValue As String = Nothing
        If IsFilterBatchNumber Then '篩選批號
            ReturnValue = "Select  A.* " & If(IsFilterBatchNumber, " ,B.* ", Nothing) & _
           ",3.66 * A.QCA12 + 5.64 * A.QCA08 + 0.84 * A.QCA15 - 75.78 * A.QCA07 - 71.62 * A.QCA25 - 2.87 * A.QCA13 - 0.16 * A.QCA09 - 0.08 * A.QCA14 - 36.63 AS DF_2" & _
           ",3 * A.QCA12 + 4.5 * A.QCA08 + 3 * A.QCA15 - 2.8 * A.QCA13 - 84 * (A.QCA07 + A.QCA25) - 1.4 * (A.QCA09 + A.QCA14) - 19.8 AS DF_3" & _
           ",413 - (A.QCA07 + A.QCA25) * 462 - 9.2 * A.QCA08 - 8.1 * A.QCA09 - 13.7 * A.QCA12 - 9.5 * A.QCA13 - 18.5 * A.QCA15 AS MD30 , '' AS SGA33 " & _
           " From  @#PPS100LB.PPSQCAPF AS A LEFT OUTER JOIN  @#SMS100LB.SMSSGAPF AS B ON A.QCA01=B.SGA01 AND A.QCA02<=(B.SGA07 + 3) AND  A.QCA02>=(B.SGA07 - 3) AND B.SGA03=1 WHERE NOT QCA33 LIKE 'LOSS%'  "
            tbLotsNumbers.Text = tbLotsNumbers.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.SGA33 IN ('" & tbLotsNumbers.Text.Replace(",", "','") & "')", Nothing)
        Else
            ReturnValue = "Select A.* " & If(IsFilterBatchNumber, " ,B.SGA33 ", ", '' AS SGA33 ") & _
            ",3.66 * A.QCA12 + 5.64 * A.QCA08 + 0.84 * A.QCA15 - 75.78 * A.QCA07 - 71.62 * A.QCA25 - 2.87 * A.QCA13 - 0.16 * A.QCA09 - 0.08 * A.QCA14 - 36.63 AS DF_2" & _
            ",3 * A.QCA12 + 4.5 * A.QCA08 + 3 * A.QCA15 - 2.8 * A.QCA13 - 84 * (A.QCA07 + A.QCA25) - 1.4 * (A.QCA09 + A.QCA14) - 19.8 AS DF_3" & _
            ",413 - (A.QCA07 + A.QCA25) * 462 - 9.2 * A.QCA08 - 8.1 * A.QCA09 - 13.7 * A.QCA12 - 9.5 * A.QCA13 - 18.5 * A.QCA15 AS MD30 " & _
            " From  @#PPS100LB.PPSQCAPF A "
            WhereValue &= " WHERE NOT QCA33 LIKE 'LOSS%' "
        End If

        If Not String.IsNullOrEmpty(tbSteelKind.Text) Then  '鋼種材質篩選
            tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbSteelKind.Text.Trim.Length > 0, "  AND (RTRIM(A.QCA05) || A.QCA06) IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbStove.Text) AndAlso tbStove.Text.Trim.Length > 0 Then
            Dim AddWhereString1 As String = Nothing
            Dim AddWhereString2 As String = Nothing
            For Each EachStoveRange As String In tbStove.Text.Trim.Split(",")   '成份篩選
                If EachStoveRange.Contains("~") Then
                    AddWhereString1 &= IIf(String.IsNullOrEmpty(AddWhereString1), Nothing, " OR ")
                    AddWhereString1 &= " QCA01>='" & EachStoveRange.Split("~")(0).Trim & "' AND QCA01<='" & EachStoveRange.Split("~")(1).Trim & "' "
                Else
                    AddWhereString2 &= IIf(String.IsNullOrEmpty(AddWhereString2), Nothing, ",") & "'" & EachStoveRange.Trim & "'"
                End If
            Next
            Dim AddWhereString As String = Nothing
            AddWhereString &= AddWhereString1
            If Not String.IsNullOrEmpty(AddWhereString2) Then
                AddWhereString &= IIf(String.IsNullOrEmpty(AddWhereString), Nothing, " OR ") & " QCA01 IN (" & AddWhereString2 & ")"
            End If
            WhereValue &= " AND (" & AddWhereString & ")"
        End If


        For Each EachItem As ListItem In lbElements.Items
            Dim Datas() As String = EachItem.Value.Split(":")
            WhereValue &= " AND QCA" & Datas(0) & " >= " & Datas(1) & " AND QCA" & Datas(0) & " <= " & Datas(2)

            'If EachItem.Text.ToUpper = "CA" OrElse EachItem.Text.ToUpper = "MG" Then
            '    WhereValue &= " QCA" & Datas(0) & "/100 >= " & Datas(1) & " AND QCA" & Datas(0) & "/100 <= " & Datas(2)
            'Else
            '    WhereValue &= " QCA" & Datas(0) & " >= " & Datas(1) & " AND QCA" & Datas(0) & " <= " & Datas(2)
            'End If

        Next
        If CheckBox1.Checked Then
            Dim StartDateTime As DateTime = CType(Me.tbStartDate.Text, Date).AddHours(Val(tbStartHour.Text)).AddMinutes(Val(tbStartMinute.Text))
            Dim EndDateTime As DateTime = CType(Me.tbEndDate.Text, Date).AddHours(Val(tbEndHour.Text)).AddMinutes(Val(tbEndMinute.Text))
            Dim StartDateValue As Integer = (Format(StartDateTime.AddDays(1), "yyyy") - 1911) * 10000 + Format(StartDateTime.AddDays(1), "MMdd")
            Dim EndDateValue As Integer = (Format(EndDateTime.AddDays(-1), "yyyy") - 1911) * 10000 + Format(EndDateTime.AddDays(-1), "MMdd")
            WhereValue &= " AND ( "
            WhereValue &= " QCA02>=" & StartDateValue & " AND QCA02<=" & EndDateValue
            StartDateValue = (Format(StartDateTime, "yyyy") - 1911) * 10000 + Format(StartDateTime, "MMdd")
            EndDateValue = (Format(EndDateTime, "yyyy") - 1911) * 10000 + Format(EndDateTime, "MMdd")
            WhereValue &= " OR (QCA02=" & StartDateValue & " AND (QCA03*100+QCA04)>=" & StartDateTime.Hour * 100 + StartDateTime.Minute & ")"
            WhereValue &= " OR (QCA02=" & EndDateValue & " AND (QCA03*100+QCA04)<=" & EndDateTime.Hour * 100 + EndDateTime.Minute & ")"
            WhereValue &= " ) "
        End If

        Me.hfSQLString.Value = ReturnValue & WhereValue & " Order by " & IIf(IsFilterBatchNumber, "B.SGA33 , ", Nothing) & " A.QCA01"
        Me.hfDFAndMD30Range.Value = (Me.txDF1.Text & "," & Me.txDF2.Text & "," & Me.txMD301.Text & "," & Me.txMD302.Text).Replace("'", Nothing)
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
            tbEndDate.Text = Format(New Date(Now.Year, Now.Month, 1).AddMonths(1), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        'Me.CustomValidator1.IsValid = Not (String.IsNullOrEmpty(tbStove.Text) OrElse tbStove.Text.Trim.Length = 0)
        'If Me.CustomValidator1.IsValid = False Then
        '    Exit Sub
        'End If
        IsUserAlreadyPutSearch = True
        SetQryStringToControl()
        If RadioButtonList1.SelectedValue = "0" Then
            MultiView1.SetActiveView(Me.View1)
            GridView1.DataBind()
        Else
            MultiView1.SetActiveView(Me.View2)
        End If
    End Sub

    Protected Sub btnAddElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddElement.Click
        Try
            Dim AddItem As New ListItem
            AddItem.Text = DropDownList1.SelectedItem.Text & ":" & CType(tbElementStartValue.Text.Trim, Single).ToString & "~" & CType(tbElementEndValue.Text.Trim, Single).ToString
            If DropDownList1.SelectedItem.Text.ToUpper = "CA" OrElse DropDownList1.SelectedItem.Text.ToUpper = "MG" Then
                AddItem.Value = DropDownList1.SelectedItem.Value & "/100:" & CType(tbElementStartValue.Text.Trim, Single).ToString & ":" & CType(tbElementEndValue.Text.Trim, Single).ToString
            Else
                AddItem.Value = DropDownList1.SelectedItem.Value & ":" & CType(tbElementStartValue.Text.Trim, Single).ToString & ":" & CType(tbElementEndValue.Text.Trim, Single).ToString
            End If
            lbElements.Items.Add(AddItem)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDeleteElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteElement.Click
        If Not IsNothing(lbElements.SelectedItem) Then
            lbElements.Items.Remove(lbElements.SelectedItem)
        End If
    End Sub

    Protected Sub tbClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbClearSearchCondiction.Click
        IsUserAlreadyPutSearch = False
        tbStove.Text = Nothing
        Call btnDeleteElement_Click(Nothing, Nothing)
    End Sub

    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        Me.IsUserAlreadyPutSearch = True
        SetQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        If RadioButtonList1.SelectedValue = "0" Then
            ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value), "爐號成份查詢" & Format(Now, "mmss") & ".xls")
        Else
            ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search1(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value), "爐號成份查詢" & Format(Now, "mmss") & ".xls")
        End If
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub
End Class