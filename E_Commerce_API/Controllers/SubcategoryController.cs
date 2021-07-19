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
    public class SubcategoryController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.sub_category>> GetAllSubcategories()
        {
            //EntityMapper<DataAccessLayer.sub_category, sub_category> mapObj = new EntityMapper<DataAccessLayer.sub_category, sub_category>();
            List<DataAccessLayer.sub_category> sub_categoryList = SubcategoryDAL.GetAllSubcategorys();
            List<Models.sub_category> sub_categorys = new List<Models.sub_category>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<sub_category, Models.sub_category>());
            var mapper = new Mapper(config);
            foreach (var item in sub_categoryList)
            {
                sub_categorys.Add(mapper.Map<Models.sub_category>(item));
            }
            return Json<List<Models.sub_category>>(sub_categorys);
        }
        [HttpGet]
        public JsonResult<Models.sub_category> GetSubcategoryById(string id)
        {
            //EntityMapper<DataAccessLayer.sub_category, sub_category> mapObj = new EntityMapper<DataAccessLayer.sub_category, sub_category>();
            DataAccessLayer.sub_category dalsub_category = SubcategoryDAL.GetSubcategoryById(id);
            Models.sub_category products = new Models.sub_category();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<sub_category, Models.sub_category>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.sub_category>(dalsub_category);
            return Json<Models.sub_category>(products);
        }
        [HttpPost]
        public bool CreateNewSubcategory(Models.sub_category product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<sub_category, DataAccessLayer.sub_category> mapObj = new EntityMapper<sub_category, DataAccessLayer.sub_category>();
                DataAccessLayer.sub_category productObj = new DataAccessLayer.sub_category();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.sub_category, sub_category>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<sub_category>(product);
                status = SubcategoryDAL.CreateNewSubcategory(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateSubcategory(Models.sub_category product)
        {
            //EntityMapper<sub_category, DataAccessLayer.sub_category> mapObj = new EntityMapper<sub_category, DataAccessLayer.sub_category>();
            DataAccessLayer.sub_category productObj = new DataAccessLayer.sub_category();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.sub_category, sub_category>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<sub_category>(product);
            var status = SubcategoryDAL.UpdateSubcategory(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteSubcategory(string id)
        {
            var status = SubcategoryDAL.DeleteSubcategory(id);
            return status;
        }
    }
}
