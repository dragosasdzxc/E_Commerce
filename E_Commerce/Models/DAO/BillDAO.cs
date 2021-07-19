using E_Commerce.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace E_Commerce.Models.DAO
{
    public class BillDAO:IRepository<bill>
    {
        private static BillDAO instance = null;
        private BillDAO()
        {
        }
        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();
                }
                return instance;
            }
        }
        public int Create(bill newBill)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Bill/CreateNewBill", newBill);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        public int Update(bill updateBill)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Bill/UpdateBill", updateBill);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        public bill GetById(object id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Bill/GetBillById?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    bill res = response.Content.ReadAsAsync<bill>().Result;
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<bill> GetAll()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Bill/GetAllBills");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<bill> res = response.Content.ReadAsAsync<List<bill>>().Result;
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<bill> GetPaging(int pageNumber, int row)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Bill/GetAllBills");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<bill> res = response.Content.ReadAsAsync<List<bill>>().Result.Select(u => new bill { id_bill = u.id_bill }).Skip((pageNumber - 1) * row).Take(row).ToList();
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<bill> Search(int pageNumber, int row, string textSearch)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Bill/GetAllBills");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<bill> res = response.Content.ReadAsAsync<List<bill>>().Result.Where(u => u.id_bill.ToLower().Contains(textSearch.ToLower())).Select(u => new bill { id_bill = u.id_bill }).Skip((pageNumber - 1) * row).Take(row).ToList();
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public int Delete(object id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Bill/DeleteBill?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}