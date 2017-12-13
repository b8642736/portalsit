Imports System.Reflection

Public Class CrudUtils
    'Public Shared Function DataTableToList(Of ObjectType As {CompanyORMDB.ORMBaseClass.ClassDB, New})(ByVal fromDataTable As DataTable) As List(Of ObjectType)
    '    Dim ReturnValue As New List(Of ObjectType)
    '    Dim AddItem As ObjectType = New ObjectType

    '    Dim ClassColumnName As List(Of String) = AddItem.CDBClassFieldNames
    '    ClassColumnName.Add(ParamXmlUtils.TypeOfEnum_Display(ParamXmlUtils.TypeOfEnum.CRUDXmlSource))

    '    Dim TableColumnNames As New List(Of String)
    '    For Each EachColumn As DataColumn In fromDataTable.Columns
    '        TableColumnNames.Add(EachColumn.ColumnName)
    '    Next

    '    For Each SourceDataRow As DataRow In fromDataTable.Rows
    '        Try
    '            AddItem = New ObjectType
    '            SetClassFieldValue(AddItem, ParamXmlUtils.TypeOfEnum_Display(ParamXmlUtils.TypeOfEnum.CRUDClass), fromDataTable.TableName, Nothing)

    '            For Each EachFieldName As String In ClassColumnName
    '                SetClassFieldValue(AddItem, EachFieldName, SourceDataRow.Item(EachFieldName), Nothing)
    '            Next
    '            ReturnValue.Add(AddItem)

    '        Catch ex As Exception
    '        End Try
    '    Next

    '    Return ReturnValue
    'End Function

    Public Shared Function SetClassFieldValue(ByRef fromClass As CompanyORMDB.ORMBaseClass.ClassDB, _
                                                                                                                ByVal FieldName As String, ByVal SetValue As Object, _
                                                                                                                Optional ByVal AttributeNIndex As Object() = Nothing) As Boolean
        '設定資料庫類別所有'屬性'之值
        Dim myPropertyInfo As PropertyInfo = Nothing
        For Each EachItem As PropertyInfo In fromClass.GetType.GetProperties
            If EachItem.Name = FieldName Then
                myPropertyInfo = EachItem
                Exit For
            End If
        Next
        If myPropertyInfo Is Nothing Then
            Return False
        End If

        If IsDBNull(SetValue) Then
            myPropertyInfo.SetValue(fromClass, Nothing, AttributeNIndex)
        Else
            Dim ConvertedSetValueObject As Object
            Try
                ConvertedSetValueObject = Convert.ChangeType(SetValue, myPropertyInfo.PropertyType)
            Catch ex As Exception
                ConvertedSetValueObject = SetValue
            End Try

            Try
                myPropertyInfo.SetValue(fromClass, ConvertedSetValueObject, AttributeNIndex)
            Catch ex As Exception
            End Try
        End If
        Return True

    End Function


    Public Shared Function GetClassFieldValue(ByRef fromClass As CompanyORMDB.ORMBaseClass.ClassDB, _
                                                                                                               ByVal FieldName As String) As Object
        '設定資料庫類別所有'屬性'之值
        Dim myPropertyInfo As PropertyInfo = Nothing
        For Each EachItem As PropertyInfo In fromClass.GetType.GetProperties
            If EachItem.Name = FieldName Then
                myPropertyInfo = EachItem
                Exit For
            End If
        Next
        If myPropertyInfo Is Nothing Then
            Return False
        End If

        Try
            Return myPropertyInfo.GetValue(fromClass, Nothing)
        Catch ex As Exception
            Return False
        End Try


    End Function
End Class
