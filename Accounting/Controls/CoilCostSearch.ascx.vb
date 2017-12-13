Public Class CoilCostSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SqlString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SqlString As String, ByVal SqlString1 As String) As AccountDataSet.CoilCostSearchDataTable
        If String.IsNullOrEmpty(SqlString) OrElse SqlString.Trim.Length = 0 Then
            Return New AccountDataSet.CoilCostSearchDataTable
        End If
        Dim ReturnValue As New AccountDataSet.CoilCostSearchDataTable
        Dim QryAdapter As CompanyORMDB.AS400SQLQueryAdapter = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SqlString)
        Dim QryResult As DataTable = QryAdapter.SelectQuery
        Dim QryResult1 As DataTable = QryAdapter.SelectQuery(SqlString1)
        Dim ACSRM1RowForEachRow As DataRow = Nothing
        For Each EachRow As DataRow In (From A In QryResult.Rows Select A Order By A.ITEM("BLA11"), A.ITEM("RM204"), A.ITEM("RM205"), A.ITEM("RM214"), A.ITEM("RM218"), A.ITEM("RM215")).ToList
            ACSRM1RowForEachRow = (From A In QryResult1 Where A.Item("RM100") = EachRow.Item("RM200") And A.Item("RM101") = EachRow.Item("RM201") And A.Item("RM107") = EachRow.Item("BLA11") And A.Item("RM105") <= EachRow.Item("RM202") & EachRow.Item("RM202A") Select A Order By A.Item("RM105") Descending).FirstOrDefault
            Dim AddItem As AccountDataSet.CoilCostSearchRow = ReturnValue.NewRow
            With AddItem
                .批次 = EachRow.Item("BLA11")
                .鋼種 = EachRow.Item("RM204")
                .表面 = EachRow.Item("RM205")
                .厚度 = EachRow.Item("RM214")
                .銷售別 = EachRow.Item("RM218")
                .料別 = EachRow.Item("RM215")
                .鋼捲 = EachRow.Item("RM200")
                .斷捲 = EachRow.Item("RM201")
                .日期 = EachRow.Item("RM202") & EachRow.Item("RM202A")
                .繳庫線別 = EachRow.Item("RM203")
                .重量 = EachRow.Item("RM206")
                .軋鋼變動原料 = EachRow.Item("RM207")
                .軋鋼變動燃料 = EachRow.Item("RM208")
                .軋鋼變動物料 = EachRow.Item("RM209")
                .軋鋼變動人工 = EachRow.Item("RM210")
                .軋鋼變動間接費用 = EachRow.Item("RM211")
                .軋鋼固定人工 = EachRow.Item("RM210A")
                .軋鋼固定間接費用 = EachRow.Item("RM211A")
                .軋鋼磅差 = EachRow.Item("RM212")
                .軋鋼繳庫單號 = EachRow.Item("RM213")
                .軋鋼型別 = EachRow.Item("RM217")
                .銷售別 = EachRow.Item("RM218")
                .料別 = EachRow.Item("RM215")
                .軋鋼等級 = EachRow.Item("RM216")
                .煉鋼變動原料 = EachRow.Item("RM221")
                .煉鋼變動燃料 = EachRow.Item("RM222")
                .煉鋼變動物料 = EachRow.Item("RM223")
                .煉鋼變動人工 = EachRow.Item("RM224")
                .煉鋼變動間接費用 = EachRow.Item("RM225")
                .煉鋼固定人工 = EachRow.Item("RM224A")
                .煉鋼固定間接費用 = EachRow.Item("RM225A")
                .軋壞損耗 = EachRow.Item("RM226")
                .代軋費 = EachRow.Item("RM227")
                If Not IsDBNull(EachRow.Item("BOL27")) Then
                    .銷售金額 = EachRow.Item("BOL27")
                End If
                If Not IsDBNull(EachRow.Item("CUA11")) Then
                    .訂單年月 = CType(EachRow.Item("CIA04"), String).Substring(3, 5)
                    .客戶名稱 = EachRow.Item("CUA11")
                End If
                If Not IsNothing(ACSRM1RowForEachRow) Then
                    .投入重量 = ACSRM1RowForEachRow.Item("RM110") + ACSRM1RowForEachRow.Item("RM112") + ACSRM1RowForEachRow.Item("RM113")
                    If Not (IsDBNull(EachRow.Item("RM206")) OrElse EachRow.Item("RM206") = 0) Then
                        .產出率 = Format(Val(EachRow.Item("RM206") / Val(.投入重量)), "0.0%")
                    End If
                End If
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function

#End Region
#Region "查詢 方法:Search1"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SqlString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search1(ByVal SqlString As String, ByVal SqlString1 As String) As AccountDataSet.CoilCostSearchDataTable
        If String.IsNullOrEmpty(SqlString) OrElse SqlString.Trim.Length = 0 Then
            Return New AccountDataSet.CoilCostSearchDataTable
        End If
        Dim ReturnValue As New AccountDataSet.CoilCostSearchDataTable
        Dim QryAdapter As CompanyORMDB.AS400SQLQueryAdapter = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SqlString)
        Dim QryResult As DataTable = QryAdapter.SelectQuery
        Dim QryResult1 As DataTable = QryAdapter.SelectQuery(SqlString1)
        Dim ACSRM1RowForEachRow As DataRow = Nothing
        Dim PreDataRow As AccountDataSet.CoilCostSearchRow = Nothing
        For Each EachRow As DataRow In (From A In QryResult.Rows Select A Order By A.ITEM("BLA11"), A.ITEM("RM204"), A.ITEM("RM205"), A.ITEM("RM214"), A.ITEM("RM218"), A.ITEM("RM215")).ToList
            ACSRM1RowForEachRow = (From A In QryResult1 Where A.Item("RM100") = EachRow.Item("RM200") And A.Item("RM101") = EachRow.Item("RM201") And A.Item("RM107") = EachRow.Item("BLA11") And A.Item("RM105") <= EachRow.Item("RM202") & EachRow.Item("RM202A") Select A Order By A.Item("RM105") Descending).FirstOrDefault
            Dim AddItem As AccountDataSet.CoilCostSearchRow = ReturnValue.NewRow
            With AddItem
                .批次 = EachRow.Item("BLA11")
                .鋼種 = EachRow.Item("RM204")
                .表面 = EachRow.Item("RM205")
                .厚度 = EachRow.Item("RM214")
                .銷售別 = EachRow.Item("RM218")
                .料別 = EachRow.Item("RM215")
                .鋼捲 = EachRow.Item("RM200")
                .斷捲 = EachRow.Item("RM201")
                .日期 = EachRow.Item("RM202") & EachRow.Item("RM202A")
                .繳庫線別 = EachRow.Item("RM203")
                .重量 = EachRow.Item("RM206")
                .軋鋼變動原料 = EachRow.Item("RM207")
                .軋鋼變動燃料 = EachRow.Item("RM208")
                .軋鋼變動物料 = EachRow.Item("RM209")
                .軋鋼變動人工 = EachRow.Item("RM210")
                .軋鋼變動間接費用 = EachRow.Item("RM211")
                .軋鋼固定人工 = EachRow.Item("RM210A")
                .軋鋼固定間接費用 = EachRow.Item("RM211A")
                .軋鋼磅差 = EachRow.Item("RM212")
                .軋鋼繳庫單號 = EachRow.Item("RM213")
                .軋鋼型別 = EachRow.Item("RM217")
                .銷售別 = EachRow.Item("RM218")
                .料別 = EachRow.Item("RM215")
                .軋鋼等級 = EachRow.Item("RM216")
                .煉鋼變動原料 = EachRow.Item("RM221")
                .煉鋼變動燃料 = EachRow.Item("RM222")
                .煉鋼變動物料 = EachRow.Item("RM223")
                .煉鋼變動人工 = EachRow.Item("RM224")
                .煉鋼變動間接費用 = EachRow.Item("RM225")
                .煉鋼固定人工 = EachRow.Item("RM224A")
                .煉鋼固定間接費用 = EachRow.Item("RM225A")
                .軋壞損耗 = EachRow.Item("RM226")
                .代軋費 = EachRow.Item("RM227")
                If Not IsDBNull(EachRow.Item("BOL27")) Then
                    .銷售金額 = EachRow.Item("BOL27")
                End If
                If Not IsDBNull(EachRow.Item("CUA11")) Then
                    .訂單年月 = CType(EachRow.Item("CIA04"), String).Substring(3, 5)
                    .客戶名稱 = EachRow.Item("CUA11")
                End If
                If Not IsNothing(ACSRM1RowForEachRow) Then
                    .投入重量 = ACSRM1RowForEachRow.Item("RM110") + ACSRM1RowForEachRow.Item("RM112") + ACSRM1RowForEachRow.Item("RM113")
                    If Not (IsDBNull(EachRow.Item("RM206")) OrElse EachRow.Item("RM206") = 0) Then
                        .產出率 = Format(Val(EachRow.Item("RM206") / Val(.投入重量)), "0.0%")
                    End If
                End If
            End With
            '依 批次/鋼種/表面/厚度/銷售別/料別 小計
            If Not IsNothing(PreDataRow) Then
                With PreDataRow
                    Select Case True
                        Case .批次 = AddItem.批次 AndAlso .鋼種 = AddItem.鋼種 AndAlso .表面 = AddItem.表面 AndAlso .厚度 = AddItem.厚度 AndAlso .銷售別 = AddItem.銷售別 AndAlso .料別 <> AddItem.料別
                        Case .批次 = AddItem.批次 AndAlso .鋼種 = AddItem.鋼種 AndAlso .表面 = AddItem.表面 AndAlso .厚度 = AddItem.厚度 AndAlso .銷售別 <> AddItem.銷售別
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別 & "," & .料別)
                        Case .批次 = AddItem.批次 AndAlso .鋼種 = AddItem.鋼種 AndAlso .表面 = AddItem.表面 AndAlso .厚度 <> AddItem.厚度
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別 & "," & .料別)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別)
                        Case .批次 = AddItem.批次 AndAlso .鋼種 = AddItem.鋼種 AndAlso .表面 <> AddItem.表面
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別 & "," & .料別)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度)
                        Case .批次 = AddItem.批次 AndAlso .鋼種 <> AddItem.鋼種
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別 & "," & .料別)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面)
                        Case .批次 <> AddItem.批次
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別 & "," & .料別)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面)
                            Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種)
                    End Select
                End With
            End If
            ReturnValue.Rows.Add(AddItem)
            PreDataRow = AddItem
        Next
        If Not IsNothing(PreDataRow) Then
            With PreDataRow
                Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別 & "," & .料別)
                Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度 & "," & .銷售別)
                Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面 & "," & .厚度)
                Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種 & "," & .表面)
                Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次 & "," & .鋼種)
                Call AddSubRow(QryResult, QryResult1, ReturnValue, .批次)
            End With
        End If
        Return ReturnValue
    End Function

    Private Sub AddSubRow(ByVal SourceData As DataTable, ByVal SourceData1 As DataTable, ByVal AddToTable As AccountDataSet.CoilCostSearchDataTable, ByVal SubSumKeys As String)
        Dim Keys As List(Of String) = SubSumKeys.Split(",").ToList
        Dim SubDatas As List(Of DataRow) = (From A In SourceData.Rows Select CType(A, DataRow)).ToList
        Dim KeyCount As Integer = 1
        Dim AddItem As AccountDataSet.CoilCostSearchRow = AddToTable.NewRow
        With AddItem
            .批次 = "加總"
            .鋼種 = "加總"
            .表面 = "加總"
            .厚度 = "加總"
            .銷售別 = "加總"
            .料別 = "加總"
            For Each EachKey As String In Keys
                Select Case True
                    Case KeyCount = 1 AndAlso Keys.Count > KeyCount
                        SubDatas = (From A In SubDatas Select A Where A.Item("BLA11") = EachKey).ToList
                        .批次 = EachKey
                    Case KeyCount = 2 AndAlso Keys.Count > KeyCount
                        SubDatas = (From A In SubDatas Select A Where A.Item("RM204") = EachKey).ToList
                        .鋼種 = EachKey
                    Case KeyCount = 3 AndAlso Keys.Count > KeyCount
                        SubDatas = (From A In SubDatas Select A Where A.Item("RM205") = EachKey).ToList
                        .表面 = EachKey
                    Case KeyCount = 4 AndAlso Keys.Count > KeyCount
                        SubDatas = (From A In SubDatas Select A Where A.Item("RM214") = EachKey).ToList
                        .厚度 = EachKey
                    Case KeyCount = 5 AndAlso Keys.Count > KeyCount
                        SubDatas = (From A In SubDatas Select A Where A.Item("RM218") = EachKey).ToList
                        .銷售別 = EachKey
                    Case KeyCount = 6 AndAlso Keys.Count > KeyCount
                        SubDatas = (From A In SubDatas Select A Where A.Item("RM215") = EachKey).ToList
                        .料別 = EachKey
                End Select
                KeyCount += 1
            Next
            If SubDatas.Count = 0 Then
                Exit Sub
            End If
            .鋼捲 = "****"
            .斷捲 = "****"
            .日期 = "****"
            .繳庫線別 = "****"
            .重量 = (From A In SubDatas Select Val(A.Item("RM206"))).Sum
            .軋鋼變動原料 = (From A In SubDatas Select Val(A.Item("RM207"))).Sum
            .軋鋼變動燃料 = (From A In SubDatas Select Val(A.Item("RM208"))).Sum
            .軋鋼變動物料 = (From A In SubDatas Select Val(A.Item("RM209"))).Sum
            .軋鋼變動人工 = (From A In SubDatas Select Val(A.Item("RM210"))).Sum
            .軋鋼變動間接費用 = (From A In SubDatas Select Val(A.Item("RM211"))).Sum
            .軋鋼固定人工 = (From A In SubDatas Select Val(A.Item("RM210A"))).Sum
            .軋鋼固定間接費用 = (From A In SubDatas Select Val(A.Item("RM211A"))).Sum
            .軋鋼磅差 = (From A In SubDatas Select Val(A.Item("RM212"))).Sum
            .軋鋼繳庫單號 = (From A In SubDatas Select Val(A.Item("RM213"))).Sum
            .煉鋼變動原料 = (From A In SubDatas Select Val(A.Item("RM221"))).Sum
            .煉鋼變動燃料 = (From A In SubDatas Select Val(A.Item("RM222"))).Sum
            .煉鋼變動物料 = (From A In SubDatas Select Val(A.Item("RM223"))).Sum
            .煉鋼變動人工 = (From A In SubDatas Select Val(A.Item("RM214"))).Sum
            .煉鋼變動間接費用 = (From A In SubDatas Select Val(A.Item("RM215"))).Sum
            .煉鋼固定人工 = (From A In SubDatas Select Val(A.Item("RM224A"))).Sum
            .煉鋼固定間接費用 = (From A In SubDatas Select Val(A.Item("RM225A"))).Sum
            .軋壞損耗 = (From A In SubDatas Select Val(A.Item("RM226"))).Sum
            .代軋費 = (From A In SubDatas Select Val(A.Item("RM227"))).Sum
            .訂單年月 = "****"
            .客戶名稱 = "****"
            .銷售金額 = (From A In SubDatas Where Not IsDBNull(A.Item("BOL27")) Select Val(A.Item("BOL27"))).Sum

            Dim InputWeight As Double = 0
            Dim NoFindACSRM1RowInputWeight As Double = 0
            For Each EachRow In SubDatas
                Dim ACSRM1RowForEachRow As DataRow = (From A In SourceData1 Where A.Item("RM100") = EachRow.Item("RM200") And A.Item("RM101") = EachRow.Item("RM201") And A.Item("RM107") = EachRow.Item("BLA11") And A.Item("RM105") <= EachRow.Item("RM202") & EachRow.Item("RM202A") Select A Order By A.Item("RM105") Descending).FirstOrDefault
                If Not IsNothing(ACSRM1RowForEachRow) Then
                    InputWeight += Val(ACSRM1RowForEachRow.Item("RM110")) + Val(ACSRM1RowForEachRow.Item("RM112")) + Val(ACSRM1RowForEachRow.Item("RM113"))
                Else
                    InputWeight += Val(EachRow.Item("RM206"))
                    NoFindACSRM1RowInputWeight += Val(EachRow.Item("RM206"))
                End If
            Next
            .投入重量 = InputWeight - NoFindACSRM1RowInputWeight
            .產出率 = Format((From A In SubDatas Select Val(A.Item("RM206"))).Sum / InputWeight, "0.0%")
        End With

        AddToTable.Rows.Add(AddItem)
    End Sub

#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim WhereString As String = Nothing
        Dim ReturnValue As String = Nothing
        Dim ReturnValueHistory As String = Nothing
        Dim SubReturnValue As String = Nothing
        Dim SubReturnValueHistory1 As String = Nothing
        Dim SubReturnValueHistory2 As String = Nothing

        If Not String.IsNullOrEmpty(tbBatch.Text) AndAlso tbBatch.Text.Trim.Length > 0 Then
            WhereString &= " AND B.BLA11 IN ('" & tbBatch.Text.Trim.Replace(",", "','") & "') "
        End If
        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            WhereString &= " AND A.RM204 IN ('" & tbSteelKind.Text.Trim.Replace(",", "','") & "') "
        End If
        If Not String.IsNullOrEmpty(tbFace.Text) AndAlso tbFace.Text.Trim.Length > 0 Then
            WhereString &= " AND A.RM205 IN ('" & tbFace.Text.Trim.Replace(",", "','") & "') "
        End If
        If tbThick1.Text.Trim <> "-1" OrElse tbThick2.Text.Trim <> "999" Then
            WhereString &= " AND A.RM214>= " & tbThick1.Text.Trim & " AND A.RM214<=" & tbThick2.Text.Trim
        End If
        If rblSellKind.SelectedValue <> "ALL" Then
            WhereString &= " AND A.RM218='" & rblSellKind.SelectedValue & "'"
        End If
        If Not String.IsNullOrEmpty(tbMaterialKind.Text) AndAlso tbMaterialKind.Text.Trim.Length > 0 Then
            WhereString &= " AND A.RM215 IN ('" & tbMaterialKind.Text.Trim.Replace(",", "','") & "') "
        End If

        If cbYear.Checked Then
            WhereString &= " AND A.RM202>='" & Me.tbStartDate.Text.Replace("\", Nothing).Replace("/", Nothing).Trim & "' AND A.RM202<='" & Me.tbEndDate.Text.Replace("\", Nothing).Replace("/", Nothing).Trim & "' "
        End If

        ReturnValueHistory = "SELECT A.*,B.BLA11,D.BOL27,E.CUA11,C.CIA04 FROM @#ACS300LB.ACSRM2PF.HISTORY A  JOIN @#PPS100LB.PPSBLAPF B ON A.RM200=B.BLA09  JOIN @#PPS100LB.PPSCIAPF C ON A.RM200=C.CIA02 AND A.RM201=C.CIA03 AND INTEGER(A.RM202 || A.RM202A) = C.CIA58 LEFT OUTER JOIN @#SLS300LB.SL2BOLPF D ON C.CIA62=D.BOL02  AND C.CIA02=D.BOL16 AND C.CIA03=D.BOL17  LEFT OUTER JOIN @#SLS300LB.SL2CUAPF E ON LEFT(C.CIA04,3)=E.CUA01 WHERE 1=1 " & WhereString
        ReturnValue = "SELECT A.*,B.BLA11,D.BOL27,E.CUA11,C.CIA04 FROM @#ACS300LB.ACSRM2PF A JOIN @#PPS100LB.PPSBLAPF B ON A.RM200=B.BLA09  JOIN @#PPS100LB.PPSCIAPF C ON A.RM200=C.CIA02 AND A.RM201=C.CIA03 AND INTEGER(A.RM202 || A.RM202A) = C.CIA58 LEFT OUTER JOIN @#SLS300LB.SL2BOLPF D ON C.CIA62=D.BOL02 AND C.CIA02=D.BOL16 AND C.CIA03=D.BOL17  LEFT OUTER JOIN @#SLS300LB.SL2CUAPF E ON LEFT(C.CIA04,3)=E.CUA01 WHERE 1=1 " & WhereString
        ReturnValue = ReturnValue & " UNION (" & ReturnValueHistory & ")"

        SubReturnValueHistory1 = "Select H1.RM100,H1.RM101,H1.RM105,H1.RM107,H1.RM110,H1.RM112,H1.RM113 FROM @#ACS300LB.ACSRM1PF.History H1 WHERE H1.RM102=0 AND H1.RM106='P3' AND (H1.RM100 || H1.RM101 || H1.RM107)  IN (" & ReturnValue.Replace("A.*,B.BLA11,D.BOL27,E.CUA11,C.CIA04", "A.RM200 || A.RM201 || B.BLA11") & ") "
        SubReturnValueHistory2 = "Select H2.RM100,H2.RM101,H2.RM105,H2.RM107,H2.RM110,H2.RM112,H2.RM113 FROM @#ACS300LB.ACSRM1PF.Temp04 H2 WHERE H2.RM102=0 AND H2.RM106='P3' AND (H2.RM100 || H2.RM101 || H2.RM107)  IN (" & ReturnValue.Replace("A.*,B.BLA11,D.BOL27,E.CUA11,C.CIA04", "A.RM200 || A.RM201 || B.BLA11") & ") "
        SubReturnValue = "Select SUBA.RM100,SUBA.RM101,SUBA.RM105,SUBA.RM107,SUBA.RM110,SUBA.RM112,SUBA.RM113 FROM @#ACS300LB.ACSRM1PF SUBA WHERE SUBA.RM102=0 AND SUBA.RM106='P3' AND (SUBA.RM100 || SUBA.RM101 || SUBA.RM107)  IN (" & ReturnValue.Replace("A.*,B.BLA11,D.BOL27,E.CUA11,C.CIA04", "A.RM200 || A.RM201 ||B.BLA11") & ") "
        SubReturnValue &= " UNION (" & SubReturnValueHistory1 & ")" & " UNION (" & SubReturnValueHistory2 & ")"


        If DropDownList1.SelectedIndex = 0 Then
            Me.hfQryString.Value = ReturnValue & " Order by BLA11,RM204,RM205,RM214,RM218,RM215"
            Me.hfSubQryString.Value = SubReturnValue
        Else
            Me.hfQryString1.Value = ReturnValue & " Order by BLA11,RM204,RM205,RM214,RM218,RM215"
            Me.hfSubQryString.Value = SubReturnValue
        End If
    End Sub

#End Region


    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy") - 1911 & "/" & Format(Now, "MM")
            tbEndDate.Text = tbStartDate.Text
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If DropDownList1.SelectedIndex = 0 Then
            Me.MultiView1.SetActiveView(Me.View1)
            Me.MakQryStringToControl()
            GridView1.DataBind()
        Else
            Me.MultiView1.SetActiveView(Me.View2)
            Me.MakQryStringToControl()
            GridView2.DataBind()
        End If

    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Select Case DropDownList1.SelectedIndex
            Case 0
                Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value, Me.hfSubQryString.Value), "鋼捲成本明細" & Format(Now, "mmss") & ".xls")
                ExcelConvert.DownloadEXCELFile(Me.Response)
            Case 1
                Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search1(Me.hfQryString1.Value, Me.hfSubQryString.Value), "鋼捲成本彙總" & Format(Now, "mmss") & ".xls")
                ExcelConvert.DownloadEXCELFile(Me.Response)
        End Select
    End Sub
End Class