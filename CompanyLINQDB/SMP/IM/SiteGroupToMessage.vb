Partial Public Class SiteGroupToMessage

    Dim DBDataContext As New IMDataContext

#Region "訊息模式說明 屬性:ReadWriteModeString"
    ''' <summary>
    ''' 訊息模式說明
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ReadWriteModeString() As String
        Get
            Select Case True
                Case Me.ReadWriteMode = 0
                    Return "可傳送/可接收"
                Case Me.ReadWriteMode = 1
                    Return "只可傳送"
                Case Me.ReadWriteMode = 2
                    Return "只可接收"
                Case Else
                    Return Nothing
            End Select
        End Get
    End Property
#End Region

#Region "相關SiteGroup 屬性:AboutSiteGroup"

    Private _AboutSiteGroup As SiteGroup
    ''' <summary>
    ''' 相關SiteGroup
    ''' </summary>
    ''' <param name="CacheData"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutSiteGroup(Optional ByVal CacheData As List(Of SiteGroup) = Nothing) As SiteGroup
        Get
            If IsNothing(_AboutSiteGroup) Then
                If Not IsNothing(CacheData) Then
                    For Each EachItem As SiteGroup In CacheData
                        If EachItem.ID = Me.FK_SiteGroupID Then
                            _AboutSiteGroup = EachItem
                            Exit For
                        End If
                    Next
                Else
                    _AboutSiteGroup = (From A In DBDataContext.SiteGroup Where A.ID = Me.FK_SiteGroupID Select A).FirstOrDefault
                End If
            End If
            Return _AboutSiteGroup
        End Get
        Private Set(ByVal value As SiteGroup)
            _AboutSiteGroup = value
        End Set
    End Property

#End Region
#Region "相關Message 屬性:AboutMessage"

    Private _AboutMessage As Message
    ''' <summary>
    ''' 相關Message
    ''' </summary>
    ''' <param name="CacheData"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutMessage(Optional ByVal CacheData As List(Of Message) = Nothing) As Message
        Get
            If IsNothing(_AboutMessage) Then
                If Not IsNothing(CacheData) Then
                    For Each EachItem As Message In CacheData
                        If EachItem.ID = Me.FK_MessageID Then
                            _AboutMessage = EachItem
                            Exit For
                        End If
                    Next
                Else
                    _AboutMessage = (From A In DBDataContext.Message Where A.ID = Me.FK_MessageID Select A).FirstOrDefault
                End If
            End If
            Return _AboutMessage
        End Get
        Private Set(ByVal value As Message)
            _AboutMessage = value
        End Set
    End Property

#End Region
#Region "相關SiteGroup_GroupName 屬性:SiteGroup_GroupName"
    ''' <summary>
    ''' 相關SiteGroup_GroupName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SiteGroup_GroupName() As String
        Get
            If IsNothing(Me.AboutSiteGroup) Then
                Return Nothing
            End If
            Return Me.AboutSiteGroup.GroupName
        End Get
    End Property
#End Region
#Region "相關Message_MsgText 屬性:AboutMessage_MsgText"
    ''' <summary>
    ''' 相關Message_MsgText
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AboutMessage_MsgText() As String
        Get
            If IsNothing(Me.AboutMessage) Then
                Return Nothing
            End If
            Return Me.AboutMessage.MsgText
        End Get
    End Property

#End Region

End Class
