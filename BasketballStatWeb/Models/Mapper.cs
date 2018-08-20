using DAL2;
using DAL2.DAObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BasketballStatWeb.Models
{
    public class Mapper
    {
        public List<Player> Map(List<playerDAO> _playerListToMap)
        {
            //mapper used to get all the data from the data access
            //player for the playerview mode
            //from the playerDAO object
            //use this in the httpGET player controller action
            List<Player> _playerListToReturn = new List<Player>();
            foreach (playerDAO _playerToMap in _playerListToMap)
            {
                 Player _playerToView = new Player();
                _playerToView.PlayerID = _playerToMap.PlayerID;
                _playerToView.FirstName = _playerToMap.FirstName;
                _playerToView.LastName = _playerToMap.LastName;
                _playerToView.Height = _playerToMap.Height;
                _playerToView.birthdate = _playerToMap.birthdate;
                _playerToView.TeamID = _playerToMap.TeamID;
                _playerToView.TeamName = _playerToMap.TeamName;
                _playerListToReturn.Add(_playerToView);

            }
            return _playerListToReturn;
        }

        public playerDAO Map(Player _createListToMap)
        {
            playerDAO _playerToCreate = new playerDAO();
            _playerToCreate.PlayerID = _createListToMap.PlayerID;
            _playerToCreate.FirstName = _createListToMap.FirstName;
            _playerToCreate.LastName = _createListToMap.LastName;
            _playerToCreate.Height = _createListToMap.Height;
            _playerToCreate.birthdate = _createListToMap.birthdate;
            _playerToCreate.TeamID = _createListToMap.TeamID;
            _playerToCreate.TeamName = _createListToMap.TeamName;
            return _playerToCreate;
        }
        public Player Map(playerDAO _createListToMap)
        {
            Player _playerToCreate = new Player();
            _playerToCreate.PlayerID = _createListToMap.PlayerID;
            _playerToCreate.FirstName = _createListToMap.FirstName;
            _playerToCreate.LastName = _createListToMap.LastName;
            _playerToCreate.Height = _createListToMap.Height;
            _playerToCreate.birthdate = _createListToMap.birthdate;
            _playerToCreate.TeamID = _createListToMap.TeamID;
            _playerToCreate.TeamName = _createListToMap.TeamName;
            return _playerToCreate;
        }
        public User Map(userDAO _createListToMap)
        {
            User _userToLog = new User();
            _userToLog.userName = _createListToMap.userName;
            _userToLog.password = _createListToMap.Password;
            _userToLog.login_ID = _createListToMap.login_ID;
            _userToLog.role_ID = _createListToMap.role_ID;
            return _userToLog;
        }
        
        public userDAO Map(User _createListToMap)
        {
            userDAO _userToLog = new userDAO();
            _userToLog.userName = _createListToMap.userName;
            _userToLog.Password = _createListToMap.password;
            _userToLog.login_ID = _createListToMap.login_ID;
            _userToLog.role_ID = _createListToMap.role_ID;
            return _userToLog;
        }
        public List<User> Map(List<userDAO> _userListToMap)
        {
            List<User> _userListToReturn = new List<User>();
            foreach (userDAO _userToMap in _userListToMap)
            {
                User _userToView = new User();
                _userToView.login_ID = _userToMap.login_ID;
                _userToView.userName = _userToMap.userName;
                _userToView.password = _userToMap.Password;
                _userToView.role_ID = _userToMap.role_ID;

                _userListToReturn.Add(_userToView);

            }
            return _userListToReturn;
        }
        
    }
}