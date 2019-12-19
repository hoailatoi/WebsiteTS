using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteTS.Controllers
{
    public class KhachhangController : Controller
    {
        // GET: Khachhang
        public ActionResult KhachHang()
        {
            var dao = new FoodDao();
            ViewBag.ListTS = dao.ListTraSua();
            return View();
        }
    }
}