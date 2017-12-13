﻿Public Class WorkOrRestDetailSearch
    Inherits System.Web.UI.UserControl

    Private Shared _clsSystemNote As New PublicClassLibrary.ClsSystemNote
#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As Personnel.WorkOrResetDetailSearchDataTable
        Dim ReturnValue As New Personnel.WorkOrResetDetailSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        'Dim CoilBugAssey As List(Of CompanyORMDB.PPS100LB.PPSDEFPF) = CompanyORMDB.PPS100LB.PPSDEFPF.ALL_PPSDEPF(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
        For Each EachItem As DataRow In (From A In Adapter.SelectQuery.Rows Select A).ToList
            Dim AddRow As Personnel.WorkOrResetDetailSearchRow = ReturnValue.NewRow
            With AddRow
                .單位 = EachItem.Item("QD3005")
                .姓名 = EachItem.Item("QD3003")
                .工號 = EachItem.Item("QD3001")
                .日期 = String.Format("{0}/{1}/{2}", EachItem.Item("QD3007"), EachItem.Item("QD3008"), EachItem.Item("QD3009"))
                .值勤 = EachItem.Item("QD3033")
                If CType(EachItem.Item("QD3012"), String).Trim.Length > 0 Then
                    .應出勤時間 = String.Format("{0}~{1}", EachItem.Item("QD3012"), EachItem.Item("QD3013"))
                End If
                If CType(EachItem.Item("QD3014"), String).Trim.Length > 0 Then
                    .刷卡時時間 = String.Format("{0}~{1}", EachItem.Item("QD3014"), EachItem.Item("QD3015"))
                End If
                If Not IsDBNull(EachItem.Item("QD3016")) AndAlso CType(EachItem.Item("QD3016"), String).Trim.Length > 0 Then
                    .刷卡時時間 = vbNewLine & String.Format("{0}~{1}", EachItem.Item("QD3016"), EachItem.Item("QD3017"))
                End If
                If Not IsDBNull(EachItem.Item("QD3018")) AndAlso CType(EachItem.Item("QD3018"), String).Trim.Length > 0 Then
                    .刷卡時時間 = vbNewLine & String.Format("{0}~{1}", EachItem.Item("QD3018"), EachItem.Item("QD3019"))
                End If
                If Not IsDBNull(EachItem.Item("QD3025")) AndAlso CType(EachItem.Item("QD3025"), String).Trim.Length > 0 Then
                    '  .請假時數 = EachItem.Item("QD3025")
                    If EachItem.Item("QD3025") <> "0" Then
                        .請假時數 = EachItem.Item("QD3025")
                        .請假時數 &= "<BR><BR>[明細]"

                        Dim SearchDate As String = EachItem.Item("QD3007") & Right("00" & EachItem.Item("QD3008"), 2) & Right("00" & EachItem.Item("QD3009"), 2)
                        .請假時數 &= SearchAS400_PLT000LB_PQDT03PF(EachItem.Item("QD3001").ToString, SearchDate)
                    End If

                End If
                Dim TxtTemp As String = Nothing
                If Not IsDBNull(EachItem.Item("QD3022")) AndAlso Val(EachItem.Item("QD3022")) > 0 Then
                    TxtTemp &= "錢:" & EachItem.Item("QD3022")
                End If
                If Not IsDBNull(EachItem.Item("QD3023")) AndAlso Val(EachItem.Item("QD3023")) > 0 Then
                    TxtTemp &= IIf(String.IsNullOrEmpty(TxtTemp), Nothing, " ") & "補:" & EachItem.Item("QD3023")
                End If
                .加班 = TxtTemp
                If Not IsDBNull(EachItem.Item("QD3035")) AndAlso EachItem.Item("QD3035") = "A" Then
                    .說明 = "值日"
                End If

            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function
#End Region


#Region "取得AS400請假明細 函式:SearchAS400_PLT000LB_PQDT03PF"
    Public Shared Function SearchAS400_PLT000LB_PQDT03PF(ByVal fromEmpNo As String, ByVal fromSearchDate As String) As String
        Dim retMsg As New StringBuilder
        Dim itemMsg As String
        Dim SQL As New StringBuilder
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim QueryDataTable As DataTable

        SQL.Append("SELECT (QDT306*10000+QDT307*100+QDT308) Date_Start ,(QDT311*10000+QDT312*100+QDT313) Date_End" & vbNewLine)
        SQL.Append("           ,qdt304,qdt320,qdt321" & vbNewLine)
        SQL.Append("FROM @#PLT000LB.PQDT03PF v" & vbNewLine)
        SQL.Append("WHERE 1=1" & vbNewLine)
        SQL.Append("  AND QDT303 ='" & fromEmpNo & "'" & vbNewLine)
        SQL.Append("  AND (QDT306*10000+QDT307*100+QDT308) <=" & fromSearchDate & vbNewLine)
        SQL.Append("  AND (QDT311*10000+QDT312*100+QDT313) >=" & fromSearchDate & vbNewLine)
        SQL.Append("ORDER BY qdt306,qdt307,qdt308,qdt311,qdt312,qdt313" & vbNewLine)
        QueryDataTable = Adapter.SelectQuery(SQL.ToString)


        For Each EachItem As DataRow In QueryDataTable.Rows

            itemMsg = EachItem.Item("QDT321")  '預設值：小時

            If Val(EachItem.Item("QDT320")) > 0 Then      '天數
                If Val(EachItem.Item("Date_End")) > fromSearchDate Then
                    itemMsg = "8.0"
                Else
                    '最後一天，且沒有小時
                    If Val(EachItem.Item("QDT321")) = 0 Then
                        itemMsg = "8.0"
                    End If
                End If
            End If



            itemMsg &= "：" & _clsSystemNote.getLev4Content("AS400", "請假代碼", EachItem.Item("QDT304"))
            retMsg.Append("<BR>" & itemMsg)
        Next

        Return retMsg.ToString
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
        ReturnValue.Append(String.Format("Select * " & _
                   " From  @#PLT000LB.PQDM03PF  " & _
                   " WHERE (QD3007*10000+QD3008*100+QD3009)>={0}" & _
                   " AND (QD3007*10000+QD3008*100+QD3009)<={1}", StartDate, EndDate))


        If Not String.IsNullOrEmpty(tbDepts.Text) Then
            tbDepts.Text = tbDepts.Text.Replace("'", Nothing).ToUpper
            ReturnValue.Append(IIf(tbDepts.Text.Trim.Length > 0, "  AND QD3005 IN ('" & tbDepts.Text.Replace(",", "','") & "')", Nothing))
        End If


        If Not String.IsNullOrEmpty(tbEmployeeNameOrID.Text) Then
            tbEmployeeNameOrID.Text = tbEmployeeNameOrID.Text.Replace("'", Nothing).ToUpper
            ReturnValue.Append(" AND (")
            ReturnValue.Append(IIf(tbEmployeeNameOrID.Text.Trim.Length > 0, " QD3001  ='" & tbEmployeeNameOrID.Text.Trim & "'", Nothing))
            ReturnValue.Append(IIf(tbEmployeeNameOrID.Text.Trim.Length > 0, " OR QD3003  like '%" & tbEmployeeNameOrID.Text.Trim & "%'", Nothing))
            ReturnValue.Append(" ) ")
        End If
        ReturnValue.Append(" ORDER BY QD3005,QD3001,QD3007,QD3008,QD3009 ")

        Me.hfSQLString.Value = ReturnValue.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = String.Format("{0}/{1}/{2}", Now.Date.Year, Now.Date.Month, 1)
            tbEndDate.Text = String.Format("{0}/{1}/{2}", Now.Date.Year, Now.Date.Month, Date.DaysInMonth(Now.Date.Year, Now.Date.Month))
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ControlWhereMaker()
        GridView1.DataBind()
    End Sub
End Class