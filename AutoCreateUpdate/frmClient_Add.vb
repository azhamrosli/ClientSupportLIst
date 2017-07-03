Public Class frmClient_Add
    Public ID As String = Nothing
    Public isEdit As Boolean = False
    Dim Errorlog As clsError = Nothing
    Private Sub frmClient_Add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If isEdit = False Then
                btnGenerateID.PerformClick()
                txtID.Enabled = True
                btnGenerateID.Visible = True
            Else
                txtID.Enabled = False
                btnGenerateID.Visible = False

                Dim dt As DataTable = LoadClient_ByID(ID)

                If dt IsNot Nothing Then
                    txtID.Text = ID
                    txtRefID.Text = IIf(IsDBNull(dt.Rows(0)("RefID")), "", dt.Rows(0)("RefID"))
                    txtName.Text = IIf(IsDBNull(dt.Rows(0)("CompanyName")), "", dt.Rows(0)("CompanyName"))
                    txtAddress1.Text = IIf(IsDBNull(dt.Rows(0)("Address1")), "", dt.Rows(0)("Address1"))
                    txtAddress2.Text = IIf(IsDBNull(dt.Rows(0)("Address2")), "", dt.Rows(0)("Address2"))
                    txtAddress3.Text = IIf(IsDBNull(dt.Rows(0)("Address3")), "", dt.Rows(0)("Address3"))
                    txtPostcode.Text = IIf(IsDBNull(dt.Rows(0)("Postcode")), "", dt.Rows(0)("Postcode"))
                    txtCity.Text = IIf(IsDBNull(dt.Rows(0)("City")), "", dt.Rows(0)("City"))
                    txtState.Text = IIf(IsDBNull(dt.Rows(0)("State")), "", dt.Rows(0)("State"))
                    txtCountry.Text = IIf(IsDBNull(dt.Rows(0)("Country")), "", dt.Rows(0)("Country"))
                    txtPhone1.Text = IIf(IsDBNull(dt.Rows(0)("Phone1")), "", dt.Rows(0)("Phone1"))
                    txtPhone2.Text = IIf(IsDBNull(dt.Rows(0)("Phone2")), "", dt.Rows(0)("Phone2"))
                    txtFaxNo.Text = IIf(IsDBNull(dt.Rows(0)("FaxNo")), "", dt.Rows(0)("FaxNo"))

                    If IsDBNull(dt.Rows(0)("License_Enterprise")) = False Then
                        If dt.Rows(0)("License_Enterprise") = 1 Then
                            chkEnterprise.Checked = True
                        ElseIf dt.Rows(0)("License_Enterprise") = 2 Then
                            chkEnterprise_C.Checked = True
                        ElseIf dt.Rows(0)("License_Enterprise") = 3 Then
                            chkEnterprise_B.Checked = True
                        End If
                    Else
                        chkEnterprise.Checked = False
                        chkEnterprise_C.Checked = False
                        chkEnterprise_B.Checked = False
                    End If

                    If IsDBNull(dt.Rows(0)("License_SmallBusiness")) = False Then
                        If dt.Rows(0)("License_SmallBusiness") = 1 Then
                            chkSmallBusiness.Checked = True
                        ElseIf dt.Rows(0)("License_SmallBusiness") = 2 Then
                            chkSmallBusiness_C.Checked = True
                        ElseIf dt.Rows(0)("License_SmallBusiness") = 3 Then
                            chkSmallBusiness_B.Checked = True
                        End If
                    Else
                        chkSmallBusiness.Checked = False
                        chkSmallBusiness_C.Checked = False
                        chkSmallBusiness_B.Checked = False
                    End If

                    If IsDBNull(dt.Rows(0)("License_Lite")) = False Then
                        If dt.Rows(0)("License_Lite") = 1 Then
                            chkLite.Checked = True
                        ElseIf dt.Rows(0)("License_Lite") = 2 Then
                            chkLite_C.Checked = True
                        ElseIf dt.Rows(0)("License_Lite") = 3 Then
                            chkLite_B.Checked = True
                        End If
                    Else
                        chkLite.Checked = False
                        chkLite_C.Checked = False
                        chkLite_B.Checked = False
                    End If

                    If IsDBNull(dt.Rows(0)("License_Education")) = False AndAlso dt.Rows(0)("License_Education") = 1 Then
                        chkEducation.Checked = True
                    Else
                        chkEducation.Checked = False
                    End If

                    If IsDBNull(dt.Rows(0)("License_Trial")) = False AndAlso dt.Rows(0)("License_Trial") = 1 Then
                        chkTrial.Checked = True
                    Else
                        chkTrial.Checked = False
                    End If

                    If IsDBNull(dt.Rows(0)("License_SQL_En")) = False AndAlso dt.Rows(0)("License_SQL_En") = 1 Then
                        chkSQL_En.Checked = True
                    Else
                        chkSQL_En.Checked = False
                    End If

                    If IsDBNull(dt.Rows(0)("isBan")) = False AndAlso dt.Rows(0)("isBan") = 1 Then
                        chkBan.Checked = True
                    Else
                        chkBan.Checked = False
                    End If

                    txtServerName.Text = IIf(IsDBNull(dt.Rows(0)("ServerName")), "", dt.Rows(0)("ServerName"))

                    Dim dtUserList As DataTable = LoadUserClient_ByCompanyID(ID)

                    LvList.Items.Clear()
                    If dtUserList IsNot Nothing Then
                        Dim itm As ListViewItem
                        Dim subitm As ListViewItem.ListViewSubItem
                        For i As Integer = 0 To dtUserList.Rows.Count - 1
                            itm = New ListViewItem

                            itm.Text = IIf(IsDBNull(dtUserList.Rows(i)("ID")), "", dtUserList.Rows(i)("ID"))


                            subitm = New ListViewItem.ListViewSubItem
                            subitm.Text = IIf(IsDBNull(dtUserList.Rows(i)("Name")), "", dtUserList.Rows(i)("Name"))
                            itm.SubItems.Add(subitm)


                            subitm = New ListViewItem.ListViewSubItem
                            subitm.Text = IIf(IsDBNull(dtUserList.Rows(i)("PhoneNo")), "", dtUserList.Rows(i)("PhoneNo"))
                            itm.SubItems.Add(subitm)

                            subitm = New ListViewItem.ListViewSubItem
                            subitm.Text = IIf(IsDBNull(dtUserList.Rows(i)("Email")), "", dtUserList.Rows(i)("Email"))
                            itm.SubItems.Add(subitm)

                            LvList.Items.Add(itm)
                        Next

                    End If
                Else
                    isEdit = False
                    btnGenerateID.PerformClick()
                    txtID.Enabled = True
                    btnGenerateID.Visible = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim frm As New frmClient_User
            frm.ShowDialog()

            If frm.isCancel = False Then
                Dim itm As ListViewItem
                Dim subitm As ListViewItem.ListViewSubItem

                itm = New ListViewItem

                itm.Text = frm.ID

                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = frm.UserName
                itm.SubItems.Add(subitm)

                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = frm.PhoneNo
                itm.SubItems.Add(subitm)

                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = frm.Email
                itm.SubItems.Add(subitm)

                LvList.Items.Add(itm)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim ListofItem As New List(Of ListViewItem)
            For i As Integer = 0 To LvList.Items.Count - 1
                If LvList.Items(i).Checked = False Then
                    ListofItem.Add(LvList.Items(i))
                End If
            Next

            If ListofItem.Count > 0 Then
                For i As Integer = 0 To ListofItem.Count - 1
                    ListofItem.Add(ListofItem(i))
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LvList_DoubleClick(sender As Object, e As EventArgs) Handles LvList.DoubleClick
        Try
            Dim tmpID As String = Nothing
            For i As Integer = 0 To LvList.Items.Count - 1
                If LvList.Items(i).Selected = True Then
                    Dim frm As New frmClient_User
                    frm.isEdit = True
                    frm.ID = LvList.Items(i).SubItems(0).Text
                    frm.UserName = LvList.Items(i).SubItems(1).Text
                    frm.PhoneNo = LvList.Items(i).SubItems(2).Text
                    frm.Email = LvList.Items(i).SubItems(3).Text
                    frm.ShowDialog()

                    If frm.isCancel = False Then
                        LvList.Items(i).SubItems(0).Text = frm.ID
                        LvList.Items(i).SubItems(1).Text = frm.UserName
                        LvList.Items(i).SubItems(2).Text = frm.PhoneNo
                        LvList.Items(i).SubItems(3).Text = frm.Email
                    End If
                    Exit For
                End If
            Next

           
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGenerateID_Click(sender As Object, e As EventArgs) Handles btnGenerateID.Click
        Try
            Dim tmpID As String = "CLN-" & Format(Now, "ddMMyyyyHHmmss") & RandomID(3)

            While ValidateStepJobID(tmpID)
                tmpID = "CLN-" & Format(Now, "ddMMyyyyHHmmss") & RandomID(3)
            End While
            txtID.Text = tmpID
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPhone1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone1.KeyPress, txtPhone2.KeyPress, txtFaxNo.KeyPress
        numbervalidation_Phone(e)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If isValid() Then
                Dim EnterpriseType As Integer = 0

                If chkEnterprise.Checked Then
                    EnterpriseType = 1
                ElseIf chkEnterprise_C.Checked Then
                    EnterpriseType = 2
                ElseIf chkEnterprise_B.Checked Then
                    EnterpriseType = 3
                End If

                Dim SmallType As Integer = 0

                If chkSmallBusiness.Checked Then
                    SmallType = 1
                ElseIf chkSmallBusiness_C.Checked Then
                    SmallType = 2
                ElseIf chkSmallBusiness_B.Checked Then
                    SmallType = 3
                End If

                Dim LiteType As Integer = 0

                If chkLite.Checked Then
                    LiteType = 1
                ElseIf chkLite_C.Checked Then
                    LiteType = 2
                ElseIf chkLite_B.Checked Then
                    LiteType = 3
                End If

                Dim SQLEn As Integer = 0

                If chkSQL_En.Checked Then
                    SQLEn = 1
                End If

                If isEdit = True Then
                    If mdlProcess_Office.UpdateClient(txtID.Text, txtRefID.Text, txtName.Text, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtState.Text, _
                                                   txtCity.Text, txtPostcode.Text, txtCountry.Text, txtPhone1.Text, txtPhone2.Text, txtFaxNo.Text, _
                                                   EnterpriseType, SmallType, LiteType, _
                                                   IIf(chkEducation.Checked, 1, 0), IIf(chkTrial.Checked, 1, 0), SQLEn, IIf(chkBan.Checked, 1, 0), txtServerName.Text, LvList, Errorlog) Then
                        MsgBox("Succesfully saved data.", MsgBoxStyle.Information)
                        Me.Close()
                    Else
                        MsgBox("Unsuccessfully save data." & vbCrLf & Errorlog.ErrorMessage, MsgBoxStyle.Critical)
                    End If
                Else
                    If mdlProcess_Office.SaveClient(txtID.Text, txtRefID.Text, txtName.Text, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtState.Text, _
                                                    txtCity.Text, txtPostcode.Text, txtCountry.Text, txtPhone1.Text, txtPhone2.Text, txtFaxNo.Text, _
                                                    EnterpriseType, SmallType, LiteType, _
                                                    IIf(chkEducation.Checked, 1, 0), IIf(chkTrial.Checked, 1, 0), SQLEn, IIf(chkBan.Checked, 1, 0), txtServerName.Text, LvList, Errorlog) Then
                        MsgBox("Succesfully saved data.", MsgBoxStyle.Information)
                        Me.Close()
                    Else
                        MsgBox("Unsuccessfully save data." & vbCrLf & Errorlog.ErrorMessage, MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function isValid()
        Try
            If txtID.TextLength = 0 Then
                btnGenerateID.Focus()
                MsgBox("Please enter ID", MsgBoxStyle.Critical)
                Return False
            End If

            If txtName.TextLength = 0 Then
                txtName.Focus()
                MsgBox("Please enter CompanyName", MsgBoxStyle.Critical)
                Return False
            End If

            Return True
        Catch ex As Exception

        End Try
    End Function

    Private Sub CopyPhoneNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyPhoneNoToolStripMenuItem.Click
        CopyDataToClipBoard(0)
    End Sub

    Private Sub CopyEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyEmailToolStripMenuItem.Click
        CopyDataToClipBoard(1)
    End Sub

    Private Sub CopyEmailToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyEmailToolStripMenuItem1.Click
        CopyDataToClipBoard(2)
    End Sub
    Private Sub CopyDataToClipBoard(ByVal Type As Integer)
        Try
            Dim txt As String = ""
            For i As Integer = 0 To LvList.Items.Count - 1
                If LvList.Items(i).Selected = True Then
                    Select Case Type
                        Case 0
                            txt = LvList.Items(i).SubItems(1).Text
                        Case 1
                            txt = LvList.Items(i).SubItems(2).Text
                        Case 2
                            txt = LvList.Items(i).SubItems(3).Text
                    End Select
                End If
            Next
            My.Computer.Clipboard.SetText(txt)

        Catch ex As Exception

        End Try
    End Sub
End Class