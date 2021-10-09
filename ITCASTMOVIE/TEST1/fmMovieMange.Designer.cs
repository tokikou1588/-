namespace TEST1
{
    partial class fmMovieMange
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddorUpdate = new System.Windows.Forms.Panel();
            this.AddOrUpdateGBOX = new System.Windows.Forms.GroupBox();
            this.isQiBing = new System.Windows.Forms.CheckBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbActor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.dgvMoive = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回收站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkSelectIsQiBing = new System.Windows.Forms.CheckBox();
            this.cmbSelectType = new System.Windows.Forms.ComboBox();
            this.cmbSelectActor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSelectArea = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtSelectName = new System.Windows.Forms.TextBox();
            this.labIndex = new System.Windows.Forms.Label();
            this.labPageCount = new System.Windows.Forms.Label();
            this.UpIndex = new System.Windows.Forms.LinkLabel();
            this.DownIndex = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.AddorUpdate.SuspendLayout();
            this.AddOrUpdateGBOX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoive)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddorUpdate);
            this.groupBox1.Controls.Add(this.dgvMoive);
            this.groupBox1.Location = new System.Drawing.Point(24, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 345);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电影";
            // 
            // AddorUpdate
            // 
            this.AddorUpdate.Controls.Add(this.AddOrUpdateGBOX);
            this.AddorUpdate.Location = new System.Drawing.Point(185, 73);
            this.AddorUpdate.Name = "AddorUpdate";
            this.AddorUpdate.Size = new System.Drawing.Size(397, 236);
            this.AddorUpdate.TabIndex = 1;
            this.AddorUpdate.Visible = false;
            // 
            // AddOrUpdateGBOX
            // 
            this.AddOrUpdateGBOX.Controls.Add(this.isQiBing);
            this.AddOrUpdateGBOX.Controls.Add(this.cmbType);
            this.AddOrUpdateGBOX.Controls.Add(this.cmbActor);
            this.AddOrUpdateGBOX.Controls.Add(this.label5);
            this.AddOrUpdateGBOX.Controls.Add(this.label4);
            this.AddOrUpdateGBOX.Controls.Add(this.label3);
            this.AddOrUpdateGBOX.Controls.Add(this.txtArea);
            this.AddOrUpdateGBOX.Controls.Add(this.label1);
            this.AddOrUpdateGBOX.Controls.Add(this.btnAdd);
            this.AddOrUpdateGBOX.Controls.Add(this.txtMovieName);
            this.AddOrUpdateGBOX.Location = new System.Drawing.Point(3, 21);
            this.AddOrUpdateGBOX.Name = "AddOrUpdateGBOX";
            this.AddOrUpdateGBOX.Size = new System.Drawing.Size(391, 212);
            this.AddOrUpdateGBOX.TabIndex = 0;
            this.AddOrUpdateGBOX.TabStop = false;
            this.AddOrUpdateGBOX.Text = "新增";
            // 
            // isQiBing
            // 
            this.isQiBing.AutoSize = true;
            this.isQiBing.Location = new System.Drawing.Point(217, 112);
            this.isQiBing.Name = "isQiBing";
            this.isQiBing.Size = new System.Drawing.Size(48, 16);
            this.isQiBing.TabIndex = 23;
            this.isQiBing.Text = "骑兵";
            this.isQiBing.UseVisualStyleBackColor = true;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "爱情片",
            "动作片",
            "喜剧片",
            "恐怖片",
            "伦理片"});
            this.cmbType.Location = new System.Drawing.Point(262, 30);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 20);
            this.cmbType.TabIndex = 22;
            // 
            // cmbActor
            // 
            this.cmbActor.FormattingEnabled = true;
            this.cmbActor.Location = new System.Drawing.Point(75, 113);
            this.cmbActor.Name = "cmbActor";
            this.cmbActor.Size = new System.Drawing.Size(127, 20);
            this.cmbActor.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "演员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "地区";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(75, 61);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(127, 21);
            this.txtArea.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "电影名";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(43, 166);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMovieName
            // 
            this.txtMovieName.Location = new System.Drawing.Point(75, 33);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(127, 21);
            this.txtMovieName.TabIndex = 14;
            // 
            // dgvMoive
            // 
            this.dgvMoive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMoive.Location = new System.Drawing.Point(3, 17);
            this.dgvMoive.Name = "dgvMoive";
            this.dgvMoive.RowTemplate.Height = 23;
            this.dgvMoive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMoive.Size = new System.Drawing.Size(782, 325);
            this.dgvMoive.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.回收站ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(826, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.新增ToolStripMenuItem.Text = "新增";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.新增ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 回收站ToolStripMenuItem
            // 
            this.回收站ToolStripMenuItem.Name = "回收站ToolStripMenuItem";
            this.回收站ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.回收站ToolStripMenuItem.Text = "回收站";
            this.回收站ToolStripMenuItem.Click += new System.EventHandler(this.回收站ToolStripMenuItem_Click);
            // 
            // checkSelectIsQiBing
            // 
            this.checkSelectIsQiBing.AutoSize = true;
            this.checkSelectIsQiBing.Location = new System.Drawing.Point(242, 93);
            this.checkSelectIsQiBing.Name = "checkSelectIsQiBing";
            this.checkSelectIsQiBing.Size = new System.Drawing.Size(48, 16);
            this.checkSelectIsQiBing.TabIndex = 33;
            this.checkSelectIsQiBing.Text = "骑兵";
            this.checkSelectIsQiBing.UseVisualStyleBackColor = true;
            // 
            // cmbSelectType
            // 
            this.cmbSelectType.FormattingEnabled = true;
            this.cmbSelectType.Location = new System.Drawing.Point(265, 42);
            this.cmbSelectType.Name = "cmbSelectType";
            this.cmbSelectType.Size = new System.Drawing.Size(121, 20);
            this.cmbSelectType.TabIndex = 32;
            // 
            // cmbSelectActor
            // 
            this.cmbSelectActor.FormattingEnabled = true;
            this.cmbSelectActor.Location = new System.Drawing.Point(83, 91);
            this.cmbSelectActor.Name = "cmbSelectActor";
            this.cmbSelectActor.Size = new System.Drawing.Size(127, 20);
            this.cmbSelectActor.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "演员";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "地区";
            // 
            // txtSelectArea
            // 
            this.txtSelectArea.Location = new System.Drawing.Point(468, 47);
            this.txtSelectArea.Name = "txtSelectArea";
            this.txtSelectArea.Size = new System.Drawing.Size(127, 21);
            this.txtSelectArea.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "电影名";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(474, 88);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 25;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtSelectName
            // 
            this.txtSelectName.Location = new System.Drawing.Point(83, 41);
            this.txtSelectName.Name = "txtSelectName";
            this.txtSelectName.Size = new System.Drawing.Size(127, 21);
            this.txtSelectName.TabIndex = 24;
            // 
            // labIndex
            // 
            this.labIndex.AutoSize = true;
            this.labIndex.Location = new System.Drawing.Point(536, 476);
            this.labIndex.Name = "labIndex";
            this.labIndex.Size = new System.Drawing.Size(41, 12);
            this.labIndex.TabIndex = 34;
            this.labIndex.Text = "label9";
            // 
            // labPageCount
            // 
            this.labPageCount.AutoSize = true;
            this.labPageCount.Location = new System.Drawing.Point(623, 476);
            this.labPageCount.Name = "labPageCount";
            this.labPageCount.Size = new System.Drawing.Size(47, 12);
            this.labPageCount.TabIndex = 35;
            this.labPageCount.Text = "label10";
            // 
            // UpIndex
            // 
            this.UpIndex.AutoSize = true;
            this.UpIndex.Location = new System.Drawing.Point(466, 476);
            this.UpIndex.Name = "UpIndex";
            this.UpIndex.Size = new System.Drawing.Size(41, 12);
            this.UpIndex.TabIndex = 36;
            this.UpIndex.TabStop = true;
            this.UpIndex.Text = "上一页";
            this.UpIndex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UpIndex_LinkClicked);
            // 
            // DownIndex
            // 
            this.DownIndex.AutoSize = true;
            this.DownIndex.Location = new System.Drawing.Point(688, 476);
            this.DownIndex.Name = "DownIndex";
            this.DownIndex.Size = new System.Drawing.Size(41, 12);
            this.DownIndex.TabIndex = 37;
            this.DownIndex.TabStop = true;
            this.DownIndex.Text = "下一页";
            this.DownIndex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DownIndex_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(593, 476);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "/";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "导出Excel表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(670, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "读取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fmMovieMange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 511);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DownIndex);
            this.Controls.Add(this.UpIndex);
            this.Controls.Add(this.labPageCount);
            this.Controls.Add(this.labIndex);
            this.Controls.Add(this.checkSelectIsQiBing);
            this.Controls.Add(this.cmbSelectType);
            this.Controls.Add(this.cmbSelectActor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSelectArea);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtSelectName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmMovieMange";
            this.Text = "fmMovieMange";
            this.Load += new System.EventHandler(this.fmMovieMange_Load);
            this.groupBox1.ResumeLayout(false);
            this.AddorUpdate.ResumeLayout(false);
            this.AddOrUpdateGBOX.ResumeLayout(false);
            this.AddOrUpdateGBOX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoive)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel AddorUpdate;
        private System.Windows.Forms.DataGridView dgvMoive;
        private System.Windows.Forms.GroupBox AddOrUpdateGBOX;
        private System.Windows.Forms.CheckBox isQiBing;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbActor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkSelectIsQiBing;
        private System.Windows.Forms.ComboBox cmbSelectType;
        private System.Windows.Forms.ComboBox cmbSelectActor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSelectArea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtSelectName;
        private System.Windows.Forms.ToolStripMenuItem 回收站ToolStripMenuItem;
        private System.Windows.Forms.Label labIndex;
        private System.Windows.Forms.Label labPageCount;
        private System.Windows.Forms.LinkLabel UpIndex;
        private System.Windows.Forms.LinkLabel DownIndex;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}