Imports System.Net
Imports System.Net.FtpClient
Imports System.IO
Imports WinSCP
Imports System.ComponentModel

Public Class frmCreatePackage
    Dim ListofFile As String = Nothing
    Dim isCancel As Boolean = False
    Public Tick As Image = My.Resources.Tick1
    Public UnTick As Image = My.Resources.Untick1

    Private Sub frmCreatePackage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If My.Settings.DestinationFolder IsNot Nothing AndAlso My.Settings.DestinationFolder <> "" Then
                txtDestinationPackage.Text = My.Settings.DestinationFolder
            Else
                txtDestinationPackage.Text = Application.StartupPath
            End If

            If My.Settings.EnterpriseFolder IsNot Nothing AndAlso My.Settings.EnterpriseFolder <> "" Then
                txtEnterpriseFolder.Text = My.Settings.EnterpriseFolder
            End If

            If My.Settings.SmallFolder IsNot Nothing AndAlso My.Settings.SmallFolder <> "" Then
                txtSmallFolder.Text = My.Settings.SmallFolder
            End If

            If My.Settings.LiteFolder IsNot Nothing AndAlso My.Settings.LiteFolder <> "" Then
                txtLiteFolder.Text = My.Settings.LiteFolder
            End If

            If My.Settings.EducationFolder IsNot Nothing AndAlso My.Settings.EducationFolder <> "" Then
                txtEducationFolder.Text = My.Settings.EducationFolder
            End If

            If My.Settings.Enterprise_Upload IsNot Nothing AndAlso My.Settings.Enterprise_Upload <> "" Then
                txtHost_Enterprise.Text = My.Settings.Enterprise_Upload
            End If

            If My.Settings.Small_Upload IsNot Nothing AndAlso My.Settings.Small_Upload <> "" Then
                txtHost_Small.Text = My.Settings.Small_Upload
            End If

            If My.Settings.Lite_Upload IsNot Nothing AndAlso My.Settings.Lite_Upload <> "" Then
                txtHost_Lite.Text = My.Settings.Lite_Upload
            End If

            If My.Settings.Education_Upload IsNot Nothing AndAlso My.Settings.Education_Upload <> "" Then
                txtHost_Education.Text = My.Settings.Education_Upload
            End If

            If My.Settings.HostName IsNot Nothing AndAlso My.Settings.HostName <> "" Then
                txtHostName.Text = My.Settings.HostName
            End If

            If My.Settings.HostUser IsNot Nothing AndAlso My.Settings.HostUser <> "" Then
                txtHostUser.Text = My.Settings.HostUser
            End If

            If My.Settings.HostPassword IsNot Nothing AndAlso My.Settings.HostPassword <> "" Then
                txtHostPassword.Text = My.Settings.HostPassword
            End If

            If My.Settings.HostPort IsNot Nothing AndAlso My.Settings.HostPort <> "" Then
                txtHostPort.Text = My.Settings.HostPort
            End If

            If My.Settings.FileName IsNot Nothing AndAlso My.Settings.FileName <> "" Then
                txtFileName.Text = My.Settings.FileName
            End If

            If My.Settings.Title IsNot Nothing AndAlso My.Settings.Title <> "" Then
                txtTitle.Text = My.Settings.Title
            End If

            If My.Settings.ChangeLog IsNot Nothing AndAlso My.Settings.ChangeLog <> "" Then
                txtChangeLog.Text = My.Settings.ChangeLog
            End If

            If My.Settings.emailtemplate IsNot Nothing AndAlso My.Settings.emailtemplate <> "" Then
                txtEmailTemplate.Text = My.Settings.emailtemplate
            End If

            If My.Settings.mailsetting IsNot Nothing AndAlso My.Settings.mailsetting <> "" Then
                txtEmailSetting.Text = My.Settings.mailsetting
            End If

            If My.Settings.mailpassword IsNot Nothing AndAlso My.Settings.mailpassword <> "" Then
                txtEmailSetting_Pass.Text = mdlProcess_Office.DecriptPass(My.Settings.mailpassword)
            End If

            If My.Settings.ieVersion IsNot Nothing AndAlso My.Settings.ieVersion <> "" Then
                txtIEToolbarVersion.Text = My.Settings.ieVersion
            End If
            If My.Settings.emailtemplateOther IsNot Nothing AndAlso My.Settings.emailtemplateOther <> "" Then
                txtOtherTemplate_Email.Text = My.Settings.emailtemplateOther
            End If

            picLoading.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LogData(ByVal LogData As String, Optional ByVal Type As Integer = 0)
        Try
            If lbLog.Items.Count >= 11 Then
                lbLog.Items.RemoveAt(lbLog.Items.Count - 1)
            End If

            lbLog.Items.Insert(0, Format(Now, "HH:mm:ss") & " := " & LogData)

            Application.DoEvents()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LogData2(ByVal LogData As String, ListofData As List(Of String), Optional ByVal Type As Integer = 0)
        Try

            For i As Integer = 0 To ListofData.Count - 1
                lbLog2.Items.Insert(0, LogData & " || " & Format(Now, "HH:mm:ss") & " := " & ListofData(i))
            Next

            Application.DoEvents()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnHostTest_Click_1(sender As Object, e As EventArgs) Handles btnHostTest.Click
        FTPConnected()
    End Sub
    Private Sub FTPConnected(Optional ByVal Type As Integer = 0)
        Try
            LogData("Trying to connection")

            Dim itm As ListViewItem
            Dim subitm As ListViewItem.ListViewSubItem
            Dim tmpSplit() As String = Nothing
            Using ftp = New FtpClient()
                ftp.Host = txtHostName.Text
                ftp.Credentials = New NetworkCredential(txtHostUser.Text, txtHostPassword.Text)
                LogData("Successfully connected.")


                If Type = 1 Then
                    For i As Integer = 0 To LvHostDirectory.Items.Count - 1
                        If LvHostDirectory.Items(i).Selected Then
                            ftp.SetWorkingDirectory(LvHostDirectory.Items(i).SubItems(3).Text)
                        End If
                    Next

                ElseIf Type = 2 Then
                    ftp.SetWorkingDirectory(txtHostCurrentURL.Text)
                ElseIf Type = 3 Then
                    If LvHostDirectory.Items.Count > 0 Then
                        ftp.SetWorkingDirectory(LvHostDirectory.Items(0).SubItems(3).Text)
                    End If
                End If

                txtHostCurrentURL.Text = ftp.GetWorkingDirectory

                LogData("Open Directory " & ftp.GetWorkingDirectory)
                LvHostDirectory.Items.Clear()
                lvHostFile.Items.Clear()


                itm = New ListViewItem

                itm.Text = "..."


                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = ""
                itm.SubItems.Add(subitm)

                subitm = New ListViewItem.ListViewSubItem
                subitm.Text = ""
                itm.SubItems.Add(subitm)

                subitm = New ListViewItem.ListViewSubItem
                tmpSplit = txtHostCurrentURL.Text.Split("/")
                If tmpSplit.Length > 0 Then
                    For i As Integer = 0 To tmpSplit.Length - 1
                        If i <> (tmpSplit.Length - 1) Then
                            subitm.Text = "/" & tmpSplit(i)
                        End If
                    Next
                End If

                itm.SubItems.Add(subitm)

                LvHostDirectory.Items.Add(itm)

                For Each item In ftp.GetListing(ftp.GetWorkingDirectory())

                    itm = New ListViewItem

                    itm.Text = item.Name


                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = item.Size.ToString
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = Format(item.Modified, "dd-MMM-yyyy HH:mm:ss")
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = item.FullName
                    itm.SubItems.Add(subitm)

                    Select Case item.Type
                        Case FtpFileSystemObjectType.Directory
                            LvHostDirectory.Items.Add(itm)
                        Case FtpFileSystemObjectType.File
                            lvHostFile.Items.Add(itm)
                    End Select

                Next

            End Using

        Catch ex As Exception
            LogData("Failed " & ex.Message)
        End Try
    End Sub
    Private Sub txtHostCurrentURL_KeyUp(sender As Object, e As KeyEventArgs) Handles txtHostCurrentURL.KeyUp
        If e.KeyCode = Keys.Enter Then
            FTPConnected(2)
        End If
    End Sub
    Private Sub LvHostDirectory_DoubleClick(sender As Object, e As EventArgs) Handles LvHostDirectory.DoubleClick
        FTPConnected(1)
    End Sub
    Private Sub SetAsEnterpriseFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAsEnterpriseFolderToolStripMenuItem.Click
        SetUploadFolderDirectory(0)
    End Sub
    Private Sub SetUploadFolderDirectory(ByVal Type As Integer)
        Try
            For i As Integer = 0 To LvHostDirectory.Items.Count - 1
                If LvHostDirectory.Items(i).Selected = True Then
                    Select Case Type
                        Case 0
                            txtHost_Enterprise.Text = LvHostDirectory.Items(i).SubItems(3).Text
                        Case 1
                            txtHost_Small.Text = LvHostDirectory.Items(i).SubItems(3).Text
                        Case 2
                            txtHost_Lite.Text = LvHostDirectory.Items(i).SubItems(3).Text
                        Case 3
                            txtHost_Education.Text = LvHostDirectory.Items(i).SubItems(3).Text
                    End Select
                End If

            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAsToolStripMenuItem.Click
        SetUploadFolderDirectory(1)
    End Sub
    Private Sub SetAsLiteFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAsLiteFolderToolStripMenuItem.Click
        SetUploadFolderDirectory(2)
    End Sub
    Private Sub SetAsEducationFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAsEducationFolderToolStripMenuItem.Click
        SetUploadFolderDirectory(3)
    End Sub
    Private Sub BackToRootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToRootToolStripMenuItem.Click
        FTPConnected(0)
    End Sub
    Private Sub BackToParentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToParentToolStripMenuItem.Click
        FTPConnected(3)
    End Sub
    Private Sub btnEnterpriseFolder_Click(sender As Object, e As EventArgs) Handles btnEnterpriseFolder.Click
        FolderBrowser(0)
    End Sub
    Private Sub btnSmallFolder_Click(sender As Object, e As EventArgs) Handles btnSmallFolder.Click
        FolderBrowser(1)
    End Sub
    Private Sub btnLiteFolder_Click(sender As Object, e As EventArgs) Handles btnLiteFolder.Click
        FolderBrowser(2)
    End Sub
    Private Sub btnEducationFolder_Click(sender As Object, e As EventArgs) Handles btnEducationFolder.Click
        FolderBrowser(3)
    End Sub
    Private Sub btnDestinationPackage_Click(sender As Object, e As EventArgs) Handles btnDestinationPackage.Click
        FolderBrowser(4)
    End Sub
    Private Sub FolderBrowser(ByVal Type As Integer)
        Try

            Dim folderDlg As New FolderBrowserDialog

            folderDlg.ShowNewFolderButton = True

            If (folderDlg.ShowDialog() = DialogResult.OK) Then

                If System.IO.File.Exists(folderDlg.SelectedPath) Then
                    Select Case Type
                        Case 0
                            txtEnterpriseFolder.Text = folderDlg.SelectedPath
                            My.Settings.EnterpriseFolder = folderDlg.SelectedPath

                        Case 1
                            txtSmallFolder.Text = folderDlg.SelectedPath
                            My.Settings.SmallFolder = folderDlg.SelectedPath
                        Case 2
                            txtLiteFolder.Text = folderDlg.SelectedPath
                            My.Settings.LiteFolder = folderDlg.SelectedPath
                        Case 3
                            txtEducationFolder.Text = folderDlg.SelectedPath
                            My.Settings.EducationFolder = folderDlg.SelectedPath
                        Case 4
                            txtDestinationPackage.Text = folderDlg.SelectedPath
                            My.Settings.DestinationFolder = folderDlg.SelectedPath
                    End Select

                    My.Settings.Save()
                    My.Settings.Reload()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub
    Private Sub chkAdvance_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdvance.CheckedChanged
        TabControl1.Enabled = chkAdvance.Checked
    End Sub
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        StartPackage()
    End Sub
    Private Sub StartPackage()
        Try
            picLoading.Visible = True
            picLoading.Dock = DockStyle.Fill
            lblStage.Text = "Create EXE Package"
            btnStart.Enabled = False
            btnSetting.Enabled = False
            btnSentEmail.Enabled = False
            Application.DoEvents()

            LogData("Initialize folder and file.")

            If txtEnterpriseFolder.Text = "" OrElse System.IO.Directory.Exists(txtEnterpriseFolder.Text) = False Then
                picEnterpriseStatus_Folder.Image = UnTick
            Else
                picEnterpriseStatus_Folder.Image = Tick
            End If

            If txtSmallFolder.Text = "" OrElse System.IO.Directory.Exists(txtSmallFolder.Text) = False Then
                picSmallStatus_Folder.Image = UnTick
            Else
                picSmallStatus_Folder.Image = Tick
            End If

            If txtLiteFolder.Text = "" OrElse System.IO.Directory.Exists(txtLiteFolder.Text) = False Then
                picLiteStatus.Image = UnTick
            Else
                picLiteStatus.Image = Tick
            End If

            If txtEducationFolder.Text = "" OrElse System.IO.Directory.Exists(txtEducationFolder.Text) = False Then
                picEducationStatus_Folder.Image = UnTick
            Else
                picEducationStatus_Folder.Image = Tick
            End If

            If txtDestinationPackage.Text = "" OrElse System.IO.Directory.Exists(txtDestinationPackage.Text) = False Then
                picDestinationPackage.Image = UnTick
                MsgBox("Destination folder is not exist.", MsgBoxStyle.Critical)
                Exit Sub
            Else
                picDestinationPackage.Image = Tick
            End If

            LogData("Initialize folder and file complete.")
            CreatePackage()


            LogData("Creating Package Complete")

            If chkAdvance.Checked = True AndAlso chkUploadToServer.Checked = True Then
                lblStage.Text = "Upload To Server"
                Application.DoEvents()
                LogData("Ready to upload file to server.")
                If txtHostUser.TextLength = 0 OrElse txtHostUser.TextLength = 0 OrElse txtHostPassword.TextLength = 0 Then
                    LogData("Host not valid")
                    Exit Sub
                End If

                Dim tmpFile As String = Nothing
                Dim tmpHost As String = Nothing


                ' Recurse into subdirectories of this directory.


                Dim IndexExeMdl As Integer = 0
                For i As Integer = 0 To 3
                    tmpFile = Nothing

                    Select Case i
                        Case 0
                            If txtHost_Enterprise.TextLength > 0 Then

                                tmpFile = txtDestinationPackage.Text & "\Output\" & txtFileName.Text & "\Enterprise"
                                tmpHost = "ftp://" & txtHostName.Text & ":21/" & txtHost_Enterprise.Text & "/"
                            End If
                        Case 1
                            If txtHost_Small.TextLength > 0 Then
                                tmpFile = txtDestinationPackage.Text & "\Output\" & txtFileName.Text & "\SmallBusiness"
                                tmpHost = "ftp://" & txtHostName.Text & ":21/" & txtHost_Small.Text & "/"
                            End If
                        Case 2
                            If txtHost_Lite.TextLength > 0 Then
                                tmpFile = txtDestinationPackage.Text & "\Output\" & txtFileName.Text & "\Lite"
                                tmpHost = "ftp://" & txtHostName.Text & ":21/" & txtHost_Lite.Text & "/"
                            End If
                        Case 2
                            If txtHost_Education.TextLength > 0 Then
                                tmpFile = txtDestinationPackage.Text & "\Output\" & txtFileName.Text & "\Education"
                                tmpHost = "ftp://" & txtHostName.Text & ":21/" & txtHost_Education.Text & "/"
                            End If
                    End Select

                    If tmpFile IsNot Nothing Then
                        IndexExeMdl = 0
                        lblStatusLog2.Text = "0/" & Directory.GetFiles(tmpFile).Length & " Completed Files Upload"
                        Dim di As New IO.DirectoryInfo(tmpFile)
                        Dim diar1 As IO.FileInfo() = di.GetFiles()
                        Dim dra As IO.FileInfo
                        For Each dra In diar1
                            LogData("Progress to upload " & dra.Name)
                            lblStatusLog2.Text = "Current File is " & dra.Name & " ||  " & IndexExeMdl & "/" & Directory.GetFiles(tmpFile).Length & "Files"
                            Application.DoEvents()
                            UploadFile(dra.FullName, tmpHost & dra.Name, txtHostUser.Text, txtHostPassword.Text)
                            IndexExeMdl += 1

                        Next

                    End If

                Next
            End If
          
            If chkAdvance.Checked = True AndAlso chkCreateWebsite.Checked = True Then

                If chkWebEn.Checked = True Then
                    Dim Web As String = ""
                End If

            End If

            btnSaveSetting.PerformClick()

        Catch ex As Exception

        Finally
            btnSentEmail.Enabled = True
            btnStart.Enabled = True
            btnSetting.Enabled = True
            picLoading.Visible = False
            Application.DoEvents()
        End Try
    End Sub
    Private Sub CreatePackage()
        Try
            Dim tmpURl As String = Nothing
            Dim tmpScript As String = Nothing

            For i As Integer = 0 To 3
                ListofFile = Nothing
                lblStatusLog.Text = "Status : " & (i + 1) & "/4 Create Package"

                If isCancel Then
                    CancelJob()
                    Exit Sub
                End If

                Select Case i
                    Case 0
                        'Enterprise Full
                        LogData("Creating Enterprise Full package")

                        tmpURl = txtEnterpriseFolder.Text
                        ProcessDirectory(tmpURl, 0)
                        Application.DoEvents()

                        If writeTxt(Application.StartupPath, "list.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        'tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list.txt"), 0) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list.txt"), 0) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)
                        Application.DoEvents()

                        'Enterprise C+ Only
                        LogData("Creating Enterprise C+")
                        ListofFile = Nothing
                        ProcessDirectory(tmpURl, 1)

                        If writeTxt(Application.StartupPath, "list_C.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "C" & txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list_C.txt"), 0) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        '  tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "C" & txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list_C.txt"), 0) = False Then
                            Exit For
                        End If
                        System.Threading.Thread.Sleep(10000)

                        'Enterprise B+ Only
                        LogData("Creating Enterprise B+")
                        ListofFile = Nothing
                        ProcessDirectory(tmpURl, 2)

                        If writeTxt(Application.StartupPath, "list_B.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "B" & txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list_B.txt"), 0) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "B" & txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list_B.txt"), 0) = False Then
                            Exit For
                        End If
                        System.Threading.Thread.Sleep(10000)
                    Case 1
                        LogData("Creating SmallBusiness")
                        tmpURl = txtSmallFolder.Text

                        ProcessDirectory(tmpURl, 0)
                        Application.DoEvents()

                        If writeTxt(Application.StartupPath, "list.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list.txt"), 1) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list.txt"), 1) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)
                        Application.DoEvents()

                        'SmallBusiness C+ Only
                        LogData("Creating SmallBusiness C+")
                        ListofFile = Nothing
                        ProcessDirectory(tmpURl, 1)

                        If writeTxt(Application.StartupPath, "list_C.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "C" & txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list_C.txt"), 1) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "C" & txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list_C.txt"), 1) = False Then
                            Exit For
                        End If
                        System.Threading.Thread.Sleep(10000)

                        'SmallBusiness B+ Only
                        LogData("Creating SmallBusiness B+")
                        ListofFile = Nothing
                        ProcessDirectory(tmpURl, 2)

                        If writeTxt(Application.StartupPath, "list_B.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "B" & txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list_B.txt"), 1) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        ' tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "B" & txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list_B.txt"), 1) = False Then
                            Exit For
                        End If
                        System.Threading.Thread.Sleep(10000)
                    Case 2
                        tmpURl = txtLiteFolder.Text
                        LogData("Creating Lite")

                        ProcessDirectory(tmpURl, 0)
                        Application.DoEvents()

                        If writeTxt(Application.StartupPath, "list.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        '  tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list.txt"), 2) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        '  tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list.txt"), 2) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)
                        Application.DoEvents()

                        'Lite C+ Only
                        LogData("Creating Lite C+")
                        ListofFile = Nothing
                        ProcessDirectory(tmpURl, 1)

                        If writeTxt(Application.StartupPath, "list_C.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        '  tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "C" & txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list_C.txt"), 2) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        '  tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "C" & txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list_C.txt"), 2) = False Then
                            Exit For
                        End If
                        System.Threading.Thread.Sleep(10000)

                        'Lite B+ Only
                        LogData("Creating Lite B+")
                        ListofFile = Nothing
                        ProcessDirectory(tmpURl, 2)

                        If writeTxt(Application.StartupPath, "list_B.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        '  tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "B" & txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list_B.txt"), 2) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        '   tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, "B" & txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list_B.txt"), 2) = False Then
                            Exit For
                        End If
                        System.Threading.Thread.Sleep(10000)
                    Case 3
                        tmpURl = txtEducationFolder.Text

                        LogData("Creating Education")

                        ProcessDirectory(tmpURl, 0)
                        Application.DoEvents()

                        If writeTxt(Application.StartupPath, "list.txt", ListofFile) = False Then
                            Exit For
                        End If

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files\Taxoffice" & vbCrLf
                        '  tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCrLf
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCrLf
                        tmpScript += txtChangeLog.Text & vbCrLf
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, txtFileName.Text, IO.Path.Combine(Application.StartupPath, "script.txt"), IO.Path.Combine(Application.StartupPath, "list.txt"), 3) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)

                        tmpScript = ";The comment below contains SFX script commands" & vbCrLf
                        tmpScript += "Path=C:\Program Files (x86)\Taxoffice" & vbCrLf
                        '  tmpScript += "SavePath" & vbCrLf
                        tmpScript += "Overwrite=1" & vbCrLf
                        tmpScript += txtTitle.Text & vbCrLf
                        tmpScript += "Text" & vbCrLf
                        tmpScript += "{" & vbCrLf
                        tmpScript += txtFileName.Text & vbCr
                        tmpScript += Format(Now, "dd-MMM-yyyy HH:mm:ss") & vbCr
                        tmpScript += txtChangeLog.Text & vbCr
                        tmpScript += "}" & vbCrLf

                        If writeTxt(Application.StartupPath, "script_x64.txt", tmpScript) = False Then
                            Exit For
                        End If


                        If BuildSFX(txtDestinationPackage.Text, txtFileName.Text & "_x64", IO.Path.Combine(Application.StartupPath, "script_x64.txt"), IO.Path.Combine(Application.StartupPath, "list.txt"), 3) = False Then
                            Exit For
                        End If

                        System.Threading.Thread.Sleep(10000)
                        Application.DoEvents()

                End Select


            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub UploadFile(ByVal _FileName As String, ByVal _UploadPath As String, ByVal _FTPUser As String, ByVal _FTPPass As String)
        Dim _FileInfo As New System.IO.FileInfo(_FileName)

        ' Create FtpWebRequest object from the Uri provided
        Dim _FtpWebRequest As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(New Uri(_UploadPath)), System.Net.FtpWebRequest)

        ' Provide the WebPermission Credintials
        _FtpWebRequest.Credentials = New System.Net.NetworkCredential(_FTPUser, _FTPPass)

        ' By default KeepAlive is true, where the control connection is not closed
        ' after a command is executed.
        _FtpWebRequest.KeepAlive = False

        ' set timeout for 20 seconds
        _FtpWebRequest.Timeout = 20000

        ' Specify the command to be executed.
        _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        ' Specify the data transfer type.
        _FtpWebRequest.UseBinary = True

        ' Notify the server about the size of the uploaded file
        _FtpWebRequest.ContentLength = _FileInfo.Length

        ' The buffer size is set to 2kb
        Dim buffLength As Integer = 2048
        Dim buff(buffLength - 1) As Byte

        ' Opens a file stream (System.IO.FileStream) to read the file to be uploaded
        Using _FileStream As System.IO.FileStream = _FileInfo.OpenRead()

            Try
                ' Stream to which the file to be upload is written
                Using _Stream As System.IO.Stream = _FtpWebRequest.GetRequestStream()
                    ' Read from the file stream 2kb at a time
                    Dim contentLen As Integer = _FileStream.Read(buff, 0, buffLength)
                    Dim tmpStream As Integer = 2048
                    Dim percent As Integer = 0
                    ' Till Stream content ends
                    ProgressBar1.Maximum = _FileStream.Length
                    ProgressBar1.Minimum = 0
                    Do While contentLen <> 0
                        If isCancel Then
                            CancelJob()
                            Exit Sub
                        End If
                        ' Write Content from the file stream to the FTP Upload Stream
                        _Stream.Write(buff, 0, contentLen)
                        contentLen = _FileStream.Read(buff, 0, buffLength)
                        tmpStream += contentLen
                        percent = tmpStream / _FileStream.Length * 100
                        ProgressBar1.Increment(tmpStream)
                        ProgressBar1.Text = tmpStream.ToString("N0") & "/" & _FileStream.Length.ToString("N0") & " bytes " & percent & "%"
                        Application.DoEvents()
                    Loop

                    ' Close the file stream and the Request Stream
                    _Stream.Close()
                    _Stream.Dispose()
                    _FileStream.Close()
                    _FileStream.Dispose()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Using

    End Sub
    Private Sub CancelJob()
        Try
            LogData("Job is cancelled.")
            MsgBox("Job is cancelled.", MsgBoxStyle.Exclamation)
            isCancel = False
        Catch ex As Exception

        End Try
    End Sub
    Private Function ConvertToMBGB(ByVal TheSize As Double) As String
        Try
            Dim DoubleBytes As Double
            Select Case TheSize
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(TheSize / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(TheSize / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(TheSize / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = TheSize ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Me.Close()
            Return ""
        End Try
    End Function
    Private Sub ProcessDirectory(ByVal targetDirectory As String, ByVal Type As Integer)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        ' Process the list of files found in the directory.
        Dim fileName As String
        For Each fileName In fileEntries
            ProcessFile(fileName)

        Next fileName

        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        ' Recurse into subdirectories of this directory.
        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries
            Select Case Type
                Case 0
                    'Full Package
                    ProcessFile(subdirectory)
                Case 1
                    'C only
                    If subdirectory.Contains("Taxoffice Taxcom B+") = False Then
                        ProcessFile(subdirectory)
                    End If
                Case 2
                    'B only
                    If subdirectory.Contains("Taxoffice Taxcom C+") = False Then
                        ProcessFile(subdirectory)
                    End If
            End Select

        Next subdirectory

    End Sub 'ProcessDirectory
    ' Insert logic for processing found files here.
    Private Sub ProcessFile(ByVal path As String)
        LogData(path)
        ListofFile += path & vbCrLf
    End Sub
    Private Function writeTxt(ByVal Path As String, ByVal FileName As String, ByVal Value As String) As Boolean
        Try
            If System.IO.File.Exists(Path & "\" & FileName) = True Then
                System.IO.File.Delete(Path & "\" & FileName)
            End If
            System.IO.File.Create(Path & "\" & FileName).Dispose()

            Dim objWriter As New System.IO.StreamWriter(Path & "\" & FileName, True)
            objWriter.Write(Value)
            objWriter.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function BuildSFX(ByVal OutputPath As String, ByVal OutputFilename As String, ByVal ScriptString As String, ByVal ListString As String, ByVal Type As Integer) As Boolean
        Try
            Dim PathString As String = Nothing
            If System.IO.Directory.Exists(OutputPath) = True Then

                Select Case Type
                    Case 0
                        If System.IO.Directory.Exists(OutputPath & "/Output/" & txtFileName.Text & "/Enterprise") = False Then
                            System.IO.Directory.CreateDirectory(OutputPath & "/Output/" & txtFileName.Text & "/Enterprise")
                        End If
                        PathString = IO.Path.Combine(OutputPath & "/Output/" & txtFileName.Text & "/Enterprise", "Taxcom" & OutputFilename)
                    Case 1
                        If System.IO.Directory.Exists(OutputPath & "/Output/" & txtFileName.Text & "/SmallBusiness") = False Then
                            System.IO.Directory.CreateDirectory(OutputPath & "/Output/" & txtFileName.Text & "/SmallBusiness")
                        End If
                        PathString = IO.Path.Combine(OutputPath & "/Output/" & txtFileName.Text & "/SmallBusiness", "Taxcom" & OutputFilename)
                    Case 2
                        If System.IO.Directory.Exists(OutputPath & "/Output/" & txtFileName.Text & "/Lite") = False Then
                            System.IO.Directory.CreateDirectory(OutputPath & "/Output/" & txtFileName.Text & "/Lite")
                        End If
                        PathString = IO.Path.Combine(OutputPath & "/Output/" & txtFileName.Text & "/Lite", "Taxcom" & OutputFilename)
                    Case 3
                        If System.IO.Directory.Exists(OutputPath & "/Output/" & txtFileName.Text & "/Education") = False Then
                            System.IO.Directory.CreateDirectory(OutputPath & "/Output/" & txtFileName.Text & "/Education")
                        End If
                        PathString = IO.Path.Combine(OutputPath & "/Output/" & txtFileName.Text & "/Lite", "Education" & OutputFilename)
                End Select

            Else
                Return False
            End If

            Dim ExePath As String = "C:\Program Files\WinRAR\WinRAR.exe"

            ' Dim ScriptString As String = IO.Path.Combine(Application.StartupPath, "script.txt")
            'Dim ListString As String = IO.Path.Combine(Application.StartupPath, "list.txt")

            Dim Options As String = String.Format("a ""{0}"" @""{1}"" -ep1 -sfx -z""{2}""", PathString, ListString, ScriptString)
            ' Options &= " -iicon""C:\Temp\Icons\AppIcon.ico"""

            Process.Start(ExePath, Options)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        StartPackage()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        isCancel = True
    End Sub

    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnOpenFolder.Click
        Try
            If txtDestinationPackage.TextLength > 0 Then
                If System.IO.Directory.Exists(txtDestinationPackage.Text) = True Then
                    Process.Start(txtDestinationPackage.Text)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        Dim frm As New frmClient
        frm.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Enterprise_Click(sender As Object, e As EventArgs) Handles btnClear_Enterprise.Click
        Try
            txtEnterpriseFolder.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClear_Small_Click(sender As Object, e As EventArgs) Handles btnClear_Small.Click
        Try
            txtSmallFolder.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClear_Lite_Click(sender As Object, e As EventArgs) Handles btnClear_Lite.Click
        Try
            txtLiteFolder.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClear_Education_Click(sender As Object, e As EventArgs) Handles btnClear_Education.Click
        Try
            txtEducationFolder.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Try
            My.Computer.Clipboard.SetText("[VERSION]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveSetting_Click(sender As Object, e As EventArgs) Handles btnSaveSetting.Click
        Try
            My.Settings.emailtemplateOther = txtOtherTemplate_Email.Text
            My.Settings.ieVersion = txtIEToolbarVersion.Text
            My.Settings.mailsetting = txtEmailSetting.Text
            My.Settings.mailpassword = mdlProcess_Office.EncryptPass(txtEmailSetting_Pass.Text)
            My.Settings.emailtemplate = txtEmailTemplate.Text
            My.Settings.EnterpriseFolder = txtEnterpriseFolder.Text
            My.Settings.SmallFolder = txtSmallFolder.Text
            My.Settings.LiteFolder = txtLiteFolder.Text
            My.Settings.EducationFolder = txtEducationFolder.Text
            My.Settings.DestinationFolder = txtDestinationPackage.Text
            My.Settings.ChangeLog = txtChangeLog.Text
            My.Settings.FileName = txtFileName.Text
            My.Settings.Title = txtTitle.Text
            My.Settings.HostName = txtHostName.Text
            My.Settings.HostUser = txtHostUser.Text
            My.Settings.HostPassword = txtHostPassword.Text
            My.Settings.HostPort = txtHostPort.Text
            My.Settings.Save()
            My.Settings.Reload()

            MsgBox("Setting successfully saved.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Setting unsuccessfully saved.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub chkSentEmail_CheckedChanged(sender As Object, e As EventArgs) Handles chkSentEmail.CheckedChanged

    End Sub

    Private Sub Test_Click(sender As Object, e As EventArgs) Handles Test.Click
        Try
            Dim str As String = mdlProcess_Office.EmailTemplate_StringChange(txtTitle.Text, "", "", txtChangeLog.Text, 4, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)

            My.Computer.Clipboard.SetText(str)
            txtEmailTemplate_Test.Text = str

            Dim dt As DataTable = Nothing
            If chkEmail_Enterprise.Checked = True Then
                'Enterprise
                dt = LoadEmailUserClient_2(1000)
                If dt IsNot Nothing Then
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 1, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 2, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 1, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 2, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 1, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 2, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 3, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 3, 1, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 3, 2, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    ' mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 4, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    ' mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 4, 1, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 4, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        Try
            My.Computer.Clipboard.SetText("[TITLEVERSION]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Try
            My.Computer.Clipboard.SetText("[PACKAGE]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Try
            My.Computer.Clipboard.SetText("[DATETIME]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        Try
            My.Computer.Clipboard.SetText("[CHANGELOG]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        Try
            My.Computer.Clipboard.SetText("[URLFILE]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        Try
            My.Computer.Clipboard.SetText("[TYPE]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSentEmail_Click(sender As Object, e As EventArgs) Handles btnSentEmail.Click
        Try
            picLoading.Visible = True
            picLoading.Dock = DockStyle.Fill
            lblStage.Text = "Sent Email"
            btnStart.Enabled = False
            btnSetting.Enabled = False
            btnSentEmail.Enabled = False
            Application.DoEvents()

            If chkSentEmail.Checked = False Then
                Exit Sub
            End If

            Dim dt As DataTable = Nothing
            Dim ListOfClient As List(Of String) = Nothing
            If chkEmail_Enterprise.Checked = True Then
                'Enterprise
                dt = LoadEmailUserClient_2(0)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Enterprise Full Failed")
                        LogData2("Enterprise Full", ListOfClient)
                    Else
                        LogData("Enterprise Full OK")
                        LogData2("Enterprise Full", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Enterprise_C.Checked = True Then
                'Enterprise C+
                dt = LoadEmailUserClient_2(1)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 1, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Enterprise C+ Failed")
                        LogData2("Enterprise C+", ListOfClient)
                    Else
                        LogData("Enterprise C+ OK")
                        LogData2("Enterprise C+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Enterprise_B.Checked = True Then
                'Enterprise B+
                dt = LoadEmailUserClient_2(2)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 2, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Enterprise B+ Failed")
                        LogData2("Enterprise B+", ListOfClient)
                    Else
                        LogData("Enterprise B+ OK")
                        LogData2("Enterprise B+", ListOfClient)
                    End If
                End If
            End If


            If chkEmail_Small.Checked = True Then
                'Small
                dt = LoadEmailUserClient_2(3)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Small Full Failed")
                        LogData2("Small Full", ListOfClient)
                    Else
                        LogData("Small Full OK")
                        LogData2("Small Full", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Enterprise_C.Checked = True Then
                'Small C+
                dt = LoadEmailUserClient_2(4)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 1, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Small C+ Failed")
                        LogData2("Small C+", ListOfClient)
                    Else
                        LogData("Small C+ OK")
                        LogData2("Small C+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Enterprise_B.Checked = True Then
                'Small B+
                dt = LoadEmailUserClient_2(5)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 2, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Small B+ Failed")
                        LogData2("Small B+", ListOfClient)
                    Else
                        LogData("Small B+ OK")
                        LogData2("Small B+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Lite.Checked = True Then
                'lite
                dt = LoadEmailUserClient_2(6)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Lite Full Failed")
                        LogData2("Lite Full", ListOfClient)
                    Else
                        LogData("Lite Full OK")
                        LogData2("Lite Full", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Lite_C.Checked = True Then
                'lite C+
                dt = LoadEmailUserClient_2(7)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 1, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Lite C+ Failed")
                        LogData2("Lite C+", ListOfClient)
                    Else
                        LogData("Lite C+ OK")
                        LogData2("Lite C+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Lite_B.Checked = True Then
                'Lite B+
                dt = LoadEmailUserClient_2(8)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 2, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Lite B+ Failed")
                        LogData2("Lite B+", ListOfClient)
                    Else
                        LogData("Lite B+ OK")
                        LogData2("Lite B+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_SQL_Enteprise.Checked = True Then
                'Small B+
                dt = LoadEmailUserClient_2(10)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 4, 0, txtEmailTemplate.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("SQL Enterprise Failed")
                        LogData2("SQL Full", ListOfClient)
                    Else
                        LogData("SQL Enterprise OK")
                        LogData2("SQL Full", ListOfClient)
                    End If
                End If
            End If

            MsgBox("Succesfully send email.", MsgBoxStyle.Information)
        Catch ex As Exception

        Finally
            btnSentEmail.Enabled = True
            btnStart.Enabled = True
            btnSetting.Enabled = True
            picLoading.Visible = False
            Application.DoEvents()
        End Try
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        Try
            My.Computer.Clipboard.SetText("[TYPEPACKAGE]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click
        Try
            My.Computer.Clipboard.SetText("[TYPESERVERFOLDER]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click
        Try
            My.Computer.Clipboard.SetText("[IETOOLBARVERSION]")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOtherEmail_test_Click(sender As Object, e As EventArgs) Handles btnOtherEmail_test.Click
        Try
            Dim str As String = mdlProcess_Office.EmailTemplate_StringChange(txtTitle.Text, "", "", txtChangeLog.Text, 4, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)

            My.Computer.Clipboard.SetText(str)
            txtOtherTemplate_EmailView.Text = str

            Dim dt As DataTable = Nothing
            If chkEmail_Enterprise.Checked = True Then
                'Enterprise
                dt = LoadEmailUserClient_2(1000)
                If dt IsNot Nothing Then
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    ' mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 1, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    ' mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 2, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    ' mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 1, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 2, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 1, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 2, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 3, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 3, 1, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    ''   mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 3, 2, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 4, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '  mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 4, 1, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                    '   mdlProcess_Office.SentEmailUpdate_TEST(dt, txtTitle.Text, "", "", txtChangeLog.Text, 4, 2, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOtherEmail_SentAll_Click(sender As Object, e As EventArgs) Handles btnOtherEmail_SentAll.Click
        Try
            picLoading.Visible = True
            picLoading.Dock = DockStyle.Fill
            lblStage.Text = "Sent Email"
            btnStart.Enabled = False
            btnSetting.Enabled = False
            btnSentEmail.Enabled = False
            Application.DoEvents()

            If chkSentEmail.Checked = False Then
                Exit Sub
            End If

            Dim dt As DataTable = Nothing
            Dim ListOfClient As List(Of String) = Nothing
            If chkEmail_Enterprise.Checked = True Then
                'Enterprise
                dt = LoadEmailUserClient_2(0)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Enterprise Full Failed")
                        LogData2("Enterprise Full", ListOfClient)
                    Else
                        LogData("Enterprise Full OK")
                        LogData2("Enterprise Full", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Enterprise_C.Checked = True Then
                'Enterprise C+
                dt = LoadEmailUserClient_2(1)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 1, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Enterprise C+ Failed")
                        LogData2("Enterprise C+", ListOfClient)
                    Else
                        LogData("Enterprise C+ OK")
                        LogData2("Enterprise C+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Enterprise_B.Checked = True Then
                'Enterprise B+
                dt = LoadEmailUserClient_2(2)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 0, 2, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Enterprise B+ Failed")
                        LogData2("Enterprise B+", ListOfClient)
                    Else
                        LogData("Enterprise B+ OK")
                        LogData2("Enterprise B+", ListOfClient)
                    End If
                End If
            End If


            If chkEmail_Small.Checked = True Then
                'Small
                dt = LoadEmailUserClient_2(3)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Small Full Failed")
                        LogData2("Small Full", ListOfClient)
                    Else
                        LogData("Small Full OK")
                        LogData2("Small Full", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Enterprise_C.Checked = True Then
                'Small C+
                dt = LoadEmailUserClient_2(4)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 1, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Small C+ Failed")
                        LogData2("Small C+", ListOfClient)
                    Else
                        LogData("Small C+ OK")
                        LogData2("Small C+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Enterprise_B.Checked = True Then
                'Small B+
                dt = LoadEmailUserClient_2(5)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 1, 2, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Small B+ Failed")
                        LogData2("Small B+", ListOfClient)
                    Else
                        LogData("Small B+ OK")
                        LogData2("Small B+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Lite.Checked = True Then
                'lite
                dt = LoadEmailUserClient_2(6)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Lite Full Failed")
                        LogData2("Lite Full", ListOfClient)
                    Else
                        LogData("Lite Full OK")
                        LogData2("Lite Full", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Lite_C.Checked = True Then
                'lite C+
                dt = LoadEmailUserClient_2(7)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 1, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Lite C+ Failed")
                        LogData2("Lite C+", ListOfClient)
                    Else
                        LogData("Lite C+ OK")
                        LogData2("Lite C+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_Lite_B.Checked = True Then
                'Lite B+
                dt = LoadEmailUserClient_2(8)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 2, 2, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("Lite B+ Failed")
                        LogData2("Lite B+", ListOfClient)
                    Else
                        LogData("Lite B+ OK")
                        LogData2("Lite B+", ListOfClient)
                    End If
                End If
            End If

            If chkEmail_SQL_Enteprise.Checked = True Then
                'Small B+
                dt = LoadEmailUserClient_2(10)
                ListOfClient = Nothing
                ListOfClient = New List(Of String)
                If dt IsNot Nothing Then
                    If mdlProcess_Office.SentEmailUpdate(dt, txtTitle.Text, "", "", txtChangeLog.Text, 4, 0, txtOtherTemplate_Email.Text, txtFileName.Text, txtIEToolbarVersion.Text, ListOfClient) = False Then
                        LogData("SQL Enterprise Failed")
                        LogData2("SQL Full", ListOfClient)
                    Else
                        LogData("SQL Enterprise OK")
                        LogData2("SQL Full", ListOfClient)
                    End If
                End If
            End If

            MsgBox("Succesfully send email.", MsgBoxStyle.Information)
        Catch ex As Exception

        Finally
            btnSentEmail.Enabled = True
            btnStart.Enabled = True
            btnSetting.Enabled = True
            picLoading.Visible = False
            Application.DoEvents()
        End Try
    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label41.Click
        Try
            My.Computer.Clipboard.SetText("[TYPESERVERFOLDERIETOOLBAR]")
        Catch ex As Exception

        End Try
    End Sub
End Class