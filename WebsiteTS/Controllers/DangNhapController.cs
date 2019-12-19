using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTS.Common;
using WebsiteTS.Models;

namespace WebsiteTS.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(LoginCus login)
        {

            if (ModelState.IsValid)
            {

                var acc = new AccountDao();
                var kq = acc.Login(login.Username, login.Password);
                if (kq == 1)
                {
                    var user = acc.GetCus(login.Username);
                    var accSession = new AccLogin();
                    accSession.UserName = user.Username;
                    accSession.AccID = user.ID;

                    Session.Add(CommonConstants.Account_Session, accSession);

                    return Redirect("/Khachhang/Khachhang");
                }
                else if (kq == 2)
                {
                    var user = acc.Getnv(login.Username);
                    var accSession = new AccLogin();
                    accSession.UserName = user.Username;
                    accSession.AccID = user.MaNV;

                    Session.Add(CommonConstants.Account_Session, accSession);

                    return Redirect("/NhanVien/NhanVien");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            return View("DangNhap");
        }
        public ActionResult DangXuat()
        {
            Session[CommonConstants.Account_Session] = null;
            return RedirectToAction("DangNhap", "DangNhap");
        }
    }
}