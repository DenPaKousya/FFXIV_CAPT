Friend Module MOD_SETTING

#Region "モジュール用構造体"
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
        Public HOT_KEY_INDEX_CAPT As Integer
        Public HOT_KEY_INDEX_CHANGE_COMPOSITION As Integer
        Public HOT_KEY_INDEX_ROTATE As Integer
        Public USE_JOYSTICK As Boolean
        Public USE_JOYSTICK_BUTTON_SCRLK As Integer
        Public USE_JOYSTICK_BUTTON_CAPT_ONE As Integer
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

        Public LIGHT_ROTATE_LR_KEY As Integer
        Public LIGHT_ROTATE_LR_MS As Integer
        Public LIGHT_DISTANCE_KEY As Integer
        Public LIGHT_DISTANCE_MS As Integer
        Public LIGHT_ROTATE_UD_KEY As Integer
        Public LIGHT_ROTATE_UD_MS As Integer

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
            .HOT_KEY_INDEX_CAPT = ctlSETTINGS.cmbHOT_KEY_CAPT.SelectedIndex
            .HOT_KEY_INDEX_CHANGE_COMPOSITION = ctlSETTINGS.cmbHOT_KEY_CHANGE_COMPOSITION.SelectedIndex
            .HOT_KEY_INDEX_ROTATE = ctlSETTINGS.cmbHOT_KEY_ROTATE.SelectedIndex

            .USE_JOYSTICK = ctlSETTINGS.chkUSE_JOYSTICK.Checked
            .USE_JOYSTICK_BUTTON_SCRLK = ctlSETTINGS.cmbPAD_SCRLOCK.SelectedIndex
            .USE_JOYSTICK_BUTTON_CAPT_ONE = ctlSETTINGS.cmbPAD_CAPT_ONE.SelectedIndex
            .USE_JOYSTICK_BUTTON_CAPT = ctlSETTINGS.cmbPAD_CAPT.SelectedIndex
            .USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION = ctlSETTINGS.cmbPAD_CHANGE_COMPOSITION.SelectedIndex
            .USE_JOYSTICK_BUTTON_ROTATE = ctlSETTINGS.cmbPAD_ROTATE.SelectedIndex

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

            .LIGHT_ROTATE_LR_KEY = ctlSETTINGS.CMB_LIGHT_ROTATE_LR.SelectedIndex
            .LIGHT_ROTATE_LR_MS = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.TXT_LIGHT_ROTATE_LR.Text, 0)
            .LIGHT_DISTANCE_KEY = ctlSETTINGS.CMB_LIGHT_DISTANCE.SelectedIndex
            .LIGHT_DISTANCE_MS = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.TXT_LIGHT_DISTANCE.Text, 0)
            .LIGHT_ROTATE_UD_KEY = ctlSETTINGS.CMB_LIGHT_ROTATE_UD.SelectedIndex
            .LIGHT_ROTATE_UD_MS = FUNC_VALUE_CONVERT_NUMERIC_INT(ctlSETTINGS.TXT_LIGHT_ROTATE_UD.Text, 0)
        End With

        Return srtRET

    End Function

    Public Function FUNC_GET_INITAL_SETTINGS() As SRT_SETTINGS
        Dim srtRET As SRT_SETTINGS
        Dim strTEMP As String

        With srtRET
            .HOT_KEY_INDEX_CAPT_ONE = 10
            .HOT_KEY_INDEX_CAPT = 0
            .HOT_KEY_INDEX_CHANGE_COMPOSITION = 11
            .HOT_KEY_INDEX_ROTATE = 0

            .USE_JOYSTICK = True
            .USE_JOYSTICK_BUTTON_SCRLK = 0
            .USE_JOYSTICK_BUTTON_CAPT_ONE = 13
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

            .LIGHT_ROTATE_LR_KEY = 0
            .LIGHT_ROTATE_LR_MS = 1000
            .LIGHT_DISTANCE_KEY = 1
            .LIGHT_DISTANCE_MS = 400
            .LIGHT_ROTATE_UD_KEY = 0
            .LIGHT_ROTATE_UD_MS = 0
        End With

        Return srtRET
    End Function

    Friend Sub SUB_SET_SETTINGS(ByRef frmSETTINGS As FRM_SETTING, ByRef srtSETTINGS As SRT_SETTINGS)

        With frmSETTINGS
            .cmbHOT_KEY_CAPT_ONE.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_CAPT_ONE
            .cmbHOT_KEY_CAPT.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_CAPT
            .cmbHOT_KEY_CHANGE_COMPOSITION.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_CHANGE_COMPOSITION
            .cmbHOT_KEY_ROTATE.SelectedIndex = srtSETTINGS.HOT_KEY_INDEX_ROTATE
            .chkUSE_JOYSTICK.Checked = srtSETTINGS.USE_JOYSTICK
            .cmbPAD_SCRLOCK.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_SCRLK
            .cmbPAD_CAPT_ONE.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_CAPT_ONE
            .cmbPAD_CAPT.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_CAPT
            .cmbPAD_CHANGE_COMPOSITION.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION
            .cmbPAD_ROTATE.SelectedIndex = srtSETTINGS.USE_JOYSTICK_BUTTON_ROTATE

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

            .CMB_LIGHT_ROTATE_LR.SelectedIndex = srtSETTINGS.LIGHT_ROTATE_LR_KEY
            .TXT_LIGHT_ROTATE_LR.Text = srtSETTINGS.LIGHT_ROTATE_LR_MS
            .CMB_LIGHT_DISTANCE.SelectedIndex = srtSETTINGS.LIGHT_DISTANCE_KEY
            .TXT_LIGHT_DISTANCE.Text = srtSETTINGS.LIGHT_DISTANCE_MS
            .CMB_LIGHT_ROTATE_UD.SelectedIndex = srtSETTINGS.LIGHT_ROTATE_UD_KEY
            .TXT_LIGHT_ROTATE_UD.Text = srtSETTINGS.LIGHT_ROTATE_UD_MS
        End With
    End Sub

End Module
