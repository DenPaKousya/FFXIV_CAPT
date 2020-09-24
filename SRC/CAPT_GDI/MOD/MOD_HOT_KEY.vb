Imports System.Runtime.InteropServices
Module MOD_HOT_KEY

#Region "モジュール用・定数"
    Const cstMASK_KEYS_MAX As Integer = 3
    Const cstHOT_KEYS_MAX As Integer = 12
#End Region

#Region "モジュール用・変数"
    Private frmPARENT As FRM_MAIN

    Dim intID_HOT_KEY(cstHOT_KEYS_MAX) As Integer 'ホットキーのID
    Dim srtPATAM_HOT_KEY(cstHOT_KEYS_MAX) As IntPtr 'WndProc()メソッドでホットキーを識別するためのlParam値
    Dim intID_HOT_KEY_CPAT_ONE(cstHOT_KEYS_MAX) As Integer 'ホットキーのID
    Dim srtPATAM_HOT_KEY_CAPT_ONE(cstHOT_KEYS_MAX) As IntPtr 'WndProc()メソッドでホットキーを識別するためのlParam値
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
        Dim intLOOP_INDEX As Integer
        Dim intKEY As Integer
        Dim intMOD As Integer

        For intLOOP_INDEX = 1 To cstHOT_KEYS_MAX
            Dim intHOT_KEY_INDEX As Integer
            intHOT_KEY_INDEX = intLOOP_INDEX

            If Not FUNC_CHECK_SET_KEY(intHOT_KEY_INDEX) Then
                Continue For
            End If

            intKEY = FUNC_GET_KEYS(intHOT_KEY_INDEX)
            If intKEY = Keys.F12 Then
                intMOD = KeyModifiers.Alt
            Else
                intMOD = KeyModifiers.None
            End If
            Call FUNC_REGISTER_HOT_KEY(frmPARENT.Handle, intID_HOT_KEY(intLOOP_INDEX), srtPATAM_HOT_KEY(intLOOP_INDEX), intMOD, intKEY)
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

    Private Function FUNC_CHECK_SET_KEY(ByVal intKEY_INDEX As Integer)
        Select Case intKEY_INDEX
            Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT
                Return True
            Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT_ONE
                Return True
            Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CHANGE_COMPOSITION
                Return True
            Case srtCAPT_SETTINGS.HOT_KEY_INDEX_ROTATE
                Return True
            Case Else
                Return False
        End Select
    End Function

    Friend Function FUNC_CHECK_HOT_KEY(ByVal ptrINDEX As IntPtr) As Integer
        Dim intLOOP_INDEX As Integer

        For intLOOP_INDEX = 1 To cstHOT_KEYS_MAX
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
End Module
