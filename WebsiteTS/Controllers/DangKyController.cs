using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using WebsiteTS.Common;
using WebsiteTS.Models;

namespace WebsiteTS.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult DangKy()
        {
            SetGender();
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            SetGender();
            return View();

        }
        [HttpPost]
        public ActionResult Register(TAIKHOAN model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                if (dao.CheckUserName(model.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    model.Password = MaHoa.Instance.Encrypt(model.Password);
                    SetGender(model.Gender);
                    var result = dao.Insert(model);
                    if (result)
                    {
                        return RedirectToAction("DangNhap","DangNhap");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }

            }
            SetGender(model.Gender); //  set giá trị 
            return View(model);
        }

        public void SetGender(string sl = null)
        {

            var b = new SelectList(new List<SelectListItem>
            {
                new SelectListItem {Text = "Nam",Value="Nam"},
                new SelectListItem {Text = "Nữ",Value="Nữ"},
            }, "Value", "Text", sl);

            ViewBag.Gender = b; // tên này phải trùng với tên lúc khai báo giới tính ở sql
        }
    }
}