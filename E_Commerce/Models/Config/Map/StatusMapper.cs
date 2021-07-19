using AutoMapper;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class StatusMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<status_view, status>()
            .ForMember(sv=>sv.group_id,s=>s.MapFrom(v=>v.group_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            GroupDAO repoGr = GroupDAO.Instance;
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<status, status_view>()
            .ForMember(sv=>sv.group_name,s=>s.MapFrom(v=>repoGr.GetById(v.group_id).name_group)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}