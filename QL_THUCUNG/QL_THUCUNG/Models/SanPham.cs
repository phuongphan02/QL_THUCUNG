using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_THUCUNG.Models
{
    public class SanPham
    {
        QL_THUCUNGEntities db = new QL_THUCUNGEntities();
        public string _MaSP { get; set; }
        public string tenSP { get; set; }
        public string AnhSP { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get { return SoLuong * DonGia; } }

        public SanPham(string MaSP)
        {
            _MaSP = MaSP;
            DichVu dv = db.DichVus.Single(n => n.ID_DV == MaSP);
            tenSP = dv.TenDV;
            AnhSP = dv.AnhSP;
            DonGia = double.Parse(dv.GiaBan.ToString());
            SoLuong = 1;
        }
    }
}