using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.Controllers
{
    public class DiscountController : Controller
    {
        DiscountDAO dcDAO = new DiscountDAO();
        GiayDAO giayDAO = new GiayDAO();
        KhachHangDAO khDAO = new KhachHangDAO();
        public ActionResult Index()
        {
            return View(dcDAO.GetAll());
        }



        public ActionResult Them()
        {
            ViewBag.DanhSachGiay = giayDAO.GetAll();
            ViewBag.DanhSachKH = khDAO.getAll();
            return View("Them");
        }

        [HttpPost]
        public ActionResult Them(Discount dc)
        {
            ViewBag.DanhSachGiay = giayDAO.GetAll();
            ViewBag.DanhSachKH = khDAO.getAll();
            var checkCodeExist = dcDAO.getDiscountBaseCode(dc.code, -1);
            if (checkCodeExist != null)
            {
                ModelState.AddModelError("", "Mã giảm giá đã tồn tại. Vui lòng chọn mã khác!");
                return View();
            }
            int res = dcDAO.them(dc);
            if (res != -1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm danh mục xảy ra lỗi. Xin thử lại!");
            return View();
        }
        public ActionResult Sua(int id)
        {
            ViewBag.DanhSachGiay = giayDAO.GetAll();
            ViewBag.DanhSachKH = khDAO.getAll();
            return View(dcDAO.getDiscountById(id));
        }

        [HttpPost]
        public ActionResult Sua(Discount dc)
        {
            ViewBag.DanhSachGiay = giayDAO.GetAll();
            ViewBag.DanhSachKH = khDAO.getAll();
            var checkCodeExist = dcDAO.getDiscountBaseCode(dc.code, dc.discountId);
            if (checkCodeExist != null)
            {
                ModelState.AddModelError("", "Mã giảm giá đã tồn tại. Vui lòng chọn mã khác!");
                return View();
            }
            bool res = dcDAO.update(dc);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật xảy ra lỗi, vui lòng kiểm tra lại");
            return View();
        }

        public ActionResult Xoa(int id)
        {
            var res = dcDAO.remove(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Xóa xảy ra lỗi, vui lòng kiểm tra lại");
            return View();
        }
    }
}