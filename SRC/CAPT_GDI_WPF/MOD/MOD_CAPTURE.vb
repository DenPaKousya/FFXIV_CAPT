Imports System.Runtime.InteropServices
Friend Module MOD_CAPTURE

#Region "モジュール用・定数"
    Const CST_FILE_EXETENT_PNG As String = ".png"
    Const CST_FILE_EXETENT_JPEG As String = ".jpg"
    Const CST_FILE_EXETENT_TIFF As String = ".tif"
#End Region

#Region "モジュール用・構造体"
    Public Structure SRT_CAPT_COLOR
        Public R As Integer
        Public G As Integer
        Public B As Integer
    End Structure

    Public Structure SRT_PARAMETER_CAPT_LOGO
        Public ADD_LOGO As Boolean
        Public BMP_LOGO As Bitmap
        Public SIZE As RECT_WH
    End Structure

    Public Structure SRT_PARAMETER_CAPT
        Public PATH_SAVE As String
        Public PATH_SAVE_FOLDER_NAME As String
        Public PATH_SAVE_FILE_NAME As String
        Public IMAGE_FORMAT As Integer
        Public ADD_COPYRIGHT As Boolean
        Public IMAGE_INDEX_INIT As Integer
        Public SOUND_CAPTURE As Boolean
        Public COUNT_CAPTURE As Integer
        Public TIMER_CAPTURE As Integer
        Public INTERVAL_CAPTURE As Integer

        Public ENABLED_SEND_KEY As Boolean
        Public INDEX_SEND_KEY As Integer
        Public INTERVAL_SEND_KEY As Integer

        Public ROTATE_FLIP_TYPE As RotateFlipType
        Public TRIM_VALUE As RECT_WH
        Public FORCE_JPEG As Boolean
        Public APPEND_JPEG As Boolean

        Public LOGO As SRT_PARAMETER_CAPT_LOGO

        Public ENABLED_AEB As Boolean
    End Structure

    Private Structure SRT_IMAGE_SAVE
        Public DIR As String
        Public NAME_FILE As String
        Public IMAGE As System.Drawing.Bitmap
    End Structure

    Private Structure SRT_WINDOW
        Public NAME_CLASS As String
        Public TITLE As String
        Public HANDLE As IntPtr
        Public STYLE As Integer
    End Structure
#End Region

#Region "モジュール用・変数"
    Private FRM_PARENT As FRM_MAIN
    Private trdLOOP_DOEVENTS As System.Threading.Thread

#Region "パラメータ関係"

    Private strDIR_SAVE As String
    Private blnNUMBERING As Boolean
    Private intIMAGE_INDEX_INIT As Integer
    Private intCOUNT_CAPTURE_MAX As Integer
    Private intCOUNT_CAPTURE As Integer
    Private intTIMER_CAPTURE As Integer
    Private intINTERVAL_CAPTURE As Integer
    Private blnSOUND_CAPTURE As Boolean
    Private blnCAPTURE_DONE As Boolean
    Private datDATE_CAPTURE_INIT As System.DateTime
    Private strIMAGE_PATH_FILE_NAME As String
    Private strIMAGE_PATH_FOLDER_NAME As String

    Private blnENABLED_SEND_KEYS As Boolean
    Private intCODE_SEND_KEYS As Integer
    Private intINTERVAL_SEND_KEY As Integer

    Private enmROTATE_FLIP_TYPE As RotateFlipType
    Private recTRIM_VALUE As RECT_WH
    Private blnADD_COPYRIGHT As Boolean
    Private srtLOGO As SRT_PARAMETER_CAPT_LOGO
    Private blnSAVE_IMAGE_NORMAL As Boolean
    Private blnFORCE_JPEG As Boolean

    Private BLN_ENABLED_AEB As Boolean
#End Region

#Region "画像ファイル関係"
    Private srtIMAGE_SAVE() As SRT_IMAGE_SAVE

    Private enmIMAGE_FORMAT_CAPTURE As System.Drawing.Imaging.ImageFormat
    Private cdcIMAGE_FORMAT_CAPTURE As System.Drawing.Imaging.ImageCodecInfo
    Private prmIMAGE_ENCODER_CAPTURE As System.Drawing.Imaging.EncoderParameters
    Private strFILE_EXETENT_CAPTURE As String

    Private enmIMAGE_FORMAT_CAPTURE_JPEG As System.Drawing.Imaging.ImageFormat
    Private cdcIMAGE_FORMAT_CAPTURE_JPEG As System.Drawing.Imaging.ImageCodecInfo
    Private prmIMAGE_ENCODER_CAPTURE_JPEG As System.Drawing.Imaging.EncoderParameters
#End Region

#Region "内部状態関係"
    Private blnCONTINUOUS_SHOOTING As Boolean
    Private blnLOCK_SAVE_CONTINUOUS_SHOOTING As Boolean = False

#End Region

#Region "キャプチャ用持ち回り"
    Private rctPROCESS_CLIENT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT

    Private bmpPROCESS_CLIENT As System.Drawing.Bitmap
    Private grpPROCESS_WINDOW As System.Drawing.Graphics

    Friend bytIMAGE_PIXELS As Byte()
#End Region

#End Region

#Region "参照用・変数"
    Public blnMOD_CAPTURE_DO As Boolean = False
    Public bnlMOD_CAPTURE_NEED_CANCEL As Boolean = False 'キャンセル可否
#End Region

    Public Sub SUB_INIT_CAPTURE(ByRef frmPARENT As FRM_MAIN, ByVal srtPARAM As SRT_PARAMETER_CAPT)
        If blnLOCK_SAVE_CONTINUOUS_SHOOTING Then
            Exit Sub
        End If

        MOD_CAPTURE.FRM_PARENT = frmPARENT

        Call SUB_SET_CAPTURE_PARAM(srtPARAM)

        blnLOCK_SAVE_CONTINUOUS_SHOOTING = False

        Erase srtIMAGE_SAVE
        srtIMAGE_SAVE = Nothing
        ReDim srtIMAGE_SAVE(intCOUNT_CAPTURE_MAX)

        blnCAPTURE_DONE = True
        blnMOD_CAPTURE_DO = True
        bnlMOD_CAPTURE_NEED_CANCEL = (intCOUNT_CAPTURE_MAX > 1)
        Call SUB_LOOP_THREAD_START()
    End Sub

    Public Sub SUB_END_CAPTURE()

        If blnCONTINUOUS_SHOOTING Then
            blnLOCK_SAVE_CONTINUOUS_SHOOTING = True
            Call FUNC_SAVE_CONTINUOUS_SHOOTING()
            blnLOCK_SAVE_CONTINUOUS_SHOOTING = False
        End If

        Call SUB_END_CAPTURE_IMAGE()

        strDIR_SAVE = ""
        intCOUNT_CAPTURE_MAX = 0
        intCOUNT_CAPTURE = 0
        blnMOD_CAPTURE_DO = False
        blnCAPTURE_DONE = False

        Call MOD_CAPTURE.SUB_REFRESH_OVERLAY()
        MOD_CAPTURE.FRM_PARENT = Nothing
    End Sub

#Region "内部メソッド"

    Private Sub SUB_REFRESH_OVERLAY_STATE(ByVal strPUT As String)
        If FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        MOD_OVERLAY.PUT_STATE_STR = strPUT

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.REFRESH_OVERLAY_STATE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf FRM_PARENT.SUB_EXEC_DO), myArray)
        Call FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub SUB_REFRESH_OVERLAY()
        If FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.REFRESH_OVERLAY
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf FRM_PARENT.SUB_EXEC_DO), myArray)
        Call FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub SUB_SET_CAPTURE_PARAM(ByVal srtPARAM As SRT_PARAMETER_CAPT)
        Call SUB_SET_CAPTURE_PARAM_SUBST(srtPARAM)
        Call SUB_SET_CAPTURE_PARAM_FILE(srtPARAM.IMAGE_FORMAT)
        Call SUB_INIT_CAPTURE_IMAGE(prcTARGET)
    End Sub

    Private Sub SUB_CAPTURE_MAIN()
        Dim srtSAVE As SRT_IMAGE_SAVE

        Dim strPUT As String

        If intCOUNT_CAPTURE >= intCOUNT_CAPTURE_MAX Then
            Exit Sub
        End If

        strPUT = "CAPTURE..." & "(" & (intCOUNT_CAPTURE + 1) & "/" & intCOUNT_CAPTURE_MAX & ")"
        Call SUB_REFRESH_OVERLAY_STATE(strPUT)

        If blnSOUND_CAPTURE Then
            Call My.Computer.Audio.Play(My.Resources.SOUND_0002, Microsoft.VisualBasic.AudioPlayMode.Background)
        End If

        Call SUB_FIXED_PHRASE_INIT(datDATE_CAPTURE_INIT, intIMAGE_INDEX_INIT + intCOUNT_CAPTURE)

        srtSAVE = FUNC_GET_CAPUTURE_WINDOW(prcTARGET)

        Call SUB_SEND_KEYS()

        If Not (srtSAVE.IMAGE Is Nothing) Then
            If blnCONTINUOUS_SHOOTING Then
                Dim intINDEX As Integer
                intINDEX = intCOUNT_CAPTURE + 1
                With srtIMAGE_SAVE(intINDEX)
                    .DIR = srtSAVE.DIR
                    .NAME_FILE = srtSAVE.NAME_FILE
                    .IMAGE = srtSAVE.IMAGE
                End With
            Else
                Dim stwTIME As Stopwatch
                stwTIME = New System.Diagnostics.Stopwatch
                Call stwTIME.Start()
                strPUT = "SAVE..." & "(" & (intCOUNT_CAPTURE + 1) & "/" & intCOUNT_CAPTURE_MAX & ")"
                Call SUB_REFRESH_OVERLAY_STATE(strPUT)
                Call FUNC_SAVE_IMAGE(srtSAVE)
                Call SUB_NOTHING_SAVE_IMAGE(srtSAVE)
                Call stwTIME.Stop()
                Call SUB_PUT_TRACE("保存時間：" & stwTIME.Elapsed.ToString)
            End If
        End If

        intCOUNT_CAPTURE += 1

        If intCOUNT_CAPTURE >= intCOUNT_CAPTURE_MAX Then
            Call SUB_END_CAPTURE()
        End If
    End Sub

    Private Sub SUB_SEND_KEYS()
        If Not blnENABLED_SEND_KEYS Then
            Exit Sub
        End If
        Call SUB_FOREGROUND_WINDOW(prcTARGET)
        Select Case intCODE_SEND_KEYS
            Case ENM_SEND_KEY_INDEX.LEFT
                Call SUB_SEND_KEYS_LEFT(prcTARGET, intINTERVAL_SEND_KEY)
            Case ENM_SEND_KEY_INDEX.UP
                Call SUB_SEND_KEYS_UP(prcTARGET, intINTERVAL_SEND_KEY)
            Case ENM_SEND_KEY_INDEX.RIGHT
                Call SUB_SEND_KEYS_RIGHT(prcTARGET, intINTERVAL_SEND_KEY)
            Case ENM_SEND_KEY_INDEX.DOWN
                Call SUB_SEND_KEYS_DOWN(prcTARGET, intINTERVAL_SEND_KEY)
            Case ENM_SEND_KEY_INDEX.W
                Call SUB_SEND_KEYS_W(prcTARGET, intINTERVAL_SEND_KEY)
            Case ENM_SEND_KEY_INDEX.A
                Call SUB_SEND_KEYS_A(prcTARGET, intINTERVAL_SEND_KEY)
            Case ENM_SEND_KEY_INDEX.S
                Call SUB_SEND_KEYS_S(prcTARGET, intINTERVAL_SEND_KEY)
            Case ENM_SEND_KEY_INDEX.D
                Call SUB_SEND_KEYS_D(prcTARGET, intINTERVAL_SEND_KEY)
        End Select
    End Sub

    Private Sub SUB_END_CAPTURE_IMAGE()

        If Not (grpPROCESS_WINDOW Is Nothing) Then
            Call grpPROCESS_WINDOW.Dispose()
            Call GC.ReRegisterForFinalize(grpPROCESS_WINDOW)
            grpPROCESS_WINDOW = Nothing
        End If

        If Not (bmpPROCESS_CLIENT Is Nothing) Then
            Call bmpPROCESS_CLIENT.Dispose()
            Call GC.ReRegisterForFinalize(bmpPROCESS_CLIENT)
            bmpPROCESS_CLIENT = Nothing
        End If

        rctPROCESS_CLIENT = Nothing

        Call GC.Collect()
    End Sub

    Private Function FUNC_GET_CAPUTURE_WINDOW(ByRef prcFFXIV As Process) As SRT_IMAGE_SAVE
        Dim srtRET As SRT_IMAGE_SAVE
        Dim strDIR As String
        Dim strFILE_NAME As String

        srtRET = Nothing

        If prcFFXIV Is Nothing Then
            Return srtRET
        End If

        Dim stwTIME As Stopwatch
        stwTIME = New System.Diagnostics.Stopwatch
        Call stwTIME.Start()
        Call SUB_PRINT_WINDOW_TEST(grpPROCESS_WINDOW)
        'bmpPROCESS_CLIENT = FUNC_SLIM_DX_GET_BITMAP()

        Call stwTIME.Stop()
        Call SUB_PUT_TRACE("撮影時間：" & stwTIME.Elapsed.ToString)

        strDIR = strDIR_SAVE & "\" & FUNC_GET_FOLDER_NAME_CAPTURE()
        strFILE_NAME = FUNC_GET_FILE_NAME_CAPTURE()
        With srtRET
            .DIR = strDIR
            .NAME_FILE = strFILE_NAME

            If recTRIM_VALUE.width > 0 And recTRIM_VALUE.height > 0 Then
                Dim bmpTRIM As Bitmap
                bmpTRIM = New Bitmap(recTRIM_VALUE.width, recTRIM_VALUE.height)

                Dim srcRect As System.Drawing.Rectangle
                srcRect = New System.Drawing.Rectangle(recTRIM_VALUE.left, recTRIM_VALUE.top, recTRIM_VALUE.width, recTRIM_VALUE.height)

                Dim desRect As System.Drawing.Rectangle
                desRect = New System.Drawing.Rectangle(0, 0, srcRect.Width, srcRect.Height)

                Dim grpDRAW As Graphics = Graphics.FromImage(bmpTRIM)
                Call grpDRAW.DrawImage(bmpPROCESS_CLIENT, desRect, srcRect, GraphicsUnit.Pixel)
                Call grpDRAW.Dispose()
                .IMAGE = bmpTRIM.Clone
            Else
                .IMAGE = bmpPROCESS_CLIENT.Clone
            End If

            If Not (enmROTATE_FLIP_TYPE = RotateFlipType.RotateNoneFlipNone) Then

                If srtLOGO.ADD_LOGO Then
                    Dim INT_X As Integer
                    Dim INT_Y As Integer
                    Dim INT_WIDTH As Integer
                    Dim INT_HEIGHT As Integer
                    With srtLOGO.SIZE
                        INT_X = .left
                        INT_Y = .top
                        INT_WIDTH = .width
                        INT_HEIGHT = .height
                    End With
                    Select Case enmROTATE_FLIP_TYPE
                        Case RotateFlipType.Rotate90FlipXY
                            With srtLOGO.SIZE
                                .left = INT_Y
                                .top = srtRET.IMAGE.Width - (INT_X + srtLOGO.SIZE.width)
                                .width = INT_HEIGHT
                                .height = INT_WIDTH
                            End With
                            srtLOGO.BMP_LOGO.RotateFlip(RotateFlipType.Rotate90FlipXY)
                        Case RotateFlipType.Rotate270FlipXY
                            With srtLOGO.SIZE
                                .left = srtRET.IMAGE.Height - (INT_Y + srtLOGO.SIZE.height)
                                .top = INT_X
                                .width = INT_HEIGHT
                                .height = INT_WIDTH
                            End With
                            srtLOGO.BMP_LOGO.RotateFlip(RotateFlipType.Rotate270FlipXY)
                        Case Else
                    End Select
                End If

                .IMAGE.RotateFlip(enmROTATE_FLIP_TYPE)
            End If

        End With

        Return srtRET
    End Function

    Private Function FUNC_SAVE_CONTINUOUS_SHOOTING() As Boolean
        Dim intLOOP_INDEX As Integer
        Dim intLOOP_MAX As Integer
        Dim strPUT As String

        If srtIMAGE_SAVE Is Nothing Then
            Return True
        End If

        intLOOP_MAX = (srtIMAGE_SAVE.Length - 1)

        Dim stwTIME As Stopwatch
        stwTIME = New System.Diagnostics.Stopwatch
        Call stwTIME.Start()
        stwTIME = New System.Diagnostics.Stopwatch
        Call stwTIME.Start()
        For intLOOP_INDEX = 1 To intLOOP_MAX
            If srtIMAGE_SAVE Is Nothing Then
                Return False
            End If

            strPUT = "SAVE..." & "(" & (intLOOP_INDEX) & "/" & intLOOP_MAX & ")"
            Call SUB_REFRESH_OVERLAY_STATE(strPUT)
            Call FUNC_SAVE_IMAGE(srtIMAGE_SAVE(intLOOP_INDEX))
        Next

        Call stwTIME.Stop()
        Call SUB_PUT_TRACE("保存時間：" & stwTIME.Elapsed.ToString)

        For intLOOP_INDEX = 1 To intLOOP_MAX
            Call SUB_NOTHING_SAVE_IMAGE(srtIMAGE_SAVE(intLOOP_INDEX))
        Next

        ReDim srtIMAGE_SAVE(0)
        Erase srtIMAGE_SAVE
        Return True
    End Function

    Private Function FUNC_SAVE_IMAGE(ByRef srtSAVE As SRT_IMAGE_SAVE)
        Dim strNAME_FILE As String
        Dim strPATH_FILE As String
        Dim strPATH_FILE_JPEG As String
        Dim blnADD_THUBNAIL As Boolean
        If Not FUNC_CHECK_AND_MAKE_DIR(strDIR_SAVE) Then
            Return False
        End If

        With srtSAVE
            If .IMAGE Is Nothing Then
                Return False
            End If

            blnADD_THUBNAIL = False

            strNAME_FILE = FUNC_GET_FILE_NAME_SUB(.DIR, .NAME_FILE)
            strPATH_FILE = .DIR & "\" & strNAME_FILE & strFILE_EXETENT_CAPTURE
            strPATH_FILE_JPEG = .DIR & "\" & strNAME_FILE & CST_FILE_EXETENT_JPEG

            If srtLOGO.ADD_LOGO Then
                Call SUB_ADD_LOGO(.IMAGE, srtLOGO)
            End If

            If blnADD_COPYRIGHT Then
                Call SUB_ADD_COPYRIGHT(.IMAGE)
            End If

            Call SUB_SET_EXIF(.IMAGE)
            If blnSAVE_IMAGE_NORMAL Then
                Try
                    Call .IMAGE.Save(strPATH_FILE, cdcIMAGE_FORMAT_CAPTURE, prmIMAGE_ENCODER_CAPTURE)
                Catch ex As Exception
                    Return False
                End Try

                If Not blnADD_THUBNAIL Then
                    Call MOD_OVERLAY.SUB_ADD_THUMBNAIL_WPF(.IMAGE, strPATH_FILE)
                    blnADD_THUBNAIL = True
                End If
            End If

            If blnFORCE_JPEG Then
                Dim bmpIMAGE_JPEG As Bitmap

                bmpIMAGE_JPEG = FUNC_GET_JPEG_IMAGE(.IMAGE)

                Call SUB_SET_EXIF(bmpIMAGE_JPEG)

                Try
                    Call bmpIMAGE_JPEG.Save(strPATH_FILE_JPEG, cdcIMAGE_FORMAT_CAPTURE_JPEG, prmIMAGE_ENCODER_CAPTURE_JPEG)
                Catch ex As Exception
                    Return False
                End Try

                If Not blnADD_THUBNAIL Then
                    Call MOD_OVERLAY.SUB_ADD_THUMBNAIL_WPF(bmpIMAGE_JPEG, strPATH_FILE_JPEG)
                    blnADD_THUBNAIL = True
                End If

                Call bmpIMAGE_JPEG.Dispose()
                bmpIMAGE_JPEG = Nothing
            End If

            .IMAGE.Dispose()
        End With

        Return True
    End Function

    Private Sub SUB_NOTHING_SAVE_IMAGE(ByRef srtNOTHING As SRT_IMAGE_SAVE)
        If Not srtNOTHING.IMAGE Is Nothing Then
            Call GC.ReRegisterForFinalize(srtNOTHING.IMAGE)
        End If
        srtNOTHING.IMAGE = Nothing
        Call GC.ReRegisterForFinalize(srtNOTHING)
        srtNOTHING = Nothing
    End Sub

    Private Function Dummy() As Boolean
        Return False
    End Function

    Private Function FUNC_GET_JPEG_IMAGE(ByRef bmpBASE As Bitmap) As Bitmap
        Dim bmpRET As Bitmap
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer
        Dim decRATE As Decimal

        Const cstMAX As Integer = 1920

        If bmpBASE.Width > bmpBASE.Height Then
            If bmpBASE.Width > cstMAX Then
                intWIDTH = cstMAX
            Else
                intWIDTH = bmpBASE.Width
            End If

            decRATE = bmpBASE.Width / intWIDTH

            intHEIGHT = bmpBASE.Height / decRATE
        Else
            If bmpBASE.Height > cstMAX Then
                intHEIGHT = cstMAX
            Else
                intHEIGHT = bmpBASE.Height
            End If

            decRATE = bmpBASE.Height / intHEIGHT

            intWIDTH = bmpBASE.Width / decRATE
        End If

        bmpRET = bmpBASE.GetThumbnailImage(intWIDTH, intHEIGHT, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf Dummy), IntPtr.Zero)

        Return bmpRET
    End Function

    Private Sub SUB_ADD_COPYRIGHT(ByRef bmpBASE As Bitmap)
        Dim intWH_LONG As Integer
        If bmpBASE.Height > bmpBASE.Width Then
            intWH_LONG = bmpBASE.Height
        Else
            intWH_LONG = bmpBASE.Width
        End If

        Dim blnLARGE As Boolean
        blnLARGE = (intWH_LONG > 1920)

        Dim STR_EXE As String
        STR_EXE = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim STR_DIR As String
        STR_DIR = FUNC_PATH_TO_DIR_PATH(STR_EXE)
        Call SUB_INIT_CHANGE_IMAGE(STR_DIR & "\RES\IMG\COPYRIGHT")

        Dim bmpCR As Bitmap
        bmpCR = Nothing
        If blnLARGE Then
            bmpCR = FUNC_GET_CHANEG_IMAGE("COPYRIGHT_L.png")
            If bmpCR Is Nothing Then
                bmpCR = My.Resources.COPYRIGHT_L
            End If
        Else
            bmpCR = FUNC_GET_CHANEG_IMAGE("COPYRIGHT_S.png")
            If bmpCR Is Nothing Then
                bmpCR = My.Resources.COPYRIGHT_S
            End If
        End If

        bmpCR.MakeTransparent()

        Dim grpDRAW As Graphics
        grpDRAW = Graphics.FromImage(bmpBASE)
        Call grpDRAW.DrawImage(bmpCR, 0, bmpBASE.Height - bmpCR.Height, bmpCR.Width, bmpCR.Height)
        Call grpDRAW.Dispose()

    End Sub

    Private Sub SUB_ADD_LOGO(ByRef BMP_BASE As Bitmap, ByRef SRT_LOGO As SRT_PARAMETER_CAPT_LOGO)

        Dim GRP_DRAW As Graphics
        GRP_DRAW = Graphics.FromImage(BMP_BASE)

        'Call SRT_LOGO.BMP_LOGO.MakeTransparent()

        Dim INT_WIDTH As Integer
        Dim INT_HEIGHT As Integer
        INT_WIDTH = SRT_LOGO.SIZE.width
        INT_HEIGHT = SRT_LOGO.SIZE.height

        If BMP_BASE.Width = INT_WIDTH Then
            INT_WIDTH += 1
        End If
        If BMP_BASE.Height = INT_HEIGHT Then
            INT_HEIGHT += 1
        End If
        Call GRP_DRAW.DrawImage(SRT_LOGO.BMP_LOGO, SRT_LOGO.SIZE.left, SRT_LOGO.SIZE.top, INT_WIDTH, INT_HEIGHT)
        Call GRP_DRAW.Dispose()
    End Sub

    Private Sub SUB_SET_EXIF(ByRef bmpIMAGE As Bitmap)
        Call FUNC_ADD_EXIF_STRING(bmpIMAGE, ENM_EXIF_ID.Make, "SQUARE ENIX")
        Call FUNC_ADD_EXIF_STRING(bmpIMAGE, ENM_EXIF_ID.Model, "FFXIV")
        Call FUNC_ADD_EXIF_STRING(bmpIMAGE, ENM_EXIF_ID.Software, "ffxiv_dx11")
        Call FUNC_ADD_EXIF_STRING(bmpIMAGE, ENM_EXIF_ID.ModifyDate, FUNC_EXIF_STRING_DATETIME(datDATE_CAPTURE_INIT))
        Call FUNC_ADD_EXIF_STRING(bmpIMAGE, ENM_EXIF_ID.DateTimeOriginal, FUNC_EXIF_STRING_DATETIME(datDATE_CAPTURE_INIT))

        Call FUNC_ADD_EXIF_INT16(bmpIMAGE, ENM_EXIF_ID.ISOSpeedRatings, FUNC_EXIF_INT_DATETIME(datDATE_CAPTURE_INIT))
    End Sub

    Private Function FUNC_EXIF_INT_DATETIME(ByVal datDATE_TIME As DateTime) As Integer
        Dim intRET As Integer
        Dim intYEAR As Integer
        Dim intMONTH As Integer
        Dim intYEAR_2L As Integer

        intYEAR = datDATE_TIME.Year
        intMONTH = datDATE_TIME.Month

        intYEAR_2L = CInt(intYEAR.ToString.Substring(2, 2))
        intRET = intYEAR_2L * 100 + intMONTH
        Return intRET
    End Function

    Private Function FUNC_EXIF_STRING_DATETIME(ByVal datDATE_TIME As DateTime) As String
        Dim strRET As String
        Dim intYEAR As Integer
        Dim intMONTH As Integer
        Dim intDAY As Integer
        Dim strDATE As String
        Dim intHOUR As Integer
        Dim intMINUTE As Integer
        Dim intSECOND As Integer
        Dim strTIME As String

        intYEAR = datDATE_TIME.Year
        intMONTH = datDATE_TIME.Month
        intDAY = datDATE_TIME.Day

        strDATE = intYEAR.ToString.PadLeft(4, "0") & ":" & intMONTH.ToString.PadLeft(2, "0") & ":" & intDAY.ToString.PadLeft(2, "0")

        intHOUR = datDATE_TIME.Hour
        intMINUTE = datDATE_TIME.Minute
        intSECOND = datDATE_TIME.Second

        strTIME = intHOUR.ToString.PadLeft(2, "0") & ":" & intMINUTE.ToString.PadLeft(2, "0") & ":" & intSECOND.ToString.PadLeft(2, "0")

        strRET = strDATE & " " & strTIME

        Return strRET
    End Function

#Region "SUB_SET_CAPTURE_PARAM(内部)"
    Private Sub SUB_SET_CAPTURE_PARAM_SUBST(ByVal srtPARAM As SRT_PARAMETER_CAPT)
        Const cstINTERVAL_CAPTURE_MIN As Integer = 100
        Const cstCOUNT_CAPTURE_MAX_CONTINUOUS_SHOOTING As Integer = 50

        strDIR_SAVE = srtPARAM.PATH_SAVE
        blnNUMBERING = False
        intIMAGE_INDEX_INIT = srtPARAM.IMAGE_INDEX_INIT
        intCOUNT_CAPTURE_MAX = srtPARAM.COUNT_CAPTURE
        intTIMER_CAPTURE = srtPARAM.TIMER_CAPTURE
        intINTERVAL_CAPTURE = srtPARAM.INTERVAL_CAPTURE
        intINTERVAL_CAPTURE = If(intINTERVAL_CAPTURE < cstINTERVAL_CAPTURE_MIN, cstINTERVAL_CAPTURE_MIN, intINTERVAL_CAPTURE)
        intCOUNT_CAPTURE = 0
        datDATE_CAPTURE_INIT = System.DateTime.Now
        strIMAGE_PATH_FILE_NAME = srtPARAM.PATH_SAVE_FILE_NAME
        strIMAGE_PATH_FOLDER_NAME = srtPARAM.PATH_SAVE_FOLDER_NAME
        blnADD_COPYRIGHT = srtPARAM.ADD_COPYRIGHT
        srtLOGO = srtPARAM.LOGO

        blnSOUND_CAPTURE = srtPARAM.SOUND_CAPTURE
        blnCONTINUOUS_SHOOTING = (intINTERVAL_CAPTURE < 500) And (intCOUNT_CAPTURE_MAX > 1)
        If blnCONTINUOUS_SHOOTING Then '連写の場合は
            intCOUNT_CAPTURE_MAX = If(intCOUNT_CAPTURE_MAX > cstCOUNT_CAPTURE_MAX_CONTINUOUS_SHOOTING, cstCOUNT_CAPTURE_MAX_CONTINUOUS_SHOOTING, intCOUNT_CAPTURE_MAX) '99枚まで
        End If

        blnENABLED_SEND_KEYS = srtPARAM.ENABLED_SEND_KEY
        intCODE_SEND_KEYS = srtPARAM.INDEX_SEND_KEY
        intINTERVAL_SEND_KEY = srtPARAM.INTERVAL_SEND_KEY

        blnSAVE_IMAGE_NORMAL = True '通常保存はデフォルトTRUE
        enmROTATE_FLIP_TYPE = srtPARAM.ROTATE_FLIP_TYPE
        recTRIM_VALUE = srtPARAM.TRIM_VALUE
        blnFORCE_JPEG = srtPARAM.FORCE_JPEG
        If blnFORCE_JPEG Then
            blnSAVE_IMAGE_NORMAL = False
        End If

        BLN_ENABLED_AEB = srtPARAM.ENABLED_AEB
    End Sub

    Private Sub SUB_SET_CAPTURE_PARAM_FILE(ByVal enmIMAGE_FORMAT As ENM_IMAGE_FORMAT)
        Dim encKIND As System.Drawing.Imaging.Encoder
        Dim prmONE As System.Drawing.Imaging.EncoderParameter

        prmIMAGE_ENCODER_CAPTURE = Nothing
        Select Case enmIMAGE_FORMAT
            Case ENM_IMAGE_FORMAT.PNG
                enmIMAGE_FORMAT_CAPTURE = System.Drawing.Imaging.ImageFormat.Png
                strFILE_EXETENT_CAPTURE = CST_FILE_EXETENT_PNG
                cdcIMAGE_FORMAT_CAPTURE = FUNC_GET_ENCODER_INFO(enmIMAGE_FORMAT_CAPTURE)
            Case ENM_IMAGE_FORMAT.JPEG
                enmIMAGE_FORMAT_CAPTURE = System.Drawing.Imaging.ImageFormat.Jpeg
                strFILE_EXETENT_CAPTURE = CST_FILE_EXETENT_JPEG
                cdcIMAGE_FORMAT_CAPTURE = FUNC_GET_ENCODER_INFO(enmIMAGE_FORMAT_CAPTURE)
                encKIND = System.Drawing.Imaging.Encoder.Quality
                prmONE = New System.Drawing.Imaging.EncoderParameter(encKIND, 100L)
                prmIMAGE_ENCODER_CAPTURE = New System.Drawing.Imaging.EncoderParameters(1)
                prmIMAGE_ENCODER_CAPTURE.Param(0) = prmONE
            Case ENM_IMAGE_FORMAT.TIFF
                enmIMAGE_FORMAT_CAPTURE = System.Drawing.Imaging.ImageFormat.Tiff
                strFILE_EXETENT_CAPTURE = CST_FILE_EXETENT_TIFF
                cdcIMAGE_FORMAT_CAPTURE = FUNC_GET_ENCODER_INFO(enmIMAGE_FORMAT_CAPTURE)
            Case Else
                enmIMAGE_FORMAT_CAPTURE = System.Drawing.Imaging.ImageFormat.Png
                strFILE_EXETENT_CAPTURE = CST_FILE_EXETENT_PNG
                cdcIMAGE_FORMAT_CAPTURE = FUNC_GET_ENCODER_INFO(enmIMAGE_FORMAT_CAPTURE)
        End Select

        '固定JPEG保存用のパラメータ指定
        enmIMAGE_FORMAT_CAPTURE_JPEG = System.Drawing.Imaging.ImageFormat.Jpeg
        cdcIMAGE_FORMAT_CAPTURE_JPEG = FUNC_GET_ENCODER_INFO(enmIMAGE_FORMAT_CAPTURE_JPEG)
        encKIND = System.Drawing.Imaging.Encoder.Quality
        prmONE = New System.Drawing.Imaging.EncoderParameter(encKIND, 66L) '
        prmIMAGE_ENCODER_CAPTURE_JPEG = New System.Drawing.Imaging.EncoderParameters(1)
        prmIMAGE_ENCODER_CAPTURE_JPEG.Param(0) = prmONE

    End Sub

    Private Sub SUB_INIT_CAPTURE_IMAGE(ByRef prcFFXIV As Process)
        Dim pftPIXEL_FORMAT As System.Drawing.Imaging.PixelFormat
        rctPROCESS_CLIENT = Nothing
        bmpPROCESS_CLIENT = Nothing
        grpPROCESS_WINDOW = Nothing

        If prcFFXIV Is Nothing Then
            Exit Sub
        End If

        rctPROCESS_CLIENT = FUNC_GET_CRIENT_RECT(prcFFXIV)

        pftPIXEL_FORMAT = System.Drawing.Imaging.PixelFormat.Format24bppRgb '24bit指定
        'pftPIXEL_FORMAT = System.Drawing.Imaging.PixelFormat.Format48bppRgb

        bmpPROCESS_CLIENT = New System.Drawing.Bitmap(FUNC_GET_RECT_WIDTH(rctPROCESS_CLIENT), FUNC_GET_RECT_HEIGHT(rctPROCESS_CLIENT), pftPIXEL_FORMAT)

        grpPROCESS_WINDOW = System.Drawing.Graphics.FromImage(bmpPROCESS_CLIENT)
    End Sub

#End Region

#Region "THREAD"
    Private Sub SUB_LOOP_THREAD_START()
        If Not trdLOOP_DOEVENTS Is Nothing Then
            trdLOOP_DOEVENTS.Abort()
        End If
        trdLOOP_DOEVENTS = Nothing
        trdLOOP_DOEVENTS = New Threading.Thread(New Threading.ThreadStart(AddressOf SUB_DOEVENTS_LOOP))
        trdLOOP_DOEVENTS.IsBackground = True
        trdLOOP_DOEVENTS.Start()
    End Sub

    Private Sub SUB_DOEVENTS_LOOP()
        Dim stwTHREAD As Stopwatch
        Dim intMSEC_THREAD As Integer
        Dim intMSEC_THREAD_SUB As Integer
        Const cstMSEC_INTERVAL_THREAD As Integer = 50

        Dim sw As System.Diagnostics.Stopwatch
        Dim intELAPSED As Integer
        Dim intCHECK_TIME As Integer

        sw = New System.Diagnostics.Stopwatch
        Call sw.Start()

        stwTHREAD = New System.Diagnostics.Stopwatch
        Call stwTHREAD.Start()
        Call stwTHREAD.Stop()

        Dim INT_INDEX_AEB As Integer
        INT_INDEX_AEB = 0
        INT_INDEX_BRIGHTNESS = 0
        Do
            Call stwTHREAD.Restart()

            If Not blnCAPTURE_DONE Then
                Exit Do
            End If

            If intCOUNT_CAPTURE = 0 Then
                intCHECK_TIME = intTIMER_CAPTURE
            Else
                intCHECK_TIME = intINTERVAL_CAPTURE
            End If

            Call sw.Stop()
            intELAPSED = sw.ElapsedMilliseconds
            If intELAPSED > intCHECK_TIME Then
                Call sw.Restart()
                If BLN_ENABLED_AEB Then
                    INT_INDEX_AEB += 1
                    Call SUB_AEB_EVENT(INT_INDEX_AEB)
                End If
                Call SUB_CAPTURE_MAIN()
                If BLN_ENABLED_AEB Then
                    If INT_INDEX_AEB >= 3 Then
                        Call SUB_AEB_EVENT(1)
                    End If
                End If
            Else
                Call sw.Start()
            End If

            Call stwTHREAD.Stop()
            intMSEC_THREAD = stwTHREAD.ElapsedMilliseconds
            intMSEC_THREAD_SUB = (cstMSEC_INTERVAL_THREAD - intMSEC_THREAD)
            If intMSEC_THREAD_SUB > 0 Then
                Call System.Threading.Thread.Sleep(intMSEC_THREAD_SUB)
            End If
        Loop
    End Sub
#End Region

    Private INT_INDEX_BRIGHTNESS As Integer
    Private Sub SUB_AEB_EVENT(ByVal INT_INDEX_AEB As Integer)
        Dim INT_ADD As Integer = 50
        Dim INT_MSEC_LOOP As Integer = 40

        Select Case INT_INDEX_AEB
            Case 1
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_R, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call SUB_SET_MOUSE_POINTER_CLIENT(20, 20)
                Call SUB_MOUSE_LEFT_CLICK()
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_R, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_R, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD0, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                If INT_INDEX_BRIGHTNESS <> 0 Then
                    Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                    Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD0, ENM_MASK_KEYS.NONE)
                    For i = 1 To INT_ADD
                        Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD6, ENM_MASK_KEYS.NONE, INT_MSEC_LOOP)
                    Next
                    Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD8, ENM_MASK_KEYS.NONE)
                End If
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD0, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_R, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(200)
            Case 2
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_R, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD0, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD0, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                For i = 1 To INT_ADD
                    INT_INDEX_BRIGHTNESS += 1
                    Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD6, ENM_MASK_KEYS.NONE, INT_MSEC_LOOP)
                Next

                Call System.Threading.Thread.Sleep(500)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_R, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(200)
            Case 3
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_R, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD0, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD2, ENM_MASK_KEYS.NONE)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD0, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(500)

                For i = 1 To INT_ADD * 2
                    INT_INDEX_BRIGHTNESS -= 1
                    Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_NUMPAD4, ENM_MASK_KEYS.NONE, INT_MSEC_LOOP)
                Next

                Call System.Threading.Thread.Sleep(500)
                Call MOD_SEND_KEYS.FUNC_SEND_KEYS_MASK(prcTARGET, ENM_SEND_VK.VK_R, ENM_MASK_KEYS.NONE)
                Call System.Threading.Thread.Sleep(200)
        End Select
    End Sub

    Private Sub SUB_AEB_CANCEL()
    End Sub

#Region "フォルダ・ファイル名関連"

    Private Function FUNC_GET_FILE_NAME_SUB(ByVal strDIR As String, ByVal strFILEN_NAME_BASE As String) As String
        Dim intLOOP_INDEX As Integer
        Dim strFILE_NAME_INDEX As String

        'If Not FUNC_FILE_CHECK(strDIR & "\" & strFILEN_NAME_BASE & strFILE_EXETENT_CAPTURE) Then
        '    Return strFILEN_NAME_BASE
        'End If

        If Not FUNC_FILE_CHECK_MULTI_EXTENT(strDIR & "\" & strFILEN_NAME_BASE) Then
            Return strFILEN_NAME_BASE
        End If

        strFILE_NAME_INDEX = strFILEN_NAME_BASE
        For intLOOP_INDEX = 1 To 99
            strFILE_NAME_INDEX = strFILEN_NAME_BASE & "_" & intLOOP_INDEX.ToString("00")
            'If Not FUNC_FILE_CHECK(strDIR & "\" & strFILE_NAME_INDEX & strFILE_EXETENT_CAPTURE) Then
            '    Exit For
            'End If
            If Not FUNC_FILE_CHECK_MULTI_EXTENT(strDIR & "\" & strFILE_NAME_INDEX) Then
                Exit For
            End If
        Next

        Return strFILE_NAME_INDEX
    End Function

    Private Function FUNC_FILE_CHECK_MULTI_EXTENT(ByVal strFILE_PATH As String) As Boolean

        If FUNC_FILE_CHECK(strFILE_PATH & CST_FILE_EXETENT_PNG) Then
            Return True
        End If

        If FUNC_FILE_CHECK(strFILE_PATH & CST_FILE_EXETENT_JPEG) Then
            Return True
        End If

        If FUNC_FILE_CHECK(strFILE_PATH & CST_FILE_EXETENT_TIFF) Then
            Return True
        End If

        Return False
    End Function

    Private Function FUNC_CHECK_AND_MAKE_DIR(ByVal strDIR_BASE As String) As Boolean
        If Not FUNC_DIR_MAKE(strDIR_BASE) Then
            Return False
        End If

        Dim strDIR As String
        strDIR = strDIR_BASE & "\" & FUNC_GET_FOLDER_NAME_CAPTURE()
        If Not FUNC_DIR_MAKE(strDIR) Then
            Return False
        End If

        Return True
    End Function

    Private Function FUNC_GET_FOLDER_NAME_CAPTURE() As String
        Dim strRET As String

        strRET = FUNC_GET_FIXED_PHRASE(strIMAGE_PATH_FOLDER_NAME)

        Return strRET
    End Function

    Private Function FUNC_GET_FILE_NAME_CAPTURE() As String
        Dim strRET As String

        strRET = FUNC_GET_FIXED_PHRASE(strIMAGE_PATH_FILE_NAME)

        Return strRET
    End Function
#End Region

#End Region

End Module
