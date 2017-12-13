Public Partial Class CheckTicketMake
    Inherits System.Web.UI.UserControl


    Dim DBDataContext As New CompanyLINQDB.PCashDataContext

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

#Region "初始化查詢條件 函式:InitSearchCondiction"
    ''' <summary>
    ''' 初始化查詢條件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitSearchCondiction()
        Me.TextBox1.Text = Format(New DateTime(Now.Year, 1, 1), "yyyy")
        Me.TextBox2.Text = 1
        Me.TextBox3.Text = 9999
        Me.RadioButtonList1.Items(0).Selected = True

    End Sub
#End Region
#Region "批次處理核銷或返核銷 函式BatchYesOrNoVerification"
    ''' <summary>
    ''' 批次處理核銷或返核銷
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BatchYesOrNoVerification(ByVal IsYesVerification As Boolean, ByVal SetVerificationKind As VerificationKind)
        If Me.FormView2.CurrentMode <> FormViewMode.ReadOnly Then
            FormView2.ChangeMode(FormViewMode.ReadOnly)
        End If
        Dim CurrentPC2RecDate As DateTime = CType(CType(Me.FormView2.FindControl("RecDateLabel"), Label).Text, DateTime)
        Dim CurrentPC2Number As Integer = CType(CType(Me.FormView2.FindControl("NumberLabel"), Label).Text, Integer)
        Dim RecDate As DateTime = CType(CType(CType(FormView2, FormView).FindControl("RecDateLabel"), Label).Text, DateTime)
        Dim StartDateTime As DateTime = CType(TextBox4.Text, DateTime)
        Dim EndDateTime As DateTime = CType(TextBox5.Text, DateTime).AddDays(1).AddSeconds(-1)
        Dim MinDatetime As DateTime = New DateTime(RecDate.Year, 1, 1)
        Dim MaxDatetime As DateTime = New DateTime(RecDate.Year, 1, 1).AddYears(1).AddSeconds(-1)
        StartDateTime = IIf(StartDateTime < MinDatetime, MinDatetime, StartDateTime)
        StartDateTime = IIf(StartDateTime > MaxDatetime, MaxDatetime, StartDateTime)
        EndDateTime = IIf(EndDateTime < MinDatetime, MinDatetime, EndDateTime)
        EndDateTime = IIf(EndDateTime > MaxDatetime, MaxDatetime, EndDateTime)
        Dim ProcessRecordCount As Integer = 0
        Select Case SetVerificationKind
            Case VerificationKind.DateRange
                If IsYesVerification Then
                    For Each EachItem As PCash1 In From A In DBDataContext.PCash1 Where Not (From B In DBDataContext.PCash3 Select B.PC1RecDate.ToString & B.PC1Number.ToString).Contains(A.RecDate.ToString & A.Number.ToString) And A.RecDate >= StartDateTime And A.RecDate <= EndDateTime Select A
                        Dim AddItem As New PCash3
                        With AddItem
                            .PC1RecDate = EachItem.RecDate
                            .PC1Number = EachItem.Number
                            .PC2RecDate = CurrentPC2RecDate
                            .PC2Number = CurrentPC2Number
                        End With
                        Me.DBDataContext.PCash3.InsertOnSubmit(AddItem) : ProcessRecordCount += 1
                    Next
                Else
                    For Each EachItem As PCash3 In From A In DBDataContext.PCash3 Where A.PC2RecDate = CurrentPC2RecDate And A.PC2Number = CurrentPC2Number And A.PC1RecDate >= StartDateTime And A.PC1RecDate <= EndDateTime Select A
                        Me.DBDataContext.PCash3.DeleteOnSubmit(EachItem) : ProcessRecordCount += 1
                    Next
                End If
            Case VerificationKind.NumberRange
                If IsYesVerification Then
                    For Each EachItem As PCash1 In From A In DBDataContext.PCash1 Where Not (From B In DBDataContext.PCash3 Select B.PC1RecDate.ToString & B.PC1Number.ToString).Contains(A.RecDate.ToString & A.Number.ToString) And A.RecDate >= MinDatetime And A.RecDate <= MaxDatetime And A.Number >= Val(TextBox6.Text) And A.Number <= Val(TextBox7.Text) Select A
                        Dim AddItem As New PCash3
                        With AddItem
                            .PC1RecDate = EachItem.RecDate
                            .PC1Number = EachItem.Number
                            .PC2RecDate = CurrentPC2RecDate
                            .PC2Number = CurrentPC2Number
                        End With
                        Me.DBDataContext.PCash3.InsertOnSubmit(AddItem) : ProcessRecordCount += 1
                    Next
                Else
                    For Each EachItem As PCash3 In From A In DBDataContext.PCash3 Where A.PC2RecDate = CurrentPC2RecDate And A.PC2Number = CurrentPC2Number And A.PC1Number >= Val(TextBox6.Text) And A.PC1Number <= Val(TextBox7.Text) Select A
                        Me.DBDataContext.PCash3.DeleteOnSubmit(EachItem) : ProcessRecordCount += 1
                    Next
                End If
        End Select
        Try
            Me.DBDataContext.SubmitChanges()
            lbMessage.Text = IIf(IsYesVerification, "核銷", "取消核銷") & "成功:合計處理資料 " & ProcessRecordCount & " 筆"
        Catch ex As Exception
            lbMessage.Text = "發生錯誤:" & ex.ToString
        End Try
    End Sub

    Private Enum VerificationKind
        DateRange = 0
        NumberRange = 1
    End Enum

#End Region
#Region "Formview2最後下的指令 屬性:Formview2LastComandName"

    Private _Formview2LastComandName As String = ""
    ''' <summary>
    ''' Formview2最後下的指令
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Formview2LastComandName() As String
        Get
            Return _Formview2LastComandName
        End Get
        Set(ByVal value As String)
            _Formview2LastComandName = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitSearchCondiction()
            '初始化批之核銷項目欄位
            TextBox4.Text = Format(New DateTime(Now.Year, 1, 1), "yyyy/MM/dd")
            TextBox5.Text = Format(New DateTime(Now.Year, 12, 31), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        InitSearchCondiction()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        If Me.FormView2.CurrentMode <> FormViewMode.ReadOnly Then
            FormView2.ChangeMode(FormViewMode.ReadOnly)
        End If
        IsUserAlreadyPutSearch = True
        Me.FormView2.DataBind()
    End Sub

    Protected Sub LDSSearchReslut_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchReslut.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.PCash2) = (From A In DBDataContext.PCash2 Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.RecDate >= New DateTime(TextBox1.Text, 1, 1) And A.RecDate <= New DateTime(TextBox1.Text, 1, 1).AddYears(1).AddSeconds(-1) Select A)
        Result = From A In Result Where A.Number >= Val(TextBox2.Text) And A.Number <= Val(TextBox3.Text) Select A
        Result = IIf(Me.RadioButtonList1.SelectedValue = "0", Result, From A In Result Where A.IsToCashed = (Me.RadioButtonList1.SelectedValue = "1") Select A Order By A.TicketNumber, A.RecDate)
        e.Result = Result
    End Sub

    Protected Sub LDSWaitTicketToCash_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWaitTicketToCash.Selecting
        If FormView2.DataKey.Values.Count = 0 OrElse FormView2.CurrentMode <> FormViewMode.ReadOnly OrElse CType(Me.FormView2.FindControl("IsNewYearStartTicketCheckBox"), CheckBox).Checked = True Then
            e.Cancel = True
            Exit Sub
        End If
        Dim SubSearch As IQueryable(Of CompanyLINQDB.PCash3) = From A In DBDataContext.PCash3 Where A.PC2RecDate = CType(FormView2.DataKey.Values(0), DateTime) And A.PC2Number = CType(FormView2.DataKey.Values(1), Integer) Select A
        Dim Result As IQueryable(Of CompanyLINQDB.PCash1) = From A In DBDataContext.PCash1, B In SubSearch Where A.RecDate = B.PC1RecDate And A.Number = B.PC1Number Select A
        Me.TabPanel1.HeaderText = "已核銷項目(" & Result.Count & ")"
        e.Result = Result
    End Sub

    Protected Sub LDSTicketToCash_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSTicketToCash.Selecting
        If FormView2.DataKey.Values.Count = 0 OrElse FormView2.CurrentMode <> FormViewMode.ReadOnly OrElse CType(Me.FormView2.FindControl("IsNewYearStartTicketCheckBox"), CheckBox).Checked = True Then
            e.Cancel = True
            Exit Sub
        End If
        Dim RecDate As DateTime = CType(Me.FormView2.DataKey(0), DateTime)
        Dim StartDateTime As DateTime = New DateTime(RecDate.Year, 1, 1)
        Dim EndDateTime As DateTime = New DateTime(RecDate.Year, 1, 1).AddYears(1).AddSeconds(-1)

        Dim Result As IQueryable(Of CompanyLINQDB.PCash1) = From A In DBDataContext.PCash1 Where Not (From B In DBDataContext.PCash3 Select B.PC1RecDate.ToString & B.PC1Number.ToString).Contains(A.RecDate.ToString & A.Number.ToString) And A.RecDate >= StartDateTime And A.RecDate <= EndDateTime Select A
        Me.TabPanel2.HeaderText = "待核銷項目(" & Result.Count & ")"
        e.Result = Result
    End Sub

    Private Sub FormView2_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView2.ItemCommand
        '判斷是否為啟始支票如果是,則移除所有已核銷項目

        If e.CommandName.ToUpper = "UPDATE" AndAlso FormView2.CurrentMode = FormViewMode.Edit AndAlso CType(Me.FormView2.FindControl("IsNewYearStartTicketCheckBox"), CheckBox).Checked Then
            Me.DBDataContext.PCash3.DeleteAllOnSubmit(From A In DBDataContext.PCash3 Where A.PC2RecDate = CType(Me.FormView2.DataKey(0), DateTime) And A.PC2Number = CType(Me.FormView2.DataKey(1), Integer) Select A)
            Me.DBDataContext.SubmitChanges()
        End If
        If e.CommandName.ToUpper = "DELETE" Then
            Me.DBDataContext.PCash3.DeleteAllOnSubmit(From A In DBDataContext.PCash3 Where A.PC2RecDate = CType(Me.FormView2.DataKey(0), DateTime) And A.PC2Number = CType(Me.FormView2.DataKey(1), Integer) Select A)
            Me.DBDataContext.SubmitChanges()
        End If
        If e.CommandName.ToUpper = "UPDATE" Then
            CType(Me.FormView2.FindControl("SaveTimeTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd hh:mm:ss")
        End If
        Formview2LastComandName = e.CommandName
    End Sub

    Private Sub FormView2_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView2.PageIndexChanged
    End Sub

    Private Sub FormView2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView2.PreRender

        Select Case True
            Case FormView2.CurrentMode = FormViewMode.Insert AndAlso CType(Me.FormView2.FindControl("RecDateTextBox"), TextBox).Text.Trim.Length = 0
                CType(Me.FormView2.FindControl("RecDateTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd")
                Dim InsertDateTimeYear As DateTime = New DateTime(CType(CType(Me.FormView2.FindControl("RecDateTextBox"), TextBox).Text, DateTime).Year, 1, 1)
                Dim GetLastNumber As Integer = (From A In DBDataContext.PCash2 Where A.RecDate >= InsertDateTimeYear And A.RecDate < InsertDateTimeYear.AddYears(1) Select A.Number Order By Number Descending).FirstOrDefault
                CType(Me.FormView2.FindControl("NumberTextBox"), TextBox).Text = IIf(GetLastNumber = 0, 1, GetLastNumber + 1)
                CType(Me.FormView2.FindControl("SaveTimeTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd hh:mm:ss")
                CType(Me.FormView2.FindControl("NewYearStartMoneyTextBox"), TextBox).Text = 0
                CType(Me.FormView2.FindControl("ToCashDateTimeTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd")
            Case Not IsNothing(Formview2LastComandName) AndAlso Formview2LastComandName.ToUpper = "INSERT"
                Me.FormView2.PageIndex = Me.FormView2.DataItemCount - 1
        End Select

        GridView1.DataBind()
        GridView2.DataBind()
        Me.TabContainer1.Visible = (FormView2.DataKey.Values.Count > 0) AndAlso FormView2.CurrentMode = FormViewMode.ReadOnly AndAlso CType(Me.FormView2.FindControl("IsNewYearStartTicketCheckBox"), CheckBox).Checked = False
        Me.UpdatePanel2.Update()
    End Sub

    Protected Sub IsNewYearStartTicketCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim StartMoneyControl As TextBox = Me.FormView2.FindControl("NewYearStartMoneyTextBox")
        StartMoneyControl.Enabled = CType(Me.FormView2.FindControl("IsNewYearStartTicketCheckBox"), CheckBox).Checked
        If StartMoneyControl.Enabled Then
            StartMoneyControl.Text = 0
        End If
    End Sub

    Protected Sub IsToCashedCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim ToCashControl As TextBox = Me.FormView2.FindControl("ToCashDateTimeTextBox")
        ToCashControl.Enabled = CType(Me.FormView2.FindControl("IsToCashedCheckBox"), CheckBox).Checked
        If ToCashControl.Enabled Then
            ToCashControl.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        If Me.FormView2.CurrentMode <> FormViewMode.ReadOnly Then
            FormView2.ChangeMode(FormViewMode.ReadOnly)
        End If
        Dim NewRecord As New PCash3
        With NewRecord
            .PC1RecDate = CType(GridView2.SelectedDataKey.Item(0), DateTime)
            .PC1Number = CType(GridView2.SelectedDataKey.Item(1), Integer)
            .PC2RecDate = CType(Me.FormView2.DataKey(0), DateTime)
            .PC2Number = CType(Me.FormView2.DataKey(1), Integer)
        End With
        DBDataContext.PCash3.InsertOnSubmit(NewRecord)
        DBDataContext.SubmitChanges()
        GridView1.DataBind()
        GridView2.DataBind()
        UpdatePanel2.Update()
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        If Me.FormView2.CurrentMode <> FormViewMode.ReadOnly Then
            FormView2.ChangeMode(FormViewMode.ReadOnly)
        End If
        Dim Value1 As DateTime = CType(GridView1.SelectedDataKey.Item(0), DateTime)
        Dim Value2 As Integer = CType(GridView1.SelectedDataKey.Item(1), Integer)
        Dim Value3 As DateTime = CType(Me.FormView2.DataKey(0), DateTime)
        Dim Value4 As Integer = CType(Me.FormView2.DataKey(1), Integer)
        Dim FindRecord As PCash3 = (From A In DBDataContext.PCash3 Where A.PC1RecDate = Value1 And A.PC1Number = Value2 And A.PC2RecDate = Value3 And A.PC2Number = Value4 Select A).FirstOrDefault
        If Not IsNothing(FindRecord) Then
            DBDataContext.PCash3.DeleteOnSubmit(FindRecord)
            DBDataContext.SubmitChanges()
            GridView1.DataBind()
            GridView2.DataBind()
            UpdatePanel2.Update()
        End If
    End Sub

    Protected Sub IsNewYearStartTicketCheckBox_CheckedChanged1(ByVal sender As Object, ByVal e As EventArgs)
        Dim ToCashControl As TextBox = Me.FormView2.FindControl("NewYearStartMoneyTextBox")
        ToCashControl.Enabled = CType(Me.FormView2.FindControl("IsNewYearStartTicketCheckBox"), CheckBox).Checked
    End Sub

    Protected Sub IsToCashedCheckBox_CheckedChanged1(ByVal sender As Object, ByVal e As EventArgs)
        Dim ToCashControl As TextBox = Me.FormView2.FindControl("ToCashDateTimeTextBox")
        ToCashControl.Enabled = CType(Me.FormView2.FindControl("IsToCashedCheckBox"), CheckBox).Checked
        If ToCashControl.Enabled Then
            ToCashControl.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnBatchP1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBatchP1.Click
        BatchYesOrNoVerification(True, VerificationKind.DateRange)  '批次日期核銷
    End Sub

    Protected Sub btnBatchC1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBatchC1.Click
        BatchYesOrNoVerification(False, VerificationKind.DateRange) '批次日期反核銷
    End Sub

    Protected Sub btnBatchP2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBatchP2.Click
        BatchYesOrNoVerification(True, VerificationKind.NumberRange)  '批次號數核銷
    End Sub

    Protected Sub btnBatchC2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBatchC2.Click
        BatchYesOrNoVerification(False, VerificationKind.NumberRange)  '批次號數反核銷
    End Sub

End Class