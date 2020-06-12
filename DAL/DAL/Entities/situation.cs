using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class situation
    {
        public int id_situation { get; set; }
        public string situation_type { get; set; }
        public string situation_fullname { get; set; }
        public DateTime situation_datetime { get; set; }
        public bool situation_status { get; set; }
    }
}