using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballStatTracker.Objects
{
    public class PlayerDAO
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime birthdate { get; set; }
        public int TeamID { get; set; }
        public decimal Height { get; set; }
        public string TeamName { get; set; }
    }
}
