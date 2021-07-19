using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace E_Commerce.Models
{
    public class CustomMembershipUser:MembershipUser
    {
        #region User Properties  

        public string UserId { get; set; }
        public string FullName { get; set; }
        public string[] Roles { get; set; }

        #endregion

        public CustomMembershipUser(user user) : base("UsersMembershipProvider", user.phone_number, user.id_user, user.email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.id_user;
            FullName = user.full_name;
            Roles = user.role_id.Split(',');
        }
    }
}