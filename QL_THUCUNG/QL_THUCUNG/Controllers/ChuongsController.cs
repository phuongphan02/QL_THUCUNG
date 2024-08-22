using QL_THUCUNG.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QL_THUCUNG.Controllers
{
    public class ChuongsController : Controller
    {
        private QL_THUCUNGEntities   db = new QL_THUCUNGEntities();

        // GET: Chuongs
        public ActionResult Index()
        {

            var Chuongs = db.Chuongs.Include(m => m.DonGia);
            return View(Chuongs.ToList());
        }
        
        public ActionResult TimKiemNC(string Ma = "", string Ten = "", string tt = "", string ID_Gia = "", string hd = "")
        {
            ViewBag.Ma = Ma;
            ViewBag.Ten = Ten;
            ViewBag.tt = tt;
            ViewBag.ID_Gia = ID_Gia;
            ViewBag.hd = hd;
            var m = db.Chuongs.SqlQuery("Chuong_TimKiem'" + Ma + "',N'" + Ten + "','" + tt + "','" + ID_Gia + "','" + hd + "'");

            if (m.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(m.ToList());
        }


        // GET: Chuongs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong Chuong = db.Chuongs.Find(id);
            if (Chuong == null)
            {
                return HttpNotFound();
            }
            return View(Chuong);
        }

        // GET: Chuongs/Create
        string LayMa()
        {
            var maMax = db.Chuongs.ToList().Select(n => n.ID_Chuong).Max();
            int maTV = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("00", maTV.ToString());
            return "AS" + NV.Substring(maTV.ToString().Length - 1);
        }
        public ActionResult Create()
        {
            ViewBag.ID_Chuong = LayMa();
            ViewBag.ID_Gia = new SelectList(db.DonGias, "ID_Gia", "GiaChuong");
            return View();
        }

        // POST: Chuongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Chuong,TenChuong,TinhTrangChuong,ID_Gia,Hoatdong")] Chuong Chuong)
        {
            if (ModelState.IsValid)
            {
                Chuong.ID_Chuong = LayMa();
                Chuong.Hoatdong = false;
                db.Chuongs.Add(Chuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Gia = new SelectList(db.DonGias, "ID_Gia", "ID_Gia", Chuong.ID_Gia);
            return View(Chuong);
        }

        // GET: Chuongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong Chuong = db.Chuongs.Find(id);
            if (Chuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Gia = new SelectList(db.DonGias, "ID_Gia", "GiaChuong", Chuong.ID_Gia);
            return View(Chuong);
        }

        // POST: Chuongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Chuong,TenChuong,TinhTrangChuong,ID_Gia,Hoatdong")] Chuong Chuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Chuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Gia = new SelectList(db.DonGias, "ID_Gia", "ID_Gia", Chuong.ID_Gia);
            return View(Chuong);
        }

        // GET: Chuongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong Chuong = db.Chuongs.Find(id);
            if (Chuong == null)
            {
                return HttpNotFound();
            }
            return View(Chuong);
        }

        // POST: Chuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chuong Chuong = db.Chuongs.Find(id);
            db.Chuongs.Remove(Chuong);
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