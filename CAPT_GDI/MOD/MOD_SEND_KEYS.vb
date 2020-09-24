Module MOD_SEND_KEYS

#Region "WINAPI"
    Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hWnd As System.IntPtr, ByVal MSG As Integer, ByVal wParam As System.IntPtr, ByVal lParam As System.IntPtr) As System.IntPtr
#End Region

#Region "定数"
    Private Const CST_WAIT_ONE As Integer = 50
#End Region

#Region "列挙定数"
    Private Enum ENM_SEND_MSG
        WM_SETTEXT = &HC
        BM_CLICK = &HF5
        WM_KEYDOWN = &H100
        WM_KEYUP = &H101
        WM_COMMAND = &H111
        WM_IME_CHAR = &H286
    End Enum

    Private Enum ENM_SEND_VK
        VK_RETURN = &HD
        VK_SHIFT = &H10

        VK_PRIOR = &H21
        VK_NEXT = &H22
        VK_END = &H23
        VK_HOME = &H24
        VK_LEFT = &H25
        VK_UP = &H26
        VK_RIGHT = &H27
        VK_DOWN = &H28

        VK_0 = &H30
        VK_1 = &H31
        VK_2 = &H32
        VK_3 = &H33
        VK_4 = &H34
        VK_5 = &H35
        VK_6 = &H36
        VK_7 = &H37
        VK_8 = &H38
        VK_9 = &H39

        VK_A = &H41
        VK_B = &H42
        VK_C = &H43
        VK_D = &H44
        VK_E = &H45
        VK_F = &H46
        VK_G = &H47
        VK_H = &H48
        VK_I = &H49
        VK_J = &H4A
        VK_K = &H4B
        VK_L = &H4C
        VK_M = &H4D
        VK_N = &H4E
        VK_O = &H4F
        VK_P = &H50
        VK_Q = &H51
        VK_R = &H52
        VK_S = &H53
        VK_T = &H54
        VK_U = &H55
        VK_V = &H56
        VK_W = &H57
        VK_X = &H58
        VK_Y = &H59
        VK_Z = &H5A

        VK_SCROLL = &H91
    End Enum

#End Region

    Public Function FUNC_SEND_KEYS_STRING(ByRef prcTARGET As Process, ByVal strMSG As String) As Boolean
        Dim chrONE As Char
        Dim enmVK As ENM_SEND_VK
        Dim intLOOP_INDEX As Integer

        For intLOOP_INDEX = 1 To strMSG.Length
            chrONE = strMSG.Substring(intLOOP_INDEX - 1, 1)
            enmVK = FUNC_CNV_CHAR_TO_VK(chrONE)
            Call FUNC_SEND_KEYS(prcTARGET, enmVK,, True)
        Next

        Return True
    End Function

    Public Sub SUB_SEND_KEYS_PGUP(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_PRIOR, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_PGDN(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_NEXT, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_END(ByRef prcTARGET As Process)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_END)
    End Sub

    Public Sub SUB_SEND_KEYS_LEFT(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_LEFT, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_UP(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_UP, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_RIGHT(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_RIGHT, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_DOWN(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_DOWN, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_W(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_W, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_A(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_A, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_S(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_S, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_D(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_D, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_X(ByRef prcTARGET As Process, ByVal intWAIT As Integer)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_X, intWAIT)
    End Sub

    Public Sub SUB_SEND_KEYS_SCROLL(ByRef prcTARGET As Process)
        Call FUNC_SEND_KEYS(prcTARGET, ENM_SEND_VK.VK_SCROLL)
    End Sub

#Region "内部処理"
    Private Function FUNC_CNV_CHAR_TO_VK(ByVal chrBASE As Char) As ENM_SEND_VK
        Dim enmRET As ENM_SEND_VK

        enmRET = &H0

        Select Case chrBASE
            Case "0"
                enmRET = ENM_SEND_VK.VK_0
            Case "1"
                enmRET = ENM_SEND_VK.VK_1
            Case "2"
                enmRET = ENM_SEND_VK.VK_2
            Case "3"
                enmRET = ENM_SEND_VK.VK_3
            Case "4"
                enmRET = ENM_SEND_VK.VK_4
            Case "5"
                enmRET = ENM_SEND_VK.VK_5
            Case "6"
                enmRET = ENM_SEND_VK.VK_6
            Case "7"
                enmRET = ENM_SEND_VK.VK_7
            Case "8"
                enmRET = ENM_SEND_VK.VK_8
            Case "9"
                enmRET = ENM_SEND_VK.VK_9
            Case "9"
                enmRET = ENM_SEND_VK.VK_9
            Case "A"
                enmRET = ENM_SEND_VK.VK_A
            Case "B"
                enmRET = ENM_SEND_VK.VK_B
            Case "C"
                enmRET = ENM_SEND_VK.VK_C
            Case "D"
                enmRET = ENM_SEND_VK.VK_D
            Case "E"
                enmRET = ENM_SEND_VK.VK_E
            Case "F"
                enmRET = ENM_SEND_VK.VK_F
            Case "G"
                enmRET = ENM_SEND_VK.VK_G
            Case "H"
                enmRET = ENM_SEND_VK.VK_H
            Case "I"
                enmRET = ENM_SEND_VK.VK_I
            Case "J"
                enmRET = ENM_SEND_VK.VK_J
            Case "K"
                enmRET = ENM_SEND_VK.VK_K
            Case "L"
                enmRET = ENM_SEND_VK.VK_L
            Case "M"
                enmRET = ENM_SEND_VK.VK_M
            Case "N"
                enmRET = ENM_SEND_VK.VK_N
            Case "O"
                enmRET = ENM_SEND_VK.VK_O
            Case "P"
                enmRET = ENM_SEND_VK.VK_P
            Case "Q"
                enmRET = ENM_SEND_VK.VK_Q
            Case "R"
                enmRET = ENM_SEND_VK.VK_R
            Case "S"
                enmRET = ENM_SEND_VK.VK_S
            Case "T"
                enmRET = ENM_SEND_VK.VK_T
            Case "U"
                enmRET = ENM_SEND_VK.VK_U
            Case "V"
                enmRET = ENM_SEND_VK.VK_V
            Case "W"
                enmRET = ENM_SEND_VK.VK_W
            Case "X"
                enmRET = ENM_SEND_VK.VK_X
            Case "Y"
                enmRET = ENM_SEND_VK.VK_Y
            Case "Z"
                enmRET = ENM_SEND_VK.VK_Z
            Case Else

        End Select

        Return enmRET
    End Function

    Private Function FUNC_SEND_KEYS(ByRef prcTARGET As Process, ByVal enmVK As ENM_SEND_VK, Optional ByVal intWAIT_MSEC As Integer = CST_WAIT_ONE, Optional ByVal blnIME As Boolean = False) As Boolean
        Dim ptrHANDLE As IntPtr
        Dim ptrCHILD As Integer

        If intWAIT_MSEC <= 0 Then
            Return True
        End If

        ptrCHILD = 0
        'ptrCHILD = FUNC_FIND_WINDOW_EX(prcTARGET.MainWindowHandle, 0, "Edit", "")

        If ptrCHILD > 0 Then
            ptrHANDLE = ptrCHILD
        Else
            ptrHANDLE = prcTARGET.MainWindowHandle
        End If

        If blnIME Then
            Call SendMessage(ptrHANDLE, ENM_SEND_MSG.WM_IME_CHAR, enmVK, 0)
        Else
            Call SendMessage(ptrHANDLE, ENM_SEND_MSG.WM_KEYDOWN, enmVK, 0)
        End If

        Call System.Threading.Thread.Sleep(intWAIT_MSEC)

        If Not blnIME Then
            Call SendMessage(ptrHANDLE, ENM_SEND_MSG.WM_KEYUP, enmVK, 0)
        End If

        Return True
    End Function
#End Region

End Module
