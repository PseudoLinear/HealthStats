using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BMR_Calc
    {
        
        //Male: BMR = 66 + (6.23 x weight in pounds) + (12.7 x height in inches) - (6.8 x age in years)
        //Female: BMR = 655 + (4.35 x weight in pounds) + (4.7 x height in inches) - (4.7 x age in years)
        public decimal BMR_Result(string Gender, decimal Height, decimal Weight, int Age)
        {
            decimal Result = new decimal();

            switch (Gender)
            {
                case "Male":
                    Result = 66 + ((decimal)6.23 * Weight) + ((decimal)12.7 * Height) - ((decimal)6.8 * Age);
                        break;

                case "Female":
                    Result = 655 + ((decimal)4.35 * Weight) + ((decimal)4.7 * Height) - ((decimal)4.7 * Age);
                    break;

                   
            }
            return Result;
        }

    }
}
