using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DoAn_TranQuocDuy.Models
{
    public class Common
    {
        static DbContext cn = new DbContext("name=DoAnConnect");
        public static List<LoaiSP> getCategories()
        {
            List<LoaiSP> l = new List<LoaiSP>();            
            l = cn.Set<LoaiSP>().ToList<LoaiSP>();
            return l;
        }
        public static List<SanPham> getProduct()
        {
            List<SanPham> l = new List<SanPham>();
            l = cn.Set<SanPham>().ToList<SanPham>();
            return l;
        }
        public static List<SanPham> getProductByType(int maLoai)
        {
            List<SanPham> l = new List<SanPham>();
            l = cn.Set<SanPham>().Where(x => x.maLoai.Equals(maLoai)).ToList<SanPham>();
            return l;
        }
        public static List<TaiKhoan> getAccout()
        {
            List<TaiKhoan> l = new List<TaiKhoan>();
            l = cn.Set<TaiKhoan>().ToList<TaiKhoan>();
            return l;
        }
        public static List<SanPham> getProductByAccount(string account)
        {
            List<SanPham> l = new List<SanPham>();
            l = cn.Set<SanPham>().Where(x => x.taiKhoan.Equals(account)).ToList<SanPham>();
            return l;
        }
        public static SanPham getProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP);
        }
        public static string getNameProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).tenSP;
        }
        public static string getImgProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).hinhDD;
        }
    }
}