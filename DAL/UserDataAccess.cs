using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAObjects;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using UtilityLogger;

namespace DAL
{
    public class UserDataAccess
    {
        
        static string connectionstring = ConfigurationManager.ConnectionStrings["HealthStatsWeb"].ConnectionString;
        public UserDAO LoginUser(UserDAO _userLogin)
        {
            UserDAO _loginUser = new UserDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_Login", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@UserName", _userLogin.UserName);
                       

                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                _loginUser.User_ID = _reader.GetInt32(0);
                                _loginUser.UserName = _reader.GetString(1);
                                _loginUser.Password = _reader.GetString(2);
                                _loginUser.Role_ID = _reader.GetInt32(3);
                            }
                        }


                        _connection.Close();

                    }
                }
            }
            catch (Exception error)
            {
                //Instatiate a new errorlog and name it log 
                Error_Logger log = new Error_Logger();
                //Call the log error method from errorlogger and pass it error value 
                log.LogError(error);
            }
            return _loginUser;
        }


        //static string connectionstrings = ConfigurationManager.ConnectionStrings["BasketballDB"].ConnectionString;
        public void CreateUser(UserDAO _userCreate)
        {
            UserDAO _CreateUser = new UserDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_CreateUser", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@UserName", _userCreate.UserName);
                        _command.Parameters.AddWithValue("@Password", _userCreate.Password);
                       
                        _connection.Open();
                        _command.ExecuteNonQuery();


                        _connection.Close();
                        _connection.Dispose();

                    }
                }
            }
            catch (Exception error)
            {
                Error_Logger log = new Error_Logger();
                log.LogError(error);
            }

        }
        public List<UserDAO> ViewUsers()
        {
            List<UserDAO> _userlist = new List<UserDAO>();
            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_ViewUsers", _connection))
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
                                UserDAO _userToList = new UserDAO()
                                {
                                    User_ID = _reader.GetInt32(0),
                                    UserName = _reader.GetString(1),
                                    Password = _reader.GetString(2),
                                    Role_ID = _reader.GetInt32(3),
                                };
                                _userlist.Add(_userToList);
                            }
                        }

                    }
                }
            }
            catch (Exception error)
            {
                Error_Logger log = new Error_Logger();
                log.LogError(error);
            }
            return _userlist;
        }
        //STORED PROCEDURE FOR DELETE USER
        public bool DeleteUser(int User_ID)
        {
            bool success = false;
            try
            {
                //creating connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //this specifies what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_DeleteUser", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@User_ID", User_ID);
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
                Error_Logger log = new Error_Logger();
                log.LogError(error);
            }


            return success;

        }
        //CHANGE TO USER
        public bool UpdateUser(UserDAO UserToUpdate)
        {
            bool success = false;
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateUser", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@User_ID", UserToUpdate.User_ID);
                        _command.Parameters.AddWithValue("@UserName", UserToUpdate.UserName);
                        _command.Parameters.AddWithValue("@Password", UserToUpdate.Password);
                        _command.Parameters.AddWithValue("@Role_ID", UserToUpdate.Role_ID);

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
                Error_Logger log = new Error_Logger();
                log.LogError(error);
            }

            return success;
        }
        public UserDAO GetUserByUser_ID(int User_ID)
        {
            UserDAO _userToGet = new UserDAO();

            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_GetUserByUser_ID", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@User_ID", User_ID);
                        //here is where the connection is open
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();



                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {


                            //loop through the dataset or command and write each element to the _playerToList using the player object class
                            while (_reader.Read())
                            {

                                _userToGet.User_ID = _reader.GetInt32(0);
                                _userToGet.UserName = _reader.GetString(1);
                                _userToGet.Password = _reader.GetString(2);
                                _userToGet.Role_ID = _reader.GetInt32(3);


                            }
                        }

                    }
                }
            }
            catch (Exception error)
            {
                Error_Logger log = new Error_Logger();
                log.LogError(error);
            }
            return _userToGet;
        }
    }
}
