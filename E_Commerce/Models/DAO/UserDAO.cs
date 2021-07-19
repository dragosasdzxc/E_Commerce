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
    public class UserDAO:IRepository<user>
    {
        private static UserDAO instance = null;
        private UserDAO()
        {
        }
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
            set => instance = value;
        }
        public int Create(user newUser)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/User/CreateNewUser", newUser);
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

        public int Update(user updateUser)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/User/UpdateUser", updateUser);
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

        public user GetById(object id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/User/GetUserById?id=" + id.ToString());
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    user res = response.Content.ReadAsAsync<user>().Result;
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

        public List<user> GetAll()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/User/GetAllUsers");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<user> res = response.Content.ReadAsAsync<List<user>>().Result;
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

        public List<user> GetPaging(int pageNumber, int row)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/User/GetAllUsers");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<user> res = response.Content.ReadAsAsync<List<user>>().Result.Select(u => new user { id_user = u.id_user }).Skip((pageNumber - 1) * row).Take(row).ToList();
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

        public List<user> Search(int pageNumber, int row, string textSearch)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/User/GetAllUsers");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<user> res = response.Content.ReadAsAsync<List<user>>().Result.Where(u => u.full_name.ToLower().Contains(textSearch.ToLower())).Select(u => new user { id_user = u.id_user }).Skip((pageNumber - 1) * row).Take(row).ToList();
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
                HttpResponseMessage response = serviceObj.DeleteResponse("api/User/DeleteUser?id=" + id.ToString());
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