using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DAL.objects;
using System.Data;


namespace LibraryDatabase
{
    public class UserDataAccess
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["libraryDB"].ConnectionString;

        public User Login(User userToLogin)
        {
            //Create user
            User _userToList = new User();
            try
            {
                //Create connection to database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_login", _connection))
                    {
                        //Connect to database
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@userName", _userToList.username);
                        _command.Parameters.AddWithValue("@password", _userToList.password);
                        //Open connection

                        _connection.Open();
                        //Open SQLDataReader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop through dataset & write each element to the _genreToList
                            //Use Genre object class
                            while (_reader.Read())
                            {

                                _userToList.user_ID = _reader.GetInt32(0);
                                _userToList.username = _reader.GetString(1);
                                _userToList.password = _reader.GetString(2);
                                _userToList.role_ID = _reader.GetInt32(3);

                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                //Instatiate a new errorlog & name it log
                DAL.ErrorLogger log = new DAL.ErrorLogger();
                //Call the log error
                log.LogError(error);
            }
            return _userToList;
        }


    }
}

