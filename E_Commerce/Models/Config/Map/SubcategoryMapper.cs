using AutoMapper;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class SubcategoryMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<sub_category_view, sub_category>()
            .ForMember(sv => sv.category_id, s => s.MapFrom(v => v.category_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            CategoryDAO repoGr = CategoryDAO.Instance;
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<sub_category, sub_category_view>()
            .ForMember(sv => sv.category_name, s => s.MapFrom(v => repoGr.GetById(v.category_id).name_category)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}