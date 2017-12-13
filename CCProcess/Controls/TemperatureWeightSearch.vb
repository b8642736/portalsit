Public Class TemperatureWeightSearch

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Search() As List(Of CompanyORMDB.SMS100LB.SMSC1PF)
        Dim QryString As String = "Select * from @#SMS100LB.SMSC1PF WHERE T3>=" & New CompanyORMDB.AS400DateConverter(DateTimePicker1.Value).TwIntegerTypeData & " AND T3<=" & New CompanyORMDB.AS400DateConverter(DateTimePicker2.Value).TwIntegerTypeData
        Dim GetStoveNumbers As String = tbStoveNumber.Text
        If Not String.IsNullOrEmpty(GetStoveNumbers) AndAlso GetStoveNumbers.Trim.Length > 0 Then
            Dim SubQry As String = Nothing
            For Each EachItem As String In GetStoveNumbers.Split(",")
                SubQry &= IIf(String.IsNullOrEmpty(SubQry), Nothing, " OR ")
                If EachItem.Contains("~") Then
                    SubQry &= " T1 >='" & EachItem.Split("~")(0).Trim & "' AND T1 <='" & EachItem.Split("~")(1).Trim & "' "
                Else
                    SubQry &= " T1 ='" & EachItem.Split("~")(0).Trim & "' "
                End If
            Next
            QryString &= " AND (" & SubQry & ")"
        End If

        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            QryString &= " AND T6 IN ('" & tbSteelKind.Text.Trim.Replace(",", "','") & "')"
        End If

        Dim ReturnValue = CompanyORMDB.SMS100LB.SMSC1PF.CDBSelect(Of CompanyORMDB.SMS100LB.SMSC1PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem In ReturnValue
            EachItem.IsFistAddNewData = False
        Next
        Return ReturnValue
    End Function
#End Region

#Region "查詢結果事件 事件:SearchResult"
    ''' <summary>
    ''' 查詢結果事件
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks></remarks>
    Public Event SearchResult(ByVal Result As List(Of CompanyORMDB.SMS100LB.SMSC1PF))
#End Region

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        RaiseEvent SearchResult(Search)
    End Sub

    Private Sub TemperatureWeightSearch_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        DateTimePicker1.Value = New Date(Now.Year, Now.Month, 1)
    End Sub
End Class
