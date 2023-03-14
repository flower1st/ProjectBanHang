using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class Giohang
    {
        QLBHDataContext data = new QLBHDataContext();
        public int iMasanpham { set; get; }
        public string sTensanpham { set; get; }
        public string sAnhbia { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        public Giohang(int Masanpham)
        {
            iMasanpham = Masanpham;
            SANPHAM sanpham = data.SANPHAMs.Single(n => n.Masanpham == iMasanpham);
            sTensanpham = sanpham.Tensanpham;
            sAnhbia = sanpham.Anhbia;
            dDongia = double.Parse(sanpham.Giaban.ToString());
            iSoluong = 1;
        }
    }
}