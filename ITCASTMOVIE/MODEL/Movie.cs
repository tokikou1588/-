using System;
namespace MODEL
{
    [Serializable]
    /// <summary>
    /// 作者: JamesZou
    /// 描述: 实体层 -- Movie表映射类.
    /// 最后修改时间:2014/1/9 9:25:03
    /// </summary>
    public class Movie
    {
        public Movie()
        { }

        #region 字段们
        protected int _id;
        protected string _name;
        protected string _type;
        protected string _country;
        protected int _aid;
        protected bool _isQIBING;
        protected int _isDel;
        #endregion

        #region 属性们
        /// <summary>
        ///  
        /// </summary>
        /// 
        public int IsDel
        {
            set { _isDel = value; }
            get { return _isDel; }
        }
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        ///  
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        /// <summary>
        ///  
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }

        /// <summary>
        ///  
        /// </summary>
        public string Country
        {
            set { _country = value; }
            get { return _country; }
        }

        /// <summary>
        ///  
        /// </summary>
        public int Aid
        {
            set { _aid = value; }
            get { return _aid; }
        }

        /// <summary>
        ///  
        /// </summary>
        public bool IsQIBING
        {
            set { _isQIBING = value; }
            get { return _isQIBING; }
        }
        #endregion

        public string PyName { get; set; }
    }
}
