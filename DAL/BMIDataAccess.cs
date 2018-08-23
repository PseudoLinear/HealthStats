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
    public class BMIDataAccess
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["HealthStatsWeb"].ConnectionString;
        public void CreateBMI(BMIDAO _BMICreate)
        {
            BMIDAO _CreateBMI = new BMIDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_CreateBMI", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@Height", _BMICreate.Height);
                        _command.Parameters.AddWithValue("@Weight", _BMICreate.Weight);
                        _command.Parameters.AddWithValue("@User_ID", _BMICreate.User_ID);
                        
                        _command.Parameters.AddWithValue("@Result", _BMICreate.Result);

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
        public List<BMIDAO> ViewBMI()
        {
            List<BMIDAO> _BMIList = new List<BMIDAO>();
            
            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_ViewBMI", _connection))
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
                                BMIDAO _BMIToList = new BMIDAO()
                                {
                                    Height = _reader.GetDecimal(0),
                                    Weight = _reader.GetDecimal(1),
                                    User_ID = _reader.GetInt32(2),
                                    ID = _reader.GetInt32(3),
                                    Result= _reader.GetDecimal(4),
                                };
                                    _BMIList.Add(_BMIToList);
                            
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
            return _BMIList;
        }
        public bool UpdateBMI(BMIDAO BMIToUpdate)
        {
            bool success = false;
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateBMI", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@Height", BMIToUpdate.User_ID);
                        _command.Parameters.AddWithValue("@Weight", BMIToUpdate.Weight);
                        _command.Parameters.AddWithValue("@User_ID", BMIToUpdate.User_ID);
                        _command.Parameters.AddWithValue("@ID", BMIToUpdate.ID);

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
        public bool DeleteBMI(int ID)
        {
            bool success = false;
            try
            {
                //creating connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //this specifies what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_DeleteBMI", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@ID", ID);
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
        public List<BMIDAO> GetBMIByUser_ID(int User_ID)
        {
           List< BMIDAO> _BMIToGet = new List<BMIDAO>();

            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_GetBMIByUser_ID", _connection))
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
                            //    List
                            //    _BMIToGet.Height = _reader.GetDecimal(0);
                            //    _BMIToGet.Weight = _reader.GetDecimal(1);
                            //    _BMIToGet.User_ID = _reader.GetInt32(2);
                            //    _BMIToGet.ID = _reader.GetInt32(3);


                            //}
                            while (_reader.Read())
                            {
                                BMIDAO _BMIToList = new BMIDAO()
                                {
                                    Height = _reader.GetDecimal(0),
                                    Weight = _reader.GetDecimal(1),
                                    User_ID = _reader.GetInt32(2),
                                    ID = _reader.GetInt32(3),
                                    Result = _reader.GetDecimal(4),
                                };
                                _BMIToGet.Add(_BMIToList);

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
            return _BMIToGet;
        }
    }
}
