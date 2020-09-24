Imports System.ComponentModel

Class WPF_LOGO

#Region "画面用列挙定数"

#End Region

#Region "画面用変数"
    Friend SIZ_WINDOW As RECT_WH
    Friend BMP_VIEW_LOGO As Bitmap
    Friend BMP_BASE_LOGO As Bitmap
#End Region

#Region "プロパティ用変数"
    Private blnPROPETY_CHECK_CLOSED As Boolean = False

    Private ENM_PROPETY_ROTATE_CURRENT As RotateFlipType
    Private BLN_PROPERTY_WINDOW_MAX As Boolean
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

    Public Property ROTATE_CURRENT As RotateFlipType
        Get
            Return ENM_PROPETY_ROTATE_CURRENT
        End Get
        Set(ByVal value As RotateFlipType)
            ENM_PROPETY_ROTATE_CURRENT = value
        End Set
    End Property

    Private Property WINDOW_MAX As Boolean
        Get
            Return BLN_PROPERTY_WINDOW_MAX
        End Get
        Set(ByVal value As Boolean)
            BLN_PROPERTY_WINDOW_MAX = value
        End Set
    End Property

#End Region

#Region "NEW"
    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        'ウィンドウをマウスのドラッグで移動できるようにする
        AddHandler Me.MouseLeftButtonDown, Sub(sender, e) Me.DragMove()

        Call SUB_INIT_BUTTONS()
        Call SUB_INIT_IMAGE()
        Call SUB_INIT_CTRL_VALUE()
    End Sub
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_INIT_BUTTONS()
        Dim STR_EXE As String
        STR_EXE = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim STR_DIR As String
        STR_DIR = FUNC_PATH_TO_DIR_PATH(STR_EXE)
        Call SUB_INIT_CHANGE_IMAGE(STR_DIR & "\RES\IMG\")
    End Sub

    Private Sub SUB_INIT_IMAGE()
        Dim BLN_CHECK_FILE As Boolean
        If srtCAPT_SETTINGS.PATH_LOGO_FILE = "" Then
            BLN_CHECK_FILE = False
        Else
            If FUNC_FILE_CHECK(srtCAPT_SETTINGS.PATH_LOGO_FILE) Then
                BLN_CHECK_FILE = True
            Else
                BLN_CHECK_FILE = False
            End If
        End If

        Dim bmpAPPEND As Bitmap
        If BLN_CHECK_FILE Then
            bmpAPPEND = System.Drawing.Image.FromFile(srtCAPT_SETTINGS.PATH_LOGO_FILE)
        Else
            bmpAPPEND = My.Resources.LOGO
        End If

        Call SUB_LOAD_LOGO(bmpAPPEND, RotateFlipType.RotateNoneFlipNone)
    End Sub

    Private Sub SUB_INIT_CTRL_VALUE()
    End Sub
#End Region

#Region "補助線"
    Friend Sub SUB_CHANGE_DRAW_COMPOTION()
        Call SUB_DRAW_COMPOSTION()
    End Sub
    Private Sub SUB_DRAW_COMPOSTION()
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer
        intWIDTH = CInt(PCB_COMPOSITION.Width)
        intHEIGHT = CInt(PCB_COMPOSITION.Height)

        Dim bmpCANVAS As Bitmap
        bmpCANVAS = New Bitmap(intWIDTH, intHEIGHT)

        Dim grpDRAW As Graphics
        grpDRAW = Graphics.FromImage(bmpCANVAS)

        Const cstPEN_SIZE As Single = 3.0
        Dim penDRAW As System.Drawing.Pen
        'penDRAW = New System.Drawing.Pen(System.Drawing.Color.Cyan, cstPEN_SIZE)
        penDRAW = New System.Drawing.Pen(System.Drawing.Color.FromArgb(64, System.Drawing.Color.Black), cstPEN_SIZE)

        Dim penFORE As System.Drawing.Pen
        penFORE = New System.Drawing.Pen(System.Drawing.Color.White, 1.0)

        Call SUB_DRAW_OUTLINE(grpDRAW, penDRAW)
        Call SUB_DRAW_OUTLINE(grpDRAW, penFORE)

        PCB_COMPOSITION.Source = FUNC_GET_IMAGESOURCE(bmpCANVAS)
        Call grpDRAW.Dispose()
    End Sub

#Region "内部"
    Private Sub SUB_DRAW_OUTLINE(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim rct As System.Drawing.Rectangle

        rct = New System.Drawing.Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Call grpDRAW.DrawRectangle(penDRAW, rct)
    End Sub
#End Region

#End Region

#Region "内部処理"
    Private Sub SUB_LOAD_LOGO(ByRef BMP_LOGO As Bitmap, ByVal ENM_ROTATE As RotateFlipType)
        Dim BMP_VIEW As Bitmap

        BMP_VIEW = BMP_LOGO.Clone
        BMP_VIEW.RotateFlip(ENM_ROTATE)

        Me.Width = BMP_VIEW.Width
        Me.Height = BMP_VIEW.Height

        PCB_APPEND.Source = FUNC_GET_IMAGESOURCE(BMP_VIEW)

        BMP_BASE_LOGO = BMP_LOGO.Clone
        BMP_VIEW_LOGO = BMP_VIEW.Clone

        Me.ROTATE_CURRENT = ENM_ROTATE
    End Sub

    Private Function FUNC_GET_ROTATE_NEXT(ByVal ENM_ROTATE As RotateFlipType) As RotateFlipType
        Dim ENM_RET As RotateFlipType
        Select Case ENM_ROTATE
            Case RotateFlipType.RotateNoneFlipNone
                ENM_RET = RotateFlipType.Rotate90FlipXY
            Case RotateFlipType.Rotate90FlipXY
                ENM_RET = RotateFlipType.Rotate270FlipXY
            Case RotateFlipType.Rotate270FlipXY
                ENM_RET = RotateFlipType.RotateNoneFlipNone
            Case Else
                ENM_RET = RotateFlipType.RotateNoneFlipNone
        End Select

        Return ENM_RET
    End Function

    Private Function FUNC_GET_SIZE_WINDOW()
        Dim RET As RECT_WH

        RET.left = CInt(Me.Left)
        RET.top = CInt(Me.Top)
        RET.width = CInt(Me.Width)
        RET.height = CInt(Me.Height)

        Return RET
    End Function

    Friend Sub SUB_SET_SIZE_WINDOW()
        Dim SIZ_W As RECT_WH

        SIZ_W = FUNC_GET_SIZE_WINDOW()
        SIZ_WINDOW = SIZ_W
    End Sub

    Private BLN_SET_SIZE As Boolean = False
    Private Sub SUB_SET_RATE()
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer
        Dim intWIDTH_01 As Integer
        Dim intHEIGHT_01 As Integer
        Dim intWIDTH_02 As Integer
        Dim intHEIGHT_02 As Integer
        Dim intAREA_01 As Integer
        Dim intAREA_02 As Integer
        Dim intWIDTH_SET As Integer
        Dim intHEIGHT_SET As Integer

        intWIDTH = Me.ActualWidth
        intHEIGHT = Me.ActualHeight

        If Not MNI_RATE_LOCK.IsChecked Then
            intWIDTH_01 = intWIDTH
            intHEIGHT_01 = intHEIGHT

            intHEIGHT_02 = intHEIGHT
            intWIDTH_02 = intWIDTH
        Else
            Dim DEC_RATE_HEIGHT As Decimal
            DEC_RATE_HEIGHT = BMP_VIEW_LOGO.Height / BMP_VIEW_LOGO.Width
            intWIDTH_01 = intWIDTH
            intHEIGHT_01 = (intWIDTH_01 * DEC_RATE_HEIGHT)

            Dim DEC_RATE_WIDTH As Decimal
            DEC_RATE_WIDTH = BMP_VIEW_LOGO.Width / BMP_VIEW_LOGO.Height

            intHEIGHT_02 = intHEIGHT
            intWIDTH_02 = intHEIGHT_02 * DEC_RATE_WIDTH
        End If

        intAREA_01 = intWIDTH_01 * intHEIGHT_01
        intAREA_02 = intWIDTH_02 * intHEIGHT_02

        Dim srtRECT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT
        srtRECT = FUNC_GET_CRIENT_RECT(prcTARGET)
        Dim intWIDTH_CLIENT As Integer
        Dim intHEIGHT_CLIENT As Integer
        intWIDTH_CLIENT = FUNC_GET_RECT_WIDTH(srtRECT)
        intHEIGHT_CLIENT = FUNC_GET_RECT_HEIGHT(srtRECT)

        If intAREA_01 <= intAREA_02 Then '基本的には大きい方を採用する
            If intWIDTH_CLIENT >= intWIDTH_02 And intHEIGHT_CLIENT >= intHEIGHT_02 Then 'ただし画面サイズを超えていない場合だけ
                intWIDTH_SET = intWIDTH_02
                intHEIGHT_SET = intHEIGHT_02
            Else
                intWIDTH_SET = intWIDTH_01
                intHEIGHT_SET = intHEIGHT_01
            End If
        Else
            If intWIDTH_CLIENT >= intWIDTH_01 And intHEIGHT_CLIENT >= intHEIGHT_01 Then 'ただし画面サイズを超えていない場合だけ
                intWIDTH_SET = intWIDTH_01
                intHEIGHT_SET = intHEIGHT_01
            Else
                intWIDTH_SET = intWIDTH_02
                intHEIGHT_SET = intHEIGHT_02
            End If
        End If

        BLN_SET_SIZE = True
        Me.Width = intWIDTH_SET
        Me.Height = intHEIGHT_SET
        PCB_COMPOSITION.Width = intWIDTH_SET
        PCB_COMPOSITION.Height = intHEIGHT_SET
        Call SUB_DRAW_COMPOSTION()
        BLN_SET_SIZE = False
    End Sub

    Private Sub SUB_CHANGE_ROTATE()
        Call SUB_LOAD_LOGO(BMP_BASE_LOGO, FUNC_GET_ROTATE_NEXT(Me.ROTATE_CURRENT))
    End Sub

    Private Sub SUB_JUST_WINDOW()
        If Me.BMP_VIEW_LOGO Is Nothing Then
            Exit Sub
        End If
        BLN_SET_SIZE = True
        Me.Width = BMP_VIEW_LOGO.Width
        BLN_SET_SIZE = False
        Me.Height = BMP_VIEW_LOGO.Height
    End Sub

    Private Sub SUB_MAX_WINDOW()

        Dim srtRECT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT
        srtRECT = FUNC_GET_CRIENT_RECT(prcTARGET)
        Dim intWINDOW_WIDTH As Integer
        Dim intWINDOW_HEIGHT As Integer
        intWINDOW_WIDTH = FUNC_GET_RECT_WIDTH(srtRECT)
        intWINDOW_HEIGHT = FUNC_GET_RECT_HEIGHT(srtRECT)

        Dim intWINDOW_LEFT As Integer
        Dim intWINDOW_TOP As Integer
        intWINDOW_LEFT = FUNC_GET_LEFT_WINDOW(prcTARGET)
        intWINDOW_TOP = FUNC_GET_TOP_WINDOW(prcTARGET)
        If intWINDOW_LEFT <> 0 Then
            intWINDOW_LEFT += 8
        End If
        If intWINDOW_TOP <> 0 Then
            intWINDOW_TOP -= 8
        End If

        MNI_RATE_LOCK.IsChecked = False
        Me.Left = intWINDOW_LEFT
        Me.Top = intWINDOW_TOP
        BLN_SET_SIZE = True
        Me.Width = intWINDOW_WIDTH
        BLN_SET_SIZE = False
        Me.Height = intWINDOW_HEIGHT

        Me.WINDOW_MAX = True
    End Sub

#End Region

#Region "イベント-クリック"
#End Region

#Region "イベント-チェック"
    Private Sub CHK_OPACITY_Checked(sender As Object, e As RoutedEventArgs) Handles CHK_OPACITY.Checked
        Call SUB_CHK_OPACITY_CHECK_CHANGE()
    End Sub

    Private Sub CHK_OPACITY_Unchecked(sender As Object, e As RoutedEventArgs) Handles CHK_OPACITY.Unchecked
        Call SUB_CHK_OPACITY_CHECK_CHANGE()
    End Sub

    Private Sub SUB_CHK_OPACITY_CHECK_CHANGE()
        Dim COL_SET As Windows.Media.Color
        If CHK_OPACITY.IsChecked Then
            COL_SET = Windows.Media.Color.FromArgb(0, 0, 0, 255)
        Else
            COL_SET = Windows.Media.Color.FromArgb(8, 0, 0, 255)
        End If

        Me.Background = New SolidColorBrush(COL_SET)
    End Sub


#End Region

#Region "イベント-バリューチェンジ"
    Private Sub SLI_APPEND_IMAGE_OPACITY_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles SLI_APPEND_IMAGE_OPACITY.ValueChanged
        Dim intVALUE As Integer
        Dim intMAX As Integer
        Dim dblOPA As Double

        intMAX = CInt(SLI_APPEND_IMAGE_OPACITY.Maximum)
        intVALUE = CInt(SLI_APPEND_IMAGE_OPACITY.Value)

        dblOPA = CDec(intVALUE / intMAX)
        PCB_APPEND.Opacity = dblOPA
    End Sub
#End Region

#Region "イベント-コンテキストメニュークリック"
    Private Sub MNI_CLOSE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_CLOSE.Click
        Call Me.Close()
    End Sub

    Private Sub MNI_MAX_Click(sender As Object, e As RoutedEventArgs) Handles MNI_MAX.Click
        Call SUB_MAX_WINDOW()
    End Sub

    Private Sub MNI_RATE_LOCK_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_LOCK.Click
        If MNI_RATE_LOCK.IsChecked Then
            Call SUB_LOAD_LOGO(BMP_VIEW_LOGO, RotateFlipType.RotateNoneFlipNone)
        End If
    End Sub

    Private Sub MNI_LOAD_IMAGE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_LOAD_IMAGE.Click
        Dim ofdDIALOG As OpenFileDialog

        ofdDIALOG = New OpenFileDialog()
        ofdDIALOG.Title = "画像を開く"
        ofdDIALOG.Filter = "画像ファイル|*.png;*.jpg;*.tif"
        ofdDIALOG.Multiselect = False
        ofdDIALOG.InitialDirectory = srtCAPT_SETTINGS.PATH_SAVE

        Dim rstDIALOG As DialogResult
        rstDIALOG = ofdDIALOG.ShowDialog()

        If rstDIALOG = Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim strFILE_PATH As String
        strFILE_PATH = ofdDIALOG.FileName
        srtCAPT_SETTINGS.PATH_LOGO_FILE = strFILE_PATH

        Dim bmpAPPEND As Bitmap
        bmpAPPEND = System.Drawing.Image.FromFile(strFILE_PATH)
        Call SUB_LOAD_LOGO(bmpAPPEND, RotateFlipType.RotateNoneFlipNone)

        Call SUB_FOREGROUND_WINDOW(prcTARGET)
    End Sub

    Private Sub MNI_RESIZE_JUST_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RESIZE_JUST.Click
        Call SUB_JUST_WINDOW()
    End Sub

    Private Sub MNI_ROTATE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_ROTATE.Click
        Call SUB_CHANGE_ROTATE()
    End Sub
#End Region

    Private Sub WPF_LOGO_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.CHECK_CLOSED = True
    End Sub

    Private Sub WPF_LOGO_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
        Me.WINDOW_MAX = False

        If BLN_SET_SIZE Then
            Exit Sub
        End If
        Call SUB_SET_RATE()
        Call SUB_SET_SIZE_WINDOW()
    End Sub

    Private Sub WPF_LOGO_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Call SUB_SET_SIZE_WINDOW()
    End Sub

    Private Sub WPF_LOGO_KeyDown(sender As Object, e As Windows.Input.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub WPF_LOGO_KeyUp(sender As Object, e As Windows.Input.KeyEventArgs) Handles Me.KeyUp
        Dim intLEFT As Integer
        Dim intTOP As Integer
        Select Case e.Key
            Case Key.Up
                intLEFT = Me.Left
                intTOP = Me.Top - 1
            Case Key.Right
                intLEFT = Me.Left + 1
                intTOP = Me.Top
            Case Key.Down
                intLEFT = Me.Left
                intTOP = Me.Top + 1
            Case Key.Left
                intLEFT = Me.Left - 1
                intTOP = Me.Top
            Case Else
                intLEFT = Me.Left
                intTOP = Me.Top
        End Select

        Me.Left = intLEFT
        Me.Top = intTOP
    End Sub

    Private Sub WPF_LOGO_MouseLeave(sender As Object, e As Windows.Input.MouseEventArgs) Handles Me.MouseLeave
        Me.PCB_COMPOSITION.Visibility = Visibility.Hidden
    End Sub

    Private Sub WPF_LOGO_MouseEnter(sender As Object, e As Windows.Input.MouseEventArgs) Handles Me.MouseEnter
        Me.PCB_COMPOSITION.Visibility = Visibility.Visible
    End Sub

    Private Sub WPF_ROTATE_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseDoubleClick
        If Me.WINDOW_MAX Then
            Call SUB_JUST_WINDOW()
        Else
            Call SUB_MAX_WINDOW()
        End If
        '        Call SUB_CHANGE_ROTATE()
    End Sub


End Class
