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
    public class GenreDataAccess
    {
        //refernce app config file & create a connection string for the sql connedction
        static string connectionstring = ConfigurationManager.ConnectionStrings["libraryDB"].ConnectionString;
        //Method for Deleting a genre.
        public bool DeleteGenre (Genres genreToDelete)
        {
            bool success = false;
            try
            {
                //Create a connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what type of command is being uesd
                    using(SqlCommand _command = new SqlCommand ("sp_deleteGenre", _connection))
                    {
                        //Specify what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Where values arer going to be passed to the command
                        _command.Parameters.AddWithValue("@Genre_ID", genreToDelete.Genre_ID);
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
        //Method for Viewing genres
        public List<Genres> GetGenres()
        {
            //Create list variable named _genrelist
            List<Genres> _genrelist = new List<Genres>();
            try
            {
                //Create connection to database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what type of command object for the database
                    using(SqlCommand _command = new SqlCommand("sp_readGenre", _connection))
                    {
                        //Connect to database
                        _command.CommandType = CommandType.StoredProcedure;
                        //Open connection

                        _connection.Open();
                        //Open SQLDataReader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop through dataset & write each element to the _genreToList
                            //Use Genre object class
                            while (_reader.Read())
                            {
                                Genres _genreToList = new Genres();
                                _genreToList.Genre_ID = _reader.GetInt32(0);
                                _genreToList.Genre_descript = _reader.GetString(1);
                                _genreToList.Genre_Name = _reader.GetString(2);
                                _genreToList.IsFiction = _reader.GetBoolean(3);
                                _genrelist.Add(_genreToList);
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
            return _genrelist;
        }
        //Method for Creating a genre
        public bool NewGenre(Genres genreToAdd)
        {
            bool success = false;
            {
                try
                {
                    //connection to database
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //command object to database
                        using (SqlCommand _command = new SqlCommand("sp_createGenre", _connection))
                        {
                            //What command type is being used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Values being called from the database
                            _command.Parameters.AddWithValue("@Genre_Name", genreToAdd.Genre_Name);
                            _command.Parameters.AddWithValue("@Genre_descript", genreToAdd.Genre_descript);
                            _command.Parameters.AddWithValue("@IsFiction", genreToAdd.IsFiction);
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
        //Method for Updating a genre
        public bool UpdateGenre (Genres genreToUpdate)
        {
            bool success = false;
            try
            {
                //Create a connection to the database
                using(SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what command is being used
                    using(SqlCommand _command = new SqlCommand("sp_updateGenre", _connection))
                    {
                        //Specify what type of command type is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@Genre_ID", genreToUpdate.Genre_ID);
                        _command.Parameters.AddWithValue("@Genre_descript", genreToUpdate.Genre_descript);
                        _command.Parameters.AddWithValue("@Genre_Name", genreToUpdate.Genre_Name);
                        _command.Parameters.AddWithValue("@IsFiction", genreToUpdate.IsFiction);
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