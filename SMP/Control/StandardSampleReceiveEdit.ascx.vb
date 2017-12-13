Public Class StandardSampleReceiveEdit
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbDateStart.Text = Format(Now.AddMonths(-1), "yyyy/MM/01")
            Me.tbDateEnd.Text = Format(Now, "yyyy/MM/dd")

            'Me.tbDeviceName.Text = "JY#3"
            'Me.tbFK_SampleNumber.Text = "2F"
            'Me.tbMethod.Text = "SS300"
        End If
    End Sub

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As New StringBuilder
        SQLString.Append("SELECT * FROM [標準樣本接收資料]" & vbNewLine)
        SQLString.Append("  WHERE 1=1" & vbNewLine)

        SQLString.Append("    AND 日期時間>='" & Format(CDate(tbDateStart.Text), "yyyy/MM/dd 7:30:00") & "'" & vbNewLine)
        SQLString.Append("    AND 日期時間<'" & Format(DateAdd(DateInterval.Day, 1, CDate(tbDateEnd.Text)), "yyyy/MM/dd 7:30:00") & "'" & vbNewLine)
        SQLString.Append("    AND Sample<>'x' AND Sample<>'X' " & vbNewLine)

        If Not String.IsNullOrEmpty(tbDeviceName.Text) Then SQLString.Append("    AND DeviceName='" & tbDeviceName.Text & "'" & vbNewLine)
        If Not String.IsNullOrEmpty(tbFK_SampleNumber.Text) Then SQLString.Append("    AND FK_SampleNumber='" & tbFK_SampleNumber.Text & "'" & vbNewLine)
        If Not String.IsNullOrEmpty(tbMethod.Text) Then SQLString.Append("    AND Method='" & tbMethod.Text & "'" & vbNewLine)


        SQLString.Append("  ORDER BY [日期時間],[點序]" & vbNewLine)

        Me.hfQryString.Value = SQLString.ToString
        Me.hfTopDataNum.Value = IIf(chkTopData.Checked = True, tbTopDataNum.Text, "0")
        Me.hfSearchDate.Value = tbDateStart.Text & "|" & tbDateEnd.Text
    End Sub
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        ListView1.DataBind()
    End Sub

#Region "Search"
    ''' <summary>
    '''  依條件搜尋資料
    ''' </summary>
    ''' <param name="fromSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQL As String, ByVal fromTopDataNum As String, ByVal fromSearchDate As String) As List(Of SQLServer.QCDB01.標準樣本接收資料)
        Dim queryList As New List(Of SQLServer.QCDB01.標準樣本接收資料)
        Dim retList As New List(Of SQLServer.QCDB01.標準樣本接收資料)
        If String.IsNullOrEmpty(fromSQL) Then
            Return queryList
        End If

        Dim sqlAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        queryList = SQLServer.QCDB01.標準樣本接收資料.CDBSelect(Of SQLServer.QCDB01.標準樣本接收資料)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)


        If Not fromTopDataNum.Equals("0") AndAlso IsNumeric(fromTopDataNum) = True Then
            retList = GetTimeRangeFirstTwoTimes(CDate(fromSearchDate.Split("|")(0)), CDate(fromSearchDate.Split("|")(0)), queryList, CInt(fromTopDataNum))

        Else
            retList = queryList
        End If

        Return retList
    End Function

#End Region


#Region "CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function CDBUpdate(ByVal fromObject As SQLServer.QCDB01.標準樣本接收資料) As Integer
        fromObject.SQLQueryAdapterByThisObject = New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Return fromObject.CDBUpdate
    End Function
#End Region

#Region "CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Function CDBDelete(ByVal fromObject As SQLServer.QCDB01.標準樣本接收資料) As Integer
        fromObject.SQLQueryAdapterByThisObject = New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Return fromObject.CDBDelete
    End Function
#End Region

#Region "ListView1"

    Private Sub ListView1_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles ListView1.ItemDataBound
        Dim itemDate As Date = CType(CType(e.Item.FindControl("hf日期時間"), HiddenField).Value, DateTime)

        CType(e.Item.FindControl("show日期Label"), Label).Text = Format(itemDate, "yyyy/MM/dd")
        CType(e.Item.FindControl("show時間Label"), Label).Text = Format(itemDate, "HH:mm:ss")
        CType(e.Item.FindControl("show班別Label"), Label).Text = getAPN(itemDate)

        CType(e.Item.FindControl("show點序Label"), Label).Text = CType(CType(e.Item.FindControl("hf點序"), HiddenField).Value, String)
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim itemDate As Date = CType(CType(ListView1.EditItem.FindControl("hf日期時間"), HiddenField).Value.Trim, DateTime)

        e.NewValues.Item("日期時間") = Format(itemDate, "yyyy/MM/dd HH:mm:ss")
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim SenderControl As ListView = sender
        Dim itemDate As Date

        If Not IsNothing(SenderControl.EditItem) Then
            itemDate = CType(CType(SenderControl.EditItem.FindControl("hf日期時間"), HiddenField).Value, DateTime)
            CType(SenderControl.EditItem.FindControl("show日期Label"), Label).Text = Format(itemDate, "yyyy/MM/dd")
            CType(SenderControl.EditItem.FindControl("show時間Label"), Label).Text = Format(itemDate, "HH:mm:ss")
            CType(SenderControl.EditItem.FindControl("show班別Label"), Label).Text = getAPN(itemDate)

            CType(SenderControl.EditItem.FindControl("show點序Label"), Label).Text = CType(CType(SenderControl.EditItem.FindControl("hf點序"), HiddenField).Value, String)
        End If

    End Sub


#End Region

End Class