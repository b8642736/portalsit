Module StandardSampleModule1


#Region "重新整理取得每一個時段之前幾筆資料記錄之時間點：GetTimeRangeFirstTwoTimes"

    Public Function GetTimeRangeFirstTwoTimes(ByVal fromStartDate As Date, ByVal fromEndDate As Date, _
                                                                                      ByVal fromAllList As List(Of SQLServer.QCDB01.標準樣本接收資料CS_儀器匯入), _
                                                                                      ByVal fromShowCount As Integer) As List(Of SQLServer.QCDB01.標準樣本接收資料CS_儀器匯入)
        Dim ReturnList As List(Of SQLServer.QCDB01.標準樣本接收資料CS_儀器匯入) = GetTimeRangeFirstTwoTimes(Of SQLServer.QCDB01.標準樣本接收資料CS_儀器匯入)(fromStartDate, fromEndDate, fromAllList, fromShowCount)
        Return ReturnList
    End Function

    Public Function GetTimeRangeFirstTwoTimes(ByVal fromStartDate As Date, ByVal fromEndDate As Date, _
                                                                                          ByVal fromAllList As List(Of SQLServer.QCDB01.標準樣本接收資料OX), _
                                                                                          ByVal fromShowCount As Integer) As List(Of SQLServer.QCDB01.標準樣本接收資料OX)
        Dim ReturnList As List(Of SQLServer.QCDB01.標準樣本接收資料OX) = GetTimeRangeFirstTwoTimes(Of SQLServer.QCDB01.標準樣本接收資料OX)(fromStartDate, fromEndDate, fromAllList, fromShowCount)
        Return ReturnList
    End Function


    Public Function GetTimeRangeFirstTwoTimes(ByVal fromStartDate As Date, ByVal fromEndDate As Date, _
                                                                                            ByVal fromAllList As List(Of SQLServer.QCDB01.標準樣本接收資料), _
                                                                                            ByVal fromShowCount As Integer) As List(Of SQLServer.QCDB01.標準樣本接收資料)
        Dim ReturnList As List(Of SQLServer.QCDB01.標準樣本接收資料) = GetTimeRangeFirstTwoTimes(Of SQLServer.QCDB01.標準樣本接收資料)(fromStartDate, fromEndDate, fromAllList, fromShowCount)
        Return ReturnList
    End Function


    Private Function GetTimeRangeFirstTwoTimes(Of ObjectType As {ORMBaseClass.ClassDBSQLServer, New}) _
                                                                                               (ByVal fromStartDate As Date, ByVal fromEndDate As Date, _
                                                                                                ByVal fromAllList As List(Of ObjectType), _
                                                                                                ByVal fromShowCount As Integer) As List(Of ObjectType)

        Dim ReturnList As New List(Of ObjectType)

        Dim IndexCount As Integer : IndexCount = -1

        Dim FilterStartTime As Date
        Dim FilterEndTime As Date

        Dim TimeDatas As String
        For Each eachItem As Object In fromAllList
            TimeDatas = CDate(eachItem.日期時間)

            If IndexCount = -1 Then
                FilterStartTime = DateAdd("n", 30, DateAdd("h", 7, fromStartDate))
                FilterEndTime = DateAdd("h", 8, FilterStartTime)

                Do Until FilterEndTime > TimeDatas
                    '切換時段
                    FilterStartTime = FilterEndTime
                    FilterEndTime = DateAdd("h", 8, FilterStartTime)
                Loop

                IndexCount = 0

            ElseIf (TimeDatas > FilterEndTime) Then
                IndexCount = 0

                Do Until FilterEndTime > TimeDatas
                    '切換時段
                    FilterStartTime = FilterEndTime
                    FilterEndTime = DateAdd("h", 8, FilterStartTime)
                Loop
            End If

            If TimeDatas >= FilterStartTime And TimeDatas < FilterEndTime And IndexCount <= (fromShowCount - 1) Then
                IndexCount = IndexCount + 1
                ReturnList.Add(eachItem)
            End If

        Next

        Return ReturnList
    End Function
#End Region

#Region "取得時段代號：getAPN"
    Public Function getAPN(ByVal fromDate As Date) As String
        Dim retAPN As String

        If Format(fromDate, "HH:mm:ss") >= "07:30:00" AndAlso Format(fromDate, "HH:mm:ss") < "15:30:00" Then
            retAPN = "A"
        ElseIf Format(fromDate, "HH:mm:ss") >= "15:30:00" AndAlso Format(fromDate, "HH:mm:ss") < "23:30:00" Then
            retAPN = "B"
        Else
            retAPN = "C"
        End If

        Return retAPN
    End Function
#End Region



End Module
