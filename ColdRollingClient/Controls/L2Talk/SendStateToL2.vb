Public Class SendStateToL2

    Sub New(ByVal SetRunningPCIP As String)
        RunningPCIP = SetRunningPCIP
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
        End Set
    End Property

#End Region

#Region "轉換狀態至文字 方法:ConvertStateToText"
    ''' <summary>
    ''' 轉換狀態至文字
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ConvertStateToText() As String
        Dim GetState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter.CurrentOperationPCRunningState
        If IsNothing(GetState) Then
            Return String.Empty
        End If
        Dim ReturnValue As String = String.Empty
        Dim GetDefaultUseStationName As String
        Dim GetRunningProcessCoilsAndRunProcessdata As New List(Of String)
        Dim PRE_UPAndRunProcessdata As New List(Of String)
        Dim PRE_DOWNAndRunProcessdata As New List(Of String)



        With GetState
            GetDefaultUseStationName = .DefaultUseStationName.Trim
            If String.IsNullOrEmpty(GetDefaultUseStationName) Then
                Return String.Empty
            End If
            If GetDefaultUseStationName.Length > 0 AndAlso Val(GetDefaultUseStationName.Substring(GetDefaultUseStationName.Length - 1, 1)) = 0 Then
                GetDefaultUseStationName &= "1"
            End If
            If Not String.IsNullOrEmpty(.RunningProcessCoils) AndAlso .RunningProcessCoils.Trim.Length > 0 Then
                For Each CoilNumber As String In .RunningProcessCoils.Split(";").Reverse.ToArray
                    GetRunningProcessCoilsAndRunProcessdata.Add(CoilNumber)
                Next
            End If
            If Not String.IsNullOrEmpty(.Line1WaitProcessCoils) AndAlso .Line1WaitProcessCoils.Trim.Length > 0 Then
                For Each CoilNumber As String In .Line1WaitProcessCoils.Split(";").ToArray
                    PRE_UPAndRunProcessdata.Add(CoilNumber)
                Next
            End If
            If Not String.IsNullOrEmpty(.Line2WaitProcessCoils) AndAlso .Line2WaitProcessCoils.Trim.Length > 0 Then
                For Each CoilNumber As String In .Line2WaitProcessCoils.Split(";").ToArray
                    PRE_DOWNAndRunProcessdata.Add(CoilNumber)
                Next
            End If
        End With

        Dim Order As Integer = 1
        Dim CoilLastAboutPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF
        For Each EachItem As String In GetRunningProcessCoilsAndRunProcessdata
            If String.IsNullOrEmpty(EachItem) Then
                Exit For
            End If
            If Not String.IsNullOrEmpty(ReturnValue) Then
                ReturnValue &= vbNewLine
            End If

            CoilLastAboutPPSSHAPF = GetLastAboutPPSSHAPF(EachItem)
            If GetRunningProcessCoilsAndRunProcessdata.Contains(EachItem) = False OrElse IsNothing(CoilLastAboutPPSSHAPF) Then
                ReturnValue &= GetDefaultUseStationName & ",RUNNING," & Order & "," & EachItem.Trim & "," & EachItem.Trim & ",0,0,0"
            Else
                ReturnValue &= GetDefaultUseStationName & ",RUNNING," & Order & "," & EachItem.Trim & "," & GetLastAboutRunProcessDataNumber(EachItem.Trim)
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA16
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA14 * IIf({"TLL", "CPL", "GPL"}.Contains(GetDefaultUseStationName.PadRight(3).Substring(0, 3)), 1000, 1)
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA15
            End If
            Order += 1
        Next

        Order = 1
        For Each EachItem As String In PRE_UPAndRunProcessdata
            If String.IsNullOrEmpty(EachItem) Then
                Exit For
            End If
            If Not String.IsNullOrEmpty(ReturnValue) Then
                ReturnValue &= vbNewLine
            End If

            CoilLastAboutPPSSHAPF = GetLastAboutPPSSHAPF(EachItem)
            If PRE_UPAndRunProcessdata.Contains(EachItem) = False OrElse IsNothing(CoilLastAboutPPSSHAPF) Then
                ReturnValue &= GetDefaultUseStationName & ",PRE-UP," & Order & "," & EachItem.Trim & "," & EachItem.Trim & ",0,0,0"
            Else
                ReturnValue &= GetDefaultUseStationName & ",PRE-UP," & Order & "," & EachItem.Trim & "," & EachItem.Trim
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA16
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA14 * IIf({"TLL", "CPL", "GPL"}.Contains(GetDefaultUseStationName.PadRight(3).Substring(0, 3)), 1000, 1)
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA15
            End If
            Order += 1
        Next


        Order = 1
        For Each EachItem As String In PRE_DOWNAndRunProcessdata
            If String.IsNullOrEmpty(EachItem) Then
                Exit For
            End If
            If Not String.IsNullOrEmpty(ReturnValue) Then
                ReturnValue &= vbNewLine
            End If

            CoilLastAboutPPSSHAPF = GetLastAboutPPSSHAPF(EachItem)
            If PRE_DOWNAndRunProcessdata.Contains(EachItem) = False OrElse IsNothing(CoilLastAboutPPSSHAPF) Then
                ReturnValue &= GetDefaultUseStationName & ",PRE-DOWN," & Order & "," & EachItem.Trim & "," & EachItem.Trim & ",0,0,0"
            Else
                ReturnValue &= GetDefaultUseStationName & ",PRE-DOWN," & Order & "," & EachItem.Trim & "," & EachItem.Trim
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA16
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA14 * IIf(GetDefaultUseStationName.PadRight(3).Substring(0, 3) = "TLL", 1000, 1)
                ReturnValue &= "," & CoilLastAboutPPSSHAPF.SHA15
            End If
            Order += 1
        Next
        Return ReturnValue
    End Function

    Private Function GetLastAboutRunProcessDataNumber(ByVal OrginCoilNumber As String) As String
        Dim CoilPPSSHAPFFlowAdapter As New CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter(OrginCoilNumber)
        Dim CoilAboutRunProcessDatas As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData) = (From A In CoilPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 1 Select A).ToList

        If IsNothing(CoilAboutRunProcessDatas) OrElse CoilAboutRunProcessDatas.Count <= 1 Then
            Return OrginCoilNumber
        End If
        Return (From A In CoilPPSSHAPFFlowAdapter.AboutRunProcessDatas Select OutNumber = A.FK_OutSHA01 & A.FK_OutSHA02.Trim Order By OutNumber Descending).FirstOrDefault.Trim
    End Function

    Private Function GetLastAboutPPSSHAPF(ByVal OrginCoilNumber As String) As CompanyORMDB.IPPS100LB.IPPSSHAPF
        Dim CoilPPSSHAPFFlowAdapter As New CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter(OrginCoilNumber)

        Dim CoilAboutPPSSHAPFs As List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF) = CoilPPSSHAPFFlowAdapter.FinalALLPPSSHAPFs
        CoilAboutPPSSHAPFs = (From A In CoilAboutPPSSHAPFs Where (A.SHA01 & A.SHA02).Trim = OrginCoilNumber.Trim Select A).ToList
        If IsNothing(CoilAboutPPSSHAPFs) OrElse CoilAboutPPSSHAPFs.Count = 0 Then
            Return Nothing
        End If

        Return (From A In CoilAboutPPSSHAPFs Select A Order By A.SHA01 & A.SHA02.Trim & A.SHA04 Descending).FirstOrDefault
    End Function
#End Region

#Region "轉換狀態至文字檔 方法:ConvertStateToFullPathTextFile"
    ''' <summary>
    ''' 轉換狀態至文字檔
    ''' </summary>
    ''' <param name="FullPathTextFile"></param>
    ''' <remarks></remarks>
    Sub ConvertStateToFullPathTextFile(ByVal FullPathTextFile As String)
        My.Computer.FileSystem.WriteAllText(FullPathTextFile, ConvertStateToText, False)
    End Sub
#End Region




End Class
