namespace TEST1
{
    partial class fmMangeMain
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
            this.演员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电影管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增管理员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.演员管理ToolStripMenuItem,
            this.电影管理ToolStripMenuItem,
            this.新增管理员ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 演员管理ToolStripMenuItem
            // 
            this.演员管理ToolStripMenuItem.Name = "演员管理ToolStripMenuItem";
            this.演员管理ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.演员管理ToolStripMenuItem.Text = "演员管理";
            this.演员管理ToolStripMenuItem.Click += new System.EventHandler(this.演员管理ToolStripMenuItem_Click);
            // 
            // 电影管理ToolStripMenuItem
            // 
            this.电影管理ToolStripMenuItem.Name = "电影管理ToolStripMenuItem";
            this.电影管理ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.电影管理ToolStripMenuItem.Text = "电影管理";
            this.电影管理ToolStripMenuItem.Click += new System.EventHandler(this.电影管理ToolStripMenuItem_Click);
            // 
            // 新增管理员ToolStripMenuItem
            // 
            this.新增管理员ToolStripMenuItem.Name = "新增管理员ToolStripMenuItem";
            this.新增管理员ToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.新增管理员ToolStripMenuItem.Text = "新增管理员";
            this.新增管理员ToolStripMenuItem.Click += new System.EventHandler(this.新增管理员ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // fmMangeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 447);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmMangeMain";
            this.Text = "管理界面";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 演员管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电影管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增管理员ToolStripMenuItem;
    }
}