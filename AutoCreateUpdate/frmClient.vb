Imports Microsoft.AspNet.SignalR.Client.Hubs
Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.Client
Imports System.Reflection
Imports System.ComponentModel

Public Class frmClient
    Dim sortColumn As Integer = -1
    Private sortItems = New ImageList()
    Dim m_message As String = ""
    Dim m_name As String = ""
    Dim m_datetime As DateTime = Now
    Dim m_type As Integer = 0
    Dim m_connectionid As String = ""
    Dim m_clinetconnectionid As String = ""
    Dim ListofUser As List(Of String)
    Dim ListofUserConID As List(Of String)
    Dim m_listofUser As List(Of String)
    Dim m_listofUserConID As List(Of String)
    Dim isViewMessageCount As Integer = 0
    Dim TooltipSupport As ToolTip
    Private Delegate Sub MyDelegate()

    ' Private Delegate Sub AppendTextBoxDelegate(ByVal txt As String)
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim frm As New frmClient_Import_Update
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub frmClient_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If connection IsNot Nothing AndAlso connection.State = ConnectionState.Connected Then
                disConnect()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmClient_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.F2 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.KeyCode = Keys.F3 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.KeyCode = Keys.Insert Then
                btnAdds.PerformClick()
            ElseIf e.KeyCode = Keys.F5 Then
                LoadDataSupport()
            ElseIf e.KeyCode = Keys.F6 Then
                LoadData()          
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Timer1.Enabled = True
            Timer1.Start()

            Me.Text = My.Application.Info.Title
            'lblVersion.Text = "V" & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.Major & "." & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.MajorRevision & "." & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.Revision & "." & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.MinorRevision
            lblVersion.Text = "V" & V1 & "." & V2 & "." & V3 & "." & V4 & "." & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.Revision.ToString

            LvList.SmallImageList = sortItems

            sortItems.TransparentColor = System.Drawing.Color.Transparent
            sortItems.Images.Add("up", My.Resources.up)
            sortItems.Images.Add("down", My.Resources.down)

            cboType.SelectedIndex = 0
            LoadData()

            RemoveCancelSupport()

            myHub.On(Of String, String)("broadcastnotification", Sub(name As String, message As String)
                                                                     Me.m_name = name
                                                                     Me.m_message = message
                                                                     Me.m_type = 0
                                                                     Me.AppendNotificationBox()
                                                                 End Sub)

            myHub.On(Of String, String, DateTime, String)("broadcastMessage", Sub(name As String, message As String, datetimex As DateTime, connectionid As String)
                                                                                  Me.m_name = name
                                                                                  Me.m_message = message
                                                                                  Me.m_datetime = datetimex
                                                                                  Me.m_clinetconnectionid = connectionid
                                                                                  Me.m_type = 1
                                                                                  If connectionid <> connection.ConnectionId Then
                                                                                      My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
                                                                                      isViewMessageCount += 1

                                                                                  End If

                                                                                  Me.AppendMessageBox()
                                                                              End Sub)
            myHub.On(Of List(Of String), List(Of String), String)("onConnected", Sub(ListofUser As List(Of String), ListofUserConID As List(Of String), connectionid As String)
                                                                                     Me.m_listofUser = ListofUser
                                                                                     Me.m_listofUserConID = ListofUserConID
                                                                                     Me.m_connectionid = connectionid
                                                                                     Me.AppendListConnect()
                                                                                 End Sub)
            '  connection = New HubConnection("http://localhost:8080")
            ' myHub = connection.CreateHubProxy("hitCounter")
            startConnect()

            LoadSupportDashboard()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AppendNotificationBox()
        Try
            If Me.lblNotification.InvokeRequired Then
                Dim show As MyDelegate
                show = AddressOf AppendNotificationBox
                Me.lblNotification.Invoke(show)
            Else
                'Update the value of the textbox
                lblNotification.Text = m_message.ToString
                Dim frm As New frmNotification
                frm.Msg = m_message.ToString
                frm.Name = m_name.ToString
                frm.Type = m_type
                frm.Show()


                'Dim lblName As New Label
                'Dim lblDt As New Label
                'Dim lblMsg As New Label
                'Dim pnl As New Panel

                'pnl.Name = "pnlnoti" & Format(Now, "ddMMMyyyyHHmmss")
                'pnl.AutoSize = True
                'pnl.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                'pnl.Margin = New Padding(5)
                'pnl.Padding = New Padding(10)

                'If My.Computer.Name.ToUpper = m_name.ToUpper Then
                '    pnl.BackColor = Color.FromArgb(220, 248, 198)
                'Else
                '    pnl.BackColor = Color.LightPink
                'End If



                'lblName.Name = "lblnamenoti" & Format(Now, "ddMMMyyyyHHmmss")
                'lblName.Text = m_name.ToString
                'lblName.Location = New Point(13, 10)
                'lblName.AutoSize = True

                'lblDt.Name = "lbldtnoti" & Format(Now, "ddMMMyyyyHHmmss")
                'lblDt.Text = Format(Now, "dd-MMM-yyyy HH:MM tt")
                'lblDt.Location = New Point(flwNotification.Width - 200, 10)
                'lblDt.AutoSize = True

                'lblMsg.Name = "lblmsgnoti" & Format(Now, "ddMMMyyyyHHmmss")
                'lblMsg.Text = m_message.ToString
                'lblMsg.Location = New Point(13, 49)
                'lblMsg.AutoSize = True


                'pnl.Controls.Add(lblName)
                'pnl.Controls.Add(lblDt)
                'pnl.Controls.Add(lblMsg)
                'flwNotification.Controls.Add(pnl)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If ExportFile() Then
                MsgBox("Successfully export data.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function ExportFile() As Boolean
        Try
            Dim isAuto As Boolean = False
            Dim strFileName As String = ""
            Dim sw As IO.StreamWriter
            Dim strMsg As String = ""

            'If opAuto.Checked Then
            '    isauto = True
            'End If

            If svf.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                strFileName = svf.FileName
            Else
                Return False
            End If

            sw = New IO.StreamWriter(strFileName) 'Application.StartupPath & "\Export\" & strFileName)

            For x As Integer = 0 To LvList.Columns.Count - 1
                strMsg += LvList.Columns(x).Text.Replace(",", "|") & ","
            Next
            sw.WriteLine(strMsg)


            'write data
            For i As Integer = 0 To LvList.Items.Count - 1
                strMsg = LvList.Items(i).Text.Replace(",", "|") & ","

                For x As Integer = 1 To LvList.Columns.Count - 1
                    strMsg += LvList.Items(i).SubItems(x).Text.Replace(",", "|") & ","
                Next
                sw.WriteLine(strMsg)
            Next

            sw.Flush()
            sw.Close()

            Return True
        Catch ex As Exception
            ' LogFunction(Now, 0, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message, 1)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

    End Function
    Private Sub LoadData(Optional ByVal Type As Integer = 0)
        Try
            Dim dt As DataTable = Nothing

            If Type = 0 Then
                dt = LoadClient(IIf(chkIsBan.Checked, 1, 0))
            Else
                Dim typeData As Integer = -1

                Select Case cboType.SelectedIndex
                    Case 0
                        'All
                        typeData = -1
                    Case 1
                        'Enterprise
                        typeData = 0
                    Case 2
                        'Enterprise C+
                        typeData = 1
                    Case 3
                        'Enterprise B+
                        typeData = 2
                    Case 4
                        'Small
                        typeData = 3
                    Case 5
                        'Small C+
                        typeData = 4
                    Case 6
                        'Small B+
                        typeData = 5
                    Case 7
                        'Lite
                        typeData = 6
                    Case 8
                        'Lite
                        typeData = 8
                    Case 9
                        'sql
                        typeData = 10
                End Select
                dt = LoadClient_BySearch(txtName.Text, txtID.Text, IIf(chkIsBan.Checked, 1, 0), typeData)
            End If

            LvList.Items.Clear()
            If dt Is Nothing Then
                Exit Sub
            End If

            lblCount.Text = "Total : " & dt.Rows.Count
            Dim itm As ListViewItem
            Dim subitm As ListViewItem.ListViewSubItem
            Dim tmpstr As String = Nothing
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            Dim result As DialogResult = MessageBox.Show("Are you sure want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = Windows.Forms.DialogResult.Yes Then
                Dim ListofID As New List(Of String)
                For i As Integer = 0 To LvList.Items.Count - 1
                    If LvList.Items(i).Checked = True Then
                        ListofID.Add(LvList.Items(i).SubItems(1).Text)
                    End If
                Next

                If mdlProcess_Office.RemoveClient(ListofID) Then
                    MsgBox("Successfully remove data", MsgBoxStyle.Information)
                Else
                    MsgBox("Unsuccessfully remove data", MsgBoxStyle.Critical)
                End If
                LoadData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        Try

            For i As Integer = 0 To LvList.Items.Count - 1
                LvList.Items(i).Checked = chkSelectAll.Checked
                If chkSelectAll.Checked = True Then
                    chkSelectAll.Text = "Unselect All"
                Else
                    chkSelectAll.Text = "Select All"
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim frm As New frmClient_Add
            frm.ShowDialog()
            LoadData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LvList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles LvList.ColumnClick
        Try
            If e.Column <> sortColumn Then
                If sortColumn <> -1 Then
                    LvList.Columns(sortColumn).ImageKey = Nothing
                End If

                ' Set the sort column to the new column.
                sortColumn = e.Column
                ' Set the sort order to ascending by default.
                LvList.Sorting = SortOrder.Ascending
                LvList.Columns(sortColumn).ImageKey = "up"
            Else
                ' Determine what the last sort order was and change it.
                If LvList.Sorting = SortOrder.Ascending Then
                    LvList.Columns(sortColumn).ImageKey = "down"
                    LvList.Sorting = SortOrder.Descending
                Else
                    LvList.Columns(sortColumn).ImageKey = "up"
                    LvList.Sorting = SortOrder.Ascending
                End If
            End If
            ' Call the sort method to manually sort.
            LvList.Sort()
            ' Set the ListViewItemSorter property to a new ListViewItemComparer
            ' object.
            LvList.ListViewItemSorter = New ListViewItemComparer(e.Column, _
                                                             LvList.Sorting)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LvList_DoubleClick(sender As Object, e As EventArgs) Handles LvList.DoubleClick
        Try
            Dim tmpID As String = Nothing
            For i As Integer = 0 To LvList.Items.Count - 1
                If LvList.Items(i).Selected = True Then
                    tmpID = LvList.Items(i).SubItems(1).Text
                End If
            Next

            Dim frm As New frmClient_Add
            frm.isEdit = True
            frm.ID = tmpID
            frm.ShowDialog()

            LoadData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        LoadData(1)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        LoadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmCreatePackage
        frm.ShowDialog()

    End Sub


    Private Sub btnEmailList_Click(sender As Object, e As EventArgs) Handles btnEmailList.Click
        Try
            Dim frm As New frmListOfEmail
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        Try
            Me.LoadData(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LvList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvList.SelectedIndexChanged

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdds.Click
        Dim frm As New frmSupport_Add
        frm.ShowDialog()
        Me.LoadDataSupport(1)
    End Sub

    Private Sub btnFinds_Click(sender As Object, e As EventArgs) Handles btnFinds.Click
        LoadDataSupport(1)
    End Sub

    Private Sub btnClears_Click(sender As Object, e As EventArgs) Handles btnClears.Click

        txtIDS.Clear()
        txtNameS.Clear()
        txtPersonS.Clear()
        dtFroms.Value = Now
        dtTos.Value = Now
        txtNameS.Focus()
        LoadDataSupport()
    End Sub


    Private Sub frmSupport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
         
            cboStatuss.SelectedIndex = cboStatuss.Items.Count - 1
            dtFroms.Value = Now
            dtTos.Value = Now
            txtNameS.Focus()
            LoadDataSupport()
        Catch ex As Exception

        End Try
      
    End Sub
   
    Private Sub LoadDataSupport(Optional ByVal Type As Integer = 0)
        Try
            Dim dt As DataTable = Nothing
            'If Type = 0 Then
            '    dt = mdlProcess_Office.LoadSupport()
            'Else

            'End If
            Dim Typex As Integer = -1

            If cboStatuss.SelectedIndex <> cboStatuss.Items.Count - 1 Then
                Typex = cboStatuss.SelectedIndex
            End If
            dt = mdlProcess_Office.LoadSupport_Search(txtIDS.Text, txtNameS.Text, dtFroms.Value, dtTos.Value, Typex, txtPersonS.Text, txtReportName.Text)
            Dim tmpdata As String = ""
            LvLists.Items.Clear()
            If dt IsNot Nothing Then
                Dim itm As ListViewItem
                Dim tmpcountx As Integer = 0
                Dim subitm As ListViewItem.ListViewSubItem
                Dim tmpstr As String = ""
                lblcounts.Text = "Data Found : " & dt.Rows.Count
                For i As Integer = 0 To dt.Rows.Count - 1
                    itm = New ListViewItem
                    tmpcountx = mdlProcess_Office.LoadComment_ByCountID(IIf(IsDBNull(dt.Rows(i)("ID")), 0, dt.Rows(i)("ID")))
                    If tmpcountx > 0 Then
                        itm.Text = LvLists.Items.Count + 1 & " (!" + tmpcountx.ToString & ")"
                    Else
                        itm.Text = LvLists.Items.Count + 1
                    End If


                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("ID")), "", dt.Rows(i)("ID"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = mdlProcess_Office.ConvertDateTimeToFacebookDateTime(IIf(IsDBNull(dt.Rows(i)("DateTime")), "", dt.Rows(i)("DateTime")), 1)
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = mdlProcess_Office.GetStatusSupport(IIf(IsDBNull(dt.Rows(i)("Status")), 0, dt.Rows(i)("Status")))
                    itm.SubItems.Add(subitm)

                    If IsDBNull(dt.Rows(i)("Status")) = False Then

                        Select Case dt.Rows(i)("Status")
                            Case 0
                                itm.BackColor = Color.LightBlue
                            Case 1, 6
                                itm.BackColor = Color.LightPink
                            Case 2, 3
                                itm.BackColor = Color.White
                            Case 5
                                itm.BackColor = Color.LightGreen
                            Case 4
                                itm.BackColor = Color.DarkCyan
                                itm.ForeColor = Color.White
                            Case 7
                                itm.BackColor = Color.Black
                                itm.ForeColor = Color.White
                            Case 8
                                itm.BackColor = Color.Yellow
                                itm.ForeColor = Color.Black
                        End Select

                    End If

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("CompanyName")), "", dt.Rows(i)("CompanyName"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("Phone1")), "", dt.Rows(i)("Phone1"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("TeamviewerID")), "", dt.Rows(i)("TeamviewerID"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("PersonReport")), "", dt.Rows(i)("PersonReport"))
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
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("PersonName")), "", dt.Rows(i)("PersonName"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("Problem")), "", dt.Rows(i)("Problem"))
                    itm.SubItems.Add(subitm)


                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("RefID")), "", dt.Rows(i)("RefID"))
                    itm.SubItems.Add(subitm)


                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("ServerName")), "", dt.Rows(i)("ServerName"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("Note")), "", dt.Rows(i)("Note"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = mdlProcess_Office.GetTypeFrom(IIf(IsDBNull(dt.Rows(i)("TypeForm")), 100, dt.Rows(i)("TypeForm")))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    If IsDBNull(dt.Rows(i)("DateCreated")) = False Then
                        subitm.Text = dt.Rows(i)("DateCreated")
                    Else
                        subitm.Text = "-"
                    End If
                    ' subitm.Text = IIf(IsDBNull(dt.Rows(i)("DateCreated")), "Unspefied", Format(dt.Rows(i)("DateCreated"), "dd-MMM-yyyy HH:mm:ss"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("ModifiedBy")), "", dt.Rows(i)("ModifiedBy"))
                    itm.SubItems.Add(subitm)

                    subitm = New ListViewItem.ListViewSubItem
                    subitm.Text = IIf(IsDBNull(dt.Rows(i)("TeamviewerPass")), "", dt.Rows(i)("TeamviewerPass"))
                    itm.SubItems.Add(subitm)


                    tmpdata = IIf(IsDBNull(dt.Rows(i)("CompanyName")), "", dt.Rows(i)("CompanyName")) & vbCrLf
                    tmpdata += "Status : " & tmpstr & vbCrLf
                    tmpdata += "Phone No : " & IIf(IsDBNull(dt.Rows(i)("Phone1")), "", dt.Rows(i)("Phone1")) & vbCrLf
                    tmpdata += "Phone No 2 : " & IIf(IsDBNull(dt.Rows(i)("Phone2")), "", dt.Rows(i)("Phone2")) & vbCrLf
                    tmpdata += "Server Name : " & IIf(IsDBNull(dt.Rows(i)("ServerName")), "", dt.Rows(i)("ServerName")) & vbCrLf
                    tmpdata += "Person Name : " & IIf(IsDBNull(dt.Rows(i)("PersonName")), "", dt.Rows(i)("PersonName")) & vbCrLf
                    tmpdata += "Report Incharge : " & IIf(IsDBNull(dt.Rows(i)("PersonReport")), "", dt.Rows(i)("PersonReport")) & vbCrLf
                    tmpdata += "Type Form : " & mdlProcess_Office.GetTypeFrom(IIf(IsDBNull(dt.Rows(i)("TypeForm")), 100, dt.Rows(i)("TypeForm"))) & vbCrLf
                    tmpdata += "Problem : " & IIf(IsDBNull(dt.Rows(i)("Problem")), "", dt.Rows(i)("Problem")) & vbCrLf
                    itm.ToolTipText = tmpdata



                    LvLists.Items.Add(itm)
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub listView1_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles LvLists.ColumnClick
        ' Determine whether the column is the same as the last column clicked.
        If e.Column <> sortColumn Then
            ' Set the sort column to the new column.
            sortColumn = e.Column
            ' Set the sort order to ascending by default.
            LvLists.Sorting = SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If LvLists.Sorting = SortOrder.Ascending Then
                LvLists.Sorting = SortOrder.Descending
            Else
                LvLists.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        LvLists.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        LvLists.ListViewItemSorter = New ListViewItemComparer(e.Column, LvLists.Sorting)
    End Sub

    Private Sub LvLists_DoubleClick(sender As Object, e As EventArgs) Handles LvLists.DoubleClick
        Try
            Dim ID As Integer = 0
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected Then
                    ID = LvLists.Items(i).SubItems(1).Text
                End If
            Next

            Dim frm As New frmSupport_Add
            frm.isEdit = True
            frm.ID = ID
            frm.ShowDialog()
            Me.LoadDataSupport()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CopyTeamviewerIDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyTeamviewerIDToolStripMenuItem.Click
        Try
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected Then
                    Clipboard.SetText(LvLists.Items(i).SubItems(6).Text)
                    MsgBox("Copy " & LvLists.Items(i).SubItems(6).Text)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyTeamviewerPassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyTeamviewerPassToolStripMenuItem.Click
        Try
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected Then
                    Clipboard.SetText(LvLists.Items(i).SubItems(7).Text)
                    MsgBox("Copy " & LvLists.Items(i).SubItems(7).Text)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyCompanyNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyCompanyNameToolStripMenuItem.Click
        Try
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected Then
                    Clipboard.SetText(LvLists.Items(i).SubItems(4).Text)
                    MsgBox("Copy " & LvLists.Items(i).SubItems(4).Text)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyPersonNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyPersonNameToolStripMenuItem.Click
        Try
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected Then
                    Clipboard.SetText(LvLists.Items(i).SubItems(9).Text)
                    MsgBox("Copy " & LvLists.Items(i).SubItems(9).Text)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CopyServerNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyServerNameToolStripMenuItem.Click
        Try
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected Then
                    Clipboard.SetText(LvLists.Items(i).SubItems(12).Text)
                    MsgBox("Copy " & LvLists.Items(i).SubItems(12).Text)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CopyTelNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyTelNoToolStripMenuItem.Click
        Try
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected Then
                    Clipboard.SetText(LvLists.Items(i).SubItems(5).Text)
                    MsgBox("Copy " & LvLists.Items(i).SubItems(5).Text)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub OpenTeamviewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTeamviewerToolStripMenuItem.Click
        Try
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected Then
                    Dim p As New ProcessStartInfo

                    ' Specify the location of the binary
                    If Environment.Is64BitOperatingSystem Then
                        p.FileName = "C:\Program Files (x86)\TeamViewer\Version9\TeamViewer.exe"
                    Else
                        p.FileName = "C:\Program Files\TeamViewer\Version9\TeamViewer.exe"
                    End If

                    ' Use these arguments for the process
                    p.Arguments = "-i " & LvLists.Items(i).SubItems(6).Text & " -P " & LvLists.Items(i).SubItems(17).Text

                    ' Use a hidden window
                    p.WindowStyle = ProcessWindowStyle.Normal

                    Process.Start(p)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        LvLists_DoubleClick(sender, e)
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        btnAdds.PerformClick()
    End Sub

    Private Sub StatusSolveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusSolveToolStripMenuItem.Click
        Try

            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 3)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub StatusHoldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusHoldToolStripMenuItem.Click
        Try

            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 1)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
           
            LoadSupportDashboard()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadSupportDashboard()
        Try
            Dim DateFrom As DateTime = Now
            Dim DateTo As DateTime = Now
            Dim tmpInt As Integer = mdlProcess_Office.LoadSupportTotalSupport(2, DateFrom, DateTo)
            lblTotalSupportToday.Text = "Total Support Today : " & mdlProcess_Office.LoadSupportTotalSupport(0)

            tmpInt = mdlProcess_Office.LoadSupportTotalSupport(3, DateFrom, DateTo)

            lblTotalSupportYesterday.Text = "Total Support Yesterday : " & tmpInt

            tmpInt = mdlProcess_Office.LoadSupportTotalSupport(1, DateFrom, DateTo)

            lblTotalSupportWeek.Text = "Total Support Week : " & tmpInt & " (" & Format(DateFrom, "dd-MMM-yyyy") & " - " & Format(DateTo, "dd-MMM-yyyy") & ")"

            tmpInt = mdlProcess_Office.LoadSupportTotalSupport(2, DateFrom, DateTo)

            lblTotalSupportMonth.Text = "Total Support Month : " & tmpInt & " (" & Format(DateFrom, "dd-MMM-yyyy") & " - " & Format(DateTo, "dd-MMM-yyyy") & ")"

            tmpInt = mdlProcess_Office.LoadSupportTotalSupport(4, DateFrom, DateTo)

            lblTotalSupportYearly.Text = "Total Support Yearly : " & tmpInt & " (" & Format(DateFrom, "dd-MMM-yyyy") & " - " & Format(DateTo, "dd-MMM-yyyy") & ")"

            tmpInt = mdlProcess_Office.LoadSupportTotalSupport(5, DateFrom, DateTo)

            lblTotalSupportPendingToTesting.Text = "Total Pending To Test : " & tmpInt & " (" & Format(DateFrom, "dd-MMM-yyyy") & " - " & Format(DateTo, "dd-MMM-yyyy") & ")"

            tmpInt = mdlProcess_Office.LoadSupportTotalSupport(6, DateFrom, DateTo)

            lblTotalSupportBug.Text = "Total Bug : " & tmpInt & " (" & Format(DateFrom, "dd-MMM-yyyy") & " - " & Format(DateTo, "dd-MMM-yyyy") & ")"


            Dim tmpdt As DataTable = mdlProcess_Office.LoadTopSupport

            If tmpdt IsNot Nothing AndAlso tmpdt.Rows.Count = 3 Then
                lblTopSupport1.Text = IIf(IsDBNull(tmpdt.Rows(0)("CompanyName")), "", tmpdt.Rows(0)("CompanyName")) & " : " & IIf(IsDBNull(tmpdt.Rows(0)("countx")), 0, tmpdt.Rows(0)("countx"))
                lblTopSupport2.Text = IIf(IsDBNull(tmpdt.Rows(1)("CompanyName")), "", tmpdt.Rows(1)("CompanyName")) & " : " & IIf(IsDBNull(tmpdt.Rows(1)("countx")), 0, tmpdt.Rows(1)("countx"))
                lblTopSupport3.Text = IIf(IsDBNull(tmpdt.Rows(2)("CompanyName")), "", tmpdt.Rows(2)("CompanyName")) & " : " & IIf(IsDBNull(tmpdt.Rows(2)("countx")), 0, tmpdt.Rows(2)("countx"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StatusBugOnProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusBugOnProgramToolStripMenuItem.Click
        Try
            'bug on program
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 5)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StatusUrgentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusUrgentToolStripMenuItem.Click
        Try
            'urgent
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 7)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub StatusPendingToTestingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusPendingToTestingToolStripMenuItem.Click
        Try
            'pending to test
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 8)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DuplicateThisSupportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateThisSupportToolStripMenuItem.Click
        Try
            'duplicate suport
            Dim rlst As MsgBoxResult = MessageBox.Show("Are sure want to duplicate this support?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If rlst = MsgBoxResult.Yes Then
                Dim dt As DataTable = Nothing

                For i As Integer = 0 To LvLists.Items.Count - 1
                    If LvLists.Items(i).Selected = True Then
                        dt = mdlProcess_Office.LoadSupport_ByID(LvLists.Items(i).SubItems(1).Text)

                        If dt IsNot Nothing Then
                            mdlProcess_Office.SaveSupport(IIf(IsDBNull(dt.Rows(0)("CompanyID")), "", dt.Rows(0)("CompanyID")), IIf(IsDBNull(dt.Rows(0)("TeamviewerID")), "", dt.Rows(0)("TeamviewerID")), _
                                                          IIf(IsDBNull(dt.Rows(0)("TeamviewerPass")), "", dt.Rows(0)("TeamviewerPass")), IIf(IsDBNull(dt.Rows(0)("PersonName")), "", dt.Rows(0)("PersonName")), _
                                                         IIf(IsDBNull(dt.Rows(0)("Problem")), "", dt.Rows(0)("Problem")), IIf(IsDBNull(dt.Rows(0)("Note")), "", dt.Rows(0)("Note")), 0, IIf(IsDBNull(dt.Rows(0)("TypeForm")), 0, dt.Rows(0)("TypeForm")), _
                                                          IIf(IsDBNull(dt.Rows(0)("RefPayerNo")), "", dt.Rows(0)("RefPayerNo")), IIf(IsDBNull(dt.Rows(0)("YA")), 0, dt.Rows(0)("YA")), IIf(IsDBNull(dt.Rows(0)("PersonReport")), "", dt.Rows(0)("PersonReport")), Nothing)

                        End If

                    End If
                Next
                Me.LoadDataSupport(1)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUrgentOnly_Click(sender As Object, e As EventArgs) Handles btnUrgentOnly.Click
        Try
            dtFroms.Value = Now.AddDays(-7)
            dtTos.Value = Now
            cboStatuss.SelectedIndex = 7
            Application.DoEvents()
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBugOnly_Click(sender As Object, e As EventArgs) Handles btnBugOnly.Click
        Try
            dtFroms.Value = Now.AddMonths(-3)
            dtTos.Value = Now
            cboStatuss.SelectedIndex = 5
            Application.DoEvents()
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        Try
            dtFroms.Value = Now
            dtTos.Value = Now
            cboStatuss.SelectedIndex = cboStatuss.Items.Count - 1
            Application.DoEvents()
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThisWeek_Click(sender As Object, e As EventArgs) Handles btnThisWeek.Click
        Try
            dtFroms.Value = Now.AddDays(-7)
            dtTos.Value = Now
            cboStatuss.SelectedIndex = cboStatuss.Items.Count - 1
            Application.DoEvents()
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnHoldOnly_Click(sender As Object, e As EventArgs) Handles btnHoldOnly.Click
        Try
            dtFroms.Value = Now.AddMonths(-3)
            dtTos.Value = Now
            cboStatuss.SelectedIndex = 1
            Application.DoEvents()
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPendingTest_Click(sender As Object, e As EventArgs) Handles btnPendingTest.Click
        Try
            dtFroms.Value = Now.AddMonths(-3)
            dtTos.Value = Now
            cboStatuss.SelectedIndex = 8
            Application.DoEvents()
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThisMonth_Click(sender As Object, e As EventArgs) Handles btnThisMonth.Click
        Try
            Dim datLastDay As Date = GetLastDayOfMonth(Now.Month, Now.Year)
            dtFroms.Value = CDate(Format(Now, "01-MMM-yyyy 00:00:00"))
            dtTos.Value = Now
            cboStatuss.SelectedIndex = cboStatuss.Items.Count - 1
            Application.DoEvents()
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnYesterday_Click(sender As Object, e As EventArgs) Handles btnYesterday.Click
        Try
            dtFroms.Value = Now.AddDays(-1)
            dtTos.Value = Now.AddDays(-1)
            cboStatuss.SelectedIndex = cboStatuss.Items.Count - 1
            Application.DoEvents()
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Try

            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 0)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Try

            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 2)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PCProblemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCProblemToolStripMenuItem.Click
        Try

            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 6)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        frmSignalR.Show()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim frm As New frmReport
        frm.Show()
    End Sub

    Private Sub btnSentMessage_Click(sender As Object, e As EventArgs) Handles btnSentMessage.Click
        Try
            mdlProcess_Office.SendMessage(txtMessage.Text)
            txtMessage.Clear()
            txtMessage.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMessage_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMessage.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                mdlProcess_Office.SendMessage(txtMessage.Text)
                txtMessage.Clear()
                txtMessage.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AppendListConnect()
        Try
            If Me.lvUserOnline.InvokeRequired Then
                Dim show As MyDelegate
                show = AddressOf AppendListConnect
                Me.lvUserOnline.Invoke(show)
            Else
                lvUserOnline.Items.Clear()
                If m_listofUser.Count > 0 Then
                    Dim itm As ListViewItem
                    Dim subitm As ListViewItem.ListViewSubItem
                    lvUserOnline.BeginUpdate()

                    For i As Integer = 0 To m_listofUser.Count - 1
                        itm = New ListViewItem

                        itm.Text = m_listofUser(i)

                        subitm = New ListViewItem.ListViewSubItem
                        subitm.Text = m_listofUserConID(i)
                        itm.SubItems.Add(subitm)

                        lvUserOnline.Items.Add(itm)
                    Next
                    lvUserOnline.EndUpdate()

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub AppendMessageBox()
        Try


            If Me.flpMain.InvokeRequired Then
                Dim show As MyDelegate
                show = AddressOf AppendMessageBox
                Me.flpMain.Invoke(show)
            Else
                'Update the value of the textbox

                'Dim txt As New TextBox
                'txt.Text = m_message.ToString
                'txt.Size = New Size(flpMain.Width, 40)
                'If m_name.ToUpper = My.Computer.Name.ToUpper Then
                '    txt.BackColor = Color.Azure
                'Else
                '    txt.BackColor = Color.White
                'End If

                'flpMain.Controls.Add(txt)
                '==============================================================================================
                '==============================================================================================

                Dim PnlCont As Panel
                Dim lblUserName As Label
                Dim lblDateTime As Label
                Dim txtMsg As RichTextBox
                Dim sizepnl As Integer = 70

                If m_name.ToLower <> My.Computer.Name.ToLower Then


                    PnlCont = New Panel
                    PnlCont.Location = New Point(0, 0)
                    PnlCont.BackColor = Color.White

                    lblUserName = New Label
                    lblUserName.Text = m_name
                    lblUserName.ForeColor = Color.Black
                    lblUserName.Location = New Point(9, 10)
                    lblUserName.Size = New System.Drawing.Size(331, 13)
                    lblUserName.TextAlign = ContentAlignment.MiddleLeft
                    lblUserName.Font = New Font("Segoe UI Emoji", 8.25F, FontStyle.Bold)

                    lblDateTime = New Label
                    lblDateTime.Name = "lbldt" & Format(Now, "ddMMyyyyHHmmsss")
                    lblDateTime.Text = Format(Now, "dd-MM-yyyy HH:mm tt") 'ConvertDateTimeToFacebookDateTime(m_datetime)
                    lblDateTime.ForeColor = Color.Black
                    lblDateTime.Location = New Point(flpMain.Width - 50, 10)
                    lblDateTime.Size = New System.Drawing.Size(201, 16)
                    lblDateTime.TextAlign = ContentAlignment.MiddleRight

                    txtMsg = New RichTextBox
                    txtMsg.Text = m_message.Trim
                    txtMsg.Location = New Point(9, 37)
                    txtMsg.BackColor = Color.White
                    txtMsg.ReadOnly = True
                    txtMsg.BorderStyle = BorderStyle.None


                    Dim rtbSize As New Size(TextRenderer.MeasureText(txtMsg.Text, txtMsg.Font, txtMsg.Size, TextFormatFlags.WordBreak))

                    sizepnl = rtbSize.Height + 20

                    txtMsg.Size = New System.Drawing.Size(flpMain.Width - 250, sizepnl)
                    'PnlWrp.Size = New System.Drawing.Size(730, sizepnl + 10)
                    'PnlCont.Size = New System.Drawing.Size(550, sizepnl + 10)

                    PnlCont.Controls.Add(lblUserName)
                    PnlCont.Controls.Add(lblDateTime)
                    PnlCont.Controls.Add(txtMsg)


                    PnlCont.AutoSize = True
                    PnlCont.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                    PnlCont.Padding = New Padding(10)
                    PnlCont.Margin = New Padding(10)
                Else


                    PnlCont = New Panel
                    PnlCont.Location = New Point(180, 0)
                    PnlCont.BackColor = Color.FromArgb(220, 248, 198)

                    lblUserName = New Label
                    lblUserName.Text = m_name
                    lblUserName.ForeColor = Color.Red
                    lblUserName.Location = New Point(9, 10)
                    lblUserName.Size = New System.Drawing.Size(331, 16)
                    lblUserName.TextAlign = ContentAlignment.MiddleLeft
                    lblUserName.Font = New Font("Segoe UI Emoji", 8.25F, FontStyle.Bold)


                    lblDateTime = New Label
                    lblDateTime.Name = "lbldt" & Format(Now, "ddMMyyyyHHmmsss")
                    lblDateTime.Text = Format(Now, "dd-MM-yyyy HH:mm tt") 'ConvertDateTimeToFacebookDateTime(m_datetime)
                    lblDateTime.ForeColor = Color.Black
                    lblDateTime.Location = New Point(flpMain.Width - 250, 10)
                    lblDateTime.Size = New System.Drawing.Size(201, 16)
                    lblDateTime.TextAlign = ContentAlignment.MiddleRight

                    txtMsg = New RichTextBox
                    txtMsg.Text = m_message.Trim
                    txtMsg.Location = New Point(9, 37)
                    txtMsg.BackColor = Color.FromArgb(220, 248, 198)
                    txtMsg.ReadOnly = True
                    txtMsg.BorderStyle = BorderStyle.None

                    Dim rtbSize As New Size(TextRenderer.MeasureText(txtMsg.Text, txtMsg.Font, txtMsg.Size, TextFormatFlags.WordBreak))

                    sizepnl = rtbSize.Height + 20

                    txtMsg.Size = New System.Drawing.Size(flpMain.Width - 50, sizepnl)
                    'PnlWrp.Size = New System.Drawing.Size(730, sizepnl + 10)
                    'PnlCont.Size = New System.Drawing.Size(550, sizepnl + 10)

                    PnlCont.Controls.Add(lblUserName)
                    PnlCont.Controls.Add(lblDateTime)
                    PnlCont.Controls.Add(txtMsg)

                    PnlCont.AutoSize = True
                    PnlCont.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                    PnlCont.Padding = New Padding(10)
                    PnlCont.Margin = New Padding(10)
                End If

                flpMain.Controls.Add(PnlCont)
                flpMain.VerticalScroll.Value = flpMain.VerticalScroll.Maximum
                txtMessage.Focus()

                Me.TabControl1.TabPages(2).Text = "Message (" & isViewMessageCount.ToString & ")                                        "


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.SelectedIndex = 2 Then
                isViewMessageCount = 0
            End If
            If isViewMessageCount = 0 Then
                Me.TabControl1.TabPages(2).Text = "Message                                        "
            Else
                Me.TabControl1.TabPages(2).Text = "Message (" & isViewMessageCount.ToString & ")                                        "
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub picNotification_Click(sender As Object, e As EventArgs)

    End Sub

  
    'Private Sub ResizeBox()
    '    Try

    '        For i As Integer = 0 To flwNotification.Controls.Count - 1
    '            If TypeOf flwNotification.Controls(i) Is Panel Then
    '                'AndAlso flwNotification.Controls(i).Name.Contains("lbldt")
    '                'lblDt.Name = "lbldtnoti" & Format(Now, "ddMMMyyyyHHmmss")
    '                'lblDt.Text = Format(m_datetime, "dd-MMM-yyyy HH:MM tt")
    '                'lblDt.Location = New Point(flwNotification.Width - 200, 10)
    '                'lblDt.AutoSize = True
    '                For Each lbl As Label In flwNotification.Controls(i).Controls
    '                    If lbl.Name.Contains("lbldt") Then
    '                        lbl.Location = New Point(flwNotification.Width - 200, 10)
    '                    End If

    '                Next

    '            End If
    '        Next
    '        'lbldt
    '        Dim sizepnl As Integer = 0
    '        For i As Integer = 0 To flpMain.Controls.Count - 1
    '            If TypeOf flpMain.Controls(i) Is Panel Then
    '                'AndAlso flwNotification.Controls(i).Name.Contains("lbldt")
    '                'lblDt.Name = "lbldtnoti" & Format(Now, "ddMMMyyyyHHmmss")
    '                'lblDt.Text = Format(m_datetime, "dd-MMM-yyyy HH:MM tt")
    '                'lblDt.Location = New Point(flwNotification.Width - 200, 10)
    '                'lblDt.AutoSize = True
    '                For x As Integer = 0 To flpMain.Controls(i).Controls.Count - 1
    '                    If TypeOf flpMain.Controls(i).Controls(x) Is Label Then
    '                        If flpMain.Controls(i).Controls(x).Name.Contains("lbldt") Then
    '                            flpMain.Controls(i).Controls(x).Location = New Point(flpMain.Width - 250, 10)
    '                        End If
    '                    ElseIf TypeOf flpMain.Controls(i).Controls(x) Is RichTextBox Then
    '                        Dim rtbSize As New Size(TextRenderer.MeasureText(flpMain.Controls(i).Controls(x).Text, flpMain.Controls(i).Controls(x).Font, flpMain.Controls(i).Controls(x).Size, TextFormatFlags.WordBreak))

    '                        sizepnl = rtbSize.Height + 20

    '                        flpMain.Controls(i).Controls(x).Size = New System.Drawing.Size(flpMain.Width - 50, sizepnl)
    '                    End If
    '                Next

    '            End If
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub LvLists_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles LvLists.ItemSelectionChanged
        'Try
        '    For i As Integer = 0 To LvLists.Items.Count - 1
        '        If LvLists.Items(i).Selected = True Then
        '            TooltipSupport = New ToolTip
        '            TooltipSupport.AutoPopDelay = 5000
        '            TooltipSupport.InitialDelay = 1000
        '            TooltipSupport.ReshowDelay = 500
        '            TooltipSupport.ShowAlways = True

        '            TooltipSupport.ToolTipTitle = LvLists.Items(i).SubItems(4).Text
        '            Dim tmpdata As String = ""

        '            tmpdata = "Status : " & LvLists.Items(i).SubItems(3).Text & vbCrLf
        '            tmpdata += "Phone No : " & LvLists.Items(i).SubItems(5).Text & vbCrLf
        '            tmpdata += "Person Name : " & LvLists.Items(i).SubItems(8).Text & vbCrLf
        '            tmpdata += "Type Form : " & LvLists.Items(i).SubItems(13).Text & vbCrLf
        '            tmpdata += "Problem : " & LvLists.Items(i).SubItems(9).Text & vbCrLf


        '            TooltipSupport.Show(tmpdata, Me.LvLists)

        '        End If
        '    Next



        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub LvLists_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvLists.SelectedIndexChanged
        
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnFileBrowser.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub StatusCantTriggerProblemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusCantTriggerProblemToolStripMenuItem.Click
        Try
            'pending to test
            For i As Integer = 0 To LvLists.Items.Count - 1
                If LvLists.Items(i).Selected = True Then
                    mdlProcess_Office.UpdateStatusSupport(LvLists.Items(i).SubItems(1).Text, LvLists.Items(i).SubItems(4).Text, 4)
                End If
            Next
            Me.LoadDataSupport(1)
        Catch ex As Exception

        End Try
    End Sub
End Class
