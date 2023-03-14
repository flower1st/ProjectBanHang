using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QLBHDataContext Data = new QLBHDataContext();
        [HttpPost]
        // GET: TimKiem
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<SANPHAM> lstKQTK = Data.SANPHAMs.Where(n => n.Tensanpham.Contains(sTuKhoa)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstKQTK.Count == null)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào ";
                return View(Data.SANPHAMs.OrderBy(n => n.Tensanpham).ToPagedList(pageNumber, pageSize));

            }
            ViewBag.Thongbao = "Đã tìm thấy  " + lstKQTK.Count + "  kết quả!";
            return View(lstKQTK.OrderBy(n => n.Tensanpham).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<SANPHAM> lstKQTK = Data.SANPHAMs.Where(n => n.Tensanpham.Contains(sTuKhoa)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstKQTK.Count == null)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào ";
                return View(Data.SANPHAMs.OrderBy(n => n.Tensanpham).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Thongbao = "Đã tìm thấy  " + lstKQTK.Count + "  kết quả!";
            return View(lstKQTK.OrderBy(n => n.Tensanpham).ToPagedList(pageNumber, pageSize));
        }
    }
}