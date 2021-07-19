using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class cart
    {
        public string id_cart { get; set; }
        public string product_id { get; set; }
        public string user_id { get; set; }
        public Nullable<int> quantity { get; set; }
    }
}