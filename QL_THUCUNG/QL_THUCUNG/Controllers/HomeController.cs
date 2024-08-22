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
    public class HomeController : Controller
    {
        // GET: Home
        private QL_THUCUNGEntities  db = new QL_THUCUNGEntities();     
        public ActionResult Index()
        {
            var Chuongs = db.Chuongs.Include(n => n.DonGia);
            return View(Chuongs.ToList());
        }
        public ActionResult NhapChuong(string id)
        {
            /*ThanhVien tv = (ThanhVien)Session["ThanhVien"];*/
            ThanhToan Chuong = new ThanhToan(id);
            ViewBag.id = id;
            return View("Index");
        }
        public ActionResult TinNhan()
        {
            return View();
        }
    }
}