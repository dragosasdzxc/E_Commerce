using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessLayer
{
    public static class BillDAL
    {
        public static List<bill> GetAllBills()
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.bills.ToList();
            }
        }
        public static bill GetBillById(string billId)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                return DbContext.bills.Where(p => p.id_bill == billId).FirstOrDefault();
            }
        }
        public static bool CreateNewBill(bill bill)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    DbContext.bills.Add(bill);
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
        public static bool UpdateBill(bill us)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    bill checkBill = DbContext.bills.Where(p => p.id_bill == us.id_bill).FirstOrDefault();
                    if (checkBill != null)
                    {
                        checkBill.id_bill = us.id_bill;
                        checkBill.user_id = us.user_id;
                        checkBill.total = us.total;
                        checkBill.status_id = us.status_id;
                        checkBill.description = us.description;
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
        public static bool DeleteBill(string id)
        {
            using (var DbContext = new bepbanhlauEntities1())
            {
                bool status;
                try
                {
                    bill checkBill = DbContext.bills.Where(p => p.id_bill == id).FirstOrDefault();
                    if (checkBill != null)
                    {
                        DbContext.bills.Remove(checkBill);
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
