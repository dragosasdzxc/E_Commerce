using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using E_Commerce.Models.DAO;

namespace E_Commerce.Models.Config.Map
{
    public class UserMapper
    {
        public Mapper FromViewToEntities() {
            //cấu hình mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<user_view, user>().
                ForMember(uv => uv.branch_id, u => u.MapFrom(v => v.branch_name)).
                ForMember(uv => uv.role_id, u => u.MapFrom(v => v.role_name)).
                ForMember(uv => uv.status_id, u => u.MapFrom(v => v.status_name)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }

        public Mapper FromEntitiesToView()
        {
            IRepository<branch> repoBranch = BranchDAO.Instance;
            IRepository<status> repoStatus = StatusDAO.Instance;
            IRepository<role> repoRole = RoleDAO.Instance;
            //cấu hình mapper khi map data từ model sang view, ví dụ: lấy ra name_branch theo id_branch,etc...
            var config = new MapperConfiguration(cfg => cfg.CreateMap<user, user_view>().
                ForMember(uv => uv.branch_name, u => u.MapFrom(v => repoBranch.GetById(v.branch_id).name_branch)).
                ForMember(uv => uv.role_name, u => u.MapFrom(v => repoRole.GetById(v.role_id).name_role)).
                ForMember(uv => uv.status_name, u => u.MapFrom(v => repoStatus.GetById(v.status_id).name_status)));
            //khai báo mapper
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}