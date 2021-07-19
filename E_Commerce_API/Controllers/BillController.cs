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
    public class BillController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.bill>> GetAllBills()
        {
            //EntityMapper<bill, bill> mapObj = new EntityMapper<bill, bill>();
            List<bill> billList = BillDAL.GetAllBills();
            List<Models.bill> bills = new List<Models.bill>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bill, Models.bill>());
            var mapper = new Mapper(config);
            foreach (var item in billList)
            {
                bills.Add(mapper.Map<Models.bill>(item));
            }
            return Json<List<Models.bill>>(bills);
        }
        [HttpGet]
        public JsonResult<Models.bill> GetBillById(string id)
        {
            //EntityMapper<bill, bill> mapObj = new EntityMapper<bill, bill>();
            bill dalbill = BillDAL.GetBillById(id);
            Models.bill products = new Models.bill();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bill, Models.bill>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.bill>(dalbill);
            return Json<Models.bill>(products);
        }
        [HttpPost]
        public bool CreateNewBill(Models.bill product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<bill, bill> mapObj = new EntityMapper<bill, bill>();
                bill productObj = new bill();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.bill, bill>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<bill>(product);
                status = BillDAL.CreateNewBill(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateBill(Models.bill product)
        {
            //EntityMapper<bill, bill> mapObj = new EntityMapper<bill, bill>();
            bill productObj = new bill();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.bill, bill>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<bill>(product);
            var status = BillDAL.UpdateBill(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteBill(string id)
        {
            var status = BillDAL.DeleteBill(id);
            return status;
        }
    }
}
