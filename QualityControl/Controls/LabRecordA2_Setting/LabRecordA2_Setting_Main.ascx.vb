Public Class LabRecordA2_Setting_Main
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LabRecordA2_Setting_Module.P_IE_Compatible(Page)

        If Not IsPostBack Then
            '  TabContainer1_ActiveTabChanged(TabContainer1, Nothing)
        End If
    End Sub



    Private Sub TabContainer1_ActiveTabChanged(sender As Object, e As EventArgs) Handles TabContainer1.ActiveTabChanged
        Dim W_Now_Index As Integer = TabContainer1.ActiveTabIndex
        Dim W_NowEnum As 主畫面_Enum = DirectCast([Enum].Parse(GetType(主畫面_Enum), W_Now_Index), 主畫面_Enum)

        LabRecordA2_Setting_Module.Main_Targe_Who = W_NowEnum
    End Sub

    Private Sub TabContainer1_DataBinding(sender As Object, e As EventArgs) Handles TabContainer1.DataBinding

    End Sub

    Private Sub TabContainer1_Disposed(sender As Object, e As EventArgs) Handles TabContainer1.Disposed

    End Sub

    Private Sub TabContainer1_Init(sender As Object, e As EventArgs) Handles TabContainer1.Init

    End Sub

    Private Sub TabContainer1_Load(sender As Object, e As EventArgs) Handles TabContainer1.Load

    End Sub

    Private Sub TabContainer1_PreRender(sender As Object, e As EventArgs) Handles TabContainer1.PreRender
        TabContainer1_ActiveTabChanged(TabContainer1, Nothing)
    End Sub

    Private Sub TabContainer1_Unload(sender As Object, e As EventArgs) Handles TabContainer1.Unload

    End Sub
End Class