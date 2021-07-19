using AutoMapper;
using E_Commerce.Models.Common;
using E_Commerce.Models.Config.Map;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
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
        public bool Login(user_view model) {
            return true;
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