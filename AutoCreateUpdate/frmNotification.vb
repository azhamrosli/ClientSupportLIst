Imports System.Runtime.InteropServices

Public Class frmNotification
    Public Msg As String
    Public Name As String
    Public Type As Integer

    Private Const AW_VER_POSITIVE As Integer = &H4
    Private Const AW_VER_NEGATIVE As Integer = &H8
    Private Const AW_HOR_POSITIVE As Integer = &H1
    Private Const AW_HOR_NEGATIVE As Integer = &H2
    Private Const AW_HIDE As Integer = &H10000
    Private Const AW_SLIDE As Integer = &H40000

    <DllImport("user32.dll", EntryPoint:="AnimateWindow")> _
    Private Shared Function AnimateWindow(ByVal hWnd As IntPtr, ByVal dwTime As UInteger, ByVal dwFlags As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Function
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim ScreenSizeX As Integer = Me.Size.Width
        Dim ScreenSizeY As Integer = Me.Size.Height


        Me.Location = New Point(intX - (ScreenSizeX + 5), intY - 150)

        Application.DoEvents()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmNotification_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            AnimateWindow(Me.Handle, 300, AW_HOR_POSITIVE Or AW_SLIDE)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmNotification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Timer1.Enabled = True
            Timer1.Start()

            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
            lblMsg.Text = Name & vbCrLf & Msg
            AnimateWindow(Me.Handle, 500, AW_HOR_NEGATIVE Or AW_SLIDE)
            ' AnimateWindow(Me.Handle, 1000, AW_SLIDE Or AW_VER_POSITIVE)
            ' Me.Location = New Point(0, 0)
            Me.BringToFront()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class