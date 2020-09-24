Imports System.ComponentModel

Class WPF_MAIN

#Region "画面用・定数"
    Const CST_COUNT_STICKER As Integer = 5

#End Region

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_OPEN_FILE = 1
        DO_BACKUP
        DO_RESTORE
        DO_DELETE
        DO_DOWNLOAD
    End Enum

    Private Enum ENM_MARKER_INFO
        MARKER_A_POINT_01 = (&HC * 0) + &H1
        MARKER_A_POINT_02
        MARKER_A_POINT_03
        MARKER_A_POINT_04
        MARKER_A_OPTION_01 = (&HC * 0) + &H9
        MARKER_A_OPTION_02
        MARKER_A_OPTION_03
        MARKER_A_OPTION_04

        MARKER_B_POINT_01 = (&HC * 1) + &H1
        MARKER_B_POINT_02
        MARKER_B_POINT_03
        MARKER_B_POINT_04
        MARKER_B_OPTION_01 = (&HC * 1) + &H9
        MARKER_B_OPTION_02
        MARKER_B_OPTION_03
        MARKER_B_OPTION_04


        MARKER_C_POINT_01 = (&HC * 2) + &H1
        MARKER_C_POINT_02
        MARKER_C_POINT_03
        MARKER_C_POINT_04
        MARKER_C_OPTION_01 = (&HC * 2) + &H9
        MARKER_C_OPTION_02
        MARKER_C_OPTION_03
        MARKER_C_OPTION_04

        MARKER_D_POINT_01 = (&HC * 3) + &H1
        MARKER_D_POINT_02
        MARKER_D_POINT_03
        MARKER_D_POINT_04
        MARKER_D_OPTION_01 = (&HC * 3) + &H9
        MARKER_D_OPTION_02
        MARKER_D_OPTION_03
        MARKER_D_OPTION_04

        MARKER_1_POINT_01 = (&HC * 4) + &H1
        MARKER_1_POINT_02
        MARKER_1_POINT_03
        MARKER_1_POINT_04
        MARKER_1_OPTION_01 = (&HC * 4) + &H9
        MARKER_1_OPTION_02
        MARKER_1_OPTION_03
        MARKER_1_OPTION_04

        MARKER_2_POINT_01 = (&HC * 5) + &H1
        MARKER_2_POINT_02
        MARKER_2_POINT_03
        MARKER_2_POINT_04
        MARKER_2_OPTION_01 = (&HC * 5) + &H9
        MARKER_2_OPTION_02
        MARKER_2_OPTION_03
        MARKER_2_OPTION_04

        MARKER_3_POINT_01 = (&HC * 6) + &H1
        MARKER_3_POINT_02
        MARKER_3_POINT_03
        MARKER_3_POINT_04
        MARKER_3_OPTION_01 = (&HC * 6) + &H9
        MARKER_3_OPTION_02
        MARKER_3_OPTION_03
        MARKER_3_OPTION_04

        MARKER_4_POINT_01 = (&HC * 7) + &H1
        MARKER_4_POINT_02
        MARKER_4_POINT_03
        MARKER_4_POINT_04
        MARKER_4_OPTION_01 = (&HC * 7) + &H9
        MARKER_4_OPTION_02
        MARKER_4_OPTION_03
        MARKER_4_OPTION_04

        ID_CONTENT_02 = &H63
        ID_CONTENT_01 = &H64
        DATE_TIME_01 = &H65
        DATE_TIME_02 = &H66
        DATE_TIME_03 = &H67
        DATE_TIME_04 = &H68
    End Enum

#End Region

#Region "画面用・構造体"

#Region "マーカー情報"
    Private Structure SRT_MARKER_INFO
        Public BYT_STICKER_ENABLED() As Byte
        Public BYT_STICKER_ENABLED_CNV() As Byte
        Public STICKER_ENABLED As Integer

        Public BYT_TITLE() As Byte
        Public BYT_TITLE_CNV() As Byte
        Public TITLE As String

        Public BYT_STICKER_INFO() As Byte

        Public BYT_STICKER_BACKUP() As Byte

        Public BYT_MARKER() As Byte

        Public POINT_MARKER_A() As Byte
        Public POINT_MARKER_B() As Byte
        Public POINT_MARKER_C() As Byte
        Public POINT_MARKER_D() As Byte
        Public POINT_MARKER_1() As Byte
        Public POINT_MARKER_2() As Byte
        Public POINT_MARKER_3() As Byte
        Public POINT_MARKER_4() As Byte

        Public OPTION_MARKER_A() As Byte
        Public OPTION_MARKER_B() As Byte
        Public OPTION_MARKER_C() As Byte
        Public OPTION_MARKER_D() As Byte
        Public OPTION_MARKER_1() As Byte
        Public OPTION_MARKER_2() As Byte
        Public OPTION_MARKER_3() As Byte
        Public OPTION_MARKER_4() As Byte

        Public ID_ENABLED As Integer
        Public ID_CONTENT_01 As Integer
        Public ID_CONTENT_02 As Integer

        Public DATE_TIME_EDIT_01 As Integer
        Public DATE_TIME_EDIT_02 As Integer
        Public DATE_TIME_EDIT_03 As Integer
        Public DATE_TIME_EDIT_04 As Integer
        Public DATE_TIME_EDIT_INT As Integer

        Public DATE_TIME_EDIT As DateTime

        Public Function ENABLED() As Boolean

            If Me.STICKER_ENABLED = 1 Then
                Return True
            End If
            Return False

        End Function

        Public Function NAME_STICKER() As String

            If Not Me.ENABLED Then
                Return "EMPTY"
            End If

            Return Me.TITLE
        End Function

        Private Function FUNC_GET_CONTENT_NAME() As String
            Dim STR_RET As String
            Select Case Me.ID_CONTENT_01
                Case &H30
                    STR_RET = FUNC_GET_NAME_CONTENT_30(Me.ID_CONTENT_02)
                Case &H31
                    STR_RET = FUNC_GET_NAME_CONTENT_31(Me.ID_CONTENT_02)
                Case &H33
                    STR_RET = FUNC_GET_NAME_CONTENT_33(Me.ID_CONTENT_02)
                Case Else
                    STR_RET = ""
            End Select

            Return STR_RET
        End Function

        Private Function FUNC_GET_CONTENT_ID_STRING() As String
            Dim STR_RET As String

            STR_RET = ""
            STR_RET &= "("
            STR_RET &= FUNC_GET_STRING_HEX_BYTE(Me.ID_CONTENT_01)
            STR_RET &= "-"
            STR_RET &= FUNC_GET_STRING_HEX_BYTE(Me.ID_CONTENT_02)
            STR_RET &= ")"

            Return STR_RET
        End Function


    End Structure


#End Region

#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean

    Private INT_OFFSET_MARKER As Integer = &H6C96

    Private STR_INIT_PATH_BACKUP As String
    Private STR_INIT_PATH_RESTORE As String
    Private STR_FILE_PATH_UISAVE As String
    Private BYT_UISAVE() As Byte
    Private SRT_MARKER_LIST(CST_COUNT_STICKER) As SRT_MARKER_INFO

    Private LBL_NAME_CONTENT(CST_COUNT_STICKER) As Label

#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        LBL_NAME_CONTENT(1) = LBL_01_NAME_CONTENT
        LBL_NAME_CONTENT(2) = LBL_02_NAME_CONTENT
        LBL_NAME_CONTENT(3) = LBL_03_NAME_CONTENT
        LBL_NAME_CONTENT(4) = LBL_04_NAME_CONTENT
        LBL_NAME_CONTENT(5) = LBL_05_NAME_CONTENT

    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()
        STR_INIT_PATH_BACKUP = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        STR_INIT_PATH_RESTORE = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        TXT_PATH_UISAVE.Text = ""
        LBL_OFFSET.Content = ""

        For i = 1 To CST_COUNT_STICKER
            Call SUB_CLEAR_MARKER(i)
        Next

        GRP_SAVE_LIST.IsEnabled = False
        GRP_TASK.IsEnabled = False
    End Sub
#End Region

#Region "各処理呼出元"
    Private Sub SUB_EXEC_DO(
    ByVal enmEXEC_DO As ENM_MY_EXEC_DO
    )
        If BLN_PROCESS_DOING Then
            Exit Sub
        End If

        Me.Cursor = Cursors.Wait
        BLN_PROCESS_DOING = True

        Select Case enmEXEC_DO
            Case ENM_MY_EXEC_DO.DO_OPEN_FILE
                Call SUB_OPEN_FILE()
            Case ENM_MY_EXEC_DO.DO_BACKUP
                Call SUB_BACKUP()
            Case ENM_MY_EXEC_DO.DO_RESTORE
                Call SUB_RESTORE()
            Case ENM_MY_EXEC_DO.DO_DELETE
                Call SUB_DELETE()
            Case ENM_MY_EXEC_DO.DO_DOWNLOAD
                Call SUB_DOWNLOAD()
        End Select

        BLN_PROCESS_DOING = False
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

#Region "実行処理群"
    Private Sub SUB_OPEN_FILE()
        Dim PRC_TARGET As Process
        PRC_TARGET = FUNC_GET_FFXIV_PROCESS()

        Dim MBR_RESULT As MessageBoxResult
        If Not (PRC_TARGET Is Nothing) Then
            Dim STR_MSG As String
            STR_MSG = ""
            STR_MSG &= "ゲーム実行中はファイルの書換が出来ません。" & System.Environment.NewLine
            STR_MSG &= "よろしいですか？" & System.Environment.NewLine
            STR_MSG &= "（キャラクター選択画面での書換は可能です。）" & System.Environment.NewLine
            MBR_RESULT = MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.YesNo, MessageBoxImage.Question)
        Else
            MBR_RESULT = MessageBoxResult.Yes
        End If

        If Not MBR_RESULT = MessageBoxResult.Yes Then
            Exit Sub
        End If

        Dim OFD_UISAVE As Microsoft.Win32.OpenFileDialog
        OFD_UISAVE = New Microsoft.Win32.OpenFileDialog
        OFD_UISAVE.Filter = "ユーザーインターフェースファイル|UISAVE.DAT"
        OFD_UISAVE.InitialDirectory = FUNC_GET_INIT_PATH()

        Dim BLN_OPEN As Boolean
        BLN_OPEN = OFD_UISAVE.ShowDialog()
        If Not BLN_OPEN Then
            Exit Sub
        End If

        TXT_PATH_UISAVE.Text = OFD_UISAVE.FileName
        If Not FUNC_LOAD_UISAVE(OFD_UISAVE.FileName) Then
            Call MessageBox.Show(STR_FUNC_LOAD_UISAVE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        STR_FILE_PATH_UISAVE = OFD_UISAVE.FileName
        Call SUB_EDIT()
    End Sub

    Private Sub SUB_BACKUP()

        If Not FUNC_CHECK_BACKUP() Then
            Call MessageBox.Show(STR_FUNC_CHECK_BACKUP_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
            Exit Sub
        End If

        Dim SFD_BACKUP As Microsoft.Win32.SaveFileDialog
        SFD_BACKUP = New Microsoft.Win32.SaveFileDialog
        SFD_BACKUP.Filter = FUNC_GET_BACKUP_DIALOG_FILTER()
        SFD_BACKUP.InitialDirectory = STR_INIT_PATH_BACKUP

        Dim INT_INDEX_MARKER As Integer
        INT_INDEX_MARKER = FUNC_GET_INDEX_MARKER()
        SFD_BACKUP.FileName = FUNC_CONVERT_STR_TO_FILE_NAME(SRT_MARKER_LIST(INT_INDEX_MARKER).TITLE)

        Dim BLN_SAVE As Boolean
        BLN_SAVE = SFD_BACKUP.ShowDialog()
        If Not BLN_SAVE Then
            Exit Sub
        End If
        STR_INIT_PATH_BACKUP = FUNC_PATH_TO_DIR_PATH(SFD_BACKUP.FileName)

        Dim STR_FILE_PATH As String
        STR_FILE_PATH = SFD_BACKUP.FileName

        If Not FUNC_WRITE_FILE(STR_FILE_PATH, SRT_MARKER_LIST(INT_INDEX_MARKER).BYT_STICKER_BACKUP) Then
            Call MessageBox.Show(STR_FUNC_WRITE_FILE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Dim STR_MSG As String
        STR_MSG = ""
        STR_MSG &= "ステッカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "タイトル：" & SRT_MARKER_LIST(INT_INDEX_MARKER).NAME_STICKER & System.Environment.NewLine
        STR_MSG &= "をバックアップしました。" & System.Environment.NewLine
        Call MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub

    Private Sub SUB_RESTORE()

        If Not FUNC_CHECK_RESTORE() Then
            Call MessageBox.Show(STR_FUNC_CHECK_RESTORE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
            Exit Sub
        End If

        Dim OFD_BACKUP As Microsoft.Win32.OpenFileDialog
        OFD_BACKUP = New Microsoft.Win32.OpenFileDialog
        OFD_BACKUP.Filter = FUNC_GET_BACKUP_DIALOG_FILTER()
        OFD_BACKUP.InitialDirectory = STR_INIT_PATH_RESTORE

        Dim BLN_OPEN As Boolean
        BLN_OPEN = OFD_BACKUP.ShowDialog()
        If Not BLN_OPEN Then
            Exit Sub
        End If
        STR_INIT_PATH_RESTORE = FUNC_PATH_TO_DIR_PATH(OFD_BACKUP.FileName)

        Dim INT_INDEX_MARKER As Integer
        INT_INDEX_MARKER = FUNC_GET_INDEX_MARKER()
        Dim STR_MSG As String
        STR_MSG = ""
        STR_MSG &= "ステッカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "を上書きします。" & System.Environment.NewLine
        STR_MSG &= "よろしいですか？" & System.Environment.NewLine
        Dim MBR_RESULT As MessageBoxResult
        MBR_RESULT = MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.YesNo, MessageBoxImage.Question)
        If MBR_RESULT = MessageBoxResult.No Then
            Exit Sub
        End If

        Dim BYT_RESTORE() As Byte
        BYT_RESTORE = Nothing
        If Not FUNC_READ_FILE(OFD_BACKUP.FileName, BYT_RESTORE) Then
            Call MessageBox.Show(STR_FUNC_READ_FILE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        If BYT_RESTORE.Length <> CST_LENGTH_FILE_SBK Then
            Call MessageBox.Show("バックアップファイルの内容が正しくありません。", Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Dim INT_MOD_FROM As Integer
        INT_MOD_FROM = INT_OFFSET_MARKER
        Dim INT_MOD_TO As Integer

        Dim BYT_WRITE() As Byte
        ReDim BYT_WRITE(BYT_UISAVE.Length - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            BYT_WRITE(i) = BYT_UISAVE(i)
        Next

        Dim INT_WRITE_INDEX As Integer
        INT_WRITE_INDEX = 0

        '有効／無効
        INT_MOD_FROM = INT_OFFSET_MARKER + 0
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_STICKER_ENABLED_BYTE_LENGTH)
        INT_MOD_TO = INT_MOD_FROM + (CST_STICKER_ENABLED_BYTE_LENGTH - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            End If
        Next

        'タイトル
        INT_MOD_FROM = INT_OFFSET_MARKER + (CST_STICKER_ENABLED_BYTE_LENGTH * CST_COUNT_STICKER)
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_TITLE_BYTE_LENGTH)
        INT_MOD_TO = INT_MOD_FROM + (CST_TITLE_BYTE_LENGTH - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            End If
        Next

        '内容
        INT_MOD_FROM = INT_OFFSET_MARKER + (CST_STICKER_ENABLED_BYTE_LENGTH * CST_COUNT_STICKER) + (CST_TITLE_BYTE_LENGTH * CST_COUNT_STICKER) + &HB
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_STICKER_INFO_BYTE_LENGTH)
        INT_MOD_TO = INT_MOD_FROM + (CST_STICKER_INFO_BYTE_LENGTH - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            End If
        Next

        If Not FUNC_BACKUP_UISAVE_DAT() Then
            Call MessageBox.Show(STR_FUNC_BACKUP_UISAVE_DAT_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        If Not FUNC_FILE_DELETE(STR_FILE_PATH_UISAVE) Then
            Call MessageBox.Show(STR_FILE_TOOL_LAST_ERR_STRING, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        If Not FUNC_WRITE_FILE(STR_FILE_PATH_UISAVE, BYT_WRITE) Then
            Call MessageBox.Show(STR_FUNC_WRITE_FILE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Call FUNC_LOAD_UISAVE(STR_FILE_PATH_UISAVE)
        Call SUB_EDIT()

        STR_MSG = ""
        STR_MSG &= "ステッカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "を復元しました。" & System.Environment.NewLine
        Call MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub

    Private Sub SUB_DELETE()

        If Not FUNC_CHECK_DELETE() Then
            Call MessageBox.Show(STR_FUNC_CHECK_DELETE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
            Exit Sub
        End If

        Dim INT_INDEX_MARKER As Integer
        INT_INDEX_MARKER = FUNC_GET_INDEX_MARKER()
        Dim STR_MSG As String
        STR_MSG = ""
        STR_MSG &= "ステッカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "タイトル：" & SRT_MARKER_LIST(INT_INDEX_MARKER).NAME_STICKER & System.Environment.NewLine
        STR_MSG &= "を削除します。" & System.Environment.NewLine
        STR_MSG &= "よろしいですか？" & System.Environment.NewLine
        Dim MBR_RESULT As MessageBoxResult
        MBR_RESULT = MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.YesNo, MessageBoxImage.Question)
        If MBR_RESULT = MessageBoxResult.No Then
            Exit Sub
        End If

        Dim INT_MOD_FROM As Integer
        INT_MOD_FROM = INT_OFFSET_MARKER
        Dim INT_MOD_TO As Integer

        Dim BYT_WRITE() As Byte
        ReDim BYT_WRITE(BYT_UISAVE.Length - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            BYT_WRITE(i) = BYT_UISAVE(i)
        Next

        '有効／無効
        INT_MOD_FROM = INT_OFFSET_MARKER + 0
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_STICKER_ENABLED_BYTE_LENGTH)
        INT_MOD_TO = INT_MOD_FROM + (CST_STICKER_ENABLED_BYTE_LENGTH - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                BYT_WRITE(i) = &H42
            End If
        Next

        If Not FUNC_BACKUP_UISAVE_DAT() Then
            Call MessageBox.Show(STR_FUNC_BACKUP_UISAVE_DAT_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        If Not FUNC_FILE_DELETE(STR_FILE_PATH_UISAVE) Then
            Call MessageBox.Show(STR_FILE_TOOL_LAST_ERR_STRING, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        If Not FUNC_WRITE_FILE(STR_FILE_PATH_UISAVE, BYT_WRITE) Then
            Call MessageBox.Show(STR_FUNC_WRITE_FILE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Call FUNC_LOAD_UISAVE(STR_FILE_PATH_UISAVE)
        Call SUB_EDIT()

        STR_MSG = ""
        STR_MSG &= "ステッカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "を削除しました。" & System.Environment.NewLine
        Call MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub

    Private Sub SUB_DOWNLOAD()

        Dim STR_PATH_DAT As String
        STR_PATH_DAT = ""
        If Not FUNC_SHOW_WINDOW_DOWNLOAD(STR_PATH_DAT) Then
            Exit Sub
        End If

        Dim INT_INDEX_MARKER As Integer
        INT_INDEX_MARKER = FUNC_GET_INDEX_MARKER()
        Dim STR_MSG As String
        STR_MSG = ""
        STR_MSG &= "ステッカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "を上書きします。" & System.Environment.NewLine
        STR_MSG &= "よろしいですか？" & System.Environment.NewLine
        Dim MBR_RESULT As MessageBoxResult
        MBR_RESULT = MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.YesNo, MessageBoxImage.Question)
        If MBR_RESULT = MessageBoxResult.No Then
            Exit Sub
        End If

        Dim BYT_RESTORE() As Byte
        BYT_RESTORE = Nothing
        If Not FUNC_READ_FILE(STR_PATH_DAT, BYT_RESTORE) Then
            Call MessageBox.Show(STR_FUNC_READ_FILE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        If BYT_RESTORE.Length <> CST_LENGTH_FILE_SBK Then
            Call MessageBox.Show("バックアップファイルの内容が正しくありません。", Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Dim INT_MOD_FROM As Integer
        INT_MOD_FROM = INT_OFFSET_MARKER
        Dim INT_MOD_TO As Integer

        Dim BYT_WRITE() As Byte
        ReDim BYT_WRITE(BYT_UISAVE.Length - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            BYT_WRITE(i) = BYT_UISAVE(i)
        Next

        Dim INT_WRITE_INDEX As Integer
        INT_WRITE_INDEX = 0

        '有効／無効
        INT_MOD_FROM = INT_OFFSET_MARKER + 0
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_STICKER_ENABLED_BYTE_LENGTH)
        INT_MOD_TO = INT_MOD_FROM + (CST_STICKER_ENABLED_BYTE_LENGTH - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            End If
        Next

        'タイトル
        INT_MOD_FROM = INT_OFFSET_MARKER + (CST_STICKER_ENABLED_BYTE_LENGTH * CST_COUNT_STICKER)
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_TITLE_BYTE_LENGTH)
        INT_MOD_TO = INT_MOD_FROM + (CST_TITLE_BYTE_LENGTH - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            End If
        Next

        '内容
        INT_MOD_FROM = INT_OFFSET_MARKER + (CST_STICKER_ENABLED_BYTE_LENGTH * CST_COUNT_STICKER) + (CST_TITLE_BYTE_LENGTH * CST_COUNT_STICKER) + &HB
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_STICKER_INFO_BYTE_LENGTH)
        INT_MOD_TO = INT_MOD_FROM + (CST_STICKER_INFO_BYTE_LENGTH - 1)
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            End If
        Next

        If Not FUNC_BACKUP_UISAVE_DAT() Then
            Call MessageBox.Show(STR_FUNC_BACKUP_UISAVE_DAT_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        If Not FUNC_FILE_DELETE(STR_FILE_PATH_UISAVE) Then
            Call MessageBox.Show(STR_FILE_TOOL_LAST_ERR_STRING, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        If Not FUNC_WRITE_FILE(STR_FILE_PATH_UISAVE, BYT_WRITE) Then
            Call MessageBox.Show(STR_FUNC_WRITE_FILE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Call FUNC_LOAD_UISAVE(STR_FILE_PATH_UISAVE)
        Call SUB_EDIT()

        STR_MSG = ""
        STR_MSG &= "ステッカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "を復元しました。" & System.Environment.NewLine
        Call MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub
#End Region

#Region "チェック処理"

    Dim STR_FUNC_CHECK_FILE_ERROR As String
    Private Function FUNC_CHECK_FILE() As Boolean
        STR_FUNC_CHECK_FILE_ERROR = ""

        Dim INT_BYTE_COUNT As Integer
        INT_BYTE_COUNT = BYT_UISAVE.Length
        'Const CST_BYTE_COUNT_UISAVE As Integer = 29728
        Const CST_BYTE_COUNT_UISAVE As Integer = 64544
        If INT_BYTE_COUNT <> CST_BYTE_COUNT_UISAVE Then
            STR_FUNC_CHECK_FILE_ERROR = ""
            STR_FUNC_CHECK_FILE_ERROR &= "ファイルサイズエラーです。" & System.Environment.NewLine
            STR_FUNC_CHECK_FILE_ERROR &= "想定サイズ：" & CST_BYTE_COUNT_UISAVE & System.Environment.NewLine
            STR_FUNC_CHECK_FILE_ERROR &= "読込サイズ：" & INT_BYTE_COUNT & System.Environment.NewLine
            Return False
        End If

        Return True
    End Function

    Dim STR_FUNC_CHECK_BACKUP_ERROR As String
    Private Function FUNC_CHECK_BACKUP() As Boolean
        STR_FUNC_CHECK_BACKUP_ERROR = ""

        Dim INT_INDEX_MARKER As Integer
        INT_INDEX_MARKER = FUNC_GET_INDEX_MARKER()
        If INT_INDEX_MARKER <= 0 Then
            STR_FUNC_CHECK_BACKUP_ERROR = ""
            STR_FUNC_CHECK_BACKUP_ERROR &= "マーカーを選択してください。" & System.Environment.NewLine
            Return False
        End If

        Return True
    End Function

    Dim STR_FUNC_CHECK_RESTORE_ERROR As String
    Private Function FUNC_CHECK_RESTORE() As Boolean
        STR_FUNC_CHECK_RESTORE_ERROR = ""

        Dim INT_INDEX_MARKER As Integer
        INT_INDEX_MARKER = FUNC_GET_INDEX_MARKER()
        If INT_INDEX_MARKER <= 0 Then
            STR_FUNC_CHECK_RESTORE_ERROR = ""
            STR_FUNC_CHECK_RESTORE_ERROR &= "マーカーを選択してください。" & System.Environment.NewLine
            Return False
        End If

        Return True
    End Function


    Dim STR_FUNC_CHECK_DELETE_ERROR As String
    Private Function FUNC_CHECK_DELETE() As Boolean
        STR_FUNC_CHECK_DELETE_ERROR = ""

        Dim INT_INDEX_MARKER As Integer
        INT_INDEX_MARKER = FUNC_GET_INDEX_MARKER()
        If INT_INDEX_MARKER <= 0 Then
            STR_FUNC_CHECK_DELETE_ERROR = ""
            STR_FUNC_CHECK_DELETE_ERROR &= "マーカーを選択してください。" & System.Environment.NewLine
            Return False
        End If

        Return True
    End Function
#End Region

#Region "内部処理"

    Private STR_FUNC_BACKUP_UISAVE_DAT_ERROR As String
    Private Function FUNC_BACKUP_UISAVE_DAT() As Boolean
        STR_FUNC_BACKUP_UISAVE_DAT_ERROR = ""

        Dim STR_EXECUTE_DIR As String
        STR_EXECUTE_DIR = FUNC_PATH_TO_DIR_PATH(FUNC_GET_EXE_PATH())
        Dim STR_BACKUP_DIR As String
        STR_BACKUP_DIR = STR_EXECUTE_DIR & "\" & "BACKUP_UISAVE" & "\"
        If Not FUNC_DIR_MAKE(STR_BACKUP_DIR) Then
            STR_FUNC_BACKUP_UISAVE_DAT_ERROR = STR_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If
        Dim STR_NOW_DATETIME As String
        STR_NOW_DATETIME = FUNC_GET_DATETIME_STR(System.DateTime.Now)
        STR_BACKUP_DIR &= STR_NOW_DATETIME & "\"
        If Not FUNC_DIR_MAKE(STR_BACKUP_DIR) Then
            STR_FUNC_BACKUP_UISAVE_DAT_ERROR = STR_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If
        Dim STR_FILE_PATH_UISAVE_BACKUP As String
        STR_FILE_PATH_UISAVE_BACKUP = STR_BACKUP_DIR & "UISAVE.DAT"
        If Not FUNC_FILE_COPY(STR_FILE_PATH_UISAVE, STR_FILE_PATH_UISAVE_BACKUP) Then
            STR_FUNC_BACKUP_UISAVE_DAT_ERROR = STR_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If

        Return True
    End Function

    Private Function FUNC_GET_INIT_PATH() As String
        Dim STR_RET As String
        STR_RET = ""

        Dim STR_TEMP As String
        STR_TEMP = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        STR_RET = STR_TEMP

        STR_TEMP = STR_RET & "My Games" & "\"
        If Not FUNC_DIR_CHECK(STR_TEMP) Then
            Return STR_RET
        End If

        STR_RET = STR_TEMP
        STR_TEMP = STR_RET & "FINAL FANTASY XIV - A Realm Reborn" & "\"
        If Not FUNC_DIR_CHECK(STR_TEMP) Then
            Return STR_RET
        End If

        STR_RET = STR_TEMP
        STR_TEMP = FUNC_DIRECTORY_NAME_GETS(STR_RET, "FFXIV_CHR")
        If STR_TEMP = "" Then
            Return STR_RET
        End If

        STR_RET = STR_TEMP
        Return STR_RET
    End Function

    Private STR_FUNC_LOAD_UISAVE_ERROR As String
    Private Function FUNC_LOAD_UISAVE(ByVal STR_FILE_PATH As String) As Boolean

        If Not FUNC_READ_FILE(STR_FILE_PATH, BYT_UISAVE) Then
            STR_FUNC_LOAD_UISAVE_ERROR = STR_FUNC_READ_FILE_ERROR
            Return False
        End If

        If Not FUNC_CHECK_FILE() Then
            STR_FUNC_LOAD_UISAVE_ERROR = STR_FUNC_CHECK_FILE_ERROR
            Return False
        End If

        INT_OFFSET_MARKER = FUNC_GET_OFFSET()
        Dim STR_TEMP As String
        STR_TEMP = Convert.ToString(INT_OFFSET_MARKER, 16)
        LBL_OFFSET.Content = STR_TEMP

        If Not FUNC_GET_STICKER_INFO() Then
            STR_FUNC_LOAD_UISAVE_ERROR = STR_FUNC_GET_MARKER_INFO_ERROR
            Return False
        End If

        Return True
    End Function

    Private Function FUNC_GET_OFFSET() As Integer
        Dim INT_RET As Integer

        Dim BYT_CHECK() As Byte
        ReDim BYT_CHECK(3)
        Dim INT_CHECK_INDEX As Integer
        INT_CHECK_INDEX = 0
        BYT_CHECK(INT_CHECK_INDEX) = &H24
        INT_CHECK_INDEX += 1
        BYT_CHECK(INT_CHECK_INDEX) = &H31
        INT_CHECK_INDEX += 1
        BYT_CHECK(INT_CHECK_INDEX) = &H55
        INT_CHECK_INDEX += 1
        BYT_CHECK(INT_CHECK_INDEX) = &H31

        Dim INT_LOOP_MAX As Integer
        INT_LOOP_MAX = (BYT_UISAVE.Length - 1)
        INT_LOOP_MAX -= BYT_CHECK.Length
        For i = 0 To INT_LOOP_MAX
            Dim BLN_CHECK As Boolean
            BLN_CHECK = True
            For j = 0 To (BYT_CHECK.Length - 1)
                If BYT_CHECK(j) = BYT_UISAVE(i + j) Then
                    Continue For
                End If
                BLN_CHECK = False
            Next
            If BLN_CHECK Then
                If i < &H6C96 Then
                    BLN_CHECK = False
                End If
            End If
            If BLN_CHECK Then
                INT_RET = i + &H10
                Return INT_RET
            End If
        Next
        INT_RET = &H7051

        Return INT_RET
    End Function

    Private Sub SUB_CLEAR_MARKER(ByVal INT_INDEX As Integer)
        LBL_NAME_CONTENT(INT_INDEX).Content = ""
        'LBL_NAME_CONTENT(INT_INDEX).ToolTip = ""
    End Sub

    Dim STR_FUNC_READ_FILE_ERROR As String
    Private Function FUNC_READ_FILE(ByVal STR_FILE_NAME As String, ByRef BYT_READE() As Byte) As Boolean
        STR_FUNC_READ_FILE_ERROR = ""

        Dim SFS_DATA As System.IO.FileStream
        Try
            SFS_DATA = New System.IO.FileStream(STR_FILE_NAME, IO.FileMode.Open, System.IO.FileAccess.Read)
        Catch ex As Exception
            STR_FUNC_READ_FILE_ERROR = ex.Message
            SFS_DATA = Nothing
            Return False
        End Try

        BYT_READE = Nothing
        ReDim BYT_READE(SFS_DATA.Length - 1)

        Try
            SFS_DATA.Read(BYT_READE, 0, BYT_READE.Length)
        Catch ex As Exception
            STR_FUNC_READ_FILE_ERROR = ex.Message
            SFS_DATA = Nothing
            Return False
        End Try

        Try
            SFS_DATA.Close()
        Catch ex As Exception
            STR_FUNC_READ_FILE_ERROR = ex.Message
            SFS_DATA = Nothing
            Return False
        End Try

        Return True
    End Function

    Dim STR_FUNC_GET_MARKER_INFO_ERROR As String
    Private Function FUNC_GET_STICKER_INFO() As Boolean
        STR_FUNC_GET_MARKER_INFO_ERROR = ""

        Dim INT_INDEX_CURRENT As Integer
        INT_INDEX_CURRENT = INT_OFFSET_MARKER

        '有効／無効
        For i = 1 To CST_COUNT_STICKER
            With SRT_MARKER_LIST(i)
                ReDim .BYT_STICKER_ENABLED(CST_STICKER_ENABLED_BYTE_LENGTH)
                For j = 1 To CST_STICKER_ENABLED_BYTE_LENGTH
                    .BYT_STICKER_ENABLED(j) = BYT_UISAVE(INT_INDEX_CURRENT + j)
                Next
                INT_INDEX_CURRENT += CST_STICKER_ENABLED_BYTE_LENGTH
            End With
        Next

        'タイトル
        For i = 1 To CST_COUNT_STICKER
            With SRT_MARKER_LIST(i)
                ReDim .BYT_TITLE(CST_TITLE_BYTE_LENGTH)
                For j = 1 To CST_TITLE_BYTE_LENGTH
                    .BYT_TITLE(j) = BYT_UISAVE(INT_INDEX_CURRENT + j)
                Next
            End With
            INT_INDEX_CURRENT += CST_TITLE_BYTE_LENGTH
        Next

        INT_INDEX_CURRENT += &HB
        '内容
        For i = 1 To CST_COUNT_STICKER
            With SRT_MARKER_LIST(i)
                ReDim .BYT_STICKER_INFO(CST_STICKER_INFO_BYTE_LENGTH)
                For j = 1 To CST_STICKER_INFO_BYTE_LENGTH
                    .BYT_STICKER_INFO(j) = BYT_UISAVE(INT_INDEX_CURRENT + j)
                Next
            End With
            INT_INDEX_CURRENT += CST_STICKER_INFO_BYTE_LENGTH
        Next

        For i = 1 To CST_COUNT_STICKER
            Call SUB_INIT_VALUE_STICKER(SRT_MARKER_LIST(i))
        Next

        Return True
    End Function

    Private Sub SUB_INIT_VALUE_STICKER(ByRef SRT_DATA As SRT_MARKER_INFO)
        With SRT_DATA
            ReDim .BYT_STICKER_ENABLED_CNV(.BYT_STICKER_ENABLED.Length - 1)
            For i = 1 To (.BYT_STICKER_ENABLED.Length - 1)
                .BYT_STICKER_ENABLED_CNV(i) = FUNC_CONVERT_HEX_UISAVE(.BYT_STICKER_ENABLED(i))
            Next
            .STICKER_ENABLED = .BYT_STICKER_ENABLED_CNV(1)

            ReDim .BYT_TITLE_CNV(.BYT_TITLE.Length - 1)
            For i = 1 To (.BYT_TITLE.Length - 1)
                .BYT_TITLE_CNV(i) = FUNC_CONVERT_HEX_UISAVE(.BYT_TITLE(i))
            Next

            Dim BYT_TEMP() As Byte
            BYT_TEMP = Nothing
            For i = 1 To (.BYT_TITLE_CNV.Length - 1)
                If .BYT_TITLE_CNV(i) = &H0 Then
                    Exit For
                End If
                Dim INT_INDEX As Integer
                If BYT_TEMP Is Nothing Then
                    INT_INDEX = 0
                Else
                    INT_INDEX = BYT_TEMP.Length
                End If
                ReDim Preserve BYT_TEMP(INT_INDEX)
                BYT_TEMP(INT_INDEX) = .BYT_TITLE_CNV(i)
            Next
            If BYT_TEMP Is Nothing Then
                .TITLE = ""
            Else
                .TITLE = System.Text.Encoding.UTF8.GetString(BYT_TEMP)
            End If

            Dim INT_INDEX_BACKUP As Integer
            INT_INDEX_BACKUP = (.BYT_STICKER_ENABLED.Length - 1) + (.BYT_TITLE.Length - 1) + (.BYT_STICKER_INFO.Length - 1)
            ReDim .BYT_STICKER_BACKUP(INT_INDEX_BACKUP)

            Dim INT_CURRENT As Integer
            INT_CURRENT = 0
            For i = 1 To (.BYT_STICKER_ENABLED.Length - 1)
                INT_CURRENT += 1
                .BYT_STICKER_BACKUP(INT_CURRENT) = .BYT_STICKER_ENABLED(i)
            Next
            For i = 1 To (.BYT_TITLE.Length - 1)
                INT_CURRENT += 1
                .BYT_STICKER_BACKUP(INT_CURRENT) = .BYT_TITLE(i)
            Next
            For i = 1 To (.BYT_STICKER_INFO.Length - 1)
                INT_CURRENT += 1
                .BYT_STICKER_BACKUP(INT_CURRENT) = .BYT_STICKER_INFO(i)
            Next
        End With
    End Sub

    Private Sub SUB_EDIT()

        For i = 1 To CST_COUNT_STICKER
            Call SUB_CLEAR_MARKER(i)

            LBL_NAME_CONTENT(i).Content = SRT_MARKER_LIST(i).NAME_STICKER
        Next

        GRP_SAVE_LIST.IsEnabled = True
        GRP_TASK.IsEnabled = True

        Call SUB_CHECK_MARKER_DEFAULT()
    End Sub

    Private Function FUNC_GET_INDEX_MARKER() As Integer
        Dim INT_RET As Integer
        INT_RET = 0

        If RDO_MARKER_01.IsChecked Then
            INT_RET = 1
            Return INT_RET
        End If

        If RDO_MARKER_02.IsChecked Then
            INT_RET = 2
            Return INT_RET
        End If

        If RDO_MARKER_03.IsChecked Then
            INT_RET = 3
            Return INT_RET
        End If

        If RDO_MARKER_04.IsChecked Then
            INT_RET = 4
            Return INT_RET
        End If

        If RDO_MARKER_05.IsChecked Then
            INT_RET = 5
            Return INT_RET
        End If

        Return INT_RET
    End Function

    Private Sub SUB_CHECK_MARKER_DEFAULT()
        If RDO_MARKER_01.IsChecked Then
            Exit Sub
        End If
        If RDO_MARKER_02.IsChecked Then
            Exit Sub
        End If
        If RDO_MARKER_03.IsChecked Then
            Exit Sub
        End If
        If RDO_MARKER_04.IsChecked Then
            Exit Sub
        End If
        If RDO_MARKER_05.IsChecked Then
            Exit Sub
        End If
        RDO_MARKER_01.IsChecked = True
        RDO_MARKER_02.IsChecked = False
        RDO_MARKER_03.IsChecked = False
        RDO_MARKER_04.IsChecked = False
        RDO_MARKER_05.IsChecked = False
    End Sub

    Dim STR_FUNC_WRITE_FILE_ERROR As String
    Private Function FUNC_WRITE_FILE(ByVal STR_PATH_FILE As String, ByVal BYT_WRITE() As Byte) As Boolean
        STR_FUNC_WRITE_FILE_ERROR = ""

        Dim SFS_DATA As System.IO.FileStream

        Try
            SFS_DATA = New System.IO.FileStream(STR_PATH_FILE, IO.FileMode.Create)
        Catch ex As Exception
            STR_FUNC_WRITE_FILE_ERROR = ex.Message
            SFS_DATA = Nothing
            Return False
        End Try

        Dim SBW_DATA As System.IO.BinaryWriter ' バイナリデータ用
        Try
            SBW_DATA = New System.IO.BinaryWriter(SFS_DATA) 'ファイルオープン
        Catch ex As Exception
            STR_FUNC_WRITE_FILE_ERROR = ex.Message
            SFS_DATA.Dispose()
            SFS_DATA = Nothing
            SBW_DATA = Nothing
            Return False
        End Try

        Call SBW_DATA.Write(BYT_WRITE) 'ファイル書き込み
        Call SBW_DATA.Close() 'ファイルクローズ

        Return True
    End Function

    Private Function FUNC_GET_BACKUP_DIALOG_FILTER() As String
        Dim STR_RET As String

        STR_RET = ""
        STR_RET &= "ステッカーバックアップファイル|*.SBK"

        Return STR_RET
    End Function

    Private Function FUNC_GET_DATETIME_STR(ByVal DAT_BASE As DateTime) As String
        Dim STR_YEAR As String
        STR_YEAR = MOD_CODE_TOOL.Format(DAT_BASE.Year, "0000")

        Dim STR_MONTH As String
        STR_MONTH = MOD_CODE_TOOL.Format(DAT_BASE.Month, "00")

        Dim STR_DAY As String
        STR_DAY = MOD_CODE_TOOL.Format(DAT_BASE.Day, "00")

        Dim STR_HOUR As String
        STR_HOUR = MOD_CODE_TOOL.Format(DAT_BASE.Hour, "00")

        Dim STR_MINUTE As String
        STR_MINUTE = MOD_CODE_TOOL.Format(DAT_BASE.Minute, "00")

        Dim STR_SECOND As String
        STR_SECOND = MOD_CODE_TOOL.Format(DAT_BASE.Second, "00")

        Dim STR_RET As String
        STR_RET = STR_YEAR & STR_MONTH & STR_DAY & "_" & STR_HOUR & STR_MINUTE & STR_SECOND
        Return STR_RET
    End Function

    Private Function FUNC_CONVERT_STR_TO_FILE_NAME(ByVal STR_BASE As String) As String
        Dim STR_TEMP As String
        STR_TEMP = STR_BASE
        STR_TEMP = STR_TEMP.Replace("/", "")
        STR_TEMP = STR_TEMP.Replace(":", "")
        STR_TEMP = STR_TEMP.Replace("\", "")
        STR_TEMP = STR_TEMP.Replace("?", "")
        STR_TEMP = STR_TEMP.Replace("*", "")
        STR_TEMP = STR_TEMP.Replace("<", "")
        STR_TEMP = STR_TEMP.Replace(">", "")
        STR_TEMP = STR_TEMP.Replace(" ", "")

        Dim STR_RET As String
        STR_RET = STR_TEMP
        Return STR_RET
    End Function
#End Region

#Region "以後共通へ"

#End Region

#Region "NEW"
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Call SUB_CTRL_NEW_INIT()
    End Sub

#End Region

#Region "イベント-ボタンクリック"
    Private Sub BTN_OPEN_FILE_Click(sender As Object, e As RoutedEventArgs) Handles BTN_OPEN_FILE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_OPEN_FILE)
    End Sub

    Private Sub BTN_BACKUP_Click(sender As Object, e As RoutedEventArgs) Handles BTN_BACKUP.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_BACKUP)
    End Sub

    Private Sub BTN_RESTORE_Click(sender As Object, e As RoutedEventArgs) Handles BTN_RESTORE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_RESTORE)
    End Sub

    Private Sub BTN_DELETE_Click(sender As Object, e As RoutedEventArgs) Handles BTN_DELETE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_DELETE)
    End Sub

    Private Sub BTN_DOWNLOAD_Click(sender As Object, e As RoutedEventArgs) Handles BTN_DOWNLOAD.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_DOWNLOAD)
    End Sub
#End Region

    Private Sub WPF_MAIN_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub WPF_MAIN_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub
End Class
