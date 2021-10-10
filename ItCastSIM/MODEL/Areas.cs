using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Areas
    {
        public Areas()
        { }
        #region Model
        private int _aid;
        private string _aname;
        private int _apid;
        private int _asort;
        private DateTime _aaddtime = DateTime.Now;
        private bool _adelflag = false;
        /// <summary>
        /// 
        /// </summary>
        public int AID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AName
        {
            set { _aname = value; }
            get { return _aname; }
        }
        /// <summary>
        /// 父级节点ID(-1为顶级节点)
        /// </summary>
        public int APid
        {
            set { _apid = value; }
            get { return _apid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ASort
        {
            set { _asort = value; }
            get { return _asort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AAddTime
        {
            set { _aaddtime = value; }
            get { return _aaddtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ADelFlag
        {
            set { _adelflag = value; }
            get { return _adelflag; }
        }
        #endregion Model
    }
}
