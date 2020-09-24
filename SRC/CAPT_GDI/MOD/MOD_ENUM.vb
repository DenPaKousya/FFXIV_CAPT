Public Module MOD_ENUM
    Public Enum ENM_DIVISION_PATTERN
        TWO_DIV = 2
        THREE_DIV = 3
        QUAD_DIV = 4
        THREE_DIV_PHI = 5

        RATE_16_TO_9 = 6
        RATE_3_TO_2 = 7

        GOLDEN_RECTANGLE_L = 8
        GOLDEN_RECTANGLE_R = 9

        MIN = TWO_DIV
        MAX = GOLDEN_RECTANGLE_R
    End Enum

    Friend Enum ENM_ALIGNMENT
        LEFT_TOP = 0
        RIGHT_TOP
        LEFT_BOTTOM
        RIGHT_BOTTOM
    End Enum

    Friend Enum ENM_IMAGE_FORMAT
        PNG = 0
        JPEG = 1
        TIFF = 2
    End Enum

    Friend Enum ENM_POSITION_OVERLAY
        UNKNOWN = -1
        CENTER = 0
        LEFT_TOP = 1
        LEFT_BOTTOM = 2
        RIGHT_TOP = 3
        RIGHT_BOTTOM = 4
    End Enum

    Friend Enum ENM_SEND_KEY_INDEX
        NONE = 0
        LEFT
        UP
        RIGHT
        DOWN
        W
        A
        S
        D
    End Enum

    Friend Enum ENM_LIGHT_ROTATE_LR_KEY_INDEX
        LEFT = 0
        RIGHT
    End Enum

    Friend Enum ENM_LIGHT_DISTANSE_KEY_INDEX
        PAGE_UP = 0
        PAGE_DOWN
    End Enum

    Friend Enum ENM_LIGHT_ROTATE_UD_KEY_INDEX
        UP = 0
        DOWN
    End Enum

    Friend Function FUNC_GET_NAME_IMAGE_FORMAT(ByVal enmIMAGE_FORMAT As ENM_IMAGE_FORMAT) As String
        Dim strRET As String

        Select Case enmIMAGE_FORMAT
            Case ENM_IMAGE_FORMAT.PNG
                strRET = "PNG"
            Case ENM_IMAGE_FORMAT.JPEG
                strRET = "JPEG"
            Case ENM_IMAGE_FORMAT.TIFF
                strRET = "TIFF"
            Case Else
                strRET = "UNKNOWN"
        End Select

        Return strRET
    End Function
End Module
