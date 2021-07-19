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
    public class ProductController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.product>> GetAllProducts()
        {
            //EntityMapper<DataAccessLayer.product, product> mapObj = new EntityMapper<DataAccessLayer.product, product>();
            List<DataAccessLayer.product> productList = ProductDAL.GetAllProducts();
            List<Models.product> products = new List<Models.product>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<product, Models.product>());
            var mapper = new Mapper(config);
            foreach (var item in productList)
            {
                products.Add(mapper.Map<Models.product>(item));
            }
            return Json<List<Models.product>>(products);
        }
        [HttpGet]
        public JsonResult<Models.product> GetProductById(string id)
        {
            //EntityMapper<DataAccessLayer.product, product> mapObj = new EntityMapper<DataAccessLayer.product, product>();
            DataAccessLayer.product dalproduct = ProductDAL.GetProductById(id);
            Models.product products = new Models.product();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<product, Models.product>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.product>(dalproduct);
            return Json<Models.product>(products);
        }
        [HttpPost]
        public bool CreateNewProduct(Models.product product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<product, DataAccessLayer.product> mapObj = new EntityMapper<product, DataAccessLayer.product>();
                DataAccessLayer.product productObj = new DataAccessLayer.product();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.product, product>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<product>(product);
                status = ProductDAL.CreateNewProduct(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateProduct(Models.product product)
        {
            //EntityMapper<product, DataAccessLayer.product> mapObj = new EntityMapper<product, DataAccessLayer.product>();
            DataAccessLayer.product productObj = new DataAccessLayer.product();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.product, product>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<product>(product);
            var status = ProductDAL.UpdateProduct(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteProduct(string id)
        {
            var status = ProductDAL.DeleteProduct(id);
            return status;
        }
    }
}
