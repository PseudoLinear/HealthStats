using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasketballStatWeb.Models;
using DAL2;


namespace BasketballStatWeb.Controllers
{
    public class PlayerController : Controller
    {
        //instantiate the mapper so i can use it for the whole controller 
        //(_mapper gives access to methods in mapper class)
        static Mapper _mapper = new Mapper();
        //instantiate the playerdataacess class so we can use its methods
        static PlayerDataAccess _playerdataaccess = new PlayerDataAccess();
        // GET: Player for viewing
        [HttpGet]
        //create a view player method for our httpGet
        public ActionResult ViewPlayers()
        {
            //instantiate and name 
            PlayerViewModel _viewModel = new PlayerViewModel();
            //use method from DAL that has stored procedure, map it to the model called playerlist
            _viewModel.PlayerList = _mapper.Map(_playerdataaccess.GetAllPlayers());
            //load viewmodel into view and return the view
            return View(_viewModel.PlayerList);
        }


        [HttpGet]
        public ActionResult CreatePlayers()
        {
            Player _viewModel = new Player();
           
            return View(_viewModel);
        }
        [HttpPost]
        public ActionResult CreatePlayers(Player _playerToCreate)
        {

            _playerdataaccess.CreatePlayer(_mapper.Map(_playerToCreate));
           
            return RedirectToAction("ViewPlayers");
        }

        [HttpGet]
        public ActionResult UpdatePlayers(int player_ID)
        {
            Player playerToUpdate = _mapper.Map(_playerdataaccess.GetPlayerByID(player_ID));

            return View(playerToUpdate);
        }
        [HttpPost]
        public ActionResult UpdatePlayers(Player _playerToUpdate)
        {

            _playerdataaccess.UpdatePlayer(_mapper.Map(_playerToUpdate));

            return RedirectToAction("ViewPlayers");
        }




        [HttpGet]
        public ActionResult DeletePlayers(int playerID)
        {
          
            bool isDeleted = _playerdataaccess.DeletePlayer(playerID);
            return RedirectToAction("ViewPlayers");
        }
    }
}