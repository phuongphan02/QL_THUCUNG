using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_THUCUNG.Models
{
    public class ThanhToan
    {
        public string id_Chuong { get; set; }
        public string TTDV { get; set; }
        public string id_tv { get; set; }
        public DateTime TGNhan { get; set; }
        public DateTime TGTra { get; set; }
        public float thanhToan { get; set; }
        public ThanhToan(string idChuong)
        {
            id_Chuong = idChuong;
            TGNhan = TGNhan;
            TGTra = TGTra;
        }

    }
}