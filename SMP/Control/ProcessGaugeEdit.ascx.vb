Public Partial Class ProcessGaugeEdit
    Inherits System.Web.UI.UserControl


    Dim DBDataContext As New CompanyLINQDB.SMPDataContext

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

#Region "設定欄位初始值 屬性:SetDataDefaultValue"
    ''' <summary>
    ''' 設定欄位初始值
    ''' </summary>
    ''' <param name="FromControl"></param>
    ''' <param name="IsUPLimit"></param>
    ''' <remarks></remarks>
    Private Sub SetDataDefaultValue(ByVal FromControl As FormView, ByVal IsUPLimit As Boolean, Optional ByVal IsInsertInitial As Boolean = False)
        If IsInsertInitial Then
            CType(FromControl.FindControl("鋼種TextBox"), TextBox).Text = "304"
            CType(FromControl.FindControl("材質TextBox"), TextBox).Text = "TE1"
            CType(FromControl.FindControl("站別TextBox"), TextBox).Text = "E1"
            CType(FromControl.FindControl("序號TextBox"), TextBox).Text = "1"
            CType(FromControl.FindControl("DropDownList1"), DropDownList).SelectedValue = IIf(IsUPLimit, "H", "L")
        End If
        CType(FromControl.FindControl("DFTextBox"), TextBox).Text = IIf(IsUPLimit, "99.0", "0")
        CType(FromControl.FindControl("MD30TextBox"), TextBox).Text = IIf(IsUPLimit, "99.0", "0")
        CType(FromControl.FindControl("CTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("SiTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("MnTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("PTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("STextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("CrTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("NiTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("CuTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("MoTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("CoTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("ALTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("SnTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("PbTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("TiTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("NbTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("VTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("WTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("O2TextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("N2TextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("H2TextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("BTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("CaTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("MgTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("FeTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("N1TextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("O1TextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("C2TextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("S2TextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")


        CType(FromControl.FindControl("AsTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("BiTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("SbTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("ZnTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("ZrTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("GPTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("TaTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("CAndNTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")
        CType(FromControl.FindControl("NbAndTaTextBox"), TextBox).Text = IIf(IsUPLimit, "99", "0")

        CType(FromControl.FindControl("最後更新時間TextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd hh:mm:ss")
        CType(FromControl.FindControl("更新來源IPTextBox"), TextBox).Text = IIf(Me.Request.UserHostAddress = "::1", "127.0.0.1", Me.Request.UserHostAddress)
    End Sub
#End Region

    Dim IsInsertModeJustChanged As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        Me.RadioButtonList1.SelectedIndex = 0
    End Sub

    Protected Sub LDSEditDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSEditDataSource.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.製程判定) = (From A In DBDataContext.製程判定 Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox4.Text), Result, From A In Result Where A.鋼種.Contains(TextBox4.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.材質.Contains(TextBox1.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.站別.Contains(TextBox2.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox3.Text), Result, From A In Result Where A.序號 = Val(TextBox3.Text.Trim) Select A)
        If Me.RadioButtonList1.SelectedValue = "H" OrElse Me.RadioButtonList1.SelectedValue = "L" Then
            Result = From A In Result Where A.上下限 = Me.RadioButtonList1.SelectedValue.ToString Select A
        End If
        e.Result = Result
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.FormView1.DataBind()
    End Sub

    Private Sub FormView1_ModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ModeChanged
        If FormView1.CurrentMode = FormViewMode.Insert Then
            IsInsertModeJustChanged = True
        End If
    End Sub

    Private Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
        If IsInsertModeJustChanged AndAlso FormView1.CurrentMode = FormViewMode.Insert Then
            SetDataDefaultValue(Me.FormView1, CType(FormView1.FindControl("DropDownList1"), DropDownList).SelectedValue = "H", True)
        End If
    End Sub

    Protected Sub UpdateButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        CType(Me.FormView1.FindControl("最後更新時間TextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd hh:mm:ss")
        CType(Me.FormView1.FindControl("更新來源IPTextBox"), TextBox).Text = IIf(Me.Request.UserHostAddress = "::1", "127.0.0.1", Me.Request.UserHostAddress)
        Dim GetEmployeeNumber As String = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
        CType(Me.FormView1.FindControl("更新者TextBox"), TextBox).Text = IIf(IsNothing(GetEmployeeNumber), "(未知)", GetEmployeeNumber)
    End Sub

    Protected Sub InsertButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Call UpdateButton_Click(sender, e)
    End Sub

    Protected Sub CustomValidatorAllPK_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim Value1 As String = CType(Me.FormView1.FindControl("鋼種TextBox"), TextBox).Text
        Dim Value2 As String = CType(Me.FormView1.FindControl("材質TextBox"), TextBox).Text
        Dim Value3 As String = CType(Me.FormView1.FindControl("站別TextBox"), TextBox).Text
        Dim Value4 As Integer = (CType(Me.FormView1.FindControl("序號TextBox"), TextBox).Text)
        Dim Value5 As String = CType(Me.FormView1.FindControl("DropDownList1"), DropDownList).SelectedValue
        Dim ValidControl As CustomValidator = Me.FormView1.FindControl("CustomValidatorAllPK")

        args.IsValid = Not (From A In DBDataContext.製程判定 Where A.鋼種 = Value1 And A.材質 = Value2 And A.站別 = Value3 And A.序號 = Value4 And A.上下限 = Value5 Select A).Any
        If args.IsValid = False Then
            ValidControl.Text = "鋼種:" & Value1 & "+材質:" & Value2 & "+站別:" & Value3 & "+序號:" & Value4 & "+上下限:" & Value5 & " 已存在於資料庫不可重覆加入!"
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        SetDataDefaultValue(Me.FormView1, CType(FormView1.FindControl("DropDownList1"), DropDownList).SelectedValue = "H")
    End Sub

End Class