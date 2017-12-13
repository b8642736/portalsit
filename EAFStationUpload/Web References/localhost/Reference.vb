﻿'------------------------------------------------------------------------------
' <auto-generated>
'     這段程式碼是由工具產生的。
'     執行階段版本:4.0.30319.1
'
'     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
'     變更將會遺失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'原始程式碼已由 Microsoft.VSDesigner 自動產生，版本 4.0.30319.1。
'
Namespace localhost
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="EAFServiceSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class EAFService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private ConvertExcelFileToDataBaseOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.EAFStationUpload.My.MySettings.Default.EAFStationUpload_localhost_EAFService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event ConvertExcelFileToDataBaseCompleted As ConvertExcelFileToDataBaseCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConvertExcelFileToDataBase", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ConvertExcelFileToDataBase(<System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> ByVal FileData() As Byte, ByVal SourceFileName As String) As String
            Dim results() As Object = Me.Invoke("ConvertExcelFileToDataBase", New Object() {FileData, SourceFileName})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ConvertExcelFileToDataBaseAsync(ByVal FileData() As Byte, ByVal SourceFileName As String)
            Me.ConvertExcelFileToDataBaseAsync(FileData, SourceFileName, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ConvertExcelFileToDataBaseAsync(ByVal FileData() As Byte, ByVal SourceFileName As String, ByVal userState As Object)
            If (Me.ConvertExcelFileToDataBaseOperationCompleted Is Nothing) Then
                Me.ConvertExcelFileToDataBaseOperationCompleted = AddressOf Me.OnConvertExcelFileToDataBaseOperationCompleted
            End If
            Me.InvokeAsync("ConvertExcelFileToDataBase", New Object() {FileData, SourceFileName}, Me.ConvertExcelFileToDataBaseOperationCompleted, userState)
        End Sub
        
        Private Sub OnConvertExcelFileToDataBaseOperationCompleted(ByVal arg As Object)
            If (Not (Me.ConvertExcelFileToDataBaseCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ConvertExcelFileToDataBaseCompleted(Me, New ConvertExcelFileToDataBaseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub ConvertExcelFileToDataBaseCompletedEventHandler(ByVal sender As Object, ByVal e As ConvertExcelFileToDataBaseCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ConvertExcelFileToDataBaseCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
