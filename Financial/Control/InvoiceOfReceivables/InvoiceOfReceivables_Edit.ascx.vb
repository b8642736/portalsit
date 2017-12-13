Public Class InvoiceOfReceivables_Edit
    Inherits System.Web.UI.UserControl

    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New AS400DateConverter
    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

    Private C_SYSTEM_TYPE As String = "財務_收款通知單"


    Private Const C_TableEdit2_Row As Integer = 5
    Private C_idbtnSystemNote As String = "btSystemNote"
    Private C_idtextBox1 As String = "tbItem"
    Private C_idtextBox2 As String = "tbAmount"
    Private C_idtextBox3 As String = "tbMemo"

    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As InvoiceOfReceivables_Model.主畫面_Enum, _
                           ByVal from單據號碼1 As String, ByVal from單據號碼2 As String)

    Private Function WP_項目數量_目前() As Integer
        Return CType(Me.hfTableRowCount.Value, Integer)
    End Function


#Region "ViewState：畫面上資料暫存區"
    <Serializable()> _
    Class ListDataType
        Implements Runtime.Serialization.ISerializable

#Region "Index"
        Private _Index As Integer
        Public Property Index As Integer
            Get
                Return _Index
            End Get
            Set(value As Integer)
                _Index = (value + 1)
            End Set
        End Property
#End Region

#Region "Key"
        Private _Key As String
        Public Property Key As String
            Get
                Return _Key
            End Get
            Set(value As String)
                _Key = value
            End Set
        End Property
#End Region

#Region "Value"
        Private _Value As String
        Public Property Value As String
            Get
                Return _Value
            End Get
            Set(value As String)
                _Value = value
            End Set
        End Property
#End Region

        Public Sub New(ByVal fromKey As String, ByVal fromValue As String, ByVal fromIndex As Integer)
            Me.Key = fromKey
            Me.Value = fromValue
            Me.Index = fromIndex
        End Sub

#Region "序列化/反序列化"
        Public Sub New(info As Runtime.Serialization.SerializationInfo, context As Runtime.Serialization.StreamingContext)
            For Each eachItem As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                eachItem.SetValue(Me, info.GetValue(eachItem.Name, eachItem.PropertyType), Nothing)
            Next
        End Sub

        Public Sub GetObjectData(info As Runtime.Serialization.SerializationInfo, context As Runtime.Serialization.StreamingContext) Implements Runtime.Serialization.ISerializable.GetObjectData
            For Each eachItem As System.Reflection.PropertyInfo In Me.GetType.GetProperties
                info.AddValue(eachItem.Name, eachItem.GetValue(Me, Nothing))
            Next
        End Sub
#End Region
    End Class

    Const C_ListData As String = "cListData"
    Private Property WP_ListData As List(Of ListDataType)
        Get
            Return ViewState(C_ListData)
        End Get

        Set(value As List(Of ListDataType))
            ViewState(C_ListData) = value
        End Set
    End Property
#End Region

#Region "ViewState：PayMethod"

    Const C_PayMethod As String = "PayMethod"
    Private ReadOnly Property WP_DataTable_PayMethod As DataTable
        Get
            If ViewState(C_PayMethod) Is Nothing Then
                ViewState(C_PayMethod) = WP_ClsSystemNote.getLev3(C_SYSTEM_TYPE, "_付款方式")
            End If

            Return CType(ViewState(C_PayMethod), DataTable)
        End Get

    End Property
#End Region

    Public Sub P_reFresh子物件(ByVal from單據號碼1 As String, ByVal from單據號碼2 As String, _
                                                        ByVal fromUserUnit As String, ByVal fromUserID As String)

        P_Init()
        'MultiView1.SetActiveView(View1)
        Me._tbInvoice_Number.Text = (from單據號碼1 & from單據號碼2)

        Dim editMode As EditMode_Enum

        If Me._tbInvoice_Number.Text = "NEW" Then
            editMode = EditMode_Enum.新增

            Me._tbInvoice_Number.Text = ""
            Me.tbPurchase_Number.Text = ""
            Me._tbKeyIn_Unit.Text = fromUserUnit
            Me._tbKeyIn_Operator.Text = fromUserID

        Else

            editMode = EditMode_Enum.查詢

        End If


        P_LockAndRefreshController(editMode)
        If Me._tbInvoice_Number.Text = "" Then Exit Sub

        Select Case editMode
            Case EditMode_Enum.查詢, EditMode_Enum.編輯
                P_LoadDataByInvoice_Number(from單據號碼1, from單據號碼2)

                '動態HtmlTable
                P_LockAndRefreshController(editMode, tableEdit2)
        End Select


    End Sub



#Region "鎖定畫面上物件：P_LockAndRefreshController"

    Private Sub P_LockAndRefreshController(ByVal fromEditMode As EditMode_Enum)

        For Each eachItem As System.Web.UI.Control In Me.View1.Controls
            P_LockAndRefreshController(fromEditMode, eachItem)
        Next
    End Sub

    Private Sub P_LockAndRefreshController(ByVal fromEditMode As EditMode_Enum, ByVal fromControl As Control)
        Dim objRadioButton As RadioButton
        Dim objDropDownList As DropDownList
        Dim objButton As Button, objTextBox As TextBox
        Dim objCustomValidator As CustomValidator

        Dim objHtmlTable As HtmlTable
        Dim objHtmlTableRow As HtmlTableRow
        Dim objHtmlTableCell As HtmlTableCell

        Select Case True

            Case TypeOf fromControl Is CustomValidator
                objCustomValidator = CType(fromControl, CustomValidator)
                objCustomValidator.ErrorMessage = ""
                objCustomValidator.IsValid = True

            Case TypeOf fromControl Is RadioButton
                objRadioButton = CType(fromControl, RadioButton)

                If fromEditMode = EditMode_Enum.初始化 OrElse _
                    fromEditMode = EditMode_Enum.新增 Then

                    'objRadioButton.Checked = (objRadioButton.ID = rbPlayMethodB.ID) '預設:現金

                    '付款方式
                    '-----------------------------------------------------
                    Dim W_PayMethod As String = ""
                    '1:by User
                    W_PayMethod = (From A As DataRow In WP_DataTable_PayMethod Where A.Item(WP_ClsSystemNote.NOTE_ID).Equals(Me._tbKeyIn_Operator.Text) Select A.Item(WP_ClsSystemNote.CONTENT)).FirstOrDefault

                    If W_PayMethod = "" Then
                        '2:by Unit
                        W_PayMethod = (From A As DataRow In WP_DataTable_PayMethod Where A.Item(WP_ClsSystemNote.NOTE_ID).Equals(Me._tbKeyIn_Unit.Text) Select A.Item(WP_ClsSystemNote.CONTENT)).FirstOrDefault
                    End If

                    If W_PayMethod = "" Then
                        '3:by 系統預設
                        W_PayMethod = (From A As DataRow In WP_DataTable_PayMethod Where A.Item(WP_ClsSystemNote.NOTE_ID).Equals("系統預設") Select A.Item(WP_ClsSystemNote.CONTENT)).FirstOrDefault
                    End If

                    objRadioButton.Checked = (objRadioButton.ID = ("rbPlayMethod" & W_PayMethod.Trim.ToUpper))

                    '-----------------------------------------------------
                    objRadioButton.Enabled = True

                ElseIf fromEditMode = EditMode_Enum.查詢 Then
                    objRadioButton.Enabled = False
                End If

            Case TypeOf fromControl Is DropDownList
                objDropDownList = CType(fromControl, DropDownList)

                If fromEditMode = EditMode_Enum.初始化 Then
                    objDropDownList.Enabled = True
                    objDropDownList.SelectedIndex = -1
                Else
                    Select Case fromEditMode
                        Case EditMode_Enum.新增, EditMode_Enum.查詢
                            objDropDownList.Enabled = False
                        Case Else
                            objDropDownList.Enabled = True
                    End Select

                End If

            Case TypeOf fromControl Is Button
                objButton = CType(fromControl, Button)

                If fromEditMode = EditMode_Enum.初始化 Then
                    objButton.Enabled = True
                Else

                    objButton.Enabled = (fromEditMode = EditMode_Enum.新增)

                    'If objButton.Enabled = False _
                    '     AndAlso (objButton.ID.Substring(0, 1).Equals(C_SystemChar)) Then
                    '    objButton.Enabled = True
                    'End If
                End If

            Case TypeOf fromControl Is TextBox
                objTextBox = CType(fromControl, TextBox)

                If objTextBox.ID.IndexOf(C_idtextBox2) >= 0 Then
                    objTextBox.Style.Add("text-align", "right")
                End If

                If fromEditMode = EditMode_Enum.初始化 Then
                    objTextBox.Enabled = True
                    objTextBox.BackColor = C_RGBColorUNLock
                    objTextBox.Text = ""
                Else

                    objTextBox.Enabled = (fromEditMode = EditMode_Enum.新增)

                    If objTextBox.Enabled = True _
                         AndAlso (objTextBox.ID.Substring(0, 1).Equals(C_SystemChar)) Then
                        objTextBox.Enabled = False
                    End If

                    objTextBox.BackColor = IIf(objTextBox.Enabled = True, C_RGBColorUNLock, C_RGBColorLock)
                    objTextBox.ForeColor = IIf(objTextBox.Enabled = True, C_RGBTextColorUnLock, C_RGBTextColorLock)

                    objTextBox.ReadOnly = Not (objTextBox.Enabled)
                    objTextBox.Text = IIf(objTextBox.Enabled = True, "", objTextBox.Text)

                    objTextBox.Enabled = True
                End If

            Case TypeOf fromControl Is HtmlTable
                objHtmlTable = CType(fromControl, HtmlTable)

                If fromEditMode = EditMode_Enum.初始化 AndAlso _
                          objHtmlTable.ID = "tableEdit2" Then
                    Do Until (objHtmlTable.Rows.Count - 1) <= C_TableEdit2_Row
                        objHtmlTable.Rows.RemoveAt(objHtmlTable.Rows.Count - 1)
                    Loop
                End If


                For Each eachRow As HtmlTableRow In objHtmlTable.Rows
                    P_LockAndRefreshController(fromEditMode, eachRow)
                Next

            Case TypeOf fromControl Is HtmlTableRow
                objHtmlTableRow = CType(fromControl, HtmlTableRow)

                For Each eachCell As HtmlTableCell In objHtmlTableRow.Cells
                    P_LockAndRefreshController(fromEditMode, eachCell)
                Next

            Case TypeOf fromControl Is HtmlTableCell
                objHtmlTableCell = CType(fromControl, HtmlTableCell)

                For Each eachControl As Control In objHtmlTableCell.Controls
                    P_LockAndRefreshController(fromEditMode, eachControl)
                Next

            Case fromControl.Controls.Count > 0
                For Each eachControl As Control In fromControl.Controls
                    P_LockAndRefreshController(fromEditMode, eachControl)
                Next

            Case Else


        End Select


    End Sub

#End Region

#Region "Property"
    Private C_WP_btSystemNote_Click As String = "C_btSystemNote_Click"
    Private Property WP_btSystemNote_Click As String
        Get
            If ViewState(C_WP_btSystemNote_Click) Is Nothing Then
                Return ""
            End If
            Return ViewState(C_WP_btSystemNote_Click)
        End Get
        Set(value As String)
            ViewState(C_WP_btSystemNote_Click) = value
        End Set
    End Property
#End Region

#Region "P_Init"
    Private Sub P_Init()
        P_LockAndRefreshController(EditMode_Enum.初始化)
        P_reFresh_SystemNote_Invoice_Status()

        MultiView1.SetActiveView(View1)

        Me.hfTableRowCount.Value = tableEdit2.Rows.Count - 1
        WP_ListData = New List(Of ListDataType)

    End Sub
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

#Region "Dynamic HtmlTabl"

    Private Function getRequestIndex(ByVal fromControlID As String) As Integer

        Dim W_Index As Integer
        For Each eachItem As String In Request.Form.AllKeys

            For Each eachSplit As String In eachItem.Split("$")
                If eachSplit.Equals(fromControlID) Then
                    Return W_Index
                End If
            Next

            W_Index += 1
        Next

        Return -1
    End Function

    Private Function getListDataIndex(ByVal fromControlID As String) As Integer
        Return (From A As ListDataType In WP_ListData Where A.Key.Equals(fromControlID) Select A.Index).FirstOrDefault
    End Function

    Private Function getListDataControl(ByVal fromControlID As String) As String
        Return (From A As ListDataType In WP_ListData Where A.Key.Equals(fromControlID) Select A.Value).FirstOrDefault
    End Function

    Private Sub updateListDataControl(ByVal fromControlID As String, ByVal fromNewValue As String)
        Dim objListDataType As ListDataType = (From A As ListDataType In WP_ListData Where A.Key.Equals(fromControlID) Select A).First

        objListDataType.Value = fromNewValue

    End Sub

    Private Function getRequestControl(ByVal fromControlID As String) As String
        Dim W_Index As Integer = getRequestIndex(fromControlID)
        Dim retRequest As String = ""

        If W_Index > -1 Then
            retRequest = Request.Form(W_Index)

            If getListDataIndex(fromControlID) = 0 Then
                WP_ListData.Add(New ListDataType(fromControlID, retRequest, WP_ListData.Count))

            Else
                updateListDataControl(fromControlID, retRequest)
            End If

            Return retRequest

        Else
            If getListDataIndex(fromControlID) > 0 Then
                Return getListDataControl(fromControlID)
            End If
        End If

        Return ""
    End Function



    Protected Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        P_TableEdit2_Rebuild()
        P_TableEdit2_AddRow()
    End Sub

    Private Sub P_TableEdit2_Rebuild()
        P_TableEdit2_Do(TableEdit2_Mode.Rebuild)
    End Sub

    Private Sub P_TableEdit2_AddRow()
        P_TableEdit2_Do(TableEdit2_Mode.AddNewRow)
    End Sub

    Private Sub P_TableEdit2_ReFreshData()
        P_TableEdit2_Do(TableEdit2_Mode.ReFreshData)
    End Sub

    Enum TableEdit2_Mode
        Rebuild = 1
        AddNewRow = 2
        ReFreshData = 3
    End Enum

    Protected Sub P_TableEdit2_Do(ByVal fromDoMode As TableEdit2_Mode)

        Dim tableEdit As HtmlTable = Me.FindControl("tableEdit2")
        Dim tableRowIndex As Integer = tableEdit2.Rows.Count - 1
        Dim hfRowIndex As Integer = Me.hfTableRowCount.Value

        If fromDoMode = TableEdit2_Mode.Rebuild Then
            If tableRowIndex >= hfRowIndex Then
                Exit Sub
            End If
        End If

        Dim W_Control_Index As Integer

        Dim row As HtmlTableRow : row = tableEdit2.Rows(tableRowIndex)
        Dim cell1 As HtmlTableCell, cell2 As HtmlTableCell, cell3 As HtmlTableCell
        Dim objButton As Button, widthButton As Double = CType(row.FindControl(C_idbtnSystemNote & tableRowIndex), Button).Width.Value
        Dim objLabel1 As Label


        'Dim objTextBox1_New As TextBox, widthtextBox1 As Double = CType(row.FindControl(C_idtextBox1 & tableRowIndex), TextBox).Width.Value
        'Dim objTextBox2_New As TextBox, widthtextBox2 As Double = CType(row.FindControl(C_idtextBox2 & tableRowIndex), TextBox).Width.Value
        'Dim objTextBox3_New As TextBox, widthtextBox3 As Double = CType(row.FindControl(C_idtextBox3 & tableRowIndex), TextBox).Width.Value

        Dim objTextBox1_New As TextBox, objTextBox1_Sample As TextBox = CType(row.FindControl(C_idtextBox1 & tableRowIndex), TextBox)
        Dim objTextBox2_New As TextBox, objTextBox2_Sample As TextBox = CType(row.FindControl(C_idtextBox2 & tableRowIndex), TextBox)
        Dim objTextBox3_New As TextBox, objTextBox3_Sample As TextBox = CType(row.FindControl(C_idtextBox3 & tableRowIndex), TextBox)

        Dim II As Integer, II_Start As Integer, II_End As Integer, JJ As Integer


        Select Case fromDoMode
            Case TableEdit2_Mode.AddNewRow
                II_Start = (tableRowIndex + 1)
                II_End = (hfRowIndex + C_TableEdit2_Row)

            Case TableEdit2_Mode.Rebuild
                II_Start = (tableRowIndex + 1)
                II_End = hfRowIndex

            Case TableEdit2_Mode.ReFreshData
                II_Start = 1
                II_End = hfRowIndex
        End Select

        For II = II_Start To II_End
            W_Control_Index = II

            objButton = New Button : objButton.ID = C_idbtnSystemNote & W_Control_Index : objButton.Width = Unit.Percentage(widthButton) : objButton.Text = "片語"
            objButton.Attributes.Add("runat", "server")
            AddHandler objButton.Click, AddressOf btSystemNote_Click

            objLabel1 = New Label : objLabel1.Text = "&nbsp&nbsp"
            objTextBox1_New = New TextBox : objTextBox1_New.ID = C_idtextBox1 & W_Control_Index : objTextBox1_New.Width = Unit.Percentage(objTextBox1_Sample.Width.Value)
            objTextBox2_New = New TextBox : objTextBox2_New.ID = C_idtextBox2 & W_Control_Index : objTextBox2_New.Width = Unit.Percentage(objTextBox2_Sample.Width.Value)
            objTextBox3_New = New TextBox : objTextBox3_New.ID = C_idtextBox3 & W_Control_Index : objTextBox3_New.Width = Unit.Percentage(objTextBox3_Sample.Width.Value)

            For Each eachKey As String In objTextBox2_Sample.Style.Keys
                objTextBox2_New.Style.Add(eachKey, objTextBox2_Sample.Style.Item(eachKey))
            Next

            If fromDoMode = TableEdit2_Mode.Rebuild Then
                objTextBox1_New.Text = getRequestControl(C_idtextBox1 & W_Control_Index)
                objTextBox2_New.Text = getRequestControl(C_idtextBox2 & W_Control_Index)
                objTextBox3_New.Text = getRequestControl(C_idtextBox3 & W_Control_Index)

            ElseIf fromDoMode = TableEdit2_Mode.ReFreshData Then
                getRequestControl(C_idtextBox1 & W_Control_Index)
                getRequestControl(C_idtextBox2 & W_Control_Index)
                getRequestControl(C_idtextBox3 & W_Control_Index)
            End If

            If fromDoMode <> TableEdit2_Mode.ReFreshData Then
                cell1 = New HtmlTableCell : cell1.Controls.Add(objButton) : cell1.Controls.Add(objLabel1) : cell1.Controls.Add(objTextBox1_New)
                cell2 = New HtmlTableCell : cell2.Controls.Add(objTextBox2_New)
                cell3 = New HtmlTableCell : cell3.Controls.Add(objTextBox3_New)

                cell1.Attributes.Add("class", row.Cells(0).Attributes.Item("class"))
                cell2.Attributes.Add("class", row.Cells(1).Attributes.Item("class"))
                cell3.Attributes.Add("class", row.Cells(2).Attributes.Item("class"))

                row = New HtmlTableRow : row.Cells.Add(cell1) : row.Cells.Add(cell2) : row.Cells.Add(cell3)
                tableEdit.Rows.Add(row)
            End If

        Next

        If fromDoMode = TableEdit2_Mode.AddNewRow Then
            Me.hfTableRowCount.Value = W_Control_Index
        End If

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            P_Init()

        Else
            P_TableEdit2_Rebuild()
        End If

    End Sub


#Region "View2"

    Protected Sub btSystemNote_Submit_Click(sender As Object, e As EventArgs) Handles btSystemNote_Submit.Click
        Dim txtItemObj As TextBox, txtMemoObj As TextBox
        Dim W_Index As String = WP_btSystemNote_Click.Replace(C_idbtnSystemNote, "")

        txtItemObj = Me.FindControl(C_idtextBox1 & W_Index)
        txtMemoObj = Me.FindControl(C_idtextBox3 & W_Index)

        txtItemObj.Text &= (IIf(txtItemObj.Text = "", "", "；"))
        txtMemoObj.Text &= (IIf(txtMemoObj.Text = "", "", "；"))

        txtItemObj.Text &= ddItem.SelectedValue
        txtMemoObj.Text &= ddMemo.SelectedValue

        MultiView1.SetActiveView(View1)

    End Sub


    Protected Sub btSystemNote_Cancel_Click(sender As Object, e As EventArgs) Handles btSystemNote_Cancel.Click
        MultiView1.SetActiveView(View1)
    End Sub
#End Region

    Protected Sub btSystemNote_Click(sender As Object, e As EventArgs) _
              Handles btSystemNote1.Click, btSystemNote2.Click _
                             , btSystemNote3.Click, btSystemNote4.Click _
                             , btSystemNote5.Click

        P_TableEdit2_ReFreshData()

        WP_btSystemNote_Click = (CType(sender, Button).ID)

        P_reFresh_SystemNote_Item()
        P_reFresh_SystemNote_Memo()
        MultiView1.SetActiveView(View2)
    End Sub


#Region "SystemNote"
    Private Sub P_reFresh_SystemNote_Invoice_Status()
        Dim queryDataTable1 As DataTable

        queryDataTable1 = WP_ClsSystemNote.getLev3(C_SYSTEM_TYPE, "_單據狀態")

        WP_ClsSystemNote.setDropDownList(ddInvoice_Status, queryDataTable1, WP_ClsSystemNote.Display_Lable)
        ddInvoice_Status.SelectedIndex = -1
    End Sub

    Private Sub P_reFresh_SystemNote_Item()
        Dim queryDataTable1 As DataTable, queryDataTable2 As DataTable

        queryDataTable1 = WP_ClsSystemNote.getLev2(C_SYSTEM_TYPE)
        queryDataTable2 = (From A In queryDataTable1 _
                                               Where Not CType(A.Item(WP_ClsSystemNote.NOTE_TYPE), String).Substring(0, 1).Equals("_") _
                                               Select A).CopyToDataTable

        WP_ClsSystemNote.setDropDownList(ddItem, queryDataTable2)
    End Sub

    Private Sub P_reFresh_SystemNote_Memo()
        Dim queryDataTable1 As DataTable

        queryDataTable1 = WP_ClsSystemNote.getLev3(C_SYSTEM_TYPE, ddItem.SelectedValue)

        WP_ClsSystemNote.setDropDownList(ddMemo, queryDataTable1, WP_ClsSystemNote.NOTE_ID)
    End Sub

    Protected Sub ddItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddItem.TextChanged
        P_reFresh_SystemNote_Memo()
    End Sub
#End Region



#Region "讀取單據資料：P_LoadDataByInvoice_Number"
    Private Sub P_LoadDataByInvoice_Number(ByVal from單據號碼1 As String, ByVal from單據號碼2 As String)
        Dim crudList_Master As List(Of CompanyORMDB.COME.KIND01PF) = Nothing
        Dim crudList_Detail As List(Of CompanyORMDB.COME.KIND02PF) = Nothing
        Dim crudMaster As CompanyORMDB.COME.KIND01PF = Nothing
        Dim crudDetail As CompanyORMDB.COME.KIND02PF = Nothing


        CustomValidator1.ErrorMessage = ""
        Dim W_SQL As New StringBuilder
        Try

            Dim W_付款方式 As String = ""

            'Master
            '-------------------------------------------------------------------------------------
            W_SQL.Append("SELECT  * " & vbNewLine)
            W_SQL.Append("FROM @#COME.KIND01PF " & vbNewLine)
            W_SQL.Append("WHERE 1=1  AND KD101='" & from單據號碼1 & "' " & vbNewLine)
            W_SQL.Append("    AND KD102 =" & from單據號碼2 & " " & vbNewLine)

            crudList_Master = COME.KIND01PF.CDBSelect(Of COME.KIND01PF)(W_SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            If crudList_Master.Count > 0 Then
                crudMaster = crudList_Master.Item(0)

                With crudMaster
                    Me._tbKeyIn_Operator.Text = .KD103 & Space(1) & showEmployeeName(WP_DataTable_Employee, .KD103)
                    Me._tbKeyIn_Unit.Text = .KD104 & Space(1) & showUnitName(WP_DataTable_Unit, .KD104)
                    Me._tbKeyIn_Date.Text = InvoiceOfReceivables_Model.showFormatFor_DateTime(False, .KD105, .KD106)

                    Me._tbInvoice_Operator.Text = .KD107 & Space(1) & showEmployeeName(WP_DataTable_Employee, .KD107)
                    Me._tbInvoice_Unit.Text = .KD108 & Space(1) & showUnitName(WP_DataTable_Unit, .KD108)
                    Me._tbInvoice_Date.Text = InvoiceOfReceivables_Model.showFormatFor_DateTime(False, .KD109, .KD110)

                    Me._tbAmount0.Text = ModTools.showInfoForMoney(.KD111)
                    ModTools.SelectedIndexByText(Me.ddInvoice_Status, .KD112)


                    rbPlayMethodA.Checked = False
                    rbPlayMethodB.Checked = False
                    rbPlayMethodC.Checked = False
                    rbPlayMethodD.Checked = False
                    rbPlayMethodE.Checked = False
                    rbPlayMethodF.Checked = False
                    W_付款方式 = .KD113
                    Select Case W_付款方式
                        Case "A"        '支票
                            Me.rbPlayMethodA.Checked = True
                            Me.tbrbPlayMethod_A_1.Text = .KD114
                            Me.tbrbPlayMethod_A_2.Text = .KD115

                        Case "B"        '現金
                            Me.rbPlayMethodB.Checked = True

                        Case "C"        '匯台銀鼓山
                            Me.rbPlayMethodC.Checked = True

                        Case "D"        '其他
                            Me.rbPlayMethodD.Checked = True
                            Me.tbrbPlayMethod_D_1.Text = .KD114

                        Case "E"        '定存單
                            Me.rbPlayMethodE.Checked = True
                            Me.tbrbPlayMethod_E_1.Text = .KD114
                            Me.tbrbPlayMethod_E_2.Text = .KD115

                        Case "F"        '保證函
                            Me.rbPlayMethodF.Checked = True
                            Me.tbrbPlayMethod_F_1.Text = .KD114
                            Me.tbrbPlayMethod_F_2.Text = .KD115
                    End Select

                    Me.tbPurchase_Number.Text = .KD116

                End With

            End If


            'Detail
            '-------------------------------------------------------------------------------------
            W_SQL = New StringBuilder
            W_SQL.Append("SELECT  * " & vbNewLine)
            W_SQL.Append("FROM @#COME.KIND02PF " & vbNewLine)
            W_SQL.Append("WHERE 1=1  AND KD201='" & from單據號碼1 & "' " & vbNewLine)
            W_SQL.Append("    AND KD202 =" & from單據號碼2 & " " & vbNewLine)
            W_SQL.Append("ORDER BY KD203 " & vbNewLine)

            crudList_Detail = COME.KIND02PF.CDBSelect(Of COME.KIND02PF)(W_SQL.ToString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            Dim tbItemObj As TextBox, tbAmountObj As TextBox
            Dim tbMemoObj As TextBox


            '---------------------------------------
            Do Until WP_項目數量_目前() >= crudList_Detail.Count
                P_TableEdit2_AddRow()
            Loop
            '---------------------------------------

            For II = 1 To crudList_Detail.Count
                tbItemObj = CType(Me.FindControl(C_idtextBox1 & II), TextBox)
                tbAmountObj = CType(Me.FindControl(C_idtextBox2 & II), TextBox)
                tbMemoObj = CType(Me.FindControl(C_idtextBox3 & II), TextBox)

                crudDetail = crudList_Detail.Item(II - 1)
                With crudDetail
                    tbAmountObj.Text = ModTools.showInfoForMoney(.KD204)
                    tbItemObj.Text = .KD205
                    tbMemoObj.Text = .KD206
                End With
            Next II
            '-------------------------------------------------------------------------------------


        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        End Try

        'CustomValidator1.IsValid = String.IsNullOrEmpty(CustomValidator1.ErrorMessage)
    End Sub


#End Region


#Region "SaveData"
    Private Function FB_CustomValidator1() As Boolean

        Dim alertMsg As New List(Of String)
        CustomValidator1.ErrorMessage = ""

        Dim tbItemObj As TextBox, tbAmountObj As TextBox
        Dim II As Integer
        For II = 1 To WP_項目數量_目前()
            tbItemObj = CType(Me.FindControl(C_idtextBox1 & II), TextBox)
            tbAmountObj = CType(Me.FindControl(C_idtextBox2 & II), TextBox)


            If tbItemObj.Text <> "" AndAlso _
                 IsNumeric(tbAmountObj.Text) = False Then
                alertMsg.Add("項次" & II & ": 金額錯誤")
            End If

            If tbAmountObj.Text <> "" Then
                If IsNumeric(tbAmountObj.Text) = False Then alertMsg.Add("項次" & II & ": 金額錯誤")
                If tbItemObj.Text = "" Then alertMsg.Add("項次" & II & ": 摘要未輸入")
            End If

        Next


        Dim playMoney As Long = 0
        Dim keyInData As String = ""
        For II = 1 To WP_項目數量_目前()
            tbItemObj = CType(Me.FindControl(C_idtextBox1 & II), TextBox)
            tbAmountObj = CType(Me.FindControl(C_idtextBox2 & II), TextBox)

            keyInData &= tbItemObj.Text.Trim & tbAmountObj.Text.Trim
            If IsNumeric(tbAmountObj.Text) = True Then
                playMoney += Double.Parse(tbAmountObj.Text)
            End If
        Next
        _tbAmount0.Text = playMoney

        If keyInData = "" Then
            alertMsg.Add("最少需輸入一筆摘要與金額")
        End If

        If rbPlayMethodA.Checked = True Then
            If tbrbPlayMethod_A_1.Text = "" Then alertMsg.Add("未輸入: [支票]號碼")
            If tbrbPlayMethod_A_2.Text = "" Then alertMsg.Add("未輸入: [支票]付款行")
        End If

        If rbPlayMethodD.Checked = True Then
            If tbrbPlayMethod_D_1.Text = "" Then alertMsg.Add("未輸入: [其他]說明")
        End If

        If rbPlayMethodE.Checked = True Then
            If tbrbPlayMethod_E_1.Text = "" Then alertMsg.Add("未輸入: [定存單]票號")
            If tbrbPlayMethod_E_2.Text = "" Then alertMsg.Add("未輸入: [定存單]銀行")
        End If

        If rbPlayMethodF.Checked = True Then
            If tbrbPlayMethod_F_1.Text = "" Then alertMsg.Add("未輸入: [保證函]票號")
            If tbrbPlayMethod_F_2.Text = "" Then alertMsg.Add("未輸入: [保證函]銀行")
        End If
        CustomValidator1.ErrorMessage = String.Join("<br/>", alertMsg.ToArray)

        CustomValidator1.IsValid = String.IsNullOrEmpty(CustomValidator1.ErrorMessage)
        Return (CustomValidator1.IsValid)
    End Function

    Protected Sub btSubmit_Click(sender As Object, e As EventArgs) Handles _btData_Submit.Click

        '資料驗證
        '-------------------------------------------------------------------------------------
        If FB_CustomValidator1() = False Then
            Exit Sub
        End If
        '-------------------------------------------------------------------------------------

        CustomValidator1.ErrorMessage = ""
        '單據號碼
        '-------------------------------------------------------------------------------------
        If Me._tbInvoice_Number.Text = "" Then Me._tbInvoice_Number.Text = Fs_GetNewInvoice_Number()
        Dim W_單據號碼1 As String = "", W_單據號碼2 As String = ""
        If _tbInvoice_Number.Text.Length >= 2 Then
            W_單據號碼1 = _tbInvoice_Number.Text.Substring(0, 2)
        End If
        If _tbInvoice_Number.Text.Length >= 3 Then
            W_單據號碼2 = _tbInvoice_Number.Text.Substring(2)
        End If

        Dim crudStatus As Integer = 0
        Dim crudMaster As CompanyORMDB.COME.KIND01PF = Nothing
        Dim crudDetail As CompanyORMDB.COME.KIND02PF = Nothing

        Try
            '準備資料
            '-------------------------------------------------------------------------------------
            Me._tbInvoice_Unit.Text = Me._hfInvoice_Unit.Value
            Me._tbInvoice_Operator.Text = Me._hfInvoice_Operator.Value


            Dim W_Now As Date = Now
            Dim W_輸入日期 As Integer, W_輸入時間 As Integer

            WP_AS400DateConverter.DateValue = W_Now
            W_輸入日期 = WP_AS400DateConverter.TwSevenCharsTypeData
            W_輸入時間 = W_Now.ToString("HHMMss")
            Me._tbKeyIn_Date.Text = W_輸入日期 & Space(1) & W_輸入時間

            Dim W_付款方式 As String = ""
            Select Case True
                Case Me.rbPlayMethodA.Checked
                    W_付款方式 = "A"
                Case Me.rbPlayMethodB.Checked
                    W_付款方式 = "B"
                Case Me.rbPlayMethodC.Checked
                    W_付款方式 = "C"
                Case Me.rbPlayMethodD.Checked
                    W_付款方式 = "D"
                Case Me.rbPlayMethodE.Checked
                    W_付款方式 = "E"
                Case Me.rbPlayMethodF.Checked
                    W_付款方式 = "F"
            End Select


            '寫入資料庫 - Master
            '-------------------------------------------------------------------------------------
            crudStatus = 1
            crudMaster = New COME.KIND01PF()
            crudMaster.SQLQueryAdapterByThisObject = WP_AS400Adapter
            With crudMaster
                .KD101 = W_單據號碼1
                .KD102 = W_單據號碼2
                .KD103 = Me._tbKeyIn_Operator.Text
                .KD104 = Me._tbKeyIn_Unit.Text
                .KD105 = W_輸入日期
                .KD106 = W_輸入時間
                .KD111 = Me._tbAmount0.Text
                .KD112 = "C"    '新增後固定  查詢 :C
                .KD113 = W_付款方式

                Select Case W_付款方式
                    Case "A"        '支票
                        .KD114 = Me.tbrbPlayMethod_A_1.Text
                        .KD115 = Me.tbrbPlayMethod_A_2.Text

                    Case "D"        '其他
                        .KD114 = Me.tbrbPlayMethod_D_1.Text

                    Case "E"        '定存單
                        .KD114 = Me.tbrbPlayMethod_E_1.Text
                        .KD115 = Me.tbrbPlayMethod_E_2.Text

                    Case "F"        '保證函
                        .KD114 = Me.tbrbPlayMethod_F_1.Text
                        .KD115 = Me.tbrbPlayMethod_F_2.Text
                End Select
                .KD116 = Me.tbPurchase_Number.Text

            End With

            crudMaster.CDBInsert()

            '寫入資料庫 - Detail
            '-------------------------------------------------------------------------------------
            crudStatus = 2

            Dim tbItemObj As TextBox, tbAmountObj As TextBox
            Dim tbMemoObj As TextBox
            Dim W_Index As Integer
            For II = 1 To WP_項目數量_目前()
                tbItemObj = CType(Me.FindControl(C_idtextBox1 & II), TextBox)
                tbAmountObj = CType(Me.FindControl(C_idtextBox2 & II), TextBox)
                tbMemoObj = CType(Me.FindControl(C_idtextBox3 & II), TextBox)

                If tbItemObj.Text = "" Then Continue For
                W_Index += 1
                crudDetail = New COME.KIND02PF
                With crudDetail
                    .KD201 = W_單據號碼1
                    .KD202 = W_單據號碼2
                    .KD203 = W_Index
                    .KD204 = tbAmountObj.Text
                    .KD205 = tbItemObj.Text
                    .KD206 = tbMemoObj.Text
                End With

                crudDetail.SQLQueryAdapterByThisObject = WP_AS400Adapter
                crudDetail.CDBInsert()
            Next


            '-------------------------------------------------------------------------------------

            '畫面更新
            '-------------------------------------------------------------------------------------

            RaiseEvent Event_reFresh父物件(主畫面_Enum.查詢, W_單據號碼1, W_單據號碼2)


        Catch ex As Exception
            CustomValidator1.ErrorMessage = "存檔失敗: " & ex.Message
            'CustomValidator1.IsValid = False

            Me._tbKeyIn_Date.Text = ""
            If crudStatus >= 1 Then
                crudMaster.SQLQueryAdapterByThisObject = WP_AS400Adapter
                crudMaster.CDBDelete()
            End If

            If crudStatus >= 2 Then
                Dim W_DeleteSQL_Detail As String
                W_DeleteSQL_Detail = "DELETE FROM @#COME.KIND02PF WHERE 1=1 "
                W_DeleteSQL_Detail &= " AND kd201='" & crudMaster.KD101 & "'  "
                W_DeleteSQL_Detail &= " AND kd202=" & crudMaster.KD102

                WP_AS400Adapter.ExecuteNonQuery(W_DeleteSQL_Detail)
            End If

        End Try

        CustomValidator1.IsValid = String.IsNullOrEmpty(CustomValidator1.ErrorMessage)

    End Sub


    Private Function Fs_GetNewInvoice_Number() As String
        Dim W_SQL As New StringBuilder
        Dim W_單據號碼1 As String = "", W_單據號碼2 As Long

        W_單據號碼1 = "H1"
        W_單據號碼2 = Integer.Parse(Now.ToString("yyyy").Substring(2, 2) _
                                                              & "00000")


        W_SQL.Append("SELECT  IFNULL(MAX(kd102) ," & W_單據號碼2 & ")   kd102_max " & vbNewLine)
        W_SQL.Append("FROM @#COME.KIND01PF " & vbNewLine)
        W_SQL.Append("WHERE 1=1  AND KD101='" & W_單據號碼1 & "' " & vbNewLine)
        W_SQL.Append("    AND KD102 >=" & W_單據號碼2 & " " & vbNewLine)

        W_單據號碼2 = Long.Parse(WP_AS400Adapter.SelectQuery(W_SQL.ToString).Rows(0).Item(0))
        W_單據號碼2 += 1

        Return W_單據號碼1 & String.Format("{0:0000000}", W_單據號碼2)
    End Function


#End Region


    Protected Sub _btData_Cancel_Click(sender As Object, e As EventArgs) Handles _btData_Cancel.Click
        Exit Sub

        P_LockAndRefreshController(EditMode_Enum.新增)
    End Sub



End Class