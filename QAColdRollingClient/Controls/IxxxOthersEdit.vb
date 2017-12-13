Public Interface IxxxTitleEdit
    Event CallBackEvent(ByVal Sender As IxxxTitleEdit, ByVal ReturnValue As String)
    Event MessageEvent(ByVal Message As String)
    Function SaveControlDataToDB() As Integer
    Sub InitControlValue()
    Sub SetControlValueToQABugRecordOtherData()
    ReadOnly Property CoilPositionErrLength As Long
    ReadOnly Property IsUpdateFromL2Value As Boolean


    '' Sub getUpDown_Status(ByRef status As String)
    '' Sub refreshRadioBtn_upAndDown()
    '' Sub SetUpDown_Status(ByVal status As String)
End Interface
