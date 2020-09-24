Friend Module MOD_OVERLAY

#Region "モジュール用変数"
    Friend FRM_PARENT As FRM_MAIN
    Private wpfOVERLAY As WPF_OVERLAY
#End Region

#Region "プロパティ用変数"
    Private blnPROPERTY_STATE_SHOW As Boolean = False
    Private strPROPERTY_PUT_STATE_STR As String = ""
#End Region

#Region "プロパティ"
    Public Property STATE_SHOW As Boolean
        Get
            Return blnPROPERTY_STATE_SHOW
        End Get
        Set(ByVal value As Boolean)
            blnPROPERTY_STATE_SHOW = value
        End Set
    End Property

    Public Property PUT_STATE_STR As String
        Get
            Return strPROPERTY_PUT_STATE_STR
        End Get
        Set(ByVal value As String)
            strPROPERTY_PUT_STATE_STR = value
        End Set
    End Property

#End Region

    Public Sub SUB_CALL_OVERLAY(ByRef frmPARENT As FRM_MAIN)
        If MOD_OVERLAY.STATE_SHOW Then
            'Call SUB_CLOSE_OVERLAY()
            Call SUB_CLOSE_OVERLAY_WPF()
        Else
            'Call SUB_SHOW_OVERLAY(frmPARENT)
            Call SUB_SHOW_OVERLAY_WPF(frmPARENT)
        End If
    End Sub

#Region "WPF"
    Public Sub SUB_RECALL_OVERLAY_WPF(ByRef frmPARENT As FRM_MAIN)
        If Not MOD_OVERLAY.STATE_SHOW Then
            Exit Sub
        End If

        Call SUB_CLOSE_OVERLAY_WPF()
        Call SUB_SHOW_OVERLAY_WPF(frmPARENT)
    End Sub

    Public Sub SUB_SHOW_OVERLAY_WPF(ByRef frmPARENT As FRM_MAIN)
        If prcTARGET Is Nothing Then
            Exit Sub
        End If

        If MOD_OVERLAY.STATE_SHOW Then
            Exit Sub
        End If

        MOD_OVERLAY.FRM_PARENT = frmPARENT

        wpfOVERLAY = New WPF_OVERLAY

        Call SUB_SET_SIZE_OVERLAY_WPF(wpfOVERLAY)
        wpfOVERLAY.PCB_COMPOSITION.Width = wpfOVERLAY.Width
        wpfOVERLAY.PCB_COMPOSITION.Height = wpfOVERLAY.Height
        wpfOVERLAY.PCB_APPEND.Width = wpfOVERLAY.Width
        wpfOVERLAY.PCB_APPEND.Height = wpfOVERLAY.Height

        Call SUB_SET_LOCATION_OVERLAY_WPF(wpfOVERLAY, ENM_POSITION_OVERLAY.LEFT_TOP)
        Call SUB_VISIBLE_OVERLAY_WPF()

        Call wpfOVERLAY.Show()
        Call wpfOVERLAY.SUB_DRAW_COMPOSTION(FUNC_CNV_OCT(srtCAPT_SETTINGS.OVERLAY_COMPOSITION_TYPE))
        Call wpfOVERLAY.SUB_DRAW_PARAMETERS_GUIDE()
        Call wpfOVERLAY.SUB_DRAW_PARAMETERS_VALUE()
        Call wpfOVERLAY.SUB_DRAW_STATE("")

        wpfOVERLAY.Topmost = True

        Call SUB_FOREGROUND_WINDOW(prcTARGET)

        MOD_OVERLAY.STATE_SHOW = True
    End Sub

    Public Sub SUB_CLOSE_OVERLAY_WPF()

        If Not MOD_OVERLAY.STATE_SHOW Then
            Exit Sub
        End If

        If wpfOVERLAY Is Nothing Then
            Exit Sub
        End If

        Try
            Call wpfOVERLAY.Close()
            wpfOVERLAY = Nothing
        Catch ex As Exception
            Exit Sub
        End Try

        MOD_OVERLAY.STATE_SHOW = False
    End Sub

    Public Sub SUB_VISIBLE_OVERLAY_WPF()

        If wpfOVERLAY Is Nothing Then
            Exit Sub
        End If

        Call SUB_VISIBLE_OVERLAY_WPF_COMPOSITION()
        Call SUB_VISIBLE_OVERLAY_WPF_SHORTCUT()
        Call SUB_VISIBLE_OVERLAY_WPF_CAPT_PARAM()
        Call SUB_VISIBLE_OVERLAY_WPF_THUMBNAIL()
        Call SUB_VISIBLE_OVERLAY_WPF_COLOR_INFO()

    End Sub

    Public Sub SUB_VISIBLE_OVERLAY_WPF_COMPOSITION()
        wpfOVERLAY.PCB_COMPOSITION.Visibility = FUNC_GET_VISIBILITY(srtCAPT_SETTINGS.OVERLAY_COMPOSITION)
    End Sub

    Private Sub SUB_VISIBLE_OVERLAY_WPF_COLOR_INFO()
        Dim enmVisibility As System.Windows.Visibility
        Dim enmVA As System.Windows.VerticalAlignment
        Dim enmHA As System.Windows.HorizontalAlignment

        Dim intRIGHT As Integer
        Dim intLEFT As Integer

        With srtCAPT_SETTINGS
            enmVisibility = FUNC_GET_VISIBILITY(.OVERLAY_HISTOGRAM)
            enmVA = FUNC_GET_VA(.OVERLAY_HISTOGRAM_ALIGNMENT)
            enmHA = FUNC_GET_HA(.OVERLAY_HISTOGRAM_ALIGNMENT)
        End With

        wpfOVERLAY.PCB_COLOR_INFO.Visibility = enmVisibility

        wpfOVERLAY.PCB_COLOR_INFO.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_COLOR_INFO.HorizontalAlignment = enmHA

        intRIGHT = 0
        intLEFT = 0

        If wpfOVERLAY.PCB_BUTTON_CLOSE.Visibility = Windows.Visibility.Visible And wpfOVERLAY.PCB_BUTTON_CLOSE.VerticalAlignment = wpfOVERLAY.PCB_COLOR_INFO.VerticalAlignment Then
            If wpfOVERLAY.PCB_BUTTON_CLOSE.HorizontalAlignment = Windows.HorizontalAlignment.Right Then
                intRIGHT += wpfOVERLAY.PCB_BUTTON_CLOSE.Width + 10
            End If

            If wpfOVERLAY.PCB_BUTTON_CLOSE.HorizontalAlignment = Windows.HorizontalAlignment.Left Then
                intLEFT += wpfOVERLAY.PCB_BUTTON_CLOSE.Width + 10
            End If
        End If

        If wpfOVERLAY.PCB_PARAM.Visibility = Windows.Visibility.Visible And wpfOVERLAY.PCB_PARAM.VerticalAlignment = wpfOVERLAY.PCB_COLOR_INFO.VerticalAlignment Then
            If wpfOVERLAY.PCB_PARAM.HorizontalAlignment = Windows.HorizontalAlignment.Right Then
                intRIGHT += wpfOVERLAY.PCB_PARAM.Width + 10
            End If

            If wpfOVERLAY.PCB_PARAM.HorizontalAlignment = Windows.HorizontalAlignment.Left Then
                intLEFT += wpfOVERLAY.PCB_PARAM.Width + 10
            End If
        End If

        If wpfOVERLAY.PCB_THUMBNAIL_01.Visibility = Windows.Visibility.Visible And wpfOVERLAY.PCB_THUMBNAIL_01.VerticalAlignment = wpfOVERLAY.PCB_COLOR_INFO.VerticalAlignment Then
            If wpfOVERLAY.PCB_THUMBNAIL_01.HorizontalAlignment = Windows.HorizontalAlignment.Right Then
                intRIGHT += wpfOVERLAY.PCB_SHUTTER.Width + 10 + wpfOVERLAY.PCB_THUMBNAIL_01.Width + 10 + wpfOVERLAY.PCB_THUMBNAIL_02.Width + 10 + +wpfOVERLAY.PCB_THUMBNAIL_03.Width + 10
            End If

            If wpfOVERLAY.PCB_THUMBNAIL_01.HorizontalAlignment = Windows.HorizontalAlignment.Left Then
                intLEFT += wpfOVERLAY.PCB_SHUTTER.Width + 10 + wpfOVERLAY.PCB_THUMBNAIL_01.Width + 10 + wpfOVERLAY.PCB_THUMBNAIL_02.Width + 10 + +wpfOVERLAY.PCB_THUMBNAIL_03.Width + 10
            End If
        End If

        With wpfOVERLAY.PCB_COLOR_INFO.Margin
            Dim mrgSET As Windows.Thickness
            mrgSET = New Windows.Thickness(.Left + intLEFT, .Top, .Right + intRIGHT, .Bottom)
            wpfOVERLAY.PCB_COLOR_INFO.Margin = mrgSET
        End With

    End Sub

    Private Sub SUB_VISIBLE_OVERLAY_WPF_THUMBNAIL()
        Dim enmVisibility As System.Windows.Visibility
        Dim enmVA As System.Windows.VerticalAlignment
        Dim enmHA As System.Windows.HorizontalAlignment

        Dim intRIGHT As Integer
        Dim intLEFT As Integer

        With srtCAPT_SETTINGS
            enmVisibility = FUNC_GET_VISIBILITY(.OVERLAY_THUMBNAIL)
            enmVA = FUNC_GET_VA(.OVERLAY_THUMBNAIL_ALIGNMENT)
            enmHA = FUNC_GET_HA(.OVERLAY_THUMBNAIL_ALIGNMENT)
        End With

        wpfOVERLAY.PCB_THUMBNAIL_01.Visibility = enmVisibility
        wpfOVERLAY.PCB_THUMBNAIL_02.Visibility = enmVisibility
        wpfOVERLAY.PCB_THUMBNAIL_03.Visibility = enmVisibility
        wpfOVERLAY.PCB_SHUTTER.Visibility = enmVisibility
        wpfOVERLAY.PCB_SHUTTER_JPEG.Visibility = enmVisibility

        wpfOVERLAY.PCB_THUMBNAIL_01.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_THUMBNAIL_02.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_THUMBNAIL_03.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_SHUTTER.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_SHUTTER_JPEG.VerticalAlignment = enmVA

        wpfOVERLAY.PCB_THUMBNAIL_01.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_THUMBNAIL_02.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_THUMBNAIL_03.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_SHUTTER.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_SHUTTER_JPEG.HorizontalAlignment = enmHA

        intRIGHT = 0
        intLEFT = 0

        If wpfOVERLAY.PCB_BUTTON_CLOSE.Visibility = Windows.Visibility.Visible And wpfOVERLAY.PCB_BUTTON_CLOSE.VerticalAlignment = wpfOVERLAY.PCB_THUMBNAIL_01.VerticalAlignment Then
            If wpfOVERLAY.PCB_BUTTON_CLOSE.HorizontalAlignment = Windows.HorizontalAlignment.Right Then
                intRIGHT += wpfOVERLAY.PCB_BUTTON_CLOSE.Width + 10
            End If

            If wpfOVERLAY.PCB_BUTTON_CLOSE.HorizontalAlignment = Windows.HorizontalAlignment.Left Then
                intLEFT += wpfOVERLAY.PCB_BUTTON_CLOSE.Width + 10
            End If
        End If

        If wpfOVERLAY.PCB_PARAM.Visibility = Windows.Visibility.Visible And wpfOVERLAY.PCB_PARAM.VerticalAlignment = wpfOVERLAY.PCB_THUMBNAIL_01.VerticalAlignment Then
            If wpfOVERLAY.PCB_PARAM.HorizontalAlignment = Windows.HorizontalAlignment.Right Then
                intRIGHT += wpfOVERLAY.PCB_PARAM.Width + 10
            End If

            If wpfOVERLAY.PCB_PARAM.HorizontalAlignment = Windows.HorizontalAlignment.Left Then
                intLEFT += wpfOVERLAY.PCB_PARAM.Width + 10
            End If
        End If

        With wpfOVERLAY.PCB_THUMBNAIL_01.Margin
            Dim mrgSET As Windows.Thickness
            mrgSET = New Windows.Thickness(.Left + intLEFT, .Top, .Right + intRIGHT, .Bottom)
            wpfOVERLAY.PCB_THUMBNAIL_01.Margin = mrgSET
        End With

        With wpfOVERLAY.PCB_THUMBNAIL_02.Margin
            Dim mrgSET As Windows.Thickness
            mrgSET = New Windows.Thickness(.Left + intLEFT, .Top, .Right + intRIGHT, .Bottom)
            wpfOVERLAY.PCB_THUMBNAIL_02.Margin = mrgSET
        End With

        With wpfOVERLAY.PCB_THUMBNAIL_03.Margin
            Dim mrgSET As Windows.Thickness
            mrgSET = New Windows.Thickness(.Left + intLEFT, .Top, .Right + intRIGHT, .Bottom)
            wpfOVERLAY.PCB_THUMBNAIL_03.Margin = mrgSET
        End With

        With wpfOVERLAY.PCB_SHUTTER.Margin
            Dim mrgSET As Windows.Thickness
            mrgSET = New Windows.Thickness(.Left + intLEFT, .Top, .Right + intRIGHT, .Bottom)
            wpfOVERLAY.PCB_SHUTTER.Margin = mrgSET
        End With

        With wpfOVERLAY.PCB_SHUTTER_JPEG.Margin
            Dim mrgSET As Windows.Thickness
            mrgSET = New Windows.Thickness(.Left + intLEFT, .Top, .Right + intRIGHT, .Bottom)
            wpfOVERLAY.PCB_SHUTTER_JPEG.Margin = mrgSET
        End With

    End Sub

    Private Sub SUB_VISIBLE_OVERLAY_WPF_CAPT_PARAM()

        Dim enmVisibility As System.Windows.Visibility
        Dim enmVA As System.Windows.VerticalAlignment
        Dim enmHA As System.Windows.HorizontalAlignment

        Dim intRIGHT As Integer
        Dim intLEFT As Integer

        With srtCAPT_SETTINGS
            enmVisibility = FUNC_GET_VISIBILITY(.OVERLAY_CAPT_PARAM)
            enmVA = FUNC_GET_VA(.OVERLAY_CAPT_PARAM_ALIGNMENT)
            enmHA = FUNC_GET_HA(.OVERLAY_CAPT_PARAM_ALIGNMENT)
        End With

        wpfOVERLAY.PCB_PARAM.Visibility = enmVisibility

        wpfOVERLAY.PCB_PARAM.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_PARAM.HorizontalAlignment = enmHA

        intRIGHT = 0
        intLEFT = 0

        If wpfOVERLAY.PCB_BUTTON_CLOSE.VerticalAlignment = wpfOVERLAY.PCB_PARAM.VerticalAlignment Then
            If wpfOVERLAY.PCB_BUTTON_CLOSE.HorizontalAlignment = Windows.HorizontalAlignment.Right Then
                intRIGHT += wpfOVERLAY.PCB_BUTTON_CLOSE.Width + 10
            End If

            If wpfOVERLAY.PCB_BUTTON_CLOSE.HorizontalAlignment = Windows.HorizontalAlignment.Left Then
                intLEFT += wpfOVERLAY.PCB_BUTTON_CLOSE.Width + 10
            End If
        End If

        With wpfOVERLAY.PCB_PARAM.Margin
            Dim mrgSET As Windows.Thickness
            mrgSET = New Windows.Thickness(.Left + intLEFT, .Top, .Right + intRIGHT, .Bottom)
            wpfOVERLAY.PCB_PARAM.Margin = mrgSET
        End With

    End Sub

    Private Sub SUB_VISIBLE_OVERLAY_WPF_SHORTCUT()
        Dim enmVisibility As System.Windows.Visibility
        Dim enmVA As System.Windows.VerticalAlignment
        Dim enmHA As System.Windows.HorizontalAlignment

        With srtCAPT_SETTINGS
            enmVisibility = FUNC_GET_VISIBILITY(.OVERLAY_SHORTCUT)
            enmVA = FUNC_GET_VA(.OVERLAY_SHORTCUT_ALIGNMENT)
            enmHA = FUNC_GET_HA(.OVERLAY_SHORTCUT_ALIGNMENT)
        End With

        wpfOVERLAY.PCB_BUTTON_CLOSE.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_COMPOSITION.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_CHANGE_COMPOSITION.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_ROTATE.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_SETTING.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_UI.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_EXPLORER.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_APPEND_IMAGE_LOAD.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_APPEND_IMAGE_CHANGE.Visibility = enmVisibility
        wpfOVERLAY.SLI_APPEND_IMAGE_OPACITY.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_SHUTTER_CONTINUOUS.Visibility = enmVisibility
        wpfOVERLAY.PCB_BUTTON_LIGHT.Visibility = enmVisibility

        wpfOVERLAY.PCB_BUTTON_CLOSE.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_COMPOSITION.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_CHANGE_COMPOSITION.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_ROTATE.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_SETTING.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_UI.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_EXPLORER.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_APPEND_IMAGE_LOAD.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_APPEND_IMAGE_CHANGE.VerticalAlignment = enmVA
        wpfOVERLAY.SLI_APPEND_IMAGE_OPACITY.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_SHUTTER_CONTINUOUS.VerticalAlignment = enmVA
        wpfOVERLAY.PCB_BUTTON_LIGHT.VerticalAlignment = enmVA

        wpfOVERLAY.PCB_BUTTON_CLOSE.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_COMPOSITION.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_CHANGE_COMPOSITION.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_ROTATE.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_SETTING.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_UI.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_EXPLORER.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_APPEND_IMAGE_LOAD.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_APPEND_IMAGE_CHANGE.HorizontalAlignment = enmHA
        wpfOVERLAY.SLI_APPEND_IMAGE_OPACITY.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_SHUTTER_CONTINUOUS.HorizontalAlignment = enmHA
        wpfOVERLAY.PCB_BUTTON_LIGHT.HorizontalAlignment = enmHA
    End Sub

    Private Function FUNC_GET_VA(ByVal enmALIGNMENT As ENM_ALIGNMENT) As System.Windows.VerticalAlignment
        Dim enmRET As System.Windows.VerticalAlignment
        Select Case enmALIGNMENT
            Case ENM_ALIGNMENT.LEFT_TOP
                enmRET = Windows.VerticalAlignment.Top
            Case ENM_ALIGNMENT.RIGHT_TOP
                enmRET = Windows.VerticalAlignment.Top
            Case ENM_ALIGNMENT.LEFT_BOTTOM
                enmRET = Windows.VerticalAlignment.Bottom
            Case ENM_ALIGNMENT.RIGHT_BOTTOM
                enmRET = Windows.VerticalAlignment.Bottom
        End Select

        Return enmRET
    End Function

    Private Function FUNC_GET_HA(ByVal enmALIGNMENT As ENM_ALIGNMENT) As System.Windows.HorizontalAlignment
        Dim enmRET As System.Windows.HorizontalAlignment
        Select Case enmALIGNMENT
            Case ENM_ALIGNMENT.LEFT_TOP
                enmRET = Windows.HorizontalAlignment.Left
            Case ENM_ALIGNMENT.RIGHT_TOP
                enmRET = Windows.HorizontalAlignment.Right
            Case ENM_ALIGNMENT.LEFT_BOTTOM
                enmRET = Windows.HorizontalAlignment.Left
            Case ENM_ALIGNMENT.RIGHT_BOTTOM
                enmRET = Windows.HorizontalAlignment.Right
        End Select

        Return enmRET
    End Function

    Public Sub SUB_REFRESH_OVERLAY_WPF()

        If Not MOD_OVERLAY.STATE_SHOW Then
            Exit Sub
        End If

        Call wpfOVERLAY.SUB_DRAW_COMPOSTION(FUNC_CNV_OCT(srtCAPT_SETTINGS.OVERLAY_COMPOSITION_TYPE))
        Call wpfOVERLAY.SUB_DRAW_PARAMETERS_GUIDE()
        Call wpfOVERLAY.SUB_DRAW_PARAMETERS_VALUE()
        Call wpfOVERLAY.SUB_DRAW_STATE("")
    End Sub

    Public Sub SUB_REFRESH_OVERLAY_STATE_WPF()

        If wpfOVERLAY Is Nothing Then
            Exit Sub
        End If

        Call wpfOVERLAY.SUB_DRAW_STATE(MOD_OVERLAY.PUT_STATE_STR)
    End Sub

    Public Sub SUB_ADD_THUMBNAIL_WPF(ByRef bmpIMAGE As Bitmap, ByRef strFILE_PATH As String)

        If wpfOVERLAY Is Nothing Then
            Exit Sub
        End If

        Call wpfOVERLAY.SUB_SET_THUMBNAIL(bmpIMAGE, strFILE_PATH)

        Dim iarINVOKE As IAsyncResult
        iarINVOKE = FRM_PARENT.BeginInvoke(New WPF_OVERLAY_DELEGATE(AddressOf wpfOVERLAY.SUB_REFRESH_THUMBNAIL))
        Call FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

#Region "内部"

    Private Function FUNC_GET_VISIBILITY(ByVal blnVISIBLE As Boolean) As Windows.Visibility
        Dim enmRET As Windows.Visibility
        If blnVISIBLE Then
            enmRET = Windows.Visibility.Visible
        Else
            enmRET = Windows.Visibility.Hidden
        End If

        Return enmRET
    End Function


    Private Sub SUB_SET_SIZE_OVERLAY_WPF(ByRef wpfOVERLAY As System.Windows.Window)
        Dim srtRECT As RECT
        Dim intWINDOW_WIDTH As Integer
        Dim intWINDOW_HEIGHT As Integer

        srtRECT = FUNC_GET_CRIENT_RECT(prcTARGET)
        intWINDOW_WIDTH = FUNC_GET_RECT_WIDTH(srtRECT)
        intWINDOW_HEIGHT = FUNC_GET_RECT_HEIGHT(srtRECT)

        Try
            wpfOVERLAY.Width = intWINDOW_WIDTH
            wpfOVERLAY.Height = intWINDOW_HEIGHT
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SUB_SET_LOCATION_OVERLAY_WPF(ByRef wpfOVERLAY As System.Windows.Window, enmPOSITION_OVERLAY As ENM_POSITION_OVERLAY)
        Dim pntLOCATION As System.Drawing.Point
        Dim srtRECT As RECT
        Dim intWINDOW_LEFT As Integer
        Dim intWINDOW_TOP As Integer
        Dim intWINDOW_WIDTH As Integer
        Dim intWINDOW_HEIGHT As Integer
        Dim intCLIENT_WIDTH As Integer
        Dim intCLIENT_HEIGHT As Integer

        Dim intWIDTH_SUB As Integer
        Dim intHEIGHT_SUB As Integer
        Dim intBORDER As Integer

        Dim intLEFT As Integer
        Dim intTOP As Integer

        If enmPOSITION_OVERLAY = ENM_POSITION_OVERLAY.UNKNOWN Then
            Exit Sub
        End If

        srtRECT = FUNC_GET_WINDOW_RECT(prcTARGET)
        intWINDOW_LEFT = srtRECT.left
        intWINDOW_TOP = srtRECT.top
        intWINDOW_WIDTH = FUNC_GET_RECT_WIDTH(srtRECT)
        intWINDOW_HEIGHT = FUNC_GET_RECT_HEIGHT(srtRECT)

        srtRECT = FUNC_GET_CRIENT_RECT(prcTARGET)
        intCLIENT_WIDTH = FUNC_GET_RECT_WIDTH(srtRECT)
        intCLIENT_HEIGHT = FUNC_GET_RECT_HEIGHT(srtRECT)

        intWIDTH_SUB = intWINDOW_WIDTH - intCLIENT_WIDTH
        intHEIGHT_SUB = intWINDOW_HEIGHT - intCLIENT_HEIGHT

        intBORDER = Math.Floor(intWIDTH_SUB / 2)
        intWINDOW_LEFT += intBORDER
        intWINDOW_TOP += (intHEIGHT_SUB - intBORDER)

        Select Case enmPOSITION_OVERLAY
            Case ENM_POSITION_OVERLAY.CENTER
                intLEFT = CInt(CDec(intWINDOW_WIDTH / 2) - CDec(wpfOVERLAY.Width / 2))
                intTOP = CInt(CDec(intWINDOW_HEIGHT / 2) - CDec(wpfOVERLAY.Height / 2))
            Case ENM_POSITION_OVERLAY.LEFT_TOP
                intLEFT = 0
                intTOP = 0
            Case ENM_POSITION_OVERLAY.LEFT_BOTTOM
                intLEFT = 0
                intTOP = intWINDOW_HEIGHT - wpfOVERLAY.Height
            Case ENM_POSITION_OVERLAY.RIGHT_TOP
                intLEFT = intWINDOW_WIDTH - wpfOVERLAY.Width
                intTOP = 0
            Case ENM_POSITION_OVERLAY.RIGHT_BOTTOM
                intLEFT = intWINDOW_WIDTH - wpfOVERLAY.Width
                intTOP = intWINDOW_HEIGHT - wpfOVERLAY.Height
            Case Else
                intLEFT = 0
                intTOP = 0
        End Select

        intLEFT += intWINDOW_LEFT
        intTOP += intWINDOW_TOP

        pntLOCATION = New System.Drawing.Point(intLEFT, intTOP)
        Try
            wpfOVERLAY.Left = intLEFT
            wpfOVERLAY.Top = intTOP
        Catch ex As Exception

        End Try
    End Sub
#End Region

#End Region

#Region "共有内部処理"
    Private Function FUNC_CNV_OCT(ByVal intSETTING As Integer) As ENM_DIVISION_PATTERN
        Dim enmRET As ENM_DIVISION_PATTERN

        Select Case intSETTING
            Case 0
                enmRET = ENM_DIVISION_PATTERN.TWO_DIV
            Case 1
                enmRET = ENM_DIVISION_PATTERN.THREE_DIV
            Case 2
                enmRET = ENM_DIVISION_PATTERN.QUAD_DIV
            Case 3
                enmRET = ENM_DIVISION_PATTERN.THREE_DIV_PHI
            Case 4
                enmRET = ENM_DIVISION_PATTERN.RATE_16_TO_9
            Case 5
                enmRET = ENM_DIVISION_PATTERN.RATE_3_TO_2
            Case 6
                enmRET = ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_L
            Case 7
                enmRET = ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_R
            Case Else
                enmRET = ENM_DIVISION_PATTERN.THREE_DIV
        End Select

        Return enmRET
    End Function
#End Region

End Module
