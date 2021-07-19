using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class user_view
    {
        public string id_user { get; set; }
        public string full_name { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string address { get; set; }
        public string role_name { get; set; }
        public string status_name { get; set; }
        public string branch_name { get; set; }
        public string activation_code { get; set; }
        public Nullable<bool> active { get; set; }
    }
}