using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessLayer
{
    public static class BilldetailDAL
    {
        public static List<bill_detail> GetAllBilldetails()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.bill_detail.ToList();
            }
        }
        public static bill_detail GetBilldetailById(int bill_detailId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.bill_detail.Where(p => p.id_bill_detail == bill_detailId).FirstOrDefault();
            }
        }
        public static bool CreateNewBilldetail(bill_detail bill_detail)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.bill_detail.Add(bill_detail);
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
        public static bool UpdateBilldetail(bill_detail us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    bill_detail checkBilldetail = DbContext.bill_detail.Where(p => p.id_bill_detail == us.id_bill_detail).FirstOrDefault();
                    if (checkBilldetail != null)
                    {
                        checkBilldetail.bill_id = us.bill_id;
                        checkBilldetail.product_id = us.product_id;
                        checkBilldetail.quantity = us.quantity;
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
        public static bool DeleteBilldetail(int id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    bill_detail checkBilldetail = DbContext.bill_detail.Where(p => p.id_bill_detail == id).FirstOrDefault();
                    if (checkBilldetail != null)
                    {
                        DbContext.bill_detail.Remove(checkBilldetail);
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
