Namespace SQLServer
	Namespace PPS100LB
	Public Class PlanProductionDisplay
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "CIW0A線別 屬性:CIW0A"
            Private _CIW0A As System.String
            ''' <summary>
            ''' CIW0A線別
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW0A() As System.String
                Get
                    Return _CIW0A
                End Get
                Set(ByVal value As System.String)
                    If Not String.IsNullOrEmpty(value) Then
                        value = value.ToUpper
                    End If
                    _CIW0A = value
                End Set
            End Property
#End Region
#Region "CIW00日期 屬性:CIW00"
            Private _CIW00 As System.Int32
            ''' <summary>
            ''' CIW00日期
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW00() As System.Int32
                Get
                    Return _CIW00
                End Get
                Set(ByVal value As System.Int32)
                    _CIW00 = value
                End Set
            End Property
#End Region
#Region "CIW01時間 屬性:CIW01"
            Private _CIW01 As System.Int32
            ''' <summary>
            ''' CIW01時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW01() As System.Int32
                Get
                    Return _CIW01
                End Get
                Set(ByVal value As System.Int32)
                    _CIW01 = value
                End Set
            End Property
#End Region
#Region "CIW02寬度 屬性:CIW02"
            Private _CIW02 As System.Int32
            ''' <summary>
            ''' CIW02寬度
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW02() As System.Int32
                Get
                    Return _CIW02
                End Get
                Set(ByVal value As System.Int32)
                    _CIW02 = value
                End Set
            End Property
#End Region
#Region "CIW03鋼種 屬性:CIW03"
            Private _CIW03 As System.String
            ''' <summary>
            ''' CIW03鋼種
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW03() As System.String
                Get
                    Return _CIW03
                End Get
                Set(ByVal value As System.String)
                    _CIW03 = value
                End Set
            End Property
#End Region
#Region "CIW04TYPE 屬性:CIW04"
            Private _CIW04 As System.String
            ''' <summary>
            ''' CIW04TYPE
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW04() As System.String
                Get
                    Return _CIW04
                End Get
                Set(ByVal value As System.String)
                    _CIW04 = value
                End Set
            End Property
#End Region
#Region "CIW05黑皮厚 屬性:CIW05"
            Private _CIW05 As System.String
            ''' <summary>
            ''' CIW05黑皮厚
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW05() As System.String
                Get
                    Return _CIW05
                End Get
                Set(ByVal value As System.String)
                    _CIW05 = value
                End Set
            End Property
#End Region
#Region "CIW06項 屬性:CIW06"
            Private _CIW06 As System.Int32
            ''' <summary>
            ''' CIW06項
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW06() As System.Int32
                Get
                    Return _CIW06
                End Get
                Set(ByVal value As System.Int32)
                    _CIW06 = value
                End Set
            End Property
#End Region
#Region "CIW12派工量 屬性:CIW12"
            Private _CIW12 As System.Int32
            ''' <summary>
            ''' CIW12派工量
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW12() As System.Int32
                Get
                    Return _CIW12
                End Get
                Set(ByVal value As System.Int32)
                    _CIW12 = value
                End Set
            End Property
#End Region
#Region "CIW15優先順序 屬性:CIW15"
            Private _CIW15 As System.Int32
            ''' <summary>
            ''' CIW15優先順序
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CIW15() As System.Int32
                Get
                    Return _CIW15
                End Get
                Set(ByVal value As System.Int32)
                    _CIW15 = value
                End Set
            End Property
#End Region
#Region "資料儲存時間 屬性:DataSaveTime"
            Private _DataSaveTime As DateTime
            ''' <summary>
            ''' 資料儲存時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property DataSaveTime() As DateTime
                Get
                    Return _DataSaveTime
                End Get
                Set(ByVal value As DateTime)
                    _DataSaveTime = value
                End Set
            End Property

#End Region

#Region "CIW06狀態說明 屬性:CIW06Descript"
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property CIW06Descript As String
                Get
                    Select Case CIW06
                        Case 1
                            Return "組合料"
                        Case 2
                            Return "黑皮直軋"
                        Case 3
                            Return "直投ZML"
                        Case 4
                            Return "直投NO1"
                    End Select
                    Return "未知"
                End Get
            End Property
#End Region
#Region "顯示寬度 屬性:DisplayWidth"
            ''' <summary>
            ''' 顯示寬度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public ReadOnly Property DisplayWidth As Integer
                Get
                    Select Case CIW02
                        Case 914
                            Return 955
                        Case 1000
                            Return 1030
                        Case 1219
                            Return 1250
                        Case 1250
                            Return 1280
                        Case 1260
                            Return 1290
                    End Select
                    Return CIW02
                End Get
            End Property
#End Region

#Region "重新設定排序編號 函式:ReOrderCIW15"
            ''' <summary>
            ''' 重新設定排序編號
            ''' </summary>
            ''' <remarks></remarks>
            Public Shared Sub ReOrderCIW15()
                Dim QryString As String = "Select * from  PlanProductionDisplay Order by CIW15"
                Dim SearchResult As List(Of PlanProductionDisplay) = PlanProductionDisplay.CDBSelect(Of PlanProductionDisplay)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                Dim SetOrderNubmer As Integer = 10
                For Each EachItem In SearchResult
                    EachItem.CIW15 = SetOrderNubmer
                    Dim SaveValue As Integer = EachItem.CDBUpdate()
                    SetOrderNubmer += 10
                Next
            End Sub
#End Region


#Region "合併AS400派工資料至SQLServer 函式:MergeAS400ProductionToSQLServer (不用作廢)"
            ' ''' <summary>
            ' ''' 合併AS400派工資料至SQLServer
            ' ''' </summary>
            ' ''' <param name="MergeLine"></param>
            ' ''' <remarks></remarks>
            'Public Shared Sub MergeAS400ProductionToSQLServer(ByVal MergeLine As MergeLineEnum)
            '    Dim QryString As String = "Select * from @#SLS300LB.SL2CIWPF WHERE CIW91='' "
            '    Select Case MergeLine
            '        Case MergeLineEnum.CPL
            '            QryString &= " AND LEFT(CIW0A,2)='CP'"
            '        Case MergeLineEnum.APL
            '            QryString &= " AND LEFT(CIW0A,2)='AP'"
            '        Case MergeLineEnum.ZML
            '            QryString &= " AND LEFT(CIW0A,2)='ZM'"
            '    End Select
            '    Dim SearchResult1 As List(Of CompanyORMDB.SLS300LB.SL2CIWPF) = CompanyORMDB.SLS300LB.SL2CIWPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CIWPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            '    QryString = "Select * from PlanProductionDisplay "
            '    Dim SearchResult2 As List(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay) = CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            '    Dim IsSQLDataFinded As Boolean = False
            '    Dim NewAddPlanProductionDisplays As New List(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay)
            '    For Each EachAS400Item As CompanyORMDB.SLS300LB.SL2CIWPF In SearchResult1
            '        IsSQLDataFinded = False
            '        With EachAS400Item
            '            For Each EachSqlItem In SearchResult2
            '                If EachSqlItem.CIW0A = .CIW0A And _
            '                   EachSqlItem.CIW02 = .CIW02 And _
            '                   EachSqlItem.CIW03 = .CIW03 And _
            '                   EachSqlItem.CIW04 = .CIW04 And _
            '                   EachSqlItem.CIW05 = .CIW05 And _
            '                   EachSqlItem.CIW15 = .CIW15 Then
            '                    EachSqlItem.CIW12 += .CIW12
            '                    If EachSqlItem.CDBSave > 0 Then
            '                        .CIW91 = "A"    '註記為已讀取(合併資料)
            '                        .CDBSave()
            '                        IsSQLDataFinded = True : Exit For
            '                    End If
            '                End If
            '            Next
            '            For Each EachItem In NewAddPlanProductionDisplays
            '                If EachItem.CIW0A = .CIW0A And _
            '                   EachItem.CIW02 = .CIW02 And _
            '                   EachItem.CIW03 = .CIW03 And _
            '                   EachItem.CIW04 = .CIW04 And _
            '                   EachItem.CIW05 = .CIW05 And _
            '                   EachItem.CIW15 = .CIW15 Then
            '                    EachItem.CIW12 += .CIW12
            '                    If EachItem.CDBSave > 0 Then
            '                        .CIW91 = "A"    '註記為已讀取(合併資料)
            '                        .CDBSave()
            '                        IsSQLDataFinded = True : Exit For
            '                    End If
            '                End If
            '            Next
            '            If IsSQLDataFinded = False Then
            '                Dim AddNewItem As New CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay
            '                AddNewItem.CIW0A = .CIW0A
            '                AddNewItem.CIW00 = .CIW00
            '                AddNewItem.CIW01 = .CIW01
            '                AddNewItem.CIW02 = .CIW02
            '                AddNewItem.CIW03 = .CIW03
            '                AddNewItem.CIW04 = .CIW04
            '                AddNewItem.CIW05 = .CIW05
            '                AddNewItem.CIW06 = .CIW06
            '                AddNewItem.CIW12 = .CIW12
            '                AddNewItem.CIW15 = .CIW15
            '                If AddNewItem.CDBSave() > 0 Then
            '                    NewAddPlanProductionDisplays.Add(AddNewItem)
            '                    .CIW91 = "A"    '註記為已讀取(合併資料)
            '                    .CDBSave()
            '                End If
            '            End If
            '        End With
            '    Next
            'End Sub
#End Region
#Region "合併產線列舉 列舉:MergeLineEnum"
            Public Enum MergeLineEnum
                ALL = 0
                CPL = 1
                APL = 2
                ZML = 3
            End Enum
#End Region



#Region "找尋未完成符合規格之派工 方法:FindMatchSpecPlanProductionDisplay"
            ''' <summary>
            ''' 找尋未完成符合規格之派工(優先權最高者為優先)
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function FindMatchSpecPlanProductionDisplay(ByVal SetCIW0A As String, ByVal SetCIW02 As Integer, ByVal SetCIW03 As String, ByVal SetCIW04 As String, ByVal SetCIW05 As String, ByVal SetCIW06 As Integer) As PlanProductionDisplay
                Dim QryString As String = "Select * from PlanProductionDisplay Where CIW0A='" & SetCIW0A.Trim & "' and CIW02=" & SetCIW02 & " and CIW03='" & SetCIW03.Trim & "' and CIW04='" & SetCIW04.Trim & "' and LTRIM(CIW05)='" & Format(Val(SetCIW05.Trim), "0.0") & "' and CIW06=" & SetCIW06 & " order by CIW15 "
                Dim SearchResult As List(Of PlanProductionDisplay) = PlanProductionDisplay.CDBSelect(Of PlanProductionDisplay)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count = 0 Then
                    Return Nothing
                End If
                Return SearchResult(0)
            End Function
#End Region

            Public Overrides Function CDBUpdate() As Integer
                Return MyBase.CDBUpdate()
            End Function

            Public Overrides Function CDBInsert() As Integer
                Me.DataSaveTime = Now
                Return MyBase.CDBInsert()
            End Function


        End Class
	End Namespace
End Namespace