Public Class NumberKeyboard

    Public Event ButtonClickEvent(sender As Object, ByVal Value As String)

#Region "限定那些按鈕啟用 函式:SetButtonEnableOnly"
    ''' <summary>
    ''' 限定那些按鈕啟用
    ''' </summary>
    ''' <param name="ButtonDisplayNames"></param>
    ''' <remarks></remarks>
    Public Sub SetButtonVisibleOnly(ByVal ButtonDisplayNames() As String)
        For Each EachItem As Button In TableLayoutPanel1.Controls
            EachItem.Visible = ButtonDisplayNames.Contains(EachItem.Text.ToUpper)
        Next
    End Sub
#End Region
#Region "變更按鈕顯示名稱 函式:ChangeButtonDisplayName"
    ''' <summary>
    ''' 變更按鈕顯示名稱
    ''' </summary>
    ''' <param name="OrginDisplayName"></param>
    ''' <param name="NewDisplayName"></param>
    ''' <remarks></remarks>
    Public Sub ChangeButtonDisplayName(ByVal OrginDisplayName As String, ByVal NewDisplayName As String)
        For Each EachItem As Button In TableLayoutPanel1.Controls
            If EachItem.Text = OrginDisplayName Then
                EachItem.Text = NewDisplayName
            End If
        Next
    End Sub
#End Region

#Region "輸入模式 屬性:InputMode"
    Private _InputMode As InputModeEnum = InputModeEnum.UnKnow
    ''' <summary>
    ''' 輸入模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InputMode As InputModeEnum
        Get
            Return _InputMode
        End Get
        Set(value As InputModeEnum)
            If value <> _InputMode Then
                _InputMode = value
                RefreshControlEnableOrVisible()
                Exit Property
            End If
            _InputMode = value
        End Set
    End Property
#End Region
#Region "輸入模式列舉 列舉:InputModeEnum"
    ''' <summary>
    ''' 輸入模式列舉
    ''' </summary>
    ''' <remarks></remarks>
    Enum InputModeEnum
        UnKnow = 1
        Density = 2
        DistributeLocationType = 3
        PosOrNegInput = 4
    End Enum
#End Region
#Region "重整顯示 函式:RefreshControlEnableOrVisible"
    ''' <summary>
    ''' 重整顯示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshControlEnableOrVisible()
        For Each EachButton As Button In Me.Controls(0).Controls
            EachButton.Visible = True
            EachButton.Enabled = True
            EachButton.Text = EachButton.Tag
        Next
        Select Case InputMode
            Case InputModeEnum.Density
                For Each EachButton As Button In Me.Controls(0).Controls
                    If {"7", "8", "9"}.Contains(EachButton.Text) Then
                        EachButton.Enabled = False
                    End If
                Next
            Case InputModeEnum.DistributeLocationType
                With Me
                    .SetButtonVisibleOnly({"1", "2", "3", "4", "5", "確認"})
                    .ChangeButtonDisplayName("1", "1內")
                    .ChangeButtonDisplayName("2", "2外")
                    .ChangeButtonDisplayName("3", "3全")
                    .ChangeButtonDisplayName("4", "4雙")
                    .ChangeButtonDisplayName("5", "5無")
                End With
            Case InputModeEnum.PosOrNegInput
                With Me
                    .SetButtonVisibleOnly({"1", "2", "3", "確認"})
                    .ChangeButtonDisplayName("1", "1正")
                    .ChangeButtonDisplayName("2", "2反")
                    .ChangeButtonDisplayName("3", "3雙")
                End With

        End Select

    End Sub
#End Region


    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btnDot.Click, btnDELETE.Click, btnCLEAR.Click, btnOK.Click
        Dim SenderControl As Button = sender
        RaiseEvent ButtonClickEvent(Me, SenderControl.Name.Replace("btn", Nothing).ToUpper)
    End Sub

End Class
