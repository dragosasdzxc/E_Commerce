using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Business
{
    public class HomeBusiness
    {
        private static HomeBusiness instance = null;
        private HomeBusiness()
        {
        }
        public static HomeBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HomeBusiness();
                }
                return instance;
            }
            set => instance = value;
        }
    }
}