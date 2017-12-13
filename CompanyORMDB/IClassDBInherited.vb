Public Interface IClassDBInherited
    Event CDBDataInsertUpdateDeletedEvent(ByVal DBObject As ClassDB, ByVal DataInsertUpdateDeleteKind As DataInsertUpdateDeleteType)
    Function CDBInsert() As Integer
    Function CDBUpdate() As Integer
    Function CDBDelete() As Integer

    Enum DataInsertUpdateDeleteType
        Insert = 1
        Update = 2
        Delete = 3
    End Enum

End Interface
