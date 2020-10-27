using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Server.EF;

namespace WebApplication3.Server.DAO
{
    public class DanhMucDAO
    {
        ShopBanGiayDbConText db = null;
        public DanhMucDAO()
        {
            db = new ShopBanGiayDbConText();
        }

        public IEnumerable<TheLoai> GetAll()
        {
            return db.TheLoais.ToList();
        }


        public TheLoai getCategoryById(int id)
        {
            return db.TheLoais.SingleOrDefault(item => item.id == id);
        }

        public int add(TheLoai tl)
        {
            try
            {
                tl.createdDate = DateTime.Now;
                db.TheLoais.Add(tl);
                db.SaveChanges();
                return tl.id;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public bool update(TheLoai tl)
        {
            try
            {
                var entity = db.TheLoais.Find(tl.id);
                entity.categoryName = tl.categoryName;
                entity.description = tl.description;
                entity.minifyDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool remove(int id)
        {
            foreach(var g in db.Giays.Where(item => item.categoryId == id))
            {
                db.Giays.Attach(g);
                db.Giays.Remove(g);
            }
            TheLoai tl = new TheLoai() { id = id };
            db.TheLoais.Attach(tl);
            db.TheLoais.Remove(tl);
            db.SaveChanges();
            return true;
        }

    }
}