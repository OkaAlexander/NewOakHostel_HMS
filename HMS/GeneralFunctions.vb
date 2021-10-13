Public Class GeneralFunctions
    Public updateKey As String

    '
    'Give Save options
    '
    Public Enum mode
        Save
        Update
    End Enum

    '
    'convert picture  from image to array of byte
    '
    Public Function ConvertToByteArray(image As Image) As Byte()
        Dim converter As New ImageConverter
        Return converter.ConvertTo(image, GetType(Byte()))
    End Function

    '
    'converts picture from array of byte to image
    '
    Public Function ConvertToImage(image As Byte()) As Image
        Dim myimage As Image
        Dim ms As New System.IO.MemoryStream(image)
        myimage = System.Drawing.Image.FromStream(ms)
        Return myimage
    End Function

    '
    'truncates the string after 25 characters
    '
    Public Function TruncateString(str As String) As String
        Dim truncatedStr As String
        If str.Length > 25 Then
            truncatedStr = str.Substring(0, 25) + "..."
            Return truncatedStr
        End If
        Return str
    End Function

    '
    'for uploading an image
    '
    Public Function uploadImg(pic As OpenFileDialog, imgBox As PictureBox) As Boolean
        Try
            Dim file As String
            If pic.ShowDialog() = DialogResult.Cancel Then
                Return False
            Else
                file = pic.FileName
                imgBox.Image = Image.FromFile(file)
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
End Class
