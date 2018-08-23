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
    public class BMRDataAccess
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["HealthStatsWeb"].ConnectionString;
        public void CreateBMR(BMRDAO _BMRCreate)
        {
            BMRDAO _CreateBMR = new BMRDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_CreateBMR", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@Height", _BMRCreate.Height);
                        _command.Parameters.AddWithValue("@Weight", _BMRCreate.Weight);
                        _command.Parameters.AddWithValue("@Age", _BMRCreate.Age);
                        _command.Parameters.AddWithValue("@Gender", _BMRCreate.Gender);
                        _command.Parameters.AddWithValue("@User_ID", _BMRCreate.User_ID);
                        _command.Parameters.AddWithValue("Result", _BMRCreate.Result);

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
        public List<BMRDAO> ViewBMR()
        {
            List<BMRDAO> _BMRList = new List<BMRDAO>();
            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_ViewBMR", _connection))
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
                                BMRDAO _BMRToList = new BMRDAO()
                                {
                                    Height = _reader.GetDecimal(0),
                                    Weight = _reader.GetDecimal(1),
                                    Age = _reader.GetInt32(2),
                                    Gender = _reader.GetString(3),                                    
                                    User_ID = _reader.GetInt32(4),
                                    ID = _reader.GetInt32(5),
                                    Result = _reader.GetDecimal(6),
                                };
                                _BMRList.Add(_BMRToList);
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
            return _BMRList;
        }
        public bool UpdateBMR(BMRDAO BMRToUpdate)
        {
            bool success = false;
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateBMR", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@Height", BMRToUpdate.Height);
                        _command.Parameters.AddWithValue("@Weight", BMRToUpdate.Weight);
                        _command.Parameters.AddWithValue("@Age", BMRToUpdate.Age);
                        _command.Parameters.AddWithValue("@Gender", BMRToUpdate.Gender);
                        _command.Parameters.AddWithValue("@User_ID", BMRToUpdate.User_ID);
                        _command.Parameters.AddWithValue("@ID", BMRToUpdate.ID);

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
        public bool DeleteBMR(int ID)
        {
            bool success = false;
            try
            {
                //creating connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //this specifies what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_DeleteBMR", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@ID",ID);
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
        public List<BMRDAO> GetBMRByUser_ID(int User_ID)
        {
            List<BMRDAO> _BMRToGet = new List<BMRDAO>();

            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_GetBMRByUser_ID", _connection))
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
                            //while (_reader.Read())
                            //{

                            //    _BMRToGet.Height = _reader.GetDecimal(0);
                            //    _BMRToGet.Weight = _reader.GetDecimal(1);
                            //    _BMRToGet.Age = _reader.GetInt32(2);
                            //    _BMRToGet.Gender = _reader.GetString(3);
                            //    _BMRToGet.User_ID = _reader.GetInt32(4);
                            //    _BMRToGet.ID = _reader.GetInt32(5);


                            //}
                            while (_reader.Read())
                            {
                                BMRDAO _BMRToList = new BMRDAO()
                                {
                                    Height = _reader.GetDecimal(0),
                                    Weight = _reader.GetDecimal(1),
                                    Age = _reader.GetInt32(2),
                                    Gender = _reader.GetString(3),
                                    User_ID = _reader.GetInt32(4),
                                    ID = _reader.GetInt32(5),
                                    Result = _reader.GetDecimal(6),
                                };
                                _BMRToGet.Add(_BMRToList);
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
            return _BMRToGet;
        }
        public BMRDAO GetRecentBMRByUser_ID(int User_ID)
        {
            BMRDAO _BMRToGet = new BMRDAO();

            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_GetRecentBMR", _connection))
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

                                _BMRToGet.Height = _reader.GetDecimal(0);
                                _BMRToGet.Weight = _reader.GetDecimal(1);
                                _BMRToGet.Age = _reader.GetInt32(2);
                                _BMRToGet.Gender = _reader.GetString(3);
                                _BMRToGet.User_ID = _reader.GetInt32(4);
                                _BMRToGet.ID = _reader.GetInt32(5);
                                _BMRToGet.Result = _reader.GetDecimal(6);


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
            return _BMRToGet;
        }
    }
}
