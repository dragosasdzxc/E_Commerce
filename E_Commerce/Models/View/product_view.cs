using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class product_view
    {
        public string id_product { get; set; }
        public string name_product { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public Nullable<int> sale { get; set; }
        public Nullable<long> date_create { get; set; }
        public string branch_name { get; set; }
        public string status_name { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> quantity { get; set; }
        public string image { get; set; }
    }
}