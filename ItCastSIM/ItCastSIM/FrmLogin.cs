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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        BLL.PersonManager pm = new BLL.PersonManager();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(MessageBox.Show("aa", "bb", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning).ToString());
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPwd.Text.Trim();
            MODEL.Person per = pm.Login(userName);
            if (per == null)
            {
                MessageBox.Show("用户名不存在");
            }
            else
            {
                if (per.PPwd == userPwd)
                {
                    //MessageBox.Show(this.DialogResult.ToString()); none
                    this.DialogResult = DialogResult.OK; //这个窗体你做了相应的合理的操作，那么窗体就会关闭
                    #region 不能关闭起始窗体
                    //MessageBox.Show(per.PCName+":登录成功");
                    //FrmMain frm = new FrmMain();
                    //frm.Text = "欢迎你：" + per.PCName;
                    ////this.Hide();
                    ////this.Visible = false; //设置隐藏属性
                    //frm.ShowDialog();
                    //frm.DialogResult = DialogResult.OK;
                    //this.Close();//关闭当前窗体，如果一个窗体是从另外一个窗体打开的，如果关闭起始的打开窗体，那么通过这个起始窗体打开的所有窗体都会关闭。。也就说明，如果关闭起始窗体，那么就相当于退出应用程序 
                    #endregion
                }
                else
                {
                    MessageBox.Show("密码错误了");
                }
            }
        }
    }
}
