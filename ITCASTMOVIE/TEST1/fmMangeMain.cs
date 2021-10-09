using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST1
{
    public partial class fmMangeMain : Form
    {
        public fmMangeMain()
        {
            InitializeComponent();
        }

        private void 演员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmActorMange fam = fmActorMange.Fam;
            fam.MdiParent = this;
            fam.Show();
        }

        private void 电影管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmMovieMange fmm = fmMovieMange.Fmm;
            fmm.MdiParent = this;
            fmm.Show();
        }

        private void 新增管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddPerson fap = new fmAddPerson();
            fap.Show();
        }
    }
}
