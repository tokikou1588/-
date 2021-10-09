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
    public partial class fmLogin : Form
    {
        public fmLogin()
        {
            InitializeComponent();
        }



        BLL.Person bll = new BLL.Person();
      
        private void button1_Click(object sender, EventArgs e)
        {
            //判断用户名和密码是否为空
            if (txtLoginUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (txtLoginPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            //声明一个model对象接受用户名和密码并且去BLL层查询
            MODEL.Person model = new MODEL.Person();
            model.LoginUserName = txtLoginUserName.Text.Trim();
            model.LoginPassword = GetMD5.getMD5(txtLoginPassword.Text.Trim());
           //接收Bll层返回的对象
            model =   bll.Login(model);
            //判断Bll层是否真的有返回对象
            if (model.ID > 0)
            {
                MessageBox.Show("欢迎您回来：" + model.NickName);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
