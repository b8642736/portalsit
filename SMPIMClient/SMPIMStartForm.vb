Public Class SMPIMStartForm

    Private Sub SMPIMStartForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AddControl As UCSMPIM = New UCSMPIM
        AddControl.Dock = DockStyle.Fill
        Me.Controls.Add(AddControl)
        If CompanyORMDB.DeviceInformation.GetLocalIPs.Count > 0 Then
            Me.Text &= "   本機IP:" & CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim
        End If
        If Not String.IsNullOrEmpty(My.User.Name) AndAlso My.User.Name.Trim.Length > 0 Then
            Me.Text &= "   Window登入名稱:" & My.User.Name.Trim
        Else
            Me.Text &= "   Window登入名稱:無"
        End If
        Dim CPUIDs As List(Of String) = CompanyORMDB.DeviceInformation.GetCpuIDs
        If CPUIDs.Count > 0 AndAlso Not String.IsNullOrEmpty(CPUIDs(0)) AndAlso CPUIDs(0).Trim.Length > 0 Then
            Me.Text &= "   本機CPU編號:" & CPUIDs(0).Trim
        End If
    End Sub
End Class