using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using DAL.DAObjects;

namespace HealthStats.Models
{
    public class Mapper
    {
        public List<User> Map(List<UserDAO> _UserListToMap)
        {
            //mapper used to get all the data from the data access
            //player for the playerview mode
            //from the playerDAO object
            //use this in the httpGET player controller action
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

       /*
        public User Map(UserDAO _CreateListToMap)
        {
            User _UserToLog = new User()
            {
                User_ID = _CreateListToMap.User_ID,
                UserName = _CreateListToMap.UserName,
                Password = _CreateListToMap.Password,
                Role_ID = _CreateListToMap.Role_ID,
            };
            return _UserToLog;
        }
        */

       /* public UserDAO Map(User _CreateListToMap)
        {
            UserDAO _UserToLog = new UserDAO()
            {
                 User_ID = _CreateListToMap.User_ID,
                 UserName = _CreateListToMap.UserName,
                 Password = _CreateListToMap.Password,
                 Role_ID = _CreateListToMap.Role_ID,
            };
            return _UserToLog;
        }
        */
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
    }
}