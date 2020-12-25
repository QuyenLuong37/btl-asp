using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Areas.Admin.ModelAdmin;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private ShopBanGiayDbConText db = new ShopBanGiayDbConText();
        // GET: Home
        public ActionResult Index()
        {
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            return View();
        }

        public ActionResult KiemTraDonHang()
        {
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            var userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["USER_ID"]);
            var dh = db.DonHangs.Where(donhang => donhang.userId == userId).Select(item => new DonHangViewModel() {
                address = item.address,
                createdAt = item.createdAt,
                orderId = item.orderId,
                status = item.status,
                totalMoney = db.ChiTietDonHangs.Where(i => i.orderId == item.orderId).Sum(i => i.price * i.quantity)
            }).ToList();
            return View(dh);
        }

        string formatNumber(decimal? num)
        {
            return Convert.ToDecimal(num).ToString("#,##0.00");
        }
        public PartialViewResult _KhuyenMai()
        {
            var list = db.Giays.Where(item => item.comparePrice > item.price).Take(10);
            return PartialView(list);
        }
        public PartialViewResult _SanPhamMoi()
        {
            var list = db.Giays.OrderByDescending(item => item.createdAt).Take(10);
            return PartialView(list);
        }


    }
}