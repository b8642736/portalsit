<Serializable()> _
Public Class MenuEdit


    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim SaveSucessCount As Integer = 0
        DataGridView1.EndEdit()
        Try
            For Each EachItem As WebMenu In bsWebMenuRoot.DataSource
                SaveSucessCount += CType(EachItem, WebMenu).CDBSave()
            Next
        Catch ex As Exception
            tsslMessage.Text = "前" & SaveSucessCount & "筆資料已儲存"
            tsslMessage.Text &= "錯誤發生:" & ex.ToString
        End Try
        tsslMessage.Text = "全部資料儲存成功(共" & SaveSucessCount & "筆資料已儲存)"
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim WhereString As String = Nothing
        If Not String.IsNullOrEmpty(TextBox1.Text) Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " MenuName like '%" & TextBox1.Text.Replace("''", Nothing) & "%'"
        End If
        If Not String.IsNullOrEmpty(TextBox2.Text) Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " NodeText like'%" & TextBox2.Text.Replace("''", Nothing) & "%'"
        End If
        Dim SQLQuery As String = "Select * from WebMenu " & IIf(String.IsNullOrEmpty(WhereString), Nothing, " Where " & WhereString)
        Me.bsWebMenuRoot.DataSource = WebMenu.CDBSelect(Of WebMenu)(SQLQuery)
    End Sub

    Private Sub btnClearSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSearch.Click
        Me.TextBox1.Text = Nothing
        Me.TextBox2.Text = Nothing
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If IsNothing(Me.bsWebMenuRoot.Current) OrElse MsgBox("是否確定刪除?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        DataGridView1.EndEdit()
        tsslMessage.Text = "已成功刪除" & CType(Me.bsWebMenuRoot.Current, WebMenu).CDBDelete() & "筆資料"
        Me.bsWebMenuRoot.RemoveCurrent()
    End Sub

End Class
