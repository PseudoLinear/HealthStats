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
    public class WLCDataAccess
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["HealthStatsWeb"].ConnectionString;
        public void CreateWLC(WLCDAO _WLCCreate)
        {
            WLCDAO _CreateUser = new WLCDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_CreateWLC", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@Gender", _WLCCreate.Gender);
                        _command.Parameters.AddWithValue("@Age", _WLCCreate.Age);
                        _command.Parameters.AddWithValue("@Height", _WLCCreate.Height);
                        _command.Parameters.AddWithValue("@Weight", _WLCCreate.Weight);
                        _command.Parameters.AddWithValue("@Goal", _WLCCreate.Goal);
                        _command.Parameters.AddWithValue("@GoalTime", _WLCCreate.GoalTime);
                        _command.Parameters.AddWithValue("@User_ID", _WLCCreate.User_ID);
                        _command.Parameters.AddWithValue("@Result", _WLCCreate.Result);

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
        public List<WLCDAO> ViewWLC()
        {
            List<WLCDAO> _WLCList = new List<WLCDAO>();
            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_ViewWLC", _connection))
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
                                WLCDAO _userToList = new WLCDAO()
                                {
                                    Gender = _reader.GetString(0),
                                    Age = _reader.GetInt32(1),
                                    Height = _reader.GetDecimal(2),
                                    Weight = _reader.GetDecimal(3),
                                    Goal = _reader.GetDecimal(4),
                                    GoalTime = _reader.GetDecimal(5),
                                    User_ID = _reader.GetInt32(6),
                                    ID = _reader.GetInt32(7),
                                    Result = _reader.GetDecimal(8),
                                };
                                _WLCList.Add(_userToList);
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
            return _WLCList;
        }
        public bool UpdateWLC(WLCDAO WLCToUpdate)
        {
            bool success = false;
            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateWLC", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@Gender", WLCToUpdate.Gender);
                        _command.Parameters.AddWithValue("@Age", WLCToUpdate.Age);
                        _command.Parameters.AddWithValue("@Height", WLCToUpdate.Height);
                        _command.Parameters.AddWithValue("@Weight", WLCToUpdate.Weight);
                        _command.Parameters.AddWithValue("@Goal", WLCToUpdate.Goal);
                        _command.Parameters.AddWithValue("GoalTime", WLCToUpdate.GoalTime);
                        _command.Parameters.AddWithValue("@Result", WLCToUpdate.Result);

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
        public bool DeleteWLC(int ID)
        {
            bool success = false;
            try
            {
                //creating connection to the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    //this specifies what type of command object for the database
                    using (SqlCommand _command = new SqlCommand("sp_DeleteWLC", _connection))
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
        public WLCDAO GetWLCByUser_ID(int User_ID)
        {
            WLCDAO _WLCToGet = new WLCDAO();

            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_GetWLCByUser_ID", _connection))
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

                                _WLCToGet.Gender = _reader.GetString(0);
                                _WLCToGet.Age = _reader.GetInt32(1);
                                _WLCToGet.Height = _reader.GetDecimal(2);
                                _WLCToGet.Weight = _reader.GetDecimal(3);
                                _WLCToGet.Goal = _reader.GetDecimal(4);
                                _WLCToGet.GoalTime = _reader.GetDecimal(5);
                                _WLCToGet.User_ID = _reader.GetInt32(6);
                                _WLCToGet.ID = _reader.GetInt32(7);



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
            return _WLCToGet;
        }
        public WLCDAO GetWLCByID(int ID)
        {
            WLCDAO _WLCToGet = new WLCDAO();

            try
            {  //esablishing the connection for the database
                using (SqlConnection _connection = new SqlConnection(connectionstring))

                {   //establishing the command to pass to the database and defining the command
                    using (SqlCommand _command = new SqlCommand("sp_GetWLCByID", _connection))
                    {
                        //this specifies what type of command is being used
                        _command.CommandType = CommandType.StoredProcedure;
                        //here is where values are going to be passed to the command
                        _command.Parameters.AddWithValue("@ID", ID);
                        //here is where the connection is open
                        _connection.Open();
                        //this executes the command
                        _command.ExecuteNonQuery();



                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {


                            //loop through the dataset or command and write each element to the _playerToList using the player object class
                            while (_reader.Read())
                            {

                                _WLCToGet.Gender = _reader.GetString(0);
                                _WLCToGet.Age = _reader.GetInt32(1);
                                _WLCToGet.Height = _reader.GetDecimal(2);
                                _WLCToGet.Weight = _reader.GetDecimal(3);
                                _WLCToGet.Height = _reader.GetDecimal(4);
                                _WLCToGet.Goal = _reader.GetDecimal(5);
                                _WLCToGet.GoalTime = _reader.GetDecimal(6);


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
            return _WLCToGet;
        }
    }
}
