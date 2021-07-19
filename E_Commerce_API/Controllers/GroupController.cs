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
    public class GroupController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.group>> GetAllGroups()
        {
            //EntityMapper<DataAccessLayer.group, group> mapObj = new EntityMapper<DataAccessLayer.group, group>();
            List<DataAccessLayer.group> groupList = GroupDAL.GetAllGroups();
            List<Models.group> groups = new List<Models.group>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<group, Models.group>());
            var mapper = new Mapper(config);
            foreach (var item in groupList)
            {
                groups.Add(mapper.Map<Models.group>(item));
            }
            return Json<List<Models.group>>(groups);
        }
        [HttpGet]
        public JsonResult<Models.group> GetGroupById(string id)
        {
            //EntityMapper<DataAccessLayer.group, group> mapObj = new EntityMapper<DataAccessLayer.group, group>();
            DataAccessLayer.group dalgroup = GroupDAL.GetGroupById(id);
            Models.group products = new Models.group();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<group, Models.group>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.group>(dalgroup);
            return Json<Models.group>(products);
        }
        [HttpPost]
        public bool CreateNewGroup(Models.group product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<group, DataAccessLayer.group> mapObj = new EntityMapper<group, DataAccessLayer.group>();
                DataAccessLayer.group productObj = new DataAccessLayer.group();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.group, group>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<group>(product);
                status = GroupDAL.CreateNewGroup(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateGroup(Models.group product)
        {
            //EntityMapper<group, DataAccessLayer.group> mapObj = new EntityMapper<group, DataAccessLayer.group>();
            DataAccessLayer.group productObj = new DataAccessLayer.group();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.group, group>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<group>(product);
            var status = GroupDAL.UpdateGroup(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteGroup(string id)
        {
            var status = GroupDAL.DeleteGroup(id);
            return status;
        }
    }
}
