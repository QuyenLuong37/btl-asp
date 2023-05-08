using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Controllers
{
    public class HangKhuyenMaiController : Controller
    {
        private ShopBanGiayDbConText db = new ShopBanGiayDbConText();
        // GET: HangKhuyenMai
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            var list = db.Giays.Where(item => item.comparePrice > item.price).ToList().ToPagedList(pageNumber, pageSize);
            return PartialView(list) ;
        }
    }
}