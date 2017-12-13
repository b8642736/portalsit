Public Class NewDataEdit

    Public Event Finish(ByVal Sender As NewDataEdit)

#Region "前一控制項 屬性:PreControl"
    Private _PreControl As StationClient
    ''' <summary>
    ''' 前一控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreControl() As StationClient
        Get
            Return _PreControl
        End Get
        Set(ByVal value As StationClient)
            _PreControl = value
            If Not IsNothing(_PreControl) AndAlso Not IsNothing(_PreControl.CurrentEditNewPPSSHAPF) Then
                Dim SetDatas As New List(Of CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF)
                SetDatas.Add(_PreControl.CurrentEditNewPPSSHAPF)
                Me.bsEditData.DataSource = SetDatas
            End If
        End Set
    End Property
#End Region

#Region "下一產線名稱下拉選單選項更新 函式:NextLineNamePullDownDataRefresh"
    ''' <summary>
    ''' 下一產線名稱下拉選單選項更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NextLineNamePullDownDataRefresh()
        Dim Qry As String =  " Select Distinct InNextOperationLineName from InOutOperationLineName UNION ( Select Distinct OutNextOperationLineName  from InOutOperationLineName  WHERE NOT OutNextOperationLineName IN ( Select Distinct InNextOperationLineName from InOutOperationLineName))"
        ComboBox2.Items.Clear()
        Dim QryAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        For Each EachItem As DataRow In QryAdapter.SelectQuery(Qry).Rows
            ComboBox2.Items.Add(CType(EachItem.Item(0), String).PadLeft(4))
        Next
    End Sub
#End Region

#Region "重整顯示可用剩餘重量 函式:RefreshDisplayCanUseWeight"
    ''' <summary>
    ''' 重整顯示可用剩餘重量
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDisplayCanUseWeight()
        If IsNothing(PreControl) OrElse IsNothing(PreControl.CurrentSelectTreeNode) Then
            lbRemendWeight.Text = 0
        End If
        Dim ReturnValue As Double = PreControl.CurrentSelectTreeNode.MyPPSSHAPFFlowAdapter.PrePPSSHAPFForAlreadyNewPPSSHAPFs.SHA17
        For Each EachItem As CompanyORMDB.IPPS100LB.IPPSSHAPF In PreControl.CurrentSelectTreeNode.MyPPSSHAPFFlowAdapter.AlreadyNewPPSSHAPFs
            If Not EachItem Is PreControl.CurrentEditNewPPSSHAPF Then
                ReturnValue -= (EachItem.SHA17 + EachItem.SHA18 + EachItem.SHA19 + EachItem.SHA20)
            Else
                ReturnValue -= (Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox7.Text))
            End If
        Next
        Select Case True
            Case ReturnValue > 0
                lbRemendWeight.ForeColor = Color.Green
            Case ReturnValue = 0
                lbRemendWeight.ForeColor = Color.Black
            Case Else
                lbRemendWeight.ForeColor = Color.Red
        End Select
        lbRemendWeight.Text = ReturnValue
    End Sub
#End Region

    Public Sub RefreshEditData(ByVal SourceEditData As CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF)
        Dim GetCurrentData As CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF = SourceEditData
        Me.bsEditData.DataSource = GetCurrentData
        RefreshDisplayCanUseWeight()
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        RaiseEvent Finish(Me)
    End Sub

    Private Sub NewDataEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NextLineNamePullDownDataRefresh()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged, TextBox7.TextChanged
        Dim SenderControl As TextBox = sender
        If Double.TryParse(SenderControl.Text, Nothing) = False Then
            SenderControl.Text = 0
        End If
        RefreshDisplayCanUseWeight()
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        Dim SenderControl As TextBox = sender
        If Double.TryParse(SenderControl.Text, Nothing) = False Then
            SenderControl.Text = 0
        End If
    End Sub

    Private Sub btnPutAllWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPutAllWeight.Click
        If Me.bsEditData.Count > 0 Then
            CType(Me.bsEditData.Item(0), CompanyORMDB.IPPS100LB.IPPSSHAPF).SHA17 = Val(TextBox3.Text) + Val(lbRemendWeight.Text)
            Me.bsEditData.ResetBindings(False)
        End If
    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click, TextBox2.Click, TextBox3.Click, TextBox4.Click, TextBox5.Click, TextBox6.Click, TextBox7.Click
        CType(sender, TextBox).SelectAll()
    End Sub

End Class
