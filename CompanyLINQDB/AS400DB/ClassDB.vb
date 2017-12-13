Namespace ORMBaseClass

    Public MustInherit Class ClassDB

        Sub New(ByVal SetLibraryName As String, ByVal SetFileName As String)
            Me.CDBLibraryName = SetLibraryName
            Me.CDBFileName = SetFileName
        End Sub

        Sub New(ByVal SetLibraryName As String, ByVal SetFileName As String, ByVal SetMemberName As String)
            Me.CDBLibraryName = SetLibraryName
            Me.CDBFileName = SetFileName
            Me.CDBMemberName = SetMemberName
        End Sub

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



#Region "取得類別欄位使用者自訂屬性 方法:GetFieldCustomAttributes"
        ''' <summary>
        ''' 取得類別欄位使用者自訂屬性
        ''' </summary>
        ''' <typeparam name="CustomerType"></typeparam>
        ''' <param name="FieldName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetFieldCustomAttributes(Of CustomerType)(ByVal FieldName As String) As CustomerType
            'Dim ReturnValue As List(Of Object) = From A In Me.GetType.GetProperties Where A.Name = FieldName Select A.GetType.GetCustomAttributes(GetType(CustomerType), True).ToList
            'If IsNothing(ReturnValue) Then
            '    Return Nothing
            'End If
            'Return CType((From A In ReturnValue Select A).LastOrDefault, CustomerType)
            For Each EachItem As PropertyInfo In Me.GetType.GetProperties
                If EachItem.Name = FieldName Then
                    Dim GetCustAtt As List(Of Object) = EachItem.GetCustomAttributes(GetType(CustomerType), True).ToList
                    If GetCustAtt.Count = 0 Then
                        Return Nothing
                    Else
                        Return GetCustAtt(GetCustAtt.Count - 1)
                    End If
                End If
            Next
        End Function
#End Region
#Region "類別欄位 屬性:CDBClassFieldNames"

        Private _CDBClassFieldNames As List(Of String)
        ''' <summary>
        ''' 類別欄位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public ReadOnly Property CDBClassFieldNames() As List(Of String)
            Get
                If IsNothing(_CDBClassFieldNames) Then
                    _CDBClassFieldNames = (From A In CDBFieldsPropertyInfo Select A.Name).ToList
                End If
                Return _CDBClassFieldNames
            End Get
        End Property

#End Region


#Region "物件複製 方法:CDBClone"
        ''' <summary>
        ''' 物件複製
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CDBClone() As ClassDB
            Return Me.MemberwiseClone   '使用表層複製
        End Function
#End Region

#Region "PrimaryKey欄位PropertyInfo 屬性:CDBPKFieldsPropertyInfo"

        Private _CDBPKFieldsPropertyInfo As List(Of PropertyInfo) = Nothing
        ''' <summary>
        ''' PrimaryKey欄位PropertyInfo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CDBPKFieldsPropertyInfo() As List(Of PropertyInfo)
            Get
                If IsNothing(_CDBPKFieldsPropertyInfo) OrElse _CDBPKFieldsPropertyInfo.Count = 0 Then
                    _CDBPKFieldsPropertyInfo = New List(Of PropertyInfo)
                    For Each EachItem As PropertyInfo In Me.GetType.GetProperties
                        Dim GetCustomerProperty As SetCDBFieldAttribute = GetFieldCustomAttributes(Of SetCDBFieldAttribute)(EachItem.Name)
                        If Not IsNothing(GetCustomerProperty) AndAlso GetCustomerProperty.FieldType = SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey Then
                            _CDBPKFieldsPropertyInfo.Add(EachItem)
                        End If
                    Next
                End If
                Return _CDBPKFieldsPropertyInfo
            End Get
            Private Set(ByVal value As List(Of PropertyInfo))
                _CDBPKFieldsPropertyInfo = value
            End Set
        End Property
#End Region
#Region "資料庫欄位的PropertyInfo 屬性:CDBFieldsPropertyInfo"

        Private _CDBFieldsPropertyInfo As List(Of PropertyInfo) = New List(Of PropertyInfo)
        ''' <summary>
        ''' 資料庫欄位的PropertyInfo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CDBFieldsPropertyInfo() As List(Of PropertyInfo)
            Get
                If Not IsNothing(_CDBFieldsPropertyInfo) AndAlso _CDBFieldsPropertyInfo.Count > 0 Then
                    Return _CDBFieldsPropertyInfo
                End If
                For Each EachItem As PropertyInfo In Me.GetType.GetProperties
                    Dim GetCustomerProperty As SetCDBFieldAttribute = GetFieldCustomAttributes(Of SetCDBFieldAttribute)(EachItem.Name)
                    If IsNothing(GetCustomerProperty) OrElse GetCustomerProperty.FieldType <> SetCDBFieldAttribute.FieldTypeEnum.NotField Then
                        _CDBFieldsPropertyInfo.Add(EachItem)
                    End If
                Next
                Return _CDBFieldsPropertyInfo
            End Get
            Set(ByVal value As List(Of PropertyInfo))
                _CDBFieldsPropertyInfo = value
            End Set
        End Property

#End Region
#Region "取得類別屬性之值 方法:CDBGetFieldValue"
        ''' <summary>
        ''' 取得類別屬性之值
        ''' </summary>
        ''' <param name="FieldName"></param>
        ''' <param name="AttributeNIndex"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CDBGetFieldValue(ByVal FieldName As String, Optional ByVal AttributeNIndex As Object() = Nothing) As Object
            Dim myPropertyInfo As PropertyInfo = (From A In Me.CDBFieldsPropertyInfo Where A.Name = FieldName Select A).FirstOrDefault
            If myPropertyInfo Is Nothing Then
                Return Nothing
            Else
                Return myPropertyInfo.GetValue(Me, AttributeNIndex)
            End If

        End Function
#End Region
#Region "設定類別屬性之值 方法:CDBSetFieldValue"
        ''' <summary>
        ''' 設定類別屬性之值
        ''' </summary>
        ''' <param name="FieldName"></param>
        ''' <param name="AttributeNIndex"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CDBSetFieldValue(ByVal FieldName As String, ByVal SetValue As Object, Optional ByVal AttributeNIndex As Object() = Nothing) As Boolean
            '設定資料庫類別所有'屬性'之值
            Dim myPropertyInfo As PropertyInfo = (From A In Me.CDBFieldsPropertyInfo Where A.Name = FieldName Select A).FirstOrDefault
            If myPropertyInfo Is Nothing Then
                Return False
            End If

            If IsDBNull(SetValue) Then
                myPropertyInfo.SetValue(Me, Nothing, AttributeNIndex)
            Else
                Dim ConvertedSetValueObject As Object
                Try
                    ConvertedSetValueObject = Convert.ChangeType(SetValue, myPropertyInfo.PropertyType)
                Catch ex As Exception
                    ConvertedSetValueObject = SetValue
                End Try
                myPropertyInfo.SetValue(Me, ConvertedSetValueObject, AttributeNIndex)
            End If
            Return True

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

#Region "新增SQL字串 屬性:CDBInsertSQLString"
        ''' <summary>
        ''' 新增SQL字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CDBInsertSQLString() As String
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
        ReadOnly Property CDBUpdateSQLString() As String
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
                    If (From A In CDBPKFieldsPropertyInfo Select A.Name).Contains(EachColumn.Name) Then
                        PKString &= IIf(IsNothing(PKString), EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd, "," & EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd)
                    End If
                Next

                Return "Update @#" & Me.CDBLibraryName & "." & Me.CDBFileName & "." & Me.CDBMemberName & " Set " & FieldValueString & " Where " & PKString

            End Get
        End Property
#End Region
#Region "刪除SQL字串 屬性:CDBUpdateSQLString"
        ''' <summary>
        ''' 刪除SQL字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CDBDeleteSQLString() As String
            Get
                If CDBPKFieldsPropertyInfo.Count = 0 Then
                    Throw New Exception("必須有PrimaryKey")
                End If
                Dim ValueTypeSetAdd As String = Nothing
                Dim PKString As String = Nothing
                For Each EachColumn As PropertyInfo In Me.CDBFieldsPropertyInfo
                    ValueTypeSetAdd = IIf(EachColumn.PropertyType Is GetType(String), "'", Nothing)
                    If (From A In CDBPKFieldsPropertyInfo Select A.Name).Contains(EachColumn.Name) Then
                        PKString &= IIf(IsNothing(PKString), EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd, "," & EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd)
                    End If
                Next

                Return "Delete From @#" & Me.CDBLibraryName & "." & Me.CDBFileName & "." & Me.CDBMemberName & " Where " & PKString
            End Get
        End Property
#End Region
#Region "新增 方法:CDBInsert"
        ''' <summary>
        ''' 新增
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function CDBInsert() As Integer
            If CDBClassFieldNames.Count = 0 Then
                Return 0
            End If
            Return (New AS400SQLQuery).ExecuteNonQuery(CDBInsertSQLString)
        End Function
#End Region
#Region "更新 方法:CDBUpdate"
        ''' <summary>
        ''' 更新
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function CDBUpdate() As Integer
            If CDBClassFieldNames.Count = 0 Then
                Return 0
            End If
            Return (New AS400SQLQuery).ExecuteNonQuery(CDBUpdateSQLString)
        End Function
#End Region
#Region "刪除 方法:CDBDelete"
        ''' <summary>
        ''' 刪除
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function CDBDelete() As Integer
            If CDBClassFieldNames.Count = 0 Then
                Return 0
            End If
            Return (New AS400SQLQuery).ExecuteNonQuery(CDBDeleteSQLString)
        End Function
#End Region
#Region "查詢 方法:CDBSelect"
        ''' <summary>
        ''' 查詢
        ''' </summary>
        ''' <typeparam name="ObjectType"></typeparam>
        ''' <param name="FitSQLString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function CDBSelect(Of ObjectType As {ClassDB, New})(ByVal FitSQLString As String) As List(Of ObjectType)
            Return CDBSelect(Of ObjectType)(FitSQLString, Nothing, Nothing, Nothing)
        End Function
        ''' <summary>
        ''' 查詢
        ''' </summary>
        ''' <typeparam name="ObjectType"></typeparam>
        ''' <param name="FitSQLString"></param>
        ''' <param name="SetLibraryName"></param>
        ''' <param name="SetFileName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function CDBSelect(Of ObjectType As {ClassDB, New})(ByVal FitSQLString As String, ByVal SetLibraryName As String, ByVal SetFileName As String) As List(Of ObjectType)
            Return CDBSelect(Of ObjectType)(FitSQLString, SetLibraryName, SetFileName, Nothing)
        End Function
        ''' <summary>
        ''' 查詢
        ''' </summary>
        ''' <typeparam name="ObjectType"></typeparam>
        ''' <param name="FitSQLString"></param>
        ''' <param name="SetLibraryName"></param>
        ''' <param name="SetFileName"></param>
        ''' <param name="SetMemberName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function CDBSelect(Of ObjectType As {ClassDB, New})(ByVal FitSQLString As String, ByVal SetLibraryName As String, ByVal SetFileName As String, ByVal SetMemberName As String) As List(Of ObjectType)
            Dim DBService As New AS400SQLQuery
            Dim ReturnValue As New List(Of ObjectType)
            Dim AS400QueryResult As DataTable = DBService.SelectQuery(FitSQLString)

            Dim AddItem As ObjectType = New ObjectType
            'Dim MachColumns As List(Of DataColumn) = (From A In AS400QueryResult.Columns Where (From B In AddItem.CDBFieldsPropertyInfo Select B.GetType.Name.ToUpper).Contains(CType(A, DataColumn).ColumnName.ToUpper) Select CType(A, DataColumn)).ToList
            'Dim MachColumns As New List(Of DataColumn)
            'For Each EachColumn As DataColumn In AS400QueryResult.Columns
            '    If AddItem.CDBClassFieldNames.Contains(EachColumn.ColumnName) Then
            '        MachColumns.Add(EachColumn)
            '    End If
            'Next
            For Each EachItem As DataRow In AS400QueryResult.Rows
                AddItem = New ObjectType
                AddItem.CDBSetDataRowValueToObject(EachItem)
                ReturnValue.Add(AddItem)
            Next

            Return ReturnValue
        End Function

#End Region
#Region "設定DataRow值給資料庫類別物件 方法:CDBSetDataRowValueToObject"
        ''' <summary>
        ''' 設定DataRow值給資料庫類別物件
        ''' </summary>
        ''' <param name="SourceDataRow"></param>
        ''' <param name="AttributeNIndex"></param>
        ''' <param name="JumpLessDataRowField">給值發生錯誤時是否要忽略</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CDBSetDataRowValueToObject(ByVal SourceDataRow As DataRow, Optional ByVal AttributeNIndex As Object() = Nothing, Optional ByVal JumpLessDataRowField As Boolean = False) As Boolean
            '設定DataRow值給資料庫類別物件
            If IsNothing(SourceDataRow) Then
                Throw New Exception("SourceDataRowValueFromObject's 'SetDataRow' Can't be Nothing")
            End If
            Dim TableColumnNames As New List(Of String)
            For Each EachColumn As DataColumn In SourceDataRow.Table.Columns
                TableColumnNames.Add(EachColumn.ColumnName)
            Next
            For Each EachFieldName As String In From A In CDBClassFieldNames Where TableColumnNames.Contains(A) Select A
                Try
                    CDBSetFieldValue(EachFieldName, SourceDataRow.Item(EachFieldName), AttributeNIndex)
                Catch ex1 As ArgumentException
                    If Not JumpLessDataRowField Then
                        Throw New ArgumentException("Can Find Field '" & EachFieldName & "' In DataRow:" & vbNewLine & ex1.ToString)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.ToString)
                    Return False
                End Try
            Next
            Return True
        End Function

#End Region
#Region "設定資料表產生物件集合 Shared方法:CDBSetDataTableToObjects"
        ''' <summary>
        ''' 設定資料表產生物件集合
        ''' </summary>
        ''' <typeparam name="OutputType"></typeparam>
        ''' <param name="SourceData"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CDBSetDataTableToObjects(Of OutputType As {New, ClassDB})(ByVal SourceData As DataTable) As List(Of OutputType)
            Dim ReturnValue As New List(Of OutputType)
            For Each EachRow As DataRow In SourceData.Rows
                Dim AddItem As New OutputType
                AddItem.CDBSetDataRowValueToObject(EachRow)
                ReturnValue.Add(AddItem)
            Next
            Return ReturnValue
        End Function
#End Region



    End Class

#Region "設定屬性類別 類別:SetCDBFieldAttribute"
    <AttributeUsage(AttributeTargets.Property)> _
    Public Class SetCDBFieldAttribute
        Inherits System.Attribute

#Region "是否為資料庫欄位 屬性:FieldType"
        Private _FieldType As FieldTypeEnum
        ''' <summary>
        ''' 是否為資料庫欄位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FieldType() As FieldTypeEnum
            Get
                Return _FieldType
            End Get
            Private Set(ByVal value As FieldTypeEnum)
                _FieldType = value
            End Set
        End Property
#End Region

#Region "建構 函式:New"
        Public Sub New(ByVal SetFieldType As FieldTypeEnum)
            FieldType = SetFieldType
        End Sub
#End Region

        Public Enum FieldTypeEnum
            FieldOnly = 0
            FieldAndPrimaryKey = 1
            NotField = 99
        End Enum
    End Class
#End Region

End Namespace
