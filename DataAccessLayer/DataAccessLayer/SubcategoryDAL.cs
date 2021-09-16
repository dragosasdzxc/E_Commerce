using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessLayer
{
    public static class SubcategoryDAL
    {
        public static List<sub_category> GetAllSubcategorys()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.sub_category.ToList();
            }
        }
        public static sub_category GetSubcategoryById(string sub_categoryId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.sub_category.Where(p => p.id_sub_category == sub_categoryId).FirstOrDefault();
            }
        }
        public static bool CreateNewSubcategory(sub_category sub_category)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.sub_category.Add(sub_category);
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
        public static bool UpdateSubcategory(sub_category us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    sub_category checkSubcategory = DbContext.sub_category.Where(p => p.id_sub_category == us.id_sub_category).FirstOrDefault();
                    if (checkSubcategory != null)
                    {
                        checkSubcategory.id_sub_category = us.id_sub_category;
                        checkSubcategory.name_sub_category = us.name_sub_category;
                        checkSubcategory.category_id = us.category_id;
                        checkSubcategory.description = us.description;
                        checkSubcategory.active = us.active;
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
        public static bool DeleteSubcategory(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    sub_category checkSubcategory = DbContext.sub_category.Where(p => p.id_sub_category == id).FirstOrDefault();
                    if (checkSubcategory != null)
                    {
                        DbContext.sub_category.Remove(checkSubcategory);
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
