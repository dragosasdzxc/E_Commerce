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
    public class BilldetailController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.bill_detail>> GetAllBilldetails()
        {
            //EntityMapper<bill_detail, bill_detail> mapObj = new EntityMapper<bill_detail, bill_detail>();
            List<bill_detail> bill_detailList = BilldetailDAL.GetAllBilldetails();
            List<Models.bill_detail> bill_details = new List<Models.bill_detail>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bill_detail, Models.bill_detail>());
            var mapper = new Mapper(config);
            foreach (var item in bill_detailList)
            {
                bill_details.Add(mapper.Map<Models.bill_detail>(item));
            }
            return Json<List<Models.bill_detail>>(bill_details);
        }
        [HttpGet]
        public JsonResult<Models.bill_detail> GetBilldetailById(int id)
        {
            //EntityMapper<bill_detail, bill_detail> mapObj = new EntityMapper<bill_detail, bill_detail>();
            bill_detail dalbill_detail = BilldetailDAL.GetBilldetailById(id);
            Models.bill_detail products = new Models.bill_detail();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bill_detail, Models.bill_detail>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.bill_detail>(dalbill_detail);
            return Json<Models.bill_detail>(products);
        }
        [HttpPost]
        public bool CreateNewBilldetail(Models.bill_detail product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<bill_detail, bill_detail> mapObj = new EntityMapper<bill_detail, bill_detail>();
                bill_detail productObj = new bill_detail();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.bill_detail, bill_detail>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<bill_detail>(product);
                status = BilldetailDAL.CreateNewBilldetail(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateBilldetail(Models.bill_detail product)
        {
            //EntityMapper<bill_detail, bill_detail> mapObj = new EntityMapper<bill_detail, bill_detail>();
            bill_detail productObj = new bill_detail();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.bill_detail, bill_detail>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<bill_detail>(product);
            var status = BilldetailDAL.UpdateBilldetail(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteBilldetail(int id)
        {
            var status = BilldetailDAL.DeleteBilldetail(id);
            return status;
        }
    }
}
