using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthStatsWeb.Models
{
    public class BMR
    {
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int User_ID { get; set; }
        public int ID { get; set; }
        public decimal Result { get; set; }
    }
}