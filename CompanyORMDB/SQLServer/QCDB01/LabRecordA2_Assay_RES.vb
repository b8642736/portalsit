Namespace SQLServer
    Namespace QCDB01
        Public Class LabRecordA2_Assay_RES
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
            End Sub

#Region "參照規範 屬性:參照規範"
            Private _參照規範 As System.String
            ''' <summary>
            ''' 參照規範
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 參照規範() As System.String
                Get
                    Return _參照規範
                End Get
                Set(ByVal value As System.String)
                    _參照規範 = value
                End Set
            End Property
#End Region
#Region "表面類別 屬性:表面類別"
            Private _表面類別 As System.String
            ''' <summary>
            ''' 表面類別
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 表面類別() As System.String
                Get
                    Return _表面類別
                End Get
                Set(ByVal value As System.String)
                    _表面類別 = value
                End Set
            End Property
#End Region
#Region "鋼種 屬性:鋼種"
            Private _鋼種 As System.String
            ''' <summary>
            ''' 鋼種
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 鋼種() As System.String
                Get
                    Return _鋼種
                End Get
                Set(ByVal value As System.String)
                    _鋼種 = value
                End Set
            End Property
#End Region
#Region "材質 屬性:材質"
            Private _材質 As System.String
            ''' <summary>
            ''' 材質
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 材質() As System.String
                Get
                    Return _材質
                End Get
                Set(ByVal value As System.String)
                    _材質 = value
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

#Region "STYLE 屬性:STYLE"
            Private _STYLE As System.String
            ''' <summary>
            ''' STYLE
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property STYLE() As System.String
                Get
                    Return _STYLE
                End Get
                Set(ByVal value As System.String)
                    _STYLE = value
                End Set
            End Property
#End Region
#Region "KIND 屬性:KIND"
            Private _KIND As System.String
            ''' <summary>
            ''' KIND
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property KIND() As System.String
                Get
                    Return _KIND
                End Get
                Set(ByVal value As System.String)
                    _KIND = value
                End Set
            End Property
#End Region
        End Class
    End Namespace
End Namespace