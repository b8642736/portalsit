Partial Public Class SMPMethodToSMPStandardSample
    Dim DBContext As New SMPDataContext

#Region "是否停用 屬性:IsNOUseString"
    ''' <summary>
    ''' 是否停用
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsNOUseString() As String
        Get
            Return IIf(Me.About_SMPMethod.IsNOUse OrElse Me.About_SMPStandardSample.IsNOUse, "已停用!", "啟用中")
        End Get
    End Property
#End Region


#Region "相關SMPMethod 屬性:About_SMPMethod"

    Private _About_SMPMethod As SMPMethod
    ''' <summary>
    ''' 相關SMPMethod
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property About_SMPMethod() As SMPMethod
        Get
            If IsNothing(_About_SMPMethod) Then
                _About_SMPMethod = (From A In DBContext.SMPMethod Where A.MethodNumber = Me.SMPMethodNumber Select A).FirstOrDefault
            End If
            Return _About_SMPMethod
        End Get
    End Property

#End Region

#Region "相關SMPStandardSample 屬性:About_SMPStandardSample"

    Private _About_SMPStandardSample As SMPStandardSample
    ''' <summary>
    ''' 相關SMPStandardSample
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property About_SMPStandardSample() As SMPStandardSample
        Get
            If IsNothing(_About_SMPStandardSample) Then
                _About_SMPStandardSample = (From A In DBContext.SMPStandardSample Where A.SampleNumber = Me.SMPSampleNumber Select A).FirstOrDefault
            End If
            Return _About_SMPStandardSample
        End Get
    End Property

#End Region


End Class
