﻿namespace ItCastSIM
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiUpPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpUserName = new System.Windows.Forms.ToolStripMenuItem();
            this.sdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClass = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFeedBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindowList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpPwd,
            this.tsmiUpUserName,
            this.tsmiClass,
            this.tsmiStudent,
            this.tmiFeedBack,
            this.tsmiWindowList,
            this.tsmiExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.tsmiWindowList;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiUpPwd
            // 
            this.tsmiUpPwd.Name = "tsmiUpPwd";
            this.tsmiUpPwd.Size = new System.Drawing.Size(68, 21);
            this.tsmiUpPwd.Text = "修改密码";
            // 
            // tsmiUpUserName
            // 
            this.tsmiUpUserName.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sdfToolStripMenuItem});
            this.tsmiUpUserName.Name = "tsmiUpUserName";
            this.tsmiUpUserName.Size = new System.Drawing.Size(80, 21);
            this.tsmiUpUserName.Text = "修改用户名";
            // 
            // sdfToolStripMenuItem
            // 
            this.sdfToolStripMenuItem.Name = "sdfToolStripMenuItem";
            this.sdfToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.sdfToolStripMenuItem.Text = "sdf";
            // 
            // tsmiClass
            // 
            this.tsmiClass.Name = "tsmiClass";
            this.tsmiClass.Size = new System.Drawing.Size(68, 21);
            this.tsmiClass.Text = "班级管理";
            this.tsmiClass.Click += new System.EventHandler(this.tsmiClass_Click);
            // 
            // tsmiStudent
            // 
            this.tsmiStudent.Name = "tsmiStudent";
            this.tsmiStudent.Size = new System.Drawing.Size(68, 21);
            this.tsmiStudent.Text = "学员管理";
            this.tsmiStudent.Click += new System.EventHandler(this.tsmiStudent_Click);
            // 
            // tmiFeedBack
            // 
            this.tmiFeedBack.Name = "tmiFeedBack";
            this.tmiFeedBack.Size = new System.Drawing.Size(92, 21);
            this.tmiFeedBack.Text = "反馈信息管理";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(44, 21);
            this.tsmiExit.Text = "退出";
            // 
            // tsmiWindowList
            // 
            this.tsmiWindowList.Name = "tsmiWindowList";
            this.tsmiWindowList.Size = new System.Drawing.Size(44, 21);
            this.tsmiWindowList.Text = "窗口";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 420);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpPwd;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpUserName;
        private System.Windows.Forms.ToolStripMenuItem sdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiClass;
        private System.Windows.Forms.ToolStripMenuItem tsmiStudent;
        private System.Windows.Forms.ToolStripMenuItem tmiFeedBack;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindowList;
    }
}