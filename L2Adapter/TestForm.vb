Public Class TestForm
    WithEvents myOPCUAAdapter As OPCUAAdapter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(myOPCUAAdapter) Then
            myOPCUAAdapter = New OPCUAAdapter(Me)
        End If
        Button1.Text = "Connect:" & myOPCUAAdapter.ConnectOPCServer()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'myOPCUAAdapter.OPCItemAsyncRead("ns=2;s=APL2.CLX.Global.AP2_Length", 0, 1)
        myOPCUAAdapter.OPCItemAsyncRead("ns=2;s=Channel1.Device1.Tag1", 0, 1)
    End Sub

    Private Sub myOPCUAAdapter_ErrorMessage(e As Exception, ErrorMessage As String) Handles myOPCUAAdapter.ErrorMessage
        MsgBox(ErrorMessage)
    End Sub

    Private Sub myOPCUAAdapter_ItemValueReaded(IsDataGood As Boolean, ReadData As Object, ClientHandle As Object) Handles myOPCUAAdapter.ItemValueReaded
        Me.Label1.Text = ClientHandle.ToString & ":" & IIf(IsDataGood, CType(ReadData, String), Nothing)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'myOPCUAAdapter.AddOPCItem("ns=2;s=APL2.CLX.Global.AP2_Length", Type.GetType("Integer"))
        myOPCUAAdapter.AddOPCItem("ns=2;s=Channel1.Device1.Tag1", Type.GetType("Integer"))
        myOPCUAAdapter.OPCItemSubscribt()
    End Sub

    Private Sub myOPCUAAdapter_SubscriptionReaded(allQualitiesGood As Boolean, noErrors As Boolean, AllValues As Dictionary(Of Integer, OPCUAAdapter.OPCItemSubscribeDefine)) Handles myOPCUAAdapter.SubscriptionReaded
        Me.Label1.Text = AllValues.Values(0).OPCReturnValue.Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'myOPCUAAdapter.OPCItemASyncWrite("ns=2;s=Channel1.Device1.Tag1", 11)
    End Sub

End Class