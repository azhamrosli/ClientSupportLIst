Imports Microsoft.AspNet.SignalR.Client.Hubs
Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.Client
Imports System.Reflection
Imports System.ComponentModel

Public Class frmSignalR

  
    Dim ListofUser As List(Of String)
    Dim ListofUserConID As List(Of String)
    Dim m_message As String = ""
    Dim m_name As String = ""
    Dim m_datetime As DateTime = Now
    Dim m_connectionid As String = ""
    Dim m_clinetconnectionid As String = ""
    Dim m_listofUser As List(Of String)
    Dim m_listofUserConID As List(Of String)
    Private Delegate Sub MyDelegate()

    Private Sub frmSignalR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            myHub.On(Of String, String, DateTime, String)("broadcastMessage", Sub(name As String, message As String, datetimex As DateTime, connectionid As String)
                                                                                  Me.m_name = name
                                                                                  Me.m_message = message
                                                                                  Me.m_datetime = datetimex
                                                                                  Me.m_clinetconnectionid = connectionid
                                                                                  Me.AppendMessageBox()
                                                                              End Sub)
            myHub.On(Of List(Of String), List(Of String), String)("onConnected", Sub(ListofUser As List(Of String), ListofUserConID As List(Of String), connectionid As String)
                                                                                     Me.m_listofUser = ListofUser
                                                                                     Me.m_listofUserConID = ListofUserConID
                                                                                     Me.m_connectionid = connectionid
                                                                                     Me.AppendListConnect()
                                                                                 End Sub)

            mdlProcess_Office.chatConnect()

            Me.MaximumSize = New Size(980, Screen.PrimaryScreen.Bounds.Height - 30)
        Catch ex As Exception

        End Try
    End Sub
   
    
    Private Sub AppendListConnect()
        Try
            If Me.lbListConnect.InvokeRequired Then
                Dim show As MyDelegate
                show = AddressOf AppendListConnect
                Me.lbListConnect.Invoke(show)
            Else
                lbListConnect.Items.Clear()
                If m_listofUser.Count > 0 Then
                    For i As Integer = 0 To m_listofUser.Count - 1
                        lbListConnect.Items.Add(m_listofUser(i))
                    Next
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
                Dim PnlWrp As Panel
                Dim PnlCont As Panel
                Dim lblUserName As Label
                Dim lblDateTime As Label
                Dim txtMsg As RichTextBox
                Dim sizepnl As Integer = 70

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
                    lblDateTime.Name = "lbldt" & Format(Now, "ddMMyyyyHHmmsss")
                    lblDateTime.Text = ConvertDateTimeToFacebookDateTime(m_datetime)
                    lblDateTime.ForeColor = Color.Black
                    lblDateTime.Location = New Point(346, 10)
                    lblDateTime.Size = New System.Drawing.Size(201, 13)
                    lblDateTime.TextAlign = ContentAlignment.MiddleRight

                    txtMsg = New RichTextBox
                    txtMsg.Text = m_message
                    txtMsg.Location = New Point(9, 37)
                    txtMsg.BackColor = Color.White
                    txtMsg.ReadOnly = True
                    txtMsg.BorderStyle = BorderStyle.None

                    Dim rtbSize As New Size(TextRenderer.MeasureText(txtMsg.Text, txtMsg.Font, txtMsg.Size, TextFormatFlags.WordBreak))

                    sizepnl = rtbSize.Height + 70

                    txtMsg.Size = New System.Drawing.Size(535, sizepnl)
                    PnlWrp.Size = New System.Drawing.Size(730, sizepnl + 10)
                    PnlCont.Size = New System.Drawing.Size(550, sizepnl + 10)

                    PnlCont.Controls.Add(lblUserName)
                    PnlCont.Controls.Add(lblDateTime)
                    PnlCont.Controls.Add(txtMsg)

                    PnlWrp.Controls.Add(PnlCont)

                Else
                    PnlWrp = New Panel

                    PnlCont = New Panel
                    PnlCont.Location = New Point(180, 0)
                    PnlCont.BackColor = Color.FromArgb(220, 248, 198)

                    lblUserName = New Label
                    lblUserName.Text = m_name
                    lblUserName.ForeColor = Color.Red
                    lblUserName.Location = New Point(9, 10)
                    lblUserName.Size = New System.Drawing.Size(331, 13)
                    lblUserName.TextAlign = ContentAlignment.MiddleLeft
                    lblUserName.Font = New Font("Tahoma", 8.25F, FontStyle.Bold)


                    lblDateTime = New Label
                    lblDateTime.Name = "lbldt" & Format(Now, "ddMMyyyyHHmmsss")
                    lblDateTime.Text = ConvertDateTimeToFacebookDateTime(m_datetime)
                    lblDateTime.ForeColor = Color.Black
                    lblDateTime.Location = New Point(346, 10)
                    lblDateTime.Size = New System.Drawing.Size(201, 13)
                    lblDateTime.TextAlign = ContentAlignment.MiddleRight

                    txtMsg = New RichTextBox
                    txtMsg.Text = m_message
                    txtMsg.Location = New Point(9, 37)
                    txtMsg.BackColor = Color.FromArgb(220, 248, 198)
                    txtMsg.ReadOnly = True
                    txtMsg.BorderStyle = BorderStyle.None


                    Dim rtbSize As New Size(TextRenderer.MeasureText(txtMsg.Text, txtMsg.Font, txtMsg.Size, TextFormatFlags.WordBreak))

                    sizepnl = rtbSize.Height + 70

                    txtMsg.Size = New System.Drawing.Size(535, sizepnl)
                    PnlWrp.Size = New System.Drawing.Size(730, sizepnl + 10)
                    PnlCont.Size = New System.Drawing.Size(550, sizepnl + 10)

                    PnlCont.Controls.Add(lblUserName)
                    PnlCont.Controls.Add(lblDateTime)
                    PnlCont.Controls.Add(txtMsg)

                    PnlWrp.Controls.Add(PnlCont)

                End If
               
                flpMain.Controls.Add(PnlWrp)
                flpMain.VerticalScroll.Value = flpMain.VerticalScroll.Maximum
                txtMessage.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
End Class