Public Class ModTools

#Region "NoNull : 把Null轉成非Null"
    ''' <summary>
    ''' 把Null轉成非Null
    ''' </summary>
    ''' <param name="fromData">傳入資料</param>
    ''' <param name="NullValue">Null替代資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NoNull(ByVal fromData As Object, Optional ByVal NullValue As Object = "") As Object
        If IsDBNull(fromData) Then
            NoNull = NullValue
        Else
            NoNull = fromData
        End If
    End Function

#End Region


#Region "showSpace : 補足Html空白長度"
    ''' <summary>
    ''' 補足Html空白長度
    ''' </summary>
    ''' <param name="fromNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function showSpace(ByVal fromNum As Integer) As String
        Dim retString As String
        Dim W_String As String

        W_String = Space(fromNum)
        retString = W_String.Replace(Space(1), "&nbsp")

        Return retString
    End Function
#End Region

#Region "showInfoForMoney：將字串補逗點"
    Public Shared Function showInfoForMoney(ByVal fromMoney As Long)
        Dim W_ShowMoney As String

        W_ShowMoney = String.Format("{0:N0}", fromMoney)
        Return W_ShowMoney
    End Function
#End Region

#Region "DropDownList：設定值"
    Private Shared C_SpecialChar As String = "："

    Public Shared Sub SelectedIndexByValue(ByVal fromDropDownList As System.Web.UI.WebControls.DropDownList, _
                                                                    ByVal fromValue As String)
        fromDropDownList.SelectedIndex = -1

        For II As Integer = 0 To fromDropDownList.Items.Count - 1
            If fromDropDownList.Items(II).Value.Split(C_SpecialChar)(0) = fromValue Then
                fromDropDownList.SelectedIndex = II
                Exit For
            End If
        Next II
    End Sub

    Public Shared Sub SelectedIndexByText(ByVal fromDropDownList As System.Web.UI.WebControls.DropDownList, _
                                                                 ByVal fromText As String)
        fromDropDownList.SelectedIndex = -1

        For II As Integer = 0 To fromDropDownList.Items.Count - 1
            If fromDropDownList.Items(II).Text.Split(C_SpecialChar)(0) = fromText Then
                fromDropDownList.SelectedIndex = II
                Exit For
            End If
        Next II
    End Sub
#End Region

#Region "RadioButtonList：設定值"

    Public Shared Sub SelectedByText(ByVal fromRadioButtonList As System.Web.UI.WebControls.RadioButtonList, _
                                                        ByVal fromText As String)
        For II As Integer = 0 To fromRadioButtonList.Items.Count - 1
            fromRadioButtonList.Items(II).Selected = (fromRadioButtonList.Items(II).Text.Split(C_SpecialChar)(0) = fromText)
        Next
    End Sub

    Public Shared Sub SelectedByValue(ByVal fromRadioButtonList As System.Web.UI.WebControls.RadioButtonList, _
                                                         ByVal fromText As String)
        For II As Integer = 0 To fromRadioButtonList.Items.Count - 1
            fromRadioButtonList.Items(II).Selected = (fromRadioButtonList.Items(II).Value.Split(C_SpecialChar)(0) = fromText)
        Next
    End Sub

#End Region

#Region  "FS_Number2ChineseString：數字轉國字大寫"
    Public Shared Function FS_Number2ChineseString(ByVal fromNum As Object) As String
        Dim retString As String = ""
        Dim W_Num As String = CStr(fromNum)

        Dim W_CS_Num() As String = Split("零,壹,貳,參,肆,伍,陸,柒,捌,玖", ",")
        Dim W_CS_Uni1() As String = Split(",拾,佰,仟", ",")
        Dim W_CS_Uni2() As String = Split(",萬,億,兆", ",")

        Dim W_CS_Space As String = Space(2)

        Dim W_Index_Uni2 As Integer = 0
        Dim W_Index_Uni1 As Integer

        Dim s As String
        Dim aa As Integer
        Dim j As Integer
        Dim k As Integer

        Do
            aa = 0
            j = CInt(Right(W_Num, 4))
            W_Index_Uni1 = 0
            s = ""

            Do
                k = j Mod 10
                If k > 0 Then
                    aa = 1
                    s = W_CS_Space & W_CS_Num(k) & W_CS_Space & W_CS_Uni1(W_Index_Uni1) & s
                ElseIf k = 0 Then
                    If aa = 1 Then
                        s = "零" & s
                    End If
                End If
                j = j \ 10
                W_Index_Uni1 = W_Index_Uni1 + 1
            Loop Until j = 0
            If (s <> "") Then
                retString = s & W_CS_Uni2(W_Index_Uni2) & retString
            End If
            If Len(W_Num) > 4 Then
                W_Num = Left(W_Num, Len(W_Num) - 4)
            Else
                W_Num = ""
            End If
            W_Index_Uni2 = W_Index_Uni2 + 1
        Loop Until W_Num = ""

        retString &= IIf(retString.Substring(retString.Length - W_CS_Space.Length).Equals(W_CS_Space), "", W_CS_Space)
        retString &= "元整"
        Return retString
    End Function

#End Region
End Class
