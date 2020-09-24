Public Class FRM_SETTING

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Me.Icon = My.Resources._32px
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        TXT_TEST_SEND_STR.Text = "/grouppose"

        TXT_TEST_OPERATION_MOUSE_X.Text = CStr(100)
        TXT_TEST_OPERATION_MOUSE_Y.Text = CStr(100)
    End Sub
#End Region

#Region "実行処理群"
    Private Sub SUB_OK()
        SRT_CURRENT_SETTINGS = FUNC_GET_SETTINGS(Me)
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
        Call SUB_SET_SETTINGS(Me, SRT_INI)
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
#End Region

#Region "NEW"
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Call SUB_CTRL_NEW_INIT()
    End Sub

#End Region

#Region "イベント-インデックスチェンジ"
    Private Sub CMB_KIND_GAMEPAD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_KIND_GAMEPAD.SelectedIndexChanged
        Call MOD_SETTING.SUB_REFRESH_GAMEPAD_BUTTON(Me)
    End Sub
#End Region

#Region "イベント-クリック"
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Call SUB_OK()
    End Sub

    Private Sub btnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Call SUB_CANCEL()
    End Sub

    Private Sub btnINIT_SETTINGS_Click(sender As Object, e As EventArgs) Handles btnINIT_SETTINGS.Click
        Call SUB_INIT_SETTING()
    End Sub

    Private Sub BTN_TEST_SEND_KEY_Click(sender As Object, e As EventArgs) Handles BTN_TEST_SEND_KEY.Click
        Call SUB_TEST_SEND_KEY()
    End Sub

    Private Sub BTN_TEST_SEND_STR_Click(sender As Object, e As EventArgs) Handles BTN_TEST_SEND_STR.Click
        Call SUB_TEST_SEND_TEXT()
    End Sub

    Private Sub BTN_TEST_OPERATION_MOUSE_Click(sender As Object, e As EventArgs) Handles BTN_TEST_OPERATION_MOUSE.Click
        Call SUB_TEST_OPERATION_MOUSE()
    End Sub
#End Region

    Private Sub FRM_SETTING_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SUB_CTRL_VALUE_INIT()
    End Sub

End Class