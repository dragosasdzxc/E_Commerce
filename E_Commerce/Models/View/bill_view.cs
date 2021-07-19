using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class bill_view
    {
        public string id_bill { get; set; }
        public string user_name { get; set; }
        public string status_name { get; set; }
        public Nullable<int> total { get; set; }
        public string description { get; set; }
    }
}