using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class WLC_Calc
    {
        static BMR_Calc bmr = new BMR_Calc();
        //assuming 2000 cal diet
        //3,500 cal in 1 lbs 
        //Goal(lbs) / GoalTime(days) = daily needed cal deficit 
        //(2000 * GoalTime) - (BMR * GoalTime) = cal left to burn (total)
        //cal left to burn / GoalTime = daily needed deficit 
        public decimal WLC_Result(string Gender, int Age, decimal Height, decimal Weight, decimal Goal, decimal GoalTime)
        {
            decimal Result = new decimal();

            Result = (Goal * 3500) + (GoalTime * 2000) - (bmr.BMR_Result(Gender, Height, Weight, Age) * GoalTime);
            Result = Result / GoalTime;

            return Result;
        }
    }
}
