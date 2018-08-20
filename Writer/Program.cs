using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("contactlist.txt", true);
            writer.WriteLine("John Doe, 26, 660-252-1252, 123 main st, macon mo 63552");
            writer.Close();
            writer.Dispose();
            Console.ReadLine();


        }
    }
}
