using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Business_Logic_Layer
{
    public class BMI_Calc
    {
        //BMI = (Weight in Pounds / (Height in inches x Height in inches)) x 703
        public decimal BMI_Result(decimal Height, decimal Weight)
            
        {
            decimal Result = new decimal();

           Result = (Weight / (Height * Height)) * 703;


            
            
            return Result;
        }

    }
}
