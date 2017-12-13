Public Class AssetSplit
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.AST500LB.AST101PF)
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of CompanyORMDB.AST500LB.AST101PF)
        End If
        Dim ReturnValue As List(Of CompanyORMDB.AST500LB.AST101PF) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.AST500LB.AST101PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As CompanyORMDB.AST500LB.AST101PF In ReturnValue
            EachItem.TransferCount = 1
        Next
        Return ReturnValue
    End Function
#End Region

#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.AST500LB.AST101PF) As Integer

    End Function
#End Region



#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        tbNumbers.Text = tbNumbers.Text.ToUpper
        tbName.Text = tbName.Text.ToUpper
        tbDept.Text = tbDept.Text.ToUpper
        Dim SQLString As New StringBuilder
        SQLString.Append("Select A.*,B.* from @#AST500LB.AST101PF.ASTFSA A LEFT JOIN @#AST500LB.AST106PF.ASTFSA B ON A.NUMBER=B.NUMBER AND B.SEQ=1 WHERE 1=1 ")
        If Not String.IsNullOrEmpty(tbNumbers.Text) Then
            SQLString.Append(" and A.number in ('" & tbNumbers.Text.Trim.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbName.Text) Then
            SQLString.Append(" and A.name in ('" & tbName.Text.Trim.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbDept.Text) Then
            SQLString.Append(" and B.deptsa in ('" & tbDept.Text.Trim.Replace(",", "','") & "')")
        End If
        Me.hfQryString.Value = SQLString.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.MakQryStringToControl()
        Me.ListView1.DataBind()
        If Not IsNothing(ListView1.FindControl("MessageLabel")) Then
            CType(ListView1.FindControl("MessageLabel"), Label).Text = ""
        End If
    End Sub



    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Try
            Dim FindOrginAST101PF As List(Of CompanyORMDB.AST500LB.AST101PF) = CompanyORMDB.AST500LB.AST101PF.CDBSelect(Of CompanyORMDB.AST500LB.AST101PF)("Select * From @#AST500LB.AST101PF.ASTFSA WHERE NUMBER='" & e.Keys("NUMBER") & "' AND DEPT='SA'", New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
            Dim SuccessTransCount As Integer = 0
            SuccessTransCount = 0
            With FindOrginAST101PF(0)
                .TransferNewNumber = e.NewValues("TransferNewNumber")
                .TransferNewDEPTSA = e.NewValues("TransferNewDEPTSA")
                .TransferCount = e.NewValues("TransferCount")
                If FindOrginAST101PF.Count = 1 Then
                    SuccessTransCount = .AssetTransfer
                    If SuccessTransCount = 0 AndAlso Not String.IsNullOrEmpty(.AssetTransferErrorMsg) Then
                        CType(ListView1.FindControl("MessageLabel"), Label).Text = .AssetTransferErrorMsg : Exit Sub
                    End If
                Else
                    CType(ListView1.FindControl("MessageLabel"), Label).Text = "移轉失敗:找到" & FindOrginAST101PF.Count & "原始資料,無法做轉移,請洽系統管理員!"
                    Exit Sub
                End If
            End With

            '加寫一筆移轉資料至記錄中
            If SuccessTransCount > 0 Then
                Try
                    Dim InsertRec As New AST401PF
                    InsertRec.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    With InsertRec
                        .TRNDATE = New CompanyORMDB.AS400DateConverter(Now).TwIntegerTypeData
                        .TRNTIME = Format(Now, "HHmmss")
                        .FNUMBER = FindOrginAST101PF(0).NUMBER
                        .TNUMBER = FindOrginAST101PF(0).TransferNewNumber
                        .FDEPTSA = FindOrginAST101PF(0).AboutAST106PF_UseDept
                        .TDEPTSA = FindOrginAST101PF(0).TransferNewDEPTSA
                        .TRNCOUNT = FindOrginAST101PF(0).TransferCount
                        .MEMO1 = "依移轉單"
                    End With
                    InsertRec.CDBSave()
                Catch ex As Exception
                End Try
            End If
            CType(ListView1.FindControl("MessageLabel"), Label).Text = "移轉成功!"
        Catch ex As Exception
            CType(ListView1.FindControl("MessageLabel"), Label).Text = "移轉失敗:" & ex.ToString
        End Try
    End Sub

    Protected Sub btnClearInput_Click(sender As Object, e As EventArgs) Handles btnClearInput.Click
        tbNumbers.Text = Nothing
        tbName.Text = Nothing
        tbDept.Text = Nothing
    End Sub
End Class