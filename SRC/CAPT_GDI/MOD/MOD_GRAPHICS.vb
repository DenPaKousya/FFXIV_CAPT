Imports System.Runtime.InteropServices
Friend Module MOD_GRAPHICS

#Region "WINAPI"
    <DllImport("user32.dll")> Private Function PrintWindow(ByVal hWnd As System.IntPtr, ByVal dc As System.IntPtr, ByVal reservedFlag As UInteger) As Integer
    End Function
#End Region

#Region "構造体"
    Private Structure SRT_CLIENT_IMAGE
        Public RECT As RECT
        Public PIXEL_FORMAT As System.Drawing.Imaging.PixelFormat
        Public HEIGHT As Integer
        Public WIDTH As Integer
        Public GRAPH As System.Drawing.Graphics
        Public IMAGE As System.Drawing.Bitmap
    End Structure

#End Region

#Region "変数"
    Private srtPARAM As SRT_CLIENT_IMAGE
#End Region

    Delegate Function DelPrintWindow(ByVal hWnd As System.IntPtr, ByVal dc As System.IntPtr, ByVal reservedFlag As UInteger) As Integer
    Private lodUSER32 As DynamicLibraryLoader
    Private delPRINT_WINDOW As [Delegate]
    Private mtdPRINT_WINDOW As DelPrintWindow

    Public Sub SUB_INIT_GAPHICS()
        Dim blnRET As Boolean

        lodUSER32 = New DynamicLibraryLoader

        blnRET = lodUSER32.Load("user32.dll")

        If Not blnRET Then
            lodUSER32 = Nothing
            Exit Sub
        End If

        delPRINT_WINDOW = lodUSER32.GetDelegate("PrintWindow", GetType(DelPrintWindow))

        If delPRINT_WINDOW Is Nothing Then
            Call lodUSER32.Free()
            Exit Sub
        End If

        mtdPRINT_WINDOW = CType(delPRINT_WINDOW, DelPrintWindow)
    End Sub

    Public Sub SUB_END_GAPHICS()

        If Not delPRINT_WINDOW Is Nothing Then
            delPRINT_WINDOW = Nothing
        End If

        If lodUSER32 Is Nothing Then
            Exit Sub
        End If

        Call lodUSER32.Free()

        lodUSER32 = Nothing
    End Sub

    Public Function FUNC_INIT_CLIENT_IMAGE() As Boolean

        With srtPARAM
            .RECT = FUNC_GET_CRIENT_RECT(prcTARGET)
            .PIXEL_FORMAT = System.Drawing.Imaging.PixelFormat.Format24bppRgb '24bit指定
            .HEIGHT = FUNC_GET_RECT_HEIGHT(.RECT)
            .WIDTH = FUNC_GET_RECT_WIDTH(.RECT)

            If .HEIGHT <= 0 Then
                Return False
            End If

            If .WIDTH <= 0 Then
                Return False
            End If

            .IMAGE = New System.Drawing.Bitmap(.WIDTH, .HEIGHT, .PIXEL_FORMAT)
            .GRAPH = System.Drawing.Graphics.FromImage(.IMAGE)
        End With

        Return True
    End Function

    Public Sub SUB_PRINT_WINDOW_TEST(ByRef grpBITMAP As Graphics)
        Dim ptrGRAPHIC As IntPtr
        Const cstFLAG As UInteger = (1 Or 2)

        If grpBITMAP Is Nothing Then
            Exit Sub
        End If

        If prcTARGET Is Nothing Then
            Exit Sub
        End If

        ptrGRAPHIC = grpBITMAP.GetHdc

        If delPRINT_WINDOW Is Nothing Then
            Exit Sub
        End If

        Call mtdPRINT_WINDOW(prcTARGET.MainWindowHandle, ptrGRAPHIC, cstFLAG)

        Call grpBITMAP.ReleaseHdc(ptrGRAPHIC)
    End Sub

    Public Sub SUB_PRINT_WINDOW(ByRef grpBITMAP As Graphics)
        Dim ptrGRAPHIC As IntPtr
        Const cstFLAG As UInteger = (1 Or 2)

        If grpBITMAP Is Nothing Then
            Exit Sub
        End If

        If prcTARGET Is Nothing Then
            Exit Sub
        End If

        ptrGRAPHIC = grpBITMAP.GetHdc
        Call PrintWindow(prcTARGET.MainWindowHandle, ptrGRAPHIC, cstFLAG)
        Call grpBITMAP.ReleaseHdc(ptrGRAPHIC)
    End Sub

#Region "現状未使用"

    Public Function FUNC_GET_CLIENT_BITMAP() As Bitmap
        Dim bmpRET As System.Drawing.Bitmap
        Dim pftPIXEL_FORMAT As System.Drawing.Imaging.PixelFormat
        Dim rctPROCESS_CLIENT As RECT
        Dim grpPROCESS_WINDOW As System.Drawing.Graphics

        Dim intHEIGHT As Integer
        Dim intWIDTH As Integer

        If prcTARGET Is Nothing Then
            Return Nothing
        End If

        pftPIXEL_FORMAT = System.Drawing.Imaging.PixelFormat.Format24bppRgb '24bit指定

        rctPROCESS_CLIENT = FUNC_GET_CRIENT_RECT(prcTARGET)

        intHEIGHT = FUNC_GET_RECT_HEIGHT(rctPROCESS_CLIENT)
        intWIDTH = FUNC_GET_RECT_WIDTH(rctPROCESS_CLIENT)

        If intHEIGHT <= 0 Then
            Return Nothing
        End If

        If intWIDTH <= 0 Then
            Return Nothing
        End If

        bmpRET = New System.Drawing.Bitmap(intWIDTH, intHEIGHT, pftPIXEL_FORMAT)

        grpPROCESS_WINDOW = System.Drawing.Graphics.FromImage(bmpRET)

        Call SUB_PRINT_WINDOW(grpPROCESS_WINDOW)

        Return bmpRET
    End Function

    Public Function FUNC_GET_CLIENT_IMAGE() As Image
        Dim imgRET As System.Drawing.Image
        Dim bmpTEMP As System.Drawing.Bitmap
        Dim pftPIXEL_FORMAT As System.Drawing.Imaging.PixelFormat
        Dim rctPROCESS_CLIENT As RECT
        Dim grpPROCESS_WINDOW As System.Drawing.Graphics

        Dim intHEIGHT As Integer
        Dim intWIDTH As Integer

        If prcTARGET Is Nothing Then
            Return Nothing
        End If

        pftPIXEL_FORMAT = System.Drawing.Imaging.PixelFormat.Format24bppRgb '24bit指定

        rctPROCESS_CLIENT = FUNC_GET_CRIENT_RECT(prcTARGET)

        intHEIGHT = FUNC_GET_RECT_HEIGHT(rctPROCESS_CLIENT)
        intWIDTH = FUNC_GET_RECT_WIDTH(rctPROCESS_CLIENT)

        If intHEIGHT <= 0 Then
            Return Nothing
        End If

        If intWIDTH <= 0 Then
            Return Nothing
        End If

        bmpTEMP = New System.Drawing.Bitmap(intWIDTH, intHEIGHT, pftPIXEL_FORMAT)
        imgRET = bmpTEMP
        grpPROCESS_WINDOW = System.Drawing.Graphics.FromImage(imgRET)

        Call SUB_PRINT_WINDOW(grpPROCESS_WINDOW)

        Return imgRET
    End Function
#End Region

    Public Function FUNC_GET_CLIENT_DEFAULT_IMAGE() As Image
        Dim imgRET As System.Drawing.Image
        Dim bmpTEMP As System.Drawing.Bitmap
        Dim pftPIXEL_FORMAT As System.Drawing.Imaging.PixelFormat
        Dim rctPROCESS_CLIENT As RECT

        Dim intHEIGHT As Integer
        Dim intWIDTH As Integer

        If prcTARGET Is Nothing Then
            Return Nothing
        End If

        pftPIXEL_FORMAT = System.Drawing.Imaging.PixelFormat.Format24bppRgb '24bit指定

        rctPROCESS_CLIENT = FUNC_GET_CRIENT_RECT(prcTARGET)

        intHEIGHT = FUNC_GET_RECT_HEIGHT(rctPROCESS_CLIENT)
        intWIDTH = FUNC_GET_RECT_WIDTH(rctPROCESS_CLIENT)

        If intHEIGHT <= 0 Then
            Return Nothing
        End If

        If intWIDTH <= 0 Then
            Return Nothing
        End If

        bmpTEMP = New System.Drawing.Bitmap(intWIDTH, intHEIGHT, pftPIXEL_FORMAT)
        imgRET = bmpTEMP

        Return imgRET
    End Function

End Module
