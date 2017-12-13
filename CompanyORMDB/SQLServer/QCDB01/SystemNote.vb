Namespace SQLServer
    Namespace QCDB01
        Public Class SystemNote
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
            End Sub

#Region "SYSTEM_TYPE 屬性:SYSTEM_TYPE"
            Private _SYSTEM_TYPE As System.String
            ''' <summary>
            ''' SYSTEM_TYPE
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SYSTEM_TYPE() As System.String
                Get
                    Return _SYSTEM_TYPE
                End Get
                Set(ByVal value As System.String)
                    _SYSTEM_TYPE = value
                End Set
            End Property
#End Region
#Region "NOTE_TYPE 屬性:NOTE_TYPE"
            Private _NOTE_TYPE As System.String
            ''' <summary>
            ''' NOTE_TYPE
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property NOTE_TYPE() As System.String
                Get
                    Return _NOTE_TYPE
                End Get
                Set(ByVal value As System.String)
                    _NOTE_TYPE = value
                End Set
            End Property
#End Region
#Region "NOTE_ID 屬性:NOTE_ID"
            Private _NOTE_ID As System.String
            ''' <summary>
            ''' NOTE_ID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property NOTE_ID() As System.String
                Get
                    Return _NOTE_ID
                End Get
                Set(ByVal value As System.String)
                    _NOTE_ID = value
                End Set
            End Property
#End Region
#Region "CONTENT 屬性:CONTENT"
            Private _CONTENT As System.String
            ''' <summary>
            ''' CONTENT
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CONTENT() As System.String
                Get
                    Return _CONTENT
                End Get
                Set(ByVal value As System.String)
                    _CONTENT = value
                End Set
            End Property
#End Region
#Region "DISPLAY_SEQ 屬性:DISPLAY_SEQ"
            Private _DISPLAY_SEQ As System.Int32
            ''' <summary>
            ''' DISPLAY_SEQ
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DISPLAY_SEQ() As System.Int32
                Get
                    Return _DISPLAY_SEQ
                End Get
                Set(ByVal value As System.Int32)
                    _DISPLAY_SEQ = value
                End Set
            End Property
#End Region
#Region "DEL_FLAG 屬性:DEL_FLAG"
            Private _DEL_FLAG As System.String
            ''' <summary>
            ''' DEL_FLAG
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DEL_FLAG() As System.String
                Get
                    Return _DEL_FLAG
                End Get
                Set(ByVal value As System.String)
                    _DEL_FLAG = value
                End Set
            End Property
#End Region
        End Class
    End Namespace
End Namespace