
Public Module InvoiceOfReceivables_Model

    Public Enum 主畫面_Enum
        查詢 = 0
        編修 = 1
        列印 = 2
    End Enum

    Public Enum EditMode_Enum
        初始化 = 0
        新增 = 1
        編輯 = 2
        查詢 = 3
    End Enum

    Public C_SystemChar As String = "_"
    Public C_RGBTextColorLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#2B2B2B")
    Public C_RGBTextColorUnLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#000000")
    Public C_RGBColorLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#CCCCCC")
    Public C_RGBColorUNLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF")

    Public C_Status_LOGIN As String = "LOGIN"
    Public C_Status_BACK As String = "BACK"

#Region "FD_Data_Employee"
    Private WP_AS400Adapter As New AS400SQLQueryAdapter

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

#Region "FD_Data_Department"
    

    Public Function FD_Data_Department() As DataTable
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT pqdp1,pqdp2 " & vbNewLine)
        querySQL.Append("FROM @#PLT000LB.PQDDPTl2 " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("ORDER BY pqdp1 " & vbNewLine)
        Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(querySQL.ToString)

        Return queryDataTable
    End Function

#End Region

#Region "ViewState：Employee"
    Public Const C_DataTableEmployee As String = "DataTableEmployee"
    Public Const C_DataTableUnit As String = "DataTableUnit"

    Public Function showUnitName(ByRef fromDatatable As DataTable, ByVal fromUnitID As String) As String
        Dim showName As String = (From A In fromDatatable Where A.Item("pqdp1").ToString.Trim.Equals(fromUnitID.Trim) Select A.Item("pqdp2")).FirstOrDefault
        Dim retMsg As String = IIf(String.IsNullOrEmpty(showName), fromUnitID, showName)

        Return retMsg
    End Function

    Private Function showEmployeeInfo(ByVal fromDataTable_Employee As DataTable, ByVal fromID As String, ByVal fromColumnName As String) As String
        Dim showName As String = (From A In fromDataTable_Employee Where A.Item("qd100a").ToString.Trim.Equals(fromID.Trim) Select A.Item(fromColumnName).ToString.Trim).FirstOrDefault
        Dim retMsg As String = IIf(String.IsNullOrEmpty(showName), fromID, showName)

        Return retMsg
    End Function

    Public Function showEmployeeName(ByVal fromDataTable_Employee As DataTable, ByVal fromID As String) As String
        Return showEmployeeInfo(fromDataTable_Employee, fromID, "qd100c")
    End Function

    Public Function showEmployeeUserUnit(ByVal fromDataTable_Employee As DataTable, ByVal fromID As String) As String
        Return showEmployeeInfo(fromDataTable_Employee, fromID, "qd100e")
    End Function
#End Region


#Region "ShowFormat"
    Public Function showFormatFor_DateTime(ByVal fromShowIsHtml As Boolean, _
                                                                                     ByVal fromDate As String, ByVal fromTime As String)
        Dim returnValue As String
        Dim W_Space As String = IIf(fromShowIsHtml = True, ModTools.showSpace(2), Space(2))

        returnValue = showFormatForDate(fromDate) & _
                                               W_Space & _
                                               showFormatForTime(fromTime)

        Return returnValue
    End Function

    Public Function showFormatForDate(ByVal fromDate As String)
        Dim returnValue As String = fromDate
        If returnValue = "0" Then returnValue = ""

        If fromDate.Length >= 6 Then
            Dim W_Split_1 As String = fromDate.Substring(0, IIf(fromDate.Length = 6, 2, 3))
            Dim W_Split_2 As String = Microsoft.VisualBasic.Right(fromDate, 4)

            returnValue = W_Split_1
            returnValue &= "/" & W_Split_2.Substring(0, 2)
            returnValue &= "/" & W_Split_2.Substring(2, 2)
        End If

        Return returnValue
    End Function

    Public Function showFormatForTime(ByVal fromTime As String)
        Dim returnValue As String = fromTime
        If returnValue = "0" Then returnValue = ""

        If returnValue.Length = 5 Then returnValue = "0" & returnValue
        If returnValue.Length >= 6 Then
            returnValue = returnValue.Substring(0, 2) & ":" & returnValue.Substring(2, 2) & ":" & returnValue.Substring(4, 2)
        End If

        Return returnValue

    End Function
#End Region



End Module

