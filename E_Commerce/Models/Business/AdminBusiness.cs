using E_Commerce.Models.Common;
using E_Commerce.Models.Config.Map;
using E_Commerce.Models.DAO;
using Newtonsoft.Json.Linq;
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
            ExternalData repoEx = ExternalData.Instance;
            List<user_view> res = new List<user_view>();
            List<user> us = repoUser.GetAll();
            var mapper = new UserMapper().FromEntitiesToView();
            JArray jsonListCity = repoEx.GetAllCity();
            foreach (var item in us) {
                JArray jsonListDistrict = repoEx.GetAllDistrict(item.city);
                JArray jsonListWard = repoEx.GetAllWard(item.district);
                item.password = Shared.DecryptString(Shared.developKey,item.password);
                item.city = jsonListCity.Children<JObject>().FirstOrDefault(i=>i["code"].ToString()==item.city).GetValue("name").ToString();
                item.district = jsonListDistrict.Children<JObject>().FirstOrDefault(i => i["code"].ToString() == item.district).GetValue("name").ToString();
                item.ward = jsonListWard.Children<JObject>().FirstOrDefault(i => i["code"].ToString() == item.ward).GetValue("name").ToString();
                res.Add(mapper.Map<user_view>(item));
            }
            return res;
        }
    }
}