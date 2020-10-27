using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CustomerInfo
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string commune { get; set; }
    }
}