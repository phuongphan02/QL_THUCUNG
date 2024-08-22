using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QL_THUCUNG.Models;

namespace QL_THUCUNG.Controllers
{
    public class HoaDonsController : Controller
    {
        private QL_THUCUNGEntities db = new QL_THUCUNGEntities();

        // GET: HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.Chuong).Include(h => h.ThanhVien).Include(h => h.ThanhToanDV);
            return View(hoaDons.ToList());
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        public ActionResult ChiTietHoaDon(string id_chuong)
        {
            var hoaDons = db.HoaDons
                .Include(h => h.Chuong)
                .Include(h => h.ThanhVien)
                .Include(h => h.ThanhToanDV)
                .Where(h => h.ID_Chuong == id_chuong)
                .ToList();

            if (hoaDons.Count == 0)
            {
                return HttpNotFound();
            }

            ViewBag.MaChuong = id_chuong;
            // Thêm nút thanh toán nếu hóa đơn chưa được thanh toán
            if (hoaDons.Any(h => h.TinhTrangHD == "Chưa thanh toán"))
            {
                ViewBag.ThanhToan = true;
            }
            else
            {
                ViewBag.ThanhToan = false;
            }

            return View(hoaDons);
        }
        public ActionResult ThanhToan(string id)
        {
            // Lấy danh sách các hóa đơn chưa được thanh toán của chuồng
            var hoaDons = db.HoaDons.Where(h => h.ID_Chuong == id && h.TinhTrangHD == "Chưa thanh toán").ToList();

            // Cập nhật trạng thái hóa đơn và chuồng
            foreach (var hoaDon in hoaDons)
            {
                hoaDon.TinhTrangHD = "Đã thanh toán";
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult DongChuong(string id)
        {
            // Lấy danh sách các hóa đơn của chuồng
            var hoaDons = db.HoaDons.Where(h => h.ID_Chuong == id).ToList();

            // Cập nhật trạng thái hóa đơn và chuồng
            foreach (var hoaDon in hoaDons)
            {
                if(hoaDon != null) {  
                    hoaDon.Chuong.Hoatdong = false;
                    db.SaveChanges();
                }
               
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.ID_Chuong = new SelectList(db.Chuongs, "ID_Chuong", "TenChuong");
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_ThanhVien", "TenThanhVien");
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_ThanhVien");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HoaDon,ID_ThanhVien,ID_TTDV,ID_Chuong,ThoiGianNhan,ThoiGianTra,TongTien,TinhTrangHD")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Chuong = new SelectList(db.Chuongs, "ID_Chuong", "TenChuong", hoaDon.ID_Chuong);
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_ThanhVien", "TenThanhVien", hoaDon.ID_ThanhVien);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_ThanhVien", hoaDon.ID_TTDV);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Chuong = new SelectList(db.Chuongs, "ID_Chuong", "TenChuong", hoaDon.ID_Chuong);
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_ThanhVien", "TenThanhVien", hoaDon.ID_ThanhVien);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_ThanhVien", hoaDon.ID_TTDV);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HoaDon,ID_ThanhVien,ID_TTDV,ID_Chuong,ThoiGianNhan,ThoiGianTra,TongTien,TinhTrangHD")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Chuong = new SelectList(db.Chuongs, "ID_Chuong", "TenChuong", hoaDon.ID_Chuong);
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_ThanhVien", "TenThanhVien", hoaDon.ID_ThanhVien);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_ThanhVien", hoaDon.ID_TTDV);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
