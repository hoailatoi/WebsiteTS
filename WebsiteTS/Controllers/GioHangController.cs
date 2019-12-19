using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

using WebsiteTS.Common;
using WebsiteTS.Models;
using System.Web.Script.Serialization;
using Model.EF;
using System.Configuration;

namespace WebsiteTS.Controllers
{
    public class GioHangController : Controller
    {
        public const string CartSession = "CartSession";
        // GET: GioHang
        public ActionResult Cart()
        {
            var Cart = Session[CartSession];
            var list = new List<CartItem>();
            if (Cart != null)
            {
                list = (List<CartItem>)Cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int maDoUong, int SoLuong)
        {
            var douong = new FoodDao().GetFood(maDoUong);
            var Cart = Session[CartSession];
            if (Cart != null)
            {
                var list = (List<CartItem>)Cart;
                if (list.Exists(x => x.Monan.MaTS == maDoUong))
                {
                    foreach (var item in list)
                    {
                        if (item.Monan.MaTS == maDoUong)
                        {
                            item.SoLuong += SoLuong;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Monan = douong;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Monan = douong;
                item.SoLuong = SoLuong;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Cart", "GioHang");
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Monan.MaTS == item.Monan.MaTS);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        //xóa tất cả trong gio hàng
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        //xóa 1 mặt hàng trong giỏ h
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Monan.MaTS == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult ThanhToan()
        {

            if (Session[CommonConstants.Account_Session] == null)
            {
                return Redirect("/DangNhap/DangNhap");
            }
            else
            {
                var cart = Session[CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult ThanhToan(string shipName, string address, string mobile, string httt, string htgh)
        {
            var od = new OrderDao();
            var session = (AccLogin)Session[CommonConstants.Account_Session];
            var dondathang = new DONDATHANG();
            dondathang.ID = new AccountDao().GetCus(session.UserName).ID;
            dondathang.NgayGiaoHang = DateTime.Now;
            dondathang.TenNguoiNhan = shipName;
            dondathang.DiaChiNhan = address;
            dondathang.DienThoaiNhan = mobile;
            dondathang.HTGiaoHang = htgh;
            dondathang.HTThanhToan = httt;
            try
            {
                var soDH = od.Insert(dondathang);
                var cart = (List<CartItem>)Session[CartSession];
                var chitietDao = new OrderDetailDao();
                decimal total = 0;
                string tenmonan = null, gia = null;
                foreach (var item in cart)
                {
                    decimal thanhtien = 0;
                    var chitiet = new CTDATHANG();
                    chitiet.SoDH = soDH;
                    chitiet.MaTS = item.Monan.MaTS;
                    chitiet.DonGia = item.Monan.DonGia;
                    chitiet.SoLuong = item.SoLuong;
                    thanhtien += item.Monan.DonGia.Value * item.SoLuong;
                    od.InsertSLBan(item.Monan.MaTS, item.SoLuong);
                    chitietDao.Insert(chitiet);

                    total += (item.Monan.DonGia.GetValueOrDefault(0) * item.SoLuong);
                    tenmonan += item.Monan.TenTS + "<br />";
                    gia += item.Monan.DonGia.GetValueOrDefault(0).ToString("N0") + "<br />";
                }
                Session[CartSession] = null;

            }
            catch (Exception)
            {
                return Redirect("/loi-thanh-toan");
            }
            return RedirectToAction("DatHangThanhCong", "GioHang");
        }
        public ActionResult DatHangThanhCong()
        {
            return View();
        }
    }

}
