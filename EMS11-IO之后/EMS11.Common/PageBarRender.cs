﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS11.Common
{
    using System.Web.Mvc;
    using System.Web;

    public static class PageBarRender
    {
        /// <summary>
        /// 自定义分页控件 ,在@Html上扩展的一个方法
        /// </summary>
        /// <param name="htmlhelper">当前@Html对象</param>
        /// <param name="area">区域名称</param>
        /// <param name="controller">控制器名称</param>
        /// <param name="action">方法名称</param>
        /// <param name="pagesize">每页显示数据的条数</param>
        /// <param name="totalcount">当前分页列表的所有数据总条数</param>
        /// <returns></returns>
        public static MvcHtmlString PageBarBulider(this HtmlHelper htmlhelper, string area, string controller, string action, int pagesize, int totalcount)
        {
            //从url参数pageindex 获取当前的页索引
            string currentpageindex = HttpContext.Current.Request.QueryString["pageindex"];
            int icurrentPi = 1;
            //由于第一次进入某个列表页面是不会带有pageindex和pagesize参数的，所以currentpageindex 有可能为空
            //当为空的时候应该赋值1才正常
            if (string.IsNullOrEmpty(currentpageindex))
            {
                icurrentPi = 1;
            }
            else
            {
                icurrentPi = Convert.ToInt32(currentpageindex);
            }

            //1.0 计算出当前列表总共有多少页数据
            decimal pagecount = Math.Ceiling((totalcount / Convert.ToDecimal(pagesize)));

            //2.0 拼装当前分页控件使用的url
            string areaPix = string.IsNullOrEmpty(area) ? "" : "/" + area;
            string urlfmt = areaPix + "/" + controller + "/" + action + "?pageindex={0}&pagesize={1}";

            System.Text.StringBuilder html = new StringBuilder(200);
            html.Append("<div id=pagebar><ul>");
            html.Append("<li><a href=\"" + string.Format(urlfmt, 1, pagesize) + "\">首页</a></li>");
            html.Append("<li><a href=\"" + string.Format(urlfmt, icurrentPi == 1 ? 1 : icurrentPi - 1, pagesize) + "\">上一页</a></li>");
            for (int i = 1; i <= pagecount; i++)
            {
                if (i == icurrentPi)
                {
                    html.Append("<li><a style='color:#ff6a00;' href=\"" + string.Format(urlfmt, i, pagesize) + "\">" + i + "</a></li>");
                }
                else
                {
                    html.Append("<li><a href=\"" + string.Format(urlfmt, i, pagesize) + "\">" + i + "</a></li>");
                }
            }
            html.Append("<li><a href=\"" + string.Format(urlfmt, icurrentPi == pagecount ? pagecount : icurrentPi + 1, pagesize) + "\">下一页</a></li>");
            html.Append("<li><a href=\"" + string.Format(urlfmt, pagecount, pagesize) + "\">尾页</a></li>");
            html.Append("</ul></div>");

            return new MvcHtmlString(html.ToString());
        }

        public static MvcHtmlString PageBarBulider(this HtmlHelper htmlhelper, int pagesize, int totalcount)
        {


            //从url参数pageindex 获取当前的页索引
            string currentpageindex = HttpContext.Current.Request.QueryString["pageindex"];
            int icurrentPi = 1;
            //由于第一次进入某个列表页面是不会带有pageindex和pagesize参数的，所以currentpageindex 有可能为空
            //当为空的时候应该赋值1才正常
            if (string.IsNullOrEmpty(currentpageindex))
            {
                icurrentPi = 1;
            }
            else
            {
                icurrentPi = Convert.ToInt32(currentpageindex);
            }

            //1.0 计算出当前列表总共有多少页数据
            decimal pagecount = Math.Ceiling((totalcount / Convert.ToDecimal(pagesize)));

            //2.0  在分页方法里面获取当前视图所在的url路径
            string url = HttpContext.Current.Request.RawUrl;  //  /roduct/productList/5?pageindex=1&pagesize=6
            if (url.IndexOf("?") > -1)
            {
                url = url.Substring(0, url.IndexOf("?"));  //  /roduct/productList/5?pageindex=1&pagesize=6
            }
            //根据url拼装其分页参数
            string urlfmt = url + "?pageindex={0}&pagesize={1}";

            System.Text.StringBuilder html = new StringBuilder(200);
            html.Append("<div id=pagebar><ul>");
            html.Append("<li><a href=\"" + string.Format(urlfmt, 1, pagesize) + "\">首页</a></li>");
            html.Append("<li><a href=\"" + string.Format(urlfmt, icurrentPi == 1 ? 1 : icurrentPi - 1, pagesize) + "\">上一页</a></li>");
            for (int i = 1; i <= pagecount; i++)
            {
                if (i == icurrentPi)
                {
                    html.Append("<li><a style='color:#ff6a00;' href=\"" + string.Format(urlfmt, i, pagesize) + "\">" + i + "</a></li>");
                }
                else
                {
                    html.Append("<li><a href=\"" + string.Format(urlfmt, i, pagesize) + "\">" + i + "</a></li>");
                }
            }
            html.Append("<li><a href=\"" + string.Format(urlfmt, icurrentPi == pagecount ? pagecount : icurrentPi + 1, pagesize) + "\">下一页</a></li>");
            html.Append("<li><a href=\"" + string.Format(urlfmt, pagecount, pagesize) + "\">尾页</a></li>");
            html.Append("</ul></div>");

            return new MvcHtmlString(html.ToString());
        }
    }
}
