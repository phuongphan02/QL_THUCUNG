using QL_THUCUNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_THUCUNG.Controllers
{
    public class HomeUserController : Controller
    {
        QL_THUCUNGEntities db = new QL_THUCUNGEntities();
        // GET: HomeUser
        public ActionResult Trangchu()
        {
            return View();
        }
        public ActionResult Trangchupatirial()
        {
            if (Session["ThanhVien"] == null)
            {
                return PartialView();
            }
            ThanhVien tv = (ThanhVien)Session["ThanhVien"];
            ViewBag.Ten = tv.TenThanhVien;
            return PartialView();

        }
        public ActionResult GoiDV()
        {
            return View(db.DichVus.ToList());
        }
        public ActionResult TinNhan()
        {
            return View();
        }
        public ActionResult Taikhoan()
        {
            return View();
        }
    }
}