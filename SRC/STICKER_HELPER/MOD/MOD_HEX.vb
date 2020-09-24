Public Module MOD_HEX

    Public Function FUNC_GET_STRING_HEX_BYTE(ByVal INT_VALUE As Integer) As String
        Dim STR_TEMP As String
        STR_TEMP = Convert.ToString(INT_VALUE, 16)

        STR_TEMP &= "00" & STR_TEMP

        Dim STR_RET As String
        STR_RET = STR_TEMP.Substring(STR_TEMP.Length - 2, 2)
        Return STR_RET
    End Function

    Public Function FUNC_CONVERT_HEX_UISAVE(ByVal BYT_ONE As Byte) As Byte

        Const CST_XOR As Byte = &H42

        Dim BYT_RET As Byte
        BYT_RET = BYT_ONE Xor CST_XOR
        Return BYT_RET

        'Dim INT_TEMP As Integer

        'INT_TEMP = BYT_ONE
        'Dim INT_LOW As Integer
        'INT_LOW = INT_TEMP And &HF

        'Dim INT_HIGH As Integer
        'INT_HIGH = INT_TEMP And &HF0
        'INT_HIGH = INT_HIGH >> 4

        'Dim INT_LOW_CNV As Integer
        'INT_LOW_CNV = FUNC_CONVERT_ONE_VALUE_4BIT(INT_LOW)

        'Dim INT_HIGH_CNV As Integer
        'INT_HIGH_CNV = FUNC_CONVERT_ONE_VALUE_4BIT(INT_HIGH)
        'INT_HIGH_CNV = INT_HIGH_CNV << 4

        'Dim INT_RET As Integer
        'INT_RET = INT_HIGH_CNV + INT_LOW_CNV

        'Dim BYT_RET As Byte
        'BYT_RET = CByte(INT_RET)
        'Return BYT_RET
    End Function

    Private Function FUNC_CONVERT_ONE_VALUE_4BIT(ByVal INT_VALUE As Integer)
        'INT_VALUE=0~15

        Dim INT_MOD As Integer
        INT_MOD = INT_VALUE Mod 2

        Dim INT_RET As Integer
        If INT_MOD = 0 Then
            INT_RET = INT_VALUE + 1
        Else
            INT_RET = INT_VALUE - 1
        End If

        Return INT_RET
    End Function

    Public Function FUNC_GECT_STRING_FROM_HEX(ByRef BYT_HEX() As Byte) As String
        Dim BYT_TEMP() As Byte
        BYT_TEMP = Nothing
        For i = 1 To (BYT_HEX.Length - 1)
            If BYT_HEX(i) = &H0 Then
                Exit For
            End If
            Dim INT_INDEX As Integer
            If BYT_TEMP Is Nothing Then
                INT_INDEX = 0
            Else
                INT_INDEX = BYT_TEMP.Length
            End If
            ReDim Preserve BYT_TEMP(INT_INDEX)
            BYT_TEMP(INT_INDEX) = BYT_HEX(i)
        Next

        Dim STR_RET As String

        If BYT_TEMP Is Nothing Then
            STR_RET = ""
        Else
            STR_RET = System.Text.Encoding.UTF8.GetString(BYT_TEMP)
        End If

        Return STR_RET
    End Function
End Module
