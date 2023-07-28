using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;

namespace DoAn_TranQuocDuy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string acc , string pass)
        {
            foreach(TaiKhoan i in Common.getAccout())
            {
                if (acc.Equals(i.taiKhoan1) && pass.Equals(i.matKhau))
                {
                    Session["Login"] = i;
                    return RedirectToAction("Index", "Dashboard", new {Acc= i.taiKhoan1, area = "PrivatesPages" });
                    break;
                }
            }
            
            return View();
        }
    }
}