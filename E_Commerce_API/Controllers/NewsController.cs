using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace E_Commerce_API.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.news>> GetAllNews()
        {
            //EntityMapper<DataAccessLayer.news, news> mapObj = new EntityMapper<DataAccessLayer.news, news>();
            List<DataAccessLayer.news> newsList = NewsDAL.GetAllNews();
            List<Models.news> newss = new List<Models.news>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<news, Models.news>());
            var mapper = new Mapper(config);
            foreach (var item in newsList)
            {
                newss.Add(mapper.Map<Models.news>(item));
            }
            return Json<List<Models.news>>(newss);
        }
        [HttpGet]
        public JsonResult<Models.news> GetNewsById(string id)
        {
            //EntityMapper<DataAccessLayer.news, news> mapObj = new EntityMapper<DataAccessLayer.news, news>();
            DataAccessLayer.news dalnews = NewsDAL.GetNewsById(id);
            Models.news products = new Models.news();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<news, Models.news>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.news>(dalnews);
            return Json<Models.news>(products);
        }
        [HttpPost]
        public bool CreateNewNews(Models.news product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<news, DataAccessLayer.news> mapObj = new EntityMapper<news, DataAccessLayer.news>();
                DataAccessLayer.news productObj = new DataAccessLayer.news();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.news, news>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<news>(product);
                status = NewsDAL.CreateNewNews(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateNews(Models.news product)
        {
            //EntityMapper<news, DataAccessLayer.news> mapObj = new EntityMapper<news, DataAccessLayer.news>();
            DataAccessLayer.news productObj = new DataAccessLayer.news();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.news, news>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<news>(product);
            var status = NewsDAL.UpdateNews(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteNews(string id)
        {
            var status = NewsDAL.DeleteNews(id);
            return status;
        }
    }
}
