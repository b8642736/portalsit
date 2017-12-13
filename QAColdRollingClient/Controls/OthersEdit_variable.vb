Public Class OthersEdit_variable



#Region "紀錄其他頁籤上下收狀態"

    Private Shared Property _upDownStatus As String = ""
    Public Shared Property upDown_Status()
        Get
            Return _upDownStatus
        End Get
        Set(ByVal Value)
            If Value = "下收" Then
                _upDownStatus = "下收"
            ElseIf Value = "上收" Then
                _upDownStatus = "上收"
            Else
                _upDownStatus = "none"
            End If
        End Set
    End Property
#End Region


End Class
