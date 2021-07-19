using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class bill_detail_view
    {
        public int id_bill_detail { get; set; }
        public string bill_id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> quantity { get; set; }
    }
}