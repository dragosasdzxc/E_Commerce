
using E_Commerce.Models;
using E_Commerce.Models.Business;
using E_Commerce.Models.Common;
using E_Commerce.Models.Config.Login;
using E_Commerce.Models.DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Commerce.Controllers
{
    [AllowAnonymous]
    //[CustomActionFilters,CustomErrorFilters]
    public class AccountsController : CustomBaseController
    {
        // GET: Accounts
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Logout();
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [ValidateAntiForgeryToken]
        public ActionResult LoginDB(user_view model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.phone_number, Shared.EncryptString(Shared.developKey, model.password)))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(model.phone_number, false);
                    if (user != null)
                    {
                        RoleDAO repoRole = RoleDAO.Instance;
                        string[] roleLists = user.Roles;
                        List<string> userRoles = new List<string>();
                        foreach (var role in roleLists)
                        {
                            string roleName = repoRole.GetById(role).name_role;
                            userRoles.Add(roleName);
                        }
                        CustomSerializeModel userModel = new Models.CustomSerializeModel()
                        {
                            UserId = user.UserId,
                            FullName = user.FullName,
                            RoleName = userRoles,
                        };

                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                            1, model.phone_number, DateTime.Now, DateTime.Now.AddDays(7), false, userData
                            );

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("CookieAuth", enTicket);
                        Response.Cookies.Add(faCookie);
                    }

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else if (returnUrl == "" || returnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            Alert("Something Wrong : Phone number or password invalid ^_^ ");
            return RedirectToAction("Login", "Accounts"); ;
        }
        public ActionResult Signup(user_view model)
        {
            ExternalData repoEx = ExternalData.Instance;
            RoleDAO repoRl = RoleDAO.Instance;
            StatusDAO repoStat = StatusDAO.Instance;
            BranchDAO repoBr = BranchDAO.Instance;
            JArray jsonListCity = repoEx.GetAllCity();
            ViewBag.jsonListCity = jsonListCity;
            ViewBag.listRole = repoRl.GetAll();
            ViewBag.listStatus = repoStat.GetAll();
            ViewBag.listBranch = repoBr.GetAll();
            return View(model);
        }
        public ActionResult SignupDB(user_view model)
        {

            if (ModelState.IsValid)
            {
                // Email Verification  
                string checkEmailExist = Membership.GetUserNameByEmail(model.email);
                if (!string.IsNullOrEmpty(checkEmailExist))
                {
                    //Alert("This email already Exist! Please choose another email!");
                    return new HttpStatusCodeResult(HttpStatusCode.Conflict, "This email already Exist! Please choose another email!");
                }

                //Save User Data   
                LoginBusiness repoLogin = LoginBusiness.Instance;
                repoLogin.Signup(model);

                //Verification Email  
                VerificationEmail(model.email, model.activation_code.ToString());
                //Alert("Your account has been created successfully! Please check your email to validate your account.");
                return new HttpStatusCodeResult(HttpStatusCode.Accepted, "Your account has been created successfully! Please check your email to validate your account!");
            }
            else
            {
                //Alert("Something Wrong!!!");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Something wrong!");
            }


            //return RedirectToAction("Signup", "Accounts");
        }
        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("CookieAuth", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts", null);
        }
        public ActionResult ActivationAccount(string id)
        {
            bool statusAccount = false;
            UserDAO repoUser = UserDAO.Instance;
            StatusDAO repoStat = StatusDAO.Instance;
            var userAccount = repoUser.GetAll().Where(u => u.activation_code.ToString().Equals(id)).FirstOrDefault();
            if (userAccount != null)
            {
                userAccount.status_id = repoStat.GetAll().Where(u => u.name_status.Equals("Validated")).Select(u => u.id_status).FirstOrDefault();
                repoUser.Update(userAccount);
                statusAccount = true;
            }
            else
            {
                ViewBag.Message = "Something Wrong !!";
            }
            ViewBag.Status = statusAccount;
            return View();
        }
        [NonAction]
        public void VerificationEmail(string email, string activationCode)
        {
            var url = string.Format("/Accounts/ActivationAccount/{0}", activationCode);
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("duongnguyen5566@gmail.com");
            msg.To.Add(email);
            msg.Subject = "Bep Banh Lau - Validate account";
            msg.Body = "Please click on the following link in order to activate your account: " + link;
            msg.Priority = MailPriority.High;


            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("duongnguyen5566@gmail.com", "Anime47chamcom");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }
        }
        [HttpGet]
        public JArray GetDistrictByCityId(string id)
        {
            ExternalData repoEx = ExternalData.Instance;
            JArray jsonListDistrict = repoEx.GetAllDistrict(id);
            return jsonListDistrict;
        }
        [HttpGet]
        public JArray GetWardByDistrictId(string id)
        {
            ExternalData repoEx = ExternalData.Instance;
            JArray jsonListWard = repoEx.GetAllWard(id);
            return jsonListWard;
        }
    }
}