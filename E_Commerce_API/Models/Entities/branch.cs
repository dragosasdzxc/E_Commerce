using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.Models
{
    public class branch
    {
        public string id_branch { get; set; }
        public string name_branch { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string description { get; set; }
        public Nullable<bool> active { get; set; }
    }
}