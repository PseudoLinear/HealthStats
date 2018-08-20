using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.objects
{
    public class Books
    {
        public int Book_ID { get; set; }
        public string Book_title { get; set; }
        public string Book_descript { get; set; }
        public decimal Book_price { get; set; }
        public string IsPaperback { get; set; }
        public int Author_ID { get; set; }
        public string Author_Name { get; set; }
        public string Author_Bio { get; set; }
        public string Author_BirthLoc { get; set; }
        public DateTime Author_DOB { get; set; }
        public int Genre_ID { get; set; }
        public string Genre_Name { get; set; }
        public string Genre_descript { get; set; }
        public string IsFiction { get; set; }
    }
}
