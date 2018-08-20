using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //user inputs the phrase 1. open
            //Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please choose a menu item");
            Console.WriteLine("Menu");
            Console.WriteLine("1.) Eggs and Bacon");
            string userinput = Console.ReadLine();
            int.TryParse(userinput, out int menuchoice);
            if(menuchoice == 1)
            {
                Console.WriteLine("You have selected eggs and bacon");
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
            Console.ReadLine();
        }   
    }
}
