Imports System.ComponentModel

Public Class WPF_TRIM

#Region "画面用列挙定数"
    Friend Enum ENM_WINDOW_RATE
        RATE_FREE = 0
        RATE_1_1
        RATE_2_3
        RATE_3_2
        RATE_3_4
        RATE_4_3
        RATE_5_7
        RATE_7_5
        RATE_5_8
        RATE_8_5
        RATE_5_12
        RATE_12_5
        RATE_9_16
        RATE_16_9
    End Enum
#End Region

#Region "画面用変数"
    Friend SIZ_WINDOW As RECT_WH
#End Region

#Region "プロパティ用変数"
    Private blnPROPETY_CHECK_CLOSED As Boolean = False
    Private enmPROPERTY_COMPOSTION_TYPE As ENM_DIVISION_PATTERN
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

    Public Property DRAWED_COMPOSTION_TYPE As ENM_DIVISION_PATTERN
        Get
            Return enmPROPERTY_COMPOSTION_TYPE
        End Get
        Set(ByVal value As ENM_DIVISION_PATTERN)
            enmPROPERTY_COMPOSTION_TYPE = value
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
    End Sub
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_INIT_BUTTONS()
        Dim STR_EXE As String
        STR_EXE = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim STR_DIR As String
        STR_DIR = FUNC_PATH_TO_DIR_PATH(STR_EXE)
        Call SUB_INIT_CHANGE_IMAGE(STR_DIR & "\RES\IMG\TRIM")
        'Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_CLOSE, "CLOSE.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_SHUTTER, "SHUTTER_C_W.png")
        Call SUB_CHANGE_IMAGE_WPF_BUTTON(PCB_BUTTON_SHUTTER_JPEG, "SHUTTER_C_G.png")
    End Sub
#End Region

#Region "構図補助"
    Friend Sub SUB_CHANGE_DRAW_COMPOTION(ByVal ENM_PAT As ENM_DIVISION_PATTERN)

        If Me.DRAWED_COMPOSTION_TYPE = ENM_PAT Then
            Exit Sub
        End If

        Call SUB_COMP_ALL_UNCHECKED()

        Select Case ENM_PAT
            Case ENM_DIVISION_PATTERN.TWO_DIV
                MNI_COMP_2DIV.IsChecked = True
            Case ENM_DIVISION_PATTERN.THREE_DIV
                MNI_COMP_3DIV.IsChecked = True
            Case ENM_DIVISION_PATTERN.QUAD_DIV
                MNI_COMP_4DIV.IsChecked = True
            Case ENM_DIVISION_PATTERN.THREE_DIV_PHI
                MNI_COMP_3DIV_PHI.IsChecked = True
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HLL
                MNI_COMP_GOLDEN_RECTANGLE_HLL.IsChecked = True
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HUR
                MNI_COMP_GOLDEN_RECTANGLE_HUR.IsChecked = True
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HUL
                MNI_COMP_GOLDEN_RECTANGLE_HUL.IsChecked = True
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HLR
                MNI_COMP_GOLDEN_RECTANGLE_HLR.IsChecked = True
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VLL
                MNI_COMP_GOLDEN_RECTANGLE_VLL.IsChecked = True
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VUR
                MNI_COMP_GOLDEN_RECTANGLE_VUR.IsChecked = True
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VUL
                MNI_COMP_GOLDEN_RECTANGLE_VUL.IsChecked = True
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VLR
                MNI_COMP_GOLDEN_RECTANGLE_VLR.IsChecked = True
            Case Else
                MNI_COMP_NONE.IsChecked = True
        End Select

        Call SUB_DRAW_COMPOSTION(ENM_PAT)

        Me.DRAWED_COMPOSTION_TYPE = ENM_PAT
    End Sub

    Private Sub SUB_DRAW_COMPOSTION(ByVal enmPAT As ENM_DIVISION_PATTERN)
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

        grpDRAW.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Call SUB_DRAW_OUTLINE(grpDRAW, penDRAW)
        Call SUB_DRAW_OUTLINE(grpDRAW, penFORE)

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

            Case ENM_DIVISION_PATTERN.RATE_3_TO_2

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
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VLL
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.VERTICAL_START_LOWER_LEFT, grpDRAW, penDRAW, PCB_COMPOSITION)
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.VERTICAL_START_LOWER_LEFT, grpDRAW, penFORE, PCB_COMPOSITION)
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VUR
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.VERTICAL_START_UPPER_RIGHT, grpDRAW, penDRAW, PCB_COMPOSITION)
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.VERTICAL_START_UPPER_RIGHT, grpDRAW, penFORE, PCB_COMPOSITION)
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VUL
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.VERTICAL_START_UPPER_LEFT, grpDRAW, penDRAW, PCB_COMPOSITION)
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.VERTICAL_START_UPPER_LEFT, grpDRAW, penFORE, PCB_COMPOSITION)
            Case ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VLR
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.VERTICAL_START_LOWER_RIGHT, grpDRAW, penDRAW, PCB_COMPOSITION)
                Call SUB_DRAW_GOLDEN_RECTANGLE(ENM_GOLDEN_RATE_TYPE.VERTICAL_START_LOWER_RIGHT, grpDRAW, penFORE, PCB_COMPOSITION)
            Case Else

        End Select

        PCB_COMPOSITION.Source = FUNC_GET_IMAGESOURCE(bmpCANVAS)
        Call grpDRAW.Dispose()

    End Sub

#Region "内部"

    Private Sub SUB_DRAW_OUTLINE(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim rct As System.Drawing.Rectangle

        rct = New System.Drawing.Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Call grpDRAW.DrawRectangle(penDRAW, rct)
    End Sub

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

    Private Sub SUB_DRAW_GOLDEN_RECTANGLE_L(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim decONE_W As Decimal
        Dim decONE_H As Decimal

        decONE_W = PCB_COMPOSITION.Width / 1618
        decONE_H = PCB_COMPOSITION.Height / 1000

        Dim intDRAW_X As Integer
        Dim intDRAW_Y As Integer
        Dim intDRAW_W As Integer
        Dim intDRAW_H As Integer

        intDRAW_X = 0
        intDRAW_Y = 0
        intDRAW_W = 0
        intDRAW_H = 0

        If decONE_W > decONE_H Then
            Dim intWIDTH As Integer
            Dim intLEFT_1 As Integer
            Dim intLEFT_2 As Integer
            Dim decONE As Decimal

            decONE = decONE_H

            intWIDTH = CInt(decONE * 1618)

            intLEFT_1 = (PCB_COMPOSITION.Width - intWIDTH) / 2
            intLEFT_2 = intLEFT_1 + intWIDTH

            intDRAW_X = intLEFT_1
            intDRAW_Y = 0
            intDRAW_W = intLEFT_2 - intLEFT_1
            intDRAW_H = CInt(PCB_COMPOSITION.Height)
        Else
            Dim intHEIGHT As Integer
            Dim intTOP_1 As Integer
            Dim intTOP_2 As Integer
            Dim decONE As Decimal

            decONE = decONE_W
            intHEIGHT = (decONE * 1000)

            intTOP_1 = (PCB_COMPOSITION.Height - intHEIGHT) / 2
            intTOP_2 = intTOP_1 + intHEIGHT

            intDRAW_X = 0
            intDRAW_Y = intTOP_1
            intDRAW_W = CInt(PCB_COMPOSITION.Width)
            intDRAW_H = intTOP_2 - intTOP_1
        End If

        Call grpDRAW.DrawRectangle(penDRAW, intDRAW_X, intDRAW_Y, intDRAW_W, intDRAW_H)

        Dim intPOINT_WH As Integer
        Dim intNEXT_X As Integer
        Dim intNEXT_Y As Integer

        intNEXT_X = intDRAW_X
        intNEXT_Y = intDRAW_Y + intDRAW_H
        intPOINT_WH = intDRAW_W
        For intLOOP_INDEX = 1 To 16
            Dim intMOD As Integer
            Dim intPOINT_X As Integer
            Dim intPOINT_Y As Integer
            Dim intPOINT_W As Integer
            Dim intPOINT_H As Integer
            Dim intSTART_ANGLE As Integer
            Dim intSWEEP_ANGLE As Integer
            Dim intPOINT_ARC_X As Integer
            Dim intPOINT_ARC_Y As Integer

            intPOINT_WH = FUNC_GET_LENGTH_LONG(intPOINT_WH)

            If intPOINT_WH <= 10 Then
                Exit For
            End If

            intPOINT_X = intNEXT_X
            intPOINT_Y = intNEXT_Y

            intMOD = intLOOP_INDEX Mod 4

            Select Case intMOD
                Case 1
                    intPOINT_W = intPOINT_WH
                    intPOINT_H = -intPOINT_WH
                    intSTART_ANGLE = 180
                    intSWEEP_ANGLE = 90
                    intPOINT_ARC_X = intPOINT_X
                    intPOINT_ARC_Y = intPOINT_Y - intPOINT_WH
                Case 2
                    intPOINT_W = intPOINT_WH
                    intPOINT_H = intPOINT_WH
                    intSTART_ANGLE = 270
                    intSWEEP_ANGLE = 90
                    intPOINT_ARC_X = intPOINT_X - intPOINT_WH
                    intPOINT_ARC_Y = intPOINT_Y
                Case 3
                    intPOINT_W = -intPOINT_WH
                    intPOINT_H = intPOINT_WH
                    intSTART_ANGLE = 0
                    intSWEEP_ANGLE = 90
                    intPOINT_ARC_X = intPOINT_X - intPOINT_WH - intPOINT_WH
                    intPOINT_ARC_Y = intPOINT_Y - intPOINT_WH
                Case 0
                    intPOINT_W = -intPOINT_WH
                    intPOINT_H = -intPOINT_WH
                    intSTART_ANGLE = 90
                    intSWEEP_ANGLE = 90
                    intPOINT_ARC_X = intPOINT_X - intPOINT_WH
                    intPOINT_ARC_Y = intPOINT_Y - intPOINT_WH - intPOINT_WH
            End Select

            Call SUB_DRAW_RECTANGLE(grpDRAW, penDRAW, intPOINT_X, intPOINT_Y, intPOINT_W, intPOINT_H)

            Call grpDRAW.DrawArc(penDRAW, intPOINT_ARC_X, intPOINT_ARC_Y, intPOINT_WH * 2, intPOINT_WH * 2, intSTART_ANGLE, intSWEEP_ANGLE)

            intNEXT_X = intPOINT_X + intPOINT_W
            intNEXT_Y = intPOINT_Y + intPOINT_H
        Next

    End Sub

    Private Sub SUB_DRAW_GOLDEN_RECTANGLE_R(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen)
        Dim decONE_W As Decimal
        Dim decONE_H As Decimal

        decONE_W = PCB_COMPOSITION.Width / 1618
        decONE_H = PCB_COMPOSITION.Height / 1000

        Dim intDRAW_X As Integer
        Dim intDRAW_Y As Integer
        Dim intDRAW_W As Integer
        Dim intDRAW_H As Integer

        intDRAW_X = 0
        intDRAW_Y = 0
        intDRAW_W = 0
        intDRAW_H = 0

        If decONE_W > decONE_H Then
            Dim intWIDTH As Integer
            Dim intLEFT_1 As Integer
            Dim intLEFT_2 As Integer
            Dim decONE As Decimal

            decONE = decONE_H

            intWIDTH = CInt(decONE * 1618)

            intLEFT_1 = (PCB_COMPOSITION.Width - intWIDTH) / 2
            intLEFT_2 = intLEFT_1 + intWIDTH

            intDRAW_X = intLEFT_1
            intDRAW_Y = 0
            intDRAW_W = intLEFT_2 - intLEFT_1
            intDRAW_H = CInt(PCB_COMPOSITION.Height)
        Else
            Dim intHEIGHT As Integer
            Dim intTOP_1 As Integer
            Dim intTOP_2 As Integer
            Dim decONE As Decimal

            decONE = decONE_W
            intHEIGHT = (decONE * 1000)

            intTOP_1 = (PCB_COMPOSITION.Height - intHEIGHT) / 2
            intTOP_2 = intTOP_1 + intHEIGHT

            intDRAW_X = 0
            intDRAW_Y = intTOP_1
            intDRAW_W = CInt(PCB_COMPOSITION.Width)
            intDRAW_H = intTOP_2 - intTOP_1
        End If

        Call grpDRAW.DrawRectangle(penDRAW, intDRAW_X, intDRAW_Y, intDRAW_W, intDRAW_H)

        Dim intPOINT_WH As Integer
        Dim intNEXT_X As Integer
        Dim intNEXT_Y As Integer

        intNEXT_X = intDRAW_X + intDRAW_W
        intNEXT_Y = intDRAW_Y
        intPOINT_WH = intDRAW_W
        For intLOOP_INDEX = 1 To 16
            Dim intMOD As Integer
            Dim intPOINT_X As Integer
            Dim intPOINT_Y As Integer
            Dim intPOINT_W As Integer
            Dim intPOINT_H As Integer
            Dim intSTART_ANGLE As Integer
            Dim intSWEEP_ANGLE As Integer
            Dim intPOINT_ARC_X As Integer
            Dim intPOINT_ARC_Y As Integer

            intPOINT_WH = FUNC_GET_LENGTH_LONG(intPOINT_WH)

            If intPOINT_WH <= 10 Then
                Exit For
            End If

            intPOINT_X = intNEXT_X
            intPOINT_Y = intNEXT_Y

            intMOD = intLOOP_INDEX Mod 4

            Select Case intMOD
                Case 1
                    intPOINT_W = -intPOINT_WH
                    intPOINT_H = intPOINT_WH
                    intSTART_ANGLE = 0
                    intSWEEP_ANGLE = 90
                    intPOINT_ARC_X = intPOINT_X - intPOINT_WH - intPOINT_WH
                    intPOINT_ARC_Y = intPOINT_Y - intPOINT_WH
                Case 2
                    intPOINT_W = -intPOINT_WH
                    intPOINT_H = -intPOINT_WH
                    intSTART_ANGLE = 90
                    intSWEEP_ANGLE = 90
                    intPOINT_ARC_X = intPOINT_X - intPOINT_WH
                    intPOINT_ARC_Y = intPOINT_Y - intPOINT_WH - intPOINT_WH
                Case 3
                    intPOINT_W = intPOINT_WH
                    intPOINT_H = -intPOINT_WH
                    intSTART_ANGLE = 180
                    intSWEEP_ANGLE = 90
                    intPOINT_ARC_X = intPOINT_X
                    intPOINT_ARC_Y = intPOINT_Y - intPOINT_WH
                Case 0
                    intPOINT_W = intPOINT_WH
                    intPOINT_H = intPOINT_WH
                    intSTART_ANGLE = 270
                    intSWEEP_ANGLE = 90
                    intPOINT_ARC_X = intPOINT_X - intPOINT_WH
                    intPOINT_ARC_Y = intPOINT_Y
            End Select

            Call SUB_DRAW_RECTANGLE(grpDRAW, penDRAW, intPOINT_X, intPOINT_Y, intPOINT_W, intPOINT_H)

            Call grpDRAW.DrawArc(penDRAW, intPOINT_ARC_X, intPOINT_ARC_Y, intPOINT_WH * 2, intPOINT_WH * 2, intSTART_ANGLE, intSWEEP_ANGLE)

            intNEXT_X = intPOINT_X + intPOINT_W
            intNEXT_Y = intPOINT_Y + intPOINT_H
        Next

    End Sub

    Private Sub SUB_DRAW_RECTANGLE(ByRef grpDRAW As Graphics, ByRef penDRAW As System.Drawing.Pen, ByVal intX As Integer, ByVal intY As Integer, ByVal intW As Integer, ByVal intH As Integer)
        Dim intX_SET As Integer
        Dim intY_SET As Integer
        Dim intW_SET As Integer
        Dim intH_SET As Integer

        If intW < 0 Then
            intX_SET = intX + intW
            intW_SET = -1 * intW
        Else
            intX_SET = intX
            intW_SET = intW
        End If

        If intH < 0 Then
            intY_SET = intY + intH
            intH_SET = -1 * intH
        Else
            intY_SET = intY
            intH_SET = intH
        End If

        Call grpDRAW.DrawRectangle(penDRAW, intX_SET, intY_SET, intW_SET, intH_SET)

    End Sub

    Private Function FUNC_GET_LENGTH_SHORT(ByVal intLENGTH As Integer) As Integer
        Dim decONE As Decimal
        Dim decRET As Decimal
        Dim intRET As Integer

        decONE = (intLENGTH / 1618)

        decRET = decONE * 618

        intRET = CInt(decRET)
        Return intRET
    End Function

    Private Function FUNC_GET_LENGTH_LONG(ByVal intLENGTH As Integer) As Integer
        Dim decONE As Decimal
        Dim decRET As Decimal
        Dim intRET As Integer

        decONE = (intLENGTH / 1618)

        decRET = decONE * 1000

        intRET = CInt(decRET)
        Return intRET
    End Function
#End Region

#End Region

#Region "イベント-クリック"

    Private Sub PCB_BUTTON_SHUTTER_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_SHUTTER.Click
        Call SUB_CALL_CAPT_ONE_NORMAL()
    End Sub

    Private Sub PCB_BUTTON_SHUTTER_JPEG_Click(sender As Object, e As RoutedEventArgs) Handles PCB_BUTTON_SHUTTER_JPEG.Click
        Call SUB_CALL_CAPT_ONE_SNS()
    End Sub

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
            COL_SET = Windows.Media.Color.FromArgb(16, 0, 0, 255)
        End If

        Me.Background = New SolidColorBrush(COL_SET)
    End Sub
#End Region

#Region "イベント-コンテキストメニュークリック"
    Private Sub MNI_CAPT_Click(sender As Object, e As RoutedEventArgs) Handles MNI_CAPT.Click

        Call SUB_CALL_CAPT_ONE_NORMAL()
    End Sub

    Private Sub MNI_CAPT_SNS_Click(sender As Object, e As RoutedEventArgs) Handles MNI_CAPT_SNS.Click
        Call SUB_CALL_CAPT_ONE_SNS()
    End Sub

    Private Sub MNI_CLOSE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_CLOSE.Click
        Call Me.Close()
    End Sub

    Private Sub MNI_RATE_FREE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_FREE.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_FREE)
    End Sub

    Private Sub MNI_RATE_1_1_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_1_1.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_1_1)
    End Sub

    Private Sub MNI_RATE_2_3_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_2_3.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_2_3)
    End Sub

    Private Sub MNI_RATE_3_2_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_3_2.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_3_2)
    End Sub

    Private Sub MNI_RATE_3_4_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_3_4.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_3_4)
    End Sub

    Private Sub MNI_RATE_4_3_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_4_3.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_4_3)
    End Sub

    Private Sub MNI_RATE_5_7_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_5_7.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_5_7)
    End Sub

    Private Sub MNI_RATE_7_5_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_7_5.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_7_5)
    End Sub

    Private Sub MNI_RATE_5_8_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_5_8.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_5_8)
    End Sub

    Private Sub MNI_RATE_8_5_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_8_5.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_8_5)
    End Sub

    Private Sub MNI_RATE_5_12_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_5_12.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_5_12)
    End Sub

    Private Sub MNI_RATE_12_5_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_12_5.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_12_5)
    End Sub

    Private Sub MNI_RATE_9_16_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_9_16.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_9_16)
    End Sub

    Private Sub MNI_RATE_16_9_Click(sender As Object, e As RoutedEventArgs) Handles MNI_RATE_16_9.Click
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_16_9)
    End Sub

    Private Sub SUB_RATE_ALL_UNCHECKED()
        MNI_RATE_FREE.IsChecked = False
        MNI_RATE_1_1.IsChecked = False
        MNI_RATE_2_3.IsChecked = False
        MNI_RATE_3_2.IsChecked = False
        MNI_RATE_3_4.IsChecked = False
        MNI_RATE_4_3.IsChecked = False
        MNI_RATE_5_7.IsChecked = False
        MNI_RATE_7_5.IsChecked = False
        MNI_RATE_5_8.IsChecked = False
        MNI_RATE_8_5.IsChecked = False
        MNI_RATE_5_12.IsChecked = False
        MNI_RATE_12_5.IsChecked = False
        MNI_RATE_9_16.IsChecked = False
        MNI_RATE_16_9.IsChecked = False
    End Sub

    Private Sub MNI_COMP_NONE_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_NONE.Click
        Call SUB_CHANGE_DRAW_COMPOTION(-1)
    End Sub

    Private Sub MNI_COMP_2DIV_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_2DIV.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.TWO_DIV)
    End Sub

    Private Sub MNI_COMP_3DIV_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_3DIV.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.THREE_DIV)
    End Sub

    Private Sub MNI_COMP_4DIV_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_4DIV.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.QUAD_DIV)
    End Sub

    Private Sub MNI_COMP_3DIV_PHI_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_3DIV_PHI.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.THREE_DIV_PHI)
    End Sub

    Private Sub MNI_COMP_GOLDEN_RECTANGLE_HLL_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_GOLDEN_RECTANGLE_HLL.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HLL)
    End Sub

    Private Sub MNI_COMP_GOLDEN_RECTANGLE_HUR_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_GOLDEN_RECTANGLE_HUR.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HUR)
    End Sub

    Private Sub MNI_COMP_GOLDEN_RECTANGLE_HUL_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_GOLDEN_RECTANGLE_HUL.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HUL)
    End Sub

    Private Sub MNI_COMP_GOLDEN_RECTANGLE_HLR_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_GOLDEN_RECTANGLE_HLR.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_HLR)
    End Sub

    Private Sub MNI_COMP_GOLDEN_RECTANGLE_VLL_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_GOLDEN_RECTANGLE_VLL.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VLL)
    End Sub

    Private Sub MNI_COMP_GOLDEN_RECTANGLE_VUR_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_GOLDEN_RECTANGLE_VUR.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VUR)
    End Sub

    Private Sub MNI_COMP_GOLDEN_RECTANGLE_VUL_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_GOLDEN_RECTANGLE_VUL.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VUL)
    End Sub

    Private Sub MNI_COMP_GOLDEN_RECTANGLE_VLR_Click(sender As Object, e As RoutedEventArgs) Handles MNI_COMP_GOLDEN_RECTANGLE_VLR.Click
        Call SUB_CHANGE_DRAW_COMPOTION(ENM_DIVISION_PATTERN.GOLDEN_RECTANGLE_VLR)
    End Sub

    Private Sub SUB_COMP_ALL_UNCHECKED()
        MNI_COMP_NONE.IsChecked = False
        MNI_COMP_2DIV.IsChecked = False
        MNI_COMP_3DIV.IsChecked = False
        MNI_COMP_4DIV.IsChecked = False
        MNI_COMP_3DIV_PHI.IsChecked = False
        MNI_COMP_GOLDEN_RECTANGLE_HLL.IsChecked = False
        MNI_COMP_GOLDEN_RECTANGLE_HUR.IsChecked = False
        MNI_COMP_GOLDEN_RECTANGLE_HUL.IsChecked = False
        MNI_COMP_GOLDEN_RECTANGLE_HLR.IsChecked = False
        MNI_COMP_GOLDEN_RECTANGLE_VLL.IsChecked = False
        MNI_COMP_GOLDEN_RECTANGLE_VUR.IsChecked = False
        MNI_COMP_GOLDEN_RECTANGLE_VUL.IsChecked = False
        MNI_COMP_GOLDEN_RECTANGLE_VLR.IsChecked = False
    End Sub

    Private Sub MNI_FIT_WINDOW_Click(sender As Object, e As RoutedEventArgs) Handles MNI_FIT_WINDOW.Click
        Call SUB_FIT_WINDOW()
    End Sub

    Private Sub MNI_FIT_LOGO_Click(sender As Object, e As RoutedEventArgs) Handles MNI_FIT_LOGO.Click
        If Not MOD_LOGO.FUNC_CHECK_WINDOW_LOGO Then
            Exit Sub
        End If

        Dim RCT_WH As RECT_WH
        RCT_WH = FUNC_GET_SIZE_WINDOW_LOGO()

        Call SUB_RATE_ALL_UNCHECKED()
        Call SUB_CHANGE_RATE(ENM_WINDOW_RATE.RATE_FREE)
        Me.Left = RCT_WH.left
        Me.Top = RCT_WH.top
        Me.Width = RCT_WH.width
        Me.Height = RCT_WH.height
    End Sub
#End Region

#Region "内部処理"
    Private Sub SUB_FIT_WINDOW()

        Dim SRT_RECT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT
        SRT_RECT = FUNC_GET_CRIENT_RECT(prcTARGET)

        Dim INT_WINDOW_WIDTH As Integer
        INT_WINDOW_WIDTH = FUNC_GET_RECT_WIDTH(SRT_RECT)

        Dim INT_WINDOW_HEIGHT As Integer
        INT_WINDOW_HEIGHT = FUNC_GET_RECT_HEIGHT(SRT_RECT)

        Dim INT_WINDOW_LEFT As Integer
        INT_WINDOW_LEFT = CAPT_COMMON.MOD_PROCESS_WINDOW.FUNC_GET_LEFT_WINDOW(prcTARGET)

        Dim INT_WINDOW_TOP As Integer
        INT_WINDOW_TOP = CAPT_COMMON.MOD_PROCESS_WINDOW.FUNC_GET_TOP_WINDOW(prcTARGET)

        If INT_WINDOW_LEFT <> 0 Then
            INT_WINDOW_LEFT += 8
        End If
        If INT_WINDOW_TOP <> 0 Then
            INT_WINDOW_TOP -= 8
        End If

        Me.Left = INT_WINDOW_LEFT
        Me.Top = INT_WINDOW_TOP
        BLN_SET_SIZE = True
        Me.Width = INT_WINDOW_WIDTH
        Me.Height = INT_WINDOW_HEIGHT
        BLN_SET_SIZE = False
        Call SUB_SET_RATE(ENM_RATE_CURRENT)

        If ENM_RATE_CURRENT = ENM_WINDOW_RATE.RATE_FREE Then
            Exit Sub
        End If

        'アスペクト比固定以外の場合は位置の調整を行う
        '余白部分を中央寄せ
        Dim INT_WIDTH_SUB As Integer
        INT_WIDTH_SUB = INT_WINDOW_WIDTH - Me.Width
        Dim INT_HEIGHT_SUB As Integer
        INT_HEIGHT_SUB = INT_WINDOW_HEIGHT - Me.Height

        If INT_WIDTH_SUB > INT_HEIGHT_SUB Then '左右中央寄せ
            Me.Left = INT_WINDOW_LEFT + Math.Truncate(INT_WIDTH_SUB / 2)
        Else '上下中央寄せ
            Me.Top = INT_WINDOW_LEFT + Math.Truncate(INT_HEIGHT_SUB / 2)
        End If
    End Sub

    Private Sub SUB_CALL_CAPT_ONE_NORMAL()
        If MOD_TRIM.FRM_PARENT Is Nothing Then
            Exit Sub
        End If
        MOD_TRIM.FRM_PARENT.FORCE_JPEG = False

        Call SUB_CALL_CAPT_ONE()
    End Sub

    Private Sub SUB_CALL_CAPT_ONE_SNS()
        If MOD_TRIM.FRM_PARENT Is Nothing Then
            Exit Sub
        End If
        MOD_TRIM.FRM_PARENT.FORCE_JPEG = True

        Call SUB_CALL_CAPT_ONE()
    End Sub

    Private Sub SUB_CALL_CAPT_ONE()
        If MOD_TRIM.FRM_PARENT Is Nothing Then
            Exit Sub
        End If

        Dim myArray(0) As Object
        myArray(0) = FRM_MAIN.ENM_MY_EXEC_DO.CAPT_ONE
        Dim iarINVOKE As IAsyncResult
        iarINVOKE = MOD_TRIM.FRM_PARENT.BeginInvoke(New FRM_MAIN_DELEGATE_DO_EXEC(AddressOf MOD_TRIM.FRM_PARENT.SUB_EXEC_DO), myArray)
        Call MOD_TRIM.FRM_PARENT.EndInvoke(iarINVOKE)
    End Sub

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

    Private Function FUNC_GET_LEFT_WINDOW() As Integer
        Dim srtRECT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT
        srtRECT = FUNC_GET_WINDOW_RECT(prcTARGET)

        Dim intWINDOW_LEFT As Integer
        Dim intWINDOW_TOP As Integer
        intWINDOW_LEFT = srtRECT.left
        intWINDOW_TOP = srtRECT.top

        Dim intWINDOW_WIDTH As Integer
        Dim intWINDOW_HEIGHT As Integer
        intWINDOW_WIDTH = FUNC_GET_RECT_WIDTH(srtRECT)
        intWINDOW_HEIGHT = FUNC_GET_RECT_HEIGHT(srtRECT)

        srtRECT = FUNC_GET_CRIENT_RECT(prcTARGET)
        Dim intCLIENT_WIDTH As Integer
        Dim intCLIENT_HEIGHT As Integer
        intCLIENT_WIDTH = FUNC_GET_RECT_WIDTH(srtRECT)
        intCLIENT_HEIGHT = FUNC_GET_RECT_HEIGHT(srtRECT)

        Dim intWIDTH_SUB As Integer
        Dim intHEIGHT_SUB As Integer
        intWIDTH_SUB = intWINDOW_WIDTH - intCLIENT_WIDTH
        intHEIGHT_SUB = intWINDOW_HEIGHT - intCLIENT_HEIGHT

        Dim intBORDER As Integer
        intWINDOW_LEFT += intBORDER
        intWINDOW_TOP += (intHEIGHT_SUB - intBORDER)

        Return intWINDOW_LEFT
    End Function

    Private Function FUNC_GET_TOP_WINDOW() As Integer
        Dim srtRECT As CAPT_COMMON.MOD_PROCESS_WINDOW.RECT
        srtRECT = FUNC_GET_WINDOW_RECT(prcTARGET)

        Dim intWINDOW_LEFT As Integer
        Dim intWINDOW_TOP As Integer
        intWINDOW_LEFT = srtRECT.left
        intWINDOW_TOP = srtRECT.top

        Dim intWINDOW_WIDTH As Integer
        Dim intWINDOW_HEIGHT As Integer
        intWINDOW_WIDTH = FUNC_GET_RECT_WIDTH(srtRECT)
        intWINDOW_HEIGHT = FUNC_GET_RECT_HEIGHT(srtRECT)

        srtRECT = FUNC_GET_CRIENT_RECT(prcTARGET)
        Dim intCLIENT_WIDTH As Integer
        Dim intCLIENT_HEIGHT As Integer
        intCLIENT_WIDTH = FUNC_GET_RECT_WIDTH(srtRECT)
        intCLIENT_HEIGHT = FUNC_GET_RECT_HEIGHT(srtRECT)

        Dim intWIDTH_SUB As Integer
        Dim intHEIGHT_SUB As Integer
        intWIDTH_SUB = intWINDOW_WIDTH - intCLIENT_WIDTH
        intHEIGHT_SUB = intWINDOW_HEIGHT - intCLIENT_HEIGHT

        Dim intBORDER As Integer
        intWINDOW_LEFT += intBORDER
        intWINDOW_TOP += (intHEIGHT_SUB - intBORDER)

        Return intWINDOW_TOP
    End Function

    Private Sub SUB_PUT_GUIDE()
        Dim strPUT As String

        strPUT = ""
        strPUT &= "X:" & Me.Left & System.Environment.NewLine
        strPUT &= "Y:" & Me.Top & System.Environment.NewLine
        strPUT &= "W:" & Me.ActualWidth & System.Environment.NewLine
        strPUT &= "H:" & Me.ActualHeight & System.Environment.NewLine

        LBL_GUIDE.Content = strPUT
    End Sub

    Private ENM_RATE_CURRENT As ENM_WINDOW_RATE = -1
    Friend Sub SUB_CHANGE_RATE(ByVal ENM_RATE As ENM_WINDOW_RATE)

        If ENM_RATE_CURRENT = ENM_RATE Then
            Exit Sub
        End If

        Call SUB_RATE_ALL_UNCHECKED()
        Select Case ENM_RATE
            Case ENM_WINDOW_RATE.RATE_FREE
                MNI_RATE_FREE.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_1_1
                MNI_RATE_1_1.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_2_3
                MNI_RATE_2_3.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_3_2
                MNI_RATE_3_2.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_3_4
                MNI_RATE_3_4.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_4_3
                MNI_RATE_4_3.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_5_7
                MNI_RATE_5_7.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_7_5
                MNI_RATE_7_5.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_5_8
                MNI_RATE_5_8.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_8_5
                MNI_RATE_8_5.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_5_12
                MNI_RATE_5_12.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_12_5
                MNI_RATE_12_5.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_9_16
                MNI_RATE_9_16.IsChecked = True
            Case ENM_WINDOW_RATE.RATE_16_9
                MNI_RATE_16_9.IsChecked = True
        End Select

        Call SUB_SET_RATE(ENM_RATE)
        ENM_RATE_CURRENT = ENM_RATE
    End Sub

    Private BLN_SET_SIZE As Boolean = False
    Private Sub SUB_SET_RATE(ByVal ENM_RATE As ENM_WINDOW_RATE)
        If ENM_RATE < 0 Then
            Exit Sub
        End If

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

        Select Case ENM_RATE
            Case ENM_WINDOW_RATE.RATE_FREE
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = intHEIGHT
                intWIDTH_02 = intWIDTH
                intHEIGHT_02 = intHEIGHT
            Case ENM_WINDOW_RATE.RATE_1_1
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 1) * 1)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 1) * 1)
            Case ENM_WINDOW_RATE.RATE_2_3
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 2) * 3)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 3) * 2)
            Case ENM_WINDOW_RATE.RATE_3_2
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 3) * 2)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 2) * 3)
            Case ENM_WINDOW_RATE.RATE_3_4
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 3) * 4)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 4) * 3)
            Case ENM_WINDOW_RATE.RATE_4_3
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 4) * 3)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 3) * 4)
            Case ENM_WINDOW_RATE.RATE_5_7
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 1000) * 1414)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 1414) * 1000)
            Case ENM_WINDOW_RATE.RATE_7_5
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 1414) * 1000)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 1000) * 1414)
            Case ENM_WINDOW_RATE.RATE_5_8
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 1000) * 1618)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 1618) * 1000)
            Case ENM_WINDOW_RATE.RATE_8_5
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 1618) * 1000)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 1000) * 1618)
            Case ENM_WINDOW_RATE.RATE_5_12
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 1000) * 2414)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 2414) * 1000)
            Case ENM_WINDOW_RATE.RATE_12_5
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 2414) * 1000)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 1000) * 2414)
            Case ENM_WINDOW_RATE.RATE_9_16
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 9) * 16)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 16) * 9)
            Case ENM_WINDOW_RATE.RATE_16_9
                intWIDTH_01 = intWIDTH
                intHEIGHT_01 = CInt((intWIDTH_01 / 16) * 9)
                intHEIGHT_02 = intHEIGHT
                intWIDTH_02 = CInt((intHEIGHT_02 / 9) * 16)
        End Select

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
        Call SUB_DRAW_COMPOSTION(Me.DRAWED_COMPOSTION_TYPE)
        Call SUB_PUT_GUIDE()
        BLN_SET_SIZE = False
    End Sub

#End Region

    Private Sub WPF_TRIM_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.CHECK_CLOSED = True
    End Sub

    Private Sub WPF_TRIM_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
        If BLN_SET_SIZE Then
            Exit Sub
        End If
        Call SUB_SET_RATE(ENM_RATE_CURRENT)
        Call SUB_PUT_GUIDE()
        Call SUB_SET_SIZE_WINDOW()
    End Sub

    Private Sub WPF_TRIM_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Call SUB_PUT_GUIDE()
        Call SUB_SET_SIZE_WINDOW()
    End Sub

    Private Sub WPF_TRIM_KeyDown(sender As Object, e As Windows.Input.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub WPF_TRIM_KeyUp(sender As Object, e As Windows.Input.KeyEventArgs) Handles Me.KeyUp
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

End Class
