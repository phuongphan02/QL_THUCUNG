using QL_THUCUNG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QL_THUCUNG.Controllers
{
    public class DichVusController : Controller
    {
        private QL_THUCUNGEntities db = new QL_THUCUNGEntities();

        // GET: DichVus
        
        string LayMa()
        {
            var maMax = db.DichVus.ToList().Select(n => n.ID_DV).Max();
            int maTV = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("0", maTV.ToString());
            return "DV" + NV.Substring(maTV.ToString().Length - 1);
        }
        
        public ActionResult Index()
        {
            return View(db.DichVus.ToList());
        }
        

        public ActionResult TimKiemNC(string Ma = "", string Ten = "", string GiaBan ="", string AnhSP ="")
        {
            
            ViewBag.Ma = Ma; 
            ViewBag.Ten = Ten;
            ViewBag.GiaBan = GiaBan;
            ViewBag.AnhSP = AnhSP;
            
            var dv = db.DichVus.SqlQuery("DV_TimKiem'" + Ma + "',N'" + Ten + "','" + GiaBan + "','" + AnhSP + "'");
            if (dv.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(dv.ToList());
        }


        // GET: DichVus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // GET: DichVus/Create
        public ActionResult Create()
        {
            ViewBag.ID_DV = LayMa();
            return View();
        }

        // POST: DichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DV,TenDV,GiaBan")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                dichVu.ID_DV = LayMa();
                db.DichVus.Add(dichVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dichVu);
        }

        // GET: DichVus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // POST: DichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DV,TenDV,ANHSP,GiaBan")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dichVu);
        }

        // GET: DichVus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // POST: DichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DichVu dichVu = db.DichVus.Find(id);
            db.DichVus.Remove(dichVu);
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