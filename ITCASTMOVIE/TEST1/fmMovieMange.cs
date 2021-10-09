using Microsoft.International.Converters.PinYinConverter;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST1
{

    public partial class fmMovieMange : Form
    {


        //准备一个BLL对象
        BLL.Movie bll = new BLL.Movie();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddOrUpdateGBOX.Text == "新增")
            {
                //调用新增方法
                AddMovie();
            }
            else
            {
                //调用更新方法
                UpdateMovie();
            }



        }
        private void fmMovieMange_Load(object sender, EventArgs e)
        {
            loadlist(null);
        }

        #region 全局变量
        /// <summary>
        /// 全局变量
        /// isDel 删除标记
        /// PageIndex 当前页面
        /// PageSize 页容量
        /// PageCount 总条数
        /// selectmodel 全局查询对象
        /// </summary>
        int isDel = 0;
        int PageIndex = 1;
        int PageSize = 10;
        int PageCount;
        MODEL.Movie selectmodel;
        #endregion

        #region 初始化select对象
        //初始化全局MODEL对象 只要在loadlist调用使用了selectmodel这个全局变量 就初始化
        void GetSelectModel()
        {
            selectmodel = new MODEL.Movie();
            selectmodel.IsDel = isDel;

            #region 给对象赋值


            if (!string.IsNullOrEmpty(txtSelectName.Text.Trim()))
            {
                if (!ChineseChar.IsValidChar(txtSelectName.Text.Trim()[0]))
                {
                    selectmodel.PyName = txtSelectName.Text.Trim();
                }
                else
                {
                    selectmodel.Name = txtSelectName.Text.Trim();
                }
            }

            if (!string.IsNullOrEmpty(cmbSelectType.Text))
            {

                selectmodel.Type = cmbSelectType.Text;
            }


            MODEL.Actor amodel = cmbSelectActor.SelectedItem as MODEL.Actor;
            if (amodel != null)
            {
                selectmodel.Aid = amodel.Id;
            }

            selectmodel.IsQIBING = checkSelectIsQiBing.Checked == true ? true : false;

            if (!string.IsNullOrEmpty(txtSelectArea.Text.Trim()))
            {
                selectmodel.Country = txtSelectArea.Text.Trim();
            }



            #endregion

        }
        #endregion

        #region 加载列表
        void loadlist(MODEL.Movie model)
        {
            //根据条件获取列表
            dgvMoive.DataSource = bll.GetListBySearch(model, PageIndex, PageSize, out PageCount);
            //获取演员列表
            List<MODEL.Actor> alist = new BLL.Actor().GetAllList(0);
            //遍历演员列表 加载到 cmbox空间里
            foreach (MODEL.Actor amodel in alist)
            {
                cmbActor.Items.Add(amodel);
            }
            cmbActor.DisplayMember = "name";
            //判断获取的table的总条数是否为0
            if (PageCount == 0)
            {
                labIndex.Text = "0";
            }
            else
            {
                labIndex.Text = PageIndex.ToString();
            }
            //获取总页面
            labPageCount.Text = Math.Ceiling(PageCount * 1.0 / PageSize).ToString();


        }
        #endregion

        #region 单例模式代码
        private fmMovieMange()
        {
            InitializeComponent();
        }

        private static fmMovieMange fmm;

        public static fmMovieMange Fmm
        {
            get
            {
                if (fmm == null || fmm.IsDisposed == true)
                {
                    fmm = new fmMovieMange();
                }
                return fmm;
            }
        }
        #endregion

        #region 修改方法
        void UpdateMovie()
        {
            //将选中的一行转换为MODEL对象
            MODEL.Movie model = dgvMoive.SelectedRows[0].DataBoundItem as MODEL.Movie;

            #region 给对象赋值
            model.Name = txtMovieName.Text.Trim();
            model.Type = cmbType.Text;
            MODEL.Actor amodel = cmbActor.SelectedItem as MODEL.Actor;
            model.Aid = amodel.Id;
            model.IsQIBING = isQiBing.Checked == true ? true : false;
            model.Country = txtArea.Text.Trim();
            #endregion

            //判断是否修改成功
            if (bll.UpdateMovie(model))
            {
                MessageBox.Show("修改成功");
                loadlist(null);
                AddorUpdate.Visible = false;
            }
            else
            {
                MessageBox.Show("修改失败");
            }

        }
        #endregion

        #region 新增方法
        void AddMovie()
        {
            //准备一个电影model对象
            MODEL.Movie model = new MODEL.Movie();

            #region 给对象赋值
            model.Name = txtMovieName.Text.Trim();

            model.PyName = ChartoPinyin(model.Name);

            model.Type = cmbType.Text;
            MODEL.Actor amodel = cmbActor.SelectedItem as MODEL.Actor;
            model.Aid = amodel.Id;
            model.IsQIBING = isQiBing.Checked == true ? true : false;
            model.Country = txtArea.Text.Trim();
            #endregion

            //判断是否新增成功
            if (bll.AddMovie(model))
            {
                MessageBox.Show("新增成功");
                AddorUpdate.Visible = false;
                loadlist(null);
            }
            else
            {
                MessageBox.Show("未添加成功");
            }
        }
        #endregion

        public string ChartoPinyin(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                ChineseChar ch = new ChineseChar(c);

                for (int i = 0; i < ch.PinyinCount; )
                {

                    sb.Append(ch.Pinyins[0].ToString().Substring(0, ch.Pinyins[0].ToString().Length - 1));
                    break;
                }
            }

            return sb.ToString().ToLower();
        }

        #region 查询按钮
        private void btnSelect_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            GetSelectModel();
            loadlist(selectmodel);


        }
        #endregion

        #region 菜单栏
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrUpdateGBOX.Text = "新增";
            btnAdd.Text = "新增";
            AddorUpdate.Visible = true;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMoive.SelectedRows.Count > 0)
            {
                string ids = "";
                for (int i = 0; i < dgvMoive.SelectedRows.Count; i++)
                {
                    MODEL.Movie model = dgvMoive.SelectedRows[i].DataBoundItem as MODEL.Movie;
                    if (i == 0)
                    {
                        ids = model.Id.ToString();
                    }
                    else
                    {
                        ids += "," + model.Id;
                    }
                }

                int DelCount = bll.UpdateByDel(ids, isDel + 1);
                MessageBox.Show("删除了" + DelCount + "条数据");
                GetSelectModel();
                loadlist(selectmodel);
            }

        }

        private void 回收站ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (isDel == 0)
            {
                isDel = 1;
                回收站ToolStripMenuItem.Text = "主界面";
                GetSelectModel();
                loadlist(selectmodel);

            }
            else
            {
                isDel = 0;
                回收站ToolStripMenuItem.Text = "回收站";
                GetSelectModel();
                loadlist(selectmodel);

            }


        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //获取选中行的 model对象
            MODEL.Movie model = dgvMoive.SelectedRows[0].DataBoundItem as MODEL.Movie;
            //将model对象的值填充到框
            txtMovieName.Text = model.Name;
            txtArea.Text = model.Country;

            //遍历读取演员框来默认帮我们选中
            for (int i = 0; i < cmbActor.Items.Count; i++)
            {
                MODEL.Actor m = cmbActor.Items[i] as MODEL.Actor;
                if (m.Id == model.Aid)
                {
                    cmbActor.Text = m.Name;
                    break;
                }
            }
            //获取电影的类型
            cmbType.Text = model.Type;
            //获取电影是否无码
            isQiBing.Checked = model.IsQIBING;
            //修改面板的值
            AddOrUpdateGBOX.Text = "修改";
            btnAdd.Text = "修改";
            //显示出面板
            AddorUpdate.Visible = true;
        }
        #endregion

        #region 分页调用
        private void UpIndex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //判断已经是否是第一页 如果是 就提示是第一页并退出这个事件
            if (labIndex.Text == "1")
            {
                MessageBox.Show("已经第一页了");
                return;
            }
            //否则将页面减一
            PageIndex--;
            labIndex.Text = PageIndex.ToString();

            //初始化话全局model对象
            GetSelectModel();
            //加载
            loadlist(selectmodel);
        }

        private void DownIndex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (labIndex.Text == labPageCount.Text)
            {
                MessageBox.Show("已经是最后一页了");
                return;
            }
            PageIndex++;
            labIndex.Text = PageIndex.ToString();
            GetSelectModel();
            loadlist(selectmodel);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();//创建文件保存对话框
            DialogResult res = sfd.ShowDialog();//得到对话框关闭时返回的结果
            if (res == DialogResult.OK)
            {
                if (dgvMoive.RowCount == 0)
                    return; //说明没有数据
                string path = sfd.FileName+ ".xls";
                using (FileStream fs = new FileStream(path , FileMode.OpenOrCreate))
                {
                    HSSFWorkbook workbook = new HSSFWorkbook();//准备一个EXCEL表 
                    HSSFSheet sheet = workbook.CreateSheet("电影表");//创建一个工作簿
                    for (int i = 0; i < dgvMoive.RowCount; i++)//嵌套循环遍历
                    {
                        HSSFRow row = sheet.CreateRow(i);//创建Excel行
                        for (int j = 0; j < dgvMoive.ColumnCount; j++)
                        {
                            HSSFCell cell = row.CreateCell(j); //创建Excel列
                            cell.SetCellValue(dgvMoive[j, i].Value.ToString());//为列填值
                        }
                    } 
                    workbook.Write(fs);//将数据写入到磁盘
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();//打开文件对话框
            ofd.Filter = "Excel文档|*.xls";//限制打开的文本类型
            DialogResult res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                string path = ofd.FileName;
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    //准备一个EXCEL表 并从文件流里读取
                    HSSFWorkbook work = new HSSFWorkbook(fs);
                    //准备一个sheet从EXCEL表里并获取指定工作簿
                    HSSFSheet sheet = work.GetSheet("电影表");
                    //准备一行并从sheet里获取指定行
                    HSSFRow row = sheet.GetRow(0);
                    //准备一列并从行里获取指定列
                    HSSFCell cell = row.GetCell(2);
                    //通过cell.StringCellValue获取到了单元格的值
                    MessageBox.Show(cell.StringCellValue.ToString());
                }
            }
        }


    }
}
