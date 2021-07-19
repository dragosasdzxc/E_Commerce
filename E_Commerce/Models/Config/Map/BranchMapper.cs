using AutoMapper;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class BranchMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<branch_view, branch>());
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            GroupDAO repoGr = GroupDAO.Instance;
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<branch, branch_view>());
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}