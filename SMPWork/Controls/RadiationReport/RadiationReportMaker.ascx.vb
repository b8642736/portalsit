Public Partial Class RadiationReportMaker
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.SMPDataContext

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal StartDate As Date, ByVal EndDate As Date) As SMPWork.ReportUseDataSet.AB爐分析資料DataTable    'List(Of SMPWork.ReportUseDataSet.AB爐分析資料Row) 
        If IsNothing(StartDate) OrElse IsNothing(StartDate) Then
            Return New SMPWork.ReportUseDataSet.AB爐分析資料DataTable
        End If
        'Dim DBDataContext As New CompanyLINQDB.SMPDataContext
        Dim SetStartDate As Integer = (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd")
        Dim SetEndDate As Integer = (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
        'Dim Query As List(Of CompanyLINQDB.分析資料) = (From A In DBDataContext.分析資料 Where A.日期 >= SetStartDate And A.日期 <= SetEndDate Select A Order By A.日期 Descending, A.時間 Descending).ToList
        Dim QryString As String = "Select * From 分析資料 Where 日期>=" & SetStartDate & " AND 日期<=" & SetEndDate & " AND (站別 like 'C%' OR 站別 like 'L%' OR 站別 like 'S%') AND 站別<> 'CC' Order By 日期,爐號"
        Dim Query As List(Of CompanyORMDB.SQLServer.QCDB01.分析資料) = CompanyORMDB.SQLServer.QCDB01.分析資料.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.分析資料)(QryString)
        Query = FilterLastProductSample(Query)  '篩選只取成品最後一塊
        Dim ReturnValue As New SMPWork.ReportUseDataSet.AB爐分析資料DataTable
        For Each EachDate As Date In (From A In Query Select A.日期DateFormat).Distinct
            Dim EachDateTemp As Date = EachDate
            Dim FindIndexDataA As List(Of CompanyORMDB.SQLServer.QCDB01.分析資料) = (From A In Query Where A.日期DateFormat = EachDateTemp And A.爐號 Like "A*" Select A).ToList
            Dim FindIndexDataB As List(Of CompanyORMDB.SQLServer.QCDB01.分析資料) = (From A In Query Where A.日期DateFormat = EachDateTemp And A.爐號 Like "B*" Select A).ToList
            '產生每天最多20筆資料
            For RowCount As Integer = 0 To 19
                Dim AddRow As SMPWork.ReportUseDataSet.AB爐分析資料Row = ReturnValue.NewAB爐分析資料Row
                With AddRow
                    If FindIndexDataA.Count - 1 >= RowCount Then
                        .A爐號 = FindIndexDataA(RowCount).爐號
                        .A備註1 = FindIndexDataA(RowCount).備註1
                        .A輻射 = FindIndexDataA(RowCount).輻射
                        .A判定 = IIf(.A備註1 = "" Or .A輻射 = 0, "", IIf(.A備註1 >= "8.0" Or .A輻射 > 8, "X", "V"))
                        .A操作員 = FindIndexDataA(RowCount).操作員
                    End If
                    If FindIndexDataB.Count - 1 >= RowCount Then
                        .B爐號 = FindIndexDataB(RowCount).爐號
                        .B備註1 = FindIndexDataB(RowCount).備註1
                        .B輻射 = FindIndexDataB(RowCount).輻射
                        .B判定 = IIf(.B備註1 = "" Or .B輻射 = 0, "", IIf(.B備註1 >= "8.0" Or .B輻射 > 8, "X", "V"))
                        .B操作員 = FindIndexDataB(RowCount).操作員
                    End If
                    .A日期 = Format(EachDate, "yyyyMMdd")
                End With
                ReturnValue.Rows.Add(AddRow)
            Next
        Next

        'Return New List(Of SMPWork.ReportUseDataSet.AB爐分析資料Row)
        Return ReturnValue
    End Function

    '篩選只取成品最後一塊
    Private Function FilterLastProductSample(ByVal DataSource As List(Of CompanyORMDB.SQLServer.QCDB01.分析資料)) As List(Of CompanyORMDB.SQLServer.QCDB01.分析資料)
        Dim ReturnValue As New List(Of CompanyORMDB.SQLServer.QCDB01.分析資料)
        Dim AddItem As CompanyORMDB.SQLServer.QCDB01.分析資料 = Nothing
        For Each EachStoveNumber As String In (From A In DataSource Select A.爐號 Distinct).ToList
            Dim EachStoveNumberTemp As String = EachStoveNumber
            AddItem = (From A In DataSource Where A.爐號 = EachStoveNumberTemp And A.站別.Substring(0, 1) = "S" Select A Order By A.站別 Descending).FirstOrDefault
            If Not IsNothing(AddItem) Then
                ReturnValue.Add(AddItem) : Continue For
            End If
            AddItem = (From A In DataSource Where A.爐號 = EachStoveNumberTemp And A.站別.Substring(0, 1) = "C" Select A Order By A.站別 Descending).FirstOrDefault
            If Not IsNothing(AddItem) Then
                ReturnValue.Add(AddItem) : Continue For
            End If
            AddItem = (From A In DataSource Where A.爐號 = EachStoveNumberTemp And A.站別.Substring(0, 1) = "L" Select A Order By A.站別 Descending).FirstOrDefault
            If Not IsNothing(AddItem) Then
                ReturnValue.Add(AddItem) : Continue For
            End If
        Next
        Return ReturnValue
    End Function
#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TextBox1.Text = Format(Now, "yyyy/MM/dd")
            Me.TextBox2.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub


    Protected Sub btnReportMaker_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReportMaker.Click
        Dim SearchDataRow As List(Of String) = (From A In Search(Me.TextBox1.Text, Me.TextBox2.Text).Rows Select CType(CType(A, SMPWork.ReportUseDataSet.AB爐分析資料Row).A日期, String).Trim Distinct).ToList
        Dim EachPageDates As String = Nothing
        For Each EachItem As String In SearchDataRow
            EachPageDates &= IIf(IsNothing(EachPageDates), Nothing, ",") & EachItem.Substring(0, 4) & "/" & EachItem.Substring(4, 2) & "/" & EachItem.Substring(6, 2)
        Next
        EachPageDates &= ""

        ReportViewer1.Visible = True
        'Dim Parameters(1) As Microsoft.Reporting.WebForms.ReportParameter
        'Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("PageNumber", RadioButtonList1.SelectedValue)
        'Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("EachPageDates", EachPageDates)
        'ReportViewer1.LocalReport.SetParameters(Parameters)
        Dim Parameters(1) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("PageNumber", 1)
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("EachPageDates", EachPageDates)
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.DataBind()
        ReportViewer1.LocalReport.Refresh()
    End Sub


End Class