using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BasketballStatTracker.Objects;
using System.Data.SqlClient;
using System.Data;
using System.IO;



namespace DAL
{
    public class PlayerDataAccess
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["BasketballDB"].ConnectionString;
        //method used to delete a player
        public bool DeletePlayer(PlayerDAO PlayerToDelete)
        {
            bool success = false;
            try
            {
                //creating connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //this specifies what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_DeletePlayer", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@PlayerID", PlayerToDelete.PlayerID);
                        //here is where the connection is open
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();
                        success = true;
                        _connection.Close();

                    }

                }

            }
            catch
            {
                //TODO: add an error handling method call here-
            }

            if (success == true)
            {
                Console.WriteLine("You have successfully deleted a PlayerDAO");
                Console.ReadLine();
            }
            return success;

        }
        //create a method that will get all my players and place them in a list named _playerlist
        public List<PlayerDAO> GetAllPlayers()
        {
            List<PlayerDAO> _playerlist = new List<PlayerDAO>();
            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                    
                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_ReadAllPlayer", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        //connect to the database
                        _connection.Open();
                        //open the SQL data reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //loop through the dataset or command and write each element to the _playerToList using the player object class
                            while (_reader.Read())
                            {
                                PlayerDAO _playerToList = new PlayerDAO();
                                _playerToList.PlayerID = _reader.GetInt32(0);
                                _playerToList.FirstName = _reader.GetString(1);
                                _playerToList.LastName = _reader.GetString(2);
                                _playerToList.birthdate = _reader.GetDateTime(3);
                                _playerToList.Height = _reader.GetDecimal(4);
                                _playerToList.TeamName = _reader.GetString(5);
                                _playerlist.Add(_playerToList);
                            }
                        }

                    }
                }
            }
            catch (Exception error)
            {
                string message = string.Format("Time: {0}", DateTime.Now.ToString(""));
                message += Environment.NewLine;
                message += "---------------------------------------------------------";
                message += Environment.NewLine;
                message += string.Format("message {0}", error.Message);
                message += Environment.NewLine;
                message += string.Format("Stack Trace {0}", error.StackTrace);
                message += Environment.NewLine;
                message += string.Format("Source: {0}", error.Source);
                message += Environment.NewLine;
                message += string.Format("TargetSite: {0}", error.TargetSite.ToString());
                message += Environment.NewLine;
                message += "---------------------------------------------------------";
                message += Environment.NewLine;

            using (StreamWriter _writer = new StreamWriter("C:\\Users\admin2\\Desktop\\error stream", true))
                {
                    _writer.WriteLine(message);
                }


            }
            return _playerlist;
        }
    }
}
