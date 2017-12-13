Partial Public Class EAFT2_OperatorType

#Region "找尋操作代碼 方法FindOperatorTypeID"
    ''' <summary>
    ''' 找尋操作代碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function FindOperatorTypeID(ByVal OperatorType As OperatorTypeEnum, Optional ByVal IsReFindFromDataBase As Boolean = False) As Integer
        Dim FindRecord As EAFT2_OperatorType = FindOperatorType(OperatorType, IsReFindFromDataBase)
        If IsNothing(FindRecord) Then
            Return 0
        End If
        Return FindRecord.OperatorTypeID
    End Function
#End Region

#Region "找尋操作 方法FindOperatorType"
    ''' <summary>
    ''' 找尋操作
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function FindOperatorType(ByVal OperatorType As OperatorTypeEnum, Optional ByVal IsReFindFromDataBase As Boolean = False) As EAFT2_OperatorType
        Static FindRecords As List(Of EAFT2_OperatorType) = Nothing
        If IsNothing(FindRecords) OrElse IsReFindFromDataBase Then
            Dim DBContext As New EAFClassesDataContext
            FindRecords = (From A In DBContext.EAFT2_OperatorType Select A).ToList
        End If
        Return (From A In FindRecords Where A.OperatorTypeID = OperatorType Select A).FirstOrDefault
    End Function
#End Region

End Class

Public Enum OperatorTypeEnum
    前爐完 = 1
    接電極完 = 2
    補爐完 = 3
    準備送電I = 4
    送電I = 5
    準備送電II = 6
    送電II = 7
    準備送電III = 8
    送電III = 9
    準備送電IV = 10
    送電IV = 11
    MD = 12
    S1_T1 = 13
    O2 = 14
    O2止 = 15
    S2_T2 = 16
    Tap = 17
    S3_T3 = 18
End Enum


