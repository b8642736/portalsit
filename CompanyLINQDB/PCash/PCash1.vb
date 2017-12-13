Partial Public Class PCash1

    Dim DBContext As New PCashDataContext

#Region "相關PCash2 屬性:About_PCash2"
    Dim _About_PCash2 As PCash2 = Nothing
    Dim _About_PCash2_IsAlreadyGet As Boolean = False
    ''' <summary>
    ''' 相關PCash2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property About_PCash2() As PCash2
        Get
            If IsNothing(_About_PCash2) Then
                If _About_PCash2_IsAlreadyGet Then
                    Return Nothing
                End If
                Dim GetPCash3 As PCash3 = (From A In DBContext.PCash3 Where A.PC1RecDate = Me.RecDate And A.PC1Number = Me.Number Select A).FirstOrDefault
                If IsNothing(GetPCash3) Then
                    Return Nothing
                End If
                _About_PCash2 = (From A In DBContext.PCash2 Where A.RecDate = GetPCash3.PC2RecDate And A.Number = GetPCash3.PC2Number Select A).FirstOrDefault
            End If
            Return _About_PCash2
        End Get
    End Property
#End Region

#Region "使用單位中文 屬性:DepCodeChinese"
    ''' <summary>
    ''' 使用單位中文
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DepCodeChinese() As String
        Get
            If IsNothing(Me.DepCode) OrElse String.IsNullOrEmpty(Me.DepCode) Then
                Return Nothing
            End If
            Dim GetPCash4 As PCash4 = (From A In DBContext.PCash4 Where A.DepCode = Me.DepCode Select A).FirstOrDefault
            If IsNothing(GetPCash4) Then
                Return Nothing
            End If
            Return GetPCash4.DepName
        End Get
    End Property
#End Region

#Region "報銷憑證號碼 屬性:ToPCash2_Number"
    ''' <summary>
    ''' 報銷憑證號碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ToPCash2_Number() As Integer
        Get
            If IsNothing(About_PCash2) Then
                Return 0
            End If
            Return About_PCash2.Number
        End Get
    End Property
#End Region

#Region "報銷憑證日期 屬性:ToPCash2_RecDate"
    ''' <summary>
    ''' 報銷憑證日期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ToPCash2_RecDate() As DateTime
        Get
            If IsNothing(About_PCash2) Then
                Return Nothing
            End If
            Return About_PCash2.RecDate
        End Get
    End Property
#End Region

#Region "憑證是否已兌現 屬性:IsToCashed"
    ''' <summary>
    ''' 憑證是否已兌現
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsToCashed() As Nullable(Of Boolean)
        Get
            If IsNothing(About_PCash2) Then
                Return Nothing
            End If
            Return About_PCash2.IsToCashed
        End Get
    End Property
#End Region

End Class
