Namespace ORMBaseClass
    Public Class ClassDBAS400
        Inherits ClassDB
        Implements IClassDBInherited


        Sub New(ByVal SetLibraryName As String, ByVal SetFileName As String)
            Me.CDBLibraryName = SetLibraryName
            Me.CDBFileName = SetFileName
        End Sub

        Sub New(ByVal SetLibraryName As String, ByVal SetFileName As String, ByVal SetMemberName As String)
            Me.CDBLibraryName = SetLibraryName
            Me.CDBFileName = SetFileName
            Me.CDBMemberName = SetMemberName
        End Sub

        Sub New(ByVal SetLibraryName As String, ByVal SetFileName As String, ByVal SetSQLQueryAdapterByThisObject As AS400SQLQueryAdapter)
            Me.CDBLibraryName = SetLibraryName
            Me.CDBFileName = SetFileName
            Me.SQLQueryAdapterByThisObject = SetSQLQueryAdapterByThisObject
        End Sub

        Sub New(ByVal SetLibraryName As String, ByVal SetFileName As String, ByVal SetMemberName As String, ByVal SetSQLQueryAdapterByThisObject As AS400SQLQueryAdapter)
            Me.CDBLibraryName = SetLibraryName
            Me.CDBFileName = SetFileName
            Me.CDBMemberName = SetMemberName
            Me.SQLQueryAdapterByThisObject = SetSQLQueryAdapterByThisObject
        End Sub

#Region "LocalSQL查詢轉接器For此物件 屬性:SQLQueryAdapterByThisObject"
        Private _SQLQueryAdapterByThisObject As AS400SQLQueryAdapter
        ''' <summary>
        ''' LocalSQL查詢轉接器For此物件
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property SQLQueryAdapterByThisObject() As AS400SQLQueryAdapter
            Get
                Return _SQLQueryAdapterByThisObject
            End Get
            Set(ByVal value As AS400SQLQueryAdapter)
                _SQLQueryAdapterByThisObject = value
            End Set
        End Property
#End Region
#Region "SQL查詢轉接器 屬性:SQLQueryAdapter"

        Private Shared _SQLQueryAdapter As AS400SQLQueryAdapter
        ''' <summary>
        ''' SQL查詢轉接器
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SQLQueryAdapter() As AS400SQLQueryAdapter
            Get
                'If IsNothing(_SQLQueryAdapter) Then
                '    _SQLQueryAdapter = New AS400SQLQueryAdapter
                'End If
                Return _SQLQueryAdapter
            End Get
            Set(ByVal value As AS400SQLQueryAdapter)
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
        ReadOnly Property CDBCurrentUseSQLQueryAdapter() As AS400SQLQueryAdapter
            Get
                If Not IsNothing(Me.SQLQueryAdapterByThisObject) Then
                    Return Me.SQLQueryAdapterByThisObject
                End If
                Return ClassDBAS400.SQLQueryAdapter
            End Get
        End Property
#End Region


#Region "Library名稱 屬性:CDBLibraryName"

        Private _CDBLibraryName As String
        ''' <summary>
        ''' Library名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Overridable Property CDBLibraryName() As String
            Get
                Return _CDBLibraryName
            End Get
            Set(ByVal value As String)
                _CDBLibraryName = value
            End Set
        End Property

#End Region
#Region "FileName 屬性:CDBFileName"


        Private _CDBFileName As String
        ''' <summary>
        ''' FileName
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Overridable Property CDBFileName() As String
            Get
                Return _CDBFileName
            End Get
            Set(ByVal value As String)
                _CDBFileName = value
            End Set
        End Property


#End Region
#Region "MemberName 屬性:CDBMemberName"

        Private _CDBMemberName As String
        ''' <summary>
        ''' MemberName
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Overridable Property CDBMemberName() As String
            Get
                If IsNothing(_CDBMemberName) Then
                    Return Me.CDBFileName
                End If
                Return _CDBMemberName
            End Get
            Set(ByVal value As String)
                _CDBMemberName = value
            End Set
        End Property

#End Region
#Region "完整AS400檔案路徑 屬性:CDBFullAS400DBPath"
        ''' <summary>
        ''' 完整AS400檔案路徑
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CDBFullAS400DBPath() As String
            Get
                Dim ReturnValue As String = " @#"
                If CDBFileName = CDBMemberName Then
                    ReturnValue &= CDBLibraryName & "." & CDBFileName & " "
                Else
                    ReturnValue &= CDBLibraryName & "." & CDBFileName & "." & CDBMemberName & " "
                End If
                Return ReturnValue
            End Get
        End Property
#End Region



#Region "新增SQL字串 屬性:CDBInsertSQLString"
        ''' <summary>
        ''' 新增SQL字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Overrides ReadOnly Property CDBInsertSQLString() As String
            Get
                Dim FieldString As String = Nothing
                Dim ValueString As String = Nothing
                Dim ValueTypeSetAdd As String = Nothing
                For Each EachColumn As PropertyInfo In CDBFieldsPropertyInfo
                    ValueTypeSetAdd = IIf(EachColumn.PropertyType Is GetType(String), "'", Nothing)
                    FieldString &= IIf(IsNothing(FieldString), EachColumn.Name, "," & EachColumn.Name)
                    ValueString &= IIf(IsNothing(ValueString), ValueTypeSetAdd & EachColumn.GetValue(Me, Nothing) & ValueTypeSetAdd, "," & ValueTypeSetAdd & CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd)
                Next
                Return "Insert into @#" & Me.CDBLibraryName & "." & Me.CDBFileName & "." & Me.CDBMemberName & " (" & FieldString & ") Values (" & ValueString & ")"
            End Get
        End Property
#End Region
#Region "更新SQL字串 屬性:CDBUpdateSQLString"
        ''' <summary>
        ''' 更新SQL字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Overrides ReadOnly Property CDBUpdateSQLString() As String
            Get
                If CDBPKFieldsPropertyInfo.Count = 0 Then
                    Throw New Exception("必須有PrimaryKey")
                End If
                Dim ValueTypeSetAdd As String = Nothing

                Dim FieldValueString As String = Nothing
                Dim PKString As String = Nothing
                For Each EachColumn As PropertyInfo In Me.CDBFieldsPropertyInfo
                    ValueTypeSetAdd = IIf(EachColumn.PropertyType Is GetType(String), "'", Nothing)
                    FieldValueString &= IIf(IsNothing(FieldValueString), EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd, "," & EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd)
                    For Each EachItem As PropertyInfo In CDBPKFieldsPropertyInfo
                        If EachItem.Name = EachColumn.Name Then
                            PKString &= IIf(IsNothing(PKString), EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd, " AND " & EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd)
                            Exit For
                        End If
                    Next
                Next

                Return "Update @#" & Me.CDBLibraryName & "." & Me.CDBFileName & "." & Me.CDBMemberName & " Set " & FieldValueString & " Where " & PKString

            End Get
        End Property
#End Region
#Region "刪除SQL字串 屬性:CDBDeleteSQLString"
        ''' <summary>
        ''' 刪除SQL字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Overrides ReadOnly Property CDBDeleteSQLString() As String
            Get
                If CDBPKFieldsPropertyInfo.Count = 0 Then
                    Throw New Exception("必須有PrimaryKey")
                End If
                Dim ValueTypeSetAdd As String = Nothing
                Dim PKString As String = Nothing
                For Each EachColumn As PropertyInfo In Me.CDBFieldsPropertyInfo
                    ValueTypeSetAdd = IIf(EachColumn.PropertyType Is GetType(String), "'", Nothing)
                    For Each EachItem As PropertyInfo In CDBPKFieldsPropertyInfo
                        If EachItem.Name = EachColumn.Name Then
                            PKString &= IIf(IsNothing(PKString), EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd, " AND " & EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd)
                            Exit For
                        End If
                    Next
                Next

                Return "Delete From @#" & Me.CDBLibraryName & "." & Me.CDBFileName & "." & Me.CDBMemberName & " Where " & PKString
            End Get
        End Property
#End Region
#Region "資料增刪修事件 事件:CDBDataInsertUpdateDeleteEvent"
        ''' <summary>
        ''' 資料增刪修事件
        ''' </summary>
        ''' <param name="DBObject"></param>
        ''' <param name="DataInsertUpdateDeleteKind"></param>
        ''' <remarks></remarks>
        Public Event CDBDataInsertUpdateDeletedEvent(DBObject As ClassDB, DataInsertUpdateDeleteKind As IClassDBInherited.DataInsertUpdateDeleteType) Implements IClassDBInherited.CDBDataInsertUpdateDeletedEvent
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

            Dim ReturnValue As Integer = 0
            If IsNothing(Me.SQLQueryAdapterByThisObject) Then
                ReturnValue = SQLQueryAdapter.ExecuteNonQuery(CDBInsertSQLString)
            Else
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
            Dim ReturnValue As Integer = 0
            If IsNothing(Me.SQLQueryAdapterByThisObject) Then
                ReturnValue = SQLQueryAdapter.ExecuteNonQuery(CDBDeleteSQLString)
            Else
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
        ''' <param name="FitSQLString"></param>
        ''' <param name="SetSQLQueryAdapterByThisObject"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.DataObjectMethod(DataObjectMethodType.Select)> _
        Public Overloads Shared Function CDBSelect(Of ObjectType As {ClassDBAS400, New})(ByVal FitSQLString As String, Optional ByVal SetSQLQueryAdapterByThisObject As AS400SQLQueryAdapter = Nothing) As List(Of ObjectType)
            If IsNothing(FitSQLString) Then
                Return Nothing
            End If

            Dim UseSQLQueryAdapter As AS400SQLQueryAdapter = SetSQLQueryAdapterByThisObject
            If IsNothing(UseSQLQueryAdapter) Then
                UseSQLQueryAdapter = SQLQueryAdapter
            End If
            If IsNothing(UseSQLQueryAdapter) Then
                UseSQLQueryAdapter = (New ObjectType).SQLQueryAdapterByThisObject
            End If
            If IsNothing(UseSQLQueryAdapter) Then
                Throw New Exception("請先設定本物件之SQLQueryAdapter或SQLQueryAdapterByThisObject")
            End If



            'Dim MachColumns As List(Of DataColumn) = (From A In AS400QueryResult.Columns Where (From B In AddItem.CDBFieldsPropertyInfo Select B.GetType.Name.ToUpper).Contains(CType(A, DataColumn).ColumnName.ToUpper) Select CType(A, DataColumn)).ToList
            'Dim MachColumns As New List(Of DataColumn)
            'For Each EachColumn As DataColumn In AS400QueryResult.Columns
            '    If AddItem.CDBClassFieldNames.Contains(EachColumn.ColumnName) Then
            '        MachColumns.Add(EachColumn)
            '    End If
            'Next
            Dim ASS400QueryLibraryAndFileAndMemberName As List(Of String) = GetASS400QueryLibraryAndFileAndMemberName(FitSQLString)
            If ASS400QueryLibraryAndFileAndMemberName.Count < 2 Then
                Throw New Exception("查詢指令中資料來源有誤 ex:Select x from @#LibraryXX.FileXX.MemberXX")
            End If
            Dim SetLibraryName As String = ASS400QueryLibraryAndFileAndMemberName.Item(0).Replace(UseSQLQueryAdapter.SQLFromDBMemberIndicatory, Nothing)
            Dim SetFileName As String = ASS400QueryLibraryAndFileAndMemberName.Item(1)
            Dim SetMemberName As String = Nothing
            If ASS400QueryLibraryAndFileAndMemberName.Count > 2 Then
                SetMemberName = ASS400QueryLibraryAndFileAndMemberName.Item(2)
            End If

            Dim AddItem As ObjectType = Nothing
            Dim ReturnValue As New List(Of ObjectType)
            For Each EachItem As DataRow In UseSQLQueryAdapter.SelectQuery(FitSQLString).Rows
                AddItem = New ObjectType
                With AddItem
                    If Not IsNothing(SetSQLQueryAdapterByThisObject) Then
                        .SQLQueryAdapterByThisObject = SetSQLQueryAdapterByThisObject
                    End If
                    .CDBLibraryName = SetLibraryName
                    .CDBFileName = SetFileName
                    .CDBMemberName = SetMemberName
                    .CDBSetDataRowValueToObject(EachItem)
                End With
                ReturnValue.Add(AddItem)
            Next

            Return ReturnValue
        End Function

        Public Overloads Shared Function CDBSelect(Of ObjectType As {ClassDBAS400, New})(ByVal FitSQLString As String, ByVal SetGetDataMoe As AS400SQLQueryAdapter.ConnectionMoeEnum) As List(Of ObjectType)
            Return CDBSelect(Of ObjectType)(FitSQLString, New AS400SQLQueryAdapter(SetGetDataMoe))
        End Function

        Private Shared Function GetASS400QueryLibraryAndFileAndMemberName(ByVal SourceAS400String As String) As List(Of String)
            Dim ReturnValue As List(Of String) = New List(Of String)
            For Each EachItem As String In SourceAS400String.Split(" ")
                If EachItem.StartsWith("@#") Then
                    For Each EachItemValue As String In EachItem.Split(".")
                        ReturnValue.Add(EachItemValue.Trim)
                    Next
                    Return ReturnValue
                End If
            Next
            Return ReturnValue
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

        Public Shared Function CDBSave(ByVal SourceObject As ClassDBAS400) As Integer
            Return SourceObject.CDBSave()
        End Function
#End Region


        '#Region "找尋資料 方法:CDBFindObject"
        '        Shared Function CDBFindObject(Of ObjectType As {New, ClassDB})(ByVal FieldNames() As String, ByVal ParamArray AA() As Object) As List(Of ObjectType)
        '            CDBFindObject(Of ClassDBAS400 )(
        '        End Function

        '#End Region

    End Class
End Namespace
