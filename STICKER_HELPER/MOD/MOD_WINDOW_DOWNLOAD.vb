Module MOD_WINDOW_DOWNLOAD

    Public Function FUNC_SHOW_WINDOW_DOWNLOAD(ByRef STR_PATH_DAT As String) As Boolean

        STR_PATH_DAT = ""

        Dim WPF_SHOW As WPF_DOWNLOAD
        WPF_SHOW = New WPF_DOWNLOAD

        Call WPF_SHOW.ShowDialog()

        Dim BLN_OK As Boolean
        BLN_OK = WPF_SHOW.RET_OK
        STR_PATH_DAT = WPF_SHOW.RET_PATH_DAT
        WPF_SHOW = Nothing

        If Not BLN_OK Then
            Return False
        End If

        Return True
    End Function
End Module
