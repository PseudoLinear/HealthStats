using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketballStatWeb.Models
{
    public class User
    {
        public int login_ID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int role_ID { get; set; }
    }
}