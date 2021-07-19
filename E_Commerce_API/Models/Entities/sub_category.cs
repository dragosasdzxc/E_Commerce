using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.Models
{
    public class sub_category
    {
        public string id_sub_category { get; set; }
        public string name_sub_category { get; set; }
        public string category_id { get; set; }
        public string description { get; set; }
        public Nullable<bool> active { get; set; }
    }
}