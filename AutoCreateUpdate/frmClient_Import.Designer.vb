<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClient_Import
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.DtClientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New AutoCreateUpdate.DataSet1()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompanyNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PostcodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CountryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FaxNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseEnterpriseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseSmallBusinessDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseLiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseEducationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseTrialDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtClientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1188, 49)
        Me.Panel1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(136, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Client Import"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1113, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(75, 49)
        Me.Panel3.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "File :"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(86, 68)
        Me.txtFileName.MaxLength = 150
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(619, 27)
        Me.txtFileName.TabIndex = 149
        '
        'dgview
        '
        Me.dgview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgview.AutoGenerateColumns = False
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.CompanyNameDataGridViewTextBoxColumn, Me.Address1DataGridViewTextBoxColumn, Me.Address2DataGridViewTextBoxColumn, Me.Address3DataGridViewTextBoxColumn, Me.StateDataGridViewTextBoxColumn, Me.CityDataGridViewTextBoxColumn, Me.PostcodeDataGridViewTextBoxColumn, Me.CountryDataGridViewTextBoxColumn, Me.Phone1DataGridViewTextBoxColumn, Me.Phone2DataGridViewTextBoxColumn, Me.FaxNoDataGridViewTextBoxColumn, Me.LicenseEnterpriseDataGridViewTextBoxColumn, Me.LicenseSmallBusinessDataGridViewTextBoxColumn, Me.LicenseLiteDataGridViewTextBoxColumn, Me.LicenseEducationDataGridViewTextBoxColumn, Me.LicenseTrialDataGridViewTextBoxColumn, Me.RefID})
        Me.dgview.DataSource = Me.DtClientBindingSource
        Me.dgview.Location = New System.Drawing.Point(18, 109)
        Me.dgview.Name = "dgview"
        Me.dgview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgview.RowTemplate.Height = 24
        Me.dgview.Size = New System.Drawing.Size(1158, 468)
        Me.dgview.TabIndex = 153
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(1082, 64)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(93, 39)
        Me.btnSave.TabIndex = 155
        Me.btnSave.Text = "Import"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Location = New System.Drawing.Point(983, 64)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(93, 39)
        Me.btnRemove.TabIndex = 156
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnFind
        '
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Image = Global.AutoCreateUpdate.My.Resources.Resources.Search_Find
        Me.btnFind.Location = New System.Drawing.Point(711, 64)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 39)
        Me.btnFind.TabIndex = 152
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Image = Global.AutoCreateUpdate.My.Resources.Resources.logo
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(129, 49)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'DtClientBindingSource
        '
        Me.DtClientBindingSource.DataMember = "dtClient"
        Me.DtClientBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        '
        'CompanyNameDataGridViewTextBoxColumn
        '
        Me.CompanyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName"
        Me.CompanyNameDataGridViewTextBoxColumn.HeaderText = "CompanyName"
        Me.CompanyNameDataGridViewTextBoxColumn.Name = "CompanyNameDataGridViewTextBoxColumn"
        '
        'Address1DataGridViewTextBoxColumn
        '
        Me.Address1DataGridViewTextBoxColumn.DataPropertyName = "Address1"
        Me.Address1DataGridViewTextBoxColumn.HeaderText = "Address1"
        Me.Address1DataGridViewTextBoxColumn.Name = "Address1DataGridViewTextBoxColumn"
        '
        'Address2DataGridViewTextBoxColumn
        '
        Me.Address2DataGridViewTextBoxColumn.DataPropertyName = "Address2"
        Me.Address2DataGridViewTextBoxColumn.HeaderText = "Address2"
        Me.Address2DataGridViewTextBoxColumn.Name = "Address2DataGridViewTextBoxColumn"
        '
        'Address3DataGridViewTextBoxColumn
        '
        Me.Address3DataGridViewTextBoxColumn.DataPropertyName = "Address3"
        Me.Address3DataGridViewTextBoxColumn.HeaderText = "Address3"
        Me.Address3DataGridViewTextBoxColumn.Name = "Address3DataGridViewTextBoxColumn"
        '
        'StateDataGridViewTextBoxColumn
        '
        Me.StateDataGridViewTextBoxColumn.DataPropertyName = "State"
        Me.StateDataGridViewTextBoxColumn.HeaderText = "State"
        Me.StateDataGridViewTextBoxColumn.Name = "StateDataGridViewTextBoxColumn"
        '
        'CityDataGridViewTextBoxColumn
        '
        Me.CityDataGridViewTextBoxColumn.DataPropertyName = "City"
        Me.CityDataGridViewTextBoxColumn.HeaderText = "City"
        Me.CityDataGridViewTextBoxColumn.Name = "CityDataGridViewTextBoxColumn"
        '
        'PostcodeDataGridViewTextBoxColumn
        '
        Me.PostcodeDataGridViewTextBoxColumn.DataPropertyName = "Postcode"
        Me.PostcodeDataGridViewTextBoxColumn.HeaderText = "Postcode"
        Me.PostcodeDataGridViewTextBoxColumn.Name = "PostcodeDataGridViewTextBoxColumn"
        '
        'CountryDataGridViewTextBoxColumn
        '
        Me.CountryDataGridViewTextBoxColumn.DataPropertyName = "Country"
        Me.CountryDataGridViewTextBoxColumn.HeaderText = "Country"
        Me.CountryDataGridViewTextBoxColumn.Name = "CountryDataGridViewTextBoxColumn"
        '
        'Phone1DataGridViewTextBoxColumn
        '
        Me.Phone1DataGridViewTextBoxColumn.DataPropertyName = "Phone1"
        Me.Phone1DataGridViewTextBoxColumn.HeaderText = "Phone1"
        Me.Phone1DataGridViewTextBoxColumn.Name = "Phone1DataGridViewTextBoxColumn"
        '
        'Phone2DataGridViewTextBoxColumn
        '
        Me.Phone2DataGridViewTextBoxColumn.DataPropertyName = "Phone2"
        Me.Phone2DataGridViewTextBoxColumn.HeaderText = "Phone2"
        Me.Phone2DataGridViewTextBoxColumn.Name = "Phone2DataGridViewTextBoxColumn"
        '
        'FaxNoDataGridViewTextBoxColumn
        '
        Me.FaxNoDataGridViewTextBoxColumn.DataPropertyName = "FaxNo"
        Me.FaxNoDataGridViewTextBoxColumn.HeaderText = "FaxNo"
        Me.FaxNoDataGridViewTextBoxColumn.Name = "FaxNoDataGridViewTextBoxColumn"
        '
        'LicenseEnterpriseDataGridViewTextBoxColumn
        '
        Me.LicenseEnterpriseDataGridViewTextBoxColumn.DataPropertyName = "License_Enterprise"
        Me.LicenseEnterpriseDataGridViewTextBoxColumn.HeaderText = "License_Enterprise"
        Me.LicenseEnterpriseDataGridViewTextBoxColumn.Name = "LicenseEnterpriseDataGridViewTextBoxColumn"
        '
        'LicenseSmallBusinessDataGridViewTextBoxColumn
        '
        Me.LicenseSmallBusinessDataGridViewTextBoxColumn.DataPropertyName = "License_SmallBusiness"
        Me.LicenseSmallBusinessDataGridViewTextBoxColumn.HeaderText = "License_SmallBusiness"
        Me.LicenseSmallBusinessDataGridViewTextBoxColumn.Name = "LicenseSmallBusinessDataGridViewTextBoxColumn"
        '
        'LicenseLiteDataGridViewTextBoxColumn
        '
        Me.LicenseLiteDataGridViewTextBoxColumn.DataPropertyName = "License_Lite"
        Me.LicenseLiteDataGridViewTextBoxColumn.HeaderText = "License_Lite"
        Me.LicenseLiteDataGridViewTextBoxColumn.Name = "LicenseLiteDataGridViewTextBoxColumn"
        '
        'LicenseEducationDataGridViewTextBoxColumn
        '
        Me.LicenseEducationDataGridViewTextBoxColumn.DataPropertyName = "License_Education"
        Me.LicenseEducationDataGridViewTextBoxColumn.HeaderText = "License_Education"
        Me.LicenseEducationDataGridViewTextBoxColumn.Name = "LicenseEducationDataGridViewTextBoxColumn"
        '
        'LicenseTrialDataGridViewTextBoxColumn
        '
        Me.LicenseTrialDataGridViewTextBoxColumn.DataPropertyName = "License_Trial"
        Me.LicenseTrialDataGridViewTextBoxColumn.HeaderText = "License_Trial"
        Me.LicenseTrialDataGridViewTextBoxColumn.Name = "LicenseTrialDataGridViewTextBoxColumn"
        '
        'RefID
        '
        Me.RefID.DataPropertyName = "RefID"
        Me.RefID.HeaderText = "RefID"
        Me.RefID.Name = "RefID"
        '
        'frmClient_Import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1188, 585)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgview)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmClient_Import"
        Me.Text = "YGL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtClientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataSet1 As AutoCreateUpdate.DataSet1
    Friend WithEvents DtClientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostcodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CountryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FaxNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseEnterpriseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseSmallBusinessDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseLiteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseEducationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseTrialDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
