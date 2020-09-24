Imports System.Runtime.InteropServices

Public Delegate Sub FRM_MAIN_DELEGATE()
Friend Delegate Sub FRM_MAIN_DELEGATE_DO_EXEC(ByVal enmEXEC_DO As FRM_MAIN.ENM_MY_EXEC_DO)

Public Class FRM_MAIN

#Region "プロパティ用変数"
    Private ENM_PROPERTY_FLIP_ROTATE_TYPE As RotateFlipType = RotateFlipType.RotateNoneFlipNone
    Private BLN_PROPERTY_FORCE_JPEG As Boolean = False
#End Region

#Region "プロパティ"
    Public Property FLIP_ROTATE_TYPE As RotateFlipType
        Get
            Return ENM_PROPERTY_FLIP_ROTATE_TYPE
        End Get
        Set(ByVal value As RotateFlipType)
            ENM_PROPERTY_FLIP_ROTATE_TYPE = value
        End Set
    End Property

    Public Property FORCE_JPEG As Boolean
        Get
            Return BLN_PROPERTY_FORCE_JPEG
        End Get
        Set(ByVal value As Boolean)
            BLN_PROPERTY_FORCE_JPEG = value
        End Set
    End Property
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Me.Icon = My.Resources.CAPT
        Me.NTI_TASK.Icon = Me.Icon
        Call SUB_INIT_HOTKEY(Me)
        Call SUB_REG_HOTKEY()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()

    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub SUB_CTRL_VIEW_FIN()
        Call SUB_UNREG_HOTKEY()
    End Sub

    Private Sub SUB_CTRL_DISPOSED_FIN() '画面破棄時の追記処理(Dispose時)
    End Sub
#End Region

#Region "実行処理群"
    Private Sub SUB_CAPTURE_ONE()

        Dim srtPARAM_CAPT As SRT_PARAMETER_CAPT
        With srtPARAM_CAPT

            .PATH_SAVE = srtCAPT_SETTINGS.PATH_SAVE
            .PATH_SAVE_FOLDER_NAME = srtCAPT_SETTINGS.PATH_SAVE_FOLDER_NAME
            .PATH_SAVE_FILE_NAME = srtCAPT_SETTINGS.PATH_SAVE_FILE_NAME
            .IMAGE_FORMAT = srtCAPT_SETTINGS.IMAGE_FORMAT
            .ADD_COPYRIGHT = srtCAPT_SETTINGS.ADD_COPYRIGHT
            .IMAGE_INDEX_INIT = srtCAPT_SETTINGS.IMAGE_INDEX

            .SOUND_CAPTURE = srtCAPT_SETTINGS.SOUND_CAPTURE
            .COUNT_CAPTURE = 1
            .TIMER_CAPTURE = 0
            .INTERVAL_CAPTURE = 0

            .ROTATE_FLIP_TYPE = Me.FLIP_ROTATE_TYPE
            .FORCE_JPEG = Me.FORCE_JPEG
            If .FORCE_JPEG Then
                .ADD_COPYRIGHT = True
            End If
            .ENABLED_SEND_KEY = False
            .INDEX_SEND_KEY = 0
        End With

        Call SUB_INIT_CAPTURE(Me, srtPARAM_CAPT)

        srtCAPT_SETTINGS.IMAGE_INDEX += srtPARAM_CAPT.COUNT_CAPTURE

        'キャプチャ指示後に初期化する
        Me.FLIP_ROTATE_TYPE = RotateFlipType.RotateNoneFlipNone
        Me.FORCE_JPEG = False
    End Sub

    Private Sub SUB_CAPTURE()
        If blnMOD_CAPTURE_DO And bnlMOD_CAPTURE_NEED_CANCEL Then
            Call SUB_END_CAPTURE()
        End If

        Dim srtPARAM_CAPT As SRT_PARAMETER_CAPT
        With srtPARAM_CAPT

            .PATH_SAVE = srtCAPT_SETTINGS.PATH_SAVE
            .PATH_SAVE_FOLDER_NAME = srtCAPT_SETTINGS.PATH_SAVE_FOLDER_NAME
            .PATH_SAVE_FILE_NAME = srtCAPT_SETTINGS.PATH_SAVE_FILE_NAME
            .IMAGE_FORMAT = srtCAPT_SETTINGS.IMAGE_FORMAT
            .ADD_COPYRIGHT = srtCAPT_SETTINGS.ADD_COPYRIGHT
            .IMAGE_INDEX_INIT = srtCAPT_SETTINGS.IMAGE_INDEX

            .SOUND_CAPTURE = srtCAPT_SETTINGS.SOUND_CAPTURE
            .COUNT_CAPTURE = srtCAPT_SETTINGS.COUNT_CAPTURE
            .TIMER_CAPTURE = srtCAPT_SETTINGS.TIMER_CAPTURE
            .INTERVAL_CAPTURE = srtCAPT_SETTINGS.INTERVAL_CAPTURE

            .ROTATE_FLIP_TYPE = RotateFlipType.RotateNoneFlipNone

            .ENABLED_SEND_KEY = Not (srtCAPT_SETTINGS.SEND_KEY_INDEX = ENM_SEND_KEY_INDEX.NONE)
            .INDEX_SEND_KEY = srtCAPT_SETTINGS.SEND_KEY_INDEX
            .INTERVAL_SEND_KEY = srtCAPT_SETTINGS.INTERVAL_SEND_KEY
        End With

        Call SUB_INIT_CAPTURE(Me, srtPARAM_CAPT)

        srtCAPT_SETTINGS.IMAGE_INDEX += srtPARAM_CAPT.COUNT_CAPTURE

    End Sub

    Private Sub SUB_END()
        NTI_TASK.Visible = False
        Call SUB_MAIN_END()
    End Sub

    Private Sub SUB_VIEW_SETTING()
        Call SUB_CALL_SETTING(Me)
    End Sub

    Private Sub SUB_VIEW_OVERLAY()
        Call SUB_CALL_OVERLAY(Me)
    End Sub

    Private Sub SUB_VIEW_ROTATE()
        Call SUB_CALL_ROTATE(Me)
    End Sub

    Private Sub SUB_REFRESH_OVERLAY()
        Call MOD_OVERLAY.SUB_REFRESH_OVERLAY_WPF()
    End Sub

    Private Sub SUB_REFRESH_OVERLAY_STATE()
        Call MOD_OVERLAY.SUB_REFRESH_OVERLAY_STATE_WPF()
    End Sub

    Private Sub SUB_SEND_KEYS_SCL_LK()
        Call MOD_SEND_KEYS.SUB_SEND_KEYS_SCROLL(prcTARGET)
    End Sub

    Private Sub SUB_SEND_KEYS_LIGHT()
        Call MOD_SEND_KEYS.SUB_SEND_KEYS_END(prcTARGET)

        Select Case srtCAPT_SETTINGS.LIGHT_ROTATE_LR_KEY
            Case ENM_LIGHT_ROTATE_LR_KEY_INDEX.LEFT
                Call MOD_SEND_KEYS.SUB_SEND_KEYS_LEFT(prcTARGET, srtCAPT_SETTINGS.LIGHT_ROTATE_LR_MS)
            Case ENM_LIGHT_ROTATE_LR_KEY_INDEX.RIGHT
                Call MOD_SEND_KEYS.SUB_SEND_KEYS_RIGHT(prcTARGET, srtCAPT_SETTINGS.LIGHT_ROTATE_LR_MS)
            Case Else

        End Select

        Select Case srtCAPT_SETTINGS.LIGHT_DISTANCE_KEY
            Case ENM_LIGHT_DISTANSE_KEY_INDEX.PAGE_UP
                Call MOD_SEND_KEYS.SUB_SEND_KEYS_PGUP(prcTARGET, srtCAPT_SETTINGS.LIGHT_DISTANCE_MS)
            Case ENM_LIGHT_DISTANSE_KEY_INDEX.PAGE_DOWN
                Call MOD_SEND_KEYS.SUB_SEND_KEYS_PGDN(prcTARGET, srtCAPT_SETTINGS.LIGHT_DISTANCE_MS)
            Case Else
        End Select

        Select Case srtCAPT_SETTINGS.LIGHT_ROTATE_UD_KEY
            Case ENM_LIGHT_ROTATE_UD_KEY_INDEX.UP
                Call MOD_SEND_KEYS.SUB_SEND_KEYS_UP(prcTARGET, srtCAPT_SETTINGS.LIGHT_ROTATE_UD_MS)
            Case ENM_LIGHT_ROTATE_UD_KEY_INDEX.DOWN
                Call MOD_SEND_KEYS.SUB_SEND_KEYS_DOWN(prcTARGET, srtCAPT_SETTINGS.LIGHT_ROTATE_UD_MS)
            Case Else

        End Select

        Call MOD_SEND_KEYS.SUB_SEND_KEYS_X(prcTARGET, 50)
    End Sub

#End Region

#Region "外部呼出"
    Friend Enum ENM_MY_EXEC_DO
        CAPT_ONE = 11
        CAPT_CON = 12
        VIEW_SETTING = 21
        VIEW_OVERLAY = 22
        VIEW_ROTATE = 23
        REFRESH_OVERLAY = 31
        REFRESH_OVERLAY_STATE = 32
        SEND_KEYS_SCL_LK = 41
        SEND_KEYS_LIGHT = 42
    End Enum

    Private BLN_DO_EXEC As Boolean = False
    Friend Sub SUB_EXEC_DO(ByVal enmEXEC_DO As ENM_MY_EXEC_DO)

        If BLN_DO_EXEC Then
            Exit Sub
        End If

        BLN_DO_EXEC = True
        Select Case enmEXEC_DO
            Case ENM_MY_EXEC_DO.CAPT_ONE
                Call SUB_CAPTURE_ONE()
            Case ENM_MY_EXEC_DO.CAPT_CON
                Call SUB_CAPTURE()
            Case ENM_MY_EXEC_DO.VIEW_SETTING
                Call SUB_VIEW_SETTING()
            Case ENM_MY_EXEC_DO.VIEW_OVERLAY
                Call SUB_VIEW_OVERLAY()
            Case ENM_MY_EXEC_DO.VIEW_ROTATE
                Call SUB_VIEW_ROTATE()
            Case ENM_MY_EXEC_DO.REFRESH_OVERLAY
                Call SUB_REFRESH_OVERLAY()
            Case ENM_MY_EXEC_DO.REFRESH_OVERLAY_STATE
                Call SUB_REFRESH_OVERLAY_STATE()
            Case ENM_MY_EXEC_DO.SEND_KEYS_SCL_LK
                Call SUB_SEND_KEYS_SCL_LK()
            Case ENM_MY_EXEC_DO.SEND_KEYS_LIGHT
                Call SUB_SEND_KEYS_LIGHT()
        End Select

        BLN_DO_EXEC = False

    End Sub

    Friend Sub SUB_SET_PROCESS(ByVal blnENABLED As Boolean)
        Dim strTEXT As String

        If blnENABLED Then
            strTEXT = ""
            strTEXT &= "FFXIVプロセスを確認しました。" & System.Environment.NewLine
            strTEXT &= "プロセスID：" & prcTARGET.Id & System.Environment.NewLine
        Else
            strTEXT = ""
            strTEXT = "FFXIVプロセスを探索しています..." & System.Environment.NewLine
        End If

        NTI_TASK.Text = strTEXT
        Call SUB_CMS_ENABLED(blnENABLED)

        If Not blnENABLED Then
            If MOD_OVERLAY.STATE_SHOW Then
                Call MOD_OVERLAY.SUB_CLOSE_OVERLAY_WPF()
            End If
        End If
    End Sub

    Private Sub SUB_CMS_ENABLED(ByVal blnENABLED As Boolean)

        TSM_CAPT_ONE.Enabled = blnENABLED
        TSM_CAPT.Enabled = blnENABLED
        TSM_OVERLAY.Enabled = blnENABLED
        TSM_ROTATE.Enabled = blnENABLED
    End Sub

    Private Delegate Sub safeCall(ByVal blnENABLED As Boolean)

#End Region

#Region "NEW"
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Call SUB_CTRL_NEW_INIT()
    End Sub
#End Region

#Region "イベント-ホットキー"
    'ホットキーの入力メッセージを取得する
    Private stwHOT_KEY As Stopwatch
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim intELAPSED As Integer

        Const WM_HOTKEY As Integer = &H312
        Dim blnDO As Boolean

        If Not m.Msg = WM_HOTKEY Then
            MyBase.WndProc(m)
            Exit Sub
        End If

        blnDO = False
        If stwHOT_KEY Is Nothing Then
            stwHOT_KEY = New System.Diagnostics.Stopwatch
            blnDO = True
            Call stwHOT_KEY.Start()
        End If

        If Not blnDO Then
            Call stwHOT_KEY.Stop()
            intELAPSED = stwHOT_KEY.ElapsedMilliseconds
            blnDO = (intELAPSED > 500)
        End If

        If blnDO Then
            Dim intCAPT_INDEX As Integer
            intCAPT_INDEX = FUNC_CHECK_HOT_KEY(m.LParam)

            Call SUB_DO_HOT_KEY_EVENT(intCAPT_INDEX)
            Call stwHOT_KEY.Restart()

        Else
            Call stwHOT_KEY.Start()
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub SUB_DO_HOT_KEY_EVENT(ByVal intHOT_KEY_INDEX As Integer)
        If intHOT_KEY_INDEX <= 0 Then
            Exit Sub
        End If

        Select Case intHOT_KEY_INDEX
            Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.CAPT_CON)
            Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CAPT_ONE
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.CAPT_ONE)
            Case srtCAPT_SETTINGS.HOT_KEY_INDEX_CHANGE_COMPOSITION
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.VIEW_OVERLAY)
            Case srtCAPT_SETTINGS.HOT_KEY_INDEX_ROTATE
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.VIEW_ROTATE)
            Case Else

        End Select

    End Sub

    Private Function FUNC_GET_HOT_KEY_INDEX(ByVal intINDEX As Integer) As Integer
        Return intINDEX
    End Function
#End Region

#Region "イベント-タイマー"
    Private Sub TIM_CHECK_PROCESS_Tick(sender As Object, e As EventArgs) Handles TIM_CHECK_PROCESS.Tick
        If prcTARGET Is Nothing Then
            Call SUB_SET_PROCESS(False)
            Call SUB_END_CAPTURE()
        Else
            Call SUB_SET_PROCESS(True)
        End If
    End Sub
#End Region

#Region "イベント-クリック"
    Private Sub TSM_CAPT_ONE_Click(sender As Object, e As EventArgs) Handles TSM_CAPT_ONE.Click
        Call SUB_CAPTURE_ONE()
    End Sub

    Private Sub TSM_CAPT_Click(sender As Object, e As EventArgs) Handles TSM_CAPT.Click
        Call SUB_CAPTURE()
    End Sub

    Private Sub TSM_OVERLAY_Click(sender As Object, e As EventArgs) Handles TSM_OVERLAY.Click
        Call SUB_VIEW_OVERLAY()
    End Sub

    Private Sub TSM_ROTATE_Click(sender As Object, e As EventArgs) Handles TSM_ROTATE.Click
        Call SUB_VIEW_ROTATE()
    End Sub

    Private Sub TSM_SETTING_Click(sender As Object, e As EventArgs) Handles TSM_SETTING.Click
        Call SUB_VIEW_SETTING()
    End Sub

    Private Sub TSM_EXIT_Click(sender As Object, e As EventArgs) Handles TSM_EXIT.Click
        Call SUB_END()
    End Sub
#End Region

    Private Sub FRM_MAIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub FRM_MAIN_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Call SUB_END_JOYSTICK()
        Call SUB_CTRL_VIEW_FIN()
    End Sub

    Private Sub TSM_COMPOSITION_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Call SUB_VIEW_OVERLAY()
    End Sub

End Class
