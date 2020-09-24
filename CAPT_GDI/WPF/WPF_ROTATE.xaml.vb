Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Threading

Public Delegate Sub WPF_ROTATE_DELEGATE()
Class WPF_ROTATE

#Region "変数"
    Private TIM_PRIVATE_TIMER As System.Timers.Timer
#End Region

#Region "プロパティ用変数"
    Private blnPROPETY_CHECK_CLOSED As Boolean = False
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

    Public Property TICK_GET_IMAGE As Boolean
        Get
            Return False
            'Return timGET_IMAGE.Enabled
        End Get
        Set(ByVal value As Boolean)
            'timGET_IMAGE.Enabled = value
        End Set
    End Property
#End Region

#Region "実行処理群"

    Private Function dummy() As Boolean
        Return False
    End Function

    Private Sub SUB_DRAW_STRING(ByRef grpDRAW As Graphics, ByVal strVALUE As String, ByVal intSIZE As Integer, ByVal intX As Integer, ByVal intY As Integer)
        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        Dim ff As New FontFamily("Lucida Console")
        'Dim ff As New FontFamily(Me.FontFamily.Source)

        Call gp.AddString(strVALUE, ff, 0, intSIZE, New System.Drawing.Point(intX, intY), StringFormat.GenericDefault)
        Call grpDRAW.FillPath(Brushes.Cyan, gp)
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

        blnDO_REFRESH = True

        Call IMG_PRIVATE_ROTATE_THUM.RotateFlip(ENM_FLIP_ROTATE)
        PCB_ROTATE.Source = FUNC_GET_IMAGESOURCE(IMG_PRIVATE_ROTATE_THUM)

        blnDO_REFRESH = False
    End Sub

    Private blnDO_PRINT_WINDOW As Boolean = False
    Private Sub SUB_RE_PRINT_WINDOW()

        If blnDO_PRINT_WINDOW Then
            Exit Sub
        End If

        blnDO_PRINT_WINDOW = True

        Call SUB_PRINT_WINDOW_TEST(GRP_PRIVATE_ROTATE)
        'Call SUB_PRINT_WINDOW(GRP_PRIVATE_ROTATE)
        'Call GRP_PRIVATE_ROTATE.CopyFromScreen(New System.Drawing.Point(0, 0), New System.Drawing.Point(0, 0), IMG_PRIVATE_ROTATE.Size)
        Call SUB_MAKE_THUMBNAIL_WPF()

        blnDO_PRINT_WINDOW = False
    End Sub

    Private Sub SUB_MAKE_THUMBNAIL_WPF()

        If Not IMG_PRIVATE_ROTATE_THUM Is Nothing Then
            Call GC.ReRegisterForFinalize(IMG_PRIVATE_ROTATE_THUM)
        End If

        IMG_PRIVATE_ROTATE_THUM = Nothing

        If IMG_PRIVATE_ROTATE Is Nothing Then
            Exit Sub
        End If

        'IMG_PRIVATE_ROTATE_THUM = IMG_PRIVATE_ROTATE.Clone
        IMG_PRIVATE_ROTATE_THUM = IMG_PRIVATE_ROTATE.GetThumbnailImage(INT_ROTATE_HEIGHT, INT_ROTATE_WIDTH, New Image.GetThumbnailImageAbort(AddressOf dummy), IntPtr.Zero)

    End Sub

    Private Sub SUB_CHANGE_ROTATE()
        If ENM_FLIP_ROTATE = RotateFlipType.Rotate270FlipXY Then
            ENM_FLIP_ROTATE = RotateFlipType.Rotate90FlipXY
        Else
            ENM_FLIP_ROTATE = RotateFlipType.Rotate270FlipXY
        End If
    End Sub

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

#Region "イベント-クリック"

#End Region

#Region "イベント-マウス左アップ"

    Private Sub PCB_ROTATE_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PCB_ROTATE.MouseLeftButtonUp
        Call SUB_CHANGE_ROTATE()
        Call SUB_REFRESH_IMAGE()
    End Sub

    Private Sub PCB_SHUTTER_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PCB_SHUTTER.MouseLeftButtonUp
        If MOD_ROTATE.FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        MOD_ROTATE.FRM_PARENT.FLIP_ROTATE_TYPE = ENM_FLIP_ROTATE '回転を設定
        MOD_ROTATE.FRM_PARENT.FORCE_JPEG = False

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_ONE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_SHUTTER_JPEG_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PCB_SHUTTER_JPEG.MouseLeftButtonUp
        If MOD_ROTATE.FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        MOD_ROTATE.FRM_PARENT.FLIP_ROTATE_TYPE = ENM_FLIP_ROTATE '回転を設定
        MOD_ROTATE.FRM_PARENT.FORCE_JPEG = True

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_ONE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_ROTATE.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_ROTATE.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_ROTATE.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub
#End Region

#Region "イベント-タイマー"
    'Private intTICK_COUNTER As Integer = 0
    'Const CST_TICK_MAX As Integer = 50
    Private Sub dispatcherTimer_Tick(sender As Object, e As EventArgs)
        Call Me.SUB_RE_PRINT_WINDOW()
        Call Me.SUB_REFRESH_IMAGE()

        'intTICK_COUNTER += 1
        'If intTICK_COUNTER >= CST_TICK_MAX Then
        '    intTICK_COUNTER = 0
        '    'Call GC.Collect()
        'End If
    End Sub

    Private Sub SUB_TIMER(sender As Object, e As System.Timers.ElapsedEventArgs)
    End Sub

    Private Sub SUB_START_TIMER()
        TIM_PRIVATE_TIMER = New System.Timers.Timer
        TIM_PRIVATE_TIMER.Interval = 200
        TIM_PRIVATE_TIMER.AutoReset = True

        AddHandler TIM_PRIVATE_TIMER.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf SUB_TIMER)
        Call TIM_PRIVATE_TIMER.Start()
    End Sub

    Private Sub SUB_STOP_TIMER()
        Call TIM_PRIVATE_TIMER.Stop()
    End Sub
#End Region

    Private dispatcherTimer As System.Windows.Threading.DispatcherTimer

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        dispatcherTimer = New DispatcherTimer(DispatcherPriority.Normal)
        dispatcherTimer.Interval = TimeSpan.FromMilliseconds(250)
        AddHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick

        PCB_SHUTTER.Source = FUNC_GET_IMAGESOURCE(My.Resources.SHUTTER_C_W)
        PCB_SHUTTER_JPEG.Source = FUNC_GET_IMAGESOURCE(My.Resources.SHUTTER_C_G)
    End Sub

    Private Sub WPF_ROTATE_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded



        '        AddHandler dispatcherTimer.Tick, New EventHandler(AddressOf dispatcherTimer_Tick)
        dispatcherTimer.IsEnabled = True
        Call dispatcherTimer.Start()

        ENM_FLIP_ROTATE = RotateFlipType.Rotate270FlipXY
        IMG_PRIVATE_ROTATE = FUNC_GET_CLIENT_DEFAULT_IMAGE()
        GRP_PRIVATE_ROTATE = System.Drawing.Graphics.FromImage(IMG_PRIVATE_ROTATE)

        INT_ROTATE_WIDTH = PCB_ROTATE.Width
        INT_ROTATE_HEIGHT = PCB_ROTATE.Height

        'Call SUB_START_TIMER()
    End Sub

    Private blnCLOSING As Boolean = False
    Private Sub WPF_ROTATE_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        blnCLOSING = True
        'Call SUB_STOP_TIMER()
    End Sub

    Private Sub WPF_ROTATE_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        If Not (dispatcherTimer Is Nothing) Then
            Call dispatcherTimer.Stop()
            dispatcherTimer.IsEnabled = False
            RemoveHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
            dispatcherTimer.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal) 'エラー用
            dispatcherTimer = Nothing
        End If

        Me.CHECK_CLOSED = True
    End Sub

    Private Sub WPF_ROTATE_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
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
End Class
