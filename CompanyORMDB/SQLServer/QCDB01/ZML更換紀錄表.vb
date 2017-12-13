Namespace SQLServer
    Namespace QCDB01
        Public Class ZML更換紀錄表
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
            End Sub

#Region "GID 屬性:GID"
            Private _GID As System.String
            ''' <summary>
            ''' GID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property GID() As System.String
                Get
                    Return _GID
                End Get
                Set(ByVal value As System.String)
                    _GID = value
                End Set
            End Property
#End Region

#Region "紀錄表類別 屬性:紀錄表類別"
            Private _紀錄表類別 As System.String
            ''' <summary>
            ''' 資料別
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 紀錄表類別() As System.String
                Get
                    Return _紀錄表類別
                End Get
                Set(ByVal value As System.String)
                    _紀錄表類別 = value
                End Set
            End Property
#End Region
#Region "機別 屬性:機別"
            Private _機別 As System.String
            ''' <summary>
            ''' 機別
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 機別() As System.String
                Get
                    Return _機別
                End Get
                Set(ByVal value As System.String)
                    _機別 = value
                End Set
            End Property
#End Region
#Region "日期 屬性:日期"
            Private _日期 As System.DateTime
            ''' <summary>
            ''' 日期
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 日期() As System.DateTime
                Get
                    Return _日期
                End Get
                Set(ByVal value As System.DateTime)
                    _日期 = value
                End Set
            End Property
#End Region
#Region "班別 屬性:班別"
            Private _班別 As System.String
            ''' <summary>
            ''' 班別
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 班別() As System.String
                Get
                    Return _班別
                End Get
                Set(ByVal value As System.String)
                    _班別 = value
                End Set
            End Property
#End Region
#Region "尺寸上輥 屬性:尺寸上輥"
            Private _尺寸上輥 As System.String
            ''' <summary>
            ''' 尺寸上輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 尺寸上輥() As System.String
                Get
                    Return _尺寸上輥
                End Get
                Set(ByVal value As System.String)
                    _尺寸上輥 = value
                End Set
            End Property
#End Region
#Region "尺寸下輥 屬性:尺寸下輥"
            Private _尺寸下輥 As System.String
            ''' <summary>
            ''' 尺寸下輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 尺寸下輥() As System.String
                Get
                    Return _尺寸下輥
                End Get
                Set(ByVal value As System.String)
                    _尺寸下輥 = value
                End Set
            End Property
#End Region
#Region "尺寸驅動輥 屬性:尺寸驅動輥"
            Private _尺寸驅動輥 As System.String
            ''' <summary>
            ''' 尺寸驅動輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 尺寸驅動輥() As System.String
                Get
                    Return _尺寸驅動輥
                End Get
                Set(ByVal value As System.String)
                    _尺寸驅動輥 = value
                End Set
            End Property
#End Region
#Region "背輥代號 屬性:背輥代號"
            Private _背輥代號 As System.String
            ''' <summary>
            ''' 背輥代號
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 背輥代號() As System.String
                Get
                    Return _背輥代號
                End Get
                Set(ByVal value As System.String)
                    _背輥代號 = value
                End Set
            End Property
#End Region
#Region "規格 屬性:規格"
            Private _規格 As System.String
            ''' <summary>
            ''' 規格
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 規格() As System.String
                Get
                    Return _規格
                End Get
                Set(ByVal value As System.String)
                    _規格 = value
                End Set
            End Property
#End Region
#Region "定期更換 屬性:定期更換"
            Private _定期更換 As System.String
            ''' <summary>
            ''' 定期更換
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 定期更換() As System.String
                Get
                    Return _定期更換
                End Get
                Set(ByVal value As System.String)
                    _定期更換 = value
                End Set
            End Property
#End Region
#Region "損換更換 屬性:損換更換"
            Private _損換更換 As System.String
            ''' <summary>
            ''' 損換更換
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 損換更換() As System.String
                Get
                    Return _損換更換
                End Get
                Set(ByVal value As System.String)
                    _損換更換 = value
                End Set
            End Property
#End Region
#Region "原因 屬性:原因"
            Private _原因 As System.String
            ''' <summary>
            ''' 原因
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 原因() As System.String
                Get
                    Return _原因
                End Get
                Set(ByVal value As System.String)
                    _原因 = value
                End Set
            End Property
#End Region
#Region "班別說明 屬性:班別說明"
            Private _班別說明 As System.String
            ''' <summary>
            ''' 班別說明
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property 班別說明() As System.String
                Get
                    Return _班別說明
                End Get
                Set(ByVal value As System.String)
                    _班別說明 = value
                End Set
            End Property
#End Region
        End Class
    End Namespace
End Namespace