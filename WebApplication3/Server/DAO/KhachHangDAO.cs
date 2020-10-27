using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Server.EF;
namespace WebApplication3.Server.DAO
{
    public class KhachHangDAO
    {
        ShopBanGiayDbConText db = null;
        public KhachHangDAO()
        {
            db = new ShopBanGiayDbConText();
        }

        public IEnumerable<KhachHang> getAll()
        {
            return db.KhachHangs.ToList();
        }

        public Boolean them(KhachHang kh)
        {
            var checkEmailExist = db.KhachHangs.Where(item => item.email == kh.email);
            if (checkEmailExist.Count() > 0)
            {
                return false;
            }
            kh.createdAt = DateTime.Now;
            kh.isAdmin = kh.isAdmin == null || kh.isAdmin == false ? false : true;
            db.KhachHangs.Add(kh);
            db.SaveChanges();
            return true;
        }

        public KhachHang getUserByEmail(String email) {
            return db.KhachHangs.SingleOrDefault(item => item.email == email);
        }

        public KhachHang getUserById(int id)
        {

            return db.KhachHangs.SingleOrDefault(item => item.userId == id);
        }

        public bool updateCustomer(KhachHang entity)
        {
            try
            {
                var kh = db.KhachHangs.Find(entity.userId);
                kh.firstName = entity.firstName;
                kh.lastName = entity.lastName;
                kh.address = entity.address;
                kh.email = entity.email;
                kh.age = entity.age;
                kh.phone = entity.phone;
                kh.isAdmin = entity.isAdmin;
                kh.modifyDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool removeCustomer(int id) {
            try
            {
                KhachHang kh = new KhachHang() { userId = id };
                db.KhachHangs.Attach(kh);
                db.KhachHangs.Remove(kh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool login(String email, String password, Boolean isWeb)
        {
            var check = db.KhachHangs.Count(item => item.email == email && item.password == password && item.isAdmin == !isWeb);
            if (check > 0)
            {
                return true;
            }
            return false;
        }
    }
}