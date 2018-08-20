using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            string seconds = "";
            string minutes = "";
            string hours = "";


            for (int h = 0; h < 24; h++)

            {
                if (h < 10)
                {
                    hours = "0";
                }

                for (int m = 0; m < 60; m++)

                {
                    if (m < 10)
                    {
                        minutes = "0";
                    }





                    for (int s = 0; s < 60; s++)
                    {
                        if (s < 10)
                        {
                            seconds = "0";
                        }


                        Console.WriteLine(hours + h + ":" + minutes + m + ":" + seconds + s);
                        seconds = "";
                        minutes = "";
                        hours = "";
                        
                    }
                }
            }Console.ReadLine();
        }
    }
}       
                 


              
                

            


            

            
        
    

