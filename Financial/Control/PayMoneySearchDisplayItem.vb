''' <summary>
''' 付款查詢顯示項目
''' </summary>
''' <remarks></remarks>
Public Class PayMoneySearchDisplayItem
    Inherits CompanyORMDB.CASH.CASH01PF

#Region "付款查詢 方法:PayMoneySearch"
    ''' <summary>
    ''' 付款查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PayMoneySearch(ByVal StartPayDay As DateTime, ByVal EndPayDay As DateTime) As List(Of PayMoneySearchDisplayItem)
        Dim StartDayStr As String = CType(Format(Val(Format(StartPayDay, "yyyy")) - 1911, "000"), String) & Format(StartPayDay, "MMdd")
        Dim EndDayStr As String = CType(Format(Val(Format(EndPayDay, "yyyy")) - 1911, "000"), String) & Format(EndPayDay, "MMdd")
        Dim SQLString As String = "Select DEPART,ACITEM,USEFOR,RECEPR,CHKAMT,PAYDAT,BANKN1 FROM @#CASH.CASH01PF Where PAYDAT>='" & StartDayStr & "' and PAYDAT<='" & EndDayStr & "' Order by ACITEM,PAYDAT"


        'Dim DBService As New CompanyLINQDB.AS400SQLQuery(SQLString)
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim TempValues As New List(Of PayMoneySearchDisplayItem)
        For Each EachItem As DataRow In DBService.SelectQuery.Rows
            Dim AddItem As New PayMoneySearchDisplayItem
            With AddItem
                .DEPART = EachItem.Item("DEPART")
                .ACITEM = EachItem.Item("ACITEM")
                .USEFOR = EachItem.Item("USEFOR")
                .RECEPR = EachItem.Item("RECEPR")
                .CHKAMT = EachItem.Item("CHKAMT")
                Dim DataDateStr As String = EachItem.Item("PAYDAT")
                .PAYDAT = CType(Val(DataDateStr.Substring(0, 3)) + 1911, String) & "/" & DataDateStr.Substring(3, 2) & "/" & DataDateStr.Substring(5, 2)
                .BANKN1 = EachItem.Item("BANKN1")
            End With
            TempValues.Add(AddItem)
        Next
        Dim ReturnValue As New List(Of PayMoneySearchDisplayItem)
        For Each EachItem As String In (From A In TempValues Select A.ACITEM Order By ACITEM).Distinct
            Dim CompareACITEM As String = EachItem
            Dim GroupDatas As List(Of PayMoneySearchDisplayItem) = (From A In TempValues Where A.ACITEM = CompareACITEM Select A Order By A.PAYDAT).ToList
            ReturnValue.AddRange(GroupDatas)
            Dim ADDSmallSumItem As New PayMoneySearchDisplayItem
            With ADDSmallSumItem
                .ACITEM = "小計:"
                .CHKAMT = (From A In GroupDatas Select A.CHKAMT).Sum
                .DisplayPayDay = ""
            End With
            ReturnValue.Add(ADDSmallSumItem)
        Next
        Dim ADDTotalSumItem As New PayMoneySearchDisplayItem
        With ADDTotalSumItem
            .ACITEM = "合計:"
            .CHKAMT = (From A In ReturnValue Select A.CHKAMT).Sum
            .DisplayPayDay = ""
        End With
        ReturnValue.Add(ADDTotalSumItem)

        Return ReturnValue
    End Function
#End Region

#Region "顯示付款日 屬性:DisplayPayDay"

    Private _DisplayPayDay As String
    ''' <summary>
    ''' 顯示付款日
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DisplayPayDay() As String
        Get
            If IsNothing(_DisplayPayDay) Then
                _DisplayPayDay = Me.PAYDAT ' Format(Me.PAYDAT, "yyyy/MM/dd").ToString
            End If
            Return _DisplayPayDay
        End Get
        Private Set(ByVal value As String)
            _DisplayPayDay = value
        End Set
    End Property

#End Region

End Class
