Partial Public Class EAFT2_Analysis
    Dim DBContext As New EAFDataContext
#Region "作業內容時間(分) 屬性:TIME"
    ''' <summary>
    ''' 作業內容時間(分)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TIME() As Integer
        Get
            Dim FirtOperatorType As EAFT2_OperatorType = (From A In Me.DBContext.EAFT2_OperatorType Where Me.FK_OperatorTypeID = A.OperatorTypeID Select A).FirstOrDefault
            Dim SecondOperatorType As EAFT2_OperatorType = Nothing
            Select Case FirtOperatorType.OperatorTypeID
                Case EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電I)
                    SecondOperatorType = EAFT2_OperatorType.FindOperatorType(OperatorTypeEnum.準備送電II)
                Case EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電II)
                    SecondOperatorType = EAFT2_OperatorType.FindOperatorType(OperatorTypeEnum.準備送電III)
                Case EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電III)
                    SecondOperatorType = EAFT2_OperatorType.FindOperatorType(OperatorTypeEnum.準備送電IV)
                Case EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電IV)
                    SecondOperatorType = EAFT2_OperatorType.FindOperatorType(OperatorTypeEnum.MD)
            End Select
            If IsNothing(FirtOperatorType) OrElse IsNothing(SecondOperatorType) Then
                Return 0
            End If


            Dim FirtOperator As EAFT2 = (From A In Me.EAFT1.EAFT2 Where A.FK_OperatorTypeID = FirtOperatorType.OperatorTypeID Select A Order By A.StartTime Ascending).FirstOrDefault
            Dim SecondOperator As EAFT2 = (From A In Me.EAFT1.EAFT2 Where A.FK_OperatorTypeID = SecondOperatorType.OperatorTypeID And A.IsInputStartTime = True Select A Order By A.StartTime Ascending).FirstOrDefault
            If IsNothing(SecondOperator) Then
                SecondOperator = (From A In Me.EAFT1.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorType(OperatorTypeEnum.MD).OperatorTypeID Select A Order By A.StartTime Ascending).FirstOrDefault
            End If
            If IsNothing(FirtOperator) OrElse IsNothing(SecondOperator) Then
                Return 0
            End If

            Dim SessonOperatorTypes As List(Of EAFT2_OperatorType) = (From A In Me.DBContext.EAFT2_OperatorType Where A.OperatorOrder >= FirtOperatorType.OperatorOrder AndAlso A.OperatorOrder < SecondOperatorType.OperatorOrder Select A Order By A.OperatorOrder).ToList
            Dim ReturnValue As Integer = SecondOperator.StartTime.Subtract(FirtOperator.StartTime).TotalMinutes
            Dim TotalWaitThingsMinutes As Integer = 0
            For Each EachItem In (From A In Me.EAFT1.EAFT2_Wait, B In SessonOperatorTypes Where A.FK_OperatorTypeID = B.OperatorTypeID Select A)
                TotalWaitThingsMinutes += EachItem.EndTime.Subtract(EachItem.StartTime).TotalMinutes
            Next
            Return ReturnValue - TotalWaitThingsMinutes
        End Get
    End Property
#End Region
#Region "KWH100值 屬性:KWH100"
    ''' <summary>
    ''' KWH100值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property KWH100() As Single
        Get
            Dim FirstEAF2 = (From A In Me.EAFT1.EAFT2 Where A.FK_OperatorTypeID = Me.FK_OperatorTypeID And A.ElectricPower > 0 Select A Order By A.StartTime Ascending).FirstOrDefault
            Dim NextEAFT2 = (From A In Me.EAFT1.EAFT2 Where A.FK_OperatorTypeID = Me.FK_OperatorTypeID + 1 And A.ElectricPower > 0 Select A Order By A.StartTime Ascending).FirstOrDefault
            Dim MDOperator = (From A In Me.EAFT1.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.MD) And A.ElectricPower > 0 Select A Order By A.StartTime Ascending).FirstOrDefault
            If IsNothing(FirstEAF2) OrElse IsNothing(NextEAFT2) AndAlso IsNothing(MDOperator) Then
                Return 0
            End If
            If IsNothing(NextEAFT2) Then
                Return FirstEAF2.ElectricPower - NextEAFT2.ElectricPower
            Else
                Return FirstEAF2.ElectricPower - MDOperator.ElectricPower
            End If
        End Get
    End Property
#End Region
#Region "TIME除TONE值 屬性:TIMEDivTONE"
    ''' <summary>
    ''' TIME除TONE值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TIMEDivTONE() As Single
        Get
            If Me.TONValue = 0 Then
                Return 0
            End If
            Return Me.TIME / Me.TONValue
        End Get
    End Property


#End Region
#Region "KWH除TONE值 屬性:KWHDivTONE"
    ''' <summary>
    ''' KWH除TONE值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property KWHDivTONE() As Single
        Get
            If Me.TONValue = 0 Then
                Return 0
            End If
            Return Me.KWH100 / Me.TONValue * 100
        End Get
    End Property
#End Region
#Region "KWH除TIME值 屬性:KWHDivTIME"
    ''' <summary>
    ''' KWH除TONE值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property KWHDivTIME() As Single
        Get
            If Me.TIME = 0 Then
                Return 0
            End If
            Return Me.KWH100 / Me.TIME * 100
        End Get
    End Property
#End Region

End Class
