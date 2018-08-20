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
    public class WLCController : Controller
    {
        Mapper _Mapper = new Mapper();
        static WLCDataAccess _WLCDataAccess = new WLCDataAccess();
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


            _WLCDataAccess.CreateWLC(_Mapper.Map(_viewModel));
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
        public ActionResult UpdateWLC(int User_ID)
        {
            WLC WLCToUpdate = _Mapper.Map(_WLCDataAccess.GetWLCByUser_ID(User_ID));

            return View(WLCToUpdate);
        }
        [HttpPost]
        public ActionResult UpdateWLC(WLC _WLCToUpdate)
        {

            _WLCDataAccess.UpdateWLC(_Mapper.Map(_WLCToUpdate));

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