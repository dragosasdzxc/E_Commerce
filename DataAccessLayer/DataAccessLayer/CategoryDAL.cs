using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessLayer
{
    public static class CategoryDAL
    {
        public static List<category> GetAllCategories()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.categories.ToList();
            }
        }
        public static category GetCategoryById(string categoryId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.categories.Where(p => p.id_category == categoryId).FirstOrDefault();
            }
        }
        public static bool CreateNewCategory(category category)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.categories.Add(category);
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
        public static bool UpdateCategory(category us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    category checkCategory = DbContext.categories.Where(p => p.id_category == us.id_category).FirstOrDefault();
                    if (checkCategory != null)
                    {
                        checkCategory.id_category = us.id_category;
                        checkCategory.name_category = us.name_category;
                        checkCategory.description = us.description;
                        checkCategory.active = us.active;
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
        public static bool DeleteCategory(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    category checkCategory = DbContext.categories.Where(p => p.id_category == id).FirstOrDefault();
                    if (checkCategory != null)
                    {
                        DbContext.categories.Remove(checkCategory);
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
