using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class GroupDAL
    {
        public static List<group> GetAllGroups()
        {
            using (var DbContext = new bepbanhlauEntities())
            {
                return DbContext.groups.ToList();
            }
        }
        public static group GetGroupById(string groupId)
        {
            using (var DbContext = new bepbanhlauEntities())
            {
                return DbContext.groups.Where(p => p.id_group == groupId).FirstOrDefault();
            }
        }
        public static bool CreateNewGroup(group group)
        {
            using (var DbContext = new bepbanhlauEntities())
            {
                bool status;
                try
                {
                    DbContext.groups.Add(group);
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
        public static bool UpdateGroup(group us)
        {
            using (var DbContext = new bepbanhlauEntities())
            {
                bool status;
                try
                {
                    group checkGroup = DbContext.groups.Where(p => p.id_group == us.id_group).FirstOrDefault();
                    if (checkGroup != null)
                    {
                        checkGroup.id_group = us.id_group;
                        checkGroup.name_group = us.name_group;
                        checkGroup.active = us.active;
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
        public static bool DeleteGroup(string id)
        {
            using (var DbContext = new bepbanhlauEntities())
            {
                bool status;
                try
                {
                    group checkGroup = DbContext.groups.Where(p => p.id_group == id).FirstOrDefault();
                    if (checkGroup != null)
                    {
                        DbContext.groups.Remove(checkGroup);
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
