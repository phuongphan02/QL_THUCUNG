using QL_THUCUNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_THUCUNG.Controllers
{
    public class DangNhapController : Controller
    {
        QL_THUCUNGEntities db = new QL_THUCUNGEntities();
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string n = "Admin";
            string p = "123456";
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            if (sTaiKhoan == n && sMatKhau == p)
            {
                return RedirectToAction("../Home/Index");
            }

            ThanhVien account = db.ThanhViens.SingleOrDefault(a => a.TenDN == sTaiKhoan && a.Matkhau == sMatKhau);
            if (account != null)
            {
                ViewBag.tb = "Đăng nhập thành công";
                Session["ThanhVien"] = account;
                return RedirectToAction("../HomeUser/Trangchu");
            }
            else
            {
                ViewBag.tb = "Tên đặng nhập hoặc mật khẩu sai";
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            // Xóa session của quản trị viên
            Session["Admin"] = null;

            // Xóa session của người dùng
            Session["ThanhVien"] = null;

            // Chuyển hướng về trang đăng nhập
            return RedirectToAction("DangNhap");
        }
    }
}