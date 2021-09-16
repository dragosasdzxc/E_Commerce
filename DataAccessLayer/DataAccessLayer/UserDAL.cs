using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class UserDAL
    {
        public static List<user> GetAllUsers()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.users.ToList();
            }
        }
        public static user GetUserById(string userId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.users.Where(p => p.id_user == userId).FirstOrDefault();
            }
        }
        public static bool CreateNewUser(user user)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.users.Add(user);
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
        public static bool UpdateUser(user us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    user checkUser = DbContext.users.Where(p => p.id_user == us.id_user).FirstOrDefault();
                    if (checkUser != null)
                    {
                        checkUser.id_user = us.id_user;
                        checkUser.full_name = us.full_name;
                        checkUser.phone_number = us.phone_number;
                        checkUser.email = us.email;
                        checkUser.password = us.password;
                        checkUser.city = us.city;
                        checkUser.ward = us.ward;
                        checkUser.district = us.district;
                        checkUser.address = us.address;
                        checkUser.role_id = us.role_id;
                        checkUser.status_id = us.status_id;
                        checkUser.branch_id = us.branch_id;
                        checkUser.activation_code = us.activation_code;
                        checkUser.active = us.active;
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
        public static bool DeleteUser(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    user checkUser = DbContext.users.Where(p => p.id_user == id).FirstOrDefault();
                    if (checkUser != null)
                    {
                        DbContext.users.Remove(checkUser);
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
