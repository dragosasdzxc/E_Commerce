using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.Models
{
    public class bill_detail
    {
        public int id_bill_detail { get; set; }
        public string bill_id { get; set; }
        public string product_id { get; set; }
        public Nullable<int> quantity { get; set; }
    }
}