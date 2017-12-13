Imports System.ComponentModel

Partial Public Class SteelPlantSendOutSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As DisplayDataSet.SteelPlantSendOutDisplayDataTableDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New DisplayDataSet.SteelPlantSendOutDisplayDataTableDataTable
        End If
        Dim SearchResult As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = (From A In CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.SMS100LB.SMSSGAPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Select A Order By A.SGA05, A.SGA06, A.SGA09, A.SGA35StateLeng).ToList

        Dim ReturnValue As New DisplayDataSet.SteelPlantSendOutDisplayDataTableDataTable
        Dim GroupItems As New List(Of CompanyORMDB.SMS100LB.SMSSGAPF)
        Dim PreEachItem As CompanyORMDB.SMS100LB.SMSSGAPF = Nothing
        'Dim PreRunSteelKind As String = Nothing
        For Each EachItem As CompanyORMDB.SMS100LB.SMSSGAPF In SearchResult
            GroupItems.Add(EachItem)
            If Not IsNothing(PreEachItem) AndAlso (PreEachItem.SGA05 <> EachItem.SGA05 OrElse PreEachItem.SGA06 <> EachItem.SGA06 OrElse PreEachItem.SGA09 <> EachItem.SGA09) Then
                GroupItems.Remove(EachItem)
                AddDisplayGroupSum("小計:", GroupItems, ReturnValue) '執行小計
                GroupItems.Clear()
                GroupItems.Add(EachItem)
            End If

            If Not IsNothing(PreEachItem) AndAlso PreEachItem.SGA05 <> EachItem.SGA05 Then
                AddDiscountRateGroupSum(PreEachItem.SGA05, SearchResult, ReturnValue)
            End If

            AddDisplayItem(EachItem, ReturnValue, SearchResult)    '加入顯示行
            PreEachItem = EachItem
            'PreRunSteelKind = EachItem.SGA05
        Next
        AddDisplayGroupSum("小計:", GroupItems, ReturnValue) '執行小計
        AddDiscountRateGroupSum(PreEachItem.SGA05, SearchResult, ReturnValue)
        AddDisplayGroupSum("總計:", SearchResult, ReturnValue)  '執行總計
        Return ReturnValue
    End Function

#Region "加入顯示行 函式:AddDisplayItem"
    ''' <summary>
    ''' 加入顯示行
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddDisplayItem(ByVal ShowDisplayItem As CompanyORMDB.SMS100LB.SMSSGAPF, ByVal SourceDataTable As DisplayDataSet.SteelPlantSendOutDisplayDataTableDataTable, ByVal AllSearchResult As List(Of CompanyORMDB.SMS100LB.SMSSGAPF))
        Static PreDisplayItem As CompanyORMDB.SMS100LB.SMSSGAPF
        Dim WillAddItemRow As DisplayDataSet.SteelPlantSendOutDisplayDataTableRow = Nothing
        Select Case True
            Case IsNothing(PreDisplayItem)
                WillAddItemRow = Nothing
            Case PreDisplayItem.SteelKindAndMaterialAndWidthAndLongString = ShowDisplayItem.SteelKindAndMaterialAndWidthAndLongString
                WillAddItemRow = (From A In SourceDataTable Where A.鋼種尺寸 = ShowDisplayItem.SteelKindAndMaterialAndWidthAndLongString Select A).FirstOrDefault
            Case Else
                WillAddItemRow = Nothing
        End Select
        If IsNothing(WillAddItemRow) Then
            WillAddItemRow = SourceDataTable.NewRow
            SourceDataTable.Rows.Add(WillAddItemRow)
        End If
        With WillAddItemRow
            .鋼種尺寸 = ShowDisplayItem.SteelKindAndMaterialAndWidthAndLongString
            .計劃數量 += 1
            .計劃重量 += ShowDisplayItem.SGA35StateWeight
            If ShowDisplayItem.SGA35 = "C" OrElse ShowDisplayItem.SGA35 = "*" Then
                .已外送數量 += 1
                .已外送重量 += ShowDisplayItem.SGA35StateWeight
            End If
            .平均重量 = (.計劃重量 / .計劃數量)
            .平均重量 = Format(.平均重量, "0.0")
        End With
        PreDisplayItem = ShowDisplayItem
    End Sub
#End Region
#Region "加入研磨率小計 顯示行 函式:AddDiscountRateGroupSum"
    ''' <summary>
    ''' 加入研磨率小計
    ''' </summary>
    ''' <param name="SteelKind"></param>
    ''' <param name="AllSearchResult"></param>
    ''' <remarks></remarks>
    Private Sub AddDiscountRateGroupSum(ByVal SteelKind As String, ByVal AllSearchResult As List(Of CompanyORMDB.SMS100LB.SMSSGAPF), ByVal SourceDataTable As DisplayDataSet.SteelPlantSendOutDisplayDataTableDataTable)
        Dim SourceGroupData As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = (From A In AllSearchResult Where A.SGA05.Trim = SteelKind.Trim Select A).ToList

        If SourceGroupData.Count = 0 Then
            Exit Sub
        End If
        Dim InsertItem As DisplayDataSet.SteelPlantSendOutDisplayDataTableRow = SourceDataTable.NewRow
        With InsertItem

            .鋼種尺寸 = SteelKind & " 研磨率"
            .計劃數量 = 0
            .計劃重量 = 0
            .已外送數量 = 0
            .已外送重量 = 0
            .平均重量 = 0
            .平均重量 = 0

            Dim Value1 As Double = (From A In SourceGroupData Select A.GrindWeight).Sum
            Dim Value2 As Double = (From A In SourceGroupData Select A.SGA15).Sum
            If Value2 > 0 Then
                .研磨率 = Format(Value1 / Value2 * 100, "0.0000")
            End If
            Dim SourceGroupData1 As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = (From A In SourceGroupData Where A.SGA02.Trim = "1" And A.SGA03 = 1 Select A).ToList
            Value1 = (From A In SourceGroupData1 Where A.IsHead = True Select A.GrindWeight).Sum
            Value2 = (From A In SourceGroupData1 Where A.IsHead = True Select A.SGA15).Sum
            If Value2 > 0 Then
                .頭塊研磨率 = Format(Value1 / Value2 * 100, "0.0000")
            End If
            Dim SourceGroupData2 As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = (From A In SourceGroupData Where Not (A.SGA02.Trim = "1" And A.SGA03 = 1) Select A).ToList
            Value1 = (From A In SourceGroupData2 Where A.IsHead = False Select A.GrindWeight).Sum
            Value2 = (From A In SourceGroupData2 Where A.IsHead = False Select A.SGA15).Sum
            If Value2 > 0 Then
                .非頭塊研磨率 = Format(Value1 / Value2 * 100, "0.0000")
            End If
        End With
        SourceDataTable.Rows.Add(InsertItem)


    End Sub
#End Region
#Region "加入小計/總計 顯示行 函式:AddDisplayGroupSum"

    ''' <summary>
    ''' 加入小計/總計 顯示行
    ''' </summary>
    ''' <param name="GroupName">小計/總計</param>
    ''' <param name="SourceGroupData"></param>
    ''' <param name="SourceDataTable"></param>
    ''' <remarks></remarks>
    Private Sub AddDisplayGroupSum(ByVal GroupName As String, ByVal SourceGroupData As List(Of CompanyORMDB.SMS100LB.SMSSGAPF), ByVal SourceDataTable As DisplayDataSet.SteelPlantSendOutDisplayDataTableDataTable)
        '加入小計/總計 顯示行
        If SourceGroupData.Count <= 0 Then
            Exit Sub
        End If
        Dim InsertItem As DisplayDataSet.SteelPlantSendOutDisplayDataTableRow = SourceDataTable.NewRow
        Dim SearchResultSubDatas As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = (From A In SourceGroupData Where A.SGA35 = "C" Or A.SGA35 = "*" Select A).ToList
        With InsertItem
            .鋼種尺寸 = GroupName
            .計劃數量 = SourceGroupData.Count
            .計劃重量 = (From A In SourceGroupData Select A.SGA35StateWeight).Sum
            If SearchResultSubDatas.Count = 0 Then
                .已外送數量 = 0
                .已外送重量 = 0
            Else
                .已外送數量 = SearchResultSubDatas.Count
                .已外送重量 = (From A In SearchResultSubDatas Select A.SGA35StateWeight).Sum
            End If
            .平均重量 = Format(.計劃重量 / .計劃數量, "0.0")
        End With
        SourceDataTable.Rows.Add(InsertItem)

        'Static PreRunSteelKind As String = Nothing
        'If GroupName.Substring(0, 2) = "小計" AndAlso (String.IsNullOrEmpty(PreRunSteelKind) OrElse PreRunSteelKind <> SourceGroupData(0).SGA05) Then
        '    PreRunSteelKind = SourceGroupData(0).SGA05
        '    AddDiscountRateGroupSum(PreRunSteelKind, AllSearchResult, SourceDataTable)
        'End If

    End Sub
#End Region

#End Region
#Region "顯示其它資訊 函式:DisplayOtherInfo"
    ''' <summary>
    ''' 顯示其它資訊
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayOtherInfo()
        lbOtherMsg1.Text = String.Empty
        lbOtherMsg2.Text = String.Empty
        If String.IsNullOrEmpty(Me.hfQry.Value) Then
            Exit Sub
        End If
        Dim SearchResult As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = (From A In CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.SMS100LB.SMSSGAPF)(Me.hfQry.Value, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Select A Order By A.SGA05, A.SGA06, A.SGA09, A.SGA35StateLeng).ToList
        Dim StartStoveANumber As String = (From A In SearchResult Select A.SGA01 Where SGA01.Substring(0, 1) = "A" Order By SGA01 Ascending).FirstOrDefault
        Dim EndStoveANumber As String = (From A In SearchResult Select A.SGA01 Where SGA01.Substring(0, 1) = "A" Order By SGA01 Descending).FirstOrDefault
        Dim StartStoveBNumber As String = (From A In SearchResult Select A.SGA01 Where SGA01.Substring(0, 1) = "B" Order By SGA01 Ascending).FirstOrDefault
        Dim EndStoveBNumber As String = (From A In SearchResult Select A.SGA01 Where SGA01.Substring(0, 1) = "B" Order By SGA01 Descending).FirstOrDefault
        lbOtherMsg1.Text = StartStoveANumber & "~" & EndStoveANumber
        lbOtherMsg2.Text = StartStoveBNumber & "~" & EndStoveBNumber
    End Sub
#End Region
#Region "產生查詢指令至控制項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢指令至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        Dim SearchBathNumber As String = TextBox1.Text.Trim.Replace("'", Nothing)
        Dim QueryString As String = "Select * from @#SMS100LB.SMSSGAPF Where SGA33='" & SearchBathNumber & "' AND (SGA35='B' OR SGA35='C' OR SGA35='*') "
        If Not String.IsNullOrEmpty(TextBox2.Text) Then
            QueryString &= " AND SGA05 IN ('" & TextBox2.Text.Trim.Replace(",", "','") & "')"
        End If
        QueryString &= " Order By SGA05,SGA06,SGA09,SGA08,SGA18"
        Me.hfQry.Value = QueryString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearchReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchReset.Click
        TextBox1.Text = Nothing
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        GridView1.DataBind()
        DisplayOtherInfo()
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        MakeQryToControl()
        Dim SetDisplayColumns As New List(Of ConvertColumnName)
        SetDisplayColumns.Add(New ConvertColumnName("鋼種尺寸", "鋼種尺寸"))
        SetDisplayColumns.Add(New ConvertColumnName("計劃數量", "計劃數量"))
        SetDisplayColumns.Add(New ConvertColumnName("計劃重量", "計劃重量"))
        SetDisplayColumns.Add(New ConvertColumnName("已外送數量", "已外送數量"))
        SetDisplayColumns.Add(New ConvertColumnName("已外送重量", "已外送重量"))
        SetDisplayColumns.Add(New ConvertColumnName("平均重量", "平均重量"))
        SetDisplayColumns.Add(New ConvertColumnName("研磨率", "研磨率"))
        SetDisplayColumns.Add(New ConvertColumnName("頭塊研磨率", "頭塊研磨率"))
        SetDisplayColumns.Add(New ConvertColumnName("非頭塊研磨率", "非頭塊研磨率"))
        Dim ExcelConvert As New DataConvertExcel(Search(Me.hfQry.Value), SetDisplayColumns, "送外代軋鋼胚統計" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class