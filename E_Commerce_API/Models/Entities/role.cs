using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.Models
{
    public class role
    {
        public string id_role { get; set; }
        public string name_role { get; set; }
        public Nullable<bool> active { get; set; }
    }
}