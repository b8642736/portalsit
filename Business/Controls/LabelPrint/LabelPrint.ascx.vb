Public Partial Class LabelPrint
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"

    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search() As SLS300LB.LabelPrintDataTableDataTable  ' List(Of SLS300LB.LabelPrintDataTableRow)
        Dim Step1SearchResult As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF) '= (From A In CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Where A.About_SL2CH2PF_CH202 <> "Y" Select A Order By A.QTN03, A.QTN05, A.QTN94).ToList
        Dim ReturnValue As New SLS300LB.LabelPrintDataTableDataTable
        Dim AddItem As SLS300LB.LabelPrintDataTableRow = ReturnValue.NewRow
        With AddItem
            .產品 = "304(Cold rolled coil) 2D"
            .尺寸 = "1.4mm*1247mm*1226m" & vbNewLine & "Scrap edge width 27mm"
            .毛重 = "17,585"
            .淨重 = "17,577"
            .字號 = "台正字第5699號"
            .鋼捲編號 = "D7753"
            .鋼胚編號 = "A8815-1020"
            .儲位 = "CP04-03"
            .品級 = "1"
            .繳庫日期 = "2009/08/26"
            .檢驗員 = "32375"
            .序號 = "143"
            .備註1 = "1Applicable specification"
            .備註1 &= vbNewLine & "2/Steel grade/Finish:"
            .備註1 &= vbNewLine & "3ASTM A240/304/2D"
            .備註1 &= vbNewLine & "4EN10028-7/1.4301/2D"
            .備註1 &= vbNewLine & "5Type of Inspection:"
            .備註1 &= vbNewLine & "6EN10204 Type 3.1"
            .備註1 &= vbNewLine & "7Heat treatment condition:"

            .備註1 &= vbNewLine & "8Applicable specification"
            .備註1 &= vbNewLine & "9/Steel grade/Finish:"
            .備註1 &= vbNewLine & "1ASTM A240/304/2D"
            .備註1 &= vbNewLine & "2EN10028-7/1.4301/2D"
            .備註1 &= vbNewLine & "3Type of Inspection:"
            .備註1 &= vbNewLine & "4EN10204 Type 3.1"
            .備註1 &= vbNewLine & "5Heat treatment condition:"
        End With
        ReturnValue.Rows.Add(AddItem)


        AddItem = ReturnValue.NewRow
        With AddItem
            .產品 = "" ' "202(Cold rolled coil) BA"
            .尺寸 = "" ' "1.5mm*1247mm*1226m" & vbNewLine & "Scrap edge width 27mm"
            .毛重 = "" ' "99.999"
            .淨重 = "" ' "88.888"
            .字號 = "" ' "台正字第9999號"
            .鋼捲編號 = "" ' "E7753"
            .鋼胚編號 = "" ' "A8815-1020"
            .儲位 = "" ' "CP04-03"
            .品級 = "" ' "1"
            .繳庫日期 = "" ' "2009/08/26"
            .檢驗員 = "" ' "32375"
            .序號 = "" ' "143"
            .備註1 = "" ' "DDD"
            '.備註1 &= "|AAA" & "|" & "BBB" & "|" & "CCC" & "|" & "DDD"
            '.備註1 &= "|AAA" & "|" & "BBB" & "|" & "CCC" & "|" & "DDD"
            '.備註1 &= "|AAA" & "|" & "BBB" & "|" & "CCC" & "|" & "DDD"
            .備註1 &= ""
        End With
        ReturnValue.Rows.Add(AddItem)




        'For kk As Integer = 1 To 50

        '    Dim AddItem As SLS300LB.LabelPrintDataTableRow = ReturnValue.NewRow
        '    With AddItem
        '        .產品 = "304(Cold rolled coil) 2D"
        '        .尺寸 = "1.4*1247*1226" & vbNewLine & "Scrap edge width 27mm"
        '        .毛重 = "17,585"
        '        .淨重 = "17,577"
        '        .字號 = "台正字第5699號"
        '        .鋼捲編號 = "D7753"
        '        .鋼胚編號 = "A8815-1020"
        '        .儲位 = "CP04-03"
        '        .品級 = "1"
        '        .繳庫日期 = "2009/08/26"
        '        .檢驗員 = "32375"
        '        .序號 = "143"
        '        .備註1 = "AAA" & vbNewLine & "BBB" & vbNewLine & "CCC" & vbNewLine & "DDD"
        '        .備註1 &= "AAA" & vbNewLine & "BBB" & vbNewLine & "CCC" & vbNewLine & "DDD"
        '        .備註1 &= "AAA" & vbNewLine & "BBB" & vbNewLine & "CCC" & vbNewLine & "DDD"
        '    End With
        '    ReturnValue.Rows.Add(AddItem)
        'Next

        Return ReturnValue
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        'e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        ReportViewer1.Visible = True
        'Dim Parameters(1) As Microsoft.Reporting.WebForms.ReportParameter
        'Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("Year1", CType(Me.TextBox1.Text, Integer))
        'Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("Month1", CType(Me.DropDownList1.SelectedValue, Integer))
        'ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class