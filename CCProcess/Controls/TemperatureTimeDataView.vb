Public Class TemperatureTimeDataView

#Region "取得攪拌溫度及時間資料 屬性:GetElementInformations"
    ''' <summary>
    ''' 取得化學成份資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetTemperatureTimeDataViews(ByVal SourceSMSC1PF As CompanyORMDB.SMS100LB.SMSC1PF) As List(Of TemperatureTimeDataView)

        Dim ReturnValue As New List(Of TemperatureTimeDataView)
        Dim AboutSMSC11PFs As List(Of CompanyORMDB.SMS100LB.SMSC11PF) = Nothing
        If IsNothing(SourceSMSC1PF) Then
            Return ReturnValue
        End If
        AboutSMSC11PFs = SourceSMSC1PF.AboutSMSC11PFs
        Dim AddItem As TemperatureTimeDataView = New TemperatureTimeDataView
        AddItem.DisplayItem = "出鋼前"
        AddItem.Time = SourceSMSC1PF.T11
        AddItem.Temperature = SourceSMSC1PF.T12
        ReturnValue.Add(AddItem)

        If AboutSMSC11PFs.Count > 0 Then
            AddItem = New TemperatureTimeDataView
            AddItem.DisplayItem = "出鋼後"
            AddItem.Time = SourceSMSC1PF.T11
            AddItem.Temperature = SourceSMSC1PF.T12
            ReturnValue.Add(AddItem)
        End If


        Dim TotalMixMinute As Integer = 0
        For Each EachItem In AboutSMSC11PFs
            AddItem = New TemperatureTimeDataView
            With AddItem
                Select Case AboutSMSC11PFs.IndexOf(EachItem)
                    Case 0
                        .DisplayItem = "出鋼後"
                    Case 1
                        .DisplayItem = "氣體攪拌開始"
                    Case Else
                        .DisplayItem = "氣體攪拌液溫"
                End Select
                .Time = EachItem.T3
                .Temperature = EachItem.T5
            End With
            ReturnValue.Add(AddItem)
            TotalMixMinute += Val(EachItem.MixTime)
        Next

        AddItem = New TemperatureTimeDataView
        With AddItem
            .DisplayItem = "攪拌時間合計"
            .Time = TotalMixMinute
        End With
        ReturnValue.Add(AddItem)

        Return ReturnValue
    End Function
    'Shared Function GetTemperatureTimeDataViews(ByVal StoveNumber As String, ByVal NearDate As Date) As List(Of TemperatureTimeDataView)
    '    Dim ReturnValue As New List(Of TemperatureTimeDataView)
    '    'Dim AS400AD As New CompanyLINQDB.SMPDataContext
    '    Dim StartDate As String = Format(New CompanyORMDB.AS400DateConverter(NearDate.AddMonths(-5)).DateValue, "HHmm")
    '    Dim EndDate As String = Format(New CompanyORMDB.AS400DateConverter(NearDate.AddMonths(5)).DateValue, "HHmm")
    '    Dim QryString As String = "Select * from @#SMS100LB.SMSC1PF WHERE "
    '    Dim SearchResult = CompanyORMDB.SMS100LB.SMSC1PF.CDBSelect(Of CompanyORMDB.SMS100LB.SMSC1PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    '    For Each EachItem In SearchResult
    '        Dim AddItem As New TemperatureTimeDataView
    '        With AddItem

    '        End With
    '        ReturnValue.Add(AddItem)
    '    Next

    '    Return ReturnValue
    'End Function
#End Region
#Region "顯示項目 屬性:DisplayItem"
    Private _DisplayItem As String
    Public Property DisplayItem() As String
        Get
            Return _DisplayItem
        End Get
        Private Set(ByVal value As String)
            _DisplayItem = value
        End Set
    End Property

#End Region
#Region "時間 屬性:Time"
    Private _Time As String
    Property Time As String
        Get
            Return _Time
        End Get
        Private Set(value As String)
            _Time = value
        End Set
    End Property
#End Region
#Region "溫度 屬性:Temperature"
    Private _Temperature As String
    Property Temperature As String
        Get
            Return _Temperature
        End Get
        Private Set(value As String)
            _Temperature = value
        End Set
    End Property
#End Region

End Class

