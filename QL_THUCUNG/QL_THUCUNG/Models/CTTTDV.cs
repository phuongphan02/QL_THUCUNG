//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_THUCUNG.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTTTDV
    {
        public string ID_TTDV { get; set; }
        public string ID_DV { get; set; }
        public Nullable<int> Soluong { get; set; }
        public Nullable<decimal> Gia { get; set; }
    
        public virtual DichVu DichVu { get; set; }
        public virtual ThanhToanDV ThanhToanDV { get; set; }
    }
}
