using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL2.DAObjects;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL2
{
   public class userDataAccess
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["BasketballDB"].ConnectionString;
        public userDAO LoginUser(userDAO _userLogin)
        {
            userDAO _loginUser = new userDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_Login", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@userName", _userLogin.userName);
                       
                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                _loginUser.login_ID = _reader.GetInt32(0);
                                _loginUser.userName = _reader.GetString(1);
                                _loginUser.Password = _reader.GetString(2);
                                _loginUser.role_ID = _reader.GetInt32(3);
                            }
                        }


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
            return _loginUser;
        }
    
    
        //static string connectionstrings = ConfigurationManager.ConnectionStrings["BasketballDB"].ConnectionString;
        public void  CreateUser(userDAO _userCreate)
        {
            userDAO _CreateUser = new userDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_createUser", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@userName", _userCreate.userName);
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
            
        }
        public List<userDAO> GetAllUsers()
        {
            List<userDAO> _userlist = new List<userDAO>();
            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_ReadAllUsers", _connection))
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
                                userDAO _userToList = new userDAO();
                                _userToList.login_ID = _reader.GetInt32(0);
                                _userToList.userName = _reader.GetString(1);
                                _userToList.Password = _reader.GetString(2);
                                _userToList.role_ID = _reader.GetInt32(3);
                                _userlist.Add(_userToList);
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
            return _userlist;
        }
        //STORED PROCEDURE FOR DELETE USER
        public bool DeleteUser(int login_ID)
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
                        _command.Parameters.AddWithValue("@login_ID", login_ID);
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
        //CHANGE TO USER
        public bool UpdateUser(userDAO UserToUpdate)
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
                        _command.Parameters.AddWithValue("@login_ID", UserToUpdate.login_ID);
                        _command.Parameters.AddWithValue("@userName", UserToUpdate.userName);
                        _command.Parameters.AddWithValue("@Password", UserToUpdate.Password);
                        _command.Parameters.AddWithValue("@role_ID", UserToUpdate.role_ID);
                       
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
        public userDAO GetUserByloginID(int login_ID)
        {
            userDAO _userToGet = new userDAO();

            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_GetUserByloginID", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@login_ID",login_ID);
                        //here is where the connection is open
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();



                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {


                            //loop through the dataset or command and write each element to the _playerToList using the player object class
                            while (_reader.Read())
                            {

                                _userToGet.login_ID = _reader.GetInt32(0);
                                _userToGet.userName = _reader.GetString(1);
                                _userToGet.Password = _reader.GetString(2);
                                _userToGet.role_ID = _reader.GetInt32(3);
                                

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



            }
            return _userToGet;
        }
    }
}
