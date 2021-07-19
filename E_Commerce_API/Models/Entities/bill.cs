using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.Models
{
    public class bill
    {
        public string id_bill { get; set; }
        public string user_id { get; set; }
        public string status_id { get; set; }
        public Nullable<int> total { get; set; }
        public string description { get; set; }
    }
}