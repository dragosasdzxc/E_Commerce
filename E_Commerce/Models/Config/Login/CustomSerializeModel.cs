using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class CustomSerializeModel
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public List<string> RoleName { get; set; }
    }
}