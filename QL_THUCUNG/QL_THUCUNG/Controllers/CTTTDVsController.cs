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
    public class CTTTDVsController : Controller
    {
        private QL_THUCUNGEntities db = new QL_THUCUNGEntities();

        // GET: CTTTDVs
        public ActionResult Index()
        {
            var cTTTDVs = db.CTTTDVs.Include(c => c.DichVu).Include(c => c.ThanhToanDV);
            return View(cTTTDVs.ToList());
        }

        // GET: CTTTDVs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTTTDV cTTTDV = db.CTTTDVs.Find(id);
            if (cTTTDV == null)
            {
                return HttpNotFound();
            }
            return View(cTTTDV);
        }

        // GET: CTTTDVs/Create
        public ActionResult Create()
        {
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV");
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_ThanhVien");
            return View();
        }

        // POST: CTTTDVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TTDV,ID_DV,Soluong,Gia")] CTTTDV cTTTDV)
        {
            if (ModelState.IsValid)
            {
                db.CTTTDVs.Add(cTTTDV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", cTTTDV.ID_DV);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_ThanhVien", cTTTDV.ID_TTDV);
            return View(cTTTDV);
        }

        // GET: CTTTDVs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTTTDV cTTTDV = db.CTTTDVs.Find(id);
            if (cTTTDV == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", cTTTDV.ID_DV);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_ThanhVien", cTTTDV.ID_TTDV);
            return View(cTTTDV);
        }

        // POST: CTTTDVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TTDV,ID_DV,Soluong,Gia")] CTTTDV cTTTDV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTTTDV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", cTTTDV.ID_DV);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_ThanhVien", cTTTDV.ID_TTDV);
            return View(cTTTDV);
        }

        // GET: CTTTDVs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTTTDV cTTTDV = db.CTTTDVs.Find(id);
            if (cTTTDV == null)
            {
                return HttpNotFound();
            }
            return View(cTTTDV);
        }

        // POST: CTTTDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTTTDV cTTTDV = db.CTTTDVs.Find(id);
            db.CTTTDVs.Remove(cTTTDV);
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
