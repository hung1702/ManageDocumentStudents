using G02Apis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G02Apis.Applications.DTOModel
{
    public class DiemModel
    {
        public int Id { get; set; }
        public Nullable<int> MonHocId { get; set; }
        public Nullable<int> SinhVienId { get; set; }
        public Nullable<int> HocKyId { get; set; }
        public Nullable<decimal> DiemCC { get; set; }
        public Nullable<decimal> DiemTH { get; set; }
        public Nullable<decimal> DiemKT { get; set; }
        public Nullable<decimal> DiemThi { get; set; }
        public Nullable<decimal> DiemTB { get; set; }
        public Nullable<decimal> DiemCKy { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<int> NguoiTao { get; set; }

        public virtual HocKy HocKy { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual SinhVien SinhVien { get; set; }
    }
}