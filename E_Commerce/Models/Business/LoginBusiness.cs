using AutoMapper;
using E_Commerce.Models.Common;
using E_Commerce.Models.Config.Map;
using E_Commerce.Models.DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace E_Commerce.Models.Business
{
    public class LoginBusiness
    {
        private static LoginBusiness instance = null;
        private LoginBusiness()
        {
        }
        public static LoginBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginBusiness();
                }
                return instance;
            }
            set => instance = value;
        }
        /// <summary>
        /// Get users phone number and password from <paramref name="model"></paramref> and check users exists or not.
        /// </summary>
        /// <param name="model">Contain users phone number and password.</param>
        /// <returns>The ticket contain user information if user exists, return ticket contain a string value "empty" if user not exists.</returns>
        public string Login(user_view model) {
            string enTicket = null;
            //check if user exist
            if (Membership.ValidateUser(model.phone_number, Shared.EncryptString(Shared.developKey, model.password)))
            {
                //get user information
                var user = (CustomMembershipUser)Membership.GetUser(model.phone_number, false);
                //if user information not null, return a ticket contain user information
                if (user != null)
                {
                    RoleDAO repoRole = RoleDAO.Instance;
                    string[] roleLists = user.Roles;
                    List<string> userRoles = new List<string>();
                    foreach (var role in roleLists)
                    {
                        string roleName = repoRole.GetById(role).name_role;
                        userRoles.Add(roleName);
                    }
                    CustomSerializeModel userModel = new Models.CustomSerializeModel()
                    {
                        UserId = user.UserId,
                        FullName = user.FullName,
                        RoleName = userRoles,
                    };

                    string userData = JsonConvert.SerializeObject(userModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                        (
                        1, model.phone_number, DateTime.Now, DateTime.Now.AddDays(7), false, userData
                        );

                    enTicket = FormsAuthentication.Encrypt(authTicket);
                }
                else {
                    enTicket = "empty";
                }
            }
            return enTicket;
        }
        public bool Signup(user_view model)
        {
            string userSecretCode= Guid.NewGuid().ToString("N");
            IRepository<user> repoUser = UserDAO.Instance;
            var mapper = new UserMapper().FromViewToEntities();
            long currentTime = Convert.ToInt64(DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds);
            model.id_user = currentTime.ToString() + model.phone_number + model.full_name;
            model.password = Shared.EncryptString(Shared.developKey,model.password);
            model.active = true;
            model.activation_code = userSecretCode;
            user us = mapper.Map<user>(model);
            int IsSignupSuccess=repoUser.Create(us);
            if (IsSignupSuccess == 1)
            {
                return true;
            }
            else {
                return false;
            }
        }
        
    }
}