using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;            //HAVE TO ADD SYSTEM.IO

namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\admin2\\Desktop\\contactlist.txt", true);
            Console.WriteLine(reader.ReadToEnd());
            Console.ReadLine();
            reader.Close();
            reader.Dispose();
        }
    }
}
