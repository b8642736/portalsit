Namespace SQLServer
    Namespace QCDB01
        Public Class LabRecordA2_Report
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
            End Sub

#Region "SAMPLE_UNIT 屬性:SAMPLE_UNIT"
            Private _SAMPLE_UNIT As System.String
            ''' <summary>
            ''' SAMPLE_UNIT
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SAMPLE_UNIT() As System.String
                Get
                    Return _SAMPLE_UNIT
                End Get
                Set(ByVal value As System.String)
                    _SAMPLE_UNIT = value
                End Set
            End Property
#End Region
#Region "SAMPLE_DATE 屬性:SAMPLE_DATE"
            Private _SAMPLE_DATE As System.DateTime
            ''' <summary>
            ''' SAMPLE_DATE
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SAMPLE_DATE() As System.DateTime
                Get
                    Return _SAMPLE_DATE
                End Get
                Set(ByVal value As System.DateTime)
                    _SAMPLE_DATE = value
                End Set
            End Property
#End Region
#Region "SAMPLE_KIND 屬性:SAMPLE_KIND"
            Private _SAMPLE_KIND As System.String
            ''' <summary>
            ''' SAMPLE_KIND
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SAMPLE_KIND() As System.String
                Get
                    Return _SAMPLE_KIND
                End Get
                Set(ByVal value As System.String)
                    _SAMPLE_KIND = value
                End Set
            End Property
#End Region
#Region "SAMPLE_ID 屬性:SAMPLE_ID"
            Private _SAMPLE_ID As System.String
            ''' <summary>
            ''' SAMPLE_ID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SAMPLE_ID() As System.String
                Get
                    Return _SAMPLE_ID
                End Get
                Set(ByVal value As System.String)
                    _SAMPLE_ID = value
                End Set
            End Property
#End Region
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
#Region "RESULT_VALUE 屬性:RESULT_VALUE"
            Private _RESULT_VALUE As System.Double
            ''' <summary>
            ''' RESULT_VALUE
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RESULT_VALUE() As System.Double
                Get
                    Return _RESULT_VALUE
                End Get
                Set(ByVal value As System.Double)
                    _RESULT_VALUE = value
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