Public Class frmPictureView
    Public Image As Bitmap = Nothing

    Private Sub frmPictureView_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmPictureView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub LoadData()
        Try
            If Image IsNot Nothing Then
                PictureBox1.Image = Image
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class