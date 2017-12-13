Public Class NonRadioactive_Main
    Inherits System.Web.UI.UserControl
    Public Enum 主畫面_Enum
        查詢 = 0
        編修 = 1
        列印 = 2
    End Enum

    Private Sub P_reFresh父物件(from主畫面_ActiveTabIndex As 主畫面_Enum, ByVal labno As String, ByVal subno As Int32) _
        Handles NonRadioactive_Edit1.Event_reFresh父物件, _
                NonRadioactive_Search1.Event_reFresh父物件
        TabContainer1.ActiveTabIndex = from主畫面_ActiveTabIndex

        Select Case from主畫面_ActiveTabIndex
            Case 主畫面_Enum.列印
                NonRadioactive_Print1.P_reFresh子物件(labno, subno)
            Case 主畫面_Enum.查詢
                If labno IsNot Nothing Then
                    NonRadioactive_Search1.P_reFresh子物件(labno)
                Else
                    NonRadioactive_Search1.P_reFresh子物件()
                End If

            Case 主畫面_Enum.編修
                If labno IsNot Nothing Then
                    NonRadioactive_Edit1.P_reFresh子物件(labno, subno)
                Else
                    NonRadioactive_Edit1.P_reFresh子物件(True)
                End If

        End Select
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TabContainer1.ActiveTabIndex = 主畫面_Enum.查詢
        End If
    End Sub

    Protected Sub TabContainer1_ActiveTabChanged(sender As Object, e As EventArgs) Handles TabContainer1.ActiveTabChanged
        Select Case TabContainer1.ActiveTabIndex
            Case 主畫面_Enum.查詢
            Case 主畫面_Enum.編修
                NonRadioactive_Edit1.P_reFresh子物件(False)
            Case 主畫面_Enum.列印
                NonRadioactive_Print1.P_reFresh子物件("LOCK", Nothing)
        End Select
    End Sub
End Class