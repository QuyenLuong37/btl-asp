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
        // GET: Account
        public ActionResult Index()
        {
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            return View();
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