using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class branch_view
    {
        public string id_branch { get; set; }
        public string name_branch { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string description { get; set; }
        public Nullable<bool> active { get; set; }
    }
}