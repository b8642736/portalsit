Public Class SellStatic
    Inherits System.Web.UI.UserControl

#Region "查詢打單數量統計：Search"
    ''' <summary>
    ''' 查詢打單數量統計
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function Search1(ByVal SQLString As String) As EISDataSet.SellStaticDataTable


    End Function
#End Region


#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerSQLStringToControl()
        Dim ReturnValue As String = "Select A.*,C.CH202 From @#PPS100LB.SL2BOLPF A JOIN @#SLS300LB.SL2CH2PF C ON  A.BOL06=C.CH201 WHERE  1=1 "
        Me.hyfQry.Value = ReturnValue
    End Sub
#End Region




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbStartDate.Text = Format(Now, "yyyy/MM/01")
        tbEndDate.Text = Format(Now, "yyyy/MM/" & Date.DaysInMonth(Now.Year, Now.Month))
        MakerSQLStringToControl()
        GridView1.DataBind()

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerSQLStringToControl()
        GridView1.DataBind()
    End Sub

End Class