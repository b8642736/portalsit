Namespace ORMBaseClass
    <Serializable()> _
    Public Class ClassDBSQLServer
        Inherits ClassDB
        Implements IClassDBInherited

        Sub New(ByVal SetSQLQueryAdapterByThisObject As SQLServerSQLQueryAdapter)
            Me.SQLQueryAdapterByThisObject = SetSQLQueryAdapterByThisObject
        End Sub

        Sub New(ByVal SetGetDataMoe As SQLServerSQLQueryAdapter.ConnectionMoeEnum, ByVal SetSQLServerName As SQLServerSQLQueryAdapter.ConnectServerNameEnum, ByVal SetConnectDBName As String)
            Me.SQLQueryAdapterByThisObject = New SQLServerSQLQueryAdapter(SetGetDataMoe, SetSQLServerName, SetConnectDBName)
        End Sub

#Region "LocalSQL查詢轉接器For此物件 屬性:SQLQueryAdapterByThisObject"
        Private _SQLQueryAdapterByThisObject As SQLServerSQLQueryAdapter
        ''' <summary>
        ''' LocalSQL查詢轉接器For此物件
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property SQLQueryAdapterByThisObject() As SQLServerSQLQueryAdapter
            Get
                Return _SQLQueryAdapterByThisObject
            End Get
            Set(ByVal value As SQLServerSQLQueryAdapter)
                _SQLQueryAdapterByThisObject = value
            End Set
        End Property
#End Region
#Region "SQL查詢轉接器 屬性:SQLQueryAdapter"

        Private Shared _SQLQueryAdapter As SQLServerSQLQueryAdapter '= New SQLServerSQLQueryAdapter()
        ''' <summary>
        ''' SQL查詢轉接器
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SQLQueryAdapter() As SQLServerSQLQueryAdapter
            Get
                'If IsNothing(_SQLQueryAdapter) Then
                '    _SQLQueryAdapter = New SQLServerSQLQueryAdapter()
                'End If
                Return _SQLQueryAdapter
            End Get
            Set(ByVal value As SQLServerSQLQueryAdapter)
                _SQLQueryAdapter = value
            End Set
        End Property

#End Region
#Region "現在使用查詢轉接器 屬性:CDBCurrentUseSQLQueryAdapter"
        ''' <summary>
        ''' 現在使用查詢轉接器
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CDBCurrentUseSQLQueryAdapter() As SQLServerSQLQueryAdapter
            Get
                If Not IsNothing(Me.SQLQueryAdapterByThisObject) Then
                    Return Me.SQLQueryAdapterByThisObject
                End If
                Return ClassDBSQLServer.SQLQueryAdapter
            End Get
        End Property
#End Region

#Region "資料增刪修事件 事件:CDBDataInsertUpdateDeleteEvent"
        ''' <summary>
        ''' 資料增刪修事件
        ''' </summary>
        ''' <param name="DBObject"></param>
        ''' <remarks></remarks>
        Public Event CDBDataInsertUpdateDeletedEvent(ByVal DBObject As ClassDB, ByVal DataInsertUpdateDeleteKind As IClassDBInherited.DataInsertUpdateDeleteType) Implements IClassDBInherited.CDBDataInsertUpdateDeletedEvent
#End Region
#Region "新增 方法:CDBInsert"
        ''' <summary>
        ''' 新增
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Insert)> _
        Public Overridable Function CDBInsert() As Integer Implements IClassDBInherited.CDBInsert
            If CDBClassFieldNames.Count = 0 Then
                Return 0
            End If

            If IsNothing(SQLQueryAdapter) AndAlso IsNothing(SQLQueryAdapterByThisObject) Then
                Throw New Exception("請先設定本物件之SQLQueryAdapter或SQLQueryAdapterByThisObject")
            End If

            Dim ReturnValue As Integer = 0
            If IsNothing(Me.SQLQueryAdapterByThisObject) Then
                'Return SQLQueryAdapter.SQLServerExecuteNonQuery(CDBInsertSQLString, Me.SQLServerNameOrIP, Me.ConnectDBName)
                ReturnValue = SQLQueryAdapter.ExecuteNonQuery(CDBInsertSQLString)
            Else
                'Return SQLQueryAdapterByThisObject.SQLServerExecuteNonQuery(CDBInsertSQLString, Me.SQLServerNameOrIP, Me.ConnectDBName)
                ReturnValue = SQLQueryAdapterByThisObject.ExecuteNonQuery(CDBInsertSQLString)
            End If
            If ReturnValue > 0 Then
                RaiseEvent CDBDataInsertUpdateDeletedEvent(Me, IClassDBInherited.DataInsertUpdateDeleteType.Insert)
            End If
            Return ReturnValue
        End Function
#End Region
#Region "更新 方法:CDBUpdate"
        ''' <summary>
        ''' 更新
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Update)> _
        Public Overridable Function CDBUpdate() As Integer Implements IClassDBInherited.CDBUpdate
            If CDBClassFieldNames.Count = 0 Then
                Return 0
            End If
            If IsNothing(SQLQueryAdapter) AndAlso IsNothing(SQLQueryAdapterByThisObject) Then
                Throw New Exception("請先設定本物件之SQLQueryAdapter或SQLQueryAdapterByThisObject")
            End If
            Dim ReturnValue As Integer = 0
            If IsNothing(Me.SQLQueryAdapterByThisObject) Then
                ReturnValue = SQLQueryAdapter.ExecuteNonQuery(CDBUpdateSQLString)
            Else
                ReturnValue = SQLQueryAdapterByThisObject.ExecuteNonQuery(CDBUpdateSQLString)
            End If
            If ReturnValue > 0 Then
                RaiseEvent CDBDataInsertUpdateDeletedEvent(Me, IClassDBInherited.DataInsertUpdateDeleteType.Update)
            End If
            Return ReturnValue
        End Function
#End Region
#Region "刪除 方法:CDBDelete"
        ''' <summary>
        ''' 刪除
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Delete)> _
        Public Overridable Function CDBDelete() As Integer Implements IClassDBInherited.CDBDelete
            If CDBClassFieldNames.Count = 0 Then
                Return 0
            End If
            If IsNothing(SQLQueryAdapter) AndAlso IsNothing(SQLQueryAdapterByThisObject) Then
                Throw New Exception("請先設定本物件之SQLQueryAdapter或SQLQueryAdapterByThisObject")
            End If
            Dim ReturnValue As Integer = 0
            If IsNothing(Me.SQLQueryAdapterByThisObject) Then
                'Return SQLQueryAdapter.SQLServerExecuteNonQuery(CDBDeleteSQLString, Me.SQLServerNameOrIP, Me.ConnectDBName)
                ReturnValue = SQLQueryAdapter.ExecuteNonQuery(CDBDeleteSQLString)
            Else
                'Return SQLQueryAdapterByThisObject.SQLServerExecuteNonQuery(CDBDeleteSQLString, Me.SQLServerNameOrIP, Me.ConnectDBName)
                ReturnValue = SQLQueryAdapterByThisObject.ExecuteNonQuery(CDBDeleteSQLString)
            End If
            If ReturnValue > 0 Then
                RaiseEvent CDBDataInsertUpdateDeletedEvent(Me, IClassDBInherited.DataInsertUpdateDeleteType.Delete)
            End If
            Return ReturnValue
        End Function
#End Region
#Region "查詢 方法:CDBSelect"
        ''' <summary>
        ''' 查詢
        ''' </summary>
        ''' <typeparam name="ObjectType"></typeparam>
        ''' <param name="SetQueryString"></param>
        ''' <param name="SetSQLQueryAdapterByThisObject"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function CDBSelect(Of ObjectType As {ClassDBSQLServer, New})(ByVal SetQueryString As String, Optional ByVal SetSQLQueryAdapterByThisObject As SQLServerSQLQueryAdapter = Nothing) As List(Of ObjectType)

            Dim UseSQLQueryAdapter As SQLServerSQLQueryAdapter = SetSQLQueryAdapterByThisObject
            If IsNothing(UseSQLQueryAdapter) Then
                UseSQLQueryAdapter = SQLQueryAdapter
            End If
            If IsNothing(UseSQLQueryAdapter) Then
                UseSQLQueryAdapter = (New ObjectType).SQLQueryAdapterByThisObject
            End If
            If IsNothing(UseSQLQueryAdapter) Then
                Throw New Exception("請先設定本物件之SQLQueryAdapter或SQLQueryAdapterByThisObject")
            End If

            Dim ReturnValue As New List(Of ObjectType)
            Dim AddItem As ObjectType = Nothing
            For Each EachItem As DataRow In UseSQLQueryAdapter.SelectQuery(SetQueryString).Rows
                AddItem = New ObjectType
                If Not IsNothing(SetSQLQueryAdapterByThisObject) Then
                    AddItem.SQLQueryAdapterByThisObject = SetSQLQueryAdapterByThisObject
                End If
                AddItem.CDBSetDataRowValueToObject(EachItem)
                ReturnValue.Add(AddItem)
            Next
            Return ReturnValue
        End Function

        Public Shared Function CDBSelect(Of ObjectType As {ClassDBSQLServer, New})(ByVal SetGetDataMoe As SQLServerSQLQueryAdapter.ConnectionMoeEnum, ByVal SetSQLServerName As SQLServerSQLQueryAdapter.ConnectServerNameEnum, ByVal SetConnectDBName As String, ByVal SetSourceQueryString As String) As List(Of ObjectType)
            Return CDBSelect(Of ObjectType)(SetSourceQueryString, New SQLServerSQLQueryAdapter(SetGetDataMoe, SetSQLServerName, SetConnectDBName))
        End Function

        Public Shared Function CDBSelect(Of ObjectType As {ClassDBSQLServer, New})(ByVal SetGetDataMoe As SQLServerSQLQueryAdapter.ConnectionMoeEnum, ByVal SetSourceQueryString As String) As List(Of ObjectType)
            Dim TempObject As ObjectType = New ObjectType
            Dim DefaultDBName As String = TempObject.CDBCurrentUseSQLQueryAdapter.ConnectDBName
            Dim DefaultDBServer As SQLServerSQLQueryAdapter.ConnectServerNameEnum = TempObject.CDBCurrentUseSQLQueryAdapter.SQLServerName
            Return CDBSelect(Of ObjectType)(SetSourceQueryString, New SQLServerSQLQueryAdapter(SetGetDataMoe, DefaultDBServer, DefaultDBName))
        End Function

#End Region
#Region "由資料庫更新物件 方法:CDBRefreshDataFromDataBase"
        ''' <summary>
        ''' 由資料庫更新物件
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CDBRefreshDataFromDataBase(Optional ByVal SetSQLQueryAdapterByThisObject As SQLServerSQLQueryAdapter = Nothing) As Boolean
            If Not IsNothing(SetSQLQueryAdapterByThisObject) Then
                Me.SQLQueryAdapterByThisObject = SetSQLQueryAdapterByThisObject
            End If
            If IsNothing(Me.SQLQueryAdapterByThisObject) Then
                Throw New Exception("請先設定本物件之SQLQueryAdapter或SQLQueryAdapterByThisObject")
            End If

            Dim GetDataRows As DataRowCollection = Me.SQLQueryAdapterByThisObject.SelectQuery(Me.CDBSelectByThisRecordSQLString).Rows
            If GetDataRows.Count > 1 Then
                Throw New Exception("以本物件主鍵取得資料有 " & GetDataRows.Count & " 筆,無法得知使用何筆資料更新本物件!")
            End If

            Return Me.CDBSetDataRowValueToObject(GetDataRows(0))

        End Function
#End Region
#Region "儲存(先更新如失敗則新增) 方法:CDBSave"
        ''' <summary>
        ''' 儲存
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function CDBSave() As Integer
            Dim SaveCount As Integer = 0
            SaveCount = CDBUpdate()
            If SaveCount < 1 Then
                SaveCount = CDBInsert()
            End If
            Return SaveCount

        End Function
#End Region



        '注意在這邊不可以複寫欄位名稱，因為在填值時(CDBSetDataRowValueToObject)還是使用原本名稱
        '#Region "[複寫]類別欄位 屬性:CDBClassFieldNames"
        '       
        '        Private _CDBClassFieldNames_Overrides As List(Of String)
        '        ''' <summary>
        '        ''' 類別欄位
        '        ''' </summary>
        '        ''' <value></value>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        '        Public Overrides ReadOnly Property CDBClassFieldNames() As List(Of String)
        '            Get

        '                If IsNothing(_CDBClassFieldNames_Overrides) Then
        '                    Dim MyBaseList As List(Of String) = MyBase.CDBClassFieldNames

        '                    For II As Integer = 0 To MyBaseList.Count - 1
        '                        MyBaseList(II) = CDBFs_CheckKeyWord_SQLServer(MyBaseList(II))
        '                    Next

        '                    _CDBClassFieldNames_Overrides = MyBaseList
        '                End If
        '                Return _CDBClassFieldNames_Overrides
        '            End Get
        '        End Property


        '#End Region









    End Class



End Namespace
