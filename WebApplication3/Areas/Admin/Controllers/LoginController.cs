using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Common;
using WebApplication3.Models;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginAdmin(UserLogin u, Boolean isWeb)
        {
            var kh = new KhachHangDAO();
            var result = kh.login(u.email, Encryptor.MD5Hash(u.password), isWeb);
            if (result)
            {
                var user = kh.getUserByEmail(u.email);
                var customerInfoToCheckout = new CustomerInfo();
                customerInfoToCheckout.firstName = user.firstName;
                customerInfoToCheckout.lastName = user.lastName;
                customerInfoToCheckout.email = user.email;
                customerInfoToCheckout.address = user.address;
                customerInfoToCheckout.phone = user.phone;
                customerInfoToCheckout.province = user.province;
                customerInfoToCheckout.district = user.district;
                customerInfoToCheckout.commune = user.commune;
                var userSession = new UserSession();
                userSession.email = user.email;
                userSession.userId = user.userId;
                Session.Add("USER_ID", user.userId);
                Session.Add("TenAdmin", user.firstName);
                Session.Add("HoAdmin", user.lastName);
                return RedirectToAction("Index", "Home", new { area = "Admin"});
            }
            else
            {
                ModelState.AddModelError("", "Email hoặc mật khẩu cung cấp không chính xác.");
                if (isWeb)
                {
                    return RedirectToAction("Index", "Account", new { error = "Email hoặc mật khẩu cung cấp không chính xác." });
                }
                return View("Index");
            }


        }

        [HttpPost]
        public ActionResult Index(UserLogin u, Boolean isWeb)
        {
            var kh = new KhachHangDAO();
            var result = kh.login(u.email, Encryptor.MD5Hash(u.password), isWeb);
            if (result)
            {
                var user = kh.getUserByEmail(u.email);
                var customerInfoToCheckout = new CustomerInfo();
                customerInfoToCheckout.firstName = user.firstName;
                customerInfoToCheckout.lastName = user.lastName;
                customerInfoToCheckout.email = user.email;
                customerInfoToCheckout.address = user.address;
                customerInfoToCheckout.phone = user.phone;
                customerInfoToCheckout.province = user.province;
                customerInfoToCheckout.district = user.district;
                customerInfoToCheckout.commune = user.commune;
                var userSession = new UserSession();
                userSession.email = user.email;
                userSession.userId = user.userId;
                Session.Add("USER_ID", user.userId);
                Session.Add("EMAIL", user.email);
                Session.Add("firstName", user.firstName);
                Session.Add("lastName", user.lastName);
                var check = System.Web.HttpContext.Current.Session["NOT_LOGGED_IN"];
                if (check != null)
                {
                    return Redirect(Url.Action("Checkout", "PaymentMethod", customerInfoToCheckout));
                }
                Session.Add("NOT_LOGGED_IN", null);
                return RedirectToAction("MyAccount", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Email hoặc mật khẩu cung cấp không chính xác.");
                if (isWeb)
                {
                    return RedirectToAction("Index", "Account", new { error = "Email hoặc mật khẩu cung cấp không chính xác." });
                }
                return View("Index");
            }


        }
    }
}