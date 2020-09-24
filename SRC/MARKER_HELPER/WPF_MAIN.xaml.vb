Imports System.ComponentModel

Public Class WPF_MAIN

#Region "画面用・定数"
    Const CST_COUNT_MARKER As Integer = 5
    Const CST_MARKER_BYTE_LENGTH As Integer = &H68
    Const CST_VALUE_UISAVE_NULL As Integer = &H31 '49
    Const CST_VALUE_ENABLED As Integer = &H6F
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

        Public Function ENABLED_MARKER_A() As Boolean
            If POINT_MARKER_A(1) = CST_VALUE_UISAVE_NULL Then
                Return False
            End If

            Return True
        End Function

        Public Function ENABLED_MARKER_B() As Boolean
            If POINT_MARKER_B(1) = CST_VALUE_UISAVE_NULL Then
                Return False
            End If

            Return True
        End Function

        Public Function ENABLED_MARKER_C() As Boolean
            If POINT_MARKER_C(1) = CST_VALUE_UISAVE_NULL Then
                Return False
            End If

            Return True
        End Function

        Public Function ENABLED_MARKER_D() As Boolean
            If POINT_MARKER_D(1) = CST_VALUE_UISAVE_NULL Then
                Return False
            End If

            Return True
        End Function

        Public Function ENABLED_MARKER_1() As Boolean
            If POINT_MARKER_1(1) = CST_VALUE_UISAVE_NULL Then
                Return False
            End If

            Return True
        End Function

        Public Function ENABLED_MARKER_2() As Boolean
            If POINT_MARKER_2(1) = CST_VALUE_UISAVE_NULL Then
                Return False
            End If

            Return True
        End Function

        Public Function ENABLED_MARKER_3() As Boolean
            If POINT_MARKER_3(1) = CST_VALUE_UISAVE_NULL Then
                Return False
            End If

            Return True
        End Function

        Public Function ENABLED_MARKER_4() As Boolean
            If POINT_MARKER_4(1) = CST_VALUE_UISAVE_NULL Then
                Return False
            End If

            Return True
        End Function

        Public Function ENABLED() As Boolean

            If Me.ENABLED_MARKER_A Then
                Return True
            End If
            If Me.ENABLED_MARKER_B Then
                Return True
            End If
            If Me.ENABLED_MARKER_C Then
                Return True
            End If
            If Me.ENABLED_MARKER_D Then
                Return True
            End If
            If Me.ENABLED_MARKER_1 Then
                Return True
            End If
            If Me.ENABLED_MARKER_2 Then
                Return True
            End If
            If Me.ENABLED_MARKER_3 Then
                Return True
            End If
            If Me.ENABLED_MARKER_4 Then
                Return True
            End If

            'If Me.ID_ENABLED = CST_VALUE_ENABLED Then
            '    Return True
            'End If
            Return False
        End Function

        Public Function NAME_CONTENET() As String

            If Not Me.ENABLED Then
                Return "EMPTY"
            End If

            Dim STR_NAME As String
            STR_NAME = FUNC_GET_CONTENT_NAME()

            Dim STR_RET As String

            If STR_NAME = "" Then
                STR_RET = ""
                STR_RET &= "UNKNOWN CONTENT"
                STR_RET &= Me.FUNC_GET_CONTENT_ID_STRING()
                Return STR_RET
            End If

            STR_RET = ""
            STR_RET &= STR_NAME
            STR_RET &= Me.FUNC_GET_CONTENT_ID_STRING()
            Return STR_RET
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
    Private SRT_MARKER_LIST(CST_COUNT_MARKER) As SRT_MARKER_INFO

    Private BRS_DEFAULT_MARKER_A As Brush
    Private BRS_DEFAULT_MARKER_B As Brush
    Private BRS_DEFAULT_MARKER_C As Brush
    Private BRS_DEFAULT_MARKER_D As Brush
    Private BRS_DEFAULT_MARKER_1 As Brush
    Private BRS_DEFAULT_MARKER_2 As Brush
    Private BRS_DEFAULT_MARKER_3 As Brush
    Private BRS_DEFAULT_MARKER_4 As Brush

    Private LBL_NAME_CONTENT(CST_COUNT_MARKER) As Label
    Private LBL_MARKER_A(CST_COUNT_MARKER) As Label
    Private LBL_MARKER_B(CST_COUNT_MARKER) As Label
    Private LBL_MARKER_C(CST_COUNT_MARKER) As Label
    Private LBL_MARKER_D(CST_COUNT_MARKER) As Label
    Private LBL_MARKER_1(CST_COUNT_MARKER) As Label
    Private LBL_MARKER_2(CST_COUNT_MARKER) As Label
    Private LBL_MARKER_3(CST_COUNT_MARKER) As Label
    Private LBL_MARKER_4(CST_COUNT_MARKER) As Label

#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        LBL_NAME_CONTENT(1) = LBL_01_NAME_CONTENT
        LBL_NAME_CONTENT(2) = LBL_02_NAME_CONTENT
        LBL_NAME_CONTENT(3) = LBL_03_NAME_CONTENT
        LBL_NAME_CONTENT(4) = LBL_04_NAME_CONTENT
        LBL_NAME_CONTENT(5) = LBL_05_NAME_CONTENT

        LBL_MARKER_A(1) = LBL_01_MARKER_A
        LBL_MARKER_A(2) = LBL_02_MARKER_A
        LBL_MARKER_A(3) = LBL_03_MARKER_A
        LBL_MARKER_A(4) = LBL_04_MARKER_A
        LBL_MARKER_A(5) = LBL_05_MARKER_A

        LBL_MARKER_B(1) = LBL_01_MARKER_B
        LBL_MARKER_B(2) = LBL_02_MARKER_B
        LBL_MARKER_B(3) = LBL_03_MARKER_B
        LBL_MARKER_B(4) = LBL_04_MARKER_B
        LBL_MARKER_B(5) = LBL_05_MARKER_B

        LBL_MARKER_C(1) = LBL_01_MARKER_C
        LBL_MARKER_C(2) = LBL_02_MARKER_C
        LBL_MARKER_C(3) = LBL_03_MARKER_C
        LBL_MARKER_C(4) = LBL_04_MARKER_C
        LBL_MARKER_C(5) = LBL_05_MARKER_C

        LBL_MARKER_D(1) = LBL_01_MARKER_D
        LBL_MARKER_D(2) = LBL_02_MARKER_D
        LBL_MARKER_D(3) = LBL_03_MARKER_D
        LBL_MARKER_D(4) = LBL_04_MARKER_D
        LBL_MARKER_D(5) = LBL_05_MARKER_D

        LBL_MARKER_1(1) = LBL_01_MARKER_1
        LBL_MARKER_1(2) = LBL_02_MARKER_1
        LBL_MARKER_1(3) = LBL_03_MARKER_1
        LBL_MARKER_1(4) = LBL_04_MARKER_1
        LBL_MARKER_1(5) = LBL_05_MARKER_1

        LBL_MARKER_2(1) = LBL_01_MARKER_2
        LBL_MARKER_2(2) = LBL_02_MARKER_2
        LBL_MARKER_2(3) = LBL_03_MARKER_2
        LBL_MARKER_2(4) = LBL_04_MARKER_2
        LBL_MARKER_2(5) = LBL_05_MARKER_2

        LBL_MARKER_3(1) = LBL_01_MARKER_3
        LBL_MARKER_3(2) = LBL_02_MARKER_3
        LBL_MARKER_3(3) = LBL_03_MARKER_3
        LBL_MARKER_3(4) = LBL_04_MARKER_3
        LBL_MARKER_3(5) = LBL_05_MARKER_3

        LBL_MARKER_4(1) = LBL_01_MARKER_4
        LBL_MARKER_4(2) = LBL_02_MARKER_4
        LBL_MARKER_4(3) = LBL_03_MARKER_4
        LBL_MARKER_4(4) = LBL_04_MARKER_4
        LBL_MARKER_4(5) = LBL_05_MARKER_4
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()
        BRS_DEFAULT_MARKER_A = LBL_01_MARKER_A.Foreground
        BRS_DEFAULT_MARKER_B = LBL_01_MARKER_B.Foreground
        BRS_DEFAULT_MARKER_C = LBL_01_MARKER_C.Foreground
        BRS_DEFAULT_MARKER_D = LBL_01_MARKER_D.Foreground
        BRS_DEFAULT_MARKER_1 = LBL_01_MARKER_1.Foreground
        BRS_DEFAULT_MARKER_2 = LBL_01_MARKER_2.Foreground
        BRS_DEFAULT_MARKER_3 = LBL_01_MARKER_3.Foreground
        BRS_DEFAULT_MARKER_4 = LBL_01_MARKER_4.Foreground

        STR_INIT_PATH_BACKUP = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        STR_INIT_PATH_RESTORE = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        TXT_PATH_UISAVE.Text = ""
        LBL_OFFSET.Content = ""

        For i = 1 To CST_COUNT_MARKER
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
        'If Not (PRC_TARGET Is Nothing) Then
        '    Dim STR_MSG As String
        '    STR_MSG = ""
        '    STR_MSG &= "FFXIVが起動している状態では実行できません。"
        '    Call MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
        '    Exit Sub
        'End If

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

        Dim BLN_SAVE As Boolean
        BLN_SAVE = SFD_BACKUP.ShowDialog()
        If Not BLN_SAVE Then
            Exit Sub
        End If
        STR_INIT_PATH_BACKUP = FUNC_PATH_TO_DIR_PATH(SFD_BACKUP.FileName)

        Dim STR_FILE_PATH As String
        STR_FILE_PATH = SFD_BACKUP.FileName

        Dim INT_INDEX_MARKER As Integer
        INT_INDEX_MARKER = FUNC_GET_INDEX_MARKER()

        If Not FUNC_WRITE_FILE(STR_FILE_PATH, SRT_MARKER_LIST(INT_INDEX_MARKER).BYT_MARKER) Then
            Call MessageBox.Show(STR_FUNC_WRITE_FILE_ERROR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Dim STR_MSG As String
        STR_MSG = ""
        STR_MSG &= "マーカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "コンテンツ：" & SRT_MARKER_LIST(INT_INDEX_MARKER).NAME_CONTENET & System.Environment.NewLine
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
        STR_MSG &= "マーカー：" & INT_INDEX_MARKER & System.Environment.NewLine
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

        Dim INT_MOD_FROM As Integer
        INT_MOD_FROM = INT_OFFSET_MARKER
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_MARKER_BYTE_LENGTH)

        Dim INT_MOD_TO As Integer
        INT_MOD_TO = INT_MOD_FROM + (CST_MARKER_BYTE_LENGTH - 1)

        Dim BYT_WRITE() As Byte
        ReDim BYT_WRITE(BYT_UISAVE.Length - 1)
        Dim INT_WRITE_INDEX As Integer
        INT_WRITE_INDEX = 0
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            Else
                BYT_WRITE(i) = BYT_UISAVE(i)
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
        STR_MSG &= "マーカー：" & INT_INDEX_MARKER & System.Environment.NewLine
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
        STR_MSG &= "マーカー：" & INT_INDEX_MARKER & System.Environment.NewLine
        STR_MSG &= "コンテンツ：" & SRT_MARKER_LIST(INT_INDEX_MARKER).NAME_CONTENET & System.Environment.NewLine
        STR_MSG &= "を削除します。" & System.Environment.NewLine
        STR_MSG &= "よろしいですか？" & System.Environment.NewLine
        Dim MBR_RESULT As MessageBoxResult
        MBR_RESULT = MessageBox.Show(STR_MSG, Me.Title, MessageBoxButton.YesNo, MessageBoxImage.Question)
        If MBR_RESULT = MessageBoxResult.No Then
            Exit Sub
        End If

        Dim BYT_RESTORE() As Byte
        BYT_RESTORE = Nothing
        ReDim BYT_RESTORE(CST_MARKER_BYTE_LENGTH)
        For i = 1 To (BYT_RESTORE.Length - 1)
            BYT_RESTORE(i) = CST_VALUE_UISAVE_NULL
        Next

        Dim INT_MOD_FROM As Integer
        INT_MOD_FROM = INT_OFFSET_MARKER
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_MARKER_BYTE_LENGTH)

        Dim INT_MOD_TO As Integer
        INT_MOD_TO = INT_MOD_FROM + (CST_MARKER_BYTE_LENGTH - 1)

        Dim BYT_WRITE() As Byte
        ReDim BYT_WRITE(BYT_UISAVE.Length - 1)
        Dim INT_WRITE_INDEX As Integer
        INT_WRITE_INDEX = 0
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            Else
                BYT_WRITE(i) = BYT_UISAVE(i)
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
        STR_MSG &= "マーカー：" & INT_INDEX_MARKER & System.Environment.NewLine
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
        STR_MSG &= "マーカー：" & INT_INDEX_MARKER & System.Environment.NewLine
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

        Dim INT_MOD_FROM As Integer
        INT_MOD_FROM = INT_OFFSET_MARKER
        INT_MOD_FROM += 1 + ((INT_INDEX_MARKER - 1) * CST_MARKER_BYTE_LENGTH)

        Dim INT_MOD_TO As Integer
        INT_MOD_TO = INT_MOD_FROM + (CST_MARKER_BYTE_LENGTH - 1)

        Dim BYT_WRITE() As Byte
        ReDim BYT_WRITE(BYT_UISAVE.Length - 1)
        Dim INT_WRITE_INDEX As Integer
        INT_WRITE_INDEX = 0
        For i = 0 To (BYT_UISAVE.Length - 1)
            If INT_MOD_FROM <= i And i <= INT_MOD_TO Then
                INT_WRITE_INDEX += 1
                BYT_WRITE(i) = BYT_RESTORE(INT_WRITE_INDEX)
            Else
                BYT_WRITE(i) = BYT_UISAVE(i)
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
        STR_MSG &= "マーカー：" & INT_INDEX_MARKER & System.Environment.NewLine
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

        If Not FUNC_GET_MARKER_INFO() Then
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
        BYT_CHECK(INT_CHECK_INDEX) = &H31
        INT_CHECK_INDEX += 1
        BYT_CHECK(INT_CHECK_INDEX) = &H55
        INT_CHECK_INDEX += 1
        BYT_CHECK(INT_CHECK_INDEX) = &H31
        INT_CHECK_INDEX += 1
        BYT_CHECK(INT_CHECK_INDEX) = &H3E

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
                INT_RET = i + &HE
                Return INT_RET
            End If
        Next
        INT_RET = &H6C96

        Return INT_RET
    End Function

    Private Sub SUB_CLEAR_MARKER(ByVal INT_INDEX As Integer)
        LBL_NAME_CONTENT(INT_INDEX).Content = ""
        LBL_NAME_CONTENT(INT_INDEX).ToolTip = ""
        LBL_MARKER_A(INT_INDEX).Foreground = New SolidColorBrush(Colors.Gray)
        LBL_MARKER_B(INT_INDEX).Foreground = New SolidColorBrush(Colors.Gray)
        LBL_MARKER_C(INT_INDEX).Foreground = New SolidColorBrush(Colors.Gray)
        LBL_MARKER_D(INT_INDEX).Foreground = New SolidColorBrush(Colors.Gray)
        LBL_MARKER_1(INT_INDEX).Foreground = New SolidColorBrush(Colors.Gray)
        LBL_MARKER_2(INT_INDEX).Foreground = New SolidColorBrush(Colors.Gray)
        LBL_MARKER_3(INT_INDEX).Foreground = New SolidColorBrush(Colors.Gray)
        LBL_MARKER_4(INT_INDEX).Foreground = New SolidColorBrush(Colors.Gray)
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
    Private Function FUNC_GET_MARKER_INFO() As Boolean
        STR_FUNC_GET_MARKER_INFO_ERROR = ""

        Dim INT_INDEX_CURRENT As Integer
        INT_INDEX_CURRENT = 0
        INT_INDEX_CURRENT = INT_OFFSET_MARKER
        For i = 1 To CST_COUNT_MARKER
            With SRT_MARKER_LIST(i)
                ReDim .BYT_MARKER(CST_MARKER_BYTE_LENGTH)
                For j = 1 To CST_MARKER_BYTE_LENGTH
                    .BYT_MARKER(j) = BYT_UISAVE(INT_INDEX_CURRENT + j)
                Next
            End With
            INT_INDEX_CURRENT += CST_MARKER_BYTE_LENGTH
        Next

        For i = 1 To CST_COUNT_MARKER
            Call SUB_INIT_VALUE_MARKER(SRT_MARKER_LIST(i))
        Next

        Return True
    End Function

    Private Sub SUB_INIT_VALUE_MARKER(ByRef SRT_DATA As SRT_MARKER_INFO)
        With SRT_DATA
            .DATE_TIME_EDIT_01 = FUNC_CONVERT_HEX_UISAVE(.BYT_MARKER(ENM_MARKER_INFO.DATE_TIME_01))
            .DATE_TIME_EDIT_02 = FUNC_CONVERT_HEX_UISAVE(.BYT_MARKER(ENM_MARKER_INFO.DATE_TIME_02))
            .DATE_TIME_EDIT_03 = FUNC_CONVERT_HEX_UISAVE(.BYT_MARKER(ENM_MARKER_INFO.DATE_TIME_03))
            .DATE_TIME_EDIT_04 = FUNC_CONVERT_HEX_UISAVE(.BYT_MARKER(ENM_MARKER_INFO.DATE_TIME_04))

            .DATE_TIME_EDIT_INT = 0
            .DATE_TIME_EDIT_INT += (.DATE_TIME_EDIT_01 << (8 * 0))
            .DATE_TIME_EDIT_INT += (.DATE_TIME_EDIT_02 << (8 * 1))
            .DATE_TIME_EDIT_INT += (.DATE_TIME_EDIT_03 << (8 * 2))
            .DATE_TIME_EDIT_INT += (.DATE_TIME_EDIT_04 << (8 * 3))

            Const CST_DATE_TIME_BASE As DateTime = #1/1/1970 09:00:00 AM#
            Dim INT_ADD_MINUIES As Integer
            INT_ADD_MINUIES = (.DATE_TIME_EDIT_INT \ 64)
            '.DATE_TIME_EDIT = CST_DATE_TIME_BASE.AddMinutes(INT_ADD_MINUIES)
            .DATE_TIME_EDIT = CST_DATE_TIME_BASE.AddSeconds(.DATE_TIME_EDIT_INT)

            .ID_CONTENT_01 = .BYT_MARKER(ENM_MARKER_INFO.ID_CONTENT_01)
            .ID_CONTENT_02 = .BYT_MARKER(ENM_MARKER_INFO.ID_CONTENT_02)

            ReDim .POINT_MARKER_A(4)
            .POINT_MARKER_A(1) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_A_POINT_01)
            .POINT_MARKER_A(2) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_A_POINT_02)
            .POINT_MARKER_A(3) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_A_POINT_03)
            .POINT_MARKER_A(4) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_A_POINT_04)

            ReDim .POINT_MARKER_B(4)
            .POINT_MARKER_B(1) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_B_POINT_01)
            .POINT_MARKER_B(2) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_B_POINT_02)
            .POINT_MARKER_B(3) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_B_POINT_03)
            .POINT_MARKER_B(4) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_B_POINT_04)

            ReDim .POINT_MARKER_C(4)
            .POINT_MARKER_C(1) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_C_POINT_01)
            .POINT_MARKER_C(2) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_C_POINT_02)
            .POINT_MARKER_C(3) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_C_POINT_03)
            .POINT_MARKER_C(4) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_C_POINT_04)

            ReDim .POINT_MARKER_D(4)
            .POINT_MARKER_D(1) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_D_POINT_01)
            .POINT_MARKER_D(2) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_D_POINT_02)
            .POINT_MARKER_D(3) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_D_POINT_03)
            .POINT_MARKER_D(4) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_D_POINT_04)

            ReDim .POINT_MARKER_1(4)
            .POINT_MARKER_1(1) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_1_POINT_01)
            .POINT_MARKER_1(2) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_1_POINT_02)
            .POINT_MARKER_1(3) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_1_POINT_03)
            .POINT_MARKER_1(4) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_1_POINT_04)

            ReDim .POINT_MARKER_2(4)
            .POINT_MARKER_2(1) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_2_POINT_01)
            .POINT_MARKER_2(2) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_2_POINT_02)
            .POINT_MARKER_2(3) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_2_POINT_03)
            .POINT_MARKER_2(4) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_2_POINT_04)

            ReDim .POINT_MARKER_3(4)
            .POINT_MARKER_3(1) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_3_POINT_01)
            .POINT_MARKER_3(2) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_3_POINT_02)
            .POINT_MARKER_3(3) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_3_POINT_03)
            .POINT_MARKER_3(4) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_3_POINT_04)

            ReDim .POINT_MARKER_4(4)
            .POINT_MARKER_4(1) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_4_POINT_01)
            .POINT_MARKER_4(2) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_4_POINT_02)
            .POINT_MARKER_4(3) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_4_POINT_03)
            .POINT_MARKER_4(4) = .BYT_MARKER(ENM_MARKER_INFO.MARKER_4_POINT_04)
        End With
    End Sub

    Private Sub SUB_EDIT()

        For i = 1 To CST_COUNT_MARKER
            Call SUB_CLEAR_MARKER(i)

            LBL_NAME_CONTENT(i).Content = SRT_MARKER_LIST(i).NAME_CONTENET
            If SRT_MARKER_LIST(i).ENABLED Then
                LBL_NAME_CONTENT(i).ToolTip = SRT_MARKER_LIST(i).DATE_TIME_EDIT.ToShortDateString & " " & SRT_MARKER_LIST(i).DATE_TIME_EDIT.ToShortTimeString

                If SRT_MARKER_LIST(i).ENABLED_MARKER_A Then
                    LBL_MARKER_A(i).Foreground = BRS_DEFAULT_MARKER_A
                End If
                If SRT_MARKER_LIST(i).ENABLED_MARKER_B Then
                    LBL_MARKER_B(i).Foreground = BRS_DEFAULT_MARKER_B
                End If
                If SRT_MARKER_LIST(i).ENABLED_MARKER_C Then
                    LBL_MARKER_C(i).Foreground = BRS_DEFAULT_MARKER_C
                End If
                If SRT_MARKER_LIST(i).ENABLED_MARKER_D Then
                    LBL_MARKER_D(i).Foreground = BRS_DEFAULT_MARKER_D
                End If
                If SRT_MARKER_LIST(i).ENABLED_MARKER_1 Then
                    LBL_MARKER_1(i).Foreground = BRS_DEFAULT_MARKER_1
                End If
                If SRT_MARKER_LIST(i).ENABLED_MARKER_2 Then
                    LBL_MARKER_2(i).Foreground = BRS_DEFAULT_MARKER_2
                End If
                If SRT_MARKER_LIST(i).ENABLED_MARKER_3 Then
                    LBL_MARKER_3(i).Foreground = BRS_DEFAULT_MARKER_3
                End If
                If SRT_MARKER_LIST(i).ENABLED_MARKER_4 Then
                    LBL_MARKER_4(i).Foreground = BRS_DEFAULT_MARKER_4
                End If
            End If
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
        STR_RET &= "マーカーバックアップファイル|*.BAK"

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
