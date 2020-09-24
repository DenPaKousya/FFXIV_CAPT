Imports System.ComponentModel

Friend Module MOD_JOYPAD

#Region "モジュール用・定数"
    Const cstNUMBER_BUTTON_MAX As Integer = 16
#End Region

#Region "WIN32API"
    ' ***** constant value *****

    ' joyID number
    Private Const JOYSTICKID1 = 0
    Private Const JOYSTICKID2 = 1

    ' *** dwFlag of JOYINFOEX member
    Private Const JOY_RETURNZ As Long = &H4&
    Private Const JOY_RETURNY As Long = &H2&
    Private Const JOY_RETURNX As Long = &H1&
    Private Const JOY_RETURNV As Long = &H20
    Private Const JOY_RETURNU As Long = &H10
    Private Const JOY_RETURNR As Long = &H8&
    Private Const JOY_RETURNPOV As Long = &H40&
    Private Const JOY_RETURNBUTTONS As Long = &H80&
    Private Const JOY_RETURNALL As Long = (JOY_RETURNX Or JOY_RETURNY Or JOY_RETURNZ Or JOY_RETURNR Or JOY_RETURNU Or JOY_RETURNV Or JOY_RETURNPOV Or JOY_RETURNBUTTONS)

    ' *** Message from Joystick
    Private Const MM_JOY1BUTTONDOWN As Long = &H3B5
    Private Const MM_JOY1BUTTONUP As Long = &H3B7
    Private Const MM_JOY1MOVE As Long = &H3A0
    Private Const MM_JOY1ZMOVE As Long = &H3A2

    ' *** joyStick API MMResult
    Private Const JOYERR_BASE As Long = 160
    Private Const JOYERR_NOCANDO As Long = (JOYERR_BASE + 6)
    Private Const JOYERR_NOERROR As Long = (0)
    Private Const JOYERR_PARMS As Long = (JOYERR_BASE + 5)
    Private Const JOYERR_UNPLUGGED As Long = (JOYERR_BASE + 7)
    Private Const MMSYSERR_BASE As Long = 0
    Private Const MMSYSERR_NODRIVER As Long = (MMSYSERR_BASE + 6)
    Private Const MMSYSERR_INVALPARAM As Long = (MMSYSERR_BASE + 11)
    Private Const MMSYSERR_BADDEVICEID As Long = (MMSYSERR_BASE + 2)


    ' ***** structure definision *****
    Public Structure JOYINFOEX
        Public dwSize As Integer ' size of structure _
        Public dwFlags As Integer ' flags to indicate what to return _
        Public dwXpos As Integer ' x position _
        Public dwYpos As Integer ' y position _
        Public dwZpos As Integer ' z position _
        Public dwRpos As Integer ' rudder/4th axis position _
        Public dwUpos As Integer ' 5th axis position _
        Public dwVpos As Integer ' 6th axis position _
        Public dwButtons As Integer ' button states _
        Public dwButtonNumber As Integer ' current button number pressed _
        Public dwPOV As Integer ' point of view state _
        Public dwReserved1 As Integer ' reserved for communication between winmm driver _
        Public dwReserved2 As Integer ' reserved for future expansion _
    End Structure


    ' ***** Win32 API declair *****
    Public Declare Function joyGetPosEx Lib "winmm.dll" Alias "joyGetPosEx" (ByVal uJoyID As Integer, ByRef pji As JOYINFOEX) As Integer

    Public Declare Function joySetCapture Lib "winmm.dll" _
    Alias "joySetCapture" (ByVal hwnd As System.IntPtr,
                           ByVal uID As Integer,
                           ByVal uPeriod As Integer,
                           ByVal bChanged As Integer) As Integer

    Public Declare Function joyReleaseCapture Lib "winmm.dll" _
    Alias "joyReleaseCapture" (ByVal uJoyID As Integer) As Integer

#End Region

#Region "モジュール用・変数"
    Friend intNUMBER_BUTTON_SCRLK As Integer
    Friend intNUMBER_BUTTON As Integer
    Friend intNUMBER_BUTTON_ONE As Integer
    Friend intNUMBER_BUTTON_VIEW_OVERLAY As Integer
    Friend intNUMBER_BUTTON_VIEW_ROTATE As Integer

    Private FRM_PARENT As FRM_MAIN
#End Region

#Region "引き渡し"
    Public Sub SUB_PARAM_INIT()
        intNUMBER_BUTTON_ONE = srtCAPT_SETTINGS.USE_JOYSTICK_BUTTON_CAPT_ONE
        intNUMBER_BUTTON = srtCAPT_SETTINGS.USE_JOYSTICK_BUTTON_CAPT
        intNUMBER_BUTTON_SCRLK = srtCAPT_SETTINGS.USE_JOYSTICK_BUTTON_SCRLK
        intNUMBER_BUTTON_VIEW_OVERLAY = srtCAPT_SETTINGS.USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION
        intNUMBER_BUTTON_VIEW_ROTATE = srtCAPT_SETTINGS.USE_JOYSTICK_BUTTON_ROTATE
    End Sub
#End Region

#Region "コントローラ関連"
    Private JoyStickInput As JOYINFOEX
    Private Captured As Boolean = False

    Public Sub SUB_GET_JOYSTICK(ByRef objOWNER As Object)
        JoyStickInput.dwSize = System.Runtime.InteropServices.Marshal.SizeOf(JoyStickInput)
        JoyStickInput.dwFlags = JOY_RETURNALL
        Call CaptureJoystick(objOWNER)
        FRM_PARENT = objOWNER
        Call SUB_LOOP_THREAD_START()
    End Sub

    Friend Sub SUB_END_JOYSTICK()
        If Captured Then
            Captured = False
            Call System.Threading.Thread.Sleep(100)
            Call joyReleaseCapture(JOYSTICKID1)
        End If

        If Not trdLOOP_DOEVENTS Is Nothing Then
            Call trdLOOP_DOEVENTS.Abort()
        End If

    End Sub

    ' ***** capture Joysticks *****
    Private Sub CaptureJoystick(ByRef objOWNER As Object)

        Dim Result As Integer

        If Captured Then
            'MsgBox("すでにジョイスティックの接続を確保しています")
        Else
            Dim hndTEMP As IntPtr
            hndTEMP = objOWNER.Handle
            Result = joySetCapture(CInt(hndTEMP), JOYSTICKID1, 50, False)
            If Result > 0 Then
                'MsgBox("エラーだそうです。" + CStr(Result))
            Else
                Captured = True
                'MsgBox("ジョイスティックの接続を確保しました")
            End If
        End If

    End Sub

    Public Function FUNC_GET_JOYPOS(ByRef intBUTTONS As Integer) As Boolean
        Dim intRESULT As Integer
        intRESULT = joyGetPosEx(JOYSTICKID1, JoyStickInput)

        Select Case intRESULT
            Case MMSYSERR_NODRIVER
                Return False
            Case MMSYSERR_INVALPARAM
                Return False
            Case MMSYSERR_BADDEVICEID
                Return False
            Case JOYERR_UNPLUGGED
                Return False
            Case JOYERR_PARMS
                Return False
            Case Else

        End Select

        intBUTTONS = JoyStickInput.dwButtons
        Return True
    End Function

    Private Function FUNC_GET_BUTTON_ROW(ByVal intHEX_BUTTON As Integer) As Boolean()
        Dim blnRET(cstNUMBER_BUTTON_MAX) As Boolean
        Dim intLOOP_INDEX As Integer
        Dim intCHECK As Integer
        Dim intCALC As Integer

        For intLOOP_INDEX = 0 To ((blnRET.Length - 1) - 1)
            intCHECK = 2 ^ intLOOP_INDEX
            intCALC = intHEX_BUTTON And intCHECK
            blnRET(intLOOP_INDEX + 1) = (intCALC <> 0)
        Next

        Return blnRET
    End Function

#End Region

#Region "実行処理群"

    Private Enum ENM_MY_EXEC_DO
        DO_START = 1
        DO_START_ONE
        DO_VIEW_OVERLAY
        DO_VIEW_ROTATE
        DO_STOP
    End Enum
    Private blnPROCESS_DOING As Boolean = False
    Private Sub SUB_EXEC_DO(
    ByVal enmEXEC_DO As ENM_MY_EXEC_DO
    )
        If blnPROCESS_DOING Then
            Exit Sub
        End If

        blnPROCESS_DOING = True

        Select Case enmEXEC_DO
            Case ENM_MY_EXEC_DO.DO_START
                Call SUB_START()
            Case ENM_MY_EXEC_DO.DO_START_ONE
                Call SUB_START_ONE()
            Case ENM_MY_EXEC_DO.DO_VIEW_OVERLAY
                Call SUB_VIEW_OVERLAY()
            Case ENM_MY_EXEC_DO.DO_VIEW_ROTATE
                Call SUB_VIEW_ROTATE()
            Case ENM_MY_EXEC_DO.DO_STOP
                Call SUB_STOP()
        End Select

        blnPROCESS_DOING = False
    End Sub

    Private Sub SUB_START_ONE()
        If FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_ONE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf FRM_PARENT.SUB_EXEC_DO), myArray)
        Call FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub SUB_START()
        If FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_CON
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf FRM_PARENT.SUB_EXEC_DO), myArray)
        Call FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub SUB_STOP()
        Call SUB_END_CAPTURE()
    End Sub

    Private Sub SUB_VIEW_OVERLAY()
        If FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.VIEW_OVERLAY
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf FRM_PARENT.SUB_EXEC_DO), myArray)
        Call FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub SUB_VIEW_ROTATE()
        If FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.VIEW_ROTATE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf FRM_PARENT.SUB_EXEC_DO), myArray)
        Call FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub
#End Region

#Region "スレッド"

    Private trdLOOP_DOEVENTS As Threading.Thread
    Private blnBUTTON_DOWN As Boolean
    Private Sub SUB_LOOP_THREAD_START()
        If Not trdLOOP_DOEVENTS Is Nothing Then
            trdLOOP_DOEVENTS.Abort()
        End If

        blnBUTTON_DOWN = False
        trdLOOP_DOEVENTS = Nothing
        trdLOOP_DOEVENTS = New Threading.Thread(New Threading.ThreadStart(AddressOf SUB_DOEVENTS_LOOP))
        trdLOOP_DOEVENTS.IsBackground = True
        trdLOOP_DOEVENTS.Start()
    End Sub

    Private Sub SUB_DOEVENTS_LOOP()
        Dim stwTHREAD As Stopwatch
        Dim intMSEC_THREAD As Integer
        Dim intMSEC_THREAD_SUB As Integer
        Const cstMSEC_INTERVAL_THREAD As Integer = 50

        Dim sw As System.Diagnostics.Stopwatch
        Dim intElapsed As Integer
        Dim intCHECK_TIME As Integer
        Dim blnCHECK_TIME As Boolean
        Dim intBUTTONS As Integer
        Dim blnBUTTONS_ROW(cstNUMBER_BUTTON_MAX) As Boolean

        intCHECK_TIME = 500
        blnCHECK_TIME = True

        sw = New System.Diagnostics.Stopwatch
        Call sw.Start()

        stwTHREAD = New System.Diagnostics.Stopwatch
        Call stwTHREAD.Start()
        Call stwTHREAD.Stop()
        Do
            Call stwTHREAD.Restart()

            If Not Captured Then
                Exit Do
            End If

            If Not FUNC_GET_JOYPOS(intBUTTONS) Then
                Exit Do
            End If

            blnBUTTONS_ROW = FUNC_GET_BUTTON_ROW(intBUTTONS)
            If intBUTTONS = 0 Then
                blnBUTTON_DOWN = False
            End If

            If Not blnBUTTON_DOWN And intBUTTONS <> 0 Then
                blnBUTTON_DOWN = True

                Call sw.Stop()
                intElapsed = sw.ElapsedMilliseconds
                If blnCHECK_TIME = False And (intElapsed > intCHECK_TIME) Then
                    blnCHECK_TIME = True
                    Call sw.Restart()
                Else
                    Call sw.Start()
                End If

                If blnCHECK_TIME Then
                    Dim intLOOP_INDEX As Integer
                    blnCHECK_TIME = False

                    For intLOOP_INDEX = 1 To (blnBUTTONS_ROW.Length - 1)
                        If Not blnBUTTONS_ROW(intLOOP_INDEX) Then
                            Continue For
                        End If

                        Select Case intLOOP_INDEX
                            Case intNUMBER_BUTTON_SCRLK
                                Call MOD_SEND_KEYS.SUB_SEND_KEYS_SCROLL(prcTARGET)
                            Case intNUMBER_BUTTON_ONE '撮影指示
                                If blnMOD_CAPTURE_DO Then
                                    Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_STOP)
                                Else
                                    Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_START_ONE)
                                End If
                            Case intNUMBER_BUTTON '撮影指示
                                If blnMOD_CAPTURE_DO Then
                                    Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_STOP)
                                Else
                                    Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_START)
                                End If
                            Case intNUMBER_BUTTON_VIEW_OVERLAY
                                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_VIEW_OVERLAY)
                            Case intNUMBER_BUTTON_VIEW_ROTATE
                                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_VIEW_ROTATE)
                            Case Else

                        End Select
                    Next
                End If
            End If

            Call stwTHREAD.Stop()
            intMSEC_THREAD = stwTHREAD.ElapsedMilliseconds
            intMSEC_THREAD_SUB = (cstMSEC_INTERVAL_THREAD - intMSEC_THREAD)
            If intMSEC_THREAD_SUB > 0 Then
                Try
                    Call System.Threading.Thread.Sleep(intMSEC_THREAD_SUB)
                Catch ex As Exception
                    'スルー
                End Try
            End If
        Loop

    End Sub
#End Region

End Module
