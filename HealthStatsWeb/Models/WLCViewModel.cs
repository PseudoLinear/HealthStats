using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthStatsWeb.Models
{
    public class WLCViewModel
    {     
        
            public WLC SingleWLC { get; set; }
            public List<WLC> WLCList { get; set; }

            public WLCViewModel()
            {
                SingleWLC = new WLC();
                WLCList = new List<WLC>();
            }
        
    }
}