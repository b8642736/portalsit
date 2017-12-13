Public Class HumitureEdit
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/dd")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        ListView1.DataBind()
    End Sub


    Private Sub ListView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewInsertEventArgs) Handles ListView1.ItemInserting
        e.Values("SaveDateTime") = Format(Now, "yyyy/MM/dd HH:mm:ss")
        Dim SetDataDateTime As DateTime = CType(CType(ListView1.InsertItem.FindControl("DataDateTextBox"), TextBox).Text.Trim, Date)
        SetDataDateTime = SetDataDateTime.AddHours(Val(CType(ListView1.InsertItem.FindControl("DataHourTextBox"), TextBox).Text.Trim))
        SetDataDateTime = SetDataDateTime.AddMinutes(Val(CType(ListView1.InsertItem.FindControl("DataMinuteTextBox"), TextBox).Text.Trim))
        e.Values("DataDateTime") = Format(SetDataDateTime, "yyyy/MM/dd HH:mm:ss")

    End Sub

    Private Sub ListView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        e.NewValues("HFSaveDateTime") = Format(Now, "yyyy/MM/dd HH:mm:ss")
        Dim SetDataDateTime As DateTime = CType(CType(ListView1.EditItem.FindControl("DataDateTextBox"), TextBox).Text.Trim, DateTime)
        SetDataDateTime = SetDataDateTime.AddHours(Val(CType(ListView1.EditItem.FindControl("DataHourTextBox"), TextBox).Text.Trim))
        SetDataDateTime = SetDataDateTime.AddMinutes(Val(CType(ListView1.EditItem.FindControl("DataMinuteTextBox"), TextBox).Text.Trim))
        e.NewValues.Item("DataDateTime") = Format(SetDataDateTime, "yyyy/MM/dd HH:mm:ss")
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        If CType(ListView1.InsertItem.FindControl("DataDateTextBox"), TextBox).Text.Trim.Length = 0 Then
            CType(ListView1.InsertItem.FindControl("DataDateTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd")
        End If
        If CType(ListView1.InsertItem.FindControl("DataHourTextBox"), TextBox).Text.Trim.Length = 0 Then
            CType(ListView1.InsertItem.FindControl("DataHourTextBox"), TextBox).Text = Format(Now, "HH")
        End If
        If CType(ListView1.InsertItem.FindControl("DataMinuteTextBox"), TextBox).Text.Trim.Length = 0 Then
            CType(ListView1.InsertItem.FindControl("DataMinuteTextBox"), TextBox).Text = Format(Now, "mm")
        End If
        If CType(ListView1.InsertItem.FindControl("TempertureTextBox"), TextBox).Text.Trim.Length = 0 Then
            CType(ListView1.InsertItem.FindControl("TempertureTextBox"), TextBox).Text = "22"
        End If
        If CType(ListView1.InsertItem.FindControl("HumidityTextBox"), TextBox).Text.Trim.Length = 0 Then
            CType(ListView1.InsertItem.FindControl("HumidityTextBox"), TextBox).Text = "70"
        End If

        Dim SenderControl As ListView = sender
        If Not IsNothing(SenderControl.EditItem) Then
            CType(SenderControl.EditItem.FindControl("DataDateTextBox"), TextBox).Text = Format(CType(CType(SenderControl.EditItem.FindControl("HFDataDateTime"), HiddenField).Value, DateTime), "yyyy/MM/dd")
            CType(SenderControl.EditItem.FindControl("DataHourTextBox"), TextBox).Text = Format(CType(CType(SenderControl.EditItem.FindControl("HFDataDateTime"), HiddenField).Value, DateTime), "HH")
            CType(SenderControl.EditItem.FindControl("DataMinuteTextBox"), TextBox).Text = Format(CType(CType(SenderControl.EditItem.FindControl("HFDataDateTime"), HiddenField).Value, DateTime), "mm")
        End If

    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If CheckBox1.Checked Then
            Dim DBDataContext As New CompanyLINQDB.SMPDataContext
            e.Result = From A In DBDataContext.溫濕度記錄 Where A.DataDateTime >= Format(CType(tbStartDate.Text, DateTime), "yyyy/MM/dd") And A.DataDateTime <= Format(CType(tbEndDate.Text, DateTime), "yyyy/MM/dd") Select A
        End If
    End Sub
End Class