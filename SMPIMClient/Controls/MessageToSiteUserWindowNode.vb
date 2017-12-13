''' <summary>
''' 訊息節點
''' </summary>
''' <remarks></remarks>
Public Class MessageToSiteUserWindowNode
    Inherits TreeNode

    Sub New(ByVal SetOrginMessageToSiteUsers As MessageToSiteUsers, Optional ByVal CachSiteUsers As List(Of SiteUser) = Nothing)
        OrginMessageToSiteUsers = SetOrginMessageToSiteUsers
        Me.Text = Me.OrginMessageToSiteUsers.MsgText.Trim & "(" & OrginMessageToSiteUsers.SendTime & ")"
        Me.Text &= IIf(SetOrginMessageToSiteUsers.ReceiveMessageRole(CachSiteUsers) = MessageToSiteUsers.ReceiveMessageRoleEnum.Receiver, "遠端訊息!", Nothing)
    End Sub

#Region "原始MessageToSiteUsers 屬性:OrginMessageToSiteUsers"

    Private _OrginMessageToSiteUsers As MessageToSiteUsers
    ''' <summary>
    ''' 原始MessageToSiteUsers
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrginMessageToSiteUsers() As MessageToSiteUsers
        Get
            Return _OrginMessageToSiteUsers
        End Get
        Private Set(ByVal value As MessageToSiteUsers)
            _OrginMessageToSiteUsers = value
        End Set
    End Property

#End Region
    '#Region "重整控制項圖示 函式:RefreshNodeImage"
    '        ''' <summary>
    '        ''' 重整控制項圖示
    '        ''' </summary>
    '        ''' <remarks></remarks>
    '        Private Sub RefreshNodeImage()
    '            Dim MessageRole As MessageToSiteUsers.ReceiveMessageRoleEnum = Me.OrginMessageToSiteUsers.ReceiveMessageRole

    '            Select Case True
    '                Case MessageRole = MessageToSiteUsers.ReceiveMessageRoleEnum.SenderAndReceiver
    '                    Select Case True
    '                        Case OrginMessageToSiteUsers.SenderMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck AndAlso OrginMessageToSiteUsers.ReceiverMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck
    '                            Me.ImageIndex = 3
    '                        Case OrginMessageToSiteUsers.ReceiverMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck
    '                            Me.ImageIndex = 1
    '                        Case OrginMessageToSiteUsers.SenderMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck
    '                            Me.ImageIndex = 2
    '                        Case Else
    '                            Me.ImageIndex = 4
    '                    End Select
    '                Case MessageRole = MessageToSiteUsers.ReceiveMessageRoleEnum.Receiver AndAlso OrginMessageToSiteUsers.ReceiverMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck
    '                    Me.ImageIndex = 1
    '                Case MessageRole = MessageToSiteUsers.ReceiveMessageRoleEnum.Sender AndAlso OrginMessageToSiteUsers.SenderMessageCheckState = MessageToSiteUsers.MessageCheckStateEnum.WaitCheck
    '                    Me.ImageIndex = 2
    '                Case Else
    '                    Me.ImageIndex = 4
    '            End Select
    '        End Sub
    '#End Region
#Region "重整所有訊息節點圖示 函式:RefreshAllNodesIcon"
    ''' <summary>
    ''' 重整所有訊息節點圖示
    ''' </summary>
    ''' <param name="Nodes"></param>
    ''' <remarks></remarks>
    Public Shared Sub RefreshAllNodesIcon(ByVal Nodes As List(Of TreeNode))
        For Each EachItem As MessageToSiteUserWindowNode In Nodes
            'EachItem.RefreshNodeImage()
            EachItem.ImageIndex = 1
            If EachItem.Nodes.Count > 0 Then
                Dim SubNodes As New List(Of TreeNode)
                For Each EachItemSubNode As MessageToSiteUserWindowNode In EachItem.Nodes
                    SubNodes.Add(EachItemSubNode)
                Next
                Call RefreshAllNodesIcon(SubNodes)
            End If
        Next
    End Sub
    ''' <summary>
    ''' 重整所有訊息節點圖示
    ''' </summary>
    ''' <param name="Nodes"></param>
    ''' <remarks></remarks>
    Public Shared Sub RefreshAllNodesIcon(ByVal Nodes As TreeNodeCollection)
        Dim PuishData As New List(Of TreeNode)
        For Each EachItem As TreeNode In Nodes
            PuishData.Add(EachItem)
        Next
        Call RefreshAllNodesIcon(PuishData)
    End Sub

#End Region
End Class
