using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace WebsiteTS.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var accDao = new CategoryDao();
            var model = accDao.ListCategoryAll(page, pagesize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}