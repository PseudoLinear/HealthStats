using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace groceryList
{
    class Program
    {
        static void Main(string[] args)
        {
            String runAgain = "yes";
            while (runAgain == "yes")
            {
                String path = "C:\\Users\\admin2\\Desktop\\GroceryList.txt"; //  path to the file
                String groceryItem;
                decimal price;
                int quantity;
                String option;

                /* START
                 * Show user menu
                 * Give user options to */
                Console.WriteLine("Welcome to your grocery list\n");
                Console.WriteLine("Please enter Add: to add to the list.");
                Console.WriteLine("Exit: to exit to the list.");
                Console.WriteLine("Clear: to clear the file.");
                Console.WriteLine("View: to view the file.\n");
                // Get choice from user
                option = Console.ReadLine().ToUpper();

                switch (option)
                {
                    // if add
                    case "ADD":
                        // create file
                        StreamWriter writer = new StreamWriter(path, true);
                        // Get the item, price, and quantity
                        Console.WriteLine("Please intput the items you would like to add to the grocery list");
                        // Write to file
                        groceryItem = Console.ReadLine();
                        writer.WriteLine(groceryItem + Environment.NewLine);
                        Console.WriteLine("Please input the price");
                        price = Convert.ToDecimal(Console.ReadLine());
                        writer.WriteLine(price + Environment.NewLine);
                        Console.WriteLine("Please input the quantity");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        writer.WriteLine(quantity + Environment.NewLine);
                        // Close and dispose file
                        writer.Close();
                        writer.Dispose();
                        break;

                    // if clear
                    case "CLEAR":
                        // Clear the file
                        StreamWriter clear = new StreamWriter(path);
                        Console.WriteLine("clearing the file");
                        // Overwrite fiel with null
                        clear.WriteLine("");
                        // Close and dispose 
                        Console.ReadLine();
                        clear.Close();
                        clear.Dispose();
                        break;

                    // if view
                    case "VIEW":
                        // Create StreamReader
                        StreamReader reader = new StreamReader(path, true);
                        Console.WriteLine("Here is your grocery list");
                        // View file and print to user
                        Console.WriteLine(reader.ReadToEnd());
                        // Close and dispose
                        reader.Close();
                        reader.Dispose();
                        break;
                    // if exit
                    // Exit the program
                    case "EXIT":
                        runAgain = "no";
                        break;

                    default:
                        Console.WriteLine("you did not enter a valid choose");
                        break;

                }
                /* if user chose anything besides exit,
                   after task is done, ask if they want ot re-run the program
                   if yes, rerun program
                   else exit the program*/

                if (runAgain == "no")
                {
                    Environment.Exit(0); // exiting the program
                }
                else
                {
                    Console.WriteLine("Would you like to run again? if so, enter yes");
                    runAgain = Console.ReadLine().ToLower();
                    Console.Clear(); // clearing the console
                }

            }
        }
    }
}

