//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
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
        public string role_id { get; set; }
        public string status_id { get; set; }
        public string branch_id { get; set; }
        public string activation_code { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
