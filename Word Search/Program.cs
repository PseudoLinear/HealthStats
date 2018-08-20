using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
     
namespace Word_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Text");
            string sentence = Console.ReadLine().ToLower();
            //Console.WriteLine("Enter a word to search");
            //string word = Console.ReadLine().ToLower();
            int count = 0;

            string[] words = sentence.Split(' ');

            foreach (string element in words)
            {
                if (element == sentence)
                {
                    count++;
                }
            }
            Console.WriteLine("The word " + sentence + " appeared " + count + " times");
            Console.ReadLine();





            
            


            
        }
    }
}
