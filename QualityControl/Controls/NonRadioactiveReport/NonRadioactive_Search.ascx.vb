Public Class NonRadioactive_Search
    Inherits System.Web.UI.UserControl
    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As NonRadioactive_Main.主畫面_Enum, _
                           ByVal fromLabno As String, ByVal subno As Int32)
    Dim sublabnoformate As String = "000"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            P_Init()
            MakeQryStringToControl()
        End If
    End Sub
    Private Sub P_Init()
        Dim W_Date_E As Date = Now
        Dim W_Date_S As Date = DateAdd(DateInterval.Month, -1, W_Date_E)

        tbDateS.Text = W_Date_S.ToString("yyyy/MM/dd")
        tbDateE.Text = W_Date_E.ToString("yyyy/MM/dd")
        tbBuyer.Text = ""
        tbCoilno.Text = ""

    End Sub
#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()

        Dim querySql As New StringBuilder
        querySql.Append("SELECT * FROM LabRecordA1_M WHERE 1=1 " & vbNewLine)
        If ckBydate.Checked Then
            Dim DateE As String = Date.Parse(tbDateE.Text).AddDays(1).ToString("yyyy/MM/dd")
            querySql.Append("and 資料日期 between '" & tbDateS.Text & "' and '" & DateE & "'" & vbNewLine)
        End If
        If tbBuyer.Text.Length > 0 Then
            querySql.Append("and 客戶名稱 Like '%" & tbBuyer.Text & "%'" & vbNewLine)
        End If
        If tbLabno.Text.Length > 0 Then
            querySql.Append("and LAB_REPORTNO = '" & tbLabno.Text & "'" & vbNewLine)
        End If
        querySql.Append("order by LAB_REPORTNO DESC" & vbNewLine)

        '鋼捲須從LabRecordA1_D查詢
        If tbCoilno.Text.Length > 0 Then
            Dim CoilNosString As String = ""
            If tbCoilno.Text.Contains(",") Then
                Dim coils() As String = tbCoilno.Text.Split(",")
                For Each coil As String In coils
                    CoilNosString &= "OR 鋼捲號碼 = '" & coil & "'" & vbNewLine
                Next
                CoilNosString = CoilNosString.Substring(2)
                CoilNosString &= ")"

            Else
                CoilNosString = " 鋼捲號碼 = '" & tbCoilno.Text & "' )" & vbNewLine
            End If

            Dim result As String = ""
            Dim queryCol As String = "SELECT LAB_REPORTNO FROM [dbo].[LabRecordA1_D] " & vbNewLine
            queryCol &= "WHERE 1=1 AND (" & vbNewLine
            queryCol &= CoilNosString
            queryCol &= "GROUP BY LAB_REPORTNO"
            Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
            Dim dtResult As DataTable = sqlAdapter.SelectQuery(queryCol)
            For Each dr As DataRow In dtResult.Rows
                result &= "OR LAB_REPORTNO ='" & dr.Item("LAB_REPORTNO") & "'" & vbNewLine
            Next
            result = result.Substring(2)
            result &= ")"
            querySql = New StringBuilder
            querySql.Append("SELECT * FROM LabRecordA1_M WHERE 1=1 AND (" & vbNewLine)
            querySql.Append(result)
            If ckBydate.Checked Then
                Dim DateE As String = Date.Parse(tbDateE.Text).AddDays(1).ToString("yyyy/MM/dd")
                querySql.Append("AND 資料日期 BETWEEN '" & tbDateS.Text & "' AND '" & DateE & "'" & vbNewLine)
            End If
            If tbBuyer.Text.Length > 0 Then
                querySql.Append("AND 客戶名稱 Like '%" & tbBuyer.Text & "%'" & vbNewLine)
            End If
            If tbLabno.Text.Length > 0 Then
                querySql.Append("AND LAB_REPORTNO = '" & tbLabno.Text & "'" & vbNewLine)
            End If
            'querySql.Append("ORDER BY LAB_REPORTNO DESC" & vbNewLine)

        End If

        Me.hfSQL.Value = querySql.ToString
    End Sub
#End Region

#Region "SystemNote:CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of SQLServer.QCdb01.LabRecordA1_M)
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New List(Of SQLServer.QCdb01.LabRecordA1_M)
        End If
        Return SQLServer.QCdb01.LabRecordA1_M.CDBSelect(Of SQLServer.QCdb01.LabRecordA1_M)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As SQLServer.QCdb01.LabRecordA1_M) As Integer
        Try
            Return fromObj.CDBInsert
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "系統資訊")
        End Try
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As SQLServer.QCdb01.LabRecordA1_M) As Integer
        Return fromObj.CDBUpdate
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As SQLServer.QCdb01.LabRecordA1_M) As Integer
        Return fromObj.CDBDelete
    End Function
#End Region
    Public Sub P_reFresh子物件()
        MakeQryStringToControl()
        ListView1.DataBind()
    End Sub
    Public Sub P_reFresh子物件(ByVal labno As String)
        tbLabno.Text = labno
        btnSearch_Click(Nothing, Nothing)
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs)
        Dim str_labno As String = CType(sender, Button).ToolTip.Trim
        Dim labno As String = ""
        Dim subno As Int32 = 0
        If str_labno.Contains("-") Then
            labno = str_labno.Split("-")(0)
            subno = CInt(str_labno.Split("-")(1))
        Else
            labno = str_labno
        End If
        RaiseEvent Event_reFresh父物件(NonRadioactive_Main.主畫面_Enum.列印, labno, subno)
    End Sub

    Protected Sub btnView_Click(sender As Object, e As EventArgs)
        Dim str_labno As String = CType(sender, Button).ToolTip.Trim
        Dim labno As String = ""
        Dim subno As Int32 = 0
        If str_labno.Contains("-") Then
            labno = str_labno.Split("-")(0)
            subno = CInt(str_labno.Split("-")(1))
        Else
            labno = str_labno
        End If
        RaiseEvent Event_reFresh父物件(NonRadioactive_Main.主畫面_Enum.編修, labno, subno)
    End Sub
    ''' <summary>
    ''' 回傳日期字串
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_Date(ByVal str As String)
        Dim result As String = ""
        Try
            result = Date.Parse(str).ToString("yyyy/MM/dd")
        Catch ex As Exception
            Return str
        End Try
        Return result
    End Function
    ''' <summary>
    ''' 回傳買受人字串
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_Buyer(ByVal str As String)
        If str.Contains("Buyer") Then
            Return str.Split(":")(1).Trim
        End If
        If str.Contains("買受人") Then
            Return str.Split("：")(1).Trim
        End If
        Return str
    End Function
    Public Function FS_showlabno(ByVal str As String, ByVal subno As Int32)
        If subno > 0 Then
            Return str & "-" & subno.ToString(sublabnoformate)
        End If
        Return str
    End Function

    'Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
    '    e.NewValues("品檢日期_起") = Date.Parse(e.NewValues("品檢日期_起"))
    '    e.NewValues("品檢日期_迄") = Date.Parse(e.NewValues("品檢日期_迄"))
    '    e.NewValues("資料日期") = Date.Parse(e.NewValues("資料日期"))
    'End Sub

    'Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
    '    e.Values("品檢日期_起") = Date.Parse(e.Values("品檢日期_起"))
    '    e.Values("品檢日期_迄") = Date.Parse(e.Values("品檢日期_迄"))
    '    e.Values("資料日期") = Date.Parse(e.Values("資料日期"))
    'End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        lbMessage.Text = ""
        Try
            If ckBydate.Checked Then
                Date.Parse(tbDateS.Text)
                Date.Parse(tbDateE.Text)
            End If
        Catch ex As Exception
            lbMessage.Text = "Error：請輸入正確時間格式"
            Exit Sub
        End Try
        MakeQryStringToControl()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        RaiseEvent Event_reFresh父物件(NonRadioactive_Main.主畫面_Enum.編修, Nothing, Nothing)
    End Sub

    Protected Sub ckBydate_CheckedChanged(sender As Object, e As EventArgs) Handles ckBydate.CheckedChanged
        tbDateE.Enabled = ckBydate.Checked
        tbDateS.Enabled = ckBydate.Checked
    End Sub
End Class