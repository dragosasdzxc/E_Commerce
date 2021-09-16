using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class StatusDAL
    {
        public static List<status> GetAllStatus()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.status.ToList();
            }
        }
        public static status GetStatusById(string statusId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.status.Where(p => p.id_status == statusId).FirstOrDefault();
            }
        }
        public static bool CreateNewStatus(status stat)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.status.Add(stat);
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
        public static bool UpdateStatus(status us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    status checkStatus = DbContext.status.Where(p => p.id_status == us.id_status).FirstOrDefault();
                    if (checkStatus != null)
                    {
                        checkStatus.id_status = us.id_status;
                        checkStatus.name_status = us.name_status;
                        checkStatus.active = us.active;
                        checkStatus.group_id = us.group_id;
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
        public static bool DeleteStatus(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    status checkStatus = DbContext.status.Where(p => p.id_status == id).FirstOrDefault();
                    if (checkStatus != null)
                    {
                        DbContext.status.Remove(checkStatus);
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
