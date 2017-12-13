Namespace SQLServer
    Namespace PPS100LB
        ''' <summary>
        ''' 軋鋼處理排程
        ''' </summary>
        ''' <remarks></remarks>
        Public Class ProcessSchedual
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            End Sub

#Region "ID 屬性:ID"
            Private _ID As System.String
            ''' <summary>
            ''' ID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ID() As System.String
                Get
                    If String.IsNullOrEmpty(_ID) OrElse _ID.Trim.Length = 0 Then
                        _ID = Guid.NewGuid.ToString
                    End If
                    Return _ID
                End Get
                Set(ByVal value As System.String)
                    _ID = value
                End Set
            End Property
#End Region
#Region "FinalFish 屬性:FinalFish"
            Private _FinalFish As System.String
            ''' <summary>
            ''' FinalFish
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FinalFish() As System.String
                Get
                    Return _FinalFish
                End Get
                Set(ByVal value As System.String)
                    _FinalFish = value
                End Set
            End Property
#End Region
#Region "EquipmentName 屬性:EquipmentName"
            Private _EquipmentName As System.String
            ''' <summary>
            ''' EquipmentName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property EquipmentName() As System.String
                Get
                    Return _EquipmentName
                End Get
                Set(ByVal value As System.String)
                    _EquipmentName = value
                End Set
            End Property
#End Region
#Region "本站處理過後面表面 屬性:OverProcessFish"
            Private _OverProcessFish As String
            ''' <summary>
            ''' 本站處理過後面表面
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property OverProcessFish() As String
                Get
                    Return _OverProcessFish
                End Get
                Set(ByVal value As String)
                    _OverProcessFish = value
                End Set
            End Property


#End Region
#Region "所屬站台屬性ID 屬性:FK_StationID"

            Private _FK_StationName As String
            ''' <summary>
            ''' 所屬站台屬性ID
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_StationName() As String
                Get
                    Return _FK_StationName
                End Get
                Set(ByVal value As String)
                    _FK_StationName = value
                    AboutStation = Nothing
                End Set
            End Property

#End Region
#Region "PreProcessSchedualIDs 屬性:PreProcessSchedualIDs"
            Private _PreProcessSchedualIDs As System.String
            ''' <summary>
            ''' PreProcessSchedualIDs
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property PreProcessSchedualIDs() As System.String
                Get
                    Return _PreProcessSchedualIDs
                End Get
                Set(ByVal value As System.String)
                    _PreProcessSchedualIDs = value
                End Set
            End Property
#End Region

            '#Region "找尋排程階程序號之所有節點 方法:FindLevelNumberProcessScheduals"
            '            ''' <summary>
            '            ''' 找尋排程階程序號之所有節點
            '            ''' </summary>
            '            ''' <param name="FindAnyoneNode"></param>
            '            ''' <param name="FindLevelNumber"></param>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            Public Shared Function FindLevelNumberProcessScheduals(ByVal FindAnyoneNode As ProcessSchedual, ByVal FindLevelNumber As Integer) As List(Of ProcessSchedual)
            '                Dim CurrentLevelNumberItems As New List(Of ProcessSchedual)
            '                If FindLevelNumber = 1 Then
            '                    CurrentLevelNumberItems.Add(FindAnyoneNode.FirstProcessSchedualEquipment)
            '                Else
            '                    For Each EachItem As ProcessSchedual In FindAnyoneNode.FirstProcessSchedualEquipment.AllNextProcessSchedualEquipments
            '                        If EachItem.SchedualLevelNumber = FindLevelNumber Then
            '                            CurrentLevelNumberItems.Add(EachItem)
            '                        End If
            '                    Next
            '                End If

            '                Return CurrentLevelNumberItems
            '            End Function
            '#End Region
            '#Region "排程階程序號 屬性:SchedualLevelNumber"
            '            ''' <summary>
            '            ''' 排程階程序號
            '            ''' </summary>
            '            ''' <value></value>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            '            ReadOnly Property SchedualLevelNumber As Integer
            '                Get
            '                    Dim CureentLevelNodes As New List(Of ProcessSchedual)
            '                    CureentLevelNodes.Add(FirstProcessSchedualEquipment)
            '                    Dim ReturnValue As Integer = 1
            '                    Do While IsFindedInLevelNodes(CureentLevelNodes) = False
            '                        ReturnValue += 1
            '                        Dim SetFindNextLevelNodes As New List(Of ProcessSchedual)
            '                        For Each EachItem As ProcessSchedual In CureentLevelNodes
            '                            SetFindNextLevelNodes.AddRange(EachItem.NextProcessSchedualEquipments)
            '                        Next
            '                        If SetFindNextLevelNodes.Count = 0 Then
            '                            Return -1   '本節點出現異常(找不到所屬序號)
            '                        End If
            '                        CureentLevelNodes = SetFindNextLevelNodes
            '                    Loop
            '                    Return ReturnValue
            '                End Get
            '            End Property
            '            Private Function IsFindedInLevelNodes(ByVal SourceNodes As List(Of ProcessSchedual)) As Boolean
            '                For Each Eachitem As ProcessSchedual In SourceNodes
            '                    If Eachitem.ID.Trim = Me.ID.Trim Then
            '                        Return True
            '                    End If
            '                Next
            '                Return False
            '            End Function
            '#End Region

#Region "產生本程序作業記錄PPSSHAPF 方法:CreateTheProcessPPSSHAPF"
            Public Function CreateTheProcessPPSSHAPF(ByVal PrePPSSHAPF As IPPS100LB.IPPSSHAPF, Optional ByVal BrokenNumber As Integer = 0) As List(Of IPPS100LB.IPPSSHAPF)
                Dim ReturnValue As New List(Of IPPS100LB.IPPSSHAPF)
                Dim SetInOutOperationLineName As InOutOperationLineName = CompareGetInOutOperationLineName(PrePPSSHAPF)

                For AddCount As Integer = 0 To BrokenNumber
                    Dim AddItem As New PPSSHAPF
                    For Each EachFieldName As String In AddItem.CDBClassFieldNames
                        AddItem.CDBSetFieldValue(EachFieldName, PrePPSSHAPF.CDBGetFieldValue(EachFieldName))
                    Next
                    '經過本站必定變更部份
                    With AddItem
                        If PrePPSSHAPF.SHA29.Trim <> "*" Then
                            .SHA04 += 1 '前筆資料非分捲指示資料
                        End If
                        If IsNothing(SetInOutOperationLineName) Then
                            .SHA08 = Me.EquipmentName
                            If NextProcessSchedualEquipments.Count > 0 Then
                                .SHA27 = NextProcessSchedualEquipments(0).EquipmentName
                            Else
                                .SHA27 = ""
                            End If
                        Else
                            .SHA08 = SetInOutOperationLineName.OutOperationLineName
                            .SHA27 = SetInOutOperationLineName.OutNextOperationLineName
                        End If
                        If BrokenNumber > 0 Then
                            .SHA02 = GenerateBrokeNumber(.SHA02, AddCount + 1)
                        End If
                        .SHA11 = (Format(Now, "yyyy") - 1911) * 10000 + Format(Now, "MMdd")
                        If BrokenNumber > 0 AndAlso AddCount <> 0 Then
                            .SHA17 = 0
                        End If
                        .SHA18 = 0
                        .SHA19 = 0
                        .SHA22 = Format(Now, "HH")
                        .SHA23 = Format(Now, "mm")
                        .SHA24 = .SHA22
                        .SHA25 = .SHA23
                        .SHA39 = .SHA39.Trim
                        .IsTransToAS400 = False
                        .DataSourceType = 0     '0.SQLServer現場產生1.AS400資料來源
                        .FK_ProcessSchedualID = Me.ID
                        .SHA28 = "*"
                        .SavePCIP = PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP
                    End With
                    ReturnValue.Add(AddItem)
                Next

                Return ReturnValue
            End Function

            Private Function CompareGetInOutOperationLineName(ByVal PrePPSSHAPF As IPPS100LB.IPPSSHAPF) As InOutOperationLineName
                Dim SqlQry As String = "Select * From InOutOperationLineName Where ID IN ( Select InOutOperationLineNameID FROM ProcessToInOutOperationLineName Where ProcessSchedualID='" & Me.ID.Trim & "')"
                Dim GetInOutOperationLineNames As List(Of InOutOperationLineName) = InOutOperationLineName.CDBSelect(Of InOutOperationLineName)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SqlQry)
                For Each EachItem As InOutOperationLineName In GetInOutOperationLineNames
                    '比對前站PPSSHAPF之 處理後表面SHA06與預計下站產線名稱SHA27
                    If EachItem.InCurrentFish.Trim = PrePPSSHAPF.SHA06.Trim AndAlso EachItem.InNextOperationLineName.Trim = PrePPSSHAPF.SHA27.Trim Then
                        Return EachItem
                    End If
                Next
                'SqlQry="Select * From InOutOperationLineName Where ID IN ( Select InOutOperationLineNameID FROM ProcessToInOutOperationLineName Where ProcessSchedualID='" & Me.ID.Trim & "')"
                Return Nothing
            End Function

            Private Function GenerateBrokeNumber(ByVal OrginBrokenNumber As String, ByVal NewNumber As Integer) As String
                If NewNumber <= 0 Then
                    Return OrginBrokenNumber
                End If
                Dim GetOrginBrokenNumber As String = OrginBrokenNumber.Trim
                Return GetOrginBrokenNumber & Chr(Asc("A") + (NewNumber - 1))
            End Function
#End Region
#Region "前一站設備名稱集合 屬性:PreProcessSchedualEquipmentNames"
            ''' <summary>
            ''' 前一站設備名稱集合
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public ReadOnly Property PreProcessSchedualEquipmentNames As String
                Get
                    'Dim SQLQry As String = "Select EquipmentName From ProcessSchedual Where ID IN ('" & Me.PreProcessSchedualIDs.Replace(",", "','") & "')"
                    'Dim SearchResult As List(Of ProcessSchedual) = ProcessSchedual.CDBSelect(Of ProcessSchedual)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLQry)
                    'If SearchResult.Count = 0 Then
                    '    Return Nothing
                    'End If
                    Dim ReturnValue As String = Nothing
                    For Each EachItem As ProcessSchedual In PreProcessSchedualEquipments
                        ReturnValue &= IIf(IsNothing(ReturnValue), Nothing, ",") & EachItem.EquipmentName
                    Next
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "下一站設備名稱集合 屬性:NextProcessSchedualEquipmentNames"
            ''' <summary>
            ''' 下一站設備名稱集合
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public ReadOnly Property NextProcessSchedualEquipmentNames As String
                Get
                    Dim ReturnValue As String = Nothing
                    For Each EachItem As ProcessSchedual In NextProcessSchedualEquipments
                        ReturnValue &= IIf(IsNothing(ReturnValue), Nothing, ",") & EachItem.EquipmentName
                    Next
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "最前站設備 屬性:FirstProcessSchedualEquipment"
            ''' <summary>
            ''' 最前站設備
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property FirstProcessSchedualEquipment As ProcessSchedual
                Get
                    Dim ReturnValue As ProcessSchedual = Me
                    Do While ReturnValue.PreProcessSchedualEquipments.Count <> 0
                        ReturnValue = ReturnValue.PreProcessSchedualEquipments(0)
                    Loop
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "本站設備之前所有設備 屬性:AllPreProcessSchedualEquipments"
            ''' <summary>
            ''' 本站設備之前所有設備
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public ReadOnly Property AllPreProcessSchedualEquipments As List(Of ProcessSchedual)
                Get
                    Dim ReturnValue As New List(Of ProcessSchedual)
                    For Each EachItem As ProcessSchedual In Me.PreProcessSchedualEquipments
                        ReturnValue.AddRange(EachItem.AllPreProcessSchedualEquipments)
                        ReturnValue.Add(EachItem)
                    Next
                    Return RemoveDoubleProcessScheduals(ReturnValue)
                End Get
            End Property
#End Region
#Region "本站設備之後所有設備 屬性:AllNextProcessSchedualEquipments"
            ''' <summary>
            ''' 本站設備之後所有設備
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public ReadOnly Property AllNextProcessSchedualEquipments As List(Of ProcessSchedual)
                Get
                    Dim ReturnValue As New List(Of ProcessSchedual)
                    For Each EachItem As ProcessSchedual In Me.NextProcessSchedualEquipments
                        ReturnValue.Add(EachItem)
                        ReturnValue.AddRange(EachItem.AllNextProcessSchedualEquipments)
                    Next
                    Return RemoveDoubleProcessScheduals(ReturnValue)
                End Get
            End Property
#End Region
#Region "移除重覆排程部份 方法:RemoveDoubleProcessScheduals"
            ''' <summary>
            ''' 移除重覆排程部份
            ''' </summary>
            ''' <param name="SourceItems"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Private Function RemoveDoubleProcessScheduals(ByVal SourceItems As List(Of ProcessSchedual)) As List(Of ProcessSchedual)
                Dim ReturnValue As New List(Of ProcessSchedual)
                Dim AddedKey As New List(Of String)
                For Each Eachitem As ProcessSchedual In SourceItems
                    If Not AddedKey.Contains(Eachitem.ID.Trim) Then
                        AddedKey.Add(Eachitem.ID.Trim)
                        ReturnValue.Add(Eachitem)
                    End If
                Next
                Return ReturnValue
            End Function
#End Region
#Region "前一站設備集合 屬性:PreProcessSchedualEquipments"
            ''' <summary>
            ''' 前一站設備集合
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property PreProcessSchedualEquipments As List(Of ProcessSchedual)
                Get
                    Dim ReturnValue As New List(Of ProcessSchedual)
                    If String.IsNullOrEmpty(Me.PreProcessSchedualIDs) Then
                        Return ReturnValue
                    End If
                    For Each EachPreProcessSchedualID As String In Me.PreProcessSchedualIDs.Split(",")
                        For Each Eachitem As ProcessSchedual In GetAllProcessSchedualCash
                            If Eachitem.ID.Trim = EachPreProcessSchedualID.Trim Then
                                ReturnValue.Add(Eachitem)
                            End If
                        Next
                    Next
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "下一站設備集合 屬性:NextProcessSchedualEquipments"
            ''' <summary>
            ''' 下一站設備集合
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property NextProcessSchedualEquipments As List(Of ProcessSchedual)
                Get
                    Dim ReturnValue As New List(Of ProcessSchedual)
                    For Each Eachitem As ProcessSchedual In GetAllProcessSchedualCash
                        If Eachitem.PreProcessSchedualIDs.Contains(Me.ID.Trim) Then
                            ReturnValue.Add(Eachitem)
                        End If
                    Next
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "取得所有排程資料(2秒內資料快取)  屬性:GetAllProcessSchedualCash"
            ''' <summary>
            ''' 取得所有排程資料(2秒內資料快取)
            ''' </summary>
            ''' <remarks></remarks>
            Shared _GetAllProcessSchedualCash As List(Of ProcessSchedual) = Nothing
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property GetAllProcessSchedualCash As List(Of ProcessSchedual)
                Get
                    Static LastGetDataTime As New DateTime(2000, 1, 1)
                    If IsNothing(_GetAllProcessSchedualCash) OrElse Now.Subtract(LastGetDataTime).TotalSeconds > 2 Then
                        _GetAllProcessSchedualCash = ProcessSchedual.CDBSelect(Of ProcessSchedual)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * From ProcessSchedual Order By FinalFish ")
                    End If
                    Return _GetAllProcessSchedualCash
                End Get
            End Property
#End Region
#Region "所有軋鋼處理排程(資料快取用途) 屬性:AllProcessScheduals"
            Shared _AllProcessScheduals As List(Of ProcessSchedual)
            Shared LastGetDataTime As DateTime = New DateTime(2000, 1, 1)
            ''' <summary>
            ''' 所有軋鋼處理排程(資料快取用途)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Shared ReadOnly Property AllProcessScheduals As List(Of ProcessSchedual)
                Get
                    If IsNothing(_AllProcessScheduals) OrElse Now.Subtract(LastGetDataTime).Seconds > 3 Then
                        _AllProcessScheduals = ProcessSchedual.CDBSelect(Of ProcessSchedual)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * From ProcessSchedual")
                    End If
                    LastGetDataTime = Now
                    Return _AllProcessScheduals
                End Get
            End Property
#End Region

#Region "由AS400資料來源 P.P.排程檔推測可能現在的軋鋼處理排程 方法:GuessAS400DataNowInProcessScheduals"
            ''' <summary>
            ''' 由AS400資料來源 P.P.排程檔推測可能現在的軋鋼處理排程
            ''' </summary>
            ''' <param name="SourceData"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function GuessAS400DataNowInProcessScheduals(ByVal SourceData As IPPS100LB.IPPSSHAPF) As List(Of ProcessSchedual)
                Dim QryString1 As String = "Select * From ProcessSchedual Where FinalFish='" & SourceData.SHA39.Trim & "' "
                If SourceData.SHA06.Trim.Length > 0 Then
                    QryString1 &= " AND OverProcessFish='" & SourceData.SHA06.Trim & "'"
                End If
                Dim QryString2 As String = "Select ProcessSchedualID From ProcessToInOutOperationLineName Where InOutOperationLineNameID in (Select ID from InOutOperationLineName Where OutOperationLineName='" & SourceData.SHA08.Trim & "' AND OutNextOperationLineName='" & SourceData.SHA27.Trim & "')"
                QryString1 &= " AND ID IN ( " & QryString2 & " )"
                Return ProcessSchedual.CDBSelect(Of ProcessSchedual)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString1)
            End Function
#End Region
#Region "相關所屬站台 屬性:AboutStation"
            Private _AboutStation As Station
            ''' <summary>
            ''' 相關所屬站台
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutStation() As Station
                Get
                    If IsNothing(_AboutStation) Then
                        For Each EachItem As Station In Station.AllStation
                            If EachItem.StationName.Trim = Me.FK_StationName.Trim Then
                                _AboutStation = EachItem
                                Exit For
                            End If
                        Next
                    End If
                    Return _AboutStation
                End Get
                Private Set(ByVal value As Station)
                    _AboutStation = value
                End Set
            End Property

#End Region
#Region "所屬站台屬性名稱 屬性:StationName"
            Private _StationName As String = ""
            ''' <summary>
            ''' 所屬站台屬性名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property StationName As String
                Get
                    If String.IsNullOrEmpty(_StationName) Then
                        If IsNothing(AboutStation) Then
                            _StationName = ""
                        Else
                            _StationName = AboutStation.StationName
                        End If
                    End If
                    Return _StationName
                End Get
            End Property
#End Region
#Region "依IP取得Station中的ProcessSchedual Shared方法:GetProcessSchedualFromStationForIP"
            ''' <summary>
            ''' 依IP取得Station中的ProcessSchedual
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function GetProcessSchedualFromStationForIP(ByVal GetPCIPs As List(Of String)) As List(Of ProcessSchedual)
                Dim StationNames As New List(Of String)
                Dim StationNamesString As String = Nothing
                Dim LoacalPCIPs As String = Nothing
                For Each EachItem As String In GetPCIPs
                    LoacalPCIPs &= IIf(String.IsNullOrEmpty(LoacalPCIPs), Nothing, ",") & EachItem
                Next
                Dim SQLString As String = "Select * From Station Where StationName in ( Select StationName from StationToWebClientPCAccount Where ClientIP in ('" & LoacalPCIPs.Replace(",", "','") & "') )"
                Dim SearchStationDatas As List(Of Station) = Station.CDBSelect(Of Station)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
                For Each EachItem As Station In SearchStationDatas
                    If Not StationNames.Contains(EachItem.StationName) Then
                        StationNames.Add(EachItem.StationName)
                        StationNamesString &= IIf(String.IsNullOrEmpty(StationNamesString), Nothing, ",") & EachItem.StationName.Trim
                    End If
                    For Each EachItem1 As Station In EachItem.AllParentLevelStations
                        If Not StationNames.Contains(EachItem1.StationName) Then
                            StationNames.Add(EachItem1.StationName)
                            StationNamesString &= IIf(String.IsNullOrEmpty(StationNamesString), Nothing, ",") & EachItem1.StationName.Trim
                        End If
                    Next
                Next

                If String.IsNullOrEmpty(LoacalPCIPs) Then
                    Return New List(Of ProcessSchedual)
                End If
                SQLString = "Select * from ProcessSchedual Where FK_StationName IN ('" & StationNamesString.Replace(",", "','") & "')"
                Return ProcessSchedual.CDBSelect(Of ProcessSchedual)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
            End Function
#End Region


#Region "覆寫刪除程序"
            Public Overrides Function CDBDelete() As Integer
                If IsNothing(Me.PreProcessSchedualIDs) OrElse Me.PreProcessSchedualIDs.Trim.Length = 0 Then
                    '因為此筆為第一筆,所以直接刪除此程序之之後的所有程序
                    For Each EachItem As ProcessSchedual In Me.AllNextProcessSchedualEquipments
                        EachItem.CDBDelete()
                    Next
                Else
                    '因為此筆非第一筆,判斷程序之後的程序是否有別的程序會使用到,如果沒有則刪除本程序之後的所有程序
                    Dim NextNodes As List(Of ProcessSchedual) = Me.NextProcessSchedualEquipments
                    For Each EachItem As ProcessSchedual In NextNodes
                        If IsHaveOtherNodeReferance(Me, EachItem) = False Then
                            EachItem.CDBDelete()
                        End If
                    Next
                End If

                Dim SQLDataAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                '刪除與本站相關的ProcessToInOutOperationLineName
                Dim QryString As String '= "Delete  From ProcessToWebClientPCAccount Where ProcessSchedualID='" & Me.ID.Trim & "'"
                'SQLDataAdapter.ExecuteNonQuery(QryString)
                '刪除與本站相關的ProcessToInOutOperationLineName
                QryString = "Delete  From ProcessToInOutOperationLineName Where ProcessSchedualID='" & Me.ID.Trim & "'"
                SQLDataAdapter.ExecuteNonQuery(QryString)

                Return MyBase.CDBDelete()
            End Function

            Private Function IsHaveOtherNodeReferance(ByVal PreDeleteNode As ProcessSchedual, ByVal WillDeleteNode As ProcessSchedual) As Boolean
                For Each EachItem In WillDeleteNode.PreProcessSchedualEquipments
                    If EachItem.ID.Trim <> PreDeleteNode.ID.Trim Then
                        Return True
                    End If
                Next
                Return False
            End Function
#End Region

        End Class

    End Namespace
End Namespace