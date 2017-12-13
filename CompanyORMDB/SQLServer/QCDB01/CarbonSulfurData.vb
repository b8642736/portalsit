Namespace SQLServer
    Namespace QCDB01
        Public Class CarbonSulfurData
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
#Region "ID 屬性:ID"

            Private _ID As String
            ''' <summary>
            ''' ID
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ID() As String
                Get
                    Return _ID
                End Get
                Set(ByVal value As String)
                    _ID = value
                End Set
            End Property

#End Region
#Region "Carbon 屬性:Carbon"
            Private _Carbon As System.Double
            ''' <summary>
            ''' Carbon
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Carbon() As System.Double
                Get
                    Return _Carbon
                End Get
                Set(ByVal value As System.Double)
                    _Carbon = value
                End Set
            End Property
#End Region
#Region "Sulfur 屬性:Sulfur"
            Private _Sulfur As System.Double
            ''' <summary>
            ''' Sulfur
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Sulfur() As System.Double
                Get
                    Return _Sulfur
                End Get
                Set(ByVal value As System.Double)
                    _Sulfur = value
                End Set
            End Property
#End Region
#Region "WT 屬性:WT"

            Private _WT As Single
            ''' <summary>
            ''' WT
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property WT() As Single
                Get
                    Return _WT
                End Get
                Set(ByVal value As Single)
                    _WT = value
                End Set
            End Property

#End Region
#Region "Method 屬性:Method"

            Private _Method As String
            ''' <summary>
            ''' Method
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Method() As String
                Get
                    Return _Method
                End Get
                Set(ByVal value As String)
                    _Method = value
                End Set
            End Property

#End Region

        End Class
    End Namespace
End Namespace