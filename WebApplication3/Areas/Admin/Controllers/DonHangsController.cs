using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Areas.Admin.ModelAdmin;
using WebApplication3.Authorize;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.Controllers
{
    [AuthorizeUserAttribute]
    public class DonHangsController : Controller
    {
        private ShopBanGiayDbConText db = new ShopBanGiayDbConText();

        public ActionResult UpdateStatus(int orderId, string status)
        {
            var _dh = new DonHang() { orderId = orderId, status = status };
            db.DonHangs.Attach(_dh);
            db.Entry(_dh).Property(X => X.status).IsModified = true;
            db.SaveChanges();
            return RedirectToAction("Details", new { id = orderId});
        }

        // GET: Admin/DonHangs
        public  ActionResult Index(string term, bool isSearchTerm = false, String Type = "all", int? page = 1)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            if (isSearchTerm)
            {
                var listOrders = db.DonHangs.ToList().Where(orderItem => orderItem.orderId == Convert.ToInt32(term)).Select(item =>
                {
                    item.customerName = db.KhachHangs.ToList().Where(kh =>
                    {

                        return kh.userId == item.userId;
                    }).Select(i => i.firstName).SingleOrDefault();
                    return item;
                }).ToPagedList(pageNumber, pageSize);
                return View(listOrders);
            }
            if (Type == "all")
            {
                var l = this.getOrderBaseStatus("all", pageNumber, pageSize);
                return View(l);
            } else if (Type == "pending")
            {
                var l = this.getOrderBaseStatus("pending", pageNumber, pageSize);
                return View(l);
            }
            else if (Type == "deliver")
            {
                var l = this.getOrderBaseStatus("deliver", pageNumber, pageSize);
                return View(l);
            }
            else if (Type == "delivered")
            {
                var l = this.getOrderBaseStatus("delivered", pageNumber, pageSize);
                return View(l);
            }
            else if (Type == "canceled")
            {
                var l = this.getOrderBaseStatus("canceled", pageNumber, pageSize);
                return View(l);
            }
            else
            {
                var l = this.getOrderBaseStatus("all", pageNumber, pageSize);
                return View(l);
            }
        }

        private IEnumerable<DonHang> getOrderBaseStatus(string status, int pageNumber, int pageSize)
        {
            if (status == "all")
            {
                return db.DonHangs.ToList().Select(item =>
                {
                    item.customerName = db.KhachHangs.ToList().Where(kh =>
                    {

                        return kh.userId == item.userId;
                    }).Select(i => i.firstName).SingleOrDefault();
                    return item;
                }).ToPagedList(pageNumber, pageSize);
            }
            return db.DonHangs.ToList().Where(i => i.status == status).Select(item =>
            {
                item.customerName = db.KhachHangs.ToList().Where(kh =>
                {

                    return kh.userId == item.userId;
                }).Select(i => i.firstName).SingleOrDefault();
                return item;
            }).ToPagedList(pageNumber, pageSize);
        } 

        // GET: Admin/DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var donHang = db.DonHangs.ToList().Where(order => order.orderId == id).Select(item => new DonHangViewModel() {
                customerName = db.KhachHangs.ToList().Where(kh => {
                    return kh.userId == item.userId;
                }).Select(i => i.firstName + " " + i.lastName).SingleOrDefault(),
                address = item.address,
                status = item.status,
                orderId = item.orderId,
                listOrders = db.ChiTietDonHangs.Where(product => product.orderId == item.orderId).ToList(),
                totalQuantity = db.ChiTietDonHangs.Where(product => product.orderId == item.orderId).Sum(i => i.quantity),
                totalMoney = db.ChiTietDonHangs.Where(product => product.orderId == item.orderId).Sum(i => i.price)
            }).SingleOrDefault();
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: Admin/DonHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderId,customerId,address,note,status,discountId")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donHang);
        }

        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderId,customerId,address,note,status,discountId")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donHang);
        }

        // GET: Admin/DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
