using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.Models
{
    public class group
    {
        public string id_group { get; set; }
        public string name_group { get; set; }
        public Nullable<bool> active { get; set; }
    }
}