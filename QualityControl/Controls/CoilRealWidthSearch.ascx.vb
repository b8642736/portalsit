Public Partial Class CoilRealWidthSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal SQLString2 As String, ByVal AVBPoints As String) As QualityControlDataSet.CoilRealWidthSearchDataTableDataTable
        Dim ReturnValueTmp As New QualityControlDataSet.CoilRealWidthSearchDataTableDataTable
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim AdapterResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList
        Dim Adapter2 As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString2)
        Dim AdapterResult2 As List(Of DataRow) = (From A In Adapter2.SelectQuery.Rows Select CType(A, DataRow)).ToList
        Dim NumberCount As Integer = 0
        For Each EachItem As DataRow In (From A In AdapterResult Where A.Item("QDS01") = "AP1H" Select A Order By A.Item("BLA01"), A.Item("BLA11")).ToList
            Dim EachItemTemp As DataRow = EachItem
            Dim AddRow As QualityControlDataSet.CoilRealWidthSearchDataTableRow = ReturnValueTmp.NewRow
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
                .AP1H公稱厚度 = CType(EachItem.Item("SHA33"), Integer) / 100
                .AP1H_3寬度 = Format(AverageWidth(AVBPoints, EachItem.Item("QDS10"), EachItem.Item("QDS13"), EachItem.Item("QDS16"), EachItem.Item("QDS19"), EachItem.Item("QDS21"), EachItem.Item("QDS24")), "0,0.00")

                Dim FindAP1HData As DataRow = (From A In AdapterResult Where CType(A.Item("QDS02"), String) = CType(EachItemTemp.Item("QDS02"), String) And CType(A.Item("QDS03"), String) = CType(EachItemTemp.Item("QDS03"), String) And A.Item("QDS01") = "AP1H" Select A Order By A.Item("QDS01") Descending).FirstOrDefault
                If Not IsNothing(FindAP1HData) Then
                    Dim FindBug33Data As DataRow = (From A In AdapterResult2 Where A.Item("QDE01") = FindAP1HData.Item("QDS01") And A.Item("QDE02") = FindAP1HData.Item("QDS02") And A.Item("QDE03") = FindAP1HData.Item("QDS03") Select A Order By A.Item("QDE11") Descending).FirstOrDefault
                    If Not IsNothing(FindBug33Data) Then
                        .AP1H邊夾寬 = FindBug33Data.Item("QDE11")
                    End If
                End If

                Dim FindAP2OrBAData As DataRow = (From A In AdapterResult Where CType(A.Item("QDS02"), String).Trim = CType(EachItemTemp.Item("QDS02"), String).Trim And CType(A.Item("QDS03"), String).Trim = CType(EachItemTemp.Item("QDS03"), String).Trim And (CType(A.Item("QDS01") = "AP2C", String).Trim Or CType(A.Item("QDS01"), String).Trim = "BL" Or CType(A.Item("QDS01"), String).Trim = "BAL" Or CType(A.Item("QDS01"), String).Trim = "BALC") Select A Order By A.Item("QDS01") Descending).FirstOrDefault
                If Not IsNothing(FindAP2OrBAData) Then
                    .CR公稱厚度 = CType(FindAP2OrBAData("SHA33"), Integer) / 100
                    '.CR寬度 = FindAP2OrBAData("QDS16")
                    .CR寬度 = Format(AverageWidth(AVBPoints, FindAP2OrBAData.Item("QDS10"), FindAP2OrBAData.Item("QDS13"), FindAP2OrBAData.Item("QDS16"), FindAP2OrBAData.Item("QDS19"), FindAP2OrBAData.Item("QDS21"), FindAP2OrBAData.Item("QDS24")), "0,0.00")
                    .CR產線 = FindAP2OrBAData("QDS01")
                    Dim FindBug33Data As DataRow = (From A In AdapterResult2 Where A.Item("QDE01") = FindAP2OrBAData.Item("QDS01") And A.Item("QDE02") = FindAP2OrBAData.Item("QDS02") And A.Item("QDE03") = FindAP2OrBAData.Item("QDS03") Select A Order By A.Item("QDE11") Descending).FirstOrDefault
                    If Not IsNothing(FindBug33Data) Then
                        .邊夾寬 = FindBug33Data.Item("QDE11")
                    End If
                End If
            End With
            ReturnValueTmp.Rows.Add(AddRow)
        Next


        Dim Number As Integer = 1
        Dim ReturnValue As New QualityControlDataSet.CoilRealWidthSearchDataTableDataTable
        For Each EachItem As QualityControlDataSet.CoilRealWidthSearchDataTableRow In (From A In ReturnValueTmp Select A Order By A.CR產線 Descending, A.CR公稱厚度 Descending).ToList
            Dim AddRow As QualityControlDataSet.CoilRealWidthSearchDataTableRow = ReturnValue.NewRow
            With AddRow
                .序號 = Number
                .鋼捲號碼 = EachItem.鋼捲號碼
                .鋼種 = EachItem.鋼種
                .材質 = EachItem.材質
                .熱軋批次 = EachItem.熱軋批次
                .熱軋號碼 = EachItem.熱軋號碼
                .鋼胚號碼 = EachItem.鋼胚號碼
                .鋼胚產日 = EachItem.鋼胚產日
                If Not IsDBNull(EachItem.AP1H公稱厚度) Then
                    .AP1H公稱厚度 = EachItem.AP1H公稱厚度
                End If
                If Not IsDBNull(EachItem.AP1H_3寬度) Then
                    .AP1H_3寬度 = EachItem.AP1H_3寬度
                End If
                If Not IsDBNull(EachItem.AP1H邊夾寬) Then
                    .AP1H邊夾寬 = EachItem.AP1H邊夾寬
                End If
                If Not IsDBNull(EachItem.CR公稱厚度) Then
                    .CR公稱厚度 = EachItem.CR公稱厚度
                End If
                If Not IsDBNull(EachItem.CR寬度) Then
                    .CR寬度 = EachItem.CR寬度
                End If
                If Not IsDBNull(EachItem.CR產線) Then
                    .CR產線 = EachItem.CR產線
                End If
                If Not IsDBNull(EachItem.邊夾寬) Then
                    .邊夾寬 = EachItem.邊夾寬
                End If

            End With
            Number += 1
            ReturnValue.Rows.Add(AddRow)
        Next

        Return ReturnValue
    End Function

    Public Function AverageWidth(ByVal GetAVBPoints As String, ByVal ParamArray Values() As Single) As Single
        Dim TotalValue As Double = 0
        Dim DevCount As Integer = 0
        For Each PointIndex As Integer In GetAVBPoints.Split(",")
            If Values.Count >= PointIndex AndAlso Values(PointIndex) > 0 Then
                TotalValue += Values(PointIndex) : DevCount += 1
            End If
        Next
        Return TotalValue / DevCount
    End Function
#End Region


#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"
    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

        If Not String.IsNullOrEmpty(tbLotsNumber.Text) Then
            tbLotsNumber.Text = tbLotsNumber.Text.Replace("'", Nothing)
            'ReturnValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND C.BLA11  IN ('" & tbLotsNumber.Text.Replace(",", "','") & "')", Nothing)
            Select Case True
                Case tbLotsNumber.Text.Split("~").Count = 1
                    ReturnValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND C.BLA11  ='" & tbLotsNumber.Text.Trim & "'", Nothing)
                Case tbLotsNumber.Text.Split("~").Count = 2
                    ReturnValue &= IIf(tbLotsNumber.Text.Trim.Length > 0, " AND C.BLA11>='" & tbLotsNumber.Text.Split("~")(0).Trim & "' AND C.BLA11<='" & tbLotsNumber.Text.Split("~")(1).Trim & "'", Nothing)
            End Select
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
        If Not String.IsNullOrEmpty(tbSteelKindType.Text) Then
            tbSteelKindType.Text = tbSteelKindType.Text.Replace("'", Nothing)
            ReturnValue &= IIf(tbSteelKindType.Text.Trim.Length > 0, " AND (RTRIM(C.BLA02) || C.BLA18) IN ('" & tbSteelKindType.Text.Replace(",", "','") & "')", Nothing)
        End If

        Dim SetAVBPoints As String = Nothing
        For Each EachItem As ListItem In CheckBoxList1.Items
            If EachItem.Selected Then
                SetAVBPoints &= IIf(IsNothing(SetAVBPoints), Nothing, ",") & EachItem.Value
            End If
        Next

        'Me.hfControlSQLMaker.Value = "Select A.*,B.SHA33,B.SHA01,B.SHA02,B.SHA04,B.SHA08,C.* from @#PPS100LB.PPSQDSL3 A INNER JOIN @#PPS100LB.PPSSHALC B ON (A.QDS02 || A.QDS03 || A.QDS01) = (B.SHA01 || B.SHA02 || B.SHA08) LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.QDS02 = C.BLA09 Where (B.SHA08='AP1H' OR B.SHA08='AP2C' OR B.SHA08='BL') " & ReturnValue
        'Me.hfControlSQLMaker2.Value = "Select D.QDE01, D.QDE02,D.QDE03,D.QDE04,D.QDE11 FROM @#PPS100LB.PPSQDEPF D Where D.QDE05=33 AND (D.QDE01='AP2C' OR D.QDE01='BL') AND (D.QDE01 || D.QDE02 || D.QDE03) IN (" & "Select A.QDS01 || A.QDS02 || A.QDS03 from @#PPS100LB.PPSQDSL3 A INNER JOIN @#PPS100LB.PPSSHALC B ON (A.QDS02 || A.QDS03 || A.QDS01) = (B.SHA01 || B.SHA02 || B.SHA08) LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.QDS02 = C.BLA09 Where (B.SHA08='AP2C' OR B.SHA08='BL') " & ReturnValue & ")"

        Me.hfControlSQLMaker.Value = "Select A.*,B.SHA33,B.SHA01,B.SHA02,B.SHA04,B.SHA08,C.* from @#PPS100LB.PPSQDSL3 A INNER JOIN @#PPS100LB.PPSSHALC B ON (A.QDS02 || A.QDS03 || A.QDS01) = (B.SHA01 || B.SHA02 || B.SHA08) LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.QDS02 = C.BLA09 Where (B.SHA08='AP1H' OR B.SHA08='AP2C' OR B.SHA08='BL' OR SHA08='BAL' OR SHA08='BALC') " & ReturnValue
        Me.hfControlSQLMaker2.Value = "Select D.QDE01, D.QDE02,D.QDE03,D.QDE04,D.QDE11 FROM @#PPS100LB.PPSQDEPF D Where D.QDE05=33 AND (D.QDE01='AP1H' OR D.QDE01='AP2C' OR D.QDE01='BL'  OR QDE01='BAL' OR QDE01='BALC') AND (D.QDE01 || D.QDE02 || D.QDE03) IN (" & "Select A.QDS01 || A.QDS02 || A.QDS03 from @#PPS100LB.PPSQDSL3 A INNER JOIN @#PPS100LB.PPSSHALC B ON (A.QDS02 || A.QDS03 || A.QDS01) = (B.SHA01 || B.SHA02 || B.SHA08) LEFT JOIN @#PPS100LB.PPSBLAPF C ON A.QDS02 = C.BLA09 Where (B.SHA08='AP1H' OR B.SHA08='AP2C' OR B.SHA08='BL' OR SHA08='BAL' OR SHA08='BALC') " & ReturnValue & ")"
        Me.hfAvgPoints.Value = SetAVBPoints
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        SQLMakerToControl()
        GridView1.DataBind()
    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
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
        ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfControlSQLMaker.Value, Me.hfControlSQLMaker2.Value, Me.hfAvgPoints.Value), "鋼捲實際寬度查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxList1.SelectedIndexChanged
        For Each EachItem As ListItem In CheckBoxList1.Items
            If EachItem.Selected Then
                Exit Sub
            End If
        Next
        For Each EachItem As ListItem In CheckBoxList1.Items
            EachItem.Selected = True
        Next
    End Sub
End Class