Friend Module MOD_CHANGE_IMAGE

    Private STR_DIR_IMAGE As String = ""

    Public Sub SUB_INIT_CHANGE_IMAGE(ByVal STR_SET_DIR As String)
        STR_DIR_IMAGE = STR_SET_DIR
    End Sub

    Public Sub SUB_CHANGE_IMAGE_WPF_BUTTON(ByRef BTN_BUTTON As Controls.Button, ByVal STR_NAME_FILE As String)
        Dim OBJ_CONTENT As Object
        OBJ_CONTENT = BTN_BUTTON.Content

        If OBJ_CONTENT Is Nothing Then
            Exit Sub
        End If

        Dim STR_PATH As String
        STR_PATH = ""
        STR_PATH &= STR_DIR_IMAGE
        STR_PATH &= "\"
        STR_PATH &= STR_NAME_FILE

        If Not FUNC_FILE_CHECK(STR_PATH) Then
            Exit Sub
        End If

        Dim m_bitmap As BitmapImage
        m_bitmap = New BitmapImage()
        m_bitmap.BeginInit()
        m_bitmap.UriSource = New Uri(STR_PATH)
        m_bitmap.EndInit()

        Dim IMG_CONTENT As Controls.Image
        IMG_CONTENT = OBJ_CONTENT
        IMG_CONTENT.Source = m_bitmap
    End Sub

    Public Sub SUB_CHANGE_IMAGE_WPF(ByRef IMG_IMAGE As Controls.Image, ByVal STR_NAME_FILE As String)
        Dim STR_PATH As String
        STR_PATH = ""
        STR_PATH &= STR_DIR_IMAGE
        STR_PATH &= "\"
        STR_PATH &= STR_NAME_FILE

        If Not FUNC_FILE_CHECK(STR_PATH) Then
            Exit Sub
        End If

        Dim m_bitmap As BitmapImage
        m_bitmap = New BitmapImage()
        m_bitmap.BeginInit()
        m_bitmap.UriSource = New Uri(STR_PATH)
        m_bitmap.EndInit()

        IMG_IMAGE.Source = m_bitmap
    End Sub

    Public Function FUNC_GET_CHANEG_IMAGE(ByVal STR_NAME_FILE As String) As Bitmap
        Dim STR_PATH As String
        STR_PATH = ""
        STR_PATH &= STR_DIR_IMAGE
        STR_PATH &= "\"
        STR_PATH &= STR_NAME_FILE

        If Not FUNC_FILE_CHECK(STR_PATH) Then
            Return Nothing
        End If

        Dim BMP_RET As Bitmap
        BMP_RET = System.Drawing.Image.FromFile(STR_PATH)
        Return BMP_RET
    End Function
End Module
