Imports System.Runtime.InteropServices
Module MOD_HOT_KEY

#Region "モジュール用・定数"
#End Region

#Region "モジュール用・列挙定数"
    Friend Enum ENM_HOT_KEYS_EVENT
        CAPT = 1
        CAPT_ONE
        CAPT_ONE_SNS
        CHANGE_COMPOSITION
        ROTATE
        MAX = ROTATE
    End Enum
#End Region

#Region "モジュール用・変数"
    Private frmPARENT As FRM_MAIN

    Private intID_HOT_KEY(ENM_HOT_KEYS_EVENT.MAX) As Integer 'ホットキーのID
    Private srtPATAM_HOT_KEY(ENM_HOT_KEYS_EVENT.MAX) As IntPtr 'WndProc()メソッドでホットキーを識別するためのlParam値
#End Region

#Region "WINAPI"
    <DllImport("user32", EntryPoint:="RegisterHotKey")> Private Function RegisterHotKey(ByVal hWnd As IntPtr, ByVal id As Integer, ByVal fsModifier As Integer, ByVal vk As Integer) As Integer
    End Function

    <DllImport("user32", EntryPoint:="UnregisterHotKey")> Private Function UnregisterHotKey(ByVal hWnd As IntPtr, ByVal id As Integer) As Integer
    End Function

    'ホットキーの修飾キー
    Private Const MOD_ALT As Byte = &H1
    Private Const MOD_CONTROL As Byte = &H2
    Private Const MOD_SHIFT As Byte = &H4

    <Flags()>
    Private Enum KeyModifiers As Integer
        None = 0
        Alt = MOD_ALT
        Control = MOD_CONTROL
        Shift = MOD_SHIFT
    End Enum
#End Region

    Friend Sub SUB_INIT_HOTKEY(ByRef frmBASE As Form)
        frmPARENT = frmBASE
    End Sub

    Friend Sub SUB_REG_HOTKEY()

        For intLOOP_INDEX = 1 To ENM_HOT_KEYS_EVENT.MAX
            Dim intHOT_KEY_CODE_BASE As Integer
            Dim intMOD_BASE As Integer

            Select Case intLOOP_INDEX
                Case ENM_HOT_KEYS_EVENT.CAPT
                    intHOT_KEY_CODE_BASE = srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT
                    intMOD_BASE = srtCAPT_SETTINGS.HOT_MASK_INDEX_CAPT
                Case ENM_HOT_KEYS_EVENT.CAPT_ONE
                    intHOT_KEY_CODE_BASE = srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT_ONE
                    intMOD_BASE = srtCAPT_SETTINGS.HOT_MASK_INDEX_CAPT_ONE
                Case ENM_HOT_KEYS_EVENT.CAPT_ONE_SNS
                    intHOT_KEY_CODE_BASE = srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT_ONE_SNS
                    intMOD_BASE = srtCAPT_SETTINGS.HOT_MASK_INDEX_CAPT_ONE_SNS
                Case ENM_HOT_KEYS_EVENT.CHANGE_COMPOSITION
                    intHOT_KEY_CODE_BASE = srtCAPT_SETTINGS.HOT_KEY_INDEX_CHANGE_COMPOSITION
                    intMOD_BASE = srtCAPT_SETTINGS.HOT_MASK_INDEX_CHANGE_COMPOSITION
                Case ENM_HOT_KEYS_EVENT.ROTATE
                    intHOT_KEY_CODE_BASE = srtCAPT_SETTINGS.HOT_KEY_INDEX_ROTATE
                    intMOD_BASE = srtCAPT_SETTINGS.HOT_MASK_INDEX_ROTATE
                Case Else
                    Continue For
            End Select

            Dim intHOT_KEY_CODE As Integer
            intHOT_KEY_CODE = FUNC_GET_KEYS(intHOT_KEY_CODE_BASE)
            Dim intMOD As Integer
            intMOD = FUNC_GET_MOD(intMOD_BASE)
            Call FUNC_REGISTER_HOT_KEY(frmPARENT.Handle, intID_HOT_KEY(intLOOP_INDEX), srtPATAM_HOT_KEY(intLOOP_INDEX), intMOD, intHOT_KEY_CODE)
        Next

    End Sub

    ' ホットキーの設定を行う
    Private Function FUNC_REGISTER_HOT_KEY(ByVal hWnd As IntPtr, ByRef id As Integer, ByRef lParam As IntPtr, ByVal modifier As KeyModifiers, ByVal key As Keys) As Boolean
        Dim intPARAM As Integer
        Dim intRET As Integer
        Dim intMOD As Integer
        Dim intKEY As Integer

        intMOD = CInt(modifier)
        intKEY = CInt(key)

        id = (intMOD * &H100) Or intKEY

        intPARAM = intMOD Or intKEY * &H10000
        lParam = New IntPtr(intPARAM)

        intRET = RegisterHotKey(hWnd, id, CInt(modifier), CInt(key))

        Return (intRET <> 0)

    End Function

    Friend Sub SUB_UNREG_HOTKEY()

        If intID_HOT_KEY Is Nothing Then
            Exit Sub
        End If

        For intLOOP_INDEX = 1 To (intID_HOT_KEY.Length - 1)
            Call UnregisterHotKey(frmPARENT.Handle, intID_HOT_KEY(intLOOP_INDEX))
        Next

    End Sub

    'Private Function FUNC_CHECK_SET_KEY(ByVal intKEY_INDEX As Integer)
    '    Select Case intKEY_INDEX
    '        Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT
    '            Return True
    '        Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT_ONE
    '            Return True
    '        Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CHANGE_COMPOSITION
    '            Return True
    '        Case srtCAPT_SETTINGS.HOT_KEY_INDEX_ROTATE
    '            Return True
    '        Case Else
    '            Return False
    '    End Select
    'End Function

    Friend Function FUNC_CHECK_HOT_KEY(ByVal ptrINDEX As IntPtr) As Integer
        Dim intLOOP_INDEX As Integer

        For intLOOP_INDEX = 1 To ENM_HOT_KEYS_EVENT.MAX
            If ptrINDEX.Equals(srtPATAM_HOT_KEY(intLOOP_INDEX)) Then
                Return intLOOP_INDEX
            End If
        Next

        Return -1
    End Function

    Private Function FUNC_GET_KEYS(ByVal intHOT_KEY_INDEX As Integer) As System.Windows.Forms.Keys
        Dim keyRET As System.Windows.Forms.Keys

        Select Case intHOT_KEY_INDEX
            Case 0
                keyRET = Keys.None
            Case 1
                keyRET = Keys.F1
            Case 2
                keyRET = Keys.F2
            Case 3
                keyRET = Keys.F3
            Case 4
                keyRET = Keys.F4
            Case 5
                keyRET = Keys.F5
            Case 6
                keyRET = Keys.F6
            Case 7
                keyRET = Keys.F7
            Case 8
                keyRET = Keys.F8
            Case 9
                keyRET = Keys.F9
            Case 10
                keyRET = Keys.F10
            Case 11
                keyRET = Keys.F11
            Case 12
                keyRET = Keys.F12
            Case Else
                keyRET = Keys.None
        End Select

        Return keyRET
    End Function

    Private Function FUNC_GET_MOD(ByVal intHOT_MOD_INDEX As Integer) As KeyModifiers
        Dim ret As KeyModifiers

        Select Case intHOT_MOD_INDEX
            Case 0
                ret = Keys.None
            Case 1
                ret = KeyModifiers.Alt
            Case 2
                ret = KeyModifiers.Control
            Case 3
                ret = KeyModifiers.Shift
            Case Else
                ret = KeyModifiers.None
        End Select

        Return ret
    End Function
End Module
