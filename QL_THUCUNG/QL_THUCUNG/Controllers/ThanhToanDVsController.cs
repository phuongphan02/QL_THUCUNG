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
    public class ThanhToanDVsController : Controller
    {
        private QL_THUCUNGEntities db = new QL_THUCUNGEntities();

        // GET: ThanhToanDVs
        // GET: ThanhToanDVs
        public ActionResult Index()
        {
            return View(db.ThanhToanDVs.ToList());
        }

        // GET: ThanhToanDVs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToanDV thanhToanDV = db.ThanhToanDVs.Find(id);
            if (thanhToanDV == null)
            {
                return HttpNotFound();
            }
            return View(thanhToanDV);
        }

        // GET: ThanhToanDVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThanhToanDVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TTDV,TongGia")] ThanhToanDV thanhToanDV)
        {
            if (ModelState.IsValid)
            {
                db.ThanhToanDVs.Add(thanhToanDV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thanhToanDV);
        }

        // GET: ThanhToanDVs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToanDV thanhToanDV = db.ThanhToanDVs.Find(id);
            if (thanhToanDV == null)
            {
                return HttpNotFound();
            }
            return View(thanhToanDV);
        }

        // POST: ThanhToanDVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TTDV,TongGia")] ThanhToanDV thanhToanDV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhToanDV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thanhToanDV);
        }

        // GET: ThanhToanDVs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToanDV thanhToanDV = db.ThanhToanDVs.Find(id);
            if (thanhToanDV == null)
            {
                return HttpNotFound();
            }
            return View(thanhToanDV);
        }

        // POST: ThanhToanDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThanhToanDV thanhToanDV = db.ThanhToanDVs.Find(id);
            db.ThanhToanDVs.Remove(thanhToanDV);
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
