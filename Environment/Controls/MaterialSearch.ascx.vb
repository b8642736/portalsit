Public Class MaterialSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As EnvironmentDataSet.MaterialSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New EnvironmentDataSet.MaterialSearchDataTable
        End If
        Dim QryResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(SQLString)
        Dim ReturnValue As New EnvironmentDataSet.MaterialSearchDataTable
        For Each EachKey As String In (From A In QryResult Select A.Item("MST012") & "," & A.Item("MST002") & "," & CType(A.Item("MST018"), String).Substring(0, 5)).Distinct
            Dim GroupData As List(Of DataRow) = (From A In QryResult Where A.Item("MST012") = EachKey.Split(",")(0) And A.Item("MST002") = EachKey.Split(",")(1) And CType(A.Item("MST018"), String).Substring(0, 5) = EachKey.Split(",")(2) Select A).ToList
            If GroupData.Count > 0 Then
                Dim AddRow As EnvironmentDataSet.MaterialSearchRow = ReturnValue.NewRow
                With AddRow
                    .用途單位 = EachKey.Split(",")(0)
                    .料號 = EachKey.Split(",")(1)
                    .年月 = EachKey.Split(",")(2)
                    If Not IsDBNull(GroupData(0).Item("MSM002")) Then
                        .品名 = GroupData(0).Item("MSM002")
                    End If
                    If Not IsDBNull(GroupData(0).Item("MSM003")) Then
                        .規範 = GroupData(0).Item("MSM003")
                    End If
                    If Not IsDBNull(GroupData(0).Item("MSM004")) Then
                        .計量單位 = GroupData(0).Item("MSM004")
                    End If
                    .實收數量 = (From A In GroupData Select Val(A.Item("MST003"))).Sum
                End With
                ReturnValue.Rows.Add(AddRow)
            End If
        Next

        Return ReturnValue
    End Function

#End Region

#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerSQLStringToControl()
        Dim ReturnValue As String = "Select A.MST002,A.MST003,A.MST012,A.MST018,B.MSM002,B.MSM003,B.MSM004 FROM @#MTS100LB.MTST01PF A LEFT JOIN @#MTS100LB.MTSM01PF B ON A.MST002=B.MSM001  WHERE  A.MST001='D' AND A.MST003<>0 "
        Dim CStartDate As String = (Val(Format(CDate(Me.tbStartDate.Text), "yyyy")) - 1911) & Format(CDate(Me.tbStartDate.Text), "MM")
        Dim CEndDate As String = (Val(Format(CDate(Me.tbEndDate.Text), "yyyy")) - 1911) & Format(CDate(Me.tbEndDate.Text), "MM")
        ReturnValue &= " AND LEFT(MST018,5)>='" & CStartDate & "' AND LEFT(MST018,5)<='" & CEndDate & "'"


        Me.hfQry.Value = ReturnValue & " Order by A.MST002"
    End Sub
#End Region


    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        tbStartDate.Text = Format(Now, "yyyy/MM/01")
        tbEndDate.Text = Format(Now, "yyyy/MM/dd")
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.MakerSQLStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        Me.MakerSQLStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel  = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQry.Value), "單位物料查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class