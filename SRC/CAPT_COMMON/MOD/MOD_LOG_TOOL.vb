Public Module MOD_LOG_TOOL
    'デバッグログの出力判断・及び出力
    Public Sub SUB_SYSTEM_LOG_PUT_DEBUG(
    ByVal strLOG As String
    )
        Dim cstEXTEND_LOG As String = ".LOG"
        Dim strLOG_DIR As String
        Dim strLOG_FILE_NAME As String
        Dim strLOG_PATH As String
        Dim blnPUT As Boolean
        Dim strHEAD As String
        Dim strEXE_NAME As String

        blnPUT = True
        If Not blnPUT Then
            Exit Sub
        End If

        strLOG_DIR = FUNC_PATH_TO_DIR_PATH(System.Windows.Forms.Application.ExecutablePath) & "\"
        If Not FUNC_DIR_MAKE(strLOG_DIR) Then '出力用ディレクトリを作成
            Exit Sub
        End If

        strEXE_NAME = FUNC_GET_FILENAME_REMOVE_EXCTENT(FUNC_PATH_TO_FILENAME(System.Windows.Forms.Application.ExecutablePath))
        strLOG_FILE_NAME = strEXE_NAME & cstEXTEND_LOG

        strLOG_PATH = strLOG_DIR & strLOG_FILE_NAME

        strHEAD = System.DateTime.Now.ToShortDateString & " " & System.DateTime.Now.ToShortTimeString
        If Not FUNC_FILE_APPEND_WRITE(strLOG_PATH, strHEAD) Then
            Exit Sub
        End If

        If Not FUNC_FILE_APPEND_WRITE(strLOG_PATH, strLOG) Then
            Exit Sub
        End If

    End Sub
End Module
