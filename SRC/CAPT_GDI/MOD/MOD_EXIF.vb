Friend Module MOD_EXIF

#Region "モジュール用・列挙定数"
    Public Enum ENM_EXIF_ID
        Make = 271
        Model = 272
        Software = 305
        ModifyDate = 306
        ISOSpeedRatings = 34855
        DateTimeOriginal = 36867
    End Enum
#End Region

#Region "モジュール用・変数"
    Private bmpSAMPLE_IMAGE As Bitmap
    Private itmSAMPLE_PITEM As System.Drawing.Imaging.PropertyItem
#End Region
    Public Function FUNC_INIT_EXIF() As Boolean
        Try
            bmpSAMPLE_IMAGE = New System.Drawing.Bitmap(".\RES\IMG\\SAMPLE.tif")
            itmSAMPLE_PITEM = bmpSAMPLE_IMAGE.PropertyItems(0)
        Catch ex As Exception
            Return False
        End Try

        Dim intLOOP_INDEX As Integer
        For intLOOP_INDEX = 0 To (bmpSAMPLE_IMAGE.PropertyItems.Length - 1)
            With bmpSAMPLE_IMAGE.PropertyItems(intLOOP_INDEX)
                If .Type = 2 Then
                    Dim bytTEST() As Byte
                    Dim val As String
                    bytTEST = .Value

                    val = System.Text.Encoding.ASCII.GetString(bytTEST)

                    Console.WriteLine(val & " " & .Id)
                End If
            End With
        Next

        Return True
    End Function

    Public Function FUNC_ADD_EXIF_STRING(ByRef bmpIMAGE As Bitmap, ByVal enmID As ENM_EXIF_ID, ByVal strVALUE As String) As Boolean
        Dim itmSET As System.Drawing.Imaging.PropertyItem
        Dim strSET As String

        strSET = strVALUE & Convert.ToChar(0)
        itmSET = itmSAMPLE_PITEM
        With itmSET
            .Id = CInt(enmID)
            .Type = 2
            .Value = System.Text.Encoding.ASCII.GetBytes(strSET)
            .Len = .Value.Length
        End With

        Call bmpIMAGE.SetPropertyItem(itmSET) '格納する

        Return True
    End Function

    Public Function FUNC_ADD_EXIF_INT16(ByRef bmpIMAGE As Bitmap, ByVal enmID As ENM_EXIF_ID, ByVal intVALUE As Integer) As Boolean
        Dim itmSET As System.Drawing.Imaging.PropertyItem
        itmSET = itmSAMPLE_PITEM
        With itmSET
            .Id = CInt(enmID)
            .Type = 3
            .Value = BitConverter.GetBytes(intVALUE)
            .Len = .Value.Length
        End With

        Call bmpIMAGE.SetPropertyItem(itmSET) '格納する

        Return True
    End Function

    Private Function FUNC_EDIT_EXIF(ByRef bmpIMAGE As Bitmap) As Boolean
        Dim intLOOP_INDEX As Integer

        If bmpIMAGE.PropertyItems Is Nothing OrElse bmpIMAGE.PropertyItems.Length = 0 Then
            Return False
        End If

        For intLOOP_INDEX = 0 To (bmpIMAGE.PropertyItems.Length - 1)
            Dim itmPITEM As System.Drawing.Imaging.PropertyItem = bmpIMAGE.PropertyItems(intLOOP_INDEX)

            With itmPITEM
                If .Id = &H13B And .Type = 2 Then
                    ''値を変更する
                    '.Value = System.Text.Encoding.ASCII.GetBytes(
                    '    artist + ControlChars.NullChar)
                    'pi.Len = pi.Value.Length
                    ''設定する
                    'bmp.SetPropertyItem(pi)
                    Return True
                End If
            End With
        Next

        Return False
    End Function
End Module
