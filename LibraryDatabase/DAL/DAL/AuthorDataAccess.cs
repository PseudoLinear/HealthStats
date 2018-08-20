using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.objects;
using System.Data.SqlClient;
using System.Data;
using System.IO;



namespace LibraryDatabase
{
    public class AuthorDataAccess
    {
        //refernce app config file & create a connection string for the sql connedction
        static string connectionstring = ConfigurationManager.ConnectionStrings["libraryDB"].ConnectionString;
        //Method for Deleting an author
        public bool DeleteAuthor(Authors authorToDelete)
        {
            bool success = false;
            try
            {
                //Create a connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what type of command is being uesd
                    using (SqlCommand _command = new SqlCommand("sp_deleteAuthor", _connection))
                    {
                        //Specify what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Where values arer going to be passed to the command
                        _command.Parameters.AddWithValue("@Author_ID", authorToDelete.Author_ID);
                        //Open Connection
                        _connection.Open();
                        //Execute command
                        _command.ExecuteNonQuery();
                        success = true;
                        _connection.Close();
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
            return success;
        }
        //Method for Viewing an author
        public List<Authors> GetAuthors()
        {
            //Create list variable named _genrelist
            List<Authors> _authorlist = new List<Authors>();
            try
            {
                //Create connection to database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_readAuthor", _connection))
                    {
                        //Connect to database
                        _command.CommandType = CommandType.StoredProcedure;
                        //Open connection
                        _connection.Open();
                        //Open SQLDataReader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop through dataset & write each element to the _genrelist
                            //Use Genre object class
                            while (_reader.Read())
                            {
                                Authors _authorToList = new Authors();
                                _authorToList.Author_ID = _reader.GetInt32(0);
                                _authorToList.Author_Name = _reader.GetString(1);
                                _authorToList.Author_Bio = _reader.GetString(2);
                                _authorToList.Author_BirthLoc = _reader.GetString(3);
                                _authorToList.Author_DOB = _reader.GetDateTime(4);
                                _authorlist.Add(_authorToList);
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
            return _authorlist;
        }
        //Method for Creating an author
        public bool NewAuthor(Authors authorToAdd)
        {
            bool success = false;
            {
                try
                {
                    //connection to database
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //command object to database
                        using (SqlCommand _command = new SqlCommand("sp_createAuthor", _connection))
                        {
                            //What command type is being used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Values being called from the database
                            _command.Parameters.AddWithValue("@Author_Name", authorToAdd.Author_Name);
                            _command.Parameters.AddWithValue("@Author_Bio", authorToAdd.Author_Bio);
                            _command.Parameters.AddWithValue("@Author_BirthLoc", authorToAdd.Author_BirthLoc);
                            _command.Parameters.AddWithValue("@Author_DOB", authorToAdd.Author_DOB);
                            //Open connection
                            _connection.Open();
                            //Execute command
                            _command.ExecuteNonQuery();
                            success = true;
                            _connection.Close();
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
                return success;
            }
        }
        //Method for Updating an author
        public bool UpdateAuthor(Authors authorToUpdate)
        {
            bool success = false;
            {
                try
                {
                    //connection to database
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //command object to database
                        using (SqlCommand _command = new SqlCommand("sp_updateAuthor", _connection))
                        {
                            //What command type is being used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Values being called from the database
                            _command.Parameters.AddWithValue("@Author_ID", authorToUpdate.Author_ID);
                            _command.Parameters.AddWithValue("@Author_Name", authorToUpdate.Author_Name);
                            _command.Parameters.AddWithValue("@Author_Bio", authorToUpdate.Author_Bio);
                            _command.Parameters.AddWithValue("@Author_BirthLoc", authorToUpdate.Author_BirthLoc);
                            _command.Parameters.AddWithValue("@Author_DOB", authorToUpdate.Author_DOB);
                            //Open connection
                            _connection.Open();
                            //Execute command
                            _command.ExecuteNonQuery();
                            success = true;
                            _connection.Close();
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
                return success;
            }
        }
    }
}
