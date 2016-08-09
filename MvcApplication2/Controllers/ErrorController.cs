using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        [AllowAnonymous]
        public ActionResult Index()
        {
            Exception e = new Exception("Invalid Controller or /and Action Name.");
            HandleErrorInfo errorInfo = new HandleErrorInfo(e, "Error","Index");
            return View("Error",errorInfo);
        }

    }
}
