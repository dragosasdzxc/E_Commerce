using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class category_view
    {
        public string id_category { get; set; }
        public string name_category { get; set; }
        public string description { get; set; }
        public Nullable<bool> active { get; set; }
    }
}