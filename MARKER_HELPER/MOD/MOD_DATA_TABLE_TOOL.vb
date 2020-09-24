Module MOD_DATA_TABLE_TOOL

    'データテーブルの作成
    Public Sub SUB_MAKE_DATA_TABLE(ByRef tblHBase As System.Data.DataTable, ByVal strHColumnString As String, ByVal strHTypeString As String)
        Dim objWGuideColumn As Object
        Dim intWLoopIndex As Integer
        Dim colWTblColumn As System.Data.DataColumn

        tblHBase = New System.Data.DataTable

        objWGuideColumn = Split(strHColumnString, ",")

        For intWLoopIndex = LBound(objWGuideColumn) To UBound(objWGuideColumn)
            colWTblColumn = New System.Data.DataColumn
            colWTblColumn.ColumnName = objWGuideColumn(intWLoopIndex)
            colWTblColumn.DataType = FUNC_CONV_STR_TO_TYPE(Mid(strHTypeString, intWLoopIndex + 1, 1))
            tblHBase.Columns.Add(colWTblColumn)
        Next
    End Sub

    '列型の変換
    Private Function FUNC_CONV_STR_TO_TYPE(ByVal chrHTypeChar As Char) As Type
        Select Case chrHTypeChar
            Case "L"
                Return System.Type.GetType("System.Int64")
            Case "S"
                Return System.Type.GetType("System.String")
            Case "C"
                Return System.Type.GetType("System.Decimal")
            Case "D"
                Return System.Type.GetType("System.DateTime")
            Case "I"
                Return System.Type.GetType("System.Int32")
            Case "Z"
                Return System.Type.GetType("System.Double")
            Case "B"
                Return System.Type.GetType("System.Boolean")
            Case Else
                Return System.Type.GetType("System.String")
        End Select
    End Function

    'データテーブルに行を追加
    Public Sub SUB_ADD_ROW_DATA_TABLE(ByRef TBL_BASE As System.Data.DataTable, ByRef OBJ_ROW() As Object)
        Call TBL_BASE.Rows.Add(OBJ_ROW)
    End Sub

End Module
