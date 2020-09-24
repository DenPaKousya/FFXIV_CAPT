Module MOD_MAIN

#Region "共有・定数"
    Public Const CST_STICKER_ENABLED_BYTE_LENGTH As Integer = &H1
    Public Const CST_TITLE_BYTE_LENGTH As Integer = &H40
    Public Const CST_STICKER_INFO_BYTE_LENGTH As Integer = &H11E0

    Public Const CST_VALUE_UISAVE_NULL As Integer = &H42

    Public Const CST_LENGTH_FILE_SBK As Integer = &H1222
#End Region

    Public Sub Main()

        Dim WPF_MAIN_WINDOW As WPF_MAIN
        WPF_MAIN_WINDOW = New WPF_MAIN
        Call WPF_MAIN_WINDOW.ShowDialog()
    End Sub
End Module
