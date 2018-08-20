using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballStatTracker.Objects;



namespace BasketballStatTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a new instance of the player data access
            PlayerDataAccess data = new PlayerDataAccess();

            //communticate with our end user
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("View Players (V)?");
            Console.WriteLine("Delete fromt the database (D)?");
            
            string 
                choice = Console.ReadLine().ToUpper();
            //enter the switch case which will decide the method to call based on the value of the choice
            switch (choice)
            {
                case "V":
                    //calling the player class placing it in a list
                    //creating a new instance of the player class in a list
                    List<PlayerDAO> PlayerToView = new List<PlayerDAO>();
                    //call the view all players method and add value to the player to view list
                    PlayerToView = data.GetAllPlayers();
                    //loop through the PlayerToView list and write out all the values
                    foreach (PlayerDAO singleplayer in PlayerToView)
                    {
                        Console.WriteLine(singleplayer.PlayerID + " " + singleplayer.FirstName + " " + singleplayer.LastName);
                    }
                    Console.ReadLine();
                    break;
                    //this will run when the user inputs D into the choice variable
                case "D":
                    // Prompt user for input
                    Console.WriteLine("Enter the ID of the PlayerDAO you would like to delete");
                    //converting users input to an interger
                    int deletechoice = Convert.ToInt32(Console.ReadLine());
                    // calling the player class and creating a new instance of player class (instanciating)
                    PlayerDAO deleteplayer = new PlayerDAO();
                    // Place the value of delete choice into the player class
                    deleteplayer.PlayerID = deletechoice;
                    // Call the delete player method from playerdataaccess
                    //pass the player class named delete player to the method
                    bool check = data.DeletePlayer(deleteplayer);
                    if (check == true)
                    {
                        Console.WriteLine("You have deleted a PlayerDAO from the database");

                    }
                    else
                    {
                        Console.WriteLine("FAILED to delete");
                    }

                    
                    break;

                   

                default:
                    Console.WriteLine("You have entered an invalid value, try entering 'V' or 'D'");
                    Console.ReadLine();
                    break;
            }   

            
        }
    }
}
