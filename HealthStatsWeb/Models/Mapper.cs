
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using DAL.DAObjects;

namespace HealthStatsWeb.Models
{
    public class Mapper
    {
     
        public List<User> Map(List<UserDAO> _UserListToMap)
        {
            
            List<User> _UserListToReturn = new List<User>();
            foreach (UserDAO _UserToMap in _UserListToMap)
            {
                User _UserToView = new User()
                {
                    User_ID = _UserToMap.User_ID,
                    UserName = _UserToMap.UserName,
                    Password = _UserToMap.Password,
                    Role_ID = _UserToMap.Role_ID,
                };

                _UserListToReturn.Add(_UserToView);

            }
            return _UserListToReturn;
        }
        
        public UserDAO Map(User _CreateListToMap)
        {
            UserDAO _UserToCreate = new UserDAO()

            {
                User_ID = _CreateListToMap.User_ID,
                UserName = _CreateListToMap.UserName,
                Password = _CreateListToMap.Password,
                Role_ID = _CreateListToMap.Role_ID,
            };
            return _UserToCreate;
        }
        
        public User Map(UserDAO _CreateListToMap)
        {
            User _UserToCreate = new User()
            {
                User_ID = _CreateListToMap.User_ID,
                UserName = _CreateListToMap.UserName,
                Password = _CreateListToMap.Password,
                Role_ID = _CreateListToMap.Role_ID,
            };
            return _UserToCreate;
        }

       
        public List<UserDAO> Map(List<User> _UserListToMap)
        {
            List<UserDAO> _UserListToReturn = new List<UserDAO>();
            foreach (User _UserToMap in _UserListToMap)
            {
                UserDAO _userToView = new UserDAO()
                {
                    User_ID = _UserToMap.User_ID,
                    UserName = _UserToMap.UserName,
                    Password = _UserToMap.Password,
                    Role_ID = _UserToMap.Role_ID,
                };

                _UserListToReturn.Add(_userToView);

            }
            return _UserListToReturn;
        }

        public BMIDAO Map(BMI _CreateListToMap)
        {
            BMIDAO _BMIToCreate = new BMIDAO()

            {
                Height = _CreateListToMap.Height,
                Weight = _CreateListToMap.Weight,
                User_ID = _CreateListToMap.User_ID,
                ID = _CreateListToMap.ID,
                Result = _CreateListToMap.Result,
                
            };
            return _BMIToCreate;
        }

        public BMI Map(BMIDAO _CreateListToMap)
        {
            BMI _BMIToCreate = new BMI()

            {
                Height = _CreateListToMap.Height,
                Weight = _CreateListToMap.Weight,
                User_ID = _CreateListToMap.User_ID,
                ID = _CreateListToMap.ID,
                Result = _CreateListToMap.Result,
                
            };
            return _BMIToCreate;
        }
        public List<BMIDAO> Map(List<BMI> _BMIListToMap)
        {
            List<BMIDAO> _BMIListToReturn = new List<BMIDAO>();
            foreach (BMI _BMIToMap in _BMIListToMap)
            {
                BMIDAO _BMIToView = new BMIDAO()
                {
                    Height = _BMIToMap.Height,
                    Weight = _BMIToMap.Weight,
                    User_ID = _BMIToMap.User_ID,
                    ID = _BMIToMap.ID,
                    Result = _BMIToMap.Result,
                };

                _BMIListToReturn.Add(_BMIToView);

            }
            return _BMIListToReturn;
        }
        public List<BMI> Map(List<BMIDAO> _BMIListToMap)
        {
            List<BMI> _BMIListToReturn = new List<BMI>();
            foreach (BMIDAO _BMIToMap in _BMIListToMap)
            {
                BMI _BMIToView = new BMI()
                {
                    Height = _BMIToMap.Height,
                    Weight = _BMIToMap.Weight,
                    User_ID = _BMIToMap.User_ID,
                    ID = _BMIToMap.ID,
                    Result = _BMIToMap.Result,
                };

                _BMIListToReturn.Add(_BMIToView);

            }
            return _BMIListToReturn;
        }



        public BMRDAO Map(BMR _CreateListToMap)
        {
            BMRDAO _BMRToCreate = new BMRDAO()
            {
                Height = _CreateListToMap.Height,
                Weight = _CreateListToMap.Weight,
                Age = _CreateListToMap.Age,
                Gender = _CreateListToMap.Gender,
                User_ID = _CreateListToMap.User_ID,
                ID = _CreateListToMap.ID,
                Result = _CreateListToMap.Result,
            };
            return _BMRToCreate;
        }

        public BMR Map(BMRDAO _CreateListToMap)
        {
            BMR _BMRToCreate = new BMR()
            {
                Height = _CreateListToMap.Height,
                Weight = _CreateListToMap.Weight,
                Age = _CreateListToMap.Age,
                Gender = _CreateListToMap.Gender,
                User_ID = _CreateListToMap.User_ID,
                ID = _CreateListToMap.ID,
                Result = _CreateListToMap.Result,
            };
            return _BMRToCreate;
        }
        public List<BMRDAO> Map(List<BMR> _BMRListToMap)
        {
            List<BMRDAO> _BMRListToReturn = new List<BMRDAO>();
            foreach (BMR _BMRToMap in _BMRListToMap)
            {
                BMRDAO _BMRToView = new BMRDAO()
                {
                    Height = _BMRToMap.Height,
                    Weight = _BMRToMap.Weight,
                    Age = _BMRToMap.Age,
                    Gender = _BMRToMap.Gender,
                    User_ID = _BMRToMap.User_ID,
                    ID = _BMRToMap.ID,
                    Result = _BMRToMap.Result,
                };

                _BMRListToReturn.Add(_BMRToView);

            }
            return _BMRListToReturn;
        }
        public List<BMR> Map(List<BMRDAO> _BMRListToMap)
        {
            List<BMR> _BMRListToReturn = new List<BMR>();
            foreach (BMRDAO _BMRToMap in _BMRListToMap)
            {
                BMR _BMRToView = new BMR()
                {
                    Height = _BMRToMap.Height,
                    Weight = _BMRToMap.Weight,
                    Age = _BMRToMap.Age,
                    Gender = _BMRToMap.Gender,
                    User_ID = _BMRToMap.User_ID,
                    ID = _BMRToMap.ID,
                    Result = _BMRToMap.Result,
                };

                _BMRListToReturn.Add(_BMRToView);

            }
            return _BMRListToReturn;
        }
        public List<WLCDAO> Map(List<WLC> _WLCListToMap)
        {
            List<WLCDAO> _WLCListToReturn = new List<WLCDAO>();
            foreach (WLC _WLCToMap in _WLCListToMap)
            {
                WLCDAO _WLCToView = new WLCDAO()
                {
                    Gender = _WLCToMap.Gender,
                    Age = _WLCToMap.Age,
                    Height = _WLCToMap.Height,
                    Weight = _WLCToMap.Weight,
                    Goal = _WLCToMap.Goal,
                    GoalTime = _WLCToMap.GoalTime,
                    User_ID = _WLCToMap.User_ID,
                    ID = _WLCToMap.ID,
                    Result = _WLCToMap.Result,
                };

                _WLCListToReturn.Add(_WLCToView);

            }
            return _WLCListToReturn;
        }
        public List<WLC> Map(List<WLCDAO> _WLCListToMap)
        {
            List<WLC> _WLCListToReturn = new List<WLC>();
            foreach (WLCDAO _WLCToMap in _WLCListToMap)
            {
                WLC _WLCToView = new WLC()
                {
                    Gender = _WLCToMap.Gender,
                    Age = _WLCToMap.Age,
                    Height = _WLCToMap.Height,
                    Weight = _WLCToMap.Weight,
                    Goal = _WLCToMap.Goal,
                    GoalTime = _WLCToMap.GoalTime,
                    User_ID = _WLCToMap.User_ID,
                    ID = _WLCToMap.ID,
                    Result = _WLCToMap.Result,
                };

                _WLCListToReturn.Add(_WLCToView);

            }
            return _WLCListToReturn;
        }

        public WLCDAO Map(WLC _CreateListToMap)
        {
            WLCDAO _WLCToCreate = new WLCDAO()
            {
                Gender = _CreateListToMap.Gender,
                Age = _CreateListToMap.Age,
                Height = _CreateListToMap.Height,
                Weight = _CreateListToMap.Weight,
                Goal = _CreateListToMap.Goal,
                GoalTime = _CreateListToMap.GoalTime,
                User_ID = _CreateListToMap.User_ID,
                ID = _CreateListToMap.ID,
                Result = _CreateListToMap.Result,
            };
            return _WLCToCreate;
        }

        public WLC Map(WLCDAO _CreateListToMap)
        {
            WLC _WLCToCreate = new WLC()
            {
                Gender = _CreateListToMap.Gender,
                Age = _CreateListToMap.Age,
                Height = _CreateListToMap.Height,
                Weight = _CreateListToMap.Weight,
                Goal = _CreateListToMap.Goal,
                GoalTime = _CreateListToMap.GoalTime,
                User_ID = _CreateListToMap.User_ID,
                ID = _CreateListToMap.ID,
                Result = _CreateListToMap.Result,
            };
            return _WLCToCreate;
        }






    }
}