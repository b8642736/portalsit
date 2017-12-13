Public Module LabRecordA2_Edit_Module
    Public ReadOnly WP_System_Type As String = "品保_檢驗證明書"
    Public ReadOnly WP_AC_System_Type As String = "品保_檢驗報告輸入"
    Public ReadOnly NO_NOTE_Type As String = "_表單編號"
    Public ReadOnly AC_NOTE_Type As String = "_檢驗單位"
    'Dim SPinfo_NOTE_Type As String = "第二頁_內容"
    Dim WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Public ReadOnly 參照規範 As String = "SPECIFCATION"
    Public ReadOnly 表面 As String = "FINISH"
    Public ReadOnly 鋼種 As String = "STEEL_GRAGE"
    Public ReadOnly 料別 As String = "CATEGORY"
    Public ReadOnly 爐號 As String = "CAST_NO"
    Public ReadOnly 鋼捲號碼 As String = "COIL_NUM"
    Public ReadOnly Assay_R As String = "ASSAY_RES"
    Public ReadOnly Assay_D As String = "ASSAY_DAT"
    Public ReadOnly Assay_ID As String = "ASSAY_ID"
    Public ReadOnly Remark_R As String = "REMARK_RES"
    Public ReadOnly Remark_D As String = "REMARK_DAT"
    Public ReadOnly Remark_ID As String = "REMARK_ID"
    Public ReadOnly JUDGET_TYPE As String = "JUDGET_TYPE"
    Public ReadOnly JUDGET_DOC As String = "JUDGET_DOC"

    '0915 顯示 對外正式名稱欄位名稱後啜辭
    Public ReadOnly _RealName As String = "_DISPLAY"
    Public ReadOnly 業務附註 As String = "APPEND_REMARK"
    'Property baseItem As String() = {"TA01", "TA02", "TA03", "TA04", "TA05", "TA06", "TA07", "TA08", "TA09"}
    Property baseItem As String() = (From dr In DT_QuerySQL("SELECT * FROM [QCdb01].[dbo].[LabRecordA2_Assay_DAT] WHERE SUBSTRING(ASSAY_ID,1,2) = 'AZ'")
                                     Select dr.Field(Of String)(Assay_ID)).ToArray
    
    'Property DT_baseItem As DataTable = WP_ClsSystemNote.getLev3(WP_System_Type, "檢驗證明書_標題列")
    Property DT_Buyer_set As DataTable = DT_QuerySQL("Select * From Openquery([AS400], 'SELECT CUA01 ||'':'' || CUA02 as NAME FROM SLS300LB.SL2CUAPF A WHERE 1=1 AND NOT CUA11 = ''< NULL >''')")
    Property DT_System_Note_AC As DataTable
    Public Enum 對照檔
        Assay = 0
        Remark = 1
    End Enum
    Public Enum 基本檔
        Assay = 0
        Remark = 1
    End Enum
    Public Enum RES增減
        加入 = 0
        移除 = 1
    End Enum
    Public Enum 判定結果
        正常 = 0
        不符 = 1
        格式錯誤 = 2
        未知的運算元 = 3
    End Enum

#Region "時間字串相關"
    ''' <summary>
    ''' 西元日期轉民國日期
    ''' </summary>
    ''' <param name="fromString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_ConvertToTaiwanDate(ByVal fromString As String) As String
        Dim result As String = ""
        Try
            Return CInt(Format(Convert.ToDateTime(fromString).AddYears(-1911), "yyyyMMdd")).ToString("0000000")
        Catch ex As Exception
            Return fromString
        End Try
    End Function
    ''' <summary>
    '''SQL時間轉24小時
    ''' </summary>
    ''' <param name="fromString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_24H(ByVal fromString As String) As String
        Dim result As String = ""
        Try
            Return Format(Convert.ToDateTime(fromString), "yyyy/MM/dd HH:mm")
        Catch ex As Exception
            Return fromString
        End Try
    End Function
#End Region

#Region "DataTable:查詢SQL/AS400"
    ''' <summary>
    ''' 查詢SQL
    ''' </summary>
    ''' <param name="fromSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_QuerySQL(ByVal fromSQL As String) As DataTable
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New DataTable
        End If
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(fromSQL)
        Return dtResult
    End Function
    ''' <summary>
    ''' 查詢AS400
    ''' </summary>
    ''' <param name="fromSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_QueryAS400(ByVal fromSQL As String) As DataTable
        Dim result As String = ""
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New DataTable
        End If
        Dim as400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim dtResult As DataTable = as400Adapter.SelectQuery(fromSQL)
        Return dtResult
    End Function
#End Region

#Region "DataTable:查詢對照檔(RES)  "
    ''' <summary>
    ''' 查詢對照檔(RES)
    ''' </summary>
    ''' <param name="config"></param>
    ''' <param name="specification"></param>
    ''' <param name="finish"></param>
    ''' <param name="steelgrade"></param>
    ''' <param name="category"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_config(ByVal config As 對照檔, ByVal specification As String, ByVal finish As String, ByVal steelgrade As String, ByVal category As String) As DataTable
        Dim result As String = ""
        Dim querySql As String = ""
        Select Case config
            Case 對照檔.Assay
                querySql = "SELECT [參照規範] " & vbNewLine
                querySql &= "      ,[表面類別] " & vbNewLine
                querySql &= "      ,[鋼種] " & vbNewLine
                querySql &= "      ,[材質] " & vbNewLine
                querySql &= "      ,[ASSAY_ID] " & vbNewLine
                querySql &= "      ,[NORMAL_RANGE_L] + '~' + [NORMAL_RANGE_H] AS NORMAL_RANGE       " & vbNewLine
                querySql &= "      ,[RESULT_FORMAT] " & vbNewLine
                querySql &= "      ,[EFF_FLAG] " & vbNewLine
                querySql &= "      ,[SAVE_OPER] " & vbNewLine
                querySql &= "      ,[SAVE_DATE] " & vbNewLine
                querySql &= "  FROM [QCdb01].[dbo].[LabRecordA2_Assay_RES] WHERE 1=1 " & vbNewLine
                querySql &= "AND 參照規範 = '" & specification & "'" & vbNewLine
                querySql &= "AND 表面類別 = '" & finish & "'" & vbNewLine
                querySql &= "AND 鋼種 = '" & steelgrade & "'" & vbNewLine
                querySql &= "AND 材質 = '" & category & "'" & vbNewLine

            Case 對照檔.Remark
                querySql = "SELECT * FROM [dbo].[LabRecordA2_Remark_RES] WHERE 1=1" & vbNewLine
                querySql &= "AND 參照規範 = '" & specification & "'" & vbNewLine
                querySql &= "AND 表面類別 = '" & finish & "'" & vbNewLine
                querySql &= "AND 鋼種 = '" & steelgrade & "'" & vbNewLine
                querySql &= "AND 材質 = '" & category & "'" & vbNewLine
        End Select

        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Return dtResult
    End Function

#End Region

#Region "DataTable:查詢DeBug對照檔(RES)  "
    ''' <summary>
    ''' 查詢對照檔(RES)
    ''' </summary>
    ''' <param name="config"></param>
    ''' <param name="specification"></param>
    ''' <param name="finish"></param>
    ''' <param name="steelgrade"></param>
    ''' <param name="category"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_DeBug_config(ByVal config As 對照檔, ByVal specification As String, ByVal finish As String, ByVal steelgrade As String, ByVal category As String) As DataTable
        Dim result As String = ""
        Dim querySql As String = ""
        Select Case config
            Case 對照檔.Assay
                querySql &= "SELECT [鋼種] " & vbNewLine
                querySql &= "      ,[材質] " & vbNewLine
                querySql &= "      ,[表面類別] " & vbNewLine
                querySql &= "      ,[參照規範] " & vbNewLine
                querySql &= "      ,A.[ASSAY_ID] " & vbNewLine
                querySql &= "      ,B.[ASSAY_NAME] " & vbNewLine
                querySql &= "      ,A.[NORMAL_RANGE_L] + '~' + A.[NORMAL_RANGE_H] AS NORMAL_RANGE" & vbNewLine
                querySql &= "      ,A.[RESULT_FORMAT] " & vbNewLine
                querySql &= "      ,B.[DISPLAY_SEQ] " & vbNewLine
                querySql &= "      ,A.[EFF_FLAG] " & vbNewLine
                querySql &= "      ,A.[SAVE_OPER] " & vbNewLine
                querySql &= "      ,A.[SAVE_DATE] " & vbNewLine
                querySql &= "  FROM [QCdb01].[dbo].[LabRecordA2_Assay_RES] A " & vbNewLine
                querySql &= "  LEFT JOIN [QCdb01].[dbo].[LabRecordA2_Assay_DAT] B  " & vbNewLine
                querySql &= "  ON A.ASSAY_ID = B.ASSAY_ID " & vbNewLine
                querySql &= "  WHERE 1=1 " & vbNewLine
                querySql &= "AND A.參照規範 = '" & specification & "'" & vbNewLine
                querySql &= "AND A.表面類別 = '" & finish & "'" & vbNewLine
                querySql &= "AND A.鋼種 = '" & steelgrade & "'" & vbNewLine
                querySql &= "AND A.材質 = '" & category & "'" & vbNewLine

            Case 對照檔.Remark
                querySql &= "SELECT [鋼種] " & vbNewLine
                querySql &= "      ,[材質] " & vbNewLine
                querySql &= "      ,[表面類別] " & vbNewLine
                querySql &= "      ,[參照規範] " & vbNewLine
                querySql &= "      ,A.[REMARK_ID] " & vbNewLine
                querySql &= "      ,IIF(LEN(CONTEXT)>16,LEFT(CONTEXT,16) + '...(略)',CONTEXT) AS 內容" & vbNewLine
                querySql &= "      ,B.DISPLAY_SEQ " & vbNewLine
                querySql &= "      ,A.[EFF_FLAG] " & vbNewLine
                querySql &= "      ,A.[SAVE_OPER] " & vbNewLine
                querySql &= "      ,A.[SAVE_DATE] " & vbNewLine
                querySql &= "  FROM [QCdb01].[dbo].[LabRecordA2_Remark_RES] A " & vbNewLine
                querySql &= "  LEFT JOIN [dbo].[LabRecordA2_Remark_DAT] B " & vbNewLine
                querySql &= "  ON A.REMARK_ID = B.REMARK_ID " & vbNewLine
                querySql &= "  WHERE 1=1 " & vbNewLine
                querySql &= "AND A.參照規範 = '" & specification & "'" & vbNewLine
                querySql &= "AND A.表面類別 = '" & finish & "'" & vbNewLine
                querySql &= "AND A.鋼種 = '" & steelgrade & "'" & vbNewLine
                querySql &= "AND A.材質 = '" & category & "'" & vbNewLine
        End Select

        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Return dtResult
    End Function

#End Region

#Region "取得DAT檔"
    Public Function DT_getDat(ByVal type As 基本檔)
        Dim querySql As String
        If type = 基本檔.Assay Then
            querySql = " SELECT [ASSAY_ID] " & vbNewLine
            querySql &= "      ,[ASSAY_NAME] " & vbNewLine
            querySql &= "      ,[DISPLAY_SEQ] " & vbNewLine
            querySql &= "      ,[DISPLAY_FLAG] " & vbNewLine
            '' RANGE_HL
            querySql &= "      ,[NORMAL_RANGE_L] + '~' + [NORMAL_RANGE_H] AS NORMAL_RANGE" & vbNewLine
            querySql &= "      ,[RESULT_FORMAT] " & vbNewLine
            querySql &= "      ,[RESULT_KIND] " & vbNewLine
            querySql &= "      ,[RESULT_TABLE_COLUMN] " & vbNewLine
            querySql &= "      ,[EFF_FLAG] " & vbNewLine
            querySql &= "      ,[SAVE_OPER] " & vbNewLine
            querySql &= "      ,[SAVE_DATE] " & vbNewLine
            querySql &= "FROM [QCdb01].[dbo].[LabRecordA2_Assay_DAT] WHERE 1=1 " & vbNewLine
        Else
            querySql = "SELECT * FROM [QCdb01].[dbo].[LabRecordA2_REMARK_DAT] WHERE 1=1 " & vbNewLine
        End If
        Return DT_QuerySQL(querySql)
    End Function
#End Region

#Region "String:查詢客戶名稱"
    ''' <summary>
    ''' 透過客戶代碼查詢客戶名稱
    ''' </summary>
    ''' <param name="fromCusID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_Customer(ByVal fromCusID As String) As String
        Dim result As String = ""
        Dim querySql As String = "EXEC [dbo].[PD_AS400_客戶基本資料檔] @from客戶編號清單 = '" & fromCusID & "'"
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Try
            result = dtResult.Rows(0).Item("CUA02")
        Catch ex As Exception
            Return "ERROR"
        End Try
        Return result
    End Function
#End Region

#Region "String:查詢提貨單日期"
    ''' <summary>
    ''' 透過提貨單號查詢提貨單日期
    ''' </summary>
    ''' <param name="fromBOL02">提貨單號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_DeliveryDate(ByVal fromBOL02 As String) As String
        Dim result As String = ""
        Dim querySql As String = ""
        querySql &= "SELECT MAX(BOL01) as BOL01 FROM @#SLS300LB.SL2BOLPF WHERE trim(BOL02) = '" & fromBOL02.Trim & "'" & vbNewLine
        Dim sqlAdapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Try
            result = dtResult.Rows(0).Item("BOL01")
        Catch ex As Exception
            Return "ERROR"
        End Try
        Return result
    End Function
#End Region

#Region "String:查詢訂單號碼"
    ''' <summary>
    ''' 透過提貨單號查詢定單號碼
    ''' </summary>
    ''' <param name="fromBOL02">提貨單號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_ContractNo(ByVal fromBOL02 As String) As String
        Dim result As String = ""
        Dim querySql As String = ""
        querySql &= "SELECT MAX(BOL01) as BOL01,BOL02,BOL03 FROM @#SLS300LB.SL2BOLPF WHERE trim(BOL02) = '" & fromBOL02.Trim & "'" & vbNewLine
        querySql &= "GROUP BY BOL02,BOL03"
        Dim sqlAdapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Try
            result = dtResult.Rows(0).Item("BOL03")
        Catch ex As Exception
            Return "ERROR"
        End Try
        Return result
    End Function
#End Region

#Region "DataTable:查詢化性"
    ''' <summary>
    ''' 透過爐號與元素(多項以,分隔)查詢化性
    ''' </summary>
    ''' <param name="fromFno"></param>
    ''' <param name="fromElements"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_QueryChemical(ByVal fromFno As String, ByVal fromElements As String) As DataTable
        Dim result As String = ""
        Dim querySql As String = "EXEC [dbo].[QCdb01_分析資料_化學成分]  @fno = '" & fromFno & "' , @element = '" & fromElements & "'"
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Return dtResult
    End Function
#End Region

#Region "DataTable:查詢物性"
    ''' <summary>
    ''' 透過鋼捲號碼查詢物性
    ''' </summary>
    ''' <param name="fromColis"></param>
    ''' <param name="fromItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_Mechanical(ByVal fromColis As String, ByVal fromItem As String) As DataTable
        Dim result As String = ""
        Dim querySql As String = "SELECT " & fromItem & "FROM @#PPS100LB.PPSQCGPF WHERE QCG01 > 1050101 and QCG02 = '" & fromColis & "'"
        Dim as400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim dtResult As DataTable = as400Adapter.SelectQuery(querySql)
        Return dtResult

    End Function
#End Region

#Region "DataTable:查詢其他資訊"
    ''' <summary>
    ''' 查詢其他資訊(AC)
    ''' </summary>
    ''' <param name="from_kind">來源類型</param>
    ''' <param name="from_sample_id">鋼捲號碼或爐號</param>
    ''' <param name="fromItem">ASSAY_ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_Other(ByVal from_kind As String, ByVal from_sample_id As String, ByVal fromItem As String) As DataTable
        If IsNothing(DT_System_Note_AC) Then
            DT_System_Note_AC = WP_ClsSystemNote.getLev3(WP_AC_System_Type, AC_NOTE_Type)
        End If

        Dim system_note_ac = From dr As DataRow In DT_System_Note_AC.Rows
                             Where dr.Item("NOTE_ID").ToString.Trim = from_kind

        If Not system_note_ac.Any Then

        End If
        Dim sample_id As String = from_sample_id.Split(",")(IIf(system_note_ac.First.Item("CONTENT") = "KA", 1, 0))
        Dim result As String = ""
        Dim querySql As String = "SELECT RESULT_VALUE FROM [QCdb01].[dbo].[LabRecordA2_Report]" & vbNewLine
        querySql &= "WHERE 1=1" & vbNewLine
        querySql &= "AND SAMPLE_UNIT = '" & from_kind & "'" & vbNewLine
        querySql &= "AND SAMPLE_ID = '" & sample_id & "'" & vbNewLine
        querySql &= "AND ASSAY_ID = '" & fromItem & "'" & vbNewLine
        querySql &= "ORDER BY SAVE_DATE DESC"
        Dim dtResult As DataTable = DT_QuerySQL(querySql)
        Return dtResult

    End Function
#End Region

#Region "DataTable : 取得完整RES對照檔(有加權)"
    ''' <summary>
    ''' 取得完整RES對照檔，依據加權排序(鋼種10 材質100 表面 1000 參照10000) 
    ''' </summary>
    ''' <param name="config"></param>
    ''' <returns></returns>
    ''' <remarks>加權越小越下面  最晚吃到的設定為主</remarks>

    Public Function DT_config(ByVal config As 對照檔) As DataTable
        Dim result As String = ""
        Dim querySql As String = ""
        querySql = "SELECT [鋼種] " & vbNewLine
        querySql &= "      ,[材質] " & vbNewLine
        querySql &= "      ,[表面類別] " & vbNewLine
        querySql &= "      ,[參照規範] " & vbNewLine
        Select Case config
            Case 對照檔.Assay
                querySql &= "      ,A.[ASSAY_ID] " & vbNewLine
                querySql &= "      ,B.[ASSAY_NAME] " & vbNewLine
                '' RANGE_HL
                querySql &= "      ,A.[NORMAL_RANGE_L] + '~' + A.[NORMAL_RANGE_H] AS NORMAL_RANGE" & vbNewLine
                querySql &= "      ,A.[RESULT_FORMAT] " & vbNewLine
            Case 對照檔.Remark
                querySql &= "      ,A.[REMARK_ID] " & vbNewLine
                querySql &= "      ,IIF(LEN(CONTEXT)>16,LEFT(CONTEXT,16) + '...(略)',CONTEXT) as 內容" & vbNewLine
        End Select
        querySql &= "      ,B.DISPLAY_SEQ " & vbNewLine
        querySql &= "      ,A.[EFF_FLAG] " & vbNewLine
        'querySql &= "      ,A.[SAVE_OPER] " & vbNewLine
        'querySql &= "      ,A.[SAVE_DATE] " & vbNewLine
        querySql &= "      ,( " & vbNewLine
        querySql &= "    case 鋼種 " & vbNewLine
        querySql &= "         when '+' then 0 " & vbNewLine
        querySql &= "         when '-' then 0 " & vbNewLine
        querySql &= "         else 10 " & vbNewLine
        querySql &= "    END " & vbNewLine
        querySql &= "    + " & vbNewLine
        querySql &= "    case 材質 " & vbNewLine
        querySql &= "         when '+' then 0 " & vbNewLine
        querySql &= "         when '-' then 0 " & vbNewLine
        querySql &= "         else 100 " & vbNewLine
        querySql &= "    END " & vbNewLine
        querySql &= "    + " & vbNewLine
        querySql &= "    case 表面類別 " & vbNewLine
        querySql &= "         when '+' then 0 " & vbNewLine
        querySql &= "         when '-' then 0 " & vbNewLine
        querySql &= "         else 1000 " & vbNewLine
        querySql &= "    END " & vbNewLine
        querySql &= "    + " & vbNewLine
        querySql &= "    case 參照規範 " & vbNewLine
        querySql &= "         when '+' then 0 " & vbNewLine
        querySql &= "         when '-' then 0 " & vbNewLine
        querySql &= "         else 10000 " & vbNewLine
        querySql &= "    END " & vbNewLine
        querySql &= ") as 權重 " & vbNewLine
        querySql &= " " & vbNewLine
        Select Case config
            Case 對照檔.Assay
                querySql &= "FROM [QCdb01].[dbo].[LabRecordA2_Assay_RES] A" & vbNewLine
                querySql &= "  LEFT JOIN [dbo].[LabRecordA2_Assay_DAT] B " & vbNewLine
                querySql &= "  ON A.ASSAY_ID = B.ASSAY_ID " & vbNewLine
                querySql &= "WHERE 1=1" & vbNewLine
                'querySql &= "AND NOT ((鋼種 in ('+','-')) and (材質 in ('+','-')) and (表面類別 in ('+','-')) and (參照規範 in ('+','-'))) " & vbNewLine
                querySql &= "AND A.EFF_FLAG = 'N' " & vbNewLine
                querySql &= "Order by DISPLAY_SEQ,ASSAY_ID,權重,鋼種,材質 " & vbNewLine
            Case 對照檔.Remark
                querySql &= "FROM [QCdb01].[dbo].[LabRecordA2_Remark_RES] A" & vbNewLine
                querySql &= "  LEFT JOIN [dbo].[LabRecordA2_Remark_DAT] B " & vbNewLine
                querySql &= "  ON A.REMARK_ID = B.REMARK_ID " & vbNewLine
                querySql &= "WHERE 1=1" & vbNewLine
                querySql &= "AND A.EFF_FLAG = 'N' " & vbNewLine
                'querySql &= "AND NOT ((鋼種 in ('+','-')) and (材質 in ('+','-')) and (表面類別 in ('+','-')) and (參照規範 in ('+','-'))) " & vbNewLine
                querySql &= "Order by DISPLAY_SEQ,REMARK_ID,權重,鋼種,材質 " & vbNewLine
        End Select


        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Return dtResult
    End Function
#End Region

#Region "DataTable:查詢基本檔(DAT)"
    ''' <summary>
    ''' 查詢基本檔(DAT)
    ''' </summary>
    ''' <param name="config"></param>
    ''' <param name="ids"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_configdat(ByVal config As 對照檔, ids As String()) As DataTable
        Dim result As String = ""
        Dim querySql As String = ""
        Dim firstline As Boolean = True
        Select Case config
            Case 對照檔.Assay
                querySql = " SELECT [ASSAY_ID] " & vbNewLine
                querySql &= "      ,[ASSAY_NAME] " & vbNewLine
                querySql &= "      ,[DISPLAY_SEQ] " & vbNewLine
                querySql &= "      ,[DISPLAY_FLAG] " & vbNewLine
                '' RANGE_HL
                querySql &= "      ,[NORMAL_RANGE_L] + '~' + [NORMAL_RANGE_H] AS NORMAL_RANGE" & vbNewLine
                querySql &= "      ,[RESULT_FORMAT] " & vbNewLine
                querySql &= "      ,[RESULT_KIND] " & vbNewLine
                querySql &= "      ,[RESULT_TABLE_COLUMN] " & vbNewLine
                querySql &= "      ,[EFF_FLAG] " & vbNewLine
                querySql &= "      ,[SAVE_OPER] " & vbNewLine
                querySql &= "      ,[SAVE_DATE] " & vbNewLine
                querySql &= "FROM [QCdb01].[dbo].[LabRecordA2_Assay_DAT] WHERE 1=1 " & vbNewLine
                For Each id As String In ids
                    If firstline Then
                        querySql &= "AND (ASSAY_ID = '" & id & "'" & vbNewLine
                        firstline = False
                    Else
                        querySql &= "OR ASSAY_ID = '" & id & "'" & vbNewLine
                    End If
                Next
                querySql &= ")AND EFF_FLAG = 'N'"
                querySql &= "order by DISPLAY_SEQ"
            Case 對照檔.Remark
                querySql = "SELECT * FROM [dbo].[LabRecordA2_Remark_DAT] WHERE 1=1" & vbNewLine
                For Each id As String In ids
                    If firstline Then
                        querySql &= "AND (REMARK_ID = '" & id & "'" & vbNewLine
                        firstline = False
                    Else
                        querySql &= "OR REMARK_ID = '" & id & "'" & vbNewLine
                    End If
                Next
                querySql &= ")AND EFF_FLAG = 'N'"
        End Select

        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Return dtResult
    End Function
#End Region

#Region "DataTable : 檢查項目Table"
    ''' <summary>
    ''' 取得檢查項目DataTable
    ''' </summary>
    ''' <param name="steelgrade">鋼種</param>
    ''' <param name="finish">表面</param>
    ''' <param name="category">料別</param>
    ''' <param name="specification">參照規範</param>
    ''' <param name="remark_id">附註ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_check(ByVal steelgrade As String, ByVal finish As String, ByVal category As String, ByVal specification As String, ByVal remark_id As String) As DataTable
        Dim queryString As String = ""
        queryString &= "SELECT * FROM [QCdb01].[dbo].[LabRecordA2_Remark_RESAssay] " & vbNewLine
        queryString &= "WHERE 1=1" & vbNewLine
        queryString &= "AND 鋼種 = '" & steelgrade & "'" & vbNewLine
        queryString &= "AND 表面類別 = '" & finish & "'" & vbNewLine
        queryString &= "AND 材質 = '" & category & "'" & vbNewLine
        queryString &= "AND 參照規範 = '" & specification & "'" & vbNewLine
        queryString &= "AND REMARK_ID = '" & remark_id & "'" & vbNewLine
        queryString &= "AND EFF_FLAG = 'N'" & vbNewLine
        Return DT_QuerySQL(queryString)
    End Function
#End Region

#Region "取得設定或預設範圍與小數位數"
    ''' <summary>
    ''' 取RES檔小數位數與NORMAL_RANGE 若RES無設定則以DAT為主
    ''' </summary>
    ''' <param name="resTable"></param>
    ''' <param name="datTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function clone_format(ByVal resTable As DataTable, ByVal datTable As DataTable) As DataTable
        datTable.Columns("NORMAL_RANGE").ReadOnly = False
        For Each dr As DataRow In datTable.Rows
            Dim resrow = From item As DataRow In resTable.Rows
                         Where item.Item("ASSAY_ID") = dr.Item("ASSAY_ID")
            dr.Item("NORMAL_RANGE") = IIf(resrow.First.Item("NORMAL_RANGE").ToString.Trim = "", dr.Item("NORMAL_RANGE"), resrow.First.Item("NORMAL_RANGE"))
            dr.Item("RESULT_FORMAT") = IIf(resrow.First.Item("RESULT_FORMAT").ToString.Trim = "", dr.Item("RESULT_FORMAT"), resrow.First.Item("RESULT_FORMAT"))
        Next
        Return datTable
    End Function
#End Region

#Region "產生SQL in 條件:input A-B-C,- 或 A|B|C,| output 'A','B','C'  "
    ''' <summary>
    ''' 產生SQL in 條件:input A-B-C,- 或 A|B|C,| output 'A','B','C'  
    ''' </summary>
    ''' <param name="fromString"></param>
    ''' <param name="splitString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_SQL_IN(ByVal fromString As String, ByVal splitString As String) As String
        Dim result As String = ""
        If fromString.IndexOf(splitString) < 0 Then
            result = "'" & fromString & "'"
        Else
            For Each labno In fromString.Split(splitString)
                result &= "'" & labno & "',"
            Next
            result = result.Remove(result.Length - 1, 1)
        End If
        Return result
    End Function
#End Region

#Region "DataTable:取得套用設定的對照檔(RES)"
    ''' <summary>
    ''' 取得套用設定的對照檔(RES)
    ''' </summary>
    ''' <param name="config"></param>
    ''' <param name="specification"></param>
    ''' <param name="finish"></param>
    ''' <param name="steelgrade"></param>
    ''' <param name="category"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_getResTable(ByVal config As 對照檔, ByVal specification As String, ByVal finish As String, ByVal steelgrade As String, ByVal category As String, YaWuList As String) As DataTable
        Dim IDitem As String = ""
        Dim Item_head As String = ""
        If config = 對照檔.Assay Then
            IDitem = Assay_ID
            Item_head = "A"
        Else
            IDitem = Remark_ID
            Item_head = "R"
        End If

        Dim normalTable As DataTable = DT_config(config, specification, finish, steelgrade, category)
        If Not normalTable.Rows.Count > 0 Then
            Dim source_Table As DataTable = DT_config(config)
            For Each dr As DataRow In source_Table.Rows
                If RES_isPassAdd(dr, RES增減.加入, specification, finish, steelgrade, category) Then
                    Dim item = From resitem As DataRow In normalTable.Rows
                               Where resitem.Item(IDitem) = dr.Item(IDitem)
                    If item.Count > 0 Then
                        item.Single.Delete()
                        normalTable.AcceptChanges()
                    End If
                    normalTable.ImportRow(dr)
                End If
            Next

            For Each dr As DataRow In source_Table.Rows
                If RES_isPassAdd(dr, RES增減.移除, specification, finish, steelgrade, category) Then
                    Dim item = From resitem As DataRow In normalTable.Rows
                               Where resitem.Item(IDitem) = dr.Item(IDitem)
                    If item.Count > 0 Then
                        item.Single.Delete()
                        normalTable.AcceptChanges()
                    End If
                End If
            Next
        End If

        If Not YaWuList.Trim.Length = 0 Then
            Dim YaWuItem_set As String()
            If YaWuList.IndexOf("|") < 0 Then
                YaWuItem_set = {YaWuList}
            Else
                YaWuItem_set = From element As String In YaWuList.Split("|")
                               Where element.Trim.StartsWith(Item_head)
            End If


            For Each yawu_item In YaWuItem_set
                Dim item = From resitem As DataRow In normalTable.Rows
                           Where resitem.Item(IDitem) = yawu_item
                If item.Count > 0 Then
                    item.Single.Delete()
                    normalTable.AcceptChanges()
                End If
                Dim dr = normalTable.NewRow
                dr.Item(0) = "*"
                dr.Item(1) = "*"
                dr.Item(2) = "*"
                dr.Item(3) = "*"
                dr.Item(4) = yawu_item
                normalTable.Rows.Add(dr)
            Next
        End If

        Return normalTable
    End Function
#End Region

#Region "DataTable:取得套用設定的對照檔(RES)_FOR DeBug視窗 解譯欄位、移除非必要資訊、保留未套用RES規則"
    ''' <summary>
    ''' 取得套用設定的對照檔(RES)_FOR DeBug視窗 解譯欄位、移除非必要資訊、保留未套用RES規則
    ''' </summary>
    ''' <param name="config"></param>
    ''' <param name="specification"></param>
    ''' <param name="finish"></param>
    ''' <param name="steelgrade"></param>
    ''' <param name="category"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DT_DeBug_getResTable(ByVal config As 對照檔, ByVal specification As String, ByVal finish As String, ByVal steelgrade As String, ByVal category As String, YaWuList As String) As DataTable
        Dim IDitem As String = ""
        Dim Item_head As String = ""
        If config = 對照檔.Assay Then
            IDitem = Assay_ID
            Item_head = "A"
        Else
            IDitem = Remark_ID
            Item_head = "R"
        End If

        Dim normalTable As DataTable = DT_DeBug_config(config, specification, finish, steelgrade, category)
        normalTable.Columns.Add("權重")
        If Not normalTable.Rows.Count > 0 Then
            Dim source_Table As DataTable = DT_config(config)
            For Each dr As DataRow In source_Table.Rows
                If RES_isPassAdd(dr, RES增減.加入, specification, finish, steelgrade, category) Then
                    Dim item = From resitem As DataRow In normalTable.Rows
                               Where resitem.Item(IDitem) = dr.Item(IDitem)
                    normalTable.ImportRow(dr)
                End If
            Next

            For Each dr As DataRow In source_Table.Rows
                If RES_isPassAdd(dr, RES增減.移除, specification, finish, steelgrade, category) Then
                    Dim item = From resitem As DataRow In normalTable.Rows
                               Where resitem.Item(IDitem) = dr.Item(IDitem)
                    normalTable.ImportRow(dr)
                End If
            Next

            For Each col As DataColumn In normalTable.Columns
                col.ColumnName = FS_TW_ColumnName(col.ColumnName)
                If col.ColumnName = "" Then
                    normalTable.Columns.Remove(col)
                End If
            Next
        End If
        If Not YaWuList.Trim.Length = 0 Then
            Dim YaWuItem_set As String()
            If YaWuList.IndexOf("|") < 0 Then
                YaWuItem_set = {YaWuList}
            Else
                YaWuItem_set = From element As String In YaWuList.Split("|")
                               Where element.Trim.StartsWith(Item_head)
            End If


            For Each yawu_item In YaWuItem_set
                Dim item = From resitem As DataRow In normalTable.Rows
                           Where resitem.Item(IDitem) = yawu_item
                Dim dr = normalTable.NewRow
                dr.Item(0) = "*"
                dr.Item(1) = "*"
                dr.Item(2) = "*"
                dr.Item(3) = "*"
                dr.Item(4) = yawu_item
                dr.Item("LEVEL") = 99999
                normalTable.Rows.Add(dr)
            Next
        End If
        Return normalTable
    End Function
#End Region

#Region "Boolean : 判斷RES規則是否可以套用"
    ''' <summary>
    ''' 判斷RES規則是否可以套用
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <param name="action"></param>
    ''' <param name="specification"></param>
    ''' <param name="finish"></param>
    ''' <param name="steelgrade"></param>
    ''' <param name="category"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RES_isPassAdd(ByVal dr As DataRow, ByVal action As RES增減, ByVal specification As String, ByVal finish As String, ByVal steelgrade As String, ByVal category As String) As Boolean
        If True _
            And dr.Item("參照規範").ToString.Trim = specification.Trim _
            And dr.Item("表面類別").ToString.Trim = finish.Trim _
            And dr.Item("鋼種").ToString.Trim = steelgrade.Trim _
            And dr.Item("材質").ToString.Trim = category.Trim Then
            Return False
        End If
        Dim sym As String = ""
        Select Case action
            Case RES增減.加入
                sym = "+"
            Case RES增減.移除
                sym = "-"
        End Select

        Dim b_規範 As Boolean = dr.Item("參照規範").ToString.Trim = specification.Trim Or dr.Item("參照規範").ToString.Trim = sym
        Dim b_表面 As Boolean = dr.Item("表面類別").ToString.Trim = finish.Trim Or dr.Item("表面類別").ToString.Trim = sym
        Dim b_鋼種 As Boolean = dr.Item("鋼種").ToString.Trim = steelgrade.Trim Or dr.Item("鋼種").ToString.Trim = sym
        Dim b_材質 As Boolean = dr.Item("材質").ToString.Trim = category.Trim Or dr.Item("材質").ToString.Trim = sym

        Return b_材質 And b_表面 And b_鋼種 And b_規範
    End Function
#End Region

#Region "String : 將DataTable的某個欄組成以 | 分隔的字串"
    ''' <summary>
    ''' 將DataTable的某個欄位資料組成以 | 分隔的字串
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="item"></param>
    ''' <returns>以 | 分隔的字串</returns>
    ''' <remarks></remarks>
    Public Function FS_filedtostring(ByVal dt As DataTable, ByVal item As String) As String
        Dim result As String = ""
        If dt.Rows.Count = 0 Then
            Return ""
        End If
        For Each dr As DataRow In dt.Rows
            result &= dr.Item(item).ToString.Trim() & "|"
        Next
        result = result.Remove(result.Length - 1)
        Return result
    End Function
#End Region

#Region "DataTable : 將欄位名稱轉為中文"
    ''' <summary>
    ''' 資料庫英翻中
    ''' </summary>
    ''' <param name="fromDT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FD_convert_columnName(ByVal fromDT As DataTable) As DataTable
        For Each col As DataColumn In fromDT.Columns
            col.ColumnName = FS_TW_ColumnName(col.ColumnName)
        Next
        Return fromDT
    End Function
#End Region

#Region "DataTable : 將DataTable轉為Debug Mode 移除不必要資訊、欄位名稱解譯"
    ''' <summary>
    ''' 將DataTable轉為Debug Mode 移除不必要資訊、欄位名稱解譯 
    ''' </summary>
    ''' <param name="fromDT">欲轉換的DataTable</param>
    ''' <param name="add_apply_columns">是否新增'套用設定'欄位</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FD_ConvertToDebugMode(ByVal fromDT As DataTable, ByVal add_apply_columns As Boolean) As DataTable
        Dim removeColName As String() = {"來源種類", "資料來源", "停用", "values", 鋼種 & _RealName, 表面 & _RealName, 料別 & _RealName, 參照規範 & _RealName, "delivery_Num2", "SAVE_OPER", "SAVE_DATE"}
        Dim result As DataTable = FD_convert_columnName(fromDT)
        For Each ColName As String In removeColName
            If result.Columns.IndexOf((ColName)) >= 0 Then
                result.Columns.Remove(ColName)
            End If
        Next
        If add_apply_columns Then
            result.Columns.Add("套用設定")
        End If
        Return result
    End Function
#End Region

#Region "DeBug UI : 輸入4Keys 將詳細設定套用至GridView上並上色"
    ''' <summary>
    ''' DeBug UI : 輸入4Keys 將詳細設定套用至GridView上並上色
    ''' </summary>
    ''' <param name="gv">目標GridView</param>
    ''' <param name="type">資料來源</param>
    ''' <param name="specification">參照規範</param>
    ''' <param name="finish">表面</param>
    ''' <param name="steelgrade">鋼種</param>
    ''' <param name="category">材質</param>
    ''' <remarks></remarks>
    Public Sub UI_set_debug_RES_gridview(ByRef gv As GridView, ByVal type As 對照檔, ByVal specification As String, ByVal finish As String, ByVal steelgrade As String, ByVal category As String, YaWuList As String)
        Dim debug_table As DataTable = DT_DeBug_getResTable(type, specification, finish, steelgrade, category, YaWuList)
        Dim ID_col_name As String = IIf(type = 對照檔.Assay, "項目ID", "權重")
        debug_table = FD_ConvertToDebugMode(debug_table, True)
        Dim view As DataView = debug_table.AsDataView()
        'Dim dat_table As DataTable = DT_getDat(type)
        view.Sort = IIf(type = 對照檔.Assay, ID_col_name & ",權重", ID_col_name & ",權重")
        gv.DataSource = view
        gv.DataBind()
        '套用設定欄位的index
        Dim target_index As Int32 = IIf(type = 對照檔.Assay, 10, 8)

        Dim color As Drawing.Color = Drawing.Color.LemonChiffon

        For Each gr As GridViewRow In gv.Rows
            Dim rowindex As Int32 = gr.RowIndex
            If rowindex = 0 Then
                gv.Rows(rowindex).BackColor = color
                If gv.Rows.Count = 1 Then
                    gr.Cells(target_index).Text = "V"
                End If
                Continue For
            End If
            If gv.Rows(rowindex - 1).Cells(4).Text.Trim = gr.Cells(4).Text.Trim Then
                gv.Rows(rowindex).BackColor = color
            Else
                gv.Rows(rowindex - 1).Cells(target_index).Text = "V"
                color = IIf(color = Drawing.Color.LemonChiffon, Drawing.Color.White, Drawing.Color.LemonChiffon)
                gv.Rows(rowindex).BackColor = color
            End If
            If rowindex = gv.Rows.Count - 1 Then
                gr.Cells(target_index).Text = "V"
            End If
        Next

    End Sub

    ''' <summary>
    ''' DeBug UI : 輸入4Keys 將套用結果套用至GridView上
    ''' </summary>
    ''' <param name="gv">目標GridView</param>
    ''' <param name="type">資料來源</param>
    ''' <param name="specification">參照規範</param>
    ''' <param name="finish">表面</param>
    ''' <param name="steelgrade">鋼種</param>
    ''' <param name="category">材質</param>
    ''' <remarks></remarks>
    Public Sub UI_set_debug_DAT_gridview(ByRef gv As GridView, ByVal type As 對照檔, ByVal specification As String, ByVal finish As String, ByVal steelgrade As String, ByVal category As String, ByVal yawulist As String)
        Dim columnName_ID As String = IIf(type = 對照檔.Assay, Assay_ID, Remark_ID)
        Dim table_Name_SQL As String = IIf(type = 對照檔.Assay, Assay_D, Remark_D)
        Dim res_table As DataTable = DT_getResTable(type, specification, finish, steelgrade, category, yawulist)
        Dim id_set As String() = FS_filedtostring(res_table, columnName_ID).Split("|")

        Dim dat_table As DataTable = DT_configdat(type, id_set)
        If type = 對照檔.Assay Then
            dat_table.Columns.Add("values")
            dat_table = clone_format(res_table, dat_table)
        End If

        gv.DataSource = FD_ConvertToDebugMode(dat_table, False)
        gv.DataBind()
        gv.Visible = False
    End Sub
#End Region

#Region "String : 資料庫欄位中文名稱"
    ''' <summary>
    ''' 回傳資料庫欄位中文名稱
    ''' </summary>
    ''' <param name="fromstring"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_TW_ColumnName(ByVal fromstring As String) As String
        Select Case fromstring.ToUpper
            Case "ASSAY_ID"
                Return "項目ID"
            Case "REMARK_ID"
                Return "附註ID"
            Case "NORMAL_RANGE"
                Return "範圍"
            Case "RESULT_FORMAT"
                Return "小數位數"
            Case "LABREPORT_NO"
                Return "材證單號"
            Case "ITEM_NO"
                Return "項次"
            Case "ASSAY_NAME"
                Return "顯示名稱"
            Case "RESULT_KIND"
                Return "來源種類"
            Case "RESULT_TABLE_COLUMN"
                Return "資料來源"
            Case "RESULT_VALUE"
                Return "值"
            Case "CONTEXT"
                Return "內容"
            Case "DISPLAY_SEQ"
                Return "顯示排序"
            Case "DISPLAY_FLAG"
                Return "是否顯示"
            Case "IS_ASSAY_ITEM"
                Return "是否檢驗"
            Case "CHECK_ASSAY_ITEM"
                Return "檢驗條件"
            Case "EFF_FLAG"
                Return "停用"
            Case "CUSTOMER"
                Return "客戶名稱"
            Case "CONTRACT_NO"
                Return "定單號碼"
            Case "LC_NO"
                Return "信用狀號碼"
            Case "DELIVERY_NO"
                Return "提貨單號"
            Case "SAVE_DATATIME"
                Return "儲存時間"
            Case "REMARK_LIST"
                Return "附註項目"
            Case "DELIVERY_NUM"
                Return "提貨單號"
            Case "ORDER_NUM"
                Return "訂單號碼"
            Case "CUST_NUM"
                Return "客戶代號"
            Case "COIL_NUM"
                Return "鋼捲號碼"
            Case "HEAT_NO"
                Return "爐號_細"
            Case "CAST_NO"
                Return "爐號"
            Case "PRODUCT"
                Return "產品型態"
            Case "STEEL_GRAGE"
                Return "鋼種"
            Case "FINISH"
                Return "表面"
            Case "CATEGORY"
                Return "料別"
            Case "THICKNESS"
                Return "厚度"
            Case "WIDTH"
                Return "寬度"
            Case "LENGTH"
                Return "長度"
            Case "LENGHT"
                Return "長度"
            Case "NETWEIGHT"
                Return "淨重"
            Case "SPECIFCATION"
                Return "參照規範"
            Case "APPEND_REMARK"
                Return "業務附註"
            Case "SIZE"
                Return "產品尺寸"
            Case Else
                Return fromstring
        End Select

    End Function
#End Region

#Region "DataTableRow : 加入錯誤訊息"
    Public Sub addErrorMessage(ByRef fromDataTabe As QualityControlDataSet.LabRecordA2DetailsMessageDataTable, ByVal fromlabno As String, ByVal fromMsg As String)
        Dim dr As QualityControlDataSet.LabRecordA2DetailsMessageRow = fromDataTabe.NewLabRecordA2DetailsMessageRow
        dr.LABNO = fromlabno
        dr.CONTENT = fromMsg
        fromDataTabe.AddLabRecordA2DetailsMessageRow(dr)
    End Sub
#End Region

#Region "DataTableRow : 加入作業清單"
    Public Sub addResult(ByRef fromDataTabe As QualityControlDataSet.LabRecordA2DetailsDataTable, ByVal fromlabno As String, ByVal fromResult As String)
        Dim dr As QualityControlDataSet.LabRecordA2DetailsRow = fromDataTabe.NewLabRecordA2DetailsRow
        dr.LABNO = fromlabno
        dr.RESULT = fromResult
        fromDataTabe.AddLabRecordA2DetailsRow(dr)
    End Sub
#End Region

#Region "Enum 判定結果 : 判定是否符合規範"
    ''' <summary>
    ''' 判定是否符合結果
    ''' </summary>
    ''' <param name="X">輸入值</param>
    ''' <param name="Operators">判定方式</param>
    ''' <param name="Y">目標值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function good_judget(ByVal X As String, ByVal Operators As String, ByVal Y As String) As 判定結果
        Try
            Select Case Operators
                Case "A"  '數字 - 等於
                    Return IIf(CDbl(X) = CDbl(Y), 判定結果.正常, 判定結果.不符)
                Case "B"  '數字 - 不等於
                    Return IIf(Not CDbl(X) = CDbl(Y), 判定結果.正常, 判定結果.不符)
                Case "C"  '數字 - 小於
                    Return IIf(CDbl(X) < CDbl(Y), 判定結果.正常, 判定結果.不符)
                Case "D"  '數字 - 小於等於
                    Return IIf(CDbl(X) <= CDbl(Y), 判定結果.正常, 判定結果.不符)
                Case "E"  '數字 - 大於
                    Return IIf(CDbl(X) > CDbl(Y), 判定結果.正常, 判定結果.不符)
                Case "F"  '數字 - 大於等於
                    Return IIf(CDbl(X) >= CDbl(Y), 判定結果.正常, 判定結果.不符)
                Case "G"  '文字 - 等於
                    Return IIf(X.Trim.Equals(Y.Trim), 判定結果.正常, 判定結果.不符)
                Case "H"  '文字 - 不等於
                    Return IIf(Not X.Trim.Equals(Y.Trim), 判定結果.正常, 判定結果.不符)
                Case Else
                    Return 判定結果.未知的運算元
            End Select
        Catch ex As Exception
            Return 判定結果.格式錯誤
        End Try
    End Function
#End Region

#Region "String : 取得判定條件說明"
    ''' <summary>
    ''' 取得判定條件說明
    ''' </summary>
    ''' <param name="Operators">判定方式</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FS_Operator(ByVal Operators As String) As String
        Select Case Operators
            Case "A"
                Return "等於(數字)"
            Case "B"
                Return "不等於(數字)"
            Case "C"
                Return "小於(數字)"
            Case "D"
                Return "小於等於(數字)"
            Case "E"
                Return "大於(數字)"
            Case "F"
                Return "大於等於(數字)"
            Case "G"
                Return "等於(文字)"
            Case "H"
                Return "不等於(文字)"
            Case Else
                Return "未知的運算元"
        End Select

    End Function
#End Region
End Module
