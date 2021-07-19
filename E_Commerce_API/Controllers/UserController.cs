using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using System.Diagnostics;

namespace E_Commerce_API.Controllers
{
    public class UserController : ApiController
    {
        // GET: Users 
        [HttpGet]
        public JsonResult<List<Models.user>> GetAllUsers()
        {
            //EntityMapper<DataAccessLayer.user, Models.user> mapObj = new EntityMapper<DataAccessLayer.user, Models.user>();
            List<DataAccessLayer.user> userList = UserDAL.GetAllUsers();
            List<Models.user> users = new List<Models.user>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<user, Models.user>());
            var mapper = new Mapper(config);
            foreach (var item in userList)
            {
                users.Add(mapper.Map<Models.user>(item));
            }
            return Json<List<Models.user>>(users);
        }
        [HttpGet]
        public JsonResult<Models.user> GetUserById(string id)
        {
            //EntityMapper<DataAccessLayer.user, Models.user> mapObj = new EntityMapper<DataAccessLayer.user, Models.user>();
            DataAccessLayer.user daluser = UserDAL.GetUserById(id);
            Models.user products = new Models.user();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<user, Models.user>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.user>(daluser);
            return Json<Models.user>(products);
        }
        [HttpPost]
        public bool CreateNewUser(Models.user product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<Models.user, DataAccessLayer.user> mapObj = new EntityMapper<Models.user, DataAccessLayer.user>();
                DataAccessLayer.user productObj = new DataAccessLayer.user();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.user, user>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<user>(product);
                status = UserDAL.CreateNewUser(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateUser(Models.user product)
        {
            //EntityMapper<Models.user, DataAccessLayer.user> mapObj = new EntityMapper<Models.user, DataAccessLayer.user>();
            DataAccessLayer.user productObj = new DataAccessLayer.user();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.user, user>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<user>(product);
            var status = UserDAL.UpdateUser(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteUser(string id)
        {
            var status = UserDAL.DeleteUser(id);
            return status;
        }
    }
}
