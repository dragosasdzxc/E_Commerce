using AutoMapper;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class ProductMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<product_view, product>()
            .ForMember(sv => sv.branch_id, s => s.MapFrom(v => v.branch_name))
            .ForMember(sv => sv.status_id, s => s.MapFrom(v => v.status_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            BranchDAO repoBr = BranchDAO.Instance;
            StatusDAO repoStat = StatusDAO.Instance;
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<product, product_view>()
            .ForMember(sv => sv.branch_name, s => s.MapFrom(v => repoBr.GetById(v.branch_id).name_branch))
            .ForMember(sv => sv.status_name, s => s.MapFrom(v => repoStat.GetById(v.status_id).name_status)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}