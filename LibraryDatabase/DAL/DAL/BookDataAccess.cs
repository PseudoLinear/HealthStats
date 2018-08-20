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
    public class BookDataAccess
    {
        //refernce app config file & create a connection string for the sql connedction
        static string connectionstring = ConfigurationManager.ConnectionStrings["libraryDB"].ConnectionString;
        //Method for Deleting a book
        public bool DeleteBook(Books bookToDelete)
        {
            bool success = false;
            try
            {
                //Create a connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_deleteBook", _connection))
                    {
                        //Spefify what tyoe of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@Book_ID", bookToDelete.Book_ID);
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
        //Method for Viewing books
        public List<Books> GetBooks()
        {
            //Create list variable named _booklist
            List<Books> _booklist = new List<Books>();
            try
            {
                //Create connection to database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_readBook", _connection))
                    {
                        //Connect to database
                        _command.CommandType = CommandType.StoredProcedure;
                        //Open connection
                        _connection.Open();
                        //Open SQLDataReader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            //Loop throug dataset & write each element to the _bookToList
                            //Use Books object class
                            while (_reader.Read())
                            {
                                Books _bookToList = new Books();
                                _bookToList.Book_ID = _reader.GetInt32(0);
                                _bookToList.Book_title = _reader.GetString(1);
                                _bookToList.Book_descript = _reader.GetString(2);
                                _bookToList.Book_price = _reader.GetDecimal(3);
                                _bookToList.IsPaperback = _reader.GetString(4);
                                _bookToList.Author_Name = _reader.GetString(5);
                                _bookToList.Genre_Name = _reader.GetString(6);
                                _booklist.Add(_bookToList);
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
            return _booklist;
        }
        //Method for Creating books
        public bool NewBook(Books bookToAdd)
        {
            bool success = false;
            {
                try
                {
                    //connection to database
                    using (SqlConnection _newbook = new SqlConnection(connectionstring))
                    {
                        //command object to database
                        using (SqlCommand _command = new SqlCommand("sp_createBook", _newbook))
                        {
                            //What command type is being used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Values being called from the database
                            _command.Parameters.AddWithValue("@Book_title", bookToAdd.Book_title);
                            _command.Parameters.AddWithValue("@Book_descript", bookToAdd.Book_descript);
                            _command.Parameters.AddWithValue("@Book_price", bookToAdd.Book_price);
                            _command.Parameters.AddWithValue("@IsPaperback", bookToAdd.IsPaperback);
                            _command.Parameters.AddWithValue("@Author_ID", bookToAdd.Author_ID);
                            _command.Parameters.AddWithValue("@Genre_ID", bookToAdd.Genre_ID);
                            //Open newbook
                            _newbook.Open();
                            //Execute command
                            _command.ExecuteNonQuery();
                            success = true;
                            _newbook.Close();
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
       //Method for Updating books
       public bool UpdateBook (Books bookToUpdate)
       {
            bool success = false;
            try
            {
                //Create a connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //Specify what command is being used
                    using(SqlCommand _command = new SqlCommand("sp_updateBook", _connection))
                    {
                        //Specify what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //Where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@Book_ID", bookToUpdate.Book_ID);
                        _command.Parameters.AddWithValue("@Book_title",bookToUpdate.Book_title);
                        _command.Parameters.AddWithValue("@Book_descript", bookToUpdate.Book_descript);
                        _command.Parameters.AddWithValue("@Book_price", bookToUpdate.Book_price);
                        _command.Parameters.AddWithValue("@IsPaperback", bookToUpdate.IsPaperback);
                        _command.Parameters.AddWithValue("@Author_ID", bookToUpdate.Author_ID);
                        _command.Parameters.AddWithValue("@Genre_ID", bookToUpdate.Genre_ID);
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