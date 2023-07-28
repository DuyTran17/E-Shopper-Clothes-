using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_TranQuocDuy.Models;


namespace DoAn_TranQuocDuy.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TaiKhoan x)
        {
            //Kiểm tra nếu tên tài khoản đã có sẽ chuyển thẳng về trang login
            foreach(TaiKhoan i in Common.getAccout())
            {
                if (x.taiKhoan1.Equals(i.taiKhoan1))
                {
                    break;
                }
                else
                {
                    DoAnConnect db = new DoAnConnect();
                    db.TaiKhoans.Add(x);
                    db.SaveChanges();
                    break;
                }
            }
            
            return RedirectToAction("Index", "Login");
        }
    }
    

}