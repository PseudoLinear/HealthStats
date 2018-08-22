using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.DAObjects;
using HealthStatsWeb;
using HealthStatsWeb.Models;

namespace HealthStatsWeb.Controllers
{
    public class UserController : Controller
    {


        Mapper _Mapper = new Mapper();
        static UserDataAccess _UserDataAccess = new UserDataAccess();
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        //Post send usermodel so that user can login
        [HttpPost]

        public ActionResult Login(User viewModel)
        {

            //check to make sure user is accessing view in the browser
            if (ModelState.IsValid)
            {
                //instantiate a new user named _user
                // User _user = new User();
                //run the login stored procedure using my view model 
                UserDAO _user1 = _UserDataAccess.LoginUser(_Mapper.Map(viewModel));

                if (viewModel.Password == _user1.Password)
                {
                    //Put the _user1 values into the session variable
                    Session["User_ID"] = _user1.User_ID;
                    Session["Role_ID"] = _user1.Role_ID;



                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //return register user
                    return RedirectToAction("CreateUser", "Register");
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
        public ActionResult CreateUser()
        {
            User _viewModel = new User();
            return View(_viewModel);
        }
        [HttpPost]
        public ActionResult CreateUser(User _viewModel)
        {


            _UserDataAccess.CreateUser(_Mapper.Map(_viewModel));

            return RedirectToAction("ViewUsers", "User");
        }
        [HttpGet]
        //create a view user method for our httpGet



        public ActionResult ViewUsers()
        {
            if (Session["Role_ID"] != null)
            {
                if ((int)Session["Role_ID"] == 2 || ((int)Session["Role_ID"] == 3))
                {
                    //instantiate and name 
                    UserViewModel _viewModel = new UserViewModel();
                    //use method from DAL that has stored procedure, map it to the model called playerlist
                    _viewModel.UserList = _Mapper.Map(_UserDataAccess.ViewUsers());
                    //load viewmodel into view and return the view
                    return View(_viewModel.UserList);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "user");
            }
        }
        [HttpGet]
        public ActionResult Delete(int User_ID)
        {
            if (Session["Role_ID"] != null)
            {
                if ((int)Session["Role_ID"] == 3)
                {
                    bool isDeleted = _UserDataAccess.DeleteUser(User_ID);
                    return RedirectToAction("ViewUsers", "user");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        public ActionResult UpdateUser(int User_ID)
        {
            if (Session["Role_ID"] != null)
            {
                if ((int)Session["Role_ID"] == 3)
                {
                    User UserToUpdate = _Mapper.Map(_UserDataAccess.GetUserByUser_ID(User_ID));
                    return View(UserToUpdate);
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            


           
        }
        [HttpPost]
        public ActionResult UpdateUser(User _UserToUpdate)
        {
            if (Session["Role_ID"] != null)
            {
                if ((int)Session["Role_ID"] == 3)
                {
                    _UserDataAccess.UpdateUser(_Mapper.Map(_UserToUpdate));

                    return RedirectToAction("ViewUsers", "user");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            
        }
    }
}