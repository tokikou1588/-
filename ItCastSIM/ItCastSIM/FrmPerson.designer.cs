﻿namespace ItCastSIM
{
    partial class FrmPerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPerson));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pcname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pgender = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.paddtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cboClasses = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnChoice = new System.Windows.Forms.Button();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.cboIdentity = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtPwd2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gpAdd = new System.Windows.Forms.GroupBox();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSearchClass = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsmiAddStudent = new System.Windows.Forms.ToolStripButton();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsmiDelete = new System.Windows.Forms.ToolStripButton();
            this.tsmiShowList = new System.Windows.Forms.ToolStripButton();
            this.tsmiShowRecovery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEmail = new System.Windows.Forms.ToolStripButton();
            this.tsmiExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiID = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpAdd.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.cname,
            this.pcname,
            this.ppyname,
            this.pgender,
            this.pemail,
            this.ptype,
            this.paddtime});
            this.dgvList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvList.Location = new System.Drawing.Point(7, 47);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(834, 378);
            this.dgvList.TabIndex = 9;
            this.dgvList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvList_CellBeginEdit);
            this.dgvList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "PID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // cname
            // 
            this.cname.DataPropertyName = "PCID";
            this.cname.HeaderText = "班级名称";
            this.cname.Name = "cname";
            this.cname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pcname
            // 
            this.pcname.DataPropertyName = "pcname";
            this.pcname.HeaderText = "姓名";
            this.pcname.Name = "pcname";
            // 
            // ppyname
            // 
            this.ppyname.DataPropertyName = "ppyname";
            this.ppyname.HeaderText = "拼音";
            this.ppyname.Name = "ppyname";
            // 
            // pgender
            // 
            this.pgender.DataPropertyName = "GenderString";
            this.pgender.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.pgender.HeaderText = "性别";
            this.pgender.Items.AddRange(new object[] {
            "男",
            "女",
            "妖"});
            this.pgender.Name = "pgender";
            this.pgender.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pgender.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pemail
            // 
            this.pemail.DataPropertyName = "pemail";
            this.pemail.HeaderText = "邮件";
            this.pemail.Name = "pemail";
            // 
            // ptype
            // 
            this.ptype.DataPropertyName = "TypeString";
            this.ptype.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ptype.HeaderText = "身份";
            this.ptype.Items.AddRange(new object[] {
            "教员",
            "学员"});
            this.ptype.Name = "ptype";
            this.ptype.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ptype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // paddtime
            // 
            this.paddtime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paddtime.DataPropertyName = "paddtime";
            this.paddtime.HeaderText = "注册时间";
            this.paddtime.Name = "paddtime";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDel,
            this.tsmiUp});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(100, 22);
            this.tsmiDel.Text = "删除";
            // 
            // tsmiUp
            // 
            this.tsmiUp.Name = "tsmiUp";
            this.tsmiUp.Size = new System.Drawing.Size(100, 22);
            this.tsmiUp.Text = "修改";
            // 
            // cboClasses
            // 
            this.cboClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasses.FormattingEnabled = true;
            this.cboClasses.Location = new System.Drawing.Point(75, 158);
            this.cboClasses.Name = "cboClasses";
            this.cboClasses.Size = new System.Drawing.Size(100, 20);
            this.cboClasses.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(234, 237);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboSearchType
            // 
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Items.AddRange(new object[] {
            "请选择",
            "教员",
            "学员"});
            this.cboSearchType.Location = new System.Drawing.Point(297, 17);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(76, 20);
            this.cboSearchType.TabIndex = 2;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(158, 17);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(100, 21);
            this.txtSearchName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "班级:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(117, 237);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnChoice
            // 
            this.btnChoice.Location = new System.Drawing.Point(315, 197);
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Size = new System.Drawing.Size(67, 23);
            this.btnChoice.TabIndex = 15;
            this.btnChoice.Text = "选择";
            this.btnChoice.UseVisualStyleBackColor = true;
            this.btnChoice.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(326, 159);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(35, 16);
            this.rdoFemale.TabIndex = 13;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "女";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Checked = true;
            this.rdoMale.Location = new System.Drawing.Point(276, 159);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(35, 16);
            this.rdoMale.TabIndex = 12;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "男";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // cboIdentity
            // 
            this.cboIdentity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdentity.FormattingEnabled = true;
            this.cboIdentity.Items.AddRange(new object[] {
            "教员",
            "学员"});
            this.cboIdentity.Location = new System.Drawing.Point(265, 115);
            this.cboIdentity.Name = "cboIdentity";
            this.cboIdentity.Size = new System.Drawing.Size(100, 20);
            this.cboIdentity.TabIndex = 10;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(480, 17);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(107, 21);
            this.dtpStart.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "性别 ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "身份";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(75, 198);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(236, 21);
            this.txtDistrict.TabIndex = 14;
            // 
            // txtPwd2
            // 
            this.txtPwd2.Location = new System.Drawing.Point(265, 73);
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.Size = new System.Drawing.Size(100, 21);
            this.txtPwd2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "确认密码";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(75, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 21);
            this.txtEmail.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(737, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(618, 17);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(107, 21);
            this.dtpEnd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "至";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(381, 19);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(96, 16);
            this.chkDate.TabIndex = 4;
            this.chkDate.Text = "根据日期查询";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = " 地区";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.gpAdd);
            this.groupBox1.Controls.Add(this.dgvList);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkDate);
            this.groupBox1.Controls.Add(this.cboSearchType);
            this.groupBox1.Controls.Add(this.txtSearchName);
            this.groupBox1.Controls.Add(this.cboSearchClass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 431);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "学员列表";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(263, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "身份:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "姓名:";
            // 
            // gpAdd
            // 
            this.gpAdd.BackColor = System.Drawing.Color.Linen;
            this.gpAdd.Controls.Add(this.cboClasses);
            this.gpAdd.Controls.Add(this.btnCancel);
            this.gpAdd.Controls.Add(this.btnOk);
            this.gpAdd.Controls.Add(this.btnChoice);
            this.gpAdd.Controls.Add(this.rdoFemale);
            this.gpAdd.Controls.Add(this.rdoMale);
            this.gpAdd.Controls.Add(this.cboIdentity);
            this.gpAdd.Controls.Add(this.label10);
            this.gpAdd.Controls.Add(this.label8);
            this.gpAdd.Controls.Add(this.txtDistrict);
            this.gpAdd.Controls.Add(this.txtPwd2);
            this.gpAdd.Controls.Add(this.label6);
            this.gpAdd.Controls.Add(this.txtEmail);
            this.gpAdd.Controls.Add(this.label11);
            this.gpAdd.Controls.Add(this.txtLoginName);
            this.gpAdd.Controls.Add(this.label9);
            this.gpAdd.Controls.Add(this.txtPwd);
            this.gpAdd.Controls.Add(this.label7);
            this.gpAdd.Controls.Add(this.label4);
            this.gpAdd.Controls.Add(this.label5);
            this.gpAdd.Controls.Add(this.txtName);
            this.gpAdd.Controls.Add(this.label3);
            this.gpAdd.Location = new System.Drawing.Point(218, 116);
            this.gpAdd.Name = "gpAdd";
            this.gpAdd.Size = new System.Drawing.Size(407, 273);
            this.gpAdd.TabIndex = 10;
            this.gpAdd.TabStop = false;
            this.gpAdd.Text = "新增";
            this.gpAdd.Visible = false;
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(265, 33);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(100, 21);
            this.txtLoginName.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "班级";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(75, 74);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "登陆名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "密码";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "姓名";
            // 
            // cboSearchClass
            // 
            this.cboSearchClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchClass.FormattingEnabled = true;
            this.cboSearchClass.Location = new System.Drawing.Point(43, 17);
            this.cboSearchClass.Name = "cboSearchClass";
            this.cboSearchClass.Size = new System.Drawing.Size(76, 20);
            this.cboSearchClass.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddStudent,
            this.tsmiUpdate,
            this.tsmiDelete,
            this.tsmiShowList,
            this.tsmiShowRecovery,
            this.toolStripSeparator1,
            this.tsmiEmail,
            this.tsmiExit,
            this.toolStripSeparator2,
            this.tsmiID});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(857, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsmiAddStudent
            // 
            this.tsmiAddStudent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAddStudent.Image")));
            this.tsmiAddStudent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiAddStudent.Name = "tsmiAddStudent";
            this.tsmiAddStudent.Size = new System.Drawing.Size(60, 22);
            this.tsmiAddStudent.Text = "新增学员";
            this.tsmiAddStudent.Click += new System.EventHandler(this.tsmiAddStudent_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsmiUpdate.Image")));
            this.tsmiUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(36, 22);
            this.tsmiUpdate.Text = "修改";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDelete.Image")));
            this.tsmiDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(36, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiShowList
            // 
            this.tsmiShowList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiShowList.Image = ((System.Drawing.Image)(resources.GetObject("tsmiShowList.Image")));
            this.tsmiShowList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiShowList.Name = "tsmiShowList";
            this.tsmiShowList.Size = new System.Drawing.Size(60, 22);
            this.tsmiShowList.Text = "查看列表";
            // 
            // tsmiShowRecovery
            // 
            this.tsmiShowRecovery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiShowRecovery.Image = ((System.Drawing.Image)(resources.GetObject("tsmiShowRecovery.Image")));
            this.tsmiShowRecovery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiShowRecovery.Name = "tsmiShowRecovery";
            this.tsmiShowRecovery.Size = new System.Drawing.Size(72, 22);
            this.tsmiShowRecovery.Text = "查看回收站";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsmiEmail
            // 
            this.tsmiEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiEmail.Image = ((System.Drawing.Image)(resources.GetObject("tsmiEmail.Image")));
            this.tsmiEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiEmail.Name = "tsmiEmail";
            this.tsmiEmail.Size = new System.Drawing.Size(60, 22);
            this.tsmiEmail.Text = "发送邮件";
            // 
            // tsmiExit
            // 
            this.tsmiExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiExit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExit.Image")));
            this.tsmiExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(36, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsmiID
            // 
            this.tsmiID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiID.Image = ((System.Drawing.Image)(resources.GetObject("tsmiID.Image")));
            this.tsmiID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiID.Name = "tsmiID";
            this.tsmiID.Size = new System.Drawing.Size(25, 22);
            this.tsmiID.Text = "ID";
            // 
            // FrmPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 466);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPerson_FormClosing);
            this.Load += new System.EventHandler(this.FrmPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpAdd.ResumeLayout(false);
            this.gpAdd.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ComboBox cboClasses;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnChoice;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.ComboBox cboIdentity;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPwd2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gpAdd;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSearchClass;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsmiAddStudent;
        private System.Windows.Forms.ToolStripButton tsmiUpdate;
        private System.Windows.Forms.ToolStripButton tsmiDelete;
        private System.Windows.Forms.ToolStripButton tsmiShowList;
        private System.Windows.Forms.ToolStripButton tsmiShowRecovery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsmiEmail;
        private System.Windows.Forms.ToolStripButton tsmiExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsmiID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.ToolStripMenuItem tsmiUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppyname;
        private System.Windows.Forms.DataGridViewComboBoxColumn pgender;
        private System.Windows.Forms.DataGridViewTextBoxColumn pemail;
        private System.Windows.Forms.DataGridViewComboBoxColumn ptype;
        private System.Windows.Forms.DataGridViewTextBoxColumn paddtime;
    }
}