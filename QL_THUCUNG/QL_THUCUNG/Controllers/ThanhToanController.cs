using QL_THUCUNG.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_THUCUNG.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        QL_THUCUNGEntities db = new QL_THUCUNGEntities();
        //[HttpPost]
        private List<ThanhToan> LayThanhToan()
        {
            List<ThanhToan> ls = Session["ThanhToan"] as List<ThanhToan>;
            if (ls == null)
            {
                //Nếu chưa có đơn thanh toán thì tạo 
                ls = new List<ThanhToan>();
                Session["ThanhToan"] = ls;
            }
            return ls;
        }
        //Mở chuồng
        public ActionResult MoChuong(string id_chuong)
        {
            Chuong chuong = db.Chuongs.SingleOrDefault(n => n.ID_Chuong == id_chuong);
            if (chuong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ThanhToan> ls = LayThanhToan();
            ThanhToan tt = ls.Find(n => n.id_Chuong == id_chuong);
            ThanhVien tv = (ThanhVien)Session["ThanhViens"];
            if (tv != null)
            {
                tt.id_tv = tv.ID_ThanhVien;
            }
            if (tt == null)
            {
                chuong.Hoatdong = true;
                db.SaveChanges();
                tt = new ThanhToan(id_chuong);
                ls.Add(tt);
                //Thông báo thành công
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DongChuong(string id_chuong)
        {
            Chuong chuong = db.Chuongs.SingleOrDefault(n => n.ID_Chuong == id_chuong);
            if (chuong == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<ThanhToan> ls = LayThanhToan();
            ThanhToan tt = ls.Find(n => n.id_Chuong == id_chuong);

            chuong.Hoatdong = false;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}