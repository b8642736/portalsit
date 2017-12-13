Public Class JudgeEdit
    Inherits System.Web.UI.UserControl

    Public Const WP_Num_Default As Integer = 999
    Public Const WP_Num_Formula As Integer = 980

#Region "資料查詢 方法:Search"
    'Public Shared Function Search(ByVal QryString As String) As List(Of CompanyORMDB.SQLServer.QCDB01.成品判定)
    '    Dim ReutnrValue As New List(Of CompanyORMDB.SQLServer.QCDB01.成品判定)
    '    If String.IsNullOrEmpty(QryString) Then
    '        Return ReutnrValue
    '    End If
    '    Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
    '    ReutnrValue = CompanyORMDB.SQLServer.QCDB01.成品判定.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.成品判定)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    '    Return ReutnrValue
    'End Function


    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal QryString1 As String) As List(Of CompanyORMDB.SQLServer.QCDB01.成品判定_公式)
        Dim ReutnrValue2 As New List(Of CompanyORMDB.SQLServer.QCDB01.成品判定_公式)
        If String.IsNullOrEmpty(QryString1) Then
            Return ReutnrValue2
        End If



        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim ReutnrValue1 As List(Of CompanyORMDB.SQLServer.QCDB01.成品判定) = CompanyORMDB.SQLServer.QCDB01.成品判定.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.成品判定)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString1)

        For Each eachItem1 As CompanyORMDB.SQLServer.QCDB01.成品判定 In ReutnrValue1
            ReutnrValue2.Add(CDBClass_成品判定_公式(eachItem1))
        Next eachItem1


        'Dim QryString2 As String = QryString1.Replace("成品判定", "成品判定_公式")
        'Dim ReutnrValue2 As List(Of CompanyORMDB.SQLServer.QCDB01.成品判定_公式) = CompanyORMDB.SQLServer.QCDB01.成品判定_公式.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.成品判定_公式)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString2)


        'Dim eachItemValue1 As Object = Nothing
        'Dim eachItemValue2 As Object = Nothing
        'Dim eachItem2 As CompanyORMDB.SQLServer.QCDB01.成品判定_公式 = Nothing
        'For Each eachItem1 As CompanyORMDB.SQLServer.QCDB01.成品判定_公式 In ReutnrValue1
        '    eachItem2 = (From B In ReutnrValue2 _
        '                 Where B.鋼種.Equals(eachItem1.鋼種) _
        '                    AndAlso B.材質.Equals(eachItem1.材質) _
        '                    AndAlso B.管制種類.Equals(eachItem1.管制種類) _
        '                    Select B).FirstOrDefault


        '    For Each eachFieldName As String In eachItem1.CDBClassDBPropertyFieldNames
        '        eachItemValue1 = eachItem1.CDBGetFieldValue(eachFieldName)

        '        Select Case eachFieldName
        '            Case "鋼種", "材質", "管制種類"

        '            Case Else
        '                If Math.Abs(Double.Parse(eachItemValue1)) = WP_Num_Formula Then
        '                    If Not eachItem2 Is Nothing Then
        '                        eachItemValue2 = eachItem2.CDBGetFieldValue(eachFieldName)

        '                        If Not eachItemValue2 Is Nothing Then
        '                            eachItem1.CDBSetFieldValue(eachFieldName, eachItemValue2)
        '                        End If

        '                    End If

        '                End If
        '        End Select


        '    Next eachFieldName

        'Next eachItem1

        Return ReutnrValue2
    End Function


#End Region

#Region "新增 方法:CDBInsert"
    'Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.成品判定) As Integer
    '    Return SourceObject.CDBInsert
    'End Function
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.成品判定_公式) As Integer
        Return CDBClass_Run(SourceObject, CDBClass_Enum.Insert)
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    'Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.成品判定) As Integer
    '    Return SourceObject.CDBUpdate
    'End Function
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.成品判定_公式) As Integer

        Return CDBClass_Run(SourceObject, CDBClass_Enum.Update)
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    'Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.成品判定) As Integer
    '    Return SourceObject.CDBDelete
    'End Function

    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.成品判定_公式) As Integer
        Return CDBClass_Run(SourceObject, CDBClass_Enum.Delete)
    End Function
#End Region

#Region "CDBClass_成品判定"
    Public Shared Function CDBClass_成品判定_公式(ByVal eachItem1 As CompanyORMDB.SQLServer.QCDB01.成品判定) As CompanyORMDB.SQLServer.QCDB01.成品判定_公式
        Dim QryString1 As String = eachItem1.CDBDeleteSQLString
        Dim QryString2 As String
        Dim W_Index_Where As Integer = QryString1.ToUpper.IndexOf(" WHERE ")
        QryString2 = "Select * FROM 成品判定_公式 " & QryString1.Substring(W_Index_Where)

        Dim ReutnrValue2 As List(Of CompanyORMDB.SQLServer.QCDB01.成品判定_公式) = CompanyORMDB.SQLServer.QCDB01.成品判定_公式.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.成品判定_公式)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString2)

        Dim eachItemValue As Object = Nothing
        Dim eachItem2 As CompanyORMDB.SQLServer.QCDB01.成品判定_公式

        eachItem2 = (From B In ReutnrValue2 _
                     Where B.鋼種.Equals(eachItem1.鋼種) _
                        AndAlso B.材質.Equals(eachItem1.材質) _
                        AndAlso B.管制種類.Equals(eachItem1.管制種類) _
                        Select B).FirstOrDefault

        Dim returnItem As New CompanyORMDB.SQLServer.QCDB01.成品判定_公式

        For Each eachFieldName As String In eachItem1.CDBClassDBPropertyFieldNames
            eachItemValue = eachItem1.CDBGetFieldValue(eachFieldName)

            If Not eachItem2 Is Nothing Then
                Select Case eachFieldName
                    Case "鋼種", "材質", "管制種類"

                    Case Else
                        If Math.Abs(Double.Parse(eachItemValue)) = WP_Num_Formula Then
                            eachItemValue = eachItem2.CDBGetFieldValue(eachFieldName)
                        End If
                End Select
            End If

            returnItem.CDBSetFieldValue(eachFieldName, eachItemValue)
        Next eachFieldName

        Return returnItem
    End Function
    Public Shared Function CDBClass_成品判定_公式_Check(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.成品判定_公式) As CompanyORMDB.SQLServer.QCDB01.成品判定_公式
        Dim eachItemValue1 As Object
        'Dim eachItemValue2 As Object
        Dim SourceObject2 As New CompanyORMDB.SQLServer.QCDB01.成品判定_公式

        Dim kind As String
        If SourceObject.管制種類.Length >= 2 AndAlso SourceObject.管制種類.Substring(1, 1).Equals("L") Then
            kind = "-"
        Else
            kind = "+"
        End If

        For Each eachFieldName As String In SourceObject.CDBClassDBPropertyFieldNames
            eachItemValue1 = SourceObject.CDBGetFieldValue(eachFieldName)

            Select Case eachFieldName
                Case "鋼種", "材質", "管制種類"


                Case Else
                    If IsNumeric(eachItemValue1) = True Then
                        '                                                                                                         '原本：數字類型

                    ElseIf Convert.ToString(eachItemValue1).Trim = "" Then     '原本：未輸入 +-999
                        eachItemValue1 = Double.Parse(String.Concat(kind, WP_Num_Default))

                    End If

            End Select

            SourceObject2.CDBSetFieldValue(eachFieldName, eachItemValue1)

        Next eachFieldName

        Return SourceObject2
    End Function
    Public Shared Function CDBClass_成品判定(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.成品判定_公式) As CompanyORMDB.SQLServer.QCDB01.成品判定
        Dim eachItemValue1 As Object
        Dim eachItemValue2 As Object
        Dim SourceObject2 As New CompanyORMDB.SQLServer.QCDB01.成品判定

        Dim kind As String
        If SourceObject.管制種類.Length >= 2 AndAlso SourceObject.管制種類.Substring(1, 1).Equals("L") Then
            kind = "-"
        Else
            kind = "+"
        End If

        For Each eachFieldName As String In SourceObject2.CDBClassDBPropertyFieldNames
            eachItemValue1 = SourceObject.CDBGetFieldValue(eachFieldName)

            Select Case eachFieldName
                Case "鋼種", "材質", "管制種類"
                    eachItemValue2 = Convert.ToString(eachItemValue1)

                Case Else
                    If IsNumeric(eachItemValue1) = True Then
                        eachItemValue2 = Double.Parse(eachItemValue1)           '原本：數字類型

                    Else                                                                                                      '公式：文字類型 +-980
                        eachItemValue2 = Double.Parse(String.Concat(kind, WP_Num_Formula))
                    End If

            End Select

            SourceObject2.CDBSetFieldValue(eachFieldName, eachItemValue2)

        Next eachFieldName

        Return SourceObject2
    End Function

    Enum CDBClass_Enum
        Delete = 1
        Insert = 2
        Update = 3
    End Enum

    Public Shared Function CDBClass_Run(ByVal fromSourceObject2 As CompanyORMDB.SQLServer.QCDB01.成品判定_公式 _
                                                                           , ByVal fromCDBClass_Enum As CDBClass_Enum) As Integer

        Dim SourceObject2 As CompanyORMDB.SQLServer.QCDB01.成品判定_公式 = CDBClass_成品判定_公式_Check(fromSourceObject2)
        Dim SourceObject1 As CompanyORMDB.SQLServer.QCDB01.成品判定 = CDBClass_成品判定(SourceObject2)

        Dim W_Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim W_SqlConnection As SqlClient.SqlConnection = W_Adapter.SqlConnection
        W_SqlConnection.Open()

        Dim W_SqlTransaction As SqlClient.SqlTransaction = W_SqlConnection.BeginTransaction

        Dim W_CMD_1_Delete As New SqlClient.SqlCommand(SourceObject1.CDBDeleteSQLString, W_SqlConnection)
        Dim W_CMD_1_Insert As New SqlClient.SqlCommand(SourceObject1.CDBInsertSQLString, W_SqlConnection)
        Dim W_CMD_2_Delete As New SqlClient.SqlCommand(SourceObject2.CDBDeleteSQLString, W_SqlConnection)
        Dim W_CMD_2_Insert As New SqlClient.SqlCommand(SourceObject2.CDBInsertSQLString, W_SqlConnection)


        W_CMD_1_Delete.Transaction = W_SqlTransaction
        W_CMD_1_Insert.Transaction = W_SqlTransaction
        W_CMD_2_Delete.Transaction = W_SqlTransaction
        W_CMD_2_Insert.Transaction = W_SqlTransaction

        Try
            'Type1:Delete
            Select Case fromCDBClass_Enum
                Case CDBClass_Enum.Delete, CDBClass_Enum.Update
                    W_CMD_1_Delete.ExecuteNonQuery()
                    W_CMD_2_Delete.ExecuteNonQuery()
            End Select

            'Type2:Insert 
            Select Case fromCDBClass_Enum
                Case CDBClass_Enum.Insert, CDBClass_Enum.Update
                    W_CMD_1_Insert.ExecuteNonQuery()
                    W_CMD_2_Insert.ExecuteNonQuery()
            End Select

            'Type3:Commit
            W_SqlTransaction.Commit()

        Catch ex2 As Exception
            W_SqlTransaction.Rollback()

        Finally
            W_SqlConnection.Close()
        End Try

        Return 2
    End Function
#End Region



#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As New StringBuilder
        SQLString.Append(" Select * From 成品判定  Where 1=1 ")
        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            SQLString.Append(String.Format(" AND RTRIM(LTRIM(鋼種)) IN ('{0}')", tbSteelKind.Text.Split("','")))
        End If
        If Not String.IsNullOrEmpty(tbMaterial.Text) AndAlso tbMaterial.Text.Trim.Length > 0 Then
            SQLString.Append(String.Format(" AND RTRIM(LTRIM(材質)) IN ('{0}')", tbMaterial.Text.Split("','")))
        End If

        Dim FilterItems As String = String.Empty
        For Each EachItem As ListItem In CheckBoxList1.Items
            If EachItem.Selected Then
                FilterItems &= IIf(String.IsNullOrEmpty(FilterItems), "", "','") & EachItem.Value
            End If
        Next
        If Not String.IsNullOrEmpty(FilterItems) AndAlso FilterItems.Split(",").Count < 4 Then
            SQLString.Append(String.Format(" AND RTRIM(LTRIM(管制種類)) IN ('{0}')", FilterItems))
        End If

        Me.hfQry.Value = SQLString.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
    End Sub
End Class

