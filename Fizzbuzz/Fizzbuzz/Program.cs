﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzbuzz
{
    class Program
    {
        static void Main()
        {
            for (int i = 1; i <= 100; i++)
            {
                bool fizz = i % 3 == 0;
                bool buzz = i % 5 == 0;
                if (fizz && buzz)
                    Console.WriteLine("fizzbuzz");
                else if (fizz)
                    Console.WriteLine("fizz");
                else if (buzz)
                    Console.WriteLine("buzz");
                else
                    Console.WriteLine(i);
            } 
            

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();

            
            
            
        }       
    }
}
