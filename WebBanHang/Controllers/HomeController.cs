using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        QLBHDataContext Data = new QLBHDataContext();
        private List<SANPHAM> Laysanphammoi(int count)
        {
            return Data.SANPHAMs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);
            var sanphammoi = Laysanphammoi(20);
            return View(sanphammoi.ToPagedList(pageNum, pageSize));
        }
        public ActionResult LoaiSP()
        {
            var LoaiSP = from cd in Data.LOAISPs select cd;
            return PartialView(LoaiSP);
        }
        public ActionResult ThuongHieu()
        {
            var ThuongHieu = from cd in Data.THUONGHIEUs select cd;
            return PartialView(ThuongHieu);
        }
        public ActionResult SPTheoLoaiSP(int id, int? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var Sanpham = from s in Data.SANPHAMs where s.MaLoai == id select s;
            return View(Sanpham.ToPagedList(pageNum, pageSize));
        }
        public ActionResult SPTheoThuongHieu(int id, int? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var Sanpham = from s in Data.SANPHAMs where s.MaTH == id select s;
            return View(Sanpham.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Details(int id)
        {
            var Sanpham = from s in Data.SANPHAMs
                          where s.Masanpham == id
                          select s;
            return View(Sanpham.Single());
        }
    }
}