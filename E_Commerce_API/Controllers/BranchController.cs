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
    public class BranchController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.branch>> GetAllBranches()
        {
            //EntityMapper<branch, branch> mapObj = new EntityMapper<branch, branch>();
            List<branch> branchList = BranchDAL.GetAllBranches();
            List<Models.branch> branchs = new List<Models.branch>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<branch, Models.branch>());
            var mapper = new Mapper(config);
            foreach (var item in branchList)
            {
                branchs.Add(mapper.Map<Models.branch>(item));
            }
            return Json<List<Models.branch>>(branchs);
        }
        [HttpGet]
        public JsonResult<Models.branch> GetBranchById(string id)
        {
            //EntityMapper<branch, branch> mapObj = new EntityMapper<branch, branch>();
            branch dalbranch = BranchDAL.GetBranchById(id);
            Models.branch products = new Models.branch();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<branch, Models.branch>());
            var mapper = new Mapper(config);
            products = mapper.Map<Models.branch>(dalbranch);
            return Json<Models.branch>(products);
        }
        [HttpPost]
        public bool CreateNewBranch(Models.branch product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<branch, branch> mapObj = new EntityMapper<branch, branch>();
                branch productObj = new branch();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.branch, branch>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<branch>(product);
                status = BranchDAL.CreateNewBranch(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateBranch(Models.branch product)
        {
            //EntityMapper<branch, branch> mapObj = new EntityMapper<branch, branch>();
            branch productObj = new branch();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.branch, branch>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<branch>(product);
            var status = BranchDAL.UpdateBranch(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteBranch(string id)
        {
            var status = BranchDAL.DeleteBranch(id);
            return status;
        }
    }
}
