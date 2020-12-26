using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Common;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {

        private ShopBanGiayDbConText db = new ShopBanGiayDbConText();
        // GET: Account
        public ActionResult Index(bool? isLogout)
        {

            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            if (isLogout == true) {
                System.Web.HttpContext.Current.Session.Clear();
               
            } else
            {
                var userId = System.Web.HttpContext.Current.Session["USER_ID"];
                if (userId != null)
                {
                    var kh = db.KhachHangs.ToList().Where(item => item.userId == Convert.ToInt32(userId)).SingleOrDefault();
                    return RedirectToAction("MyAccount");
                }
            }
            
            return View();
        }

        public ActionResult MyAccount()
        {
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            var userId = System.Web.HttpContext.Current.Session["USER_ID"];
            if (userId != null)
            {
                var kh = db.KhachHangs.ToList().Where(item => item.userId == Convert.ToInt32(userId)).SingleOrDefault();
                return View(kh);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Register(KhachHang kh)
        {
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            if (ModelState.IsValid)
            {
                var khachHangDDAO = new KhachHangDAO();
                var pw = Encryptor.MD5Hash(kh.password);
                var cfpw = Encryptor.MD5Hash(kh.confirmPassword);
                kh.password = pw;
                kh.confirmPassword = cfpw;
                var res = khachHangDDAO.them(kh);
                if (res)
                {
                    ViewBag.Message = "Thêm khách hàng thành công";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Email đã tồn tại. Vui lòng chọn email khác!");
                return View();
            }
            return View();
        }
    }
}