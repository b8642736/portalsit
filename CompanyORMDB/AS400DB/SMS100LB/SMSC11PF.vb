Namespace SMS100LB
Public Class SMSC11PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SMS100LB", GetType(SMSC11PF).Name)
	End Sub

#Region "爐號 屬性:T1"
	Private _T1 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T1 () As System.String
		Get
			Return _T1
		End Get
		Set(Byval value as System.String)
                _T1 = value
		End Set
	End Property
#End Region
#Region "日期 屬性:T2"
	Private _T2 As System.Int32
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T2 () As System.Int32
		Get
			Return _T2
		End Get
		Set(Byval value as System.Int32)
                _T2 = value
		End Set
	End Property
#End Region
#Region "時間 屬性:T3"
	Private _T3 As System.String
	''' <summary>
	''' 時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property T3() As System.String
            Get
                Return _T3
            End Get
            Set(ByVal value As System.String)
                _T3 = value.Trim
            End Set
        End Property
#End Region
#Region "AR1狀況 屬性:T4"
        Private _T4 As System.Int32
        ''' <summary>
        ''' AR狀況
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
#Region "溫度 屬性:T5"
	Private _T5 As System.Int32
	''' <summary>
	''' 溫度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T5 () As System.Int32
		Get
			Return _T5
		End Get
		Set(Byval value as System.Int32)
			_T5 = value
		End Set
	End Property
#End Region
#Region "AR壓力 屬性:T6"
	Private _T6 As System.Single
	''' <summary>
	''' AR壓力
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T6 () As System.Single
		Get
			Return _T6
		End Get
		Set(Byval value as System.Single)
			_T6 = value
		End Set
	End Property
#End Region
#Region "AR流量 屬性:T7"
	Private _T7 As System.Int32
	''' <summary>
	''' AR流量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T7 () As System.Int32
		Get
			Return _T7
		End Get
		Set(Byval value as System.Int32)
			_T7 = value
		End Set
	End Property
#End Region
#Region "AR2狀況 屬性:T8"
        Private _T8 As System.Int32
        ''' <summary>
        ''' AR狀況
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

#Region "溫降 屬性:DownTempature"
        ''' <summary>
        ''' 溫降
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property DownTempature As String
            Get
                Dim PreRecord As SMSC11PF = Nothing
                For Each EachItem As SMSC11PF In Me.AboutAllT1_SMSC11PFs
                    If EachItem.T1 = Me.T1 AndAlso EachItem.T2 = Me.T2 AndAlso EachItem.T3 = Me.T3 Then
                        If IsNothing(PreRecord) OrElse PreRecord.T5 <= 0 Then
                            Return "-"
                        Else
                            Return Math.Abs((Me.T5 - PreRecord.T5)).ToString
                        End If
                    End If
                    PreRecord = EachItem
                Next
                Return "-"
            End Get
        End Property
#End Region
#Region "攪拌時間 屬性:MixTime"
        ''' <summary>
        ''' 攪拌時間
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property MixTime As String
            Get
                Dim PreRecord As SMSC11PF = Nothing
                For Each EachItem As SMSC11PF In Me.AboutAllT1_SMSC11PFs
                    If EachItem.T1 = Me.T1 AndAlso EachItem.T2 = Me.T2 AndAlso EachItem.T3 = Me.T3 Then
                        If IsNothing(PreRecord) Then
                            PreRecord = EachItem
                            Continue For
                        End If

                        If String.IsNullOrEmpty(Me.T3) OrElse String.IsNullOrEmpty(PreRecord.T3) Then
                            Return "-"
                        End If
                        Dim PreTime As DateTime = (New Date(2000, 1, 1)).AddHours(Val(PreRecord.T3.ToString.PadLeft(4, "0").Substring(0, 2))).AddMinutes(Val(PreRecord.T3.ToString.PadLeft(4, "0").Substring(2, 2)))
                        Dim MyTime As DateTime = (New Date(2000, 1, 1)).AddHours(Val(EachItem.T3.ToString.PadLeft(4, "0").Substring(0, 2))).AddMinutes(Val(EachItem.T3.ToString.PadLeft(4, "0").Substring(2, 2)))
                        If MyTime < PreTime Then
                            PreTime.AddDays(-1)
                        End If
                        Return MyTime.Subtract(PreTime).TotalMinutes
                    End If
                    PreRecord = EachItem
                Next
                Return "-"
            End Get
        End Property
#End Region
#Region "溫降速度 屬性:DownTempatureSpeed"
        ''' <summary>
        ''' 溫降速度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property DownTempatureSpeed As String
            Get
                If String.IsNullOrEmpty(Me.DownTempature) OrElse Me.DownTempature = "-" _
                    OrElse String.IsNullOrEmpty(Me.MixTime) OrElse Me.MixTime = "-" Then
                    Return "-"
                End If
                Dim DowTempature As Single = Val(Me.DownTempature)
                Dim UseMixTime As Single = Val(Me.MixTime)
                If DownTempature = 0 OrElse UseMixTime = 0 Then
                    Return "-"
                End If
                Return Format(DownTempature / UseMixTime, "0.00")
            End Get
        End Property
#End Region



#Region "相關爐號所有攪拌資料 屬性:AboutAllT1_SMSC11PFs"
        Private _AboutAllT1_SMSC11PFs As List(Of SMSC11PF) = Nothing
        ''' <summary>
        ''' 相關爐號所有攪拌資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAllT1_SMSC11PFs As List(Of SMSC11PF)
            Get
                Static LastGetDataTime As DateTime = Now.AddMinutes(-1)
                If Now.Subtract(LastGetDataTime).TotalSeconds > 3 AndAlso IsNothing(_AboutAllT1_SMSC11PFs) OrElse _AboutAllT1_SMSC11PFs.Count = 0 Then
                    _AboutAllT1_SMSC11PFs = SMSC11PF.CDBSelect(Of SMSC11PF)("Select * from @#SMS100LB.SMSC11PF WHERE T1='" & Me.T1 & "' ORDER BY T2,T3", AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                LastGetDataTime = Now
                Return _AboutAllT1_SMSC11PFs
            End Get
        End Property
#End Region

    End Class
End Namespace