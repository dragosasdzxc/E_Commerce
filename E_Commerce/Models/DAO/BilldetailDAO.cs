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
    public class BilldetailDAO:IRepository<bill_detail>
    {
        private static BilldetailDAO instance = null;
        private BilldetailDAO()
        {
        }
        public static BilldetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BilldetailDAO();
                }
                return instance;
            }
        }
        public int Create(bill_detail newBilldetail)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Billdetail/CreateNewBilldetail", newBilldetail);
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

        public int Update(bill_detail updateBilldetail)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Billdetail/UpdateBilldetail", updateBilldetail);
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

        public bill_detail GetById(object id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Billdetail/GetBilldetailById?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    bill_detail res = response.Content.ReadAsAsync<bill_detail>().Result;
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

        public List<bill_detail> GetAll()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Billdetail/GetAllBilldetails");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<bill_detail> res = response.Content.ReadAsAsync<List<bill_detail>>().Result;
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

        public List<bill_detail> GetPaging(int pageNumber, int row)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Billdetail/GetAllBilldetails");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<bill_detail> res = response.Content.ReadAsAsync<List<bill_detail>>().Result.Select(u => new bill_detail { id_bill_detail = u.id_bill_detail }).Skip((pageNumber - 1) * row).Take(row).ToList();
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

        public List<bill_detail> Search(int pageNumber, int row, string textSearch)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Billdetail/GetAllBilldetails");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<bill_detail> res = response.Content.ReadAsAsync<List<bill_detail>>().Result.Where(u => u.bill_id.ToLower().Contains(textSearch.ToLower()) || u.product_id.ToLower().Contains(textSearch.ToLower())).Select(u => new bill_detail { id_bill_detail = u.id_bill_detail }).Skip((pageNumber - 1) * row).Take(row).ToList();
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
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Billdetail/DeleteBilldetail?id=" + id.ToString());
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