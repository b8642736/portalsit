Public Class MISAssetTransferEdit
    Inherits System.Web.UI.UserControl

#Region "查詢現有資產 函式:SearchNearAsset"
    ''' <summary>
    ''' 查詢現有資產
    ''' </summary>
    ''' <param name="SearchSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchNearAsset(ByVal SearchSQL As String) As List(Of AST101PF)
        If String.IsNullOrEmpty(SearchSQL) Then
            Return New List(Of AST101PF)
        End If
        Dim ReturnValue As List(Of AST101PF) = AST101PF.CDBSelect(Of AST101PF)(SearchSQL, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return ReturnValue
    End Function
#End Region
#Region "產生查詢字串至控制項 函式:SearchNearAssetToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeNearAssetToControl()
        Dim QryString As New StringBuilder
        QryString.Append("Select * from @#AST500LB.AST101PF.ASTFSA WHERE 1=1 ")

        If Not String.IsNullOrEmpty(tbNAssetNumber.Text) AndAlso tbNAssetNumber.Text.Trim.Length > 4 Then
            Dim FindAssetNumber As String = tbNAssetNumber.Text.Trim
            QryString.Append(" and  number like '" & FindAssetNumber.Substring(0, FindAssetNumber.Length - 3) & "%'")
        End If

        If Not String.IsNullOrEmpty(tbAssetName.Text) AndAlso tbAssetName.Text.Trim.Length > 0 Then
            QryString.Append(" and  name like '%" & tbAssetName.Text.Trim & "%'")
        End If

        QryString.Append(" order by number")

        Me.hfSearchNearAsset.Value = QryString.ToString
    End Sub
#End Region


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of AST402PF)
        Dim ReturnValue As List(Of AST402PF) = Nothing
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If

        ReturnValue = New List(Of AST402PF)
        Dim SearchReslut As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString).SelectQuery
        For Each EachItem As DataRow In SearchReslut.Rows
            Dim AddItem As New AST402PF
            With AddItem
                .CDBSetDataRowValueToObject(EachItem)
                If Not IsDBNull(EachItem.Item("DEPTSA")) AndAlso Trim(EachItem.Item("DEPTSA")).Length > 0 Then
                    .About_AST106PF_ASTFSA = Trim(EachItem.Item("DEPTSA"))
                Else
                    .About_AST106PF_ASTFSA = " "
                End If
            End With
            ReturnValue.Add(AddItem)
        Next
        'ReturnValue = AST402PF.CDBSelect(Of AST402PF)(QryString, New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))

        Return ReturnValue
    End Function

    Public Function SearchToDataTable(ByVal QryString As String) As DataTable
        Dim ReturnValue As New DataTable
        ReturnValue.Columns.Add("移出單位", "".GetType)
        ReturnValue.Columns.Add("移入單位", "".GetType)
        ReturnValue.Columns.Add("行政處現行單位", "".GetType)
        ReturnValue.Columns.Add("資料建立日期", "".GetType)
        ReturnValue.Columns.Add("資產編號", "".GetType)
        ReturnValue.Columns.Add("資產類別", "".GetType)
        ReturnValue.Columns.Add("資產名稱", "".GetType)
        ReturnValue.Columns.Add("數量", GetType(Integer))
        ReturnValue.Columns.Add("出帳資產編號", "".GetType)
        ReturnValue.Columns.Add("入帳資產編號", "".GetType)
        ReturnValue.Columns.Add("移轉時殘值", GetType(Double))
        ReturnValue.Columns.Add("移轉後預估年限", GetType(Integer))
        ReturnValue.Columns.Add("編修資料工號", "".GetType)
        ReturnValue.Columns.Add("設備使用者姓名", "".GetType)
        ReturnValue.Columns.Add("設備編號", "".GetType)
        ReturnValue.Columns.Add("設備IP", "".GetType)
        ReturnValue.Columns.Add("資訊處設備ID", "".GetType)
        ReturnValue.Columns.Add("備註", "".GetType)
        For Each EachItem As AST402PF In Search(QryString)
            Dim AddRow As DataRow = ReturnValue.NewRow
            With AddRow
                .Item("移出單位") = EachItem.OUTDEPT
                .Item("移入單位") = EachItem.INDEPT
                .Item("行政處現行單位") = EachItem.About_AST106PF_ASTFSA
                .Item("資料建立日期") = EachItem.CDATADATE
                .Item("資產編號") = EachItem.NUMBER
                .Item("資產類別") = EachItem.KIND
                .Item("資產名稱") = EachItem.NAME
                .Item("數量") = EachItem.QUANT
                .Item("出帳資產編號") = EachItem.REFORGNUM
                .Item("入帳資產編號") = EachItem.TVALUE
                .Item("移轉時殘值") = EachItem.TDEPR
                .Item("移轉後預估年限") = EachItem.TDUEDAY
                .Item("編修資料工號") = EachItem.EDTUSRID
                .Item("設備使用者姓名") = EachItem.USERNAME
                .Item("設備編號") = EachItem.EQUID
                .Item("設備IP") = EachItem.EQUIP
                .Item("資訊處設備ID") = EachItem.MISEQUID
                .Item("備註") = EachItem.MEMO
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        Return ReturnValue
    End Function
#End Region
#Region "查詢印表 方式:SearchToPrint"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function SearchToPrint(ByVal QryString As String) As AST500LBDataSet.MISAssetTransferDataTable
        Dim ReturnValue As New AST500LBDataSet.MISAssetTransferDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Dim ItemCount As Integer = 1
        For Each EachItem As AST402PF In AST402PF.CDBSelect(Of AST402PF)(QryString, New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
            Dim AddItem As AST500LBDataSet.MISAssetTransferRow = ReturnValue.NewRow
            With AddItem
                .項次 = ItemCount
                .移出單位 = EachItem.OUTDEPT.Trim
                .轉入單位 = EachItem.INDEPT.Trim
                .資產編號 = EachItem.NUMBER.Trim
                .資產類別 = EachItem.KIND.Trim
                .資產名稱 = EachItem.NAME.Trim
                .數量 = EachItem.QUANT
                .入帳時資產總值 = Format(EachItem.TVALUE, "###,0.##")
                .移轉時殘值 = Format(EachItem.TDEPR, "###,0.##")
                .移轉後預估使用年限 = EachItem.TDUEDAY
                If Not String.IsNullOrEmpty(EachItem.USERNAME) AndAlso EachItem.USERNAME.Trim.Length > 0 Then
                    .備註 = "使用人:" & EachItem.USERNAME
                End If
            End With
            ReturnValue.Rows.Add(AddItem)
            ItemCount += 1
        Next
        Return ReturnValue
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As AST402PF) As Integer
        With SourceObject
            .OUTDEPT = .OUTDEPT.ToUpper
            .INDEPT = .INDEPT.ToUpper
            .NUMBER = .NUMBER.ToUpper
            .REFORGNUM = .REFORGNUM.ToUpper
            .EDTUSRID = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
            If .ISWAITPRT Then
                .PRINTGUP = .EDTUSRID
            Else
                .PRINTGUP = ""
            End If
            .CDATADATE = New CompanyORMDB.AS400DateConverter(Now).TwSevenCharsTypeData
        End With
        SplitAssetReCompute(SourceObject)
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBInsert
    End Function

#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As AST402PF) As Integer
        With SourceObject
            .OUTDEPT = .OUTDEPT.ToUpper
            .INDEPT = .INDEPT.ToUpper
            .NUMBER = .NUMBER.ToUpper
            .REFORGNUM = .REFORGNUM.ToUpper
            .EDTUSRID = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
            If .ISWAITPRT Then
                .PRINTGUP = .EDTUSRID
            Else
                .PRINTGUP = ""
            End If
        End With
        SplitAssetReCompute(SourceObject)
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBUpdate()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As AST402PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete
    End Function
#End Region
#Region "重新計算資產分割並附予結果 函式:SplitAssetReCompute"
    ''' <summary>
    ''' 重新計算資產分割並附予結果
    ''' </summary>
    ''' <param name="SourceData"></param>
    ''' <remarks></remarks>
    Shared Sub SplitAssetReCompute(ByRef SourceData As CompanyORMDB.AST500LB.AST402PF)
        Dim OrginalAssetString As String = "Select * from @#AST500LB.AST101PF.ASTFSA WHERE NUMBER='" & SourceData.REFORGNUM.Trim & "' "
        Dim SearchResult As List(Of AST101PF) = AST101PF.CDBSelect(Of AST101PF)(OrginalAssetString, New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
        If SearchResult.Count = 0 Then
            Exit Sub
        End If
        Dim ModValue As Double = 0
        Dim UnitPrice As Double = 0
        Dim FindedAST101PF As AST101PF = SearchResult(0)
        With SourceData
            Select Case True
                Case .REFORGNUM.Substring(0, 1) = "1"
                    .KIND = "土地"
                Case .REFORGNUM.Substring(0, 3) = "111"
                    .KIND = "土地改良物"
                Case .REFORGNUM.Substring(0, 1) = "2"
                    .KIND = "房屋及設備"
                Case .REFORGNUM.Substring(0, 1) = "3"
                    .KIND = "機械及設備"
                Case .REFORGNUM.Substring(0, 1) = "4"
                    .KIND = "交通設備"
                Case .REFORGNUM.Substring(0, 1) = "5"
                    .KIND = "雜項設備"
            End Select
            .NAME = FindedAST101PF.NAME
            If FindedAST101PF.AMOUNT > 0 Then
                ModValue = FindedAST101PF.AMOUNT Mod FindedAST101PF.QUANT
                UnitPrice = (FindedAST101PF.AMOUNT - ModValue) / FindedAST101PF.QUANT
                .TVALUE = UnitPrice * .QUANT
            End If
            If FindedAST101PF.DEPR > 0 Then
                ModValue = FindedAST101PF.DEPR Mod FindedAST101PF.QUANT
                UnitPrice = (FindedAST101PF.AMOUNT - FindedAST101PF.DEPR - ModValue) / FindedAST101PF.QUANT
                .TDEPR = UnitPrice * .QUANT
            End If
            Dim DueDate As Date = (New CompanyORMDB.AS400DateConverter(FindedAST101PF.DATE & "01")).DateValue.AddYears(FindedAST101PF.USLAFF).AddYears(FindedAST101PF.N7611)
            .TDUEDAY = (DueDate.Year - 1911) * 100 + Val(Format(DueDate, "MM"))
        End With
    End Sub
#End Region
#Region "目前Windows登入帳號　屬性:CurrentWindowsLoginEmployeeNumber"
    ''' <summary>
    ''' 目前Windows登入帳號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentWindowsLoginEmployeeNumber() As String
        Get
            If String.IsNullOrEmpty(My.User.Name) Then
                Return Nothing
            End If
            Dim DomainUserString() As String = My.User.Name.Split("\")
            If DomainUserString.Length < 2 And DomainUserString(0).ToUpper <> "DOMAIN" And DomainUserString(0).ToUpper <> "TESSCO" Then
                Return Nothing
            End If
            Return DomainUserString(1)
        End Get
    End Property
#End Region
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As New StringBuilder
        SQLString.Append("Select A.*,B.DEPTSA From @#AST500LB.AST402PF A LEFT JOIN @#AST500LB.AST106PF.ASTFSA B ON A.NUMBER=B.NUMBER and B.SEQ=1 WHERE 1=1 ")
        If Not String.IsNullOrEmpty(tbNUMBER.Text) AndAlso tbNUMBER.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.NUMBER in  ('" & tbNUMBER.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbName.Text) AndAlso tbName.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.NAME in  ('" & tbName.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbREFORGNUM.Text) AndAlso tbREFORGNUM.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.REFORGNUM in  ('" & tbREFORGNUM.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbUSERNAME.Text) AndAlso tbUSERNAME.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.USERNAME in  ('" & tbUSERNAME.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbEQUID.Text) AndAlso tbEQUID.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.EQUID in  ('" & tbEQUID.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbMISEQUID.Text) AndAlso tbMISEQUID.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.MISEQUID in  ('" & tbMISEQUID.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbOUTDEPT.Text) AndAlso tbOUTDEPT.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.OUTDEPT in  ('" & tbOUTDEPT.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbINDEPT.Text) AndAlso tbINDEPT.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.INDEPT in  ('" & tbINDEPT.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbEQUIP.Text) AndAlso tbEQUIP.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.EQUIP in  ('" & tbEQUIP.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbPRINTGUPSearch.Text) AndAlso tbPRINTGUPSearch.Text.Trim.Length > 0 Then
            SQLString.Append(" AND A.PRINTGUP in  ('" & tbPRINTGUPSearch.Text.Replace(",", "','") & "')")
        End If
        If rblTransStatus.SelectedValue <> "ALL" Then
            Select Case rblTransStatus.SelectedValue
                Case "NOTRANS"
                    SQLString.Append(" AND B.DEPTSA IS NULL ")
                Case "TRANS"
                    SQLString.Append(" AND NOT B.DEPTSA IS NULL AND A.INDEPT = B.DEPTSA ")
                Case "TRANSDIFFDEPT"
                    SQLString.Append(" AND NOT B.DEPTSA IS NULL AND A.INDEPT <> B.DEPTSA")
            End Select
        End If
        Me.hfQryString.Value = SQLString.ToString
    End Sub
#End Region
#Region "產生查詢字串至控制項 函式:MakQryStringToPrintReportControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToPrintReportControl()
        Dim SQLString As New StringBuilder
        SQLString.Append("Select * From @#AST500LB.AST402PF WHERE 1=1")
        If Not String.IsNullOrEmpty(tbPRINTGUP.Text) AndAlso tbPRINTGUP.Text.Trim.Length > 0 Then
            SQLString.Append(" and PRINTGUP='" & tbPRINTGUP.Text.Trim & "'")
        End If
        If Not String.IsNullOrEmpty(tbDept.Text) AndAlso tbDept.Text.Trim.Length > 0 Then
            If tbPRINTGUP.Text.Contains("*") Then
                SQLString.Append(" and PRINTGUP like '" & tbDept.Text.Trim.Replace("*", "%") & "' ")
            Else
                SQLString.Append(" and PRINTGUP = '" & tbDept.Text.Trim & "' ")
            End If
        End If
        SQLString.Append(" order by PRINTGUP,NUMBER")
        Me.hfPrintQry.Value = SQLString.ToString
    End Sub
#End Region

#Region "驗證資料是否正確 函式:ValidDataOutErrormMsg"
    Private Function ValidDataOutErrormMsg(ByVal IsInsertMode As String) As String
        '檢核新增資料是否正確
        Dim ErrorMsg As String = Nothing
        Dim OUTDEPTTextBox As TextBox
        Dim INDEPTTextBox As TextBox
        Dim NUMBERTextBox As TextBox
        Dim QUANTTextBox As TextBox
        Dim REFORGNUMTextBox As TextBox

        If IsInsertMode Then
            OUTDEPTTextBox = CType(ListView1.InsertItem.FindControl("OUTDEPTTextBox"), TextBox)
            INDEPTTextBox = CType(ListView1.InsertItem.FindControl("INDEPTTextBox"), TextBox)
            NUMBERTextBox = CType(ListView1.InsertItem.FindControl("NUMBERTextBox"), TextBox)
            QUANTTextBox = CType(ListView1.InsertItem.FindControl("QUANTTextBox"), TextBox)
            REFORGNUMTextBox = CType(ListView1.InsertItem.FindControl("REFORGNUMTextBox"), TextBox)
        Else
            OUTDEPTTextBox = CType(ListView1.EditItem.FindControl("OUTDEPTTextBox"), TextBox)
            INDEPTTextBox = CType(ListView1.EditItem.FindControl("INDEPTTextBox"), TextBox)
            NUMBERTextBox = CType(ListView1.EditItem.FindControl("NUMBERTextBox"), TextBox)
            QUANTTextBox = CType(ListView1.EditItem.FindControl("QUANTTextBox"), TextBox)
            REFORGNUMTextBox = CType(ListView1.EditItem.FindControl("REFORGNUMTextBox"), TextBox)
        End If

        Dim SearchResult As DataTable = Nothing
        If Not String.IsNullOrEmpty(REFORGNUMTextBox.Text) AndAlso REFORGNUMTextBox.Text.Trim.Length > 0 Then
            Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            Dim QryString As String = "Select A.* , B.* from @#AST500LB.AST101PF.ASTFSA A LEFT JOIN @#AST500LB.AST106PF.ASTFSA B ON A.NUMBER=B.NUMBER AND B.SEQ=1 WHERE A.NUMBER='" & REFORGNUMTextBox.Text.Trim & "'"
            SearchResult = Adapter.SelectQuery(QryString)
        End If
        Select Case True
            Case String.IsNullOrEmpty(OUTDEPTTextBox.Text) OrElse OUTDEPTTextBox.Text.Trim.Length = 0
                ErrorMsg = "轉出單位不可為空白!"
            Case String.IsNullOrEmpty(INDEPTTextBox.Text) OrElse INDEPTTextBox.Text.Trim.Length = 0
                ErrorMsg = "轉入單位不可為空白!"
            Case String.IsNullOrEmpty(NUMBERTextBox.Text) OrElse NUMBERTextBox.Text.Trim.Length = 0
                ErrorMsg = "資產編號不可為空白!"
            Case String.IsNullOrEmpty(QUANTTextBox.Text) OrElse Val(QUANTTextBox.Text) <= 0
                ErrorMsg = "移轉數量不可小於或等於零!"
            Case String.IsNullOrEmpty(REFORGNUMTextBox.Text) OrElse REFORGNUMTextBox.Text.Trim.Length = 0
                ErrorMsg = "參考原資產編號不可為空白!"
            Case IsNothing(SearchResult) OrElse SearchResult.Rows.Count = 0
                ErrorMsg = "找不到參考原資產編號!"
            Case OUTDEPTTextBox.Text.Trim.ToUpper <> CType(SearchResult.Rows(0).Item("DEPTSA"), String).Trim.ToUpper
                ErrorMsg = "轉出單位與參考原資產編號之單位不同輸入有誤!"
            Case CType(QUANTTextBox.Text, Integer) > CType(SearchResult.Rows(0).Item("QUANT"), Integer)
                ErrorMsg = "轉出數量已超過參考原資產編號之現有數量" & CType(SearchResult.Rows(0).Item("QUANT"), Integer) & "),輸入有誤!"
        End Select
        Return ErrorMsg
    End Function
#End Region





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbPRINTGUP.Text = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        ListView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(SearchToDataTable(hfQryString.Value), "資訊處資產移轉查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Protected Sub btnSearchPrint_Click(sender As Object, e As EventArgs) Handles btnSearchPrint.Click
        MakQryStringToPrintReportControl()
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        Dim ErrorMsg As String = ValidDataOutErrormMsg(True)
        CType(Me.ListView1.FindControl("lbMsg"), Label).Text = ErrorMsg
        e.Cancel = Not String.IsNullOrEmpty(ErrorMsg)   '如有錯誤則取消新增
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim ErrorMsg As String = ValidDataOutErrormMsg(False)
        CType(Me.ListView1.EditItem.FindControl("lbMsg"), Label).Text = ErrorMsg
        e.Cancel = Not String.IsNullOrEmpty(ErrorMsg)   '如有錯誤則取消新增
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        'Dim OUTDEPTControl As TextBox = ListView1.InsertItem.FindControl("OUTDEPTTextBox")
        'If Not IsNothing(OUTDEPTControl) AndAlso QUANTControl.Text.Trim.Length = 0 Then
        '    OUTDEPTControl.Text = "H3"
        'End If
        Dim QUANTControl As TextBox = ListView1.InsertItem.FindControl("QUANTTextBox")
        If Not IsNothing(QUANTControl) AndAlso QUANTControl.Text.Trim.Length = 0 Then
            QUANTControl.Text = "1"
        End If
    End Sub

    Protected Sub btnSearchAsset_Click(sender As Object, e As EventArgs) Handles btnSearchAsset.Click
        MakeNearAssetToControl()
        Me.GridView1.DataBind()
    End Sub


    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        If Not String.IsNullOrEmpty(GridView1.SelectedValue) AndAlso GridView1.SelectedValue.ToString.Trim.Length > 0 Then
            CType(ListView1.InsertItem.FindControl("REFORGNUMTextBox"), TextBox).Text = GridView1.SelectedDataKey(0).ToString.Trim
            Dim ListviewControl As TextBox = ListView1.InsertItem.FindControl("OUTDEPTTextBox")
            ListviewControl.Text = GridView1.SelectedDataKey(1).ToString.Trim

            ListviewControl = ListView1.InsertItem.FindControl("NUMBERTextBox")
            If String.IsNullOrEmpty(ListviewControl.Text) AndAlso _
                Not String.IsNullOrEmpty(tbNAssetNumber.Text) AndAlso tbNAssetNumber.Text.Trim.Length > 0 Then
                ListviewControl.Text = tbNAssetNumber.Text.Split(",")(0)
            End If
            TabContainer1.ActiveTab = TabPanel1
        End If
    End Sub


    Protected Sub btnClearSearchCondiction_Click(sender As Object, e As EventArgs) Handles btnClearSearchCondiction.Click
        tbNAssetNumber.Text = Nothing
        tbAssetName.Text = Nothing
    End Sub


    Protected Sub btnClearPrintGouptNumber_Click(sender As Object, e As EventArgs) Handles btnClearPrintGouptNumber.Click
        Dim Qry As String = "Update @#AST500LB.AST402PF SET PRINTGUP='' WHERE  PRINTGUP='" & WebAppAuthority.CurrentWindowsLoginEmployeeNumber.Trim & "'"
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Adapter.ExecuteNonQuery(Qry)
    End Sub
End Class