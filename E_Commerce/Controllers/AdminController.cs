using E_Commerce.Models;
using E_Commerce.Models.Business;
using E_Commerce.Models.Config.Login;
using System.Collections.Generic;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : CustomBaseController
    {        
        public ActionResult Home()
        {
            AdminBusiness repo = AdminBusiness.Instance;
            List<user_view> res= repo.GetAllUsers();
            return View(res);
        }
    }
}