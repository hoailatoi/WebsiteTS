using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTS.Areas.Admin.Models;
using WebsiteTS.Common;
using Model.Dao;
using WebsiteTS.Models;

namespace WebsiteTS.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //GET: Admin/Login
        public ActionResult LoginAcc()
        {
            return View();
        }
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {

                var acc = new UserDao();
                var kq = acc.Login(loginModel.username, /*MaHoa.Instance.Encrypt(*/loginModel.password);
                if (kq == 1)
                {
                    var user = acc.GetAccount(loginModel.username);
                    var accSession = new AccLogin();
                    accSession.UserName = user.TenDNQTV;
                    accSession.AccID = user.MaQuanTri;
                    
                    Session.Add(CommonConstants.Admin_Session, accSession);

                    return Redirect("/Admin/Index/AdminIndex");
                }
                else if (kq == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            return View("LoginAcc");
        }
        public ActionResult Logout()
        {
            Session["Account_Session"] = null;
            return RedirectToAction("LoginAcc");
        }
    }
}