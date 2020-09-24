Module MOD_MAIN

    Sub Main(ByVal STR_COMMAND_LINE() As String)

        PRC_TARGET = FUNC_GET_FFXIV_PROCESS()

        If PRC_TARGET Is Nothing Then
            Exit Sub
        End If

        Dim STR_COMMAND As String
        STR_COMMAND = FUNC_GET_FFXIV_COMMAND(STR_COMMAND_LINE)

        If STR_COMMAND = "" Then
            Exit Sub
        End If

        Call SUB_FOREGROUND_WINDOW(PRC_TARGET)

        Call SUB_SEND_KEYS_RETURN(PRC_TARGET)

        Call FUNC_SEND_KEYS_STRING_02(PRC_TARGET, STR_COMMAND)

        Call SUB_SEND_KEYS_RETURN(PRC_TARGET)

    End Sub

    Private Function FUNC_GET_FFXIV_COMMAND(ByRef STR_CL() As String) As String

        If STR_CL Is Nothing Then
            Return ""
        End If

        Dim STR_RET As String
        STR_RET = ""
        For i = 0 To STR_CL.Length - 1
            If i > 0 Then
                STR_RET &= " "
            End If
            STR_RET &= STR_CL(i)
        Next

        Return STR_RET
    End Function
End Module
