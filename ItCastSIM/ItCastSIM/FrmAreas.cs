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
    public partial class FrmAreas : Form
    {
        #region 无参的构造函数
        /// <summary>
        /// 无参的构造函数
        /// </summary>
        public FrmAreas()
        {
            InitializeComponent();
        } 
        #endregion
        FrmPerson frm;
        public FrmAreas(FrmPerson frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        IFillData Ifrm;
        public FrmAreas(IFillData Ifrm) //以接口类型做为参数，可以传入任何实现了接口的类的对象
        {
            InitializeComponent();
            this.Ifrm =Ifrm;
        }
        DGFill DGfrm;
        public FrmAreas(DGFill DGfrm) //以接口类型做为参数，可以传入任何实现了接口的类的对象
        {
            InitializeComponent();
            this.DGfrm = DGfrm;
        }
        BLL.AreasManager am = new BLL.AreasManager();

        List<MODEL.Areas> lists = null;

        #region 窗体加载事件  -void FrmAreas_Load(object sender, EventArgs e)
        /// <summary>
        /// 窗体加载事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAreas_Load(object sender, EventArgs e)
        {
            lists = am.GetAllAraesList(false);
            LoadData(0,null);
        } 
        #endregion

        #region 使用递归实现地区信息的添加  -void LoadData(int id, TreeNode parentNode)
        /// <summary>
        /// 使用递归实现地区信息的添加
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentNode"></param>
        void LoadData(int id, TreeNode parentNode)
        {
            //遍历取得的集合，每一个对象对应着一个节点
            foreach (MODEL.Areas a in lists)
            {
                if (a.APid == id) //省
                {
                    TreeNode node = new TreeNode(a.AName);
                    node.Tag = a; //将当前对应存储到对应的节点中
                    if (parentNode == null)
                    {
                        this.tvlist.Nodes.Add(node);
                    }
                    else
                    {
                        parentNode.Nodes.Add(node);
                    }
                    #region MyRegion
                    //foreach (MODEL.Areas aa in lists)
                    //{
                    //    if (aa.APid == a.AID) //省
                    //    {
                    //        TreeNode subnode = new TreeNode(aa.AName);
                    //        subnode.Tag = aa; //将当前对应存储到对应的节点中
                    //        node.Nodes.Add(subnode);
                    //    }
                    //} 
                    #endregion
                    LoadData(a.AID, node);
                }
            }
        } 
        #endregion

        #region 树控件点击过后 -void tvlist_AfterSelect(object sender, TreeViewEventArgs e)
        /// <summary>
        /// 树控件点击过后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvlist_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.tvlist.SelectedNode;
            if (node == null)
            {
                return;
            }
            int aid = (node.Tag as MODEL.Areas).AID;
            foreach (MODEL.Areas a in lists)
            {
                if (a.APid == aid) //这是当前选择节点的子节点
                {
                    TreeNode subnode = new TreeNode(a.AName);
                    subnode.Tag = a;
                    node.Nodes.Add(subnode);
                }
            }
        } 
        #endregion

        #region 确认用户选择的地区值 +void btnOk_Click(object sender, EventArgs e)
        /// <summary>
        /// 确认用户选择的地区值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            TreeNode node = this.tvlist.SelectedNode;
            if (node == null)
            {
                return;
            }
            StringBuilder sbtr = new StringBuilder();//显示的地区字符串值
            StringBuilder sbIds = new StringBuilder();//需要插入到数据表中的ID号
            GetStrAndIds(sbtr, sbIds, node);
            //frm.txtDistrict.Text = sbtr.ToString().Substring(0,sbtr.Length-1);
            //frm.txtDistrict.Tag = sbIds;
            //传递窗体对象的方法进行赋值
            //frm.FillData(sbtr.ToString().Substring(0, sbtr.Length - 1), sbIds.ToString().Substring(0, sbIds.Length - 1));
            //传递接口的方式进行赋值
            //Ifrm.FillData(sbtr.ToString().Substring(0, sbtr.Length - 1), sbIds.ToString().Substring(0, sbIds.Length - 1));
            //以委托的方式进行赋值
            DGfrm(sbtr.ToString().Substring(0, sbtr.Length - 1), sbIds.ToString().Substring(0, sbIds.Length - 1));
        } 
        #endregion

        #region 递归的方式获取用户选择的地区信息  -void GetStrAndIds(StringBuilder sbtr, StringBuilder sbIds, TreeNode node)
        /// <summary>
        /// 递归的方式获取用户选择的地区信息
        /// </summary>
        /// <param name="sbtr"></param>
        /// <param name="sbIds"></param>
        /// <param name="node"></param>
        void GetStrAndIds(StringBuilder sbtr, StringBuilder sbIds, TreeNode node)
        {
            if (node.Parent != null) //说明当前节点还有父节点，需要再往上找
            {
                GetStrAndIds(sbtr, sbIds, node.Parent);
            }
            sbtr.Append(node.Text + "|"); //添加地区显示文本
            sbIds.Append((node.Tag as MODEL.Areas).AID + "|");
        } 
        #endregion
    }
}
