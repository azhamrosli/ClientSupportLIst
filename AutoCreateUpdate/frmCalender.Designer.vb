<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalender
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MonthCalendar1.BoldedDates = New Date() {New Date(2017, 5, 17, 0, 0, 0, 0), New Date(2017, 5, 20, 0, 0, 0, 0)}
        Me.MonthCalendar1.CalendarDimensions = New System.Drawing.Size(3, 3)
        Me.MonthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Sunday
        Me.MonthCalendar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthCalendar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonthCalendar1.Location = New System.Drawing.Point(12, 18)
        Me.MonthCalendar1.MaxDate = New Date(9998, 12, 14, 0, 0, 0, 0)
        Me.MonthCalendar1.MinDate = New Date(1753, 1, 10, 0, 0, 0, 0)
        Me.MonthCalendar1.MonthlyBoldedDates = New Date() {New Date(2017, 5, 9, 0, 0, 0, 0)}
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        Me.MonthCalendar1.TitleBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.MonthCalendar1.TitleForeColor = System.Drawing.Color.Fuchsia
        Me.MonthCalendar1.TrailingForeColor = System.Drawing.Color.Red
        '
        'frmCalender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 495)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Name = "frmCalender"
        Me.Text = "frmCalender"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
End Class
