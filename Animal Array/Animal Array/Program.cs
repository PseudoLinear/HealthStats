using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Array
{
    class Program
    {
        static void Main()

        {
            // create a 2d array for animals
            string[,] array = new string[,]
            {
                {"cat","dog"},
                {"bird","fish"},
            };
            //Print out array values
            Console.WriteLine(array[0, 0]);
            Console.WriteLine(array[0, 1]);
            Console.WriteLine(array[1, 0]);
            Console.WriteLine(array[1, 1]);
            Console.ReadLine();
        }
    }
}
