Namespace ORMBaseClass
    <Serializable()> _
    Public MustInherit Class ClassDB
        Implements IClassDB
        Implements ISerializable


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
                    Dim GetCustAtt() As Object = EachItem.GetCustomAttributes(GetType(CustomerType), True)

                    If GetCustAtt.Length = 0 Then
                        Return Nothing
                    Else
                        Return GetCustAtt(GetCustAtt.Length - 1)
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
        Public Overridable ReadOnly Property CDBClassFieldNames() As List(Of String)
            Get
                If IsNothing(_CDBClassFieldNames) Then
                    _CDBClassFieldNames = New List(Of String)
                    For Each EachItem As System.Reflection.PropertyInfo In CDBFieldsPropertyInfo
                        _CDBClassFieldNames.Add(EachItem.Name)
                    Next
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
        Public Function CDBGetFieldValue(ByVal FieldName As String, Optional ByVal AttributeNIndex As Object() = Nothing) As Object Implements IClassDB.CDBGetFieldValue
            Dim myPropertyInfo As PropertyInfo = Nothing ' (From A In Me.CDBFieldsPropertyInfo Where A.Name = FieldName Select A).FirstOrDefault
            For Each EachItem As PropertyInfo In Me.CDBFieldsPropertyInfo
                If EachItem.Name = FieldName Then
                    myPropertyInfo = EachItem
                    Exit For
                End If
            Next

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
        Function CDBSetFieldValue(ByVal FieldName As String, ByVal SetValue As Object, Optional ByVal AttributeNIndex As Object() = Nothing) As Boolean
            '設定資料庫類別所有'屬性'之值
            Dim myPropertyInfo As PropertyInfo = Nothing
            For Each EachItem As PropertyInfo In Me.CDBFieldsPropertyInfo
                If EachItem.Name = FieldName Then
                    myPropertyInfo = EachItem
                    Exit For
                End If
            Next
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


#Region "新增SQL字串 屬性:CDBInsertSQLString"
        ''' <summary>
        ''' 新增SQL字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Overridable ReadOnly Property CDBInsertSQLString() As String
            Get
                Dim FieldString As String = Nothing
                Dim ValueString As String = Nothing
                Dim ValueTypeSetAdd As String = Nothing
                Dim ColumnName1 As String = Nothing
                For Each EachColumn As PropertyInfo In CDBFieldsPropertyInfo
                    ValueTypeSetAdd = IIf(EachColumn.PropertyType Is GetType(String) OrElse EachColumn.PropertyType Is GetType(DateTime), "'", Nothing)

                    'FieldString &= IIf(IsNothing(FieldString), EachColumn.Name, "," & EachColumn.Name)
                    If TypeOf Me Is ClassDBSQLServer Then
                        ColumnName1 = CDBFs_CheckKeyWord_SQLServer(EachColumn.Name)
                    Else
                        ColumnName1 = EachColumn.Name
                    End If
                    FieldString &= IIf(IsNothing(FieldString), ColumnName1, "," & ColumnName1)

                    ValueString &= IIf(IsNothing(ValueString), ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(EachColumn.GetValue(Me, Nothing)) & ValueTypeSetAdd, "," & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd)
                Next
                Dim TypeStrings() As String = Me.GetType.ToString.Split(".")
                Return "Insert into " & TypeStrings(TypeStrings.Length - 1) & " (" & FieldString & ") Values (" & ValueString & ")"
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
        Overridable ReadOnly Property CDBUpdateSQLString() As String
            Get
                If CDBPKFieldsPropertyInfo.Count = 0 Then
                    Throw New Exception("必須有PrimaryKey")
                End If
                Dim ValueTypeSetAdd As String = Nothing

                Dim FieldValueString As String = Nothing
                Dim PKString As String = Nothing
                Dim ColumnName1 As String = Nothing
                For Each EachColumn As PropertyInfo In Me.CDBFieldsPropertyInfo
                    ValueTypeSetAdd = IIf(EachColumn.PropertyType Is GetType(String) OrElse EachColumn.PropertyType Is GetType(DateTime), "'", Nothing)

                    'FieldValueString &= IIf(IsNothing(FieldValueString), EachColumn.Name & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd, "," & EachColumn.Name & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd)
                    If TypeOf Me Is ClassDBSQLServer Then
                        ColumnName1 = CDBFs_CheckKeyWord_SQLServer(EachColumn.Name)
                    Else
                        ColumnName1 = EachColumn.Name
                    End If
                    FieldValueString &= IIf(IsNothing(FieldValueString), ColumnName1 & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd, "," & ColumnName1 & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd)

                    For Each EachItem As PropertyInfo In CDBPKFieldsPropertyInfo
                        If EachItem.Name = EachColumn.Name Then
                            'PKString &= IIf(IsNothing(PKString), EachColumn.Name & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd, " AND " & EachColumn.Name & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd)
                            PKString &= IIf(IsNothing(PKString), ColumnName1 & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd, " AND " & ColumnName1 & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd)
                            Exit For
                        End If
                    Next
                Next
                Dim TypeStrings() As String = Me.GetType.ToString.Split(".")
                Return "Update " & TypeStrings(TypeStrings.Length - 1) & " Set " & FieldValueString & " Where " & PKString

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
        Overridable ReadOnly Property CDBDeleteSQLString() As String
            Get
                If CDBPKFieldsPropertyInfo.Count = 0 Then
                    Throw New Exception("必須有PrimaryKey")
                End If
                Dim ValueTypeSetAdd As String = Nothing
                Dim PKString As String = Nothing
                Dim ColumnName1 As String = Nothing
                For Each EachColumn As PropertyInfo In Me.CDBFieldsPropertyInfo
                    ValueTypeSetAdd = IIf(EachColumn.PropertyType Is GetType(String) OrElse EachColumn.PropertyType Is GetType(DateTime), "'", Nothing)
                    For Each EachItem As PropertyInfo In CDBPKFieldsPropertyInfo
                        If EachItem.Name = EachColumn.Name Then
                            'PKString &= IIf(IsNothing(PKString), EachColumn.Name & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd, " AND " & EachColumn.Name & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd)
                            If TypeOf Me Is ClassDBSQLServer Then
                                ColumnName1 = CDBFs_CheckKeyWord_SQLServer(EachColumn.Name)
                            Else
                                ColumnName1 = EachColumn.Name
                            End If
                            PKString &= IIf(IsNothing(PKString), ColumnName1 & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd, " AND " & ColumnName1 & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd)

                            Exit For
                        End If
                    Next
                Next

                Dim TypeStrings() As String = Me.GetType.ToString.Split(".")
                Return "Delete From " & TypeStrings(TypeStrings.Length - 1) & " Where " & PKString
            End Get
        End Property
#End Region
#Region "查詢此筆資料SQL字串 屬性:CDBSelectByThisRecordSQLString"
        ''' <summary>
        ''' 查詢此筆資料SQL字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Overridable ReadOnly Property CDBSelectByThisRecordSQLString() As String
            Get
                If CDBPKFieldsPropertyInfo.Count = 0 Then
                    Throw New Exception("必須有PrimaryKey")
                End If
                Dim ValueTypeSetAdd As String = Nothing
                Dim PKString As String = Nothing
                For Each EachColumn As PropertyInfo In Me.CDBFieldsPropertyInfo
                    ValueTypeSetAdd = IIf(EachColumn.PropertyType Is GetType(String) OrElse EachColumn.PropertyType Is GetType(DateTime), "'", Nothing)
                    For Each EachItem As PropertyInfo In CDBPKFieldsPropertyInfo
                        If EachItem.Name = EachColumn.Name Then
                            PKString &= IIf(IsNothing(PKString), EachColumn.Name & "=" & ValueTypeSetAdd & Me.CDBGetFieldValue(EachColumn.Name) & ValueTypeSetAdd, " AND " & EachColumn.Name & "=" & ValueTypeSetAdd & ORMDataTypeChangeSqlServerDataType(Me.CDBGetFieldValue(EachColumn.Name)) & ValueTypeSetAdd)
                            Exit For
                        End If
                    Next
                Next

                Dim TypeStrings() As String = Me.GetType.ToString.Split(".")
                Return "Select * From " & TypeStrings(TypeStrings.Length - 1) & " Where " & PKString
            End Get
        End Property
#End Region
#Region "物件資料型別轉換SQLServer資料型別 方法:ORMDataTypeChangeSqlServerDataType"
        ''' <summary>
        ''' 物件資料型別轉換SQLServer資料型別
        ''' </summary>
        ''' <param name="OrginData"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ORMDataTypeChangeSqlServerDataType(ByVal OrginData As Object) As String
            Select Case True
                Case TypeOf OrginData Is Boolean
                    Return IIf(OrginData = True, "1", "0")
                Case TypeOf OrginData Is DateTime
                    Return Format(OrginData, "yyyy/MM/dd HH:mm:ss")
            End Select
            Return OrginData
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
            Me.CDBOrginDataRow = SourceDataRow
            Dim TableColumnNames As New List(Of String)
            For Each EachColumn As DataColumn In SourceDataRow.Table.Columns
                TableColumnNames.Add(EachColumn.ColumnName)
            Next
            For Each EachFieldName As String In CDBClassFieldNames
                If IsHaveFieldNameInTableColumnNames(TableColumnNames, EachFieldName) Then
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
                End If
            Next
            Return True
        End Function
        Protected Function IsHaveFieldNameInTableColumnNames(ByVal SourceTableColumnNames As List(Of String), ByVal FindTableColumnName As String) As Boolean
            Dim FindTableColumnName1 As String = FindTableColumnName.ToUpper
            For Each EachItem As String In SourceTableColumnNames
                If EachItem.ToUpper = FindTableColumnName1 Then
                    Return True
                End If
            Next
            Return False
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
#Region "原始資料DataRow 屬性:CDBOrginDataRow"
        Private _CDBOrginDataRow As DataRow
        ''' <summary>
        ''' 原始資料DataRow
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CDBOrginDataRow() As DataRow
            Get
                Return _CDBOrginDataRow
            End Get
            Private Set(ByVal value As DataRow)
                _CDBOrginDataRow = value
            End Set
        End Property


#End Region


#Region "屬性欄位名稱集合 屬性:CDBClassDBPropertyFieldNames"
        Private _ClassDBPropertyFieldNames As List(Of String)
        ''' <summary>
        ''' 屬性欄位名稱集合
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public ReadOnly Property CDBClassDBPropertyFieldNames() As IList(Of String) Implements IClassDB.CDBClassDBPropertyFieldNames
            Get
                '取得資料庫類別所有'屬性'為資料庫欄位(具存在於實體資料庫)的屬性名稱
                If IsNothing(_ClassDBPropertyFieldNames) Then '判斷是否為第一次建立，如果為是則搜尋類別
                    _ClassDBPropertyFieldNames = New List(Of String)
                    For Each myPropertyInfo As PropertyInfo In Me.GetType.GetProperties
                        Dim CustAttributeObjs() As SetCDBFieldAttribute  'SetIsClassDBAttribute
                        CustAttributeObjs = myPropertyInfo.GetCustomAttributes(GetType(SetCDBFieldAttribute), True)
                        Dim IsClassDBField As Boolean = True
                        If CustAttributeObjs.Length > 0 Then
                            Dim EachSetIsClassDBAttribute As SetCDBFieldAttribute
                            For Each EachSetIsClassDBAttribute In CustAttributeObjs
                                IsClassDBField = (EachSetIsClassDBAttribute.FieldType <> SetCDBFieldAttribute.FieldTypeEnum.NotField)
                            Next
                        End If
                        If IsClassDBField Then
                            _ClassDBPropertyFieldNames.Add(myPropertyInfo.Name)
                        End If
                    Next
                    _ClassDBPropertyFieldNames.TrimExcess()
                End If

                Return _ClassDBPropertyFieldNames

            End Get
        End Property

#End Region

#Region "取得資料庫類別所有屬性之資料形態 方法:CDBGetClassDBFieldType"
        ''' <summary>
        ''' 取得資料庫類別所有屬性之資料形態(注意:AttributeNIndex未完成)
        ''' </summary>
        ''' <param name="FieldName"></param>
        ''' <param name="AttributeNIndex"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CDBGetClassDBFieldType(ByVal FieldName As String, Optional ByVal AttributeNIndex As Object() = Nothing) As Type Implements IClassDB.CDBGetClassDBFieldType
            '取得資料庫類別所有屬性之資料形態(注意:AttributeNIndex未完成)
            Dim GetFieldType As Type
            Static FieldTypeHashTable As Hashtable
            If IsNothing(FieldTypeHashTable) Then
                FieldTypeHashTable = New Hashtable
                Dim myFieldList As IEnumerator = Me.CDBClassDBPropertyFieldNames.GetEnumerator
                Do While myFieldList.MoveNext
                    Dim GetFieldName As String = CType(myFieldList.Current, String)
                    GetFieldType = Nothing

                    If IsNothing(GetFieldType) Then
                        Dim myPropertyInfo As PropertyInfo = CDBGetClassDBVariablePropertyInfo(GetFieldName)
                        If Not IsNothing(myPropertyInfo) Then
                            Dim CustAttributeObjs() As SetCDBFieldAttribute
                            CustAttributeObjs = myPropertyInfo.GetCustomAttributes(GetType(SetCDBFieldAttribute), True)
                            Dim IsClassDBField As Boolean = True
                            If CustAttributeObjs.Length > 0 Then
                                Dim EachSetIsClassDBAttribute As SetCDBFieldAttribute
                                For Each EachSetIsClassDBAttribute In CustAttributeObjs
                                    IsClassDBField = (EachSetIsClassDBAttribute.FieldType <> SetCDBFieldAttribute.FieldTypeEnum.NotField)
                                Next
                            End If
                            If IsClassDBField Then
                                'GetFieldType = myPropertyInfo.GetValue(Me, AttributeNIndex).GetType
                                GetFieldType = myPropertyInfo.PropertyType
                            End If
                        End If
                    End If

                    If Not IsNothing(GetFieldType) Then
                        FieldTypeHashTable.Add(GetFieldName, GetFieldType)
                    End If
                Loop
            End If
            Return FieldTypeHashTable(FieldName)
        End Function

#End Region

#Region "取得公用變數的PropertyInfo 方法:CDBGetClassDBVariablePropertyInfo"
        ''' <summary>
        ''' 取得公用變數的PropertyInfo
        ''' </summary>
        ''' <param name="FieldName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function CDBGetClassDBVariablePropertyInfo(ByVal FieldName As String) As PropertyInfo
            '取得公用變數的PropertyInfo
            FieldName = UCase(FieldName)
            Static FieldHashTable As Hashtable
            If IsNothing(FieldHashTable) Then
                FieldHashTable = New Hashtable
                Dim EachPropertyNames As IEnumerator = Me.CDBClassDBPropertyFieldNames.GetEnumerator
                Do While EachPropertyNames.MoveNext
                    Dim myPropertyInfo As PropertyInfo
                    For Each myPropertyInfo In Me.GetType.GetProperties
                        If UCase(CType(EachPropertyNames.Current, String)) = UCase(myPropertyInfo.Name) Then
                            FieldHashTable.Add(UCase(myPropertyInfo.Name), myPropertyInfo)
                            Exit For
                        End If
                    Next

                Loop
            End If

            If IsNothing(FieldHashTable.Item(FieldName)) Then
                Return Nothing
            End If
            Return FieldHashTable.Item(FieldName)
        End Function

#End Region

#Region "實現(ISerializable.GetObjectData)序列化資料 方法:CDBGetObjectData"
        ''' <summary>
        ''' 實現(ISerializable.GetObjectData)序列化資料
        ''' </summary>
        ''' <param name="info"></param>
        ''' <param name="context"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub CDBGetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
            Try
                '將本元件儲存資訊序列化
                For Each EachItem As String In Me.CDBClassDBPropertyFieldNames
                    info.AddValue(EachItem, Me.CDBGetFieldValue(EachItem))
                Next
            Catch ex As Exception
                MsgBox("SerializationInfo Sub GetObjectData Function  HaveDataError!")
            End Try
        End Sub
#End Region
#Region "反序列化建構函式 函式:CDBUnSerializeNEW"
        ''' <summary>
        ''' 反序列化建構函式
        ''' </summary>
        ''' <param name="info"></param>
        ''' <param name="context"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub CDBUnSerializeNEW(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements IClassDB.CDBUnSerializeNEW
            Try
                For Each EachItem As String In Me.CDBClassDBPropertyFieldNames 'CDBGetClassDBFieldNames
                    Me.CDBSetFieldValue(EachItem, info.GetValue(EachItem, Me.CDBGetClassDBFieldType(EachItem)))
                Next
            Catch ex As Exception
                MsgBox("UnSerializationInfo Sub New Function HaveDataError!")
            End Try
        End Sub

#End Region


#Region "MVC 屬性:CDBCRUDXml"
        Private _CDBCRUDClass As String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CDBCRUDClass As String
            Get
                Return _CDBCRUDClass
            End Get
            Set(value As String)
                _CDBCRUDClass = value
            End Set
        End Property

        Private _CDBCRUDXmlSource As String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CDBCRUDXmlSource As String
            Get
                Return _CDBCRUDXmlSource
            End Get
            Set(value As String)
                _CDBCRUDXmlSource = value
            End Set
        End Property

        Private _CDBCRUDXmlInsert As String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CDBCRUDXmlInsert As String
            Get
                Return _CDBCRUDXmlInsert
            End Get
            Set(value As String)
                _CDBCRUDXmlInsert = value
            End Set
        End Property

        Private _CDBCRUDXmlUpdate As String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CDBCRUDXmlUpdate As String
            Get
                Return _CDBCRUDXmlUpdate
            End Get
            Set(value As String)
                _CDBCRUDXmlUpdate = value
            End Set
        End Property

        Private _CDBCRUDXmlDelete As String
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property CDBCRUDXmlDelete As String
            Get
                Return _CDBCRUDXmlDelete
            End Get
            Set(value As String)
                _CDBCRUDXmlDelete = value
            End Set
        End Property
#End Region


#Region "處理SQL Server保留字"
        ''' <summary>
        '''  處理SQL Server保留字
        ''' </summary>
        ''' <param name="fromWord"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CDBFs_CheckKeyWord_SQLServer(ByVal fromWord As String) As String
            Dim keyWordList() As String = New String() {"AS", "Dim"}
            Dim charStart As String = "["
            Dim charEnd As String = "]"
            For Each eachItem As String In keyWordList
                If eachItem.Trim.ToUpper = fromWord.Trim.ToUpper Then
                    Return charStart & fromWord & charEnd
                    Exit Function
                End If
            Next
            Return fromWord
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

#Region "IClassDB類別介面"

    Public Interface IClassDB

        ReadOnly Property CDBClassDBPropertyFieldNames() As IList(Of String)
        Sub CDBUnSerializeNEW(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        Function CDBGetClassDBFieldType(ByVal FieldName As String, Optional ByVal AttributeNIndex As Object() = Nothing) As Type

        Function CDBGetFieldValue(ByVal FieldName As String, Optional ByVal AttributeNIndex As Object() = Nothing) As Object
    End Interface
#End Region

End Namespace
