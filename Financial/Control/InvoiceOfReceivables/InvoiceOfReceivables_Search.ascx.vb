Public Class InvoiceOfReceivables_Search
    Inherits System.Web.UI.UserControl

    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New AS400DateConverter
    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote


    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As InvoiceOfReceivables_Model.主畫面_Enum, _
                           ByVal from單據號碼1 As String, ByVal from單據號碼2 As String)

#Region "ViewState：使用者登入資訊"
    Const C_LoginUserID As String = "LoginUserID"
    Const C_LoginUserUnit As String = "LoginUserUnit"

    Private Property WP_LoginUserID As String
        Get
            If ViewState(C_LoginUserID) Is Nothing Then
                Return ""
            Else
                Return ViewState(C_LoginUserID).ToString
            End If
        End Get

        Set(value As String)
            ViewState(C_LoginUserID) = value
        End Set
    End Property

    Private Property WP_LoginUserUnit As String
        Get
            If ViewState(C_LoginUserUnit) Is Nothing Then
                Return ""
            Else
                Return ViewState(C_LoginUserUnit).ToString
            End If
        End Get

        Set(value As String)
            ViewState(C_LoginUserUnit) = value
        End Set
    End Property



#End Region

    Public Sub P_reFresh子物件(ByVal from單據號碼1 As String, ByVal from單據號碼2 As String, _
                                                        ByVal fromUserUnit As String, ByVal fromUserID As String)

        If from單據號碼1.Equals(C_Status_BACK) Then Exit Sub

        Call P_Init()

        For II = 0 To ddUnit.Items.Count - 1
            If WP_ClsSystemNote.Fs_GetStrBefor(ddUnit.Items(II).Text, "：") = fromUserUnit Then
                ddUnit.SelectedIndex = II
                Exit For
            End If
        Next

        WP_LoginUserID = fromUserID
        WP_LoginUserUnit = fromUserUnit
        '調整畫面與權限控管
        '--------------------------------------------------------------------------------------------
        If (From A In WP_DataTableOfInvoice_Operator _
              Where A.Item(WP_ClsSystemNote.NOTE_ID).Equals(fromUserID) _
               Select A).Count = 0 Then
            '一般使用者
            tbOperator.Text = fromUserID
            ddUnit.Enabled = False

        Else
            '財務處收款人員
            tbOperator.Text = ""
            ddUnit.Enabled = True
            ddUnit.SelectedIndex = 0
        End If
        'ListView1
        '--------------------------------------------------------------------------------------------
        ListView1.DataBind()


        If from單據號碼1.Equals(C_Status_LOGIN) Then Exit Sub


        Me.tbInvoice_Number.Text = from單據號碼1 & from單據號碼2
        '新增單據後，畫面上呈現此筆資料
        '--------------------------------------------------------------------------------------------
        If Me.tbInvoice_Number.Text <> "" Then
            Call btnSearch_Click(btnSearch, Nothing)
        End If

    End Sub


#Region "ViewState：UnitChange_Input"
    Const C_Invoice_Operator As String = "Invoice_Operator"
    Private ReadOnly Property WP_DataTableOfInvoice_Operator As DataTable
        Get
            If ViewState(C_Invoice_Operator) Is Nothing Then
                ViewState(C_Invoice_Operator) = WP_ClsSystemNote.getLev3("財務_收款通知單", "_審核人員")
            End If
            Return ViewState(C_Invoice_Operator)
        End Get
    End Property
#End Region


#Region "ViewState：UnitChange_Input"
    Const C_Invoice_Status As String = "Invoice_Status"
    Private ReadOnly Property WP_DataTableOfInvoice_Status As DataTable
        Get
            If ViewState(C_Invoice_Status) Is Nothing Then
                ViewState(C_Invoice_Status) = WP_ClsSystemNote.getLev3("財務_收款通知單", "_單據狀態")
            End If
            Return ViewState(C_Invoice_Status)
        End Get
    End Property
#End Region

#Region "ViewState：Employee"

    Private Property WP_DataTable_Employee As DataTable
        Get
            If ViewState(C_DataTableEmployee) Is Nothing Then
                ViewState(C_DataTableEmployee) = FD_Data_Employee_Now()
            End If
            Return ViewState(C_DataTableEmployee)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableEmployee) = value
        End Set

    End Property


#End Region

#Region "ViewState：Unit"

    Private Property WP_DataTable_Unit As DataTable
        Get
            If ViewState(C_DataTableUnit) Is Nothing Then
                ViewState(C_DataTableUnit) = FD_Data_Department()
            End If
            Return ViewState(C_DataTableUnit)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableUnit) = value
        End Set

    End Property


#End Region


#Region "xxxx"
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        P_ListView1_EditMode_Exit()
        RaiseEvent Event_reFresh父物件(主畫面_Enum.編修, "NEW", "")
    End Sub

    Protected Sub btnDetail_Click(sender As Object, e As EventArgs)
        btnBatch(sender, e, 主畫面_Enum.編修)
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs)
        btnBatch(sender, e, 主畫面_Enum.列印)
    End Sub

    Private Sub P_ListView1_EditMode_Exit()
        '取消編輯模式
        ListView1.EditIndex = -1
    End Sub
    Private Sub btnBatch(sender As Object, e As EventArgs, _
                                            ByVal from主畫面_ActiveTabIndex As InvoiceOfReceivables_Model.主畫面_Enum)

        P_ListView1_EditMode_Exit()

        Dim W_單據號碼1 As String, W_單據號碼2 As Integer
        Dim W_Split() As String = CType(sender, Button).ToolTip.Split(InvoiceOfReceivables_Model.C_SystemChar)
        W_單據號碼1 = W_Split(0)
        W_單據號碼2 = W_Split(1)

        RaiseEvent Event_reFresh父物件(from主畫面_ActiveTabIndex, W_單據號碼1, W_單據號碼2)
    End Sub
#End Region



    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call P_Init()
        End If
    End Sub

    Private Sub P_Init()
        Dim W_Date_E As Date = Now
        Dim W_Date_S As Date = DateAdd(DateInterval.Day, -14, W_Date_E)

        tbDateS.Text = W_Date_S.ToString("yyyy/MM/dd")
        tbDateE.Text = W_Date_E.ToString("yyyy/MM/dd")

        tbOperator.Text = ""
        tbInvoice_Number.Text = ""

        hfSQL.Value = ""
        With ddUnit.Items
            .Clear()
            .Add("ALL：全公司")

            Dim objViewStat As DataTable = WP_DataTable_Unit

            For Each eachItem As DataRow In objViewStat.Rows
                .Add(eachItem.Item("PQDP1").Trim & "：" & eachItem.Item("PQDP2").Trim)
            Next
        End With


    End Sub

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim retSQL As New StringBuilder
        Dim W_Unit As String = ""
        Try
            CustomValidator1.ErrorMessage = ""
            W_Unit = WP_ClsSystemNote.Fs_GetStrBefor(ddUnit.Text, "：")

            retSQL.Append("SELECT * " & vbNewLine)
            retSQL.Append("FROM @#COME.KIND01PF " & vbNewLine)
            retSQL.Append("WHERE 1=1 " & vbNewLine)

            If Me.tbInvoice_Number.Text <> "" Then
                Dim W_單據號碼1 As String = "", W_單據號碼2 As Integer
                If Me.tbInvoice_Number.Text.Length >= 2 Then W_單據號碼1 = Me.tbInvoice_Number.Text.Substring(0, 2)
                If Me.tbInvoice_Number.Text.Length >= 3 Then W_單據號碼2 = Me.tbInvoice_Number.Text.Substring(2)

                retSQL.Append(" AND kd101='" & W_單據號碼1 & "' " & vbNewLine)
                retSQL.Append(" AND kd102=" & W_單據號碼2 & " " & vbNewLine)

            Else
                Dim W_DateS As Integer, W_DateE As Integer
                WP_AS400DateConverter.DateValue = Date.Parse(Me.tbDateS.Text)
                W_DateS = WP_AS400DateConverter.TwIntegerTypeData
                WP_AS400DateConverter.DateValue = Date.Parse(Me.tbDateE.Text)
                W_DateE = WP_AS400DateConverter.TwIntegerTypeData

                retSQL.Append(" AND kd105 >=" & W_DateS & " " & vbNewLine)
                retSQL.Append(" AND kd105 <=" & W_DateE & " " & vbNewLine)
                If W_Unit <> "ALL" Then
                    retSQL.Append(" AND kd104='" & W_Unit & "' " & vbNewLine)
                End If
                If Me.tbOperator.Text <> "" Then
                    retSQL.Append(" AND kd103='" & Me.tbOperator.Text & "' " & vbNewLine)
                End If
            End If

            Me.hfSQL.Value = retSQL.ToString


        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        End Try
        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")

    End Sub
#End Region


#Region "更新 方法:Update"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function Update(ByVal fromObj As COME.KIND01PF) As Integer
        'fromObj.SQLQueryAdapterByThisObject = WP_AS400Adapter

        Dim W_SQL As New StringBuilder
        W_SQL.Append("UPDATE come.kind01pf " & vbNewLine)
        W_SQL.Append("Set kd107='" & fromObj.KD107 & "' " & vbNewLine)
        W_SQL.Append("     , kd108='" & fromObj.KD108 & "' " & vbNewLine)
        W_SQL.Append("     , kd109=" & fromObj.KD109 & " " & vbNewLine)
        W_SQL.Append("     , kd110=" & fromObj.KD110 & " " & vbNewLine)
        W_SQL.Append("     , kd112='" & fromObj.KD112 & "' " & vbNewLine)

        W_SQL.Append("Where  1=1 " & vbNewLine)
        W_SQL.Append("   AND kd101='" & fromObj.KD101 & "' " & vbNewLine)
        W_SQL.Append("   AND kd102=" & fromObj.KD102 & " " & vbNewLine)

        WP_AS400Adapter.ExecuteNonQuery(W_SQL.ToString)

        Return 1
    End Function
#End Region
#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As List(Of COME.KIND01PF)
        Dim ReturnValue As New List(Of COME.KIND01PF)
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If


        ReturnValue = COME.KIND01PF.CDBSelect(Of COME.KIND01PF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return ReturnValue
    End Function
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        P_ListView1_EditMode_Exit()
        MakQryStringToControl()
    End Sub




#Region "Show：顯示於畫面上相關程式碼"


    Protected Function showInfoForPlayMethod(ByVal fromKDPlayMethod As String _
                                                                     , ByVal fromKDMemo1 As String _
                                                                     , ByVal fromKDMemo2 As String) As String
        Dim W_KDPlayMethod As String
        Dim W_KDMemo1 As String = ""
        Dim W_KDMemo2 As String = ""

        Select Case fromKDPlayMethod
            Case "A"
                W_KDPlayMethod = "支票"
                W_KDMemo1 = "票號：" & fromKDMemo1
                W_KDMemo2 = "付款行：" & fromKDMemo2
            Case "B"
                W_KDPlayMethod = "現金"
            Case "C"
                W_KDPlayMethod = "匯台銀鼓山"
            Case "D"
                W_KDPlayMethod = "其他"
                W_KDMemo1 = fromKDMemo1
            Case "E"
                W_KDPlayMethod = "定存單"
                W_KDMemo1 = "票號：" & fromKDMemo1
                W_KDMemo2 = "銀行：" & fromKDMemo2
            Case "F"
                W_KDPlayMethod = "保證函"
                W_KDMemo1 = "票號：" & fromKDMemo1
                W_KDMemo2 = "銀行：" & fromKDMemo2
            Case Else
                W_KDPlayMethod = "UnKnow：" & fromKDPlayMethod
        End Select

        W_KDPlayMethod = "[ " & W_KDPlayMethod
        W_KDPlayMethod &= " ] &nbsp<BR>"
        W_KDMemo1 &= "&nbsp<BR>"
        If W_KDMemo2 = "" Then W_KDMemo2 = "&nbsp"

        Return W_KDPlayMethod _
                      & W_KDMemo1 _
                      & W_KDMemo2
    End Function

    Protected Function showInfoForLabel(ByVal fromKDDate As String, ByVal fromKDTime As String _
                                                                     , ByVal fromKDUnit As String _
                                                                     , ByVal fromKDOper As String) As String

        Dim W_ShowDateTime As String = ""

        W_ShowDateTime = InvoiceOfReceivables_Model.showFormatFor_DateTime(True, fromKDDate, fromKDTime)

        If W_ShowDateTime = "" Then W_ShowDateTime = ModTools.showSpace(15)
        W_ShowDateTime &= "&nbsp<BR>"

        Dim W_ShowUserName As String = fromKDOper
        W_ShowUserName &= Space(1) & showEmployeeName(WP_DataTable_Employee, fromKDOper)

        Dim W_ShowUnitName As String = fromKDUnit.Replace(Space(1), "")
        W_ShowUnitName &= Space(1) & showUnitName(WP_DataTable_Unit, fromKDUnit)

        Return W_ShowDateTime _
                      & W_ShowUnitName & "<BR>" _
                      & W_ShowUserName
    End Function

    Protected Function showInfoForLabel_Number(ByVal fromKD101 As String, ByVal fromKD102 As Integer _
                                                                     , ByVal fromKD116 As String) As String

        
        Return fromKD101 & fromKD102.ToString & "<BR>" _
                      & fromKD116 & "<BR>" _
                      & "&nbsp"
    End Function

#End Region


    Protected Function showInvoice_Status(ByVal fromInvoice_StatusCode As String) As String
        Dim display_Label As String

        display_Label = (From A In WP_DataTableOfInvoice_Status Where A.Item(WP_ClsSystemNote.NOTE_ID).ToString.Trim.Equals(fromInvoice_StatusCode.Trim) Select A.Item(WP_ClsSystemNote.CONTENT)).FirstOrDefault

        Return fromInvoice_StatusCode.Trim & "：" & display_Label
    End Function

    Public Function showEditButtonStatus(ByVal fromInvoice_Date As Integer, ByVal fromInvoice_Operator As String) As Boolean
        Dim retFalg As Boolean = True

        If fromInvoice_Date > 0 OrElse
            (fromInvoice_Operator.Trim.Length > 0) Then retFalg = False

        If retFalg = True Then
            If (From A In WP_DataTableOfInvoice_Operator _
              Where A.Item(WP_ClsSystemNote.NOTE_ID).Equals(WP_LoginUserID) _
               Select A).Count = 0 Then
                retFalg = False
            End If
        End If
        Return retFalg
    End Function
#Region "ListView1 相關"

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim listViewItemObj As ListViewItem = ListView1.EditItem
        Dim fiddenFieldObj As HiddenField
        Dim dropDownListObj As DropDownList

        If Not IsNothing(listViewItemObj) Then
            dropDownListObj = listViewItemObj.FindControl("ddKD112")
            fiddenFieldObj = listViewItemObj.FindControl("KD112HiddenField")


            WP_ClsSystemNote.setDropDownList(dropDownListObj, WP_DataTableOfInvoice_Status)

            ModTools.SelectedIndexByText(dropDownListObj, fiddenFieldObj.Value.Trim)
        End If

    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating

        Try
            CustomValidator1.ErrorMessage = ""

            Dim listView As ListView = CType(sender, ListView)
            Dim colName As String
            Dim ddObj As DropDownList


            colName = "KD112"
            ddObj = CType(listView.EditItem.FindControl("dd" & colName), DropDownList)
            e.NewValues(colName) = ddObj.SelectedValue.Split("：")(0)


            Dim W_Now As Date = Now
            Dim W_輸入日期 As Integer, W_輸入時間 As Integer

            WP_AS400DateConverter.DateValue = W_Now
            W_輸入日期 = WP_AS400DateConverter.TwSevenCharsTypeData
            W_輸入時間 = W_Now.ToString("HHMMss")

            colName = "KD107"
            e.NewValues(colName) = WP_LoginUserID

            colName = "KD108"
            e.NewValues(colName) = WP_LoginUserUnit

            colName = "KD109"
            e.NewValues(colName) = W_輸入日期

            colName = "KD110"
            e.NewValues(colName) = W_輸入時間


        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        End Try
        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")

    End Sub


#End Region


End Class