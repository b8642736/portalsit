Public Class LabRecordA2_Main
    Inherits System.Web.UI.UserControl
    Public Enum 主畫面_Enum
        編修 = 0

        列印 = 1
    End Enum

    Private Sub P_reFresh父物件(from主畫面_ActiveTabIndex As 主畫面_Enum, ByVal labnoList As String) _
        Handles LabRecordA2_Search1.Event_reFresh父物件
        TabContainer1.ActiveTabIndex = from主畫面_ActiveTabIndex

        Select Case from主畫面_ActiveTabIndex
            Case 主畫面_Enum.列印
                LabRecordA2_Print1.P_reFresh子物件(labnoList)
            Case 主畫面_Enum.編修
                'If labno IsNot Nothing Then
                '    LabRecordA2_Edit1.P_reFresh子物件(labno)
                'Else
                '    LabRecordA2_Edit1.P_reFresh子物件(True)
                'End If
        End Select
    End Sub
    Private Sub P_reFresh父物件2(ByVal from主畫面_ActiveTabIndex As LabRecordA2_Main.主畫面_Enum, _
        ByVal labnoList As String, ByVal from_ds_main As QualityControlDataSet.LabRecordA2DetailsDataTable, _
        ByVal from_ds_meesage As QualityControlDataSet.LabRecordA2DetailsMessageDataTable) _
        Handles LabRecordA2_Search1.Event_reFresh父物件2
        TabContainer1.ActiveTabIndex = from主畫面_ActiveTabIndex

        Select Case from主畫面_ActiveTabIndex
            Case 主畫面_Enum.列印
                LabRecordA2_Print1.P_reFresh子物件(labnoList, from_ds_main, from_ds_meesage)
            Case 主畫面_Enum.編修
                'If labno IsNot Nothing Then
                '    LabRecordA2_Edit1.P_reFresh子物件(labno)
                'Else
                '    LabRecordA2_Edit1.P_reFresh子物件(True)
                'End If
        End Select
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TabContainer1.ActiveTabIndex = 主畫面_Enum.編修
            '參照規範 表面 鋼種 材質
            ' If Not Request.QueryString.Item("KEY3") = Nothing Or _
            'Not Request.QueryString.Item("KEY4") = Nothing Or _
            'Not Request.QueryString.Item("KEY2") = Nothing Or _
            'Not Request.QueryString.Item("KEY1") = Nothing Then
            '     TabContainer1.ActiveTabIndex = 主畫面_Enum.列印
            '     TabContainer1.Tabs(主畫面_Enum.編修).Enabled = False
            '     TabContainer1.Tabs(主畫面_Enum.檢視).Enabled = False
            ' Else
            '     TabContainer1.ActiveTabIndex = 主畫面_Enum.編修
            ' End If

        End If

    End Sub

    'Protected Sub TabContainer1_ActiveTabChanged(sender As Object, e As EventArgs) Handles TabContainer1.ActiveTabChanged
    '    Select Case TabContainer1.ActiveTabIndex
    '        Case 主畫面_Enum.查詢
    '        Case 主畫面_Enum.編修
    '            NonRadioactive_Edit1.P_reFresh子物件(False)
    '        Case 主畫面_Enum.列印
    '            NonRadioactive_Print1.P_reFresh子物件("LOCK")
    '    End Select
    'End Sub
End Class