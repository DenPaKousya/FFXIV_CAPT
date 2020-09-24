Public Module MOD_FILE_TOOL
    Public STR_FILE_TOOL_LAST_ERR_STRING As String = ""
    'ファイルチェック処理
    Public Function FUNC_FILE_CHECK(
    ByVal strFILE_PATH As String
    ) As Boolean
        Dim filBASE As System.IO.FileInfo
        Dim blnRET As Boolean

        If strFILE_PATH Is Nothing Then
            Return False
        End If

        If strFILE_PATH = "" Then
            Return False
        End If

        filBASE = New System.IO.FileInfo(strFILE_PATH)
        blnRET = filBASE.Exists

        Call GC.ReRegisterForFinalize(filBASE)
        filBASE = Nothing

        Return blnRET
    End Function

    'ファイルの削除を行う
    Public Function FUNC_FILE_DELETE(ByVal strFilePath As String) As Boolean

        If Not FUNC_FILE_CHECK(strFilePath) Then
            Return True 'ファイルがなければ消去する必要なし
        End If

        Try
            Call System.IO.File.Delete(strFilePath)
        Catch ex As Exception
            STR_FILE_TOOL_LAST_ERR_STRING = ex.Message
            Return False
        End Try

        Return True
    End Function

    'ディレクトリのチェック
    Public Function FUNC_DIR_CHECK(ByVal strPATH_DIR As String) As Boolean
        Dim dirCHECK As System.IO.DirectoryInfo
        Dim blnRET As Boolean

        STR_FILE_TOOL_LAST_ERR_STRING = ""

        Try
            dirCHECK = New System.IO.DirectoryInfo(strPATH_DIR)
        Catch ex As Exception
            dirCHECK = Nothing
            STR_FILE_TOOL_LAST_ERR_STRING = ex.Message
            Return True '無理やりあるものとして返して上位関数でのエラーを誘う
        End Try

        blnRET = dirCHECK.Exists
        dirCHECK = Nothing

        Return blnRET
    End Function


    '指定のディレクトリのディレクトリを取得する(代表一つ)
    Public Function FUNC_DIRECTORY_NAME_GETS(ByVal strDIR As String, ByVal strFILETER As String) As String
        Dim STR_RET As String
        STR_RET = ""

        Dim STR_DIRECTORIES() As String
        STR_DIRECTORIES = System.IO.Directory.GetDirectories(strDIR, "*" & strFILETER & "*")
        If STR_DIRECTORIES Is Nothing Then
            Return ""
        End If

        If STR_DIRECTORIES.Length < 1 Then
            Return ""
        End If

        STR_RET = STR_DIRECTORIES(0)

        Return STR_RET
    End Function

    '実行パスの取得
    Public Function FUNC_GET_EXE_PATH() As String
        Dim ASB_CURRENT As System.Reflection.Assembly
        ASB_CURRENT = System.Reflection.Assembly.GetEntryAssembly()

        Dim STR_RET As String
        STR_RET = ASB_CURRENT.Location()

        Return STR_RET
    End Function

    'パスからディレクトリパスを抜き出す
    Public Function FUNC_PATH_TO_DIR_PATH(
    ByVal strPATH As String
    ) As String
        Dim strRET As String
        Dim intLEN As Integer
        Dim strCHECK As String
        Dim intLOOP_INDEX As Integer

        intLEN = Len(strPATH)
        strRET = ""
        For intLOOP_INDEX = 1 To intLEN
            strCHECK = Mid(strPATH, intLEN - intLOOP_INDEX, 1)
            If strCHECK = "\" Then
                strRET = Mid(strPATH, 1, intLEN - intLOOP_INDEX)
                Exit For
            End If
        Next

        Return strRET
    End Function


    'ディレクトリの作成
    Public Function FUNC_DIR_MAKE(ByVal strPATH_DIR As String) As Boolean
        Dim dirMake As System.IO.DirectoryInfo
        Dim strPATH_DIR_TOP As String

        STR_FILE_TOOL_LAST_ERR_STRING = ""

        strPATH_DIR_TOP = FUNC_DIR_CONVERT_ONE_TOP(strPATH_DIR)

        If Not FUNC_DIR_CHECK(strPATH_DIR_TOP) Then
            If Not FUNC_DIR_MAKE(strPATH_DIR_TOP) Then
                Return False
            End If
        End If

        If FUNC_DIR_CHECK(strPATH_DIR) Then 'すでに存在するなら
            Return True 'そのまま
        End If

        Try
            dirMake = New System.IO.DirectoryInfo(strPATH_DIR)
        Catch ex As Exception
            dirMake = Nothing
            STR_FILE_TOOL_LAST_ERR_STRING = ex.Message
            Return False
        End Try

        Try
            Call dirMake.Create() '作成
            dirMake = Nothing
        Catch ex As Exception
            dirMake = Nothing
            STR_FILE_TOOL_LAST_ERR_STRING = ex.Message
            Return False
        End Try

        Return True
    End Function

    '上位ディレクトリへ変換
    Public Function FUNC_DIR_CONVERT_ONE_TOP(ByVal strPATH_DIR As String) As String
        Dim strRET As String
        Dim intLEN As Integer
        Dim strCHECK As String
        Dim intLOOP_INDEX As Integer

        intLEN = strPATH_DIR.Length
        strRET = ""
        For intLOOP_INDEX = 1 To intLEN
            strCHECK = Mid(strPATH_DIR, intLEN - intLOOP_INDEX, 1)
            If strCHECK = "\" Then
                strRET = Mid(strPATH_DIR, 1, intLEN - intLOOP_INDEX)
                Exit For
            End If
        Next

        Return strRET
    End Function


    'ファイルのコピーを行う
    Public Function FUNC_FILE_COPY(
    ByVal strFILE_SOURCE As String, ByVal strFILE_DEST As String
    ) As Boolean
        If Not FUNC_FILE_CHECK(strFILE_SOURCE) Then
            STR_FILE_TOOL_LAST_ERR_STRING = "基本ファイル：" & strFILE_SOURCE & "が存在しません"
            Return False 'ファイルがなければコピーできない
        End If

        If FUNC_FILE_CHECK(strFILE_DEST) Then 'コピー先ファイルが存在する場合は
            If Not FUNC_FILE_DELETE(strFILE_DEST) Then '強制削除
                'エラーは中で
                Return False
            End If
        End If

        Try
            Call System.IO.File.Copy(strFILE_SOURCE, strFILE_DEST)
        Catch ex As Exception
            STR_FILE_TOOL_LAST_ERR_STRING = ex.Message
            Return False
        End Try

        Return True
    End Function

End Module
