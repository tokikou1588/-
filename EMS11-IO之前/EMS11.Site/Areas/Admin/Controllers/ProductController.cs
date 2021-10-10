using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS11.Site.Areas.Admin.Controllers
{
    using EMS11.EntityMap;
    using EMS11.Common;
    using EMS11.Model;
    using System.Drawing;
    using EMS11.Model.ModelView;

    public class ProductController : CheckLoginController
    {
        //
        // GET: /Admin/Product/

        #region 1.0 实现产品列表逻辑
        public ActionResult Index()
        {
            SetClist();

            //base.productBLL.DbSet.Where();

            var list = base.productBLL
                .WhereJoin(c => c.is_lock == (int)Enums.EStatus.Normal, new string[] { "Category" })
                .Select(c => c.EntityMap());

            return View(list);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string pname = form["pname"];
            string cateid = form["cateid"];

            int icateid;
            if (int.TryParse(cateid, out icateid) == false)
            {
                icateid = -1;
            }

            //ado.net
            //string sql = "select * from product where 1=1";
            //if (!string.IsNullOrEmpty(pname))
            //{
            //    sql += " and p_title like '%" + pname + "%'";
            //}
            //if (icateid > 0)
            //{
            //    sql += " and category_id = " + icateid;
            //}

            //linq 来动态进行条件组合查询
            var list = (from c in base.productBLL.DbSet
                        where string.IsNullOrEmpty(pname) ? true : c.p_title.Contains(pname)
                        where icateid < 0 ? true : c.category_id == icateid
                        select c)
                        .ToList()
                       .Select(d => d.EntityMap());

            SetClist();

            return View(list);
        }
        #endregion

        #region 2.0 实现产品图片上传功能
        public ActionResult Upload(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(int id, FormCollection form)
        {
            //实现将上传图片保存到服务器磁盘物理目录
            // upload/img下
            //同时将原图产生一个缩略图保存到 upload/thum下

            //1.0 先定义要保存图片的物理路径
            string soucePath = Server.MapPath("/upload/img/");
            string thumPath = Server.MapPath("/upload/thum/");

            //2.0 接收浏览器上传上来的图片资源
            var file = Request.Files[0];

            if (file != null)
            {
                string filename = file.FileName;
                string extName = System.IO.Path.GetExtension(filename); //获取文件的扩展名 .jpg
                string newFileName = Guid.NewGuid() + extName;

                //2.0.1 实现图片的缩略图
                using (Image oldImg = Image.FromStream(file.InputStream))
                {
                    //产生了缩略图thumImg，GetThumbnailImage（）会产生一个bug：对于某些格式的图片产生的缩略图没有任何的图像呈现
                    //Image thumImg = oldImg.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                    #region 解决办法：自己new位图来将原始图片进行缩略处理
                    //解决办法：自己new位图来将原始图片进行缩略处理
                    using (Image thumImg = new Bitmap(120, 120))
                    {
                        using (Graphics g = Graphics.FromImage(thumImg))
                        {
                            g.DrawImage(oldImg
                                , new Rectangle(0, 0, 120, 120)
                                , new Rectangle(0, 0, oldImg.Width, oldImg.Height)
                                , GraphicsUnit.Pixel);
                        }
                    #endregion

                        //2.0.2 将缩略图存入服务器制定的物理路径
                        thumImg.Save(thumPath + newFileName);
                    }

                    //2.0.3 将原始图片保存
                    oldImg.Save(soucePath + newFileName);

                    //2.0.4 将文件名更新到数据库表字段中 img_url
                    var model = base.productBLL.WhereByCondition(c => c.p_id == id).FirstOrDefault();
                    model.img_url = newFileName;
                    base.productBLL.SaveChanges();
                }
            }


            return Redirect("/Admin/Product/Index");
        }
        #endregion

        #region 3.0 实现产品新增功能
        public ActionResult Create()
        {
            SetClist();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductView model)
        {
            model.sort_id = 1;
            model.click = 0;
            model.is_lock = 0;
            model.add_time = DateTime.Now;
            try
            {
                base.productBLL.Add(model.EntityMap());
                base.productBLL.SaveChanges();

                return Redirect("/Admin/Product/Index");
            }
            catch (Exception ex)
            {
                SetClist();
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }
        #endregion

        #region 4.0 编辑功能
        public ActionResult Edit(int id)
        {
            SetClist();
            var model = base.productBLL.WhereByCondition(c => c.p_id == id).FirstOrDefault();

            return View(model.EntityMap());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, ProductView model)
        {
            try
            {
                var entity = base.productBLL.WhereByCondition(c => c.p_id == id).FirstOrDefault();
                entity.p_title = model.p_title;
                entity.p_content = model.p_content;
                entity.p_photo_no = model.p_photo_no;
                entity.category_id = model.category_id;

                base.productBLL.SaveChanges();

                return Redirect("/Admin/Product/Index");
            }
            catch (Exception ex)
            {
                SetClist();
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }
        #endregion

        /// <summary>
        /// 负责将类别数据以SelectList 形式返回给视图
        /// </summary>
        private void SetClist()
        {
            List<Category> catelist = base.categoryBLL.WhereAll().ToList();
            catelist.Insert(0, new Category() { c_id = -1, c_title = "--请选择--" });
            SelectList slist = new SelectList(catelist, "c_id", "c_title");

            ViewBag.clist = slist;
        }

    }
}
