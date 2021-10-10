using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ItCastSIM
{
    public partial class FrmPerson : Form,IFillData
    {      
        /// <summary>
        /// 构造函数
        /// </summary>
        private FrmPerson()
        {
            InitializeComponent();
            //不自动生成列：没有绑定的列不会在dgv控件中显示
            this.dgvList.AutoGenerateColumns = false;
            //如果是手动添加项的下拉列表，它不会自动选择项，需要设置。但是如果是绑定数据源的下拉列表，就会自动选择第一项
            this.cboIdentity.SelectedIndex = 0;
        }
        /// <summary>
        /// 全局的人员表业务层对象
        /// </summary>
        BLL.PersonManager pm = new BLL.PersonManager();
        /// <summary>
        /// 全局的班级表业务层对象
        /// </summary>
        BLL.ClassesManager cm = new BLL.ClassesManager();
        /// <summary>
        /// 全局的地区表业务类对象
        /// </summary>
        BLL.AreasManager am = new BLL.AreasManager();
        /// <summary>
        /// 静态的全局单例对象
        /// </summary>
        static FrmPerson frm = null;

        #region 获取单个实例 + static FrmPerson GetFrmPerson()
        /// <summary>
        /// 获取单个实例
        /// 静态是因为不能创建类的对象
        /// </summary>
        /// <returns></returns>
        public static FrmPerson GetFrmPerson()
        {
            if (frm == null || frm.IsDisposed == true)
            {
                frm = new FrmPerson();
            }
            return frm;
        } 
        #endregion

        #region 关闭窗体，重置单例对象为NULL - void FrmPerson_FormClosing(object sender, FormClosingEventArgs e)
        /// <summary>
        /// 关闭窗体，重置单例对象为NULL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frm = null;
        } 
        #endregion

        #region 窗体加载，显示所有人员信息  +void FrmPerson_Load(object sender, EventArgs e)
        /// <summary>
        /// 窗体加载，显示所有人员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPerson_Load(object sender, EventArgs e)
        {
            //指定dgv控件的数据源
            //得到需要绑定数据源的列
            DataGridViewComboBoxColumn c = (DataGridViewComboBoxColumn)dgvList.Columns["cname"];
            c.DisplayMember = "CName";
            c.ValueMember = "CID";
            c.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvList.DataSource = pm.GetAllPersonList(false);
            c.DataSource = cm.GetAllClassesList(false);
            //MessageBox.Show("aaaaa");
            //指定新增和修改面板中的班级下拉列表数据源
            this.cboClasses.DisplayMember = "CName";
            this.cboClasses.ValueMember = "CID";//也可以通过得到绑定的对象获取这这个值
            this.cboClasses.DataSource = cm.GetAllClassesList(false);
            //绑定查询块中班级列表信息
            this.cboSearchClass.DisplayMember = "CName";
            this.cboSearchClass.ValueMember = "CID";//也可以通过得到绑定的对象获取这这个值
            List<MODEL.Classes> lists=cm.GetAllClassesList(false);
            //添加一个对象到集合的最前面
            lists.Insert(0,new MODEL.Classes(){CID=-1,CName="请选择"});
            this.cboSearchClass.DataSource = lists;
        } 
        #endregion

        #region 删除人员信息  +void tsmiDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            //判断有没有选择一行记录
            if (dgvList.SelectedRows.Count == 0) //如果选择的行数为0，说明没有选择
            {
                return;
            }
            //SelectedRows要求你选择了整行，如果没有，就报错
            //MODEL.Person per=this.dgvList.SelectedRows[0]
            //只要求你选择了这一行其中一个单元格
            DataGridViewRow row = this.dgvList.CurrentRow;
            MODEL.Person per = row.DataBoundItem as MODEL.Person;
            if (pm.DeletePerson(per.PID))
            {
                MessageBox.Show("删除成功");
                this.dgvList.DataSource = pm.GetAllPersonList(false);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        } 
        #endregion

        #region 新增，显示面板  -void tsmiAddStudent_Click(object sender, EventArgs e)
        /// <summary>
        /// 新增，显示面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            gpAdd.Visible = true;
            this.btnOk.Text = "新增";
        } 
        #endregion

        #region 新增和修改操作  - void btnOk_Click(object sender, EventArgs e)
        /// <summary>
        /// 新增和修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //对象的方式得到班级ID
            //MODEL.Classes cla = this.cboClasses.SelectedItem as MODEL.Classes;
            //通过控件之前的绑定项ValueMenber得到班级ID
            //MessageBox.Show(this.cboClasses.SelectedValue.ToString());
            if (ValidateInput())
            {
                MODEL.Person newPer=null;
                if (btnOk.Text == "新增")
                {
                    newPer = new MODEL.Person();
                }
                else if(btnOk.Text=="修改")
                {
                    newPer = this.dgvList.SelectedRows[0].DataBoundItem as MODEL.Person;
                }
                newPer.PCID = (this.cboClasses.SelectedItem as MODEL.Classes).CID;
                newPer.PType = this.cboIdentity.SelectedIndex + 1;
                newPer.PLoginName = txtLoginName.Text.Trim();
                newPer.PCName = txtName.Text.Trim();
                //newPer.PPYName = "";//拼音以后再说
                newPer.PPwd = txtPwd2.Text.Trim();
                newPer.PGender = rdoMale.Checked ? true : false;
                newPer.PEmail = txtEmail.Text.Trim(); //有可能是“”文本框如果没有填写那么得到就是“”而不是null
                newPer.PAreas = txtDistrict.Tag.ToString();
                if (btnOk.Text == "新增")
                {
                     if (pm.AddNewPerson(newPer))
                    {
                        MessageBox.Show("添加成功");
                        this.dgvList.DataSource = pm.GetAllPersonList(false);
                    }
                    else
                    {
                        MessageBox.Show("添加不成功");
                    }
                }
                else if (btnOk.Text == "修改")
                {
                    //MessageBox.Show(?"修改成功":"修改失败");
                    if (pm.UpdatePerson(newPer))
                    {
                        MessageBox.Show("修改成功");
                        this.dgvList.DataSource = pm.GetAllPersonList(false);
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
            }
        }
        #endregion

        #region 验证用户的控件输入  -  bool ValidateInput()
        /// <summary> 
        /// 验证用户的控件输入
        /// </summary>
        /// <returns></returns>
        bool ValidateInput()
        {
            //1.做非空验证
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请输入姓名");
                txtName.Focus();//获取鼠标的光标点
                return false;
            }
            else
            {
                if (Regex.IsMatch(txtName.Text.Trim(), @"\W"))
                {
                    MessageBox.Show("姓名中的特殊字符，请重新输入");
                    txtName.Focus();//获取鼠标的光标点
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtLoginName.Text.Trim()))
            {
                MessageBox.Show("请输入登录名");
                txtLoginName.Focus();//获取鼠标的光标点
                return false;
            }
            else
            {
                if (Regex.IsMatch(txtLoginName.Text.Trim(), @"\W"))
                {
                    MessageBox.Show("登录名中的特殊字符，请重新输入");
                    txtLoginName.Focus();//获取鼠标的光标点
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtPwd.Text.Trim()))
            {
                MessageBox.Show("请输入密码");
                txtPwd.Focus();//获取鼠标的光标点
                return false;
            }
            if (txtPwd.Text != txtPwd2.Text)
            {
                MessageBox.Show("请输入确认密码");
                txtPwd2.Focus();//获取鼠标的光标点
                return false;
            }
            if(!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                //wuhu0723@126.com
                if(!Regex.IsMatch(txtEmail.Text.Trim(),@"\w+[@]\w+[.]\w+"))
                {
                    MessageBox.Show("请输入正确的邮箱");
                    txtEmail.Focus();//获取鼠标的光标点
                    return false;
                }
            }
            return true;
        } 
        #endregion

        #region 查询操作  -void btnSearch_Click(object sender, EventArgs e)
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cboSearchType.Text);
        } 
        #endregion

        #region 退出-关闭当前窗体  -void tsmiExit_Click(object sender, EventArgs e)
        /// <summary>
        /// 退出-关闭当前窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体（如果当前窗体是起始窗体，那么就相当于退出整个应用程序）
            //Application.Exit();//不管在那里，都可以退出整个应用程序
        } 
        #endregion

        #region 修改，显示详细信息 + void tsmiUpdate_Click(object sender, EventArgs e)
        /// <summary>
        /// 修改，显示详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                return;
            }
            btnOk.Text = "修改";
            gpAdd.Visible = true;
            MODEL.Person curPer = this.dgvList.SelectedRows[0].DataBoundItem as MODEL.Person;
            //为控件赋值
            txtDistrict.Text = string.IsNullOrEmpty(curPer.PAreas) ? "" : GetAreas(curPer.PAreas);
            txtDistrict.Tag = curPer.PAreas; //同时将地区值填充到控件的Tag里面
            txtEmail.Text = curPer.PEmail;
            txtLoginName.Text = curPer.PLoginName;
            txtName.Text = curPer.PCName;
            txtPwd.Text = txtPwd2.Text = curPer.PPwd;
            cboIdentity.SelectedIndex = curPer.PType - 1;

            //cboClasses.Text = curPer.Cname;
            cboClasses.SelectedValue = curPer.PCID; //也可以通过设置SelectedValue值，它会自动判断控件中的那一项的valueMenber值与之对应，如果有对应的，就显示对应的DisPlayMenber值    SelectedValue--实际值   3
            if (curPer.PGender)
            {
                rdoMale.Checked = true;
            }
            else
            {
                rdoFemale.Checked = true;
            }
        } 
        #endregion

        #region 获取指定ID的地区信息  + string GetAreas(string areas)
        /// <summary>
        /// 获取指定ID的地区信息
        /// </summary>
        /// <param name="areas"></param>
        /// <returns></returns>
        string GetAreas(string areas)//1|38|510
        {
            StringBuilder sb = new StringBuilder();
            string[] spits = areas.Split('|');
            for (int i = 0; i < spits.Length; i++)
            {
                sb.Append(am.GetArea(spits[i]) + "|");
            }
            return sb.ToString().Substring(0, sb.Length - 1);
        } 
        #endregion

        #region 取消新增和修改操作，恢复控件的原始值  - void btnCancel_Click(object sender, EventArgs e)
        /// <summary>
        /// 取消新增和修改操作，恢复控件的原始值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.gpAdd.Visible = false;
            txtDistrict.Text = txtEmail.Text = txtLoginName.Text = txtName.Text = txtPwd.Text = txtPwd2.Text = "";
            this.cboClasses.SelectedIndex = cboIdentity.SelectedIndex = 0;
            rdoMale.Checked = true;
        } 
        #endregion

        #region 用户的选择从一行切换到另外一行  +void dgvList_SelectionChanged(object sender, EventArgs e)
        /// <summary>
        /// 用户的选择从一行切换到另外一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridViewSelectionMode mode = dgvList.SelectionMode;
            if (isEdit == true)
            {
                if (temp.PCID != per.PCID || temp.Cname != per.Cname || temp.PEmail != per.PEmail || temp.PType != per.PType || temp.PGender != per.PGender)
                {
                    //MessageBox.Show("提交");
                    //MODEL.Person per = this.dgvList.CurrentRow.DataBoundItem as MODEL.Person; //这是不是我想修改对象
                    if (pm.UpdatePerson(per))
                    {
                        MessageBox.Show("修改成功");
                        isEdit = false;
                        this.dgvList.DataSource = pm.GetAllPersonList(false);//绑定数据源会触发SelectionChanged事件
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
                isEdit = false;
                isFirst = true;
            }
        }
        #endregion
        bool isEdit = false;
        bool isFirst = true; //是否是第一次进入编辑状态
        MODEL.Person per = null;
        MODEL.Person temp = new MODEL.Person();//记住第一次进行编辑状态时行的原始的值

        #region 当你选择一个单元格同时进行了编辑状态的时候触发 +void dgvList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        /// <summary>
        /// 当你选择一个单元格同时进行了编辑状态的时候触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //MessageBox.Show("在编辑单元格了");
            isEdit = true;
            per = this.dgvList.CurrentRow.DataBoundItem as MODEL.Person;
            if (isFirst)
            {
                //temp = per;//不能对象=对象
                temp.Cname = per.Cname;
                temp.PCName = per.PCName;
                temp.PEmail = per.PEmail;
                temp.PType = per.PType;
                temp.PGender = per.PGender;
                temp.PCID = per.PCID;
                isFirst = false;
            }
        } 
        #endregion

        private void btnChoice_Click(object sender, EventArgs e)
        {
            DGFill dg = new DGFill(FillData);
            FrmAreas frm = new FrmAreas(FillData);
            frm.ShowDialog();
        }

        public void FillData(string str,string ids)
        {
            txtDistrict.Text = str;
            txtDistrict.Tag = ids;
        }
    }
}
