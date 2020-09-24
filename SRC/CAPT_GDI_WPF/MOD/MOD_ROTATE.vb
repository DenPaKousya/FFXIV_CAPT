Public Delegate Sub MOD_ROTATE_DELEGATE()
Friend Module MOD_ROTATE

#Region "モジュール用・定数"
    'Public Const cstHEIGHT_SUB_FORM As Integer = 40
    'Public Const cstWIDTH_SUB_FORM As Integer = 16
    Public Const cstHEIGHT_SUB_FORM As Integer = 4
    Public Const cstWIDTH_SUB_FORM As Integer = 0
    'Public Const cstSHUTTER_POS_Y_SUB As Integer = 60
#End Region

#Region "モジュール用・変数"
    Friend FRM_PARENT As FRM_MAIN

    Private wpfSHOW As WPF_ROTATE

    Friend ENM_FLIP_ROTATE As RotateFlipType = RotateFlipType.Rotate270FlipXY

    Friend IMG_PRIVATE_ROTATE As System.Drawing.Bitmap
    Friend GRP_PRIVATE_ROTATE As Graphics
    Friend IMG_PRIVATE_ROTATE_THUM As System.Drawing.Bitmap
    'Friend IMS_PRIVATE_ROTATE_THUM As System.Windows.Media.ImageSource
    Friend INT_ROTATE_WIDTH As Integer
    Friend INT_ROTATE_HEIGHT As Integer
#End Region

    Public Sub SUB_RECALL_ROTATE(ByRef frmPARENT As FRM_MAIN)

        MOD_ROTATE.FRM_PARENT = frmPARENT

        If FUNC_CHECK_FRM_WPF() Then
            Call SUB_CLOSE_ROTATE_WPF()
            Call SUB_SHOW_ROTATE_WPF()
        End If

    End Sub

    Public Sub SUB_CALL_ROTATE(ByRef frmPARENT As FRM_MAIN)

        MOD_ROTATE.FRM_PARENT = frmPARENT

        If FUNC_CHECK_FRM_WPF() Then
            Call SUB_CLOSE_ROTATE_WPF()
        Else
            Call SUB_SHOW_ROTATE_WPF()
        End If
    End Sub

#Region "WPF"
    Public Sub SUB_CLOSE_ROTATE_WPF()

        If wpfSHOW Is Nothing Then
            Exit Sub
        End If

        Try
            Call wpfSHOW.Close()
            wpfSHOW = Nothing
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Friend Sub SUB_RESIZE_WINDOW_WPF(ByRef wpfRESIZE As WPF_ROTATE)
        Dim rctPROCESS_CLIENT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT
        Dim intHEIGHT As Integer
        Dim intWIDTH As Integer
        Dim decRATE As Decimal
        Dim intWIDTH_SET As Integer
        Dim intMAX_HEIGHT As Integer

        rctPROCESS_CLIENT = FUNC_GET_CRIENT_RECT(prcTARGET)

        intHEIGHT = FUNC_GET_RECT_HEIGHT(rctPROCESS_CLIENT)
        intWIDTH = FUNC_GET_RECT_WIDTH(rctPROCESS_CLIENT)

        If intHEIGHT <= 0 Or intWIDTH <= 0 Then
            Exit Sub
        End If

        intMAX_HEIGHT = wpfRESIZE.ActualHeight - cstHEIGHT_SUB_FORM
        If intMAX_HEIGHT < 0 Then
            intMAX_HEIGHT = 0
        End If
        If wpfRESIZE.PCB_ROTATE.Height <> intMAX_HEIGHT Then
            wpfRESIZE.PCB_ROTATE.Height = intMAX_HEIGHT
        End If

        If wpfRESIZE.PCB_ROTATE.Height > 0 Then
            decRATE = intWIDTH / wpfRESIZE.PCB_ROTATE.Height
            intWIDTH_SET = intHEIGHT / decRATE
        Else
            intWIDTH_SET = 0
        End If

        If wpfRESIZE.PCB_ROTATE.Width = intWIDTH_SET Then
            Exit Sub
        End If

        wpfRESIZE.PCB_ROTATE.Width = intWIDTH_SET

        srtCAPT_SETTINGS.ROTATE_SIZE_W = wpfRESIZE.PCB_ROTATE.Width
        srtCAPT_SETTINGS.ROTATE_SIZE_H = wpfRESIZE.PCB_ROTATE.Height
    End Sub

    Private BLN_SET_ACTIVATE As Boolean = False
    Public Sub SUB_SET_TOPMOST_ROTATE(ByVal BLN_TOPMOST As Boolean, ByVal BLN_ACTIVATE As Boolean)
        If wpfSHOW Is Nothing Then
            Exit Sub
        End If
        If wpfSHOW.Topmost = BLN_TOPMOST Then
            Exit Sub
        End If

        wpfSHOW.Topmost = BLN_TOPMOST
        If Not BLN_TOPMOST Then
            BLN_SET_ACTIVATE = False
        End If
        If BLN_TOPMOST And BLN_ACTIVATE Then
            Call wpfSHOW.Activate()
            BLN_SET_ACTIVATE = True
        End If
    End Sub

    Public Function FUNC_GET_HANDLE_ROTATE() As IntPtr
        If wpfSHOW Is Nothing Then
            Return IntPtr.Zero
        End If

        Dim HLP_WINDOW As System.Windows.Interop.WindowInteropHelper
        Dim INT_RET As IntPtr
        HLP_WINDOW = New System.Windows.Interop.WindowInteropHelper(wpfSHOW)
        INT_RET = HLP_WINDOW.Handle
        Return INT_RET
    End Function

#Region "内部"
    Private Function FUNC_CHECK_FRM_WPF()
        If wpfSHOW Is Nothing Then
            Return False
        End If

        If wpfSHOW.CHECK_CLOSED Then
            Return False
        End If

        Return True
    End Function

    Private Sub SUB_SHOW_ROTATE_WPF()

        'If wpfSHOW Is Nothing Then
        wpfSHOW = New WPF_ROTATE
        'End If

        wpfSHOW.Title = "回転イメージ"
        wpfSHOW.Left = srtCAPT_SETTINGS.ROTATE_POSITION_X
        wpfSHOW.Top = srtCAPT_SETTINGS.ROTATE_POSITION_Y

        wpfSHOW.Width = srtCAPT_SETTINGS.ROTATE_SIZE_W + cstWIDTH_SUB_FORM
        wpfSHOW.Height = srtCAPT_SETTINGS.ROTATE_SIZE_H + cstHEIGHT_SUB_FORM
        Call SUB_RESIZE_WINDOW_WPF(wpfSHOW)

        Call wpfSHOW.SUB_REFRESH_IMAGE()
        Call wpfSHOW.Show()

        wpfSHOW.Topmost = True
        Call SUB_FOREGROUND_WINDOW(prcTARGET)

    End Sub
#End Region

#End Region

#Region "内部共通"

    Private Function dummy() As Boolean
        Return False
    End Function

    Friend Sub SUB_MAKE_THUMBNAIL()
        IMG_PRIVATE_ROTATE_THUM = IMG_PRIVATE_ROTATE.GetThumbnailImage(INT_ROTATE_HEIGHT, INT_ROTATE_WIDTH, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf dummy), IntPtr.Zero)
        Call IMG_PRIVATE_ROTATE_THUM.RotateFlip(ENM_FLIP_ROTATE)
    End Sub

#End Region

End Module
