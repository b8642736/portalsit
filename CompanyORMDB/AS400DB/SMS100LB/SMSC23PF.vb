Namespace SMS100LB
    Public Class SMSC23PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SMS100LB", GetType(SMSC23PF).Name)
            Me.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            Me.T14 = Format(CreateUniqueNowTime, "HHmmss")
        End Sub

#Region "爐號 屬性:T1"
        Private _T1 As System.String
        ''' <summary>
        ''' 爐號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property T1() As System.String
            Get
                Return _T1
            End Get
            Set(ByVal value As System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T1 = value
            End Set
        End Property
#End Region
#Region "溫度及重量記錄表日期 屬性:T2"
        Private _T2 As System.Int32
        ''' <summary>
        ''' 溫度及重量記錄表日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property T2() As System.Int32
            Get
                Return _T2
            End Get
            Set(ByVal value As System.Int32)
                _T2 = value
            End Set
        End Property
#End Region
#Region "儲存時間 屬性:T14"
        Private _T14 As String
        ''' <summary>
        ''' 儲存時間
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property T14() As String
            Get
                Return _T14
            End Get
            Set(ByVal value As String)
                _T14 = value
            End Set
        End Property
#End Region
#Region "二水澆鑄速度 屬性:T3"
        Private _T3 As System.Single
        ''' <summary>
        ''' 二水澆鑄速度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T3() As System.Single
            Get
                Return _T3
            End Get
            Set(ByVal value As System.Single)
                _T3 = value
            End Set
        End Property
#End Region
#Region "二水噴水量MS 屬性:T4"
        Private _T4 As System.Int32
        ''' <summary>
        ''' 二水噴水量MS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T4() As System.Int32
            Get
                Return _T4
            End Get
            Set(ByVal value As System.Int32)
                _T4 = value
            End Set
        End Property
#End Region
#Region "二水噴水量1A 屬性:T5"
        Private _T5 As System.Int32
        ''' <summary>
        ''' 二水噴水量1A
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T5() As System.Int32
            Get
                Return _T5
            End Get
            Set(ByVal value As System.Int32)
                _T5 = value
            End Set
        End Property
#End Region
#Region "二水噴水量1B 屬性:T6"
        Private _T6 As System.Int32
        ''' <summary>
        ''' 二水噴水量1B1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T6() As System.Int32
            Get
                Return _T6
            End Get
            Set(ByVal value As System.Int32)
                _T6 = value
            End Set
        End Property
#End Region
#Region "二水噴水量NS 屬性:T7"
        Private _T7 As System.Int32
        ''' <summary>
        ''' 二水噴水量NS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T7() As System.Int32
            Get
                Return _T7
            End Get
            Set(ByVal value As System.Int32)
                _T7 = value
            End Set
        End Property
#End Region
#Region "二水噴水量2FS 屬性:T8"
        Private _T8 As System.Int32
        ''' <summary>
        ''' 二水噴水量2FS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T8() As System.Int32
            Get
                Return _T8
            End Get
            Set(ByVal value As System.Int32)
                _T8 = value
            End Set
        End Property
#End Region
#Region "二水噴水量2LS 屬性:T9"
        Private _T9 As System.Int32
        ''' <summary>
        ''' 二水噴水量2LS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T9() As System.Int32
            Get
                Return _T9
            End Get
            Set(ByVal value As System.Int32)
                _T9 = value
            End Set
        End Property
#End Region
#Region "二水噴水量3FS 屬性:T10"
        Private _T10 As System.Int32
        ''' <summary>
        ''' 二水噴水量3FS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T10() As System.Int32
            Get
                Return _T10
            End Get
            Set(ByVal value As System.Int32)
                _T10 = value
            End Set
        End Property
#End Region
#Region "二水噴水量3LS 屬性:T11"
        Private _T11 As System.Int32
        ''' <summary>
        ''' 二水噴水量3LS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T11() As System.Int32
            Get
                Return _T11
            End Get
            Set(ByVal value As System.Int32)
                _T11 = value
            End Set
        End Property
#End Region
#Region "二水噴水量4FS 屬性:T12"
        Private _T12 As System.Int32
        ''' <summary>
        ''' 二水噴水量4FS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T12() As System.Int32
            Get
                Return _T12
            End Get
            Set(ByVal value As System.Int32)
                _T12 = value
            End Set
        End Property
#End Region
#Region "二水噴水量4LS 屬性:T13"
        Private _T13 As System.Int32
        ''' <summary>
        ''' 二水噴水量4LS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T13() As System.Int32
            Get
                Return _T13
            End Get
            Set(ByVal value As System.Int32)
                _T13 = value
            End Set
        End Property
#End Region

#Region "產生唯一現在時間 方法:CreateUniqueNowTime"
        Private Shared _CreateUniqueNowTime As DateTime = New DateTime(2000, 1, 1)
        ''' <summary>
        ''' 產生唯一現在時間
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateUniqueNowTime() As DateTime
            Dim NowTime As DateTime = Now 'IIf(Now > _CreateUniqueNowTime, Now, _CreateUniqueNowTime)
            Select Case True
                Case Format(NowTime, "yyyy/MM/dd HH:mm:ss") > Format(_CreateUniqueNowTime, "yyyy/MM/dd HH:mm:ss")
                    _CreateUniqueNowTime = NowTime
                Case Format(NowTime, "yyyy/MM/dd HH:mm:ss") = Format(_CreateUniqueNowTime, "yyyy/MM/dd HH:mm:ss")
                    _CreateUniqueNowTime = NowTime.AddSeconds(1)
                Case Format(NowTime, "yyyy/MM/dd HH:mm:ss") < Format(_CreateUniqueNowTime, "yyyy/MM/dd HH:mm:ss")
                    _CreateUniqueNowTime = _CreateUniqueNowTime.AddSeconds(1)
            End Select


            Return _CreateUniqueNowTime
        End Function
#End Region

    End Class
End Namespace