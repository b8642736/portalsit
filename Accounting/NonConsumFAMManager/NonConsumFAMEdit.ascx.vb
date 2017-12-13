Public Partial Class NonConsumFAMEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal SQLString As String) As List(Of AST103PF)
        Return ClassDBAS400.CDBSelect(Of AST103PF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
Public Shared Function CDBInsert(ByVal SourceObject As AST103PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "更新 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
Public Shared Function CDBUpdate(ByVal SourceObject As AST103PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBUpdate()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
Public Shared Function CDBDelete(ByVal SourceObject As AST103PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete()
    End Function
#End Region
#Region "查詢SQL字串 屬性:SearhSQLString"
    ''' <summary>
    ''' 查詢SQL字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SearhSQLString() As String
        Get
            Dim StartDateConverter As New CompanyORMDB.AS400DateConverter(Me.btStartDate.Text.Trim)
            Dim EndDateConverter As New CompanyORMDB.AS400DateConverter(Me.btEndDate.Text.Trim)
            Dim QueryString As String = "Select * From @#" & (New AST103PF).CDBLibraryName & ".AST103PF Where AS304>=" & StartDateConverter.TwIntegerTypeData & " AND AS304<=" & EndDateConverter.TwIntegerTypeData & " AND AS391<>'*' "
            If Not String.IsNullOrEmpty(tbAS301.Text.Trim) Then
                QueryString &= " AND AS301 LIKE '" & tbAS301.Text.Trim.Replace("'", Nothing) & "%'"
            End If
            If Not String.IsNullOrEmpty(tbAS302.Text.Trim) Then
                QueryString &= " AND AS302 LIKE '%" & tbAS302.Text.Trim.Replace("'", Nothing) & "%'"
            End If
            If Not String.IsNullOrEmpty(tbAS306.Text.Trim) Then
                QueryString &= " AND AS306 LIKE '" & tbAS306.Text.Trim.Replace("'", Nothing) & "%'"
            End If
            If Not String.IsNullOrEmpty(tbAS310.Text.Trim) Then
                QueryString &= " AND AS310 LIKE '%" & tbAS310.Text.Trim.Replace("'", Nothing) & "%'"
            End If
            If Not String.IsNullOrEmpty(tbAS311.Text.Trim) Then
                If IsNumeric(tbAS311.Text.Trim.Substring(0, 1)) = False Then
                    Dim SubQuery As String = "SELECT PT0102 FROM @#PLT500LB.PTM010PF WHERE PT0101 LIKE '%" & tbAS311.Text.Trim.Replace("'", Nothing) & "%'"
                    QueryString &= " AND AS311 in (" & SubQuery & ")"
                Else
                    QueryString &= " AND AS311 LIKE '%" & tbAS311.Text.Trim.Replace("'", Nothing) & "%'"
                End If
            End If
            If Not String.IsNullOrEmpty(tbAS393.Text.Trim) Then
                QueryString &= " AND AS393 LIKE '%" & tbAS393.Text.Trim.Replace("'", Nothing) & "%'"
            End If

            Return QueryString
        End Get
    End Property
#End Region

#Region "找尋員工等待輸入工號控制項 屬性:WaitImputEmployeeNumberControlID"
    ''' <summary>
    ''' 找尋員工等待輸入工號控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property WaitImputEmployeeNumberControlID() As String
        Get
            Return Me.ViewState("_WaitImputEmployeeNumberControl")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_WaitImputEmployeeNumberControl") = value
        End Set
    End Property

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
        If Not IsPostBack Then
            btStartDate.Text = Format(New Date(2001, 1, 1), "yyyy/MM/dd")
            btEndDate.Text = Format(New Date(Now.Year, 12, 31), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        Me.IsUserAlreadyPutSearch = False
        btStartDate.Text = Format(New Date(2001, 1, 1), "yyyy/MM/dd")
        btEndDate.Text = Format(New Date(Now.Year, 12, 31), "yyyy/MM/dd")
        tbAS301.Text = Nothing
        tbAS302.Text = Nothing
        tbAS306.Text = Nothing
        tbAS310.Text = Nothing
        tbAS311.Text = Nothing
        hfSearchSQLString.Value = Nothing
    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        hfSearchSQLString.Value = SearhSQLString
        Me.ListView1.DataBind()
    End Sub

    Protected Sub btnConvertToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConvertToExcel.Click
        Dim SearchResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SearhSQLString).SelectQuery
        With SearchResult
            .Columns("AS301").ColumnName = "財產編號"
            .Columns("AS302").ColumnName = "序號"
            .Columns("AS303").ColumnName = "請購憑證"
            .Columns("AS304").ColumnName = "入帳日(民國)"
            .Columns("AS305").ColumnName = "領料單"
            .Columns("AS306").ColumnName = "部門"
            .Columns("AS307").ColumnName = "數量"
            .Columns("AS308").ColumnName = "金額"
            .Columns("AS309").ColumnName = "年限"
            .Columns("AS310").ColumnName = "名稱說明"
            .Columns("AS311").ColumnName = "員工工號"
            .Columns("AS312").ColumnName = "狀態"
            .Columns.Add("員工姓名", GetType(String))
            .Columns.Remove(.Columns("AS391"))
            .Columns.Remove(.Columns("AS392"))
        End With
        '入帳日期格式變更及員工工號變更為員工姓名
        Dim SQLQuery1 As String = "Select PT0101,PT0102 From @#PLT500LB.PTM010PF"
        Dim QueryString As String = "Select PT0101,PT0102 From @#" & (New CompanyORMDB.PLT500LB.PTM010PF).CDBLibraryName & ".PTM010PF "
        Dim SelectedEemployees As List(Of CompanyORMDB.PLT500LB.PTM010PF) = ClassDBAS400.CDBSelect(Of CompanyORMDB.PLT500LB.PTM010PF)(QueryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        SearchResult.Columns("序號").DataType = GetType(String)
        For Each EachRow As DataRow In SearchResult.Rows
            With EachRow
                .Item("序號") = "=TEXT(" & CType(.Item("序號"), String) & ",""000"")"
                If CType(.Item("員工工號"), String).Trim.Length > 0 Then
                    Dim FindEmployeeObject As CompanyORMDB.PLT500LB.PTM010PF = (From A In SelectedEemployees Where A.PT0102 Like CType(.Item("員工工號"), String) & "*" Select A).FirstOrDefault
                    If Not IsNothing(FindEmployeeObject) Then
                        .Item("員工姓名") = FindEmployeeObject.PT0101
                    End If
                End If
                .Item("狀態") = AST103PF.GetAS312_Explain(CType(.Item("狀態"), String))
            End With

        Next

        Dim ExcelConvert As New DataConvertExcel(SearchResult, "非消耗物品" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile_V1(Me.Response)
    End Sub


    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Private Sub EmployeeSampleSearch1_UserCancelReturn(ByVal SenderControl As EmployeeSampleSearch) Handles EmployeeSampleSearch1.UserCancelReturn
        Me.MultiView1.SetActiveView(Me.View1)
    End Sub

    Private Sub EmployeeSampleSearch1_UserSelectedEmployee(ByVal SenderControl As EmployeeSampleSearch, ByVal SelectedEmployee As CompanyORMDB.PLT500LB.PTM010PF) Handles EmployeeSampleSearch1.UserSelectedEmployee
        Me.MultiView1.SetActiveView(Me.View1)
        If Not IsNothing(WaitImputEmployeeNumberControlID) Then
            Select Case True
                Case Not IsNothing(Me.FindControl(WaitImputEmployeeNumberControlID))
                    CType(Me.FindControl(WaitImputEmployeeNumberControlID), TextBox).Text = SelectedEmployee.PT0102
                Case Not IsNothing(Me.ListView1.InsertItem.FindControl(WaitImputEmployeeNumberControlID))
                    CType(Me.ListView1.InsertItem.FindControl(WaitImputEmployeeNumberControlID), TextBox).Text = SelectedEmployee.PT0102
                Case Not IsNothing(Me.ListView1.EditItem.FindControl(WaitImputEmployeeNumberControlID))
                    CType(Me.ListView1.EditItem.FindControl(WaitImputEmployeeNumberControlID), TextBox).Text = SelectedEmployee.PT0102
            End Select
        End If
    End Sub

    Protected Sub btnEmployeeSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEmployeeSearch.Click
        Me.WaitImputEmployeeNumberControlID = tbAS311.ID
        Me.MultiView1.SetActiveView(Me.View2)
    End Sub
    Protected Sub btnEmployeeSearch1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.WaitImputEmployeeNumberControlID = "AS311TextBox"
        Me.MultiView1.SetActiveView(Me.View2)
    End Sub
    Protected Sub btnEmployeeSearch2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.WaitImputEmployeeNumberControlID = "AS311TextBoxEdit"
        Me.MultiView1.SetActiveView(Me.View2)
    End Sub

End Class