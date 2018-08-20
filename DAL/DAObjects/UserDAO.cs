using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAObjects
{
   public class UserDAO
    {
        public int User_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role_ID { get; set; }
    }
}
