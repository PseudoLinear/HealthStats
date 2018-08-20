using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;



namespace DAL2
{
    public class PlayerDataAccess
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["BasketballDB"].ConnectionString;
        //method used to delete a player
        public bool DeletePlayer(int playerID)
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
                        _command.Parameters.AddWithValue("@PlayerID", playerID);
                        //here is where the connection is open
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();
                        success = true;
                        _connection.Close();

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
            }

           
            return success;

        }
        //create a method that will get all my players and place them in a list named _playerlist
        public List<playerDAO> GetAllPlayers()
        {
            List<playerDAO> _playerlist = new List<playerDAO>();
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
                                playerDAO _playerToList = new playerDAO();
                                _playerToList.PlayerID = _reader.GetInt32(0);
                                _playerToList.FirstName = _reader.GetString(1);
                                _playerToList.LastName = _reader.GetString(2);
                                _playerToList.birthdate = _reader.GetDateTime(3);
                                _playerToList.Height = _reader.GetDecimal(4);
                                _playerToList.TeamID = _reader.GetInt32(5);
                                _playerToList.TeamName = _reader.GetString(6);
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

            //using (StreamWriter _writer = new StreamWriter("C:\\Users\admin2\\Desktop\\errorstream", true))
            //    {
            //        _writer.WriteLine(message);
            //    }


            }
            return _playerlist;
        }

        public playerDAO GetPlayerByID(int player_ID)
        {
            playerDAO _playerToGet = new playerDAO();
       
            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_GetPlayerByPlayerID", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@Player_ID", player_ID);
                        //here is where the connection is open
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();
                        
                       

                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            

                            //loop through the dataset or command and write each element to the _playerToList using the player object class
                            while (_reader.Read())
                            {
                               
                                _playerToGet.PlayerID = _reader.GetInt32(0);
                                _playerToGet.FirstName = _reader.GetString(1);
                                _playerToGet.LastName = _reader.GetString(2);
                                _playerToGet.birthdate = _reader.GetDateTime(3);
                                _playerToGet.Height = _reader.GetDecimal(4);
                                _playerToGet.TeamID = _reader.GetInt32(5);
                                _playerToGet.TeamName = _reader.GetString(6);
                                
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

                //using (StreamWriter _writer = new StreamWriter("C:\\Users\admin2\\Desktop\\errorstream", true))
                //    {
                //        _writer.WriteLine(message);
                //    }


            }
            return _playerToGet;
        }

        public bool CreatePlayer(playerDAO PlayerToCreate)
        {
            bool success = false;
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_CreatePlayer", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@FirstName", PlayerToCreate.FirstName);
                        _command.Parameters.AddWithValue("@LastName", PlayerToCreate.LastName);
                        _command.Parameters.AddWithValue("@Birthdate", PlayerToCreate.birthdate);
                        _command.Parameters.AddWithValue("@height", PlayerToCreate.Height);
                        _command.Parameters.AddWithValue("@Team_ID", PlayerToCreate.TeamID);
                        //here is where the connection is open
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();
                        success = true;
                        _connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //error logger
            }

            return success;
        }

        public bool UpdatePlayer(playerDAO PlayerToUpdate)
        {
            bool success = false;
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdatePlayerByPlayerID", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@PlayerID", PlayerToUpdate.PlayerID);
                        _command.Parameters.AddWithValue("@FirstName", PlayerToUpdate.FirstName);
                        _command.Parameters.AddWithValue("@LastName", PlayerToUpdate.LastName);
                        _command.Parameters.AddWithValue("@Birthdate", PlayerToUpdate.birthdate);
                        _command.Parameters.AddWithValue("@height", PlayerToUpdate.Height);
                        
                        //here is where the connection is open
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();
                        success = true;
                        _connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //error logger
            }

            return success;
        }
    }
}
