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
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'原始程式碼已由 Microsoft.VSDesigner 自動產生，版本 4.0.30319.1。
'
Namespace Portalsit2
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WSDBSQLQuerySoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WSDBSQLQuery
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private GetServerTimeOperationCompleted As System.Threading.SendOrPostCallback
        
        Private AS400SelectQueryOperationCompleted As System.Threading.SendOrPostCallback
        
        Private AS400ExecuteNonQueryOperationCompleted As System.Threading.SendOrPostCallback
        
        Private SQLServerSelectQueryOperationCompleted As System.Threading.SendOrPostCallback
        
        Private SQLServerExecuteNonQueryOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.CompanyORMDB.My.MySettings.Default.CompanyORMDB_Portalsit2_WSDBSQLQuery
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
        Public Event GetServerTimeCompleted As GetServerTimeCompletedEventHandler
        
        '''<remarks/>
        Public Event AS400SelectQueryCompleted As AS400SelectQueryCompletedEventHandler
        
        '''<remarks/>
        Public Event AS400ExecuteNonQueryCompleted As AS400ExecuteNonQueryCompletedEventHandler
        
        '''<remarks/>
        Public Event SQLServerSelectQueryCompleted As SQLServerSelectQueryCompletedEventHandler
        
        '''<remarks/>
        Public Event SQLServerExecuteNonQueryCompleted As SQLServerExecuteNonQueryCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetServerTime", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetServerTime() As Date
            Dim results() As Object = Me.Invoke("GetServerTime", New Object(-1) {})
            Return CType(results(0),Date)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetServerTimeAsync()
            Me.GetServerTimeAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetServerTimeAsync(ByVal userState As Object)
            If (Me.GetServerTimeOperationCompleted Is Nothing) Then
                Me.GetServerTimeOperationCompleted = AddressOf Me.OnGetServerTimeOperationCompleted
            End If
            Me.InvokeAsync("GetServerTime", New Object(-1) {}, Me.GetServerTimeOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetServerTimeOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetServerTimeCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetServerTimeCompleted(Me, New GetServerTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AS400SelectQuery", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function AS400SelectQuery(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As System.Data.DataTable
            Dim results() As Object = Me.Invoke("AS400SelectQuery", New Object() {SetSourceQueryString, AcceptCodeReplay})
            Return CType(results(0),System.Data.DataTable)
        End Function
        
        '''<remarks/>
        Public Overloads Sub AS400SelectQueryAsync(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String)
            Me.AS400SelectQueryAsync(SetSourceQueryString, AcceptCodeReplay, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub AS400SelectQueryAsync(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String, ByVal userState As Object)
            If (Me.AS400SelectQueryOperationCompleted Is Nothing) Then
                Me.AS400SelectQueryOperationCompleted = AddressOf Me.OnAS400SelectQueryOperationCompleted
            End If
            Me.InvokeAsync("AS400SelectQuery", New Object() {SetSourceQueryString, AcceptCodeReplay}, Me.AS400SelectQueryOperationCompleted, userState)
        End Sub
        
        Private Sub OnAS400SelectQueryOperationCompleted(ByVal arg As Object)
            If (Not (Me.AS400SelectQueryCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AS400SelectQueryCompleted(Me, New AS400SelectQueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AS400ExecuteNonQuery", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function AS400ExecuteNonQuery(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As Integer
            Dim results() As Object = Me.Invoke("AS400ExecuteNonQuery", New Object() {SetSourceQueryString, AcceptCodeReplay})
            Return CType(results(0),Integer)
        End Function
        
        '''<remarks/>
        Public Overloads Sub AS400ExecuteNonQueryAsync(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String)
            Me.AS400ExecuteNonQueryAsync(SetSourceQueryString, AcceptCodeReplay, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub AS400ExecuteNonQueryAsync(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String, ByVal userState As Object)
            If (Me.AS400ExecuteNonQueryOperationCompleted Is Nothing) Then
                Me.AS400ExecuteNonQueryOperationCompleted = AddressOf Me.OnAS400ExecuteNonQueryOperationCompleted
            End If
            Me.InvokeAsync("AS400ExecuteNonQuery", New Object() {SetSourceQueryString, AcceptCodeReplay}, Me.AS400ExecuteNonQueryOperationCompleted, userState)
        End Sub
        
        Private Sub OnAS400ExecuteNonQueryOperationCompleted(ByVal arg As Object)
            If (Not (Me.AS400ExecuteNonQueryCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AS400ExecuteNonQueryCompleted(Me, New AS400ExecuteNonQueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SQLServerSelectQuery", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function SQLServerSelectQuery(ByVal SetSourceQueryString As String, ByVal SetSQLServerConnectionString As String, ByVal AcceptCodeReplay As String) As System.Data.DataTable
            Dim results() As Object = Me.Invoke("SQLServerSelectQuery", New Object() {SetSourceQueryString, SetSQLServerConnectionString, AcceptCodeReplay})
            Return CType(results(0),System.Data.DataTable)
        End Function
        
        '''<remarks/>
        Public Overloads Sub SQLServerSelectQueryAsync(ByVal SetSourceQueryString As String, ByVal SetSQLServerConnectionString As String, ByVal AcceptCodeReplay As String)
            Me.SQLServerSelectQueryAsync(SetSourceQueryString, SetSQLServerConnectionString, AcceptCodeReplay, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SQLServerSelectQueryAsync(ByVal SetSourceQueryString As String, ByVal SetSQLServerConnectionString As String, ByVal AcceptCodeReplay As String, ByVal userState As Object)
            If (Me.SQLServerSelectQueryOperationCompleted Is Nothing) Then
                Me.SQLServerSelectQueryOperationCompleted = AddressOf Me.OnSQLServerSelectQueryOperationCompleted
            End If
            Me.InvokeAsync("SQLServerSelectQuery", New Object() {SetSourceQueryString, SetSQLServerConnectionString, AcceptCodeReplay}, Me.SQLServerSelectQueryOperationCompleted, userState)
        End Sub
        
        Private Sub OnSQLServerSelectQueryOperationCompleted(ByVal arg As Object)
            If (Not (Me.SQLServerSelectQueryCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SQLServerSelectQueryCompleted(Me, New SQLServerSelectQueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SQLServerExecuteNonQuery", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function SQLServerExecuteNonQuery(ByVal SetSourceQueryString As String, ByVal SetSQLServerConnectionString As String, ByVal AcceptCodeReplay As String) As Integer
            Dim results() As Object = Me.Invoke("SQLServerExecuteNonQuery", New Object() {SetSourceQueryString, SetSQLServerConnectionString, AcceptCodeReplay})
            Return CType(results(0),Integer)
        End Function
        
        '''<remarks/>
        Public Overloads Sub SQLServerExecuteNonQueryAsync(ByVal SetSourceQueryString As String, ByVal SetSQLServerConnectionString As String, ByVal AcceptCodeReplay As String)
            Me.SQLServerExecuteNonQueryAsync(SetSourceQueryString, SetSQLServerConnectionString, AcceptCodeReplay, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SQLServerExecuteNonQueryAsync(ByVal SetSourceQueryString As String, ByVal SetSQLServerConnectionString As String, ByVal AcceptCodeReplay As String, ByVal userState As Object)
            If (Me.SQLServerExecuteNonQueryOperationCompleted Is Nothing) Then
                Me.SQLServerExecuteNonQueryOperationCompleted = AddressOf Me.OnSQLServerExecuteNonQueryOperationCompleted
            End If
            Me.InvokeAsync("SQLServerExecuteNonQuery", New Object() {SetSourceQueryString, SetSQLServerConnectionString, AcceptCodeReplay}, Me.SQLServerExecuteNonQueryOperationCompleted, userState)
        End Sub
        
        Private Sub OnSQLServerExecuteNonQueryOperationCompleted(ByVal arg As Object)
            If (Not (Me.SQLServerExecuteNonQueryCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SQLServerExecuteNonQueryCompleted(Me, New SQLServerExecuteNonQueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub GetServerTimeCompletedEventHandler(ByVal sender As Object, ByVal e As GetServerTimeCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetServerTimeCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Date
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Date)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub AS400SelectQueryCompletedEventHandler(ByVal sender As Object, ByVal e As AS400SelectQueryCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class AS400SelectQueryCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataTable
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataTable)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub AS400ExecuteNonQueryCompletedEventHandler(ByVal sender As Object, ByVal e As AS400ExecuteNonQueryCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class AS400ExecuteNonQueryCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Integer
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Integer)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub SQLServerSelectQueryCompletedEventHandler(ByVal sender As Object, ByVal e As SQLServerSelectQueryCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class SQLServerSelectQueryCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataTable
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataTable)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub SQLServerExecuteNonQueryCompletedEventHandler(ByVal sender As Object, ByVal e As SQLServerExecuteNonQueryCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class SQLServerExecuteNonQueryCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Integer
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Integer)
            End Get
        End Property
    End Class
End Namespace