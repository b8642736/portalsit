Public Class Form6

    Private Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        MsgBox("File Changed", vbOKOnly)
    End Sub
End Class