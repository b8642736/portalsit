Partial Public Class EAFT1

    Dim DBContext As New EAFDataContext

    Private Sub OnCreated()
        Me.ID = "{" & Guid.NewGuid.ToString & "}"
    End Sub

    '氧氣消耗量
#Region "氧氣消耗總量 屬性:TotalUseOxygan"
    ''' <summary>
    ''' 氧氣消耗總量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TotalUseOxygan() As Integer
        Get
            Return (From A In Me.EAFT2 Select A.Oxygen).ToArray.Sum
        End Get
    End Property
#End Region
#Region "用量 屬性:OxyganUseCapacity"
    ''' <summary>
    ''' 用量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property OxyganUseCapacity() As Single
        Get
            Dim Value2 As Long = Me.SumMaterial
            If Value2 = 0 Then
                Return 0
            End If
            Return Me.TotalUseOxygan / Value2
        End Get
    End Property
#End Region

    '電力消耗量KWH*100
#Region "終電力 屬性:TerminateElectricPower"
    ''' <summary>
    ''' 終電力
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TerminateElectricPower() As Decimal
        Get
            Return Me.StartElectricPower + Me.TotalElectricPower
        End Get
    End Property
#End Region
#Region "總電力 屬性:TotalElectricPower"
    ''' <summary>
    ''' 總電力
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TotalElectricPower() As Integer
        Get
            Dim GetTap As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.Tap) Select A).FirstOrDefault
            If IsNothing(GetTap) Then
                Return 0
            End If
            Return GetTap.ElectricPower
        End Get
    End Property
#End Region
#Region "MD值 屬性MD"
    ''' <summary>
    ''' MD值
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property MD() As Single
        Get
            Dim GetEAFT2MD As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.MD) Select A).FirstOrDefault
            Dim Value2 As Long = Me.SumMaterial
            If IsNothing(GetEAFT2MD) OrElse Value2 = 0 Then
                Return 0
            End If
            Return GetEAFT2MD.ElectricPower / Value2 * 100000
        End Get
    End Property

#End Region
#Region "用量 屬性:ElectricUseCapacity"
    ''' <summary>
    ''' 用量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ElectricUseCapacity() As Single
        Get
            Dim Value1 As Integer = Me.TotalElectricPower
            Dim Value2 As Long = Me.PackMaterial
            Return Value1 / Value2
        End Get
    End Property
#End Region

    '操作時間
#Region "接電極時間 屬性:ConnectPowerMinutes"
    ''' <summary>
    ''' 接電極時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ConnectPowerMinutes() As Integer
        Get
            Dim StartEAFT2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.前爐完) Select A).FirstOrDefault
            If IsNothing(StartEAFT2) Then
                Return 0
            End If
            Dim EndEAFT2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.接電極完) And A.StartTime > StartEAFT2.StartTime Select A).FirstOrDefault
            If IsNothing(EndEAFT2) Then
                Return 0
            End If
            Dim ReturnMinute As Integer = EndEAFT2.StartTime.Subtract(StartEAFT2.StartTime).TotalMinutes
            Dim WaitEventMinutes As Integer = (From A In Me.EAFT2_Wait Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.前爐完) And A.EndTime > A.StartTime Select A.WaitMinutes).ToArray.Sum
            Return ReturnMinute - WaitEventMinutes
        End Get
    End Property
#End Region
#Region "補爐時間 屬性:FettingMinutes"
    ''' <summary>
    ''' 補爐時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FettingMinutes() As Integer
        Get
            Dim EAFT2_1 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.前爐完) Select A).FirstOrDefault
            Dim EAFT2_2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.接電極完) Select A).FirstOrDefault
            Dim EAFT2_3 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.補爐完) Select A).FirstOrDefault
            Dim ReturnValue As Integer = 0
            If IsNothing(EAFT2_3) OrElse (IsNothing(EAFT2_2) And IsNothing(EAFT2_1)) Then
                Return 0
            End If
            If IsNothing(EAFT2_2) Then
                ReturnValue = EAFT2_1.StartTime.Subtract(EAFT2_3.StartTime).TotalMinutes
            Else
                ReturnValue = EAFT2_1.StartTime.Subtract(EAFT2_2.StartTime).TotalMinutes
            End If
            Dim EAFT2WaitTime As Integer = (From A In Me.EAFT2_Wait Where A.FK_OperatorTypeID = 2 Select A.WaitMinutes).ToArray.Sum
            Return ReturnValue - EAFT2WaitTime
        End Get
    End Property
#End Region
#Region "加料時間 屬性:ADDMaterialMinutes"
    ''' <summary>
    ''' 加料時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ADDMaterialMinutes() As Integer
        Get
            Dim SubValue As Integer = 0
            Dim ReturnValue As Integer = 0
            Dim FirstOperator As EAFT2 = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電I) Select a).FirstOrDefault
            If IsNothing(FirstOperator) Then
                FirstOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.補爐完) Select a).FirstOrDefault
                SubValue = (From A In Me.EAFT2_Wait Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.補爐完) Or A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電I) Select A.WaitMinutes).ToArray.Sum
            End If
            If IsNothing(FirstOperator) Then
                FirstOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.接電極完) Select a).FirstOrDefault
                SubValue = (From A In Me.EAFT2_Wait Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.補爐完) Or A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電I) Or A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.接電極完) Select A.WaitMinutes).ToArray.Sum
            End If
            If IsNothing(FirstOperator) Then
                FirstOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.前爐完) Select a).FirstOrDefault
                SubValue = (From A In Me.EAFT2_Wait Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.補爐完) Or A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電I) Or A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.接電極完) Or A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.前爐完) Select A.WaitMinutes).ToArray.Sum
            End If
            Dim SecondOperator As EAFT2 = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電I) Select a).FirstOrDefault
            If Not IsNothing(FirstOperator) AndAlso Not IsNothing(SecondOperator) Then
                ReturnValue += (SecondOperator.StartTime.Subtract(FirstOperator.StartTime).TotalMinutes - SubValue)
            End If

            FirstOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電II) Select a).FirstOrDefault
            SecondOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電II) Select a).FirstOrDefault
            If Not IsNothing(FirstOperator) AndAlso Not IsNothing(SecondOperator) Then
                SubValue = (From A In Me.EAFT2_Wait Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電II) Select A.WaitMinutes).ToArray.Sum
                ReturnValue += (SecondOperator.StartTime.Subtract(FirstOperator.StartTime).TotalMinutes - SubValue)
            End If

            FirstOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電III) Select a).FirstOrDefault
            SecondOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電III) Select a).FirstOrDefault
            If Not IsNothing(FirstOperator) AndAlso Not IsNothing(SecondOperator) Then
                SubValue = (From A In Me.EAFT2_Wait Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電III) Select A.WaitMinutes).ToArray.Sum
                ReturnValue += (SecondOperator.StartTime.Subtract(FirstOperator.StartTime).TotalMinutes - SubValue)
            End If

            FirstOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電IV) Select a).FirstOrDefault
            SecondOperator = (From a In Me.EAFT2 Where a.IsInputStartTime And a.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電IV) Select a).FirstOrDefault
            If Not IsNothing(FirstOperator) AndAlso Not IsNothing(SecondOperator) Then
                SubValue = (From A In Me.EAFT2_Wait Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.準備送電IV) Select A.WaitMinutes).ToArray.Sum
                ReturnValue += (SecondOperator.StartTime.Subtract(FirstOperator.StartTime).TotalMinutes - SubValue)
            End If

            Return ReturnValue
        End Get
    End Property
#End Region
#Region "溶解時間 屬性:DissolveMinutes"
    ''' <summary>
    ''' 溶解時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DissolveMinutes() As Integer
        Get
            'Dim ReturnValue As Integer = 0
            'For Each EachItem As EAFT2_Analysis In From A In Me.EAFT2_Analysis
            '    ReturnValue += EachItem.TIME
            'Next
            Return (From A In Me.EAFT2_Analysis Select A.TIME).ToArray.Sum
        End Get
    End Property
#End Region
#Region "精煉時間 屬性:RefineMinutes"
    ''' <summary>
    ''' 精煉時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RefineMinutes() As Integer
        Get
            Return Me.MD_TAP
        End Get
    End Property
#End Region
#Region "吹氧時間 屬性:OxygenBlastMinutes"
    ''' <summary>
    ''' 吹氧時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property OxygenBlastMinutes() As Integer
        Get
            Dim StartO2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.O2) Select A).FirstOrDefault
            Dim EndO2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.O2止) Select A).FirstOrDefault
            If IsNothing(StartO2) OrElse IsNothing(EndO2) Then
                Return 0
            End If
            Return EndO2.StartTime.Subtract(StartO2.StartTime).TotalMinutes
        End Get
    End Property
#End Region
#Region "出鋼時間 屬性:OutputSteelMinutes"
    ''' <summary>
    ''' 出鋼時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property OutputSteelMinutes() As Integer
        Get
            Dim EndEAFT2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.S3_T3) Select A).FirstOrDefault
            Dim StartEAFT2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.Tap) Select A).FirstOrDefault
            If IsNothing(StartEAFT2) OrElse IsNothing(EndEAFT2) Then
                Return 0
            End If
            Return EndEAFT2.StartTime.Subtract(StartEAFT2.StartTime).TotalMinutes
        End Get
    End Property
#End Region
#Region "操作時間小計 屬性:TotalOperatorMinutes"
    ''' <summary>
    ''' 操作時間小計
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TotalOperatorMinutes() As Integer
        Get
            Return Me.ConnectPowerMinutes + Me.FettingMinutes + Me.ADDMaterialMinutes + Me.DissolveMinutes + Me.RefineMinutes + Me.OxygenBlastMinutes + Me.OutputSteelMinutes
        End Get
    End Property
#End Region
#Region "Tap_Tap時間 屬性:Tap_TapMinutes"
    ''' <summary>
    ''' Tap_Tap時間 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Tap_TapMinutes() As Integer
        Get
            Return Me.TotalOperatorMinutes + Me.TotalWaitMinutes
        End Get
    End Property
#End Region
    '等待時間
#Region "雙口時間 屬性:DoubleMouseMinutes"
    ''' <summary>
    ''' 雙口時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DoubleMouseMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "清理出鋼口*" Or A.WaitReason Like "清理爐門口*" Or A.WaitReason Like "修補出鋼口*" Or A.WaitReason Like "修補爐門口*" Or A.WaitReason Like "撞爐門殘鋼*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "烘爐時間 屬性:RoastMinutes"
    ''' <summary>
    ''' 烘爐時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RoastMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "烘爐*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "刮爐壁時間 屬性:CleanStoveMinutes"
    ''' <summary>
    ''' 刮爐壁時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CleanStoveMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "清除爐壁渣*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "吊湯塊時間 屬性:RecycleIronMinutes"
    ''' <summary>
    ''' 吊湯塊時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RecycleIronMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "吊湯塊*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "吊壓廢鐵時間 屬性:HangScrapMinutes"
    ''' <summary>
    ''' 吊壓廢鐵時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property HangScrapMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "吊壓廢鐵*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "電力超載時間 屬性:ElectricPowerOverflowMinutes"
    ''' <summary>
    ''' 電力超載時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ElectricPowerOverflowMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "電力超載*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "清理排塵時間 屬性:CleanDustMinutes"
    ''' <summary>
    ''' 清理排塵時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CleanDustMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "清理排塵*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "更換爐蓋時間 屬性:ChangeCoverMinutes"
    ''' <summary>
    ''' 更換爐蓋時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ChangeCoverMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "更換爐蓋*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "水箱漏水時間 屬性:WaterTankLeakingMinutes"
    ''' <summary>
    ''' 水箱漏水時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaterTankLeakingMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "水箱漏水*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "更換出鋼槽時間 屬性:ChangeSteelTroughMinutes"
    ''' <summary>
    ''' 更換出鋼槽時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ChangeSteelTroughMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "更換出鋼槽*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "渣稠加渣材時間 屬性:AddTwoDregsMinutes"
    ''' <summary>
    ''' 渣稠加渣材時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AddTwoDregsMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "渣稠加渣材*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待盛鋼桶打渣時間 屬性:WaitSteelDregsToTupMinutes"
    ''' <summary>
    ''' 待盛鋼桶打渣時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitSteelDregsToTupMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待盛鋼桶打渣*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "配合擋板管制時間 屬性:WaitShieldMinutes"
    ''' <summary>
    ''' 配合擋板管制時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitShieldMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "配合擋板管制*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待煙大時間 屬性:WaitSmokeMinutes"
    ''' <summary>
    ''' 待煙大時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitSmokeMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "煙大暫停*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待AOD時間 屬性:WaitAODMinutes"
    ''' <summary>
    ''' 待AOD時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitAODMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待AOD*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待LD時間 屬性:WaitLDMinutes"
    ''' <summary>
    ''' 待LD時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitLDMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待LD*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待CCM時間 屬性:WaitCCMMinutes"
    ''' <summary>
    ''' 待CCM時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitCCMMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待CCM*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待加料時間 屬性:WaitAddMaterialMinutes"
    ''' <summary>
    ''' 待加料時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitAddMaterialMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待加料*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待天車時間 屬性:WaitSkyCarMinutes"
    ''' <summary>
    ''' 待天車時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitSkyCarMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待天車*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "斷電極時間 屬性:StopElectrodeMinutes"
    ''' <summary>
    ''' 斷電極時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property StopElectrodeMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "斷電極*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "爐蓋作動故障時間 屬性:CoverBreakdownMinutes"
    ''' <summary>
    ''' 爐蓋作動故障時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CoverBreakdownMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "爐蓋作動故障*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "傾爐作動故障時間 屬性:CoverInclineBreakdownMinutes"
    ''' <summary>
    ''' 傾爐作動故障時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CoverInclineBreakdownMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "傾爐作動故障*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "加料車故障時間 屬性:AddMaterialCarBreakdownMinutes"
    ''' <summary>
    ''' 加料車故障時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AddMaterialCarBreakdownMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "加料車故障*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "爐體短路時間 屬性:StoveBodyShortCircuitMinutes"
    ''' <summary>
    ''' 爐體短路時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property StoveBodyShortCircuitMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "爐體短路*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "補爐機故障時間 屬性:FettlingMachineBreakdownMinutes"
    ''' <summary>
    ''' 補爐機故障時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FettlingMachineBreakdownMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "補爐機故障時間*" Or A.WaitReason Like "補爐機皮管破*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "爐體部份漏水時間 屬性:StoveBodyLeakinessMinutes"
    ''' <summary>
    ''' 爐體部份漏水時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property StoveBodyLeakinessMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "爐體部份漏水*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待預保班查修時間 屬性:WaitFixPersonMinutes"
    ''' <summary>
    ''' 待預保班查修時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitFixPersonMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待預保班查修*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待AOD更換爐體時間 屬性:WaitChangeStoveMinutes"
    ''' <summary>
    ''' 待AOD更換爐體時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitChangeStoveMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待AOD更換爐體*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "待天車洗L/D時間 屬性:WaitSkyCarCleanLDMinutes"
    ''' <summary>
    ''' 待天車洗L/D時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitSkyCarCleanLDMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "待天車洗L/D*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "計劃性停爐時間 屬性:PlanStopMinutes"
    ''' <summary>
    ''' 計劃性停爐時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PlanStopMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Where A.WaitReason Like "計劃性停爐*" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property
#End Region
#Region "機械電系時間 屬性:MachineElectricMinutes"
    ''' <summary>
    ''' 機械電系時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MachineElectricMinutes() As Integer
        Get
            Dim ReturnValue As Integer = TotalWaitMinutes
            ReturnValue -= Me.DoubleMouseMinutes
            ReturnValue -= Me.RoastMinutes
            ReturnValue -= Me.CleanStoveMinutes
            ReturnValue -= Me.RecycleIronMinutes
            ReturnValue -= Me.HangScrapMinutes
            ReturnValue -= Me.ElectricPowerOverflowMinutes
            ReturnValue -= Me.CleanDustMinutes
            ReturnValue -= Me.ChangeCoverMinutes
            ReturnValue -= Me.WaterTankLeakingMinutes
            ReturnValue -= Me.ChangeSteelTroughMinutes
            ReturnValue -= Me.AddTwoDregsMinutes
            ReturnValue -= Me.WaitSteelDregsToTupMinutes
            ReturnValue -= Me.WaitShieldMinutes
            ReturnValue -= Me.WaitSmokeMinutes
            ReturnValue -= Me.WaitAODMinutes
            ReturnValue -= Me.WaitLDMinutes
            ReturnValue -= Me.WaitCCMMinutes
            ReturnValue -= Me.WaitAddMaterialMinutes
            ReturnValue -= Me.WaitSkyCarMinutes
            ReturnValue -= Me.StopElectrodeMinutes
            ReturnValue -= Me.CoverBreakdownMinutes
            ReturnValue -= Me.CoverInclineBreakdownMinutes
            ReturnValue -= Me.AddMaterialCarBreakdownMinutes
            ReturnValue -= Me.StoveBodyShortCircuitMinutes
            ReturnValue -= Me.FettlingMachineBreakdownMinutes
            ReturnValue -= Me.StoveBodyLeakinessMinutes
            ReturnValue -= Me.WaitFixPersonMinutes
            ReturnValue -= Me.WaitChangeStoveMinutes
            ReturnValue -= Me.WaitSkyCarCleanLDMinutes
            ReturnValue -= Me.PlanStopMinutes
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "等待時間合計 屬性:TotalWaitMinutes"
    ''' <summary>
    ''' 等待時間合計
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TotalWaitMinutes() As Integer
        Get
            Return (From A In Me.EAFT2_Wait Select A.WaitMinutes).ToArray.Sum - Me.PlanStopMinutes
        End Get
    End Property

#End Region



#Region "停爐時間合計(所有停爐時間-計劃性停爐) 屬性:StopOperatorTotalMinutes"
    ''' <summary>
    ''' 停爐時間合計(所有停爐時間-計劃性停爐)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property StopOperatorTotalMinutes() As Integer
        Get
            Return (From A In DBContext.EAFT2_Wait Where A.FK_EAF1ID = Me.ID And A.WaitReason <> "計劃性停爐" Select A.WaitMinutes).ToArray.Sum
        End Get
    End Property

#End Region





#Region "吹氧 屬性:BlowOxygen"
    ''' <summary>
    ''' 吹氧
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property BlowOxygen() As Integer
        Get
            Dim StartO2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.O2) Select A).FirstOrDefault
            Dim EndO2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.O2止) Select A).FirstOrDefault
            If IsNothing(StartO2) OrElse IsNothing(EndO2) Then
                Return 0
            End If
            Return EndO2.StartTime.Subtract(StartO2.StartTime).TotalMinutes
        End Get
    End Property

#End Region
#Region "裝料kg 屬性:PackMaterial"
    ''' <summary>
    ''' 裝料kg
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PackMaterial() As Long
        Get
            Return (From A In Me.EAFT2_Analysis Select A.TONValue).Sum * 1000
        End Get
    End Property
#End Region
#Region "總料kg 屬性:SumMaterial"
    ''' <summary>
    ''' 總料kg
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SumMaterial() As Long
        Get
            Return PackMaterial + Me.Ferromanganese + Ferrosilicon + Me.Nickel
        End Get
    End Property
#End Region

#Region "MD-TAP值  屬性:MD_TAP"
    ''' <summary>
    ''' MD-TAP值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MD_TAP() As Integer
        Get
            Dim StartMD As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.MD) Select A).FirstOrDefault
            Dim EndTAB As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.Tap) Select A).FirstOrDefault
            If IsNothing(StartMD) OrElse IsNothing(StartMD) Then
                Return 0
            End If
            Dim StartMDOperatorType As EAFT2_OperatorType = (From A In DBContext.EAFT2_OperatorType Where A.OperatorTypeID = StartMD.FK_OperatorTypeID Select A).FirstOrDefault
            Dim EndTABOperatorType As EAFT2_OperatorType = (From A In DBContext.EAFT2_OperatorType Where A.OperatorTypeID = EndTAB.FK_OperatorTypeID Select A).FirstOrDefault
            Dim WaitEventMinutes As Integer = 0
            If Not IsNothing(StartMDOperatorType) AndAlso Not IsNothing(StartMDOperatorType) Then
                WaitEventMinutes = (From A In Me.EAFT2_Wait Where A.EAFT2_OperatorType.OperatorOrder >= StartMDOperatorType.OperatorOrder And A.EAFT2_OperatorType.OperatorOrder < EndTABOperatorType.OperatorOrder Select A.WaitMinutes).ToArray.Sum
            End If
            Return EndTAB.StartTime.Subtract(StartMD.StartTime).TotalMinutes - Me.BlowOxygen - WaitEventMinutes
        End Get
    End Property

#End Region
#Region "送電分析時間合計 屬性:EAFT2_Analysis_TimeTOTAL"
    ''' <summary>
    ''' 送電分析時間合計
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property EAFT2_Analysis_TimeTOTAL() As Integer
        Get
            Return (From A In Me.EAFT2_Analysis Select A.TIME).ToArray.Sum
        End Get
    End Property
#End Region
#Region "送電分析KWH100合計 屬性:EAFT2_Analysis_KWH100TOTAL"
    ''' <summary>
    ''' 送電分析KWH100合計
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property EAFT2_Analysis_KWH100TOTAL() As Integer
        Get
            Dim GetTAP As EAFT2 = From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.Tap) Select A
            If IsNothing(GetTAP) Then
                Return 0
            End If
            Return GetTAP.ElectricPower
        End Get
    End Property
#End Region
#Region "送電分析KWHDivTIME合計 屬性:EAFT2_Analysis_KWHDivTIMETOTAL"
    ''' <summary>
    ''' 送電分析KWHDivTIME合計
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property EAFT2_Analysis_KWHDivTIMETOTAL() As Single
        Get
            Dim GetTime As Integer = Me.EAFT2_Analysis_TimeTOTAL
            If GetTime = 0 Then
                Return 0
            End If
            Return Me.EAFT2_Analysis_KWH100TOTAL / GetTime
        End Get
    End Property
#End Region

    '底部資料
#Region "錳鐵 屬性:Ferromanganese"
    ''' <summary>
    ''' 錳鐵
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Ferromanganese() As Single
        Get
            Return (From A In Me.EAFT2 Where A.MemoItem Like "FeMn*" Select A.MemoMetal).ToArray.Sum
        End Get
    End Property
#End Region
#Region "矽鐵 屬性:Ferrosilicon"
    ''' <summary>
    ''' 矽鐵
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Ferrosilicon() As Single
        Get
            Return (From A In Me.EAFT2 Where A.MemoItem Like "FeSi*" Select A.MemoMetal).ToArray.Sum
        End Get
    End Property

#End Region
#Region "鎳鐵 屬性:Nickel"
    ''' <summary>
    ''' 鎳鐵
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Nickel() As Single
        Get
            Return (From A In Me.EAFT2 Where A.MemoItem Like "鎳鐵*" Select A.MemoMetal).ToArray.Sum
        End Get
    End Property

#End Region
#Region "螢石 屬性:Fluorite"
    ReadOnly Property Fluorite() As Single
        Get
            Return (From A In Me.EAFT2 Where A.MemoItem Like "CaF2*" Select A.MemoMetal).ToArray.Sum
        End Get
    End Property
#End Region
#Region "爐渣鐵 屬性:IronSlage"
    ''' <summary>
    ''' 爐渣鐵
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IronSlage() As Single
        Get
            Return (From A In Me.EAFT2 Where A.MemoItem Like "爐渣鐵*" Select A.MemoDregs).ToArray.Sum
        End Get
    End Property
#End Region
#Region "湯塊 屬性:RecycleIron"
    ''' <summary>
    ''' 湯塊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RecycleIron() As Single
        Get
            Return (From A In Me.EAFT2 Where A.MemoItem Like "EAF湯塊*" Or A.MemoItem Like "CCM湯塊*" Select A.MemoMetal).ToArray.Sum
        End Get
    End Property
#End Region
#Region "集塵灰 屬性:DustCollectMaterial"
    ''' <summary>
    ''' 集塵灰
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DustCollectMaterial() As Single
        Get
            Return (From A In Me.EAFT2 Where A.MemoItem Like "集塵灰*" Select A.MemoMetal).ToArray.Sum
        End Get
    End Property
#End Region
#Region "CaO料 屬性:CaOMaterial"
    ''' <summary>
    ''' CaO料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CaOMaterial() As Single
        Get
            Return (From A In Me.EAFT2 Where A.MemoItem Like "CaO*" Select A.MemoMetal).ToArray.Sum + Me.CaOWeight
        End Get
    End Property
#End Region



#Region "出鋼溫度 屬性:LastOutputTemperature"
    ''' <summary>
    ''' 出鋼溫度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property LastOutputTemperature() As Single
        Get
            Dim myEAFT2 As EAFT2 = (From A In Me.EAFT2 Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.S3_T3) Select A).FirstOrDefault
            If IsNothing(myEAFT2) Then
                Return 0
            End If
            Return myEAFT2.Thermograph
        End Get
    End Property
#End Region

    '回收率
#Region "Ni回收率 屬性:NiRecyclePercentage"
    ''' <summary>
    ''' Ni回收率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NiRecyclePercentage() As Double
        Get
            Dim Value1 As Double = Me.NiElementTotalWeight
            If Value1 = 0 Then
                Return 0
            End If
            Dim LDNi As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDNi) Then
                Return 0
            End If
            Return (Me.MoltenSteelWeight * LDNi.Ni) / Value1
        End Get
    End Property
#End Region
#Region "Cr回收率 屬性:CrRecyclePercentage"
    ''' <summary>
    ''' Cr回收率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CrRecyclePercentage() As Double
        Get
            Dim Value1 As Double = Me.CrElementTotalWeight
            If Value1 = 0 Then
                Return 0
            End If
            Dim LDCr As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDCr) Then
                Return 0
            End If
            Return (Me.MoltenSteelWeight * LDCr.Cr) / Value1
        End Get
    End Property
#End Region
#Region "鋼水回收率 屬性:MoltenSteelRecyclePercentage"
    ''' <summary>
    ''' 鋼水回收率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MoltenSteelRecyclePercentage() As Double
        Get
            Dim Value1 As Double = Me.SumMaterial
            If Value1 = 0 Then
                Return 0
            End If
            Dim Value2 As Double = Me.MoltenSteelWeight

            Return Value2 / Value1 * 100
        End Get
    End Property
#End Region
#Region "(CaO/SiO2)鹽基度 屬性:Ca0DivSi02Value"
    ''' <summary>
    ''' (CaO/SiO2)鹽基度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Ca0DivSi02Value() As Double
        Get
            Dim Value1_1 As Double = 0
            Dim LDSi As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDSi) Then
                Value1_1 = 0
            Else
                Value1_1 = LDSi.Si
            End If
            Dim Value1_2 As Double = (From A In Me.EAFT2 Where A.MemoItem = "FeSi" Select A.MemoMetal).ToArray.Sum
            Dim Value1 As Double = (Me.Allocate_Si + Value1_2 * 0.7 - Me.MoltenSteelWeight * Value1_1 / 100) * 2.14
            If Value1 = 0 Then
                Return 0
            End If
            Dim Value2_1 As Double = (From A In Me.EAFT2 Where A.MemoItem = "CaO" Select A.MemoDregs).ToArray.Sum
            Dim Value2 As Double = (Value2_1 + Me.CaOWeight) * 0.9
            Return Value2 / Value1
        End Get
    End Property
#End Region


    '配料百分比
#Region "C元素配料百分比 屬性:Allocate_CPercentage"
    ''' <summary>
    ''' 元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_CPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_C / myPackMaterial * 100, "0.00")
        End Get
    End Property
#End Region
#Region "Si元素配料百分比 屬性:Allocate_SiPercentage"
    ''' <summary>
    ''' Si元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_SiPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_Si / myPackMaterial * 100, "0.00")
        End Get
    End Property
#End Region
#Region "Mn元素配料百分比 屬性:Allocate_MnPercentage"
    ''' <summary>
    ''' Mn元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_MnPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_Mn / myPackMaterial * 100, "0.00")
        End Get
    End Property
#End Region
#Region "P元素配料百分比 屬性:Allocate_PPercentage"
    ''' <summary>
    ''' P元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_PPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_P / myPackMaterial * 100, "0.000")
        End Get
    End Property
#End Region
#Region "S元素配料百分比 屬性:Allocate_SPercentage"
    ''' <summary>
    ''' S元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_SPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_S / myPackMaterial * 100, "0.000")
        End Get
    End Property
#End Region
#Region "Cr元素配料百分比 屬性:Allocate_CrPercentage"
    ''' <summary>
    ''' Cr元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_CrPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_Cr / myPackMaterial * 100, "0.00")
        End Get
    End Property
#End Region
#Region "Ni元素配料百分比 屬性:Allocate_NiPercentage"
    ''' <summary>
    ''' Ni元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_NiPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_Ni / myPackMaterial * 100, "0.000")
        End Get
    End Property
#End Region
#Region "Cu元素配料百分比 屬性:Allocate_CuPercentage"
    ''' <summary>
    ''' Cu元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_CuPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_Cu / myPackMaterial * 100, "0.000")
        End Get
    End Property
#End Region
#Region "Mo元素配料百分比 屬性:Allocate_MoPercentage"
    ''' <summary>
    ''' Mo元素配料百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Allocate_MoPercentage() As Single
        Get
            Dim myPackMaterial As Long = Me.PackMaterial
            If myPackMaterial = 0 Then
                Return 0
            End If
            Return Format(Me.Allocate_Mo / myPackMaterial * 100, "0.000")
        End Get
    End Property
#End Region
    '電爐元素重量kg
#Region "C元素重量 屬性:HotPlate_CWeight"
    Const C_Cok = 0.83              '焦碳
    Const C_FeSi = 0.002
    Const C_FeMn = 0.063
    Const C_NickelSteel = 0.014    '鎳鐵
    ''' <summary>
    ''' C元素重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property HotPlate_CWeight() As Single
        Get
            Dim Value1 As Single = Me.Ferromanganese
            Return Value1 * C_FeSi + Value1 * C_FeMn + Value1 * C_NickelSteel + (From A In Me.EAFT2 Where A.MemoItem = "焦碳" Select A.MemoDregs).ToArray.Sum * C_Cok
        End Get
    End Property
#End Region
#Region "Si元素重量 屬性:HotPlate_SiWeight"
    Const Si_FeSi = 0.75
    Const Si_NickelSteel = 0.01    '鎳鐵
    ''' <summary>
    ''' Si元素重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property HotPlate_SiWeight() As Single
        Get
            Dim Value1 As Single = Me.Ferromanganese
            Return Value1 * Si_FeSi + Value1 * Si_NickelSteel
        End Get
    End Property
#End Region
#Region "Mn元素重量 屬性:HotPlate_MnWeight"
    Const Mn_FeMn = 0.73
    Const Mn_NickelSteel = 0.003
    ''' <summary>
    ''' Mn元素重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property HotPlate_MnWeight() As Single
        Get
            Dim Value1 As Single = Me.Ferromanganese
            Dim Value2 As Single = Me.Ferrosilicon
            Return Value1 * Mn_FeMn + Value2 * Mn_NickelSteel
        End Get
    End Property
#End Region
#Region "Cr元素重量 屬性:HotPlate_CrWeight"
    Const Cr_NickelSteel = 0.006 '鎳鐵
    ''' <summary>
    ''' Cr元素重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property HotPlate_CrWeight() As Single
        Get
            Dim Value1 As Single = Me.Nickel
            Return Value1 * Cr_NickelSteel
        End Get
    End Property
#End Region
#Region "Ni元素重量 屬性:HotPlate_NiWeight"
    Const Ni_NickelSteel = 0.29 '鎳鐵
    ''' <summary>
    ''' Ni元素重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property HotPlate_NiWeight() As Single
        Get
            Dim Value1 As Single = Me.Nickel
            Return Value1 * Ni_NickelSteel
        End Get
    End Property
#End Region
    '元素總重量
#Region "C元素總重量 屬性:CElementTotalWeight"
    ''' <summary>
    ''' C元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CElementTotalWeight() As Double
        Get
            Return Me.Allocate_C + HotPlate_CWeight
        End Get
    End Property
#End Region
#Region "Si元素總重量 屬性:SiElementTotalWeight"
    ''' <summary>
    ''' Si元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SiElementTotalWeight() As Double
        Get
            Return Me.Allocate_Si + HotPlate_SiWeight
        End Get
    End Property
#End Region
#Region "Mn元素總重量 屬性:MnElementTotalWeight"
    ''' <summary>
    ''' Mn元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MnElementTotalWeight() As Double
        Get
            Return Me.Allocate_Mn + HotPlate_MnWeight
        End Get
    End Property
#End Region
#Region "P元素總重量 屬性:PElementTotalWeight"
    ''' <summary>
    ''' P元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PElementTotalWeight() As Double
        Get
            Return Me.Allocate_P
        End Get
    End Property
#End Region
#Region "S元素總重量 屬性:SElementTotalWeight"
    ''' <summary>
    ''' S元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SElementTotalWeight() As Double
        Get
            Return Me.Allocate_S
        End Get
    End Property
#End Region
#Region "Cr元素總重量 屬性:CrElementTotalWeight"
    ''' <summary>
    ''' Cr元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CrElementTotalWeight() As Double
        Get
            Return Me.Allocate_Cr + HotPlate_CrWeight
        End Get
    End Property
#End Region
#Region "Ni元素總重量 屬性:NiElementTotalWeight"
    ''' <summary>
    ''' Ni元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NiElementTotalWeight() As Double
        Get
            Return Me.Allocate_Ni + HotPlate_NiWeight
        End Get
    End Property
#End Region
#Region "Cu元素總重量 屬性:CuElementTotalWeight"
    ''' <summary>
    ''' Cu元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CuElementTotalWeight() As Double
        Get
            Return Me.Allocate_Cu
        End Get
    End Property
#End Region
#Region "Mo元素總重量 屬性:MoElementTotalWeight"
    ''' <summary>
    ''' Mo元素總重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MoElementTotalWeight() As Double
        Get
            Return Me.Allocate_Mo
        End Get
    End Property
#End Region
    '元素總重量百分比
#Region "C元素總重量百分比 屬性:CElementTotalWeightPercentage"
    ''' <summary>
    ''' C元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.CElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region
#Region "Si元素總重量百分比 屬性:SiElementTotalWeightPercentage"
    ''' <summary>
    ''' Si元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SiElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.SiElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region
#Region "Mn元素總重量百分比 屬性:MnElementTotalWeightPercentage"
    ''' <summary>
    ''' Mn元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MnElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.MnElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region
#Region "P元素總重量百分比 屬性:PElementTotalWeightPercentage"
    ''' <summary>
    ''' P元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.PElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region
#Region "S元素總重量百分比 屬性:SElementTotalWeightPercentage"
    ''' <summary>
    ''' S元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.SElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region
#Region "Cr元素總重量百分比 屬性:CrElementTotalWeightPercentage"
    ''' <summary>
    ''' Cr元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CrElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.CrElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region
#Region "Ni元素總重量百分比 屬性:NiElementTotalWeightPercentage"
    ''' <summary>
    ''' Ni元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NiElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.NiElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region
#Region "Cu元素總重量百分比 屬性:CuElementTotalWeightPercentage"
    ''' <summary>
    ''' Cu元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CuElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.CuElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region
#Region "Mo元素總重量百分比 屬性:MoElementTotalWeightPercentage"
    ''' <summary>
    ''' Mo元素總重量百分比
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MoElementTotalWeightPercentage()
        Get
            Dim GetTotalWeight As Long = Me.SumMaterial
            If GetTotalWeight = 0 Then
                Return 0
            End If
            Return Me.MoElementTotalWeight / GetTotalWeight * 100
        End Get
    End Property
#End Region

    'CHI ~CHIV TON Value
#Region "CHI值 屬性:CHI_I"
    ''' <summary>
    ''' CHI值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CHI_I() As Single
        Get
            Dim GetEAFT2 As EAFT2_Analysis = (From A In Me.EAFT2_Analysis Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電I) Select A).FirstOrDefault
            If IsNothing(GetEAFT2) Then
                Return 0
            End If
            Return GetEAFT2.TONValue
        End Get
    End Property

#End Region
#Region "CHI值 屬性:CHI_II"
    ''' <summary>
    ''' CHI值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CHI_II() As Single
        Get
            Dim GetEAFT2 As EAFT2_Analysis = (From A In Me.EAFT2_Analysis Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電II) Select A).FirstOrDefault
            If IsNothing(GetEAFT2) Then
                Return 0
            End If
            Return GetEAFT2.TONValue
        End Get
    End Property

#End Region
#Region "CHI值 屬性:CHI_III"
    ''' <summary>
    ''' CHIII值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CHI_III() As Single
        Get
            Dim GetEAFT2 As EAFT2_Analysis = (From A In Me.EAFT2_Analysis Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電III) Select A).FirstOrDefault
            If IsNothing(GetEAFT2) Then
                Return 0
            End If
            Return GetEAFT2.TONValue
        End Get
    End Property
#End Region
#Region "CHI值 屬性:CHI_IV"
    ''' <summary>
    ''' CHIV值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CHI_IV() As Single
        Get
            Dim GetEAFT2 As EAFT2_Analysis = (From A In Me.EAFT2_Analysis Where A.FK_OperatorTypeID = EAFT2_OperatorType.FindOperatorTypeID(OperatorTypeEnum.送電IV) Select A).FirstOrDefault
            If IsNothing(GetEAFT2) Then
                Return 0
            End If
            Return GetEAFT2.TONValue
        End Get
    End Property
#End Region

    '鋼液尾塊元素成份
#Region "尾塊元素成份C 屬性:TailCElement"
    ''' <summary>
    ''' 尾塊元素成份C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailCElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.C
        End Get
    End Property
#End Region
#Region "尾塊元素成份S1 屬性:TailS1Element"
    ''' <summary>
    ''' 尾塊元素成份S1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailS1Element() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 1 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.Si
        End Get
    End Property
#End Region
#Region "尾塊元素成份S2 屬性:TailS2Element"
    ''' <summary>
    ''' 尾塊元素成份S2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailS2Element() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 2 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.Si
        End Get
    End Property

#End Region
#Region "尾塊元素成份Si 屬性:TailSiElement"
    ''' <summary>
    ''' 尾塊元素成份Si
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailSiElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.Si
        End Get
    End Property
#End Region
#Region "尾塊元素成份Mn 屬性:TailMnElement"
    ''' <summary>
    ''' 尾塊元素成份Mn
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailMnElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.Mn
        End Get
    End Property
#End Region
#Region "尾塊元素成份P 屬性:TailPElement"
    ''' <summary>
    ''' 尾塊元素成份P
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailPElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.P
        End Get
    End Property
#End Region
#Region "尾塊元素成份S 屬性:TailSElement"
    ''' <summary>
    ''' 尾塊元素成份S
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailSElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.S
        End Get
    End Property
#End Region
#Region "尾塊元素成份Cr 屬性:TailCrElement"
    ''' <summary>
    ''' 尾塊元素成份Cr
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailCrElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.Cr
        End Get
    End Property
#End Region
#Region "尾塊元素成份Ni 屬性:TailNiElement"
    ''' <summary>
    ''' 尾塊元素成份Ni
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailNiElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.Ni
        End Get
    End Property
#End Region
#Region "尾塊元素成份Cu 屬性:TailCuElement"
    ''' <summary>
    ''' 尾塊元素成份Cu
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailCuElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.Cu
        End Get
    End Property
#End Region
#Region "尾塊元素成份Sn 屬性:TailSnElement"
    ''' <summary>
    ''' 尾塊元素成份Sn
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TailSnElement() As Single
        Get
            Dim LDRecord As EAFT3 = (From A In Me.EAFT3 Where A.SampleNumber = 5 Select A).FirstOrDefault
            If IsNothing(LDRecord) Then
                Return 0
            End If
            Return LDRecord.Sn
        End Get
    End Property
#End Region
End Class

