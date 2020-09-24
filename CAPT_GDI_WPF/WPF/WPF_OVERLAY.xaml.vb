Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Threading

Public Delegate Sub WPF_OVERLAY_DELEGATE()
Class WPF_OVERLAY

#Region "プロパティ用変数"
    Private enmPROPERTY_COMPOSTION_TYPE As ENM_DIVISION_PATTERN
#End Region

#Region "プロパティ"
    Public Property DRAWED_COMPOSTION_TYPE As ENM_DIVISION_PATTERN
        Get
            Return enmPROPERTY_COMPOSTION_TYPE
        End Get
        Set(ByVal value As ENM_DIVISION_PATTERN)
            enmPROPERTY_COMPOSTION_TYPE = value
        End Set
    End Property

    Public Property TICK_GET_COLOR_INFO As Boolean
        Get
            Return False 'timGET_COLOR_INFO.Enabled
        End Get
        Set(ByVal value As Boolean)
            'timGET_COLOR_INFO.Enabled = value
        End Set
    End Property

#End Region

    Private dispatcherTimer As System.Windows.Threading.DispatcherTimer

#Region "初期化・終了処理"
    Private Sub SUB_INIT_BUTTONS()
        Dim STR_EXE As String
        STR_EXE = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim STR_DIR As String
        STR_DIR = FUNC_PATH_TO_DIR_PATH(STR_EXE)
        Call SUB_INIT_CHANGE_IMAGE(STR_DIR & "\RES\IMG\OVERLAY")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_CLOSE, "CLOSE.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_COMPOSITION, "COMPOSITION.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_CHANGE_COMPOSITION, "CHANGE_RIGHT.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_ROTATE, "ROTATE.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_SETTING, "SETTING.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_UI, "USER_INTERFACE.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_EXPLORER, "EXPLORER.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_APPEND_IMAGE_LOAD, "APPEND_IMAGE_LOAD.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_APPEND_IMAGE_CHANGE, "APPEND_IMAGE_CHANGE.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_SHUTTER_CONTINUOUS, "SHUTTER_CONTINUOUS.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_LIGHT, "LIGHT.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_TRIM, "TRIM.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_LOGO, "LOGO_ICON.png")

        Call SUB_CHANGE_IMAGE_WPF(PCB_SHUTTER, "SHUTTER_C_W.png")
        Call SUB_CHANGE_IMAGE_WPF(PCB_SHUTTER_JPEG, "SHUTTER_C_G.png")
    End Sub
#End Region

#Region "パラメータ"
    Public Sub SUB_DRAW_PARAMETERS_GUIDE()
        Dim intFONT_SIZE As Integer
        Dim intY As Integer
        Dim strTEMP As String
        Dim bmpGUIDE As Bitmap
        Dim grpGUIDE As Graphics

        If Not PCB_PARAM_GUIDE.Visibility = Visibility.Visible Then
            Exit Sub
        End If

        PCB_PARAM_GUIDE.Source = Nothing

        intFONT_SIZE = Me.FontSize

        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        intWIDTH = CInt(PCB_PARAM_GUIDE.Width)
        intHEIGHT = CInt(PCB_PARAM_GUIDE.Height)

        'ガイド
        bmpGUIDE = New Bitmap(intWIDTH, intHEIGHT)
        grpGUIDE = Graphics.FromImage(bmpGUIDE)
        grpGUIDE.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        intY = 0

        strTEMP = "TIMER"
        Call SUB_DRAW_STRING(grpGUIDE, strTEMP, intFONT_SIZE, 0, intY)
        intY += intFONT_SIZE + 4

        strTEMP = "TYPE"
        Call SUB_DRAW_STRING(grpGUIDE, strTEMP, intFONT_SIZE, 0, intY)
        intY += intFONT_SIZE + 4

        strTEMP = "INDEX"
        Call SUB_DRAW_STRING(grpGUIDE, strTEMP, intFONT_SIZE, 0, intY)
        intY += intFONT_SIZE + 4

        bmpGUIDE.MakeTransparent()
        'If PCB_COMPOSITION.Visible Then
        '    PCB_PARAM_GUIDE.Parent = PCB_COMPOSITION
        'Else
        '    PCB_PARAM_GUIDE.Parent = Me
        'End If
        PCB_PARAM_GUIDE.Source = FUNC_GET_IMAGESOURCE(bmpGUIDE)

        Call grpGUIDE.Dispose()
    End Sub

    Public Sub SUB_DRAW_PARAMETERS_VALUE()
        Dim intY As Integer
        Dim strTEMP As String
        Dim intFONT_SIZE As Integer

        Dim bmpVALUE As Bitmap
        Dim grpVALUE As Graphics

        If Not PCB_PARAM_VALUE.Visibility = Visibility.Visible Then
            Exit Sub
        End If

        PCB_PARAM_VALUE.Source = Nothing

        intFONT_SIZE = Me.FontSize

        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        intWIDTH = CInt(PCB_PARAM_GUIDE.Width)
        intHEIGHT = CInt(PCB_PARAM_GUIDE.Height)

        '値
        bmpVALUE = New Bitmap(intWIDTH, intHEIGHT)
        grpVALUE = Graphics.FromImage(bmpVALUE)
        grpVALUE.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        intY = 0

        strTEMP = srtCAPT_SETTINGS.TIMER_CAPTURE & "ms"
        Call SUB_DRAW_STRING(grpVALUE, strTEMP, intFONT_SIZE, 0, intY)
        intY += intFONT_SIZE + 4

        strTEMP = FUNC_GET_NAME_IMAGE_FORMAT(srtCAPT_SETTINGS.IMAGE_FORMAT)
        Call SUB_DRAW_STRING(grpVALUE, strTEMP, intFONT_SIZE, 0, intY)
        intY += intFONT_SIZE + 4

        strTEMP = MOD_CODE_TOOL.Format(srtCAPT_SETTINGS.IMAGE_INDEX, "00000")
        Call SUB_DRAW_STRING(grpVALUE, strTEMP, intFONT_SIZE, 0, intY)
        intY += intFONT_SIZE + 4

        bmpVALUE.MakeTransparent()
        'If PCB_COMPOSITION.Visible Then
        '    PCB_PARAM_VALUE.Parent = PCB_COMPOSITION
        'Else
        '    PCB_PARAM_VALUE.Parent = Me
        'End If
        PCB_PARAM_VALUE.Source = FUNC_GET_IMAGESOURCE(bmpVALUE)
        Call grpVALUE.Dispose()

    End Sub
#End Region

#Region "ヒストグラム"

#Region "構造体"
    Private Structure SRT_COLOR_INFO
        Public VALUE_FROM As Integer
        Public VALUE_TO As Integer
        Public VALUE_COUNT As Integer
    End Structure
#End Region

#Region "変数"
    Private IMG_PRIVATE_COLOR_INFO As Bitmap
    Private GRP_PRIVATE_COLOR_INFO As Graphics
    Private TIM_PRIVATE_TIMER As System.Timers.Timer
#End Region

    Public Sub SUB_DRAW_COLOR_INFO()
        Dim penDRAW_BORDER As System.Drawing.Pen
        Dim penDRAW_GRAPH As System.Drawing.Pen
        Dim bmpCANVAS As Bitmap
        Dim grpDRAW As Graphics
        Dim intLOOP_INDEX As Integer
        Dim intVALUE(255) As Integer
        Dim intVALUE_MAX As Integer
        Dim decTEMP As Decimal
        Dim intGRAPH As Integer
        Dim bytONE As Byte
        Const cstPEN_SIZE_BORDER As Single = 2
        Const cstPEN_SIZE_GRAPH As Single = 1
        Dim intLENGTH As Integer
        Dim bytPIXELS() As Byte

        PCB_COLOR_INFO.Source = Nothing

        If Not PCB_COLOR_INFO.Visibility = Visibility.Visible Then
            Exit Sub
        End If

        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        intWIDTH = CInt(PCB_COLOR_INFO.Width)
        intHEIGHT = CInt(PCB_COLOR_INFO.Height)

        bmpCANVAS = New Bitmap(intWIDTH, intHEIGHT)
        grpDRAW = Graphics.FromImage(bmpCANVAS)

        penDRAW_BORDER = New System.Drawing.Pen(System.Drawing.Color.White, cstPEN_SIZE_BORDER)
        penDRAW_GRAPH = New System.Drawing.Pen(System.Drawing.Color.Cyan, cstPEN_SIZE_GRAPH)

        Call grpDRAW.DrawLine(penDRAW_BORDER, 0, bmpCANVAS.Height, bmpCANVAS.Width, bmpCANVAS.Height)

        ReDim intVALUE(255)
        intLENGTH = 0 '
        bytPIXELS = FUNC_GET_SS_COLOR_INFO()
        If Not bytPIXELS Is Nothing Then
            intLENGTH = ((bytPIXELS.Length / 255) * 10)
            For intLOOP_INDEX = 0 To (bytPIXELS.Length - 1)
                bytONE = bytPIXELS(intLOOP_INDEX)
                intVALUE(bytONE) += 1
            Next
        End If

        intVALUE_MAX = 0
        For intLOOP_INDEX = 0 To 255
            If intLENGTH <= intVALUE(intLOOP_INDEX) Then
                intVALUE(intLOOP_INDEX) = intLENGTH
            End If
            If intVALUE_MAX <= intVALUE(intLOOP_INDEX) Then
                intVALUE_MAX = intVALUE(intLOOP_INDEX)
            End If
        Next

        For intLOOP_INDEX = 0 To 255
            If intVALUE_MAX = 0 Then
                intGRAPH = 0
            Else
                decTEMP = (intVALUE(intLOOP_INDEX) / intVALUE_MAX) * 128
                intGRAPH = Math.Floor(decTEMP)
            End If
            Call grpDRAW.DrawLine(penDRAW_GRAPH, intLOOP_INDEX, bmpCANVAS.Height - 2, intLOOP_INDEX, bmpCANVAS.Height - 2 - intGRAPH)
        Next

        bmpCANVAS.MakeTransparent()

        PCB_COLOR_INFO.Source = FUNC_GET_IMAGESOURCE(bmpCANVAS)
        Call grpDRAW.Dispose()
    End Sub

    Shared Function dummy() As Boolean
        Return False
    End Function

    Private Function FUNC_GET_SS_COLOR_INFO() As Byte()
        Dim bytRET() As Byte

        bytRET = FUNC_GET_COLOR_ARRAY(IMG_PRIVATE_COLOR_INFO)

        Return bytRET
    End Function

    Private blnDO_RE_PRINT_WINDOW_COLOR_INFO As Boolean = False
    Private Sub SUB_RE_PRINT_WINDOW_COLOR_INFO()
        If blnDO_RE_PRINT_WINDOW_COLOR_INFO Then
            Exit Sub
        End If

        If Not PCB_COLOR_INFO.Visibility = Visibility.Visible Then
            Exit Sub
        End If

        blnDO_RE_PRINT_WINDOW_COLOR_INFO = True
        Call SUB_PRINT_WINDOW_TEST(GRP_PRIVATE_COLOR_INFO)
        'Call SUB_PRINT_WINDOW(GRP_PRIVATE_COLOR_INFO)

        blnDO_RE_PRINT_WINDOW_COLOR_INFO = False
    End Sub
#End Region

#Region "状態"
    Public Sub SUB_DRAW_STATE(ByVal strPUT_STATE As String)
        Dim intFONT_SIZE As Integer
        Dim bmpSTATE As Bitmap
        Dim grpSTATE As Graphics
        Dim intY As Integer
        Dim strTEMP As String

        If Not PCB_STATE.Visibility = Visibility.Visible Then
            Exit Sub
        End If

        PCB_STATE.Source = Nothing

        intFONT_SIZE = Me.FontSize

        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        intWIDTH = CInt(PCB_STATE.Width)
        intHEIGHT = CInt(PCB_STATE.Height)

        bmpSTATE = New Bitmap(intWIDTH, intHEIGHT)
        grpSTATE = Graphics.FromImage(bmpSTATE)
        grpSTATE.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        intY = 0

        strTEMP = strPUT_STATE
        Call SUB_DRAW_STRING(grpSTATE, strTEMP, intFONT_SIZE, 0, intY)
        intY += intFONT_SIZE + 4

        bmpSTATE.MakeTransparent()
        'If PCB_COMPOSITION.Visible Then
        '    PCB_STATE.Parent = PCB_COMPOSITION
        'Else
        '    PCB_STATE.Parent = Me
        'End If
        PCB_STATE.Source = FUNC_GET_IMAGESOURCE(bmpSTATE)
        Call grpSTATE.Dispose()
    End Sub
#End Region

#Region "構図補助"
    Public Sub SUB_DRAW_COMPOSTION(ByVal enmPAT As ENM_DIVISION_PATTERN)
        Dim bmpCANVAS As Bitmap
        Dim grpDRAW As Graphics
        Dim penDRAW As System.Drawing.Pen

        If Me.DRAWED_COMPOSTION_TYPE = enmPAT Then
            Exit Sub
        End If

        PCB_COMPOSITION.Source = Nothing

        If Not PCB_COMPOSITION.Visibility = Visibility.Visible Then
            Exit Sub
        End If

        Const cstPEN_SIZE As Single = 3.0

        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        intWIDTH = CInt(PCB_COMPOSITION.Width)
        intHEIGHT = CInt(PCB_COMPOSITION.Height)

        bmpCANVAS = New Bitmap(intWIDTH, intHEIGHT)
        grpDRAW = Graphics.FromImage(bmpCANVAS)

        ' penDRAW = New System.Drawing.Pen(System.Drawing.Color.Cyan, cstPEN_SIZE)
        penDRAW = New System.Drawing.Pen(System.Drawing.Color.FromArgb(64, System.Drawing.Color.Black), cstPEN_SIZE)

        Dim penFORE As System.Drawing.Pen
        penFORE = New System.Drawing.Pen(System.Drawing.Color.White, 1.0)

        grpDRAW.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Select Case enmPAT
            Case ENM_DIVISION_PATTERN.TWO_DIV
                Call SUB_DRAW_TWO_DIV(grpDRAW, penDRAW)
                Call SUB_DRAW_TWO_DIV(grpDRAW, penFORE)
            Case ENM_DIVISION_PATTERN.THREE_DIV
                Call SUB_DRAW_THREE_DIV(grpDRAW, penDRAW)
                Call SUB_DRAW_THREE_DIV(grpDRAW, penFORE)
            Case ENM_DIVISION_PATTERN.QUAD_DIV
                Call SUB_DRAW_QUAD_DIV(grpDRAW, penDRAW)
                Call SUB_DRAW_QUAD_DIV(grpDRAW, penFORE)
            Case ENM_DIVISION_PATTERN.THREE_DIV_PHI
                Call SUB_DRAW_THREE_DIV_PHI(grpDRAW, penDRAW)
                Call SUB_DRAW_THREE_DIV_PHI(grpDRAW, penFORE)
            Case ENM_DIVISION_PATTERN.RATE_16_TO_9
                Call SUB_DRAW_RATE_16_TO_9(grpDRAW, penDRAW)
                Call SUB_DRAW_RATE_16_TO_9(grpDRAW, penFORE)
            Case ENM_DIVISION_PATTERN.RATE_3_TO_2
                Call SUB_DRAW_RATE_3_TO_2(grpDRAW, penDRAW)
                Call SUB_DRAW_RATE_3_TO_2(grpDRAW, penFORE)
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HLL
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.HORIZONTAL_START_LOWER_LEFT, grpDRAW, penDRAW, PCB_COMPOSITION)
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.HORIZONTAL_START_LOWER_LEFT, grpDRAW, penFORE, PCB_COMPOSITION)
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HUR
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.HORIZONTAL_START_UPPER_RIGHT, grpDRAW, penDRAW, PCB_COMPOSITION)
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.HORIZONTAL_START_UPPER_RIGHT, grpDRAW, penFORE, PCB_COMPOSITION)
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HUL
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.HORIZONTAL_START_UPPER_LEFT, grpDRAW, penDRAW, PCB_COMPOSITION)
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.HORIZONTAL_START_UPPER_LEFT, grpDRAW, penFORE, PCB_COMPOSITION)
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HLR
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.HORIZONTAL_START_LOWER_RIGHT, grpDRAW, penDRAW, PCB_COMPOSITION)
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.HORIZONTAL_START_LOWER_RIGHT, grpDRAW, penFORE, PCB_COMPOSITION)
            Case Else

        End Select

        PCB_COMPOSITION.Source = FUNC_GET_IMAGESOURCE(bmpCANVAS)
        Call grpDRAW.Dispose()

        Me.DRAWED_COMPOSTION_TYPE = enmPAT
    End Sub

#Region "内部"

    Private Sub SUB_DRAW_TWO_DIV(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        Dim intHEIGT_2 As Integer
        Dim intWIDTH_2 As Integer

        intWIDTH = PCB_COMPOSITION.Width
        intHEIGHT = PCB_COMPOSITION.Height

        intHEIGT_2 = Math.Floor(intHEIGHT / 2)
        intWIDTH_2 = Math.Floor(intWIDTH / 2)

        Call grpDRAW.DrawLine(penDRAW, 0, intHEIGT_2, intWIDTH, intHEIGT_2)
        Call grpDRAW.DrawLine(penDRAW, intWIDTH_2, 0, intWIDTH_2, intHEIGHT)

    End Sub

    Private Sub SUB_DRAW_THREE_DIV(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        Dim intHEIGT_3 As Integer
        Dim intWIDTH_3 As Integer

        intWIDTH = PCB_COMPOSITION.Width
        intHEIGHT = PCB_COMPOSITION.Height

        intHEIGT_3 = Math.Floor(intHEIGHT / 3)
        intWIDTH_3 = Math.Floor(intWIDTH / 3)

        Call grpDRAW.DrawLine(penDRAW, 0, intHEIGT_3, intWIDTH, intHEIGT_3)
        Call grpDRAW.DrawLine(penDRAW, 0, intHEIGT_3 * 2, intWIDTH, intHEIGT_3 * 2)

        Call grpDRAW.DrawLine(penDRAW, intWIDTH_3, 0, intWIDTH_3, intHEIGHT)
        Call grpDRAW.DrawLine(penDRAW, intWIDTH_3 * 2, 0, intWIDTH_3 * 2, intHEIGHT)

    End Sub

    Private Sub SUB_DRAW_QUAD_DIV(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        Dim intHEIGT_4 As Integer
        Dim intWIDTH_4 As Integer

        intWIDTH = PCB_COMPOSITION.Width
        intHEIGHT = PCB_COMPOSITION.Height

        intHEIGT_4 = Math.Floor(intHEIGHT / 4)
        intWIDTH_4 = Math.Floor(intWIDTH / 4)

        Call grpDRAW.DrawLine(penDRAW, 0, intHEIGT_4, intWIDTH, intHEIGT_4)
        Call grpDRAW.DrawLine(penDRAW, 0, intHEIGT_4 * 2, intWIDTH, intHEIGT_4 * 2)
        Call grpDRAW.DrawLine(penDRAW, 0, intHEIGT_4 * 3, intWIDTH, intHEIGT_4 * 3)

        Call grpDRAW.DrawLine(penDRAW, intWIDTH_4, 0, intWIDTH_4, intHEIGHT)
        Call grpDRAW.DrawLine(penDRAW, intWIDTH_4 * 2, 0, intWIDTH_4 * 2, intHEIGHT)
        Call grpDRAW.DrawLine(penDRAW, intWIDTH_4 * 3, 0, intWIDTH_4 * 3, intHEIGHT)

    End Sub

    Private Sub SUB_DRAW_THREE_DIV_PHI(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer

        Dim decHEIGHT_ONE As Decimal
        Dim decWIDTH_ONE As Decimal

        Dim intHEIGT_1 As Integer
        Dim intWIDTH_1 As Integer

        Const cstGOLDEN_VALUE As Integer = 1618
        Dim intRATE_VALUE As Integer

        intRATE_VALUE = cstGOLDEN_VALUE + 1000 + cstGOLDEN_VALUE

        intWIDTH = PCB_COMPOSITION.Width
        intHEIGHT = PCB_COMPOSITION.Height

        decWIDTH_ONE = intWIDTH / intRATE_VALUE
        decHEIGHT_ONE = intHEIGHT / intRATE_VALUE

        intHEIGT_1 = Math.Floor(decHEIGHT_ONE * (cstGOLDEN_VALUE))
        Call grpDRAW.DrawLine(penDRAW, 0, intHEIGT_1, intWIDTH, intHEIGT_1)
        intHEIGT_1 = Math.Floor(decHEIGHT_ONE * (cstGOLDEN_VALUE + 1000))
        Call grpDRAW.DrawLine(penDRAW, 0, intHEIGT_1, intWIDTH, intHEIGT_1)

        intWIDTH_1 = Math.Floor(decWIDTH_ONE * (cstGOLDEN_VALUE))
        Call grpDRAW.DrawLine(penDRAW, intWIDTH_1, 0, intWIDTH_1, intHEIGHT)
        intWIDTH_1 = Math.Floor(decWIDTH_ONE * (cstGOLDEN_VALUE + 1000))
        Call grpDRAW.DrawLine(penDRAW, intWIDTH_1, 0, intWIDTH_1, intHEIGHT)

    End Sub

    Private Sub SUB_DRAW_RATE_16_TO_9(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim decONE_W As Decimal
        Dim decONE_H As Decimal
        Dim decONE As Decimal

        decONE_W = PCB_COMPOSITION.Width / 16
        decONE_H = PCB_COMPOSITION.Height / 9

        If decONE_W > decONE_H Then
            Dim intWIDTH As Integer
            Dim intLEFT_1 As Integer
            Dim intLEFT_2 As Integer

            decONE = decONE_H
            intWIDTH = CInt(decONE * 16)
            intLEFT_1 = (PCB_COMPOSITION.Width - intWIDTH) / 2
            intLEFT_2 = intLEFT_1 + intWIDTH

            Call grpDRAW.DrawLine(penDRAW, intLEFT_1, 0, intLEFT_1, CInt(PCB_COMPOSITION.Height))
            Call grpDRAW.DrawLine(penDRAW, intLEFT_2, 0, intLEFT_2, CInt(PCB_COMPOSITION.Height))
            Call grpDRAW.DrawLine(penDRAW, intLEFT_1, 1, intLEFT_2, 1)
            Call grpDRAW.DrawLine(penDRAW, intLEFT_1, CInt(PCB_COMPOSITION.Height) - 1, intLEFT_2, CInt(PCB_COMPOSITION.Height) - 1)
        Else
            Dim intHEIGHT As Integer
            Dim intTOP_1 As Integer
            Dim intTOP_2 As Integer

            decONE = decONE_W
            intHEIGHT = (decONE * 9)

            intTOP_1 = (PCB_COMPOSITION.Height - intHEIGHT) / 2
            intTOP_2 = intTOP_1 + intHEIGHT

            Call grpDRAW.DrawLine(penDRAW, 0, intTOP_1, CInt(PCB_COMPOSITION.Width), intTOP_1)
            Call grpDRAW.DrawLine(penDRAW, 0, intTOP_2, CInt(PCB_COMPOSITION.Width), intTOP_2)
            Call grpDRAW.DrawLine(penDRAW, 1, intTOP_1, 1, intTOP_2)
            Call grpDRAW.DrawLine(penDRAW, CInt(PCB_COMPOSITION.Width) - 1, intTOP_1, CInt(PCB_COMPOSITION.Width) - 1, intTOP_2)
        End If

    End Sub

    Private Sub SUB_DRAW_RATE_3_TO_2(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim decONE_W As Decimal
        Dim decONE_H As Decimal
        Dim decONE As Decimal

        decONE_W = PCB_COMPOSITION.Width / 3
        decONE_H = PCB_COMPOSITION.Height / 2

        If decONE_W > decONE_H Then
            Dim intWIDTH As Integer
            Dim intLEFT_1 As Integer
            Dim intLEFT_2 As Integer

            decONE = decONE_H

            intWIDTH = CInt(decONE * 3)

            intLEFT_1 = (PCB_COMPOSITION.Width - intWIDTH) / 2
            intLEFT_2 = intLEFT_1 + intWIDTH

            Call grpDRAW.DrawLine(penDRAW, intLEFT_1, 0, intLEFT_1, CInt(PCB_COMPOSITION.Height))
            Call grpDRAW.DrawLine(penDRAW, intLEFT_2, 0, intLEFT_2, CInt(PCB_COMPOSITION.Height))
            Call grpDRAW.DrawLine(penDRAW, intLEFT_1, 0, intLEFT_2, 0)
            Call grpDRAW.DrawLine(penDRAW, intLEFT_1, CInt(PCB_COMPOSITION.Height), intLEFT_2, CInt(PCB_COMPOSITION.Height))
        Else
            Dim intHEIGHT As Integer
            Dim intTOP_1 As Integer
            Dim intTOP_2 As Integer

            decONE = decONE_W

            intHEIGHT = (decONE * 2)

            intTOP_1 = (PCB_COMPOSITION.Height - intHEIGHT) / 2
            intTOP_2 = intTOP_1 + intHEIGHT

            Call grpDRAW.DrawLine(penDRAW, 0, intTOP_1, CInt(PCB_COMPOSITION.Width), intTOP_1)
            Call grpDRAW.DrawLine(penDRAW, 0, intTOP_2, CInt(PCB_COMPOSITION.Width), intTOP_2)
            Call grpDRAW.DrawLine(penDRAW, 1, intTOP_1, 1, intTOP_2)
            Call grpDRAW.DrawLine(penDRAW, CInt(PCB_COMPOSITION.Width) - 1, intTOP_1, CInt(PCB_COMPOSITION.Width) - 1, intTOP_2)
        End If

    End Sub
#End Region

#End Region

#Region "サムネイル"

#Region "変数"
    Private bmpSET_THUMBNAIL_IMAGE As Bitmap
    Private strSET_THUMBNAIL_FILE_PATH As String
#End Region

    Public Sub SUB_SET_THUMBNAIL(ByRef bmpIMAGE As Bitmap, ByVal strFILE_PATH As String)
        bmpSET_THUMBNAIL_IMAGE = bmpIMAGE
        strSET_THUMBNAIL_FILE_PATH = strFILE_PATH
    End Sub

    Public Sub SUB_REFRESH_THUMBNAIL()
        Call SUB_ADD_THUMBNAIL(bmpSET_THUMBNAIL_IMAGE, strSET_THUMBNAIL_FILE_PATH)
    End Sub

    Public Sub SUB_CLEAR_THUMBNAIL()
        PCB_THUMBNAIL_01.Source = Nothing
        PCB_THUMBNAIL_02.Source = Nothing
        PCB_THUMBNAIL_03.Source = Nothing
    End Sub

    Public Sub SUB_ADD_THUMBNAIL(ByRef bmpIMAGE As Bitmap, ByVal strFILE_PATH As String)

        If Not PCB_THUMBNAIL_01.Visibility = Visibility.Visible Then
            Exit Sub
        End If

        If PCB_THUMBNAIL_01.Source Is Nothing Then
            Call SUB_RESIZE_PCB(PCB_THUMBNAIL_01, bmpIMAGE)
            Call SUB_SET_IMAGE(PCB_THUMBNAIL_01, bmpIMAGE.Clone)
            PCB_THUMBNAIL_01.Tag = strFILE_PATH
            Exit Sub
        End If

        If PCB_THUMBNAIL_02.Source Is Nothing Then
            Call SUB_RESIZE_PCB(PCB_THUMBNAIL_02, bmpIMAGE)
            Call SUB_SET_IMAGE(PCB_THUMBNAIL_02, bmpIMAGE.Clone)
            PCB_THUMBNAIL_02.Tag = strFILE_PATH
            Exit Sub
        End If

        If PCB_THUMBNAIL_03.Source Is Nothing Then
            Call SUB_RESIZE_PCB(PCB_THUMBNAIL_03, bmpIMAGE)
            Call SUB_SET_IMAGE(PCB_THUMBNAIL_03, bmpIMAGE.Clone)
            PCB_THUMBNAIL_03.Tag = strFILE_PATH
            Exit Sub
        End If

        Call SUB_RESIZE_PCB_SOURCE(PCB_THUMBNAIL_01, PCB_THUMBNAIL_02.Source)
        PCB_THUMBNAIL_01.Source = Nothing
        Call SUB_SET_IMAGE_SOURCE(PCB_THUMBNAIL_01, PCB_THUMBNAIL_02.Source.Clone)
        PCB_THUMBNAIL_01.Tag = PCB_THUMBNAIL_02.Tag

        Call SUB_RESIZE_PCB_SOURCE(PCB_THUMBNAIL_02, PCB_THUMBNAIL_03.Source)
        PCB_THUMBNAIL_02.Source = Nothing
        Call SUB_SET_IMAGE_SOURCE(PCB_THUMBNAIL_02, PCB_THUMBNAIL_03.Source.Clone)
        PCB_THUMBNAIL_02.Tag = PCB_THUMBNAIL_03.Tag

        Call SUB_RESIZE_PCB(PCB_THUMBNAIL_03, bmpIMAGE)
        PCB_THUMBNAIL_03.Source = Nothing
        Call SUB_SET_IMAGE(PCB_THUMBNAIL_03, bmpIMAGE.Clone)
        PCB_THUMBNAIL_03.Tag = strFILE_PATH

    End Sub

    Private Sub SUB_RESIZE_PCB(ByRef pcbMAIN As Controls.Image, ByRef bmpIMAGE As Bitmap)
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer
        Dim decRATE As Decimal
        Const cstWIDTH_MAX As Integer = 160
        Const cstHEIGHT_MAX As Integer = 90

        pcbMAIN.Width = cstWIDTH_MAX
        pcbMAIN.Height = cstHEIGHT_MAX

        decRATE = bmpIMAGE.Height / pcbMAIN.Height
        intWIDTH = bmpIMAGE.Width / decRATE

        If intWIDTH <= pcbMAIN.Width Then
            pcbMAIN.Width = intWIDTH
            Exit Sub
        End If

        decRATE = bmpIMAGE.Width / pcbMAIN.Width
        intHEIGHT = bmpIMAGE.Height / decRATE
        pcbMAIN.Height = intHEIGHT
    End Sub

    Private Sub SUB_RESIZE_PCB_SOURCE(ByRef pcbMAIN As Controls.Image, ByRef bmpIMAGE As System.Windows.Media.ImageSource)
        Dim intWIDTH As Integer
        Dim intHEIGHT As Integer
        Dim decRATE As Decimal
        Const cstWIDTH_MAX As Integer = 160
        Const cstHEIGHT_MAX As Integer = 90

        pcbMAIN.Width = cstWIDTH_MAX
        pcbMAIN.Height = cstHEIGHT_MAX

        decRATE = bmpIMAGE.Height / pcbMAIN.Height
        intWIDTH = bmpIMAGE.Width / decRATE

        If intWIDTH <= pcbMAIN.Width Then
            pcbMAIN.Width = intWIDTH
            Exit Sub
        End If

        decRATE = bmpIMAGE.Width / pcbMAIN.Width
        intHEIGHT = bmpIMAGE.Height / decRATE
        pcbMAIN.Height = intHEIGHT
    End Sub

    Private Sub SUB_SET_IMAGE(ByRef pcbMAIN As Controls.Image, ByRef bmpIMAGE As System.Drawing.Image)
        pcbMAIN.Source = FUNC_GET_IMAGESOURCE(bmpIMAGE)
    End Sub

    Private Sub SUB_SET_IMAGE_SOURCE(ByRef pcbMAIN As Controls.Image, ByRef bmpIMAGE As System.Windows.Media.ImageSource)
        pcbMAIN.Source = bmpIMAGE
    End Sub

#End Region

#Region "実行処理群"

    Private Sub SUB_DRAW_STRING(ByRef grpDRAW As Graphics, ByVal strVALUE As String, ByVal intSIZE As Integer, ByVal intX As Integer, ByVal intY As Integer)
        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        Dim ff As New System.Drawing.FontFamily("Lucida Console")
        'Dim ff As New FontFamily(Me.FontFamily.Source)

        Call gp.AddString(strVALUE, ff, 0, intSIZE, New System.Drawing.Point(intX, intY), StringFormat.GenericDefault)
        Call grpDRAW.FillPath(System.Drawing.Brushes.White, gp)
        'Call grpDRAW.DrawPath(Pens.Cyan, gp) '文字列の縁を描画する

    End Sub

    Private Function FUNC_GET_NEXT_COMP(ByVal intVALUE As Integer) As Integer
        Dim intRET As Integer
        Const cstVALUE_MIN As Integer = 0
        Const cstVALUE_MAX As Integer = 9

        If intVALUE = cstVALUE_MAX Then
            intRET = cstVALUE_MIN
        Else
            intRET = intVALUE + 1
        End If

        Return intRET
    End Function

    Private Sub SUB_IMAGE_VIEW(ByVal intNUMBER As Integer)
        Dim strFILE_PATH As String

        Select Case intNUMBER
            Case 1
                strFILE_PATH = PCB_THUMBNAIL_01.Tag
            Case 2
                strFILE_PATH = PCB_THUMBNAIL_02.Tag
            Case 3
                strFILE_PATH = PCB_THUMBNAIL_03.Tag
            Case Else
                strFILE_PATH = ""
        End Select

        If strFILE_PATH = "" Then
            Exit Sub
        End If

        If Not FUNC_FILE_CHECK(strFILE_PATH) Then
            Exit Sub
        End If

        Call System.Diagnostics.Process.Start(strFILE_PATH)

    End Sub

#End Region

#Region "イベント-クリック"

    Private Sub PCB_BUTTON_CLOSE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_CLOSE.Click
        MOD_OVERLAY.STATE_SHOW = False
        Call Me.Close()
    End Sub

    Private Sub PCB_BUTTON_COMPOSITION_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_COMPOSITION.Click
        srtCAPT_SETTINGS.OVERLAY_COMPOSITION = Not srtCAPT_SETTINGS.OVERLAY_COMPOSITION
        Call SUB_VISIBLE_OVERLAY_WPF_COMPOSITION()
        Call SUB_REFRESH_OVERLAY_WPF()
    End Sub

    Private Sub PCB_BUTTON_CHANGE_COMPOSITION_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_CHANGE_COMPOSITION.Click
        srtCAPT_SETTINGS.OVERLAY_COMPOSITION_TYPE = FUNC_GET_NEXT_COMP(srtCAPT_SETTINGS.OVERLAY_COMPOSITION_TYPE)
        Call SUB_REFRESH_OVERLAY_WPF()
    End Sub

    Private Sub PCB_BUTTON_ROTATE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_ROTATE.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.VIEW_ROTATE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_BUTTON_SETTING_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_SETTING.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.VIEW_SETTING
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_BUTTON_UI_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_UI.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_SCL_LK
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_BUTTON_EXPLORER_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_EXPLORER.Click
        Dim strDIR As String

        strDIR = srtCAPT_SETTINGS.PATH_SAVE

        If Not FUNC_DIR_CHECK(strDIR) Then
            Exit Sub
        End If

        If Not FUNC_CALL_EXE_FILE_SHELL(strDIR, "", False) Then
            Exit Sub
        End If
    End Sub

    Private Sub PCB_BUTTON_APPEND_IMAGE_LOAD_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_APPEND_IMAGE_LOAD.Click
        Dim ofdDIALOG As OpenFileDialog
        Dim rstDIALOG As DialogResult
        Dim strFILE_PATH As String

        ofdDIALOG = New OpenFileDialog()

        ofdDIALOG.Title = "画像を開く"
        ofdDIALOG.Filter = "画像ファイル|*.bmp;*.png;*.tif;*.jpg"
        ofdDIALOG.Multiselect = False
        ofdDIALOG.InitialDirectory = srtCAPT_SETTINGS.PATH_SAVE

        rstDIALOG = ofdDIALOG.ShowDialog()

        If rstDIALOG = Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        strFILE_PATH = ofdDIALOG.FileName

        Dim bmpAPPEND As Bitmap
        bmpAPPEND = System.Drawing.Image.FromFile(strFILE_PATH)

        PCB_APPEND.Source = FUNC_GET_IMAGESOURCE(bmpAPPEND)
        PCB_APPEND.Visibility = Visibility.Visible
        Call SUB_FOREGROUND_WINDOW(prcTARGET)
    End Sub

    Private Sub PCB_BUTTON_APPEND_IMAGE_CHANGE_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_APPEND_IMAGE_CHANGE.Click
        If PCB_APPEND.Source Is Nothing Then
            Exit Sub
        End If

        If PCB_APPEND.Visibility = Visibility.Visible Then
            PCB_APPEND.Visibility = Visibility.Hidden
        Else
            PCB_APPEND.Visibility = Visibility.Visible
        End If
        Call SUB_FOREGROUND_WINDOW(prcTARGET)
    End Sub

    Private Sub PCB_BUTTON_SHUTTER_CONTINUOUS_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_SHUTTER_CONTINUOUS.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_CON
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_BUTTON_LIGHT_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_LIGHT.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.SEND_KEYS_LIGHT
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_BUTTON_TRIM_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_TRIM.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.VIEW_TRIM
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_BUTTON_LOGO_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_LOGO.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.VIEW_LOGO
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_BUTTON_THUMNAIL_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_THUMNAIL.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.VIEW_THUMBNAIL
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)

    End Sub

    Private Sub PCB_BUTTON_AEB_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_AEB.Click
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_AEB
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub
#End Region

#Region "イベント-マウス左アップ"
    Private Sub PCB_THUMBNAIL_01_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PCB_THUMBNAIL_01.MouseLeftButtonUp
        Call SUB_IMAGE_VIEW(1)
    End Sub

    Private Sub PCB_THUMBNAIL_02_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PCB_THUMBNAIL_02.MouseLeftButtonUp
        Call SUB_IMAGE_VIEW(2)
    End Sub

    Private Sub PCB_THUMBNAIL_03_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PCB_THUMBNAIL_03.MouseLeftButtonUp
        Call SUB_IMAGE_VIEW(3)
    End Sub

    Private Sub PCB_SHUTTER_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PCB_SHUTTER.MouseLeftButtonUp
        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_ONE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

    Private Sub PCB_SHUTTER_JPEG_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PCB_SHUTTER_JPEG.MouseLeftButtonUp

        MOD_OVERLAY.FRM_PARENT.FORCE_JPEG = True

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_ONE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_OVERLAY.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_OVERLAY.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_OVERLAY.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

#End Region

#Region "イベント-タイマー"
    Private Sub dispatcherTimer_Tick(sender As Object, e As EventArgs)
        Call Me.SUB_RE_PRINT_WINDOW_COLOR_INFO()
        Call Me.SUB_DRAW_COLOR_INFO()
    End Sub

    Private Sub SUB_TIMER(sender As Object, e As System.Timers.ElapsedEventArgs)

    End Sub

    Private Sub SUB_START_TIMER()
        TIM_PRIVATE_TIMER = New System.Timers.Timer
        TIM_PRIVATE_TIMER.Interval = 1000
        TIM_PRIVATE_TIMER.AutoReset = True

        AddHandler TIM_PRIVATE_TIMER.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf SUB_TIMER)
        Call TIM_PRIVATE_TIMER.Start()
    End Sub

    Private Sub SUB_STOP_TIMER()
        Call TIM_PRIVATE_TIMER.Stop()
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

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        dispatcherTimer = New DispatcherTimer(DispatcherPriority.Normal)

        Call SUB_INIT_BUTTONS()
    End Sub

    Private Sub WPF_OVERLAY_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000)
        AddHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
        Call dispatcherTimer.Start()

        Me.DRAWED_COMPOSTION_TYPE = -1
        Me.SLI_APPEND_IMAGE_OPACITY.Value = CInt((PCB_APPEND.Opacity) * SLI_APPEND_IMAGE_OPACITY.Maximum)

        IMG_PRIVATE_COLOR_INFO = FUNC_GET_CLIENT_DEFAULT_IMAGE()
        GRP_PRIVATE_COLOR_INFO = System.Drawing.Graphics.FromImage(IMG_PRIVATE_COLOR_INFO)
    End Sub

    Private Sub WPF_OVERLAY_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not (dispatcherTimer Is Nothing) Then
            Call dispatcherTimer.Stop()
            dispatcherTimer.IsEnabled = False
            RemoveHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
            dispatcherTimer = Nothing
        End If
    End Sub

    Private Sub WPF_OVERLAY_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

End Class
