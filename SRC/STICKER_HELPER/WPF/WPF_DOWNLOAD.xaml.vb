Imports System.ComponentModel

Public Class WPF_DOWNLOAD

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_OK = 1
        DO_CANCEL
        DO_VIEW_LIST
    End Enum

    Private Enum ENM_CSV_INDEX
        COMMENT
        URL

        UBOUND = URL
    End Enum

    Private Enum ENM_GRID_INDEX
        NO
        COMMENT

        UBOUND = COMMENT
    End Enum
#End Region

#Region "画面用・構造体"
    Private Structure SRT_INFO_CSV
        Public COMMENT As String
        Public URL As String
    End Structure
#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean
    Private STR_URL_CSV As String
    Private TBL_GRID As System.Data.DataTable
    Private SRT_GRID_INFO() As SRT_INFO_CSV
#End Region

#Region "画面用・プロパティ変数"
    Private BLN_RET_OK As Boolean = False
    Private STR_RET_PATH_DAT As String
#End Region

#Region "プロパティ"
    Friend Property RET_OK() As Boolean
        Get
            Return BLN_RET_OK
        End Get
        Set(ByVal Value As Boolean)
            BLN_RET_OK = Value
        End Set
    End Property

    Friend Property RET_PATH_DAT() As String
        Get
            Return STR_RET_PATH_DAT
        End Get
        Set(ByVal Value As String)
            STR_RET_PATH_DAT = Value
        End Set
    End Property
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()

        Call SUB_MAKE_DATA_TABLE(TBL_GRID, "No,コメント", "IS")
        DGV_LIST.DataContext = TBL_GRID
        DGV_LIST.ItemsSource = TBL_GRID.DefaultView
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()
        STR_URL_CSV = "https://drive.google.com/uc?id=1kZMP5yMF80CroOgIDfM4obkAC5Ri4sEK"
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        TXT_URL_CSV.Text = STR_URL_CSV

        Call SUB_PUT_GUIDE("")
    End Sub
#End Region

#Region "各処理呼出元"
    Private Sub SUB_EXEC_DO(
    ByVal ENM_EXEC_DO As ENM_MY_EXEC_DO
    )
        If BLN_PROCESS_DOING Then
            Exit Sub
        End If

        Me.Cursor = Cursors.Wait
        BLN_PROCESS_DOING = True
        Call SUB_DOEVENTS()

        Select Case ENM_EXEC_DO
            Case ENM_MY_EXEC_DO.DO_OK
                Call SUB_OK()
            Case ENM_MY_EXEC_DO.DO_CANCEL
                Call SUB_CANCEL()
            Case ENM_MY_EXEC_DO.DO_VIEW_LIST
                Call SUB_VIEW_LIST()
        End Select

        Call SUB_DOEVENTS()
        BLN_PROCESS_DOING = False
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

#Region "実行処理群"
    Private Sub SUB_OK()
        Dim INT_INDEX As Integer
        INT_INDEX = DGV_LIST.SelectedIndex
        INT_INDEX += 1
        If INT_INDEX <= 0 Then
            Call MessageBox.Show("ダウンロードするステッカーを選択してください。", Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
            Exit Sub
        End If

        Call SUB_PUT_GUIDE(INT_INDEX & " " & "ステッカーをダウンロードしています。")
        Dim STR_PATH_DAT As String
        STR_PATH_DAT = ""
        If Not FUNC_DOWNLOAD_DAT(STR_PATH_DAT, SRT_GRID_INFO(INT_INDEX).URL) Then
            Call MessageBox.Show(STR_FUNC_DOWNLOAD_CSV_ERR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Call SUB_PUT_GUIDE("")
        Me.RET_PATH_DAT = STR_PATH_DAT
        Me.RET_OK = True
        Me.Close()
    End Sub

    Private Sub SUB_CANCEL()
        Me.Close()
    End Sub

    Private Sub SUB_VIEW_LIST()
        Dim STR_URL As String
        STR_URL = TXT_URL_CSV.Text
        STR_URL = FUNC_CONVERT_URL_GOOGLE_DRIVE(STR_URL)

        Call SUB_PUT_GUIDE("ステッカーリストをダウンロードしています。")
        Dim STR_PATH_CSV As String
        STR_PATH_CSV = ""
        If Not FUNC_DOWNLOAD_CSV(STR_URL, STR_PATH_CSV) Then
            Call MessageBox.Show(STR_FUNC_DOWNLOAD_CSV_ERR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Dim BLN_CHECK_CSV As Boolean
        BLN_CHECK_CSV = FUNC_CHECK_FILE_INFO_CSV(STR_PATH_CSV)

        Call SUB_PUT_GUIDE("リストを読込んでいます。")
        Dim STR_ARRAY_CSV() As String
        STR_ARRAY_CSV = Nothing
        If BLN_CHECK_CSV Then
            If Not FUNC_GET_CSV_STRING(STR_PATH_CSV, STR_ARRAY_CSV) Then
                Call MessageBox.Show(STR_FUNC_GET_CSV_STRING_ERR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
                Exit Sub
            End If
        Else
            If Not FUNC_GET_SBK_STRING(STR_PATH_CSV, STR_URL, STR_ARRAY_CSV) Then
                Call MessageBox.Show(STR_FUNC_GET_SBK_STRING_ERR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
                Exit Sub
            End If
        End If

        Call SUB_PUT_GUIDE("リストを解析しています。")

        SRT_GRID_INFO = Nothing
        If Not FUNC_GET_CSV_INFO(STR_ARRAY_CSV, SRT_GRID_INFO) Then
            Call MessageBox.Show(STR_FUNC_GET_CSV_INFO_ERR, Me.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Exit Sub
        End If

        Call SUB_PUT_GUIDE("リストを表示しています。")
        Call SUB_SET_GRID(SRT_GRID_INFO)

        Call SUB_PUT_GUIDE("")
    End Sub
#End Region

#Region "内部処理"
    Private STR_FUNC_DOWNLOAD_DAT_ERR As String
    Private Function FUNC_DOWNLOAD_DAT(ByRef STR_PATH_DAT As String, ByVal STR_URL As String) As Boolean
        STR_FUNC_DOWNLOAD_DAT_ERR = ""

        STR_PATH_DAT = ""

        Dim STR_DOWNLOAD_DIR As String
        STR_DOWNLOAD_DIR = FUNC_GET_DOWNLOAD_PATH()
        If Not FUNC_DIR_MAKE(STR_DOWNLOAD_DIR) Then
            STR_FUNC_DOWNLOAD_DAT_ERR = STR_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If

        Dim STR_PATH_FILE As String
        STR_PATH_FILE = STR_DOWNLOAD_DIR & "TEMP.DAT"
        If Not FUNC_FILE_DELETE(STR_PATH_FILE) Then
            STR_FUNC_DOWNLOAD_DAT_ERR = STR_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If

        Dim WBC_CSV As System.Net.WebClient
        Try
            WBC_CSV = New System.Net.WebClient
        Catch ex As Exception
            STR_FUNC_DOWNLOAD_DAT_ERR = ex.Message
            Return False
        End Try
        Try
            WBC_CSV.DownloadFile(STR_URL, STR_PATH_FILE)
        Catch ex As Exception
            STR_FUNC_DOWNLOAD_DAT_ERR = ex.Message
            Return False
        End Try

        STR_PATH_DAT = STR_PATH_FILE

        Call WBC_CSV.Dispose()
        WBC_CSV = Nothing

        Return True
    End Function

    Private STR_FUNC_DOWNLOAD_CSV_ERR As String
    Private Function FUNC_DOWNLOAD_CSV(ByVal STR_URL As String, ByRef STR_PATH_CSV As String) As Boolean
        STR_FUNC_DOWNLOAD_CSV_ERR = ""

        STR_PATH_CSV = ""

        Dim STR_DOWNLOAD_DIR As String
        STR_DOWNLOAD_DIR = FUNC_GET_DOWNLOAD_PATH()
        If Not FUNC_DIR_MAKE(STR_DOWNLOAD_DIR) Then
            STR_FUNC_DOWNLOAD_CSV_ERR = STR_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If

        Dim STR_PATH_FILE As String
        STR_PATH_FILE = STR_DOWNLOAD_DIR & "LIST.CSV"
        If Not FUNC_FILE_DELETE(STR_PATH_FILE) Then
            STR_FUNC_DOWNLOAD_CSV_ERR = STR_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If

        Dim WBC_CSV As System.Net.WebClient
        Try
            WBC_CSV = New System.Net.WebClient
        Catch ex As Exception
            STR_FUNC_DOWNLOAD_CSV_ERR = ex.Message
            Return False
        End Try
        Try
            WBC_CSV.DownloadFile(STR_URL, STR_PATH_FILE)
        Catch ex As Exception
            STR_FUNC_DOWNLOAD_CSV_ERR = ex.Message
            Return False
        End Try

        STR_PATH_CSV = STR_PATH_FILE

        Call WBC_CSV.Dispose()
        WBC_CSV = Nothing

        Return True
    End Function

    Private Function FUNC_CHECK_FILE_INFO_CSV(ByVal STR_PATH As String) As Boolean
        Dim FIF_FILE As System.IO.FileInfo

        Try
            FIF_FILE = New System.IO.FileInfo(STR_PATH)
        Catch ex As Exception
            Return False
        End Try

        Dim INT_LENGTH As Integer
        INT_LENGTH = FIF_FILE.Length

        If INT_LENGTH = CST_LENGTH_FILE_SBK Then
            Return False
        End If

        Return True
    End Function

    Private STR_FUNC_GET_SBK_STRING_ERR As String
    Private Function FUNC_GET_SBK_STRING(ByVal STR_PATH As String, ByVal STR_URL As String, ByRef STR_ARRAY() As String) As Boolean
        If STR_ARRAY Is Nothing Then
            ReDim STR_ARRAY(0)
        End If

        Dim BYT_RESTORE() As Byte
        BYT_RESTORE = Nothing
        If Not FUNC_READ_FILE(STR_PATH, BYT_RESTORE) Then
            STR_FUNC_GET_SBK_STRING_ERR = STR_FUNC_READ_FILE_ERROR
            Return False
        End If

        Dim INT_INDEX_TITLE_FROM As Integer
        INT_INDEX_TITLE_FROM = 1
        INT_INDEX_TITLE_FROM += CST_STICKER_ENABLED_BYTE_LENGTH

        Dim BYT_TITLE() As Byte
        ReDim BYT_TITLE(CST_TITLE_BYTE_LENGTH)
        For i = 1 To (BYT_TITLE.Length - 1)
            BYT_TITLE(i) = BYT_RESTORE(INT_INDEX_TITLE_FROM + i - 1)
        Next

        Dim BYT_TITLE_CNV() As Byte
        ReDim BYT_TITLE_CNV(BYT_TITLE.Length - 1)
        For i = 1 To (BYT_TITLE.Length - 1)
            BYT_TITLE_CNV(i) = FUNC_CONVERT_HEX_UISAVE(BYT_TITLE(i))
        Next

        Dim STR_TITLE As String
        STR_TITLE = FUNC_GECT_STRING_FROM_HEX(BYT_TITLE_CNV)

        Dim STR_ROW_ONE As String
        STR_ROW_ONE = ""
        STR_ROW_ONE &= STR_TITLE & ","
        STR_ROW_ONE &= STR_URL & ""

        Dim INT_INDEX As Integer
        INT_INDEX = STR_ARRAY.Length
        ReDim Preserve STR_ARRAY(INT_INDEX)
        STR_ARRAY(INT_INDEX) = STR_ROW_ONE

        Return True
    End Function

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


    Private STR_FUNC_GET_CSV_STRING_ERR As String
    Private Function FUNC_GET_CSV_STRING(ByVal STR_PATH_CSV As String, ByRef STR_ARRAY() As String) As Boolean

        If STR_ARRAY Is Nothing Then
            ReDim STR_ARRAY(0)
        End If

        Dim ENC_FILE As System.Text.Encoding
        ENC_FILE = System.Text.Encoding.UTF8 'System.Text.Encoding.GetEncoding("shift_jis")

        Dim STW_CSV_READER As System.IO.StreamReader
        Try
            STW_CSV_READER = New System.IO.StreamReader(STR_PATH_CSV, ENC_FILE)
        Catch ex As Exception
            STR_FUNC_GET_CSV_STRING_ERR = ex.Message
            Return False
        End Try

        Dim STR_ROW As String
        While (STW_CSV_READER.Peek() > -1)
            STR_ROW = STW_CSV_READER.ReadLine()
            Dim INT_INDEX As Integer
            INT_INDEX = STR_ARRAY.Length
            ReDim Preserve STR_ARRAY(INT_INDEX)
            STR_ARRAY(INT_INDEX) = STR_ROW
        End While

        Call STW_CSV_READER.Close()
        Call STW_CSV_READER.Dispose()
        STW_CSV_READER = Nothing

        Return True
    End Function

    Private STR_FUNC_GET_CSV_INFO_ERR As String
    Private Function FUNC_GET_CSV_INFO(ByRef STR_ARRAY() As String, ByRef SRT_INFO() As SRT_INFO_CSV) As Boolean

        ReDim SRT_INFO(0)

        If STR_ARRAY Is Nothing Then
            Return True
        End If

        Dim INT_INDEX_MAX As Integer
        INT_INDEX_MAX = (STR_ARRAY.Length - 1)
        ReDim SRT_INFO(INT_INDEX_MAX)
        For i = 1 To (STR_ARRAY.Length - 1)
            If Not FUNC_GET_CSV_INFO_ONE(STR_ARRAY(i), SRT_INFO(i)) Then
                STR_FUNC_GET_CSV_INFO_ERR = ""
                STR_FUNC_GET_CSV_INFO_ERR &= i & "行目：" & System.Environment.NewLine
                STR_FUNC_GET_CSV_INFO_ERR &= STR_FUNC_GET_CSV_INFO_ONE_ERR
                Return False
            End If
        Next

        Return True
    End Function

    Private STR_FUNC_GET_CSV_INFO_ONE_ERR As String
    Private Function FUNC_GET_CSV_INFO_ONE(ByVal STR_ROW As String, ByRef SRT_INFO As SRT_INFO_CSV) As Boolean

        Dim STR_ROW_SEP() As String
        STR_ROW_SEP = STR_ROW.Split(",")
        If STR_ROW_SEP Is Nothing Then
            STR_FUNC_GET_CSV_INFO_ONE_ERR = "行がCSV構造となっていません。"
            Return False
        End If

        If Not ((STR_ROW_SEP.Length - 1) = ENM_CSV_INDEX.UBOUND) Then
            STR_FUNC_GET_CSV_INFO_ONE_ERR = "レイアウトが不正です。"
            Return False
        End If

        With SRT_INFO
            Dim INT_INDEX As Integer
            Try
                INT_INDEX = ENM_CSV_INDEX.COMMENT
                .COMMENT = CStr(FUNC_GET_STR_FROM_CSV(STR_ROW_SEP, INT_INDEX))

                INT_INDEX = ENM_CSV_INDEX.URL
                .URL = CStr(FUNC_GET_STR_FROM_CSV(STR_ROW_SEP, INT_INDEX))
                .URL = FUNC_CONVERT_URL_GOOGLE_DRIVE(.URL)
            Catch ex As Exception
                STR_FUNC_GET_CSV_INFO_ONE_ERR = ex.Message
                Return False
            End Try
        End With

        With SRT_INFO
        End With

        Return True
    End Function

    Private Function FUNC_GET_STR_FROM_CSV(ByRef STR_ROW_SEP() As String, ByVal INT_INDEX As Integer) As String
        Dim STR_TEMP As String
        STR_TEMP = FUNC_GET_STR_VALUE_FROM_ROW(STR_ROW_SEP, INT_INDEX)
        STR_TEMP = STR_TEMP.Replace("""", "")  '項目内部の”を潰す

        Return STR_TEMP
    End Function

    Private Function FUNC_GET_STR_VALUE_FROM_ROW(ByRef STR_ROW() As String, ByVal INT_INDEX As Integer, Optional ByVal STR_MISS As String = "") As String
        Dim STR_RET As String

        If STR_ROW.Length > INT_INDEX Then
            STR_RET = STR_ROW(INT_INDEX)
        Else
            STR_RET = STR_MISS
        End If

        Return STR_RET
    End Function

    Private Sub SUB_SET_GRID(ByRef SRT_INFO() As SRT_INFO_CSV)

        Call TBL_GRID.Clear()
        Dim INT_MAX_INDEX As Integer
        INT_MAX_INDEX = (SRT_INFO.Length - 1)

        For i = 1 To INT_MAX_INDEX
            Dim OBJ_TEMP(ENM_GRID_INDEX.UBOUND) As Object
            With SRT_INFO(i)
                OBJ_TEMP(ENM_GRID_INDEX.NO) = i
                OBJ_TEMP(ENM_GRID_INDEX.COMMENT) = .COMMENT
            End With
            Call SUB_ADD_ROW_DATA_TABLE(TBL_GRID, OBJ_TEMP)
        Next

        Call SUB_WPF_DATA_GRID_SORT_CLEAR(DGV_LIST)
    End Sub
#End Region

#Region "その他処理"
    Private Function FUNC_GET_DOWNLOAD_PATH() As String
        Dim STR_EXECUTE_DIR As String
        STR_EXECUTE_DIR = FUNC_PATH_TO_DIR_PATH(FUNC_GET_EXE_PATH())
        Dim STR_DOWNLOAD_DIR As String
        STR_DOWNLOAD_DIR = STR_EXECUTE_DIR & "\" & "DOWNLOAD" & "\"

        Return STR_DOWNLOAD_DIR
    End Function

    Private Sub SUB_PUT_GUIDE(ByVal STR_PUT As String)
        LBL_GUIDE.Content = STR_PUT
        Call SUB_DOEVENTS()
    End Sub

    Private Sub SUB_DOEVENTS()
        Dim Frame As System.Windows.Threading.DispatcherFrame
        Frame = New System.Windows.Threading.DispatcherFrame

        Dim callback As Object
        callback = New System.Windows.Threading.DispatcherOperationCallback(AddressOf FUNC_DOEVENTS_CALLBACK)

        Call System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, callback, Frame)
        Call System.Windows.Threading.Dispatcher.PushFrame(Frame)
    End Sub

    Private Function FUNC_DOEVENTS_CALLBACK(ByVal obj As System.Windows.Threading.DispatcherFrame) As Object
        obj.Continue = False
        Return Nothing
    End Function

    Private Sub SUB_WPF_DATA_GRID_SORT_CLEAR(ByRef DGV_CONTROL As System.Windows.Controls.DataGrid)

        If DGV_CONTROL Is Nothing Then
            Exit Sub
        End If

        If DGV_CONTROL.Columns Is Nothing Then
            Exit Sub
        End If

        For i = 0 To (DGV_CONTROL.Columns.Count - 1)
            DGV_CONTROL.Columns(i).SortDirection = Nothing
        Next
    End Sub

    Private Function FUNC_CONVERT_URL_GOOGLE_DRIVE(ByVal STR_URL As String) As String
        Const CST_URL_GOOGLE_DRIVE As String = "https://drive.google.com/"

        Dim STR_CHECK As String
        STR_CHECK = CST_URL_GOOGLE_DRIVE & "open"
        Dim BLN_CHECK_OPEN As Boolean
        BLN_CHECK_OPEN = STR_URL.Contains(STR_CHECK)

        STR_CHECK = CST_URL_GOOGLE_DRIVE & "file/"
        Dim BLN_CHECK_FILE As Boolean
        BLN_CHECK_FILE = STR_URL.Contains(STR_CHECK)

        If (Not BLN_CHECK_OPEN) And (Not BLN_CHECK_FILE) Then
            Return STR_URL
        End If

        Dim STR_REMOVE As String
        STR_REMOVE = STR_URL.Replace(CST_URL_GOOGLE_DRIVE, "")

        Dim STR_ID_FILE As String

        If BLN_CHECK_OPEN Then
            Dim STR_TEMP() As String
            STR_TEMP = STR_REMOVE.Split("=")
            STR_ID_FILE = STR_TEMP(1)
        Else
            Dim STR_TEMP() As String
            STR_TEMP = STR_REMOVE.Split("/")
            STR_ID_FILE = STR_TEMP(2)
        End If

        Dim STR_RET As String
        STR_RET = ""
        STR_RET &= CST_URL_GOOGLE_DRIVE
        STR_RET &= "uc" & "?"
        STR_RET &= "id" & "=" & STR_ID_FILE

        Return STR_RET
    End Function
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
    Private Sub BTN_OK_Click(sender As Object, e As RoutedEventArgs) Handles BTN_OK.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_OK)
    End Sub

    Private Sub BTN_CANCEL_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CANCEL.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CANCEL)
    End Sub

    Private Sub BTN_VIEW_LIST_Click(sender As Object, e As RoutedEventArgs) Handles BTN_VIEW_LIST.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_VIEW_LIST)
    End Sub
#End Region

    Private Sub WPF_DOWNLOAD_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub WPF_DOWNLOAD_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

End Class
