using E_Commerce.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_Commerce.Models.Common
{
    public class ExternalData
    {
        private static ExternalData instance = null;
        private ExternalData()
        {
        }
        public static ExternalData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExternalData();
                }
                return instance;
            }
            set => instance = value;
        }
        //-----API FROM THONGTINDOANHNGHIEP-----, ERROR: CLOSE CONNECTION
        //public JArray GetAllCity() {
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("https://thongtindoanhnghiep.co/api/city");
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            JObject readResponse = response.Content.ReadAsAsync<JObject>().Result;
        //            string getListCity = readResponse["LtsItem"].ToString();
        //            JArray res = JArray.Parse(getListCity);
        //            return res;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (EntityException ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
        //public JArray GetAllDistrict(string id)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("https://thongtindoanhnghiep.co/api/city/"+id+"/district");
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            JArray res = response.Content.ReadAsAsync<JArray>().Result;
        //            return res;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (EntityException ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
        //public JArray GetAllWard(string id)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("https://thongtindoanhnghiep.co/api/district/"+id+"/ward");
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            JArray res = response.Content.ReadAsAsync<JArray>().Result;
        //            return res;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (EntityException ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
        //-----END-----

        //-----API FROM SUPERSHIP-----, CURRENT USING
        public JArray GetAllCity()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("https://api.mysupership.vn/v1/partner/areas/province"); 
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    JObject readResponse = response.Content.ReadAsAsync<JObject>().Result;
                    string getListCity = readResponse["results"].ToString();
                    JArray res = JArray.Parse(getListCity);
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
        public JArray GetAllDistrict(string id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("https://api.mysupership.vn/v1/partner/areas/district?province=" + id);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    JObject readResponse = response.Content.ReadAsAsync<JObject>().Result;
                    string getListDistrict = readResponse["results"].ToString();
                    JArray res = JArray.Parse(getListDistrict);
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
        public JArray GetAllWard(string id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("https://api.mysupership.vn/v1/partner/areas/commune?district="+id);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    JObject readResponse = response.Content.ReadAsAsync<JObject>().Result;
                    string getListWard = readResponse["results"].ToString();
                    JArray res = JArray.Parse(getListWard);
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
    }
}