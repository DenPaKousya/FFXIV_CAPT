Friend Module MOD_TRIM

#Region "モジュール用変数"
    Friend FRM_PARENT As FRM_MAIN
    Private WPF_MY_WINDOW As WPF_TRIM

#End Region

#Region "PUBLIC"

    Public Sub SUB_CALL_TRIM(ByRef FRM_CALL As FRM_MAIN)
        If FUNC_CHECK_WINDOW() Then
            Call SUB_CLOSE_TRIM()
        Else
            Call SUB_SHOW_TRIM(FRM_CALL)
        End If
    End Sub

    Public Sub SUB_RECALL_TRIM(ByRef FRM_CALL As FRM_MAIN)

        If Not FUNC_CHECK_WINDOW() Then
            Exit Sub
        End If

        Call SUB_CLOSE_TRIM()
        Call SUB_SHOW_TRIM(FRM_CALL)
    End Sub

    Public Sub SUB_SHOW_TRIM(ByRef FRM_CALL As FRM_MAIN)
        If prcTARGET Is Nothing Then
            Exit Sub
        End If

        If FUNC_CHECK_WINDOW() Then
            Exit Sub
        End If

        MOD_TRIM.FRM_PARENT = FRM_CALL

        WPF_MY_WINDOW = New WPF_TRIM

        Call SUB_SET_LOCATION_OVERLAY_WPF(WPF_MY_WINDOW, ENM_POSITION_OVERLAY.LEFT_TOP)
        Call WPF_MY_WINDOW.SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.THREE_DIV)
        WPF_MY_WINDOW.Background = New SolidColorBrush(Windows.Media.Color.FromArgb(16, 0, 0, 255))
        Call WPF_MY_WINDOW.Show()
        Call WPF_MY_WINDOW.SUB_CHANGE_RATE(WPF_TRIM.ENM_WINDOW_RATE.RATE_FREE)
        Call WPF_MY_WINDOW.SUB_SET_SIZE_WINDOW()

        WPF_MY_WINDOW.Topmost = True

        Call SUB_FOREGROUND_WINDOW(prcTARGET)
    End Sub

    Public Sub SUB_CLOSE_TRIM()

        If Not FUNC_CHECK_WINDOW() Then
            Exit Sub
        End If

        Try
            Call WPF_MY_WINDOW.Close()
            WPF_MY_WINDOW = Nothing
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Public Function FUNC_GET_SIZE_TRIMING(ByVal BASE As RECT_WH) As RECT_WH
        Dim intWINDOW_LEFT As Integer
        Dim intWINDOW_TOP As Integer
        intWINDOW_LEFT = FUNC_GET_LEFT_WINDOW(prcTARGET)
        intWINDOW_TOP = FUNC_GET_TOP_WINDOW(prcTARGET)

        'If intWINDOW_LEFT <> 0 Then
        '    intWINDOW_LEFT += 8
        'End If
        'If intWINDOW_TOP <> 0 Then
        '    intWINDOW_TOP -= 2
        'End If

        If intWINDOW_LEFT <> 0 Then
            intWINDOW_LEFT += 3
        End If
        If intWINDOW_TOP <> 0 Then
            intWINDOW_TOP -= 3
        End If


        Dim size As RECT_WH
        'size.left = CInt(BASE.left) - (intWINDOW_LEFT + 8)
        'size.top = CInt(BASE.top) - (intWINDOW_TOP - 2)
        size.left = CInt(BASE.left) - (intWINDOW_LEFT + 0)
        size.top = CInt(BASE.top) - (intWINDOW_TOP - 0)
        size.width = CInt(BASE.width)
        size.height = CInt(BASE.height)
        If size.left < 0 Then
            size.width += size.left
            size.left = 0
        End If
        If size.top < 0 Then
            size.height += size.top
            size.top = 0
        End If

        Return size
    End Function

    Private BLN_SET_ACTIVATE As Boolean = False
    Public Sub SUB_SET_TOPMOST_TRIM(ByVal BLN_TOPMOST As Boolean, ByVal BLN_ACTIVATE As Boolean)
        If WPF_MY_WINDOW Is Nothing Then
            Exit Sub
        End If
        'If WPF_MY_WINDOW.Topmost = BLN_TOPMOST Then
        '    Exit Sub
        'End If

        WPF_MY_WINDOW.Topmost = BLN_TOPMOST
        If Not BLN_TOPMOST Then
            BLN_SET_ACTIVATE = False
        End If
        If BLN_TOPMOST And BLN_ACTIVATE And Not BLN_SET_ACTIVATE Then
            Call WPF_MY_WINDOW.Activate()
            BLN_SET_ACTIVATE = True
        End If
    End Sub

    Public Function FUNC_GET_HANDLE_TRIM() As IntPtr
        If WPF_MY_WINDOW Is Nothing Then
            Return IntPtr.Zero
        End If

        Dim HLP_WINDOW As System.Windows.Interop.WindowInteropHelper
        Dim INT_RET As IntPtr
        HLP_WINDOW = New System.Windows.Interop.WindowInteropHelper(WPF_MY_WINDOW)
        INT_RET = HLP_WINDOW.Handle
        Return INT_RET
    End Function
#End Region

#Region "FRIEND"
    Friend Function FUNC_CHECK_WINDOW_TRIM()
        Return FUNC_CHECK_WINDOW()
    End Function

    Friend Function FUNC_GET_SIZE_WINDOW_TRIM() As RECT_WH
        Dim RET_SIZE As RECT_WH
        With RET_SIZE
            .top = 0
            .left = 0
            .height = 0
            .width = 0
        End With

        If WPF_MY_WINDOW Is Nothing Then
            Return RET_SIZE
        End If

        RET_SIZE = WPF_MY_WINDOW.SIZ_WINDOW
        Return RET_SIZE
    End Function
#End Region

#Region "PRIVATE"
    Private Function FUNC_CHECK_WINDOW()
        If WPF_MY_WINDOW Is Nothing Then
            Return False
        End If

        If WPF_MY_WINDOW.CHECK_CLOSED Then
            Return False
        End If

        Return True
    End Function
#End Region

End Module
