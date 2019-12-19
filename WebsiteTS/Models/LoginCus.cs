using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteTS.Models
{
    public class LoginCus
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        public bool rememberMe { set; get; }
    }
}