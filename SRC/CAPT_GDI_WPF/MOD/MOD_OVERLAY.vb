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

    Private BLN_SET_ACTIVATE As Boolean = False
    Public Sub SUB_SET_TOPMOST_OVERLAY(ByVal BLN_TOPMOST As Boolean, ByVal BLN_ACTIVATE As Boolean)
        If wpfOVERLAY Is Nothing Then
            Exit Sub
        End If

        If wpfOVERLAY.Topmost = BLN_TOPMOST Then
            Exit Sub
        End If

        wpfOVERLAY.Topmost = BLN_TOPMOST
        If Not BLN_TOPMOST Then
            BLN_SET_ACTIVATE = False
        End If
        If BLN_TOPMOST And BLN_ACTIVATE And Not BLN_SET_ACTIVATE Then
            Call wpfOVERLAY.Activate()
            BLN_SET_ACTIVATE = True
        End If
    End Sub

    Public Function FUNC_GET_HANDLE_OVERLAY() As IntPtr
        If wpfOVERLAY Is Nothing Then
            Return IntPtr.Zero
        End If

        Dim HLP_WINDOW As System.Windows.Interop.WindowInteropHelper
        Dim INT_RET As IntPtr
        HLP_WINDOW = New System.Windows.Interop.WindowInteropHelper(wpfOVERLAY)
        INT_RET = HLP_WINDOW.Handle
        Return INT_RET
    End Function

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

        Dim CTL_BUTTONS() As Controls.Button
        ReDim CTL_BUTTONS(15)
        With wpfOVERLAY
            CTL_BUTTONS(1) = .PCB_BUTTON_CLOSE
            CTL_BUTTONS(2) = .PCB_BUTTON_COMPOSITION
            CTL_BUTTONS(3) = .PCB_BUTTON_CHANGE_COMPOSITION
            CTL_BUTTONS(4) = .PCB_BUTTON_ROTATE
            CTL_BUTTONS(5) = .PCB_BUTTON_TRIM
            CTL_BUTTONS(6) = .PCB_BUTTON_SETTING
            CTL_BUTTONS(7) = .PCB_BUTTON_UI
            CTL_BUTTONS(8) = .PCB_BUTTON_EXPLORER
            CTL_BUTTONS(9) = .PCB_BUTTON_SHUTTER_CONTINUOUS
            CTL_BUTTONS(10) = .PCB_BUTTON_LOGO
            CTL_BUTTONS(11) = .PCB_BUTTON_THUMNAIL
            CTL_BUTTONS(12) = .PCB_BUTTON_AEB
            CTL_BUTTONS(13) = .PCB_BUTTON_LIGHT
            CTL_BUTTONS(14) = .PCB_BUTTON_APPEND_IMAGE_LOAD
            CTL_BUTTONS(15) = .PCB_BUTTON_APPEND_IMAGE_CHANGE
        End With

        Dim CTL_SLIDERS() As Controls.Slider
        ReDim CTL_SLIDERS(15)
        With wpfOVERLAY
            CTL_SLIDERS(1) = Nothing
            CTL_SLIDERS(2) = Nothing
            CTL_SLIDERS(3) = Nothing
            CTL_SLIDERS(4) = Nothing
            CTL_SLIDERS(5) = Nothing
            CTL_SLIDERS(6) = Nothing
            CTL_SLIDERS(7) = Nothing
            CTL_SLIDERS(8) = Nothing
            CTL_SLIDERS(9) = Nothing
            CTL_SLIDERS(10) = Nothing
            CTL_SLIDERS(11) = Nothing
            CTL_SLIDERS(12) = Nothing
            CTL_SLIDERS(13) = Nothing
            CTL_SLIDERS(14) = Nothing
            CTL_SLIDERS(15) = .SLI_APPEND_IMAGE_OPACITY
        End With

        Const CST_X_INIT As Integer = 10
        Const CST_Y_INIT As Integer = 10

        Dim INT_X As Integer
        INT_X = CST_X_INIT

        Dim INT_Y As Integer
        INT_Y = CST_Y_INIT

        Const CST_MARGIN As Integer = 0
        Dim INT_BUTTON_SIZE As Integer
        INT_BUTTON_SIZE = 45

        For i = 1 To (CTL_BUTTONS.Length - 1)
            With CTL_BUTTONS(i)
                .Visibility = enmVisibility
                .VerticalAlignment = enmVA
                .HorizontalAlignment = enmHA
                .Margin = FUNC_GET_THICKNESE(enmVA, enmHA, INT_X, INT_Y)
                .Height = INT_BUTTON_SIZE
                .Width = INT_BUTTON_SIZE
            End With

            If Not (CTL_SLIDERS(i) Is Nothing) Then
                With CTL_SLIDERS(i)
                    .Visibility = enmVisibility
                    .VerticalAlignment = enmVA
                    .HorizontalAlignment = enmHA
                    Dim INT_X_ADD As Integer
                    INT_X_ADD = CTL_BUTTONS(i).Width + CST_MARGIN
                    Dim INT_Y_ADD As Integer
                    INT_Y_ADD = CInt((CTL_BUTTONS(i).Height - .Height) / 2)

                    .Margin = FUNC_GET_THICKNESE(enmVA, enmHA, INT_X + INT_X_ADD, INT_Y + INT_Y_ADD)
                End With
            End If

            INT_X += 0
            INT_Y += CTL_BUTTONS(i).Height + CST_MARGIN
        Next
    End Sub

    Private Function FUNC_GET_THICKNESE(ByVal ENM_VA As System.Windows.VerticalAlignment, ByVal ENM_HA As System.Windows.HorizontalAlignment, ByVal INT_X As Integer, ByVal INT_Y As Integer)
        Dim INT_TOP As Integer
        Dim INT_BUTTOM As Integer
        Select Case ENM_VA
            Case VerticalAlignment.Top
                INT_TOP = INT_Y
                INT_BUTTOM = 0
            Case VerticalAlignment.Bottom
                INT_TOP = 0
                INT_BUTTOM = INT_Y
            Case Else
                INT_TOP = 0
                INT_BUTTOM = 0
        End Select

        Dim INT_LEFT As Integer
        Dim INT_RIGHT As Integer
        Select Case ENM_HA
            Case Windows.HorizontalAlignment.Left
                INT_LEFT = INT_X
                INT_RIGHT = 0
            Case Windows.HorizontalAlignment.Right
                INT_LEFT = 0
                INT_RIGHT = INT_X
            Case Else
                INT_LEFT = 0
                INT_RIGHT = 0
        End Select

        Dim THK_RET As Thickness
        THK_RET = New Thickness(INT_LEFT, INT_TOP, INT_RIGHT, INT_BUTTOM)

        Return THK_RET
    End Function

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
        Dim srtRECT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT
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

#End Region

#End Region

#Region "共有内部処理"
    Private Function FUNC_CNV_OCT(ByVal INT_SETTING As Integer) As ENM_DIVISION_PATTERN
        Dim enmRET As ENM_DIVISION_PATTERN

        Select Case INT_SETTING
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
                enmRET = ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HLL
            Case 7
                enmRET = ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HUR
            Case 8
                enmRET = ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HUL
            Case 9
                enmRET = ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HLR
            Case Else
                enmRET = ENM_DIVISION_PATTERN.THREE_DIV
        End Select

        Return enmRET
    End Function
#End Region

End Module
