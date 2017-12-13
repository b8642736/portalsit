Module ModFood

#Region "Enum-伙食輸入"
    Public C_特殊部門代號 As String = "#"

    Public Enum Enum_特殊部門代號清單
        程式人員專用 = 1
        行政處專用_一般 = 2
        行政處專用_特殊 = 3
    End Enum

    Public Function 特殊部門代號清單_代號(ByVal fromEnum As Enum_特殊部門代號清單) As String
        Return C_特殊部門代號 & fromEnum
    End Function

    Public Function 特殊部門代號清單_名稱(ByVal fromEnum As Enum_特殊部門代號清單) As String
        Select Case fromEnum
            Case Enum_特殊部門代號清單.行政處專用_一般
                Return "行政處專用_一般"
            Case Enum_特殊部門代號清單.行政處專用_特殊
                Return "行政處專用_特殊"
            Case Enum_特殊部門代號清單.程式人員專用
                Return "程式人員專用"
            Case Else
                Return "UnKnow"
        End Select
    End Function

#End Region

#Region "MsgBox：彈跳訊息"
    ''' <summary>
    ''' 彈出提示訊息
    ''' </summary>
    ''' <param name="fromControl">Me</param>
    ''' <param name="fromMessage">訊息文字</param>
    ''' <remarks></remarks>
    Public Sub MsgBox(fromControl As System.Web.UI.Control, _
                            ByVal fromMessage As String)
        Dim sScript As String
        Dim sMessage As String

        sMessage = Strings.Replace(fromMessage, "'", "\'") '處理單引號
        sMessage = Strings.Replace(sMessage, vbNewLine, "\n") '處理換行
        sScript = String.Format("alert('{0}');", sMessage)
        ScriptManager.RegisterStartupScript(fromControl, fromControl.GetType(), "alert", sScript, True)
    End Sub
#End Region

    Private WP_AS400Adapter As New AS400SQLQueryAdapter

#Region "FD_Data_Department"
    Private Sub P_Data_Department_OrderBy(ByRef fromDatatable As DataTable)
        fromDatatable = (From A In fromDatatable Order By A.Item("pqdp1") Select A).CopyToDataTable
    End Sub

    Public Function FD_Data_Department_Super() As DataTable
        Dim addItem As DataRow
        Dim queryDataTable As DataTable = FD_Data_Department_Normal()

        For II As Integer = Enum_特殊部門代號清單.程式人員專用 To Enum_特殊部門代號清單.行政處專用_特殊
            addItem = queryDataTable.NewRow
            addItem.Item("pqdp1") = 特殊部門代號清單_代號(II)
            addItem.Item("pqdp2") = 特殊部門代號清單_名稱(II)
            queryDataTable.Rows.Add(addItem)
        Next II

        P_Data_Department_OrderBy(queryDataTable)
        Return queryDataTable
    End Function

    Public Function FD_Data_Department_Normal() As DataTable
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT pqdp1,pqdp2 " & vbNewLine)
        querySQL.Append("FROM @#PLT000LB.PQDDPTl2 " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("ORDER BY pqdp1 " & vbNewLine)
        Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(querySQL.ToString)

        P_Data_Department_OrderBy(queryDataTable)
        Return queryDataTable
    End Function

#End Region

#Region "FD_Data_Employee"
    Public Function FD_Data_Employee_Now() As DataTable
        Dim queryEEE As Integer = Integer.Parse(Now.ToString("yyyy")) - 1911
        Dim queryMM As Integer = Integer.Parse(Now.ToString("MM"))

        Return FD_Data_Employee(queryEEE, queryMM)
    End Function

    Public Function FD_Data_Employee(ByVal fromEEE As Integer, ByVal fromMM As Integer) As DataTable
        Dim sql As New StringBuilder
        sql.Append("SELECT qd100e, qd100a, qd100c " & vbNewLine)
        sql.Append("FROM @#PLT000LB.PQDM01L3 " & vbNewLine)
        sql.Append("WHERE 1=1 " & vbNewLine)
        sql.Append("  and qd100i= " & fromEEE & vbNewLine)
        sql.Append("  and qd100j= " & fromMM & vbNewLine)

        Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(sql.ToString)
        Return queryDataTable
    End Function
#End Region

End Module
