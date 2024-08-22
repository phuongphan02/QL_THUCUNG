using QL_THUCUNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_THUCUNG.Controllers
{
    public class SanPhamController : Controller
    {
        #region SanPham
        QL_THUCUNGEntities db = new QL_THUCUNGEntities();
        // Lấy sản phẩm
        public List<SanPham> LaySaPham()
        {
            List<SanPham> lsSanPham = Session["SanPham"] as List<SanPham>;
            if (lsSanPham == null)
            {
                // Nếu giỏ hàng chưa tồn tại thì tạo giỏ hàng
                lsSanPham = new List<SanPham>();
                Session["SanPham"] = lsSanPham;
            }
            return lsSanPham;
        }
        // Thêm sản phẩm
        public ActionResult ThemSanPham(string madv, string url)
        {
            DichVu dv = db.DichVus.SingleOrDefault(n => n.ID_DV == madv);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SanPham> lsSanPham = LaySaPham();
            SanPham sp = lsSanPham.Find(n => n._MaSP == madv);
            if (sp == null)
            {
                sp = new SanPham(madv);
                lsSanPham.Add(sp);
                return Redirect(url);
            }
            else
            {
                sp.SoLuong++;
                return Redirect(url);
            }
        }
        // Cập nhật 
        public ActionResult CapNhat(string madv, FormCollection f)
        {
            DichVu dv = db.DichVus.SingleOrDefault(n => n.ID_DV == madv);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SanPham> lsSanPham = LaySaPham();
            SanPham sp = lsSanPham.SingleOrDefault(n => n._MaSP == madv);
            if (sp != null)
            {
                sp.SoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("SanPham");

        }
        // Xoa
        public ActionResult Xoa(string madv)
        {
            DichVu dv = db.DichVus.SingleOrDefault(n => n.ID_DV == madv);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SanPham> lsSanPham = LaySaPham();
            SanPham sp = lsSanPham.SingleOrDefault(n => n._MaSP == madv);
            if (sp != null)
            {
                lsSanPham.RemoveAll(n => n._MaSP == madv);
            }
            if (lsSanPham.Count == 0)
            {
                return RedirectToAction("Trangchu", "HomeUser");
            }
            return RedirectToAction("SanPham");
        }
        // Trang gio hang
        public ActionResult SanPham()
        {
            if (Session["SanPham"] == null)
            {
                return RedirectToAction("GoiMon", "HomeUser");
            }
            List<SanPham> lsSanPham = LaySaPham();
            return View(lsSanPham);
        }
        // Tổng số lượng
        private int TongSoLuong()
        {
            int SL = 0;
            List<SanPham> lsSanPham = Session["SanPham"] as List<SanPham>;
            if (lsSanPham != null)
            {
                SL = lsSanPham.Sum(n => n.SoLuong);
            }
            return SL;
        }
        // Tinh tien
        private double TongTien()
        {
            double Tongtien = 0;
            List<SanPham> lsSanPham = Session["SanPham"] as List<SanPham>;
            if (lsSanPham != null)
            {
                Tongtien = lsSanPham.Sum(n => n.ThanhTien);
            }
            return Tongtien;
        }

        // tạo partial giỏ hàng
        public ActionResult SanPhamPartial()
        {
            if (TongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                return PartialView();
            }
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }

        // Nguời dùng sửa giỏ hàng

        public ActionResult SuaSoLuong()
        {
            if (Session["SanPham"] == null)
            {
                return RedirectToAction("Trangchu", "HomeUser");
            }
            List<SanPham> lsSanPham = LaySaPham();
            return View(lsSanPham);

        }
        #endregion

        #region Gọi món
        [HttpPost]

        private string LayMaTT()
        {
            var maMax = db.ThanhToanDVs.ToList().Select(n => n.ID_TTDV).Max();
            int maTT = int.Parse(maMax.Substring(2)) + 1;
            string ID = String.Concat("00", maTT.ToString());
            return "TT" + ID.Substring(maTT.ToString().Length - 1);
        }
        public ActionResult GoiMon()
        {
            if (Session["SanPham"] == null)
            {
                RedirectToAction("Trangchu", "Home");
            }
            ThanhToanDV tt = new ThanhToanDV();
            List<SanPham> sp = LaySaPham();
            tt.ID_TTDV = LayMaTT();

            // Lấy id thành viên
            ThanhVien tv = (ThanhVien)Session["ThanhVien"];
            tt.ID_ThanhVien = tv.ID_ThanhVien;

            // Thêm vào database 
            db.ThanhToanDVs.Add(tt);
            Session["TTDV"] = tt;
            db.SaveChanges();
            foreach (var item in sp)
            {
                CTTTDV cttt = new CTTTDV();
                cttt.ID_TTDV = tt.ID_TTDV;
                cttt.ID_DV = item._MaSP;
                cttt.Soluong = item.SoLuong;
                cttt.Gia = (decimal)item.DonGia;
                db.CTTTDVs.Add(cttt);
            }
            db.SaveChanges();
            sp.Clear();
            return RedirectToAction("Trangchu", "HomeUser");
        }
        public ActionResult GoiSanPham()
        {
            List<SanPham> sp = LaySaPham();
            sp.Clear();
            return RedirectToAction("GoiMon", "HomeUser");
        }
            #endregion
        }
}