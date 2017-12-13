Namespace SQLServer
    Namespace QCDB01
        Public Class LaboratoryReportRecord
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM, "QCDB01")
            End Sub

#Region "爐號 屬性:爐號"
            Private _爐號 As System.String
            ''' <summary>
            ''' 爐號
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 爐號() As System.String
                Get
                    Return _爐號
                End Get
                Set(ByVal value As System.String)
                    _爐號 = value
                End Set
            End Property
#End Region
#Region "站別 屬性:站別"
            Private _站別 As System.String
            ''' <summary>
            ''' 站別
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 站別() As System.String
                Get
                    Return _站別
                End Get
                Set(ByVal value As System.String)
                    _站別 = value
                End Set
            End Property
#End Region
#Region "序號 屬性:序號"
            Private _序號 As System.Int16
            ''' <summary>
            ''' 序號
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 序號() As System.Int16
                Get
                    Return _序號
                End Get
                Set(ByVal value As System.Int16)
                    _序號 = value
                End Set
            End Property
#End Region
#Region "日期 屬性:日期"
            Private _日期 As System.Double
            ''' <summary>
            ''' 日期
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 日期() As System.Double
                Get
                    Return _日期
                End Get
                Set(ByVal value As System.Double)
                    _日期 = value
                End Set
            End Property
#End Region
#Region "列印日期 屬性:列印日期"
            Private _列印日期 As System.DateTime
            ''' <summary>
            ''' 列印日期
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 列印日期() As System.DateTime
                Get
                    Return _列印日期
                End Get
                Set(ByVal value As System.DateTime)
                    _列印日期 = value
                End Set
            End Property
#End Region
#Region "列印者 屬性:列印者"
            Private _列印者 As System.String
            ''' <summary>
            ''' 列印者
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 列印者() As System.String
                Get
                    Return _列印者
                End Get
                Set(ByVal value As System.String)
                    _列印者 = value
                End Set
            End Property
#End Region

        End Class
    End Namespace
End Namespace
