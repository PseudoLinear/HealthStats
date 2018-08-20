using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2.DAObjects
{
    public class userDAO
    {
        public object roleName;

        public int login_ID { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public int role_ID { get; set; }
    }
}
