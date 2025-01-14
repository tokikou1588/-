﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class HomeController : DemoController
    {
        public ActionResult Index()
        {
            return this.InvokeAction("DemoAction");
        }

        protected override IValueProvider CreateValueProvider()
        {
            NameValueCollection dataSource = new NameValueCollection();

            dataSource.Add("contacts[0].Name", "张三");
            dataSource.Add("contacts[0].PhoneNo", "123456789");
            dataSource.Add("contacts[0].EmailAddress", "zhangsan@gmail.com");
            dataSource.Add("contacts[0].Address.Province", "江苏");
            dataSource.Add("contacts[0].Address.City", "苏州");
            dataSource.Add("contacts[0].Address.District", "工业园区");
            dataSource.Add("contacts[0].Address.Street", "星湖街328号");

            dataSource.Add("contacts[1].Name", "李四");
            dataSource.Add("contacts[1].PhoneNo", "987654321");
            dataSource.Add("contacts[1].EmailAddress", "lisi@gmail.com");
            dataSource.Add("contacts[1].Address.Province", "江苏");
            dataSource.Add("contacts[1].Address.City", "苏州");
            dataSource.Add("contacts[1].Address.District", "工业园区");
            dataSource.Add("contacts[1].Address.Street", "金鸡湖路328号");

            return new NameValueCollectionValueProvider(dataSource, CultureInfo.CurrentCulture);
        }

        public ActionResult DemoAction(Contact[] contacts)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            for (int i = 0; i < contacts.Length; i++)
            {
                string name = contacts[i].Name;
                string phoneNo = contacts[i].PhoneNo;
                string emailAddress = contacts[i].EmailAddress;
                string address = string.Format("{0}省{1}市{2}{3}",
                    contacts[i].Address.Province, contacts[i].Address.City,
                    contacts[i].Address.District, contacts[i].Address.Street);

                parameters.Add(string.Format("[{0}].Name", i), name);
                parameters.Add(string.Format("[{0}].PhoneNo", i), phoneNo);
                parameters.Add(string.Format("[{0}].EmailAddress", i), emailAddress);
                parameters.Add(string.Format("[{0}].Address", i), address);
            }
            return View("DemoAction", parameters);
        }
    }
}
