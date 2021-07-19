using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace E_Commerce.Models
{
    public class CustomPrincipal:IPrincipal
    {
        #region Identity Properties  

        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
        #endregion

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string phone_number)
        {
            Identity = new GenericIdentity(phone_number);
        }
    }
}
