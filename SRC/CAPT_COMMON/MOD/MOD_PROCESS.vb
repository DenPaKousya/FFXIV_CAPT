Imports System.Runtime.InteropServices

Public Module MOD_PROCESS

#Region "モジュール用・定数"
    Private Const CST_DEFAULT_PROCESS_NAME As String = "ffxiv_dx11"
    'Private Const CST_DEFAULT_PROCESS_NAME As String = "chrome"
    'Private Const CST_DEFAULT_PROCESS_NAME As String = "cmd"
    'Private Const CST_DEFAULT_PROCESS_NAME As String = "Hidemaru"
    'Private Const CST_DEFAULT_PROCESS_NAME As String = "Notepad"
    'Private Const CST_DEFAULT_PROCESS_NAME As String = "Calculator"
    'Private Const CST_DEFAULT_PROCESS_NAME As String = "FlowScape"
#End Region

    Public Function FUNC_GET_FFXIV_PROCESS(Optional ByVal STR_FFXIV_PROCESS_NAME As String = CST_DEFAULT_PROCESS_NAME, Optional ByVal INT_ID As Integer = 0) As Process
        'Dim p As Process
        'For Each p In Process.GetProcesses()
        '    If (p.MainWindowHandle <> IntPtr.Zero) Then
        '        If (p.ProcessName = STR_FFXIV_PROCESS_NAME) Then
        '            Return p
        '        End If
        '    End If
        'Next

        Dim PRC_ARRAY() As Process
        PRC_ARRAY = Process.GetProcessesByName(STR_FFXIV_PROCESS_NAME)

        If PRC_ARRAY Is Nothing Then
            Return Nothing
        End If

        For i = 0 To (PRC_ARRAY.Length - 1)

            Dim BLN_CHECK_ID As Boolean

            If INT_ID = 0 Then
                BLN_CHECK_ID = True
            Else
                BLN_CHECK_ID = (INT_ID = PRC_ARRAY(i).Id)
            End If
            If BLN_CHECK_ID Then
                Return PRC_ARRAY(i)
            End If
        Next

        Return Nothing
    End Function

    Public Function FUNC_GET_PROCESS_ID_ARRAY(Optional ByVal STR_FFXIV_PROCESS_NAME As String = CST_DEFAULT_PROCESS_NAME) As Integer()
        Dim INT_RET() As Integer
        ReDim INT_RET(0)

        Dim PRC_ARRAY() As Process
        PRC_ARRAY = Process.GetProcessesByName(STR_FFXIV_PROCESS_NAME)

        If PRC_ARRAY Is Nothing Then
            Return INT_RET
        End If

        For i = 0 To (PRC_ARRAY.Length - 1)
            Dim INT_INDEX As Integer
            INT_INDEX = INT_RET.Length
            ReDim Preserve INT_RET(INT_INDEX)
            INT_RET(INT_INDEX) = PRC_ARRAY(i).Id
        Next

        Return INT_RET
    End Function
End Module
