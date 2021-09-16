using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessLayer
{
    public static class ProductDAL
    {
        public static List<product> GetAllProducts()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.products.ToList();
            }
        }
        public static product GetProductById(string productId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.products.Where(p => p.id_product == productId).FirstOrDefault();
            }
        }
        public static bool CreateNewProduct(product product)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.products.Add(product);
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
        public static bool UpdateProduct(product us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    product checkProduct = DbContext.products.Where(p => p.id_product == us.id_product).FirstOrDefault();
                    if (checkProduct != null)
                    {
                        checkProduct.id_product = us.id_product;
                        checkProduct.name_product = us.name_product;
                        checkProduct.description = us.description;
                        checkProduct.price = us.price;
                        checkProduct.sale = us.sale;
                        checkProduct.date_create = us.date_create;
                        checkProduct.branch_id = us.branch_id;
                        checkProduct.status_id = us.status_id;
                        checkProduct.active = us.active;
                        checkProduct.quantity = us.quantity;
                        checkProduct.image = us.image;
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
        public static bool DeleteProduct(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    product checkProduct = DbContext.products.Where(p => p.id_product == id).FirstOrDefault();
                    if (checkProduct != null)
                    {
                        DbContext.products.Remove(checkProduct);
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
