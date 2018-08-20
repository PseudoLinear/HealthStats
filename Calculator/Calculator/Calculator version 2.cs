using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string cal = "yes";
            while (cal == "yes")   //lines 13 and 14 set up the loop, hence the open bracket below line 14
            { 

            decimal usernum1;
            decimal usernum2;
            string operation; //used string because sentences 

            Console.WriteLine("Enter your first number");

           usernum1 = Convert.ToDecimal(Console.ReadLine());
           Console.WriteLine("Enter your second number");
           usernum2 = Convert.ToDecimal(Console.ReadLine()); //converted to decimal because input wasn't a word/sentence 
            Console.WriteLine("Select your operation");
            Console.WriteLine("+ to add");
            Console.WriteLine("- to subtract");
            Console.WriteLine("* to multiply");
            Console.WriteLine("/ to divide");
            operation = Console.ReadLine();

            switch (operation)
            {

                case "+":
                    Console.WriteLine("your equation is " + usernum1 + "+" + usernum2 + " your answer is " + (usernum1 + usernum2));
                    Console.ReadLine();
                    break;



                case "-":
                    Console.WriteLine("your equation is " + usernum1 + "-" + usernum2 + " your answer is " + (usernum1 - usernum2));
                    Console.ReadLine();
                    break;



                case "/":
                    Console.WriteLine("your equation is " + usernum1 + "/" + usernum2 + " your answer is " + (usernum1 / usernum2));
                    Console.ReadLine();
                    break;


                case "*":
                    Console.WriteLine("your equation is " + usernum1 + "*" + usernum2 + " your answer is " + (usernum1 * usernum2));
                    Console.ReadLine();
                    break;
            }

                    
                

                    //------------------------------------------------------------------------------------
                    Console.WriteLine("Enter 'yes' if you would like to continue");
                    cal = Console.ReadLine();    // this line makes "cal" equal whatever was input above


                 




                        Console.ReadLine();
            }
        }
    }
}
