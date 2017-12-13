Partial Public Class GuestSuesWatchRecord

    Dim WebAPPAuthorityDBDataContext As New WebAPPAuthorityDataContext

#Region "Window登入者名稱 屬性:WindowLoginNameName"
    Private _WindowLoginNameName As String = Nothing
    ReadOnly Property WindowLoginNameName As String
        Get
            If IsNothing(_WindowLoginNameName) Then
                Dim LoginDatas() As String = Me.WindowLoginName.Split("\")
                If LoginDatas.Count < 2 Then
                    Return Me.WindowLoginName
                End If
                Dim GetWebLoginAccount As CompanyLINQDB.WebLoginAccount = (From A In WebAPPAuthorityDBDataContext.WebLoginAccount Where A.WindowLoginName.Trim = LoginDatas(1).Trim Select A).FirstOrDefault
                If IsNothing(GetWebLoginAccount) Then
                    _WindowLoginNameName = Me.WindowLoginName
                    Return _WindowLoginNameName
                End If
                _WindowLoginNameName = GetWebLoginAccount.DisplayName
            End If
            Return _WindowLoginNameName
        End Get
    End Property
#End Region
End Class
