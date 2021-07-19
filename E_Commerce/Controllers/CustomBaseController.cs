using E_Commerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CustomBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext context) {
            base.OnActionExecuting(context);
            //transfer message alert from tempdata to viewbag and remove it in tempdata
            if (TempData["Alert"] != null)
            {
                ViewBag.Alert = TempData["Alert"];
                TempData.Remove("Alert");
            }
            //get list branch
            BranchDAO repoBr = BranchDAO.Instance;
            ViewBag.listBranch = repoBr.GetAll();
        }
        protected override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        protected override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        protected override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception e = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result= new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                 (new
                 {
                     controller = "Error",
                     action = "AccessDenied",
                 }
                 ));
        }
        protected void Alert(string text) {
            TempData["Alert"] = text;
        }
    }
}