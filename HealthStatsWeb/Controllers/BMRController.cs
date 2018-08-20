using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.DAObjects;
using HealthStatsWeb;
using HealthStatsWeb.Models;
using Business_Logic_Layer;

namespace HealthStatsWeb.Controllers
{
    public class BMRController : Controller
    {
        Mapper _Mapper = new Mapper();
        static BMRDataAccess _BMRDataAccess = new BMRDataAccess();
        static BMR_Calc _Calc = new BMR_Calc();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateBMR()
        {
            BMR _viewModel = new BMR();
            return View(_viewModel);
        }
        [HttpPost]
        public ActionResult CreateBMR(BMR _viewModel)
        {
            _viewModel.Result = _Calc.BMR_Result(_viewModel.Gender, _viewModel.Height, _viewModel.Weight, _viewModel.Age);
            //Pulling User_ID out of session and casting it as an int
            _viewModel.User_ID = (int)Session["User_ID"];
            _BMRDataAccess.CreateBMR(_Mapper.Map(_viewModel));

            return RedirectToAction("ViewBMR", "BMR");
        }
        [HttpGet]
        //create a view user method for our httpGet
        public ActionResult ViewBMR()
        {
            //instantiate and name 
            BMRViewModel _viewModel = new BMRViewModel();
            //use method from DAL that has stored procedure, map it to the model called playerlist
            _viewModel.BMRList = _Mapper.Map(_BMRDataAccess.ViewBMR());
            //load viewmodel into view and return the view
            return View(_viewModel.BMRList);
        }
        [HttpGet]
        public ActionResult UpdateBMR(int User_ID)
        {
            BMR BMRToUpdate = _Mapper.Map(_BMRDataAccess.GetBMRByUser_ID(User_ID));

            return View(BMRToUpdate);
        }
        [HttpPost]
        public ActionResult UpdateBMR(BMR _BMRToUpdate)
        {

            _BMRDataAccess.UpdateBMR(_Mapper.Map(_BMRToUpdate));

            return RedirectToAction("ViewBMR", "BMR");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            bool isDeleted = _BMRDataAccess.DeleteBMR(ID);
            return RedirectToAction("ViewBMR", "BMR");
        }
    }
}