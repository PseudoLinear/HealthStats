using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.objects
{
    public class Authors
    {
        public int Author_ID { get; set; }
        public string Author_Name { get; set; }
        public string Author_Bio { get; set; }
        public string Author_BirthLoc { get; set; }
        public DateTime Author_DOB { get; set; }
        public int Book_ID { get; set; }
        public string Book_title { get; set; }
    }
}
