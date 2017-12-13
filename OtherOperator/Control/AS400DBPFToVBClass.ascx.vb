Public Partial Class AS400DBPFToVBClass
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnConvertToVBFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConvertToVBFile.Click
        If String.IsNullOrEmpty(tbLibraryName.Text) OrElse String.IsNullOrEmpty(tbFileName.Text) OrElse String.IsNullOrEmpty(tbMemberName.Text) Then
            TextBox1.Text = Nothing
            lbMessage.Text = "請完整輸入資料庫定義檔來源LabraryName+FileName+MemberName來源檔案!"
        Else
            Dim VBCodeConverter As New AS400DBToVB(Me.tbLibraryName.Text, Me.tbFileName.Text, Me.tbMemberName.Text)
            TextBox1.Text = VBCodeConverter.ConvertFieldRowInfoToVBCode()
            lbMessage.Text = "轉換完成!"
        End If
        btnDownLoad.Visible = TextBox1.Text.Trim.Length > 0
    End Sub

    Protected Sub btnDownLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoad.Click
        AS400DBToVB.DownTextVBCode(Me.TextBox1.Text, Me.tbMemberName.Text & ".vb", Me.Page)
    End Sub

End Class