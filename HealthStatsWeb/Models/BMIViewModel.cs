using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthStatsWeb.Models
{
    public class BMIViewModel
    {
        public BMI SingleBMI { get; set; }
        public List<BMI> BMIList { get; set; }

        public BMIViewModel()
        {
            SingleBMI = new BMI();
            BMIList = new List<BMI>();
        }
    }
}