using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;

namespace DoAn_TranQuocDuy.Controllers
{
    public class DetailController : Controller
    {
        // GET: detail
        public ActionResult Index(string MaSP)
        {
            DoAnConnect db = new DoAnConnect();
            SanPham x = db.SanPhams.Where(sp => sp.maSP.Equals(MaSP)).First<SanPham>();
            ViewData["SPcanxem"] = x;
            return View();
        }
        public ActionResult Add(string maSP)
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            gh.themSP(maSP, 1);
            Session["GioHang"] = gh;
            return RedirectToAction("Index","Home");
        }
    }
}