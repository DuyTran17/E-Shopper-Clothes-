using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;

namespace DoAn_TranQuocDuy.Areas.PrivatesPages.Controllers
{
    public class DashboardController : Controller
    {
        // GET: PrivatesPages/Dashboard
        public ActionResult Index()
        {           
            TaiKhoan x = (TaiKhoan)Session["Login"]; 
            ViewData["taiKhoan"] = x;
            return View();
        }
    }
}