Public Class FRM_SETTING

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Me.Icon = My.Resources.CAPT
    End Sub
#End Region

#Region "実行処理群"
    Private Sub SUB_OK()

        srtCAPT_SETTINGS = FUNC_GET_SETTINGS(Me)
        Call MOD_JOYPAD.SUB_PARAM_INIT()
        Call MOD_HOT_KEY.SUB_UNREG_HOTKEY()
        Call MOD_HOT_KEY.SUB_REG_HOTKEY()
        Call MOD_OVERLAY.SUB_RECALL_OVERLAY_WPF(MOD_SETTING.FRM_PARENT)
        Call MOD_ROTATE.SUB_RECALL_ROTATE(MOD_SETTING.FRM_PARENT)
        Call MOD_LOGO.SUB_RECALL_LOGO(MOD_SETTING.FRM_PARENT)
        Call Me.Close()
    End Sub

    Private Sub SUB_CANCEL()
        Call Me.Close()
    End Sub

    Private Sub SUB_INIT_SETTING()
        Dim srtINI As SRT_SETTINGS
        srtINI = FUNC_GET_INITAL_SETTINGS()
        Call SUB_SET_SETTINGS(Me, srtINI)
    End Sub

    Private Sub SUB_INIT_SETTING_ROTATE_POSITION()
        Me.txtROTATE_POSITION_X.Text = 0
        Me.txtROTATE_POSITION_Y.Text = 0
    End Sub

    Private Sub SUB_INIT_SETTING_ROTATE_SIZE()
        Me.txtROTATE_SIZE_W.Text = cstROTATE_SIZE_W_DEFAULT
        Me.txtROTATE_SIZE_H.Text = cstROTATE_SIZE_H_DEFAULT
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

    Private Sub btnPATH_SAVE_REF_Click(sender As Object, e As EventArgs) Handles btnPATH_SAVE_REF.Click
        Dim dgrRESULT As System.Windows.Forms.DialogResult
        fbdPATH_SAVE.SelectedPath = txtPATH_SAVE.Text

        dgrRESULT = fbdPATH_SAVE.ShowDialog()
        If dgrRESULT = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        txtPATH_SAVE.Text = fbdPATH_SAVE.SelectedPath
    End Sub

    Private Sub btnOPEN_DIR_Click(sender As Object, e As EventArgs) Handles btnOPEN_DIR.Click
        Dim strDIR As String

        strDIR = txtPATH_SAVE.Text

        If Not FUNC_DIR_CHECK(strDIR) Then
            Exit Sub
        End If

        If Not FUNC_CALL_EXE_FILE_SHELL(strDIR, "", False) Then
            Exit Sub
        End If
    End Sub

    Private Sub BTN_REF_PATH_LOGO_FILE_Click(sender As Object, e As EventArgs) Handles BTN_REF_PATH_LOGO_FILE.Click
        Dim ofdDIALOG As OpenFileDialog

        ofdDIALOG = New OpenFileDialog()
        ofdDIALOG.Title = "画像を開く"
        ofdDIALOG.Filter = "画像ファイル|*.png"
        ofdDIALOG.Multiselect = False
        ofdDIALOG.InitialDirectory = srtCAPT_SETTINGS.PATH_SAVE

        Dim rstDIALOG As DialogResult
        rstDIALOG = ofdDIALOG.ShowDialog()

        If rstDIALOG = Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim strFILE_PATH As String
        strFILE_PATH = ofdDIALOG.FileName
        TXT_PATH_LOGO_FILE.Text = strFILE_PATH
    End Sub

    Private Sub btnROTATE_POSITION_INIT_Click(sender As Object, e As EventArgs) Handles btnROTATE_POSITION_INIT.Click
        Call SUB_INIT_SETTING_ROTATE_POSITION()
    End Sub

    Private Sub btnROTATE_SIZE_INIT_Click(sender As Object, e As EventArgs) Handles btnROTATE_SIZE_INIT.Click
        Call SUB_INIT_SETTING_ROTATE_SIZE()
    End Sub

#End Region

#Region "イベント-インデックスチェンジ"
    Private Sub cmbKIND_JOY_STICK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKIND_JOY_STICK.SelectedIndexChanged
        Call MOD_SETTING.SUB_REFRESH_JOY_STICK_BUTTON(Me)
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

End Class