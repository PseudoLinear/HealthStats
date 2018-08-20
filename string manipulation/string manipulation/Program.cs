using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*create a string array 
              fill the array with values
              clone array change one element
              of the cloned array and print 
              out both arrays*/
            string[] array = { "Kelly", "Tristan", "Kayla" };
            string[] cloned = array.Clone() as string[];
            cloned[0] = "Anna";
            Console.WriteLine(string.Join(",", array));
            Console.WriteLine(string.Join(",", cloned));
            Console.ReadLine();
            
            
            
            
        }
    }
}
