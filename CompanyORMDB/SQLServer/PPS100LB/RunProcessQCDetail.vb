Namespace SQLServer
	Namespace PPS100LB
	Public Class RunProcessQCDetail
	Inherits ClassDBSQLServer

	Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                SaveTime = Now
	End Sub

#Region "FK_RunProcessDataID 屬性:FK_RunProcessDataID"
            Private _FK_RunProcessDataID As System.String
            ''' <summary>
            ''' FK_RunProcessDataID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property FK_RunProcessDataID() As System.String
                Get
                    Return _FK_RunProcessDataID
                End Get
                Set(ByVal value As System.String)
                    _FK_RunProcessDataID = value
                End Set
            End Property
#End Region
#Region "StartPosition 屬性:StartPosition"
            Private _StartPosition As System.Decimal
            ''' <summary>
            ''' StartPosition
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property StartPosition() As System.Decimal
                Get
                    Return _StartPosition
                End Get
                Set(ByVal value As System.Decimal)
                    _StartPosition = value
                End Set
            End Property
#End Region
#Region "EndPosition 屬性:EndPosition"
            Private _EndPosition As System.Decimal
            ''' <summary>
            ''' EndPosition
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property EndPosition() As System.Decimal
                Get
                    Return _EndPosition
                End Get
                Set(ByVal value As System.Decimal)
                    _EndPosition = value
                End Set
            End Property
#End Region
#Region "QABugNumber 屬性:QABugNumber"
            Private _QABugNumber As System.String
            ''' <summary>
            ''' QABugNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property QABugNumber() As System.String
                Get
                    Return _QABugNumber
                End Get
                Set(ByVal value As System.String)
                    _QABugNumber = value
                End Set
            End Property
#End Region
#Region "IsUpLineBug 屬性:IsUpLineBug"
            Private _IsUpLineBug As System.Boolean
            ''' <summary>
            ''' IsUpLineBug
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property IsUpLineBug() As System.Boolean
                Get
                    Return _IsUpLineBug
                End Get
                Set(ByVal value As System.Boolean)
                    _IsUpLineBug = value
                End Set
            End Property
#End Region
#Region "RowGroup 屬性:RowGroup"
            Private _RowGroup As Integer
            ''' <summary>
            ''' RowGroup
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RowGroup() As Integer
                Get
                    Return _RowGroup
                End Get
                Set(ByVal value As Integer)
                    _RowGroup = value
                End Set
            End Property

#End Region
#Region "缺陷是否發生 屬性:IsBugHappen"
            Private _IsBugHappen As Boolean
            ''' <summary>
            ''' 缺陷是否發生
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsBugHappen() As Boolean
                Get
                    Return _IsBugHappen
                End Get
                Set(ByVal value As Boolean)
                    _IsBugHappen = value
                End Set
            End Property

#End Region
#Region "資料儲存時間 屬性:SaveTime"
            ''' <summary>
            ''' 資料儲存時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property SaveTime As DateTime
#End Region

#Region "缺陷代碼中文 屬性:QABugNumberChinese"
            ''' <summary>
            ''' 缺陷代碼中文
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property QABugNumberChinese As String
                Get
                    For Each EachItem As QABUG In QABUG.AllBugDatas
                        If EachItem.Number.Trim = Me.QABugNumber.Trim Then
                            Return EachItem.CName.Trim
                        End If
                    Next
                    Return ""
                End Get
            End Property
#End Region

	End Class
	End Namespace
End Namespace