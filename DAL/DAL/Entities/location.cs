using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class location
    {
        public int id_location { get; set; }
        public int location_type { get; set; }
        public string location_area { get; set; }
        public string location_name { get; set; }
    }
}