﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication3.Authorize;
using WebApplication3.Common;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.Controllers
{

    public class KhachHangController : Controller
    {
        KhachHangDAO khDAO = new KhachHangDAO();
        public ActionResult Index()
        {
            return View(khDAO.getAll());
        }

        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them(KhachHang kh)
        {
            var khachHangDDAO = new KhachHangDAO();
            var pw = Encryptor.MD5Hash(kh.password);
            kh.password = pw;
            var res = khachHangDDAO.them(kh);
            if (res)
            {
                ViewBag.Message = "Thêm khách hàng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Email đã tồn tại. Vui lòng chọn email khác!");
            return View();
        }
        public ActionResult Sua(int id)
        {
            return View(khDAO.getUserById(id));
        }

        [HttpPost]
        public ActionResult Sua(KhachHang kh)
        {
            bool res = khDAO.updateCustomer(kh);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật xảy ra lỗi, vui lòng kiểm tra lại");
            return View();
        }
        public ActionResult XoaKH(int id)
        {
            var res = khDAO.removeCustomer(id);
            if (!res)
            {
                ModelState.AddModelError("", "Xóa khách hàng xảy ra lỗi. Xin thử lại!");
            }
            ViewBag.Message = "Xóa khách hàng thành công";
            return RedirectToAction("Index", "KhachHang");
        }
    }
}