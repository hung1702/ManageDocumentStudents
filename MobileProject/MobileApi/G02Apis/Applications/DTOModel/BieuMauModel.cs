using G02Apis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G02Apis.Applications.DTOModel
{
    public class BieuMauModel
    {
        public int Id { get; set; }
        public Nullable<int> SinhVienId { get; set; }
        public Nullable<int> MaSinhVien { get; set; }
        public Nullable<int> NamThu { get; set; }
        public Nullable<int> SDT { get; set; }
        public string KhoaHoc { get; set; }
        public string QueQuan { get; set; }
        public string CMND { get; set; }
        public string NoiDung { get; set; }
        public string LyDo { get; set; }
        public bool DaXacMinh { get; set; }
        public bool IsPending { get; set; }
        public bool IsApproved { get; set; }
        public bool IsSolved { get; set; }
        public Nullable<int> LoaiVBId { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<int> NguoiTao { get; set; }
        public LoaiVB LoaiVB { get; set; }
    }
}