Namespace SQLServer
    Namespace QCDB01
        Public Class OXYGENData
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "qcdb01")
                Me.RecordID = Guid.NewGuid.ToString
                Me.日期時間 = Now
            End Sub

#Region "資料記錄ID 屬性:RecordID"

            Private _RecordID As String
            ''' <summary>
            ''' 資料記錄ID
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
                       Public Property RecordID() As String
                Get
                    Return _RecordID
                End Get
                Set(ByVal value As String)
                    _RecordID = value
                End Set
            End Property

#End Region
#Region "爐號 屬性:爐號"
            Private _爐號 As System.String
            ''' <summary>
            ''' 爐號
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
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
            Public Property 序號() As System.Int16
                Get
                    Return _序號
                End Get
                Set(ByVal value As System.Int16)
                    _序號 = value
                End Set
            End Property
#End Region
#Region "日期時間 屬性:日期時間"
            Private _日期時間 As System.DateTime
            ''' <summary>
            ''' 日期時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 日期時間() As System.DateTime
                Get
                    Return _日期時間
                End Get
                Set(ByVal value As System.DateTime)
                    _日期時間 = value
                End Set
            End Property
#End Region
#Region "IDCODE 屬性:IDCODE"

            Private _IDCODE As String
            ''' <summary>
            ''' IDCODE
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IDCODE() As String
                Get
                    Return _IDCODE
                End Get
                Set(ByVal value As String)
                    _IDCODE = value
                End Set
            End Property
#End Region
#Region "NITROGEN 屬性:NITROGEN"
            Private _NITROGEN As System.Double
            ''' <summary>
            ''' NITROGEN
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NITROGEN() As System.Double
                Get
                    Return _NITROGEN
                End Get
                Set(ByVal value As System.Double)
                    _NITROGEN = value
                End Set
            End Property
#End Region
#Region "OXYGEN 屬性:OXYGEN"
            Private _OXYGEN As System.Double
            ''' <summary>
            ''' OXYGEN
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property OXYGEN() As System.Double
                Get
                    Return _OXYGEN
                End Get
                Set(ByVal value As System.Double)
                    _OXYGEN = value
                End Set
            End Property
#End Region

        End Class
    End Namespace
End Namespace