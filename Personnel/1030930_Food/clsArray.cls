VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsArray"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

'***********************************************************************
'程式設計人員:陳坤何
'程式設計日期:2005/09/20
'程式說明:欄位拆解與合併
'最後修正人員:
'最後修正日期:
'***********************************************************************
Const MaxCol = 50
Dim mData() As mdata_str
Dim mIndex As Long
Private Type mdata_str
     smData(1 To MaxCol + 1) As Variant
End Type
Dim mSortCol As Long
Dim mCols As Long


Private Sub Class_Initialize()
mIndex = 0
ReDim mData(0 To 0)
 mCols = 0
End Sub
Public Sub Clear()
Class_Initialize
End Sub
Public Sub Add(ByVal key1 As Variant, Optional ByVal key2 As Variant = "", Optional ByVal key3 As Variant = "")
mIndex = mIndex + 1
ReDim Preserve mData(0 To mIndex)

mData(mIndex).smData(1) = key1
mData(mIndex).smData(2) = key2
mData(mIndex).smData(3) = key3
If mCols < 3 Then mCols = 3
End Sub
Public Sub AddKey(ByVal key1 As Variant, Optional ByVal key2 As Variant = "", Optional ByVal key3 As Variant = "")
Dim W_INDEX As Long
W_INDEX = KeyIndex(key1)
If W_INDEX = 0 Then
    mIndex = mIndex + 1
    ReDim Preserve mData(0 To mIndex)
    mData(mIndex).smData(1) = key1
    mData(mIndex).smData(2) = key2
    mData(mIndex).smData(3) = key3
    If mCols < 3 Then mCols = 3
End If
End Sub

Public Sub AddByRs(ByRef Rs As Recordset, Optional ByVal NoDuplicate As Boolean = False)
Dim II As Long
Dim JJ As Long
Dim W_Col As Long
Dim W_Flag As Boolean
'為了增加速度
If Rs.RecordCount > 0 And NoDuplicate = False Then
    II = mIndex
    mIndex = II + Rs.RecordCount
    ReDim Preserve mData(0 To mIndex)
    Do While Not Rs.EOF
                II = II + 1
                If Rs.Fields.Count > MaxCol Then
                      W_Col = MaxCol
                  Else
                      W_Col = Rs.Fields.Count
                  End If
                  For JJ = 1 To W_Col
                          mData(II).smData(JJ) = Rs.Fields(JJ - 1)
                  Next JJ
             Rs.MoveNext
    Loop
    If mCols < W_Col Then mCols = W_Col
Else
        Do While Not Rs.EOF
            W_Flag = True
            If NoDuplicate = True Then
                    W_Flag = (KeyIndex(Rs.Fields(0).value) = 0)
            End If
            If W_Flag = True Then
                        mIndex = mIndex + 1
                        ReDim Preserve mData(0 To mIndex)
                        If Rs.Fields.Count > MaxCol Then
                            JJ = MaxCol
                        Else
                            JJ = Rs.Fields.Count
                        End If
                        For II = 1 To JJ
                                mData(mIndex).smData(II) = Rs.Fields(II - 1)
                        Next II
            End If
            Rs.MoveNext
        Loop
        If mCols < JJ Then mCols = JJ
End If
End Sub
Public Sub addByCsv(ByVal FileName As String, Optional ByVal NoDuplicate As Boolean = False)
Dim II As Long
Dim JJ As Long
Dim W_h As Long
Dim W_data As String
Dim W_Rec As String
Dim W_Fleld As Variant
W_h = FreeFile
On Error GoTo Err_Rtn
Open FileName For Input As #W_h
        Do While Not EOF(W_h)
              Line Input #W_h, W_Rec
              If W_Rec <> "" Then
                    W_Fleld = Split(W_Rec, ",")
                     If NoDuplicate = False Or (NoDuplicate = True And KeyIndex(W_Fleld(0)) = 0) Then
                              mIndex = mIndex + 1
                              ReDim Preserve mData(0 To mIndex)
                              If UBound(W_Fleld) + 1 > MaxCol Then
                                  JJ = MaxCol
                              Else
                                  JJ = UBound(W_Fleld) + 1
                              End If
                              For II = 1 To JJ
                                      mData(mIndex).smData(II) = W_Fleld(II - 1)
                              Next II
                      End If
              End If
       Loop
        If mCols < JJ Then mCols = JJ
Close #W_h
Exit Sub
Err_Rtn:
    MsgBox ERR.Description, , "系統錯誤訊息"
End Sub
Public Sub Save2Csv(ByVal FileName As String, ByVal Cols As Long)
Dim II As Long
Dim JJ As Long
Dim W_h As Long
Dim W_data As String
Dim W_Rec As String
Dim W_Fleld As Variant
W_h = FreeFile
On Error GoTo Err_Rtn

Open FileName For Output As #W_h
        For II = 1 To mIndex
               W_Rec = ""
              For JJ = 1 To Cols - 1
                    W_Rec = W_Rec & mData(II).smData(JJ) & ","
               Next JJ
                W_Rec = W_Rec & mData(II).smData(JJ)
                Print #W_h, W_Rec
         Next II
Close #W_h
Exit Sub
Err_Rtn:
    MsgBox ERR.Description, , "系統錯誤訊息"
End Sub



Public Property Let Count(ByVal value As Long)
    mIndex = value
    ReDim Preserve mData(0 To mIndex)
End Property
Public Property Get Count() As Long
    Count = mIndex
End Property

Public Property Get value(ByVal Index As Long, ByVal Col As Long) As Variant
If Index < 1 Or Index > mIndex Or Col < 1 Or Col > MaxCol Then
    MsgBox "超過範圍值", , "系統錯誤訊息"
Else
    value = mData(Index).smData(Col)
End If
End Property

Public Property Let value(ByVal Index As Long, ByVal Col As Long, ByVal NewData As Variant)
If Index < 1 Or Index > mIndex Or Col < 1 Or Col > MaxCol Then
    MsgBox "超過範圍值", , "系統錯誤訊息"
Else
      mData(Index).smData(Col) = NewData
End If
End Property

Public Function KeyIndex(ByVal key1 As Variant) As Long
Dim II As Long
    For II = 1 To mIndex
        If mData(II).smData(1) = key1 Then
            KeyIndex = II
            Exit Function
        End If
   Next II
KeyIndex = 0
End Function

Public Function KeyValue(ByVal key1 As Variant, ByVal Col As Long, Optional ByVal Default As Variant = "") As Variant
Dim II As Long

    If Col < 1 Or Col > MaxCol Then
        KeyValue = Default
        Exit Function
    End If

    For II = 1 To mIndex
        If mData(II).smData(1) = key1 Then
            KeyValue = mData(II).smData(Col)
            Exit Function
        End If
   Next II
KeyValue = Default
End Function

Public Sub MergeByRs(ByRef Rs As Object, ColIndex)
Dim II As Long
Dim JJ As Long
Dim W_INDEX
If ColIndex > MaxCol Then
    MsgBox "超過範圍.." & ColIndex
    Exit Sub
End If
Do While Not Rs.EOF
    W_INDEX = KeyIndex(Rs.Fields(0).value)
    If W_INDEX = 0 Then
                mIndex = mIndex + 1
                ReDim Preserve mData(0 To mIndex)
                 mData(mIndex).smData(1) = Rs.Fields(0)
                 mData(mIndex).smData(ColIndex) = Rs.Fields(1)
    Else
            mData(W_INDEX).smData(ColIndex) = Rs.Fields(1)
    End If
    Rs.MoveNext
Loop
End Sub

Public Sub Merge(ByVal ColIndex As Integer, ByRef a As clsArray, ByVal arrayColIndex As Integer)
Dim II As Long
Dim JJ As Long
Dim W_INDEX
If ColIndex > MaxCol Then
    MsgBox "超過範圍.." & ColIndex
    Exit Sub
End If
For II = 1 To a.Count
    W_INDEX = KeyIndex(a.value(II, 1))
    If W_INDEX = 0 Then
                mIndex = mIndex + 1
                ReDim Preserve mData(0 To mIndex)
                 mData(mIndex).smData(1) = a.value(II, 1)
                 mData(mIndex).smData(ColIndex) = a.value(II, arrayColIndex)
    Else
            mData(W_INDEX).smData(ColIndex) = a.value(II, arrayColIndex)
    End If
Next
End Sub


Public Sub ReMove(ByVal Index As Long)
Dim II As Long
Dim W_data() As mdata_str
ReDim W_data(0 To mIndex - Index)

If Index <= mIndex And Index > 0 Then
    For II = Index + 1 To mIndex
            W_data(II - Index) = mData(II)
    Next II
    mIndex = mIndex - 1
    ReDim Preserve mData(0 To mIndex)
    For II = Index To mIndex
             mData(II) = W_data(II - Index + 1)
    Next II
End If
End Sub

Public Sub ReMoveKey(ByVal key1 As Variant)
Dim W_INDEX
W_INDEX = KeyIndex(key1)
If W_INDEX > 0 Then
    ReMove (W_INDEX)
End If
End Sub
Public Sub Sort(ByVal Colunm As Long)
    mSortCol = Colunm
    QuickSort 1, mIndex
End Sub
Public Sub SortColList(ByVal ColList As String)
    Dim W_Temp As Variant
    Dim II As Long, JJ As Long, KK As Long, LL As Long
    Dim W_Key As Long
    Dim L As Long
    W_Temp = Split(ColList, ",")
    mSortCol = Val(W_Temp(0))
    QuickSort 1, mIndex
    
    For JJ = 1 To UBound(W_Temp)
            L = 1
            W_Key = 1
            mSortCol = Val(W_Temp(JJ))
            For II = 2 To mIndex
                       If ChkIsSame(W_Key, II, ColList, 0, JJ - 1) = False Then
                            W_Key = II
                            If II - L > 1 Then
                                QuickSort L, II - 1
                            End If
                           L = II
                  End If
            Next II
            If II - L > 1 Then
                    QuickSort L, II - 1
            End If
   Next JJ
End Sub

Public Function GetCsvString(ByVal Colunm As Long, Optional ByVal NoEmpty As Boolean = False, Optional ByVal charString As String = "") As String

Dim II As Long
Dim JJ As Long
GetCsvString = ""
For II = 1 To mIndex
    If Trim(mData(II).smData(Colunm)) <> "" Or NoEmpty = False Then
    
       GetCsvString = GetCsvString & charString & Trim(mData(II).smData(Colunm)) & charString & ","
   End If
Next II
If GetCsvString <> "" Then
    GetCsvString = Left(GetCsvString, Len(GetCsvString) - 1)
End If
End Function
Public Function GetValueArray(ByVal Index As Long, ByVal Colunms As Long) As Variant
Dim W_Temp() As Variant
Dim II As Long
ReDim W_Temp(Colunms) As Variant
For II = 1 To Colunms
    W_Temp(II) = mData(Index).smData(II)
Next II
GetValueArray = W_Temp
End Function

Public Sub AddSum(ByVal key1 As String, ByVal Col As Long, ByVal value As Double)
    Dim W_INDEX As Long
    W_INDEX = KeyIndex(key1)
    If W_INDEX = 0 Then
        mIndex = mIndex + 1
        ReDim Preserve mData(0 To mIndex)
        mData(mIndex).smData(1) = key1
        mData(mIndex).smData(Col) = value
    Else
        mData(W_INDEX).smData(Col) = mData(W_INDEX).smData(Col) + value
    End If
End Sub

Public Function Str2SQLStr(ByVal Column As Long, Optional ByVal char As String = "'", Optional ByVal splitstr As String = ",") As String
    '2006/2/10 Add
    Dim II As Long
    On Error Resume Next
    Str2SQLStr = ""
    For II = 1 To mIndex
            Str2SQLStr = Str2SQLStr & char & mData(II).smData(Column) & char & splitstr
    Next II
    If Str2SQLStr <> "" Then
        Str2SQLStr = Left(Str2SQLStr, Len(Str2SQLStr) - Len(splitstr))
    End If
End Function

Public Function AddSum2(ByVal key1 As String, ByVal Col As Long, ByVal value As Double) As Long
    Dim W_INDEX As Long
    W_INDEX = KeyIndex(key1)
    If W_INDEX = 0 Then
        mIndex = mIndex + 1
        ReDim Preserve mData(0 To mIndex)
        mData(mIndex).smData(1) = key1
        mData(mIndex).smData(Col) = value
        AddSum2 = mIndex
    Else
        mData(W_INDEX).smData(Col) = mData(W_INDEX).smData(Col) + value
        AddSum2 = W_INDEX
    End If
    
End Function

Public Sub SetColValue(ByVal Colunms As Long, ByVal value As Variant)
    Dim II As Long
    If Colunms < 1 Or Colunms > 50 Then Exit Sub
    For II = 1 To mIndex
         mData(II).smData(Colunms) = value
    Next II
End Sub

Public Sub CopyProperty(ByRef Array1 As clsArray)
    Dim II As Long
    Dim JJ As Long
    mIndex = Array1.Count
    ReDim Preserve mData(0 To mIndex)
    For II = 1 To Array1.Count
            For JJ = 1 To MaxCol
                mData(II).smData(JJ) = Array1.value(II, JJ)
            Next JJ
    Next II
End Sub
Public Function BinarySearch(ByVal Key As Variant, Optional ByVal Col As Long = 1) As Long
    '前題為Col已排序
    Dim W_Low As Long
    Dim W_Upper As Long
    Dim W_Mid As Long
    BinarySearch = 0
    W_Low = 1
    W_Upper = mIndex
    Do While W_Low <= W_Upper
            W_Mid = Int(W_Upper + W_Low) / 2
            If mData(W_Mid).smData(Col) < Key Then
                W_Low = W_Mid + 1
            ElseIf mData(W_Mid).smData(Col) > Key Then
                 W_Upper = W_Mid - 1
            Else
                BinarySearch = W_Mid
                Exit Do
            End If
    Loop
End Function

Public Function BinarySeek(ByVal Key As Variant, Optional ByVal Col As Long = 1) As Long
    '前題為Col已排序
    Dim W_Low As Long
    Dim W_Upper As Long
    Dim W_Mid As Long
    BinarySeek = 0
    W_Low = 1
    W_Upper = mIndex
    Do While W_Low <= W_Upper
            W_Mid = Int(W_Upper + W_Low) / 2
            If mData(W_Mid).smData(Col) < Key Then
                W_Low = W_Mid + 1
            ElseIf mData(W_Mid).smData(Col) > Key Then
                 W_Upper = W_Mid - 1
            Else
                 BinarySeek = W_Mid
                 Exit Do
            End If
    Loop
    If BinarySeek > 0 Then
         W_Upper = W_Mid
         Do While W_Low <= W_Upper
             W_Mid = Int(W_Upper + W_Low) / 2
             If mData(W_Mid).smData(Col) = Key Then
                 BinarySeek = W_Mid
                 W_Upper = W_Mid - 1
             Else
                 W_Low = W_Mid + 1
             End If
        Loop
    End If
End Function
Private Function Partition(ByVal L As Long, ByVal R As Long) As Long
    Dim II As Long, JJ As Long
    Dim W_Temp As mdata_str
    II = L - 1
    For JJ = L To R - 1
         If mData(JJ).smData(mSortCol) <= mData(R).smData(mSortCol) Then
            II = II + 1
            W_Temp = mData(II)
             mData(II) = mData(JJ)
             mData(JJ) = W_Temp
        End If
    Next JJ
     II = II + 1
    W_Temp = mData(II)
     mData(II) = mData(R)
     mData(R) = W_Temp
     Partition = II
End Function
     
Private Function QuickSort(ByVal L As Long, ByVal R As Long) As Long
    Dim Q As Long
    If L < R Then
        Q = Partition(L, R)
        Call QuickSort(L, Q - 1)
        Call QuickSort(Q + 1, R)
    End If
End Function

Public Function DistinctCount(ByVal Col As Long) As Long
    Dim II As Long
    Dim W_Temp As Variant
    DistinctCount = 0
    For II = 1 To mIndex
            If W_Temp <> mData(II).smData(Col) Then
                DistinctCount = DistinctCount + 1
                W_Temp = mData(II).smData(Col)
            End If
    Next II
End Function
' 2006/12/7 add
Public Sub addByStr(ByVal Str As String, ByVal RowTerm As String, ByVal ColTerm As String, Optional ByVal NoDuplicate As Boolean = False)
Dim II As Long
Dim JJ As Long
Dim KK As Long
Dim W_h As Long
Dim W_data As String
Dim W_Rec As Variant
Dim W_Fleld As Variant
        W_Rec = Split(Str, RowTerm)
        For II = 0 To UBound(W_Rec)
              If W_Rec(II) <> "" Then
                    W_Fleld = Split(W_Rec(II), ColTerm)
                     If NoDuplicate = False Or (NoDuplicate = True And KeyIndex(W_Fleld(0)) = 0) Then
                              mIndex = mIndex + 1
                              ReDim Preserve mData(0 To mIndex)
                              If UBound(W_Fleld) + 1 > MaxCol Then
                                  JJ = MaxCol
                              Else
                                  JJ = UBound(W_Fleld) + 1
                              End If
                              For KK = 1 To JJ
                                      mData(mIndex).smData(KK) = W_Fleld(KK - 1)
                              Next KK
                      End If
              End If
       Next II
Exit Sub
Err_Rtn:
    MsgBox ERR.Description, , "系統錯誤訊息"
End Sub

Public Function SplitKey(ByVal Index As Long, ByVal SplitCol As Long, Optional ByVal Term As String = "|") As String
    Dim W_Temp As Variant
    W_Temp = Split(mData(Index).smData(1), Term)
    SplitKey = W_Temp(SplitCol - 1)
End Function

Public Function GroupBy(Optional ByVal SelectList As String = "SUM(2)", Optional ByVal GroupByList As String = "1") As clsArray
    Dim W_Select As Variant
    Dim W_GroupBy As Variant
    Dim II As Long
    Dim JJ As Long
    Dim KK As Long
    Dim W_INDEX As Long
    Dim W_Flag As Boolean
    Dim W_Temp As String
    Set GroupBy = New clsArray
    W_Select = Split(SelectList, ",")
    W_GroupBy = Split(GroupByList, ",")
    If UBound(W_Select) = -1 Then
        Exit Function
    End If
    For II = 1 To mIndex
            W_INDEX = 0
            For JJ = 1 To GroupBy.Count
                W_Flag = True
                For KK = 0 To UBound(W_GroupBy)
                    W_Flag = W_Flag And (mData(II).smData(Val(W_GroupBy(KK))) = GroupBy.value(JJ, KK + 1))
                Next KK
                If W_Flag = True Then
                        W_INDEX = JJ
                        Exit For
               End If
            Next JJ
            If W_INDEX = 0 Then
                GroupBy.Add ""
                W_INDEX = GroupBy.Count
                For KK = 0 To UBound(W_GroupBy)
                    GroupBy.value(W_INDEX, KK + 1) = mData(II).smData(Val(W_GroupBy(KK)))
                Next
            End If
            GroupBy.value(W_INDEX, MaxCol) = Val(GroupBy.value(W_INDEX, MaxCol)) + 1
            For KK = 0 To UBound(W_Select)
                Select Case Split(W_Select(KK), "(")(0)
                    Case "SUM", "AVG"
                        GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy)) = Val(GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy))) + Val(mData(II).smData(Val(Split(W_Select(KK), "(")(1))))
                    Case "LIST"
                        GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy)) = GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy)) & mData(II).smData(Val(Split(W_Select(KK), "(")(1))) & ","
                    Case "COUNT"
                        GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy)) = Val(GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy))) + 1
                End Select
            Next KK
    Next II
    For W_INDEX = 1 To GroupBy.Count
            For KK = 0 To UBound(W_Select)
                Select Case Split(W_Select(KK), "(")(0)
                    Case "AVG"
                        GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy)) = Val(GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy))) / GroupBy.value(W_INDEX, MaxCol)
                    Case "LIST"
                        If Len(GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy))) > 0 Then
                            GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy)) = Left(GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy)), Len(GroupBy.value(W_INDEX, KK + 2 + UBound(W_GroupBy))) - 1)
                        End If
                End Select
            Next KK
    Next W_INDEX
    W_Temp = ""
    For II = 0 To UBound(W_GroupBy)
            W_Temp = W_Temp & II + 1 & ","
    Next II
    If W_Temp <> "" Then
        W_Temp = Left(W_Temp, Len(W_Temp) - 1)
        GroupBy.SortColList W_Temp
    End If
End Function
' add 2007/1/3
Public Property Let Cols(ByVal value As Long)
    mCols = value
End Property
Public Property Get Cols() As Long
    Cols = mCols
End Property


Public Function CrossBy(ByVal RowList As String, ByVal ColList As String, ByVal SumItem As Long) As clsArray
    '產生交叉表
    Dim W_Rows As New clsArray
    Dim W_Cols As New clsArray
    Dim W_RowList As Variant
    Dim W_ColList As Variant
    Dim II As Long
    Dim JJ As Long
    Dim KK As Long
    Dim W_INDEX As Long
    Dim W_Flag As Boolean
    Dim W_RowCount As Integer
    Dim W_ColCount As Integer
    Dim W_Key As String
    Set CrossBy = New clsArray
    
    
    W_RowList = Split(RowList, ",")
    W_ColList = Split(ColList, ",")
    W_RowCount = UBound(W_RowList) + 1
    W_ColCount = UBound(W_ColList) + 1
    If W_RowCount <= 0 Then
        Exit Function
    End If
    If W_ColCount <= 0 Then
        Exit Function
    End If
    For II = 1 To mIndex
            W_Key = ""
            For JJ = 1 To W_RowCount
                    W_Key = W_Key & mData(II).smData(W_RowList(JJ - 1)) & Chr(6)
            Next JJ
            W_Rows.AddKey W_Key
            
            W_Key = ""
            For JJ = 1 To W_ColCount
                    W_Key = W_Key & mData(II).smData(W_ColList(JJ - 1)) & Chr(6)
            Next JJ
            W_Cols.AddKey W_Key
    Next II
    W_Rows.Sort 1
    W_Cols.Sort 1
    For II = 1 To W_ColCount
        CrossBy.Add ""
        W_INDEX = CrossBy.Count
         For JJ = 1 To W_Cols.Count
                CrossBy.value(W_INDEX, JJ + W_RowCount) = Split(W_Cols.value(JJ, 1), Chr(6))(II - 1)
         Next JJ
    Next II
     For II = 1 To W_Rows.Count
        CrossBy.Add ""
        W_INDEX = CrossBy.Count
        For JJ = 1 To W_RowCount
            CrossBy.value(W_INDEX, JJ) = Split(W_Rows.value(II, 1), Chr(6))(JJ - 1)
        Next JJ
     Next II
     For II = 1 To mIndex
            W_Key = ""
            For JJ = 1 To W_RowCount
                    W_Key = W_Key & mData(II).smData(W_RowList(JJ - 1)) & Chr(6)
            Next JJ
            W_INDEX = W_Rows.KeyIndex(W_Key)
            W_Key = ""
            For JJ = 1 To W_ColCount
                    W_Key = W_Key & mData(II).smData(W_ColList(JJ - 1)) & Chr(6)
            Next JJ
            KK = W_Cols.KeyIndex(W_Key)
            CrossBy.value(W_INDEX + W_ColCount, KK + W_RowCount) = Val(CrossBy.value(W_INDEX + W_ColCount, KK + W_RowCount)) + mData(II).smData(SumItem)
    Next II
    CrossBy.Cols = W_Cols.Count
    Set W_Rows = Nothing
    Set W_Cols = Nothing
End Function

Public Function ColIndex(ByVal key1 As Variant, Col As Long) As Long
Dim II As Long
    For II = 1 To mIndex
        If mData(II).smData(Col) = key1 Then
            ColIndex = II
            Exit Function
        End If
   Next II
ColIndex = 0
End Function

Public Function Distinct(Optional ByVal DistinctList As String = "1") As clsArray
    Dim W_GroupBy As Variant
    Dim II As Long
    Dim JJ As Long
    Dim KK As Long
    Dim W_INDEX As Long
    Dim W_Flag As Boolean
    Set Distinct = New clsArray
    W_GroupBy = Split(DistinctList, ",")
    For II = 1 To mIndex
            W_INDEX = 0
            For JJ = 1 To Distinct.Count
                W_Flag = True
                For KK = 0 To UBound(W_GroupBy)
                    W_Flag = W_Flag And (mData(II).smData(Val(W_GroupBy(KK))) = Distinct.value(JJ, KK + 1))
                Next KK
                If W_Flag = True Then
                        W_INDEX = JJ
                        Exit For
               End If
            Next JJ
            If W_INDEX = 0 Then
                Distinct.Add ""
                W_INDEX = Distinct.Count
                For KK = 0 To UBound(W_GroupBy)
                    Distinct.value(W_INDEX, KK + 1) = mData(II).smData(Val(W_GroupBy(KK)))
                Next
            End If
    Next II
    Distinct.Cols = UBound(W_GroupBy) + 1
End Function
Public Function GetWhere(ByVal Col As Integer, ByVal Condiction As Variant, Optional ByVal SelectList As String = "") As clsArray
    Dim W_GroupBy As Variant
    Dim II As Long
    Dim JJ As Long
    Dim KK As Long
    Dim W_INDEX As Long
    Dim W_Flag As Boolean
    Set GetWhere = New clsArray
    W_GroupBy = Split(SelectList, ",")
    For II = 1 To mIndex
            If mData(II).smData(Col) = Condiction Then
                GetWhere.Add ""
                W_INDEX = GetWhere.Count
                If UBound(W_GroupBy) >= 0 Then
                    For KK = 0 To UBound(W_GroupBy)
                        GetWhere.value(W_INDEX, KK + 1) = mData(II).smData(Val(W_GroupBy(KK)))
                    Next
                Else
                    For KK = 1 To 50
                            GetWhere.value(W_INDEX, KK) = mData(II).smData(KK)
                     Next KK
                End If
            End If
    Next II
    If UBound(W_GroupBy) >= 0 Then
        GetWhere.Cols = UBound(W_GroupBy) + 1
    Else
        GetWhere.Cols = mCols
    End If
End Function

Public Function GetWhereIN(ByVal Col As Integer, ByRef Condiction As Variant, Optional ByVal SelectList As String = "") As clsArray
    Dim W_GroupBy As Variant
    Dim II As Long
    Dim JJ As Long
    Dim KK As Long
    Dim W_INDEX As Long
    Dim W_Flag As Boolean
    Set GetWhereIN = New clsArray
    W_GroupBy = Split(SelectList, ",")
    For II = 1 To mIndex
            If IsinArry(mData(II).smData(Col), Condiction) Then
                GetWhereIN.Add ""
                W_INDEX = GetWhereIN.Count
                If UBound(W_GroupBy) >= 0 Then
                    For KK = 0 To UBound(W_GroupBy)
                        GetWhereIN.value(W_INDEX, KK + 1) = mData(II).smData(Val(W_GroupBy(KK)))
                    Next
                Else
                    For KK = 1 To 50
                            GetWhereIN.value(W_INDEX, KK) = mData(II).smData(KK)
                     Next KK
                End If
            End If
    Next II
    If UBound(W_GroupBy) >= 0 Then
        GetWhereIN.Cols = UBound(W_GroupBy) + 1
    Else
        GetWhereIN.Cols = mCols
    End If
End Function

Private Function IsinArry(ByVal data As Variant, Array1 As Variant) As Boolean
    Dim II As Integer
    IsinArry = False
    On Error Resume Next
    For II = LBound(Array1) To UBound(Array1)
            If data = Array1(II) Then
                IsinArry = True
                Exit For
            End If
    Next II
End Function

Private Function ChkIsSame(ByVal Index1 As Long, ByVal index2 As Long, ByVal ColList As String, ByVal StartCol As Integer, ByVal EndCol) As Boolean
    Dim II As Integer
    Dim W_Temp As Variant
    W_Temp = Split(ColList, ",")
    ChkIsSame = True
    For II = StartCol To EndCol
          ChkIsSame = ChkIsSame And (mData(Index1).smData(Val(W_Temp(II))) = mData(index2).smData(Val(W_Temp(II))))
    Next II
End Function


'2008/2/14
Public Function SumColValue(ByVal Colunms As Long) As Double
    Dim II As Long
    SumColValue = 0
    If Colunms < 1 Or Colunms > 50 Then Exit Function
    For II = 1 To mIndex
        SumColValue = SumColValue + mData(II).smData(Colunms)
    Next II
End Function


Public Sub SetObject(ByVal Row As Long, ByRef value As Object)
    Set mData(Row).smData(MaxCol + 1) = value
End Sub

Public Function GetObject(ByVal Row As Long) As Object
    Set GetObject = mData(Row).smData(MaxCol + 1)
End Function
