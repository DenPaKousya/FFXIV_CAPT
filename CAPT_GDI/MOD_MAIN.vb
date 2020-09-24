Module MOD_MAIN

#Region "モジュール用・変数"
    Private frmMAIN As FRM_MAIN
    Private TIM_PRIVATE_TIMER As System.Timers.Timer
#End Region

    Public Sub Main()

        If Not FUNC_INIT() Then
            Exit Sub
        End If

        frmMAIN = New FRM_MAIN
        'frmMAIN.CheckForIllegalCrossThreadCalls = False
        Call MOD_JOYPAD.SUB_GET_JOYSTICK(frmMAIN)
        Call MOD_JOYPAD.SUB_PARAM_INIT()
        Call SUB_GET_PROCESS()
        Call SUB_START_TIMER()

        Call Application.Run()
    End Sub

    Public Sub SUB_MAIN_END()
        Call SUB_STOP_TIMER()
        Call MOD_ROTATE.SUB_CLOSE_ROTATE_WPF()
        Call MOD_OVERLAY.SUB_CLOSE_OVERLAY_WPF()
        Call MOD_JOYPAD.SUB_END_JOYSTICK()

        Call FUNC_FINALIZE()

        Call frmMAIN.Close()

        Call Application.Exit()
    End Sub

#Region "タイマー開始・終了"
    Private Sub SUB_START_TIMER()

        TIM_PRIVATE_TIMER = New System.Timers.Timer
        TIM_PRIVATE_TIMER.Interval = 5000
        TIM_PRIVATE_TIMER.AutoReset = True

        AddHandler TIM_PRIVATE_TIMER.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf SUB_TIMER)
        Call TIM_PRIVATE_TIMER.Start()
    End Sub

    Private Sub SUB_STOP_TIMER()
        Call TIM_PRIVATE_TIMER.Stop()
    End Sub

#End Region

#Region "タイマー実行"
    Private Sub SUB_TIMER(sender As Object, e As System.Timers.ElapsedEventArgs)
        Call SUB_GET_PROCESS()
    End Sub
#End Region

#Region "プロセス検知・確認"
    Private Sub SUB_GET_PROCESS()

        prcTARGET = FUNC_GET_FFXIV_PROCESS()

        If prcTARGET Is Nothing Then 'プロセスが無い場合は
            Exit Sub '処理を無効にして終了
        End If

    End Sub

#End Region

End Module
