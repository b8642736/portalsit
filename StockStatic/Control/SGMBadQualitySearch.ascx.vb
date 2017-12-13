Imports System.ComponentModel

Partial Public Class SGMBadQualitySearch
    Inherits System.Web.UI.UserControl


#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal IsFilter1 As Boolean, ByVal Startate As DateTime, ByVal EndDate As DateTime, _
                           ByVal IsFilter2 As Boolean, ByVal StartBatch As String, ByVal EndBatch As String, _
                           ByVal IsFilter3 As Boolean, ByVal StartStoveA1 As String, ByVal StartStoveA2 As String, ByVal StartStoveB1 As String, ByVal StartStoveB2 As String) As List(Of CompanyORMDB.SMS100LB.SMSSGAPF)
        Dim SQLString As String = "Select * from @#SMS100LB.SMSSGAPF Where (SGA15-SGA24-SGA27)>100 "
        Dim Date1 As Integer = New CompanyORMDB.AS400DateConverter(Startate).TwIntegerTypeData
        Dim Date2 As Integer = New CompanyORMDB.AS400DateConverter(EndDate).TwIntegerTypeData
        Select Case True
            Case IsFilter1
                SQLString = SQLString & " AND SGA07>=" & Date1 & " AND SGA07<=" & Date2
            Case IsFilter2
                StartBatch = StartBatch.Replace("'", Nothing)
                EndBatch = EndBatch.Replace("'", Nothing)
                SQLString = SQLString & " AND SGA33>='" & StartBatch & "' AND SGA33<='" & EndBatch & "'"
            Case IsFilter3
                If Not String.IsNullOrEmpty(StartStoveA1) And Not String.IsNullOrEmpty(StartStoveA2) Then
                    SQLString = SQLString & " AND ((SGA01>='" & StartStoveA1 & "' AND SGA01<='" & StartStoveA2 & "')"
                    If Not String.IsNullOrEmpty(StartStoveB1) And Not String.IsNullOrEmpty(StartStoveB2) Then
                        SQLString = SQLString & " OR (SGA01>='" & StartStoveB1 & "' AND SGA01<='" & StartStoveB2 & "')"
                    End If
                    SQLString = SQLString & ")"
                Else
                    If Not String.IsNullOrEmpty(StartStoveB1) And Not String.IsNullOrEmpty(StartStoveB2) Then
                        SQLString = SQLString & " AND SGA01>='" & StartStoveB1 & "' AND SGA01<='" & StartStoveB2 & "'"
                    End If
                End If
        End Select
        SQLString = SQLString & " Order by SGA07 Desc "
        Return (From A In CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.SMS100LB.SMSSGAPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Where A.IsQualityBad = True Select A).ToList
    End Function

#End Region


#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
        End Set
    End Property
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btSearchDate1.Text = Now.Date.AddDays(-1)
            btSearchDate2.Text = Now.Date
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        GridView1.DataBind()
    End Sub

    Protected Sub btnResetSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnResetSearch.Click
        RadioButton1.Checked = True
        btSearchDate1.Text = Now.Date.AddDays(-1)
        btSearchDate2.Text = Now.Date
        btBatch1.Text = Nothing
        btBatch2.Text = Nothing
    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        Dim SetDisplayColumns As New List(Of ConvertColumnName)
        SetDisplayColumns.Add(New ConvertColumnName("SGA07DateType", "澆鑄日期", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("StoveKindName1", "鋼種", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("StoveNumber", "鋼胚編號", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("DisplaySize", "研磨後尺寸(厚*寬*長)", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("GrindWeight", "研磨重量(公斤)", GetType(String)))
        SetDisplayColumns.Add(New ConvertColumnName("GrindRate", "研磨率", GetType(String)))
        Dim ConvertDataTable As DataTable = ConvertColumnName.CreatDataTable(SetDisplayColumns)
        For Each EachItem As CompanyORMDB.SMS100LB.SMSSGAPF In Search(RadioButton1.Checked, btSearchDate1.Text, btSearchDate2.Text, RadioButton2.Checked, btBatch1.Text, btBatch2.Text, RadioButton3.Checked, tbStoveA1.Text, tbStoveA2.Text, tbStoveB1.Text, tbStoveB2.Text)
            Dim AddRow As DataRow = ConvertDataTable.NewRow
            With AddRow
                .Item("SGA07DateType") = Format(EachItem.SGA07DateType, "yyyy/MM/dd")
                .Item("StoveKindName1") = EachItem.StoveKindName1
                .Item("DisplaySize") = EachItem.DisplaySize
                .Item("StoveNumber") = EachItem.StoveNumber
                .Item("GrindWeight") = EachItem.GrindWeight
                .Item("GrindRate") = Format(EachItem.GrindRate, "0.000")
            End With
            ConvertDataTable.Rows.Add(AddRow)
        Next

        Dim ExcelConvert As New DataConvertExcel(ConvertDataTable, SetDisplayColumns, "鋼胚研磨品質不良" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub
End Class