Namespace SQLServer
    Namespace PPS100LB
        ''' <summary>
        ''' 站台
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Station
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            End Sub

#Region "StationName 屬性:StationName"
            Private _StationName As System.String
            ''' <summary>
            ''' StationName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property StationName() As System.String
                Get
                    Return _StationName
                End Get
                Set(ByVal value As System.String)
                    _StationName = value
                End Set
            End Property
#End Region
#Region "父站台 屬性:FK_ParentStationName"
            Private _FK_ParentStationName As String
            ''' <summary>
            ''' 父站台
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_ParentStationName() As String
                Get
                    Return _FK_ParentStationName
                End Get
                Set(ByVal value As String)
                    _FK_ParentStationName = value
                End Set
            End Property
#End Region

#Region "全部站台 屬性:AllStation"
            Private Shared _AllStation As List(Of Station)
            ''' <summary>
            ''' 全部站台
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Shared ReadOnly Property AllStation As List(Of Station)
                Get
                    Static LastAssetTime As DateTime = Now
                    If IsNothing(_AllStation) OrElse Now.Subtract(LastAssetTime).TotalSeconds > 5 Then
                        _AllStation = Station.CDBSelect(Of Station)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * From Station Order By StationName")
                        LastAssetTime = Now
                    End If
                    Return _AllStation
                End Get
            End Property

#End Region
#Region "取得IP之所有站台 Shared方法:GetIPsStations"
            ''' <summary>
            ''' 取得IP之所有站台
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function GetIPsStations(ByVal FindIPs As List(Of String)) As List(Of Station)
                Dim LoacalPCIPs As String = Nothing
                For Each EachItem As String In FindIPs
                    LoacalPCIPs &= IIf(String.IsNullOrEmpty(LoacalPCIPs), Nothing, ",") & EachItem.Trim
                Next
                Dim SQLString As String = "Select * From Station Where StationName in ( Select StationName from StationToWebClientPCAccount Where ClientIP in ('" & LoacalPCIPs.Replace(",", "','") & "') )"
                Return Station.CDBSelect(Of Station)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
            End Function
#End Region
#Region "本站之子站台 屬性:SubStations"
            ''' <summary>
            ''' 本站之子站台
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property SubStations As List(Of Station)
                Get
                    Dim ReturnValue As New List(Of Station)
                    For Each EachItem As Station In AllStation
                        If Not String.IsNullOrEmpty(EachItem.FK_ParentStationName) AndAlso EachItem.FK_ParentStationName.Trim = Me.StationName.Trim Then
                            ReturnValue.Add(EachItem)
                        End If
                    Next
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "本站之父站台 屬性:ParentStation"
            ''' <summary>
            ''' 本站之父站台
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property ParentStation As Station
                Get
                    If String.IsNullOrEmpty(Me.FK_ParentStationName) OrElse Me.FK_ParentStationName.Trim.Length = 0 Then
                        Return Nothing
                    End If
                    For Each EachItem As Station In AllStation
                        If EachItem.StationName.Trim = Me.FK_ParentStationName.Trim Then
                            Return EachItem
                        End If
                    Next
                    Return Nothing
                End Get
            End Property
#End Region
#Region "本站之所有階層父站台 屬性:AllParentLevelStations"
            ''' <summary>
            ''' 本站之所有階層父站台
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AllParentLevelStations() As List(Of Station)
                Get
                    Dim ReturnValue As List(Of Station) = New List(Of Station)
                    ReturnValue.Add(Me)
                    Dim ParentStation As Station = Me.ParentStation
                    Do While Not IsNothing(ParentStation)
                        ReturnValue.Add(ParentStation)
                        ParentStation = ParentStation.ParentStation
                    Loop
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "本站之所有階層子站台 屬性:SubAllLevelStations"
            ''' <summary>
            ''' 本站之所有階層子站台
            ''' </summary>
            ''' <param name="SetSearchStation"></param>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property SubAllLevelStations(Optional ByVal SetSearchStation As Station = Nothing) As List(Of Station)
                Get
                    Dim ReturnValue As List(Of Station) = New List(Of Station)
                    If IsNothing(SetSearchStation) Then
                        For Each EachItem As Station In SubStations
                            ReturnValue.AddRange(SubAllLevelStations(EachItem))
                            ReturnValue.Add(EachItem)
                        Next
                    Else
                        For Each EachItem As Station In SetSearchStation.SubStations
                            ReturnValue.AddRange(SubAllLevelStations(EachItem))
                            ReturnValue.Add(EachItem)
                        Next
                    End If
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "是否為抽象站台 屬性:IsAbstractStation"
            ''' <summary>
            ''' 是否為抽象站台
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property IsAbstractStation As Boolean
                Get
                    Return Me.SubStations.Count > 0
                End Get
            End Property
#End Region


#Region "覆寫刪除 函式:CDBDelete"
            ''' <summary>
            ''' 覆寫刪除
            ''' </summary>
            ''' <remarks></remarks>
            Shared QryAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            ''' <summary>
            ''' 覆寫刪除
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Overrides Function CDBDelete() As Integer
                For Each EachItem As Station In SubStations
                    EachItem.CDBDelete()
                Next
                'StationToWebClientPCAccount
                Dim QryString As String = "Update ProcessSchedual Set FK_StationName='' Where FK_StationName='" & Me.StationName.Trim & "'"
                QryAdapter.ExecuteNonQuery(QryString)
                QryString = "Delete StationToWebClientPCAccount Where StationName='" & Me.StationName.Trim & "'"
                QryAdapter.ExecuteNonQuery(QryString)
                Return MyBase.CDBDelete()
            End Function
#End Region

        End Class
    End Namespace
End Namespace