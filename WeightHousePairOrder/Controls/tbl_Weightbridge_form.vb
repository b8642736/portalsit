Public Class tbl_Weightbridge_form
    Property WF_No As Long
    Property WF_form_No As String
    Property WF_month_No As String
    Property WF_start_time As DateTime
    Property WF_complete_time As DateTime
    Property WF_Company_Name As String
    Property WF_Car_ID As String
    Property WF_first_Weight As Long
    Property WF_Tatol_Weight As Long
    Property WF_Empty_Weight As Long
    Property WF_Dead_Weight As Long
    Property WF_Form_type As String
    Property IsCompareTOContractDetail As Boolean   '是否已配置合約明細了

    Property OrginalDataRow As DataRow  '原始資料列

    Public Sub SetFieldValue(ByVal SetData As DataRow)
        With SetData
            Me.WF_No = SetData.Item("WF_No")
            Me.WF_form_No = SetData.Item("WF_form_No")
            Me.WF_month_No = SetData.Item("WF_month_No")
            Me.WF_start_time = SetData.Item("WF_start_time")
            Me.WF_complete_time = SetData.Item("WF_complete_time")
            Me.WF_Company_Name = SetData.Item("WF_Company_Name")
            Me.WF_Car_ID = SetData.Item("WF_Car_ID")
            Me.WF_first_Weight = SetData.Item("WF_first_Weight")
            Me.WF_Tatol_Weight = SetData.Item("WF_Tatol_Weight")
            Me.WF_Empty_Weight = SetData.Item("WF_Empty_Weight")
            Me.WF_Dead_Weight = SetData.Item("WF_Dead_Weight")
            Me.WF_Form_type = SetData.Item("WF_Form_type")
        End With
        OrginalDataRow = SetData
    End Sub

    Shared Function CreateDataByDataTable(ByVal SetDataTable As DataTable) As List(Of tbl_Weightbridge_form)
        Dim ReutrnValue As New List(Of tbl_Weightbridge_form)
        For Each EachItem As DataRow In SetDataTable.Rows
            Dim AddItem As New tbl_Weightbridge_form
            AddItem.SetFieldValue(EachItem)
            ReutrnValue.Add(AddItem)
        Next
        Return ReutrnValue
    End Function

End Class
