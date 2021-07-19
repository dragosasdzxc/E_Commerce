using AutoMapper;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class NewsMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<news_view, news>()
            .ForMember(sv => sv.user_id, s => s.MapFrom(v => v.user_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            UserDAO repoGr = UserDAO.Instance;
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<news, news_view>()
            .ForMember(sv => sv.user_name, s => s.MapFrom(v => repoGr.GetById(v.user_id).full_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}