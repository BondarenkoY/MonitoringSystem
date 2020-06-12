using System;
using System.Collections.Generic;
using System.Text;

namespace BILL.DTO
{
    public class Situation_DTO
    {
        public int id_situation { get; set; }
        public string situation_type { get; set; }
        public string situation_fullname { get; set; }
        public DateTime situation_datetime { get; set; }
    }
}