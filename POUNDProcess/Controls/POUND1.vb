Public Class POUND1

    Public Event PoundUserLogoutEvent(ByVal Sender As POUND1)

#Region "是否開始截取儀重量 屬性:IsStartGettingWeight"
    Private _IsStartGettingWeight As Boolean = False
    ''' <summary>
    ''' 是否開始截取儀重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsStartGettingWeight() As Boolean
        Get
            Return _IsStartGettingWeight
        End Get
        Set(ByVal value As Boolean)
            _IsStartGettingWeight = value
        End Set
    End Property

#End Region
#Region "資料截入日期 屬性:DataLoadDate"
    Private _DataLoadDate As Date
    Public Property DataLoadDate() As Date
        Get
            Return _DataLoadDate
        End Get
        Private Set(ByVal value As Date)
            _DataLoadDate = value
        End Set
    End Property

#End Region
#Region "掃描或手動加入鋼捲 函式:ScanOrManualAddCoil"
    ''' <summary>
    ''' 掃描或手動加入鋼捲
    ''' </summary>
    ''' <param name="TENumber">唐榮鋼捲編號</param>
    ''' <remarks></remarks>
    Private Function ScanOrManualAddCoil(ByVal TENumber As String, Optional InsertAfterNode As CoilScanedTreeNode = Nothing) As CoilScanedTreeNode
        TENumber = TENumber.Replace("-", Nothing).Replace("－", Nothing)
        stlMessage.Text = Nothing
        Select Case True
            Case IsNothing(TENumber)
                stlMessage.Text = "發生錯誤:鋼捲掃描資料為空白Nothing!"
                tbMsgRecords.Text = tbMsgRecords.Text & IIf(String.IsNullOrEmpty(tbMsgRecords.Text), Nothing, vbNewLine) & stlMessage.Text
                Return Nothing
            Case TENumber.Replace(vbNewLine, Nothing).Trim.Length < 5
                stlMessage.Text = "發生錯誤:鋼捲輸入資料長度不足5位!"
                tbMsgRecords.Text = tbMsgRecords.Text & IIf(String.IsNullOrEmpty(tbMsgRecords.Text), Nothing, vbNewLine) & stlMessage.Text
                Return Nothing
            Case TENumber.Replace(vbNewLine, Nothing).Trim.Length > 10
                stlMessage.Text = tbMsgRecords.Text & "發生錯誤:鋼捲輸入資料長度過長大於10位!"
                tbMsgRecords.Text = IIf(String.IsNullOrEmpty(tbMsgRecords.Text), Nothing, vbNewLine) & stlMessage.Text
                Return Nothing
        End Select

        TENumber = TENumber.Replace(vbNewLine, Nothing).Trim.ToUpper
        For Each EachItem As CompanyORMDB.PPS100LB.PPSCICPF In Me.TodayAllPPSCICPFs
            If TENumber = EachItem.CoilFullNumber.Trim Then
                stlMessage.Text = "發生錯誤:今日鋼捲輸入重覆(" & TENumber & "輸入者:" & EachItem.CIC94 & ")!"
                tbMsgRecords.Text = tbMsgRecords.Text & IIf(String.IsNullOrEmpty(tbMsgRecords.Text), Nothing, vbNewLine) & stlMessage.Text
                Return Nothing
            End If
        Next

        Dim OldSelectTreeNode As CoilScanedTreeNode = TreeView1.SelectedNode
        Dim AddNode As CoilScanedTreeNode = New CoilScanedTreeNode(TENumber, "STK", Me.StartWeightNumber, Me.LoginID)

        If Not IsNothing(InsertAfterNode) AndAlso TypeOf InsertAfterNode Is CoilScanedTreeNode Then
            Me.TreeView1.Nodes.Insert(Me.TreeView1.Nodes.IndexOf(InsertAfterNode), AddNode)
        Else
            Me.TreeView1.Nodes.Add(AddNode)
        End If
        If Not IsNothing(AddNode.AboutPPSCICPF) Then
            AddNode.Text = AddNode.GetTreeViewOrderNumber & ". " & AddNode.CoilFullNumber & " 重:" & AddNode.AboutPPSCICPF.CIC06
        Else
            AddNode.Text = AddNode.GetTreeViewOrderNumber & ". " & AddNode.CoilFullNumber
        End If

        '由資料庫中讀取過磅鋼捲資料
        If AddNode.ReadPPSCICPFFromDB = False Then
            AddNode.SaveToPPSCICPF()
        End If
        If IsNothing(AddNode.AboutPPSCICPF) Then
            Me.TreeView1.Nodes.Remove(AddNode)
            If Not IsNothing(OldSelectTreeNode) Then
                TreeView1.SelectedNode = OldSelectTreeNode
                Return Nothing
            End If
        End If
        Return AddNode
    End Function


#End Region
#Region "儲存所有鋼捲TreeNode至資庫 函式:SaveNodesValueToDB"
    ''' <summary>
    ''' 儲存所有鋼捲TreeNode至資庫
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SaveNodesValueToDB() As Integer
        Dim ReturnValue As Integer = 0
        For Each EachNode In TreeView1.Nodes
            If Not TypeOf (EachNode) Is CoilScanedTreeNode Then
                Continue For
            End If
            Dim SaveNode As CoilScanedTreeNode = EachNode
            ReturnValue += IIf(SaveNode.SaveToPPSCICPF(True), 1, 0)
        Next
        Return ReturnValue
    End Function
#End Region
#Region "結束編輯並儲存儲所有TreeNode鋼捲資料 函式:EndEditAndSaveNodesValueToDB"
    ''' <summary>
    ''' 結束編輯並儲存儲所有TreeNode鋼捲資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndEditAndSaveNodesValueToDB()
        Me.bsDataSource.EndEdit()
        Call SaveNodesValueToDB()
    End Sub
#End Region
#Region "今天所有鋼捲資料 屬性:TodayAllPPSCICPFs"
    Private _TodayAllPPSCICPFs As New List(Of CompanyORMDB.PPS100LB.PPSCICPF)
    ''' <summary>
    ''' 今天所有鋼捲資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TodayAllPPSCICPFs As List(Of CompanyORMDB.PPS100LB.PPSCICPF)
        Get
            Static LastAccessTime As DateTime = New Date(2014, 1, 1)
            If IsNothing(_TodayAllPPSCICPFs) OrElse Now.Subtract(LastAccessTime).TotalSeconds > 3 Then
                _TodayAllPPSCICPFs.Clear()
                Dim Qry As String = "Select * from @#PPS100LB.PPSCICPF WHERE CIC00='STK' AND CIC03=" & New CompanyORMDB.AS400DateConverter(DataLoadDate).TwIntegerTypeData & " order by cic05 "
                _TodayAllPPSCICPFs = CompanyORMDB.PPS100LB.PPSCICPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCICPF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                LastAccessTime = Now
            End If
            Return _TodayAllPPSCICPFs
        End Get
    End Property
#End Region
#Region "重新載入最後編修者之所有鋼捲資料 函式:ReLoadLastEditUserDatas"
    ''' <summary>
    ''' 重新載入最後編修者之所有鋼捲資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReLoadLastEditUserDatas()
        DataLoadDate = Now.Date
        '計算設定編修時的啟始過磅磅序
        StartWeightNumber = 1
        Dim SortedDatas As List(Of CompanyORMDB.PPS100LB.PPSCICPF) = (From A In TodayAllPPSCICPFs Select A Order By A.CIC05 Descending).ToList
        If SortedDatas.Count > 0 Then
            Dim LastDiffUserEditData As CompanyORMDB.PPS100LB.PPSCICPF = (From A In SortedDatas Where A.CIC94.Trim <> Me.LoginID.Trim Select A Order By A.CIC05 Descending).FirstOrDefault
            If IsNothing(LastDiffUserEditData) Then
                '今天尚未找到不同使用者進入系統使用過磅
                StartWeightNumber = 1
            Else
                '今天已有不同使用者進入系統使用過磅
                StartWeightNumber = LastDiffUserEditData.CIC05 + 1
            End If
        End If

        '載入登入者本次之所有編輯資料
        TreeView1.Nodes.Clear()
        For Each EachItem As CompanyORMDB.PPS100LB.PPSCICPF In (From A In SortedDatas Where A.CIC05 >= StartWeightNumber And A.CIC94.Trim = Me.LoginID.Trim Select A Order By A.CIC05).ToList
            If Not String.IsNullOrEmpty(EachItem.CIC95) Then
                EachItem.CIC95 = EachItem.CIC95.Trim
            End If
            Dim AddNode As CoilScanedTreeNode = New CoilScanedTreeNode(EachItem, StartWeightNumber, Me.LoginID)
            TreeView1.Nodes.Add(AddNode)
            AddNode.Text = AddNode.AboutPPSCICPF.CIC05 & ". " & AddNode.CoilFullNumber & " 重:" & AddNode.AboutPPSCICPF.CIC06
        Next

    End Sub
#End Region
#Region "將游標移至最後一筆未過磅的位置 函式:MoveToUnPoundPosition"
    ''' <summary>
    ''' 將游標移至最後一筆未過磅的位置
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MoveToUnPoundPosition()
        Me.bsDataSource.EndEdit()
        Dim SelectNode As CoilScanedTreeNode = TreeView1.SelectedNode
        If Not IsNothing(SelectNode) Then
            stlMessage.Text = Nothing
            If SelectNode.SaveToPPSCICPF() Then
                stlMessage.Text = SelectNode.CoilFullNumber & "鋼捲資料儲存成功!"
                Me.RefreshEnableButton()
            Else
                stlMessage.Text = "注意:" & SelectNode.CoilFullNumber & "鋼捲資料儲存失敗!"
            End If
        End If
        For Each EachNode As CoilScanedTreeNode In TreeView1.Nodes
            If EachNode.AboutPPSCICPF.CIC06 = 0 Then
                TreeView1.SelectedNode = EachNode
                Exit Sub
            End If
        Next

    End Sub
#End Region

#Region "重整控制項啟用按鈕 函式:RefreshEnableButton"
    ''' <summary>
    ''' 重整控制項啟用按鈕
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshEnableButton()
        lbEditCountMsg.Text = "鋼捲數量:" & Me.TreeView1.Nodes.Count
        tbDeviceWeight.Enabled = False
        btnTrnasWeight.Enabled = False
        tbStoreArea.Enabled = False
        If IsNothing(TreeView1.SelectedNode) Then
            Me.bsDataSource.Clear()
        Else
            tbDeviceWeight.Enabled = True
            btnTrnasWeight.Enabled = True
            tbStoreArea.Enabled = True
        End If
        '重整磅序
        For Each EachItem As CoilScanedTreeNode In TreeView1.Nodes
            EachItem.Text = EachItem.GetTreeViewOrderNumber & ". " & EachItem.CoilFullNumber & " 重:" & EachItem.AboutPPSCICPF.CIC06
        Next
    End Sub
#End Region
#Region "登入者工號 屬性:LoginID"
    Private _LoginID As String = ""
    ''' <summary>
    ''' 登入者工號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LoginID() As String
        Get
            Return _LoginID
        End Get
        Set(ByVal value As String)
            _LoginID = value
        End Set
    End Property

#End Region
#Region "起紿磅序編號 屬性:StartWeightNumber"
    Private _StartWeightNumber As Integer
    ''' <summary>
    ''' 起紿磅序編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartWeightNumber() As Integer
        Get
            Return _StartWeightNumber
        End Get
        Set(ByVal value As Integer)
            _StartWeightNumber = value
        End Set
    End Property
#End Region

    Private Sub SPWeight_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SPWeight.DataReceived
        If IsStartGettingWeight = False Then
            SPWeight.DiscardInBuffer()
            Exit Sub
        End If
        Me.Invoke(New MethodInvoker(AddressOf Me.SetSPWeightData), Nothing)
    End Sub

    Public Sub SetSPWeightData()
        Dim GetOrginData As String = SPWeight.ReadExisting
        'tbMsgRecords.Text &= vbNewLine & Now & GetOrginData
        'Exit Sub
        If String.IsNullOrEmpty(GetOrginData) OrElse Not GetOrginData.ToUpper.EndsWith("KG") Then
            Exit Sub
        End If

        Try
            GetOrginData = GetOrginData.ToUpper.Replace("ST", Nothing).Replace(",", Nothing).Replace("GS", Nothing).Replace("+", Nothing).Replace("KG", Nothing).Trim
            tbDeviceWeight.Text = CType(GetOrginData, Integer)
            Dim ShowBarValue As Integer = CType(tbDeviceWeight.Text, Integer)
            ProgressBar1.Maximum = IIf(ShowBarValue > 10000, ShowBarValue + 10, 10000)
            ProgressBar1.Value = IIf(ShowBarValue < 0, 0, ShowBarValue)
            'btnSaveWeight.Enabled = (ShowBarValue > 0)
            'btnSaveWeight.BackColor = IIf(btnSaveWeight.Enabled, Color.LightGreen, Color.Gray)
        Catch ex As Exception
            tbMsgRecords.Text = ex.ToString
        End Try
    End Sub

    Private Sub BarcordScanRS232_DataReceivFinishedEx(Sender As IO.Ports.SerialPort, e As IO.Ports.SerialDataReceivedEventArgs, ReceiveData As String) Handles BarcordScanRS232.DataReceivFinishedEx
        If Not String.IsNullOrEmpty(ReceiveData) Then
            ScanOrManualAddCoil(ReceiveData.Trim)
            RefreshEnableButton()
            MoveToUnPoundPosition()
        End If
    End Sub


    Private Sub WeightProcess_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If SPWeight.IsOpen Then
            SPWeight.DiscardInBuffer()
            SPWeight.Close()
        End If
        SPWeight.Dispose()
        If BarcordScanRS232.IsOpen Then
            BarcordScanRS232.DiscardInBuffer()
            BarcordScanRS232.Close()
        End If
        BarcordScanRS232.Dispose()
    End Sub

    Public Sub StartForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReLoadLastEditUserDatas()
        RefreshEnableButton()
        btInputCoilNumber.Focus()
        stlMessage.Text = Nothing
        Try
            If Not SPWeight.IsOpen Then
                SPWeight.OpenAndSetContainerControl(Me)
            End If
        Catch ex As Exception
            stlMessage.Text = "注意:過磅程式偵測重量發生異常,改以手動輸入重量!"
            MsgBox(stlMessage.Text & ex.ToString)
        End Try

        Try
            If Not BarcordScanRS232.IsOpen Then
                BarcordScanRS232.OpenAndSetContainerControl(Me)
            End If
        Catch ex As Exception
            stlMessage.Text &= "注意:條碼掃描器發生錯誤,請改以手動輸入鋼捲號碼!"
            MsgBox(stlMessage.Text & ex.ToString)
        End Try

    End Sub

    Private Sub btInputCoilNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btInputCoilNumber.GotFocus, btInputCoilNumber.GotFocus
        CType(sender, TextBox).BackColor = Color.Yellow
    End Sub

    Private Sub btInputCoilNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles btInputCoilNumber.KeyDown
        If e.KeyData = Keys.Enter AndAlso btnManualAddCoil.Enabled Then
            Call btnManualAddCoil_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btInputCoilNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btInputCoilNumber.LostFocus, btInputCoilNumber.LostFocus
        CType(sender, TextBox).BackColor = Color.White
    End Sub


    Private Sub btnSaveWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveWeight.Click
        'MsgBox("weight1=" & CType(TreeView1.SelectedNode, CoilScanedTreeNode).AboutPPSCICPF.CIC06)
        Me.bsDataSource.EndEdit()
        Dim SelectNode As CoilScanedTreeNode = TreeView1.SelectedNode
        If Not sender Is TreeView1 Then
            stlMessage.Text = Nothing
            If SelectNode.SaveToPPSCICPF() Then
                stlMessage.Text = SelectNode.CoilFullNumber & "鋼捲資料儲存成功!"
                Me.RefreshEnableButton()
            Else
                stlMessage.Text = "注意:" & SelectNode.CoilFullNumber & "鋼捲資料儲存失敗!"
            End If
        End If

        If Not IsNothing(sender) AndAlso sender Is btnSaveWeight AndAlso Not IsNothing(SelectNode.NextNode) Then
            TreeView1.SelectedNode = SelectNode.NextNode
        End If

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Call btnSaveWeight_Click(TreeView1, Nothing)
        Dim SetDataSource As New List(Of CompanyORMDB.PPS100LB.PPSCICPF)
        If Not IsNothing(TreeView1.SelectedNode) Then
            SetDataSource.Add(CType(TreeView1.SelectedNode, CoilScanedTreeNode).AboutPPSCICPF)
        End If
        Me.bsDataSource.DataSource = SetDataSource
        Me.bsDataSource.ResetBindings(False)
        RefreshEnableButton()
    End Sub

    Private Sub btnManualAddCoil_Click(sender As Object, e As EventArgs) Handles btnManualAddCoil.Click, btnManualInsertCoil.Click
        If sender Is btnManualInsertCoil AndAlso Not IsNothing(TreeView1.SelectedNode) Then
            Call ScanOrManualAddCoil(btInputCoilNumber.Text.Trim, TreeView1.SelectedNode)
        Else
            Call ScanOrManualAddCoil(btInputCoilNumber.Text.Trim)
        End If
        btInputCoilNumber.Text = Nothing
        Me.SaveNodesValueToDB()
        RefreshEnableButton()
        TreeView1.ExpandAll()
        MoveToUnPoundPosition()
    End Sub

    Private Sub btnClearCoils_Click(sender As Object, e As EventArgs) Handles btnClearCoils.Click
        Dim SelectNode As CoilScanedTreeNode = TreeView1.SelectedNode
        If IsNothing(SelectNode) Then
            Exit Sub
        End If
        If MsgBox("是否確定刪除鋼捲過磅資料", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If SelectNode.AboutPPSCICPF.CDBDelete > 0 Then
            TreeView1.Nodes.Remove(SelectNode)
            '重整磅序
            For Each EachItem As CoilScanedTreeNode In TreeView1.Nodes
                EachItem.Text = EachItem.GetTreeViewOrderNumber & ". " & EachItem.CoilFullNumber & " 重:" & EachItem.AboutPPSCICPF.CIC06
            Next
        End If
        Me.SaveNodesValueToDB()
        RefreshEnableButton()
    End Sub

    Private Sub btnCoilMoveUp_Click(sender As Object, e As EventArgs) Handles btnCoilMoveUp.Click, btnCoilMoveDown.Click
        Dim MoveNode As TreeNode = Me.TreeView1.SelectedNode
        Dim MoveToIndex As Integer = Me.TreeView1.Nodes.IndexOf(IIf(sender Is btnCoilMoveUp, MoveNode.PrevNode, MoveNode.NextNode))
        If MoveToIndex >= 0 Then
            Me.TreeView1.Nodes.Remove(MoveNode)
            Me.TreeView1.Nodes.Insert(MoveToIndex, MoveNode)
            Me.TreeView1.SelectedNode = MoveNode
        End If
        Me.SaveNodesValueToDB()
        RefreshEnableButton()
    End Sub

    Private Sub tbDeviceWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles tbDeviceWeight.KeyDown, tbStoreArea.KeyDown
        If e.KeyData = Keys.Enter Then
            If Val(tbDeviceWeight.Text) > 99999 Then
                MsgBox("重量超過最大範圍99999請重新輸入!", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            Call btnSaveWeight_Click(btnSaveWeight, Nothing)
            Me.RefreshEnableButton()
            tbDeviceWeight.Focus()
            tbDeviceWeight.SelectAll()
        End If
    End Sub

    Private Sub rbMachineSend_CheckedChanged(sender As Object, e As EventArgs)
        Me.RefreshEnableButton()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If DataLoadDate.Date <> Now.Date Then
            RaiseEvent PoundUserLogoutEvent(Me)
        End If
    End Sub

    Private Sub tbDeviceWeight_MouseUp(sender As Object, e As MouseEventArgs) Handles tbDeviceWeight.MouseUp
        tbDeviceWeight.SelectAll()
    End Sub

    Private Sub btnClearMsgRecord_Click(sender As Object, e As EventArgs) Handles btnClearMsgRecord.Click
        tbMsgRecords.Text = Nothing
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MsgBox("是否確定要登出?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            RaiseEvent PoundUserLogoutEvent(Me)
        End If
    End Sub

    Private Sub btnTrnasWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles btnTrnasWeight.KeyDown
        IsStartGettingWeight = True
    End Sub

    Private Sub btnTrnasWeight_KeyUp(sender As Object, e As KeyEventArgs) Handles btnTrnasWeight.KeyUp
        IsStartGettingWeight = False
    End Sub

    Private Sub btnTrnasWeight_MouseDown(sender As Object, e As MouseEventArgs) Handles btnTrnasWeight.MouseDown
        IsStartGettingWeight = True
    End Sub

    Private Sub btnTrnasWeight_MouseUp(sender As Object, e As MouseEventArgs) Handles btnTrnasWeight.MouseUp
        IsStartGettingWeight = False
        Me.bsDataSource.EndEdit()
    End Sub


End Class
