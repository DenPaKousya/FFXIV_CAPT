Public Module MOD_CASH_TOOL
#Region "キャッシュ用構造体の定義"
    Public Structure SRT_CASH_INT_DEC
        Public KEY01 As Integer
        Public VALUE As Decimal
    End Structure

    Public Structure SRT_CASH_INT_INT
        Public KEY01 As Integer
        Public VALUE As Integer
    End Structure

    Public Structure SRT_CASH_INT_STR
        Public KEY01 As Integer
        Public VALUE As String
    End Structure

    Public Structure SRT_CASH_INT_INT_STR
        Public KEY01 As Integer
        Public KEY02 As Integer
        Public VALUE As String
    End Structure
#End Region

#Region "INT_INT"
    Public Sub SUB_ADD_CASH_INT_INT( _
    ByRef srtCASH() As SRT_CASH_INT_INT, _
    ByVal intKEY01 As Integer, ByVal intVALUE As Decimal _
    )
        Dim intINDEX As Integer

        If FUNC_SEARCH_CASH_INT_INT(srtCASH, intKEY01) <> -1 Then 'すでに存在するなら
            Exit Sub '追加しない
        End If

        If IsNothing(srtCASH) Then
            intINDEX = 0
        Else
            intINDEX = UBound(srtCASH) + 1
        End If

        ReDim Preserve srtCASH(intINDEX)
        With srtCASH(intINDEX)
            .KEY01 = intKEY01
            .VALUE = intVALUE
        End With

    End Sub

    Public Function FUNC_SEARCH_CASH_INT_INT( _
    ByRef srtSEARCH() As SRT_CASH_INT_INT, _
    ByVal intKEY01 As Integer _
    ) As Integer
        Dim intLOOP_INDEX As Integer
        Dim intRET As Integer

        If IsNothing(srtSEARCH) Then
            Return -1
        End If

        intRET = -1

        For intLOOP_INDEX = LBound(srtSEARCH) To UBound(srtSEARCH)
            With srtSEARCH(intLOOP_INDEX)
                If .KEY01 = intKEY01 Then
                    intRET = intLOOP_INDEX
                    Exit For
                End If
            End With
        Next

        Return intRET
    End Function
#End Region

#Region "INT_DEC"
    Public Sub SUB_ADD_CASH_INT_DEC( _
    ByRef srtCASH() As SRT_CASH_INT_DEC, _
    ByVal intKEY01 As Integer, ByVal decVALUE As Decimal _
    )
        Dim intINDEX As Integer

        If FUNC_SEARCH_CASH_INT_DEC(srtCASH, intKEY01) <> -1 Then 'すでに存在するなら
            Exit Sub '追加しない
        End If

        If IsNothing(srtCASH) Then
            intINDEX = 0
        Else
            intINDEX = UBound(srtCASH) + 1
        End If

        ReDim Preserve srtCASH(intINDEX)
        With srtCASH(intINDEX)
            .KEY01 = intKEY01
            .VALUE = decVALUE
        End With

    End Sub

    Public Function FUNC_SEARCH_CASH_INT_DEC( _
    ByRef srtSEARCH() As SRT_CASH_INT_DEC, _
    ByVal intKEY01 As Integer _
    ) As Integer
        Dim intLOOP_INDEX As Integer
        Dim intRET As Integer

        If IsNothing(srtSEARCH) Then
            Return -1
        End If

        intRET = -1

        For intLOOP_INDEX = LBound(srtSEARCH) To UBound(srtSEARCH)
            With srtSEARCH(intLOOP_INDEX)
                If .KEY01 = intKEY01 Then
                    intRET = intLOOP_INDEX
                    Exit For
                End If
            End With
        Next

        Return intRET
    End Function
#End Region

#Region "INT_STR"
    Public Sub SUB_ADD_CASH_INT_STR( _
    ByRef srtCASH() As SRT_CASH_INT_STR, _
    ByVal intKEY01 As Integer, ByVal strVALUE As String _
    )
        Dim intINDEX As Integer

        If FUNC_SEARCH_CASH_INT_STR(srtCASH, intKEY01) <> -1 Then 'すでに存在するなら
            Exit Sub '追加しない
        End If

        If IsNothing(srtCASH) Then
            intINDEX = 0
        Else
            intINDEX = UBound(srtCASH) + 1
        End If

        ReDim Preserve srtCASH(intINDEX)
        With srtCASH(intINDEX)
            .KEY01 = intKEY01
            .VALUE = strVALUE
        End With

    End Sub

    Public Function FUNC_SEARCH_CASH_INT_STR( _
    ByRef srtSEARCH() As SRT_CASH_INT_STR, _
    ByVal intKEY01 As Integer _
    ) As Integer
        Dim intLOOP_INDEX As Integer
        Dim intRET As Integer

        If IsNothing(srtSEARCH) Then
            Return -1
        End If

        intRET = -1

        For intLOOP_INDEX = LBound(srtSEARCH) To UBound(srtSEARCH)
            With srtSEARCH(intLOOP_INDEX)
                If .KEY01 = intKEY01 Then
                    intRET = intLOOP_INDEX
                    Exit For
                End If
            End With
        Next

        Return intRET
    End Function
#End Region

#Region "INT_INT_STR"
    Public Sub SUB_ADD_CASH_INT_INT_STR( _
    ByRef srtCASH() As SRT_CASH_INT_INT_STR, _
    ByVal intKEY01 As Integer, ByVal intKEY02 As Integer, ByVal strVALUE As String _
    )
        Dim intINDEX As Integer

        If FUNC_SEARCH_CASH_INT_INT_STR(srtCASH, intKEY01, intKEY02) <> -1 Then 'すでに存在するなら
            Exit Sub '追加しない
        End If

        If IsNothing(srtCASH) Then
            intINDEX = 0
        Else
            intINDEX = UBound(srtCASH) + 1
        End If

        ReDim Preserve srtCASH(intINDEX)
        With srtCASH(intINDEX)
            .KEY01 = intKEY01
            .KEY02 = intKEY02
            .VALUE = strVALUE
        End With

    End Sub

    Public Function FUNC_SEARCH_CASH_INT_INT_STR( _
    ByRef srtSEARCH() As SRT_CASH_INT_INT_STR, _
    ByVal intKEY01 As Integer, _
    ByVal intKEY02 As Integer _
    ) As Integer
        Dim intLOOP_INDEX As Integer
        Dim intRET As Integer

        If IsNothing(srtSEARCH) Then
            Return -1
        End If

        intRET = -1

        For intLOOP_INDEX = LBound(srtSEARCH) To UBound(srtSEARCH)
            With srtSEARCH(intLOOP_INDEX)
                If .KEY01 = intKEY01 _
                And .KEY02 = intKEY02 Then
                    intRET = intLOOP_INDEX
                    Exit For
                End If
            End With
        Next

        Return intRET
    End Function

#End Region

End Module
