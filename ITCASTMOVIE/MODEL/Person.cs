using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Person
    {
        public int ID { get; set; }
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }
        public string NickName { get; set; }

        public DateTime? Birthday { get; set; }

        public bool? Gender { get; set; }

        public string CellPhone { get; set; }

        public string Email { get; set; }

        public int IsDel { get; set; }
    

    }
}
