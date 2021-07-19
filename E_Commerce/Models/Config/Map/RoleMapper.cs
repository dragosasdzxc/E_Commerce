using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class RoleMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<role_view, role>());
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<role, role_view>());
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}