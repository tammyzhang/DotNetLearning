using System.Web.Mvc;
using System.Web.Security;
using BusinessEntities;
using BusinessLayer;

namespace MvcApplication2.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
                UserStatus status = bal.IsValidUser(u);
                bool IsAdmin = false;
                switch (status)
                {
                    case UserStatus.AuthenticatedAdmin:
                        IsAdmin = true;
                        break;
                    case UserStatus.AuthenticatedUser:
                        IsAdmin = false;
                        break;
                    default:
                    {
                        ModelState.AddModelError("CredentialError", "Invalid UserName or Password");
                        return RedirectToAction("Login");
                    }

                }
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["IsAdmin"] = IsAdmin;
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("Login");
            }



        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
