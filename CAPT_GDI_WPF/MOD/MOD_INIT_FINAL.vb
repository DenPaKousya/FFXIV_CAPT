Friend Module MOD_INIT_FINAL

    Public Function FUNC_INIT() As Boolean

        If Not FUNC_INIT_SETTING() Then
            Return False
        End If

        If Not FUNC_GET_SETTING() Then
            Return False
        End If

        If Not FUNC_INIT_EXIF() Then
            Return False
        End If

        Call SUB_INIT_GAPHICS()

        Return True
    End Function

    Public Function FUNC_FINALIZE() As Boolean
        Call SUB_END_GAPHICS()

        Call FUNC_SET_SETTING()
        Return True
    End Function

#Region "内部処理"
    Private Function FUNC_INIT_SETTING()
        Dim srtINIT As SRT_SETTINGS

        srtINIT = FUNC_GET_INITAL_SETTINGS()

        srtCAPT_SETTINGS = srtINIT

        Return True
    End Function

    Private Function FUNC_GET_SETTING()
        Dim strTEMP As String

        With srtCAPT_SETTINGS
            Try
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_KEY_INDEX_CAPT_ONE)
                If Not strTEMP = "" Then
                    .HOT_KEY_INDEX_CAPT_ONE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_KEY_INDEX_CAPT_ONE_SNS)
                If Not strTEMP = "" Then
                    .HOT_KEY_INDEX_CAPT_ONE_SNS = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_KEY_INDEX_CAPT)
                If Not strTEMP = "" Then
                    .HOT_KEY_INDEX_CAPT = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_KEY_INDEX_OVERLAY)
                If Not strTEMP = "" Then
                    .HOT_KEY_INDEX_CHANGE_COMPOSITION = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_KEY_INDEX_ROTATE)
                If Not strTEMP = "" Then
                    .HOT_KEY_INDEX_ROTATE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_MASK_INDEX_CAPT_ONE)
                If Not strTEMP = "" Then
                    .HOT_MASK_INDEX_CAPT_ONE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_MASK_INDEX_CAPT_ONE_SNS)
                If Not strTEMP = "" Then
                    .HOT_MASK_INDEX_CAPT_ONE_SNS = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_MASK_INDEX_CAPT)
                If Not strTEMP = "" Then
                    .HOT_MASK_INDEX_CAPT = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_MASK_INDEX_OVERLAY)
                If Not strTEMP = "" Then
                    .HOT_MASK_INDEX_CHANGE_COMPOSITION = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_HOT_MASK_INDEX_ROTATE)
                If Not strTEMP = "" Then
                    .HOT_MASK_INDEX_ROTATE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_KIND_JOY_STICK)
                If Not strTEMP = "" Then
                    .KIND_JOY_STICK = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_JOY_STICK_MOD_BUTTON_CAPT_ONE)
                If Not strTEMP = "" Then
                    .JOY_STICK_MOD_BUTTON_CAPT_ONE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_JOY_STICK_MOD_BUTTON_CAPT_ONE_SNS)
                If Not strTEMP = "" Then
                    .JOY_STICK_MOD_BUTTON_CAPT_ONE_SNS = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_JOY_STICK_MOD_BUTTON_CAPT)
                If Not strTEMP = "" Then
                    .JOY_STICK_MOD_BUTTON_CAPT = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_JOY_STICK_MOD_BUTTON_VIEW_OVERLAY)
                If Not strTEMP = "" Then
                    .JOY_STICK_MOD_BUTTON_VIEW_OVERLAY = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_JOY_STICK_MOD_BUTTON_VIEW_ROTATE)
                If Not strTEMP = "" Then
                    .JOY_STICK_MOD_BUTTON_VIEW_ROTATE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_USE_JOYSTICK_BUTTON_CAPT_ONE)
                If Not strTEMP = "" Then
                    .USE_JOYSTICK_BUTTON_CAPT_ONE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_USE_JOYSTICK_BUTTON_CAPT_ONE_SNS)
                If Not strTEMP = "" Then
                    .USE_JOYSTICK_BUTTON_CAPT_ONE_SNS = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_USE_JOYSTICK_BUTTON_CAPT)
                If Not strTEMP = "" Then
                    .USE_JOYSTICK_BUTTON_CAPT = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_USE_JOYSTICK_BUTTON_OVERLAY)
                If Not strTEMP = "" Then
                    .USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_USE_JOYSTICK_BUTTON_ROTATE)
                If Not strTEMP = "" Then
                    .USE_JOYSTICK_BUTTON_ROTATE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_PATH_SAVE)
                If Not strTEMP = "" Then
                    .PATH_SAVE = strTEMP
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_PATH_SAVE_FOLDER_NAME)
                If Not strTEMP = "" Then
                    .PATH_SAVE_FOLDER_NAME = strTEMP
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_PATH_SAVE_FILE_NAME)
                If Not strTEMP = "" Then
                    .PATH_SAVE_FILE_NAME = strTEMP
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_IMAGE_FORMAT)
                If Not strTEMP = "" Then
                    .IMAGE_FORMAT = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_ADD_COPYRIGHT)
                If Not strTEMP = "" Then
                    .ADD_COPYRIGHT = FUNC_CAST_INT_TO_BOOL(CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_IMAGE_INDEX)
                If Not strTEMP = "" Then
                    .IMAGE_INDEX = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_SOUND_CAPTURE)
                If Not strTEMP = "" Then
                    .SOUND_CAPTURE = FUNC_CAST_INT_TO_BOOL(CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_COUNT_CAPTURE)
                If Not strTEMP = "" Then
                    .COUNT_CAPTURE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_TIMER_CAPTURE)
                If Not strTEMP = "" Then
                    .TIMER_CAPTURE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_INTERVAL_CAPTURE)
                If Not strTEMP = "" Then
                    .INTERVAL_CAPTURE = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_SEND_KEY_INDEX)
                If Not strTEMP = "" Then
                    .SEND_KEY_INDEX = CInt(strTEMP)
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_INTERVAL_SEND_KEY)
                If Not strTEMP = "" Then
                    .INTERVAL_SEND_KEY = CInt(strTEMP)
                End If

                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_SHORTCUT)
                If Not strTEMP = "" Then
                    .OVERLAY_SHORTCUT = FUNC_CAST_INT_TO_BOOL(CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_COMPOSITION)
                If Not strTEMP = "" Then
                    .OVERLAY_COMPOSITION = FUNC_CAST_INT_TO_BOOL(CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_CAPT_PARAM)
                If Not strTEMP = "" Then
                    .OVERLAY_CAPT_PARAM = FUNC_CAST_INT_TO_BOOL(CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_HISTOGRAM)
                If Not strTEMP = "" Then
                    .OVERLAY_HISTOGRAM = FUNC_CAST_INT_TO_BOOL(CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_THUMBNAIL)
                If Not strTEMP = "" Then
                    .OVERLAY_THUMBNAIL = FUNC_CAST_INT_TO_BOOL(CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_SHORTCUT_ALIGNMENT)
                If Not strTEMP = "" Then
                    .OVERLAY_SHORTCUT_ALIGNMENT = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_CAPT_PARAM_ALIGNMENT)
                If Not strTEMP = "" Then
                    .OVERLAY_CAPT_PARAM_ALIGNMENT = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_THUMBNAIL_ALIGNMENT)
                If Not strTEMP = "" Then
                    .OVERLAY_THUMBNAIL_ALIGNMENT = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_HISTOGRAM_ALIGNMENT)
                If Not strTEMP = "" Then
                    .OVERLAY_HISTOGRAM_ALIGNMENT = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_OVERLAY_COMPOSITION_TYPE)
                If Not strTEMP = "" Then
                    .OVERLAY_COMPOSITION_TYPE = (CInt(strTEMP))
                End If

                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_ROTATE_POSITION_X)
                If Not strTEMP = "" Then
                    .ROTATE_POSITION_X = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_ROTATE_POSITION_Y)
                If Not strTEMP = "" Then
                    .ROTATE_POSITION_Y = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_ROTATE_SIZE_W)
                If Not strTEMP = "" Then
                    .ROTATE_SIZE_W = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_ROTATE_SIZE_H)
                If Not strTEMP = "" Then
                    .ROTATE_SIZE_H = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_ROTATE_BUTTON_SIZE)
                If Not strTEMP = "" Then
                    .ROTATE_BUTTON_SIZE = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_ROTATE_BUTTON_SENSITIVITY)
                If Not strTEMP = "" Then
                    .ROTATE_BUTTON_SENSITIVITY = (CInt(strTEMP))
                End If

                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_LIGHT_ROTATE_LR_KEY)
                If Not strTEMP = "" Then
                    .LIGHT_ROTATE_LR_KEY = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_LIGHT_ROTATE_LR_MS)
                If Not strTEMP = "" Then
                    .LIGHT_ROTATE_LR_MS = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_LIGHT_DISTANCE_KEY)
                If Not strTEMP = "" Then
                    .LIGHT_DISTANCE_KEY = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_LIGHT_DISTANCE_MS)
                If Not strTEMP = "" Then
                    .LIGHT_DISTANCE_MS = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_LIGHT_ROTATE_UD_KEY)
                If Not strTEMP = "" Then
                    .LIGHT_ROTATE_UD_KEY = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_LIGHT_ROTATE_UD_MS)
                If Not strTEMP = "" Then
                    .LIGHT_ROTATE_UD_MS = (CInt(strTEMP))
                End If
                strTEMP = FUNC_GET_APP_SETTINGS(cstCONFIG_PATH_LOGO_FILE)
                If Not strTEMP = "" Then
                    .PATH_LOGO_FILE = (CStr(strTEMP))
                End If
            Catch ex As Exception

            End Try
        End With
        Return True
    End Function

    Private Function FUNC_SET_SETTING()
        Dim strTEMP As String

        With srtCAPT_SETTINGS
            Try
                strTEMP = CStr(.HOT_KEY_INDEX_CAPT_ONE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_KEY_INDEX_CAPT_ONE, strTEMP)
                strTEMP = CStr(.HOT_KEY_INDEX_CAPT_ONE_SNS)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_KEY_INDEX_CAPT_ONE_SNS, strTEMP)
                strTEMP = CStr(.HOT_KEY_INDEX_CAPT)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_KEY_INDEX_CAPT, strTEMP)
                strTEMP = CStr(.HOT_KEY_INDEX_CHANGE_COMPOSITION)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_KEY_INDEX_OVERLAY, strTEMP)
                strTEMP = CStr(.HOT_KEY_INDEX_ROTATE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_KEY_INDEX_ROTATE, strTEMP)
                strTEMP = CStr(.HOT_MASK_INDEX_CAPT_ONE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_MASK_INDEX_CAPT_ONE, strTEMP)
                strTEMP = CStr(.HOT_MASK_INDEX_CAPT_ONE_SNS)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_MASK_INDEX_CAPT_ONE_SNS, strTEMP)
                strTEMP = CStr(.HOT_MASK_INDEX_CAPT)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_MASK_INDEX_CAPT, strTEMP)
                strTEMP = CStr(.HOT_MASK_INDEX_CHANGE_COMPOSITION)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_MASK_INDEX_OVERLAY, strTEMP)
                strTEMP = CStr(.HOT_MASK_INDEX_ROTATE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_HOT_MASK_INDEX_ROTATE, strTEMP)

                strTEMP = CStr(.KIND_JOY_STICK)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_KIND_JOY_STICK, strTEMP)
                strTEMP = CStr(.JOY_STICK_MOD_BUTTON_CAPT_ONE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_JOY_STICK_MOD_BUTTON_CAPT_ONE, strTEMP)
                strTEMP = CStr(.JOY_STICK_MOD_BUTTON_CAPT_ONE_SNS)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_JOY_STICK_MOD_BUTTON_CAPT_ONE_SNS, strTEMP)
                strTEMP = CStr(.JOY_STICK_MOD_BUTTON_CAPT)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_JOY_STICK_MOD_BUTTON_CAPT, strTEMP)
                strTEMP = CStr(.JOY_STICK_MOD_BUTTON_VIEW_OVERLAY)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_JOY_STICK_MOD_BUTTON_VIEW_OVERLAY, strTEMP)
                strTEMP = CStr(.JOY_STICK_MOD_BUTTON_VIEW_ROTATE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_JOY_STICK_MOD_BUTTON_VIEW_ROTATE, strTEMP)
                strTEMP = CStr(.USE_JOYSTICK_BUTTON_CAPT_ONE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_USE_JOYSTICK_BUTTON_CAPT_ONE, strTEMP)
                strTEMP = CStr(.USE_JOYSTICK_BUTTON_CAPT_ONE_SNS)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_USE_JOYSTICK_BUTTON_CAPT_ONE_SNS, strTEMP)
                strTEMP = CStr(.USE_JOYSTICK_BUTTON_CAPT)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_USE_JOYSTICK_BUTTON_CAPT, strTEMP)
                strTEMP = CStr(.USE_JOYSTICK_BUTTON_CHANGE_COMPOSITION)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_USE_JOYSTICK_BUTTON_OVERLAY, strTEMP)
                strTEMP = CStr(.USE_JOYSTICK_BUTTON_ROTATE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_USE_JOYSTICK_BUTTON_ROTATE, strTEMP)

                strTEMP = CStr(.PATH_SAVE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_PATH_SAVE, strTEMP)
                strTEMP = CStr(.PATH_SAVE_FOLDER_NAME)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_PATH_SAVE_FOLDER_NAME, strTEMP)
                strTEMP = CStr(.PATH_SAVE_FILE_NAME)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_PATH_SAVE_FILE_NAME, strTEMP)
                strTEMP = CStr(.IMAGE_FORMAT)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_IMAGE_FORMAT, strTEMP)
                strTEMP = CStr(FUNC_CAST_BOOL_TO_INT(.ADD_COPYRIGHT))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_ADD_COPYRIGHT, strTEMP)
                strTEMP = CStr(.IMAGE_INDEX)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_IMAGE_INDEX, strTEMP)

                strTEMP = CStr(FUNC_CAST_BOOL_TO_INT(.SOUND_CAPTURE))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_SOUND_CAPTURE, strTEMP)
                strTEMP = CStr(.COUNT_CAPTURE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_COUNT_CAPTURE, strTEMP)
                strTEMP = CStr(.TIMER_CAPTURE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_TIMER_CAPTURE, strTEMP)
                strTEMP = CStr(.INTERVAL_CAPTURE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_INTERVAL_CAPTURE, strTEMP)
                strTEMP = CStr(.INTERVAL_CAPTURE)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_INTERVAL_CAPTURE, strTEMP)
                strTEMP = CStr(.SEND_KEY_INDEX)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_SEND_KEY_INDEX, strTEMP)
                strTEMP = CStr(.INTERVAL_SEND_KEY)
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_INTERVAL_SEND_KEY, strTEMP)

                strTEMP = CStr(FUNC_CAST_BOOL_TO_INT(.OVERLAY_COMPOSITION))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_COMPOSITION, strTEMP)
                strTEMP = CStr(FUNC_CAST_BOOL_TO_INT(.OVERLAY_CAPT_PARAM))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_CAPT_PARAM, strTEMP)
                strTEMP = CStr(FUNC_CAST_BOOL_TO_INT(.OVERLAY_HISTOGRAM))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_HISTOGRAM, strTEMP)
                strTEMP = CStr(FUNC_CAST_BOOL_TO_INT(.OVERLAY_THUMBNAIL))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_THUMBNAIL, strTEMP)
                strTEMP = CStr((.OVERLAY_SHORTCUT_ALIGNMENT))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_SHORTCUT_ALIGNMENT, strTEMP)
                strTEMP = CStr((.OVERLAY_CAPT_PARAM_ALIGNMENT))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_CAPT_PARAM_ALIGNMENT, strTEMP)
                strTEMP = CStr((.OVERLAY_THUMBNAIL_ALIGNMENT))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_THUMBNAIL_ALIGNMENT, strTEMP)
                strTEMP = CStr((.OVERLAY_HISTOGRAM_ALIGNMENT))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_HISTOGRAM_ALIGNMENT, strTEMP)
                strTEMP = CStr((.OVERLAY_COMPOSITION_TYPE))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_OVERLAY_COMPOSITION_TYPE, strTEMP)

                strTEMP = CStr((.ROTATE_POSITION_X))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_ROTATE_POSITION_X, strTEMP)
                strTEMP = CStr((.ROTATE_POSITION_Y))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_ROTATE_POSITION_Y, strTEMP)
                strTEMP = CStr((.ROTATE_SIZE_W))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_ROTATE_SIZE_W, strTEMP)
                strTEMP = CStr((.ROTATE_SIZE_H))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_ROTATE_SIZE_H, strTEMP)
                strTEMP = CStr((.ROTATE_BUTTON_SIZE))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_ROTATE_BUTTON_SIZE, strTEMP)
                strTEMP = CStr((.ROTATE_BUTTON_SENSITIVITY))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_ROTATE_BUTTON_SENSITIVITY, strTEMP)

                strTEMP = CStr((.PATH_LOGO_FILE))
                Call FUNC_WRITE_APP_CONFIG(cstCONFIG_PATH_LOGO_FILE, strTEMP)
            Catch ex As Exception

            End Try
        End With
        Return True
    End Function

#End Region

End Module
