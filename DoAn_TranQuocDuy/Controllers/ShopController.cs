﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;

namespace DoAn_TranQuocDuy.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(int MaLoai)
        {
            DoAnConnect db = new DoAnConnect();
            LoaiSP x = db.LoaiSPs.Where(sp => sp.maLoai.Equals(MaLoai)).First<LoaiSP>();
            string y = x.tenLoai;
            ViewData["loaiSPcanxem"] = x;
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