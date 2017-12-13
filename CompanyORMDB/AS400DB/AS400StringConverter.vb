Public Class AS400StringConverter

    Sub New(ByVal SetSourceString As String, ByVal SetSourceDataType As SourceDataTypeEnum)
        Me.SourceString = SetSourceString
        Me.SourceDataType = SetSourceDataType
    End Sub

#Region "重新設定來源字串 函式:ResetSourceString"
    ''' <summary>
    ''' 重新設定來源字串
    ''' </summary>
    ''' <param name="SetSourceString"></param>
    ''' <param name="SetSourceDataType"></param>
    ''' <remarks></remarks>
    Public Sub ResetSourceString(ByVal SetSourceString As String, ByVal SetSourceDataType As SourceDataTypeEnum)
        Me.SourceString = SetSourceString
        Me.SourceDataType = SetSourceDataType
    End Sub
#End Region

#Region "原始資料 屬性:SourceString"

    Private _SourceString As String
    ''' <summary>
    ''' 原始資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceString() As String
        Get
            Return _SourceString
        End Get
        Private Set(ByVal value As String)
            _SourceString = value
        End Set
    End Property

#End Region
#Region "原始資料來源 屬性:SourceDataType"

    Private _SourceDataType As SourceDataTypeEnum
    ''' <summary>
    ''' 原始資料來源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceDataType() As SourceDataTypeEnum
        Get
            Return _SourceDataType
        End Get
        Private Set(ByVal value As SourceDataTypeEnum)
            _SourceDataType = value
        End Set
    End Property

#End Region

#Region "輸出400字串 屬性:OutPut400String"
    ''' <summary>
    ''' 輸出400字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property OutPut400String() As String
        Get
            If Me.SourceDataType = SourceDataTypeEnum.AS400 Then
                Return Me.SourceString
            End If
            Return Me.SourceString.Replace("銹", "").Replace("銹", "")
        End Get
    End Property
#End Region
#Region "輸出PC字串 屬性:OutPutPCString"
    ''' <summary>
    ''' 輸出PC字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property OutPutPCString() As String
        Get
            If Me.SourceDataType = SourceDataTypeEnum.PC Then
                Return Me.SourceString
            End If
            Return Me.SourceString.Replace("", "銹").Replace("", "銹")
        End Get
    End Property
#End Region


#Region "快速轉換 方法:QuickConvert"
    Shared Converter As New AS400StringConverter(Nothing, SourceDataTypeEnum.AS400)
    ''' <summary>
    ''' 快速轉換
    ''' </summary>
    ''' <param name="SetSourceString"></param>
    ''' <param name="SetSourceDataType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function QuickConvert(ByVal SetSourceString As String, ByVal SetSourceDataType As SourceDataTypeEnum) As String
        Converter.ResetSourceString(SetSourceString, SetSourceDataType)
        If Converter.SourceDataType = SourceDataTypeEnum.AS400 Then
            Return Converter.OutPutPCString
        End If
        Return Converter.OutPut400String
    End Function
#End Region

    Public Enum SourceDataTypeEnum
        AS400 = 1
        PC = 2
    End Enum

End Class
