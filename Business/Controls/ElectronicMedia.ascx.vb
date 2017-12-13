Public Class ElectronicMedia
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_Init()
        End If
    End Sub


#Region "P_Init"
    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        P_Init()
    End Sub

    Private Sub P_Init()
        ddEEEMM.Items.Clear()

        ddEEEMM.Items.Add("本月：" & getYYYMM(Now))
        ddEEEMM.Items.Add("上月：" & getYYYMM(DateAdd(DateInterval.Month, -1, Now)))
    End Sub

    Private Function getYYYMM(ByVal fromDate As Date) As String
        Dim eee As String = Integer.Parse(fromDate.ToString("yyyy") - 1911)
        Dim MM As String = fromDate.ToString("MM")
        Return eee & MM
    End Function

#End Region


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
    End Sub
#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim retSQL_sl2cuapf As New StringBuilder
        Dim retSQL_sgau10pf1 As New StringBuilder

        If Not (txtCustNumber.Text = "" And txtCustName.Text = "") Then
            retSQL_sl2cuapf.Append("SELECT  cua03 " & vbNewLine)
            retSQL_sl2cuapf.Append("FROM @#SLS300LB.SL2CUAPF " & vbNewLine)
            retSQL_sl2cuapf.Append("WHERE 1=1" & vbNewLine)
            retSQL_sl2cuapf.Append(IIf(txtCustNumber.Text = "", " ", " AND cua01='" & txtCustNumber.Text & "'") & vbNewLine)
            retSQL_sl2cuapf.Append(IIf(txtCustName.Text = "", " ", " AND cua02 LIKE '" & txtCustName.Text & "%'") & vbNewLine)
        End If

        retSQL_sgau10pf1.Append("SELECT  * " & vbNewLine)
        retSQL_sgau10pf1.Append("FROM @#sga600lb.sgau10pf " & vbNewLine)
        retSQL_sgau10pf1.Append("WHERE 1=1" & vbNewLine)
        retSQL_sgau10pf1.Append("AND u1000='" & ddEEEMM.Text.Split("：")(1) & "'  AND u1001='33' " & vbNewLine)
        retSQL_sgau10pf1.Append(IIf(txtReceiptNumber.Text = "", " ", " AND  UPPER(TRIM(u1007)||TRIM(u1008))='" & txtReceiptNumber.Text.ToUpper & "'") & vbNewLine)


        Me.hfSQL_sgau10pf1.Value = ""
        Me.hfSQL_sl2cuapf.Value = retSQL_sl2cuapf.ToString
        Me.hfSQL_sgau10pf1.Value = retSQL_sgau10pf1.ToString
        Me.hfSQL_sgau10pf2.Value = " ORDER BY u1007, u1008, u1091"
    End Sub

#End Region



#Region "SystemNote:CRUD"
    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As CompanyORMDB.SGA600LB.SGAU10PF) As Integer


        Dim a400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        Dim sqlDelete01 As String = fromObj.CDBDeleteSQLString
        Dim sql01Where As String = sqlDelete01.Substring(sqlDelete01.ToUpper.IndexOf(" WHERE "))

        Dim sqlUpdate02 As New StringBuilder

        sqlUpdate02.Append("INSERT INTO @#sga600lb.sgau10pf.TESA")
        sqlUpdate02.Append(" SELECT * FROM @#sga600lb.sgau10pf.sgau10pf ")
        sqlUpdate02.Append(sql01Where)

        a400Adapter.ExecuteNonQuery(sqlUpdate02.ToString)
        a400Adapter.ExecuteNonQuery(sqlDelete01)

        Return 1
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL_sl2cuapf As String, _
                                                  ByVal fromSQL_sgau10pf1 As String, _
                                                  ByVal fromSQL_sgau10pf2 As String
                                                  ) As List(Of CompanyORMDB.SGA600LB.SGAU10PF)


        If (String.IsNullOrEmpty(fromSQL_sgau10pf1) Or fromSQL_sgau10pf1 = "") Then
            Return New List(Of CompanyORMDB.SGA600LB.SGAU10PF)
        End If

        Dim querySQL As String
        Dim listCompanyNumber As String = ""
        Dim queryWhereCompanyNumber As String = ""
        Dim as400Adapter As New CompanyORMDB.AS400SQLQueryAdapter

        If Not (String.IsNullOrEmpty(fromSQL_sl2cuapf) Or fromSQL_sl2cuapf = "") Then
            Dim queryListOfSl2cuapf As List(Of CompanyORMDB.SLS300LB.SL2CUAPF) = CompanyORMDB.SLS300LB.SL2CUAPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CUAPF)(fromSQL_sl2cuapf, as400Adapter)
            For Each eachItem As CompanyORMDB.SLS300LB.SL2CUAPF In queryListOfSl2cuapf
                listCompanyNumber &= "'" & eachItem.CUA03 & "',"
            Next

            If listCompanyNumber <> "" Then
                listCompanyNumber = listCompanyNumber.Substring(0, listCompanyNumber.Length - 1)
                queryWhereCompanyNumber = " AND u1005 IN (" & listCompanyNumber & ")"

            Else
                queryWhereCompanyNumber = " AND 1=2"
            End If

        End If



        querySQL = fromSQL_sgau10pf1 & queryWhereCompanyNumber & fromSQL_sgau10pf2
        Dim queryListOfSgau10pf As List(Of CompanyORMDB.SGA600LB.SGAU10PF) = CompanyORMDB.SGA600LB.SGAU10PF.CDBSelect(Of CompanyORMDB.SGA600LB.SGAU10PF)(querySQL, as400Adapter)

        Return queryListOfSgau10pf
    End Function
#End Region

    Enum TableColunm_Enum
        刪除選取 = 0
        發票號碼 = 1
        序號 = 2
        銷售金額 = 3
        營業稅額 = 4
    End Enum

    Function getColumnName(ByVal fromTableColumn_Enum As TableColunm_Enum) As String
        Select Case fromTableColumn_Enum
            Case TableColunm_Enum.刪除選取
                Return "刪除選取"
            Case TableColunm_Enum.發票號碼
                Return "發票號碼"
            Case TableColunm_Enum.序號
                Return "序號"
            Case TableColunm_Enum.銷售金額
                Return "銷售金額"
            Case TableColunm_Enum.營業稅額
                Return "營業稅額"
            Case Else
                Return fromTableColumn_Enum
        End Select
    End Function



    Public Function CreateConfirmation(ByVal fromU1007 As String, ByVal fromU1008 As String, ByVal fromU1091 As String) As String
        Return String.Format("return confirm('您確認要刪除　發票編號: {0}   序號{1}    這筆資料?');", fromU1007.Trim & fromU1008.Trim, fromU1091)
    End Function

    Public Function showMoneyFormat(ByVal fromMoneyText As String) As String
        Dim retString As String = fromMoneyText

        If IsNumeric(fromMoneyText) = True Then
            retString = String.Format("{0:N0}", Integer.Parse(fromMoneyText))
        End If

        Return retString
    End Function


    Protected Function showSpaceChar(ByVal fromSpaceCharCount As Integer) As String
        Return Space(fromSpaceCharCount).Replace(Space(1), "&nbsp")
    End Function
End Class