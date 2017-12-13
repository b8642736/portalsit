Public Class BlackCoilUnDoSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As ColdRollingProcessDataSet.BlackCoilUnDoSearchDataTable
        Dim ReturnValue As New ColdRollingProcessDataSet.BlackCoilUnDoSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If

        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim SearchResultAll As List(Of DataRow) = (From A In QryAdapter.SelectQuery Select A).ToList
        Dim SearchResult As New List(Of CompanyORMDB.PPS100LB.PPSSHAPF) '= CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EahItem In SearchResultAll
            Dim AddItem1 As New CompanyORMDB.PPS100LB.PPSSHAPF
            AddItem1.CDBSetDataRowValueToObject(EahItem)
            SearchResult.Add(AddItem1)
        Next

        Dim AddItem As ColdRollingProcessDataSet.BlackCoilUnDoSearchRow
        Dim PreSteelKind As String = String.Empty
        Dim PreType As String = String.Empty
        Dim PreGuage As Double = 0
        Dim IsFirstRecord As Boolean = True
        Dim AboutEachItemDataRow As DataRow
        For Each EachItem In SearchResult
            If IsFirstRecord = False Then
                If PreSteelKind <> EachItem.SHA12.Trim OrElse PreType <> EachItem.SHA13.Trim OrElse PreGuage <> EachItem.SHA14 Then
                    Call AddItemForGroupData(SearchResult, ReturnValue, PreSteelKind & "," & PreType & "," & PreGuage)
                End If
                If PreSteelKind <> EachItem.SHA12.Trim OrElse PreType <> EachItem.SHA13.Trim Then
                    Call AddItemForGroupData(SearchResult, ReturnValue, PreSteelKind & "," & PreType)
                End If
                If PreSteelKind <> EachItem.SHA12.Trim Then
                    Call AddItemForGroupData(SearchResult, ReturnValue, PreSteelKind)
                End If
            End If
            AddItem = ReturnValue.NewRow
            With AddItem
                .鋼種 = EachItem.SHA12.Trim
                .TYPE = EachItem.SHA13.Trim
                .厚度 = EachItem.SHA14
                .鋼捲號碼 = EachItem.SHA01.Trim & EachItem.SHA02.Trim
                AboutEachItemDataRow = (From A In SearchResultAll Where Trim(A.Item("SHA01")) & Trim(A.Item("SHA02")) = .鋼捲號碼 Select A).FirstOrDefault
                If Not IsNothing(AboutEachItemDataRow) Then
                    If Not IsDBNull(AboutEachItemDataRow.Item("BLA01")) Then
                        .中鋼熱軋號碼 = AboutEachItemDataRow.Item("BLA01")
                    End If
                    If Not IsDBNull(AboutEachItemDataRow.Item("BLA07")) Then
                        .鋼胚號碼 = AboutEachItemDataRow.Item("BLA07")
                    End If
                    If Not IsDBNull(AboutEachItemDataRow.Item("BLA11")) Then
                        .批次 = AboutEachItemDataRow.Item("BLA11")
                    End If


                End If
                .寬度 = EachItem.SHA15
                .重量 = EachItem.SHA17
                .捲數 = 1

                PreSteelKind = EachItem.SHA12.Trim
                PreType = EachItem.SHA13.Trim
                PreGuage = EachItem.SHA14
            End With
            ReturnValue.Rows.Add(AddItem)
            IsFirstRecord = False
        Next
        Call AddItemForGroupData(SearchResult, ReturnValue, PreSteelKind & "," & PreType & "," & PreGuage)
        Call AddItemForGroupData(SearchResult, ReturnValue, PreSteelKind & "," & PreType)
        Call AddItemForGroupData(SearchResult, ReturnValue, PreSteelKind)

        Return ReturnValue
    End Function

    Private Sub AddItemForGroupData(ByVal SourceData As List(Of CompanyORMDB.PPS100LB.PPSSHAPF), ByRef TargetData As ColdRollingProcessDataSet.BlackCoilUnDoSearchDataTable, ByVal GroupKeys As String)
        Dim GroupKeyArray As New List(Of String) : GroupKeyArray.AddRange(Split(GroupKeys, ","))
        Dim GroupData As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = Nothing
        If GroupKeyArray.Count <= 0 Or GroupKeyArray.Count >= 4 Then
            Exit Sub
        Else
            Select Case GroupKeyArray.Count
                Case 1
                    GroupData = (From A In SourceData Where A.SHA12.Trim = GroupKeyArray(0) Select A).ToList
                Case 2
                    GroupData = (From A In SourceData Where A.SHA12.Trim = GroupKeyArray(0) And A.SHA13.Trim = GroupKeyArray(1) Select A).ToList
                Case 3
                    GroupData = (From A In SourceData Where A.SHA12.Trim = GroupKeyArray(0) And A.SHA13.Trim = GroupKeyArray(1) And A.SHA14 = Double.Parse(GroupKeyArray(2)) Select A).ToList
            End Select
        End If
        If IsNothing(GroupData) OrElse GroupData.Count = 0 Then
            Exit Sub
        End If
        Dim AddItem As ColdRollingProcessDataSet.BlackCoilUnDoSearchRow = TargetData.NewRow
        With AddItem
            Select Case GroupKeyArray.Count
                Case 1  '列印鋼種 群組
                    .鋼種 = GroupData.First.SHA12
                    .TYPE = "-"
                    .厚度 = "-"
                    .鋼捲號碼 = "-"
                    .寬度 = "-"
                    .重量 = (From A In GroupData Select A.SHA17).Sum
                    .捲數 = GroupData.Count
                Case 2  '列印鋼種+TYPE 群組
                    .鋼種 = GroupData.First.SHA12
                    .TYPE = GroupData.First.SHA13
                    .厚度 = "-"
                    .鋼捲號碼 = "-"
                    .寬度 = "-"
                    .重量 = (From A In GroupData Select A.SHA17).Sum
                    .捲數 = GroupData.Count
                Case 3  '列印鋼種+TYPE+厚度 群組
                    .鋼種 = GroupData.First.SHA12
                    .TYPE = GroupData.First.SHA13
                    .厚度 = GroupData.First.SHA14
                    .鋼捲號碼 = "-"
                    .寬度 = "-"
                    .重量 = (From A In GroupData Select A.SHA17).Sum
                    .捲數 = GroupData.Count
            End Select
        End With
        TargetData.Rows.Add(AddItem)
    End Sub
#End Region

#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' Where
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlWhereMaker()
        'BLA09=SHA01
        Dim ReturnValue As New StringBuilder
        ReturnValue.Append("Select A.*,B.BLA01,B.BLA07,B.BLA11 from @#PPS100LB.PPSSHAPF A LEFT JOIN @#PPS100LB.PPSBLAPF B ON A.SHA01=B.BLA09 WHERE A.SHA04=1 AND A.SHA28=' ' AND A.SHA21=0 ")

        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            ReturnValue.Append(" AND A.SHA12 IN ('" & tbSteelKind.Text.Trim.Replace(",", "','") & "') ")
        End If

        If Not String.IsNullOrEmpty(tbSteelType.Text) AndAlso tbSteelType.Text.Trim.Length > 0 Then
            ReturnValue.Append(" AND A.SHA13 IN ('" & tbSteelType.Text.Trim.Replace(",", "','").ToUpper & "') ")
        End If

        If Val(tbGuage1.Text) <> 0 Or Val(tbGuage2.Text) <> 999 Then
            ReturnValue.Append(" AND A.SHA14 >=" & Val(tbGuage1.Text) & " AND A.SHA14<=" & Val(tbGuage2.Text))
        End If
        ReturnValue.Append(" ORDER BY A.SHA12,A.SHA13,A.SHA14 ")
        Me.hfSQLString.Value = ReturnValue.ToString
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ControlWhereMaker()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        Call ControlWhereMaker()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value), "黑皮未組查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class