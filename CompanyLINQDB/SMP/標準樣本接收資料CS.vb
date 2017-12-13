Partial Public Class 標準樣本接收資料CS

    Dim DataContext As New SMPDataContext

#Region "資料顯示模式 屬性:DataDisplayMode"

    Private _DataDisplayMode As DataDisplayModeEnum = DataDisplayModeEnum.RealDataMode
    ''' <summary>
    ''' 資料顯示模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>NormalMode:原始資料模式 ,ForCheckMode:應付檢查資料調整模式</remarks>
    Public Property DataDisplayMode() As DataDisplayModeEnum
        Get
            Return _DataDisplayMode
        End Get
        Set(ByVal value As DataDisplayModeEnum)
            Dim IsModeChanged As Boolean = (_DataDisplayMode <> value)
            _DataDisplayMode = value
            If _DataDisplayMode = DataDisplayModeEnum.ForCheckMode Then
                Dim RangeData As 標準樣本接收資料上下限 = About標準樣本接收資料上下限
                If IsNothing(RangeData) Then
                    Throw New Exception("找不到標準樣本接收資料上下限")
                End If
                If Not IsNothing(RangeData.UP_C) AndAlso Me.C1 > RangeData.UP_C Then
                    Me.C1 = RangeData.UP_C
                End If
                If Not IsNothing(RangeData.Down_C) AndAlso Me.C1 < RangeData.Down_C Then
                    Me.C1 = RangeData.Down_C
                End If
                If Not IsNothing(RangeData.UP_S) AndAlso Me.S1 > RangeData.UP_S Then
                    Me.S1 = RangeData.UP_S
                End If
                If Not IsNothing(RangeData.Down_S) AndAlso Me.S1 < RangeData.Down_S Then
                    Me.S1 = RangeData.Down_S
                End If
            End If
        End Set
    End Property

    Public Enum DataDisplayModeEnum
        RealDataMode = 0      '原始資料模式
        ForCheckMode = 1        '應付檢查資料調整模式
    End Enum
#End Region


#Region "相關SMPStandardSample 屬性:AboutSMPStandardSample"
    Shared _SMPStandardSampleDataCache As List(Of SMPStandardSample)
    Private _AboutSMPStandardSample As SMPStandardSample
    ''' <summary>
    ''' 相關SMPStandardSample
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutSMPStandardSample() As SMPStandardSample
        Get
            If IsNothing(_AboutSMPStandardSample) Then
                If IsNothing(_SMPStandardSampleDataCache) Then
                    _SMPStandardSampleDataCache = (From A In DataContext.SMPStandardSample Select A).ToList
                End If
                _AboutSMPStandardSample = (From A In _SMPStandardSampleDataCache Where A.SampleNumber.Trim = Me.SampleID.Trim Select A).FirstOrDefault
            End If
            Return _AboutSMPStandardSample
        End Get
        Private Set(ByVal value As SMPStandardSample)
            _AboutSMPStandardSample = value
        End Set
    End Property

#End Region

#Region "相關標準樣本接收資料上下限 屬性:About標準樣本接收資料上下限"
    Shared _About標準樣本接收資料上下限Cache As List(Of 標準樣本接收資料上下限)
    Private _About標準樣本接收資料上下限 As 標準樣本接收資料上下限
    ''' <summary>
    ''' 相關標準樣本接收資料上下限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property About標準樣本接收資料上下限() As 標準樣本接收資料上下限
        Get
            If IsNothing(_About標準樣本接收資料上下限) Then
                If IsNothing(_About標準樣本接收資料上下限Cache) Then
                    _About標準樣本接收資料上下限Cache = (From A In DataContext.標準樣本接收資料上下限 Select A).ToList
                End If
                _About標準樣本接收資料上下限 = (From A In _About標準樣本接收資料上下限Cache Where A.SampleNumber.Trim = Me.SampleID.Trim Select A).FirstOrDefault
            End If
            Return _About標準樣本接收資料上下限
        End Get
        Private Set(ByVal value As 標準樣本接收資料上下限)
            _About標準樣本接收資料上下限 = value
        End Set
    End Property

#End Region
End Class
