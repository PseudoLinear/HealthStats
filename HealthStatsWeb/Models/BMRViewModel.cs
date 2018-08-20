using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthStatsWeb.Models
{
    public class BMRViewModel
    {
        public BMR SingleBMR { get; set; }
        public List<BMR> BMRList { get; set; }

        public BMRViewModel()
        {
            SingleBMR = new BMR();
            BMRList = new List<BMR>();
        }
    }
}