using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL2;
using DAL2.DAObjects;
using BasketballStatWeb;
using BasketballStatWeb.Models;

namespace BasketballStatWeb.Controllers
{
    public class UserController : Controller
    {
        Mapper _Mapper = new Mapper();
        static userDataAccess _userDataAccess = new userDataAccess();
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        //Post send usermodel so that user can login
        [HttpPost]

        public ActionResult Login(User viewModel)
        {
           
            //check to make sure user is accessing ciew in the browser
            if (ModelState.IsValid)
            {
                //instantiate a new user named _user
               // User _user = new User();
                //run the login stored procedure using my view model 
                userDAO _user1 = _userDataAccess.LoginUser(_Mapper.Map(viewModel));

                if (viewModel.password == _user1.Password)
                {
                    //Put the _user1 values into the session variable
                    Session["UserID"] = _user1.login_ID;
                    Session["RoleID"] = _user1.role_ID;
                    Session["RoleName"] = _user1.roleName;

                   
                    return RedirectToAction("ViewPlayers", "Player");
                }
                else
                {
                    //return register user
                    return RedirectToAction("Index","Home");
                }


            }
            else
            {
               return RedirectToAction("Login", "user");

            }
              
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpGet]
        public ActionResult createUser()
        {
            User _viewModel = new User();
            return View(_viewModel);
        }
        [HttpPost]
        public ActionResult createUser(User _viewModel)
        {

            
             _userDataAccess.CreateUser(_Mapper.Map(_viewModel));

            return RedirectToAction("ViewPlayers", "Player");
        }
        [HttpGet]
        //create a view user method for our httpGet
        public ActionResult ViewUsers()
        {
            //instantiate and name 
            UserViewModel _viewModel = new UserViewModel();
            //use method from DAL that has stored procedure, map it to the model called playerlist
            _viewModel.UserList = _Mapper.Map(_userDataAccess.GetAllUsers());
            //load viewmodel into view and return the view
            return View(_viewModel.UserList);
        }
        [HttpGet]
        public ActionResult DeleteUser(int login_ID)
        {
            bool isDeleted = _userDataAccess.DeleteUser(login_ID);
            return RedirectToAction("ViewUsers", "user");
        }

        [HttpGet]
        public ActionResult UpdateUser(int login_ID)
        {
            User UserToUpdate = _Mapper.Map(_userDataAccess.GetUserByloginID(login_ID));

            return View(UserToUpdate);
        }
        [HttpPost]
        public ActionResult UpdateUser(User _UserToUpdate)
        {

            _userDataAccess.UpdateUser(_Mapper.Map(_UserToUpdate));

            return RedirectToAction("ViewUsers", "user");
        }
    }
}