using AutoMapper;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class BillMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bill_view, bill>()
            .ForMember(sv => sv.status_id, s => s.MapFrom(v => v.status_name))
            .ForMember(sv=>sv.user_id,s=>s.MapFrom(v=>v.user_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            StatusDAO repoStat = StatusDAO.Instance;
            UserDAO repoUser = UserDAO.Instance;
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bill, bill_view>()
            .ForMember(sv => sv.status_name, s => s.MapFrom(v => repoStat.GetById(v.status_id).name_status))
            .ForMember(sv => sv.user_name, s => s.MapFrom(v => repoUser.GetById(v.user_id).full_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}