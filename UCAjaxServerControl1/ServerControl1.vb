Public Class ServerControl1
    Inherits ScriptControl

    Protected Overrides Function GetScriptDescriptors() As IEnumerable(Of ScriptDescriptor)
        Dim descriptor As New ScriptControlDescriptor("UCAjaxServerControl1.ClientControl1", Me.ClientID)

        Return New List(Of ScriptDescriptor) From {descriptor}
    End Function

    ' 產生指令碼參考
    Protected Overrides Function GetScriptReferences() As IEnumerable(Of ScriptReference)
        Dim scriptRef As New ScriptReference("UCAjaxServerControl1.ClientControl1.js", Me.GetType().Assembly.FullName)

        Return New List(Of ScriptReference) From {scriptRef}
    End Function
End Class
