using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Server.EF;

namespace WebApplication3.Server.DAO
{
    public class DiscountDAO
    {
        ShopBanGiayDbConText db = null;
        public DiscountDAO()
        {
            db = new ShopBanGiayDbConText();
        }

        public IEnumerable<Discount> GetAll()
        {
            return db.Discounts.ToList().Select(item => {
                if (item.applyToProduct != 0)
                {
                    var g = db.Giays.Find(item.applyToProduct);
                    item.productName = g?.shoeName;
                } else
                {
                    item.productName = "Tất cả";
                }

                if (item.applyToCustomer != 0)
                {
                    item.customerName = db.KhachHangs.Find(item.applyToCustomer)?.firstName;
                }
                else
                {
                    item.customerName = "Tất cả";
                }

                return item;
            });
        }


        public int them(Discount dc)
        {
            dc.createdAt = DateTime.Now;
            dc.status = true;
            db.Discounts.Add(dc);
            db.SaveChanges();
            return dc.discountId;
        }


        public Discount getDiscountById(int id)
        {

            return db.Discounts.SingleOrDefault(item => item.discountId == id);
        }

        public Discount getDiscountBaseCode(String code, int discountId)
        {
            if (discountId != -1)
            {
                return db.Discounts.Where(item => item.discountId != discountId).ToList().SingleOrDefault(item => item.code == code);
            }
            return db.Discounts.SingleOrDefault(item => item.code == code);
        }
        public bool update(Discount entity)
        {
            try
            {
                var kh = db.Discounts.Find(entity.discountId);
                kh.discountName = entity.discountName;
                kh.code = entity.code;
                kh.value = entity.value;
                kh.applyToCustomer = entity.applyToCustomer;
                kh.applyToProduct = entity.applyToProduct;
                kh.limit = entity.limit;
                kh.startDate = entity.startDate;
                kh.endDate = entity.endDate;
                kh.type = entity.type;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool remove(int id)
        {
            try
            {
                Discount dc = new Discount() { discountId = id };
                db.Discounts.Attach(dc);
                db.Discounts.Remove(dc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}