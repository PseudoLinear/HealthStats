using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string cal = "yes";
            while (cal == "yes")
            {
                decimal firstinput;
                decimal secondinput;
                string operation;

                Console.WriteLine("Enter first value");

                firstinput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Select an operation");
                Console.WriteLine("+");
                Console.WriteLine("-");
                Console.WriteLine("*");
                Console.WriteLine("/");
                Console.WriteLine("%");
                Console.WriteLine("^");

                operation = Console.ReadLine();

                Console.WriteLine("Enter second value");
                secondinput = Convert.ToInt32(Console.ReadLine());

                switch (operation)
                {
                    case "+":
                        Console.WriteLine("The answer is " + (firstinput + secondinput));
                        Console.ReadLine();
                        break;

                    case "-":
                        Console.WriteLine("The answer is " + (firstinput - secondinput));
                        Console.ReadLine();
                        break;

                    case "*":
                        Console.WriteLine("The answer is " + (firstinput * secondinput));
                        Console.ReadLine();
                        break;

                    case "/":
                        Console.WriteLine("The answer is " + (firstinput / secondinput));
                        Console.ReadLine();
                        break;

                    case "%":
                        Console.WriteLine("The answer is " + (firstinput % secondinput));
                        Console.ReadLine();
                        break;

                    case "^":

                        decimal exp = firstinput;
                        for (int i = 2; i <= secondinput; i++)
                        {
                            exp = exp * firstinput;

                            Console.WriteLine(exp);
                        }
                        Console.WriteLine("The answer is " + exp);
                        Console.ReadLine();
                        break;









                }
                Console.WriteLine("press 'Enter' to use again");
                Console.ReadLine();
            }
            

            


        }
    }
}
