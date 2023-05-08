using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.ModelAdmin
{
    public class ChiTietDonHangViewModel: DonHangViewModel
    {
        public int tenSp { get; set; }
        public string gia { get; set; }
        public int quantity { get; set; }
        public decimal? totalQuantity { get; set; }
    }
}