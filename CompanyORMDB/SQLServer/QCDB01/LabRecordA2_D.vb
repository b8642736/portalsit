Namespace SQLServer
    Namespace QCDB01
        Public Class LabRecordA2_D
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
            End Sub

#Region "LABREPORT_NO 屬性:LABREPORT_NO"
            Private _LABREPORT_NO As System.String
            ''' <summary>
            ''' LABREPORT_NO
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property LABREPORT_NO() As System.String
                Get
                    Return _LABREPORT_NO
                End Get
                Set(ByVal value As System.String)
                    _LABREPORT_NO = value
                End Set
            End Property
#End Region
#Region "ITEM_NO 屬性:ITEM_NO"
            Private _ITEM_NO As System.Int32
            ''' <summary>
            ''' ITEM_NO
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ITEM_NO() As System.Int32
                Get
                    Return _ITEM_NO
                End Get
                Set(ByVal value As System.Int32)
                    _ITEM_NO = value
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
            Private _RESULT_VALUE As System.String
            ''' <summary>
            ''' RESULT_VALUE
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RESULT_VALUE() As System.String
                Get
                    Return _RESULT_VALUE
                End Get
                Set(ByVal value As System.String)
                    _RESULT_VALUE = value
                End Set
            End Property
#End Region
        End Class
    End Namespace
End Namespace