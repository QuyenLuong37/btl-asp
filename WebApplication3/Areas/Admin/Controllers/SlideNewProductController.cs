using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.Controllers
{
    public class SlideNewProductController : Controller
    {
        GiayDAO giayDAO = new GiayDAO();
        SlideNewProductDAO sl = new SlideNewProductDAO();
        // GET: Admin/SlideNewProduct
        public ActionResult Index()
        {
            return View(sl.GetAll());
        }

        public ActionResult Them()
        {
            return View(giayDAO.GetAll().Where(item => {
                var d = DateTime.Now;
                return item.createdAt < d;
            }).Take(20));
        }

        public ActionResult ThemSlide(int id)
        {
            var giay = giayDAO.getShoeById(id);
            SlideNewProduct entity = new SlideNewProduct();
            entity.shoeId = id;
            entity.createdAt = DateTime.Now;
            entity.isActive = true;
            entity.title = giay.shoeName;
            var res = sl.Them(entity);
            if (res < 0)
            {
                ModelState.AddModelError("", "Thêm slide xảy ra lỗi. Xin thử lại!");
            }
            return RedirectToAction("Them");
        }

        public ActionResult Xoa(int id)
        {
            var res = sl.Xoa(id);
            if (!res)
            {
                ModelState.AddModelError("", "Thêm slide xảy ra lỗi. Xin thử lại!");
            }
            return RedirectToAction("Index");
        }

        public ActionResult UnSelected(int id)
        {
            var res = sl.Xoa(id);
            if (!res)
            {
                ModelState.AddModelError("", "Thêm slide xảy ra lỗi. Xin thử lại!");
            }
            return RedirectToAction("Them");
        }
    }
}