using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Authorize;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.Controllers
{
    //[AuthorizeUserAttribute]
    public class DanhMucController : Controller
    {
        DanhMucDAO categoryDAO = new DanhMucDAO();
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            return View(categoryDAO.GetAll());
        }

        public ActionResult Them()
        {
            return View("Them");
        }

        [HttpPost]
        public ActionResult Them(TheLoai tl)
        {
            int res = categoryDAO.add(tl);
            if (res != -1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm danh mục xảy ra lỗi. Xin thử lại!");
            return View();
        }
        public ActionResult Sua(int id)
        {
            return View(categoryDAO.getCategoryById(id));
        }

        [HttpPost]
        public ActionResult Sua(TheLoai tl)
        {
            bool res = categoryDAO.update(tl);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật xảy ra lỗi, vui lòng kiểm tra lại");
            return View();
        }

        public ActionResult Xoa(int id)
        {
            var res = categoryDAO.remove(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Xóa xảy ra lỗi, vui lòng kiểm tra lại");
            return View();
        }
    }
}