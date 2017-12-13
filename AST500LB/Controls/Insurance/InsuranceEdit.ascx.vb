Public Partial Class InsuranceEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of AST501PF)
        Return CompanyORMDB.AST500LB.AST501PF.CDBSelect(Of CompanyORMDB.AST500LB.AST501PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function

#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
Public Shared Function CDBInsert(ByVal SourceObject As AST501PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
Public Shared Function CDBDelete(ByVal SourceObject As AST501PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete()
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As AST501PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBUpdate()
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
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim StartData As Date = CType(tbStartDate.Text, Date)
        Dim EndDate As Date = CType(tbEndDate.Text, Date)
        Dim StartDateNumber As Integer = (Format(StartData, "yyyy") - 1911) * 10000 + Format(StartData, "MMdd")
        Dim EndDateNumber As Integer = (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
        Dim SQLString As String = Nothing

        SQLString = " Select * From " & (New CompanyORMDB.AST500LB.AST501PF).CDBFullAS400DBPath.Trim
        SQLString &= " Where NOT ((SDATE<" & StartDateNumber & " AND EDATE<" & StartDateNumber & ") OR (SDATE>" & EndDateNumber & " AND EDATE>" & EndDateNumber & ")) AND FACKIND='" & RadioButtonList1.SelectedValue & "' "
        If Not String.IsNullOrEmpty(tbAssetNumber.Text) And tbAssetNumber.Text.Trim.Length > 0 Then
            SQLString &= " AND NUMBER ='" & tbAssetNumber.Text.Trim & "'"
        End If


        If Not String.IsNullOrEmpty(tbAssetName.Text) And tbAssetName.Text.Trim.Length > 0 Then
            SQLString &= " AND NUMBER IN ( SELECT NUMBER FROM " & (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue.Trim & " WHERE NAME LIKE '%" & tbAssetName.Text.Trim & "%' )"
        End If


        If Not String.IsNullOrEmpty(UseDepart.Text) And UseDepart.Text.Trim.Length > 0 Then
            SQLString &= " AND NUMBER IN ( SELECT NUMBER FROM " & (New CompanyORMDB.AST500LB.AST106PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue.Trim & " WHERE DEPTSA = '" & UseDepart.Text.Trim & "' )"
        End If


        Dim InsurceKinds As String = Nothing
        For Each EachItem1 As ListItem In cblInsurceKind.Items
            If EachItem1.Selected Then
                InsurceKinds &= IIf(IsNothing(InsurceKinds), Nothing, ",") & EachItem1.Value
            End If
        Next
        SQLString &= IIf(IsNothing(InsurceKinds), Nothing, " AND SAVKIND IN (" & InsurceKinds & ")")

        Me.hfQryString.Value = SQLString
    End Sub
#End Region
#Region "產生查詢字串至控制項 函式:MakQryStringToControl1"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl1()
        Dim StartData As Date = CType(tbStartDate.Text, Date)
        Dim EndDate As Date = CType(tbEndDate.Text, Date)
        Dim StartDateNumber As Integer = (Format(StartData, "yyyy") - 1911) * 10000 + Format(StartData, "MMdd")
        Dim EndDateNumber As Integer = (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
        Dim SQLString As String = Nothing

        SQLString = " Select A.*,B.* From @#AST500LB.AST501PF A JOIN @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER "
        If RadioButtonList1.SelectedValue = "SA" Then
            SQLString = " Select A.*,B.*,C.DEPTSA From @#AST500LB.AST501PF A JOIN @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER LEFT JOIN @#AST500LB.AST106PF C ON A.NUMBER=C.NUMBER AND C.SEQ=1 "
        End If
        SQLString &= " Where NOT ((SDATE<" & StartDateNumber & " AND EDATE<" & StartDateNumber & ") OR (SDATE>" & EndDateNumber & " AND EDATE>" & EndDateNumber & ")) AND FACKIND='" & RadioButtonList1.SelectedValue & "' "
        If Not String.IsNullOrEmpty(tbAssetNumber.Text) And tbAssetNumber.Text.Trim.Length > 0 Then
            SQLString &= " AND NUMBER ='" & tbAssetNumber.Text.Trim & "'"
        End If


        If Not String.IsNullOrEmpty(tbAssetName.Text) And tbAssetName.Text.Trim.Length > 0 Then
            SQLString &= " AND NUMBER IN ( SELECT NUMBER FROM " & (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue.Trim & " WHERE NAME LIKE '%" & tbAssetName.Text.Trim & "%' )"
        End If


        If Not String.IsNullOrEmpty(UseDepart.Text) And UseDepart.Text.Trim.Length > 0 Then
            SQLString &= " AND NUMBER IN ( SELECT NUMBER FROM " & (New CompanyORMDB.AST500LB.AST106PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue.Trim & " WHERE DEPTSA = '" & UseDepart.Text.Trim & "' )"
        End If


        Dim InsurceKinds As String = Nothing
        For Each EachItem1 As ListItem In cblInsurceKind.Items
            If EachItem1.Selected Then
                InsurceKinds &= IIf(IsNothing(InsurceKinds), Nothing, ",") & EachItem1.Value
            End If
        Next
        SQLString &= IIf(IsNothing(InsurceKinds), Nothing, " AND SAVKIND IN (" & InsurceKinds & ")")

        Me.hfQryString1.Value = SQLString
    End Sub
#End Region


#Region "已新增或刪除資產編號 屬性:AlreadyInsertOrDeleteAssetNumber"
    ''' <summary>
    ''' 已新增或刪除資產編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlreadyInsertOrDeleteAssetNumber() As String
        Get
            Return Me.ViewState("_AlreadyInsertOrDeleteAssetNumber")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_AlreadyInsertOrDeleteAssetNumber") = value
        End Set
    End Property

#End Region
#Region "已新增或刪除廠別代碼 屬性:AlreadyInsertOrDeleteFactoryCode"
    ''' <summary>
    ''' 已新增或刪除廠別代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlreadyInsertOrDeleteFactoryCode() As String
        Get
            Return Me.ViewState("_AlreadyInsertOrDeleteFactoryCode")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_AlreadyInsertOrDeleteFactoryCode") = value
        End Set
    End Property

#End Region
#Region "找尋AST101PF廠別資產資料 函式:FindAST101PFFactoryData"
    ''' <summary>
    ''' 找尋AST101PF廠別資產資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FindAlreadyInsertOrDeleteAssetData() As CompanyORMDB.AST500LB.AST101PF
        If String.IsNullOrEmpty(AlreadyInsertOrDeleteAssetNumber) OrElse AlreadyInsertOrDeleteAssetNumber.Trim.Length = 0 Then
            Return Nothing
        End If
        Select Case AlreadyInsertOrDeleteFactoryCode
            Case "SA"
                Return (From A In CompanyORMDB.AST500LB.AST101PF.AllAST101PF(AST101PF.FactoryEnum.SA) Where A.NUMBER = AlreadyInsertOrDeleteAssetNumber Select A).FirstOrDefault
            Case "AA"
                Return (From A In CompanyORMDB.AST500LB.AST101PF.AllAST101PF(AST101PF.FactoryEnum.AA) Where A.NUMBER = AlreadyInsertOrDeleteAssetNumber Select A).FirstOrDefault
            Case "AB"
                Return (From A In CompanyORMDB.AST500LB.AST101PF.AllAST101PF(AST101PF.FactoryEnum.AB) Where A.NUMBER = AlreadyInsertOrDeleteAssetNumber Select A).FirstOrDefault
            Case "QA"
                Return (From A In CompanyORMDB.AST500LB.AST101PF.AllAST101PF(AST101PF.FactoryEnum.QA) Where A.NUMBER = AlreadyInsertOrDeleteAssetNumber Select A).FirstOrDefault
            Case "NA"
                Return (From A In CompanyORMDB.AST500LB.AST101PF.AllAST101PF(AST101PF.FactoryEnum.NA) Where A.NUMBER = AlreadyInsertOrDeleteAssetNumber Select A).FirstOrDefault
            Case "RA"
                Return (From A In CompanyORMDB.AST500LB.AST101PF.AllAST101PF(AST101PF.FactoryEnum.RA) Where A.NUMBER = AlreadyInsertOrDeleteAssetNumber Select A).FirstOrDefault
            Case "RC"
                Return (From A In CompanyORMDB.AST500LB.AST101PF.AllAST101PF(AST101PF.FactoryEnum.RC) Where A.NUMBER = AlreadyInsertOrDeleteAssetNumber Select A).FirstOrDefault
            Case "RD"
                Return (From A In CompanyORMDB.AST500LB.AST101PF.AllAST101PF(AST101PF.FactoryEnum.RD) Where A.NUMBER = AlreadyInsertOrDeleteAssetNumber Select A).FirstOrDefault

            Case Else
                Return Nothing
        End Select
    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now.AddYears(-1), "yyyy/08/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
            Call TabContainer1_ActiveTabChanged(Nothing, Nothing)
        End If

    End Sub

    Public Sub InsertCustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SenderControl As CustomValidator = source
        SenderControl.ErrorMessage = ""
        If String.IsNullOrEmpty(CType(Me.ListView1.InsertItem.FindControl("NUMBERTextBox"), TextBox).Text) Then
            SenderControl.Text = "資產編號不可為空白!"
        End If
        args.IsValid = String.IsNullOrEmpty(SenderControl.Text)
    End Sub

    Private Sub ListView1_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewDeletedEventArgs) Handles ListView1.ItemDeleted
        Dim MsgControl As Label = lbMessage ' ListView1.InsertItem.FindControl("lbMessage")
        If String.IsNullOrEmpty(AlreadyInsertOrDeleteAssetNumber) OrElse AlreadyInsertOrDeleteAssetNumber.Trim.Length = 0 Then
            MsgControl.Text = Nothing
            Exit Sub
        End If
        If e.AffectedRows = 0 Then
            MsgControl.Text = "刪除資料失敗!" : MsgControl.ForeColor = System.Drawing.Color.Red
        End If
        Dim FindObject As CompanyORMDB.AST500LB.AST101PF = FindAlreadyInsertOrDeleteAssetData()

        If IsNothing(FindObject) Then
            MsgControl.Text = "刪除成功但資料異常,資料庫中找不到原資產(資產編號:" & Me.AlreadyInsertOrDeleteAssetNumber & ")!" : MsgControl.ForeColor = System.Drawing.Color.Red
        Else
            MsgControl.Text = "刪除成功! 名稱:" & FindObject.NAME & " 編號:" & Me.AlreadyInsertOrDeleteAssetNumber & "!" : MsgControl.ForeColor = System.Drawing.Color.Blue
        End If

    End Sub

    Private Sub ListView1_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewDeleteEventArgs) Handles ListView1.ItemDeleting
        Me.AlreadyInsertOrDeleteAssetNumber = e.Keys("NUMBER")
        Me.AlreadyInsertOrDeleteFactoryCode = e.Keys("FACKIND")
    End Sub

    Private Sub ListView1_ItemEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewEditEventArgs) Handles ListView1.ItemEditing
        lbMessage.Text = ""
    End Sub

    Private Sub ListView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewInsertedEventArgs) Handles ListView1.ItemInserted
        Dim MsgControl As Label = lbMessage ' ListView1.InsertItem.FindControl("lbMessage")
        If String.IsNullOrEmpty(AlreadyInsertOrDeleteAssetNumber) OrElse AlreadyInsertOrDeleteAssetNumber.Trim.Length = 0 Then
            MsgControl.Text = Nothing
            Exit Sub
        End If
        If e.AffectedRows = 0 Then
            MsgControl.Text = "新增資料失敗!" : MsgControl.ForeColor = System.Drawing.Color.Red
        End If
        Dim FindObject As CompanyORMDB.AST500LB.AST101PF = FindAlreadyInsertOrDeleteAssetData()

        If IsNothing(FindObject) Then
            MsgControl.Text = "新增成功但資料異常,資料庫中找不到原資產(資產編號:" & Me.AlreadyInsertOrDeleteAssetNumber & ")!" : MsgControl.ForeColor = System.Drawing.Color.Red
        Else
            MsgControl.Text = "新增成功! 名稱:" & FindObject.NAME & " 編號:" & Me.AlreadyInsertOrDeleteAssetNumber & "!" : MsgControl.ForeColor = System.Drawing.Color.Blue
        End If
    End Sub

    Private Sub ListView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewInsertEventArgs) Handles ListView1.ItemInserting
        e.Values("SAVKIND") = CType(ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue
        e.Values("FACKIND") = CType(ListView1.InsertItem.FindControl("DropDownList1"), DropDownList).SelectedValue
        Me.AlreadyInsertOrDeleteAssetNumber = e.Values("NUMBER")
        Me.AlreadyInsertOrDeleteFactoryCode = e.Values("FACKIND")
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        Dim SDATEControl As TextBox = Me.ListView1.InsertItem.FindControl("SDATETextBox")
        Dim EDATEControl As TextBox = Me.ListView1.InsertItem.FindControl("EDATETextBox")
        SDATEControl.Text = IIf(String.IsNullOrEmpty(SDATEControl.Text), Format(Now, "yyyy/10/02"), SDATEControl.Text)
        EDATEControl.Text = IIf(String.IsNullOrEmpty(EDATEControl.Text), Format(Now.AddYears(1), "yyyy/10/01"), EDATEControl.Text)
    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        MakQryStringToControl()
        ListView1.DataBind()
        lbMessage.Text = ""
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        If TabContainer1.ActiveTab Is TabPanel2 Then
            If String.IsNullOrEmpty(tbCopyFilterDate.Text) Then
                tbCopyFilterDate.Text = Format(Now, "yyyy/MM/dd")
            End If
            If String.IsNullOrEmpty(tbSetStartDate.Text) Then
                tbSetStartDate.Text = Format(Now, "yyyy/08/01")
            End If
            If String.IsNullOrEmpty(tbSetEndDate.Text) Then
                tbSetEndDate.Text = Format(Now.AddYears(1), "yyyy/07/31")
            End If
        End If

    End Sub

    Protected Sub btnStartCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStartCopy.Click

        Dim StartData As Date = CType(tbSetStartDate.Text, Date)
        Dim StartDateNumber As Integer = (Format(StartData, "yyyy") - 1911) * 10000 + Format(StartData, "MMdd")

        Dim EndData As Date = CType(tbSetEndDate.Text, Date)
        Dim EndDateNumber As Integer = (Format(EndData, "yyyy") - 1911) * 10000 + Format(EndData, "MMdd")

        Dim QryString As String = "Select COUNT(*) from @#AST500LB.AST501PF WHERE FACKIND='" & RadioButtonList2.SelectedValue.Trim & "' AND NOT ((SDATE<" & StartDateNumber & " AND EDATE<" & StartDateNumber & ") OR (SDATE>" & EndDateNumber & " AND EDATE>" & EndDateNumber & "))"

        If (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)).SelectQuery.Rows(0).Item(0) > 0 Then
            lbMsg.Text = "複製失敗==>設定保險起始日及終止日之間已有保險資料無法批次複製!"
            Exit Sub
        End If

        Dim CopyFromDate As Date = tbCopyFilterDate.Text
        Dim CopyFromDateNumber As Integer = (Format(CopyFromDate, "yyyy") - 1911) * 10000 + Format(CopyFromDate, "MMdd")

        Dim insertQryString As String = "INSERT INTO @#AST500LB.AST501PF ( Select A.NUMBER, A.FACKIND, " & StartDateNumber & " AS SDATE, " & EndDateNumber & " AS EDATE,A.SAVKIND,'CopyTime=" & Format(Now, "yyyy/MM/dd hh:mm:ss") & "' AS MEMO from @#AST500LB.AST501PF AS A WHERE FACKIND='" & RadioButtonList2.SelectedValue.Trim & "' AND SDATE<=" & CopyFromDateNumber & " AND EDATE>=" & CopyFromDateNumber & " )"

        lbMsg.Text = "已成功複製資料" & (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, insertQryString)).ExecuteNonQuery & " 筆"
    End Sub


    Protected Sub btnConvertToOutCompanyDownload_Click(sender As Object, e As EventArgs) Handles btnConvertToOutCompanyDownload.Click
        Me.MakQryStringToControl1()
        Dim DownloadData As New AST500LBDataSet.InsuranceEditDataTable
        Dim DownloadItem As AST500LBDataSet.InsuranceEditRow
        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, Me.hfQryString1.Value)

        For Each EachItem As DataRow In AS400Adapter.SelectQuery.Rows
            DownloadItem = DownloadData.NewRow
            With DownloadItem
                .項次 = DownloadData.Rows.Count + 1
                .資產編號 = EachItem.Item("Number")
                .資產名稱 = EachItem.Item("NAME")
                If RadioButtonList1.SelectedValue = "SA" Then
                    .置放地點 = EachItem.Item("DEPTSA")
                Else
                    .置放地點 = EachItem.Item("DEPT")
                End If
                If Val(EachItem.Item("QUANT")) <> 0 Then
                    .單價 = EachItem.Item("AMOUNT") / EachItem.Item("QUANT")
                End If
                .數量 = EachItem.Item("QUANT")
                .價值 = EachItem.Item("AMOUNT")
                .入帳年月 = EachItem.Item("DATE")
                .耐用年限 = Val(EachItem.Item("USLAFF")) + Val(EachItem.Item("N7611"))
                'If Val(EachItem.Item("N7611")) = 0 Then
                '    .殘餘價值 = Val(EachItem.Item("AMOUNT")) - Val(EachItem.Item("DEPR"))
                'Else
                '    .殘餘價值 = Val(EachItem.Item("V7611"))
                'End If
                .殘餘價值 = Format(EachItem.Item("AMOUNT") - EachItem.Item("DEPR"), "0,0.00")
            End With
            DownloadData.Rows.Add(DownloadItem)
        Next
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(DownloadData, "唐榮資產保險資料" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub
End Class