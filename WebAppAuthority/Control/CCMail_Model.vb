Imports CompanyORMDB
Imports System.Xml
Imports UCAjaxServerControl1
Imports PublicClassLibrary

Public Module CCMail_Model
    Public Enum 主畫面_Enum
        查詢 = 0
        編修 = 1
        列印 = 2
    End Enum

    Public Enum EditMode_Enum
        初始化 = 0
        新增 = 1
        編輯 = 2
        查詢 = 3
    End Enum
    Private WP_SYSNOTE As New PublicClassLibrary.ClsSystemNote
    Private WP_AS400Adapter As New AS400SQLQueryAdapter

    Public C_SystemChar As String = "_"
    Public C_RGBTextColorLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#2B2B2B")
    Public C_RGBTextColorUnLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#000000")
    Public C_RGBColorLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#CCCCCC")
    Public C_RGBColorUNLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF")
    Public C_Status_LOGIN As String = "LOGIN"
    Public C_Status_BACK As String = "BACK"

#Region "伺服器環境"
    Public S_CCMailIP As String = WP_SYSNOTE.getLev4Content("CCMail", "系統資訊", "IP")
    Public S_CCMail_API_Interface As String = WP_SYSNOTE.getLev4Content("CCMail", "系統資訊", "API_Interface")
    Public S_CCMail_API_URL As String = "http://" & S_CCMailIP & S_CCMail_API_Interface
    Public S_CCMail_API_Key As String = WP_SYSNOTE.getLev4Content("CCMail", "系統資訊", "API_Key")
    Public S_CCMail_Default_Password As String = WP_SYSNOTE.getLev4Content("CCMail", "系統資訊", "Default_Password")
    Public S_CCMail_ReportEmailAdd() As String = WP_SYSNOTE.getLev4Content("CCMail", "系統資訊", "ReportEmail").Split(";")

#End Region

#Region "資料庫欄位"
    Public dc_uid As String = "uid_XML"
    Public dc_password As String = "password_XML"
    Public dc_kind As String = "kind"
    Public dc_email As String = "email_XML"
    Public dc_empNum As String = "employeeNum_XML"
    Public dc_cn As String = "cn_XML"
    Public dc_o As String = "o_XML"
    Public dc_orgid As String = "orgId_XML"
    Public dc_parentOrgId As String = "parentOrgId_XML"
    Public dc_displayName As String = "displayName_XML"
    Public dc_deptCode As String = "deptCode"
    Public dc_deptName As String = "deptName"
    Public dc_status As String = "status"
    Public dc_sequence As String = "sequence_XML"
    Public dc_modiDate As String = "modiDate"
    Public dc_excuteDate As String = "executeDate"
    Public DeleteBufferDay As Int32 = 30
#End Region

#Region "成功代碼"
    Public S_uccess_code() As String = {"2001", "2002", "2003"}
#End Region

    

#Region "FD_Data_Employee"


    Public Function FD_Data_Employee_Now() As DataTable
        Dim queryEEE As Integer = Integer.Parse(Now.ToString("yyyy")) - 1911
        Dim queryMM As Integer = Integer.Parse(Now.ToString("MM"))

        Return FD_Data_Employee(queryEEE, queryMM)
    End Function

    Public Function FD_Data_Employee(ByVal fromEEE As Integer, ByVal fromMM As Integer) As DataTable
        Dim sql As New StringBuilder
        sql.Append("SELECT qd100e, qd100a, qd100c " & vbNewLine)
        sql.Append("FROM @#PLT000LB.PQDM01L3 " & vbNewLine)
        sql.Append("WHERE 1=1 " & vbNewLine)
        sql.Append("  and qd100i= " & fromEEE & vbNewLine)
        sql.Append("  and qd100j= " & fromMM & vbNewLine)

        Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(sql.ToString)
        Return queryDataTable
    End Function

#End Region

#Region "Excute_CCMail_PWD"
    Public Function Excute_CCMail_PWD(ByVal uid As String, ByVal pwd As String, ByVal excutePeople As String, ByVal IP As String) As String
        Dim result As String = ""
        Dim resultXML As String = ""
        Dim web As New System.Net.WebClient()
        web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        Dim xml As New StringBuilder
        xml.Append("<?xml version=""1.0"" encoding=""UTF-8""?> " & vbNewLine)
        xml.Append("<oa-cmcc> " & vbNewLine)
        xml.Append("  <apikey>" & S_CCMail_API_Key & "</apikey> " & vbNewLine)
        xml.Append("  <userInfos> " & vbNewLine)
        xml.Append("    <userItem> " & vbNewLine)
        xml.Append("      <uid>" & uid & "</uid> " & vbNewLine)
        xml.Append("      <newPwd>" & pwd & "</newPwd> " & vbNewLine)
        xml.Append("      <flag>modify</flag> " & vbNewLine)
        xml.Append("    </userItem> " & vbNewLine)
        xml.Append("  </userInfos> " & vbNewLine)
        xml.Append("</oa-cmcc> " & vbNewLine)


        Dim ExcuteUtil As New WebServiceUtils(WebServiceUtils.Enum_VerKind.B_CCMail_PHP, S_CCMail_API_URL, WebServiceUtils._WebServerMethod_B, xml.ToString)
        resultXML = ExcuteUtil.GetQueryString
        write_PWD_log(uid, pwd, excutePeople, IP, DecodeXML(resultXML, "response"))
       
        Return resultXML
    End Function
#End Region

#Region "Excute_CCMail_CreateUser"
    Public Function Excute_CCMail_CreateUser(ByVal userObj As SQLServer.MIS.CCmail_Users) As String
        Dim result As String = ""
        Dim resultXML As String = ""
        Dim web As New System.Net.WebClient()
        web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        Dim xml As New StringBuilder
        xml.Append("<?xml version=""1.0"" encoding=""UTF-8""?>" & vbNewLine)
        xml.Append("<oa-cmcc>" & vbNewLine)
        xml.Append("    <apikey>" & S_CCMail_API_Key & "</apikey>" & vbNewLine)
        xml.Append("    <userInfos>" & vbNewLine)
        xml.Append("        <userItem>" & vbNewLine)
        xml.Append("            <uid>" & userObj.uid_XML & "</uid>" & vbNewLine)
        xml.Append("            <cn>" & userObj.cn_XML & "</cn>" & vbNewLine)
        xml.Append("            <password>" & userObj.password_XML & "</password>" & vbNewLine)
        xml.Append("            <employeeNum>" & userObj.employeeNum_XML & "</employeeNum>" & vbNewLine)
        xml.Append("            <email>" & userObj.email_XML & "</email>" & vbNewLine)
        xml.Append("            <sequence>" & userObj.sequence_XML & "</sequence>" & vbNewLine)
        xml.Append("            <level>01</level>" & vbNewLine)
        xml.Append("            <org>" & vbNewLine)
        xml.Append("                <o>" & userObj.o_XML & "</o>" & vbNewLine)
        xml.Append("            </org>" & vbNewLine)
        xml.Append("            <flag>add</flag>" & vbNewLine)
        xml.Append("        </userItem>" & vbNewLine)
        xml.Append("    </userInfos>" & vbNewLine)
        xml.Append("</oa-cmcc>" & vbNewLine)


        ''=====start log=====
        write_SynchronizeUser_log(userObj, "eS")
        ''=====start Excute=====
        Dim ExcuteUtil As New WebServiceUtils(WebServiceUtils.Enum_VerKind.B_CCMail_PHP, S_CCMail_API_URL, WebServiceUtils._WebServerMethod_B, xml.ToString)
        resultXML = ExcuteUtil.GetQueryString
        Dim status As String = IIf(isExcuteSucess(FS_get_errcode(resultXML.ToString)), "Y", "E")
        ''=====excute log=====
        write_Excute_log(userObj.uid_XML, xml.ToString, resultXML)
        update_SynchronizeUser_table(userObj.uid_XML, status)
        ''=====excute log=====

        result = DecodeXML(resultXML, "response")


        Return resultXML
    End Function
#End Region

#Region "Excute_CCMail_DeleteUser"
    Public Function Excute_CCMail_DeleteUser(ByVal userObj As SQLServer.MIS.CCmail_Users) As String
        Dim result As String = ""
        Dim resultXML As String = ""
        Dim web As New System.Net.WebClient()
        web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        Dim xml As New StringBuilder
        xml.Append("<?xml version=""1.0"" encoding=""UTF-8""?>" & vbNewLine)
        xml.Append("<oa-cmcc>" & vbNewLine)
        xml.Append("    <apikey>" & S_CCMail_API_Key & "</apikey>" & vbNewLine)
        xml.Append("    <userInfos>" & vbNewLine)
        xml.Append("        <userItem>" & vbNewLine)
        xml.Append("            <uid>" & userObj.uid_XML & "</uid>" & vbNewLine)
        xml.Append("        </userItem>" & vbNewLine)
        xml.Append("        <flag>del</flag>" & vbNewLine)
        xml.Append("    </userInfos>" & vbNewLine)
        xml.Append("</oa-cmcc>" & vbNewLine)

        ''=====start log=====
        write_SynchronizeUser_log(userObj, "eS")
        ''=====start log=====
        Dim ExcuteUtil As New WebServiceUtils(WebServiceUtils.Enum_VerKind.B_CCMail_PHP, S_CCMail_API_URL, WebServiceUtils._WebServerMethod_B, xml.ToString)
        resultXML = ExcuteUtil.GetQueryString
        Dim status As String = IIf(isExcuteSucess(FS_get_errcode(resultXML.ToString)), "DEL", "E")
        ''=====excute log=====
        write_Excute_log(userObj.uid_XML, xml.ToString, resultXML)
        update_SynchronizeUser_table(userObj.uid_XML, status)
        ''=====excute log=====

        'result = DecodeXML(resultXML, "response")


        Return resultXML
    End Function
#End Region

#Region "Excute_CCMail_UpdateUser"
    Public Function Excute_CCMail_UpdateUser(ByVal userObj As SQLServer.MIS.CCmail_Users) As String
        Dim result As String = ""
        Dim resultXML As String = ""
        Dim web As New System.Net.WebClient()
        web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        Dim xml As New StringBuilder
        xml.Append("<?xml version=""1.0"" encoding=""UTF-8""?>" & vbNewLine)
        xml.Append("<oa-cmcc>" & vbNewLine)
        xml.Append("    <apikey>" & S_CCMail_API_Key & "</apikey>" & vbNewLine)
        xml.Append("    <userInfos>" & vbNewLine)
        xml.Append("        <userItem>" & vbNewLine)
        xml.Append("        <uid>" & userObj.uid_XML & "</uid>" & vbNewLine)
        xml.Append("        <cn>" & userObj.cn_XML & "</cn>" & vbNewLine)
        xml.Append("        <employeeNum>" & userObj.employeeNum_XML & "</employeeNum>" & vbNewLine)
        xml.Append("        <email>" & userObj.email_XML & "</email>" & vbNewLine)
        xml.Append("        <sequence>" & userObj.sequence_XML & "</sequence>" & vbNewLine)
        xml.Append("        <level>01</level>" & vbNewLine)
        xml.Append("        <org>" & vbNewLine)
        xml.Append("            <o>" & userObj.o_XML & "</o>" & vbNewLine)
        xml.Append("        </org>" & vbNewLine)
        xml.Append("        <flag>modify</flag>" & vbNewLine)
        xml.Append("        </userItem>" & vbNewLine)
        xml.Append("    </userInfos>" & vbNewLine)
        xml.Append("</oa-cmcc>" & vbNewLine)

        ''=====start log=====
        write_SynchronizeUser_log(userObj, "eS")
        ''=====start log=====
        Dim ExcuteUtil As New WebServiceUtils(WebServiceUtils.Enum_VerKind.B_CCMail_PHP, S_CCMail_API_URL, WebServiceUtils._WebServerMethod_B, xml.ToString)
        resultXML = ExcuteUtil.GetQueryString
        Dim status As String = IIf(isExcuteSucess(FS_get_errcode(resultXML.ToString)), "Y", "E")
        ''=====excute log=====
        write_Excute_log(userObj.uid_XML, xml.ToString, resultXML)
        update_SynchronizeUser_table(userObj.uid_XML, status)
        ''=====excute log=====

        'result = DecodeXML(resultXML, "response")
        
        Return resultXML
    End Function
#End Region

#Region "Excute_CCMail_CreateDepartment"
    Public Function Excute_CCMail_CreateDepartment(ByVal departmentObj As SQLServer.MIS.CCmail_Department) As String
        Dim result As String = ""
        Dim resultXML As String = ""
        Dim web As New System.Net.WebClient()
        web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        Dim xml As New StringBuilder
        xml.Append("<?xml version=""1.0"" encoding=""UTF-8""?>" & vbNewLine)
        xml.Append("<email-cmcc>" & vbNewLine)
        xml.Append("    <apikey>" & S_CCMail_API_Key & "</apikey>" & vbNewLine)
        xml.Append("	<orgInfos>" & vbNewLine)
        xml.Append("		<orgItem>" & vbNewLine)
        xml.Append("			<o>" & departmentObj.o_XML & "</o>" & vbNewLine)
        xml.Append("			<parentOrgId>" & departmentObj.parentOrgId_XML & "</parentOrgId>" & vbNewLine)
        xml.Append("			<orgId>" & departmentObj.orgId_XML & "</orgId>" & vbNewLine)
        xml.Append("			<displayName>" & departmentObj.displayName_XML & "</displayName>" & vbNewLine)
        xml.Append("            <sequence>" & departmentObj.sequence_XML & "</sequence>" & vbNewLine)
        xml.Append("		</orgItem>" & vbNewLine)
        xml.Append("		<flag>add</flag>" & vbNewLine)
        xml.Append("	</orgInfos>" & vbNewLine)
        xml.Append("</email-cmcc>" & vbNewLine)


        ''=====start log=====
        write_SynchronizeDepartment_log(departmentObj, "eS")
        ''=====start Excute=====
        Dim ExcuteUtil As New WebServiceUtils(WebServiceUtils.Enum_VerKind.B_CCMail_PHP, S_CCMail_API_URL, WebServiceUtils._WebServerMethod_B, xml.ToString)
        resultXML = ExcuteUtil.GetQueryString
        Dim status As String = IIf(isExcuteSucess(FS_get_errcode(resultXML.ToString)), "Y", "E")
        ''=====excute log=====
        write_Excute_log(departmentObj.o_XML, xml.ToString, resultXML)
        update_SynchronizeDepartment_table(departmentObj.o_XML, status)
        ''=====excute log=====

        result = DecodeXML(resultXML, "response")

        Return resultXML
    End Function
#End Region

#Region "Excute_CCMail_QueryUser"
    Public Function CCMail_User_isExist(ByVal fromUser As String) As Boolean
        Dim result As String = ""
        Dim resultXML As String = ""
        Dim web As New System.Net.WebClient()
        web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        Dim xml As New StringBuilder
        xml.Append("<?xml version=""1.0"" encoding=""UTF-8""?>" & vbNewLine)
        xml.Append("<oa-cmcc>" & vbNewLine)
        xml.Append("    <apikey>" & S_CCMail_API_Key & "</apikey>" & vbNewLine)
        xml.Append("    <userInfos>" & vbNewLine)
        xml.Append("        <userItem>" & vbNewLine)
        xml.Append("            <uid>" & fromUser & "</uid>" & vbNewLine)
        xml.Append("            <flag>query</flag>" & vbNewLine)
        xml.Append("        </userItem>" & vbNewLine)
        xml.Append("    </userInfos>" & vbNewLine)
        xml.Append("</oa-cmcc>" & vbNewLine)
        Dim ExcuteUtil As New WebServiceUtils(WebServiceUtils.Enum_VerKind.B_CCMail_PHP, S_CCMail_API_URL, WebServiceUtils._WebServerMethod_B, xml.ToString)
        resultXML = ExcuteUtil.GetQueryString
        If Not resultXML.Contains("Nonexist account") Then
            Return True
        Else
            Return False
        End If

    End Function

#End Region

#Region "write_PWD_log : 更改密碼Log"
    Private Sub write_PWD_log(ByVal uid As String, ByVal pwd As String, ByVal excutePeople As String, ByVal IP As String, ByVal result As String)

        Dim insertObj As New SQLServer.MIS.CCMail_PWD_Log
        With insertObj
            .uid = uid
            .pwd = ClassBorgSPM.Encrypt(pwd)
            .excuteIP = IP
            .excutePeople = excutePeople
            .excuteResult = result
            .excuteTime = Now
        End With
        insertObj.CDBInsert()
    End Sub

#End Region

#Region "write_Excute_log : 執行結果Log"
    Private Sub write_Excute_log(ByVal fromTarget As String, ByVal fromXML As String, ByVal fromResult As String)
        Dim insertObj As New SQLServer.MIS.CCmail_Excute_Log
        With insertObj
            .Target = fromTarget
            .XML = fromXML
            .Result = fromResult
            .Excute_Date = Now
        End With
        insertObj.CDBInsert()
    End Sub
#End Region

#Region "write_SynchronizeUser_log : 使用者同步歷程Log"
    Private Sub write_SynchronizeUser_log(ByVal userObj As SQLServer.MIS.CCmail_Users, ByVal stage As String)
        Dim insertObj As New SQLServer.MIS.CCmail_Users_Log
        With insertObj
            .uid_XML = userObj.uid_XML
            .kind = userObj.kind
            .password_XML = userObj.password_XML
            .email_XML = userObj.email_XML
            .employeeNum_XML = userObj.employeeNum_XML
            .cn_XML = userObj.cn_XML
            .o_XML = userObj.o_XML
            .sequence_XML = userObj.sequence_XML
            .status = userObj.status
            .modiDate = userObj.modiDate
            .executeDate = userObj.executeDate
            .stage = stage
            .ModifiedDate = Now
        End With
        insertObj.CDBInsert()

    End Sub
#End Region

#Region "update_Synchronize_table : 更新同步狀態"
    Public Sub update_SynchronizeUser_table(ByVal fromUID As String, ByVal fromStatus As String)

        Dim updateObj As New SQLServer.MIS.CCmail_Users
        updateObj = SQLServer.MIS.CCmail_Users.CDBSelect(Of SQLServer.MIS.CCmail_Users)(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QueryUidString(fromUID)).First
        If fromStatus = "DEL" Then
            updateObj.CDBDelete()
        Else
            With updateObj
                .status = fromStatus
                .modiDate = Now
            End With
            updateObj.CDBUpdate()
            write_SynchronizeUser_log(updateObj, "eE")
        End If
    End Sub
#End Region

#Region "write_SynchronizeDepartment_log : 執行結果Log"
    Private Sub write_SynchronizeDepartment_log(ByVal departmentObj As SQLServer.MIS.CCmail_Department, ByVal stage As String)

        Dim insertObj As New SQLServer.MIS.CCmail_Department_Log
        With insertObj
            .o_XML = departmentObj.o_XML
            .orgId_XML = departmentObj.orgId_XML
            .kind = departmentObj.kind
            .sequence_XML = departmentObj.sequence_XML
            .displayName_XML = departmentObj.displayName_XML
            .parentOrgId_XML = departmentObj.parentOrgId_XML
            .deptCode = departmentObj.deptCode
            .deptName = departmentObj.deptName
            .status = departmentObj.status
            .modiDate = departmentObj.modiDate
            .stage = stage
            .ModifiedDate = Now
        End With
        insertObj.CDBInsert()

    End Sub
#End Region

#Region "update_SynchronizeDepartment_table : 更新同步狀態"
    Public Sub update_SynchronizeDepartment_table(ByVal fromO As String, ByVal fromStatus As String)

        Dim updateObj As New SQLServer.MIS.CCmail_Department
        updateObj = SQLServer.MIS.CCmail_Department.CDBSelect(Of SQLServer.MIS.CCmail_Department)(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QueryOString(fromO)).First
        If fromStatus = "DEL" Then
            'updateObj.CDBDelete()
        Else
            With updateObj
                .status = fromStatus
                .modiDate = Now
            End With
            updateObj.CDBUpdate()
            write_SynchronizeDepartment_log(updateObj, "eE")
        End If

    End Sub
#End Region

#Region "String : QueryUidString"
    Public Function QueryUidString(ByVal uid As String) As String
        Return "SELECT * FROM [MIS].[dbo].[CCmail_Users] WHERE uid_XML = '" & uid & "'"
    End Function
#End Region

#Region "String : QueryOString"
    Private Function QueryOString(ByVal o As String) As String
        Return "SELECT * FROM [MIS].[dbo].[CCmail_Department] WHERE o_XML = '" & o & "'"
    End Function
#End Region

#Region "String　: FS_get_errcode"
    Public Function FS_get_errcode(ByVal formString As String) As String
        Dim lindex = formString.IndexOf("<errcode>") + ("<errcode>").Length
        Dim rindex = formString.IndexOf("</errcode>")
        If lindex < 0 Or rindex < 0 Then
            Return "Tags Not Found"
        End If
        Return formString.Substring(lindex, rindex - lindex)
    End Function

#End Region

#Region "String　: FS_get_errmsg"
    Public Function FS_get_errmsg(ByVal formString As String) As String
        Dim lindex = formString.IndexOf("<errmsg>") + ("<errmsg>").Length
        Dim rindex = formString.IndexOf("</errmsg>")
        If lindex < 0 Or rindex < 0 Then
            Return "Tags Not Found"
        End If
        Return formString.Substring(lindex, rindex - lindex)
    End Function

#End Region

#Region "Boolean : isExcuteSucess"
    Public Function isExcuteSucess(ByVal errcode As String) As Boolean
        For Each code As String In S_uccess_code
            If code.Equals(errcode) Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

#Region "String　: DecodeXML"
    Public Function DecodeXML(ByVal xml As String, ByVal rootNode As String) As String
        Dim result As New StringBuilder
        Dim objXmlDocument As New XmlDocument
        objXmlDocument.LoadXml(xml)
        Dim lv1_node_set As XmlNodeList = objXmlDocument.SelectSingleNode(rootNode).ChildNodes

        For Each lv1_node In lv1_node_set
            If lv1_node.ChildNodes.Count > 1 Then
                For Each lv2_node In lv1_node.ChildNodes
                    If lv2_node.ChildNodes.Count > 1 Then
                        For Each lv3_node In lv2_node.ChildNodes
                            If lv3_node.ChildNodes.Count > 1 Then
                                For Each lv4_node In lv3_node.ChildNodes
                                    result.Append(lv1_node.name & ".")
                                    result.Append(lv2_node.Name & ".")
                                    result.Append(lv3_node.Name & ".")
                                    result.Append(lv4_node.Name & " : ")
                                    result.Append(lv4_node.InnerText & vbNewLine)
                                Next
                            Else
                                result.Append(lv1_node.name & ".")
                                result.Append(lv2_node.Name & ".")
                                result.Append(lv3_node.Name & " : ")
                                result.Append(lv3_node.InnerText & vbNewLine)
                            End If
                        Next
                    Else
                        result.Append(lv1_node.name & ".")
                        result.Append(lv2_node.Name & " : ")
                        result.Append(lv2_node.InnerText & vbNewLine)
                    End If
                Next
            Else
                result.Append(lv1_node.Name & " : " & lv1_node.InnerText & vbNewLine)
            End If
        Next
        Return result.ToString
    End Function

#End Region

#Region "getDepartmentName : 取得部門中文名稱"
    Public Function getChineseDepartmentName(ByVal oid As String) As String
        Dim WP_SqlAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT deptName " & vbNewLine)
        querySQL.Append("FROM [MIS].[dbo].[CCmail_Department] " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("AND o_XML = '" & oid & "'" & vbNewLine)
        Dim queryDataTable As DataTable = WP_SqlAdapter.SelectQuery(querySQL.ToString)
        If queryDataTable.Rows.Count = 0 Then
            Return "---"
        Else
            Return queryDataTable.Rows(0).Item(0).ToString
        End If
    End Function
#End Region

#Region "FD_getAllDepartment : 取得CCmail所有部門"
    Public Function FD_getAllDepartment() As DataTable
        Dim WP_SqlAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT " & dc_o & "," & dc_deptName & vbNewLine)
        querySQL.Append("FROM [MIS].[dbo].[CCmail_Department] " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        Dim queryDataTable As DataTable = WP_SqlAdapter.SelectQuery(querySQL.ToString)

        Return queryDataTable

    End Function
#End Region

#Region "getKindName : 取得kind中文說明"
    Public Function FS_getKindName(ByVal formKind) As String
        Return WP_SYSNOTE.getLev4Content("CCMail", "Kind", formKind)
    End Function
#End Region

#Region "getStateName : 取得kind中文說明"
    Public Function FS_getStateName(ByVal formKind) As String
        Return WP_SYSNOTE.getLev4Content("CCMail", "執行狀態", formKind).Trim
    End Function
#End Region

#Region "FD_Data_Department"


    Public Function FD_Data_Department() As DataTable
        Dim querySQL As New StringBuilder
        querySQL.Append("SELECT pqdp1,pqdp2 " & vbNewLine)
        querySQL.Append("FROM @#PLT000LB.PQDDPTl2 " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("ORDER BY pqdp1 " & vbNewLine)
        Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(querySQL.ToString)

        Return queryDataTable
    End Function

#End Region

#Region "ViewState：Employee"
    Public Const C_DataTableEmployee As String = "DataTableEmployee"
    Public Const C_DataTableUnit As String = "DataTableUnit"

    Public Function showUnitName(ByRef fromDatatable As DataTable, ByVal fromUnitID As String) As String
        Dim showName As String = (From A In fromDatatable Where A.Item("pqdp1").ToString.Trim.Equals(fromUnitID.Trim) Select A.Item("pqdp2")).FirstOrDefault
        Dim retMsg As String = IIf(String.IsNullOrEmpty(showName), fromUnitID, showName)

        Return retMsg
    End Function

    Private Function showEmployeeInfo(ByVal fromDataTable_Employee As DataTable, ByVal fromID As String, ByVal fromColumnName As String) As String
        Dim showName As String = (From A In fromDataTable_Employee Where A.Item("qd100a").ToString.Trim.Equals(fromID.Trim) Select A.Item(fromColumnName).ToString.Trim).FirstOrDefault
        Dim retMsg As String = IIf(String.IsNullOrEmpty(showName), fromID, showName)

        Return retMsg
    End Function

    Public Function showEmployeeName(ByVal fromDataTable_Employee As DataTable, ByVal fromID As String) As String
        Return showEmployeeInfo(fromDataTable_Employee, fromID, "qd100c")
    End Function

    Public Function showEmployeeUserUnit(ByVal fromDataTable_Employee As DataTable, ByVal fromID As String) As String
        Return showEmployeeInfo(fromDataTable_Employee, fromID, "qd100e")
    End Function
#End Region

    Public Function FS_24H(ByVal fromString As String) As String
        Dim result As String = ""
        Try
            Return Format(Convert.ToDateTime(fromString), "yyyy/MM/dd HH:mm")
        Catch ex As Exception
            Return fromString
        End Try

    End Function
    Public Function FS_OnlyDate(ByVal fromString As String) As String
        Dim result As String = ""
        Try
            Return Format(Convert.ToDateTime(fromString), "yyyy/MM/dd")
        Catch ex As Exception
            Return fromString
        End Try

    End Function

#Region "ShowFormat"

    Public Function showFormatForDate(ByVal fromDate As String)
        Dim returnValue As String = fromDate
        If returnValue = "0" Then returnValue = ""

        If fromDate.Length >= 6 Then
            Dim W_Split_1 As String = fromDate.Substring(0, IIf(fromDate.Length = 6, 2, 3))
            Dim W_Split_2 As String = Microsoft.VisualBasic.Right(fromDate, 4)

            returnValue = W_Split_1
            returnValue &= "/" & W_Split_2.Substring(0, 2)
            returnValue &= "/" & W_Split_2.Substring(2, 2)
        End If

        Return returnValue
    End Function

    Public Function showFormatForTime(ByVal fromTime As String)
        Dim returnValue As String = fromTime
        If returnValue = "0" Then returnValue = ""

        If returnValue.Length = 5 Then returnValue = "0" & returnValue
        If returnValue.Length >= 6 Then
            returnValue = returnValue.Substring(0, 2) & ":" & returnValue.Substring(2, 2) & ":" & returnValue.Substring(4, 2)
        End If

        Return returnValue

    End Function
#End Region



End Module