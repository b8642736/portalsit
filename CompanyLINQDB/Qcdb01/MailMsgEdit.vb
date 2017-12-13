Partial Public Class MailMsgEdit

#Region "訊息種類名稱 屬性:MailTypeName"
    ''' <summary>
    ''' 訊息種類名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MailTypeName As String
        Get
            Select Case True
                Case Me.MailType = 1
                    Return "驗收料"
                Case Me.MailType = 2
                    Return "幅射"
                Case Me.MailType = 3
                    Return "分析超標"
                Case Else
                    Return "未知"
            End Select
        End Get
    End Property
#End Region
End Class
