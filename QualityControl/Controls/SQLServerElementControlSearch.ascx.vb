Public Class SQLServerElementControlSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal LookElements As String) As QualityControlDataSet.SQLServerElementControlSearchDataTable
        Dim ReturnValue As New QualityControlDataSet.SQLServerElementControlSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If

        Dim QryString As String = SQLString
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim SearchResult As List(Of DataRow) = (From A In Adapter.SelectQuery(SQLString).Rows Select CType(A, DataRow)).ToList

        Dim DBDataContext As New CompanyLINQDB.SMPDataContext
        Dim JudgeDatas As List(Of CompanyLINQDB.製程判定) = (From A In DBDataContext.製程判定 Where A.站別 Like "C*" And (From B In SearchResult Select B.Item("鋼種").ToString.Trim & B.Item("材質").ToString.Trim Distinct).ToList.Contains(A.鋼種.Trim & A.材質.Trim) Select A).ToList

        For Each EachSteelKind As String In (From A In SearchResult Select CType(A.Item("鋼種"), String).Trim & CType(A.Item("材質"), String).Trim Distinct).ToList
            Dim EachSteelKindTemp As String = EachSteelKind
            Dim SubDatas1 As List(Of DataRow) = (From A In SearchResult Where EachSteelKindTemp = A.Item("鋼種").ToString.Trim & A.Item("材質").ToString.Trim Select A).ToList
            For Each EachElement As String In LookElements.Split(",")
                AddGroupDatasToTargetTable(SubDatas1, JudgeDatas, ReturnValue, EachSteelKindTemp & "," & EachElement)
            Next
            'AddGroupDatasToTargetTable(SubDatas1, JudgeDatas, ReturnValue, EachSteelKindTemp)
        Next
        'AddGroupDatasToTargetTable(SearchResult, JudgeDatas, ReturnValue)

        Return ReturnValue
    End Function

    Private Sub AddGroupDatasToTargetTable(ByVal SourceDatas As List(Of DataRow), ByVal JudgeDatas As List(Of CompanyLINQDB.製程判定), ByVal TargetTable As QualityControlDataSet.SQLServerElementControlSearchDataTable, Optional ByVal TitleNames As String = Nothing)
        If SourceDatas.Count = 0 Then
            Exit Sub
        End If
        Dim AddItem As QualityControlDataSet.SQLServerElementControlSearchRow = TargetTable.NewRow
        Dim SumElementValue As Double = 0
        Dim W_AssayIDList() As String = Nothing

        With AddItem
            Select Case True
                'Case IsNothing(TitleNames)  '總計

                'Case TitleNames.Split(",").Count = 1    '鋼種材質小計
                '    .鋼種材質 = TitleNames.Split(",")(0)
                '    .成份 = "--"
                '    .冶煉爐數 = SourceDatas.Count
                '    .平均值 = "--"
                '    .管制圍範 = "--"

                Case TitleNames.Split(",").Count = 2    '鋼種材質+成份小計
                    .鋼種材質 = TitleNames.Split(",")(0)
                    .成份 = TitleNames.Split(",")(1)
                    .冶煉爐數 = SourceDatas.Count
                    For Each EachItem As DataRow In SourceDatas
                        Select Case .成份
                            Case "CAndN", "NbAndTa"


                                If .成份 = "CAndN" Then
                                    W_AssayIDList = New String() {"C", "N1"}
                                ElseIf .成份 = "NbAndTa" Then
                                    W_AssayIDList = New String() {"Nb", "Ta"}
                                End If

                                For Each W_AssayID As String In W_AssayIDList
                                    If Not IsDBNull(EachItem.Item(W_AssayID)) Then
                                        SumElementValue += CType(EachItem.Item(W_AssayID), Double)
                                    End If
                                Next

                            Case Else
                                If Not IsDBNull(EachItem.Item(.成份)) Then
                                    SumElementValue += CType(EachItem.Item(.成份), Double)
                                End If
                        End Select
                    Next
            End Select

            .平均值 = Format(SumElementValue / SourceDatas.Count, "#.######")
            Dim RangeValue As List(Of Single) = GetLowHighElementRange(JudgeDatas, .鋼種材質, .成份)
            .管制圍範 = RangeValue(0) & "~" & RangeValue(1)

            '.超出下限爐數 = (From A In SourceDatas Where CType(A.Item(.成份), Single) < RangeValue(0) Select A).Count
            '.超出上限爐數 = (From A In SourceDatas Where CType(A.Item(.成份), Single) > RangeValue(1) Select A).Count
            '.不合格爐數 = (From A In SourceDatas Where CType(A.Item(.成份), Single) < RangeValue(0) Or CType(A.Item(.成份), Single) > RangeValue(1) Select A).Count

            Select Case .成份
                Case "CAndN", "NbAndTa"
                    .超出下限爐數 = (From A In SourceDatas Where (CType(ModTools.NoNull(A.Item(W_AssayIDList(0)), 0), Single) + CType(ModTools.NoNull(A.Item(W_AssayIDList(1)), 0), Single)) < RangeValue(0) Select A).Count
                    .超出上限爐數 = (From A In SourceDatas Where (CType(ModTools.NoNull(A.Item(W_AssayIDList(0)), 0), Single) + CType(ModTools.NoNull(A.Item(W_AssayIDList(1)), 0), Single)) > RangeValue(1) Select A).Count
                    .不合格爐數 = (Integer.Parse(.超出下限爐數) + Integer.Parse(.超出上限爐數))

                Case Else
                    .超出下限爐數 = (From A In SourceDatas Where CType(ModTools.NoNull(A.Item(.成份), 0), Single) < RangeValue(0) Select A).Count
                    .超出上限爐數 = (From A In SourceDatas Where CType(ModTools.NoNull(A.Item(.成份), 0), Single) > RangeValue(1) Select A).Count
                    .不合格爐數 = (From A In SourceDatas Where CType(ModTools.NoNull(A.Item(.成份), 0), Single) < RangeValue(0) Or CType(ModTools.NoNull(A.Item(.成份), 0), Single) > RangeValue(1) Select A).Count

            End Select

        End With
        TargetTable.Rows.Add(AddItem)
    End Sub

    Private Function GetLowHighElementRange(ByVal JudgeDatas As List(Of CompanyLINQDB.製程判定), ByVal FindSteelKind As String, ByVal FindElementName As String) As List(Of Single)
        Dim ReturnValue As New List(Of Single)
        ReturnValue.Add(-999)
        ReturnValue.Add(999)

        Dim HDataRow As CompanyLINQDB.製程判定 = (From A In JudgeDatas Where A.上下限 = "H" And (A.鋼種.Trim & A.材質.Trim) = FindSteelKind.Trim Select A).FirstOrDefault
        Dim LDataRow As CompanyLINQDB.製程判定 = (From A In JudgeDatas Where A.上下限 = "L" And (A.鋼種.Trim & A.材質.Trim) = FindSteelKind.Trim Select A).FirstOrDefault

        If Not IsNothing(LDataRow) AndAlso Not LDataRow.IsNullElementValue(FindElementName) Then
            ReturnValue(0) = LDataRow.GetElementValue(FindElementName)
        End If
        If Not IsNothing(HDataRow) AndAlso Not HDataRow.IsNullElementValue(FindElementName) Then
            ReturnValue(1) = HDataRow.GetElementValue(FindElementName)
        End If
        Return ReturnValue

    End Function

#End Region

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        'Dim IsFilterBatchNumber As Boolean = (Not String.IsNullOrEmpty(tbLotsNumbers.Text)) AndAlso tbLotsNumbers.Text.Trim.Length > 0
        Dim ReturnValue As String = "Select * From 分析資料 WHERE 站別 LIKE 'C%' "
        Dim WhereValue As String = Nothing

        Dim StartDateValue As String = Format(CType(Me.tbStartDate.Text, Date), "yyyyMMdd HH:mm:ss")
        Dim EndDateValue As String = Format(CType(Me.tbEndDate.Text, Date), "yyyyMMdd HH:mm:ss")
        WhereValue &= " AND (RIGHT(STR(日期+19110000),8) +' ' + 時間) >= '" & StartDateValue & "' AND (RIGHT(STR(日期+19110000),8) +' ' + 時間) <= '" & EndDateValue & "'"

        If Not String.IsNullOrEmpty(tbSteelKind.Text) Then  '鋼種材質篩選
            tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbSteelKind.Text.Trim.Length > 0, "  AND RTRIM(LTRIM(鋼種)) + RTRIM(LTRIM(材質)) IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbStove.Text) AndAlso tbStove.Text.Trim.Length > 0 Then
            Dim AddWhereString1 As String = Nothing
            Dim AddWhereString2 As String = Nothing
            For Each EachStoveRange As String In tbStove.Text.Trim.Split(",")
                If EachStoveRange.Contains("~") Then
                    AddWhereString1 &= IIf(String.IsNullOrEmpty(AddWhereString1), Nothing, " OR ")
                    AddWhereString1 &= " 爐號 >='" & EachStoveRange.Split("~")(0).Trim & "' AND 爐號 <='" & EachStoveRange.Split("~")(1).Trim & "' "
                Else
                    AddWhereString2 &= IIf(String.IsNullOrEmpty(AddWhereString2), Nothing, ",") & "'" & EachStoveRange.Trim & "'"
                End If
            Next
            Dim AddWhereString As String = Nothing
            AddWhereString &= AddWhereString1
            If Not String.IsNullOrEmpty(AddWhereString2) Then
                AddWhereString &= IIf(String.IsNullOrEmpty(AddWhereString), Nothing, " OR ") & " 爐號 IN (" & AddWhereString2 & ")"
            End If
            WhereValue &= " AND (" & AddWhereString & ")"
        End If

        Dim SetLookElements As String = Nothing
        If lbElements.Items.Count = 0 Then
            For Each EachItem As ListItem In DropDownList1.Items
                SetLookElements &= IIf(String.IsNullOrEmpty(SetLookElements), Nothing, ",") & EachItem.Value
            Next
        Else
            For Each EachItem As ListItem In lbElements.Items   '不合格成份查詢
                SetLookElements &= IIf(String.IsNullOrEmpty(SetLookElements), Nothing, ",") & EachItem.Value.Trim
            Next
        End If


        Select Case True
            Case rbCheckMaterial.SelectedValue = "Y"
                WhereValue &= " AND 驗收料 = 'Y' "
            Case rbCheckMaterial.SelectedValue = "N"
                WhereValue &= " AND 驗收料 <> 'Y' "
        End Select

        Me.hfQry.Value = ReturnValue & WhereValue & " Order by 鋼種,材質"
        Me.hfLookElements.Value = SetLookElements
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
            tbEndDate.Text = Format(New Date(Now.Year, Now.Month, 1).AddMonths(1), "yyyy/MM/dd")
        End If

    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        SetQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnAddElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddElement.Click
        lbElements.Items.Add(New ListItem(DropDownList1.SelectedItem.Text, DropDownList1.SelectedItem.Value))
    End Sub

    Protected Sub btnDeleteElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteElement.Click
        If Not IsNothing(lbElements.SelectedItem) Then
            lbElements.Items.Remove(lbElements.SelectedItem)
        End If
    End Sub

    Protected Sub tbClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbClearSearchCondiction.Click
        tbSteelKind.Text = Nothing
        tbStove.Text = Nothing
        rbCheckMaterial.Items(0).Selected = True
    End Sub

    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        SetQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQry.Value, Me.hfLookElements.Value), "SQLServer爐號成份查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class