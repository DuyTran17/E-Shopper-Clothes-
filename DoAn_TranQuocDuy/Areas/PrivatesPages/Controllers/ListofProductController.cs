using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;

namespace DoAn_TranQuocDuy.Areas.PrivatesPages.Controllers
{
    public class ListofProductController : Controller
    {
        // GET: PrivatesPages/ListofProduct
        public ActionResult Index()
        {
            TaiKhoan x = (TaiKhoan)Session["Login"];
            ViewData["taiKhoan"] = x;
            return View();
        }
        [HttpPost]
        public ActionResult Index(SanPham y)
        {
            DoAnConnect db = new DoAnConnect();
            TaiKhoan x = (TaiKhoan)Session["Login"];
            ViewData["taiKhoan"] = x;
            y.taiKhoan = x.taiKhoan1;
            y.ngayDang = DateTime.Now;
            db.SanPhams.Add(y);
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maSP)
        {
            TaiKhoan y = (TaiKhoan)Session["Login"];
            ViewData["taiKhoan"] = y;
            DoAnConnect db = new DoAnConnect();
            SanPham x = db.SanPhams.Find(maSP);
            db.SanPhams.Remove(x);
            db.SaveChanges();
            return View("Index");
        }
        public ActionResult Duyet(string maSP)
        {
            TaiKhoan y = (TaiKhoan)Session["Login"];
            ViewData["taiKhoan"] = y;
            DoAnConnect db = new DoAnConnect();
            SanPham x = db.SanPhams.Find(maSP);
            db.SanPhams.Remove(x);
            db.SaveChanges();
            x.daDuyet = true;
            x.taiKhoan = y.taiKhoan1;
            db.SanPhams.Add(x);
            db.SaveChanges();
            return View("Index");
        }
    }
}