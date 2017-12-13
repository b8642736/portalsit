Public Class GuestSues
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.BusinessDataContext

#Region "查看編修案件編號 屬性:WatchEditGuestSuesID"
    ''' <summary>
    ''' 查看編修案件編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WatchEditGuestSuesID() As String
        Get
            Return Me.ViewState("_WatchEditGuestSuesID")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_WatchEditGuestSuesID") = value
            GridView1.Visible = Not IsNothing(Me.ViewState("_WatchEditGuestSuesID"))
        End Set
    End Property
#End Region
#Region "案件所有子訊息 屬性:SubRecordsForGuestSuesID"
    ''' <summary>
    ''' 案件所有子訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SubRecordsForGuestSuesID(Optional ByVal SetGuestSuesID As Integer = 0) As List(Of CompanyLINQDB.GuestSues)
        Get
            If SetGuestSuesID > 0 Then
            End If
            Select Case True
                Case SetGuestSuesID > 0
                    Return (From A In DBDataContext.GuestSues Where A.ID = SetGuestSuesID Select A Order By A.SubRecordNumber).ToList
                Case Not String.IsNullOrEmpty(WatchEditGuestSuesID)
                    Return (From A In DBDataContext.GuestSues Where A.ID = WatchEditGuestSuesID Select A Order By A.SubRecordNumber).ToList
                Case Else
                    Return New List(Of CompanyLINQDB.GuestSues)
            End Select

        End Get

    End Property
#End Region

#Region "清除查詢條件 函式:ClearSearchCondiction"
    ''' <summary>
    ''' 清除查詢條件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearSearchCondiction()
        tbID.Text = Nothing
        tbCustomerID.Text = Nothing
        tbUndertaker.Text = Nothing
        ddCaseState.SelectedValue = "ALL"
        tbWindowLoginName.Text = Nothing
    End Sub
#End Region
#Region "登入使用者帳號 屬性:LoginUserAccount"
    ''' <summary>
    ''' 登入者帳號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property LoginUserAccount As String
        Get
            Dim GetValue() As String = My.User.Name.Split("\")
            If GetValue.Count = 0 Then
                Return Nothing
            End If
            Return GetValue(1).Trim
        End Get
    End Property
#End Region

#Region "新增一筆查看記錄 函式:ADDNewWatchRecord"
    ''' <summary>
    ''' 新增一筆查看記錄
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ADDNewWatchRecord()
        If String.IsNullOrEmpty(WatchEditGuestSuesID) Then
            Exit Sub
        End If
        Dim NewItem As New CompanyLINQDB.GuestSuesWatchRecord
        With NewItem
            .FK_GuestSuesID = WatchEditGuestSuesID
            .WatchTime = Now
            .WindowLoginName = My.User.Name
        End With
        DBDataContext.GuestSuesWatchRecord.InsertOnSubmit(NewItem)
        DBDataContext.SubmitChanges()
    End Sub
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
#Region "找尋員工等待輸入工號控制項 屬性:WaitImputCustomerControlID"
    ''' <summary>
    ''' 找尋員工等待輸入工號控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaitImputCustomerControlID() As String
        Get
            Return Me.ViewState("_WaitImputCustomerControlID")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_WaitImputCustomerControlID") = value
        End Set
    End Property

#End Region
#Region "指定處理狀態至第一筆資料之處理狀態 函式:SetProcessStateToFirstObject"
    ''' <summary>
    ''' 指定處理狀態至第一筆資料之處理狀態
    ''' </summary>
    ''' <param name="SetValueFromObject"></param>
    ''' <remarks></remarks>
    Private Sub SetProcessStateToFirstObject(ByVal SetValueFromObject As CompanyLINQDB.GuestSues)
        If IsNothing(SetValueFromObject) OrElse SetValueFromObject.SubRecordNumber = 1 Then
            Exit Sub
        End If
        Dim FindFirstObject As CompanyLINQDB.GuestSues = (From A In DBDataContext.GuestSues Where A.ID = SetValueFromObject.ID Select A Order By A.SubRecordNumber).FirstOrDefault
        If IsNothing(FindFirstObject) Then
            Exit Sub
        End If
        FindFirstObject.ProcessState = SetValueFromObject.ProcessState
        DBDataContext.SubmitChanges()
    End Sub

#End Region

#Region "資料新增前之錯誤資料 InsertFailData"
    ''' <summary>
    ''' 資料新增前之錯誤資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InsertFailData() As CompanyLINQDB.GuestSues
        Get
            Return Me.ViewState("_InsertFailData")
        End Get
        Set(ByVal value As CompanyLINQDB.GuestSues)
            Me.ViewState("_InsertFailData") = value
        End Set
    End Property
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now.AddDays(-3), "yyyy/MM/dd")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Private Sub ldsSearchResult_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceStatusEventArgs) Handles ldsSearchResult.Inserted, ldsSearchResult.Updated, ldsSearchResult.Deleted
        SetProcessStateToFirstObject(e.Result)
    End Sub

    Private Sub ldsSearchResult_Deleteed(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceStatusEventArgs) Handles ldsSearchResult.Deleted
        Dim GetLastIDSubData As CompanyLINQDB.GuestSues = (From A In DBDataContext.GuestSues Where A.ID = CType(e.Result, CompanyLINQDB.GuestSues).ID Select A Order By A.SubRecordNumber Descending).FirstOrDefault
        SetProcessStateToFirstObject(GetLastIDSubData)
        If IsNothing(GetLastIDSubData) Then
            WatchEditGuestSuesID = Nothing
            DBDataContext.GuestSuesWatchRecord.DeleteAllOnSubmit(From A In DBDataContext.GuestSuesWatchRecord Where A.FK_GuestSuesID = CType(e.Result, CompanyLINQDB.GuestSues).ID Select A)
            DBDataContext.SubmitChanges()
        End If
    End Sub

    Private Sub ldsSearchResult_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceInsertEventArgs) Handles ldsSearchResult.Inserting
        Dim InsertItem As CompanyLINQDB.GuestSues = e.NewObject
        CType(Me.ListView1.FindControl("lbMessage"), Label).Text = Nothing
        Dim GetErrorMessage As String = InsertItem.VaildDataIsHaveError
        If Not String.IsNullOrEmpty(GetErrorMessage) Then
            CType(Me.ListView1.FindControl("lbMessage"), Label).Text = GetErrorMessage
            InsertFailData = InsertItem
            e.Cancel = True
            Exit Sub
        End If
        InsertFailData = Nothing
        With InsertItem
            If String.IsNullOrEmpty(WatchEditGuestSuesID) Then
                .ID = CompanyLINQDB.GuestSues.GetNewInsertDataID
            Else
                .ID = WatchEditGuestSuesID
            End If
            .SubRecordNumber = CompanyLINQDB.GuestSues.GetNewInsertDataSubRecordNumber(.ID)
            '.ProcessState = CType(ListView1.InsertItem.FindControl("DropDownList1"), DropDownList).SelectedValue
            .RecordTime = Now
            .WindowLoginName = My.User.Name
        End With
    End Sub

    Private Sub ldsSearchResult_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceUpdateEventArgs) Handles ldsSearchResult.Updating
        Dim UpdateItem As CompanyLINQDB.GuestSues = e.NewObject
        CType(Me.ListView1.FindControl("lbMessage"), Label).Text = Nothing
        Dim GetErrorMessage As String = UpdateItem.VaildDataIsHaveError
        If Not String.IsNullOrEmpty(GetErrorMessage) Then
            CType(Me.ListView1.FindControl("lbMessage"), Label).Text = GetErrorMessage
            e.Cancel = True : Exit Sub
        End If
        With UpdateItem
            '.ProcessState = CType(ListView1.EditItem.FindControl("DropDownList1"), DropDownList).SelectedValue
            .RecordTime = Now
            .WindowLoginName = My.User.Name
        End With

    End Sub

    Private Sub ListView1_ItemCanceling(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCancelEventArgs) Handles ListView1.ItemCanceling
        Me.InsertFailData = Nothing
    End Sub

    Private Sub ListView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles ListView1.ItemCommand
        If e.CommandName = "DetailEdit" Then
            WatchEditGuestSuesID = CType(e.Item.FindControl("IDLabel"), Label).Text
            ListView1.DataBind()
            ADDNewWatchRecord()
            GridView1.DataBind()
        End If
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        Dim InsertItemCustomerIDTextBox As TextBox = ListView1.InsertItem.FindControl("CustomerIDTextBox")
        Dim InsertItemContectHumanTextBox As TextBox = ListView1.InsertItem.FindControl("ContectHumanTextBox")
        Dim InsertItemCustomerSearchButton As Button = ListView1.InsertItem.FindControl("btnCustomerSearch1")
        Dim EditButton As Button = Nothing
        Dim DeleteButton As Button = Nothing

        If String.IsNullOrEmpty(WatchEditGuestSuesID) Then
            '案件查詢/編修模式
            Me.MultiView1.SetActiveView(View1)
            'InsertItemCustomerIDTextBox.Text = Nothing
            InsertItemCustomerIDTextBox.Enabled = True
            InsertItemCustomerSearchButton.Enabled = InsertItemCustomerIDTextBox.Enabled
            CType(Me.ListView1.InsertItem.FindControl("lbID"), Label).Text = "(系統產生)"
            For Each EachItem As ListViewDataItem In ListView1.Items
                EditButton = EachItem.FindControl("EditButton")
                DeleteButton = EachItem.FindControl("DeleteButton")
                '只有本人產生之資料與最新一筆產生之資料才可修改或刪除
                If Not IsNothing(EditButton) Then
                    EditButton.Enabled = False
                    DeleteButton.Enabled = False
                    Dim EachItemWindowLoginName As String = CType(EachItem.FindControl("HFWindowLoginName"), HiddenField).Value
                    If EachItemWindowLoginName.Trim <> My.User.Name.Trim Then
                        Continue For
                    End If
                    Dim EachItemGuestSuesID As String = CType(EachItem.FindControl("IDLabel"), Label).Text
                    Dim EachItemSubRecordNumber As String = CType(EachItem.FindControl("SubRecordNumberLabel"), Label).Text
                    Dim EachItemLastGuestSuesForID As CompanyLINQDB.GuestSues = (From A In SubRecordsForGuestSuesID(Val(EachItemGuestSuesID)) Select A Order By A.SubRecordNumber Descending).FirstOrDefault
                    If Not IsNothing(EachItemLastGuestSuesForID) AndAlso EachItemLastGuestSuesForID.SubRecordNumber = EachItemSubRecordNumber Then
                        EditButton.Enabled = True
                        DeleteButton.Enabled = True
                    End If
                End If
            Next
        Else
            '案件細項查詢/編修模式
            Me.MultiView1.SetActiveView(View2)
            Dim LastSubRecordForID As CompanyLINQDB.GuestSues = CompanyLINQDB.GuestSues.GetLastSubRecordForID(WatchEditGuestSuesID)
            InsertItemCustomerIDTextBox.Text = LastSubRecordForID.CustomerID
            InsertItemCustomerIDTextBox.Enabled = False
            InsertItemCustomerSearchButton.Enabled = InsertItemCustomerIDTextBox.Enabled
            InsertItemContectHumanTextBox.Text = LastSubRecordForID.ContectHuman
            CType(Me.ListView1.InsertItem.FindControl("lbID"), Label).Text = WatchEditGuestSuesID
            For Each EachItem As ListViewDataItem In ListView1.Items
                Dim DetailLookEditButton As Button = EachItem.FindControl("tbDetailLookEdit")
                If Not IsNothing(DetailLookEditButton) Then
                    DetailLookEditButton.Visible = False
                End If
                EditButton = EachItem.FindControl("EditButton")
                DeleteButton = EachItem.FindControl("DeleteButton")
                '只有本人產生之資料與最新一筆產生之資料才可修改或刪除
                If Not IsNothing(EditButton) Then
                    EditButton.Enabled = False
                    DeleteButton.Enabled = False
                    Dim EachItemWindowLoginName As String = CType(EachItem.FindControl("HFWindowLoginName"), HiddenField).Value
                    If EachItemWindowLoginName.Trim <> My.User.Name.Trim Then
                        Continue For
                    End If
                    Dim EachItemGuestSuesID As String = CType(EachItem.FindControl("IDLabel"), Label).Text
                    Dim EachItemSubRecordNumber As String = CType(EachItem.FindControl("SubRecordNumberLabel"), Label).Text
                    Dim EachItemLastGuestSuesForID As CompanyLINQDB.GuestSues = (From A In SubRecordsForGuestSuesID(Val(EachItemGuestSuesID)) Select A Order By A.SubRecordNumber Descending).FirstOrDefault
                    If Not IsNothing(EachItemLastGuestSuesForID) AndAlso EachItemLastGuestSuesForID.SubRecordNumber = EachItemSubRecordNumber Then
                        EditButton.Enabled = True
                        DeleteButton.Enabled = True
                    End If
                End If
            Next
        End If

        If Not IsNothing(InsertFailData) Then
            CType(ListView1.InsertItem.FindControl("CustomerIDTextBox"), TextBox).Text = InsertFailData.CustomerID
            CType(ListView1.InsertItem.FindControl("ContectHumanTextBox"), TextBox).Text = InsertFailData.ContectHuman
            CType(ListView1.InsertItem.FindControl("UndertakerTextBox"), TextBox).Text = InsertFailData.Undertaker
            CType(ListView1.InsertItem.FindControl("DropDownList1"), DropDownList).SelectedValue = InsertFailData.ProcessState
            CType(ListView1.InsertItem.FindControl("DescribeTextBox"), TextBox).Text = InsertFailData.Describe
        End If

    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        Dim SearchResult As IQueryable(Of CompanyLINQDB.GuestSues) = From A In DBDataContext.GuestSues Select A
        If Not String.IsNullOrEmpty(WatchEditGuestSuesID) Then
            e.Result = SubRecordsForGuestSuesID ' From A In SearchResult Where A.ID = WatchEditGuestSuesID Select A
            Exit Sub
        End If

        SearchResult = From A In SearchResult Where A.SubRecordNumber = 1 Select A
        If ddCaseState.SelectedValue <> "ALL" Then
            SearchResult = From A In SearchResult Where A.ProcessState = ddCaseState.SelectedValue Select A
        End If
        If Not String.IsNullOrEmpty(tbID.Text) AndAlso tbID.Text.Trim.Length > 0 Then
            SearchResult = From A In SearchResult Where A.ID = tbID.Text.Trim Select A
        End If
        If Not String.IsNullOrEmpty(tbCustomerID.Text) AndAlso tbCustomerID.Text.Trim.Length > 0 Then
            SearchResult = From A In SearchResult Where A.CustomerID = tbCustomerID.Text.Trim Select A
        End If
        If Not String.IsNullOrEmpty(tbUndertaker.Text) AndAlso tbUndertaker.Text.Trim.Length > 0 Then
            SearchResult = From A In SearchResult Where A.Undertaker Like "*" & tbUndertaker.Text.Trim & "*" Select A
        End If
        If cbRecordTime.Checked Then
            SearchResult = From A In SearchResult Where A.RecordTime >= CType(tbStartDate.Text, Date) And A.RecordTime <= CType(tbEndDate.Text, Date).AddDays(1).AddSeconds(-1) Select A
        End If
        If Not String.IsNullOrEmpty(tbWindowLoginName.Text) AndAlso tbWindowLoginName.Text.Trim.Length > 0 Then
            SearchResult = From A In SearchResult Where A.WindowLoginName Like "*" & tbWindowLoginName.Text.Trim & "*" Select A
        End If
        If CBOverTime.Checked Then
            SearchResult = From A In SearchResult Where Now > A.RecordTime.Value.AddDays(Val(tbOverDays.Text)).AddHours(Val(tbOverHours.Text)) Select A
        End If
        e.Result = SearchResult
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        ListView1.DataBind()
    End Sub

    Protected Sub btnClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearchCondiction.Click
        tbID.Text = Nothing
        tbCustomerID.Text = Nothing
        tbWindowLoginName.Text = Nothing
        tbUndertaker.Text = Nothing
        ddCaseState.SelectedValue = "ALL"
    End Sub

    Protected Sub btnBackSearchForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackSearchForm.Click
        WatchEditGuestSuesID = Nothing
        ListView1.DataBind()
    End Sub

    Private Sub EmployeeSampleSearch1_UserCancelReturn(ByVal SenderControl As EmployeeSampleSearch) Handles EmployeeSampleSearch1.UserCancelReturn
        Me.MultiView1.Visible = True
        Me.MultiView2.SetActiveView(Me.MV2View1)
    End Sub

    Private Sub CustomerSearch1_UserCancelReturn(ByVal SenderControl As CustomerSearch) Handles CustomerSearch1.UserCancelReturn
        Me.MultiView1.Visible = True
        Me.MultiView2.SetActiveView(Me.MV2View1)
    End Sub

    Private Sub EmployeeSampleSearch1_UserSelectedEmployee(ByVal SenderControl As EmployeeSampleSearch, ByVal SelectedEmployee As CompanyORMDB.PLT500LB.PTM010PF) Handles EmployeeSampleSearch1.UserSelectedEmployee
        Me.MultiView1.Visible = True
        Me.MultiView2.SetActiveView(Me.MV2View1)
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

    Private Sub CustomerSearch1_UserSelectedCustomer(ByVal SenderControl As CustomerSearch, ByVal SelectedSL2CUAPF As CompanyORMDB.SLS300LB.SL2CUAPF) Handles CustomerSearch1.UserSelectedCustomer
        InsertFailData = Nothing
        Me.MultiView1.Visible = True
        Me.MultiView2.SetActiveView(Me.MV2View1)
        If Not IsNothing(WaitImputCustomerControlID) Then
            Select Case True
                Case Not IsNothing(Me.FindControl(WaitImputCustomerControlID))
                    CType(Me.FindControl(WaitImputCustomerControlID), TextBox).Text = SelectedSL2CUAPF.CUA01
                Case Not IsNothing(Me.ListView1.InsertItem.FindControl(WaitImputCustomerControlID))
                    CType(Me.ListView1.InsertItem.FindControl(WaitImputCustomerControlID), TextBox).Text = SelectedSL2CUAPF.CUA01
            End Select
        End If
    End Sub


    Protected Sub btnEmployeeSearch1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.WaitImputEmployeeNumberControlID = "UndertakerTextBox"
        Me.MultiView1.Visible = False
        Me.MultiView2.SetActiveView(Me.MV2View2)
    End Sub

    Protected Sub btnEmployeeSearch2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.WaitImputEmployeeNumberControlID = "UndertakerTextBoxEdit"
        Me.MultiView1.Visible = False
        Me.MultiView2.SetActiveView(Me.MV2View2)
    End Sub

    Protected Sub btnCustomerSearch1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.WaitImputCustomerControlID = "CustomerIDTextBox"
        Me.MultiView1.Visible = False
        Me.MultiView2.SetActiveView(Me.MV2View3)
    End Sub

    Protected Sub ldsDetailWatchUsers_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsDetailWatchUsers.Selecting
        If String.IsNullOrEmpty(WatchEditGuestSuesID) Then
            e.Cancel = True
        End If
        e.Result = From A In DBDataContext.GuestSuesWatchRecord Where A.FK_GuestSuesID = WatchEditGuestSuesID Select A Order By A.WatchTime Descending
    End Sub

    Protected Sub btnCustomerSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCustomerSearch.Click
        Me.WaitImputCustomerControlID = "tbCustomerID"
        Me.MultiView1.Visible = False
        Me.MultiView2.SetActiveView(Me.MV2View3)
    End Sub

    Protected Sub btnEmployeeSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEmployeeSearch.Click
        Me.WaitImputEmployeeNumberControlID = "tbUndertaker"
        Me.MultiView1.Visible = False
        Me.MultiView2.SetActiveView(Me.MV2View2)
    End Sub

End Class