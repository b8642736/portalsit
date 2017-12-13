Public Class 標準樣本接收資料OneSample
    Inherits 標準樣本接收資料

    Dim DataContext As New SMPDataContext

    Sub New(ByVal StoveNumber As String, ByVal Station As String, ByVal SerialNumber As Integer, ByVal DataDateTime As DateTime)
        Me.爐號 = StoveNumber
        Me.站別 = Station
        Me.序號 = SerialNumber
        Me.日期時間 = DataDateTime
        ComputeToFinalValue()
    End Sub

    Sub New(ByVal SetObject As 標準樣本接收資料)
        Me.New(SetObject.爐號, SetObject.站別, SetObject.序號, SetObject.日期時間)
    End Sub

#Region "樣本資料群 屬性:SampleDatas"

    Private _SampleDatas As List(Of 標準樣本接收資料)
    ''' <summary>
    ''' 樣本資料群
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SampleDatas() As List(Of 標準樣本接收資料)
        Get
            Static OldKeyValue As String = Nothing
            Dim NewKeyValue As String = Me.爐號 & Me.站別 & Me.序號 & Me.日期時間
            If IsNothing(_SampleDatas) OrElse OldKeyValue <> NewKeyValue Then
                OldKeyValue = NewKeyValue
                _SampleDatas = (From A In DataContext.標準樣本接收資料 Where A.爐號 = Me.爐號 And A.站別 = Me.站別 And A.序號 = Me.序號 And A.日期時間 = Me.日期時間 Select A).ToList
            End If
            Return _SampleDatas
        End Get
    End Property

#End Region

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
            If IsModeChanged Then
                ComputeToFinalValue()
            End If
        End Set
    End Property

    Public Enum DataDisplayModeEnum
        RealDataMode = 0      '原始資料模式
        ForCheckMode = 1        '應付檢查資料調整模式
    End Enum
#End Region

#Region "計算設定結果值 函式:ComputeToFinalValue"
    ''' <summary>
    ''' 計算設定結果值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ComputeToFinalValue()
        Dim CanUseSampleDatas As List(Of 標準樣本接收資料) = (From A In SampleDatas Where A.SampleMark <> "x" And A.SampleMark <> "X" And A.SampleMark <> "v" And A.SampleMark <> "V" Order By A.點序 Select A).ToList
        Dim JustUseSampleDatas As List(Of 標準樣本接收資料) = (From A In SampleDatas Where A.SampleMark = "v" Or A.SampleMark = "V" Select A).ToList
        If CanUseSampleDatas.Count = 0 OrElse IsNothing(AboutSMPStandardSample) Then
            Exit Sub
        End If
        If JustUseSampleDatas.Count = 0 Then
            Me.C = (From A In CanUseSampleDatas Select A.C).Average
            Me.Si = (From A In CanUseSampleDatas Select A.Si).Average
            Me.Mn = (From A In CanUseSampleDatas Select A.Mn).Average
            Me.P = (From A In CanUseSampleDatas Select A.P).Average
            Me.S = (From A In CanUseSampleDatas Select A.S).Average
            Me.Cr = (From A In CanUseSampleDatas Select A.Cr).Average
            Me.Ni = (From A In CanUseSampleDatas Select A.Ni).Average
            Me.Cu = (From A In CanUseSampleDatas Select A.Cu).Average
            Me.Mo = (From A In CanUseSampleDatas Select A.Mo).Average
            Me.Co = (From A In CanUseSampleDatas Select A.Co).Average
            Me.AL = (From A In CanUseSampleDatas Select A.AL).Average
            Me.Sn = (From A In CanUseSampleDatas Select A.Sn).Average
            Me.Pb = (From A In CanUseSampleDatas Select A.Pb).Average
            Me.Ti = (From A In CanUseSampleDatas Select A.Ti).Average
            Me.Nb = (From A In CanUseSampleDatas Select A.Nb).Average
            Me.V = (From A In CanUseSampleDatas Select A.V).Average
            Me.W = (From A In CanUseSampleDatas Select A.W).Average
            Me.N2 = (From A In CanUseSampleDatas Select A.N2).Average
            Me.B = (From A In CanUseSampleDatas Select A.B).Average
            Me.Ca = (From A In CanUseSampleDatas Select A.Ca).Average
            Me.Mg = (From A In CanUseSampleDatas Select A.Mg).Average
            Me.As = (From A In CanUseSampleDatas Select A.As).Average
            Me.Bi = (From A In CanUseSampleDatas Select A.Bi).Average
            Me.Sb = (From A In CanUseSampleDatas Select A.Sb).Average
            Me.Zn = (From A In CanUseSampleDatas Select A.Zn).Average
            Me.Zr = (From A In CanUseSampleDatas Select A.Zr).Average
            Me.Fe = (From A In CanUseSampleDatas Select A.Fe).Average
        Else
            Me.C = (From A In CanUseSampleDatas Select A.C).Average + ((From A In JustUseSampleDatas Select A.C).Average - AboutSMPStandardSample.C)
            Me.Si = (From A In CanUseSampleDatas Select A.Si).Average + ((From A In JustUseSampleDatas Select A.Si).Average - AboutSMPStandardSample.Si)
            Me.Mn = (From A In CanUseSampleDatas Select A.Mn).Average + ((From A In JustUseSampleDatas Select A.Mn).Average - AboutSMPStandardSample.Mn)
            Me.P = (From A In CanUseSampleDatas Select A.P).Average + ((From A In JustUseSampleDatas Select A.P).Average - AboutSMPStandardSample.P)
            Me.S = (From A In CanUseSampleDatas Select A.S).Average + ((From A In JustUseSampleDatas Select A.S).Average - AboutSMPStandardSample.S)
            Me.Cr = (From A In CanUseSampleDatas Select A.Cr).Average + ((From A In JustUseSampleDatas Select A.Cr).Average - AboutSMPStandardSample.Cr)
            Me.Ni = (From A In CanUseSampleDatas Select A.Ni).Average + ((From A In JustUseSampleDatas Select A.Ni).Average - AboutSMPStandardSample.Ni)
            Me.Cu = (From A In CanUseSampleDatas Select A.Cu).Average + ((From A In JustUseSampleDatas Select A.Cu).Average - AboutSMPStandardSample.Cu)
            Me.Mo = (From A In CanUseSampleDatas Select A.Mo).Average + ((From A In JustUseSampleDatas Select A.Mo).Average - AboutSMPStandardSample.Mo)
            Me.Co = (From A In CanUseSampleDatas Select A.Co).Average + ((From A In JustUseSampleDatas Select A.Co).Average - AboutSMPStandardSample.Co)
            Me.AL = (From A In CanUseSampleDatas Select A.AL).Average + ((From A In JustUseSampleDatas Select A.AL).Average - AboutSMPStandardSample.AL)
            Me.Sn = (From A In CanUseSampleDatas Select A.Sn).Average + ((From A In JustUseSampleDatas Select A.Sn).Average - AboutSMPStandardSample.Sn)
            Me.Pb = (From A In CanUseSampleDatas Select A.Pb).Average + ((From A In JustUseSampleDatas Select A.Pb).Average - AboutSMPStandardSample.Pb)
            Me.Ti = (From A In CanUseSampleDatas Select A.Ti).Average + ((From A In JustUseSampleDatas Select A.Ti).Average - AboutSMPStandardSample.Ti)
            Me.Nb = (From A In CanUseSampleDatas Select A.Nb).Average + ((From A In JustUseSampleDatas Select A.Nb).Average - AboutSMPStandardSample.Nb)
            Me.V = (From A In CanUseSampleDatas Select A.V).Average + ((From A In JustUseSampleDatas Select A.V).Average - AboutSMPStandardSample.V)
            Me.W = (From A In CanUseSampleDatas Select A.W).Average + ((From A In JustUseSampleDatas Select A.W).Average - AboutSMPStandardSample.W)
            Me.N2 = (From A In CanUseSampleDatas Select A.N2).Average + ((From A In JustUseSampleDatas Select A.N2).Average - AboutSMPStandardSample.N)
            Me.B = (From A In CanUseSampleDatas Select A.B).Average + ((From A In JustUseSampleDatas Select A.B).Average - AboutSMPStandardSample.B)
            Me.Ca = (From A In CanUseSampleDatas Select A.Ca).Average + ((From A In JustUseSampleDatas Select A.Ca).Average - AboutSMPStandardSample.Ca)
            Me.Mg = (From A In CanUseSampleDatas Select A.Mg).Average + ((From A In JustUseSampleDatas Select A.Mg).Average - AboutSMPStandardSample.Mg)
            Me.As = (From A In CanUseSampleDatas Select A.As).Average + ((From A In JustUseSampleDatas Select A.As).Average - AboutSMPStandardSample.As)
            Me.Bi = (From A In CanUseSampleDatas Select A.Bi).Average + ((From A In JustUseSampleDatas Select A.Bi).Average - AboutSMPStandardSample.Bi)
            Me.Sb = (From A In CanUseSampleDatas Select A.Sb).Average + ((From A In JustUseSampleDatas Select A.Sb).Average - AboutSMPStandardSample.Sb)
            Me.Zn = (From A In CanUseSampleDatas Select A.Zn).Average + ((From A In JustUseSampleDatas Select A.Zn).Average - AboutSMPStandardSample.Zn)
            Me.Zr = (From A In CanUseSampleDatas Select A.Zr).Average + ((From A In JustUseSampleDatas Select A.Zr).Average - AboutSMPStandardSample.Zr)
            Me.Fe = (From A In CanUseSampleDatas Select A.Fe).Average + ((From A In JustUseSampleDatas Select A.Fe).Average - AboutSMPStandardSample.Fe)
        End If
        If CanUseSampleDatas.Count > 0 Then
            Me.SampleMark = CanUseSampleDatas(0).SampleMark
            Me.Sample = CanUseSampleDatas(0).Sample
            Me.Comments = CanUseSampleDatas(0).Comments
            Me.Task = CanUseSampleDatas(0).Task
            Me.Method = CanUseSampleDatas(0).Method
            Me.Shift = CanUseSampleDatas(0).Shift
            Me.Furance = CanUseSampleDatas(0).Furance
            Me.Melt = CanUseSampleDatas(0).Melt
            Me.鋼種 = CanUseSampleDatas(0).鋼種
            Me.Type = CanUseSampleDatas(0).Type
            Me.DeviceName = CanUseSampleDatas(0).DeviceName
            Me.FK_SampleNumber = CanUseSampleDatas(0).FK_SampleNumber
        End If

        If DataDisplayMode = DataDisplayModeEnum.ForCheckMode Then
            JudgeDataToForCheckMode()
        End If
    End Sub

    Private Sub JudgeDataToForCheckMode()
        Dim RangeData As 標準樣本接收資料上下限 = About標準樣本接收資料上下限
        If IsNothing(RangeData) Then
            Throw New Exception("找不到標準樣本接收資料上下限")
        End If
        If Not IsNothing(RangeData.UP_C) AndAlso Me.C > RangeData.UP_C Then
            Me.C = RangeData.UP_C
        End If
        If Not IsNothing(RangeData.Down_C) AndAlso Me.C < RangeData.Down_C Then
            Me.C = RangeData.Down_C
        End If
        If Not IsNothing(RangeData.UP_Si) AndAlso Me.Si > RangeData.UP_Si Then
            Me.Si = RangeData.UP_Si
        End If
        If Not IsNothing(RangeData.Down_Si) AndAlso Me.Si < RangeData.Down_Si Then
            Me.Si = RangeData.Down_Si
        End If
        If Not IsNothing(RangeData.UP_Mn) AndAlso Me.Mn > RangeData.UP_Mn Then
            Me.Mn = RangeData.UP_Mn
        End If
        If Not IsNothing(RangeData.Down_Mn) AndAlso Me.Mn < RangeData.Down_Mn Then
            Me.Mn = RangeData.Down_Mn
        End If
        If Not IsNothing(RangeData.UP_P) AndAlso Me.P > RangeData.UP_P Then
            Me.P = RangeData.UP_P
        End If
        If Not IsNothing(RangeData.Down_P) AndAlso Me.P < RangeData.Down_P Then
            Me.P = RangeData.Down_P
        End If
        If Not IsNothing(RangeData.UP_S) AndAlso Me.S > RangeData.UP_S Then
            Me.S = RangeData.UP_S
        End If
        If Not IsNothing(RangeData.Down_S) AndAlso Me.S < RangeData.Down_S Then
            Me.S = RangeData.Down_S
        End If
        If Not IsNothing(RangeData.UP_Cr) AndAlso Me.Cr > RangeData.UP_Cr Then
            Me.Cr = RangeData.UP_Cr
        End If
        If Not IsNothing(RangeData.Down_Cr) AndAlso Me.Cr < RangeData.Down_Cr Then
            Me.Cr = RangeData.Down_Cr
        End If
        If Not IsNothing(RangeData.UP_Ni) AndAlso Me.Ni > RangeData.UP_Ni Then
            Me.Ni = RangeData.UP_Ni
        End If
        If Not IsNothing(RangeData.Down_Ni) AndAlso Me.Ni < RangeData.Down_Ni Then
            Me.Ni = RangeData.Down_Ni
        End If
        If Not IsNothing(RangeData.UP_Cu) AndAlso Me.Cu > RangeData.UP_Cu Then
            Me.Cu = RangeData.UP_Cu
        End If
        If Not IsNothing(RangeData.Down_Cu) AndAlso Me.Cu < RangeData.Down_Cu Then
            Me.Cu = RangeData.Down_Cu
        End If
        If Not IsNothing(RangeData.UP_Mo) AndAlso Me.Mo > RangeData.UP_Mo Then
            Me.Mo = RangeData.UP_Mo
        End If
        If Not IsNothing(RangeData.Down_Mo) AndAlso Me.Mo < RangeData.Down_Mo Then
            Me.Mo = RangeData.Down_Mo
        End If
        If Not IsNothing(RangeData.UP_Co) AndAlso Me.Co > RangeData.UP_Co Then
            Me.Co = RangeData.UP_Co
        End If
        If Not IsNothing(RangeData.Down_Co) AndAlso Me.Co < RangeData.Down_Co Then
            Me.Co = RangeData.Down_Co
        End If
        If Not IsNothing(RangeData.UP_AL) AndAlso Me.AL > RangeData.UP_AL Then
            Me.AL = RangeData.UP_AL
        End If
        If Not IsNothing(RangeData.Down_AL) AndAlso Me.AL < RangeData.Down_AL Then
            Me.AL = RangeData.Down_AL
        End If
        If Not IsNothing(RangeData.UP_Sn) AndAlso Me.Sn > RangeData.UP_Sn Then
            Me.Sn = RangeData.UP_Sn
        End If
        If Not IsNothing(RangeData.Down_Sn) AndAlso Me.Sn < RangeData.Down_Sn Then
            Me.Sn = RangeData.Down_Sn
        End If
        If Not IsNothing(RangeData.UP_Pb) AndAlso Me.Pb > RangeData.UP_Pb Then
            Me.Pb = RangeData.UP_Pb
        End If
        If Not IsNothing(RangeData.Down_Pb) AndAlso Me.Pb < RangeData.Down_Pb Then
            Me.Pb = RangeData.Down_Pb
        End If
        If Not IsNothing(RangeData.UP_Ti) AndAlso Me.Ti > RangeData.UP_Ti Then
            Me.Ti = RangeData.UP_Ti
        End If
        If Not IsNothing(RangeData.Down_Ti) AndAlso Me.Ti < RangeData.Down_Ti Then
            Me.Ti = RangeData.Down_Ti
        End If
        If Not IsNothing(RangeData.UP_Nb) AndAlso Me.Nb > RangeData.UP_Nb Then
            Me.Nb = RangeData.UP_Nb
        End If
        If Not IsNothing(RangeData.Down_Nb) AndAlso Me.Nb < RangeData.Down_Nb Then
            Me.Nb = RangeData.Down_Nb
        End If
        If Not IsNothing(RangeData.UP_V) AndAlso Me.V > RangeData.UP_V Then
            Me.V = RangeData.UP_V
        End If
        If Not IsNothing(RangeData.Down_V) AndAlso Me.V < RangeData.Down_V Then
            Me.V = RangeData.Down_V
        End If
        If Not IsNothing(RangeData.UP_W) AndAlso Me.W > RangeData.UP_W Then
            Me.W = RangeData.UP_W
        End If
        If Not IsNothing(RangeData.Down_W) AndAlso Me.W < RangeData.Down_W Then
            Me.W = RangeData.Down_W
        End If
        If Not IsNothing(RangeData.UP_N2) AndAlso Me.N2 > RangeData.UP_N2 Then
            Me.N2 = RangeData.UP_N2
        End If
        If Not IsNothing(RangeData.Down_N2) AndAlso Me.N2 < RangeData.Down_N2 Then
            Me.N2 = RangeData.Down_N2
        End If
        If Not IsNothing(RangeData.UP_B) AndAlso Me.B > RangeData.UP_B Then
            Me.B = RangeData.UP_B
        End If
        If Not IsNothing(RangeData.Down_B) AndAlso Me.B < RangeData.Down_B Then
            Me.B = RangeData.Down_B
        End If
        If Not IsNothing(RangeData.UP_Ca) AndAlso Me.Ca > RangeData.UP_Ca Then
            Me.Ca = RangeData.UP_Ca
        End If
        If Not IsNothing(RangeData.Down_Ca) AndAlso Me.Ca < RangeData.Down_Ca Then
            Me.Ca = RangeData.Down_Ca
        End If
        If Not IsNothing(RangeData.UP_Mg) AndAlso Me.Mg > RangeData.UP_Mg Then
            Me.Mg = RangeData.UP_Mg
        End If
        If Not IsNothing(RangeData.Down_Mg) AndAlso Me.Mg < RangeData.Down_Mg Then
            Me.Mg = RangeData.Down_Mg
        End If
        If Not IsNothing(RangeData.UP_As) AndAlso Me.As > RangeData.UP_As Then
            Me.As = RangeData.UP_As
        End If
        If Not IsNothing(RangeData.Down_As) AndAlso Me.As < RangeData.Down_As Then
            Me.As = RangeData.Down_As
        End If
        If Not IsNothing(RangeData.UP_Bi) AndAlso Me.Bi > RangeData.UP_Bi Then
            Me.Bi = RangeData.UP_Bi
        End If
        If Not IsNothing(RangeData.Down_Bi) AndAlso Me.Bi < RangeData.Down_Bi Then
            Me.Bi = RangeData.Down_Bi
        End If
        If Not IsNothing(RangeData.UP_Sb) AndAlso Me.Sb > RangeData.UP_Sb Then
            Me.Sb = RangeData.UP_Sb
        End If
        If Not IsNothing(RangeData.Down_Sb) AndAlso Me.Sb < RangeData.Down_Sb Then
            Me.Sb = RangeData.Down_Sb
        End If
        If Not IsNothing(RangeData.UP_Zn) AndAlso Me.Zn > RangeData.UP_Zn Then
            Me.Zn = RangeData.UP_Zn
        End If
        If Not IsNothing(RangeData.Down_Zn) AndAlso Me.Zn < RangeData.Down_Zn Then
            Me.Zn = RangeData.Down_Zn
        End If
        If Not IsNothing(RangeData.UP_Zr) AndAlso Me.Zr > RangeData.UP_Zr Then
            Me.Zr = RangeData.UP_Zr
        End If
        If Not IsNothing(RangeData.Down_Zr) AndAlso Me.Zr < RangeData.Down_Zr Then
            Me.Zr = RangeData.Down_Zr
        End If
        If Not IsNothing(RangeData.UP_Fe) AndAlso Me.Fe > RangeData.UP_Fe Then
            Me.Fe = RangeData.UP_Fe
        End If
        If Not IsNothing(RangeData.Down_Fe) AndAlso Me.Fe < RangeData.Down_Fe Then
            Me.Fe = RangeData.Down_Fe
        End If


        'Select Case True
        '    Case Not IsNothing(RangeData.UP_C) AndAlso Me.C > RangeData.UP_C
        '        Me.C = RangeData.UP_C
        '    Case Not IsNothing(RangeData.Down_C) AndAlso Me.C < RangeData.Down_C
        '        Me.C = RangeData.Down_C
        '    Case Not IsNothing(RangeData.UP_Si) AndAlso Me.Si > RangeData.UP_Si
        '        Me.Si = RangeData.UP_Si
        '    Case Not IsNothing(RangeData.Down_Si) AndAlso Me.Si < RangeData.Down_Si
        '        Me.Si = RangeData.Down_Si
        '    Case Not IsNothing(RangeData.UP_Mn) AndAlso Me.Mn > RangeData.UP_Mn
        '        Me.Mn = RangeData.UP_Mn
        '    Case Not IsNothing(RangeData.Down_Mn) AndAlso Me.Mn < RangeData.Down_Mn
        '        Me.Mn = RangeData.Down_Mn
        '    Case Not IsNothing(RangeData.UP_P) AndAlso Me.P > RangeData.UP_P
        '        Me.P = RangeData.UP_P
        '    Case Not IsNothing(RangeData.Down_P) AndAlso Me.P < RangeData.Down_P
        '        Me.P = RangeData.Down_P
        '    Case Not IsNothing(RangeData.UP_S) AndAlso Me.S > RangeData.UP_S
        '        Me.S = RangeData.UP_S
        '    Case Not IsNothing(RangeData.Down_S) AndAlso Me.S < RangeData.Down_S
        '        Me.S = RangeData.Down_S
        '    Case Not IsNothing(RangeData.UP_Cr) AndAlso Me.Cr > RangeData.UP_Cr
        '        Me.Cr = RangeData.UP_Cr
        '    Case Not IsNothing(RangeData.Down_Cr) AndAlso Me.Cr < RangeData.Down_Cr
        '        Me.Cr = RangeData.Down_Cr
        '    Case Not IsNothing(RangeData.UP_Ni) AndAlso Me.Ni > RangeData.UP_Ni
        '        Me.Ni = RangeData.UP_Ni
        '    Case Not IsNothing(RangeData.Down_Ni) AndAlso Me.Ni < RangeData.Down_Ni
        '        Me.Ni = RangeData.Down_Ni
        '    Case Not IsNothing(RangeData.UP_Cu) AndAlso Me.Cu > RangeData.UP_Cu
        '        Me.Cu = RangeData.UP_Cu
        '    Case Not IsNothing(RangeData.Down_Cu) AndAlso Me.Cu < RangeData.Down_Cu
        '        Me.Cu = RangeData.Down_Cu
        '    Case Not IsNothing(RangeData.UP_Mo) AndAlso Me.Mo > RangeData.UP_Mo
        '        Me.Mo = RangeData.UP_Mo
        '    Case Not IsNothing(RangeData.Down_Mo) AndAlso Me.Mo < RangeData.Down_Mo
        '        Me.Mo = RangeData.Down_Mo
        '    Case Not IsNothing(RangeData.UP_Co) AndAlso Me.Co > RangeData.UP_Co
        '        Me.Co = RangeData.UP_Co
        '    Case Not IsNothing(RangeData.Down_Co) AndAlso Me.Co < RangeData.Down_Co
        '        Me.Co = RangeData.Down_Co
        '    Case Not IsNothing(RangeData.UP_AL) AndAlso Me.AL > RangeData.UP_AL
        '        Me.AL = RangeData.UP_AL
        '    Case Not IsNothing(RangeData.Down_AL) AndAlso Me.AL < RangeData.Down_AL
        '        Me.AL = RangeData.Down_AL
        '    Case Not IsNothing(RangeData.UP_Sn) AndAlso Me.Sn > RangeData.UP_Sn
        '        Me.Sn = RangeData.UP_Sn
        '    Case Not IsNothing(RangeData.Down_Sn) AndAlso Me.Sn < RangeData.Down_Sn
        '        Me.Sn = RangeData.Down_Sn
        '    Case Not IsNothing(RangeData.UP_Pb) AndAlso Me.Pb > RangeData.UP_Pb
        '        Me.Pb = RangeData.UP_Pb
        '    Case Not IsNothing(RangeData.Down_Pb) AndAlso Me.Pb < RangeData.Down_Pb
        '        Me.Pb = RangeData.Down_Pb
        '    Case Not IsNothing(RangeData.UP_Ti) AndAlso Me.Ti > RangeData.UP_Ti
        '        Me.Ti = RangeData.UP_Ti
        '    Case Not IsNothing(RangeData.Down_Ti) AndAlso Me.Ti < RangeData.Down_Ti
        '        Me.Ti = RangeData.Down_Ti
        '    Case Not IsNothing(RangeData.UP_Nb) AndAlso Me.Nb > RangeData.UP_Nb
        '        Me.Nb = RangeData.UP_Nb
        '    Case Not IsNothing(RangeData.Down_Nb) AndAlso Me.Nb < RangeData.Down_Nb
        '        Me.Nb = RangeData.Down_Nb
        '    Case Not IsNothing(RangeData.UP_V) AndAlso Me.V > RangeData.UP_V
        '        Me.V = RangeData.UP_V
        '    Case Not IsNothing(RangeData.Down_V) AndAlso Me.V < RangeData.Down_V
        '        Me.V = RangeData.Down_V
        '    Case Not IsNothing(RangeData.UP_W) AndAlso Me.W > RangeData.UP_W
        '        Me.W = RangeData.UP_W
        '    Case Not IsNothing(RangeData.Down_W) AndAlso Me.W < RangeData.Down_W
        '        Me.W = RangeData.Down_W
        '    Case Not IsNothing(RangeData.UP_N2) AndAlso Me.N2 > RangeData.UP_N2
        '        Me.N2 = RangeData.UP_N2
        '    Case Not IsNothing(RangeData.Down_N2) AndAlso Me.N2 < RangeData.Down_N2
        '        Me.N2 = RangeData.Down_N2
        '    Case Not IsNothing(RangeData.UP_B) AndAlso Me.B > RangeData.UP_B
        '        Me.B = RangeData.UP_B
        '    Case Not IsNothing(RangeData.Down_B) AndAlso Me.B < RangeData.Down_B
        '        Me.B = RangeData.Down_B
        '    Case Not IsNothing(RangeData.UP_Ca) AndAlso Me.Ca > RangeData.UP_Ca
        '        Me.Ca = RangeData.UP_Ca
        '    Case Not IsNothing(RangeData.Down_Ca) AndAlso Me.Ca < RangeData.Down_Ca
        '        Me.Ca = RangeData.Down_Ca
        '    Case Not IsNothing(RangeData.UP_Mg) AndAlso Me.Mg > RangeData.UP_Mg
        '        Me.Mg = RangeData.UP_Mg
        '    Case Not IsNothing(RangeData.Down_Mg) AndAlso Me.Mg < RangeData.Down_Mg
        '        Me.Mg = RangeData.Down_Mg
        '    Case Not IsNothing(RangeData.UP_As) AndAlso Me.As > RangeData.UP_As
        '        Me.As = RangeData.UP_As
        '    Case Not IsNothing(RangeData.Down_As) AndAlso Me.As < RangeData.Down_As
        '        Me.As = RangeData.Down_As
        '    Case Not IsNothing(RangeData.UP_Bi) AndAlso Me.Bi > RangeData.UP_Bi
        '        Me.Bi = RangeData.UP_Bi
        '    Case Not IsNothing(RangeData.Down_Bi) AndAlso Me.Bi < RangeData.Down_Bi
        '        Me.Bi = RangeData.Down_Bi
        '    Case Not IsNothing(RangeData.UP_Sb) AndAlso Me.Sb > RangeData.UP_Sb
        '        Me.Sb = RangeData.UP_Sb
        '    Case Not IsNothing(RangeData.Down_Sb) AndAlso Me.Sb < RangeData.Down_Sb
        '        Me.Sb = RangeData.Down_Sb
        '    Case Not IsNothing(RangeData.UP_Zn) AndAlso Me.Zn > RangeData.UP_Zn
        '        Me.Zn = RangeData.UP_Zn
        '    Case Not IsNothing(RangeData.Down_Zn) AndAlso Me.Zn < RangeData.Down_Zn
        '        Me.Zn = RangeData.Down_Zn
        '    Case Not IsNothing(RangeData.UP_Zr) AndAlso Me.Zr > RangeData.UP_Zr
        '        Me.Zr = RangeData.UP_Zr
        '    Case Not IsNothing(RangeData.Down_Zr) AndAlso Me.Zr < RangeData.Down_Zr
        '        Me.Zr = RangeData.Down_Zr
        '    Case Not IsNothing(RangeData.UP_Fe) AndAlso Me.Fe > RangeData.UP_Fe
        '        Me.Fe = RangeData.UP_Fe
        '    Case Not IsNothing(RangeData.Down_Fe) AndAlso Me.Fe < RangeData.Down_Fe
        '        Me.Fe = RangeData.Down_Fe
        'End Select
    End Sub

#End Region

#Region "操作員工編號:MakeDataEmployeeNumber"
    ''' <summary>
    ''' 操作員工編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MakeDataEmployeeNumber As String
        Get
            If Me.SampleDatas.Count = 0 OrElse IsDBNull(Me.SampleDatas(0).Shift) Then
                Return Nothing
            End If
            Return Me.SampleDatas(0).Shift.Trim
        End Get
    End Property
#End Region

#Region "使用標準樣本名稱 屬性:UseStandardSampleName"
    ''' <summary>
    ''' 使用標準樣本名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property UseStandardSampleName As String
        Get
            Dim GetData As 標準樣本接收資料上下限 = Me.About標準樣本接收資料上下限
            If IsNothing(GetData) Then
                Return Nothing
            End If
            Return GetData.SampleNumber.Trim
        End Get
    End Property
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
                Dim CanUseSampleData As 標準樣本接收資料 = (From A In SampleDatas Where A.SampleMark <> "x" And A.SampleMark <> "X" And A.SampleMark <> "v" And A.SampleMark <> "V" Select A).FirstOrDefault
                If IsNothing(_SMPStandardSampleDataCache) Then
                    _SMPStandardSampleDataCache = (From A In DataContext.SMPStandardSample Select A).ToList
                End If
                _AboutSMPStandardSample = (From A In _SMPStandardSampleDataCache Where A.SampleNumber = CanUseSampleData.FK_SampleNumber Select A).FirstOrDefault
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
                Dim CanUseSampleData As 標準樣本接收資料 = (From A In SampleDatas Where A.SampleMark <> "x" And A.SampleMark <> "X" And A.SampleMark <> "v" And A.SampleMark <> "V" Select A).FirstOrDefault
                If IsNothing(_About標準樣本接收資料上下限Cache) Then
                    _About標準樣本接收資料上下限Cache = (From A In DataContext.標準樣本接收資料上下限 Select A).ToList
                End If
                _About標準樣本接收資料上下限 = (From A In _About標準樣本接收資料上下限Cache Where A.SampleNumber = CanUseSampleData.FK_SampleNumber Select A).FirstOrDefault
            End If
            Return _About標準樣本接收資料上下限
        End Get
        Private Set(ByVal value As 標準樣本接收資料上下限)
            _About標準樣本接收資料上下限 = value
        End Set
    End Property

#End Region



End Class
