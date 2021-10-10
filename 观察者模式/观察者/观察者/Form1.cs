using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 观察者
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObsolotoMgr.Action();
        }

        /// <summary>
        /// 当页面载入完毕以后就往事件上注册两个方法XP，WarkUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ObsolotoMgr.objHandler += XP;
            ObsolotoMgr.objHandler += WarkUp;
        }


        void XP()
        {
            MessageBox.Show("吓跑贼...");
        }

        void WarkUp()
        {
            MessageBox.Show("惊醒主人...");
        }
    }
}
