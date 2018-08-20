using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.objects
{
    public class User
    {
        public int user_ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role_ID { get; set; }
    }
}
