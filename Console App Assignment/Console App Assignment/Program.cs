using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            /*create a console app
             * create a menu with the options to
             * 1 open
             * 2 delete
             * 3 exit
             * if 1 is selected and input by user write out you have 
             * chosen to open file
             * use tryparse
             * use switch case
             * --use a bool value to determine if input from user is valid
             The bool value will need to be part of the tryparse
             HINT bool validinput = int.tryparse(,);*/

            Console.WriteLine("Please select an option");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("1.) Open");
            Console.WriteLine("2.) Delete");
            Console.WriteLine("3.) Exit");
            string userinput = Console.ReadLine();
            int.TryParse(userinput, out int menuchoice);


            switch(menuchoice)
                {
                case 1:
                    Console.WriteLine("You have chosen to open file");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("You have chosen to delete file");
                    Console.ReadLine();
                    break;
                case 3:
                    break;
                
                    


            }
               



        }
    }
}
