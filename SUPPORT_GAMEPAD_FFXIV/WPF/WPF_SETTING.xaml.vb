Imports System.ComponentModel

Public Class WPF_SETTING

#Region "プロパティ用変数"
    Private BLN_PROPETY_CHECK_CLOSED As Boolean = False
#End Region

#Region "プロパティ"
    Public Property CHECK_CLOSED As Boolean
        Get
            Return BLN_PROPETY_CHECK_CLOSED
        End Get
        Set(ByVal value As Boolean)
            BLN_PROPETY_CHECK_CLOSED = value
        End Set
    End Property

#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Me.Icon = FUNC_GET_IMAGESOURCE(My.Resources._32pxl)

        'ウィンドウをマウスのドラッグで移動できるようにする
        AddHandler Me.MouseLeftButtonDown, Sub(sender, e) Me.DragMove()

        Call SUB_REFRESH_KIND(Me)
        Call SUB_REFRESH_KEY_MASK(Me)
        Call SUB_REFRESH_KEY(Me)

        Call SUB_START_TIMER()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()

    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()

        TXT_TEST_SEND_STR.Text = "/grouppose"

        TXT_TEST_OPERATION_MOUSE_X.Text = CStr(100)
        TXT_TEST_OPERATION_MOUSE_Y.Text = CStr(100)
    End Sub
#End Region

#Region "実行処理群"
    Private Sub SUB_OK()
        SRT_CURRENT_SETTINGS = FUNC_GET_SETTINGS_WPF(Me)
        Call MOD_GAMEPAD.SUB_PARAM_INIT()

        Call FUNC_SET_SETTING()

        Call Me.Close()
    End Sub

    Private Sub SUB_CANCEL()
        Call Me.Close()
    End Sub

    Private Sub SUB_INIT_SETTING()
        Dim SRT_INI As SRT_SETTINGS
        SRT_INI = FUNC_GET_INITAL_SETTINGS()
        Call SUB_SET_SETTINGS_WPF(Me, SRT_INI)
    End Sub

    Private Sub SUB_TEST_SEND_KEY()

        If PRC_TARGET Is Nothing Then
            Exit Sub
        End If

        'Call SUB_FOREGROUND_WINDOW(PRC_TARGET)
        'Call System.Threading.Thread.Sleep(100)
        'Call FUNC_SEND_KEYS_MASK(PRC_TARGET, ENM_SEND_VK.VK_S, ENM_MASK_KEYS.CTRL)
        'Call FUNC_SEND_KEYS_MASK(PRC_TARGET, ENM_SEND_VK.VK_S, ENM_MASK_KEYS.ALT)
        'Call FUNC_SEND_KEYS_MASK(PRC_TARGET, ENM_SEND_VK.VK_F4, ENM_MASK_KEYS.NONE)

        'Call FUNC_SEND_KEYS_STRING_02(PRC_TARGET, "abcdef")
        Call SUB_SEND_KEYS_1(PRC_TARGET)
    End Sub

    Private Sub SUB_TEST_SEND_TEXT()
        If PRC_TARGET Is Nothing Then
            Exit Sub
        End If

        Dim STR_COMMAND As String
        STR_COMMAND = TXT_TEST_SEND_STR.Text

        If STR_COMMAND = "" Then
            Exit Sub
        End If

        Call SUB_FOREGROUND_WINDOW(PRC_TARGET)

        Call SUB_SEND_KEYS_RETURN(PRC_TARGET)

        Call FUNC_SEND_KEYS_STRING_02(PRC_TARGET, STR_COMMAND)

        Call SUB_SEND_KEYS_RETURN(PRC_TARGET)
    End Sub

    Private Sub SUB_TEST_OPERATION_MOUSE()
        Dim INT_X As Integer
        INT_X = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_TEST_OPERATION_MOUSE_X.Text)
        Dim INT_Y As Integer
        INT_Y = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_TEST_OPERATION_MOUSE_Y.Text)

        Call SUB_SET_MOUSE_POINTER_CLIENT(INT_X, INT_Y)
    End Sub

    Private Sub SUB_CHANGE_KIND(ByVal INT_INDEX As Integer)
        Dim INT_KIND As Integer

        Select Case INT_INDEX
            Case 1
                INT_KIND = CMB_GAMEPAD_ALLOCATION_01_KIND.SelectedIndex
            Case 2
                INT_KIND = CMB_GAMEPAD_ALLOCATION_02_KIND.SelectedIndex
            Case 3
                INT_KIND = CMB_GAMEPAD_ALLOCATION_03_KIND.SelectedIndex
            Case 4
                INT_KIND = CMB_GAMEPAD_ALLOCATION_04_KIND.SelectedIndex
            Case Else
                INT_KIND = -1
        End Select

        Dim BLN_ENABLED_KEY As Boolean
        Dim BLN_ENABLED_MOUSE As Boolean

        Select Case INT_KIND
            Case 0
                BLN_ENABLED_KEY = True
                BLN_ENABLED_MOUSE = False
            Case 1
                BLN_ENABLED_KEY = False
                BLN_ENABLED_MOUSE = True
            Case Else
                BLN_ENABLED_KEY = False
                BLN_ENABLED_MOUSE = False
        End Select

        Select Case INT_INDEX
            Case 1
                CMB_GAMEPAD_ALLOCATION_01_KEY_01.IsEnabled = BLN_ENABLED_KEY
                CMB_GAMEPAD_ALLOCATION_01_KEY_02.IsEnabled = BLN_ENABLED_KEY
                TXT_GAMEPAD_ALLOCATION_01_MOUSE_X.IsEnabled = BLN_ENABLED_MOUSE
                TXT_GAMEPAD_ALLOCATION_01_MOUSE_Y.IsEnabled = BLN_ENABLED_MOUSE
            Case 2
                CMB_GAMEPAD_ALLOCATION_02_KEY_01.IsEnabled = BLN_ENABLED_KEY
                CMB_GAMEPAD_ALLOCATION_02_KEY_02.IsEnabled = BLN_ENABLED_KEY
                TXT_GAMEPAD_ALLOCATION_02_MOUSE_X.IsEnabled = BLN_ENABLED_MOUSE
                TXT_GAMEPAD_ALLOCATION_02_MOUSE_Y.IsEnabled = BLN_ENABLED_MOUSE
            Case 3
                CMB_GAMEPAD_ALLOCATION_03_KEY_01.IsEnabled = BLN_ENABLED_KEY
                CMB_GAMEPAD_ALLOCATION_03_KEY_02.IsEnabled = BLN_ENABLED_KEY
                TXT_GAMEPAD_ALLOCATION_03_MOUSE_X.IsEnabled = BLN_ENABLED_MOUSE
                TXT_GAMEPAD_ALLOCATION_03_MOUSE_Y.IsEnabled = BLN_ENABLED_MOUSE
            Case 4
                CMB_GAMEPAD_ALLOCATION_04_KEY_01.IsEnabled = BLN_ENABLED_KEY
                CMB_GAMEPAD_ALLOCATION_04_KEY_02.IsEnabled = BLN_ENABLED_KEY
                TXT_GAMEPAD_ALLOCATION_04_MOUSE_X.IsEnabled = BLN_ENABLED_MOUSE
                TXT_GAMEPAD_ALLOCATION_04_MOUSE_Y.IsEnabled = BLN_ENABLED_MOUSE
            Case Else

        End Select
    End Sub
#End Region

#Region "NEW"
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Call SUB_CTRL_NEW_INIT()
    End Sub
#End Region

#Region "イベント-セレクションチェンジ"
    Private Sub CMB_KIND_GAMEPAD_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CMB_KIND_GAMEPAD.SelectionChanged
        Call MOD_SETTING.SUB_REFRESH_GAMEPAD_BUTTON_WPF(Me)
    End Sub

    Private Sub CMB_GAMEPAD_ALLOCATION_01_KIND_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CMB_GAMEPAD_ALLOCATION_01_KIND.SelectionChanged
        Call SUB_CHANGE_KIND(1)
    End Sub

    Private Sub CMB_GAMEPAD_ALLOCATION_02_KIND_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CMB_GAMEPAD_ALLOCATION_02_KIND.SelectionChanged
        Call SUB_CHANGE_KIND(2)
    End Sub

    Private Sub CMB_GAMEPAD_ALLOCATION_03_KIND_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CMB_GAMEPAD_ALLOCATION_03_KIND.SelectionChanged
        Call SUB_CHANGE_KIND(3)
    End Sub

    Private Sub CMB_GAMEPAD_ALLOCATION_04_KIND_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CMB_GAMEPAD_ALLOCATION_04_KIND.SelectionChanged
        Call SUB_CHANGE_KIND(4)
    End Sub
#End Region

#Region "イベント-ボタンクリック"
    Private Sub BTN_OK_Click(sender As Object, e As RoutedEventArgs) Handles BTN_OK.Click
        Call SUB_OK()
    End Sub

    Private Sub BTN_CANCEL_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CANCEL.Click
        Call SUB_CANCEL()
    End Sub

    Private Sub BTN_INIT_SETTINGS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_INIT_SETTINGS.Click
        Call SUB_INIT_SETTING()
    End Sub

    Private Sub BTN_TEST_SEND_KEY_Click(sender As Object, e As RoutedEventArgs) Handles BTN_TEST_SEND_KEY.Click
        Call SUB_TEST_SEND_KEY()
    End Sub

    Private Sub BTN_TEST_SEND_STR_Click(sender As Object, e As RoutedEventArgs) Handles BTN_TEST_SEND_STR.Click
        Call SUB_TEST_SEND_TEXT()
    End Sub

    Private Sub BTN_TEST_OPERATION_MOUSE_Click(sender As Object, e As RoutedEventArgs) Handles BTN_TEST_OPERATION_MOUSE.Click
        Call SUB_TEST_OPERATION_MOUSE()
    End Sub
#End Region

#Region "イベント-タイマー"

#Region "変数"
    Private TIM_GAMEPAD As System.Timers.Timer
#End Region

#Region "開始・終了"
    Private Sub SUB_START_TIMER()
        TIM_GAMEPAD = New System.Timers.Timer
        TIM_GAMEPAD.Interval = 100
        TIM_GAMEPAD.AutoReset = True

        AddHandler TIM_GAMEPAD.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf SUB_GAMEPAD_TIMER)
        Call TIM_GAMEPAD.Start()
    End Sub
    Private Sub SUB_STOP_TIMER()
        Call TIM_GAMEPAD.Stop()
    End Sub
#End Region

    Private Sub SUB_GAMEPAD_TIMER(sender As Object, e As System.Timers.ElapsedEventArgs)
        LBL_TEST_GAMEPAD_POV.Content = CStr(MOD_GAMEPAD.GAMEPAD_POV)
        LBL_TEST_GAMEPAD_BUTTON.Content = CStr(MOD_GAMEPAD.GAMEPAD_BUTTONS)
    End Sub
#End Region

    Private Sub WPF_SETTING_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub WPF_SETTING_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.CHECK_CLOSED = True
        Call SUB_STOP_TIMER()
    End Sub
End Class
