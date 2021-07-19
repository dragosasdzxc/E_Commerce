using AutoMapper;
using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Config.Map
{
    public class BilldetailMapper
    {
        public Mapper FromViewToEntities()
        {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bill_detail_view, bill_detail>()
            .ForMember(sv => sv.product_id, s => s.MapFrom(v => v.product_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
        public Mapper FromEntitiesToView()
        {
            ProductDAO repoGr = ProductDAO.Instance;
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<bill_detail, bill_detail_view>()
            .ForMember(sv => sv.product_name, s => s.MapFrom(v => repoGr.GetById(v.product_id).name_product)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}