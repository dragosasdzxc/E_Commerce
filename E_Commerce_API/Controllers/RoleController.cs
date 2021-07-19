using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace E_Commerce_API.Controllers
{
    public class RoleController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.role>> GetAllRoles()
        {
            //EntityMapper<DataAccessLayer.role, role> mapObj = new EntityMapper<DataAccessLayer.role, role>();
            List<DataAccessLayer.role> roleList = RoleDAL.GetAllRoles();
            List<Models.role> roles = new List<Models.role>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<role, Models.role>());
            var mapper = new Mapper(config);
            foreach (var item in roleList)
            {
                roles.Add(mapper.Map<Models.role>(item));
            }
            return Json<List<Models.role>>(roles);
        }
        [HttpGet]
        public JsonResult<Models.role> GetRoleById(string id)
        {
            //EntityMapper<DataAccessLayer.role, role> mapObj = new EntityMapper<DataAccessLayer.role, role>();
            DataAccessLayer.role dalrole = RoleDAL.GetRoleById(id);
            Models.role products = new Models.role();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<role, Models.role>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.role>(dalrole);
            return Json<Models.role>(products);
        }
        [HttpPost]
        public bool CreateNewRole(Models.role product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<role, DataAccessLayer.role> mapObj = new EntityMapper<role, DataAccessLayer.role>();
                DataAccessLayer.role productObj = new DataAccessLayer.role();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.role, role>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<role>(product);
                status = RoleDAL.CreateNewRole(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateRole(Models.role product)
        {
            //EntityMapper<role, DataAccessLayer.role> mapObj = new EntityMapper<role, DataAccessLayer.role>();
            DataAccessLayer.role productObj = new DataAccessLayer.role();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.role, role>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<role>(product);
            var status = RoleDAL.UpdateRole(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteRole(string id)
        {
            var status = RoleDAL.DeleteRole(id);
            return status;
        }
    }
}
