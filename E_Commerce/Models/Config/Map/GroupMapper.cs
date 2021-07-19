using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class GroupMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<group_view, group>());
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<group, group_view>());
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}