﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class ErrorController : CustomBaseController
    {
        // GET: Error
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}