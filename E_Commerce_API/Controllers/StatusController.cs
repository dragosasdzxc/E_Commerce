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
    public class StatusController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.status>> GetAllStatus()
        {
            //EntityMapper<DataAccessLayer.status, status> mapObj = new EntityMapper<DataAccessLayer.status, status>();
            List<DataAccessLayer.status> statusList = StatusDAL.GetAllStatus();
            List<Models.status> statuss = new List<Models.status>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<status, Models.status>());
            var mapper = new Mapper(config);
            foreach (var item in statusList)
            {
                statuss.Add(mapper.Map<Models.status>(item));
            }
            return Json<List<Models.status>>(statuss);
        }
        [HttpGet]
        public JsonResult<Models.status> GetStatusById(string id)
        {
            //EntityMapper<DataAccessLayer.status, status> mapObj = new EntityMapper<DataAccessLayer.status, status>();
            DataAccessLayer.status dalstatus = StatusDAL.GetStatusById(id);
            Models.status products = new Models.status();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<status, Models.status>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.status>(dalstatus);
            return Json<Models.status>(products);
        }
        [HttpPost]
        public bool CreateNewStatus(Models.status product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<status, DataAccessLayer.status> mapObj = new EntityMapper<status, DataAccessLayer.status>();
                DataAccessLayer.status productObj = new DataAccessLayer.status();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.status, status>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<status>(product);
                status = StatusDAL.CreateNewStatus(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateStatus(Models.status product)
        {
            //EntityMapper<status, DataAccessLayer.status> mapObj = new EntityMapper<status, DataAccessLayer.status>();
            DataAccessLayer.status productObj = new DataAccessLayer.status();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.status, status>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<status>(product);
            var status = StatusDAL.UpdateStatus(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteStatus(string id)
        {
            var status = StatusDAL.DeleteStatus(id);
            return status;
        }
    }
}
