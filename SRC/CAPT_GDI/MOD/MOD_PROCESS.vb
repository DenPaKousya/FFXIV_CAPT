Imports System.Runtime.InteropServices
Friend Module MOD_PROCESS

#Region "WIN32API"
    <DllImport("user32.dll")> Private Function GetWindowRect(ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Integer
    End Function
    <DllImport("user32.dll")> Private Function GetClientRect(ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Integer
    End Function
#End Region

#Region "モジュール用・定数"
    'Private Const cstDEFAULT_PROCESS_NAME As String = "ffxiv_dx11"
    Private Const cstDEFAULT_PROCESS_NAME As String = "chrome"
    'Private Const cstDEFAULT_PROCESS_NAME As String = "notepad"
#End Region

    Friend Function FUNC_GET_FFXIV_PROCESS(Optional ByVal strFFXIV_PROCESS_NAME As String = cstDEFAULT_PROCESS_NAME) As Process
        Dim p As Process
        For Each p In Process.GetProcesses()
            If (p.MainWindowHandle <> IntPtr.Zero) Then
                If (p.ProcessName = strFFXIV_PROCESS_NAME) Then
                    Return p
                End If
            End If
        Next

        Return Nothing
    End Function

    Public Function FUNC_GET_CRIENT_RECT(ByRef prcCRIENT As Process) As RECT
        Dim srtRET As RECT

        With srtRET
            .left = 0
            .top = 0
            .right = 0
            .bottom = 0
        End With

        If prcCRIENT Is Nothing Then
            Return srtRET
        End If

        Call GetClientRect(prcCRIENT.MainWindowHandle, srtRET)

        Return srtRET
    End Function

    Public Function FUNC_GET_WINDOW_RECT(ByRef prcWINDOW As Process) As RECT
        Dim srtRET As RECT

        With srtRET
            .left = 0
            .top = 0
            .right = 0
            .bottom = 0
        End With

        If prcWINDOW Is Nothing Then
            Return srtRET
        End If

        Call GetWindowRect(prcWINDOW.MainWindowHandle, srtRET)

        Return srtRET
    End Function

    Public Function FUNC_GET_RECT_WIDTH(ByRef srtRECT As RECT) As Integer
        Dim intRET As Integer

        intRET = srtRECT.right - srtRECT.left

        Return intRET
    End Function

    Public Function FUNC_GET_RECT_HEIGHT(ByRef srtRECT As RECT) As Integer
        Dim intRET As Integer

        intRET = srtRECT.bottom - srtRECT.top

        Return intRET
    End Function

End Module
