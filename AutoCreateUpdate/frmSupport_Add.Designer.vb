<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupport_Add
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTypeCompany = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtComName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboFormType = New System.Windows.Forms.ComboBox()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.LvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.flpPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFindAttachment = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnSaveRemote = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRefID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTVPass = New System.Windows.Forms.TextBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProblem = New System.Windows.Forms.TextBox()
        Me.txtTVID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPerson = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtYA = New System.Windows.Forms.TextBox()
        Me.txtRefNoPayer = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtReportName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSupportID = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.flpMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSentMessage = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lvLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DataSet11 = New AutoCreateUpdate.DataSet1()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RemoveImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OFDGallery_UploadImg = New System.Windows.Forms.OpenFileDialog()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1314, 663)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pnlLoading)
        Me.TabPage1.Controls.Add(Me.lblTypeCompany)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtComName)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.cboFormType)
        Me.TabPage1.Controls.Add(Me.lblModifiedBy)
        Me.TabPage1.Controls.Add(Me.LvList)
        Me.TabPage1.Controls.Add(Me.flpPanel)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.btnFindAttachment)
        Me.TabPage1.Controls.Add(Me.txtName)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.btnFind)
        Me.TabPage1.Controls.Add(Me.btnSaveRemote)
        Me.TabPage1.Controls.Add(Me.txtID)
        Me.TabPage1.Controls.Add(Me.btnClose)
        Me.TabPage1.Controls.Add(Me.btnClear)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cboStatus)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtRefID)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtTVPass)
        Me.TabPage1.Controls.Add(Me.txtNote)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtProblem)
        Me.TabPage1.Controls.Add(Me.txtTVID)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtPerson)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtYA)
        Me.TabPage1.Controls.Add(Me.txtRefNoPayer)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.txtReportName)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtSupportID)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1306, 637)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Support Details                          "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pnlLoading
        '
        Me.pnlLoading.BackColor = System.Drawing.Color.Black
        Me.pnlLoading.Controls.Add(Me.PictureBox1)
        Me.pnlLoading.Location = New System.Drawing.Point(537, 304)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(118, 34)
        Me.pnlLoading.TabIndex = 230
        Me.pnlLoading.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.AutoCreateUpdate.My.Resources.Resources.loading
        Me.PictureBox1.Location = New System.Drawing.Point(-36, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(206, 25)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblTypeCompany
        '
        Me.lblTypeCompany.AutoSize = True
        Me.lblTypeCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeCompany.Location = New System.Drawing.Point(670, 37)
        Me.lblTypeCompany.Name = "lblTypeCompany"
        Me.lblTypeCompany.Size = New System.Drawing.Size(0, 16)
        Me.lblTypeCompany.TabIndex = 232
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(545, 224)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 16)
        Me.Label13.TabIndex = 231
        Me.Label13.Text = "Form Type :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 212
        Me.Label3.Text = "Company Name :"
        '
        'txtComName
        '
        Me.txtComName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComName.Location = New System.Drawing.Point(673, 111)
        Me.txtComName.MaxLength = 150
        Me.txtComName.Name = "txtComName"
        Me.txtComName.ReadOnly = True
        Me.txtComName.Size = New System.Drawing.Size(444, 22)
        Me.txtComName.TabIndex = 215
        Me.txtComName.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(544, 568)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 16)
        Me.Label14.TabIndex = 229
        Me.Label14.Text = "Modified By :"
        '
        'cboFormType
        '
        Me.cboFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormType.FormattingEnabled = True
        Me.cboFormType.Items.AddRange(New Object() {"Office = SQL", "C+ = SQL", "B+ = SQL", "P+ = SQL", "IEToolbar = SQL", "Office = Access", "C+ = Access", "B+ = Access", "P+ = Access", "IEToolbar = Access", "General", "SQL Lite"})
        Me.cboFormType.Location = New System.Drawing.Point(673, 223)
        Me.cboFormType.Name = "cboFormType"
        Me.cboFormType.Size = New System.Drawing.Size(139, 21)
        Me.cboFormType.TabIndex = 5
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.AutoSize = True
        Me.lblModifiedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModifiedBy.Location = New System.Drawing.Point(669, 568)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Size = New System.Drawing.Size(95, 16)
        Me.lblModifiedBy.TabIndex = 228
        Me.lblModifiedBy.Text = "Azham-Laptop"
        '
        'LvList
        '
        Me.LvList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LvList.BackColor = System.Drawing.Color.White
        Me.LvList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LvList.CheckBoxes = True
        Me.LvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader11, Me.ColumnHeader1, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.LvList.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvList.FullRowSelect = True
        Me.LvList.GridLines = True
        Me.LvList.Location = New System.Drawing.Point(8, 119)
        Me.LvList.Name = "LvList"
        Me.LvList.Size = New System.Drawing.Size(483, 510)
        Me.LvList.TabIndex = 210
        Me.LvList.UseCompatibleStateImageBehavior = False
        Me.LvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "No"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "ID"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Ref ID"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Name"
        Me.ColumnHeader6.Width = 200
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Address"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader7.Width = 300
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Type"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 200
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Phone"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader10.Width = 200
        '
        'flpPanel
        '
        Me.flpPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpPanel.AutoScroll = True
        Me.flpPanel.Location = New System.Drawing.Point(1127, 83)
        Me.flpPanel.Name = "flpPanel"
        Me.flpPanel.Size = New System.Drawing.Size(171, 455)
        Me.flpPanel.TabIndex = 204
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 211
        Me.Label2.Text = "Reference ID :"
        '
        'btnFindAttachment
        '
        Me.btnFindAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAttachment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindAttachment.Location = New System.Drawing.Point(1127, 50)
        Me.btnFindAttachment.Name = "btnFindAttachment"
        Me.btnFindAttachment.Size = New System.Drawing.Size(153, 28)
        Me.btnFindAttachment.TabIndex = 207
        Me.btnFindAttachment.Text = "Add Image"
        Me.btnFindAttachment.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(126, 37)
        Me.txtName.MaxLength = 150
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(365, 22)
        Me.txtName.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1124, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 24)
        Me.Label12.TabIndex = 227
        Me.Label12.Text = "Attachment"
        '
        'btnFind
        '
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.Location = New System.Drawing.Point(374, 66)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(117, 39)
        Me.btnFind.TabIndex = 1
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnSaveRemote
        '
        Me.btnSaveRemote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveRemote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveRemote.Location = New System.Drawing.Point(796, 590)
        Me.btnSaveRemote.Name = "btnSaveRemote"
        Me.btnSaveRemote.Size = New System.Drawing.Size(194, 39)
        Me.btnSaveRemote.TabIndex = 226
        Me.btnSaveRemote.Text = "[shift + enter] Save && Remote"
        Me.btnSaveRemote.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(126, 9)
        Me.txtID.MaxLength = 150
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(365, 22)
        Me.txtID.TabIndex = 197
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(1172, 590)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 39)
        Me.btnClose.TabIndex = 209
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(251, 66)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(117, 39)
        Me.btnClear.TabIndex = 213
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(996, 590)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(170, 39)
        Me.btnSave.TabIndex = 208
        Me.btnSave.Text = "[alt + Enter] Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(544, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "Reference ID :"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"New", "Hold", "Cancel", "Solved", "Cannot Trigger Problem", "Bug on Program", "PC Problem", "Urgent", "Pending To Testing"})
        Me.cboStatus.Location = New System.Drawing.Point(672, 544)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(444, 21)
        Me.cboStatus.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(544, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "Company Name :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(544, 545)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 16)
        Me.Label11.TabIndex = 225
        Me.Label11.Text = "Status :"
        '
        'txtRefID
        '
        Me.txtRefID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefID.Location = New System.Drawing.Point(673, 83)
        Me.txtRefID.MaxLength = 150
        Me.txtRefID.Name = "txtRefID"
        Me.txtRefID.ReadOnly = True
        Me.txtRefID.Size = New System.Drawing.Size(444, 22)
        Me.txtRefID.TabIndex = 217
        Me.txtRefID.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(543, 417)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 16)
        Me.Label10.TabIndex = 224
        Me.Label10.Text = "Note :"
        '
        'txtTVPass
        '
        Me.txtTVPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTVPass.Location = New System.Drawing.Point(673, 167)
        Me.txtTVPass.MaxLength = 150
        Me.txtTVPass.Name = "txtTVPass"
        Me.txtTVPass.Size = New System.Drawing.Size(139, 22)
        Me.txtTVPass.TabIndex = 3
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(672, 414)
        Me.txtNote.MaxLength = 500
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(444, 124)
        Me.txtNote.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(506, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 620)
        Me.Panel1.TabIndex = 218
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(543, 254)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 16)
        Me.Label9.TabIndex = 223
        Me.Label9.Text = "Problem :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(543, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 24)
        Me.Label5.TabIndex = 219
        Me.Label5.Text = "New Support"
        '
        'txtProblem
        '
        Me.txtProblem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProblem.Location = New System.Drawing.Point(672, 251)
        Me.txtProblem.MaxLength = 500
        Me.txtProblem.Multiline = True
        Me.txtProblem.Name = "txtProblem"
        Me.txtProblem.Size = New System.Drawing.Size(444, 157)
        Me.txtProblem.TabIndex = 6
        '
        'txtTVID
        '
        Me.txtTVID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTVID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtTVID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTVID.Location = New System.Drawing.Point(673, 139)
        Me.txtTVID.MaxLength = 150
        Me.txtTVID.Name = "txtTVID"
        Me.txtTVID.Size = New System.Drawing.Size(139, 22)
        Me.txtTVID.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(818, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 222
        Me.Label8.Text = "Person Incharge :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(544, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 220
        Me.Label6.Text = "Teamviwer ID:"
        '
        'txtPerson
        '
        Me.txtPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerson.Location = New System.Drawing.Point(933, 195)
        Me.txtPerson.MaxLength = 150
        Me.txtPerson.Name = "txtPerson"
        Me.txtPerson.Size = New System.Drawing.Size(139, 22)
        Me.txtPerson.TabIndex = 201
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(544, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 16)
        Me.Label7.TabIndex = 221
        Me.Label7.Text = "Teamviewer Pass :"
        '
        'txtYA
        '
        Me.txtYA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYA.Location = New System.Drawing.Point(933, 167)
        Me.txtYA.MaxLength = 150
        Me.txtYA.Name = "txtYA"
        Me.txtYA.Size = New System.Drawing.Size(139, 22)
        Me.txtYA.TabIndex = 236
        Me.txtYA.Text = "0"
        '
        'txtRefNoPayer
        '
        Me.txtRefNoPayer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtRefNoPayer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtRefNoPayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNoPayer.Location = New System.Drawing.Point(933, 139)
        Me.txtRefNoPayer.MaxLength = 150
        Me.txtRefNoPayer.Name = "txtRefNoPayer"
        Me.txtRefNoPayer.Size = New System.Drawing.Size(139, 22)
        Me.txtRefNoPayer.TabIndex = 235
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(817, 169)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 16)
        Me.Label16.TabIndex = 234
        Me.Label16.Text = "YA :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(817, 142)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 16)
        Me.Label15.TabIndex = 233
        Me.Label15.Text = "Reference No :"
        '
        'txtReportName
        '
        Me.txtReportName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtReportName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportName.Location = New System.Drawing.Point(673, 195)
        Me.txtReportName.MaxLength = 150
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.Size = New System.Drawing.Size(139, 22)
        Me.txtReportName.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(543, 198)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 16)
        Me.Label17.TabIndex = 237
        Me.Label17.Text = "Report By :"
        '
        'txtSupportID
        '
        Me.txtSupportID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupportID.Location = New System.Drawing.Point(672, 55)
        Me.txtSupportID.MaxLength = 150
        Me.txtSupportID.Name = "txtSupportID"
        Me.txtSupportID.ReadOnly = True
        Me.txtSupportID.Size = New System.Drawing.Size(444, 22)
        Me.txtSupportID.TabIndex = 240
        Me.txtSupportID.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(543, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 16)
        Me.Label18.TabIndex = 239
        Me.Label18.Text = "Support Ref ID :"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.flpMain)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1306, 637)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Comment(s)                          "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'flpMain
        '
        Me.flpMain.AutoScroll = True
        Me.flpMain.BackColor = System.Drawing.Color.DimGray
        Me.flpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpMain.Location = New System.Drawing.Point(3, 3)
        Me.flpMain.Name = "flpMain"
        Me.flpMain.Size = New System.Drawing.Size(1300, 588)
        Me.flpMain.TabIndex = 194
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSentMessage)
        Me.Panel2.Controls.Add(Me.txtMessage)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 591)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1300, 43)
        Me.Panel2.TabIndex = 193
        '
        'btnSentMessage
        '
        Me.btnSentMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSentMessage.Location = New System.Drawing.Point(1218, 5)
        Me.btnSentMessage.Name = "btnSentMessage"
        Me.btnSentMessage.Size = New System.Drawing.Size(75, 35)
        Me.btnSentMessage.TabIndex = 1
        Me.btnSentMessage.Text = "Sent"
        Me.btnSentMessage.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.Location = New System.Drawing.Point(0, 0)
        Me.txtMessage.MaxLength = 3000
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(1212, 43)
        Me.txtMessage.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lvLog)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1306, 637)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Log                                                           "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lvLog
        '
        Me.lvLog.BackColor = System.Drawing.Color.White
        Me.lvLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvLog.CheckBoxes = True
        Me.lvLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.lvLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvLog.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvLog.FullRowSelect = True
        Me.lvLog.GridLines = True
        Me.lvLog.Location = New System.Drawing.Point(0, 0)
        Me.lvLog.Name = "lvLog"
        Me.lvLog.Size = New System.Drawing.Size(1306, 637)
        Me.lvLog.TabIndex = 211
        Me.lvLog.UseCompatibleStateImageBehavior = False
        Me.lvLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "No"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ID"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "SupportID"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "DateTime"
        Me.ColumnHeader5.Width = 200
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Name"
        Me.ColumnHeader12.Width = 200
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Log"
        Me.ColumnHeader13.Width = 450
        '
        'DataSet11
        '
        Me.DataSet11.DataSetName = "DataSet1"
        Me.DataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Timer1
        '
        Me.Timer1.Interval = 1200
        '
        'RemoveImageToolStripMenuItem
        '
        Me.RemoveImageToolStripMenuItem.Name = "RemoveImageToolStripMenuItem"
        Me.RemoveImageToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.RemoveImageToolStripMenuItem.Text = "Remove Image"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveImageToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(154, 26)
        '
        'OFDGallery_UploadImg
        '
        Me.OFDGallery_UploadImg.FileName = "OpenFileDialog1"
        Me.OFDGallery_UploadImg.Multiselect = True
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'frmSupport_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1314, 663)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1202, 699)
        Me.Name = "frmSupport_Add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Support"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComName As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboFormType As System.Windows.Forms.ComboBox
    Friend WithEvents lblModifiedBy As System.Windows.Forms.Label
    Friend WithEvents LvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents flpPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFindAttachment As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnSaveRemote As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRefID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTVPass As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProblem As System.Windows.Forms.TextBox
    Friend WithEvents txtTVID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPerson As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataSet11 As AutoCreateUpdate.DataSet1
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents RemoveImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OFDGallery_UploadImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSentMessage As System.Windows.Forms.Button
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents flpMain As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblTypeCompany As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lvLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtYA As System.Windows.Forms.TextBox
    Friend WithEvents txtRefNoPayer As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtReportName As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSupportID As System.Windows.Forms.TextBox
End Class
