using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;

namespace DoAn_TranQuocDuy.Controllers
{
    public class CartController : Controller
    { 
        [HttpGet]
        public ActionResult Index()
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            ViewData["spDaChon"] = gh;
            return View();
        }
        public ActionResult Add(string maSP)
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            gh.themSP(maSP,1);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult Decrease(string maSP)
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            gh.giamSoLuong(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string maSP)
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            gh.xoaSP(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
    }
}