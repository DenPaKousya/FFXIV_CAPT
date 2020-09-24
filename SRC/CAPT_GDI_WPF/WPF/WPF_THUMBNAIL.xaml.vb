Imports System.ComponentModel

Public Class WPF_THUMBNAIL

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

#Region "画面用列挙定数"

#End Region

#Region "画面用変数"
    Friend SIZ_WINDOW As RECT_WH
    Friend BMP_VIEW_LOGO As Bitmap
    Friend BMP_BASE_LOGO As Bitmap
    Friend INT_HANDLE_THUMBNAIL As IntPtr

    Private STR_PATH_IMAGE_FILE As String
#End Region

#Region "初期化・終了処理"
    Public Sub SUB_INIT_THUBNAIL()

        STR_PATH_IMAGE_FILE = ""

        Dim INT_HANDLE_ME As IntPtr
        INT_HANDLE_ME = FUNC_GET_HANDLE_THUBNAIL()

        INT_HANDLE_THUMBNAIL = 0
        Dim INT_RET As Integer
        INT_RET = DwmRegisterThumbnail(INT_HANDLE_ME, prcTARGET.MainWindowHandle, INT_HANDLE_THUMBNAIL)

        If INT_RET = 0 Then
            Call SUB_REFRESH_THUBNAIL()
        End If
    End Sub

    Private Sub SUB_INIT_IMAGE()
        Dim BLN_CHECK_FILE As Boolean
        If STR_PATH_IMAGE_FILE = "" Then
            BLN_CHECK_FILE = False
        Else
            If FUNC_FILE_CHECK(STR_PATH_IMAGE_FILE) Then
                BLN_CHECK_FILE = True
            Else
                BLN_CHECK_FILE = False
            End If
        End If

        Dim bmpAPPEND As Bitmap
        If BLN_CHECK_FILE Then
            bmpAPPEND = System.Drawing.Image.FromFile(STR_PATH_IMAGE_FILE)
        Else
            bmpAPPEND = My.Resources.BLANK_16_9
        End If

        Call SUB_LOAD_LOGO(bmpAPPEND, RotateFlipType.RotateNoneFlipNone)
    End Sub
#End Region

#Region "内部処理"
    Private Sub SUB_REFRESH_THUBNAIL()

        If INT_HANDLE_THUMBNAIL = IntPtr.Zero Then
            Exit Sub
        End If

        Dim PSZ_SET As PSIZE

        Call DwmQueryThumbnailSourceSize(INT_HANDLE_THUMBNAIL, PSZ_SET)

        Dim PRP_SET As DWM_THUMBNAIL_PROPERTIES


        Dim INT_SLIDE_VALUE As Integer
        INT_SLIDE_VALUE = SLI_APPEND_IMAGE_OPACITY.Value
        Dim INT_OPACITY As Integer
        INT_OPACITY = 255 * (INT_SLIDE_VALUE / SLI_APPEND_IMAGE_OPACITY.Maximum)

        With PRP_SET
            .fVisible = True
            .dwFlags = DWM_TNP_VISIBLE Or DWM_TNP_RECTDESTINATION Or DWM_TNP_OPACITY
            .opacity = CByte(INT_OPACITY)
            .rcDestination.left = 0
            .rcDestination.top = 0
            .rcDestination.right = Me.Width
            .rcDestination.bottom = Me.Height
        End With

        Call DwmUpdateThumbnailProperties(INT_HANDLE_THUMBNAIL, PRP_SET)
    End Sub

    Private Sub SUB_LOAD_LOGO(ByRef BMP_LOGO As Bitmap, ByVal ENM_ROTATE As RotateFlipType)
        Dim BMP_VIEW As Bitmap

        BMP_VIEW = BMP_LOGO.Clone
        BMP_VIEW.RotateFlip(ENM_ROTATE)

        'Me.Width = BMP_VIEW.Width
        'Me.Height = BMP_VIEW.Height

        PCB_APPEND.Source = FUNC_GET_IMAGESOURCE(BMP_VIEW)

        BMP_BASE_LOGO = BMP_LOGO.Clone
        BMP_VIEW_LOGO = BMP_VIEW.Clone

        Me.ROTATE_CURRENT = ENM_ROTATE
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

        Dim RCT_WINDOW As MOD_PROCESS_WINDOW.RECT
        RCT_WINDOW = FUNC_GET_WINDOW_RECT(prcTARGET)
        Dim INT_WINDOW_WIDTH As Integer
        INT_WINDOW_WIDTH = FUNC_GET_RECT_WIDTH(RCT_WINDOW)
        Dim INT_WINDOW_HEIGHT As Integer
        INT_WINDOW_HEIGHT = FUNC_GET_RECT_HEIGHT(RCT_WINDOW)

        If Not MNI_RATE_LOCK.IsChecked Then
            intWIDTH_01 = intWIDTH
            intHEIGHT_01 = intHEIGHT

            intHEIGHT_02 = intHEIGHT
            intWIDTH_02 = intWIDTH
        Else
            Dim DEC_RATE_HEIGHT As Decimal
            DEC_RATE_HEIGHT = INT_WINDOW_HEIGHT / INT_WINDOW_WIDTH
            intWIDTH_01 = intWIDTH
            intHEIGHT_01 = (intWIDTH_01 * DEC_RATE_HEIGHT)

            Dim DEC_RATE_WIDTH As Decimal
            DEC_RATE_WIDTH = INT_WINDOW_WIDTH / INT_WINDOW_HEIGHT

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
        BLN_SET_SIZE = False
    End Sub
#End Region

#Region "NEW"

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        'ウィンドウをマウスのドラッグで移動できるようにする
        AddHandler Me.MouseLeftButtonDown, Sub(sender, e) Me.DragMove()

        Call SUB_INIT_IMAGE()
    End Sub

#End Region

#Region "イベント-コンテキストメニュークリック"
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
        STR_PATH_IMAGE_FILE = strFILE_PATH
        Call SUB_INIT_IMAGE()

        SLI_APPEND_IMAGE_OPACITY.Value = 50
        Call SUB_REFRESH_THUBNAIL()
    End Sub

    Private Sub MNI_DISABLE_IMAGE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_DISABLE_IMAGE.Click
        SLI_APPEND_IMAGE_OPACITY.Value = SLI_APPEND_IMAGE_OPACITY.Maximum
        STR_PATH_IMAGE_FILE = ""
        Call SUB_INIT_IMAGE()
        Call SUB_REFRESH_THUBNAIL()
    End Sub

    Private Sub MNI_CLOSE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_CLOSE.Click
        Call Me.Close()
    End Sub

    Private Sub MNI_RATE_LOCK_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_LOCK.Click
        If MNI_RATE_LOCK.IsChecked Then
            Call SUB_SET_RATE()
        End If
    End Sub
#End Region

    Private Sub SLI_APPEND_IMAGE_OPACITY_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles SLI_APPEND_IMAGE_OPACITY.ValueChanged
        Call SUB_REFRESH_THUBNAIL()
    End Sub

    Private Sub WPF_THUMBNAIL_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.CHECK_CLOSED = True
    End Sub

    Private Sub WPF_THUMBNAIL_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
        Call SUB_SET_RATE()
        Call SUB_REFRESH_THUBNAIL()
    End Sub

    Private Sub WPF_THUMBNAIL_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub WPF_THUMBNAIL_KeyDown(sender As Object, e As Windows.Input.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub WPF_THUMBNAIL_KeyUp(sender As Object, e As Windows.Input.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub WPF_THUMBNAIL_MouseLeave(sender As Object, e As Windows.Input.MouseEventArgs) Handles Me.MouseLeave
        Me.PCB_COMPOSITION.Visibility = Visibility.Hidden
    End Sub

    Private Sub WPF_THUMBNAIL_MouseEnter(sender As Object, e As Windows.Input.MouseEventArgs) Handles Me.MouseEnter
        Me.PCB_COMPOSITION.Visibility = Visibility.Visible
    End Sub


End Class
