Imports SlimDX.Direct3D9
Friend Module MOD_SLIM_DX

#Region "変数"
    Private _direct3D9 As SlimDX.Direct3D9.Direct3D = New SlimDX.Direct3D9.Direct3D()
    Private _device As SlimDX.Direct3D9.Device
    Private _surface As SlimDX.Direct3D9.Surface
    Private intBUCK_BUFFER_WIDTH As Integer
    Private intBUCK_BUFFER_HEIGHT As Integer

    Private recCAPTURE As System.Drawing.Rectangle
#End Region

    Public Sub SUB_INIT_SLIM_DX_CAPTURE(ByRef prcWINDOW As Process)
        Dim rctCLIENT As RECT
        Dim rctWINDOW As RECT
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer
        Dim itnWIDTH_WINDOW As Integer
        Dim itnHEIGHT_WINDOW As Integer
        Dim intLEFT As Integer
        Dim intTOP As Integer
        Dim intBORDER As Integer

        recCAPTURE = Nothing
        intBUCK_BUFFER_WIDTH = 0
        intBUCK_BUFFER_HEIGHT = 0

        'rctCLIENT = FUNC_GET_CRIENT_RECT(prcWINDOW)
        'rctWINDOW = FUNC_GET_WINDOW_RECT(prcWINDOW)

        'intWIDTH = FUNC_GET_RECT_WIDTH(rctCLIENT)
        'intHEIGHT = FUNC_GET_RECT_HEIGHT(rctCLIENT)

        'itnWIDTH_WINDOW = FUNC_GET_RECT_WIDTH(rctWINDOW)
        'itnHEIGHT_WINDOW = FUNC_GET_RECT_HEIGHT(rctWINDOW)

        intLEFT = rctWINDOW.left
        intTOP = rctWINDOW.top
        If intLEFT <> 0 Then
            intLEFT += intBORDER
        End If
        If intTOP <> 0 Then
            intTOP += ((itnHEIGHT_WINDOW - intBORDER * 2) - intHEIGHT) + intBORDER
        End If

        intBUCK_BUFFER_WIDTH = intWIDTH
        intBUCK_BUFFER_HEIGHT = intHEIGHT

        recCAPTURE = New System.Drawing.Rectangle(intLEFT, intTOP, intWIDTH, intHEIGHT)

        Dim parameters As SlimDX.Direct3D9.PresentParameters
        parameters = New SlimDX.Direct3D9.PresentParameters()
        'parameters.BackBufferFormat = _direct3D9.Adapters.DefaultAdapter.CurrentDisplayMode.Format
        'parameters.BackBufferHeight = intBUCK_BUFFER_HEIGHT
        'parameters.BackBufferWidth = intBUCK_BUFFER_WIDTH
        'parameters.Multisample = SlimDX.Direct3D9.MultisampleType.None
        'parameters.SwapEffect = SlimDX.Direct3D9.SwapEffect.Discard
        'parameters.DeviceWindowHandle = prcWINDOW.MainWindowHandle
        'parameters.PresentationInterval = SlimDX.Direct3D9.PresentInterval.Default
        'parameters.FullScreenRefreshRateInHertz = 0
        parameters.PresentFlags = PresentFlags.LockableBackBuffer
        '        _device = New SlimDX.Direct3D9.Device(_direct3D9, _direct3D9.Adapters.DefaultAdapter.Adapter, SlimDX.Direct3D9.DeviceType.Hardware, prcWINDOW.MainWindowHandle, SlimDX.Direct3D9.CreateFlags.SoftwareVertexProcessing, parameters)
        _device = New SlimDX.Direct3D9.Device(_direct3D9, _direct3D9.Adapters.DefaultAdapter.Adapter, SlimDX.Direct3D9.DeviceType.Hardware, 0, SlimDX.Direct3D9.CreateFlags.SoftwareVertexProcessing, parameters)

        '        _surface = SlimDX.Direct3D9.Surface.CreateOffscreenPlain(_device, _direct3D9.Adapters.DefaultAdapter.CurrentDisplayMode.Width, _direct3D9.Adapters.DefaultAdapter.CurrentDisplayMode.Height, SlimDX.Direct3D9.Format.A8R8G8B8, SlimDX.Direct3D9.Pool.SystemMemory)
        _surface = SlimDX.Direct3D9.Surface.CreateOffscreenPlain(_device, _direct3D9.Adapters.DefaultAdapter.CurrentDisplayMode.Width, _direct3D9.Adapters.DefaultAdapter.CurrentDisplayMode.Height, SlimDX.Direct3D9.Format.A8R8G8B8, SlimDX.Direct3D9.Pool.SystemMemory)

    End Sub

    Public Function FUNC_SLIM_DX_GET_BITMAP() As System.Drawing.Bitmap
        Dim bmpRET As System.Drawing.Bitmap
        bmpRET = Nothing

        Call _device.GetFrontBufferData(0, _surface)
        Dim strA As SlimDX.DataStream
        'strA = SlimDX.Direct3D9.Surface.ToStream(_surface, SlimDX.Direct3D9.ImageFileFormat.Bmp, recCAPTURE)
        strA = SlimDX.Direct3D9.Surface.ToStream(_surface, SlimDX.Direct3D9.ImageFileFormat.Bmp)


        bmpRET = New System.Drawing.Bitmap(strA)

        ' bmpRET = New Bitmap(SlimDX.Direct3D9.Surface.ToStream(_surface, SlimDX.Direct3D9.ImageFileFormat.Bmp, recCAPTURE))
        Return bmpRET
    End Function
End Module
