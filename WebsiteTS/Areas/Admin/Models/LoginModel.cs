using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteTS.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Nhập Tài Khoản")]
        public string username { set; get; }
        [Required(ErrorMessage = "Nhập Mật Khẩu")]
        public string password { set; get; }
        public string remenberme { set; get; }
    }
}