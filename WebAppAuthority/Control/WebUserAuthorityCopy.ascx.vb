Public Partial Class WebUserAuthorityCopy
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New ClassDBDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

  
    Protected Sub btnSelectSource_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectSource.Click
        Me.MultiView1.SetActiveView(Me.SourceUserSelectView)
    End Sub

    Protected Sub btnSelectTarget_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectTarget.Click
        Me.MultiView1.SetActiveView(Me.TargetUserSelectView)
    End Sub

    Private Sub EmployeeSearch1_EmployeeSelectedEvent(ByVal SelectEmployeeNumber As String) Handles EmployeeSearch1.EmployeeSelectedEvent
        Me.Label1.Text = EmployeeSearch1.SelectedEmployeeNumber
        btnStartCopy.Enabled = (Not IsNothing(EmployeeSearch1.SelectedEmployeeNumber) AndAlso Not IsNothing(EmployeeSearch2.SelectedEmployeeNumber))
        Me.MultiView1.SetActiveView(Me.DefaultView)
    End Sub

    Private Sub EmployeeSearch2_EmployeeSelectedEvent(ByVal SelectEmployeeNumber As String) Handles EmployeeSearch2.EmployeeSelectedEvent
        Me.Label2.Text = EmployeeSearch2.SelectedEmployeeNumber
        btnStartCopy.Enabled = (Not IsNothing(EmployeeSearch1.SelectedEmployeeNumber) AndAlso Not IsNothing(EmployeeSearch2.SelectedEmployeeNumber))
        Me.MultiView1.SetActiveView(Me.DefaultView)
    End Sub

    Protected Sub btnStartCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStartCopy.Click

        Select Case RadioButtonList1.SelectedValue
            Case "1"
                Dim SourceUserAuthority As IQueryable(Of CompanyLINQDB.WebUserAuthority) = From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = EmployeeSearch1.SelectedEmployeeNumber Select A
                For Each EachItem In From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = EmployeeSearch1.SelectedEmployeeNumber And Not (From B In DBDataContext.WebUserAuthority Where B.FKWebLoginAccount_WindowLoginName = EmployeeSearch2.SelectedEmployeeNumber Select B.FK_SystemCode & B.FK_SystemFunctionCode).Contains(A.FK_SystemCode & A.FK_SystemFunctionCode) Select A
                    Dim NewData As New CompanyLINQDB.WebUserAuthority
                    With NewData
                        .FK_SystemCode = EachItem.FK_SystemCode
                        .FK_SystemFunctionCode = EachItem.FK_SystemFunctionCode
                        .FKWebLoginAccount_WindowLoginName = EmployeeSearch2.SelectedEmployeeNumber
                    End With
                    DBDataContext.WebUserAuthority.InsertOnSubmit(NewData)
                Next
            Case "2"
                DBDataContext.WebUserAuthority.DeleteAllOnSubmit(From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = EmployeeSearch2.SelectedEmployeeNumber Select A)
                For Each EachItem In From A In DBDataContext.WebUserAuthority Where A.FKWebLoginAccount_WindowLoginName = EmployeeSearch1.SelectedEmployeeNumber Select A
                    Dim NewData As New CompanyLINQDB.WebUserAuthority
                    With NewData
                        .FK_SystemCode = EachItem.FK_SystemCode
                        .FK_SystemFunctionCode = EachItem.FK_SystemFunctionCode
                        .FKWebLoginAccount_WindowLoginName = EmployeeSearch2.SelectedEmployeeNumber
                    End With
                    DBDataContext.WebUserAuthority.InsertOnSubmit(NewData)
                Next
        End Select
        Try
            DBDataContext.SubmitChanges()
            btnMessageLabel.Text = "資料複製完成!"
        Catch ex As Exception
            btnMessageLabel.Text = "資料複製失敗!原因:" & ex.ToString
        Finally
            btnMessageLabel.Visible = True
        End Try
    End Sub
End Class