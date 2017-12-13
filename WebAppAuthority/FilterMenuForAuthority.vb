Public Module FilterMenuForAuthority

#Region "篩選顯示已授權選單 函式:FilterAuthorityMenu"
    ''' <summary>
    ''' 篩選顯示已授權選單
    ''' </summary>
    ''' <param name="SourceMenu"></param>
    ''' <remarks></remarks>
    Public Sub FilterAuthorityMenu(ByVal SourceWebPage As Page, ByVal SourceMenu As Menu)
        If SourceWebPage.IsPostBack Then
            Exit Sub
        End If
        Dim WillRemoveItems As New List(Of MenuItem)
        For Each EachItem As MenuItem In SourceMenu.Items
            WillRemoveItems.Add(EachItem)
            WillRemoveItems.AddRange(FindAllChildItems(EachItem))
        Next
        Dim NotRemoveItems As New List(Of MenuItem)
        For Each EachItem As MenuItem In WillRemoveItems
            If AppAuthority.FilterMenuForAuthority.IsPathAuthority(SourceWebPage, EachItem.Value) Then
                NotRemoveItems.AddRange(FindAllParentItemsAndMeItem(EachItem))
            End If
        Next
        For Each EachItem As MenuItem In (From A In WillRemoveItems Where Not NotRemoveItems.Contains(A) Select A).ToArray
            DeepFindMenuItemAndRemoveIt(SourceMenu.Items, EachItem)
        Next
    End Sub

    Private Function FindAllChildItems(ByVal SourceItem As MenuItem) As List(Of MenuItem)
        Dim ReturnValue As New List(Of MenuItem)
        For Each Eachitem As MenuItem In SourceItem.ChildItems
            ReturnValue.Add(Eachitem)
            If Eachitem.ChildItems.Count > 0 Then
                ReturnValue.AddRange(FindAllChildItems(Eachitem))
            End If
        Next
        Return ReturnValue
    End Function

    Private Function FindAllParentItemsAndMeItem(ByVal SourceItem As MenuItem) As List(Of MenuItem)
        Dim ReturnValue As New List(Of MenuItem)
        If Not IsNothing(SourceItem.Parent) Then
            ReturnValue.AddRange(FindAllParentItemsAndMeItem(SourceItem.Parent))
        End If
        ReturnValue.Add(SourceItem)
        Return ReturnValue
    End Function


    'Private Function IsItemAuthority(ByVal SourceWebPage As Page, ByVal SourceItem As MenuItem) As Boolean
    '    If String.IsNullOrEmpty(SourceItem.Value) Then
    '        Return False
    '    End If
    '    If SourceItem.Value.ToUpper = "PUBLIC" Then
    '        Return True
    '    End If
    '    Dim SystemFunctions() As String = SourceItem.Value.Split(",")
    '    For Each EachItem As String In SystemFunctions
    '        Dim Temps() As String = EachItem.Split("@")
    '        Select Case True
    '            Case Temps.Length = 1
    '                If WebAppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem(Temps(0), Nothing, SourceWebPage.Request.UserHostAddress) Then
    '                    Return True
    '                End If
    '            Case Temps.Length = 2
    '                If WebAppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem(Temps(0), Temps(1), SourceWebPage.Request.UserHostAddress) Then
    '                    Return True
    '                End If
    '            Case Else
    '                Continue For
    '        End Select
    '    Next
    '    Return False
    'End Function

    Public Function DeepFindMenuItemAndRemoveIt(ByVal SourceMenuItems As MenuItemCollection, ByVal RemoveItem As MenuItem) As Boolean
        For Each EachItem As MenuItem In SourceMenuItems
            If EachItem Is RemoveItem Then
                SourceMenuItems.Remove(RemoveItem)
                Return True
            End If
            If EachItem.ChildItems.Count > 0 Then
                If DeepFindMenuItemAndRemoveIt(EachItem.ChildItems, RemoveItem) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function
#End Region

    '' 1050624 By JiaRong
    '' 解決UCAjaxServerControl1相依性問題
    '' 移動至AppAuthority之FilterMenuForAuthority.vb

    '#Region "驗證授權路徑 方法:IsPathAuthority"
    '    ''' <summary>
    '    ''' 驗證授權路徑
    '    ''' </summary>
    '    ''' <param name="SourceWebPage"></param>
    '    ''' <param name="AuthorizePath"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function IsPathAuthority(ByVal SourceWebPage As Page, ByVal AuthorizePath As String) As Boolean
    '        If String.IsNullOrEmpty(AuthorizePath) Then
    '            Return False
    '        End If
    '        If AuthorizePath.ToUpper = "PUBLIC" Then
    '            Return True
    '        End If
    '        Dim SystemFunctions() As String = AuthorizePath.Split(",")
    '        For Each EachItem As String In SystemFunctions
    '            Dim Temps() As String = EachItem.Split("@")
    '            Select Case True
    '                Case Temps.Length = 1
    '                    If WebAppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem(Temps(0), Nothing, SourceWebPage.Request.UserHostAddress) Then
    '                        Return True
    '                    End If
    '                Case Temps.Length = 2
    '                    If WebAppAuthority.ValidAuthorityModule.IsCanValidAuthoritySystem(Temps(0), Temps(1), SourceWebPage.Request.UserHostAddress) Then
    '                        Return True
    '                    End If
    '                Case Else
    '                    Continue For
    '            End Select
    '        Next
    '        Return False
    '    End Function
    '#End Region

End Module
