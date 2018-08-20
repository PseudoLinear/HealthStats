using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthStatsWeb.Models
{
    public class WLC
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal Goal { get; set; }
        public decimal GoalTime { get; set; }
        public int User_ID { get; set; }
        public int ID { get; set; }
        public decimal Result { get; set; }

    }
}