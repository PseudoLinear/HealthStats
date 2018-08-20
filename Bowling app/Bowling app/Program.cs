using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore
{
    public class Program
    {

        static void Main()
        {

            int[,] scores = new int[11, 4]; // array
            // Loop
            for (int i = 1; i < 11; i++)
            {
                int a = (i - 1);
                int b = (i);
                int c = (i - 2);    
                Console.WriteLine("Please insert your roll value for " + i);
                scores[i, 0] = Convert.ToInt32(Console.ReadLine());

                // strike
                if (scores[i, 0] == 10)
                {
                    if (i == 1)
                    {
                        scores[i, 0] = 10;
                    }

                    else if (i < 4) 
                    {
                        scores[i, 0] = 10;
                    }

                    else if (i == 10)
                    {
                        Console.WriteLine("Strike! Two Bonus balls.");
                        scores[i, 1] = Convert.ToInt32(Console.ReadLine()); 
                        scores[i, 2] = Convert.ToInt32(Console.ReadLine());
                        
                        scores[c, 0] = (10 + scores[a, 0] + scores[b, 0]);
                        scores[a, 0] = (10 + scores[10, 0] + scores[10, 1] + scores[10,2]);

                    }
                    else
                    {
                        scores[c, 0] = (10 + scores[a, 0] + scores[b, 0]);
                    }
                }
                //Gutter ball
                else if (scores[i, 0] == 0)
                {
                    Console.WriteLine("Gutter ball!");

                    scores[i, 1] = Convert.ToInt32(Console.ReadLine());

                    if (scores[i, 1] == 0)
                    {
                        Console.WriteLine("Gutter ball!");
                    }

                    else
                    {

                    }
                }

                // spare
                else
                {
                    if (i == 10)
                    {
                        Console.WriteLine("Roll again.");
                        scores[i, 1] = Convert.ToInt32(Console.ReadLine());
                        if ((scores[i, 0] + scores[i, 1]) == 10)
                        {
                            Console.WriteLine("Bonus Ball Roll one more time");
                            scores[i, 2] = Convert.ToInt32(Console.ReadLine());
                        }
                    }

                    else
                    {
                        Console.WriteLine("Roll again.");
                        scores[i, 1] = Convert.ToInt32(Console.ReadLine());

                        if (i < 3)
                        {
                            scores[a, 0] = (10 + (scores[i, 0]));
                        }

                        else if ((scores[i, 0] + scores[i, 1]) == 10)
                        {
                            scores[a, 0] = (scores[i, 0]);
                        }
                        //Open
                        else
                        {

                        }
                    }



                }



            }     Console.WriteLine(
                    (scores[0,0] + scores[0,1] + scores[1, 0] + scores[1, 1] + scores[2, 0] + scores[2, 1] + scores[3, 0] + scores[3, 1] + scores[4, 0] + scores[4, 1] + scores[5, 0] + scores[5, 1] + scores[6, 0] + scores[6, 1] + scores[7, 0] + scores[7, 1] + scores[8, 0] + scores[8, 1] + scores[9, 0] + scores[9, 1] + scores[10, 0] + scores[10, 1] + scores[10, 2] + scores[10, 3]));
            Console.ReadLine();
            
        }
              

    }
}
