using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.Models
{
    public class news
    {
        public string id_news { get; set; }
        public string user_id { get; set; }
        public string header_name { get; set; }
        public string contents { get; set; }
    }
}