Public Class HRLeaveDetail
    Inherits System.Web.UI.UserControl

    Private _clsSystemNote As New PublicClassLibrary.ClsSystemNote
#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal fromStartDate As Date, ByVal fromEndDate As Date) As Personnel.HRLeaveDetailDataTable
        Dim ReturnValue As New Personnel.HRLeaveDetailDataTable
        Dim AddItem As Personnel.HRLeaveDetailRow

        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If

        Dim spaceString As String = "　　"
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim queryDateTable As DataTable = Adapter.SelectQuery
        Dim showInfoDays As String, showInfoHours As String

        For Each eachRow As DataRow In queryDateTable.Rows
            AddItem = ReturnValue.NewRow




            AddItem.Item(Enum_ShowColumn.單位代號) = eachRow.Item(getDBColumnID(Enum_DBColumn.單位代號)) & spaceString
            AddItem.Item(Enum_ShowColumn.工號) = eachRow.Item(getDBColumnID(Enum_DBColumn.工號)) & spaceString
            AddItem.Item(Enum_ShowColumn.姓名) = eachRow.Item(getDBColumnID(Enum_DBColumn.姓名)) & spaceString
            AddItem.Item(Enum_ShowColumn.假別) = _clsSystemNote.getLev4Content("AS400", "請假代碼", eachRow.Item(getDBColumnID(Enum_DBColumn.假別碼))) & spaceString
            AddItem.Item(Enum_ShowColumn.起始時間) = String.Format("{0}/{1}/{2} {3}:{4}" _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.起始年))) _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.起始月))) _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.起始日))) _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.起始時))) _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.起始分)))) & spaceString

            AddItem.Item(Enum_ShowColumn.終訖時間) = String.Format("{0}/{1}/{2} {3}:{4}" _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.終止年))) _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.終止月))) _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.終止日))) _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.終止時))) _
                                                               , String.Format("{0:00}", eachRow.Item(getDBColumnID(Enum_DBColumn.終止分)))) & spaceString

            showInfoDays = IIf(Val(eachRow.Item(getDBColumnID(Enum_DBColumn.共計日))) = 0, "", eachRow.Item(getDBColumnID(Enum_DBColumn.共計日)) & "日")
            showInfoHours = IIf(Val(eachRow.Item(getDBColumnID(Enum_DBColumn.共計時))) = 0, "", eachRow.Item(getDBColumnID(Enum_DBColumn.共計時)) & "時")
            showInfoDays = String.Format("{0,5}", showInfoDays).Replace(Space(1), "&nbsp")
            showInfoHours = String.Format("{0,10}", showInfoHours).Replace(Space(1), "&nbsp")

            AddItem.Item(Enum_ShowColumn.合計日時) = String.Format("{0}{1}", showInfoDays, showInfoHours)

            ReturnValue.Rows.Add(AddItem)
        Next

        Return ReturnValue

    End Function
#End Region

#Region "常數:Enum"
    Private Enum Enum_ShowColumn
        單位代號 = 0
        工號 = 1
        姓名 = 2
        假別 = 3
        起始時間 = 4
        終訖時間 = 5
        合計日時 = 6
    End Enum
    Private Enum Enum_DBColumn
        單位代號 = 2
        工號 = 3
        姓名 = 19
        假別碼 = 4
        起始年 = 6
        起始月 = 7
        起始日 = 8
        起始時 = 9
        起始分 = 10
        終止年 = 11
        終止月 = 12
        終止日 = 13
        終止時 = 14
        終止分 = 15
        共計日 = 20
        共計時 = 21
    End Enum

    Private Function getDBColumnID(ByVal fromEnum_DBColumn As Enum_DBColumn) As String
        Return "QDT3" & String.Format("{0:00}", Convert.ToInt32(fromEnum_DBColumn))
    End Function


#End Region

#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' 控制項Where條件產生器
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlWhereMaker()
        Dim ControlStartDate As Date = tbStartDate.Text.Trim
        Dim ControlEndDate As Date = tbEndDate.Text.Trim
        Dim StartDate As Double = (ControlStartDate.Year - 1911) * 10000 + ControlStartDate.Month * 100 + ControlStartDate.Day
        Dim EndDate As Double = (ControlEndDate.Year - 1911) * 10000 + ControlEndDate.Month * 100 + ControlEndDate.Day

        Dim ReturnValue As New StringBuilder

        ReturnValue.Append("/*=========================================================================================== " & vbNewLine)
        ReturnValue.Append("         判断日期有交集 " & vbNewLine)
        ReturnValue.Append("         規則 " & vbNewLine)
        ReturnValue.Append("         if(第一組最後時間小於第二組最前時間 || 第一組最前時間大於第二組最後時間){ " & vbNewLine)
        ReturnValue.Append("           無交集 " & vbNewLine)
        ReturnValue.Append("         } " & vbNewLine)
        ReturnValue.Append("         else{ " & vbNewLine)
        ReturnValue.Append("           有交集 " & vbNewLine)
        ReturnValue.Append("         } " & vbNewLine)
        ReturnValue.Append("		  " & vbNewLine)
        ReturnValue.Append("        SQL日期交集:F1>=0且F2<=0 " & vbNewLine)
        ReturnValue.Append(" ===========================================================================================*/ " & vbNewLine)
        ReturnValue.Append("Select            " & vbNewLine)
        ReturnValue.Append("         (D1E-D2S) f1,(D1S-D2E) f2, " & vbNewLine)
        ReturnValue.Append("         DATE(D1S) DD1S,DATE(D1E) DD1E, " & vbNewLine)
        ReturnValue.Append("         DATE(D2S) DD2S,DATE(D2E) DD2E, " & vbNewLine)
        ReturnValue.Append("         v2.* " & vbNewLine)
        ReturnValue.Append("  " & vbNewLine)
        ReturnValue.Append("From ( " & vbNewLine)
        ReturnValue.Append("         Select   DAYS( (1911+QDT306) ||  '-' || QDT307 || '-' || QDT308) D1S , " & vbNewLine)
        ReturnValue.Append("                   DAYS( (1911+QDT311) ||  '-' || QDT312 || '-' || QDT313) D1E ,  " & vbNewLine)
        ReturnValue.Append("                   DAYS( '" & ControlStartDate.ToString("yyyy-MM-dd") & "') D2S,  " & vbNewLine)
        ReturnValue.Append("                   DAYS( '" & ControlEndDate.ToString("yyyy-MM-dd") & "') D2E,  " & vbNewLine)
        ReturnValue.Append("                   v1.*  " & vbNewLine)
        ReturnValue.Append("          From  @#PLT000LB.PQDT03PF   v1 " & vbNewLine)
        ReturnValue.Append("          WHERE 1=1 " & vbNewLine)
        ReturnValue.Append(" " & vbNewLine)
        ReturnValue.Append("           -- ======================================================================================= " & vbNewLine)
        ReturnValue.Append("           --排除錯誤資料:4月份沒有31號(結束日期99/04/31) " & vbNewLine)
        ReturnValue.Append("		   AND NOT (QDT303='00046' AND QDT306=99 AND QDT307=4 AND QDT308=30 AND QDT309=0 AND QDT310=0) " & vbNewLine)
        ReturnValue.Append("           -- ======================================================================================= " & vbNewLine)
        ReturnValue.Append("				    " & vbNewLine)

        If Not String.IsNullOrEmpty(tbDepts.Text) Then
            tbDepts.Text = tbDepts.Text.Replace("'", Nothing).ToUpper
            ReturnValue.Append(IIf(tbDepts.Text.Trim.Length > 0, "            AND " & getDBColumnID(Enum_DBColumn.單位代號) & " IN ('" & tbDepts.Text.Replace(",", "','") & "') " & vbNewLine, Nothing))
        End If

        If Not String.IsNullOrEmpty(tbEmployeeNameOrID.Text) Then
            tbEmployeeNameOrID.Text = tbEmployeeNameOrID.Text.Replace("'", Nothing).ToUpper
            ReturnValue.Append("            AND ( " & vbNewLine)
            ReturnValue.Append(IIf(tbEmployeeNameOrID.Text.Trim.Length > 0, "                     " & getDBColumnID(Enum_DBColumn.工號) & "  ='" & tbEmployeeNameOrID.Text.Trim & "' " & vbNewLine, Nothing))
            ReturnValue.Append(IIf(tbEmployeeNameOrID.Text.Trim.Length > 0, "                     OR " & getDBColumnID(Enum_DBColumn.姓名) & "  like '%" & tbEmployeeNameOrID.Text.Trim & "%' " & vbNewLine, Nothing))
            ReturnValue.Append("            )  " & vbNewLine)
        End If

        Dim HRLevalCode As String = _clsSystemNote.Fs_GetStrBefor(ddQueryType.SelectedValue, "：")
        If HRLevalCode <> "ALL" Then
            ReturnValue.Append("		   AND  " & getDBColumnID(Enum_DBColumn.假別碼) & "='" & HRLevalCode & "' " & vbNewLine)
        End If

        ReturnValue.Append("           " & vbNewLine)
        ReturnValue.Append(") v2 " & vbNewLine)
        ReturnValue.Append("WHERE 1=1 " & vbNewLine)
        ReturnValue.Append("        AND (D1E-D2S) >=0  " & vbNewLine)
        ReturnValue.Append("        AND (D1S-D2E) <=0 " & vbNewLine)
        ReturnValue.Append("ORDER BY  qdt302,qdt303, qdt306,qdt307,qdt308,qdt309 " & vbNewLine)

        Me.hfSQLString.Value = ReturnValue.ToString
        Me.hfStartDate.Value = ControlStartDate
        Me.hfEndDate.Value = ControlEndDate
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = String.Format("{0}/{1}/{2}", Now.Date.Year, Now.Date.Month, 1)
            tbEndDate.Text = String.Format("{0}/{1}/{2}", Now.Date.Year, Now.Date.Month, Date.DaysInMonth(Now.Date.Year, Now.Date.Month))

            Dim queryDataTable As DataTable = _clsSystemNote.getLev3("AS400", "請假代碼")
            _clsSystemNote.setDropDownList(ddQueryType, queryDataTable)
        End If

    End Sub



    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ControlWhereMaker()
        GridView1.DataBind()
    End Sub

End Class