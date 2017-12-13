Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim InputString As String = "027784376 079938274"
        ''InputString &= vbNewLine & "   "
        ''InputString &= vbNewLine & " aa win97 "
        ''InputString &= vbNewLine & "C3.win95 DCDD"
        ''InputString &= vbNewLine & "98aCCCDDD 98"
        Dim PatternString As String = "\b(?!02)\d+\b"
        For Each EachItem In System.Text.RegularExpressions.Regex.Matches(InputString, PatternString, System.Text.RegularExpressions.RegexOptions.Multiline)
            MsgBox(EachItem.Value)
        Next
        'MsgBox(System.Text.RegularExpressions.Regex.Replace(InputString, PatternString, "[*]"))
    End Sub

    Private Sub SerialPortEx1_DataReceivFinishedEx(ByVal Sender As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs, ByVal ReceiveData As String) Handles SerialPortEx1.DataReceivFinishedEx
        Me.Label1.Text = ReceiveData
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SerialPortEx1.OpenAndSetContainerControl(Me)
    End Sub

End Class
