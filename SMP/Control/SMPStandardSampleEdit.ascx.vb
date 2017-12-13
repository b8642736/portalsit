Public Partial Class SMPStandardSampleEdit
    Inherits System.Web.UI.UserControl
    Dim DBContext As New CompanyLINQDB.SMPDataContext

    Private Sub ChangeButtonStatus()
        btnAddItem.Enabled = Not String.IsNullOrEmpty(ListBox1.SelectedValue) AndAlso Not String.IsNullOrEmpty(ListBox2.SelectedValue)
        Me.btnDelete.Enabled = GridView1.Rows.Count > 0 AndAlso Not IsNothing(GridView1.SelectedValue)
        btnUPPriority.Enabled = btnDelete.Enabled And GridView1.Rows.Count > 1
        btnDownPriority.Enabled = btnDelete.Enabled And btnUPPriority.Enabled

    End Sub


    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        CType(ListView1.InsertItem.FindControl("ModifyDateTextBox"), TextBox).Text = Format(Now.Date, "yyyy/MM/dd")
        CType(ListView1.InsertItem.FindControl("ModifyUserTextBox"), TextBox).Text = IIf(IsNothing(WebAppAuthority.CurrentWindowsLoginName), WebAppAuthority.CurrentWindowsLoginEmployeeNumber, WebAppAuthority.CurrentWindowsLoginName)
        If Not IsNothing(ListView1.EditItem) Then
            CType(ListView1.EditItem.FindControl("ModifyDateTextBox"), TextBox).Text = Format(Now.Date, "yyyy/MM/dd")
            CType(ListView1.EditItem.FindControl("ModifyUserTextBox"), TextBox).Text = IIf(IsNothing(WebAppAuthority.CurrentWindowsLoginName), WebAppAuthority.CurrentWindowsLoginEmployeeNumber, WebAppAuthority.CurrentWindowsLoginName)
        End If
    End Sub

    Protected Sub btnAddItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddItem.Click
        If String.IsNullOrEmpty(ListBox1.SelectedValue) OrElse String.IsNullOrEmpty(ListBox2.SelectedValue) Then
            Exit Sub
        End If
        If (From A In DBContext.SMPMethodToSMPStandardSample Where A.SMPMethodNumber = ListBox1.SelectedValue And A.SMPSampleNumber = ListBox2.SelectedValue Select A Order By A.SortOrder Ascending).Count > 0 Then
            Exit Sub
        End If
        Dim AlreadyAddThisMethodItems As List(Of CompanyLINQDB.SMPMethodToSMPStandardSample) = (From A In DBContext.SMPMethodToSMPStandardSample Where A.SMPMethodNumber = ListBox1.SelectedValue Select A Order By A.SortOrder Ascending).ToList
        Dim InsertOrderNumber As Integer = AlreadyAddThisMethodItems.Count + 1
        For OrderNumber As Integer = 1 To AlreadyAddThisMethodItems.Count
            If OrderNumber <> AlreadyAddThisMethodItems.Item(OrderNumber - 1).SortOrder Then
                InsertOrderNumber = OrderNumber
                Exit For
            End If
        Next
        Dim InsertItem As New CompanyLINQDB.SMPMethodToSMPStandardSample
        With InsertItem
            .SMPMethodNumber = ListBox1.SelectedValue
            .SMPSampleNumber = ListBox2.SelectedValue
            .SortOrder = InsertOrderNumber
        End With
        DBContext.SMPMethodToSMPStandardSample.InsertOnSubmit(InsertItem)
        DBContext.SubmitChanges()
        Me.GridView1.DataBind()
        Me.ListBox2.DataBind()
        ChangeButtonStatus()
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        If IsNothing(GridView1.SelectedDataKey) Then
            Exit Sub
        End If
        Dim DeleteItem As CompanyLINQDB.SMPMethodToSMPStandardSample = (From A In DBContext.SMPMethodToSMPStandardSample Where A.SMPMethodNumber = CType(Me.GridView1.SelectedDataKey.Values("SMPMethodNumber"), String) And A.SMPSampleNumber = CType(Me.GridView1.SelectedDataKey.Values("SMPSampleNumber"), String) And A.SortOrder = CType(Me.GridView1.SelectedDataKey.Values("SortOrder"), Integer) Select A).FirstOrDefault
        If Not IsNothing(DeleteItem) Then
            DBContext.SMPMethodToSMPStandardSample.DeleteOnSubmit(DeleteItem)
            DBContext.SubmitChanges()
        End If
        Me.GridView1.DataBind()
        Me.ListBox2.DataBind()
        ChangeButtonStatus()
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        If TabContainer1.ActiveTab Is Me.TabPanel3 Then
            Me.ListBox1.DataBind()
            Me.ListBox2.DataBind()
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub LDSStandSample_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSStandSample.Selecting
        If String.IsNullOrEmpty(Me.ListBox1.SelectedValue) Then
            e.Cancel = True
        End If
        e.Result = From A In DBContext.SMPStandardSample Where Not (From B In DBContext.SMPMethodToSMPStandardSample Where B.SMPMethodNumber = CType(Me.ListBox1.SelectedValue, String) Select B.SMPSampleNumber).Contains(A.SampleNumber) Select A
    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Me.GridView1.DataBind()
        Me.ListBox2.DataBind()
    End Sub

    Protected Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox2.SelectedIndexChanged
        btnAddItem.Enabled = Not String.IsNullOrEmpty(ListBox1.SelectedValue) AndAlso Not String.IsNullOrEmpty(ListBox2.SelectedValue)
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        ChangeButtonStatus()
    End Sub

    Protected Sub LDSEditResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSEditResult.Selecting
        If String.IsNullOrEmpty(Me.ListBox1.SelectedValue) Then
            e.Cancel = True
        End If
        e.Result = From A In DBContext.SMPMethodToSMPStandardSample Where A.SMPMethodNumber = CType(ListBox1.SelectedValue, String) Select A
    End Sub

    Protected Sub btnUPPriority_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUPPriority.Click
        Dim PreItem As CompanyLINQDB.SMPMethodToSMPStandardSample = (From A In DBContext.SMPMethodToSMPStandardSample Where A.SMPMethodNumber = CType(GridView1.SelectedDataKey.Values("SMPMethodNumber"), String) And A.SortOrder < CType(GridView1.SelectedDataKey.Values("SortOrder"), Integer) Select A Order By A.SortOrder Descending).FirstOrDefault
        Dim CurrentItem As CompanyLINQDB.SMPMethodToSMPStandardSample = (From A In DBContext.SMPMethodToSMPStandardSample Where A.SMPMethodNumber = CType(GridView1.SelectedDataKey.Values("SMPMethodNumber"), String) And A.SMPSampleNumber = CType(GridView1.SelectedDataKey.Values("SMPSampleNumber"), String) Select A).FirstOrDefault
        If IsNothing(PreItem) And Not IsNothing(CurrentItem) Then
            Exit Sub
        End If
        Dim PreNumber As Integer = PreItem.SortOrder
        PreItem.SortOrder = CurrentItem.SortOrder
        CurrentItem.SortOrder = PreNumber
        DBContext.SubmitChanges()
        Me.GridView1.DataBind()
        Me.GridView1.SelectedIndex -= 1
    End Sub

    Protected Sub btnDownPriority_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownPriority.Click
        Dim NextItem As CompanyLINQDB.SMPMethodToSMPStandardSample = (From A In DBContext.SMPMethodToSMPStandardSample Where A.SMPMethodNumber = CType(GridView1.SelectedDataKey.Values("SMPMethodNumber"), String) And A.SortOrder > CType(GridView1.SelectedDataKey.Values("SortOrder"), Integer) Select A Order By A.SortOrder Ascending).FirstOrDefault
        Dim CurrentItem As CompanyLINQDB.SMPMethodToSMPStandardSample = (From A In DBContext.SMPMethodToSMPStandardSample Where A.SMPMethodNumber = CType(GridView1.SelectedDataKey.Values("SMPMethodNumber"), String) And A.SMPSampleNumber = CType(GridView1.SelectedDataKey.Values("SMPSampleNumber"), String) Select A).FirstOrDefault
        If IsNothing(NextItem) And Not IsNothing(CurrentItem) Then
            Exit Sub
        End If
        Dim PreNumber As Integer = NextItem.SortOrder
        NextItem.SortOrder = CurrentItem.SortOrder
        CurrentItem.SortOrder = PreNumber
        DBContext.SubmitChanges()
        Me.GridView1.DataBind()
        Me.GridView1.SelectedIndex += 1

    End Sub
End Class