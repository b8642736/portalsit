Public Class ProductionNoOnwerEdit
    Inherits System.Web.UI.UserControl

    Private WP_SYSTEM_TYPE As String = "生計_無主庫存鋼捲"

#Region "WP_NoOnwerCode"
    Private _WP_NoOnwerCode_ALL As String = "_WP_NoOnwerCode_ALL"
    Private ReadOnly Property WP_NoOnwerCode_ALL As DataTable
        Get
            If ViewState(_WP_NoOnwerCode_ALL) Is Nothing Then

                Dim queryTable1 As New DataTable
                Dim queryTable2 As New DataTable

                queryTable1 = WP_NoOnwerCode_1
                ' P_DataTable_Applen(queryTable1, "CONTENT", "生計_")
                queryTable2.Merge(queryTable1, False)

                queryTable1 = WP_NoOnwerCode_2
                ' P_DataTable_Applen(queryTable1, "CONTENT", "業務_")
                queryTable2.Merge(queryTable1, False)

                ViewState(_WP_NoOnwerCode_ALL) = queryTable2
            End If
            Return ViewState(_WP_NoOnwerCode_ALL)
        End Get

    End Property

    'Private Sub P_DataTable_Applen(ByRef fromDatatable As DataTable, ByVal fromColumn As String, ByVal fromText As String)

    '    For Each eachRow As DataRow In fromDatatable.Rows
    '        eachRow.Item(fromColumn) = String.Concat(fromText, eachRow.Field(Of String)(fromColumn))
    '    Next

    'End Sub

    Private _WP_NoOnwerCode_1 As String = "_WP_NoOnwerCode_1"
    Private ReadOnly Property WP_NoOnwerCode_1 As DataTable
        Get
            If ViewState(_WP_NoOnwerCode_1) Is Nothing Then
                Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
                Dim W_NoteType As String
                Dim queryTable As New DataTable
                W_NoteType = "無主管理代碼_生計"
                queryTable.Merge(W_ClsSystemNote.getLev3(WP_SYSTEM_TYPE, W_NoteType), False)

                ViewState(_WP_NoOnwerCode_1) = queryTable
            End If
            Return ViewState(_WP_NoOnwerCode_1)
        End Get

    End Property

    Private _WP_NoOnwerCode_2 As String = "_WP_NoOnwerCode_2"
    Private ReadOnly Property WP_NoOnwerCode_2 As DataTable
        Get
            If ViewState(_WP_NoOnwerCode_2) Is Nothing Then
                Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
                Dim W_NoteType As String
                Dim queryTable As New DataTable
                W_NoteType = "無主管理代碼_業務"
                queryTable.Merge(W_ClsSystemNote.getLev3(WP_SYSTEM_TYPE, W_NoteType), False)

                ViewState(_WP_NoOnwerCode_2) = queryTable
            End If
            Return ViewState(_WP_NoOnwerCode_2)
        End Get

    End Property

    Private _WP_DateStart As String = "_WP_DateStart"
    Private Property WP_DateStart As String
        Set(value As String)
            ViewState(_WP_DateStart) = value
        End Set
        Get
            Return ViewState(_WP_DateStart)
        End Get
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            P_Init()
        End If

    End Sub


#Region "畫面上相關控制項程式碼"
    Private Sub P_Init()
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        Dim W_NoteType As String = "生效日期"
        Dim W_NoteId As String

        W_NoteId = "START_DATE"
        WP_DateStart = W_ClsSystemNote.getLev4Content(WP_SYSTEM_TYPE, W_NoteType, W_NoteId)




        With ddNoOnwerStatus.Items
            .Clear()
            .Add("N：未有狀態")
            .Add("Y：已有狀態")
            .Add("ALL：全部")
        End With
    End Sub
#End Region

#Region "CRUD"
    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As PPS100LB.PPSCIAPF) As Integer
        Dim W_SQL As New StringBuilder
        Dim W_AS400SQLQueryAdapter As New AS400SQLQueryAdapter

        W_SQL.Append("UPDATE  @#PPS100LB.PPSCIAPF " & vbNewLine)
        W_SQL.Append("SET  cia50='" & fromObj.CIA50 & " ' " & vbNewLine)
        W_SQL.Append("WHERE 1=1 " & vbNewLine)
        W_SQL.Append("and  cia02='" & fromObj.CIA02 & " ' " & vbNewLine)
        W_SQL.Append("and  cia03='" & fromObj.CIA03 & " ' " & vbNewLine)
        W_SQL.Append("and  cia54=" & fromObj.CIA54 & " " & vbNewLine)
        W_SQL.Append("and  cia55=" & fromObj.CIA55 & " " & vbNewLine)

        W_AS400SQLQueryAdapter.ExecuteNonQuery(W_SQL.ToString)
        Return 1
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of PPS100LB.PPSCIAPF)
        If String.IsNullOrEmpty(fromSQL) Then

            Return New List(Of PPS100LB.PPSCIAPF)
        End If

        Dim retList As List(Of PPS100LB.PPSCIAPF) = PPS100LB.PPSCIAPF.CDBSelect(Of PPS100LB.PPSCIAPF)(fromSQL, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)


        Return retList
    End Function
#End Region

#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim querySql As New StringBuilder

        Dim StartDate As String = New AS400DateConverter(WP_DateStart).TwSixCharsTypeData
        
        querySql.Append("SELECT *  " & vbNewLine)
        querySql.Append("FROM @#PPS100LB.PPSCIAPF  " & vbNewLine)
        querySql.Append("WHERE 1=1  " & vbNewLine)
        querySql.Append(" and cia04 = '' " & vbNewLine)

        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Select Case W_ClsSystemNote.Fs_GetStrBefor(ddNoOnwerStatus.SelectedValue, W_ClsSystemNote.Display_Symbol)
            Case "N"
                querySql.Append(" and cia50 = '' " & vbNewLine)
            Case "Y"
                querySql.Append(" and cia50 <> '' " & vbNewLine)
            Case Else
        End Select

        If tbCIA05.Text <> "" Then
            querySql.Append(" and cia05 IN ('" & tbCIA05.Text.Replace(",", "' , '") & "') " & vbNewLine)
        End If
        If tbCIA06.Text <> "" Then
            querySql.Append(" and cia06 IN ('" & tbCIA06.Text.Replace(",", "' , '") & "') " & vbNewLine)
        End If
        If tbCIA02_03.Text <> "" Then
            querySql.Append(" and cia02 || cia03  IN ('" & tbCIA02_03.Text.Replace(",", "' , '") & "') " & vbNewLine)
        End If

        querySql.Append(" and cia16='1' " & vbNewLine)

        querySql.Append("and cia58 >= " & StartDate & " " & vbNewLine)


        querySql.Append("ORDER BY CIA02, CIA03, CIA58 ")

        Me.hfSQL.Value = querySql.ToString
    End Sub
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
    End Sub

    Public Function FS_ShowNoOnwer(ByVal fromNoOnwerID As String) As String
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        Dim W_Context As String = (From A In WP_NoOnwerCode_ALL _
                                   Where A.Field(Of String)(W_ClsSystemNote.NOTE_ID).Equals(fromNoOnwerID) _
                                   Select A.Field(Of String)(W_ClsSystemNote.CONTENT)).FirstOrDefault

        Dim W_NoOnwerID_Kind As String
        Select Case True
            Case fromNoOnwerID.Trim = ""
                W_NoOnwerID_Kind = ""
            Case Else
                W_NoOnwerID_Kind = IIf(IsNumeric(fromNoOnwerID.Trim), "業務_", "品保_")
        End Select

        Return String.Concat(W_NoOnwerID_Kind _
                             , fromNoOnwerID _
                             , IIf(String.IsNullOrEmpty(W_Context), "", W_ClsSystemNote.Display_Symbol) _
                             , IIf(String.IsNullOrEmpty(W_Context), "", W_Context))

    End Function

    Public Function FB_ShowNoOnwer_Flag(ByVal fromNoOnwerID As String) As Boolean
        Return IIf(fromNoOnwerID.Trim.Equals(""), True, False)
    End Function

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim dropDownListObj As DropDownList
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        dropDownListObj = CType(ListView1.EditItem.FindControl("CIA50DropDownList"), DropDownList)

        e.NewValues("cia50") = W_ClsSystemNote.Fs_GetStrBefor(dropDownListObj.SelectedValue, W_ClsSystemNote.Display_Symbol)
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim listViewItemObj As ListViewItem = ListView1.EditItem


        If Not IsNothing(listViewItemObj) Then
            Dim dropDownListObj As DropDownList
            dropDownListObj = listViewItemObj.FindControl("CIA50DropDownList")

            Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
            W_ClsSystemNote.setDropDownList(dropDownListObj, WP_NoOnwerCode_1, W_ClsSystemNote.Display_Lable)
        End If

    End Sub
End Class