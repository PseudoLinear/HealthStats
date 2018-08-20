using System;

namespace DAL2

{
    public class playerDAO
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