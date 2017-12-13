Public Class Form2


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim WC As New System.Net.WebClient
        'Me.RichTextBox1.Text = System.Text.Encoding.ASCII.GetString(WC.DownloadData(New Uri("http://www.kimo.com.tw", True)))
    End Sub

End Class