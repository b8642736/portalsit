Public Class CoilRunningItem

#Region "前一個正在執行鋼捲CoilRunningItem 屬性:PreRunningCoilRunningItem"

    Private _PreRunningCoilRunningItem As CoilRunningItem
    ''' <summary>
    ''' 前一個正在執行鋼捲CoilRunningItem
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreRunningCoilRunningItem() As CoilRunningItem
        Get
            Return _PreRunningCoilRunningItem
        End Get
        Private Set(ByVal value As CoilRunningItem)
            _PreRunningCoilRunningItem = value
            'If IsNothing(_PreRunningCoilRunningItem) Then
            'Else
            'End If
        End Set
    End Property

#End Region
#Region "目前正在執行鋼捲節點項目 屬性:CurrentRunningCoilScanedTreeNode"

    Private _CurrentRunningCoilScanedTreeNode As CoilScanedTreeNode
    ''' <summary>
    ''' 目前正在執行鋼捲節點項目
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentRunningCoilScanedTreeNode() As CoilScanedTreeNode
        Get
            Return _CurrentRunningCoilScanedTreeNode
        End Get
        Private Set(ByVal value As CoilScanedTreeNode)
            If Not IsNothing(_CurrentRunningCoilScanedTreeNode) Then
                RemoveHandler _CurrentRunningCoilScanedTreeNode.CoilRunningOrderNumberChanged, AddressOf CoilScanTreeNodeNumberChanged
            End If
            _CurrentRunningCoilScanedTreeNode = value
            If Not IsNothing(_CurrentRunningCoilScanedTreeNode) Then
                AddHandler _CurrentRunningCoilScanedTreeNode.CoilRunningOrderNumberChanged, AddressOf CoilScanTreeNodeNumberChanged
            End If
            If IsNothing(_CurrentRunningCoilScanedTreeNode) Then
                lbCoilNumber.Text = "未知!"
            Else
                lbCoilNumber.Text = _CurrentRunningCoilScanedTreeNode.CoilFullNumber
                If Me.CurrentRunningCoilScanedTreeNode.IsWillShowCoilRunningOrder Then
                    lbCoilNumber.Text = CurrentRunningCoilScanedTreeNode.CoilRunningOrderNumber & "." & lbCoilNumber.Text
                End If
            End If
        End Set
    End Property

#End Region
#Region "下一個正在執行鋼捲CoilRunningItem 屬性:NextRunningCoilRunningItem"

    Private _NextRunningCoilRunningItem As CoilRunningItem
    ''' <summary>
    ''' 下一個正在執行鋼捲CoilRunningItem
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NextRunningCoilRunningItem() As CoilRunningItem
        Get
            Return _NextRunningCoilRunningItem
        End Get
        Private Set(ByVal value As CoilRunningItem)
            _NextRunningCoilRunningItem = value
        End Set
    End Property

#End Region

#Region "鋼捲資料節點變更畫面處理 函式:CoilScanTreeNodeNumberChanged"
    ''' <summary>
    ''' 鋼捲資料節點變更畫面處理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="NewCoilNumber"></param>
    ''' <remarks></remarks>
    Private Sub CoilScanTreeNodeNumberChanged(ByVal sender As CoilScanedTreeNode, ByVal NewCoilNumber As String)

        lbCoilNumber.Text = sender.CoilFullNumber
        If sender.IsWillShowCoilRunningOrder Then
            lbCoilNumber.Text = sender.CoilRunningOrderNumber & "." & lbCoilNumber.Text
            lbCoilNumberTitle.Text = "鋼捲編號" & IIf(Me.CurrentRunningCoilScanedTreeNode.CoilScanWaitProcessNumber = 1, "(U):", "(D):")
        End If
    End Sub
#End Region

#Region "取得所有連接之鋼捲(左尾:Tail右頭:Head) 屬性:TailLeftToHeadRightAllCoilRunningItems"
    ''' <summary>
    ''' 取得所有連接之鋼捲(左尾:Tail右頭:Head)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailLeftToHeadRightAllCoilRunningItems As List(Of CoilRunningItem)
        Get
            Dim ReturnValue As New List(Of CoilRunningItem)
            Dim NextItem As CoilRunningItem = Me.TailCoilRunningItem
            Do
                ReturnValue.Add(NextItem)
                NextItem = NextItem.NextRunningCoilRunningItem
            Loop While Not IsNothing(NextItem)
            Return ReturnValue
        End Get
    End Property
#End Region

#Region "插入CoilRunning至控制項節點頭端 方法:InsertCoilRunningItemToItemHead"
    ''' <summary>
    ''' 插入CoilRunning至控制項節點頭端
    ''' </summary>
    ''' <param name="InsertItem"></param>
    ''' <remarks></remarks>
    Public Sub InsertCoilRunningItemToItemHead(ByVal InsertItem As CoilRunningItem)
        If IsNothing(Me.NextRunningCoilRunningItem) Then
            Me.NextRunningCoilRunningItem = InsertItem
            InsertItem.PreRunningCoilRunningItem = Me
        Else
            InsertItem.NextRunningCoilRunningItem = Me.NextRunningCoilRunningItem
            InsertItem.PreRunningCoilRunningItem = Me
            Me.NextRunningCoilRunningItem.PreRunningCoilRunningItem = InsertItem
            Me.NextRunningCoilRunningItem = InsertItem
        End If
        RaiseEvent InsertCoilRunningItemToHead(InsertItem)
    End Sub
#End Region
#Region "插入CoilRunning至控制項節點尾端(左) 方法:InsertCoilRunningItemToItemTail"
    ''' <summary>
    ''' 插入CoilRunning至控制項節點尾端(左)
    ''' </summary>
    ''' <param name="InsertItem"></param>
    ''' <remarks></remarks>
    Public Sub InsertCoilRunningItemToItemTail(ByVal InsertItem As CoilRunningItem)
        If IsNothing(Me.PreRunningCoilRunningItem) Then
            Me.PreRunningCoilRunningItem = InsertItem
            InsertItem.NextRunningCoilRunningItem = Me
        Else
            InsertItem.PreRunningCoilRunningItem = Me.PreRunningCoilRunningItem
            InsertItem.NextRunningCoilRunningItem = Me
            Me.PreRunningCoilRunningItem.NextRunningCoilRunningItem = InsertItem
            Me.PreRunningCoilRunningItem = InsertItem
        End If
        RaiseEvent InsertCoilRunningItemToTail(InsertItem)
    End Sub
#End Region
#Region "加入CoilRunning至控制項節點頭端 方法:AddCoilRunningItemToItemTopHead"
    ''' <summary>
    ''' 加入CoilRunning至控制項節點頭端
    ''' </summary>
    ''' <param name="AddItem"></param>
    ''' <remarks></remarks>
    Public Sub AddCoilRunningItemToItemTopHead(ByVal AddItem As CoilRunningItem)
        Dim TopHeadCoilRunningItem As CoilRunningItem = TailLeftToHeadRightAllCoilRunningItems.LastOrDefault
        If IsNothing(TopHeadCoilRunningItem Is Me) Then
            Me.NextRunningCoilRunningItem = AddItem
            AddItem.PreRunningCoilRunningItem = Me
        Else
            TopHeadCoilRunningItem.NextRunningCoilRunningItem = AddItem
            AddItem.PreRunningCoilRunningItem = TopHeadCoilRunningItem
        End If
    End Sub
#End Region
#Region "移除連結中某節點 Shared方法:RemoveCoilRunningItem"
    ''' <summary>
    ''' 移除連結中某節點
    ''' </summary>
    ''' <param name="AnyCoilRunningItem"></param>
    ''' <param name="RemoveItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function RemoveCoilRunningItem(ByVal AnyCoilRunningItem As CoilRunningItem, ByVal RemoveItem As CoilRunningItem, ByRef NewTailCoilRunningItem As CoilRunningItem) As Boolean
        For Each EachItem As CoilRunningItem In GetTailToHeadCoilRunningItems(AnyCoilRunningItem)
            If EachItem.CurrentRunningCoilScanedTreeNode Is RemoveItem.CurrentRunningCoilScanedTreeNode Then
                Select Case True
                    Case IsNothing(RemoveItem.PreRunningCoilRunningItem) AndAlso IsNothing(RemoveItem.NextRunningCoilRunningItem)
                        NewTailCoilRunningItem = Nothing
                        RaiseEvent RemoveCoilRunningItemEvent(RemoveItem, NewTailCoilRunningItem)
                    Case IsNothing(RemoveItem.PreRunningCoilRunningItem) AndAlso Not IsNothing(RemoveItem.NextRunningCoilRunningItem)
                        RemoveItem.NextRunningCoilRunningItem.PreRunningCoilRunningItem = Nothing
                        NewTailCoilRunningItem = RemoveItem.NextRunningCoilRunningItem
                        RaiseEvent RemoveCoilRunningItemEvent(RemoveItem, NewTailCoilRunningItem)
                    Case Not IsNothing(RemoveItem.PreRunningCoilRunningItem) AndAlso IsNothing(RemoveItem.NextRunningCoilRunningItem)
                        RemoveItem.PreRunningCoilRunningItem.NextRunningCoilRunningItem = Nothing
                        NewTailCoilRunningItem = RemoveItem.PreRunningCoilRunningItem
                        RaiseEvent RemoveCoilRunningItemEvent(RemoveItem, NewTailCoilRunningItem)
                    Case Not IsNothing(RemoveItem.PreRunningCoilRunningItem) AndAlso Not IsNothing(RemoveItem.NextRunningCoilRunningItem)
                        RemoveItem.PreRunningCoilRunningItem.NextRunningCoilRunningItem = RemoveItem.NextRunningCoilRunningItem
                        RemoveItem.NextRunningCoilRunningItem.PreRunningCoilRunningItem = RemoveItem.PreRunningCoilRunningItem
                        NewTailCoilRunningItem = RemoveItem.PreRunningCoilRunningItem.TailCoilRunningItem
                        RaiseEvent RemoveCoilRunningItemEvent(RemoveItem, NewTailCoilRunningItem)
                End Select

                Return True
            End If
        Next
        Return False
    End Function
#End Region

#Region "頭端(即將結束作業)HeadeCoilRunningItem 屬性:HeadeCoilRunningItem"
    ''' <summary>
    ''' 頭端(即將結束作業)HeadeCoilRunningItem
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property HeadeCoilRunningItem As CoilRunningItem
        Get
            Dim ReturnValue As CoilRunningItem = Me
            Do While Not IsNothing(ReturnValue.NextRunningCoilRunningItem)
                ReturnValue = ReturnValue.NextRunningCoilRunningItem
            Loop
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "尾端(剛開始作業)TailCoilRunningItem 屬性:TailCoilRunningItem"
    ''' <summary>
    ''' 尾端(剛開始作業)HeadeCoilRunning
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailCoilRunningItem As CoilRunningItem
        Get
            Dim ReturnValue As CoilRunningItem = Me
            Do While Not IsNothing(ReturnValue.PreRunningCoilRunningItem)
                ReturnValue = ReturnValue.PreRunningCoilRunningItem
            Loop
            Return ReturnValue
        End Get
    End Property
#End Region

#Region "取得由尾端至頭端所有RunningItem 方法:GetTailToHeadCoilRunningItems"
    ''' <summary>
    ''' 取得由尾端至頭端所有RunningItem
    ''' </summary>
    ''' <param name="AnyCoilRunningItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetTailToHeadCoilRunningItems(ByVal AnyCoilRunningItem As CoilRunningItem) As List(Of CoilRunningItem)
        Dim ReturnValue As New List(Of CoilRunningItem)
        If IsNothing(AnyCoilRunningItem) Then
            Return ReturnValue
        End If
        Dim TailItem As CoilRunningItem = AnyCoilRunningItem.TailCoilRunningItem
        ReturnValue.Add(TailItem)
        Do While Not IsNothing(TailItem.NextRunningCoilRunningItem)
            ReturnValue.Add(TailItem.NextRunningCoilRunningItem)
            TailItem = TailItem.NextRunningCoilRunningItem
        Loop
        Return ReturnValue
    End Function
#End Region
#Region "變更前後CoilRunningItem位置 方法:ChangeTwoCoilRunningItemPosition"
    ''' <summary>
    ''' 變更前後CoilRunningItem位置
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ChangeTwoCoilRunningItemPosition(ByVal SourceCoilRunningItem As CoilRunningItem, ByVal MovePositionDirection As MovePositionDirectionEnum) As Boolean
        Select Case True
            Case MovePositionDirection = MovePositionDirectionEnum.MoveToHeadDirection AndAlso IsNothing(SourceCoilRunningItem.NextRunningCoilRunningItem)
                Return False
            Case MovePositionDirection = MovePositionDirectionEnum.MoveToTailDirection AndAlso IsNothing(SourceCoilRunningItem.PreRunningCoilRunningItem)
                Return False
            Case MovePositionDirection = MovePositionDirectionEnum.MoveToHeadDirection
                ChangeTwoCurrentRunningCoilScanedTreeNode(SourceCoilRunningItem, SourceCoilRunningItem.NextRunningCoilRunningItem)
            Case MovePositionDirection = MovePositionDirectionEnum.MoveToTailDirection
                ChangeTwoCurrentRunningCoilScanedTreeNode(SourceCoilRunningItem, SourceCoilRunningItem.PreRunningCoilRunningItem)
        End Select
        Return True
    End Function

    Private Sub ChangeTwoCurrentRunningCoilScanedTreeNode(ByVal SourceCoilRunningItem1 As CoilRunningItem, ByVal SourceCoilRunningItem2 As CoilRunningItem)
        Dim TempCurrentRunningCoilScanedTreeNode As CoilScanedTreeNode = SourceCoilRunningItem1.CurrentRunningCoilScanedTreeNode
        SourceCoilRunningItem1.CurrentRunningCoilScanedTreeNode = SourceCoilRunningItem2.CurrentRunningCoilScanedTreeNode
        SourceCoilRunningItem2.CurrentRunningCoilScanedTreeNode = TempCurrentRunningCoilScanedTreeNode
        Select Case True
            Case SourceCoilRunningItem1.IsCurrentEditCoilData
                SourceCoilRunningItem2.IsCurrentEditCoilData = True
            Case SourceCoilRunningItem2.IsCurrentEditCoilData = True
                SourceCoilRunningItem1.IsCurrentEditCoilData = True
        End Select

    End Sub

    Private Enum MovePositionDirectionEnum
        MoveToHeadDirection = 1
        MoveToTailDirection = 2
    End Enum
#End Region

#Region "退回等待區事件 事件:BackToWaitArea"
    ''' <summary>
    ''' 退回等待區事件
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <remarks></remarks>
    Public Shared Event BackToWaitArea(ByVal Sender As CoilRunningItem, ByVal NewTailCoilRunningItem As CoilRunningItem)
#End Region
#Region "完成操作事件 事件:FinishProcess"
    ''' <summary>
    ''' 完成操作事件
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <remarks></remarks>
    Public Shared Event FinishProcess(ByVal Sender As CoilRunningItem, ByVal NewTailCoilRunningItem As CoilRunningItem)
#End Region

#Region "鋼捲順序交換事件/通知事件方法 事件:CoilOrderChanged/函式:NotifyCoilOrderChanged"
    ''' <summary>
    ''' 鋼捲順序交換事件
    ''' </summary>
    ''' <param name="NewTailLeftToHeadRightAllCoilRunningItems"></param>
    ''' <remarks></remarks>
    Public Shared Event CoilOrderChanged(ByVal Sender As CoilRunningItem, NewTailLeftToHeadRightAllCoilRunningItems As List(Of CoilRunningItem))
    ''' <summary>
    ''' 通知事件方法
    ''' </summary>
    ''' <param name="NewTailLeftToHeadRightAllCoilRunningItems"></param>
    ''' <remarks></remarks>
    Private Sub NotifyCoilOrderChangedSendEvent(ByVal Sender As CoilRunningItem, NewTailLeftToHeadRightAllCoilRunningItems As List(Of CoilRunningItem))
        RaiseEvent CoilOrderChanged(Sender, NewTailLeftToHeadRightAllCoilRunningItems)
    End Sub
#End Region
#Region "插入CoilRunningItem至頭端事件 Shared事件:InsertCoilRunningItemToHead"
    ''' <summary>
    ''' 插入CoilRunningItem至頭端事件
    ''' </summary>
    ''' <param name="InsertControl"></param>
    ''' <remarks></remarks>
    Public Shared Event InsertCoilRunningItemToHead(ByVal InsertControl As CoilRunningItem)
#End Region
#Region "插入CoilRunningItem至尾端事件 Shared事件:InsertCoilRunningItemToTail"
    ''' <summary>
    ''' 插入CoilRunningItem至尾端事件
    ''' </summary>
    ''' <param name="InsertControl"></param>
    ''' <remarks></remarks>
    Public Shared Event InsertCoilRunningItemToTail(ByVal InsertControl As CoilRunningItem)
#End Region
#Region "移除連結中某節點事件 Shared方法:RemoveCoilRunningItemEvent"
    ''' <summary>
    ''' 移除連結中某節點事件
    ''' </summary>
    ''' <param name="RemoveItem"></param>
    ''' <param name="NewTailCoilRunningItem"></param>
    ''' <remarks></remarks>
    Public Shared Event RemoveCoilRunningItemEvent(ByVal RemoveItem As CoilRunningItem, ByVal NewTailCoilRunningItem As CoilRunningItem)
#End Region
#Region "編修並顯示詳細資料事件 Shared事件:EditAndShowDetailData"
    ''' <summary>
    ''' 編修並顯示詳細資料事件
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <remarks></remarks>
    Public Shared Event EditAndShowDetailData(ByVal Sender As CoilRunningItem)
#End Region
#Region "是否正在編輯鋼捲資料 屬性:IsCurrentEditCoilData"

    Private _IsCurrentEditCoilData As Boolean
    Public Property IsCurrentEditCoilData() As Boolean
        Get
            Return _IsCurrentEditCoilData
        End Get
        Set(ByVal value As Boolean)
            _IsCurrentEditCoilData = value
            If _IsCurrentEditCoilData Then
                EditButton.BackColor = Color.LightBlue
            Else
                EditButton.BackColor = Color.Transparent
            End If
            ChangeOtherCoilRunningItemCurrentEditButtonColor(Color.Transparent)
        End Set
    End Property

    Private Sub ChangeOtherCoilRunningItemCurrentEditButtonColor(ByVal SetColor As Color)
        Dim NextControl As CoilRunningItem = Me.PreRunningCoilRunningItem
        Do While Not IsNothing(NextControl)
            NextControl.EditButton.BackColor = SetColor
            NextControl = NextControl.PreRunningCoilRunningItem
        Loop
        NextControl = Me.NextRunningCoilRunningItem
        Do While Not IsNothing(NextControl)
            NextControl.EditButton.BackColor = SetColor
            NextControl = NextControl.NextRunningCoilRunningItem
        Loop
    End Sub
#End Region


#Region "是否為快送鍵命令  屬性:IsQuickKeyCommand"
    Private _IsQuickKeyCommand As Boolean = False
    ''' <summary>
    ''' 是否為快送鍵命令
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property IsQuickKeyCommand() As Boolean
        Get
            Return _IsQuickKeyCommand
        End Get
        Set(ByVal value As Boolean)
            _IsQuickKeyCommand = value
        End Set
    End Property

#End Region
#Region "傳送快送鍵命令 函式:MoveBackOrFront"
    ''' <summary>
    ''' 傳送快送鍵命令
    ''' </summary>
    ''' <param name="IsMoveToFront"></param>
    ''' <remarks></remarks>
    Public Sub MoveBackOrFront(ByVal IsMoveToFront As Boolean)
        IsQuickKeyCommand = True
        Call tbMoveBack_Click(IIf(IsMoveToFront, tbMoveFront, tbMoveBack), Nothing)
    End Sub
#End Region



    Public Sub New(ByVal SetRunningTreeNode As CoilScanedTreeNode)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.CurrentRunningCoilScanedTreeNode = SetRunningTreeNode
        lbCoilNumberTitle.Text = "鋼捲編號" & IIf(Me.CurrentRunningCoilScanedTreeNode.CoilScanWaitProcessNumber = 1, "(U):", "(D):")
    End Sub

    Private Sub tbMoveBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMoveBack.Click, tbMoveFront.Click
        Dim NewTailCoilRunningItem As CoilRunningItem = Nothing
        Select Case True
            Case sender Is tbMoveBack AndAlso ChangeTwoCoilRunningItemPosition(Me, MovePositionDirectionEnum.MoveToTailDirection) = False
                If IsQuickKeyCommand OrElse MsgBox("是確定將此鋼捲退移至等待處理區!", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RemoveCoilRunningItem(Me, Me, NewTailCoilRunningItem)
                    If Me.IsCurrentEditCoilData Then
                        Me.IsCurrentEditCoilData = False
                    End If
                    RaiseEvent BackToWaitArea(Me, NewTailCoilRunningItem)
                End If
            Case sender Is tbMoveFront AndAlso ChangeTwoCoilRunningItemPosition(Me, MovePositionDirectionEnum.MoveToHeadDirection) = False
                If IsQuickKeyCommand OrElse MsgBox("是確定將此鋼捲手動移至處理完成置放區!", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RemoveCoilRunningItem(Me, Me, NewTailCoilRunningItem)
                    If Me.IsCurrentEditCoilData Then
                        Me.IsCurrentEditCoilData = False
                    End If
                    RaiseEvent FinishProcess(Me, NewTailCoilRunningItem)
                End If
            Case Else
                '觸發所有線上生產之控制項事件(生產順序改變)
                For Each EachItem As CoilRunningItem In Me.TailLeftToHeadRightAllCoilRunningItems
                    EachItem.NotifyCoilOrderChangedSendEvent(Me, Me.TailLeftToHeadRightAllCoilRunningItems)
                Next
        End Select
        IsQuickKeyCommand = False
    End Sub

    Public Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click
        Me.IsCurrentEditCoilData = True
        RaiseEvent EditAndShowDetailData(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Me.PreRunningCoilRunningItem = Nothing
        Me.NextRunningCoilRunningItem = Nothing
        MyBase.Finalize()
    End Sub
End Class
