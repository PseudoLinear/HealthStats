using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthStats.Models
{
    public class User
    {
        public int User_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role_ID { get; set; }
    }
}