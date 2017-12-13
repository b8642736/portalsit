Partial Public Class OrderSummaryPrint
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal SQLString As String, ByVal HRSQLString As String) As SLS300LB.OrderSummaryPrintDataTable
        If String.IsNullOrEmpty(SQLString) OrElse String.IsNullOrEmpty(HRSQLString) Then
            Return New SLS300LB.OrderSummaryPrintDataTable
        End If
        Dim Step1SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Where A.About_SL2CH2PF_CH202 <> "Y" Select A Order By A.QTN03, A.QTN05, A.QTN94).ToList
        Dim ReturnValue As New SLS300LB.OrderSummaryPrintDataTable

        Dim SteelKindGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)   '鋼種小計
        Dim CRGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)   'CR小計
        Dim AddItem As DataRow
        For Each EachSteelKind As String In (From A In Step1SearchResult Select A.QTN03).Distinct
            Dim TempData1 As String = EachSteelKind
            For Each EachSteelKindThith In (From a In Step1SearchResult Where a.QTN03 = TempData1 Select a.QTN05, a.QTN03, a.SubThickArea).Distinct
                Dim FilterResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From a In Step1SearchResult Where a.QTN03 = EachSteelKindThith.QTN03 And a.QTN05 = EachSteelKindThith.QTN05 And a.SubThickArea = EachSteelKindThith.SubThickArea Select a).ToList
                SteelKindGroup.AddRange(FilterResult)
                CRGroup.AddRange(FilterResult)
                If FilterResult.Count > 0 Then
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        .Item("鋼種") = TempData1
                        .Item("厚度") = EachSteelKindThith.QTN05
                        .Item("型別") = EachSteelKindThith.SubThickArea
                        .Item("2D1") = (From A In FilterResult Where A.IsHomeSell = True And A.QTN04 Like "2D*" Select A.QTN12).Sum
                        .Item("2B1") = (From A In FilterResult Where A.IsHomeSell = True And A.QTN04 Like "2B*" Select A.QTN12).Sum
                        .Item("BA1") = (From A In FilterResult Where A.IsHomeSell = True And A.QTN04 Like "BA*" Select A.QTN12).Sum
                        .Item("SH1") = (From A In FilterResult Where A.IsHomeSell = True And A.QTN04 Like "SH*" Select A.QTN12).Sum
                        .Item("小計1") = .Item("2D1") + .Item("2B1") + .Item("BA1") + .Item("SH1")
                        .Item("2D2") = (From A In FilterResult Where A.IsHomeSell = False And A.QTN04 Like "2D*" Select A.QTN12).Sum
                        .Item("2B2") = (From A In FilterResult Where A.IsHomeSell = False And A.QTN04 Like "2B*" Select A.QTN12).Sum
                        .Item("BA2") = (From A In FilterResult Where A.IsHomeSell = False And A.QTN04 Like "BA*" Select A.QTN12).Sum
                        .Item("SH2") = (From A In FilterResult Where A.IsHomeSell = False And A.QTN04 Like "SH*" Select A.QTN12).Sum
                        .Item("小計2") = .Item("2D2") + .Item("2B2") + .Item("BA2") + .Item("SH2")
                    End With
                    ReturnValue.Rows.Add(AddItem)
                End If
            Next
            '鋼種小計
            AddItem = ReturnValue.NewRow
            With AddItem
                .Item("鋼種") = TempData1 & "小計"
                .Item("2D1") = (From A In SteelKindGroup Where A.IsHomeSell = True And A.QTN04 Like "2D*" Select A.QTN12).Sum
                .Item("2B1") = (From A In SteelKindGroup Where A.IsHomeSell = True And A.QTN04 Like "2B*" Select A.QTN12).Sum
                .Item("BA1") = (From A In SteelKindGroup Where A.IsHomeSell = True And A.QTN04 Like "BA*" Select A.QTN12).Sum
                .Item("SH1") = (From A In SteelKindGroup Where A.IsHomeSell = True And A.QTN04 Like "SH*" Select A.QTN12).Sum
                .Item("小計1") = .Item("2D1") + .Item("2B1") + .Item("BA1") + .Item("SH1")
                .Item("2D2") = (From A In SteelKindGroup Where A.IsHomeSell = False And A.QTN04 Like "2D*" Select A.QTN12).Sum
                .Item("2B2") = (From A In SteelKindGroup Where A.IsHomeSell = False And A.QTN04 Like "2B*" Select A.QTN12).Sum
                .Item("BA2") = (From A In SteelKindGroup Where A.IsHomeSell = False And A.QTN04 Like "BA*" Select A.QTN12).Sum
                .Item("SH2") = (From A In SteelKindGroup Where A.IsHomeSell = False And A.QTN04 Like "SH*" Select A.QTN12).Sum
                .Item("小計2") = .Item("2D2") + .Item("2B2") + .Item("BA2") + .Item("SH2")
            End With
            ReturnValue.Rows.Add(AddItem)
            SteelKindGroup.Clear()
        Next
        'CR小計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "CR小計"
            .Item("2D1") = (From A In CRGroup Where A.IsHomeSell = True And A.QTN04 Like "2D*" Select A.QTN12).Sum
            .Item("2B1") = (From A In CRGroup Where A.IsHomeSell = True And A.QTN04 Like "2B*" Select A.QTN12).Sum
            .Item("BA1") = (From A In CRGroup Where A.IsHomeSell = True And A.QTN04 Like "BA*" Select A.QTN12).Sum
            .Item("SH1") = (From A In CRGroup Where A.IsHomeSell = True And A.QTN04 Like "SH*" Select A.QTN12).Sum
            .Item("小計1") = .Item("2D1") + .Item("2B1") + .Item("BA1") + .Item("SH1")
            .Item("2D2") = (From A In CRGroup Where A.IsHomeSell = False And A.QTN04 Like "2D*" Select A.QTN12).Sum
            .Item("2B2") = (From A In CRGroup Where A.IsHomeSell = False And A.QTN04 Like "2B*" Select A.QTN12).Sum
            .Item("BA2") = (From A In CRGroup Where A.IsHomeSell = False And A.QTN04 Like "BA*" Select A.QTN12).Sum
            .Item("SH2") = (From A In CRGroup Where A.IsHomeSell = False And A.QTN04 Like "SH*" Select A.QTN12).Sum
            .Item("小計2") = .Item("2D2") + .Item("2B2") + .Item("BA2") + .Item("SH2")
        End With
        ReturnValue.Rows.Add(AddItem)

        '加入HR
        ReturnValue.Merge(SearchHR(HRSQLString))

        '加入總計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "總計"
            .Item("小計1") = (From A In ReturnValue Where Not A.鋼種 Like "*計*" Select A.小計1).Sum
            .Item("小計2") = (From A In ReturnValue Where Not A.鋼種 Like "*計*" Select A.小計2).Sum
        End With
        ReturnValue.Rows.Add(AddItem)

        Return ReturnValue
    End Function

#Region "小計 函式:AddSmallSum"
    ''' <summary>
    ''' 小計
    ''' </summary>
    ''' <param name="SourceDatas"></param>
    ''' <param name="TargetCustomer"></param>
    ''' <remarks></remarks>
    Private Shared Sub AddSmallSum(ByVal SourceDatas As SLS300LB.TakeGoodSearchResultTableDataTable, ByVal TargetCustomer As String)
        '客戶小計
        Dim AddItem2 As SLS300LB.TakeGoodSearchResultTableRow = SourceDatas.NewRow
        With AddItem2
            .客戶 = TargetCustomer & " 小計:"
            .鋼種 = ""
            .CR訂單量 = (From A In SourceDatas Where A.客戶 = TargetCustomer Select A.CR訂單量).Sum
            .CR提貨量 = (From A In SourceDatas Where A.客戶 = TargetCustomer Select A.CR提貨量).Sum
            .HR訂單量 = (From A In SourceDatas Where A.客戶 = TargetCustomer Select A.HR訂單量).Sum
            .HR提貨量 = (From A In SourceDatas Where A.客戶 = TargetCustomer Select A.HR提貨量).Sum
            .其它訂單量 = (From A In SourceDatas Where A.客戶 = TargetCustomer Select A.其它訂單量).Sum
            .其它提貨量 = (From A In SourceDatas Where A.客戶 = TargetCustomer Select A.其它提貨量).Sum
        End With
        SourceDatas.Rows.Add(AddItem2)

    End Sub
#End Region

#End Region
#Region "資料查詢HR 方法:SearchHR"
    Public Shared Function SearchHR(ByVal HRSQLString As String) As SLS300LB.OrderSummaryPrintDataTable
        Dim Step1SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, HRSQLString).SelectQuery) Where A.About_SL2CH2PF_CH202 <> "Y" Select A Order By A.QTN04, A.QTN03, A.QTN05, A.QTN94).ToList
        Dim ReturnValue As New SLS300LB.OrderSummaryPrintDataTable
        Dim SteelFacdAndKindGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)
        Dim HRGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)   'HR小計
        Dim AddItem As DataRow
        For Each EachSteelFaceAndKind In (From A In Step1SearchResult Select A.QTN04, A.QTN03).Distinct

            For Each EachItem In (From A In Step1SearchResult Where A.QTN04 = EachSteelFaceAndKind.QTN04 And A.QTN03 = EachSteelFaceAndKind.QTN03 Select A.QTN05, A.SubThickArea).Distinct
                Dim FilterResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From a In Step1SearchResult Where a.QTN03 = EachSteelFaceAndKind.QTN03 And a.QTN04 = EachSteelFaceAndKind.QTN04 And a.QTN05 = EachItem.QTN05 And a.SubThickArea = EachItem.SubThickArea Select a).ToList
                SteelFacdAndKindGroup.AddRange(FilterResult)
                HRGroup.AddRange(FilterResult)
                If FilterResult.Count > 0 Then
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        .Item("鋼種") = EachSteelFaceAndKind.QTN04 & ":" & EachSteelFaceAndKind.QTN03
                        .Item("厚度") = EachItem.QTN05
                        .Item("型別") = EachItem.SubThickArea
                        .Item("小計1") = (From A In FilterResult Where A.IsHomeSell Select A.QTN12).Sum
                        .Item("小計2") = (From A In FilterResult Where Not A.IsHomeSell Select A.QTN12).Sum
                    End With
                    ReturnValue.Rows.Add(AddItem)
                End If
            Next
            '鋼種小計
            AddItem = ReturnValue.NewRow
            With AddItem
                .Item("鋼種") = EachSteelFaceAndKind.QTN04 & ":" & EachSteelFaceAndKind.QTN03 & "小計"
                .Item("小計1") = (From A In SteelFacdAndKindGroup Where A.IsHomeSell Select A.QTN12).Sum
                .Item("小計2") = (From A In SteelFacdAndKindGroup Where Not A.IsHomeSell Select A.QTN12).Sum
            End With
            ReturnValue.Rows.Add(AddItem)
            SteelFacdAndKindGroup.Clear()
        Next

        'HR小計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "HR小計"
            .Item("小計1") = (From A In HRGroup Where A.IsHomeSell Select A.QTN12).Sum
            .Item("小計2") = (From A In HRGroup Where Not A.IsHomeSell Select A.QTN12).Sum
        End With
        ReturnValue.Rows.Add(AddItem)




        Return ReturnValue
    End Function
#End Region

#Region "資料查詢格式2 方法:SearchF2"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SearchF2(ByVal SQLString As String, ByVal HRSQLString As String, ByVal SQL2String As String) As SLS300LB.OrderSummaryPrintDataTable
        If String.IsNullOrEmpty(SQLString) OrElse String.IsNullOrEmpty(HRSQLString) OrElse String.IsNullOrEmpty(SQL2String) Then
            Return New SLS300LB.OrderSummaryPrintDataTable
        End If
        Dim Step1SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery) Where A.About_SL2CH2PF_CH202 <> "Y" Select A Order By A.QTN03, A.QTN05, A.QTN94).ToList
        Dim ReturnValue As New SLS300LB.OrderSummaryPrintDataTable


        Dim TotalWeight As Double = (From A In CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQL2String).SelectQuery) Where A.About_SL2CH2PF_CH202 <> "Y" Select A.QTN12).Sum


        Dim SteelKindGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)   '鋼種小計
        Dim CRGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)   'CR小計
        Dim AddItem As DataRow
        For Each EachSteelKind As String In (From A In Step1SearchResult Select A.QTN03).Distinct
            Dim TempData1 As String = EachSteelKind
            For Each EachSteelKindThith In (From a In Step1SearchResult Where a.QTN03 = TempData1 Select a.QTN05, a.QTN03).Distinct
                Dim FilterResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In Step1SearchResult Where A.QTN03 = EachSteelKindThith.QTN03 And A.QTN05 = EachSteelKindThith.QTN05 Select A).ToList
                SteelKindGroup.AddRange(FilterResult)
                CRGroup.AddRange(FilterResult)
                If FilterResult.Count > 0 Then
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        .Item("鋼種") = TempData1
                        .Item("厚度") = EachSteelKindThith.QTN05
                        .Item("小計1") = (From A In FilterResult Where A.IsHomeSell = True Select A.QTN12).Sum
                        .Item("小計2") = (From A In FilterResult Where A.IsHomeSell = False Select A.QTN12).Sum
                        .Item("鋼種數量百分比") = Format(((CType(.Item("小計1"), Integer) + CType(.Item("小計2"), Integer)) / (From A In Step1SearchResult Where A.QTN03 = EachSteelKindThith.QTN03 Select A.QTN12).Sum), "0.0%")
                        Dim DevNumber As Double = 0
                        DevNumber = (From A In Step1SearchResult Where A.QTN03 = TempData1 And A.IsHomeSell = True Select A.QTN12).Sum
                        .Item("內銷鋼種百分比") = IIf(DevNumber = 0, "-", Format(CType(.Item("小計1"), Double) / DevNumber, "0.0%"))
                        DevNumber = (From A In Step1SearchResult Where A.QTN03 = TempData1 And A.IsHomeSell = False Select A.QTN12).Sum
                        .Item("外銷鋼種百分比") = IIf(DevNumber = 0, "-", Format(CType(.Item("小計2"), Double) / DevNumber, "0.0%"))
                    End With
                    ReturnValue.Rows.Add(AddItem)
                End If
            Next
            '鋼種小計
            AddItem = ReturnValue.NewRow
            With AddItem
                .Item("鋼種") = TempData1 & "小計"
                .Item("小計1") = (From A In SteelKindGroup Where A.IsHomeSell = True Select A.QTN12).Sum
                .Item("小計2") = (From A In SteelKindGroup Where A.IsHomeSell = False Select A.QTN12).Sum
                .Item("鋼種數量百分比") = "CR鋼種:" & Format(((CType(.Item("小計1"), Integer) + CType(.Item("小計2"), Integer)) / (From A In Step1SearchResult Select A.QTN12).Sum), "0.0%")
            End With
            ReturnValue.Rows.Add(AddItem)
            SteelKindGroup.Clear()
        Next
        'CR小計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "CR小計"
            .Item("小計1") = (From A In CRGroup Where A.IsHomeSell = True Select A.QTN12).Sum
            .Item("小計2") = (From A In CRGroup Where A.IsHomeSell = False Select A.QTN12).Sum
            .Item("鋼種數量百分比") = "所有鋼種:" & Format(((CType(.Item("小計1"), Integer) + CType(.Item("小計2"), Integer)) / TotalWeight), "0.0%")
        End With
        ReturnValue.Rows.Add(AddItem)

        '加入HR
        ReturnValue.Merge(SearchHR2(HRSQLString, TotalWeight))

        '加入總計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "總計"
            .Item("小計1") = (From A In ReturnValue Where Not A.鋼種 Like "*計*" Select A.小計1).Sum
            .Item("小計2") = (From A In ReturnValue Where Not A.鋼種 Like "*計*" Select A.小計2).Sum
        End With
        ReturnValue.Rows.Add(AddItem)

        Return ReturnValue

    End Function
#End Region
#Region "資料查詢HR 方法:SearchHR2"
    Public Shared Function SearchHR2(ByVal HRSQLString As String, ByVal TotalWeight As Double) As SLS300LB.OrderSummaryPrintDataTable
        Dim Step1SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, HRSQLString).SelectQuery) Where A.About_SL2CH2PF_CH202 <> "Y" Select A Order By A.QTN04, A.QTN03, A.QTN05, A.QTN94).ToList
        Dim ReturnValue As New SLS300LB.OrderSummaryPrintDataTable
        Dim SteelFacdAndKindGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)
        Dim HRGroup As New List(Of CompanyORMDB.SLS300LB.SL2QTNPF)   'HR小計
        Dim AddItem As DataRow
        For Each EachSteelFaceAndKind In (From A In Step1SearchResult Select A.QTN04, A.QTN03).Distinct
            For Each EachItem In (From A In Step1SearchResult Where A.QTN04 = EachSteelFaceAndKind.QTN04 And A.QTN03 = EachSteelFaceAndKind.QTN03 Select A.QTN05).Distinct
                Dim FilterResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From a In Step1SearchResult Where a.QTN03 = EachSteelFaceAndKind.QTN03 And a.QTN04 = EachSteelFaceAndKind.QTN04 And a.QTN05 = EachItem Select a).ToList
                SteelFacdAndKindGroup.AddRange(FilterResult)
                HRGroup.AddRange(FilterResult)
                If FilterResult.Count > 0 Then
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        .Item("鋼種") = EachSteelFaceAndKind.QTN04 & ":" & EachSteelFaceAndKind.QTN03
                        .Item("厚度") = EachItem
                        .Item("小計1") = (From A In FilterResult Where A.IsHomeSell Select A.QTN12).Sum
                        .Item("小計2") = (From A In FilterResult Where Not A.IsHomeSell Select A.QTN12).Sum
                        .Item("鋼種數量百分比") = Format(((CType(.Item("小計1"), Integer) + CType(.Item("小計2"), Integer)) / (From A In Step1SearchResult Where A.QTN03 = EachSteelFaceAndKind.QTN03 Select A.QTN12).Sum), "0.0%")
                        Dim DevNumber As Double = 0
                        DevNumber = (From A In Step1SearchResult Where A.QTN04 = EachSteelFaceAndKind.QTN04 And A.QTN03 = EachSteelFaceAndKind.QTN03 And A.IsHomeSell = True Select A.QTN12).Sum
                        .Item("內銷鋼種百分比") = IIf(DevNumber = 0, "-", Format(CType(.Item("小計1"), Double) / DevNumber, "0.0%"))
                        DevNumber = (From A In Step1SearchResult Where A.QTN04 = EachSteelFaceAndKind.QTN04 And A.QTN03 = EachSteelFaceAndKind.QTN03 And A.IsHomeSell = False Select A.QTN12).Sum
                        .Item("外銷鋼種百分比") = IIf(DevNumber = 0, "-", Format(CType(.Item("小計2"), Double) / DevNumber, "0.0%"))
                    End With
                    ReturnValue.Rows.Add(AddItem)
                End If
            Next
            '鋼種小計
            AddItem = ReturnValue.NewRow
            With AddItem
                .Item("鋼種") = EachSteelFaceAndKind.QTN04 & ":" & EachSteelFaceAndKind.QTN03 & "小計"
                .Item("小計1") = (From A In SteelFacdAndKindGroup Where A.IsHomeSell Select A.QTN12).Sum
                .Item("小計2") = (From A In SteelFacdAndKindGroup Where Not A.IsHomeSell Select A.QTN12).Sum
                .Item("鋼種數量百分比") = "HR鋼種:" & Format(((CType(.Item("小計1"), Integer) + CType(.Item("小計2"), Integer)) / (From A In Step1SearchResult Select A.QTN12).Sum), "0.0%")
            End With
            ReturnValue.Rows.Add(AddItem)
            SteelFacdAndKindGroup.Clear()
        Next

        'HR小計
        AddItem = ReturnValue.NewRow
        With AddItem
            .Item("鋼種") = "HR小計"
            .Item("小計1") = (From A In HRGroup Where A.IsHomeSell Select A.QTN12).Sum
            .Item("小計2") = (From A In HRGroup Where Not A.IsHomeSell Select A.QTN12).Sum
            .Item("鋼種數量百分比") = "所有鋼種:" & Format(((CType(.Item("小計1"), Integer) + CType(.Item("小計2"), Integer)) / TotalWeight), "0.0%")
        End With
        ReturnValue.Rows.Add(AddItem)




        Return ReturnValue
    End Function
#End Region

#Region "產生查詢至控製項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢至控製項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        Dim FindYear As String = Format(CType(TextBox1.Text, Integer) - 1911, "000")
        Dim FindMonth As String = DropDownList1.SelectedValue
        Dim FindYear2 As String = Format(CType(TextBox2.Text, Integer) - 1911, "000")
        Dim FindMonth2 As String = DropDownList2.SelectedValue

        Me.hfQry.Value = "Select * from @#SLS300LB.SL2QTNPF Where QTN02 >= '" & FindYear & FindMonth & "00" & "' AND QTN02<='" & FindYear2 & FindMonth2 & "99" & "' AND (NOT QTN04 LIKE 'NO1%') "
        Me.hfHRQry.Value = "Select * from @#SLS300LB.SL2QTNPF Where QTN02 >= '" & FindYear & FindMonth & "00" & "' AND QTN02<='" & FindYear2 & FindMonth2 & "99" & "' AND QTN04 LIKE 'NO1%' "
        Me.hfQry2ForView2.Value = "Select * from @#SLS300LB.SL2QTNPF Where QTN02 LIKE '" & FindYear & FindMonth & "%'"

        If RadioButtonList2.SelectedValue <> "ALL" Then
            Me.hfQry.Value &= " AND QTN28='" & RadioButtonList2.SelectedValue & "'"
            Me.hfHRQry.Value &= " AND QTN28='" & RadioButtonList2.SelectedValue & "'"
            Me.hfQry2ForView2.Value &= " AND QTN28='" & RadioButtonList2.SelectedValue & "'"
        End If

    End Sub
#End Region


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        Select Case True
            Case Me.RadioButtonList1.SelectedValue = "1"
                Me.MultiView1.SetActiveView(Me.View1)
                ReportViewer1.Visible = True
                Dim Parameters(1) As Microsoft.Reporting.WebForms.ReportParameter
                Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("Year1", CType(Me.TextBox1.Text, Integer))
                Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("Month1", CType(Me.DropDownList1.SelectedValue, Integer))
                ReportViewer1.LocalReport.SetParameters(Parameters)
                ReportViewer1.LocalReport.Refresh()
            Case Me.RadioButtonList1.SelectedValue = "2"
                Me.MultiView1.SetActiveView(Me.View2)
                ReportViewer2.Visible = True
                Dim Parameters(1) As Microsoft.Reporting.WebForms.ReportParameter
                Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("Year1", CType(Me.TextBox1.Text, Integer))
                Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("Month1", CType(Me.DropDownList1.SelectedValue, Integer))
                ReportViewer2.LocalReport.SetParameters(Parameters)
                ReportViewer2.LocalReport.Refresh()
        End Select
    End Sub

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        TextBox1.Text = Format(Now, "yyyy")
        Me.DropDownList1.SelectedValue = Format(Now, "MM")
        TextBox2.Text = Format(Now, "yyyy")
        Me.DropDownList2.SelectedValue = Format(Now, "MM")
    End Sub

End Class