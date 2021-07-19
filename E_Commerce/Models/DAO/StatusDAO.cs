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
    public class StatusDAO:IRepository<status>
    {
        private static StatusDAO instance = null;
        private StatusDAO()
        {
        }
        public static StatusDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatusDAO();
                }
                return instance;
            }
        }
        public int Create(status newStatus)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Status/CreateNewStatus", newStatus);
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

        public int Update(status updateStatus)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Status/UpdateStatus", updateStatus);
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

        public status GetById(object id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Status/GetStatusById?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    status res = response.Content.ReadAsAsync<status>().Result;
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

        public List<status> GetAll()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Status/GetAllStatus");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<status> res = response.Content.ReadAsAsync<List<status>>().Result;
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

        public List<status> GetPaging(int pageNumber, int row)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Status/GetAllStatuss");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<status> res = response.Content.ReadAsAsync<List<status>>().Result.Select(u => new status { id_status = u.id_status }).Skip((pageNumber - 1) * row).Take(row).ToList();
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

        public List<status> Search(int pageNumber, int row, string textSearch)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Status/GetAllStatuss");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<status> res = response.Content.ReadAsAsync<List<status>>().Result.Where(u => u.name_status.ToLower().Contains(textSearch.ToLower())).Select(u => new status { id_status = u.id_status }).Skip((pageNumber - 1) * row).Take(row).ToList();
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
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Status/DeleteStatus?id=" + id.ToString());
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