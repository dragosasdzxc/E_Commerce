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
            return View();
        }

        public ActionResult ViewUser() {
            AdminBusiness repo = AdminBusiness.Instance;
            List<user_view> res = repo.GetAllUsers();
            return View(res);
        }
        public ActionResult CreateUser() {
            return View();
        }
        public ActionResult EditUser() {
            return View();
        }
        public ActionResult DeleteUser() {
            return View();
        }
    }
}