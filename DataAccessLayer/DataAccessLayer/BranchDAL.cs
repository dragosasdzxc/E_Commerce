using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessLayer
{
    public static class BranchDAL
    {
        public static List<branch> GetAllBranches()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.branches.ToList();
            }
        }
        public static branch GetBranchById(string branchId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.branches.Where(p => p.id_branch == branchId).FirstOrDefault();
            }
        }
        public static bool CreateNewBranch(branch branch)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.branches.Add(branch);
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
        public static bool UpdateBranch(branch us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    branch checkBranch = DbContext.branches.Where(p => p.id_branch == us.id_branch).FirstOrDefault();
                    if (checkBranch != null)
                    {
                        checkBranch.id_branch = us.id_branch;
                        checkBranch.name_branch = us.name_branch;
                        checkBranch.address = us.address;
                        checkBranch.phone_number = us.phone_number;
                        checkBranch.description = us.description;
                        checkBranch.active = us.active;
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
        public static bool DeleteBranch(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    branch checkBranch = DbContext.branches.Where(p => p.id_branch == id).FirstOrDefault();
                    if (checkBranch != null)
                    {
                        DbContext.branches.Remove(checkBranch);
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
