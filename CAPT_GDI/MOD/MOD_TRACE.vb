Friend Module MOD_TRACE
    Public Sub SUB_PUT_TRACE(ByVal strTRACE As String)
        Const cstDEBUG As Boolean = True

        If cstDEBUG Then
            Call Trace.WriteLine(strTRACE)
            Exit Sub
        End If

        Exit Sub
        Call SUB_SYSTEM_LOG_PUT_DEBUG(strTRACE)

    End Sub
End Module
