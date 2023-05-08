using PagedList;
using System;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Authorize;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.Controllers
{
    [AuthorizeUserAttribute]
    public class GiayController : Controller
    {
        GiayDAO giayDAO = new GiayDAO();
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return View(giayDAO.GetAll().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Them()
        {
            var dm = new DanhMucDAO();
            ViewBag.Categories = dm.GetAll();
            return View("Them");
        }


        [HttpPost]
        public ActionResult Them(Giay g, HttpPostedFileBase image)
        {
            if (image != null)
            {
                image.SaveAs((HttpContext.Server.MapPath("~/Images/")+ image.FileName));
                g.image = image.FileName;
            } 
            int res = giayDAO.add(g);
            if (res != -1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm giày xảy ra lỗi. Xin thử lại!");
            return View();
        }


        public ActionResult Sua(int id)
        {
            Giay entity = giayDAO.getShoeById(id);
            var dm = new DanhMucDAO();
            ViewBag.Categories = dm.GetAll();
            return View(entity);
        }
        [HttpPost]
        public ActionResult Sua(Giay g, HttpPostedFileBase imageEdit)
        {
            if (imageEdit != null)
            {
                byte[] img = new byte[imageEdit.ContentLength];
                //image.InputStream.Read(img, 0, image.ContentLength);
                imageEdit.SaveAs((HttpContext.Server.MapPath("~/Images/") + imageEdit.FileName));
                g.image = imageEdit.FileName;
            }
            bool res = giayDAO.edit(g, false);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật xảy ra lỗi. Xin kiểm tra lại!");
            return View();
        }

        public ActionResult Xoa(int id)
        {
            Giay entity = giayDAO.getShoeById(id);
            var res = giayDAO.edit(entity, true);
            if (!res)
            {
                ModelState.AddModelError("", "Xóa khách hàng xảy ra lỗi. Xin thử lại!");
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}