using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.objects
{
    public class Genres
    {
        public int Genre_ID { get; set; }
        public string Genre_Name { get; set; }
        public string Genre_descript { get; set; }
        public bool IsFiction { get; set; }
        public string Book_title { get; set; }
    }
}

