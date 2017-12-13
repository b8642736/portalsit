Public Class SiteGroupToSite
    Dim DBDataContext As New IMDataContext

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
#Region "相關Site 屬性:AboutSite"

    Private _AboutSite As Site
    ''' <summary>
    ''' 相關Message
    ''' </summary>
    ''' <param name="CacheData"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutSite(Optional ByVal CacheData As List(Of Site) = Nothing) As Site
        Get
            If IsNothing(_AboutSite) Then
                If Not IsNothing(CacheData) Then
                    For Each EachItem As Site In CacheData
                        If EachItem.ID = Me.FK_SiteID Then
                            _AboutSite = EachItem
                            Exit For
                        End If
                    Next
                Else
                    _AboutSite = (From A In DBDataContext.Site Where A.ID = Me.FK_SiteID Select A).FirstOrDefault
                End If
            End If
            Return _AboutSite
        End Get
        Private Set(ByVal value As Site)
            _AboutSite = value
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
#Region "相關Site_SiteName 屬性:Site_SiteName"
    ''' <summary>
    ''' 相關Site_SiteName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Site_SiteName() As String
        Get
            If IsNothing(Me.AboutSite) Then
                Return Nothing
            End If
            Return Me.AboutSite.SiteName
        End Get
    End Property
#End Region

End Class
