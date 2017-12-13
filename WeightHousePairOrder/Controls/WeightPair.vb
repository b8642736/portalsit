Public Class WeightPair

    Dim IsInProgramTestMode As Boolean = False  '是否在測試模式

#Region "查詢過磅記錄 函式:SearchWeightRecord"
    Dim ODBCConnectString = "Dsn=WeighBridge;uid=;pwd=;;QueryTimeOut=0;"
    ''' <summary>
    ''' 查詢過磅記錄
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SearchWeightRecord(Optional WillSetDataHaveChanged As Boolean = False)
        Dim ODBCConn As New Odbc.OdbcConnection(ODBCConnectString)
        Dim Qry As String
        If IsInProgramTestMode Then
            Qry = "Select * from tbl_Weightbridge_form Where WF_complete_time > WF_start_time and WF_complete_time >= #" & Format(Now.AddDays(-180), "yyyy/MM/dd HH:mm:ss") & "# and wf_form_type='進貨' order by WF_complete_time Desc"
        Else
            Qry = "Select * from tbl_Weightbridge_form Where WF_complete_time > WF_start_time and WF_complete_time >= #" & Format(Now.AddDays(-3), "yyyy/MM/dd HH:mm:ss") & "# and wf_form_type='進貨'  order by WF_complete_time Desc"
        End If

        Dim WeightContractComparesQry As String = "Select * from WeightContractComares Where WF_No in (" & Qry.Replace("*", "WF_No").Replace("order by WF_complete_time Desc", Nothing) & ")"
        Dim WeightContractComparesResult As New DataTable

        Try
            Me.ShowMessage = Nothing
            Dim Cmd As New Odbc.OdbcCommand(Qry, ODBCConn)
            Dim ODBCAdapter As New Odbc.OdbcDataAdapter(Cmd)
            Dim SearchResult As New DataTable
            ODBCAdapter.Fill(SearchResult)
            Static PreSearchResult As DataTable = Nothing
            Dim IsDataHaveChanged As Boolean = False

            Cmd = New Odbc.OdbcCommand(WeightContractComparesQry, ODBCConn)
            ODBCAdapter = New Odbc.OdbcDataAdapter(Cmd)
            ODBCAdapter.Fill(WeightContractComparesResult)

            Select Case True
                Case WillSetDataHaveChanged
                    IsDataHaveChanged = True
                Case IsNothing(PreSearchResult)
                    IsDataHaveChanged = True
                Case PreSearchResult.Rows.Count <> SearchResult.Rows.Count
                    IsDataHaveChanged = True
                Case Else
                    Dim RowCount As Integer = 0
                    For Each EachItem As DataRow In SearchResult.Rows
                        For EachColumnCount As Integer = 0 To SearchResult.Columns.Count - 1
                            Select Case True
                                Case IsDBNull(EachItem.Item(EachColumnCount)) <> IsDBNull(PreSearchResult.Rows(RowCount).Item(EachColumnCount))
                                    IsDataHaveChanged = True : Exit For
                                Case IsDBNull(EachItem.Item(EachColumnCount))
                                Case EachItem.Item(EachColumnCount) <> PreSearchResult.Rows(RowCount).Item(EachColumnCount)
                                    IsDataHaveChanged = True : Exit For
                            End Select
                            'If EachItem.Item(EachColumnCount) <> SearchResult.Rows(RowCount).Item(EachColumnCount) Then
                            '    IsDataHaveChanged = True : Exit For
                            'End If
                        Next
                        If IsDataHaveChanged Then
                            Exit For
                        End If
                        RowCount += 1
                    Next
            End Select

            If IsDataHaveChanged Then
                Dim SetDatas As List(Of tbl_Weightbridge_form) = tbl_Weightbridge_form.CreateDataByDataTable(SearchResult)
                For Each EachItem As tbl_Weightbridge_form In SetDatas
                    EachItem.IsCompareTOContractDetail = Not IsNothing((From A In WeightContractComparesResult Where Val(A.Item("WF_No")) = EachItem.WF_No Select A).FirstOrDefault)
                Next
                Me.bsWeightDataSource.DataSource = SetDatas
                Me.bsWeightDataSource.ResetBindings(False)
                PreSearchResult = SearchResult
            End If
        Catch ex As Exception
            Me.ShowMessage = ex.ToString
        Finally
            If ODBCConn.State <> ConnectionState.Closed Then
                ODBCConn.Close()
            End If
        End Try

    End Sub
#End Region
#Region "查詢合約 函式:SearchContract"
    ''' <summary>
    ''' 查詢合約
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SearchContract()
        Dim Qry As String = "Select  A.* , B.* from @#MTS100LB.WARB02PF A Left JOIN @#MTS100LB.WARB03PF B ON A.WRB201=B.WRB303 AND A.WRB202=B.WRB302 AND A.WRB204=B.WRB301 WHERE 1=1 "
        If Not String.IsNullOrEmpty(tbContractNumber.Text) AndAlso tbContractNumber.Text.Trim.Length > 0 Then
            Qry &= " AND A.WRB201 = '" & tbContractNumber.Text.Trim & "' "
        End If

        If Not String.IsNullOrEmpty(tbProductNumber.Text) AndAlso tbProductNumber.Text.Trim.Length > 0 Then
            Qry &= " AND A.WRB202= '" & tbProductNumber.Text.Trim & "' "
        End If
        Qry &= " Order by A.WRB204 Desc, A.WRB201 Desc "
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, Qry)
        Dim Result As DataTable = Adapter.SelectQuery
        Dim WARB03PFResult As New List(Of CompanyORMDB.MTS100LB.WARB03PF)
        For Each EachItem As DataRow In Result.Rows
            If Not IsDBNull(EachItem.Item("WRB302")) Then
                Dim AddItem As CompanyORMDB.MTS100LB.WARB03PF = New CompanyORMDB.MTS100LB.WARB03PF
                AddItem.CDBSetDataRowValueToObject(EachItem)
                WARB03PFResult.Add(AddItem)
            End If
        Next



        Dim SearchResult As New List(Of CompanyORMDB.MTS100LB.WARB02PF)
        For Each EachItem As CompanyORMDB.MTS100LB.WARB02PF In CompanyORMDB.MTS100LB.WARB02PF.CDBSetDataTableToObjects(Of CompanyORMDB.MTS100LB.WARB02PF)(Result)
            If IsNothing((From A In SearchResult Where A.WRB201 = EachItem.WRB201 And A.WRB202 = EachItem.WRB202 And A.WRB204 = EachItem.WRB204 Select A).FirstOrDefault) Then
                EachItem.SQLQueryAdapterByThisObject = Adapter
                SearchResult.Add(EachItem)
            End If
        Next
        For Each EachItem As CompanyORMDB.MTS100LB.WARB03PF In WARB03PFResult
            EachItem.SQLQueryAdapterByThisObject = Adapter
        Next
        For Each EachItem As CompanyORMDB.MTS100LB.WARB02PF In SearchResult
            With EachItem
                Dim AboutWARB03Datas As List(Of CompanyORMDB.MTS100LB.WARB03PF) = (From A In WARB03PFResult Where A.WRB301 = .WRB204 And A.WRB302.Trim = .WRB202.Trim And A.WRB303.Trim = .WRB201.Trim Select A).ToList
                EachItem.About_WARB03PFs = AboutWARB03Datas
            End With
        Next
        Me.bsContractDataSource.DataSource = SearchResult
    End Sub
#End Region
#Region "查詢合約過磅明細 函式:SearchContractDetail"
    ''' <summary>
    ''' 查詢合約過磅明細
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SearchContractDetail()
        Dim SelectContractRecord As CompanyORMDB.MTS100LB.WARB02PF = Nothing
        AllContractDetailDatas.Clear()
        If dgvContractDisplay.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If dgvContractDisplay.SelectedRows.Count > 0 Then
            SelectContractRecord = dgvContractDisplay.SelectedRows(0).DataBoundItem
        End If
        Dim Qry As String = "Select * from @#MTS100LB.WARB03PF Where WRB301=" & SelectContractRecord.WRB204 & " AND WRB302='" & SelectContractRecord.WRB202 & "' "
        AllContractDetailDatas = CompanyORMDB.MTS100LB.WARB03PF.CDBSelect(Of CompanyORMDB.MTS100LB.WARB03PF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Sub
#End Region
#Region "所有過磅明細資料 屬性:AllContractDetailDatas"
    Private _AllContractDetailDatas As New List(Of CompanyORMDB.MTS100LB.WARB03PF)
    ''' <summary>
    ''' 所有過磅明細資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AllContractDetailDatas As List(Of CompanyORMDB.MTS100LB.WARB03PF)
        Get
            Return _AllContractDetailDatas
        End Get
        Set(value As List(Of CompanyORMDB.MTS100LB.WARB03PF))
            _AllContractDetailDatas = value
        End Set
    End Property
#End Region
#Region "重整按鈕Enable 屬性:RefreshEnableButton"
    ''' <summary>
    ''' 重整按鈕Enable
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshEnableButton()
        btnCompare.Enabled = False
        btnDeleteCompare.Enabled = False
        If dgvWeightDisplay.SelectedRows.Count > 0 AndAlso dgvContractDisplay.SelectedRows.Count > 0 Then
            If CType(dgvWeightDisplay.SelectedRows(0).DataBoundItem, tbl_Weightbridge_form).IsCompareTOContractDetail = False Then
                btnCompare.Enabled = True
            End If
        End If
        If dgvProductsDisplay.SelectedRows.Count > 0 AndAlso (IsNothing(CType(dgvProductsDisplay.SelectedRows(0).DataBoundItem, CompanyORMDB.MTS100LB.WARB03PF).WRB316) OrElse CType(dgvProductsDisplay.SelectedRows(0).DataBoundItem, CompanyORMDB.MTS100LB.WARB03PF).WRB316.Trim = "") Then
            btnDeleteCompare.Enabled = True
        End If

    End Sub
#End Region

#Region "新增過磅進料資料 函式:InsertContractDetailData"
    ''' <summary>
    ''' 新增過磅進料資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InsertContractDetailData()
        Dim SelectWeightRecord As tbl_Weightbridge_form = Nothing
        Dim SelectContractRecord As CompanyORMDB.MTS100LB.WARB02PF = Nothing
        If dgvWeightDisplay.SelectedRows.Count > 0 Then
            SelectWeightRecord = dgvWeightDisplay.SelectedRows(0).DataBoundItem
        End If
        If dgvContractDisplay.SelectedRows.Count > 0 Then
            SelectContractRecord = dgvContractDisplay.SelectedRows(0).DataBoundItem
        End If
        If IsNothing(SelectWeightRecord) OrElse IsNothing(SelectContractRecord) Then
            Exit Sub
        End If

        '計算跨單序號
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim Qry As String = "Select count(*) from @#MTS100LB.WARB03PF Where WRB301=" & SelectContractRecord.WRB204 & " AND WRB302='" & SelectContractRecord.WRB202 & "' AND WRB304=" & SelectWeightRecord.WF_form_No
        Dim OverBillNumber As Integer = Val(Adapter.SelectQuery(Qry).Rows(0).Item(0)) + 1


        Dim InsertItem As New CompanyORMDB.MTS100LB.WARB03PF
        With InsertItem
            .WRB301 = SelectContractRecord.WRB204
            .WRB302 = SelectContractRecord.WRB202
            .WRB303 = SelectContractRecord.WRB201
            .WRB304 = SelectWeightRecord.WF_form_No
            .WRB305 = OverBillNumber
            .WRB306 = SelectWeightRecord.WF_Dead_Weight / 1000
            If Not String.IsNullOrEmpty(tbDopantWeight.Text) OrElse tbDopantWeight.Text.Trim.Length > 0 Then
                .WRB307 = Val(tbDopantWeight.Text)
            End If
            Dim SetStarStime As Long = (Val(Format(SelectWeightRecord.WF_start_time, "yyyy")) - 1911 - 100) * 10000000000 + Val(Format(SelectWeightRecord.WF_start_time, "MMdd")) * 1000000 + Val(Format(SelectWeightRecord.WF_start_time, "HHmmss"))
            .WRB3TM = SetStarStime

            .SQLQueryAdapterByThisObject = Adapter
            Try
                If .CDBInsert > 0 Then
                    AllContractDetailDatas.Add(InsertItem)
                    AddWeightCompareContractToAccess(SelectWeightRecord, InsertItem)
                End If

            Catch ex As Exception
                Me.ShowMessage = ex.ToString
            End Try
        End With
    End Sub

    Private Sub AddWeightCompareContractToAccess(ByVal WeightData As tbl_Weightbridge_form, ByVal Detail As CompanyORMDB.MTS100LB.WARB03PF)
        Dim ODBCConn As New Odbc.OdbcConnection(ODBCConnectString)
        Dim Qry = "Select * from WeightContractComares Where WRB301=" & Detail.WRB301 & " AND WRB302='" & Detail.WRB302.Trim & "' AND WRB303='" & Detail.WRB303.Trim & "' AND WRB304=" & Detail.WRB304 & " AND WRB305=" & Detail.WRB305
        Dim Cmd As New Odbc.OdbcCommand(Qry, ODBCConn)
        Dim ODBCAdapter As New Odbc.OdbcDataAdapter(Cmd)
        Dim SearchResult As New DataTable
        ODBCAdapter.Fill(SearchResult)
        If SearchResult.Rows.Count = 0 Then
            'DataInsertTime
            Dim InsertQry As String = "Insert into WeightContractComares (DataInsertTime,WF_No,WF_start_time,WRB301,WRB302,WRB303,WRB304,WRB305) Values ("
            InsertQry &= "#" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "#"
            InsertQry &= " ," & WeightData.WF_No
            InsertQry &= ",#" & Format(WeightData.WF_start_time, "yyyy/MM/dd HH:mm:ss") & "#"
            InsertQry &= "," & Detail.WRB301
            InsertQry &= ",'" & Detail.WRB302 & "'"
            InsertQry &= ",'" & Detail.WRB303 & "'"
            InsertQry &= "," & Detail.WRB304
            InsertQry &= "," & Detail.WRB305 & ")"
            If ODBCConn.State <> ConnectionState.Open Then
                ODBCConn.Open()
            End If
            Cmd = New Odbc.OdbcCommand(InsertQry, ODBCConn)
            Cmd.ExecuteNonQuery()
        End If


    End Sub
#End Region
#Region "刪除過磅進料資料 函式:DeleteWARB03Data"
    ''' <summary>
    ''' 刪除過磅進料資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteContractDetailData()
        Dim SelectContractDetailDataRecord As CompanyORMDB.MTS100LB.WARB03PF = Nothing
        If dgvProductsDisplay.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        SelectContractDetailDataRecord = dgvProductsDisplay.SelectedRows(0).DataBoundItem
        If SelectContractDetailDataRecord.CDBDelete Then
            AllContractDetailDatas.Remove(SelectContractDetailDataRecord)
            Dim DeleteQry As String = "Delete From WeightContractComares Where WRB301=" & SelectContractDetailDataRecord.WRB301 & " AND WRB302='" & SelectContractDetailDataRecord.WRB302.Trim & "' AND WRB303='" & SelectContractDetailDataRecord.WRB303.Trim & "' AND WRB304=" & SelectContractDetailDataRecord.WRB304 & " AND WRB305=" & SelectContractDetailDataRecord.WRB305
            Dim ODBCConn As Odbc.OdbcConnection = Nothing
            Try
                ODBCConn = New Odbc.OdbcConnection(ODBCConnectString)
                Dim Cmd As New Odbc.OdbcCommand(DeleteQry, ODBCConn)
                ODBCConn.Open()
                Cmd.ExecuteNonQuery()

            Catch ex As Exception
            Finally
                If Not IsNothing(ODBCConn) AndAlso ODBCConn.State = ConnectionState.Open Then
                    ODBCConn.Close()
                End If
            End Try

        End If
        bsInProducts.ResetBindings(False)
    End Sub
#End Region

#Region "建立磅單配對記錄資料表式 函式:CreateWightCompareContractDataTable"
    Private Sub CreateWightCompareContractDataTable()
        Dim Cmd As Odbc.OdbcCommand = Nothing
        Dim ODBCConn As Odbc.OdbcConnection = Nothing
        Try
            'Dim FindTableExsist As String = "select count(*) from msysobjects where type=1 and name='WeightContractComares'"
            ODBCConn = New Odbc.OdbcConnection(ODBCConnectString)
            'Cmd = New Odbc.OdbcCommand(FindTableExsist, ODBCConn)
            'Dim ODBCAdapter As New Odbc.OdbcDataAdapter(Cmd)
            'Dim SearchResult As New DataTable
            'ODBCAdapter.Fill(SearchResult)
            'If Val(SearchResult.Rows(0).Item(0)) = 0 Then
            '    Dim CreateTableString = "CREATE TABLE WeightContractComares (WF_No LONG  CONSTRAINT WF_No1 PRIMARY KEY ,WF_start_time DATETIME, WRB301 LONG, WRB302 TEXT(12), WRB303 TEXT(15), WRB304 INTEGER, WRB305 INTEGER)"
            '    Cmd = New Odbc.OdbcCommand(CreateTableString, ODBCConn)
            '    Cmd.ExecuteNonQuery()
            'End If

            'Dim CreateTableString = "CREATE TABLE WeightContractComares (WF_No LONG  CONSTRAINT WF_No1 PRIMARY KEY ,WF_start_time DATETIME, WRB301 LONG, WRB302 TEXT(12), WRB303 TEXT(15), WRB304 INTEGER, WRB305 INTEGER)"
            Dim CreateTableString = "CREATE TABLE WeightContractComares (DataInsertTime DATETIME,WF_No LONG ,WF_start_time DATETIME, WRB301 LONG, WRB302 TEXT(12), WRB303 TEXT(15), WRB304 INTEGER, WRB305 INTEGER)"
            ODBCConn.Open()
            Cmd = New Odbc.OdbcCommand(CreateTableString, ODBCConn)
            Cmd.ExecuteNonQuery()

        Catch ex As Exception
            'MsgBox(ex.ToString)
        Finally
            ODBCConn.Close()
        End Try
    End Sub
#End Region

#Region "顯示訊息 屬性:ShowMessage"
    ''' <summary>
    ''' 顯示訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShowMessage As String
        Get
            Return tsslMessage.Text
        End Get
        Set(value As String)
            tsslMessage.Text = value
        End Set
    End Property

#End Region

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        InsertContractDetailData()
        bsInProducts.DataSource = AllContractDetailDatas
        bsInProducts.ResetBindings(False)
        SearchWeightRecord(True)
        RefreshEnableButton()
        dgvWeightDisplay.Refresh()
    End Sub

    Private Sub btnDeleteCompare_Click(sender As Object, e As EventArgs) Handles btnDeleteCompare.Click
        If MsgBox("是否確認刪除?", vbYesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        DeleteContractDetailData()
        bsInProducts.DataSource = AllContractDetailDatas
        bsInProducts.ResetBindings(False)
        SearchWeightRecord(True)
        RefreshEnableButton()
        bsContractDataSource.ResetBindings(False)
    End Sub

    Private Sub btnReSearch_Click(sender As Object, e As EventArgs) Handles btnReSearch.Click
        SearchWeightRecord()
        RefreshEnableButton()
    End Sub

    Private Sub btnSearchContract_Click(sender As Object, e As EventArgs) Handles btnSearchContract.Click
        SearchContract()
        RefreshEnableButton()
    End Sub

    Private Sub dgvWeightDisplay_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvWeightDisplay.CellMouseUp
        RefreshEnableButton()
    End Sub

    Private Sub WeightPair_Load(sender As Object, e As EventArgs) Handles Me.Load
        CreateWightCompareContractDataTable()
        SearchWeightRecord()
        RefreshEnableButton()
    End Sub

    Private Sub dgvContractDisplay_SelectionChanged(sender As Object, e As EventArgs) Handles dgvContractDisplay.SelectionChanged
        SearchContractDetail()
        bsInProducts.DataSource = AllContractDetailDatas
        bsInProducts.ResetBindings(False)
        RefreshEnableButton()
    End Sub

    Private Sub dgvProductsDisplay_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductsDisplay.SelectionChanged
        RefreshEnableButton()
    End Sub

    Private Sub tRefreshWeightData_Tick(sender As Object, e As EventArgs) Handles tRefreshWeightData.Tick
        SearchWeightRecord()
    End Sub

End Class
