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
    public partial class fmActorMange : Form
    {
        //私有化构造函数
        private fmActorMange()
        {
            InitializeComponent();
        }
        #region 单例模式

        //声明一个静态的私有的类变量
        private static fmActorMange fam;
        //然后公开一个属性
        public static fmActorMange Fam
        {
            get
            {
                //判断如果窗体对象不存在或者已关闭就newy一个 然后返回对象
                if (fam == null || fam.IsDisposed == true)
                {
                    fam = new fmActorMange();
                }
                return fam;

            }

        } 

        #endregion

        BLL.Actor bll = new BLL.Actor();
        
        private void fmActorMange_Load(object sender, EventArgs e)
        {
            LoadList(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //准备model对象
            MODEL.Actor model = new MODEL.Actor();

            //将文本框的值赋给model对象 
            model.Name = txtName.Text.Trim();
            model.Age = Convert.ToInt32(txtAge.Text.Trim());
            model.Lv = Convert.ToInt32(txtLvevl.Text.Trim());
            //将model对象添加的数据库中
            if (bll.Add(model))
            {
                MessageBox.Show("添加成功");
                LoadList(0);
            }
            else
            {
                MessageBox.Show("添加数据不合法");
            }
        }

   
        void LoadList(int isDel)
        {
            List<MODEL.Actor> list = bll.GetAllList(isDel);
            dgvActorList.DataSource = list;
         
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //将选中行的对象强转成model对象
            MODEL.Actor model = dgvActorList.SelectedRows[0].DataBoundItem as MODEL.Actor;
            //调用bll的方法 根据传输的model和类型执行相应的操作
            //如果是在回收站的列表中 点击删除则为彻底删除
            if (chboxHSZ.Checked == true)
            {
                if (bll.UpadateIsDel(model, 2) > 0)
                {
                    MessageBox.Show("彻底删除成功");
                    LoadList(1);
                }
            }
            else
            {
                if (bll.UpadateIsDel(model, 1) > 0)
                {
                    MessageBox.Show("删除成功");
                    LoadList(0);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MODEL.Actor model = dgvActorList.SelectedRows[0].DataBoundItem as MODEL.Actor;
            model.Name = txtName.Text.Trim();
            model.Age = Convert.ToInt32(txtAge.Text.Trim());
            model.Lv = Convert.ToInt32(txtLvevl.Text.Trim());
            if (bll.UpadateIsDel(model, -1) > 0)
            {
                MessageBox.Show("修改成功");
                LoadList(0);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void dgvActorList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //准备一个model对象
            MODEL.Actor model = dgvActorList.SelectedRows[0].DataBoundItem as MODEL.Actor;
            //将model的值放在对应文本框里
            txtName.Text = model.Name;
            txtAge.Text = model.Age.ToString();
            txtLvevl.Text = model.Lv.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //判断是否勾选 如果勾选 则加载isDel为1的数据 否则加载isDel为0的数据
            if (chboxHSZ.Checked == true)
            {
                LoadList(1);
                btnHY.Visible = true;
                return;
            }
            LoadList(0);
            btnHY.Visible = false;
        }

        private void btnHY_Click(object sender, EventArgs e)
        {
            if (dgvActorList.SelectedRows.Count > 0)
            {

                // 还原代码
                MODEL.Actor model = dgvActorList.SelectedRows[0].DataBoundItem as MODEL.Actor;
                if (bll.UpadateIsDel(model, 0) > 0)
                {
                    MessageBox.Show("还原成功");
                    LoadList(1);
                }
                else
                {
                    MessageBox.Show("还原失败");
                }
            }
            else
            {
                MessageBox.Show("没有选中");
            }
        }
    }
}
