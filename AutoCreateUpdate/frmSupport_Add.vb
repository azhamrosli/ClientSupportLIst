Imports System.IO

Public Class frmSupport_Add
    Public ID As Integer = 0
    Public isEdit As Boolean = False
    Dim isRemote As Boolean = False
    Dim ListofString As List(Of String)
    Dim ErrorLog As clsError = Nothing
    Dim isSQLVersion As Boolean = False
    Private Sub LoadData(Optional ByVal Type As Integer = 0)
        Try
            Dim dt As DataTable = Nothing
            Dim tmpstr As String = Nothing
            If isEdit Then

                dt = mdlProcess_Office.LoadSupport_ByID(ID)


                If dt IsNot Nothing Then
                    txtRefID.Text = IIf(IsDBNull(dt.Rows(0)("CompanyID")), "", dt.Rows(0)("CompanyID"))
                    txtComName.Text = IIf(IsDBNull(dt.Rows(0)("CompanyName")), "", dt.Rows(0)("CompanyName"))
                    txtTVID.Text = IIf(IsDBNull(dt.Rows(0)("TeamviewerID")), "", dt.Rows(0)("TeamviewerID"))
                    txtTVPass.Text = IIf(IsDBNull(dt.Rows(0)("TeamviewerPass")), "", dt.Rows(0)("TeamviewerPass"))
                    txtPerson.Text = IIf(IsDBNull(dt.Rows(0)("PersonName")), "", dt.Rows(0)("PersonName"))
                    txtProblem.Text = IIf(IsDBNull(dt.Rows(0)("Problem")), "", dt.Rows(0)("Problem"))
                    txtNote.Text = IIf(IsDBNull(dt.Rows(0)("Note")), "", dt.Rows(0)("Note"))
                    cboStatus.SelectedIndex = IIf(IsDBNull(dt.Rows(0)("Status")), 0, dt.Rows(0)("Status"))
                    cboFormType.SelectedIndex = IIf(IsDBNull(dt.Rows(0)("TypeForm")), 0, dt.Rows(0)("TypeForm"))
                    txtRefNoPayer.Text = IIf(IsDBNull(dt.Rows(0)("RefPayerNo")), "", dt.Rows(0)("RefPayerNo"))
                    txtYA.Text = IIf(IsDBNull(dt.Rows(0)("YA")), "0", dt.Rows(0)("YA"))

                    If Type = 0 Then
                        txtID.Text = IIf(IsDBNull(dt.Rows(0)("RefID")), "", dt.Rows(0)("RefID"))
                    End If


                    If IsDBNull(dt.Rows(0)("License_Enterprise")) = False AndAlso dt.Rows(0)("License_Enterprise") = 1 Then
                        tmpstr += "Enterprise,"
                        isSQLVersion = False
                    ElseIf IsDBNull(dt.Rows(0)("License_Enterprise")) = False AndAlso dt.Rows(0)("License_Enterprise") = 2 Then
                        tmpstr += "Enterprise C+,"
                        isSQLVersion = False
                    ElseIf IsDBNull(dt.Rows(0)("License_Enterprise")) = False AndAlso dt.Rows(0)("License_Enterprise") = 3 Then
                        tmpstr += "Enterprise B+,"
                        isSQLVersion = False
                    End If

                    If IsDBNull(dt.Rows(0)("License_SmallBusiness")) = False AndAlso dt.Rows(0)("License_SmallBusiness") = 1 Then
                        tmpstr += "Small Business,"
                        isSQLVersion = False
                    ElseIf IsDBNull(dt.Rows(0)("License_SmallBusiness")) = False AndAlso dt.Rows(0)("License_SmallBusiness") = 2 Then
                        tmpstr += "Small Business C+,"
                        isSQLVersion = False
                    ElseIf IsDBNull(dt.Rows(0)("License_SmallBusiness")) = False AndAlso dt.Rows(0)("License_SmallBusiness") = 3 Then
                        tmpstr += "Small Business B+,"
                        isSQLVersion = False
                    End If

                    If IsDBNull(dt.Rows(0)("License_Lite")) = False AndAlso dt.Rows(0)("License_Lite") = 1 Then
                        tmpstr += "Lite,"
                        isSQLVersion = False
                    ElseIf IsDBNull(dt.Rows(0)("License_Lite")) = False AndAlso dt.Rows(0)("License_Lite") = 2 Then
                        tmpstr += "Lite C+,"
                        isSQLVersion = False
                    ElseIf IsDBNull(dt.Rows(0)("License_Lite")) = False AndAlso dt.Rows(0)("License_Lite") = 3 Then
                        tmpstr += "Lite B+,"
                        isSQLVersion = False
                    End If

                    If IsDBNull(dt.Rows(0)("License_Education")) = False AndAlso dt.Rows(0)("License_Education") = 1 Then
                        tmpstr += "Education,"
                        isSQLVersion = False
                    End If
                    If IsDBNull(dt.Rows(0)("License_Trial")) = False AndAlso dt.Rows(0)("License_Trial") = 1 Then
                        tmpstr += "Trial,"
                        isSQLVersion = False
                    End If
                    If IsDBNull(dt.Rows(0)("License_SQL_En")) = False AndAlso dt.Rows(0)("License_SQL_En") = 1 Then
                        tmpstr += "SQL,"
                        isSQLVersion = True
                    End If

                    lblTypeCompany.Text = "Version " & tmpstr
                    lblModifiedBy.Text = IIf(IsDBNull(dt.Rows(0)("ModifiedBy")), "", dt.Rows(0)("ModifiedBy"))
                    ' Dim tmpdt As DataTable = 

                    If mdlProcess_Office.LoadSupportAttachmentCount_ByID(ID) Then
                        Cursor = Cursors.AppStarting
                        Application.DoEvents()
                        Timer1.Enabled = True
                        Timer1.Start()
                        'Dim img As New PictureBox
                        'For i As Integer = 0 To tmpdt.Rows.Count - 1

                        '    If IsDBNull(tmpdt.Rows(i)("Data")) = False Then

                        '        img = New PictureBox
                        '        img.Size = New Size(200, 200)
                        '        mdlProcess_Office.GetImage(tmpdt.Rows(i)("Data"), img)
                        '        img.Tag = IIf(IsDBNull(tmpdt.Rows(0)("ID")), 0, tmpdt.Rows(0)("ID"))
                        '        img.ContextMenuStrip = ContextMenuStrip1
                        '        img.SizeMode = PictureBoxSizeMode.StretchImage
                        '        AddHandler img.DoubleClick, AddressOf img_DoubleClick
                        '        flpPanel.Controls.Add(img)
                        '    End If

                        'Next

                    End If

                    LoadComment()
                    LoadSupportLog()
                    Type = 1
                Else
                    isEdit = False
                    cboFormType.SelectedIndex = 0
                End If
            Else
                cboFormType.SelectedIndex = 10
            End If

            If Type = 0 Then
                dt = LoadClient(0)
            Else
                Dim typeData As Integer = -1

                dt = LoadClient_BySearch(txtName.Text, txtID.Text, 0, typeData)
            End If

            LvList.Items.Clear()
            If dt Is Nothing Then
                Exit Sub
            End If

            '   lblCount.Text = "Total : " & dt.Rows.Count
            Dim itm As ListViewItem
            Dim subitm As ListViewItem.ListViewSubItem

            For i As Integer = 0 To dt.Rows.Count - 1
                itm = New ListViewItem

                itm.Text = LvList.Items.Count + 1

                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = IIf(IsDBNull(dt.Rows(i)("ID")), "", dt.Rows(i)("ID"))
                itm.SubItems.Add(subitm)

                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = IIf(IsDBNull(dt.Rows(i)("RefID")), "", dt.Rows(i)("RefID"))
                itm.SubItems.Add(subitm)

                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = IIf(IsDBNull(dt.Rows(i)("CompanyName")), "", dt.Rows(i)("CompanyName"))
                itm.SubItems.Add(subitm)

                tmpstr = Nothing
                subitm = New ListViewItem.ListViewSubItem
                If IsDBNull(dt.Rows(i)("Address1")) = False AndAlso dt.Rows(i)("Address1") <> "" Then
                    tmpstr += dt.Rows(i)("Address1") & ","
                End If
                If IsDBNull(dt.Rows(i)("Address2")) = False AndAlso dt.Rows(i)("Address2") <> "" Then
                    tmpstr += dt.Rows(i)("Address2") & ","
                End If
                If IsDBNull(dt.Rows(i)("Address3")) = False AndAlso dt.Rows(i)("Address3") <> "" Then
                    tmpstr += dt.Rows(i)("Address3") & ","
                End If
                If IsDBNull(dt.Rows(i)("Postcode")) = False AndAlso dt.Rows(i)("Postcode") <> "" Then
                    tmpstr += dt.Rows(i)("Postcode") & ","
                End If
                If IsDBNull(dt.Rows(i)("City")) = False AndAlso dt.Rows(i)("City") <> "" Then
                    tmpstr += dt.Rows(i)("City") & ","
                End If
                If IsDBNull(dt.Rows(i)("State")) = False AndAlso dt.Rows(i)("State") <> "" Then
                    tmpstr += dt.Rows(i)("State") & ","
                End If
                If IsDBNull(dt.Rows(i)("Country")) = False AndAlso dt.Rows(i)("Country") <> "" Then
                    tmpstr += dt.Rows(i)("Country") & ","
                End If
                subitm.Text = tmpstr
                itm.SubItems.Add(subitm)

                tmpstr = Nothing
                subitm = New ListViewItem.ListViewSubItem
                If IsDBNull(dt.Rows(i)("License_Enterprise")) = False AndAlso dt.Rows(i)("License_Enterprise") = 1 Then
                    tmpstr += "Enterprise,"
                ElseIf IsDBNull(dt.Rows(i)("License_Enterprise")) = False AndAlso dt.Rows(i)("License_Enterprise") = 2 Then
                    tmpstr += "Enterprise C+,"
                ElseIf IsDBNull(dt.Rows(i)("License_Enterprise")) = False AndAlso dt.Rows(i)("License_Enterprise") = 3 Then
                    tmpstr += "Enterprise B+,"
                End If

                If IsDBNull(dt.Rows(i)("License_SmallBusiness")) = False AndAlso dt.Rows(i)("License_SmallBusiness") = 1 Then
                    tmpstr += "Small Business,"
                ElseIf IsDBNull(dt.Rows(i)("License_SmallBusiness")) = False AndAlso dt.Rows(i)("License_SmallBusiness") = 2 Then
                    tmpstr += "Small Business C+,"
                ElseIf IsDBNull(dt.Rows(i)("License_SmallBusiness")) = False AndAlso dt.Rows(i)("License_SmallBusiness") = 3 Then
                    tmpstr += "Small Business B+,"
                End If

                If IsDBNull(dt.Rows(i)("License_Lite")) = False AndAlso dt.Rows(i)("License_Lite") = 1 Then
                    tmpstr += "Lite,"
                ElseIf IsDBNull(dt.Rows(i)("License_Lite")) = False AndAlso dt.Rows(i)("License_Lite") = 2 Then
                    tmpstr += "Lite C+,"
                ElseIf IsDBNull(dt.Rows(i)("License_Lite")) = False AndAlso dt.Rows(i)("License_Lite") = 3 Then
                    tmpstr += "Lite B+,"
                End If

                If IsDBNull(dt.Rows(i)("License_Education")) = False AndAlso dt.Rows(i)("License_Education") = 1 Then
                    tmpstr += "Education,"
                End If
                If IsDBNull(dt.Rows(i)("License_Trial")) = False AndAlso dt.Rows(i)("License_Trial") = 1 Then
                    tmpstr += "Trial,"
                End If
                If IsDBNull(dt.Rows(i)("License_SQL_En")) = False AndAlso dt.Rows(i)("License_SQL_En") = 1 Then
                    tmpstr += "SQL,"
                End If
                subitm.Text = tmpstr
                itm.SubItems.Add(subitm)

                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = IIf(IsDBNull(dt.Rows(i)("Phone1")), "", dt.Rows(i)("Phone1"))
                itm.SubItems.Add(subitm)

                If IsDBNull(dt.Rows(i)("isBan")) = False AndAlso dt.Rows(i)("isBan") = 1 Then
                    itm.BackColor = Color.HotPink
                Else
                    itm.BackColor = Color.White
                End If

                LvList.Items.Add(itm)
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadSupportLog()
        Try
            Dim dt As DataTable = Nothing
            dt = mdlProcess_Office.LoadSupportLog_BySupportID(ID)

            Dim itm As ListViewItem
            Dim subitm As ListViewItem.ListViewSubItem
            lvLog.Items.Clear()
            If dt IsNot Nothing Then
                lvLog.BeginUpdate 
                For i As Integer = 0 To dt.Rows.Count - 1
                    itm = New ListViewItem

                    itm.Text = LvList.Items.Count + 1

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("ID")), "", dt.Rows(i)("ID"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("SupportID")), 0, dt.Rows(i)("SupportID"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = mdlProcess_Office.ConvertDateTimeToFacebookDateTime(IIf(IsDBNull(dt.Rows(i)("DateTime")), Now, dt.Rows(i)("DateTime")))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("Username")), "", dt.Rows(i)("Username"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("LogData")), Now, dt.Rows(i)("LogData"))
                    itm.SubItems.Add(subitm)

                    lvLog.Items.Add(itm)
                Next
                lvLog.EndUpdate()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadComment()
        Try
            Dim dt As DataTable = Nothing

            dt = mdlProcess_Office.LoadComment_BySupportID(ID)

            flpMain.Controls.Clear()
            If dt Is Nothing Then
                Exit Sub
            End If

            TabControl1.TabPages(1).Text = "Comment(s) +" & dt.Rows.Count
            Dim PnlWrp As Panel
            Dim PnlCont As Panel
            Dim lblUserName As Label
            Dim lblDateTime As Label
            Dim txtMsg As RichTextBox
            Dim sizepnl As Integer = 70
            Dim m_name As String = Nothing
            Dim m_message As String = Nothing
            Dim m_datetime As DateTime = Now
            For i As Integer = 0 To dt.Rows.Count - 1
                m_name = IIf(IsDBNull(dt.Rows(i)("Username")), "", dt.Rows(i)("Username"))
                m_message = IIf(IsDBNull(dt.Rows(i)("Message")), "", dt.Rows(i)("Message"))
                m_datetime = IIf(IsDBNull(dt.Rows(i)("DateTime")), Now, dt.Rows(i)("DateTime"))
                If m_name.ToLower <> My.Computer.Name.ToLower Then
                    PnlWrp = New Panel

                    PnlCont = New Panel
                    PnlCont.Location = New Point(0, 0)
                    PnlCont.BackColor = Color.White

                    lblUserName = New Label
                    lblUserName.Text = m_name
                    lblUserName.ForeColor = Color.Black
                    lblUserName.Location = New Point(9, 10)
                    lblUserName.Size = New System.Drawing.Size(331, 13)
                    lblUserName.TextAlign = ContentAlignment.MiddleLeft
                    lblUserName.Font = New Font("Tahoma", 8.25F, FontStyle.Bold)

                    lblDateTime = New Label
                    lblDateTime.Name = "lbldt" & Format(m_datetime, "ddMMyyyyHHmmsss")
                    lblDateTime.Text = ConvertDateTimeToFacebookDateTime(m_datetime)
                    lblDateTime.ForeColor = Color.Black
                    lblDateTime.Location = New Point(630, 10)
                    lblDateTime.Size = New System.Drawing.Size(201, 16)
                    lblDateTime.TextAlign = ContentAlignment.MiddleRight

                    txtMsg = New RichTextBox
                    txtMsg.Text = m_message
                    txtMsg.Location = New Point(9, 37)
                    txtMsg.BackColor = Color.White
                    txtMsg.ReadOnly = True
                    txtMsg.BorderStyle = BorderStyle.None

                    Dim rtbSize As New Size(TextRenderer.MeasureText(txtMsg.Text, txtMsg.Font, txtMsg.Size, TextFormatFlags.WordBreak))

                    sizepnl = rtbSize.Height

                    txtMsg.Size = New System.Drawing.Size(535, sizepnl)
                    PnlWrp.Size = New System.Drawing.Size(1300, sizepnl + 10)
                    PnlCont.Size = New System.Drawing.Size(850, sizepnl + 10)

                    PnlCont.Controls.Add(lblUserName)
                    PnlCont.Controls.Add(lblDateTime)
                    PnlCont.Controls.Add(txtMsg)


                    PnlCont.AutoSize = True
                    PnlCont.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                    PnlWrp.AutoSize = True
                    PnlWrp.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                    PnlWrp.Controls.Add(PnlCont)

                Else
                    PnlWrp = New Panel

                    PnlCont = New Panel

                    PnlCont.Location = New Point(430, 0)
                    PnlCont.BackColor = Color.FromArgb(220, 248, 198)

                    lblUserName = New Label
                    lblUserName.Text = m_name
                    lblUserName.ForeColor = Color.Red
                    lblUserName.Location = New Point(9, 10)
                    lblUserName.Size = New System.Drawing.Size(331, 16)
                    lblUserName.TextAlign = ContentAlignment.MiddleLeft
                    lblUserName.Font = New Font("Tahoma", 8.25F, FontStyle.Bold)


                    lblDateTime = New Label
                    lblDateTime.Name = "lbldt" & Format(m_datetime, "ddMMyyyyHHmmsss")
                    lblDateTime.Text = ConvertDateTimeToFacebookDateTime(m_datetime)
                    lblDateTime.ForeColor = Color.Black
                    lblDateTime.Location = New Point(630, 10)
                    lblDateTime.Size = New System.Drawing.Size(201, 16)
                    lblDateTime.TextAlign = ContentAlignment.MiddleRight

                    txtMsg = New RichTextBox
                    txtMsg.Text = m_message
                    txtMsg.Location = New Point(9, 37)
                    txtMsg.BackColor = Color.FromArgb(220, 248, 198)
                    txtMsg.ReadOnly = True
                    txtMsg.BorderStyle = BorderStyle.None


                    Dim rtbSize As New Size(TextRenderer.MeasureText(txtMsg.Text, txtMsg.Font, txtMsg.Size, TextFormatFlags.WordBreak))

                    sizepnl = rtbSize.Height

                    txtMsg.Size = New System.Drawing.Size(535, sizepnl)
                    PnlWrp.Size = New System.Drawing.Size(1300, sizepnl + 10)
                    PnlCont.Size = New System.Drawing.Size(850, sizepnl + 10)

                    PnlCont.Controls.Add(lblUserName)
                    PnlCont.Controls.Add(lblDateTime)
                    PnlCont.Controls.Add(txtMsg)


                    PnlCont.AutoSize = True
                    PnlCont.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                    PnlWrp.AutoSize = True
                    PnlWrp.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                    PnlWrp.Controls.Add(PnlCont)

                End If

                flpMain.Controls.Add(PnlWrp)
                flpMain.VerticalScroll.Value = flpMain.VerticalScroll.Maximum
            Next

            If TabControl1.SelectedIndex = 1 Then
                txtMessage.Focus()
                txtMessage.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmSupport_Add_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
                If LvList.Items.Count > 0 Then
                    txtRefID.Text = LvList.Items(0).SubItems(1).Text
                    txtComName.Text = LvList.Items(0).SubItems(3).Text

                    If LvList.Items(0).BackColor = Color.HotPink Then
                        txtComName.BackColor = Color.HotPink
                    Else
                        txtComName.BackColor = Color.LightGray
                    End If

                    txtTVID.Focus()
                    cboStatus.SelectedIndex = 0
                End If
            ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Alt Then
                btnSave.PerformClick()
            ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then
                btnSaveRemote.PerformClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmSupport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()

    End Sub

    Private Sub txtName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtName.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                LoadData(1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtID_KeyUp(sender As Object, e As KeyEventArgs) Handles txtID.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                LoadData(1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTVID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTVID.KeyPress
        Try
            numbervalidation_Decimal(e)
        Catch ex As Exception

        End Try
    End Sub
    Private Function isValid() As Boolean
        Try
            If txtRefID.TextLength = 0 Then
                MsgBox("Please select company.", MsgBoxStyle.Exclamation)
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSaveRemote_Click(sender As Object, e As EventArgs) Handles btnSaveRemote.Click
        Try
            isRemote = True
            Application.DoEvents()
            btnSave.PerformClick()
            Dim p As New ProcessStartInfo

            ' Specify the location of the binary
            If Environment.Is64BitOperatingSystem Then
                p.FileName = "C:\Program Files (x86)\TeamViewer\Version9\TeamViewer.exe"
            Else
                p.FileName = "C:\Program Files\TeamViewer\Version9\TeamViewer.exe"
            End If


            ' Use these arguments for the process
            p.Arguments = "-i " & txtTVID.Text & " -P " & txtTVPass.Text

            ' Use a hidden window
            p.WindowStyle = ProcessWindowStyle.Normal

            Process.Start(p)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTVID_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTVID.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTVPass_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTVPass.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub img_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim pic As PictureBox = DirectCast(sender, PictureBox)

            Dim frm As New frmPictureView
            frm.Image = pic.Image
            frm.LoadData()
            frm.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSentMessage_Click(sender As Object, e As EventArgs) Handles btnSentMessage.Click
        Try
            Dim ReturnID As Integer = 0

            If isEdit = True Then
                If mdlProcess_Office.SaveComment(ID, txtMessage.Text, 0) Then
                    mdlProcess_Office.SendNotification("New comment from support " & txtComName.Text & " " & txtMessage.Text)
                    LoadComment()
                End If
            Else
                MsgBox("You cannot sent comment until you save this support data.", MsgBoxStyle.Exclamation)
            End If
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMessage_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMessage.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                btnSentMessage.PerformClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.AppStarting
            pnlLoading.BackColor = Color.White

            pnlLoading.Dock = DockStyle.Fill
            pnlLoading.Visible = True
            Application.DoEvents()
            If isValid() Then

                If isEdit Then

                    If mdlProcess_Office.UpdateSupport(ID, txtRefID.Text, txtTVID.Text, txtTVPass.Text, txtPerson.Text, txtProblem.Text, _
                                                     txtNote.Text, cboStatus.SelectedIndex, cboFormType.SelectedIndex, txtRefNoPayer.Text, IIf(IsNumeric(txtYA) = False, 0, CInt(txtYA.Text)), flpPanel, ErrorLog) Then
                        MsgBox("Successfully updated your data.", MsgBoxStyle.Information)
                        If isRemote = True Then
                            Me.Close()
                        Else
                            isRemote = False
                        End If
                    Else
                        MsgBox("Unsuccessfully update data." & vbCrLf & ErrorLog.ErrorMessage, MsgBoxStyle.Critical)
                    End If
                Else
                    If mdlProcess_Office.SaveSupport(txtRefID.Text, txtTVID.Text, txtTVPass.Text, txtPerson.Text, txtProblem.Text, _
                                                     txtNote.Text, cboStatus.SelectedIndex, cboFormType.SelectedIndex, txtRefNoPayer.Text, IIf(IsNumeric(txtYA) = False, 0, CInt(txtYA.Text)), flpPanel, ErrorLog) Then
                        MsgBox("Successfully saved your data.", MsgBoxStyle.Information)
                        Me.Close()
                        
                    Else
                        MsgBox("Unsuccessfully save data." & vbCrLf & ErrorLog.ErrorMessage, MsgBoxStyle.Critical)
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        Finally
            pnlLoading.Dock = DockStyle.None
            pnlLoading.Visible = False
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.SelectedIndex = 1 Then
                txtMessage.Focus()
                txtMessage.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFind_Click_1(sender As Object, e As EventArgs) Handles btnFind.Click
        LoadData(1)
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        LoadData()

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub RemoveImageToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RemoveImageToolStripMenuItem.Click
        Try
            Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
            Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

            If cms IsNot Nothing Then
                For i As Integer = 0 To flpPanel.Controls.Count - 1
                    If flpPanel.Controls(i).Tag = cms.SourceControl.Tag Then
                        flpPanel.Controls.RemoveAt(i)   'Here you actually provide the index!
                    End If
                Next
            End If
            '  MessageBox.Show(cms.SourceControl.Tag)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFindAttachment_Click_1(sender As Object, e As EventArgs) Handles btnFindAttachment.Click
        Try
            OFDGallery_UploadImg.Filter = "Image jpg/png|*.jpg;*.png;"
            If OFDGallery_UploadImg.ShowDialog <> Windows.Forms.DialogResult.Cancel AndAlso OFDGallery_UploadImg.FileName IsNot Nothing Then
                Me.Cursor = Cursors.AppStarting
                Dim imagex As Bitmap = Nothing
                '    Dim vm As AxWMPLib.AxWindowsMediaPlayer
                For Each tmp As String In OFDGallery_UploadImg.FileNames

                    If flpPanel.Controls.Count > 4 Then
                        MsgBox("Maximum you can add only 5", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If

                    imagex = Nothing
                    imagex = Image.FromFile(tmp)

                    If imagex IsNot Nothing Then
                        Dim img As New PictureBox
                        img.Image = imagex
                        img.Size = New Size(150, 150)
                        img.Tag = tmp
                        img.ContextMenuStrip = ContextMenuStrip1
                        img.SizeMode = PictureBoxSizeMode.StretchImage
                        AddHandler img.DoubleClick, AddressOf img_DoubleClick
                        flpPanel.Controls.Add(img)
                    End If


                Next

            End If


        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()
            Cursor = Cursors.AppStarting
            Application.DoEvents()

            Dim tmpdt As DataTable = Nothing
            tmpdt = mdlProcess_Office.LoadSupportAttachment_ByID(ID)

            If tmpdt IsNot Nothing Then
                Dim img As New PictureBox
                For i As Integer = 0 To tmpdt.Rows.Count - 1

                    If IsDBNull(tmpdt.Rows(i)("Data")) = False Then

                        If IsDBNull(tmpdt.Rows(i)("Type")) = False AndAlso tmpdt.Rows(i)("Type") = 0 Then
                            img = New PictureBox
                            img.Size = New Size(150, 150)
                            mdlProcess_Office.GetImage(tmpdt.Rows(i)("Data"), img)
                            img.Tag = IIf(IsDBNull(tmpdt.Rows(i)("ID")), 0, tmpdt.Rows(i)("ID"))
                            img.ContextMenuStrip = ContextMenuStrip1
                            img.SizeMode = PictureBoxSizeMode.StretchImage
                            AddHandler img.DoubleClick, AddressOf img_DoubleClick
                            flpPanel.Controls.Add(img)

                        End If

                    End If
                    GC.Collect()
                Next

            End If

        Catch ex As Exception

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LvList_DoubleClick1(sender As Object, e As EventArgs) Handles LvList.DoubleClick
        Try
            For i As Integer = 0 To LvList.Items.Count - 1
                If LvList.Items(i).Selected Then
                    txtRefID.Text = LvList.Items(i).SubItems(1).Text
                    txtComName.Text = LvList.Items(i).SubItems(3).Text

                    If LvList.Items(i).BackColor = Color.HotPink Then
                        txtComName.BackColor = Color.HotPink
                    Else
                        txtComName.BackColor = Color.LightGray
                    End If

                    txtTVID.Focus()
                    cboStatus.SelectedIndex = 0

                    If txtRefID.Text <> "" Then
                        Dim tmpdt As DataTable = mdlProcess_Office.LoadPreviousTeamviewerID(txtRefID.Text)

                        If tmpdt IsNot Nothing Then

                            For x As Integer = 0 To tmpdt.Rows.Count - 1
                                If IsDBNull(tmpdt.Rows(x)("Datax")) = False Then
                                    txtTVID.AutoCompleteCustomSource.Add(tmpdt.Rows(x)("Datax"))
                                End If
                            Next

                        End If
                        Application.DoEvents()
                        tmpdt = mdlProcess_Office.LoadPreviousPersonNameID(txtRefID.Text)

                        If tmpdt IsNot Nothing Then

                            For x As Integer = 0 To tmpdt.Rows.Count - 1
                                If IsDBNull(tmpdt.Rows(x)("Datax")) = False Then
                                    txtPerson.AutoCompleteCustomSource.Add(tmpdt.Rows(x)("Datax"))
                                End If
                            Next

                        End If
                    End If

                    lblTypeCompany.Text = "Version " & LvList.Items(i).SubItems(5).Text
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtYA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtYA.KeyPress
        numbervalidation_Decimal(e)
    End Sub

    Private Sub txtYA_KeyUp(sender As Object, e As KeyEventArgs) Handles txtYA.KeyUp
        Try
            If txtYA.TextLength = 0 Then
                txtYA.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cboFormType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFormType.SelectedIndexChanged
        Try
            If isAllowChangeTypeForm(cboFormType.SelectedIndex, isSQLVersion) = False Then
                Dim tmpResult As DialogResult = MessageBox.Show("Are you sure want to change form type?", "", MessageBoxButtons.YesNo)

                If tmpResult = Windows.Forms.DialogResult.No Then
                    cboFormType.SelectedIndex = 10
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class