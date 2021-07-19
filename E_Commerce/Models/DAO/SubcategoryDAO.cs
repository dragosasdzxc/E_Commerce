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
    public class SubcategoryDAO:IRepository<sub_category>
    {
        private static SubcategoryDAO instance = null;
        private SubcategoryDAO()
        {
        }
        public static SubcategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SubcategoryDAO();
                }
                return instance;
            }
        }
        public int Create(sub_category newSubcategory)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Subcategory/CreateNewSubcategory", newSubcategory);
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

        public int Update(sub_category updateSubcategory)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Subcategory/UpdateSubcategory", updateSubcategory);
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

        public sub_category GetById(object id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Subcategory/GetSubcategoryById?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    sub_category res = response.Content.ReadAsAsync<sub_category>().Result;
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

        public List<sub_category> GetAll()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Subcategory/GetAllSubcategories");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<sub_category> res = response.Content.ReadAsAsync<List<sub_category>>().Result;
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

        public List<sub_category> GetPaging(int pageNumber, int row)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Subcategory/GetAllSubcategories");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<sub_category> res = response.Content.ReadAsAsync<List<sub_category>>().Result.Select(u => new sub_category { id_sub_category = u.id_sub_category }).Skip((pageNumber - 1) * row).Take(row).ToList();
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

        public List<sub_category> Search(int pageNumber, int row, string textSearch)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Subcategory/GetAllSubcategories");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<sub_category> res = response.Content.ReadAsAsync<List<sub_category>>().Result.Where(u => u.name_sub_category.ToLower().Contains(textSearch.ToLower())).Select(u => new sub_category { id_sub_category = u.id_sub_category }).Skip((pageNumber - 1) * row).Take(row).ToList();
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
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Subcategory/DeleteSubcategory?id=" + id.ToString());
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