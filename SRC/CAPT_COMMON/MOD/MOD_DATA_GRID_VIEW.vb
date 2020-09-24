Public Module MOD_DATA_GRID_VIEW

    '文字数でのラッパー
    Public Sub SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT( _
    ByRef dgvCONTROL As System.Windows.Forms.DataGridView, _
    ByVal strCOLUMN_COUNT As String, _
    ByVal strALIGNMENT As String, _
    Optional ByVal strSORT_ENABLED As String = "" _
    )
        Dim sngFONT_SIZE As Single
        Dim sngBASE_POINT As Single
        Dim objCOUNT As Object
        Dim intLOOP_INDEX As Integer
        Dim intCOUNT As Integer
        Dim strWIDTH_ROW() As String
        Dim strWIDTHS As String

        sngFONT_SIZE = dgvCONTROL.Font.Size
        sngBASE_POINT = sngFONT_SIZE * 2 '全角としてとりあえず2倍
        sngBASE_POINT = CInt(sngBASE_POINT) + 1 '

        objCOUNT = Split(strCOLUMN_COUNT, ",")
        ReDim strWIDTH_ROW(UBound(objCOUNT))
        For intLOOP_INDEX = LBound(objCOUNT) To UBound(objCOUNT)
            intCOUNT = CInt(objCOUNT(intLOOP_INDEX))
            strWIDTH_ROW(intLOOP_INDEX) = CStr(sngBASE_POINT * intCOUNT)
        Next

        strWIDTHS = FUNC_CONVERT_STRING_ROW_TO_STRING(strWIDTH_ROW)

        Call SUB_DGV_COLUMN_WIDTH_INIT(dgvCONTROL, strWIDTHS, strALIGNMENT, strSORT_ENABLED)

    End Sub

    Public Sub SUB_DGV_COLUMN_WIDTH_INIT( _
    ByRef dgvCONTROL As System.Windows.Forms.DataGridView, _
    ByVal strCOLUMN_WIDTH As String, _
    ByVal strALIGNMENT As String, _
    Optional ByVal strSORT_ENABLED As String = "" _
    )
        Dim objWIDTH As Object
        Dim intLOOP_INDEX As Integer
        Dim strCHAR As String

        objWIDTH = Split(strCOLUMN_WIDTH, ",")

        For intLOOP_INDEX = LBound(objWIDTH) To UBound(objWIDTH)
            Try
                dgvCONTROL.Columns(intLOOP_INDEX).Width = CInt(objWIDTH(intLOOP_INDEX))

                If strSORT_ENABLED = "" Then
                    dgvCONTROL.Columns(intLOOP_INDEX).SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
                Else
                    strCHAR = Mid(strSORT_ENABLED, intLOOP_INDEX + 1, 1)
                    dgvCONTROL.Columns(intLOOP_INDEX).SortMode = FUNC_GET_SORT_MODE(strCHAR)
                End If

                strCHAR = Mid(strALIGNMENT, intLOOP_INDEX + 1, 1)
                dgvCONTROL.Columns(intLOOP_INDEX).DefaultCellStyle.Alignment = FUNC_GET_ALIGNMENT_VALUE(strCHAR)

            Catch ex As Exception
                Exit Sub
            End Try
        Next

    End Sub

    Private Function FUNC_GET_SORT_MODE(ByVal strMODE As String) As System.Windows.Forms.DataGridViewColumnSortMode
        Dim enmRET As System.Windows.Forms.DataGridViewColumnSortMode

        If strMODE = "Y" Then
            enmRET = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Else
            enmRET = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        End If

        Return enmRET
    End Function

    Public Sub SUB_DGV_COLUMN_WIDTH_INIT_COPY( _
    ByRef dgvCONTROL As System.Windows.Forms.DataGridView, _
    ByRef dgvCONTROL_SOURCE As System.Windows.Forms.DataGridView _
    )
        Dim intLOOP_INDEX As Integer

        For intLOOP_INDEX = 0 To (dgvCONTROL_SOURCE.Columns.Count - 1)
            Try
                dgvCONTROL.Columns(intLOOP_INDEX).Width = dgvCONTROL_SOURCE.Columns(intLOOP_INDEX).Width
                dgvCONTROL.Columns(intLOOP_INDEX).SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
                dgvCONTROL.Columns(intLOOP_INDEX).DefaultCellStyle.Alignment = dgvCONTROL_SOURCE.Columns(intLOOP_INDEX).DefaultCellStyle.Alignment
            Catch ex As Exception
                Exit Sub
            End Try
        Next

    End Sub

    Private Function FUNC_GET_ALIGNMENT_VALUE(ByVal strCHAR As String) As System.Windows.Forms.DataGridViewContentAlignment
        Dim enmRET As System.Windows.Forms.DataGridViewContentAlignment

        Select Case strCHAR
            Case "R"
                enmRET = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Case "L"
                enmRET = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Case "C"
                enmRET = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Case Else
                enmRET = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        End Select
        Return enmRET
    End Function

    Public Function FUNC_GET_SELECT_ROW_INDEX(ByRef dgvCONTROL As System.Windows.Forms.DataGridView) As Integer
        Dim tblTEMP As DataTable
        Dim intRET As Integer
        Dim dgvROW As System.Windows.Forms.DataGridViewRow
        Dim dgvCELL As System.Windows.Forms.DataGridViewCell

        tblTEMP = dgvCONTROL.DataSource

        If IsNothing(tblTEMP) Then
            Return -1
        End If

        If tblTEMP.Rows.Count <= 0 Then
            Return 0
        End If

        Select Case dgvCONTROL.SelectionMode
            Case System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
                dgvROW = dgvCONTROL.SelectedRows(0)
                intRET = dgvROW.Cells(0).RowIndex
            Case System.Windows.Forms.DataGridViewSelectionMode.CellSelect
                dgvCELL = dgvCONTROL.SelectedCells(0)
                intRET = dgvCELL.RowIndex
            Case System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect
                dgvCELL = dgvCONTROL.SelectedCells(0)
                intRET = dgvCELL.RowIndex
            Case Else
                intRET = 0
        End Select

        intRET += 1
        Return intRET
    End Function

    Public Sub SUB_SET_SELECT_ROW_INDEX(ByRef dgvCONTROL As System.Windows.Forms.DataGridView, ByVal intSELECT As Integer)
        Dim tblTEMP As DataTable

        tblTEMP = dgvCONTROL.DataSource

        If IsNothing(tblTEMP) Then
            Exit Sub
        End If

        If tblTEMP.Rows.Count <= 0 Then
            Exit Sub
        End If

        If intSELECT <= 0 Then
            dgvCONTROL.CurrentCell = Nothing
        Else
            dgvCONTROL.CurrentCell = dgvCONTROL.Rows(intSELECT - 1).Cells(0)
        End If
        'SelectionModeプロパティが "RowHeaderSelect" なら、
        'dgvCONTROL.Rows(1).Selected = True
        Call System.Windows.Forms.Application.DoEvents()

    End Sub

    Public Sub SUB_DATA_GRID_SORT_CLEAR(ByRef dgvCONTROL As System.Windows.Forms.DataGridView)
        Dim tblTEMP As DataTable
        Dim davTEMP As DataView

        tblTEMP = dgvCONTROL.DataSource

        If IsNothing(tblTEMP) Then
            Exit Sub
        End If

        davTEMP = tblTEMP.DefaultView 'テーブルからビューを読み取る
        davTEMP.Sort = "" 'ソート条件に空（Null）を代入
        Call System.Windows.Forms.Application.DoEvents()
        'dgvCONTROL.HeaderCell.SortGlyphDirection = Windows.Forms.SortOrder.None 'ソートを解除
    End Sub
End Module
