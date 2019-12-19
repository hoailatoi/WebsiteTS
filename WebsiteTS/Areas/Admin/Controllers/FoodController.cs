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
    public class FoodController : Controller
    {
        // GET: Admin/Food
        public ActionResult DSFood(int page = 1, int pagesize = 10)
        {
            var accDao = new FoodDao();
            var model = accDao.ListFoodAll(page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Food()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Food(TS model)
        {
            if (ModelState.IsValid)
            {
                SetViewBag(model.MaTS);
                var kq = new FoodDao().Insert(model);
                if (kq)
                {
                    return Redirect("/Admin/Food/DSFood");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new FoodDao();
            var food = dao.GetFood(id);
            SetViewBag(food.MaTS);
            return View(food);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(TS model)
        {
            if (ModelState.IsValid)
            {
                SetViewBag(model.MaTS);
                var kq = new FoodDao().Update(model);
                if (kq)
                {
                    return Redirect("/Admin/Food/DSFood");
                }
            }
            SetViewBag(model.MaTS);
            return View(model);
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.MaTS = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        [HttpGet]

        public ActionResult Delete(int id)
        {
            bool result = new FoodDao().Delete(id);
            if (result)
            {
                return Redirect("/Admin/Food/DSFood"); ;
            }
            else { ModelState.AddModelError("", "Xóa món thất bại"); }
            return Redirect("/Admin/Food/DSFood"); ;
        }
    }
}