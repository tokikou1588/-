using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST1
{
    public partial class fmAddPerson : Form
    {
        public fmAddPerson()
        {
            InitializeComponent();
        }


        BLL.Person bll = new BLL.Person();

        private void button1_Click(object sender, EventArgs e)
        {
            MODEL.Person model = new MODEL.Person();
            model.LoginUserName = txtLoginName.Text.Trim();
            model.LoginPassword = GetMD5.getMD5(txtLoginPWD.Text.Trim());
            model.NickName = txtNickName.Text.Trim();
            model.Gender = chkGender.Checked==true?true:false;
            model.Birthday =Convert.ToDateTime (birthday.Text);
            model.Email = txtEmail.Text.Trim();

            if (bll.AddPerson(model))
            {
                MessageBox.Show("新增成功");

                if (EmailClass.Email.SendEmail())
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show("邮件发送失败");
                }
            }
            else
            {
                MessageBox.Show("新增失败");
            }
        }



    }
}
