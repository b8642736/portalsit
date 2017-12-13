Public Class StandSampleStdDevEdit
    Inherits System.Web.UI.UserControl


#Region "Main"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            MultiView1.SetActiveView(View1)
        End If

    End Sub
#End Region

#Region "ListView1"
    Protected Sub btnQuery_EachOneRecord_Click(sender As Object, e As EventArgs) Handles btnQuery_EachOneRecord.Click
        MakeQryStringToControl_ListView1()
    End Sub

    Private Sub MakeQryStringToControl_ListView1()
        Dim W_SQL As New StringBuilder

        W_SQL.Append("SELECT V1.* " & vbNewLine)
        W_SQL.Append("FROM 標準樣本接收資料標準差管制 v1 " & vbNewLine)

        If cbShowLastNew.Checked = True Then
            W_SQL.Append("   INNER JOIN ( " & vbNewLine)
            W_SQL.Append("                 Select SampleID, MAX(SampleVer) SampleVer_Max " & vbNewLine)
            W_SQL.Append("                 FROM 標準樣本接收資料標準差管制 " & vbNewLine)
            W_SQL.Append("                 WHERE 1=1 " & vbNewLine)
            W_SQL.Append("                 GROUP BY SampleID " & vbNewLine)
            W_SQL.Append("   ) as v2 ON v2.SampleID =v1.SampleID AND v2.SampleVer_Max = v1.SampleVer " & vbNewLine)
        End If

        W_SQL.Append("                 WHERE 1=1 " & vbNewLine)
        W_SQL.Append("                  " & IIf(Me.tbQuerySampleID_EachOneRecord.Text = "", "", "  AND v1.SampleID='" & Me.tbQuerySampleID_EachOneRecord.Text & "'") & "  " & vbNewLine)

        W_SQL.Append("ORDER BY v1.SampleID, v1.SampleVer DESC, v1.SampleKind " & vbNewLine)
        Me.hfSQL_EachOneRecord.Value = W_SQL.ToString
        Me.hfQueryDate.Value = Now.ToString("yyyy/MM/dd HH:mm:ss")
    End Sub

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search_EachOneRecord(ByVal fromSQL As String, ByVal fromQueryDate As String) As List(Of CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制)
        Dim queryObj As New List(Of CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制)

        If String.IsNullOrEmpty(fromSQL) Then
            Return queryObj
        End If

        queryObj = CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)
        Return queryObj
    End Function

    Private Sub GridView_EachOneRecord_PreRender(sender As Object, e As EventArgs) Handles GridView_EachOneRecord.PreRender
        Dim i As Integer = 1
        Dim AlternatingRowStyle_i As Integer = 1
        Dim mySingleRow As GridViewRow
        Dim iRow As Integer

        'GridView_EachOneRecord.HeaderStyle.BackColor = FC_Color1()
        For Each mySingleRow In GridView_EachOneRecord.Rows

            If CInt(mySingleRow.RowIndex) = 0 Then

                mySingleRow.Cells(0).RowSpan = 1
                mySingleRow.Cells(1).RowSpan = 1
                'mySingleRow.Cells(2).RowSpan = 1
                'mySingleRow.Cells(3).RowSpan = 1
            Else
                If mySingleRow.Cells(1).Text.Trim() = GridView_EachOneRecord.Rows(CInt(mySingleRow.RowIndex) - i).Cells(1).Text.Trim() Then
                    GridView_EachOneRecord.Rows(CInt(mySingleRow.RowIndex) - i).Cells(0).RowSpan += 1
                    GridView_EachOneRecord.Rows(CInt(mySingleRow.RowIndex) - i).Cells(1).RowSpan += 1
                    i = i + 1
                    mySingleRow.Cells(0).Visible = False
                    mySingleRow.Cells(1).Visible = False
                Else
                    ''----- 自己寫程式來處理AlternatingRowStyle的功能 -------------------
                    'If (AlternatingRowStyle_i Mod 2) <> 0 Then
                    '    For iRow = mySingleRow.RowIndex To (mySingleRow.RowIndex) + 1
                    '        P_GridView_SetColor(GridView_EachOneRecord, iRow)
                    '    Next iRow
                    'End If

                    'AlternatingRowStyle_i += 1
                    ''----------------------------------------------------------------
                    GridView_EachOneRecord.Rows(CInt(mySingleRow.RowIndex)).Cells(0).RowSpan = 1
                    GridView_EachOneRecord.Rows(CInt(mySingleRow.RowIndex)).Cells(1).RowSpan = 1
                    i = 1
                End If
            End If
        Next
    End Sub

    'Private Function FC_Color1() As System.Drawing.Color
    '    ' Return System.Drawing.ColorTranslator.FromHtml("#A6C2FF")
    '    Return FC_Color2()
    'End Function

    'Private Function FC_Color2() As System.Drawing.Color
    '    Return System.Drawing.ColorTranslator.FromHtml("#D2F0FF")
    'End Function

    'Private Sub P_GridView_SetColor(ByRef fromGridview As GridView, ByVal fromRow As Integer)
    '    For iCol As Integer = 0 To fromGridview.Columns.Count - 1
    '        fromGridview.Rows(fromRow).Cells(iCol).BackColor = FC_Color2()
    '    Next iCol
    'End Sub

#End Region




#Region "ListView2"

    Private Function FS_CheckAssayItemValue() As String
        Dim retMsg As String = ""
        Dim W_Obj_Textbox As TextBox

        For Each W_AssayItem As String In FS_AssayItem()

            For Each W_SampleKind As String In FS_SampleKind()
                W_Obj_Textbox = CType(Me.FindControl("tbItem" & W_AssayItem & "_" & W_SampleKind), TextBox)
                retMsg &= IIf(IsNumeric(W_Obj_Textbox.Text), "", W_AssayItem & "_" & W_SampleKind & "、")
            Next

        Next

        If retMsg <> "" Then retMsg = "欄位值非數字：" & retMsg.Substring(0, retMsg.Length - 1)
        Return retMsg
    End Function

    Private Sub P_PutAssayItemValue1(ByRef fromAssayItem_Mean As CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制, _
                                                                    ByRef fromAssayItem_Sed As CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制)

        Dim W_Obj_Textbox As TextBox
        Dim W_AssayItem_Now As CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制 = Nothing

        For Each W_SampleKind As String In FS_SampleKind()
            Select Case W_SampleKind
                Case "Mean"
                    W_AssayItem_Now = fromAssayItem_Mean
                Case "Std"
                    W_AssayItem_Now = fromAssayItem_Sed
            End Select

            For Each W_AssayItem As String In FS_AssayItem()
                W_Obj_Textbox = CType(Me.FindControl("tbItem" & W_AssayItem & "_" & W_SampleKind), TextBox)

                W_AssayItem_Now.SampleKind = W_SampleKind
                setClassValue(W_AssayItem_Now, W_AssayItem, W_Obj_Textbox.Text)
            Next
        Next
    End Sub

    Private Sub P_PutAssayItemValue2(ByRef fromAssayItem As CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制, _
                                                                      ByVal fromSampleID As String, ByVal fromSampleVer As Integer, _
                                                                      ByVal fromModDate As Date, ByVal fromModOperator As String)
        With fromAssayItem
            .SampleID = fromSampleID
            .SampleVer = fromSampleVer
            .ModDate = fromModDate
            .ModOperator = fromModOperator
        End With

    End Sub

    Protected Sub btnSave_OneItemAllRecord_Click(sender As Object, e As EventArgs) Handles btnSave_OneItemAllRecord.Click
        Dim W_Status_DB As Boolean = False
        Dim W_SampleVer As Integer = 0
        Dim W_SQL As String = ""
        Dim W_AssayItem_Mean As New CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制
        Dim W_AssayItem_Std As New CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制
        Dim W_Now As Date, W_Operator As String
        Try
            'Check Data
            '-------------------------------------------------------
            Me.tbMsg.Text = FS_CheckAssayItemValue()
            If Me.tbMsg.Text <> "" Then Exit Sub

            If Me.tbSampleID.Text = "" Then
                Me.tbMsg.Text = "『樣品編號』未輸入"
                Exit Sub
            End If


            'Prepare Data
            '-------------------------------------------------------            
            '畫面上
            P_PutAssayItemValue1(W_AssayItem_Mean, W_AssayItem_Std)

            '其他
            W_SQL = "SELECT MAX(SampleVer) SampleVer_MAX FROM 標準樣本接收資料標準差管制 WHERE  SampleID='" & Me.tbSampleID.Text & "'"
            Dim W_QueryTable As DataTable = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01").SelectQuery(W_SQL)
            W_SampleVer = Integer.Parse(PublicClassLibrary.ModTools.NoNull(W_QueryTable.Rows(0).Item(0), 0)) + 1
            W_Now = Now
            W_Operator = WebAppAuthority.CurrentWindowsLoginEmployeeNumber

            P_PutAssayItemValue2(W_AssayItem_Mean, Me.tbSampleID.Text, W_SampleVer, W_Now, W_Operator)
            P_PutAssayItemValue2(W_AssayItem_Std, Me.tbSampleID.Text, W_SampleVer, W_Now, W_Operator)
            '-------------------------------------------------------

            'DB start
            '-------------------------------------------------------
            W_Status_DB = True
            W_AssayItem_Mean.CDBSave()
            W_AssayItem_Std.CDBSave()

            '-------------------------------------------------------
            MultiView1.SetActiveView(View1)
            btnQuery_EachOneRecord_Click(Nothing, Nothing)

        Catch ex As Exception
            Me.tbMsg.Text = ex.Message
            If W_Status_DB = True Then
                W_AssayItem_Mean.CDBDelete()
                W_AssayItem_Std.CDBDelete()
            End If
        End Try

    End Sub

    Protected Sub btnCancel_OneItemAllRecord_Click(sender As Object, e As EventArgs) Handles btnCancel_OneItemAllRecord.Click
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub btnAddNewRecord_Click(sender As Object, e As EventArgs) Handles btnAddNewRecord.Click
        P_ShowView2(tbQuerySampleID_EachOneRecord.Text, -1)
    End Sub

    Protected Sub btnEachOneRecord_Edit_Click(sender As Object, e As EventArgs)
        Dim btnParam As String = CType(sender, Button).ToolTip
        Dim param As String() = btnParam.Split("|")

        P_ShowView2(param(0), param(1))
    End Sub

    Protected Sub P_ShowView2(ByVal fromSampleID As String, ByVal fromSampleVer As Integer)
        MultiView1.SetActiveView(View2)

        MakeQryStringToControl_ListView2(fromSampleID, fromSampleVer)

        Search_LastNewRecord(Me.hfSQL_LastNewRecord.Value, fromSampleID)
    End Sub

    Private Sub MakeQryStringToControl_ListView2(ByVal fromSampleID As String, ByVal fromSampleVer As Integer)
        Dim W_SQL As New StringBuilder

        W_SQL.Append("SELECT V1.* " & vbNewLine)
        W_SQL.Append("FROM 標準樣本接收資料標準差管制 v1 " & vbNewLine)
        W_SQL.Append("WHERE 1=1 " & vbNewLine)
        W_SQL.Append("  AND SampleID='" & fromSampleID & "'  " & vbNewLine)
        W_SQL.Append("  AND SampleVer=" & fromSampleVer & "  " & vbNewLine)
        W_SQL.Append("ORDER BY v1.SampleKind " & vbNewLine)
        Me.hfSQL_LastNewRecord.Value = W_SQL.ToString
    End Sub


    Public Sub Search_LastNewRecord(ByVal fromSQL As String, ByVal fromSampleID As String)
        Try
            Me.tbMsg.Text = "" : Me.tbSampleID.Text = fromSampleID

            Dim W_Obj_Textbox As TextBox
            Dim W_queryItem As CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制
            Dim queryList As New List(Of CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制)
            queryList = CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.標準樣本接收資料標準差管制)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)

            For Each W_SampleKind As String In FS_SampleKind()
                W_queryItem = (From A In queryList Where A.SampleKind.Equals(W_SampleKind) Select A).FirstOrDefault

                For Each W_AssayItem As String In FS_AssayItem()
                    W_Obj_Textbox = CType(Me.FindControl("tbItem" & W_AssayItem & "_" & W_SampleKind), TextBox)
                    'W_Obj_Textbox.Text = IIf(W_queryItem Is Nothing, "0", getClassValue(W_queryItem, W_AssayItem))
                    If W_queryItem Is Nothing Then
                        W_Obj_Textbox.Text = "0"
                    Else
                        W_Obj_Textbox.Text = getClassValue(W_queryItem, W_AssayItem)
                    End If
                Next

            Next

        Catch ex As Exception
            Me.tbMsg.Text = ex.Message
        End Try

    End Sub

    Private Function FS_SampleKind() As String()
        Return New String() {"Mean", "Std"}
    End Function

    Private Function FS_AssayItem() As String()
        Return New String() {"C", "Si", "Mn", "P", "S", "Cr", "Ni", "Cu", "Mo", "Co", "AL", "Sn", "Pb", "Ti", "Nb", "V", "W", "N2", "O2", "B", "Ca", "Mg", "As", "Bi", "Sb", "Zn", "Zr", "Fe", "Ta"}
    End Function


    Public Sub setClassValue(ByVal fromClass As CompanyORMDB.ORMBaseClass.ClassDB, ByVal FieldName As String, ByVal fromValue As Object)
        fromClass.CDBSetFieldValue(FieldName, fromValue)
    End Sub

    Public Function getClassValue(ByVal fromClass As CompanyORMDB.ORMBaseClass.ClassDB, ByVal FieldName As String) As Object
        'Dim retObject As Object = Nothing

        'For Each eachItem As System.Reflection.PropertyInfo In fromClass.CDBGetFieldValue(fromPropertyInfoName)
        '    If eachItem.Name = fromPropertyInfoName Then
        '        retObject = eachItem.GetValue(fromClass, Nothing)
        '        Exit For
        '    End If
        'Next

        Return fromClass.CDBGetFieldValue(FieldName)
    End Function
#End Region





End Class