Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SerialPortEx1_DataReceivFinishedEx(ByVal Sender As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs, ByVal ReceiveData As String) Handles SerialPortEx1.DataReceivFinishedEx
        Me.TextBox1.Text = ReceiveData
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.SerialPortEx1.PortName = "COM" & NumericUpDown1.Value.ToString.Trim
        Me.SerialPortEx1.OpenAndSetContainerControl(Me)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim SendMsg As New SPLMachineTalk
        With SendMsg
            .Data_1CoilNumber = TextBox0.Text
            .surface = TextBox1.Text
            .SteelKind = TextBox2.Text
            .Guage = TextBox3.Text
            .Width = TextBox4.Text
        End With
        Me.SerialPortEx1.Write(SendMsg.GetSendValue)
        MsgBox(SendMsg.GetSendValue)
    End Sub


End Class