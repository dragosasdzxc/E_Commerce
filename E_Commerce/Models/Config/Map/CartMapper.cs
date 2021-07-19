using AutoMapper;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class CartMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<cart_view, cart>()
            .ForMember(sv => sv.product_id, s => s.MapFrom(v => v.product_name))
            .ForMember(sv => sv.user_id, s => s.MapFrom(v => v.user_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            ProductDAO repoPr = ProductDAO.Instance;
            UserDAO repoUs = UserDAO.Instance;
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<cart, cart_view>()
            .ForMember(sv => sv.product_name, s => s.MapFrom(v => repoPr.GetById(v.product_id).name_product))
            .ForMember(sv => sv.user_name, s => s.MapFrom(v => repoUs.GetById(v.user_id).full_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}