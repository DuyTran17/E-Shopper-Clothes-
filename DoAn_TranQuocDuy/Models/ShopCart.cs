using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_TranQuocDuy.Models
{
    public class ShopCart
    {
        public string maKH { set; get; }
        public string taiKhoan { set; get; }
        public DateTime ngayDat { set; get; }
        public DateTime ngayGiao { set; get; }
        public string diaChi { set; get; }
        public SortedList<string, CtDonHang> spDaChon { get; set; }

        public ShopCart()
        {
            this.maKH = "";
            this.taiKhoan = "";
            this.ngayDat = DateTime.Now;
            this.ngayGiao = ngayDat.AddDays(5);
            this.diaChi = "";
            this.spDaChon = new SortedList<string, CtDonHang>();
        }
        public bool isEmpty()
        {
            return spDaChon.Keys.Count == 0;
        }
        public void themSP(string maSP,int soLuong)
        {
            if(spDaChon.Keys.Contains(maSP))
            {
                CtDonHang x = spDaChon.Values[spDaChon.IndexOfKey(maSP)];
                x.soLuong++;
            }
            else
            {
                CtDonHang y = new CtDonHang();
                y.maSP = maSP;
                y.soLuong = soLuong;
                SanPham z = Common.getProductByID(maSP);
                y.giaBan = z.giaBan;
                y.giamGia = z.giamGia;
                spDaChon.Add(maSP, y);
            }
        }
        public void xoaSP(string maSP)
        {
            if (spDaChon.Keys.Contains(maSP))
            {
                spDaChon.Remove(maSP);
            }
        }
        public void giamSoLuong(string maSP)
        {
            if (spDaChon.Keys.Contains(maSP))
            {
                CtDonHang x = spDaChon.Values[spDaChon.IndexOfKey(maSP)];
                if (x.soLuong > 1)
                {
                    x.soLuong--;  
                }
                else
                    xoaSP(maSP);
            }
        }
        public long giaTienMotSP(CtDonHang x)
        {
            return (long)((x.giaBan - (x.giaBan * (x.giamGia / 100)))   * x.soLuong);
        }
        public long tongGioHang()
        {
            long tt = 0;
            foreach (CtDonHang x in spDaChon.Values)
                tt += giaTienMotSP(x);
            return tt;
        }

    }
}