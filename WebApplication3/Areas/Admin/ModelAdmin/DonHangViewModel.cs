using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.ModelAdmin
{
    public  class DonHangViewModel
    {
        public int orderId { get; set; }
        public string customerName { get; set; }
        public string address { get; set; }
        public string status  { get; set; }
        public string note { get; set; }
        public DateTime? createdAt { get; set; }

        public List<WebApplication3.Server.EF.ChiTietDonHang> listOrders { get; set; }
        public int? totalQuantity { get; set; }
        public decimal? totalMoney { get; set; }
    }
}