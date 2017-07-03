Public Class frmClient_User
    Public ID As String = Nothing
    Public isEdit As Boolean = False
    Public UserName As String = Nothing
    Public Email As String = Nothing
    Public PhoneNo As String = Nothing
    Public isCancel As Boolean = False
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        isCancel = True
        Me.Close()
    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
         numbervalidation_Phone(e)
    End Sub

    Private Sub btnGenerateID_Click(sender As Object, e As EventArgs) Handles btnGenerateID.Click
        Try
            Dim tmpID As String = "USR-" & Format(Now, "ddMMyyyyHHmmss") & RandomID(3)

            While ValidateStepJobID(tmpID)
                tmpID = "USR-" & Format(Now, "ddMMyyyyHHmmss") & RandomID(3)
            End While
            txtID.Text = tmpID
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtName.TextLength = 0 Then
                txtName.Focus()
                MsgBox("Please enter name", MsgBoxStyle.Information)
                Exit Sub
            End If

            isCancel = False
            ID = txtID.Text
            UserName = txtName.Text
            Email = txtEmail.Text
            PhoneNo = txtPhone.Text
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmClient_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If isEdit = False Then
                btnGenerateID.PerformClick()
                txtID.Enabled = True
                btnGenerateID.Visible = True
            Else
                txtID.Enabled = False
                btnGenerateID.Visible = False

                txtID.Text = ID
                txtName.Text = UserName
                txtEmail.Text = Email
                txtPhone.Text = PhoneNo
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class