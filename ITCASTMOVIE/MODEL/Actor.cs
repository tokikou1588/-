using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    [Serializable()]
    public class Actor
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public int IsDel
        {
            get;
            set;
        }
        public int Lv
        {
            get;
            set;
        }
    }
}
