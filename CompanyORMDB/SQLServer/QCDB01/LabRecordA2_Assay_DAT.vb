Namespace SQLServer
    Namespace QCDB01
        Public Class LabRecordA2_Assay_DAT
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
            End Sub

#Region "ASSAY_ID 屬性:ASSAY_ID"
            Private _ASSAY_ID As System.String
            ''' <summary>
            ''' ASSAY_ID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ASSAY_ID() As System.String
                Get
                    Return _ASSAY_ID
                End Get
                Set(ByVal value As System.String)
                    _ASSAY_ID = value
                End Set
            End Property
#End Region
#Region "ASSAY_NAME 屬性:ASSAY_NAME"
            Private _ASSAY_NAME As System.String
            ''' <summary>
            ''' ASSAY_NAME
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ASSAY_NAME() As System.String
                Get
                    Return _ASSAY_NAME
                End Get
                Set(ByVal value As System.String)
                    _ASSAY_NAME = value
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
#Region "NORMAL_RANGE_L 屬性:NORMAL_RANGE_L"
            Private _NORMAL_RANGE_L As System.String
            ''' <summary>
            ''' NORMAL_RANGE_L
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NORMAL_RANGE_L() As System.String
                Get
                    Return _NORMAL_RANGE_L
                End Get
                Set(ByVal value As System.String)
                    _NORMAL_RANGE_L = value
                End Set
            End Property
#End Region
#Region "NORMAL_RANGE_H 屬性:NORMAL_RANGE_H"
            Private _NORMAL_RANGE_H As System.String
            ''' <summary>
            ''' NORMAL_RANGE_H
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NORMAL_RANGE_H() As System.String
                Get
                    Return _NORMAL_RANGE_H
                End Get
                Set(ByVal value As System.String)
                    _NORMAL_RANGE_H = value
                End Set
            End Property
#End Region
#Region "RESULT_FORMAT 屬性:RESULT_FORMAT"
            Private _RESULT_FORMAT As System.Int32
            ''' <summary>
            ''' RESULT_FORMAT
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RESULT_FORMAT() As System.Int32
                Get
                    Return _RESULT_FORMAT
                End Get
                Set(ByVal value As System.Int32)
                    _RESULT_FORMAT = value
                End Set
            End Property
#End Region
#Region "RESULT_KIND 屬性:RESULT_KIND"
            Private _RESULT_KIND As System.String
            ''' <summary>
            ''' RESULT_KIND
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RESULT_KIND() As System.String
                Get
                    Return _RESULT_KIND
                End Get
                Set(ByVal value As System.String)
                    _RESULT_KIND = value
                End Set
            End Property
#End Region
#Region "RESULT_TABLE_COLUMN 屬性:RESULT_TABLE_COLUMN"
            Private _RESULT_TABLE_COLUMN As System.String
            ''' <summary>
            ''' RESULT_TABLE_COLUMN
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RESULT_TABLE_COLUMN() As System.String
                Get
                    Return _RESULT_TABLE_COLUMN
                End Get
                Set(ByVal value As System.String)
                    _RESULT_TABLE_COLUMN = value
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