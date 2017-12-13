Partial Public Class TakeGoodSearch
    Inherits System.Web.UI.UserControl

#Region "第一版:資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <param name="Args">格式:內外銷@日期範圍</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search1(ByVal SQLString As String, ByVal Args As String) As SLS300LB.TakeGoodSearchResultTableDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New SLS300LB.TakeGoodSearchResultTableDataTable
        End If
        Dim Step1SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery)
        Dim ReturnValue As New SLS300LB.TakeGoodSearchResultTableDataTable

        Dim LinqQuery As List(Of String) = Nothing
        Select Case True
            Case Args.Split("@")(0) = "ALL"
                LinqQuery = (From A In Step1SearchResult Select Field1 = A.QTN01 + "," + A.QTN03 Distinct Order By Field1).ToList
            Case Args.Split("@")(0) = "HOMESELL"
                LinqQuery = (From A In Step1SearchResult Where A.QTN29 = " " Select Field1 = A.QTN01 + "," + A.QTN03 Distinct Order By Field1).ToList
            Case Args.Split("@")(0) = "EXPORTSELL"
                LinqQuery = (From A In Step1SearchResult Where A.QTN29 <> " " Select Field1 = A.QTN01 + "," + A.QTN03 Distinct Order By Field1).ToList
        End Select

        Dim PreRecordCustomer As String = Nothing
        For Each EachItem In LinqQuery
            Dim EachItemTem As String = EachItem

            If Not IsNothing(PreRecordCustomer) AndAlso EachItemTem.Substring(0, 3) <> PreRecordCustomer Then
                '客戶小計
                AddSmallSum(ReturnValue, PreRecordCustomer)
            End If
            Dim Step2SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In Step1SearchResult Where (A.QTN01 + "," + A.QTN03) = EachItemTem Select A).ToList
            For Each IsInContract As String In (From A In Step2SearchResult Select A.QTN28 Distinct).ToList
                Dim Step3SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In Step2SearchResult Where A.QTN28 = IsInContract Select A).ToList
                Dim AddItem As SLS300LB.TakeGoodSearchResultTableRow = ReturnValue.NewRow
                With AddItem
                    .年月 = Args.Split("@")(1)
                    .年月 = Replace(.年月, "~", "<BR>")
                    .客戶 = EachItem.Split(",")(0)
                    .鋼種 = EachItem.Split(",")(1)
                    ._合約內_外_ = IIf(IsInContract = "*", "合約外", "合約內")
                    .內外銷 = IIf(Args.Split("@")(0) = "ALL", "全部", IIf(Args.Split("@")(0) = "EXPORTSELL", "外銷", "內銷"))

                    Dim Step4SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = Nothing
                    Dim Step5SearchResult As List(Of String) = Nothing
                    'CR
                    Step4SearchResult = (From A In Step3SearchResult Where A.About_SL2CH2PF_CH205 = "CR" And A.About_SL2CH2PF_CH202 <> "Y" Select A).ToList
                    setDisplayItem("CR", AddItem, Step4SearchResult)

                    'HR
                    Step4SearchResult = (From A In Step3SearchResult Where A.About_SL2CH2PF_CH205 = "HR" And A.About_SL2CH2PF_CH202 <> "Y" Select A).ToList
                    setDisplayItem("HR", AddItem, Step4SearchResult)

                    '其他
                    Step4SearchResult = (From A In Step3SearchResult Where (A.About_SL2CH2PF_CH205 <> "CR" And A.About_SL2CH2PF_CH205 <> "HR" Or A.About_SL2CH2PF_CH202 = "Y") Select A).ToList
                    setDisplayItem("其他", AddItem, Step4SearchResult)
                End With
                ReturnValue.Rows.Add(AddItem)
            Next

            PreRecordCustomer = EachItemTem.Split(",")(0)
        Next
        '客戶小計
        AddSmallSum(ReturnValue, PreRecordCustomer)

        '合計
        Dim AddItem1 As SLS300LB.TakeGoodSearchResultTableRow = ReturnValue.NewRow
        With AddItem1
            .客戶 = "合計:"
            .鋼種 = ""
            .CR訂單量 = (From A In ReturnValue Where Not A.客戶 Like "*計*" Select A.CR訂單量).Sum
            .CR提貨量 = (From A In ReturnValue Where Not A.客戶 Like "*計*" Select A.CR提貨量).Sum
            .HR訂單量 = (From A In ReturnValue Where Not A.客戶 Like "*計*" Select A.HR訂單量).Sum
            .HR提貨量 = (From A In ReturnValue Where Not A.客戶 Like "*計*" Select A.HR提貨量).Sum
            .其它訂單量 = (From A In ReturnValue Where Not A.客戶 Like "*計*" Select A.其它訂單量).Sum
            .其它提貨量 = (From A In ReturnValue Where Not A.客戶 Like "*計*" Select A.其它提貨量).Sum
        End With
        ReturnValue.Rows.Add(AddItem1)

        Return ReturnValue
    End Function

    Public Shared Sub setDisplayItem(ByVal fromDisplayType As String, ByRef fromDisplayItem As SLS300LB.TakeGoodSearchResultTableRow, _
                                                          ByVal fromDataSoruce As List(Of CompanyORMDB.SLS300LB.SL2QTNPF))

        Dim show訂單量 As Single
        Dim show提貨量 As Single
        Dim show厚度 As String = ""
        Dim show厚度提貨量 As String = ""
        Dim show寬度 As String = ""

        show訂單量 = (From A In fromDataSoruce Select A.QTN12).Sum
        show提貨量 = (From A In fromDataSoruce Select A.QTN21).Sum

        Dim Step5SearchResult As List(Of String) = Nothing
        Step5SearchResult = (From A In fromDataSoruce Order By A.QTN05 Select A.QTN05 Distinct).ToList
        For Each eachItemQTN05 As String In Step5SearchResult
            show厚度 &= eachItemQTN05 & "<BR>"
            show厚度提貨量 &= (From A In fromDataSoruce Where A.QTN05 = eachItemQTN05 Select A.QTN21).Sum & "<BR>"
        Next

        Step5SearchResult = (From A In fromDataSoruce Order By A.QTN06, A.QTN08 Select A.QTN06.ToString.Trim + A.QTN08.Trim Distinct).ToList
        For Each eachItemQTN05 As String In Step5SearchResult
            show寬度 &= IIf(eachItemQTN05 = "1000", "", eachItemQTN05 & "<BR>")    '1000不顯示,其他都顯示(1000U/1219/1219U/1250/1250U)
        Next

        Select Case fromDisplayType
            Case "CR"
                fromDisplayItem.CR厚度 = show厚度
                fromDisplayItem.CR厚度提貨量 = show厚度提貨量
                fromDisplayItem.CR訂單量 = show訂單量
                fromDisplayItem.CR提貨量 = show提貨量
                fromDisplayItem.CR寬度 = show寬度

            Case "HR"
                fromDisplayItem.HR厚度 = show厚度
                fromDisplayItem.HR厚度提貨量 = show厚度提貨量
                fromDisplayItem.HR訂單量 = show訂單量
                fromDisplayItem.HR提貨量 = show提貨量
                fromDisplayItem.HR寬度 = show寬度

            Case "其他"
                fromDisplayItem.其它訂單量 = show訂單量
                fromDisplayItem.其它提貨量 = show提貨量
        End Select

    End Sub

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


#Region "第三版:依報價單"
    Enum EnumRunMode3
        客戶合約內外小計 = 1
        客戶小計 = 2
        合計 = 3
    End Enum

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search3(ByVal SQLString As String, ByVal Args As String) As SLS300LB.TakeGoodSearchResultTable3DataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New SLS300LB.TakeGoodSearchResultTable3DataTable
        End If

        'Step1SearchResult：所有符合的資料
        Dim Step1SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery)
        Dim ReturnValue As New SLS300LB.TakeGoodSearchResultTable3DataTable
        Dim AddItem As SLS300LB.TakeGoodSearchResultTable3Row

        'LinqQuery：客戶&鋼種
        Dim LinqQuery As List(Of String) = Nothing
        Select Case True
            Case Args.Split("@")(0) = "ALL"
                LinqQuery = (From A In Step1SearchResult Select Field1 = A.QTN01 + "," + A.QTN03 Distinct Order By Field1).ToList
            Case Args.Split("@")(0) = "HOMESELL"
                LinqQuery = (From A In Step1SearchResult Where A.QTN29 = " " Select Field1 = A.QTN01 + "," + A.QTN03 Distinct Order By Field1).ToList
            Case Args.Split("@")(0) = "EXPORTSELL"
                LinqQuery = (From A In Step1SearchResult Where A.QTN29 <> " " Select Field1 = A.QTN01 + "," + A.QTN03 Distinct Order By Field1).ToList
        End Select

        Dim PreRecordCustomer As String = Nothing
        Dim DateRangS As Date = CDate(Args.Split("@")(1).Split("~")(0) & "/01")
        Dim DateRangE As Date = CDate(Args.Split("@")(1).Split("~")(1) & "/02")
        For Each EachItem In LinqQuery
            Dim EachItemTem As String = EachItem

            If Not IsNothing(PreRecordCustomer) AndAlso EachItemTem.Substring(0, 3) <> PreRecordCustomer Then
                '客戶小計
                AddSmallSum3(EnumRunMode3.客戶小計, ReturnValue, PreRecordCustomer)
            End If

            Dim show報表統計月份 As String
            Dim show客戶 As String
            Dim show鋼種 As String = ""
            Dim show合約內_外 As String = ""
            Dim showHeadNow As New DisplayItemStye3

            'Step2SearchResult：客戶&鋼種
            Dim Step2SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In Step1SearchResult Where (A.QTN01 + "," + A.QTN03) = EachItemTem Select A).ToList
            For Each IsInContract As String In (From A In Step2SearchResult Select A.QTN28 Distinct).ToList

                'Step2BSearchResult：月份(Distinct)
                Dim Step2BSearchResult As List(Of String) = (From A In Step2SearchResult Where A.QTN28 = IsInContract Order By Left(A.QTN02, 5) Select Left(A.QTN02, 5) Distinct).ToList

                For Each eachItemYearMonth As String In Step2BSearchResult

                    Dim Step3SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = _
                                                                                    (From A In Step2SearchResult Where A.QTN28 = IsInContract And Left(A.QTN02, 5) = eachItemYearMonth Select A).ToList
                    AddItem = ReturnValue.NewRow
                    With AddItem
                        'show報表統計月份 = Format(DateRangNow, "yyyy/MM")
                        show報表統計月份 = Integer.Parse(Left(eachItemYearMonth, eachItemYearMonth.Length - 2)) + 1911 & "/" & Right(eachItemYearMonth, 2)
                        show客戶 = EachItem.Split(",")(0)
                        show鋼種 = EachItem.Split(",")(1)
                        show合約內_外 = IIf(IsInContract = "*", "合約外", "合約內")

                        If Not (showHeadNow.客戶.Equals(show客戶) _
                                       AndAlso showHeadNow.鋼種.Equals(show鋼種) AndAlso showHeadNow._合約內_外_.Equals(show合約內_外)) Then

                            .客戶Display = show客戶
                            .鋼種Display = show鋼種
                            ._合約內_外_Display = show合約內_外

                            showHeadNow.客戶 = show客戶
                            showHeadNow.鋼種 = show鋼種
                            showHeadNow._合約內_外_ = show合約內_外
                        End If
                        .客戶 = show客戶
                        .鋼種 = show鋼種
                        ._合約內_外_ = show合約內_外
                        .報表統計月份 = show報表統計月份

                        'Step4SearchResult：CR/HR
                        Dim Step4SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = Nothing
                        'CR
                        Step4SearchResult = (From A In Step3SearchResult Where A.About_SL2CH2PF_CH205 = "CR" And A.About_SL2CH2PF_CH202 <> "Y" Select A).ToList
                        setDisplayItem3("CR", AddItem, Step4SearchResult)

                        'HR
                        Step4SearchResult = (From A In Step3SearchResult Where A.About_SL2CH2PF_CH205 = "HR" And A.About_SL2CH2PF_CH202 <> "Y" Select A).ToList
                        setDisplayItem3("HR", AddItem, Step4SearchResult)

                    End With
                    ReturnValue.Rows.Add(AddItem)
                Next

                PreRecordCustomer = EachItemTem.Split(",")(0)
                If Not (DateRangS.Year = DateRangE.Year And DateRangS.Month = DateRangE.Month) Then
                    '客戶合約內外小計
                    AddSmallSum3(EnumRunMode3.客戶合約內外小計, ReturnValue, PreRecordCustomer, show合約內_外, show鋼種)
                End If

            Next

        Next
        '客戶小計
        AddSmallSum3(EnumRunMode3.客戶小計, ReturnValue, PreRecordCustomer)

        '合計
        AddSmallSum3(EnumRunMode3.合計, ReturnValue)

        Return ReturnValue
    End Function

    Private Shared Sub AddSmallSum3(ByVal fromRunMode As EnumRunMode3, ByRef fromSourceDatas As SLS300LB.TakeGoodSearchResultTable3DataTable)
        AddSmallSum3(EnumRunMode3.合計, fromSourceDatas, "", "", "")
    End Sub

    Private Shared Sub AddSmallSum3(ByVal fromRunMode As EnumRunMode3, ByRef fromSourceDatas As SLS300LB.TakeGoodSearchResultTable3DataTable, _
                                                                           ByVal fromCustomer As String)
        AddSmallSum3(EnumRunMode3.客戶小計, fromSourceDatas, fromCustomer, "", "")
    End Sub
    Private Shared Sub AddSmallSum3(ByVal fromRunMode As EnumRunMode3, ByRef fromSourceDatas As SLS300LB.TakeGoodSearchResultTable3DataTable, _
                                                                          ByVal fromCustomer As String, from_合約內_外_ As String, from鋼種 As String)
        Dim show客戶 As String = ""
        Dim show報表統計月份 As String = ""
        Dim showCR訂單量 As String = ""
        Dim showCR提貨量 As String = ""
        Dim showHR訂單量 As String = ""
        Dim showHR提貨量 As String = ""

        Select Case fromRunMode
            Case EnumRunMode3.客戶合約內外小計
                show報表統計月份 = "小計"
                showCR訂單量 = (From A In fromSourceDatas Where A.客戶 = fromCustomer And A._合約內_外_ = from_合約內_外_ And A.鋼種 = from鋼種 Select A.CR訂單量).Sum
                showCR提貨量 = (From A In fromSourceDatas Where A.客戶 = fromCustomer And A._合約內_外_ = from_合約內_外_ And A.鋼種 = from鋼種 Select A.CR提貨量).Sum
                showHR訂單量 = (From A In fromSourceDatas Where A.客戶 = fromCustomer And A._合約內_外_ = from_合約內_外_ And A.鋼種 = from鋼種 Select A.HR訂單量).Sum
                showHR提貨量 = (From A In fromSourceDatas Where A.客戶 = fromCustomer And A._合約內_外_ = from_合約內_外_ And A.鋼種 = from鋼種 Select A.HR提貨量).Sum

            Case EnumRunMode3.客戶小計
                show客戶 = "小計"
                showCR訂單量 = (From A In fromSourceDatas Where A.客戶 = fromCustomer Select A.CR訂單量).Sum
                showCR提貨量 = (From A In fromSourceDatas Where A.客戶 = fromCustomer Select A.CR提貨量).Sum
                showHR訂單量 = (From A In fromSourceDatas Where A.客戶 = fromCustomer Select A.HR訂單量).Sum
                showHR提貨量 = (From A In fromSourceDatas Where A.客戶 = fromCustomer Select A.HR提貨量).Sum

            Case EnumRunMode3.合計
                show客戶 = "合計"
                showCR訂單量 = (From A In fromSourceDatas Where A.客戶 Like "*小計" Select A.CR訂單量).Sum
                showCR提貨量 = (From A In fromSourceDatas Where A.客戶 Like "*小計" Select A.CR提貨量).Sum
                showHR訂單量 = (From A In fromSourceDatas Where A.客戶 Like "*小計" Select A.HR訂單量).Sum
                showHR提貨量 = (From A In fromSourceDatas Where A.客戶 Like "*小計" Select A.HR提貨量).Sum
        End Select

        Dim AddItem2 As SLS300LB.TakeGoodSearchResultTable3Row = fromSourceDatas.NewRow
        With AddItem2
            .客戶 = show客戶
            .報表統計月份 = show報表統計月份

            .CR訂單量 = showCR訂單量
            .CR提貨量 = showCR提貨量
            .HR訂單量 = showHR訂單量
            .HR提貨量 = showHR提貨量

            .客戶Display = show客戶
            .CR訂單量Display = showCR訂單量
            .CR提貨量Display = showCR提貨量
            .HR訂單量Display = showHR訂單量
            .HR提貨量Display = showHR提貨量
        End With
        fromSourceDatas.Rows.Add(AddItem2)

    End Sub
    Public Shared Sub setDisplayItem3(ByVal fromDisplayType As String, ByRef fromDisplayItem As SLS300LB.TakeGoodSearchResultTable3Row, _
                                                          ByVal fromDataSoruce As List(Of CompanyORMDB.SLS300LB.SL2QTNPF))

        Dim show訂單量 As Single
        Dim show提貨量 As Single
        Dim show厚度 As String = ""
        Dim show厚度提貨量 As String = ""
        Dim show寬度 As String = ""

        Dim show鋼捲號碼 As String = ""
        Dim show淨重 As String = ""
        Dim show一級重量 As String = ""
        Dim show二級重量 As String = ""
        Dim show三級重量 As String = ""
        Dim show報價單號碼 As String = ""

        show訂單量 = (From A In fromDataSoruce Select A.QTN12).Sum
        show提貨量 = (From A In fromDataSoruce Select A.QTN21).Sum

        'Step5SearchResult：厚度 (Distinct)
        Dim Step5SearchResult As List(Of String) = Nothing
        Step5SearchResult = (From A In fromDataSoruce Order By A.QTN05 Select A.QTN05 Distinct).ToList
        Dim DisplayItem As DisplayItemStye3
        Dim DisplayList As New List(Of DisplayItemStye3)

        For Each eachItemQTN05 As String In Step5SearchResult
            DisplayItem = New DisplayItemStye3
            DisplayItem.厚度 = eachItemQTN05
            DisplayItem.厚度提貨量 = (From A In fromDataSoruce Where A.QTN05 = eachItemQTN05 Select A.QTN21).Sum

            DisplayList.Add(DisplayItem)
        Next

        Dim DisplayListDetail As List(Of DisplayItemStye3) = Nothing
        'Step6SearchResult：厚度的報價單明細
        Dim Step6SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = Nothing
        'Step7SearchResult：此厚度的 報價單號與寬度 (Distinct)
        Dim Step7SearchResult As List(Of ClassQuerySl2qtnpfStye3) = Nothing
        For Each eachItemDisplayItem As DisplayItemStye3 In DisplayList
            DisplayListDetail = eachItemDisplayItem.Detail明細
            Step6SearchResult = (From A In fromDataSoruce Where A.QTN05 = eachItemDisplayItem.厚度 Select A).ToList
            Step7SearchResult = (From A In Step6SearchResult Group By A.QTN01, A.QTN02, A.QTN06, A.QTN08 Into GroupCount = Count() Order By QTN02 Select New ClassQuerySl2qtnpfStye3(QTN01 + QTN02, QTN06.ToString.Trim + QTN08.Trim)).ToList

            For Each eachItem報價單 As ClassQuerySl2qtnpfStye3 In Step7SearchResult
                DisplayItem = New DisplayItemStye3
                DisplayItem.報價單號碼 = eachItem報價單.報價單號碼
                DisplayItem.報價單寬度 = eachItem報價單.報價單寬度

                Dim Step8SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In Step6SearchResult Where A.QTN01 + A.QTN02 = eachItem報價單.報價單號碼 Select A).ToList
                Dim Search鋼種 As String = Step8SearchResult.Item(0).QTN03
                Dim Search表面 As String = Step8SearchResult.Item(0).QTN04
                Dim Search厚度誤差 As Single = 0.1
                Dim Search厚度S As String = Single.Parse(eachItemDisplayItem.厚度) - Search厚度誤差
                Dim Search厚度E As String = Single.Parse(eachItemDisplayItem.厚度) + Search厚度誤差
                Dim QuerySQL As New StringBuilder
                QuerySQL.Append("SELECT * FROM @#pps100lb.ppsciapf " & vbNewLine)
                QuerySQL.Append("WHERE " & vbNewLine)
                QuerySQL.Append("              cia04 ='" & eachItem報價單.報價單號碼 & "' " & vbNewLine)
                QuerySQL.Append("              AND cia05='" & Search鋼種 & "'  " & vbNewLine)
                QuerySQL.Append("              AND cia06='" & Search表面 & "'  " & vbNewLine)
                QuerySQL.Append("              AND cia07 between " & Search厚度S & " and " & Search厚度E & " " & vbNewLine)
                QuerySQL.Append("ORDER BY cia02 , cia03 " & vbNewLine)
                Dim QueryList As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = ClassDBAS400.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCIAPF)(QuerySQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

                Dim DisplayItem2 As DisplayItemStye3 = Nothing
                Dim DisplayListDetail2 As List(Of DisplayItemStye3) = DisplayItem.Detail明細
                For Each eachItemQuery As CompanyORMDB.PPS100LB.PPSCIAPF In QueryList
                    DisplayItem2 = New DisplayItemStye3
                    DisplayItem2.鋼捲號碼 = eachItemQuery.CIA02.Trim & eachItemQuery.CIA03.Trim

                    '3個數字加上1個逗號
                    DisplayItem2.淨重 = String.Format("{0:N0}", eachItemQuery.CIA13)
                    DisplayItem2.一級重量 = String.Format("{0:N0}", eachItemQuery.CIA23)
                    DisplayItem2.二級重量 = String.Format("{0:N0}", eachItemQuery.CIA24)
                    DisplayItem2.三級重量 = String.Format("{0:N0}", eachItemQuery.CIA25)

                    DisplayListDetail2.Add(DisplayItem2)
                Next

                DisplayListDetail.Add(DisplayItem)
            Next

        Next


        'Display ---------------------------------------------------------------------------------------------------------------------------------
        Dim CntOf筆數 As Integer = 0
        Dim CntOf厚度 As Integer
        Dim CntOf報價單 As Integer

        For Each eachItem1 As DisplayItemStye3 In DisplayList
            CntOf筆數 += 1
            show厚度 &= eachItem1.厚度 & "<BR>"
            show厚度提貨量 &= eachItem1.厚度提貨量 & "<BR>"

            CntOf厚度 = 0
            For Each eachItem2 As DisplayItemStye3 In eachItem1.Detail明細
                show報價單號碼 &= eachItem2.報價單號碼 & "<BR>"
                show寬度 &= eachItem2.報價單寬度 & "<BR>"

                CntOf報價單 = eachItem2.Detail明細.Count
                If CntOf報價單 = 0 Then
                    CntOf厚度 += 1

                    show鋼捲號碼 &= getStringOfBR(1)
                    show淨重 &= getStringOfBR(1)
                    show一級重量 &= getStringOfBR(1)
                    show二級重量 &= getStringOfBR(1)
                    show三級重量 &= getStringOfBR(1)

                Else
                    CntOf厚度 += CntOf報價單

                    For Each eachItem3 As DisplayItemStye3 In eachItem2.Detail明細
                        show鋼捲號碼 &= eachItem3.鋼捲號碼 & "<BR>"
                        show淨重 &= eachItem3.淨重 & "<BR>"
                        show一級重量 &= eachItem3.一級重量 & "<BR>"
                        show二級重量 &= eachItem3.二級重量 & "<BR>"
                        show三級重量 &= eachItem3.三級重量 & "<BR>"
                    Next

                    show報價單號碼 &= getStringOfBR(CntOf報價單 - 1)
                    show寬度 &= getStringOfBR(CntOf報價單 - 1)
                End If
            Next

            show厚度 &= getStringOfBR(CntOf厚度 - 1)
            show厚度提貨量 &= getStringOfBR(CntOf厚度 - 1)

            If CntOf筆數 < DisplayList.Count Then
                show報價單號碼 &= getStringOfBR(1)
                show寬度 &= getStringOfBR(1)
                show厚度 &= getStringOfBR(1)
                show厚度提貨量 &= getStringOfBR(1)
                show鋼捲號碼 &= getStringOfBR(1)
                show淨重 &= getStringOfBR(1)
                show一級重量 &= getStringOfBR(1)
                show二級重量 &= getStringOfBR(1)
                show三級重量 &= getStringOfBR(1)
            End If
        Next

        Select Case fromDisplayType
            Case "CR"
                fromDisplayItem.CR厚度 = show厚度
                fromDisplayItem.CR厚度提貨量 = show厚度提貨量
                fromDisplayItem.CR報價單號碼 = show報價單號碼
                fromDisplayItem.CR訂單量 = show訂單量
                fromDisplayItem.CR訂單量Display = fromDisplayItem.CR訂單量
                fromDisplayItem.CR提貨量 = show提貨量
                fromDisplayItem.CR提貨量Display = fromDisplayItem.CR提貨量
                fromDisplayItem.CR寬度 = show寬度

                fromDisplayItem.CR鋼捲號碼 = show鋼捲號碼
                fromDisplayItem.CR淨重 = show淨重
                fromDisplayItem.CR一級重量 = show一級重量
                fromDisplayItem.CR二級重量 = show二級重量
                fromDisplayItem.CR三級重量 = show三級重量

            Case "HR"
                fromDisplayItem.HR厚度 = show厚度
                fromDisplayItem.HR厚度提貨量 = show厚度提貨量
                fromDisplayItem.HR報價單號碼 = show報價單號碼
                fromDisplayItem.HR訂單量 = show訂單量
                fromDisplayItem.HR訂單量Display = fromDisplayItem.HR訂單量
                fromDisplayItem.HR提貨量 = show提貨量
                fromDisplayItem.HR提貨量Display = fromDisplayItem.HR提貨量
                fromDisplayItem.HR寬度 = show寬度

                fromDisplayItem.HR鋼捲號碼 = show鋼捲號碼
                fromDisplayItem.HR淨重 = show淨重
                fromDisplayItem.HR一級重量 = show一級重量
                fromDisplayItem.HR二級重量 = show二級重量
                fromDisplayItem.HR三級重量 = show三級重量
        End Select

    End Sub

    Private Shared Function getStringOfBR(ByVal fromCount As Integer) As String
        Dim retString As String = ""
        If fromCount <= 0 Then Return retString

        For II As Integer = 1 To fromCount
            retString &= "<BR>"
        Next
        Return retString
    End Function
#End Region


#Region "第四版:依提貨單"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search4(ByVal SQLString As String, ByVal Args As String, ByVal fromSQLParam As String) As SLS300LB.TakeGoodSearchResultTable3DataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New SLS300LB.TakeGoodSearchResultTable3DataTable
        End If

        'Step1SearchResult：所有符合的提貨單資料
        Dim Step1SearchResult As List(Of SL2BOLPF_Ex) = ClassDBAS400.CDBSelect(Of SL2BOLPF_Ex)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        'Step2SearchResult：所有符合的報價單資料
        Dim QuerySql2 As New StringBuilder
        Dim QueryBol03List As String = String.Join("','", (From A In Step1SearchResult Order By A.BOL03 Select A.BOL03 Distinct).ToArray)
        QuerySql2.Append("SELECT * " & vbNewLine)
        QuerySql2.Append("FROM @#SLS300LB.SL2QTNPF " & vbNewLine)
        QuerySql2.Append("WHERE qtn01|| qtn02 IN ('" & QueryBol03List & "') ")
        Dim Step1BSearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = ClassDBAS400.CDBSelect(Of CompanyORMDB.SLS300LB.SL2QTNPF)(QuerySql2.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        '整理Step1SearchResult：整合報價單資料(Step2SearchResult)至提貨單資料(Step1SearchResult)
        For Each eachItemStep1 As SL2BOLPF_Ex In Step1SearchResult
            '依 報價單號/鋼種/表面/厚度 取得資料
            Dim Temp厚度誤差 As Single
            Dim Search厚度誤差 As Single = 100
            Dim SearchStep2 As CompanyORMDB.SLS300LB.SL2QTNPF = Nothing
            For Each eachItemStep2 As CompanyORMDB.SLS300LB.SL2QTNPF In (From A In Step1BSearchResult _
                                                                                                                                                        Where A.QTN01 & A.QTN02 = eachItemStep1.BOL03 _
                                                                                                                                                            And A.QTN03 = eachItemStep1.BOL05 _
                                                                                                                                                            And A.QTN04 = eachItemStep1.BOL06
                                                                                                                                                       Select A)
                If IsNumeric(eachItemStep2.QTN05.Trim) = False Then eachItemStep2.QTN05 = "0"

                '提貨單的厚度與報價單的厚度有差，依序尋找最接近的報價單厚度
                Temp厚度誤差 = Math.Abs((Single.Parse(eachItemStep2.QTN05) - eachItemStep1.BOL07))
                If Search厚度誤差 >= Temp厚度誤差 Then
                    Search厚度誤差 = Temp厚度誤差
                    SearchStep2 = eachItemStep2
                End If
            Next

            If Not SearchStep2 Is Nothing Then
                eachItemStep1.報價單_客戶代號 = SearchStep2.QTN01
                eachItemStep1.報價單_報價單編號 = SearchStep2.QTN02
                eachItemStep1.報價單_鋼種 = SearchStep2.QTN03
                eachItemStep1.報價單_表面 = SearchStep2.QTN04
                eachItemStep1.報價單_厚度 = SearchStep2.QTN05
                eachItemStep1.報價單_合約內_外 = SearchStep2.QTN28
                eachItemStep1.報價單_寬度 = SearchStep2.QTN06
                eachItemStep1.報價單_毛修邊 = SearchStep2.QTN08
                eachItemStep1.報價單_訂單量 = SearchStep2.QTN12
                eachItemStep1.報價單_About_SL2CH2PF_CH202 = SearchStep2.About_SL2CH2PF_CH202
                eachItemStep1.報價單_About_SL2CH2PF_CH205 = SearchStep2.About_SL2CH2PF_CH205
            End If
        Next

        Dim QueryPPSCIAPFList As String = String.Join("','", (From A In Step1SearchResult Select Field1 = A.BOL16 + "," + A.BOL17 Distinct Order By Field1).ToArray)
        Dim QuerySQLPPSCIAPF As New StringBuilder
        QuerySQLPPSCIAPF.Append("SELECT * FROM @#pps100lb.ppsciapf " & vbNewLine)
        QuerySQLPPSCIAPF.Append("WHERE 1=1 " & vbNewLine)
        QuerySQLPPSCIAPF.Append("       AND cia04 IN ('" & QueryBol03List & "') ")

        Dim Setp1PPSCIAPF As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = ClassDBAS400.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCIAPF)(QuerySQLPPSCIAPF.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        Dim ReturnValue As New SLS300LB.TakeGoodSearchResultTable3DataTable
        Dim AddItem As SLS300LB.TakeGoodSearchResultTable3Row

        'tempStep1SearchResult過濾搜尋條件：鋼種/表面/厚度
        Dim tempStep1SearchResult As List(Of SL2BOLPF_Ex) = Nothing
        Dim SearchSteelKind As String = fromSQLParam.Split("|")(1)
        SearchSteelKind = SearchSteelKind.Replace("'", Nothing)
        Dim SearchFace As String = fromSQLParam.Split("|")(2)
        SearchFace = SearchFace.Replace("'", Nothing)
        Dim SearchWeightStart As String = ""
        Dim SearchWeightEnd As String = ""
        If fromSQLParam.Split("|")(3) <> "" Then
            SearchWeightStart = fromSQLParam.Split("|")(3).Split("~")(0)
            SearchWeightEnd = fromSQLParam.Split("|")(3).Split("~")(1)
        End If

        If SearchSteelKind.Length > 0 Then
            tempStep1SearchResult = (From A In Step1SearchResult Where SearchSteelKind.Split(",").Contains(A.報價單_鋼種.Trim) Select A).ToList
            Step1SearchResult = tempStep1SearchResult
        End If

        If SearchFace.Length > 0 Then
            tempStep1SearchResult = (From A In Step1SearchResult Where SearchFace.Split(",").Contains(A.報價單_表面.Trim) Select A).ToList
            Step1SearchResult = tempStep1SearchResult
        End If

        If SearchWeightStart <> "" AndAlso SearchWeightEnd <> "" Then
            tempStep1SearchResult = (From A In Step1SearchResult Where Single.Parse(A.報價單_厚度) >= SearchWeightStart And Single.Parse(A.報價單_厚度) <= SearchWeightEnd Select A).ToList
            Step1SearchResult = tempStep1SearchResult
        End If


        'LinqQuery：客戶&鋼種
        Dim LinqQuery As List(Of String) = Nothing
        Select Case True
            Case Args.Split("@")(0) = "ALL"
                LinqQuery = (From A In Step1SearchResult Select Field1 = A.報價單_客戶代號 + "," + A.報價單_鋼種 Distinct Order By Field1).ToList
            Case Args.Split("@")(0) = "HOMESELL"
                LinqQuery = (From A In Step1SearchResult Where A.報價單_合約內_外 = " " Select Field1 = A.報價單_客戶代號 + "," + A.報價單_鋼種 Distinct Order By Field1).ToList
            Case Args.Split("@")(0) = "EXPORTSELL"
                LinqQuery = (From A In Step1SearchResult Where A.報價單_合約內_外 <> " " Select Field1 = A.報價單_客戶代號 + "," + A.報價單_鋼種 Distinct Order By Field1).ToList
        End Select


        Dim PreRecordCustomer As String = Nothing
        Dim DateRangS As Date = CDate(Args.Split("@")(1).Split("~")(0) & "/01")
        Dim DateRangE As Date = CDate(Args.Split("@")(1).Split("~")(1) & "/02")
        For Each EachItem In LinqQuery
            Dim EachItemTem As String = EachItem

            If EachItemTem.Substring(0, 3) = "D04" Then
                Debug.Print(Now)
            End If

            If Not IsNothing(PreRecordCustomer) AndAlso EachItemTem.Substring(0, 3) <> PreRecordCustomer Then
                '客戶小計
                AddSmallSum3(EnumRunMode3.客戶小計, ReturnValue, PreRecordCustomer)
            End If

            Dim show報表統計月份 As String
            Dim show客戶 As String
            Dim show鋼種 As String = ""
            Dim show合約內_外 As String = ""
            Dim showHeadNow As New DisplayItemStye3

            'Step2SearchResult：客戶&鋼種
            Dim Step2SearchResult As List(Of SL2BOLPF_Ex) = (From A In Step1SearchResult Where (A.報價單_客戶代號 + "," + A.報價單_鋼種) = EachItemTem Select A).ToList
            Dim Step2IsInContract As List(Of String) = (From A In Step2SearchResult Order By A.報價單_合約內_外 Select A.報價單_合約內_外 Distinct).ToList
            For Each IsInContract As String In Step2IsInContract

                'Step2BSearchResult：提貨單月份(Distinct)
                Dim Step2BSearchResult As List(Of String) = (From A In Step2SearchResult Where A.報價單_合約內_外 = IsInContract Order By Left(A.BOL01, 5) Select Left(A.BOL01, 5) Distinct).ToList

                For Each eachItemYearMonth As String In Step2BSearchResult

                    Dim Step3SearchResult As List(Of SL2BOLPF_Ex) = _
                                                                                    (From A In Step2SearchResult Where A.報價單_合約內_外 = IsInContract And Left(A.BOL01, 5) = eachItemYearMonth Select A).ToList

                    AddItem = ReturnValue.NewRow
                    With AddItem
                        'show報表統計月份 = Format(DateRangNow, "yyyy/MM")
                        show報表統計月份 = Integer.Parse(Left(eachItemYearMonth, eachItemYearMonth.Length - 2)) + 1911 & "/" & Right(eachItemYearMonth, 2)
                        show客戶 = EachItem.Split(",")(0)
                        show鋼種 = EachItem.Split(",")(1)
                        show合約內_外 = IIf(IsInContract = "*", "合約外", "合約內")

                        If Not (showHeadNow.客戶.Equals(show客戶) _
                                       AndAlso showHeadNow.鋼種.Equals(show鋼種) AndAlso showHeadNow._合約內_外_.Equals(show合約內_外)) Then

                            .客戶Display = show客戶
                            .鋼種Display = show鋼種
                            ._合約內_外_Display = show合約內_外

                            showHeadNow.客戶 = show客戶
                            showHeadNow.鋼種 = show鋼種
                            showHeadNow._合約內_外_ = show合約內_外
                        End If
                        .客戶 = show客戶
                        .鋼種 = show鋼種
                        ._合約內_外_ = show合約內_外
                        .報表統計月份 = show報表統計月份

                        'Step4SearchResult：CR/HR
                        Dim Step4SearchResult As List(Of SL2BOLPF_Ex) = Nothing
                        'CR
                        Step4SearchResult = (From A In Step3SearchResult Where A.報價單_About_SL2CH2PF_CH205 = "CR" And A.報價單_About_SL2CH2PF_CH202 <> "Y" Select A).ToList
                        setDisplayItem4("CR", AddItem, Step4SearchResult, Setp1PPSCIAPF)

                        'HR
                        Step4SearchResult = (From A In Step3SearchResult Where A.報價單_About_SL2CH2PF_CH205 = "HR" And A.報價單_About_SL2CH2PF_CH202 <> "Y" Select A).ToList
                        setDisplayItem4("HR", AddItem, Step4SearchResult, Setp1PPSCIAPF)

                    End With
                    ReturnValue.Rows.Add(AddItem)
                Next

                PreRecordCustomer = EachItemTem.Split(",")(0)
                If Not (DateRangS.Year = DateRangE.Year And DateRangS.Month = DateRangE.Month) Then
                    '客戶合約內外小計
                    AddSmallSum3(EnumRunMode3.客戶合約內外小計, ReturnValue, PreRecordCustomer, show合約內_外, show鋼種)
                End If

            Next

        Next
        '客戶小計
        AddSmallSum3(EnumRunMode3.客戶小計, ReturnValue, PreRecordCustomer)

        '合計
        AddSmallSum3(EnumRunMode3.合計, ReturnValue)

        Return ReturnValue
    End Function

    Public Shared Sub setDisplayItem4(ByVal fromDisplayType As String, ByRef fromDisplayItem As SLS300LB.TakeGoodSearchResultTable3Row, _
                                                          ByVal fromDataSoruce As List(Of SL2BOLPF_Ex), ByVal fromQueryListPPSCIAPF As List(Of CompanyORMDB.PPS100LB.PPSCIAPF))

        Dim show訂單量 As Single
        Dim show提貨量 As Single
        Dim show厚度 As String = ""
        Dim show厚度提貨量 As String = ""
        Dim show寬度 As String = ""

        Dim show鋼捲號碼 As String = ""
        Dim show淨重 As String = ""
        Dim show一級重量 As String = ""
        Dim show二級重量 As String = ""
        Dim show三級重量 As String = ""
        Dim show報價單號碼 As String = ""

        If fromDataSoruce.Count > 0 Then
            If fromDataSoruce.Item(0).報價單_客戶代號 = "D03" Then
                Debug.Print(Now)
            End If
        End If

        '去除重複報價單資料：客戶代號/報價單編號/鋼種/表面/厚度
        Dim exists報價單 As Boolean
        Dim temp報價單清單 As New List(Of SL2BOLPF_Ex)
        For Each eachItem As SL2BOLPF_Ex In fromDataSoruce

            exists報價單 = False
            For Each eachItem2 In temp報價單清單
                If eachItem2.報價單_客戶代號 = eachItem.報價單_客戶代號 _
                    AndAlso eachItem2.報價單_報價單編號 = eachItem.報價單_報價單編號 _
                    AndAlso eachItem2.報價單_鋼種 = eachItem.報價單_鋼種 _
                    AndAlso eachItem2.報價單_表面 = eachItem.報價單_表面 _
                    AndAlso eachItem2.報價單_厚度 = eachItem.報價單_厚度 Then
                    exists報價單 = True
                    Exit For
                End If
            Next
            If exists報價單 = False Then
                temp報價單清單.Add(eachItem)
            End If
        Next
        show訂單量 = (From A In temp報價單清單 Select A.報價單_訂單量).Sum


        'Step5SearchResult：厚度 (Distinct)
        Dim Step5SearchResult As List(Of String) = Nothing
        Step5SearchResult = (From A In fromDataSoruce Order By A.報價單_厚度 Select A.報價單_厚度 Distinct).ToList
        Dim DisplayItem As DisplayItemStye3
        Dim DisplayList As New List(Of DisplayItemStye3)

        For Each eachItemQTN05 As String In Step5SearchResult
            DisplayItem = New DisplayItemStye3
            DisplayItem.厚度 = eachItemQTN05
            DisplayItem.厚度提貨量 = (From A In fromDataSoruce Where A.報價單_厚度 = eachItemQTN05 Select A.BOL14).Sum
            show提貨量 += Single.Parse(DisplayItem.厚度提貨量)

            DisplayList.Add(DisplayItem)
        Next

        Dim DisplayListDetail As List(Of DisplayItemStye3) = Nothing
        'Step6SearchResult：厚度的提貨單明細
        Dim Step6SearchResult As List(Of SL2BOLPF_Ex) = Nothing
        'Step7SearchResult：此厚度的 報價單號與寬度 (Distinct)
        Dim Step7SearchResult As List(Of ClassQuerySl2qtnpfStye3) = Nothing
        For Each eachItemDisplayItem As DisplayItemStye3 In DisplayList
            DisplayListDetail = eachItemDisplayItem.Detail明細
            Step6SearchResult = (From A In fromDataSoruce Where A.報價單_厚度 = eachItemDisplayItem.厚度 Select A).ToList
            Step7SearchResult = (From A In Step6SearchResult Group By A.報價單_客戶代號, A.報價單_報價單編號, A.報價單_寬度, A.報價單_毛修邊 Into GroupCount = Count() Order By 報價單_報價單編號 Select New ClassQuerySl2qtnpfStye3(報價單_客戶代號 + 報價單_報價單編號, 報價單_寬度.ToString.Trim + 報價單_毛修邊.Trim)).ToList

            For Each eachItem報價單 As ClassQuerySl2qtnpfStye3 In Step7SearchResult
                DisplayItem = New DisplayItemStye3
                DisplayItem.報價單號碼 = eachItem報價單.報價單號碼
                DisplayItem.報價單寬度 = eachItem報價單.報價單寬度

                Dim Step8SearchResult As List(Of SL2BOLPF_Ex) = (From A In Step6SearchResult Where A.報價單_客戶代號 + A.報價單_報價單編號 = eachItem報價單.報價單號碼 And A.報價單_寬度 + A.報價單_毛修邊 = eachItem報價單.報價單寬度 Select A).ToList

                For Each eachItemStep8 As SL2BOLPF_Ex In Step8SearchResult

                    Dim QueryList As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = (From A In fromQueryListPPSCIAPF _
                                                                                                                                                         Where A.CIA02 = eachItemStep8.BOL16 _
                                                                                                                                                               And A.CIA03 = eachItemStep8.BOL17 _
                                                                                                                                                               And A.CIA04 = eachItemStep8.BOL03 _
                                                                                                                                                               And A.CIA05 = eachItemStep8.報價單_鋼種 _
                                                                                                                                                               And A.CIA06 = eachItemStep8.報價單_表面 _
                                                                                                                                                         Order By A.CIA02, A.CIA04 _
                                                                                                                                                         Select A).ToList

                    Dim DisplayItem2 As DisplayItemStye3 = Nothing
                    Dim DisplayListDetail2 As List(Of DisplayItemStye3) = DisplayItem.Detail明細
                    For Each eachItemQuery As CompanyORMDB.PPS100LB.PPSCIAPF In QueryList
                        DisplayItem2 = New DisplayItemStye3
                        DisplayItem2.鋼捲號碼 = eachItemQuery.CIA02.Trim & eachItemQuery.CIA03.Trim

                        '3個數字加上1個逗號
                        DisplayItem2.淨重 = String.Format("{0:N0}", eachItemQuery.CIA13)
                        DisplayItem2.一級重量 = String.Format("{0:N0}", eachItemQuery.CIA23)
                        DisplayItem2.二級重量 = String.Format("{0:N0}", eachItemQuery.CIA24)
                        DisplayItem2.三級重量 = String.Format("{0:N0}", eachItemQuery.CIA25)

                        DisplayListDetail2.Add(DisplayItem2)
                    Next

                Next
                DisplayListDetail.Add(DisplayItem)

            Next

        Next


        'Display ---------------------------------------------------------------------------------------------------------------------------------
        Dim CntOf筆數 As Integer = 0
        Dim CntOf厚度 As Integer
        Dim CntOf報價單 As Integer

        For Each eachItem1 As DisplayItemStye3 In DisplayList
            CntOf筆數 += 1
            show厚度 &= eachItem1.厚度 & "<BR>"
            show厚度提貨量 &= eachItem1.厚度提貨量 & "<BR>"

            CntOf厚度 = 0
            For Each eachItem2 As DisplayItemStye3 In eachItem1.Detail明細
                show報價單號碼 &= eachItem2.報價單號碼 & "<BR>"
                show寬度 &= eachItem2.報價單寬度 & "<BR>"

                CntOf報價單 = eachItem2.Detail明細.Count
                If CntOf報價單 = 0 Then
                    CntOf厚度 += 1

                    show鋼捲號碼 &= getStringOfBR(1)
                    show淨重 &= getStringOfBR(1)
                    show一級重量 &= getStringOfBR(1)
                    show二級重量 &= getStringOfBR(1)
                    show三級重量 &= getStringOfBR(1)

                Else
                    CntOf厚度 += CntOf報價單

                    For Each eachItem3 As DisplayItemStye3 In eachItem2.Detail明細
                        show鋼捲號碼 &= eachItem3.鋼捲號碼 & "<BR>"
                        show淨重 &= eachItem3.淨重 & "<BR>"
                        show一級重量 &= eachItem3.一級重量 & "<BR>"
                        show二級重量 &= eachItem3.二級重量 & "<BR>"
                        show三級重量 &= eachItem3.三級重量 & "<BR>"
                    Next

                    show報價單號碼 &= getStringOfBR(CntOf報價單 - 1)
                    show寬度 &= getStringOfBR(CntOf報價單 - 1)
                End If
            Next

            show厚度 &= getStringOfBR(CntOf厚度 - 1)
            show厚度提貨量 &= getStringOfBR(CntOf厚度 - 1)

            If CntOf筆數 < DisplayList.Count Then
                show報價單號碼 &= getStringOfBR(1)
                show寬度 &= getStringOfBR(1)
                show厚度 &= getStringOfBR(1)
                show厚度提貨量 &= getStringOfBR(1)
                show鋼捲號碼 &= getStringOfBR(1)
                show淨重 &= getStringOfBR(1)
                show一級重量 &= getStringOfBR(1)
                show二級重量 &= getStringOfBR(1)
                show三級重量 &= getStringOfBR(1)
            End If
        Next

        Select Case fromDisplayType
            Case "CR"
                fromDisplayItem.CR厚度 = show厚度
                fromDisplayItem.CR厚度提貨量 = show厚度提貨量
                fromDisplayItem.CR報價單號碼 = show報價單號碼
                fromDisplayItem.CR訂單量 = show訂單量
                fromDisplayItem.CR訂單量Display = fromDisplayItem.CR訂單量
                fromDisplayItem.CR提貨量 = show提貨量
                fromDisplayItem.CR提貨量Display = fromDisplayItem.CR提貨量
                fromDisplayItem.CR寬度 = show寬度

                fromDisplayItem.CR鋼捲號碼 = show鋼捲號碼
                fromDisplayItem.CR淨重 = show淨重
                fromDisplayItem.CR一級重量 = show一級重量
                fromDisplayItem.CR二級重量 = show二級重量
                fromDisplayItem.CR三級重量 = show三級重量

            Case "HR"
                fromDisplayItem.HR厚度 = show厚度
                fromDisplayItem.HR厚度提貨量 = show厚度提貨量
                fromDisplayItem.HR報價單號碼 = show報價單號碼
                fromDisplayItem.HR訂單量 = show訂單量
                fromDisplayItem.HR訂單量Display = fromDisplayItem.HR訂單量
                fromDisplayItem.HR提貨量 = show提貨量
                fromDisplayItem.HR提貨量Display = fromDisplayItem.HR提貨量
                fromDisplayItem.HR寬度 = show寬度

                fromDisplayItem.HR鋼捲號碼 = show鋼捲號碼
                fromDisplayItem.HR淨重 = show淨重
                fromDisplayItem.HR一級重量 = show一級重量
                fromDisplayItem.HR二級重量 = show二級重量
                fromDisplayItem.HR三級重量 = show三級重量
        End Select

    End Sub

    Class SL2BOLPF_Ex
        Inherits CompanyORMDB.SLS300LB.SL2BOLPF

        Public 報價單_客戶代號 As String = ""
        Public 報價單_報價單編號 As String = ""
        Public 報價單_鋼種 As String
        Public 報價單_表面 As String
        Public 報價單_合約內_外 As String
        Public 報價單_厚度 As String
        Public 報價單_寬度 As String
        Public 報價單_毛修邊 As String
        Public 報價單_訂單量 As Single

        Public 報價單_About_SL2CH2PF_CH205 As String
        Public 報價單_About_SL2CH2PF_CH202 As String
    End Class
#End Region



#Region "產生查詢至控製項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢至控製項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl(ByVal fromReportFormat As String)
        Dim FindYear1 As String = Format(CType(tbStartYear.Text, Integer) - 1911, "000")
        Dim FindYear2 As String = Format(CType(tbEndYear.Text, Integer) - 1911, "000")
        Dim FindMonth1 As String = ddlStartMonth.Text.Trim
        Dim FindMonth2 As String = ddlEndMonth.Text.Trim
        Dim SQLString As String = ""

        'SQLString = "SELECT * FROM (" & vbNewLine
        'SQLString &= "          Select A.* ,CASE qtn05 WHEN '' THEN 0 ELSE DOUBLE(qtn05) END qtn05Num" & vbNewLine

        Select Case ddlReportFormat.SelectedValue
            Case 1, 3      '訂單量與提貨量清單 /  '訂單量與提貨量清單&鋼捲資料_依報價單統計
                SQLString = "SELECT * FROM (" & vbNewLine
                SQLString &= "          Select A.* ,CASE qtn05 WHEN '' THEN 0 ELSE DOUBLE(qtn05) END qtn05Num" & vbNewLine

                If ddlReportFormat.SelectedValue = "1" Then     '訂單量與提貨量清單
                    If rbSearchDateMode.SelectedItem.Text = "報價日期" Then
                        SQLString &= "          FROM @#SLS300LB.SL2QTNPF A " & vbNewLine
                        SQLString &= "          Where left(QTN02,5) >= '" & FindYear1 & FindMonth1 & "' and left(QTN02,5) <= '" & FindYear2 & FindMonth2 & "'" & vbNewLine
                    ElseIf rbSearchDateMode.SelectedItem.Text = "提貨日期" Then
                        SQLString &= "          FROM (SELECT bol03" & vbNewLine
                        SQLString &= "          		       FROM @#SLS300LB.SL2BOLPF" & vbNewLine
                        SQLString &= "          		       WHERE LEFT(bol01,5) >= '" & FindYear1 & FindMonth1 & "' AND LEFT(bol01,5) <= '" & FindYear2 & FindMonth2 & "'" & vbNewLine
                        SQLString &= "          		       GROUP BY bol03) B" & vbNewLine
                        SQLString &= "          LEFT join @#SLS300LB.SL2QTNPF A ON A.qtn01||A.qtn02 = B.bol03" & vbNewLine
                        SQLString &= "          Where 1=1" & vbNewLine
                    End If

                ElseIf ddlReportFormat.SelectedValue = "3" Then '訂單量與提貨量清單&鋼捲資料_依報價單統計
                    SQLString &= "          FROM (SELECT bol03" & vbNewLine
                    SQLString &= "          		       FROM @#SLS300LB.SL2BOLPF" & vbNewLine
                    SQLString &= "          		       WHERE LEFT(bol01,5) >= '" & FindYear1 & FindMonth1 & "' AND LEFT(bol01,5) <= '" & FindYear2 & FindMonth2 & "'" & vbNewLine
                    'SQLString &= "          		       WHERE SUBSTR(bol03,4,5) >= '" & FindYear1 & FindMonth1 & "' AND SUBSTR(bol03,4,5)<= '" & FindYear2 & FindMonth2 & "'" & vbNewLine
                    SQLString &= "          		       GROUP BY bol03) B" & vbNewLine
                    SQLString &= "          LEFT join @#SLS300LB.SL2QTNPF A ON A.qtn01||A.qtn02 = B.bol03" & vbNewLine
                    SQLString &= "          Where 1=1" & vbNewLine
                End If

                Select Case RadioButtonList1.SelectedValue.ToUpper
                    Case "HOMESELL"
                        SQLString &= " AND QTN29=' '" & vbNewLine
                    Case "EXPORTSELL"
                        SQLString &= " AND QTN29<>' '" & vbNewLine
                End Select

                If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Length > 0 Then
                    tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
                    SQLString &= "  AND QTN03 IN ('" & tbSteelKind.Text.Replace(",", "','") & "')" & vbNewLine
                End If

                If Not String.IsNullOrEmpty(tbFace.Text) AndAlso tbFace.Text.Trim.Length > 0 Then
                    SQLString &= " AND QTN04 IN ('" & tbFace.Text.Trim.ToUpper.Replace(",", "','") & "')" & vbNewLine
                End If

                SQLString &= " ) v " & vbNewLine
                SQLString &= "WHERE 1=1 " & vbNewLine
                If Not String.IsNullOrEmpty(tbStartThick.Text) OrElse Not String.IsNullOrEmpty(tbEndThick.Text) Then
                    Dim StartThick As Single = IIf(String.IsNullOrEmpty(tbStartThick.Text), 0, Val(tbStartThick.Text))
                    Dim EndThick As Single = IIf(String.IsNullOrEmpty(tbEndThick.Text), 99.99, Val(tbEndThick.Text))
                    SQLString &= "  AND ( qtn05Num>=" & StartThick & " AND qtn05Num<=" & EndThick & ")" & vbNewLine
                End If

            Case 4      '訂單量與提貨量清單&鋼捲資料_依提貨單統計
                '其他過濾條件給下一步Search4處理
                SQLString = "                           SELECT A.*" & vbNewLine
                SQLString &= "          		       FROM @#SLS300LB.SL2BOLPF A" & vbNewLine
                SQLString &= "          		       WHERE LEFT(bol01,5) >= '" & FindYear1 & FindMonth1 & "' AND LEFT(bol01,5) <= '" & FindYear2 & FindMonth2 & "'" & vbNewLine
                SQLString &= "          		       ORDER BY LEFT(bol03,3),bol05,LEFT(bol01,5) " & vbNewLine
        End Select


        Select Case fromReportFormat
            Case "1"
                Me.hfQry1.Value = SQLString

            Case "3"
                Me.hfQry3.Value = SQLString

            Case "4"
                Me.hfQry4.Value = SQLString

                '內外銷|鋼種|表面|厚度起~迄
                Me.hfQryParam4.Value = RadioButtonList1.SelectedValue.ToUpper & "|"

                If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Length > 0 Then
                    Me.hfQryParam4.Value &= tbSteelKind.Text
                End If
                Me.hfQryParam4.Value &= "|"

                If Not String.IsNullOrEmpty(tbFace.Text) AndAlso tbFace.Text.Length > 0 Then
                    Me.hfQryParam4.Value &= tbFace.Text
                End If
                Me.hfQryParam4.Value &= "|"

                If Not String.IsNullOrEmpty(tbStartThick.Text) AndAlso tbStartThick.Text.Length > 0 AndAlso IsNumeric(tbStartThick.Text) Then
                    Me.hfQryParam4.Value &= tbStartThick.Text
                Else
                    Me.hfQryParam4.Value &= "0.0"
                End If
                Me.hfQryParam4.Value &= "~"

                If Not String.IsNullOrEmpty(tbEndThick.Text) AndAlso tbEndThick.Text.Length > 0 AndAlso IsNumeric(tbEndThick.Text) Then
                    Me.hfQryParam4.Value &= tbEndThick.Text
                Else
                    Me.hfQryParam4.Value &= "99.99"
                End If

        End Select

        Me.hfArgs.Value = RadioButtonList1.SelectedValue & "@" & tbStartYear.Text & "/" & ddlStartMonth.Text & "~" & tbEndYear.Text & "/" & ddlEndMonth.Text
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartYear.Text = Now.Year
            tbEndYear.Text = tbStartYear.Text
            ddlStartMonth.SelectedValue = Format(Now, "MM")
            ddlEndMonth.SelectedValue = ddlStartMonth.SelectedValue

            tbStartThick.Text = "0.0"
            tbEndThick.Text = "99.9"
            tbSteelKind.Text = ""
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl(ddlReportFormat.SelectedValue)

        Select Case ddlReportFormat.SelectedValue
            Case "1"
                GridView1.DataBind()
                MultiView1.SetActiveView(View1)

            Case "3"
                GridView3.DataBind()
                MultiView1.SetActiveView(View3)

            Case "4"
                GridView4.DataBind()
                MultiView1.SetActiveView(View4)
        End Select

    End Sub

    Private Function getStye3HeadTextSearchRange(ByVal fromDateRange As String) As String
        Return "&nbsp;" & fromDateRange
    End Function

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        tbStartYear.Text = Now.Year
        tbEndYear.Text = tbStartYear.Text
        ddlStartMonth.SelectedValue = Format(Now, "MM")
        ddlEndMonth.SelectedValue = ddlStartMonth.SelectedValue

        tbStartThick.Text = "0.0"
        tbEndThick.Text = "99.9"
        tbSteelKind.Text = ""
    End Sub

    Protected Sub btnDownLoadExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoadExcel.Click
        ' Dim SearchResult As SLS300LB.TakeGoodSearchResultTable2DataTable = TakeGoodSearch.Search(Me.hfQry1.Value, Me.hfArgs.Value)
        Dim SearchResult As DataTable = Nothing

        MakeQryToControl(ddlReportFormat.SelectedValue)
        Select Case ddlReportFormat.SelectedValue
            Case "1"
                SearchResult = Search1(Me.hfQry1.Value, Me.hfArgs.Value)

                For Each EachItem As DataRow In SearchResult.Rows
                    '    'EachItem.Item("年月") = "=""" & EachItem.Item("年月") & """"
                    EachItem.Item("年月") = EachItem.Item("年月").ToString.Replace("/", "&nbsp;/&nbsp;")
                Next

            Case "3", "4"
                If ddlReportFormat.SelectedValue = "3" Then
                    SearchResult = Search3(Me.hfQry3.Value, Me.hfArgs.Value)
                Else
                    SearchResult = Search4(Me.hfQry4.Value, Me.hfArgs.Value, Me.hfQryParam4.Value)
                End If

                Dim SearchResultColumnsList As New List(Of String)
                For Each eachItemColumn As DataColumn In SearchResult.Columns
                    SearchResultColumnsList.Add(eachItemColumn.ColumnName)
                Next

                Dim DisplayColumnText As String = "Display"
                'Step1:Remove
                For Each eachItemColumn As String In SearchResultColumnsList
                    If Right(eachItemColumn, DisplayColumnText.Length) = DisplayColumnText Then
                        SearchResult.Columns.Remove(Mid(eachItemColumn, 1, (eachItemColumn.Length - DisplayColumnText.Length)))
                    End If
                Next

                'Step2：處理日期
                For Each eachItemRow As DataRow In SearchResult.Rows
                    eachItemRow.Item("報表統計月份") = getStye3HeadTextSearchRange(eachItemRow.Item("報表統計月份"))
                Next

                'Step3:Rename
                For Each eachItemColumn As DataColumn In SearchResult.Columns
                    If Right(eachItemColumn.ColumnName, DisplayColumnText.Length) = DisplayColumnText Then
                        eachItemColumn.ColumnName = Mid(eachItemColumn.ColumnName, 1, (eachItemColumn.ColumnName.Length - DisplayColumnText.Length))
                    End If
                Next

        End Select

        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(SearchResult, "訂單提貨" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub

    Private Sub GridView3_DataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView3.RowDataBound
        '垂直靠上對齊
        For II As Integer = 0 To e.Row.Cells.Count - 1
            e.Row.Cells(II).VerticalAlign = VerticalAlign.Top
        Next

        '數字水平靠右對齊
        For II As Integer = 0 To e.Row.Cells.Count - 1
            Select Case II
                Case 4, 5, 7, 11, 12, 13, 14, 15, 16, 18, 22, 23, 24, 25
                    e.Row.Cells(II).HorizontalAlign = HorizontalAlign.Right
                Case Else
                    e.Row.Cells(II).HorizontalAlign = HorizontalAlign.Left
            End Select
        Next
    End Sub

    Private Sub GridView4_DataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView4.RowDataBound
        '垂直靠上對齊
        For II As Integer = 0 To e.Row.Cells.Count - 1
            e.Row.Cells(II).VerticalAlign = VerticalAlign.Top
        Next

        '數字水平靠右對齊
        For II As Integer = 0 To e.Row.Cells.Count - 1
            Select Case II
                Case 4, 5, 7, 11, 12, 13, 14, 15, 16, 18, 22, 23, 24, 25
                    e.Row.Cells(II).HorizontalAlign = HorizontalAlign.Right
                Case Else
                    e.Row.Cells(II).HorizontalAlign = HorizontalAlign.Left
            End Select
        Next
    End Sub

#Region "統計與顯示用Class"
    Class ClassQuerySl2qtnpf
        Public 報價單編號 As String
        Public 鋼種 As String
        Public 表面 As String

        Sub New()

        End Sub

        Sub New(ByVal from報價單編號 As String, ByVal from鋼種 As String, ByVal from表面 As String)
            報價單編號 = from報價單編號
            鋼種 = from鋼種
            表面 = from表面
        End Sub
    End Class

    Class ClassQuerySl2qtnpfStye3
        Public 報價單號碼 As String
        Public 報價單寬度 As String

        Sub New(ByVal from報價單號碼 As String, ByVal from報價單寬度 As String)
            報價單號碼 = from報價單號碼
            報價單寬度 = from報價單寬度
        End Sub
    End Class
    Class DisplayItemStye3
        Public Detail明細 As New List(Of DisplayItemStye3)
        Public 客戶 As String = ""
        Public 鋼種 As String = ""
        Public 報表統計月份 As String = ""
        Public _合約內_外_ As String = ""
        Public 訂單量 As String = ""
        Public 提貨量 As String = ""
        Public 厚度 As String = ""
        Public 厚度提貨量 As String = ""
        Public 報價單號碼 As String = ""
        Public 報價單寬度 As String = ""
        Public 鋼捲號碼 As String = ""
        Public 淨重 As String = ""
        Public 一級重量 As String = ""
        Public 二級重量 As String = ""
        Public 三級重量 As String = ""
    End Class
#End Region

    Protected Sub ddlReportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReportFormat.SelectedIndexChanged
        rbSearchDateMode.Visible = (ddlReportFormat.SelectedItem.Value = "1")
        lbSearchDateMode.Visible = rbSearchDateMode.Visible
    End Sub
End Class