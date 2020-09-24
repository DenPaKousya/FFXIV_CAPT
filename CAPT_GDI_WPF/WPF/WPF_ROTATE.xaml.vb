Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Threading

Public Delegate Sub WPF_ROTATE_DELEGATE()
Class WPF_ROTATE

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_VIEW_GUIDE
        DO_WINDOW_CLOSE
        DO_WINDOW_MAX
        DO_CHANGE_SIZE
        DO_SHUTTER
        DO_SHUTTER_JPEG
        DO_CHANGE_ROTATE
        DO_KEY_W
        DO_KEY_A
        DO_KEY_S
        DO_KEY_D
        DO_KEY_ALLOW_UP
        DO_KEY_ALLOW_LEFT
        DO_KEY_ALLOW_DOWN
        DO_KEY_ALLOW_RIGHT
        DO_KEY_PAGE_UP
        DO_KEY_PAGE_DOWN
    End Enum
#End Region

#Region "画面用・変数"
    Private TIM_PRIVATE_TIMER As System.Timers.Timer
    Private BLN_PROCESS_DOING As Boolean
    Private BLN_CHANGE_THUM As Boolean = True
#End Region

#Region "プロパティ用変数"
    Private blnPROPETY_CHECK_CLOSED As Boolean = False
    Private BLN_PROPERTY_GUIDE_VISIBLE As Boolean = False
#End Region

#Region "プロパティ"
    Public Property CHECK_CLOSED As Boolean
        Get
            Return blnPROPETY_CHECK_CLOSED
        End Get
        Set(ByVal value As Boolean)
            blnPROPETY_CHECK_CLOSED = value
        End Set
    End Property

    Public Property GUIDE_VISIBLE As Boolean
        Get
            Return BLN_PROPERTY_GUIDE_VISIBLE
        End Get
        Set(ByVal value As Boolean)
            BLN_PROPERTY_GUIDE_VISIBLE = value
        End Set
    End Property

    'Public Property TICK_GET_IMAGE As Boolean
    '    Get
    '        Return False
    '        'Return timGET_IMAGE.Enabled
    '    End Get
    '    Set(ByVal value As Boolean)
    '        'timGET_IMAGE.Enabled = value
    '    End Set
    'End Property
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_INIT_BMP_IMAGE()
        ENM_FLIP_ROTATE = RotateFlipType.Rotate270FlipXY
        IMG_PRIVATE_ROTATE = FUNC_GET_CLIENT_DEFAULT_IMAGE(True)
        GRP_PRIVATE_ROTATE = System.Drawing.Graphics.FromImage(IMG_PRIVATE_ROTATE)
    End Sub

    Private Sub SUB_INIT_ROTATE_VIEW()
        Call SUB_RE_PRINT_WINDOW()
        Call SUB_INIT_ROTATE_VIEW_BMP()
    End Sub

    Private BLN_LOCCK_BMP As Boolean = False
    Private Sub SUB_INIT_ROTATE_VIEW_BMP()
        BLN_LOCCK_BMP = True
        BMP_SOURCE = FUNC_GET_IMAGESOURCE(IMG_PRIVATE_ROTATE_THUM)
        BMP_ROTATE = New WriteableBitmap(BMP_SOURCE)
        PCB_ROTATE.Source = BMP_ROTATE
        BLN_CHANGE_THUM = False
        BLN_LOCCK_BMP = False
    End Sub

    Private Sub SUB_ROTATE_CONTROL()
        PCB_ROTATE.RenderTransform = New RotateTransform(90, 0, 0) 'PCB_ROTATE.Width / 2, PCB_ROTATE.Height / 2)
    End Sub

    Private Sub SUB_INIT_BUTTONS()
        Dim STR_EXE As String
        STR_EXE = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim STR_DIR As String
        STR_DIR = FUNC_PATH_TO_DIR_PATH(STR_EXE)
        'Call SUB_INIT_CHANGE_IMAGE(STR_DIR & "\RES\IMG\ROTATE")
        'Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_CLOSE, "CLOSE.png")
        'Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_ROTATE, "ROTATE.png")
        'Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_SHUTTER, "SHUTTER_C_W.png")
        'Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_SHUTTER_JPEG, "SHUTTER_C_G.png")
    End Sub
#End Region

#Region "各処理呼出元"
    Private Sub SUB_EXEC_DO(
    ByVal ENM_EXEC_DO As ENM_MY_EXEC_DO
    )
        If BLN_PROCESS_DOING Then
            Exit Sub
        End If

        Me.Cursor = Cursors.Wait
        BLN_PROCESS_DOING = True

        Select Case ENM_EXEC_DO
            Case ENM_MY_EXEC_DO.DO_VIEW_GUIDE
                Call SUB_VIEW_GUIDE()
            Case ENM_MY_EXEC_DO.DO_CHANGE_SIZE
                Call SUB_CHANGE_SIZE()
            Case ENM_MY_EXEC_DO.DO_WINDOW_CLOSE
                Call SUB_WINDWO_CLOSE()
            Case ENM_MY_EXEC_DO.DO_WINDOW_MAX
                Call SUB_WINDWO_MAX()
            Case ENM_MY_EXEC_DO.DO_CHANGE_ROTATE
                Call SUB_CHANGE_ROTATE()
            Case ENM_MY_EXEC_DO.DO_SHUTTER
                Call SUB_SHUTTER()
            Case ENM_MY_EXEC_DO.DO_SHUTTER_JPEG
                Call SUB_SHUTTER_JPEG()
            Case ENM_MY_EXEC_DO.DO_KEY_W
                Call SUB_KEY_W()
            Case ENM_MY_EXEC_DO.DO_KEY_A
                Call SUB_KEY_A()
            Case ENM_MY_EXEC_DO.DO_KEY_S
                Call SUB_KEY_S()
            Case ENM_MY_EXEC_DO.DO_KEY_D
                Call SUB_KEY_D()
            Case ENM_MY_EXEC_DO.DO_KEY_ALLOW_UP
                Call SUB_KEY_ALLOW_UP()
            Case ENM_MY_EXEC_DO.DO_KEY_ALLOW_LEFT
                Call SUB_KEY_ALLOW_LEFT()
            Case ENM_MY_EXEC_DO.DO_KEY_ALLOW_DOWN
                Call SUB_KEY_ALLOW_DOWN()
            Case ENM_MY_EXEC_DO.DO_KEY_ALLOW_RIGHT
                Call SUB_KEY_ALLOW_RIGHT()
            Case ENM_MY_EXEC_DO.DO_KEY_PAGE_UP
                Call SUB_KEY_PAGE_UP()
            Case ENM_MY_EXEC_DO.DO_KEY_PAGE_DOWN
                Call SUB_KEY_PAGE_DOWN()
        End Select

        BLN_PROCESS_DOING = False
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

#Region "実行処理群"
    Private Sub SUB_VIEW_GUIDE()
        Call SUB_VISIBLE_GUIDE(Not Me.GUIDE_VISIBLE)
    End Sub

    Private Sub SUB_WINDWO_CLOSE()
        Call Me.Close()
    End Sub

    Private Sub SUB_WINDWO_MAX()
        Dim WST_CURRENT As System.Windows.WindowState
        WST_CURRENT = Me.WindowState

        Dim WST_SET As System.Windows.WindowState
        If WST_CURRENT = WindowState.Maximized Then
            WST_SET = WindowState.Normal
        Else
            WST_SET = WindowState.Maximized
        End If

        Me.WindowState = WST_SET
    End Sub

    Private Sub SUB_CHANGE_SIZE()

        Dim INT_SET_SIZE As Integer
        Select Case srtCAPT_SETTINGS.ROTATE_BUTTON_SIZE
            Case 64
                INT_SET_SIZE = 96
            Case 96
                INT_SET_SIZE = 128
            Case 128
                INT_SET_SIZE = 64
            Case Else
                INT_SET_SIZE = 64
        End Select

        Call SUB_INIT_SIZE_PCB(INT_SET_SIZE)
    End Sub

    Private Sub SUB_SHUTTER()
        Call SUB_CAPTURE(False)
    End Sub

    Private Sub SUB_SHUTTER_JPEG()
        Call SUB_CAPTURE(True)
    End Sub

    Private Sub SUB_CAPTURE(ByVal BLN_JPEG As Boolean)
        If MOD_ROTATE.FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        MOD_ROTATE.FRM_PARENT.FLIP_ROTATE_TYPE = ENM_FLIP_ROTATE '回転を設定
        MOD_ROTATE.FRM_PARENT.FORCE_JPEG = BLN_JPEG

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_ONE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub SUB_CHANGE_ROTATE()
        If ENM_FLIP_ROTATE = RotateFlipType.Rotate270FlipXY Then
            ENM_FLIP_ROTATE = RotateFlipType.Rotate90FlipXY
        Else
            ENM_FLIP_ROTATE = RotateFlipType.Rotate270FlipXY
        End If
    End Sub

    Private Sub SUB_KEY_W()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_W
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_A()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_A
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_S()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_S
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_D()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_D
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_ALLOW_UP()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_ALLOW_UP
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_ALLOW_LEFT()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_ALLOW_LEFT
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_ALLOW_DOWN()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_ALLOW_DOWN
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_ALLOW_RIGHT()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_ALLOW_RIGHT
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_PAGE_UP()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_PAGE_UP
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

    Private Sub SUB_KEY_PAGE_DOWN()
        Dim OBJ_ARRAY(0) As Object
        OBJ_ARRAY(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_PAGE_DOWN
        Dim IAR_INVOKE As IAsyncResult
        IAR_INVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), OBJ_ARRAY)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(IAR_INVOKE)
    End Sub

#End Region

#Region "画面描画関連"

    Private Function dummy() As Boolean
        Return False
    End Function

    Private Sub SUB_DRAW_STRING(ByRef grpDRAW As Graphics, ByVal strVALUE As String, ByVal intSIZE As Integer, ByVal intX As Integer, ByVal intY As Integer)
        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        Dim ff As New System.Drawing.FontFamily("Lucida Console")
        'Dim ff As New FontFamily(Me.FontFamily.Source)

        Call gp.AddString(strVALUE, ff, 0, intSIZE, New System.Drawing.Point(intX, intY), StringFormat.GenericDefault)
        Call grpDRAW.FillPath(System.Drawing.Brushes.Cyan, gp)
        'Call grpDRAW.DrawPath(Pens.Cyan, gp) '文字列の縁を描画する
    End Sub

    Private blnDO_REFRESH As Boolean = False
    Public Sub SUB_REFRESH_IMAGE()
        'PCB_ROTATE.Source = Nothing

        If IMG_PRIVATE_ROTATE_THUM Is Nothing Then
            Exit Sub
        End If

        If blnDO_REFRESH Then
            Exit Sub
        End If

        If blnDO_MAKE_THUMBNAIL Then
            'blnDO_REFRESH = False
            Exit Sub
        End If

        'Exit Sub

        blnDO_REFRESH = True

        Dim stwTIME As Stopwatch
        stwTIME = New System.Diagnostics.Stopwatch
        stwTIME.Start()
        stwTIME.Stop()

        stwTIME.Restart()
        Dim bytRET() As Byte
        bytRET = FUNC_GET_COLOR_ARRAY(IMG_PRIVATE_ROTATE_THUM)
        stwTIME.Stop()
        Call SUB_PUT_TRACE("GET_ARRAY：" & stwTIME.Elapsed.ToString)

        If bytRET Is Nothing Then
            blnDO_REFRESH = False
            Exit Sub
        End If

        'stwTIME.Restart()
        'Dim bytSET(bytRET.Length - 1) As Byte
        ''型のサイズを取得する
        'Dim typeSize As Integer = System.Runtime.InteropServices.Marshal.SizeOf(bytRET.[GetType]().GetElementType())
        'Dim intStep As Integer
        'intStep = 4
        'For i = 0 To bytSET.Length - 1 Step intStep
        '    'bytSET(i) = bytRET(i)
        '    Buffer.BlockCopy(bytRET, i * typeSize, bytSET, i * typeSize, intStep * typeSize)
        'Next
        'stwTIME.Stop()
        'Call SUB_PUT_TRACE("SET_ARRAY：" & stwTIME.Elapsed.ToString)

        If BLN_LOCCK_BMP Then
            blnDO_REFRESH = False
            Exit Sub
        End If

        If BLN_CHANGE_THUM Then
            Call SUB_INIT_ROTATE_VIEW_BMP()
        End If

        stwTIME.Restart()
        Try
            Call BMP_ROTATE.Lock()
        Catch ex As Exception
            blnDO_REFRESH = False
            Exit Sub
        End Try
        Dim stlide As Integer = BMP_ROTATE.PixelWidth * 4
        Call BMP_ROTATE.WritePixels(New Int32Rect(0, 0, BMP_ROTATE.PixelWidth, BMP_ROTATE.PixelHeight), bytRET, stlide, 0, 0)
        'Call BMP_ROTATE.WritePixels(New Int32Rect(0, 0, BMP_ROTATE.PixelWidth, BMP_ROTATE.PixelHeight), bytSET, stlide, 0, 0)
        Call BMP_ROTATE.AddDirtyRect(New System.Windows.Int32Rect(0, 0, BMP_ROTATE.PixelWidth, BMP_ROTATE.PixelHeight))
        Call BMP_ROTATE.Unlock()
        stwTIME.Stop()
        Call SUB_PUT_TRACE("WRITE_PIXEL：" & stwTIME.Elapsed.ToString)

        blnDO_REFRESH = False
    End Sub

    Private blnDO_PRINT_WINDOW As Boolean = False
    Private blnDO_MAKE_THUMBNAIL As Boolean = False
    Private Sub SUB_RE_PRINT_WINDOW()

        If blnDO_PRINT_WINDOW Then
            Exit Sub
        End If

        blnDO_PRINT_WINDOW = True
        Dim stwTIME As Stopwatch
        stwTIME = New System.Diagnostics.Stopwatch
        stwTIME.Start()
        'Call SUB_PRINT_WINDOW_TEST(GRP_PRIVATE_ROTATE)
        Dim intFLAG As Integer
        'intFLAG = (1 Or 2)
        intFLAG = (1)
        Call SUB_PRINT_WINDOW_TEST_02(GRP_PRIVATE_ROTATE, ptrTARGET_HANDLE, intFLAG)
        stwTIME.Stop()
        Call SUB_PUT_TRACE("PRINT_WINDOW：" & stwTIME.Elapsed.ToString)

        'Call SUB_PRINT_WINDOW(GRP_PRIVATE_ROTATE)
        'Call GRP_PRIVATE_ROTATE.CopyFromScreen(New System.Drawing.Point(0, 0), New System.Drawing.Point(0, 0), IMG_PRIVATE_ROTATE.Size)

        If blnDO_REFRESH Then
            blnDO_MAKE_THUMBNAIL = True
            blnDO_PRINT_WINDOW = False
            Exit Sub
        End If

        blnDO_MAKE_THUMBNAIL = True
        stwTIME.Restart()
        Call SUB_MAKE_THUMBNAIL_WPF()
        stwTIME.Stop()
        Call SUB_PUT_TRACE("MAKE_THUMBNAIL：" & stwTIME.Elapsed.ToString)

        stwTIME.Restart()
        Call IMG_PRIVATE_ROTATE_THUM.RotateFlip(ENM_FLIP_ROTATE)
        stwTIME.Stop()
        Call SUB_PUT_TRACE("ROTATE：" & stwTIME.Elapsed.ToString)
        blnDO_MAKE_THUMBNAIL = False

        blnDO_PRINT_WINDOW = False
    End Sub

    Dim INT_RATE_BEFORE As Integer = 0
    Private Sub SUB_MAKE_THUMBNAIL_WPF()

        If Not IMG_PRIVATE_ROTATE_THUM Is Nothing Then
            'Call GC.ReRegisterForFinalize(IMG_PRIVATE_ROTATE_THUM)
        End If

        IMG_PRIVATE_ROTATE_THUM = Nothing

        If IMG_PRIVATE_ROTATE Is Nothing Then
            Exit Sub
        End If

        'IMG_PRIVATE_ROTATE_THUM = IMG_PRIVATE_ROTATE.Clone
        'IMG_PRIVATE_ROTATE_THUM = IMG_PRIVATE_ROTATE.GetThumbnailImage(INT_ROTATE_HEIGHT, INT_ROTATE_WIDTH, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf dummy), IntPtr.Zero)

        Dim INT_WIDTH_IMAGE As Integer
        INT_WIDTH_IMAGE = IMG_PRIVATE_ROTATE.Width
        Dim INT_HEIGHT_IMAGE As Integer
        INT_HEIGHT_IMAGE = IMG_PRIVATE_ROTATE.Height
        Dim INT_RATE As Integer
        INT_RATE = FUNC_GET_RATE_WINDOW_IMAGE(INT_WIDTH_IMAGE, INT_HEIGHT_IMAGE)

        Dim INT_WIDTH_SET As Integer
        INT_WIDTH_SET = CInt(INT_WIDTH_IMAGE / INT_RATE)
        Dim INT_HEIGHT_SET As Integer
        INT_HEIGHT_SET = CInt(INT_HEIGHT_IMAGE / INT_RATE)
        IMG_PRIVATE_ROTATE_THUM = IMG_PRIVATE_ROTATE.GetThumbnailImage(INT_WIDTH_SET, INT_HEIGHT_SET, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf dummy), IntPtr.Zero)

        If Not (INT_RATE_BEFORE = INT_RATE) Then
            BLN_CHANGE_THUM = True
        End If
        INT_RATE_BEFORE = INT_RATE
    End Sub

    Private Function FUNC_GET_RATE_WINDOW_IMAGE(ByVal INT_WIDTH_IMAGE As Integer, ByVal INT_HEIGHT_IMAGE As Integer)
        Dim INT_RATE_WIDTH As Integer

        INT_RATE_WIDTH = FUNC_GET_RATE_WINDOW_IMAGE_WIDTH(INT_WIDTH_IMAGE)

        Dim INT_RET As Integer
        INT_RET = INT_RATE_WIDTH
        Return INT_RET
    End Function

    Private Function FUNC_GET_RATE_WINDOW_IMAGE_WIDTH(ByVal INT_WIDTH_IMAGE As Integer)

        Dim INT_WIDTH_WINDOW As Integer
        INT_WIDTH_WINDOW = srtCAPT_SETTINGS.ROTATE_SIZE_H
        If INT_WIDTH_WINDOW >= INT_WIDTH_IMAGE Then
            Return 1
        End If

        Dim INT_CURRENT As Integer
        INT_CURRENT = INT_WIDTH_IMAGE
        Dim INT_SUB_BEFORE As Integer
        INT_SUB_BEFORE = INT_CURRENT - INT_WIDTH_WINDOW
        For i = 2 To 5
            INT_CURRENT = CInt(INT_WIDTH_IMAGE / i)
            Dim INT_SUB As Integer
            INT_SUB = INT_CURRENT - INT_WIDTH_WINDOW
            INT_SUB = Math.Abs(INT_SUB)

            If INT_SUB_BEFORE < INT_SUB Then
                Return i - 1
            End If

            INT_SUB_BEFORE = INT_SUB
        Next

        Return 1
    End Function
    Private Sub DoEvents()
        Dim frame As DispatcherFrame = New DispatcherFrame()
        Dim callback As Object

        callback = New DispatcherOperationCallback(AddressOf ExitFrames)
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, callback, frame)
        Dispatcher.PushFrame(frame)
    End Sub

    Private Function ExitFrames(sender As Object) As Object
        sender.Continue = False
        Return Nothing
    End Function
#End Region

#Region "画面コントロール制御関連"
    Private Sub SUB_VISIBLE_GUIDE(ByVal BLN_VISIBLE As Boolean)
        Dim VBY_SET As System.Windows.Visibility
        If BLN_VISIBLE Then
            VBY_SET = Visibility.Visible
        Else
            VBY_SET = Visibility.Collapsed
        End If

        PCB_BUTTON_WINDOW_CLOSE.Visibility = VBY_SET
        PCB_BUTTON_WINDOW_MAX.Visibility = VBY_SET

        PCB_BUTTON_CHANGE_SIZE.Visibility = VBY_SET
        PCB_BUTTON_ROTATE.Visibility = VBY_SET
        PCB_BUTTON_SHUTTER.Visibility = VBY_SET
        PCB_BUTTON_SHUTTER_JPEG.Visibility = VBY_SET

        PCB_BUTTON_KEY_W.Visibility = VBY_SET
        PCB_BUTTON_KEY_A.Visibility = VBY_SET
        PCB_BUTTON_KEY_S.Visibility = VBY_SET
        PCB_BUTTON_KEY_D.Visibility = VBY_SET

        PCB_BUTTON_KEY_ALLOW_UP.Visibility = VBY_SET
        PCB_BUTTON_KEY_ALLOW_LEFT.Visibility = VBY_SET
        PCB_BUTTON_KEY_ALLOW_DOWN.Visibility = VBY_SET
        PCB_BUTTON_KEY_ALLOW_RIGHT.Visibility = VBY_SET

        PCB_BUTTON_KEY_PAGE_UP.Visibility = VBY_SET
        PCB_BUTTON_KEY_PAGE_DOWN.Visibility = VBY_SET

        Me.GUIDE_VISIBLE = BLN_VISIBLE
    End Sub

    Private Sub SUB_INIT_SIZE_PCB(ByVal INT_SIZE As Integer)
        Call SUB_PCB_WINDOW_GUIDE_INIT_SIZE(INT_SIZE)
        Call SUB_PCB_CONTROL_GUIDE_INIT_SIZE(INT_SIZE)
        Call SUB_PCB_CONTROL_WASD_INIT_SIZE(INT_SIZE)
        srtCAPT_SETTINGS.ROTATE_BUTTON_SIZE = INT_SIZE
    End Sub

    Private Sub SUB_PCB_WINDOW_GUIDE_INIT_SIZE(ByVal INT_SIZE As Integer)
        Dim INT_MARGIN_W As Integer
        Dim INT_MARGIN_H As Integer
        INT_MARGIN_W = 10
        INT_MARGIN_H = 10

        Dim INT_Y_CUR As Integer
        Dim INT_X_CUR As Integer
        INT_X_CUR = 0
        INT_Y_CUR = 0
        INT_X_CUR += INT_MARGIN_W
        INT_Y_CUR += INT_MARGIN_H

        Dim THK_CURRENT As Thickness

        PCB_BUTTON_WINDOW_CLOSE.Width = INT_SIZE
        PCB_BUTTON_WINDOW_CLOSE.Height = INT_SIZE
        THK_CURRENT = New Thickness(0, INT_Y_CUR, INT_X_CUR, 0)
        PCB_BUTTON_WINDOW_CLOSE.Margin = THK_CURRENT
        INT_X_CUR += INT_SIZE + 1
        INT_Y_CUR += 0

        PCB_BUTTON_WINDOW_MAX.Width = INT_SIZE
        PCB_BUTTON_WINDOW_MAX.Height = INT_SIZE
        THK_CURRENT = New Thickness(0, INT_Y_CUR, INT_X_CUR, 0)
        PCB_BUTTON_WINDOW_MAX.Margin = THK_CURRENT
        INT_X_CUR += INT_SIZE + 1
        INT_Y_CUR += 0

    End Sub

    Private Sub SUB_PCB_CONTROL_GUIDE_INIT_SIZE(ByVal INT_SIZE As Integer)
        Dim INT_MARGIN_W As Integer
        Dim INT_MARGIN_H As Integer
        INT_MARGIN_W = 10
        INT_MARGIN_H = 10

        Dim INT_Y_CUR As Integer
        Dim INT_X_CUR As Integer
        INT_X_CUR = 0
        INT_Y_CUR = 0
        INT_X_CUR += INT_MARGIN_W
        INT_Y_CUR += INT_MARGIN_H

        Dim THK_CURRENT As Thickness

        PCB_BUTTON_VIEW_GUIDE.Width = INT_SIZE
        PCB_BUTTON_VIEW_GUIDE.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, INT_Y_CUR, 0, 0)
        PCB_BUTTON_VIEW_GUIDE.Margin = THK_CURRENT
        INT_X_CUR += 0
        INT_Y_CUR += INT_SIZE + 1

        PCB_BUTTON_CHANGE_SIZE.Width = INT_SIZE
        PCB_BUTTON_CHANGE_SIZE.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, INT_Y_CUR, 0, 0)
        PCB_BUTTON_CHANGE_SIZE.Margin = THK_CURRENT
        INT_X_CUR += 0
        INT_Y_CUR += INT_SIZE + 1

        PCB_BUTTON_ROTATE.Width = INT_SIZE
        PCB_BUTTON_ROTATE.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, INT_Y_CUR, 0, 0)
        PCB_BUTTON_ROTATE.Margin = THK_CURRENT
        INT_X_CUR += 0
        INT_Y_CUR += INT_SIZE + 1

        PCB_BUTTON_SHUTTER.Width = INT_SIZE
        PCB_BUTTON_SHUTTER.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, INT_Y_CUR, 0, 0)
        PCB_BUTTON_SHUTTER.Margin = THK_CURRENT
        INT_X_CUR += 0
        INT_Y_CUR += INT_SIZE + 1

        PCB_BUTTON_SHUTTER_JPEG.Width = INT_SIZE
        PCB_BUTTON_SHUTTER_JPEG.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, INT_Y_CUR, 0, 0)
        PCB_BUTTON_SHUTTER_JPEG.Margin = THK_CURRENT
        INT_X_CUR += 0
        INT_Y_CUR += INT_SIZE + 1


    End Sub

    Private Sub SUB_PCB_CONTROL_WASD_INIT_SIZE(ByVal INT_SIZE As Integer)
        Dim INT_MARGIN_W As Integer
        Dim INT_MARGIN_H As Integer
        INT_MARGIN_W = 10
        INT_MARGIN_H = 10

        Dim INT_Y_CUR As Integer
        Dim INT_X_CUR As Integer
        INT_X_CUR = 0
        INT_Y_CUR = 0
        INT_X_CUR += INT_MARGIN_W
        INT_Y_CUR += INT_MARGIN_H

        Dim THK_CURRENT As Thickness

        PCB_BUTTON_KEY_W.Width = INT_SIZE
        PCB_BUTTON_KEY_W.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR + (INT_SIZE / 2), 0, 0, INT_Y_CUR + INT_SIZE * 2)
        PCB_BUTTON_KEY_W.Margin = THK_CURRENT

        PCB_BUTTON_KEY_A.Width = INT_SIZE
        PCB_BUTTON_KEY_A.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, 0, 0, INT_Y_CUR + INT_SIZE)
        PCB_BUTTON_KEY_A.Margin = THK_CURRENT

        PCB_BUTTON_KEY_S.Width = INT_SIZE
        PCB_BUTTON_KEY_S.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR + (INT_SIZE / 2), 0, 0, INT_Y_CUR)
        PCB_BUTTON_KEY_S.Margin = THK_CURRENT

        PCB_BUTTON_KEY_D.Width = INT_SIZE
        PCB_BUTTON_KEY_D.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR + INT_SIZE, 0, 0, INT_Y_CUR + INT_SIZE)
        PCB_BUTTON_KEY_D.Margin = THK_CURRENT

        INT_X_CUR += (INT_SIZE * 2)
        INT_Y_CUR += 0

        PCB_BUTTON_KEY_ALLOW_UP.Width = INT_SIZE
        PCB_BUTTON_KEY_ALLOW_UP.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR + (INT_SIZE / 2), 0, 0, INT_Y_CUR + INT_SIZE * 2)
        PCB_BUTTON_KEY_ALLOW_UP.Margin = THK_CURRENT

        PCB_BUTTON_KEY_ALLOW_LEFT.Width = INT_SIZE
        PCB_BUTTON_KEY_ALLOW_LEFT.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, 0, 0, INT_Y_CUR + INT_SIZE)
        PCB_BUTTON_KEY_ALLOW_LEFT.Margin = THK_CURRENT

        PCB_BUTTON_KEY_ALLOW_DOWN.Width = INT_SIZE
        PCB_BUTTON_KEY_ALLOW_DOWN.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR + (INT_SIZE / 2), 0, 0, INT_Y_CUR)
        PCB_BUTTON_KEY_ALLOW_DOWN.Margin = THK_CURRENT

        PCB_BUTTON_KEY_ALLOW_RIGHT.Width = INT_SIZE
        PCB_BUTTON_KEY_ALLOW_RIGHT.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR + INT_SIZE, 0, 0, INT_Y_CUR + INT_SIZE)
        PCB_BUTTON_KEY_ALLOW_RIGHT.Margin = THK_CURRENT

        INT_X_CUR += (INT_SIZE * 2)
        INT_Y_CUR += 0

        PCB_BUTTON_KEY_PAGE_UP.Width = INT_SIZE
        PCB_BUTTON_KEY_PAGE_UP.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, 0, 0, INT_Y_CUR + +(INT_SIZE / 2) + INT_SIZE)
        PCB_BUTTON_KEY_PAGE_UP.Margin = THK_CURRENT

        PCB_BUTTON_KEY_PAGE_DOWN.Width = INT_SIZE
        PCB_BUTTON_KEY_PAGE_DOWN.Height = INT_SIZE
        THK_CURRENT = New Thickness(INT_X_CUR, 0, 0, INT_Y_CUR + (INT_SIZE / 2))
        PCB_BUTTON_KEY_PAGE_DOWN.Margin = THK_CURRENT

    End Sub
#End Region

#Region "イベント-ボタンクリック"
    'Private Sub PCB_BUTTON_CLOSE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_CLOSE.Click
    '    Call Me.Close()
    'End Sub

    'Private Sub PCB_BUTTON_ROTATE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_ROTATE.Click
    '    Call SUB_CHANGE_ROTATE()
    'End Sub


    Private Sub PCB_BUTTON_WINDOW_CLOSE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_WINDOW_CLOSE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_WINDOW_CLOSE)
    End Sub
    Private Sub PCB_BUTTON_WINDOW_MAX_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_WINDOW_MAX.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_WINDOW_MAX)
    End Sub

    Private Sub PCB_BUTTON_VIEW_GUIDE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_VIEW_GUIDE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_VIEW_GUIDE)
    End Sub

    Private Sub PCB_BUTTON_CHANGE_SIZE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_CHANGE_SIZE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CHANGE_SIZE)
    End Sub

    Private Sub PCB_BUTTON_SHUTTER_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_SHUTTER.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHUTTER)
    End Sub

    Private Sub PCB_BUTTON_SHUTTER_JPEG_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_SHUTTER_JPEG.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHUTTER_JPEG)
    End Sub

    Private Sub PCB_BUTTON_ROTATE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_ROTATE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CHANGE_ROTATE)
    End Sub

    Private Sub PCB_BUTTON_KEY_W_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_W.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_W)
    End Sub

    Private Sub PCB_BUTTON_KEY_A_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_A.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_A)
    End Sub

    Private Sub PCB_BUTTON_KEY_S_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_S.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_S)
    End Sub

    Private Sub PCB_BUTTON_KEY_D_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_D.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_D)
    End Sub

    Private Sub PCB_BUTTON_KEY_ALLOW_UP_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_ALLOW_UP.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_ALLOW_UP)
    End Sub

    Private Sub PCB_BUTTON_KEY_ALLOW_LEFT_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_ALLOW_LEFT.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_ALLOW_LEFT)
    End Sub

    Private Sub PCB_BUTTON_KEY_ALLOW_DOWN_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_ALLOW_DOWN.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_ALLOW_DOWN)
    End Sub

    Private Sub PCB_BUTTON_KEY_ALLOW_RIGHT_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_ALLOW_RIGHT.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_ALLOW_RIGHT)
    End Sub

    Private Sub PCB_BUTTON_KEY_PAGE_UP_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_PAGE_UP.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_PAGE_UP)
    End Sub

    Private Sub PCB_BUTTON_KEY_PAGE_DOWN_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_KEY_PAGE_DOWN.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_PAGE_DOWN)
    End Sub
#End Region

#Region "イベント-コンテクストメニュークリック"
    Private Sub MNI_CAPT_Click(sender As Object, e As RoutedEventArgs) Handles MNI_CAPT.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHUTTER)
    End Sub

    Private Sub MNI_CAPT_SNS_Click(sender As Object, e As RoutedEventArgs) Handles MNI_CAPT_SNS.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHUTTER_JPEG)
    End Sub

    Private Sub MNI_ROTATE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_ROTATE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CHANGE_ROTATE)
    End Sub

    Private Sub MNI_CLOSE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_CLOSE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_WINDOW_CLOSE)
    End Sub

    Private Sub MNI_WASD_W_Click(sender As Object, e As RoutedEventArgs) Handles MNI_WASD_W.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_W)
    End Sub

    Private Sub MNI_WASD_A_Click(sender As Object, e As RoutedEventArgs) Handles MNI_WASD_A.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_A)
    End Sub

    Private Sub MNI_WASD_S_Click(sender As Object, e As RoutedEventArgs) Handles MNI_WASD_S.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_S)
    End Sub

    Private Sub MNI_WASD_D_Click(sender As Object, e As RoutedEventArgs) Handles MNI_WASD_D.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_D)
    End Sub

    Private Sub MNI_ALLOW_UP_Click(sender As Object, e As RoutedEventArgs) Handles MNI_ALLOW_UP.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_ALLOW_UP)
    End Sub

    Private Sub MNI_ALLOW_LEFT_Click(sender As Object, e As RoutedEventArgs) Handles MNI_ALLOW_LEFT.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_ALLOW_LEFT)
    End Sub

    Private Sub MNI_ALLOW_DOWN_Click(sender As Object, e As RoutedEventArgs) Handles MNI_ALLOW_DOWN.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_ALLOW_DOWN)
    End Sub

    Private Sub MNI_ALLOW_RIGHT_Click(sender As Object, e As RoutedEventArgs) Handles MNI_ALLOW_RIGHT.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_ALLOW_RIGHT)
    End Sub

    Private Sub MNI_PAGEUD_UP_Click(sender As Object, e As RoutedEventArgs) Handles MNI_PAGEUD_UP.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_PAGE_UP)
    End Sub

    Private Sub MNI_PAGEUD_DOWN_Click(sender As Object, e As RoutedEventArgs) Handles MNI_PAGEUD_DOWN.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_KEY_PAGE_DOWN)
    End Sub
#End Region

#Region "イベント-タイマー"
    Private Sub SUB_START_DISPATCHER_TIMER()
        dispatcherTimer = New DispatcherTimer(DispatcherPriority.Send)
        AddHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
        dispatcherTimer.Interval = TimeSpan.FromMilliseconds(CST_INTERVAL_MSEC)
        dispatcherTimer.IsEnabled = True
        Call dispatcherTimer.Start()
    End Sub

    Private Sub SUB_STOP_DISPATCHER_TIMER()
        If Not (dispatcherTimer Is Nothing) Then
            Call dispatcherTimer.Stop()
            dispatcherTimer.IsEnabled = False
            RemoveHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
            'dispatcherTimer.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal) 'エラー用
            dispatcherTimer = Nothing
        End If
    End Sub

    Private Sub dispatcherTimer_Tick(sender As Object, e As EventArgs)

        If intRESIZE_COUNTER > 0 Then
            intRESIZE_COUNTER -= 1
            Exit Sub
        End If

        Call Me.SUB_REFRESH_IMAGE()
    End Sub

    Private Sub SUB_TIMER(sender As Object, e As System.Timers.ElapsedEventArgs)
        Call Me.SUB_RE_PRINT_WINDOW()
    End Sub

    Private Sub SUB_START_TIMER()
        TIM_PRIVATE_TIMER = New System.Timers.Timer
        TIM_PRIVATE_TIMER.Interval = CST_INTERVAL_MSEC * 4
        TIM_PRIVATE_TIMER.AutoReset = True

        AddHandler TIM_PRIVATE_TIMER.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf SUB_TIMER)
        Call TIM_PRIVATE_TIMER.Start()
    End Sub

    Private Sub SUB_STOP_TIMER()
        Call TIM_PRIVATE_TIMER.Stop()
    End Sub
#End Region

    Const CST_INTERVAL_MSEC As Double = 25
    Private dispatcherTimer As System.Windows.Threading.DispatcherTimer
    Private BMP_ROTATE As WriteableBitmap
    Private BMP_SOURCE As System.Windows.Media.Imaging.BitmapSource

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        'ウィンドウをマウスのドラッグで移動できるようにする
        AddHandler Me.MouseLeftButtonDown, Sub(sender, e) Me.DragMove()

        Call SUB_INIT_BUTTONS()

        Call SUB_START_DISPATCHER_TIMER()
        Call SUB_START_TIMER()

        Call SUB_INIT_BMP_IMAGE()
        Call SUB_INIT_ROTATE_VIEW()
    End Sub

    Private Sub WPF_ROTATE_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        INT_ROTATE_WIDTH = PCB_ROTATE.Width
        INT_ROTATE_HEIGHT = PCB_ROTATE.Height

        Call SUB_VISIBLE_GUIDE(False)

        Call SUB_INIT_SIZE_PCB(srtCAPT_SETTINGS.ROTATE_BUTTON_SIZE)
    End Sub

    Private Sub WPF_ROTATE_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Call SUB_STOP_DISPATCHER_TIMER()
        Call SUB_STOP_TIMER()
        Me.CHECK_CLOSED = True
    End Sub

    Private Sub WPF_ROTATE_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    End Sub

    Private intRESIZE_COUNTER As Integer = 0
    Private Sub WPF_ROTATE_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
        intRESIZE_COUNTER = 10
        Call SUB_RESIZE_WINDOW_WPF(Me)
        INT_ROTATE_WIDTH = PCB_ROTATE.Width
        INT_ROTATE_HEIGHT = PCB_ROTATE.Height
    End Sub

    Private Sub WPF_ROTATE_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        srtCAPT_SETTINGS.ROTATE_POSITION_X = CInt(Me.Left)
        srtCAPT_SETTINGS.ROTATE_POSITION_Y = CInt(Me.Top)
    End Sub

    Private Sub WPF_ROTATE_SourceInitialized(sender As Object, e As EventArgs) Handles Me.SourceInitialized

    End Sub

    Private Sub WPF_ROTATE_ContentRendered(sender As Object, e As EventArgs) Handles Me.ContentRendered

    End Sub

    Private Sub WPF_ROTATE_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded

    End Sub

    Private Sub WPF_ROTATE_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseDoubleClick
        'Call SUB_CHANGE_ROTATE()
    End Sub

End Class
