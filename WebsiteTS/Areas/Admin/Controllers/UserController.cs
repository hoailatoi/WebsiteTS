using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using WebsiteTS.Common;

namespace WebsiteTS.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var accDao = new AccountDao();
            var model = accDao.ListAccountAll(page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Tao()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new AccountDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Tao(TAIKHOAN acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                string mahoaPass = MaHoa.Instance.Encrypt(acc.Password);
                acc.Password = mahoaPass;
                int id = dao.InsertAccount(acc);
                if (id > 0)
                {

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tài khoản  thất bại");
                }
            }
            return View("DanhSachTaiKhoan");
        }
        [HttpPost]
        public ActionResult Edit(TAIKHOAN acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                if (!string.IsNullOrEmpty(acc.Password))
                {
                    string mahoaPass = MaHoa.Instance.Encrypt(acc.Password);
                    acc.Password = mahoaPass;
                }

                var result = dao.UpdateAccount(acc);
                if (result)
                {

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉnh sửa tài khoản thất bại");

                }
            }
            return View("Index");
        }

        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            bool result = new AccountDao().Delete(id);
            if (!result)
                ModelState.AddModelError("", "Chỉnh sửa tài khoản thất bại");
            return RedirectToAction("Index");
        }
    }
}