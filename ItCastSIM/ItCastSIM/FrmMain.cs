using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItCastSIM
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void tsmiStudent_Click(object sender, EventArgs e)
        {
            FrmPerson frm = FrmPerson.GetFrmPerson();
            //设置打开的窗体的父窗体
            //窗体不能既是 MDI 子级，又是 MDI 父级。 mdi子窗体不能又同时是MDI父容器
            frm.MdiParent = this;  //被指定为此窗体的 MdiParent 的窗体不是 MdiContainer。说明当前窗体不是mdi容器
            frm.Show();//非顶级窗体不能显示为模式对话框。在调用 showDialog 之前应从所有父窗体中移除该窗体。,就说明了子窗体不能ShowDialog
        }

        private void tsmiClass_Click(object sender, EventArgs e)
        {
            //FrmAreas fr = new FrmAreas();
            //fr.Show();
            //OpenForms是得到已经打开的窗体的集合，并不是指new出来的对象(还没有打开 )
            //OpenForms 得到当前应用程序所打开的所有窗体集合
            if (Application.OpenForms["FrmClasses"] == null) //窗体的类名
            {
                FrmClasses frm = new FrmClasses();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                Application.OpenForms["FrmClasses"].Show();
            }
        }
    }
}
