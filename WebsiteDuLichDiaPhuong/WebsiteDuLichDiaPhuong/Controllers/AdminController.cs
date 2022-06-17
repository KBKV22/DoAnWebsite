using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDuLichDiaPhuong.Models;

namespace WebsiteDuLichDiaPhuong.Controllers
{
    public class AdminController : Controller
    {
        DuLichDiaPhuongModel dbDuLich = new DuLichDiaPhuongModel();
        // GET: Admin
        public ActionResult TrangChu()
        {
            return View();
        }

        public ActionResult DanhSachQuanHuyen()
        {
            var danhSach = dbDuLich.HUYENs.ToList();
            return View(danhSach);
        }

        public ActionResult ThemQuanHuyenMoi()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemQuanHuyenMoi(HUYEN huyen)
        {
            if (ModelState.IsValid)
            {
                HUYEN h = new HUYEN();
                h.TenHuyen = huyen.TenHuyen;
                h.MieuTa = huyen.MieuTa;
                dbDuLich.HUYENs.Add(h);
                dbDuLich.SaveChanges();
                return RedirectToAction("DanhSachQuanHuyen");
            }
            return View(huyen);
        }

        // Sửa thông tin
        public ActionResult SuaQuanHuyen(int id)
        {
            HUYEN huyen = dbDuLich.HUYENs.SingleOrDefault(n => n.MaHuyen == id);
            if (huyen == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(huyen);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaQuanHuyen(HUYEN huyen)
        {
            if (ModelState.IsValid)
            {
                var suaHuyen = dbDuLich.HUYENs.SingleOrDefault(p => p.MaHuyen == huyen.MaHuyen);
                suaHuyen.TenHuyen = huyen.TenHuyen;
                suaHuyen.MieuTa = huyen.MieuTa;
                UpdateModel(suaHuyen);
                dbDuLich.SaveChanges();
                return RedirectToAction("DanhSachQuanHuyen", huyen);
            }
            return View(huyen);
        }

        public ActionResult ChiTietQuanHuyen(int id)
        {
            HUYEN huyen = dbDuLich.HUYENs.SingleOrDefault(n => n.MaHuyen == id);
            if (huyen == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(huyen);
        }

        public ActionResult XoaQuanHuyen(int id)
        {
            HUYEN huyen = dbDuLich.HUYENs.SingleOrDefault(n => n.MaHuyen == id);
            if (huyen == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(huyen);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XoaQuanHuyen(int id, HUYEN huyen)
        {
            var xoaHuyen = dbDuLich.HUYENs.SingleOrDefault(p => p.MaHuyen == id);
            dbDuLich.HUYENs.Remove(xoaHuyen);
            dbDuLich.SaveChanges();
            return RedirectToAction("DanhSachQuanHuyen");
        }

        public ActionResult DanhSachKhachSan()
        {
            var danhSach = dbDuLich.KHACHSANs.ToList();
            return View(danhSach);
        }
        //Thêm khách sạn mới
        public ActionResult ThemKhachSanMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemKhachSanMoi(KHACHSAN khachsan)
        {
            if (ModelState.IsValid)
            {
                KHACHSAN ks = new KHACHSAN();
                ks.TenKS = khachsan.TenKS;
                ks.DiaChi = khachsan.DiaChi;
                dbDuLich.KHACHSANs.Add(khachsan);
                dbDuLich.SaveChanges();
                return RedirectToAction("DanhSachQuanHuyen");
            }
            return View(khachsan);
        }


        // Sửa thông tin
        public ActionResult SuaKhachSan(int id)
        {
            KHACHSAN khachsan = dbDuLich.KHACHSANs.SingleOrDefault(n => n.MaKS == id);
            if (khachsan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaHuyen = new SelectList(dbDuLich.HUYENs.ToList(), "MaHuyen", "TenHuyen", khachsan.MaHuyen);
            return View(khachsan);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaKhachSan(KHACHSAN khachsan)
        {
            if (ModelState.IsValid)
            {
                var suaKhachSan = dbDuLich.KHACHSANs.SingleOrDefault(p => p.MaKS == khachsan.MaKS);
                suaKhachSan.TenKS = khachsan.TenKS;
                suaKhachSan.DiaChi = khachsan.DiaChi;
                suaKhachSan.SĐT = khachsan.SĐT;
                UpdateModel(suaKhachSan);
                dbDuLich.SaveChanges();
                return RedirectToAction("DanhSachQuanHuyen", khachsan);
            }
            return View(khachsan);
        }

        //Chi tiết khách sạn
        public ActionResult ChiTietKhachSan(int id)
        {
            KHACHSAN khachsan = dbDuLich.KHACHSANs.SingleOrDefault(n => n.MaKS == id);
            if (khachsan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachsan);
        }

        //Xóa khách sạn
        public ActionResult XoaKhachSan(int id)
        {
            KHACHSAN khachsan = dbDuLich.KHACHSANs.SingleOrDefault(n => n.MaKS == id);
            if (khachsan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachsan);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XoaKhachSan(int id, KHACHSAN khachsan)
        {
            var xoaKhachSan = dbDuLich.KHACHSANs.SingleOrDefault(p => p.MaKS == id);
            dbDuLich.KHACHSANs.Remove(xoaKhachSan);
            dbDuLich.SaveChanges();
            return RedirectToAction("DanhSachKhachSan");
        }






    }
}