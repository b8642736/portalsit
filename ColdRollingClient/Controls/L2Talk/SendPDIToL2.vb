Public Class SendPDIToL2

    Sub New(ByVal SetRunningPCIP As String, ByVal SetCoilNumber As String)
        RunningPCIP = SetRunningPCIP
        CoilFullNumber = SetCoilNumber
    End Sub
    Sub New(ByVal SetRunningPCIP As String, ByVal SetCoilNumber As String, ByVal SetUserDefinePDIString As String)
        RunningPCIP = SetRunningPCIP
        CoilFullNumber = SetCoilNumber
        Me.UserDefinePDIString = SetUserDefinePDIString
    End Sub

#Region "執行電腦IP 屬性:RunningPCIP"
    Private _RunningPCIP As String
    ''' <summary>
    ''' 執行電腦IP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RunningPCIP() As String
        Get
            Return _RunningPCIP
        End Get
        Set(ByVal value As String)
            _RunningPCIP = value
            AboutOperationPCRunningState = Nothing
            AboutPIDs = Nothing
        End Set
    End Property

#End Region
#Region "完整鋼捲編號 屬性:CoilFullNumber"
    Private _CoilFullNumber As String
    ''' <summary>
    ''' 完整鋼捲編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CoilFullNumber() As String
        Get
            Return _CoilFullNumber
        End Get
        Set(ByVal value As String)
            _CoilFullNumber = value
            AboutPIDs = Nothing
        End Set
    End Property
#End Region
#Region "使用者自訂PDI字串 屬性:UserDefinePDIString"
    Private _UserDefinePDIString As String
    ''' <summary>
    ''' 使用者自訂PDI字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserDefinePDIString() As String
        Get
            Return _UserDefinePDIString
        End Get
        Set(ByVal value As String)
            _UserDefinePDIString = value
        End Set
    End Property
#End Region
#Region "轉換PDI至文字 方法:ConvertPDIToText"
    ''' <summary>
    ''' 轉換PDI至文字
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>PDI(目前有成品線作業規定/APL暫時性PDI)</remarks>
    Function ConvertPDIToText(ByVal SetConvertPIDType As ConvertPIDType) As String
        Dim GetState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = AboutOperationPCRunningState
        If IsNothing(GetState) OrElse IsNothing(Me.AboutPIDs) OrElse String.IsNullOrEmpty(GetState.DefaultUseStationName) OrElse _
            (SetConvertPIDType = ConvertPIDType.QASeparateCmd AndAlso Not {"SPL", "SBL", "TLL", "APL"}.Contains(GetState.DefaultUseStationName.Trim.PadRight(3).Substring(0, 3))) Then
            Return String.Empty
        End If
        Dim ReturnValue As New StringBuilder
        Select Case True
            Case SetConvertPIDType = ConvertPIDType.QASeparateCmd
                '成品線作業規定文字轉換
                '格式:鋼捲編號,資料建立時間,QA分捲名稱(A~Z),寬度,厚度,長度,出口缺陷,出口分捲長度,入口缺陷,入口分捲長度
                For Each EachItem As CompanyORMDB.SQLServer.PPS100LB.PDI In (From A In Me.AboutPIDs Where A.MsgType = 1 And A.CreateMsgDept.Trim = "QA" Select A Order By A.QASeparateName, A.CreateMsgTime).ToList
                    ReturnValue.Append(IIf(String.IsNullOrEmpty(ReturnValue.ToString), Nothing, vbNewLine))
                    With EachItem
                        ReturnValue.Append(Me.AboutOperationPCRunningState.DefaultUseStationName.Trim)
                        ReturnValue.Append("," & .CoilFullNumber.Trim)
                        ReturnValue.Append("," & Format(.CreateMsgTime, "yyyy/MM/dd HH:mm:ss"))
                        ReturnValue.Append("," & .QASeparateName.Trim)
                        ReturnValue.Append("," & .CoilWidth)
                        ReturnValue.Append("," & .CoilThick * IIf({"TLL", "CPL", "GPL"}.Contains(GetState.DefaultUseStationName.PadRight(3).Substring(0, 3)), 1000, 1))
                        ReturnValue.Append("," & .CoilLength)
                        ReturnValue.Append("," & .FrontCutLength)
                        ReturnValue.Append("," & .TailCutLength)
                    End With
                Next
            Case SetConvertPIDType = ConvertPIDType.APLSeparateCmd
                ReturnValue.Append(UserDefinePDIString)
        End Select
        Return ReturnValue.ToString
    End Function
#End Region
#Region "轉換PDI格式 列舉:ConvertPIDType"
    ''' <summary>
    ''' 轉換PDI格式
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ConvertPIDType
        QASeparateCmd = 0   '成品線作業規定
        APLSeparateCmd = 1  'APL分捲命令
    End Enum
#End Region
#Region "轉換狀態至文字檔 方法:ConvertStateToFullPathTextFile"
    ''' <summary>
    ''' 轉換狀態至文字檔
    ''' </summary>
    ''' <param name="FullPathTextFile"></param>
    ''' <remarks></remarks>
    Sub ConvertStateToFullPathTextFile(ByVal FullPathTextFile As String, ByVal SetConvertPIDType As ConvertPIDType)
        My.Computer.FileSystem.WriteAllText(FullPathTextFile, ConvertPDIToText(SetConvertPIDType), False)
    End Sub
#End Region
#Region "相關OperationPCRunningState"
    Private _AboutOperationPCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState
    ''' <summary>
    ''' 相關OperationPCRunningState
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AboutOperationPCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState
        Get
            If IsNothing(_AboutOperationPCRunningState) Then
                _AboutOperationPCRunningState = CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter.TheMachinePCRunningState
            End If
            Return _AboutOperationPCRunningState
        End Get
        Private Set(value As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState)
            _AboutOperationPCRunningState = value
        End Set
    End Property
#End Region
#Region "相關PDI命令 屬性:AboutPIDs"
    '成品線作業規定
    Private _AboutPIDs As List(Of CompanyORMDB.SQLServer.PPS100LB.PDI)
    ''' <summary>
    ''' 相關PDI命令
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutPIDs() As List(Of CompanyORMDB.SQLServer.PPS100LB.PDI)
        Get
            If IsNothing(_AboutPIDs) Then
                Dim QryString = "Select * From PDI where CoilFullNumber='" & Me.CoilFullNumber & "' and CreateMsgTime>='" & Format(Now.AddYears(-6), "yyyy/MM/dd") & "' Order by CreateMsgTime"
                _AboutPIDs = CompanyORMDB.SQLServer.PPS100LB.PDI.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.PDI)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            End If
            Return _AboutPIDs
        End Get
        Private Set(ByVal value As List(Of CompanyORMDB.SQLServer.PPS100LB.PDI))
            _AboutPIDs = value
        End Set
    End Property

#End Region

End Class
