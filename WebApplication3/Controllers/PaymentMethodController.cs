using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Controllers
{
    public class PaymentMethodController : Controller
    {
        // GET: PaymentMethod
        public ActionResult Checkout()
        {
            DiscountDAO dc = new DiscountDAO();
            ViewBag.discountList = dc.GetAll();
            var userId = System.Web.HttpContext.Current.Session["USER_ID"];
            if (userId != null)
            {
                return View();
            }
            Session.Add("NOT_LOGGED_IN", true);
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Payment(String address)
        {
            DiscountDAO dc = new DiscountDAO();
            ViewBag.discountList = dc.GetAll();
            Session.Add("ADDRESS", address);
            return View();
        }
        private HttpContextBase Context { get; set; }
        [HttpPost]
        public ActionResult Payment(ICollection<ChiTietDonHang> list)
        {
            DonHang dh = new DonHang();
            DonHangDAO dhDAO = new DonHangDAO();
            dh.userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["USER_ID"]);
            dh.address = Convert.ToString(System.Web.HttpContext.Current.Session["ADDRESS"]);
            dh.ChiTietDonHangs = list;
            dh.status = "pending";
            dh.createdAt = DateTime.Now;
            dhDAO.them(dh);
            DiscountDAO dc = new DiscountDAO();
            ViewBag.discountList = dc.GetAll();
            return Content("ok na");
        }
    }
}