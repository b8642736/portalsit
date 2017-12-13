Partial Public Class AS400QueryRecord

    Private Sub OnCreated()
        Me.ID = "{" & Guid.NewGuid.ToString & "}"
        Me.RunTime = Now
        Me.IsDeleted = False
    End Sub

#Region "查詢類型說明 屬性:QueryTypeExposition"
    ''' <summary>
    ''' 查詢類型說明
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property QueryTypeExposition() As String
        Get
            Select Case Me.QueryType
                Case 0
                    Return "無法判定查詢類型"
                Case 1
                    Return "查詢"
                Case 2
                    Return "新增"
                Case 3
                    Return "修改"
                Case 4
                    Return "刪除"
            End Select
            Return Nothing
        End Get
    End Property
#End Region
End Class
