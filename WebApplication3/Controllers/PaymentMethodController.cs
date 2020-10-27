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
            return View();
        }

        public ActionResult Payment()
        {
            DiscountDAO dc = new DiscountDAO();
            ViewBag.discountList = dc.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Payment(ICollection<ChiTietDonHang> list)
        {
            DonHang dh = new DonHang();
            DonHangDAO dhDAO = new DonHangDAO();
            dh.address = "Vinh";
            dh.customerId = 1;
            dh.ChiTietDonHangs = list;
            dhDAO.them(dh);
            DiscountDAO dc = new DiscountDAO();
            ViewBag.discountList = dc.GetAll();
            return RedirectToAction("Index", "Home");
        }
    }
}