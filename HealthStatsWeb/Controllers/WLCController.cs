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
    public class WLCController : Controller
    {
        Mapper _Mapper = new Mapper();
        static WLCDataAccess _WLCDataAccess = new WLCDataAccess();
        static BMRDataAccess _BMRDA  = new BMRDataAccess();
        static WLC_Calc _Calc = new WLC_Calc();
        // GET: WLC
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateWLC()
        {
            WLC _viewModel = new WLC();
            return View(_viewModel);
        }
        [HttpPost]
        public ActionResult CreateWLC(WLC _viewModel)
        {
           BMR _BMR = _Mapper.Map(_BMRDA.GetRecentBMRByUser_ID((int)Session["User_ID"]));
            _viewModel.Result = _Calc.WLC_Result(_BMR.Gender, _BMR.Age, _BMR.Height, _BMR.Weight, _viewModel.Goal, _viewModel.GoalTime);

            _WLCDataAccess.CreateWLC(_Mapper.Map(_viewModel, _BMR));
            _viewModel.User_ID = (int)Session["User_ID"];
            return RedirectToAction("ViewWLC", "WLC");
        }
        [HttpGet]
        //create a view user method for our httpGet
        public ActionResult ViewWLC()
        {
            //instantiate and name 
            WLCViewModel _viewModel = new WLCViewModel();
            //use method from DAL that has stored procedure, map it to the model called playerlist
            _viewModel.WLCList = _Mapper.Map(_WLCDataAccess.ViewWLC());
            //load viewmodel into view and return the view
            return View(_viewModel.WLCList);
        }
        [HttpGet]
        public ActionResult UpdateWLC(int ID)
        {
            WLC WLCToUpdate = _Mapper.Map(_WLCDataAccess.GetWLCByID(ID));

            return View(WLCToUpdate);
        }
        [HttpPost]
        public ActionResult UpdateWLC(WLC WLCToUpdate)
        {
            BMR _BMR = _Mapper.Map(_BMRDA.GetRecentBMRByUser_ID((int)Session["User_ID"]));
            WLCToUpdate.Result = _Calc.WLC_Result(_BMR.Gender, _BMR.Age, _BMR.Height, _BMR.Weight, WLCToUpdate.Goal, WLCToUpdate.GoalTime);
            _WLCDataAccess.UpdateWLC(_Mapper.Map(WLCToUpdate));

            return RedirectToAction("ViewWLC", "WLC");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            bool isDeleted = _WLCDataAccess.DeleteWLC(ID);
            return RedirectToAction("ViewWLC", "WLC");
        }
    }
}