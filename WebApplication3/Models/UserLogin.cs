using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Mời bạn nhập email")]
        public String email { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        public String password { get; set; }
    }
}