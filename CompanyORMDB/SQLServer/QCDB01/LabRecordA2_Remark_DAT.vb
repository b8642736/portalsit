Namespace SQLServer
    Namespace QCDB01
        Public Class LabRecordA2_Remark_DAT
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
            End Sub

#Region "REMARK_ID 屬性:REMARK_ID"
            Private _REMARK_ID As System.String
            ''' <summary>
            ''' REMARK_ID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property REMARK_ID() As System.String
                Get
                    Return _REMARK_ID
                End Get
                Set(ByVal value As System.String)
                    _REMARK_ID = value
                End Set
            End Property
#End Region
#Region "CONTEXT 屬性:CONTEXT"
            Private _CONTEXT As System.String
            ''' <summary>
            ''' CONTEXT
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CONTEXT() As System.String
                Get
                    Return _CONTEXT
                End Get
                Set(ByVal value As System.String)
                    _CONTEXT = value
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
#Region "DISPLAY_FLAG 屬性:DISPLAY_FLAG"
            Private _DISPLAY_FLAG As System.String
            ''' <summary>
            ''' DISPLAY_FLAG
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DISPLAY_FLAG() As System.String
                Get
                    Return _DISPLAY_FLAG
                End Get
                Set(ByVal value As System.String)
                    _DISPLAY_FLAG = value
                End Set
            End Property
#End Region
#Region "CHECK_ASSAY_ITEM 屬性:CHECK_ASSAY_ITEM"
            Private _CHECK_ASSAY_ITEM As System.String
            ''' <summary>
            ''' CHECK_ASSAY_ITEM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CHECK_ASSAY_ITEM() As System.String
                Get
                    Return _CHECK_ASSAY_ITEM
                End Get
                Set(ByVal value As System.String)
                    _CHECK_ASSAY_ITEM = value
                End Set
            End Property
#End Region
#Region "EFF_FLAG 屬性:EFF_FLAG"
            Private _EFF_FLAG As System.String
            ''' <summary>
            ''' EFF_FLAG
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property EFF_FLAG() As System.String
                Get
                    Return _EFF_FLAG
                End Get
                Set(ByVal value As System.String)
                    _EFF_FLAG = value
                End Set
            End Property
#End Region
#Region "SAVE_OPER 屬性:SAVE_OPER"
            Private _SAVE_OPER As System.String
            ''' <summary>
            ''' SAVE_OPER
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SAVE_OPER() As System.String
                Get
                    Return _SAVE_OPER
                End Get
                Set(ByVal value As System.String)
                    _SAVE_OPER = value
                End Set
            End Property
#End Region
#Region "SAVE_DATE 屬性:SAVE_DATE"
            Private _SAVE_DATE As System.DateTime
            ''' <summary>
            ''' SAVE_DATE
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SAVE_DATE() As System.DateTime
                Get
                    Return _SAVE_DATE
                End Get
                Set(ByVal value As System.DateTime)
                    _SAVE_DATE = value
                End Set
            End Property
#End Region

        End Class
    End Namespace
End Namespace