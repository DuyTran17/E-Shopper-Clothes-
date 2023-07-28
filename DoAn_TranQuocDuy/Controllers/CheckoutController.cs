using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;
using System.Data.Entity;

namespace DoAn_TranQuocDuy.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            ViewData["spDaChon"] = gh;
            return View();
        }
        [HttpPost]
        public ActionResult SaveToDatabase(KhachHang x)
        {
            // So sánh ngày sinh phải sau năm 1980
            DateTime datemin = new DateTime(1980, 01, 01);
            //Kiểm tra tính đúng đắn của sô điện thoại
            if(x.soDT.Length < 10)
            {
                if (x.ngaySinh > datemin)
                {
                    using (var context = new DoAnConnect())
                    {
                        using (DbContextTransaction trans = context.Database.BeginTransaction())
                        {
                            try
                            {
                                x.maKH = x.soDT;
                                context.KhachHangs.Add(x);
                                context.SaveChanges();
                                DonHang d = new DonHang();
                                d.maKH = x.maKH;
                                d.soDH = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                                d.ngayDat = DateTime.Now; d.ngayGH = DateTime.Now.AddDays(5);
                                d.taiKhoan = "admin";
                                d.diaChiGH = x.diaChi;
                                context.DonHangs.Add(d);
                                context.SaveChanges();
                                ShopCart gh = Session["GioHang"] as ShopCart;
                                foreach (CtDonHang i in gh.spDaChon.Values)
                                {
                                    i.soDH = d.soDH;
                                    context.CtDonHangs.Add(i);
                                }
                                context.SaveChanges();
                                trans.Commit();
                                RedirectToAction("Index", "CheckOutSuccess");
                            }
                            catch (Exception e)
                            {
                                trans.Rollback();
                            }
                        }
                    }
                }
                else RedirectToAction("Index", "CheckOut");
            }
            else RedirectToAction("Index", "CheckOut");


            return RedirectToAction("Index","CheckOutSuccess");
        }
    }
}