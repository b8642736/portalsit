Public Class CategorySum
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    'Public Shared Function Search(ByVal SQLQry As String) As List(Of AST500LBDataSet.CategorySumRow)
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLQry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLQry As String) As AST500LBDataSet.CategorySumDataTable
        If String.IsNullOrEmpty(SQLQry) OrElse SQLQry.Trim.Length = 0 Then
            Return New AST500LBDataSet.CategorySumDataTable
        End If
        Dim ReturnValue As New AST500LBDataSet.CategorySumDataTable
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As DataTable = Adapter.SelectQuery(SQLQry)
        For Each EachFactory As String In (From A In SearchResult Select CType(A.Item("FactoryName"), String).Trim Distinct)
            Dim EachFactoryTemp As String = EachFactory
            Dim SubDatas As List(Of DataRow) = (From A In SearchResult Where CType(A.Item("FactoryName"), String).Trim = EachFactoryTemp.Trim Select A).ToList
            For Each EachCategory As String In (From A In SubDatas Select CType(A.Item("NUMBER"), String).Trim.Substring(0, 1) Distinct)
                Dim EachCategoryTemp As String = EachCategory
                Dim SubDatas1 As New List(Of DataRow) '= (From A In SubDatas Where CType(A.Item("NUMBER"), String).Trim.Substring(0, 1) = EachCategoryTemp Select A).ToList
                If EachCategoryTemp = "1" Then
                    '土地需區分 土地 及 土地改良物
                    SubDatas1 = (From A In SubDatas Where CType(A.Item("NUMBER"), String).Trim.Substring(0, 1) = EachCategoryTemp And CType(A.Item("NUMBER"), String).Trim < "1110101" Select A).ToList
                    If SubDatas1.Count > 0 Then
                        AddSummaryRecord(ReturnValue, SubDatas1, {CType(SubDatas1(0).Item("FactoryName"), String).Trim, CType(SubDatas1(0).Item("NUMBER"), String).Trim})
                    End If
                    SubDatas1 = (From A In SubDatas Where CType(A.Item("NUMBER"), String).Trim.Substring(0, 1) = EachCategoryTemp And CType(A.Item("NUMBER"), String).Trim >= "1110101" Select A).ToList
                    If SubDatas1.Count > 0 Then
                        AddSummaryRecord(ReturnValue, SubDatas1, {CType(SubDatas1(0).Item("FactoryName"), String).Trim, CType(SubDatas1(0).Item("NUMBER"), String).Trim})
                    End If
                Else
                    SubDatas1 = (From A In SubDatas Where CType(A.Item("NUMBER"), String).Trim.Substring(0, 1) = EachCategoryTemp Select A).ToList
                    If SubDatas1.Count > 0 Then
                        AddSummaryRecord(ReturnValue, SubDatas1, {CType(SubDatas1(0).Item("FactoryName"), String).Trim, CType(SubDatas1(0).Item("NUMBER"), String).Trim})
                    End If
                End If
            Next
            If SubDatas.Count > 0 Then
                AddSummaryRecord(ReturnValue, SubDatas, {"", CType(SubDatas(0).Item("NUMBER"), String).Trim})
            End If
        Next
        '依科目小計
        For Each EachItem As String In (From A In SearchResult Select CType(A.Item("NUMBER"), String).Substring(0, 1) Distinct).ToList
            Dim CategoryDatas As List(Of DataRow) = Nothing
            If EachItem = "1" Then
                CategoryDatas = (From A In SearchResult Where CType(A.Item("NUMBER"), String).Trim.Substring(0, 1) = EachItem And CType(A.Item("NUMBER"), String).Trim < "1110101" Select A).ToList
                If CategoryDatas.Count > 0 Then
                    AddSummaryRecord(ReturnValue, CategoryDatas, {"ALL", CType(CategoryDatas(0).Item("NUMBER"), String).Trim})
                End If
                CategoryDatas = (From A In SearchResult Where CType(A.Item("NUMBER"), String).Trim.Substring(0, 1) = EachItem And CType(A.Item("NUMBER"), String).Trim >= "1110101" Select A).ToList
                If CategoryDatas.Count > 0 Then
                    AddSummaryRecord(ReturnValue, CategoryDatas, {"ALL", CType(CategoryDatas(0).Item("NUMBER"), String).Trim})
                End If
            Else
                CategoryDatas = (From A In SearchResult Where CType(A.Item("NUMBER"), String).Trim.Substring(0, 1) = EachItem Select A).ToList
                AddSummaryRecord(ReturnValue, CategoryDatas, {"ALL", CType(CategoryDatas(0).Item("NUMBER"), String).Trim})
            End If
        Next

        '總計
        AddSummaryRecord(ReturnValue, (From A In SearchResult Select A).ToList)
        Return ReturnValue
    End Function

    Private Sub AddSummaryRecord(ByVal TargetReturnValues As AST500LBDataSet.CategorySumDataTable, ByVal SourceDatas As List(Of DataRow), Optional ByVal FilterKeys() As String = Nothing)
        If SourceDatas.Count = 0 Then
            Exit Sub
        End If
        'Dim FilterKeys() As String = Nothing
        'If IsNothing(SetFilterKeys) Then
        '    FilterKeys = SetFilterKeys.Split(",")
        'End If

        Dim AddItem As AST500LBDataSet.CategorySumRow = TargetReturnValues.NewRow
        With AddItem
            Select Case True
                Case IsNothing(FilterKeys)
                    .事業單位 = "總計:"
                    .本月結存 = (From A In SourceDatas Select CType(A.Item("AMOUNT"), Double) - CType(A.Item("DEPR"), Double)).Sum

                Case FilterKeys.Count = 2 AndAlso FilterKeys(0).Trim = "ALL" And FilterKeys(1).Trim <> "" '以 科目區別小計
                    .事業單位 = "所有事業單位"
                    .科目 = GetCategoryName(FilterKeys(1))
                    .本月結存 = (From A In SourceDatas Select CType(A.Item("AMOUNT"), Double) - CType(A.Item("DEPR"), Double)).Sum
                Case FilterKeys.Count = 2 AndAlso FilterKeys(0).Trim = "" And FilterKeys(1).Trim <> "" '以 事業單位小計
                    .事業單位 = "小計:"
                    .科目 = ""
                    .本月結存 = (From A In SourceDatas Select CType(A.Item("AMOUNT"), Double) - CType(A.Item("DEPR"), Double)).Sum
                Case FilterKeys.Count = 2 AndAlso FilterKeys(0).Trim <> ""  '以 事業單位/科目 區別
                    .事業單位 = GetFactoryName(FilterKeys(0))
                    .科目 = GetCategoryName(FilterKeys(1))
                    .本月結存 = (From A In SourceDatas Select CType(A.Item("AMOUNT"), Double) - CType(A.Item("DEPR"), Double)).Sum
                Case Else
                    Exit Sub
            End Select
            .本月結存 = Format(Val(.本月結存), "#,#")
        End With
        TargetReturnValues.Rows.Add(AddItem)

    End Sub

    Private Function GetFactoryName(ByVal FactoryNameCode As String) As String
        Select Case FactoryNameCode
            Case "SA"
                Return "不銹鋼"
            Case "AA"
                Return "總公司"
            Case "AB"
                Return "總公司(新豐)"
            Case "NA"
                Return "台北辦事處"
            Case "QA"
                Return "營建部"
            Case "RA"
                Return "機械廠"
            Case "RC"
                Return "公路車輛"
            Case "RD"
                Return "鋼構"
        End Select
        Return Nothing
    End Function

    Private Function GetCategoryName(ByVal AssetNumber As String) As String
        Select Case True
            Case AssetNumber.Substring(0, 1) = "1" AndAlso AssetNumber.Substring(0, 7) >= "1110101"
                Return "土地改良物"
            Case AssetNumber.Substring(0, 1) = "1"
                Return "土地"
            Case AssetNumber.Substring(0, 1) = "2"
                Return "房屋及設備"
            Case AssetNumber.Substring(0, 1) = "3"
                Return "機械及設備"
            Case AssetNumber.Substring(0, 1) = "4"
                Return "交通設備"
            Case AssetNumber.Substring(0, 1) = "5"
                Return "雜項設備"
        End Select
        Return Nothing
    End Function

#End Region

#Region "設定資產狀態至被查詢參數控制項 函式:SetQryToSearchControl"
    ''' <summary>
    ''' 設定資產狀態至被查詢參數控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryToSearchControl()
        hfSQLQry.Value = Nothing
        If IsNothing(CheckBoxList1.SelectedItem) Then
            Exit Sub
        End If

        Dim ReturnValue As String = Nothing ' "Select * From @#AST500LB.AST101PF"
        For Each EachItem As ListItem In CheckBoxList1.Items
            If EachItem.Selected Then
                ReturnValue &= IIf(IsNothing(ReturnValue), Nothing, " UNION ") & "Select " & EachItem.Value.Trim & ".* , '" & EachItem.Value.Trim & "' as FactoryName  From @#AST500LB.AST101PF.ASTF" & EachItem.Value.Trim & " AS " & EachItem.Value.Trim
            End If
        Next
        hfSQLQry.Value = ReturnValue
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SetQryToSearchControl()
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class