Public Class BlackCoilOEMSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search1(ByVal SQLString As String) As QualityControlDataSet.BlackCoilOEMSearchDataTable1DataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.BlackCoilOEMSearchDataTable1DataTable
        End If
        Dim QryResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(SQLString)

        Dim ReturnValue As New QualityControlDataSet.BlackCoilOEMSearchDataTable1DataTable
        For Each EachItem In QryResult.Rows
            Dim AddRow As QualityControlDataSet.BlackCoilOEMSearchDataTable1Row = ReturnValue.NewRow
            With AddRow
                .熱軋號碼 = EachItem.Item("BWD01")
                .鋼種 = EachItem.Item("BWD02")
                .鋼胚編號 = EachItem.Item("BWD07")
                .鋼捲號碼 = EachItem.Item("BWD09")
                .熱軋批次 = EachItem.Item("BWD11")
                .派工單號碼 = EachItem.Item("BWD17")
                .厚度 = EachItem.Item("BWD03")
                .寬度 = EachItem.Item("BWD04")
                .重量 = EachItem.Item("BWD06")
                .起始線別1 = EachItem.Item("SHA08")
                .完成日期 = EachItem.Item("SHA21")
                .代工重捲 = IIf(CType(EachItem.Item("BWD16"), String) = "12", 1, 0)
                .起始線別2 = EachItem.Item("SHA08_2")

            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal FilterErrorCodes As String) As QualityControlDataSet.BlackCoilOEMSearchDataTableDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.BlackCoilOEMSearchDataTableDataTable
        End If
        Dim QryResult As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(SQLString)

        Dim ErrCodeFilterQryResult As New List(Of DataRow)
        If Not String.IsNullOrEmpty(FilterErrorCodes) AndAlso FilterErrorCodes.Trim.Length > 0 Then
            For Each EachErrCode As Char In FilterErrorCodes.Split(",")
                Dim EachErrCodeTemp As Char = EachErrCode
                ErrCodeFilterQryResult.AddRange((From A In QryResult Where Not ErrCodeFilterQryResult.Contains(A) And (Not IsDBNull(A.Item("ERRCODE1")) AndAlso CType(A.Item("ERRCODE1"), String).Trim.ToCharArray.Contains(EachErrCodeTemp)) Or (Not IsDBNull(A.Item("ERRCODE2")) AndAlso CType(A.Item("ERRCODE2"), String).Trim.ToCharArray.Contains(EachErrCodeTemp)) Select A).ToList)
            Next
        Else
            ErrCodeFilterQryResult = (From A In QryResult Select A).ToList
        End If

        Dim ReturnValue As New QualityControlDataSet.BlackCoilOEMSearchDataTableDataTable
        For Each EachItem In ErrCodeFilterQryResult
            Dim AddRow As QualityControlDataSet.BlackCoilOEMSearchDataTableRow = ReturnValue.NewRow
            With AddRow
                .熱軋號碼 = EachItem.Item("BWD01")
                .鋼種 = EachItem.Item("BWD02")
                .鋼胚編號 = EachItem.Item("BWD07")
                .鋼捲號碼 = EachItem.Item("BWD09")
                .熱軋批次 = EachItem.Item("BWD11")
                .派工單號碼 = EachItem.Item("BWD17")
                .厚度 = EachItem.Item("BWD03")
                .寬度 = EachItem.Item("BWD04")
                .重量 = EachItem.Item("BWD06")
                .煉鋼異常代碼 = ""
                If Not IsDBNull(EachItem.Item("ERRCODE1")) Then
                    .煉鋼異常代碼 &= CType(EachItem.Item("ERRCODE1"), String).Trim
                End If
                If Not IsDBNull(EachItem.Item("ERRCODE2")) Then
                    .煉鋼異常代碼 &= CType(EachItem.Item("ERRCODE2"), String).Trim
                End If
                .煉鋼異常代碼 = RemoveDoubleErrorCode(.煉鋼異常代碼)
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function

    Private Function RemoveDoubleErrorCode(ByVal SourceErrorCode As String) As String
        Dim ReturnValue As String = ""
        For Each EachItem As Char In SourceErrorCode.ToCharArray
            If Not ReturnValue.Contains(EachItem) Then
                ReturnValue &= EachItem
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
    Private Sub MakerSQLStringToControl1()
        Dim ReturnValue As String = "Select A.* ,B.SHA08,B.SHA21 ,COALESCE(C.SHA08 , '') AS SHA08_2 from @#PPS100LB.PPSBWDPF AS A LEFT JOIN @#PPS100LB.PPSSHAPF.HIPRO B ON A.BWD09=B.SHA01 AND B.SHA04=1 LEFT JOIN @#PPS100LB.PPSSHAPF.HIPRO C ON A.BWD09=C.SHA01 AND C.SHA04=2 WHERE  1=1 "

        If Not String.IsNullOrEmpty(tbBatchNumber.Text) Then
            tbBatchNumber.Text = tbBatchNumber.Text.Replace("'", Nothing)
            If tbBatchNumber.Text.Contains("~") Then
                ReturnValue &= IIf(tbBatchNumber.Text.Trim.Length > 0, " AND A.BWD11 >= '" & tbBatchNumber.Text.Split("~")(0).Trim & "' AND A.BWD11 <= '" & tbBatchNumber.Text.Split("~")(1).Trim & "'", Nothing)
            Else
                ReturnValue &= IIf(tbBatchNumber.Text.Trim.Length > 0, " AND A.BWD11 IN ('" & tbBatchNumber.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If

        If Not String.IsNullOrEmpty(tbCSCNumber.Text) AndAlso tbCSCNumber.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.BWD01 IN ('" & tbCSCNumber.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')"
        End If

        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.BWD02 IN ('" & tbSteelKind.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')"
        End If

        If Not String.IsNullOrEmpty(tbSlabNumber.Text) AndAlso tbSlabNumber.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.BWD07 IN ('" & tbSlabNumber.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')"
        End If

        If Not String.IsNullOrEmpty(tbCoilNumber.Text) AndAlso tbCoilNumber.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.BWD09 IN ('" & tbCoilNumber.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')"
        End If


        Me.hfControlSQLMaker1.Value = ReturnValue & " Order by A.BWD01"
    End Sub

    Private Sub MakerSQLStringToControl()
        Dim ReturnValue As String = "Select A.* , B.SGE11 AS ERRCODE1, C.SGA26 AS ERRCODE2 from @#PPS100LB.PPSBWDPF AS A Left Join @#SMS100LB.smssgepf AS B ON A.BWD07= (B.sga01 || '-'  || B.sga02 || Right('0' || B.sga03,2) || B.sga04) Left Join @#SMS100LB.SMSSGAPF AS C ON A.BWD07= (C.sga01 || '-'  || C.sga02 || Right('0' || C.sga03,2) || C.sga04)  WHERE  1=1 "


        If Not String.IsNullOrEmpty(tbBatchNumber.Text) Then
            tbBatchNumber.Text = tbBatchNumber.Text.Replace("'", Nothing)
            If tbBatchNumber.Text.Contains("~") Then
                ReturnValue &= IIf(tbBatchNumber.Text.Trim.Length > 0, " AND A.BWD11 >= '" & tbBatchNumber.Text.Split("~")(0).Trim & "' AND A.BWD11 <= '" & tbBatchNumber.Text.Split("~")(1).Trim & "'", Nothing)
            Else
                ReturnValue &= IIf(tbBatchNumber.Text.Trim.Length > 0, " AND A.BWD11 IN ('" & tbBatchNumber.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If

        If Not String.IsNullOrEmpty(tbCSCNumber.Text) AndAlso tbCSCNumber.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.BWD01 IN ('" & tbCSCNumber.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')"
        End If

        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.BWD02 IN ('" & tbSteelKind.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')"
        End If

        If Not String.IsNullOrEmpty(tbSlabNumber.Text) AndAlso tbSlabNumber.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.BWD07 IN ('" & tbSlabNumber.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')"
        End If

        If Not String.IsNullOrEmpty(tbCoilNumber.Text) AndAlso tbCoilNumber.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.BWD09 IN ('" & tbCoilNumber.Text.Replace("'", Nothing).Replace(",", "','").Trim & "')"
        End If

        hfErrCodes.Value = tbErrCode.Text.Replace("'", Nothing)
        Me.hfControlSQLMaker.Value = ReturnValue & " Order by A.BWD01"
    End Sub
#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        If RadioButtonList1.SelectedValue = "TYPE0" Then
            Me.MultiView1.SetActiveView(View1)
            MakerSQLStringToControl()
            Me.GridView1.DataBind()
        Else
            Me.MultiView1.SetActiveView(View2)
            MakerSQLStringToControl1()
            Me.GridView2.DataBind()
        End If
    End Sub

    Protected Sub tbSearch0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch0.Click
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel
        If RadioButtonList1.SelectedValue = "TYPE0" Then
            MakerSQLStringToControl()
            ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfControlSQLMaker.Value, Me.hfErrCodes.Value), "黑皮鋼捲資料查詢(格式1)" & Format(Now, "mmss") & ".xls")
        Else
            MakerSQLStringToControl1()
            ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search1(Me.hfControlSQLMaker1.Value), "黑皮鋼捲資料查詢(格式2)" & Format(Now, "mmss") & ".xls")
        End If

        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        tbErrCode.Enabled = (RadioButtonList1.SelectedValue = "TYPE0")
        If tbErrCode.Enabled = False Then
            tbErrCode.Text = Nothing
        End If
    End Sub
End Class