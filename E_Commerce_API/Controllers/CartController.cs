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
    public class CartController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.cart>> GetAllCarts()
        {
            //EntityMapper<DataAccessLayer.cart, cart> mapObj = new EntityMapper<DataAccessLayer.cart, cart>();
            List<DataAccessLayer.cart> cartList = CartDAL.GetAllCarts();
            List<Models.cart> carts = new List<Models.cart>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<cart, Models.cart>());
            var mapper = new Mapper(config);
            foreach (var item in cartList)
            {
                carts.Add(mapper.Map<Models.cart>(item));
            }
            return Json<List<Models.cart>>(carts);
        }
        [HttpGet]
        public JsonResult<Models.cart> GetCartById(string id)
        {
            //EntityMapper<DataAccessLayer.cart, cart> mapObj = new EntityMapper<DataAccessLayer.cart, cart>();
            DataAccessLayer.cart dalcart = CartDAL.GetCartById(id);
            Models.cart products = new Models.cart();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<cart, Models.cart>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.cart>(dalcart);
            return Json<Models.cart>(products);
        }
        [HttpPost]
        public bool CreateNewCart(Models.cart product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<cart, DataAccessLayer.cart> mapObj = new EntityMapper<cart, DataAccessLayer.cart>();
                DataAccessLayer.cart productObj = new DataAccessLayer.cart();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.cart, cart>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<cart>(product);
                status = CartDAL.CreateNewCart(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateCart(Models.cart product)
        {
            //EntityMapper<cart, DataAccessLayer.cart> mapObj = new EntityMapper<cart, DataAccessLayer.cart>();
            DataAccessLayer.cart productObj = new DataAccessLayer.cart();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.cart, cart>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<cart>(product);
            var status = CartDAL.UpdateCart(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteCart(string id)
        {
            var status = CartDAL.DeleteCart(id);
            return status;
        }
    }
}
