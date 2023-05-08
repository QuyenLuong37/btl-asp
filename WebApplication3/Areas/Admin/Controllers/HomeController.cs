using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Authorize;

namespace WebApplication3.Areas.Admin.Controllers
{
    [AuthorizeUserAttribute]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        //[AuthorizeUserAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login", new { area = "Admin" });
        }
    }
}