<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboReportType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtTos = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtFroms = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.DsReport1 = New AutoCreateUpdate.dsReport()
        Me.dsTopSupport = New AutoCreateUpdate.dsTopSupport()
        Me.rptView = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dtTopSupportBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.DsReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsTopSupport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTopSupportBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnGenerate)
        Me.Panel1.Controls.Add(Me.dtTos)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtFroms)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboReportType)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1045, 72)
        Me.Panel1.TabIndex = 1
        '
        'cboReportType
        '
        Me.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Items.AddRange(New Object() {"Today Support Report", "Monthly Support Report", "Yearly Support Report", "Custom Date Report", "Top 10 Support By Company"})
        Me.cboReportType.Location = New System.Drawing.Point(105, 10)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(276, 21)
        Me.cboReportType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Report :"
        '
        'dtTos
        '
        Me.dtTos.CustomFormat = "dd-MMM-yyyy"
        Me.dtTos.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTos.Location = New System.Drawing.Point(464, 38)
        Me.dtTos.Name = "dtTos"
        Me.dtTos.Size = New System.Drawing.Size(207, 20)
        Me.dtTos.TabIndex = 206
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(404, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 16)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "To :"
        '
        'dtFroms
        '
        Me.dtFroms.CustomFormat = "dd-MMM-yyyy"
        Me.dtFroms.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFroms.Location = New System.Drawing.Point(464, 7)
        Me.dtFroms.Name = "dtFroms"
        Me.dtFroms.Size = New System.Drawing.Size(207, 20)
        Me.dtFroms.TabIndex = 204
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(404, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 16)
        Me.Label8.TabIndex = 203
        Me.Label8.Text = "From :"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(688, 8)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(164, 23)
        Me.btnGenerate.TabIndex = 207
        Me.btnGenerate.Text = "Generate report"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'DsReport1
        '
        Me.DsReport1.DataSetName = "dsReport"
        Me.DsReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dsTopSupport
        '
        Me.dsTopSupport.DataSetName = "dsTopSupport"
        Me.dsTopSupport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rptView
        '
        Me.rptView.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dtTopSupport"
        ReportDataSource1.Value = Me.dtTopSupportBindingSource
        Me.rptView.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptView.LocalReport.ReportEmbeddedResource = "AutoCreateUpdate.rptTopSupport.rdlc"
        Me.rptView.Location = New System.Drawing.Point(0, 72)
        Me.rptView.Name = "rptView"
        Me.rptView.Size = New System.Drawing.Size(1045, 458)
        Me.rptView.TabIndex = 2
        '
        'dtTopSupportBindingSource
        '
        Me.dtTopSupportBindingSource.DataMember = "dtTopSupport"
        Me.dtTopSupportBindingSource.DataSource = Me.dsTopSupport
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 530)
        Me.Controls.Add(Me.rptView)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DsReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsTopSupport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTopSupportBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboReportType As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents dtTos As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtFroms As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DsReport1 As AutoCreateUpdate.dsReport
    Friend WithEvents dsTopSupport As AutoCreateUpdate.dsTopSupport
    Friend WithEvents rptView As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtTopSupportBindingSource As System.Windows.Forms.BindingSource
End Class
