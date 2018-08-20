using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_s_my_age
{
    class Program
    {   //this is the whats my project
        static void Main(string[] args)

        {   //write out instructions to the user
            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age <18)
            {
                Console.WriteLine("you can watch movie");
            }
            else if (age >= 18 && age < 21) 
            {
                Console.WriteLine("you can buy cigarettes");
           
            }
            else if (age >= 21)
            {
                Console.WriteLine("you can buy alochol");
            }
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }
    }
}
