Friend Module MOD_WPF_COMMON

    Public Sub SUB_SET_LOCATION_OVERLAY_WPF(ByRef wpfOVERLAY As System.Windows.Window, enmPOSITION_OVERLAY As ENM_POSITION_OVERLAY)
        Dim pntLOCATION As System.Drawing.Point
        Dim srtRECT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT
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
End Module
