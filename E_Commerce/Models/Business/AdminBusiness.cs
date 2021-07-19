using E_Commerce.Models.Common;
using E_Commerce.Models.Config.Map;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Business
{
    public class AdminBusiness
    {
        private static AdminBusiness instance = null;
        private AdminBusiness()
        {
        }
        public static AdminBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminBusiness();
                }
                return instance;
            }
            set => instance = value;
        }
        public List<user_view> GetAllUsers() {
            UserDAO repoUser = UserDAO.Instance;
            List<user_view> res = new List<user_view>();
            List<user> us = repoUser.GetAll();
            var mapper = new UserMapper().FromEntitiesToView();
            foreach (var item in us) {
                item.password = Shared.DecryptString(Shared.developKey,item.password);
                res.Add(mapper.Map<user_view>(item));
            }
            return res;
        }
    }
}