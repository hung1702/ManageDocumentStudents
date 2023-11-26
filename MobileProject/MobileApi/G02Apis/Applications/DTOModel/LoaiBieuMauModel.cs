using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G02Apis.Applications.DTOModel
{
    public class LoaiBieuMauModel
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> ThoiGianXuLy { get; set; }
        public string QuyTrinh { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<int> NguoiTao { get; set; }
    }
}