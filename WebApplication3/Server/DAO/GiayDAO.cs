using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication3.Models;
using WebApplication3.Server.EF;

namespace WebApplication3.Server.DAO
{
    public class GiayDAO
    {
        ShopBanGiayDbConText db = null;
        public GiayDAO()
        {
            db = new ShopBanGiayDbConText();
        }

        public IEnumerable<Giay> GetAll()
        {
            SlideNewProductDAO sl = new SlideNewProductDAO();
            return db.Giays.Where(item => !item.isDeleted).ToList().Select(item => {
                item.viewCount = item.viewCount != null ? item.viewCount : 0;
                item.categoryName = db.TheLoais.Find(item.categoryId).categoryName;
                item.isActive = sl.getSlideBaseProductId(item.shoeId) != null ? true : false;
                return item;
            });
        }


        public IEnumerable<Giay> getProductBaseMaleorFemale(string size, string filterPrice, string filterType, string sortOrder, string type)
        {
            switch (filterType)
            {
                case "all":
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.Giays.OrderByDescending(s => s.shoeName).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "name_asc":
                            return db.Giays.OrderBy(s => s.shoeName).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "price_asc":
                            return db.Giays.OrderBy(s => s.price).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "price_desc":
                            return db.Giays.OrderByDescending(s => s.price).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "oldest":
                            return db.Giays.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "newest":
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "soldest":
                            return db.Giays.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        default:
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                    }
                    
                case "lesser":
                    int priceLesser = Convert.ToInt32(filterPrice);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.Giays.OrderByDescending(s => s.shoeName).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.Giays.OrderBy(s => s.shoeName).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.Giays.OrderBy(s => s.price).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.Giays.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.Giays.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.Giays.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
                    
                case "bigger":
                    int priceBigger = Convert.ToInt32(filterPrice);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.Giays.OrderByDescending(s => s.shoeName).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.Giays.OrderBy(s => s.shoeName).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.Giays.OrderBy(s => s.price).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.Giays.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.Giays.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.Giays.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
                default:
                    string[] price = filterPrice.Split('-');
                    int start = Convert.ToInt32(price[0]);
                    int end = Convert.ToInt32(price[1]);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.Giays.OrderByDescending(s => s.shoeName).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.Giays.OrderBy(s => s.shoeName).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.Giays.OrderBy(s => s.price).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.Giays.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.Giays.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.Giays.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
            }
        }
        public IEnumerable<Giay> getProductsMale(string size, string filterPrice, string filterType, string sortOrder)
        {
            return this.getProductBaseMaleorFemale(size, filterPrice, filterType, sortOrder, "male");
        }

        public IEnumerable<Giay> getProductsFemale(string size, string filterPrice, string filterType, string sortOrder)
        {
            return this.getProductBaseMaleorFemale(size, filterPrice, filterType, sortOrder, "female");
        }

        public IEnumerable<Giay> GetProductsBaseCategoryId(int categoryId, string type, string filterPrice, string filterType, string size, string sortOrder)
        {
            switch (filterType)
            {
                case "all":
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.Giays.OrderByDescending(s => s.shoeName).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.Giays.OrderBy(s => s.shoeName).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.Giays.OrderBy(s => s.price).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.Giays.OrderByDescending(s => s.price).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.Giays.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.Giays.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
                case "lesser":
                    int priceLesser = Convert.ToInt32(filterPrice);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.Giays.OrderByDescending(s => s.shoeName).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.Giays.OrderBy(s => s.shoeName).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.Giays.OrderBy(s => s.price).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.Giays.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.Giays.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.Giays.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
                    
                case "bigger":
                    int priceBigger = Convert.ToInt32(filterPrice);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.Giays.OrderByDescending(s => s.shoeName).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.Giays.OrderBy(s => s.shoeName).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.Giays.OrderBy(s => s.price).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.Giays.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.Giays.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.Giays.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });

                    }
                default:
                    string[] price = filterPrice.Split('-');
                    int start = Convert.ToInt32(price[0]);
                    int end = Convert.ToInt32(price[1]);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.Giays.OrderByDescending(s => s.shoeName).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.Giays.OrderBy(s => s.shoeName).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.Giays.OrderBy(s => s.price).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.Giays.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.Giays.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.Giays.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.Giays.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
            }
        }

        public Giay getShoeById(int id)
        {
            return db.Giays.Find(id);
        }

        public int add(Giay g)
        {
            try
            {
                g.createdAt = DateTime.Now;
                g.status = g.inventory == null || g.inventory == 0 ? false : true;
                g.isDeleted = false;
                g.isActive = false;
                db.Giays.Add(g);
                db.SaveChanges();
                return g.shoeId;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public bool edit(Giay g, bool isDeleted)
        {
            try
            {
                var giay = db.Giays.Find(g.shoeId);
                if (g.image != null)
                {
                    giay.image = g.image;
                }
                giay.shoeName = g.shoeName;
                giay.categoryId = g.categoryId;
                giay.color = g.color;
                giay.minifyDate = DateTime.Now;
                giay.material = g.material;
                giay.inventory = g.inventory;
                giay.price = g.price;
                giay.quantitySold = g.quantitySold;
                giay.size = g.size;
                giay.type = g.type;
                giay.isDeleted = isDeleted;
                giay.warranty = g.warranty;
                giay.description = g.description;
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
            try
            {
                Giay g = new Giay() { shoeId = id };
                db.Giays.Attach(g);
                db.Giays.Remove(g);
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