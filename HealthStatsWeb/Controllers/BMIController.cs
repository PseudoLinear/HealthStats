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
    public class BMIController : Controller
    {
        Mapper _Mapper = new Mapper();
        static BMIDataAccess _BMIDataAccess = new BMIDataAccess();
        static BMI_Calc _Calc = new BMI_Calc();
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult CreateBMI()
        {

            BMI _viewModel = new BMI();
           
            return View(_viewModel);
        }
        [HttpPost]
        public ActionResult CreateBMI(BMI _viewModel)
        {
           
           _viewModel.Result = _Calc.BMI_Result(_viewModel.Height, _viewModel.Weight);

            _viewModel.User_ID = (int)Session["User_ID"];
            _BMIDataAccess.CreateBMI(_Mapper.Map(_viewModel));

            return RedirectToAction("ViewBMI", "BMI");
        }
        [HttpGet]
        //create a view user method for our httpGet
        public ActionResult ViewBMI()
        {

            //instantiate and name 
            BMIViewModel _viewModel = new BMIViewModel();
            //use method from DAL that has stored procedure, map it to the model called playerlist
            _viewModel.BMIList = _Mapper.Map(_BMIDataAccess.GetBMIByUser_ID((int)Session["User_ID"]));
            //load viewmodel into view and return the view
            return View(_viewModel.BMIList);
        }
        [HttpGet]
        public ActionResult UpdateBMI(int User_ID)
        {
            //BMI BMIToUpdate = _Mapper.Map(_BMIDataAccess.GetBMIByUser_ID(User_ID));

            return View();
        }
        [HttpPost]
        public ActionResult UpdateBMI(BMI _BMIToUpdate)
        {

            _BMIDataAccess.UpdateBMI(_Mapper.Map(_BMIToUpdate));

            return RedirectToAction("ViewBMI", "BMI");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            bool isDeleted = _BMIDataAccess.DeleteBMI(ID);
            return RedirectToAction("ViewBMI", "BMI");
        }
    }
}