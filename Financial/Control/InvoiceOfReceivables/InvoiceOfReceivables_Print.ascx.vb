Public Class InvoiceOfReceivables_Print
    Inherits System.Web.UI.UserControl


    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As InvoiceOfReceivables_Model.主畫面_Enum, _
                         ByVal from單據號碼1 As String, ByVal from單據號碼2 As String)

    Public Sub P_reFresh子物件(ByVal from單據號碼1 As String, ByVal from單據號碼2 As String)

        Me.tbInvoice_Number.Text = from單據號碼1 & from單據號碼2
        btnPrint_Click(btnPrint, Nothing)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With ReportViewer1
            .ShowExportControls = False
            '    .LocalReport.Refresh()
        End With

        'Me.tbInvoice_Number.BackColor = C_RGBColorLock
        'Me.tbInvoice_Number.Enabled = False
        'Me.btnPrint.Enabled = False

        Me.tbInvoice_Number.Visible = False
        Me.btnPrint.Visible = False
        Me.Label1.Visible = False
    End Sub


#Region "ViewState：Employee"

    Private Property WP_DataTable_Employee As DataTable
        Get
            If ViewState(C_DataTableEmployee) Is Nothing Then
                ViewState(C_DataTableEmployee) = FD_Data_Employee_Now()
            End If
            Return ViewState(C_DataTableEmployee)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableEmployee) = value
        End Set

    End Property


#End Region

#Region "ViewState：Unit"

    Private Property WP_DataTable_Unit As DataTable
        Get
            If ViewState(C_DataTableUnit) Is Nothing Then
                ViewState(C_DataTableUnit) = FD_Data_Department()
            End If
            Return ViewState(C_DataTableUnit)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableUnit) = value
        End Set

    End Property


#End Region



#Region "讀取單據資料：FT_LoadDataByInvoice_Number"
    Private Function FT_LoadDataByInvoice_Number(ByVal from單據號碼1 As String, ByVal from單據號碼2 As String) As FinancialDataSet.InvoiceOfReceivablesDataTable
        Dim paramTable As New FinancialDataSet.InvoiceOfReceivablesDataTable

        CustomValidator1.ErrorMessage = ""

        Try

            Dim paramRow As FinancialDataSet.InvoiceOfReceivablesRow
            paramRow = paramTable.NewRow

            '讀取單據資料
            '------------------------------------------------------------------------------------------------------------
            Dim crudList_Master As List(Of CompanyORMDB.COME.KIND01PF) = Nothing
            Dim crudList_Detail As List(Of CompanyORMDB.COME.KIND02PF) = Nothing
            Dim crudMaster As CompanyORMDB.COME.KIND01PF = Nothing
            Dim crudDetail As CompanyORMDB.COME.KIND02PF = Nothing

            Dim W_SQL As New StringBuilder

            Dim playMethod_Msg As String
            Dim playMethod_Select As String = "☑"
            Dim playMethod_UnSelect As String = "□"
            Dim playMethod_Space As String = Space(2)
            Dim playMethod_UnderLine As String = "".PadRight(10, "_")

            Dim column_Space As String = Space(1)
            '------------------------------------------------------------------------------------------------------------

            'Master
            '-------------------------------------------------------------------------------------
            W_SQL.Append("SELECT  * " & vbNewLine)
            W_SQL.Append("FROM @#COME.KIND01PF " & vbNewLine)
            W_SQL.Append("WHERE 1=1  AND KD101='" & from單據號碼1 & "' " & vbNewLine)
            W_SQL.Append("    AND KD102 =" & IIf(IsNumeric(from單據號碼2), from單據號碼2, 0) & " " & vbNewLine)

            crudList_Master = COME.KIND01PF.CDBSelect(Of COME.KIND01PF)(W_SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            If crudList_Master.Count > 0 Then
                crudMaster = crudList_Master.Item(0)

                With paramRow
                    .單據號碼 = crudMaster.KD101 & crudMaster.KD102
                    .輸入職編 = crudMaster.KD103 & Space(1) & showEmployeeName(WP_DataTable_Employee, crudMaster.KD103)
                    .輸入部門 = crudMaster.KD104 & Space(1) & showUnitName(WP_DataTable_Unit, crudMaster.KD104)
                    .輸入日期時間 = InvoiceOfReceivables_Model.showFormatFor_DateTime(False, crudMaster.KD105, crudMaster.KD106)
                    .輸入日期 = InvoiceOfReceivables_Model.showFormatFor_DateTime(False, crudMaster.KD105, "")
                    .收款職編 = crudMaster.KD107 & Space(1) & showEmployeeName(WP_DataTable_Employee, crudMaster.KD107)
                    .收款部門 = crudMaster.KD108 & Space(1) & showUnitName(WP_DataTable_Unit, crudMaster.KD108)
                    .收款日期時間 = InvoiceOfReceivables_Model.showFormatFor_DateTime(False, crudMaster.KD109, crudMaster.KD110)

                    '-------------------------------------------------------------------------------------------------------------
                    playMethod_Msg = IIf(crudMaster.KD113 = "A", playMethod_Select, playMethod_UnSelect) & "支票"
                    playMethod_Msg &= playMethod_Space & "票號 " & IIf(crudMaster.KD113 = "A", crudMaster.KD114.Trim, playMethod_UnderLine)
                    playMethod_Msg &= playMethod_Space & "付款行 " & IIf(crudMaster.KD113 = "A", crudMaster.KD115.Trim, playMethod_UnderLine)
                    playMethod_Msg &= vbNewLine

                    playMethod_Msg &= column_Space
                    playMethod_Msg &= IIf(crudMaster.KD113 = "B", playMethod_Select, playMethod_UnSelect) & "現金"
                    playMethod_Msg &= playMethod_Space
                    playMethod_Msg &= IIf(crudMaster.KD113 = "C", playMethod_Select, playMethod_UnSelect) & "匯台銀鼓山"
                    playMethod_Msg &= playMethod_Space
                    playMethod_Msg &= IIf(crudMaster.KD113 = "D", playMethod_Select, playMethod_UnSelect) & "其他"
                    playMethod_Msg &= playMethod_Space & IIf(crudMaster.KD113 = "D", crudMaster.KD114.Trim, playMethod_UnderLine)

                    .D合計_備註 = playMethod_Msg

                    '-------------------------------------------------------------------------------------------------------------
                    .付款方式A = IIf(crudMaster.KD113 = "A", playMethod_Select, playMethod_UnSelect) & "支票"
                    .付款方式B = IIf(crudMaster.KD113 = "B", playMethod_Select, playMethod_UnSelect) & "現金"
                    .付款方式C = IIf(crudMaster.KD113 = "C", playMethod_Select, playMethod_UnSelect) & "匯台銀鼓山"
                    .付款方式D = IIf(crudMaster.KD113 = "D", playMethod_Select, playMethod_UnSelect) & "其他"


                    Select Case crudMaster.KD113
                        Case "A"
                            .付款說明A_1 = crudMaster.KD114.Trim
                            .付款說明A_2 = crudMaster.KD115.Trim
                        Case "D"
                            .付款說明D_1 = crudMaster.KD114.Trim
                    End Select

                    '-------------------------------------------------------------------------------------------------------------

                    .D合計_金額 = ModTools.showInfoForMoney(crudMaster.KD111)
                    .D中文_金額 = "總計新台幣：" & ModTools.FS_Number2ChineseString(crudMaster.KD111)
                End With



            End If



            'Detail
            '-------------------------------------------------------------------------------------
            W_SQL = New StringBuilder
            W_SQL.Append("SELECT  * " & vbNewLine)
            W_SQL.Append("FROM @#COME.KIND02PF " & vbNewLine)
            W_SQL.Append("WHERE 1=1  AND KD201='" & from單據號碼1 & "' " & vbNewLine)
            W_SQL.Append("    AND KD202 =" & IIf(IsNumeric(from單據號碼2), from單據號碼2, 0) & " " & vbNewLine)
            W_SQL.Append("ORDER BY KD203 " & vbNewLine)

            crudList_Detail = COME.KIND02PF.CDBSelect(Of COME.KIND02PF)(W_SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)


            For II = 1 To crudList_Detail.Count
                crudDetail = crudList_Detail.Item(II - 1)

                With paramRow
                    .Item("D摘要" & II) = crudDetail.KD205.Trim
                    .Item("D金額" & II) = String.Format("{0:0,0}", crudDetail.KD204)
                    If .Item("D金額" & II).ToString.Length >= 0 AndAlso .Item("D金額" & II).ToString.Substring(0, 1) = "0" Then
                        .Item("D金額" & II) = .Item("D金額" & II).ToString.Substring(1)
                    End If
                    .Item("D備註" & II) = crudDetail.KD206.Trim
                End With
            Next II


            '欄位左方補空白
            '------------------------------------------------------------------------------------------------------------
            For Each eachColumn As DataColumn In paramTable.Columns
                If eachColumn.ColumnName = "每聯編號" Then Continue For

                paramRow.Item(eachColumn.ColumnName) = column_Space & paramRow.Item(eachColumn.ColumnName)
            Next

            '------------------------------------------------------------------------------------------------------------
            paramTable.Rows.Add(paramRow)

            '第二版要產生三筆資料
            '------------------------------------------------------------------------------------------------------------
            If ReportViewer1.LocalReport.ReportPath.ToUpper.IndexOf("V2") >= 0 Then
                paramTable.ImportRow(paramTable.Rows(0))
                paramTable.ImportRow(paramTable.Rows(0))
            End If
            '------------------------------------------------------------------------------------------------------------

            Dim W_Title() As String = New String() {"第一聯：繳款單位", "第二聯：會計處", "第三聯：財務處"}
            For II As Integer = 0 To paramTable.Rows.Count - 1
                paramRow = paramTable.Rows(II)

                paramRow.每聯編號 = (II + 1)
                paramRow.每聯標題 = W_Title(II)
            Next
        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message

        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")

        End Try


        Return paramTable
    End Function


#End Region

#Region "Report Parameter"

    Private Sub P_ReportViewer1_SetParameter(ByVal fromName As String, ByVal fromValue As String)
        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter(fromName, fromValue))
    End Sub
#End Region


    Private Function FI_RdlsVer() As Integer
        Dim rdlsVer As String
        rdlsVer = ReportViewer1.LocalReport.ReportPath.Substring(ReportViewer1.LocalReport.ReportPath.Length - 6, 1)

        Return Integer.Parse(rdlsVer)
    End Function

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click


        Try
            CustomValidator1.ErrorMessage = ""

            Dim W_單據號碼1 As String = "", W_單據號碼2 As String = ""
            If Me.tbInvoice_Number.Text.Length >= 2 Then W_單據號碼1 = Me.tbInvoice_Number.Text.Substring(0, 2)
            If Me.tbInvoice_Number.Text.Length >= 3 Then W_單據號碼2 = Me.tbInvoice_Number.Text.Substring(2)


            Dim W_ParamReportTitle() As String = {"第一聯：繳款單位", "第二聯：會計處", "第三聯：財務處"}
            ReportViewer1.LocalReport.DataSources.Clear()

            With ReportViewer1.LocalReport
                Select Case FI_RdlsVer()
                    Case 1
                        '-- Main---------------------------------------------------------------------------------------------------------------------------------------------
                        .DataSources.Add(P_AddTable("DataSet1", FT_LoadDataByInvoice_Number(W_單據號碼1, W_單據號碼2)))
                        .SetParameters(P_AddParam("ParamReportTitle", String.Join(",", W_ParamReportTitle)))


                    Case 2
                        '-- Main---------------------------------------------------------------------------------------------------------------------------------------------
                        .DataSources.Add(P_AddTable("DataSet_Master", P_AddTable_Master(W_單據號碼1, W_單據號碼2)))
                        .DataSources.Add(P_AddTable("DataSet_Detail", P_AddTable_Detail(W_單據號碼1, W_單據號碼2)))

                        '-- SubReport---------------------------------------------------------------------------------------------------------------------------------------------
                        AddHandler Me.ReportViewer1.LocalReport.SubreportProcessing, AddressOf P_SubreportProcessing_v2
                End Select


                .Refresh()
            End With
        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        End Try
        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
    End Sub


    Private Sub P_SubreportProcessing_v2(sender As Object, e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim queryTable_S1 As DataTable  'Financial.FinancialDataSet.InvoiceOfReceivables_v2_MDataTable
        Dim queryTable_S2 As Financial.FinancialDataSet.InvoiceOfReceivables_v2_DDataTable

        queryTable_S1 = CType(CType(sender, Microsoft.Reporting.WebForms.LocalReport).DataSources.Item(0).Value, Financial.FinancialDataSet.InvoiceOfReceivables_v2_MDataTable)
        queryTable_S2 = CType(CType(sender, Microsoft.Reporting.WebForms.LocalReport).DataSources.Item(1).Value, Financial.FinancialDataSet.InvoiceOfReceivables_v2_DDataTable)

        Dim W_每聯編號 As String = e.Parameters.Item("P每聯編號").Values(0).ToString
        queryTable_S1 = (From A In queryTable_S1 Where A.Field(Of Integer)("每聯編號") = Integer.Parse(W_每聯編號) Select A).CopyToDataTable

        e.DataSources.Add(P_AddTable("DataSet_S1", queryTable_S1))
        e.DataSources.Add(P_AddTable("DataSet_S2", queryTable_S2))
    End Sub


    Private Function P_AddParam(ByVal fromTag As String, ByVal fromObj As Object) As Microsoft.Reporting.WebForms.ReportParameter
        Dim reportParam As New Microsoft.Reporting.WebForms.ReportParameter(fromTag, fromObj.ToString)
        Return reportParam
    End Function

    Private Function P_AddTable(ByVal fromTag As String, ByVal fromObj As Object) As Microsoft.Reporting.WebForms.ReportDataSource
        Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource()
        rds.Name = fromTag
        rds.Value = fromObj

        Return rds
    End Function

    Private Function P_AddTable_Master(ByVal from單據號碼1 As String, from單據號碼2 As String) As FinancialDataSet.InvoiceOfReceivables_v2_MDataTable
        Dim paramTable As New FinancialDataSet.InvoiceOfReceivables_v2_MDataTable

        CustomValidator1.ErrorMessage = ""

        Try

            Dim paramRow As FinancialDataSet.InvoiceOfReceivables_v2_MRow
            paramRow = paramTable.NewRow

            '讀取單據資料
            '------------------------------------------------------------------------------------------------------------
            Dim crudList_Master As List(Of CompanyORMDB.COME.KIND01PF) = Nothing
            Dim crudMaster As CompanyORMDB.COME.KIND01PF = Nothing

            Dim W_SQL As New StringBuilder

            Dim playMethod_Msg As String
            Dim playMethod_Select As String = "☑"
            Dim playMethod_UnSelect As String = "□"
            Dim playMethod_Space As String = Space(2)
            Dim playMethod_UnderLine As String = "".PadRight(10, "_")

            Dim column_Space As String = Space(1)
            '------------------------------------------------------------------------------------------------------------

            'Master
            '-------------------------------------------------------------------------------------
            W_SQL.Append("SELECT  * " & vbNewLine)
            W_SQL.Append("FROM @#COME.KIND01PF " & vbNewLine)
            W_SQL.Append("WHERE 1=1  AND KD101='" & from單據號碼1 & "' " & vbNewLine)
            W_SQL.Append("    AND KD102 =" & IIf(IsNumeric(from單據號碼2), from單據號碼2, 0) & " " & vbNewLine)

            crudList_Master = COME.KIND01PF.CDBSelect(Of COME.KIND01PF)(W_SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            If crudList_Master.Count > 0 Then
                crudMaster = crudList_Master.Item(0)

                With paramRow
                    .單據號碼 = crudMaster.KD101 & crudMaster.KD102
                    .輸入職編 = crudMaster.KD103 & Space(1) & showEmployeeName(WP_DataTable_Employee, crudMaster.KD103)
                    .輸入部門 = crudMaster.KD104 & Space(1) & showUnitName(WP_DataTable_Unit, crudMaster.KD104)
                    .輸入日期時間 = InvoiceOfReceivables_Model.showFormatFor_DateTime(False, crudMaster.KD105, crudMaster.KD106)
                    .輸入日期 = InvoiceOfReceivables_Model.showFormatFor_DateTime(False, crudMaster.KD105, "")
                    .收款職編 = crudMaster.KD107 & Space(1) & showEmployeeName(WP_DataTable_Employee, crudMaster.KD107)
                    .收款部門 = crudMaster.KD108 & Space(1) & showUnitName(WP_DataTable_Unit, crudMaster.KD108)
                    .收款日期時間 = InvoiceOfReceivables_Model.showFormatFor_DateTime(False, crudMaster.KD109, crudMaster.KD110)

                    '-------------------------------------------------------------------------------------------------------------
                    playMethod_Msg = IIf(crudMaster.KD113 = "A", playMethod_Select, playMethod_UnSelect) & "支票"
                    playMethod_Msg &= playMethod_Space & "票號 " & IIf(crudMaster.KD113 = "A", crudMaster.KD114.Trim, playMethod_UnderLine)
                    playMethod_Msg &= playMethod_Space & "付款行 " & IIf(crudMaster.KD113 = "A", crudMaster.KD115.Trim, playMethod_UnderLine)
                    playMethod_Msg &= vbNewLine

                    playMethod_Msg &= column_Space
                    playMethod_Msg &= IIf(crudMaster.KD113 = "B", playMethod_Select, playMethod_UnSelect) & "現金"
                    playMethod_Msg &= playMethod_Space
                    playMethod_Msg &= IIf(crudMaster.KD113 = "C", playMethod_Select, playMethod_UnSelect) & "匯台銀鼓山"
                    playMethod_Msg &= playMethod_Space
                    playMethod_Msg &= IIf(crudMaster.KD113 = "D", playMethod_Select, playMethod_UnSelect) & "其他"
                    playMethod_Msg &= playMethod_Space & IIf(crudMaster.KD113 = "D", crudMaster.KD114.Trim, playMethod_UnderLine)

                    playMethod_Msg = IIf(crudMaster.KD113 = "E", playMethod_Select, playMethod_UnSelect) & "定存單"
                    playMethod_Msg &= playMethod_Space & "票號 " & IIf(crudMaster.KD113 = "E", crudMaster.KD114.Trim, playMethod_UnderLine)
                    playMethod_Msg &= playMethod_Space & "銀行 " & IIf(crudMaster.KD113 = "E", crudMaster.KD115.Trim, playMethod_UnderLine)
                    playMethod_Msg &= vbNewLine

                    playMethod_Msg = IIf(crudMaster.KD113 = "F", playMethod_Select, playMethod_UnSelect) & "保證函"
                    playMethod_Msg &= playMethod_Space & "票號 " & IIf(crudMaster.KD113 = "F", crudMaster.KD114.Trim, playMethod_UnderLine)
                    playMethod_Msg &= playMethod_Space & "銀行 " & IIf(crudMaster.KD113 = "F", crudMaster.KD115.Trim, playMethod_UnderLine)
                    playMethod_Msg &= vbNewLine


                    .合計_備註 = playMethod_Msg

                    '-------------------------------------------------------------------------------------------------------------
                    .付款方式A = IIf(crudMaster.KD113 = "A", playMethod_Select, playMethod_UnSelect) & "支票"
                    .付款方式B = IIf(crudMaster.KD113 = "B", playMethod_Select, playMethod_UnSelect) & "現金"
                    .付款方式C = IIf(crudMaster.KD113 = "C", playMethod_Select, playMethod_UnSelect) & "匯台銀鼓山"
                    .付款方式D = IIf(crudMaster.KD113 = "D", playMethod_Select, playMethod_UnSelect) & "其他"
                    .付款方式E = IIf(crudMaster.KD113 = "E", playMethod_Select, playMethod_UnSelect) & "定存單"
                    .付款方式F = IIf(crudMaster.KD113 = "F", playMethod_Select, playMethod_UnSelect) & "保證函"

                    Select Case crudMaster.KD113
                        Case "A"
                            .付款說明A_1 = crudMaster.KD114.Trim
                            .付款說明A_2 = crudMaster.KD115.Trim
                        Case "D"
                            .付款說明D_1 = crudMaster.KD114.Trim
                        Case "E"
                            .付款說明E_1 = crudMaster.KD114.Trim
                            .付款說明E_2 = crudMaster.KD115.Trim
                        Case "F"
                            .付款說明F_1 = crudMaster.KD114.Trim
                            .付款說明f_2 = crudMaster.KD115.Trim
                    End Select

                    '-------------------------------------------------------------------------------------------------------------

                    .合計_金額 = ModTools.showInfoForMoney(crudMaster.KD111)
                    .中文_金額 = "總計新台幣：" & ModTools.FS_Number2ChineseString(crudMaster.KD111)
                    .購案編號 = crudMaster.KD116
                End With

            End If


            '欄位左方補空白
            '------------------------------------------------------------------------------------------------------------
            For Each eachColumn As DataColumn In paramTable.Columns
                If eachColumn.ColumnName = "每聯編號" Then Continue For

                paramRow.Item(eachColumn.ColumnName) = column_Space & paramRow.Item(eachColumn.ColumnName)
            Next

            '------------------------------------------------------------------------------------------------------------
            paramTable.Rows.Add(paramRow)

            '第二版要產生三筆資料
            '------------------------------------------------------------------------------------------------------------
            paramTable.ImportRow(paramTable.Rows(0))
            paramTable.ImportRow(paramTable.Rows(0))

            '------------------------------------------------------------------------------------------------------------

            Dim W_Title() As String = New String() {"第一聯：繳款單位", "第二聯：會計處", "第三聯：財務處"}
            For II As Integer = 0 To paramTable.Rows.Count - 1
                paramRow = paramTable.Rows(II)

                paramRow.每聯編號 = (II + 1)
                paramRow.每聯標題 = W_Title(II)
            Next
        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message

        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")

        End Try
        Return paramTable
    End Function

    Private Function P_AddTable_Detail(ByVal from單據號碼1 As String, from單據號碼2 As String) As FinancialDataSet.InvoiceOfReceivables_v2_DDataTable
        Dim paramTable As New FinancialDataSet.InvoiceOfReceivables_v2_DDataTable

        CustomValidator1.ErrorMessage = ""

        Try

            Dim paramRow As FinancialDataSet.InvoiceOfReceivables_v2_DRow


            '讀取單據資料
            '------------------------------------------------------------------------------------------------------------            
            Dim crudList_Detail As List(Of CompanyORMDB.COME.KIND02PF) = Nothing
            Dim crudDetail As CompanyORMDB.COME.KIND02PF = Nothing

            Dim W_SQL As New StringBuilder

            'Detail
            '-------------------------------------------------------------------------------------
            W_SQL = New StringBuilder
            W_SQL.Append("SELECT  * " & vbNewLine)
            W_SQL.Append("FROM @#COME.KIND02PF " & vbNewLine)
            W_SQL.Append("WHERE 1=1  AND KD201='" & from單據號碼1 & "' " & vbNewLine)
            W_SQL.Append("    AND KD202 =" & IIf(IsNumeric(from單據號碼2), from單據號碼2, 0) & " " & vbNewLine)
            W_SQL.Append("ORDER BY KD203 " & vbNewLine)

            crudList_Detail = COME.KIND02PF.CDBSelect(Of COME.KIND02PF)(W_SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)


            For II = 1 To crudList_Detail.Count
                crudDetail = crudList_Detail.Item(II - 1)

                paramRow = paramTable.NewRow
                With paramRow
                    .摘要 = crudDetail.KD205.Trim
                    .金額 = String.Format("{0:0,0}", crudDetail.KD204)
                    If .金額.ToString.Length >= 0 AndAlso .金額.ToString.Substring(0, 1) = "0" Then
                        .金額 = .金額.ToString.Substring(1)
                    End If
                    .備註 = crudDetail.KD206.Trim
                End With

                paramTable.Rows.Add(paramRow)
            Next II


        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message

        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")

        End Try


        Return paramTable
    End Function




End Class