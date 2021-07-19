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
    public class CategoryController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.category>> GetAllCategories()
        {
            //EntityMapper<DataAccessLayer.category, category> mapObj = new EntityMapper<DataAccessLayer.category, category>();
            List<DataAccessLayer.category> categoryList = CategoryDAL.GetAllCategories();
            List<Models.category> categorys = new List<Models.category>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<category, Models.category>());
            var mapper = new Mapper(config);
            foreach (var item in categoryList)
            {
                categorys.Add(mapper.Map<Models.category>(item));
            }
            return Json<List<Models.category>>(categorys);
        }
        [HttpGet]
        public JsonResult<Models.category> GetCategoryById(string id)
        {
            //EntityMapper<DataAccessLayer.category, category> mapObj = new EntityMapper<DataAccessLayer.category, category>();
            DataAccessLayer.category dalcategory = CategoryDAL.GetCategoryById(id);
            Models.category products = new Models.category();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<category, Models.category>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.category>(dalcategory);
            return Json<Models.category>(products);
        }
        [HttpPost]
        public bool CreateNewCategory(Models.category product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<category, DataAccessLayer.category> mapObj = new EntityMapper<category, DataAccessLayer.category>();
                DataAccessLayer.category productObj = new DataAccessLayer.category();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.category, category>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<category>(product);
                status = CategoryDAL.CreateNewCategory(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateCategory(Models.category product)
        {
            //EntityMapper<category, DataAccessLayer.category> mapObj = new EntityMapper<category, DataAccessLayer.category>();
            DataAccessLayer.category productObj = new DataAccessLayer.category();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.category, category>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<category>(product);
            var status = CategoryDAL.UpdateCategory(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteCategory(string id)
        {
            var status = CategoryDAL.DeleteCategory(id);
            return status;
        }
    }
}
