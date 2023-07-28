using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;

namespace DoAn_TranQuocDuy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Add(string maSP)
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            gh.themSP(maSP, 1);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
    }
}