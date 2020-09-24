Friend Module MOD_SETTING

#Region "モジュール用・列挙定数"
    Private Enum ENM_KIND_JOY_STICK
        NONE = 0
        NORMAL = 1
        DS4 = 2
    End Enum
#End Region

#Region "モジュール用・構造体"
    Public Structure SRT_SETTINGS
        Public PATH_SAVE As String
        Public PATH_SAVE_FOLDER_NAME As String
        Public PATH_SAVE_FILE_NAME As String
        Public IMAGE_FORMAT As Integer
        Public ADD_COPYRIGHT As Boolean
        Public IMAGE_INDEX As Integer
        Public COUNT_CAPTURE As Integer
        Public TIMER_CAPTURE As Integer
        Public INTERVAL_CAPTURE As Integer
        Public SOUND_CAPTURE As Boolean
        Public SHOW_INSTRUCTION_BOOT As Boolean
        Public SEND_KEY_INDEX As Integer
        Public INTERVAL_SEND_KEY As Integer

        Public HOT_KEY_INDEX_CAPT_ONE As Integer
        Public HOT_KEY_INDEX_CAPT_ONE_SNS As Integer
        Public HOT_KEY_INDEX_CAPT As Integer
        Public HOT_KEY_INDEX_CHANGE_COMPOSITION As Integer
        Public HOT_KEY_INDEX_ROTATE As Integer
        Public HOT_MASK_INDEX_CAPT_ONE As Integer
        Public HOT_MASK_INDEX_CAPT_ONE_SNS As Integer
        Public HOT_MASK_INDEX_CAPT As Integer
        Public HOT_MASK_INDEX_CHANGE_COMPOSITION As Integer
        Public HOT_MASK_INDEX_ROTATE As Integer

        Public KIND_JOY_STICK As Integer
        Public JOY_STICK_MOD_BUTTON_CAPT_ONE As Integer
        Public JOY_STICK_MOD_BUTTON_CAPT_ONE_SNS As Integer
        Public JOY_STICK_MOD_BUTTON_CAPT As Integer
        Public JOY_STICK_MOD_BUTTON_VIEW_OVERLAY As Integer
        Public JOY_STICK_MOD_BUTTON_VIEW_ROTATE As Integer
        Public USE_JOYSTICK_BUTTON_CAPT_ONE As Integer
        Public USE_JOYSTICK_BUTTON_CAPT_ONE_SNS As Integer
        Public USE_JOYSTICK_BUTTON_CAPT As Integer
        Public USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION As Integer
        Public USE_JOYSTICK_BUTTON_ROTATE As Integer

        Public OVERLAY_SHORTCUT As Boolean
        Public OVERLAY_COMPOSITION As Boolean
        Public OVERLAY_CAPT_PARAM As Boolean
        Public OVERLAY_HISTOGRAM As Boolean
        Public OVERLAY_THUMBNAIL As Boolean
        Public OVERLAY_SHORTCUT_ALIGNMENT As Integer
        Public OVERLAY_CAPT_PARAM_ALIGNMENT As Integer
        Public OVERLAY_HISTOGRAM_ALIGNMENT As Integer
        Public OVERLAY_THUMBNAIL_ALIGNMENT As Integer
        Public OVERLAY_COMPOSITION_TYPE As Integer

        Public ROTATE_POSITION_X As Integer
        Public ROTATE_POSITION_Y As Integer
        Public ROTATE_SIZE_W As Integer
        Public ROTATE_SIZE_H As Integer
        Public ROTATE_BUTTON_SIZE As Integer
        Public ROTATE_BUTTON_SENSITIVITY As Integer

        Public LIGHT_ROTATE_LR_KEY As Integer
        Public LIGHT_ROTATE_LR_MS As Integer
        Public LIGHT_DISTANCE_KEY As Integer
        Public LIGHT_DISTANCE_MS As Integer
        Public LIGHT_ROTATE_UD_KEY As Integer
        Public LIGHT_ROTATE_UD_MS As Integer

        Public PATH_LOGO_FILE As String
    End Structure
#End Region

#Region "モジュール用変数"
    Public FRM_PARENT As FRM_MAIN
    Private FRM_SETTING As FRM_SETTING
#End Region

    Public Sub SUB_CALL_SETTING(ByRef frmPARENT As FRM_MAIN)
        Dim blnCHECK_STATE As Boolean

        blnCHECK_STATE = False

        If FUNC_GET_STATE() Then
            Call SUB_CLOSE_SETTING()
        Else
            Call SUB_VIEW_SETTING(frmPARENT)
        End If
    End Sub

    Private Function FUNC_GET_STATE() As Boolean
        If Not (FRM_SETTING Is Nothing) Then
            If FRM_SETTING.Visible Then
                Return True
            End If
        End If

        Return False
    End Function

    Private Sub SUB_VIEW_SETTING(ByRef frmPARENT As FRM_MAIN)

        If FUNC_GET_STATE() Then
            Exit Sub
        End If

        FRM_PARENT = frmPARENT

        FRM_SETTING = New FRM_SETTING
        Call SUB_SET_SETTINGS(FRM_SETTING, srtCAPT_SETTINGS)
        Call FRM_SETTING.Show()

    End Sub

    Private Sub SUB_CLOSE_SETTING()
        If Not FUNC_GET_STATE() Then
            Exit Sub
        End If

        Call FRM_SETTING.Close()
    End Sub

    Public Function FUNC_GET_SETTINGS(ByRef ctlSETTINGS As FRM_SETTING) As SRT_SETTINGS
        Dim srtRET As SRT_SETTINGS

        With srtRET
            .HOT_KEY_INDEX_CAPT_ONE = ctlSETTINGS.cmbHOT_KEY_CAPT_ONE.SelectedIndex
            .HOT_KEY_INDEX_CAPT_ONE_SNS = ctlSETTINGS.cmbHOT_KEY_CAPT_ONE_SNS.SelectedIndex
            .HOT_KEY_INDEX_CAPT = ctlSETTINGS.cmbHOT_KEY_CAPT.SelectedIndex
            .HOT_KEY_INDEX_CHANGE_COMPOSITION = ctlSETTINGS.cmbHOT_KEY_CHANGE_COMPOSITION.SelectedIndex
            .HOT_KEY_INDEX_ROTATE = ctlSETTINGS.cmbHOT_KEY_ROTATE.SelectedIndex
            .HOT_MASK_INDEX_CAPT_ONE = ctlSETTINGS.cmbHOT_MASK_CAPT_ONE.SelectedIndex
            .HOT_MASK_INDEX_CAPT_ONE_SNS = ctlSETTINGS.cmbHOT_MASK_CAPT_ONE_SNS.SelectedIndex
            .HOT_MASK_INDEX_CAPT = ctlSETTINGS.cmbHOT_MASK_CAPT.SelectedIndex
            .HOT_MASK_INDEX_CHANGE_COMPOSITION = ctlSETTINGS.cmbHOT_MASK_CHANGE_COMPOSITION.SelectedIndex
            .HOT_MASK_INDEX_ROTATE = ctlSETTINGS.cmbHOT_MASK_ROTATE.SelectedIndex

            .KIND_JOY_STICK = ctlSETTINGS.cmbKIND_JOY_STICK.SelectedIndex
            .JOY_STICK_MOD_BUTTON_CAPT_ONE = ctlSETTINGS.cmbJOY_MOD_CAPT_ONE.SelectedIndex
            .JOY_STICK_MOD_BUTTON_CAPT_ONE_SNS = ctlSETTINGS.cmbJOY_MOD_CAPT_ONE_SNS.SelectedIndex
            .JOY_STICK_MOD_BUTTON_CAPT = ctlSETTINGS.cmbJOY_MOD_CAPT.SelectedIndex
            .JOY_STICK_MOD_BUTTON_VIEW_OVERLAY = ctlSETTINGS.cmbJOY_MOD_VIEW_OVERLAY.SelectedIndex
            .JOY_STICK_MOD_BUTTON_VIEW_ROTATE = ctlSETTINGS.cmbJOY_MOD_VIEW_ROTATE.SelectedIndex
            .USE_JOYSTICK_BUTTON_CAPT_ONE = ctlSETTINGS.cmbPAD_CAPT_ONE.SelectedIndex
            .USE_JOYSTICK_BUTTON_CAPT_ONE_SNS = ctlSETTINGS.cmbPAD_CAPT_ONE_SNS.SelectedIndex
            .USE_JOYSTICK_BUTTON_CAPT = ctlSETTINGS.cmbPAD_CAPT.SelectedIndex
            .USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION = ctlSETTINGS.cmbPAD_VIEW_OVERLAY.SelectedIndex
            .USE_JOYSTICK_BUTTON_ROTATE = ctlSETTINGS.cmbPAD_VIEW_ROTATE.SelectedIndex

            .PATH_SAVE = ctlSETTINGS.txtPATH_SAVE.Text
            .PATH_SAVE_FOLDER_NAME = ctlSETTINGS.txtPATH_SAVE_FOLDER_NAME.Text
            .PATH_SAVE_FILE_NAME = ctlSETTINGS.txtPATH_SAVE_FILE_NAME.Text
            .IMAGE_FORMAT = ctlSETTINGS.cmbIMAGE_FORMAT.SelectedIndex
            .ADD_COPYRIGHT = ctlSETTINGS.chkCOPYRIGHT.Checked
            .IMAGE_INDEX = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtIMAGE_INDEX.Text)

            .SOUND_CAPTURE = ctlSETTINGS.chkSOUND_CAPTURE.Checked
            .COUNT_CAPTURE = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtCOUNT_CAPTURE.Text, 0)
            .TIMER_CAPTURE = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtTIMER_CAPTURE.Text, 5000)
            .INTERVAL_CAPTURE = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtINTERVAL_CAPTURE.Text, 10000)
            .SEND_KEY_INDEX = ctlSETTINGS.cmbSEND_KEY.SelectedIndex
            .INTERVAL_SEND_KEY = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtINTERVAL_SEND_KEY.Text, 50)

            .OVERLAY_SHORTCUT = ctlSETTINGS.chkOVERLAY_VISBLE_SHORTCUT.Checked
            .OVERLAY_COMPOSITION = ctlSETTINGS.chkOVERLAY_VISBLE_COMPOSITION.Checked
            .OVERLAY_CAPT_PARAM = ctlSETTINGS.chkOVERLAY_VISBLE_CAPT_PARAM.Checked
            .OVERLAY_HISTOGRAM = ctlSETTINGS.chkOVERLAY_VISBLE_HISTOGRAM.Checked
            .OVERLAY_THUMBNAIL = ctlSETTINGS.chkOVERLAY_VISBLE_THUMBNAIL.Checked

            .OVERLAY_SHORTCUT_ALIGNMENT = ctlSETTINGS.cmbOVERLAY_ALIGNMENT_SHORTCUT.SelectedIndex
            .OVERLAY_CAPT_PARAM_ALIGNMENT = ctlSETTINGS.cmbOVERLAY_ALIGNMENT_CAPT_PARAM.SelectedIndex
            .OVERLAY_HISTOGRAM_ALIGNMENT = ctlSETTINGS.cmbOVERLAY_ALIGNMENT_HISTOGRAM.SelectedIndex
            .OVERLAY_THUMBNAIL_ALIGNMENT = ctlSETTINGS.cmbOVERLAY_ALIGNMENT_THUMBNAIL.SelectedIndex
            .OVERLAY_COMPOSITION_TYPE = ctlSETTINGS.cmbOVERLAY_COMPOSITION_TYPE.SelectedIndex

            .ROTATE_POSITION_X = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtROTATE_POSITION_X.Text, 0)
            .ROTATE_POSITION_Y = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtROTATE_POSITION_Y.Text, 0)
            .ROTATE_SIZE_W = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtROTATE_SIZE_W.Text, cstROTATE_SIZE_W_DEFAULT)
            .ROTATE_SIZE_H = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.txtROTATE_SIZE_H.Text, cstROTATE_SIZE_H_DEFAULT)
            .ROTATE_BUTTON_SIZE = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.CMB_ROTATE_BUTTON_SIZE.Text, CST_ROTATE_BUTTON_SIZE_DEFAULT)
            If .ROTATE_BUTTON_SIZE > CST_ROTATE_BUTTON_SIZE_MAX Then
                .ROTATE_BUTTON_SIZE = CST_ROTATE_BUTTON_SIZE_MAX
            End If
            .ROTATE_BUTTON_SENSITIVITY = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.CMB_ROTATE_BUTTON_SENSITIVITY.Text, CST_ROTATE_BUTTON_SENSITIVITY_DEFAULT)
            If .ROTATE_BUTTON_SENSITIVITY > CST_ROTATE_BUTTON_SENSITIVITY_MAX Then
                .ROTATE_BUTTON_SENSITIVITY = CST_ROTATE_BUTTON_SENSITIVITY_MAX
            End If

            .LIGHT_ROTATE_LR_KEY = ctlSETTINGS.CMB_LIGHT_ROTATE_LR.SelectedIndex
            .LIGHT_ROTATE_LR_MS = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.TXT_LIGHT_ROTATE_LR.Text, 0)
            .LIGHT_DISTANCE_KEY = ctlSETTINGS.CMB_LIGHT_DISTANCE.SelectedIndex
            .LIGHT_DISTANCE_MS = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.TXT_LIGHT_DISTANCE.Text, 0)
            .LIGHT_ROTATE_UD_KEY = ctlSETTINGS.CMB_LIGHT_ROTATE_UD.SelectedIndex
            .LIGHT_ROTATE_UD_MS = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.TXT_LIGHT_ROTATE_UD.Text, 0)

            .PATH_LOGO_FILE = ctlSETTINGS.TXT_PATH_LOGO_FILE.Text
        End With

        Return srtRET

    End Function

    Public Function FUNC_GET_INITAL_SETTINGS() As SRT_SETTINGS
        Dim srtRET As SRT_SETTINGS
        Dim strTEMP As String

        With srtRET
            .HOT_MASK_INDEX_CAPT_ONE = 0
            .HOT_MASK_INDEX_CAPT_ONE_SNS = 0
            .HOT_MASK_INDEX_CAPT = 0
            .HOT_MASK_INDEX_CHANGE_COMPOSITION = 0
            .HOT_MASK_INDEX_ROTATE = 0
            .HOT_KEY_INDEX_CAPT_ONE = 10
            .HOT_KEY_INDEX_CAPT_ONE_SNS = 0
            .HOT_KEY_INDEX_CAPT = 0
            .HOT_KEY_INDEX_CHANGE_COMPOSITION = 11
            .HOT_KEY_INDEX_ROTATE = 0

            .KIND_JOY_STICK = 1
            .JOY_STICK_MOD_BUTTON_CAPT_ONE = 0
            .JOY_STICK_MOD_BUTTON_CAPT_ONE_SNS = 0
            .JOY_STICK_MOD_BUTTON_CAPT = 0
            .JOY_STICK_MOD_BUTTON_VIEW_OVERLAY = 0
            .JOY_STICK_MOD_BUTTON_VIEW_ROTATE = 0
            .USE_JOYSTICK_BUTTON_CAPT_ONE = 13
            .USE_JOYSTICK_BUTTON_CAPT_ONE_SNS = 13
            .USE_JOYSTICK_BUTTON_CAPT = 0
            .USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION = 10
            .USE_JOYSTICK_BUTTON_ROTATE = 0

            strTEMP = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            .PATH_SAVE = strTEMP & "\" & "FFXIV_CAPTURE"
            .PATH_SAVE_FOLDER_NAME = "\YYYY\MM\DD"
            .PATH_SAVE_FILE_NAME = "IMG_\INDEX"

            .IMAGE_FORMAT = ENM_IMAGE_FORMAT.PNG
            .ADD_COPYRIGHT = False
            .IMAGE_INDEX = 1

            .SOUND_CAPTURE = True
            .COUNT_CAPTURE = 1
            .TIMER_CAPTURE = 0
            .INTERVAL_CAPTURE = 1000
            .SEND_KEY_INDEX = 0
            .INTERVAL_SEND_KEY = 50

            .OVERLAY_COMPOSITION = True
            .OVERLAY_CAPT_PARAM = True
            .OVERLAY_HISTOGRAM = False
            .OVERLAY_THUMBNAIL = True

            .OVERLAY_SHORTCUT_ALIGNMENT = 1
            .OVERLAY_CAPT_PARAM_ALIGNMENT = 1
            .OVERLAY_HISTOGRAM_ALIGNMENT = 0
            .OVERLAY_THUMBNAIL_ALIGNMENT = 3

            .OVERLAY_COMPOSITION_TYPE = 1

            .ROTATE_POSITION_X = 0
            .ROTATE_POSITION_Y = 0
            .ROTATE_SIZE_W = cstROTATE_SIZE_W_DEFAULT
            .ROTATE_SIZE_H = cstROTATE_SIZE_H_DEFAULT
            .ROTATE_BUTTON_SIZE = CST_ROTATE_BUTTON_SIZE_DEFAULT
            .ROTATE_BUTTON_SENSITIVITY = CST_ROTATE_BUTTON_SENSITIVITY_DEFAULT

            .LIGHT_ROTATE_LR_KEY = 0
            .LIGHT_ROTATE_LR_MS = 1000
            .LIGHT_DISTANCE_KEY = 1
            .LIGHT_DISTANCE_MS = 400
            .LIGHT_ROTATE_UD_KEY = 0
            .LIGHT_ROTATE_UD_MS = 0

            .PATH_LOGO_FILE = ""
        End With

        Return srtRET
    End Function

    Friend Sub SUB_SET_SETTINGS(ByRef frmSETTINGS As FRM_SETTING, ByRef srtSETTINGS As SRT_SETTINGS)

        With frmSETTINGS
            .cmbHOT_KEY_CAPT_ONE.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_CAPT_ONE
            .cmbHOT_KEY_CAPT_ONE_SNS.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_CAPT_ONE_SNS
            .cmbHOT_KEY_CAPT.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_CAPT
            .cmbHOT_KEY_CHANGE_COMPOSITION.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_CHANGE_COMPOSITION
            .cmbHOT_KEY_ROTATE.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_ROTATE
            .cmbHOT_MASK_CAPT_ONE.SelectedIndex = srtSETTINGS.HOT_MASK_INDEX_CAPT_ONE
            .cmbHOT_MASK_CAPT_ONE_SNS.SelectedIndex = srtSETTINGS.HOT_MASK_INDEX_CAPT_ONE_SNS
            .cmbHOT_MASK_CAPT.SelectedIndex = srtSETTINGS.HOT_MASK_INDEX_CAPT
            .cmbHOT_MASK_CHANGE_COMPOSITION.SelectedIndex = srtSETTINGS.HOT_MASK_INDEX_CHANGE_COMPOSITION
            .cmbHOT_MASK_ROTATE.SelectedIndex = srtSETTINGS.HOT_MASK_INDEX_ROTATE
            .cmbKIND_JOY_STICK.SelectedIndex = srtSETTINGS.KIND_JOY_STICK
            .cmbJOY_MOD_CAPT_ONE.SelectedIndex = srtSETTINGS.JOY_STICK_MOD_BUTTON_CAPT_ONE
            .cmbJOY_MOD_CAPT_ONE_SNS.SelectedIndex = srtSETTINGS.JOY_STICK_MOD_BUTTON_CAPT_ONE_SNS
            .cmbJOY_MOD_CAPT.SelectedIndex = srtSETTINGS.JOY_STICK_MOD_BUTTON_CAPT
            .cmbJOY_MOD_VIEW_OVERLAY.SelectedIndex = srtSETTINGS.JOY_STICK_MOD_BUTTON_VIEW_OVERLAY
            .cmbJOY_MOD_VIEW_ROTATE.SelectedIndex = srtSETTINGS.JOY_STICK_MOD_BUTTON_VIEW_ROTATE
            .cmbPAD_CAPT_ONE.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_CAPT_ONE
            .cmbPAD_CAPT_ONE_SNS.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_CAPT_ONE_SNS
            .cmbPAD_CAPT.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_CAPT
            .cmbPAD_VIEW_OVERLAY.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION
            .cmbPAD_VIEW_ROTATE.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_ROTATE

            .txtPATH_SAVE.Text = srtSETTINGS.PATH_SAVE
            .txtPATH_SAVE_FOLDER_NAME.Text = srtSETTINGS.PATH_SAVE_FOLDER_NAME
            .txtPATH_SAVE_FILE_NAME.Text = srtSETTINGS.PATH_SAVE_FILE_NAME
            .cmbIMAGE_FORMAT.SelectedIndex = srtSETTINGS.IMAGE_FORMAT
            .chkCOPYRIGHT.Checked = srtSETTINGS.ADD_COPYRIGHT
            .txtIMAGE_INDEX.Text = srtSETTINGS.IMAGE_INDEX

            .chkSOUND_CAPTURE.Checked = srtSETTINGS.SOUND_CAPTURE
            .txtCOUNT_CAPTURE.Text = srtSETTINGS.COUNT_CAPTURE
            .txtTIMER_CAPTURE.Text = srtSETTINGS.TIMER_CAPTURE
            .txtINTERVAL_CAPTURE.Text = srtSETTINGS.INTERVAL_CAPTURE
            .cmbSEND_KEY.SelectedIndex = srtSETTINGS.SEND_KEY_INDEX
            .txtINTERVAL_SEND_KEY.Text = srtSETTINGS.INTERVAL_SEND_KEY

            .chkOVERLAY_VISBLE_COMPOSITION.Checked = srtSETTINGS.OVERLAY_COMPOSITION
            .chkOVERLAY_VISBLE_CAPT_PARAM.Checked = srtSETTINGS.OVERLAY_CAPT_PARAM
            .chkOVERLAY_VISBLE_HISTOGRAM.Checked = srtSETTINGS.OVERLAY_HISTOGRAM
            .chkOVERLAY_VISBLE_THUMBNAIL.Checked = srtSETTINGS.OVERLAY_THUMBNAIL

            .cmbOVERLAY_ALIGNMENT_SHORTCUT.SelectedIndex = srtSETTINGS.OVERLAY_SHORTCUT_ALIGNMENT
            .cmbOVERLAY_ALIGNMENT_CAPT_PARAM.SelectedIndex = srtSETTINGS.OVERLAY_CAPT_PARAM_ALIGNMENT
            .cmbOVERLAY_ALIGNMENT_HISTOGRAM.SelectedIndex = srtSETTINGS.OVERLAY_HISTOGRAM_ALIGNMENT
            .cmbOVERLAY_ALIGNMENT_THUMBNAIL.SelectedIndex = srtSETTINGS.OVERLAY_THUMBNAIL_ALIGNMENT

            .cmbOVERLAY_COMPOSITION_TYPE.SelectedIndex = srtSETTINGS.OVERLAY_COMPOSITION_TYPE

            .txtROTATE_POSITION_X.Text = srtSETTINGS.ROTATE_POSITION_X
            .txtROTATE_POSITION_Y.Text = srtSETTINGS.ROTATE_POSITION_Y
            .txtROTATE_SIZE_W.Text = srtSETTINGS.ROTATE_SIZE_W
            .txtROTATE_SIZE_H.Text = srtSETTINGS.ROTATE_SIZE_H
            .CMB_ROTATE_BUTTON_SIZE.Text = srtSETTINGS.ROTATE_BUTTON_SIZE
            .CMB_ROTATE_BUTTON_SENSITIVITY.Text = srtSETTINGS.ROTATE_BUTTON_SENSITIVITY

            .CMB_LIGHT_ROTATE_LR.SelectedIndex = srtSETTINGS.LIGHT_ROTATE_LR_KEY
            .TXT_LIGHT_ROTATE_LR.Text = srtSETTINGS.LIGHT_ROTATE_LR_MS
            .CMB_LIGHT_DISTANCE.SelectedIndex = srtSETTINGS.LIGHT_DISTANCE_KEY
            .TXT_LIGHT_DISTANCE.Text = srtSETTINGS.LIGHT_DISTANCE_MS
            .CMB_LIGHT_ROTATE_UD.SelectedIndex = srtSETTINGS.LIGHT_ROTATE_UD_KEY
            .TXT_LIGHT_ROTATE_UD.Text = srtSETTINGS.LIGHT_ROTATE_UD_MS

            .TXT_PATH_LOGO_FILE.Text = srtSETTINGS.PATH_LOGO_FILE
        End With

        Call SUB_REFRESH_JOY_STICK_BUTTON(frmSETTINGS)
    End Sub

    Public Sub SUB_REFRESH_JOY_STICK_BUTTON(ByRef frmSETTINGS As FRM_SETTING)
        Dim enmKIND_JOY_STICK As ENM_KIND_JOY_STICK
        Dim strITEMS() As String

        With frmSETTINGS
            enmKIND_JOY_STICK = .cmbKIND_JOY_STICK.SelectedIndex
            Select Case enmKIND_JOY_STICK
                Case ENM_KIND_JOY_STICK.NONE
                    ReDim strITEMS(16)
                    strITEMS(0) = "　"
                    strITEMS(1) = "　"
                    strITEMS(2) = "　"
                    strITEMS(3) = "　"
                    strITEMS(4) = "　"
                    strITEMS(5) = "　"
                    strITEMS(6) = "　"
                    strITEMS(7) = "　"
                    strITEMS(8) = "　"
                    strITEMS(9) = "　"
                    strITEMS(10) = "　"
                    strITEMS(11) = "　"
                    strITEMS(12) = "　"
                    strITEMS(13) = "　"
                    strITEMS(14) = "　"
                    strITEMS(15) = "　"
                    strITEMS(16) = "　"
                Case ENM_KIND_JOY_STICK.NORMAL
                    ReDim strITEMS(16)
                    strITEMS(0) = "未使用"
                    strITEMS(1) = "ボタン1"
                    strITEMS(2) = "ボタン2"
                    strITEMS(3) = "ボタン3"
                    strITEMS(4) = "ボタン4"
                    strITEMS(5) = "ボタン5"
                    strITEMS(6) = "ボタン6"
                    strITEMS(7) = "ボタン7"
                    strITEMS(8) = "ボタン8"
                    strITEMS(9) = "ボタン9"
                    strITEMS(10) = "ボタン10"
                    strITEMS(11) = "ボタン11"
                    strITEMS(12) = "ボタン12"
                    strITEMS(13) = "ボタン13"
                    strITEMS(14) = "ボタン14"
                    strITEMS(15) = "ボタン15"
                    strITEMS(16) = "ボタン16"
                Case ENM_KIND_JOY_STICK.DS4
                    ReDim strITEMS(14)
                    strITEMS(0) = "未使用"
                    strITEMS(1) = "□"
                    strITEMS(2) = "×"
                    strITEMS(3) = "〇"
                    strITEMS(4) = "△"
                    strITEMS(5) = "L1"
                    strITEMS(6) = "R1"
                    strITEMS(7) = "L2"
                    strITEMS(8) = "R2"
                    strITEMS(9) = "SHARE"
                    strITEMS(10) = "OPTIONS"
                    strITEMS(11) = "L3"
                    strITEMS(12) = "R3"
                    strITEMS(13) = "PS"
                    strITEMS(14) = "PAD"
                Case Else
                    ReDim strITEMS(16)
                    strITEMS(0) = "　"
                    strITEMS(1) = "　"
                    strITEMS(2) = "　"
                    strITEMS(3) = "　"
                    strITEMS(4) = "　"
                    strITEMS(5) = "　"
                    strITEMS(6) = "　"
                    strITEMS(7) = "　"
                    strITEMS(8) = "　"
                    strITEMS(9) = "　"
                    strITEMS(10) = "　"
                    strITEMS(11) = "　"
                    strITEMS(12) = "　"
                    strITEMS(13) = "　"
                    strITEMS(14) = "　"
                    strITEMS(15) = "　"
                    strITEMS(16) = "　"
            End Select

            Call SUB_REFRESH_COMBO_ITEM(.cmbPAD_CAPT_ONE, strITEMS)
            Call SUB_REFRESH_COMBO_ITEM(.cmbPAD_CAPT_ONE_SNS, strITEMS)
            Call SUB_REFRESH_COMBO_ITEM(.cmbPAD_CAPT, strITEMS)
            Call SUB_REFRESH_COMBO_ITEM(.cmbPAD_VIEW_OVERLAY, strITEMS)
            Call SUB_REFRESH_COMBO_ITEM(.cmbPAD_VIEW_ROTATE, strITEMS)

            Call SUB_REFRESH_COMBO_ITEM(.cmbJOY_MOD_CAPT_ONE, strITEMS)
            Call SUB_REFRESH_COMBO_ITEM(.cmbJOY_MOD_CAPT_ONE_SNS, strITEMS)
            Call SUB_REFRESH_COMBO_ITEM(.cmbJOY_MOD_CAPT, strITEMS)
            Call SUB_REFRESH_COMBO_ITEM(.cmbJOY_MOD_VIEW_OVERLAY, strITEMS)
            Call SUB_REFRESH_COMBO_ITEM(.cmbJOY_MOD_VIEW_ROTATE, strITEMS)
        End With

    End Sub

    Private Sub SUB_REFRESH_COMBO_ITEM(ByRef cmbREFRESH As System.Windows.Forms.ComboBox, ByRef strROW() As String)
        Dim intSELECTED_INDEX As Integer

        intSELECTED_INDEX = cmbREFRESH.SelectedIndex '退避
        Call cmbREFRESH.Items.Clear()

        For i = 0 To (strROW.Length - 1)
            Call cmbREFRESH.Items.Add(strROW(i))
        Next

        If cmbREFRESH.Items.Count > intSELECTED_INDEX Then
            cmbREFRESH.SelectedIndex = intSELECTED_INDEX
        End If

    End Sub
End Module
