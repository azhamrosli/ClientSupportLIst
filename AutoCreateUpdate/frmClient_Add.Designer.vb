<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClient_Add
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPhone1 = New System.Windows.Forms.TextBox()
        Me.txtPhone2 = New System.Windows.Forms.TextBox()
        Me.txtFaxNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRefID = New System.Windows.Forms.TextBox()
        Me.chkBan = New System.Windows.Forms.CheckBox()
        Me.btnGenerateID = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkSQL_En = New System.Windows.Forms.CheckBox()
        Me.chkLite_B = New System.Windows.Forms.CheckBox()
        Me.chkLite_C = New System.Windows.Forms.CheckBox()
        Me.chkSmallBusiness_B = New System.Windows.Forms.CheckBox()
        Me.chkSmallBusiness_C = New System.Windows.Forms.CheckBox()
        Me.chkEnterprise_B = New System.Windows.Forms.CheckBox()
        Me.chkEnterprise_C = New System.Windows.Forms.CheckBox()
        Me.chkTrial = New System.Windows.Forms.CheckBox()
        Me.chkEducation = New System.Windows.Forms.CheckBox()
        Me.chkLite = New System.Windows.Forms.CheckBox()
        Me.chkSmallBusiness = New System.Windows.Forms.CheckBox()
        Me.chkEnterprise = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.LvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyPhoneNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyEmailToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtServerName = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1371, 49)
        Me.Panel1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(136, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Client Add"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1296, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(75, 49)
        Me.Panel3.TabIndex = 9
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Company ID :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Company Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Address :"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(187, 35)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(347, 27)
        Me.txtID.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(187, 111)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(488, 27)
        Me.txtName.TabIndex = 2
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(187, 148)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(488, 27)
        Me.txtAddress1.TabIndex = 3
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(187, 185)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(488, 27)
        Me.txtAddress2.TabIndex = 4
        '
        'txtAddress3
        '
        Me.txtAddress3.Location = New System.Drawing.Point(187, 222)
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(488, 27)
        Me.txtAddress3.TabIndex = 5
        '
        'txtPostcode
        '
        Me.txtPostcode.Location = New System.Drawing.Point(187, 259)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(371, 27)
        Me.txtPostcode.TabIndex = 6
        '
        'txtCountry
        '
        Me.txtCountry.Location = New System.Drawing.Point(187, 370)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(371, 27)
        Me.txtCountry.TabIndex = 9
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(187, 296)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(371, 27)
        Me.txtCity.TabIndex = 7
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(187, 333)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(371, 27)
        Me.txtState.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Postcode :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 299)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 20)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "City :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 336)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "State :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 373)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 20)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Country :"
        '
        'txtPhone1
        '
        Me.txtPhone1.Location = New System.Drawing.Point(187, 407)
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.Size = New System.Drawing.Size(371, 27)
        Me.txtPhone1.TabIndex = 10
        '
        'txtPhone2
        '
        Me.txtPhone2.Location = New System.Drawing.Point(187, 444)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.Size = New System.Drawing.Size(371, 27)
        Me.txtPhone2.TabIndex = 11
        '
        'txtFaxNo
        '
        Me.txtFaxNo.Location = New System.Drawing.Point(187, 481)
        Me.txtFaxNo.Name = "txtFaxNo"
        Me.txtFaxNo.Size = New System.Drawing.Size(371, 27)
        Me.txtFaxNo.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 410)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 20)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Phone 1 :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 447)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 20)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Phone 2 :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 484)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 20)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Fax No :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(564, 447)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 20)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Optional"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtServerName)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtRefID)
        Me.GroupBox1.Controls.Add(Me.chkBan)
        Me.GroupBox1.Controls.Add(Me.btnGenerateID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.txtFaxNo)
        Me.GroupBox1.Controls.Add(Me.txtAddress1)
        Me.GroupBox1.Controls.Add(Me.txtPhone2)
        Me.GroupBox1.Controls.Add(Me.txtAddress2)
        Me.GroupBox1.Controls.Add(Me.txtPhone1)
        Me.GroupBox1.Controls.Add(Me.txtAddress3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPostcode)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCountry)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCity)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtState)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(700, 575)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General Information"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 20)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Ref ID :"
        '
        'txtRefID
        '
        Me.txtRefID.Location = New System.Drawing.Point(187, 74)
        Me.txtRefID.Name = "txtRefID"
        Me.txtRefID.Size = New System.Drawing.Size(488, 27)
        Me.txtRefID.TabIndex = 35
        '
        'chkBan
        '
        Me.chkBan.AutoSize = True
        Me.chkBan.Location = New System.Drawing.Point(187, 551)
        Me.chkBan.Name = "chkBan"
        Me.chkBan.Size = New System.Drawing.Size(147, 24)
        Me.chkBan.TabIndex = 34
        Me.chkBan.Text = "is Terminate / Ban"
        Me.chkBan.UseVisualStyleBackColor = True
        '
        'btnGenerateID
        '
        Me.btnGenerateID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateID.Location = New System.Drawing.Point(540, 30)
        Me.btnGenerateID.Name = "btnGenerateID"
        Me.btnGenerateID.Size = New System.Drawing.Size(135, 40)
        Me.btnGenerateID.TabIndex = 0
        Me.btnGenerateID.Text = "Generate ID"
        Me.btnGenerateID.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkSQL_En)
        Me.GroupBox2.Controls.Add(Me.chkLite_B)
        Me.GroupBox2.Controls.Add(Me.chkLite_C)
        Me.GroupBox2.Controls.Add(Me.chkSmallBusiness_B)
        Me.GroupBox2.Controls.Add(Me.chkSmallBusiness_C)
        Me.GroupBox2.Controls.Add(Me.chkEnterprise_B)
        Me.GroupBox2.Controls.Add(Me.chkEnterprise_C)
        Me.GroupBox2.Controls.Add(Me.chkTrial)
        Me.GroupBox2.Controls.Add(Me.chkEducation)
        Me.GroupBox2.Controls.Add(Me.chkLite)
        Me.GroupBox2.Controls.Add(Me.chkSmallBusiness)
        Me.GroupBox2.Controls.Add(Me.chkEnterprise)
        Me.GroupBox2.Location = New System.Drawing.Point(718, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(641, 224)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "License Type"
        '
        'chkSQL_En
        '
        Me.chkSQL_En.AutoSize = True
        Me.chkSQL_En.Location = New System.Drawing.Point(431, 147)
        Me.chkSQL_En.Name = "chkSQL_En"
        Me.chkSQL_En.Size = New System.Drawing.Size(119, 24)
        Me.chkSQL_En.TabIndex = 11
        Me.chkSQL_En.Text = "SQL Enterpise"
        Me.chkSQL_En.UseVisualStyleBackColor = True
        '
        'chkLite_B
        '
        Me.chkLite_B.AutoSize = True
        Me.chkLite_B.Location = New System.Drawing.Point(431, 111)
        Me.chkLite_B.Name = "chkLite_B"
        Me.chkLite_B.Size = New System.Drawing.Size(75, 24)
        Me.chkLite_B.TabIndex = 10
        Me.chkLite_B.Text = "Lite B+"
        Me.chkLite_B.UseVisualStyleBackColor = True
        '
        'chkLite_C
        '
        Me.chkLite_C.AutoSize = True
        Me.chkLite_C.Location = New System.Drawing.Point(220, 111)
        Me.chkLite_C.Name = "chkLite_C"
        Me.chkLite_C.Size = New System.Drawing.Size(75, 24)
        Me.chkLite_C.TabIndex = 9
        Me.chkLite_C.Text = "Lite C+"
        Me.chkLite_C.UseVisualStyleBackColor = True
        '
        'chkSmallBusiness_B
        '
        Me.chkSmallBusiness_B.AutoSize = True
        Me.chkSmallBusiness_B.Location = New System.Drawing.Point(431, 72)
        Me.chkSmallBusiness_B.Name = "chkSmallBusiness_B"
        Me.chkSmallBusiness_B.Size = New System.Drawing.Size(147, 24)
        Me.chkSmallBusiness_B.TabIndex = 8
        Me.chkSmallBusiness_B.Text = "Small Business B+"
        Me.chkSmallBusiness_B.UseVisualStyleBackColor = True
        '
        'chkSmallBusiness_C
        '
        Me.chkSmallBusiness_C.AutoSize = True
        Me.chkSmallBusiness_C.Location = New System.Drawing.Point(220, 75)
        Me.chkSmallBusiness_C.Name = "chkSmallBusiness_C"
        Me.chkSmallBusiness_C.Size = New System.Drawing.Size(147, 24)
        Me.chkSmallBusiness_C.TabIndex = 7
        Me.chkSmallBusiness_C.Text = "Small Business C+"
        Me.chkSmallBusiness_C.UseVisualStyleBackColor = True
        '
        'chkEnterprise_B
        '
        Me.chkEnterprise_B.AutoSize = True
        Me.chkEnterprise_B.Location = New System.Drawing.Point(431, 37)
        Me.chkEnterprise_B.Name = "chkEnterprise_B"
        Me.chkEnterprise_B.Size = New System.Drawing.Size(121, 24)
        Me.chkEnterprise_B.TabIndex = 6
        Me.chkEnterprise_B.Text = "Enterprise B +"
        Me.chkEnterprise_B.UseVisualStyleBackColor = True
        '
        'chkEnterprise_C
        '
        Me.chkEnterprise_C.AutoSize = True
        Me.chkEnterprise_C.Location = New System.Drawing.Point(220, 37)
        Me.chkEnterprise_C.Name = "chkEnterprise_C"
        Me.chkEnterprise_C.Size = New System.Drawing.Size(117, 24)
        Me.chkEnterprise_C.TabIndex = 5
        Me.chkEnterprise_C.Text = "Enterprise C+"
        Me.chkEnterprise_C.UseVisualStyleBackColor = True
        '
        'chkTrial
        '
        Me.chkTrial.AutoSize = True
        Me.chkTrial.Location = New System.Drawing.Point(35, 178)
        Me.chkTrial.Name = "chkTrial"
        Me.chkTrial.Size = New System.Drawing.Size(56, 24)
        Me.chkTrial.TabIndex = 4
        Me.chkTrial.Text = "Trial"
        Me.chkTrial.UseVisualStyleBackColor = True
        '
        'chkEducation
        '
        Me.chkEducation.AutoSize = True
        Me.chkEducation.Location = New System.Drawing.Point(35, 143)
        Me.chkEducation.Name = "chkEducation"
        Me.chkEducation.Size = New System.Drawing.Size(94, 24)
        Me.chkEducation.TabIndex = 3
        Me.chkEducation.Text = "Education"
        Me.chkEducation.UseVisualStyleBackColor = True
        '
        'chkLite
        '
        Me.chkLite.AutoSize = True
        Me.chkLite.Location = New System.Drawing.Point(35, 108)
        Me.chkLite.Name = "chkLite"
        Me.chkLite.Size = New System.Drawing.Size(52, 24)
        Me.chkLite.TabIndex = 2
        Me.chkLite.Text = "Lite"
        Me.chkLite.UseVisualStyleBackColor = True
        '
        'chkSmallBusiness
        '
        Me.chkSmallBusiness.AutoSize = True
        Me.chkSmallBusiness.Location = New System.Drawing.Point(35, 75)
        Me.chkSmallBusiness.Name = "chkSmallBusiness"
        Me.chkSmallBusiness.Size = New System.Drawing.Size(124, 24)
        Me.chkSmallBusiness.TabIndex = 1
        Me.chkSmallBusiness.Text = "Small Business"
        Me.chkSmallBusiness.UseVisualStyleBackColor = True
        '
        'chkEnterprise
        '
        Me.chkEnterprise.AutoSize = True
        Me.chkEnterprise.Location = New System.Drawing.Point(35, 38)
        Me.chkEnterprise.Name = "chkEnterprise"
        Me.chkEnterprise.Size = New System.Drawing.Size(94, 24)
        Me.chkEnterprise.TabIndex = 0
        Me.chkEnterprise.Text = "Enterprise"
        Me.chkEnterprise.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(1002, 656)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(174, 57)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(1182, 656)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(174, 57)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnDelete)
        Me.GroupBox3.Controls.Add(Me.btnAdd)
        Me.GroupBox3.Controls.Add(Me.LvList)
        Me.GroupBox3.Location = New System.Drawing.Point(718, 286)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(641, 345)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Person Information"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(515, 46)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 37)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(389, 46)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 37)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'LvList
        '
        Me.LvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvList.BackColor = System.Drawing.Color.White
        Me.LvList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LvList.CheckBoxes = True
        Me.LvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader4, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.LvList.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LvList.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvList.FullRowSelect = True
        Me.LvList.GridLines = True
        Me.LvList.Location = New System.Drawing.Point(20, 89)
        Me.LvList.Name = "LvList"
        Me.LvList.Size = New System.Drawing.Size(615, 243)
        Me.LvList.TabIndex = 2
        Me.LvList.UseCompatibleStateImageBehavior = False
        Me.LvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "ID"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Name"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Phone No"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Email"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 250
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyPhoneNoToolStripMenuItem, Me.CopyEmailToolStripMenuItem, Me.CopyEmailToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(159, 70)
        '
        'CopyPhoneNoToolStripMenuItem
        '
        Me.CopyPhoneNoToolStripMenuItem.Name = "CopyPhoneNoToolStripMenuItem"
        Me.CopyPhoneNoToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.CopyPhoneNoToolStripMenuItem.Text = "Copy Name"
        '
        'CopyEmailToolStripMenuItem
        '
        Me.CopyEmailToolStripMenuItem.Name = "CopyEmailToolStripMenuItem"
        Me.CopyEmailToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.CopyEmailToolStripMenuItem.Text = "Copy Phone No"
        '
        'CopyEmailToolStripMenuItem1
        '
        Me.CopyEmailToolStripMenuItem1.Name = "CopyEmailToolStripMenuItem1"
        Me.CopyEmailToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.CopyEmailToolStripMenuItem1.Text = "Copy Email"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 517)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 20)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Server Name :"
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(187, 514)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(371, 27)
        Me.txtServerName.TabIndex = 37
        '
        'frmClient_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1371, 725)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmClient_Add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "YGL"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPhone1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFaxNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEducation As System.Windows.Forms.CheckBox
    Friend WithEvents chkLite As System.Windows.Forms.CheckBox
    Friend WithEvents chkSmallBusiness As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnterprise As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnGenerateID As System.Windows.Forms.Button
    Friend WithEvents chkTrial As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents LvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkBan As System.Windows.Forms.CheckBox
    Friend WithEvents chkLite_B As System.Windows.Forms.CheckBox
    Friend WithEvents chkLite_C As System.Windows.Forms.CheckBox
    Friend WithEvents chkSmallBusiness_B As System.Windows.Forms.CheckBox
    Friend WithEvents chkSmallBusiness_C As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnterprise_B As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnterprise_C As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyPhoneNoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyEmailToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRefID As System.Windows.Forms.TextBox
    Friend WithEvents chkSQL_En As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
End Class
