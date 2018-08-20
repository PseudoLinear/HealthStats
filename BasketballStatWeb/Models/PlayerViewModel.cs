using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketballStatWeb.Models
{
    public class PlayerViewModel
    {
        
        public Player SinglePlayer { get; set; }
        public List<Player> PlayerList { get; set; }

        public PlayerViewModel()
        {
            SinglePlayer = new Player();
            PlayerList = new List<Player>();
        }
    }
}