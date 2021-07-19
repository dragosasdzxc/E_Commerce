using E_Commerce.Models.Business;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace E_Commerce.Models
{
    public class UsersRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string phone_number)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            UserDAO repoUser = UserDAO.Instance;
            RoleDAO repoRole = RoleDAO.Instance;
            string getRoles = repoUser.GetAll().Where(u => u.phone_number.Equals(phone_number)).Select(u => u.role_id).FirstOrDefault();
            string[] roleLists = getRoles.Split(',');
            List<string> userRoles = new List<string>();
            foreach (var role in roleLists)
            {
                string roleName = repoRole.GetById(role).name_role;
                userRoles.Add(roleName);
            }
            return userRoles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string phone_number, string roleName)
        {
            var userRoles = GetRolesForUser(phone_number);
            return userRoles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}