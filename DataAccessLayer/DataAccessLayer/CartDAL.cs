using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessLayer
{
    public static class CartDAL
    {
        public static List<cart> GetAllCarts()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.carts.ToList();
            }
        }
        public static cart GetCartById(string cartId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.carts.Where(p => p.id_cart == cartId).FirstOrDefault();
            }
        }
        public static bool CreateNewCart(cart cart)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.carts.Add(cart);
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
        public static bool UpdateCart(cart us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    cart checkCart = DbContext.carts.Where(p => p.id_cart == us.id_cart).FirstOrDefault();
                    if (checkCart != null)
                    {
                        checkCart.id_cart = us.id_cart;
                        checkCart.product_id = us.product_id;
                        checkCart.user_id = us.user_id;
                        checkCart.quantity = us.quantity;
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
        public static bool DeleteCart(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    cart checkCart = DbContext.carts.Where(p => p.id_cart == id).FirstOrDefault();
                    if (checkCart != null)
                    {
                        DbContext.carts.Remove(checkCart);
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
