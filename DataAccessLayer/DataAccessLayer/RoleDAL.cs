using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class RoleDAL
    {
        public static List<role> GetAllRoles()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.roles.ToList();
            }
        }
        public static role GetRoleById(string RoleId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.roles.Where(p => p.id_role == RoleId).FirstOrDefault();
            }
        }
        public static bool CreateNewRole(role Role)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.roles.Add(Role);
                    DbContext.SaveChanges();
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
                return status;
            }
        }
        public static bool UpdateRole(role role)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    role checkRole = DbContext.roles.Where(p => p.id_role == role.id_role).FirstOrDefault();
                    if (checkRole != null)
                    {
                        checkRole.id_role = role.id_role;
                        checkRole.name_role = role.name_role;
                        checkRole.active = role.active;
                        DbContext.SaveChanges();
                    }
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
                return status;
            }
        }
        public static bool DeleteRole(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    role checkRole = DbContext.roles.Where(p => p.id_role == id).FirstOrDefault();
                    if (checkRole != null)
                    {
                        DbContext.roles.Remove(checkRole);
                        DbContext.SaveChanges();
                    }
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
                return status;
            }
        }
    }
}
