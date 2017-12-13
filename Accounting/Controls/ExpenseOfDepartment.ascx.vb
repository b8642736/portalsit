Public Class ExpenseOfDepartment
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now.AddMonths(-1), "yyyy/MM/01")
            tbEndDate.Text = Format(CDate(tbStartDate.Text).AddMonths(1).AddDays(-1), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        GridView1.DataBind()
    End Sub


#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        If String.IsNullOrEmpty(tbStartDate.Text) Or String.IsNullOrEmpty(tbEndDate.Text) Then
            'Me.hfQry5141InMtst01pf.Value = ""
            'Me.hfQry5141NotInMtst01pf_A.Value = ""
            'Me.hfQry5141NotInMtst01pf_B.Value = ""
            'Me.hfQryOtherInMtst01pf.Value = ""
            Me.hfQtemp_Acd010P2.Value = ""
            Me.hfQtemp_Qqr1.Value = ""
            Exit Sub
        End If

        Dim StartDate As String = New AS400DateConverter(tbStartDate.Text).TwSevenCharsTypeData
        Dim EndDate As String = New AS400DateConverter(tbEndDate.Text).TwSevenCharsTypeData

        'Dim StringOf5141List As String = " '312','316','324' "
        'Dim SQLFixedWhereMtst01pf As New StringBuilder
        'SQLFixedWhereMtst01pf.Append("FROM @#MTS100LB.MTST01PF " & vbNewLine)
        'SQLFixedWhereMtst01pf.Append("        WHERE 1 = 1 " & vbNewLine)
        'SQLFixedWhereMtst01pf.Append("  AND mst018>='" & StartDate & "' AND mst018<='" & EndDate & "' " & vbNewLine)
        'SQLFixedWhereMtst01pf.Append("  AND mst030='5141' " & vbNewLine)
        'SQLFixedWhereMtst01pf.Append("  AND mst031 in (" & StringOf5141List & ") " & vbNewLine)

        Dim SQLFixedWhereAcd010pf As New StringBuilder
        SQLFixedWhereAcd010pf.Append("FROM @#ACLIB.ACD010PF " & vbNewLine)
        SQLFixedWhereAcd010pf.Append("WHERE 1 = 1 " & vbNewLine)
        SQLFixedWhereAcd010pf.Append("		  and DETLNO not in ('AAA') " & vbNewLine)
        SQLFixedWhereAcd010pf.Append("		  and acctno in ('5121','5131','5141') " & vbNewLine)
        SQLFixedWhereAcd010pf.Append("		  and actdat>=" & StartDate & "   and actdat<=" & EndDate & " " & vbNewLine)

        'Dim SQLFixedSelectAcd010pf As New StringBuilder
        'SQLFixedSelectAcd010pf.Append("SELECT KEY1, ACCTNO " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append(",SUBSTR(detlno,1,4) DETL, SUBSTR(workno,1,4) DEP " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("        ,SUBSTR(workno,1,2)  DPT, AMT  ,ITEMNO" & vbNewLine)
        'SQLFixedSelectAcd010pf.Append(" " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("from( " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("SELECT  digits(actdat) || digits(entno1) KEY1,ACCTNO " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("        ,CASE DETLNO " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("			WHEN '131' THEN " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("					    CASE SUBSTR(remark,1,2) WHEN '&F' THEN '131F' ELSE '131V' END " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("				ELSE  " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("                     DETLNO " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("			END DETLNO " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("			,WORKNO ,CASE dborcr WHEN 'A' THEN amount ELSE '-'||amount  END AMT " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("			,ITEMNO " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append(SQLFixedWhereAcd010pf.ToString & vbNewLine)
        'SQLFixedSelectAcd010pf.Append(" ) v " & vbNewLine)
        'SQLFixedSelectAcd010pf.Append("        where 1 = 1 " & vbNewLine)


        ''<1>5141 In MTS100LB.MTST01PF : 312.316.324
        'Dim SQL5141InMtst01pf As New StringBuilder
        'SQL5141InMtst01pf.Append("SELECT mst018 || mst054 KEY1 ,mst030 ACCTNO" & vbNewLine)
        'SQL5141InMtst01pf.Append("   , mst031 || ' ' DETL " & vbNewLine)
        'SQL5141InMtst01pf.Append("   ,mst020 DEP,substr(mst020,1,2)  DPT,mst007 AMT, '' ITEMNO " & vbNewLine)
        'SQL5141InMtst01pf.Append(SQLFixedWhereMtst01pf.ToString & vbNewLine)
        'SQL5141InMtst01pf.Append("  AND mst018 || mst054 IN (				" & vbNewLine)
        'SQL5141InMtst01pf.Append("				select digits(actdat) || digits(entno1) " & vbNewLine)
        'SQL5141InMtst01pf.Append(SQLFixedWhereAcd010pf.ToString & vbNewLine)
        'SQL5141InMtst01pf.Append("   ) " & vbNewLine)

        ''<2>5141 NOT IN MTS100LB.MTST01PF : 312.316.324
        ''Dim SQL5141NotInMtst01pf As New StringBuilder
        ''SQL5141NotInMtst01pf.Append(SQLFixedSelectAcd010pf.ToString & vbNewLine)
        ''SQL5141NotInMtst01pf.Append("   AND acctno='5141'   AND detlno IN (" & StringOf5141List & ") " & vbNewLine)
        ''SQL5141NotInMtst01pf.Append("   AND KEY1 NOT IN( " & vbNewLine)
        ''SQL5141NotInMtst01pf.Append("                                        SELECT mst018 || mst054 KEY1 " & vbNewLine)
        ''SQL5141NotInMtst01pf.Append(SQLFixedWhereMtst01pf.ToString & vbNewLine)
        ''SQL5141NotInMtst01pf.Append("       ) " & vbNewLine)

        'Dim SQL5141NotInMtst01pf_A As New StringBuilder
        'SQL5141NotInMtst01pf_A.Append(SQLFixedSelectAcd010pf.ToString & vbNewLine)
        'SQL5141NotInMtst01pf_A.Append("   AND acctno='5141'   AND detlno IN (" & StringOf5141List & ") " & vbNewLine)

        'Dim SQL5141NotInMtst01pf_B As New StringBuilder
        'SQL5141NotInMtst01pf_B.Append(" SELECT mst018 || mst054 KEY1 " & vbNewLine)
        'SQL5141NotInMtst01pf_B.Append(SQLFixedWhereMtst01pf.ToString & vbNewLine)

        ''<3> Other In Mtst01pf
        'Dim SQLOtherInMtst01pf As New StringBuilder
        'SQLOtherInMtst01pf.Append(SQLFixedSelectAcd010pf.ToString & vbNewLine)
        'SQLOtherInMtst01pf.Append("  AND ACCTNO in ('5141', '5131' ) " & vbNewLine)
        'SQLOtherInMtst01pf.Append("  AND ( " & vbNewLine)
        'SQLOtherInMtst01pf.Append("           DETLNO IN ('211','212','214','231','232','235','241','252','254','131F','131V') " & vbNewLine)
        'SQLOtherInMtst01pf.Append("      OR DETLNO IN ('255','256','257','258','278','279','283','286','313','321','323','329','685','686') " & vbNewLine)
        'SQLOtherInMtst01pf.Append("   ) " & vbNewLine)


        '<4> Acd010pf
        Dim SQLAcd010pf As New StringBuilder
        SQLAcd010pf.Append("SELECT ACTDAT,ENTNO1,DEPTNO,SHTNO1,ITEMNO,WORKNO,AMOUNT " & vbNewLine)
        SQLAcd010pf.Append(SQLFixedWhereAcd010pf.ToString & vbNewLine)

        'Me.hfQry5141InMtst01pf.Value = SQL5141InMtst01pf.ToString

        'Me.hfQry5141NotInMtst01pf_A.Value = SQL5141NotInMtst01pf_A.ToString
        'Me.hfQry5141NotInMtst01pf_B.Value = SQL5141NotInMtst01pf_B.ToString

        'Me.hfQryOtherInMtst01pf.Value = SQLOtherInMtst01pf.ToString

        '<1> Qtemp_Acd010P2
        Dim SQLQtemp_Acd010P2 As New StringBuilder
        SQLQtemp_Acd010P2.Append("SELECT digits(actdat) || digits(entno1) KEY1 " & vbNewLine)
        SQLQtemp_Acd010P2.Append("       ,acctno,detlno,deptno,workno " & vbNewLine)
        SQLQtemp_Acd010P2.Append("	   ,CASE dborcr WHEN 'A' THEN amount ELSE '-'||amount  END amt ,itemno  " & vbNewLine)
        SQLQtemp_Acd010P2.Append("FROM @#aclib.acd010pf.sa  " & vbNewLine)
        SQLQtemp_Acd010P2.Append("WHERE 1 = 1  " & vbNewLine)
        SQLQtemp_Acd010P2.Append("  AND actdat >= " & StartDate & " AND actdat<=" & EndDate & " " & vbNewLine)
        SQLQtemp_Acd010P2.Append("  AND acctno IN ('5121','5131','5141') " & vbNewLine)
        SQLQtemp_Acd010P2.Append("  AND detlno NOT IN ('AAA','131')  " & vbNewLine)
        SQLQtemp_Acd010P2.Append("   " & vbNewLine)
        SQLQtemp_Acd010P2.Append("UNION ALL " & vbNewLine)
        SQLQtemp_Acd010P2.Append("   " & vbNewLine)
        SQLQtemp_Acd010P2.Append("SELECT digits(actdat) || digits(entno1) KEY1 " & vbNewLine)
        SQLQtemp_Acd010P2.Append("       ,acctno " & vbNewLine)
        SQLQtemp_Acd010P2.Append("	   ,CASE SUBSTR(remark,1,2) WHEN '&F' THEN '131F' ELSE '131V' END detlno " & vbNewLine)
        SQLQtemp_Acd010P2.Append("	   ,deptno,workno " & vbNewLine)
        SQLQtemp_Acd010P2.Append("	   ,CASE dborcr WHEN 'A' THEN amount ELSE '-'||amount  END amt ,itemno  " & vbNewLine)
        SQLQtemp_Acd010P2.Append("FROM @#aclib.acd010pf.sa  " & vbNewLine)
        SQLQtemp_Acd010P2.Append("WHERE 1 = 1  " & vbNewLine)
        SQLQtemp_Acd010P2.Append("  AND actdat >= " & StartDate & " AND actdat<=" & EndDate & " " & vbNewLine)
        SQLQtemp_Acd010P2.Append("  AND acctno IN ('5121','5131','5141') " & vbNewLine)
        SQLQtemp_Acd010P2.Append("  and detlno = '131' " & vbNewLine)

        '<2>Qtemp_Qqr1
        Dim SQLQtemp_Qqr1 As New StringBuilder
        SQLQtemp_Qqr1.Append("SELECT mst018 || mst054 KEY1  " & vbNewLine)
        SQLQtemp_Qqr1.Append("       ,mst030,mst031,mst020,mst007 ,'' itemno  " & vbNewLine)
        SQLQtemp_Qqr1.Append("FROM @#mts100lb.mtst01pf  " & vbNewLine)
        SQLQtemp_Qqr1.Append("WHERE 1 = 1   " & vbNewLine)
        SQLQtemp_Qqr1.Append("  AND mst018 >= '" & StartDate & "' AND mst018 <= '" & EndDate & "'  " & vbNewLine)
        SQLQtemp_Qqr1.Append("  AND mst030 = '5141'  " & vbNewLine)
        SQLQtemp_Qqr1.Append("  and mst031 IN ('312','316','324')  " & vbNewLine)


        Me.hfQtemp_Acd010P2.Value = SQLQtemp_Acd010P2.ToString
        Me.hfQtemp_Qqr1.Value = SQLQtemp_Qqr1.ToString



        Me.hfQryAcd010pf.Value = SQLAcd010pf.ToString

        Me.hfQryDisplayType.Value = Me.rdDisplayType.SelectedValue
        Me.hfQryDisplayDept.Value = Me.tbDept.Text
    End Sub
#End Region

#Region "查詢 方法:Search"

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQLQtemp_Acd010P2 As String, _
                                                 ByVal fromSQLQtemp_Qqr1 As String, _
                                                     ByVal fromDisplayType As String, _
                                                     ByVal fromDisplayDept As String, _
                                                     ByVal fromQryAcd010pf As String) As DataTable
        'Public Function Search(ByVal fromSQL5141InMtst01pf As String, _
        '                                             ByVal fromSQL5141NotInMtst01pf_A As String, ByVal fromSQL5141NotInMtst01pf_B As String, _
        '                                             ByVal fromSQLOtherInMtst01pf As String, _
        '                                             ByVal fromDisplayType As String, _
        '                                             ByVal fromDisplayDept As String, _
        '                                             ByVal fromQryAcd010pf As String) As DataTable
        If String.IsNullOrEmpty(fromSQLQtemp_Acd010P2) _
            Or String.IsNullOrEmpty(fromSQLQtemp_Qqr1) _
            Or String.IsNullOrEmpty(fromDisplayType) Then
            Return New DataTable
        End If

        Dim Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)


        'V1
        '------------------------------------------------------------------------------
        'Step1:將三份資料(5141InMtst01pf / 5141NotInMtst01pf / OtherInMtst01pf) 整合至QueryTotalDataTable
        'Dim QueryTotalDataTable As DataTable
        'Dim Query5141InMtst01pf As DataTable = Adapter.SelectQuery(fromSQL5141InMtst01pf)

        'Dim Query5141NotInMtst01pf_A As DataTable = Adapter.SelectQuery(fromSQL5141NotInMtst01pf_A)
        'Dim Query5141NotInMtst01pf_B As DataTable = Adapter.SelectQuery(fromSQL5141NotInMtst01pf_B)
        'Dim Query5141NotInMtst01pf As DataTable = (From A In Query5141NotInMtst01pf_A _
        '                                           Where 1 = 1 _
        '                                           And Not (From B In Query5141NotInMtst01pf_B Select B.Item("KEY1")).Contains("Key1") _
        '                                           Select A).CopyToDataTable

        'Dim QueryOtherInMtst01pf As DataTable = Adapter.SelectQuery(fromSQLOtherInMtst01pf)
        'Dim QueryTotalDataTable As DataTable = Query5141InMtst01pf.Clone

        'Dim QueryList As List(Of DataTable) = New List(Of DataTable)
        'QueryList.Add(Query5141InMtst01pf)
        'QueryList.Add(Query5141NotInMtst01pf)
        'QueryList.Add(QueryOtherInMtst01pf)

        'For Each eachDataTable As DataTable In QueryList
        '    For Each eachRow As DataRow In eachDataTable.Rows
        '        QueryTotalDataTable.ImportRow(eachRow)
        '    Next
        'Next



        '1030612 改寫，舊版資料有問題，明細跟總計會重複計算兩次
        'V2
        '------------------------------------------------------------------------------
        'Step1:
        ' ------From:ACLIB.ACD010PF.SA_To:QTEMP.ACD010P2---
        ' TEQRYLB/ACD010Q2、ACD010Q2A、ACD010Q2A1、ACD010Q2A2、ACD010Q2A3、ACD010Q2A4
        Dim QuerySQLQtemp_Acd010P2 As DataTable = Adapter.SelectQuery(fromSQLQtemp_Acd010P2)


        ' ------From:QTEMP.ACD010P2_To:QTEMP.QQR2---
        ' TEQRYLB/ACD010Q2B   
        Dim paramAcctno1 As String = "5141"
        Dim paramDetlno1 As List(Of String) = New List(Of String)(New String() {"312", "316", "324"})
        Dim QuerySQLQtemp_Qqr2 As List(Of String) = (From A In QuerySQLQtemp_Acd010P2.AsEnumerable _
                                                     Where 1 = 1 _
                                                          And paramAcctno1.Contains(A.Field(Of String)("acctno").Trim) _
                                                           And paramDetlno1.Contains(A.Field(Of String)("detlno").Trim) _
                                                     Order By A.Field(Of String)("key1") _
                                                     Select A.Field(Of String)("key1")).Distinct.ToList

        ' ------From:MTS100LB.MTST01PF_To:QTEMP.QQR1---
        ' TEQRYLB/ACD010Q2C
        Dim QuerySQLQtemp_Qqr1 As DataTable = Adapter.SelectQuery(fromSQLQtemp_Qqr1)


        Dim QueryTeqrylb_Acd010p2d_Total As New DataTable
        ChangeDataTable(P_Do_Enum.產生基本欄位, QueryTeqrylb_Acd010p2d_Total)

        ' ------From:QTEMP.QQR2&QQR1_To:TEQRYLB.ACD010P2D---
        ' TEQRYLB/ACD010Q2D        

        Dim QueryTeqrylb_Acd010p2d_1 As DataTable = (From B In QuerySQLQtemp_Qqr1.AsEnumerable _
                                                                   Where QuerySQLQtemp_Qqr2.Contains(B.Field(Of String)("key1").Trim) _
                                                                   Select B).CopyToDataTable

        ChangeDataTable(P_Do_Enum.第1組, QueryTeqrylb_Acd010p2d_1)
        CopyDataTable(QueryTeqrylb_Acd010p2d_Total, QueryTeqrylb_Acd010p2d_1)


        ' ------From:QTEMP.ACD010P2&QQR1_To:TEQRYLB.ACD010P2D---
        ' TEQRYLB/ACD010Q2E
        Dim QuerySQLQtemp_Qqr1_List_key1 As List(Of String) = (From A In QuerySQLQtemp_Qqr1.AsEnumerable Select A.Field(Of String)("key1").Trim).Distinct.ToList
        Dim QueryTeqrylb_Acd010p2d_2 As DataTable = (From B In QuerySQLQtemp_Acd010P2.AsEnumerable _
                                                                                                  Where 1 = 1 _
                                                                                                        And Not (QuerySQLQtemp_Qqr1_List_key1.Contains(B.Field(Of String)("key1").Trim)) _
                                                                                                        And paramAcctno1.Contains(B.Field(Of String)("acctno").Trim) _
                                                                                                        And paramDetlno1.Contains(B.Field(Of String)("detlno").Trim) _
                                                                                                   Select B).CopyToDataTable
        ChangeDataTable(P_Do_Enum.第2組, QueryTeqrylb_Acd010p2d_2)
        CopyDataTable(QueryTeqrylb_Acd010p2d_Total, QueryTeqrylb_Acd010p2d_2)


        ' ------From:QTEMP.ACD010P2&QQR1_To:TEQRYLB.ACD010P2D---
        ' TEQRYLB/ACD010Q2F
        Dim paramAcctno2 As List(Of String) = New List(Of String)(New String() {"5141", "5131"})
        Dim paramDetlno2 As List(Of String) = New List(Of String)(New String() {"211", "212", "214", "231", "232", "235", "241", "252", "254", "131F", "131V"})
        Dim QueryTeqrylb_Acd010p2d_3 As DataTable = (From B In QuerySQLQtemp_Acd010P2.AsEnumerable _
                                                                                                    Group Join C In QuerySQLQtemp_Qqr1.AsEnumerable _
                                                                                                                On B.Field(Of String)("key1").Trim Equals C.Field(Of String)("key1").Trim _
                                                                                                                      And B.Field(Of String)("acctno").Trim Equals C.Field(Of String)("mst030").Trim _
                                                                                                                      And B.Field(Of String)("detlno").Trim Equals C.Field(Of String)("mst031").Trim _
                                                                                                              Into LeftJoinList = Group _
                                                                                                From C In LeftJoinList.DefaultIfEmpty _
                                                                                               Where 1 = 1 _
                                                                                                     And paramAcctno2.Contains(B.Field(Of String)("acctno").Trim) _
                                                                                                     And paramDetlno2.Contains(B.Field(Of String)("detlno").Trim) _
                                                                                                 Order By B.Field(Of String)("key1") _
                                                                                                     Select B).CopyToDataTable
        ChangeDataTable(P_Do_Enum.第3組, QueryTeqrylb_Acd010p2d_3)
        CopyDataTable(QueryTeqrylb_Acd010p2d_Total, QueryTeqrylb_Acd010p2d_3)



        ' ------From:QTEMP.ACD010P2&QQR1_To:TEQRYLB.ACD010P2D---
        ' TEQRYLB/ACD010Q2G
        Dim paramDetlno3 As List(Of String) = New List(Of String)(New String() {"255", "256", "257", "258", "278", "279", "283", "286", "313", "321", "323", "329", "685", "686"})
        Dim QueryTeqrylb_Acd010p2d_4 As DataTable = (From B In QuerySQLQtemp_Acd010P2.AsEnumerable _
                                                                                                    Group Join C In QuerySQLQtemp_Qqr1.AsEnumerable _
                                                                                                                On B.Field(Of String)("key1").Trim Equals C.Field(Of String)("key1").Trim _
                                                                                                                      And B.Field(Of String)("acctno").Trim Equals C.Field(Of String)("mst030").Trim _
                                                                                                                      And B.Field(Of String)("detlno").Trim Equals C.Field(Of String)("mst031").Trim _
                                                                                                              Into LeftJoinList = Group _
                                                                                                From C In LeftJoinList.DefaultIfEmpty _
                                                                                               Where 1 = 1 _
                                                                                                     And paramAcctno2.Contains(B.Field(Of String)("acctno").Trim) _
                                                                                                     And paramDetlno3.Contains(B.Field(Of String)("detlno").Trim) _
                                                                                                 Order By B.Field(Of String)("key1") _
                                                                                                     Select B).CopyToDataTable
        ChangeDataTable(P_Do_Enum.第4組, QueryTeqrylb_Acd010p2d_4)
        CopyDataTable(QueryTeqrylb_Acd010p2d_Total, QueryTeqrylb_Acd010p2d_4)



        '------------------------------------------------------------------------------

        'Step2:   I)DataRow轉Acd010p2d_DB
        '               II)Filter 使用者輸入單位
        Dim ListTotalData As List(Of Acd010p2d_DB)
        If fromDisplayDept = "" Then fromDisplayDept = Nothing 'UI近來會Nothing, 轉Excel進來會空字串
        ListTotalData = (From A In QueryTeqrylb_Acd010p2d_Total
                                        Where 1 = 1 _
                                            And (fromDisplayDept Is Nothing OrElse fromDisplayDept.Split(",").Contains(A.Item("DPT"))) _
                                         Select New Acd010p2d_DB(A.Item("KEY1"), A.Item("ACCTNO"), A.Item("DETL"), A.Item("DEP"), A.Item("DPT"), A.Item("AMT"), A.Item("ITEMNO"))).ToList


        'Step3:Group By Acd010p2d_DB
        Dim categories As IEnumerable(Of Acd010p2d_Display) = Nothing

        If fromDisplayType = "Sum" Then
            '各單位統計
            categories = From p In ListTotalData
                                  Group p By p.ACCTNO, p.DETL, p.DPTForOrderBy, p.DPT Into GroupSum = Sum(Double.Parse(p.AMT)) _
                                  Order By ACCTNO, DETL, DPTForOrderBy, DPT
                                  Select New Acd010p2d_Display(ACCTNO, DETL, DPT, GroupSum)

        ElseIf fromDisplayType = "Detail" Then
            '清單明細
            categories = From p In ListTotalData
                                  Group p By p.ACCTNO, p.DETL, p.DEP Into GroupSum = Sum(Double.Parse(p.AMT)) _
                                  Order By ACCTNO, DETL, DEP
                                  Select New Acd010p2d_Display(ACCTNO, DETL, DEP, GroupSum)

        ElseIf fromDisplayType = "Detail" OrElse fromDisplayType = "Detail2" Then
            '傳票明細
            categories = From p In ListTotalData
                                  Order By p.ACCTNO, p.DETL, p.DEP, p.KEY1
                                  Select New Acd010p2d_Display(p.ACCTNO, p.DETL, p.DEP, p.AMT, p.ITEMNO, p.KEY1)
        End If

        'Step4:Acd010p2d_Display
        Dim ReturnDataTable As New DataTable
        Dim AddRow As DataRow

        ReturnDataTable.Columns.Add(ColNameDataTable1(ColNameDataTable1_Enum.會計科目))
        ReturnDataTable.Columns.Add(ColNameDataTable1(ColNameDataTable1_Enum.明細科目))
        ReturnDataTable.Columns.Add(ColNameDataTable1(ColNameDataTable1_Enum.單位))
        ReturnDataTable.Columns.Add(ColNameDataTable1(ColNameDataTable1_Enum.金額))
        ReturnDataTable.Columns.Add(ColNameDataTable1(ColNameDataTable1_Enum.Key1))
        ReturnDataTable.Columns.Add(ColNameDataTable1(ColNameDataTable1_Enum.ITEMNO))

        For Each eachItem As Acd010p2d_Display In categories
            AddRow = ReturnDataTable.NewRow

            AddRow.Item(ColNameDataTable1_Enum.會計科目) = eachItem.會計科目
            AddRow.Item(ColNameDataTable1_Enum.明細科目) = eachItem.明細科目
            AddRow.Item(ColNameDataTable1_Enum.單位) = eachItem.單位
            AddRow.Item(ColNameDataTable1_Enum.金額) = eachItem.金額
            AddRow.Item(ColNameDataTable1_Enum.Key1) = eachItem.KEY1
            AddRow.Item(ColNameDataTable1_Enum.ITEMNO) = eachItem.ITEMNO

            ReturnDataTable.Rows.Add(AddRow)
        Next



        '各單位統計 / 清單明細 ，結束離開
        If Not fromDisplayType = "Detail2" Then
            ReturnDataTable.Columns.Remove(ColNameDataTable1(ColNameDataTable1_Enum.Key1))
            ReturnDataTable.Columns.Remove(ColNameDataTable1(ColNameDataTable1_Enum.ITEMNO))
            Return ReturnDataTable
        End If

        '------------------------------------------------------------------------------------------------------------------------------------------------------

        '傳票明細
        Dim queryAcd010PFList As DataTable = Adapter.SelectQuery(fromQryAcd010pf)
        Dim AddRow2 As DataRow
        Dim ReturnDataTable2 As New DataTable

        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.會計科目))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.明細科目))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.入帳日期))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.入帳編號))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.單位))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.金額))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.Space))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.傳票編號))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.單項代號))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.費用單位代號))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.工程或承訂編號))
        ReturnDataTable2.Columns.Add(ColNameDataTable2(ColNameDataTable2_Enum.金額2))

        Dim showKEY1 As String, show入帳日期 As String, show入帳編號 As String
        Dim show傳票單項代號 As String
        ' Dim showACD010PF As ACLIB.ACD010PF, listACD010PF As List(Of ACLIB.ACD010PF)
        Dim showACD010PF As DataRow, listACD010PF As DataTable

        Dim show費用單位代號 As String, show傳票編號 As String, show單項代號 As String, show工程或承訂編號 As String, show金額2 As String
        Dim connectStr As String

        For Each eachItem As DataRow In ReturnDataTable.Rows
            AddRow2 = ReturnDataTable2.NewRow

            AddRow2.Item(ColNameDataTable2_Enum.會計科目) = eachItem.Item(ColNameDataTable1_Enum.會計科目)
            AddRow2.Item(ColNameDataTable2_Enum.明細科目) = eachItem.Item(ColNameDataTable1_Enum.明細科目)

            showKEY1 = eachItem.Item(ColNameDataTable1_Enum.Key1)
            show入帳日期 = showKEY1.Substring(0, showKEY1.Length - 4)
            show入帳編號 = showKEY1.Substring(showKEY1.Length - 4)
            AddRow2.Item(ColNameDataTable2_Enum.入帳日期) = show入帳日期
            AddRow2.Item(ColNameDataTable2_Enum.入帳編號) = show入帳編號

            AddRow2.Item(ColNameDataTable2_Enum.單位) = eachItem.Item(ColNameDataTable1_Enum.單位)
            AddRow2.Item(ColNameDataTable2_Enum.金額) = eachItem.Item(ColNameDataTable1_Enum.金額)



            show傳票單項代號 = eachItem.Item(ColNameDataTable1_Enum.ITEMNO)
            If show傳票單項代號.Trim = "" Then
                'Type 1:交易檔 ，會找到一個傳票號碼，但裡面會有多筆資料，無法依單位代號/金額 來決定是哪一筆資料，故將全部資料顯示出來

                listACD010PF = (From A In queryAcd010PFList Where A.Item("ACTDAT") = show入帳日期 _
                                     And A.Item("ENTNO1") = show入帳編號 Select A).CopyToDataTable

                show費用單位代號 = "" : show傳票編號 = "" : show單項代號 = "" : show工程或承訂編號 = "" : show金額2 = ""
                For Each eachItemACD010PF As DataRow In listACD010PF.Rows
                    If show傳票編號 = "" Then show傳票編號 = eachItemACD010PF.Item("SHTNO1")
                    connectStr = IIf(eachItemACD010PF.Item("ITEMNO") = listACD010PF.Rows(listACD010PF.Rows.Count - 1).Item("ITEMNO"), "", "<BR>")

                    show費用單位代號 &= eachItemACD010PF.Item("DEPTNO") & connectStr
                    show單項代號 &= eachItemACD010PF.Item("ITEMNO") & connectStr
                    show工程或承訂編號 &= eachItemACD010PF.Item("WORKNO") & connectStr
                    show金額2 &= eachItemACD010PF.Item("AMOUNT") & connectStr
                Next


                AddRow2.Item(ColNameDataTable2_Enum.傳票編號) = show傳票編號
                AddRow2.Item(ColNameDataTable2_Enum.單項代號) = show單項代號
                AddRow2.Item(ColNameDataTable2_Enum.費用單位代號) = show費用單位代號
                AddRow2.Item(ColNameDataTable2_Enum.工程或承訂編號) = show工程或承訂編號
                AddRow2.Item(ColNameDataTable2_Enum.金額2) = show金額2

            Else
                'Type2.3:傳票檔
                AddRow2.Item(ColNameDataTable2_Enum.單項代號) = show傳票單項代號

                showACD010PF = (From A In queryAcd010PFList Where A.Item("ACTDAT") = show入帳日期 _
                                     And A.Item("ENTNO1") = show入帳編號 And A.Item("ITEMNO") = show傳票單項代號 Select A).FirstOrDefault
                If Not showACD010PF Is Nothing Then
                    AddRow2.Item(ColNameDataTable2_Enum.傳票編號) = showACD010PF.Item("SHTNO1")
                    AddRow2.Item(ColNameDataTable2_Enum.費用單位代號) = showACD010PF.Item("DEPTNO")
                    AddRow2.Item(ColNameDataTable2_Enum.工程或承訂編號) = showACD010PF.Item("WORKNO")
                    AddRow2.Item(ColNameDataTable2_Enum.金額2) = showACD010PF.Item("AMOUNT")

                End If


            End If

            ReturnDataTable2.Rows.Add(AddRow2)
        Next



        Return ReturnDataTable2
    End Function


#End Region

#Region ""

    Private Sub CopyDataTable(ByRef fromTagrge As DataTable, ByRef fromData As DataTable)

        Dim strLen As Integer

        For Each eachRow As DataRow In fromData.Rows
            strLen = eachRow.Item("DEP").ToString.Trim.Length

            If eachRow.Item("DPT").ToString.Trim = "" AndAlso strLen > 0 Then
                eachRow.Item("DPT") = eachRow.Item("DEP").ToString.Trim.Substring(0, (IIf(strLen = 1, 1, 2)))
            End If

            fromTagrge.ImportRow(eachRow)
        Next

    End Sub

    Public Sub ChangeDataTable(ByVal fromDo_Enum As P_Do_Enum, ByRef fromDataTable As DataTable)

        Select Case fromDo_Enum
            Case P_Do_Enum.產生基本欄位
                Dim colNum() As String = New String() {"KEY1", "ACCTNO", "DETL", "DEP", "DPT", "AMT", "ITEMNO"}
                For Each eachItem As String In colNum
                    fromDataTable.Columns.Add(eachItem)
                Next

            Case P_Do_Enum.第1組
                fromDataTable.Columns.Add("DPT")

                For Each eachItem As DataColumn In fromDataTable.Columns
                    Select Case eachItem.ColumnName.ToUpper
                        Case "MST030"
                            eachItem.ColumnName = "ACCTNO"
                        Case "MST031"
                            eachItem.ColumnName = "DETL"
                        Case "MST020"
                            eachItem.ColumnName = "DEP"
                        Case "MST007"
                            eachItem.ColumnName = "AMT"
                    End Select

                Next

            Case P_Do_Enum.第2組, P_Do_Enum.第3組, P_Do_Enum.第4組
                fromDataTable.Columns.Add("DPT")

                For Each eachItem As DataColumn In fromDataTable.Columns
                    Select Case eachItem.ColumnName.ToUpper
                        Case "DETLNO"
                            eachItem.ColumnName = "DETL"
                        Case "WORKNO"
                            eachItem.ColumnName = "DEP"
                    End Select

                Next

        End Select


    End Sub
#End Region

#Region "Enum"
    Enum P_Do_Enum
        產生基本欄位 = 0
        第1組 = 1
        第2組 = 2
        第3組 = 3
        第4組 = 4
    End Enum

    Enum ColNameDataTable1_Enum
        會計科目 = 0
        明細科目 = 1
        單位 = 2
        金額 = 3
        Key1 = 4
        ITEMNO = 5
    End Enum

    Private Function ColNameDataTable1(ByVal fromColNameDataTable1_Enum As ColNameDataTable1_Enum) As String
        Dim retColName As String = "XX"

        Select Case fromColNameDataTable1_Enum
            Case ColNameDataTable1_Enum.會計科目
                retColName = "會計科目"
            Case ColNameDataTable1_Enum.明細科目
                retColName = "明細科目"
            Case ColNameDataTable1_Enum.單位
                retColName = "單位"
            Case ColNameDataTable1_Enum.金額
                retColName = "金額"
            Case ColNameDataTable1_Enum.Key1
                retColName = "Key1"
            Case ColNameDataTable1_Enum.ITEMNO
                retColName = "ITEMNO"
        End Select

        Return retColName
    End Function

    Enum ColNameDataTable2_Enum
        會計科目 = 0
        明細科目 = 1
        入帳日期 = 2
        入帳編號 = 3
        單位 = 4
        金額 = 5
        Space = 6
        傳票編號 = 7
        單項代號 = 8
        費用單位代號 = 9
        工程或承訂編號 = 10
        金額2 = 11
    End Enum

    Private Function ColNameDataTable2(ByVal fromColNameDataTable2_Enum As ColNameDataTable2_Enum) As String
        Dim retColName As String = "XX"

        Select Case fromColNameDataTable2_Enum
            Case ColNameDataTable2_Enum.會計科目
                retColName = "會計科目"
            Case ColNameDataTable2_Enum.明細科目
                retColName = "明細科目"
            Case ColNameDataTable2_Enum.入帳日期
                retColName = "入帳日期"
            Case ColNameDataTable2_Enum.入帳編號
                retColName = "入帳編號"
            Case ColNameDataTable2_Enum.單位
                retColName = "單位"
            Case ColNameDataTable2_Enum.金額
                retColName = "金額"

            Case ColNameDataTable2_Enum.Space
                retColName = "  "

            Case ColNameDataTable2_Enum.費用單位代號
                retColName = "費用單位代號"
            Case ColNameDataTable2_Enum.傳票編號
                retColName = "傳票編號"
            Case ColNameDataTable2_Enum.單項代號
                retColName = "單項代號"
            Case ColNameDataTable2_Enum.工程或承訂編號
                retColName = "工程或承訂編號"
            Case ColNameDataTable2_Enum.金額2
                retColName = "金額2"

        End Select

        Return retColName
    End Function
#End Region



    Protected Sub btnExcelFileDownload_Click(sender As Object, e As EventArgs) Handles btnExcelFileDownload.Click
        MakQryStringToControl()
        'Dim ExcelConvert As PublicClassLibrary.DataConvertExcel _
        '                  = New PublicClassLibrary.DataConvertExcel(Search( _
        '                                                              Me.hfQry5141InMtst01pf.Value, Me.hfQry5141NotInMtst01pf_A.Value, Me.hfQry5141NotInMtst01pf_B.Value, _
        '                                                              Me.hfQryOtherInMtst01pf.Value, Me.rdDisplayType.SelectedValue, _
        '                                                              tbDept.Text, Me.hfQryAcd010pf.Value), "單位費用細目金額查詢" & Format(Now, "mmss") & ".xls")

        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel _
                  = New PublicClassLibrary.DataConvertExcel(Search( _
                                                              Me.hfQtemp_Acd010P2.Value, Me.hfQtemp_Qqr1.Value, _
                                                               Me.rdDisplayType.SelectedValue, _
                                                              tbDept.Text, Me.hfQryAcd010pf.Value), "單位費用細目金額查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub



    Private Sub GridView1_DataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If IsNothing(e.Row.DataItem) Then Exit Sub

        Dim displayDataTable As DataTable = CType(e.Row.DataItem, System.Data.DataRowView).DataView.Table
        If IsNothing(displayDataTable) Then Exit Sub

        Dim cellNow As System.Web.UI.WebControls.TableCell = Nothing
        For II As Integer = 0 To displayDataTable.Columns.Count - 1
            cellNow = e.Row.Cells(II)

            cellNow.Text = System.Web.HttpUtility.HtmlDecode(cellNow.Text)
        Next II

    End Sub


End Class


#Region "Acd010p2d相關Class"


Public Class Acd010p2d_Display

    Sub New(ByVal 會計科目 As String, ByVal 明細科目 As String, ByVal 單位 As String, ByVal 金額 As String)
        _會計科目 = 會計科目
        _明細科目 = 明細科目
        _單位 = 單位
        _金額 = 金額
    End Sub
    Sub New(ByVal 會計科目 As String, ByVal 明細科目 As String, ByVal 單位 As String, ByVal 金額 As String, ByVal ITEMNO As String, ByVal KEY1 As String)
        _會計科目 = 會計科目
        _明細科目 = 明細科目
        _單位 = 單位
        _金額 = 金額
        _ITEMNO = ITEMNO
        _KEY1 = KEY1
    End Sub

    Private _會計科目 As String
    Public Property 會計科目 As String
        Get
            Return _會計科目
        End Get
        Set(value As String)
            _會計科目 = value
        End Set
    End Property

    Private _明細科目 As String
    Public Property 明細科目 As String
        Get
            Return _明細科目
        End Get
        Set(value As String)
            _明細科目 = value
        End Set
    End Property

    Private _單位 As String
    Public Property 單位 As String
        Get
            Return _單位
        End Get
        Set(value As String)
            _單位 = value
        End Set
    End Property

    Private _金額 As String
    Public Property 金額 As String
        Get
            Return _金額
        End Get
        Set(value As String)
            _金額 = value
        End Set
    End Property

    Private _ITEMNO As String
    Public Property ITEMNO As String
        Get
            Return _ITEMNO
        End Get
        Set(value As String)
            _ITEMNO = value
        End Set
    End Property

    Private _KEY1 As String
    Public Property KEY1 As String
        Get
            Return _KEY1
        End Get
        Set(value As String)
            _KEY1 = value
        End Set
    End Property

End Class
Public Class Acd010p2d_DB
    'TEQRYLB.ACD010P2D
    Sub New(ByVal KEY1 As String, ByVal ACCTNO As String, ByVal DETL As String, ByVal DEP As String, _
                       ByVal DPT As String, ByVal AMT As String, ByVal ITEMNO As String)
        dbKEY1 = KEY1
        dbACCTNO = ACCTNO
        dbDETL = Trim(DETL)
        dbDEP = DEP

        dbDPT = DPT
        SetdbDPTForOrderBy(dbDPT)

        dbAMT = AMT
        dbITEMNO = ITEMNO
    End Sub

    Private dbKEY1 As String
    Public Property KEY1 As String
        Get
            Return dbKEY1
        End Get
        Set(value As String)
            dbKEY1 = value
        End Set
    End Property

    Private dbACCTNO As String
    Public Property ACCTNO As String
        Get
            Return dbACCTNO
        End Get
        Set(value As String)
            dbACCTNO = value
        End Set
    End Property

    Private dbDETL As String
    Public Property DETL As String
        Get
            Return dbDETL
        End Get
        Set(value As String)
            dbDETL = value
        End Set
    End Property

    Private dbDEP As String
    Public Property DEP As String
        Get
            Return dbDEP
        End Get
        Set(value As String)
            dbDEP = value
        End Set
    End Property

    Private dbDPT As String
    Public Property DPT As String
        Get
            Return dbDPT
        End Get
        Set(value As String)
            dbDPT = value
            SetdbDPTForOrderBy(dbDPT)
        End Set
    End Property


    Private dbDPTForOrderBy As String
    Private Sub SetdbDPTForOrderBy(ByVal fromDPT As String)
        Dim newDpt As String = ""

        'Note:WA要排在W0,W1前面
        'SQL排序WA會在W0,W1前面,LINQ排序WA會在W0,W1後面
        fromDPT = fromDPT.Trim
        For II As Integer = 0 To fromDPT.Length - 1
            If II >= 1 AndAlso IsNumeric(fromDPT.Substring(II, 1)) = False Then
                newDpt &= "0"
            Else
                newDpt &= fromDPT.Substring(II, 1)
            End If
        Next

        dbDPTForOrderBy = newDpt
    End Sub
    Public Property DPTForOrderBy As String
        Get
            Return dbDPTForOrderBy
        End Get
        Set(value As String)
            SetdbDPTForOrderBy(value)
        End Set
    End Property


    Private dbAMT As String
    Public Property AMT As String
        Get
            Return dbAMT
        End Get
        Set(value As String)
            dbAMT = value
        End Set
    End Property

    Private dbITEMNO As String
    Public Property ITEMNO As String
        Get
            Return dbITEMNO
        End Get
        Set(value As String)
            dbITEMNO = value
        End Set
    End Property

End Class
#End Region