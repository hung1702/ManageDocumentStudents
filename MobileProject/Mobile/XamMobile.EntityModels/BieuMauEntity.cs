using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamMobile.EntityModels
{
    public class BieuMauEntity
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("SinhVienId")]
        public Nullable<int> SinhVienId { get; set; }
        [JsonProperty("MaSinhVien")]
        public Nullable<int> MaSinhVien { get; set; }
        [JsonProperty("NamThu")]
        public Nullable<int> NamThu { get; set; }
        [JsonProperty("SDT")]
        public Nullable<int> SDT { get; set; }
        [JsonProperty("KhoaHoc")]
        public string KhoaHoc { get; set; }
        [JsonProperty("QueQuan")]
        public string QueQuan { get; set; }
        [JsonProperty("CMND")]
        public string CMND { get; set; }
        [JsonProperty("NoiDung")]
        public string NoiDung { get; set; }
        [JsonProperty("LyDo")]
        public string LyDo { get; set; }
        [JsonProperty("DaXacMinh")]
        public bool DaXacMinh { get; set; }
        [JsonProperty("IsPending")]
        public bool IsPending { get; set; }
        [JsonProperty("IsApproved")]
        public bool IsApproved { get; set; }
        [JsonProperty("IsSolved")]
        public bool IsSolved { get; set; }
        [JsonProperty("LoaiVBId")]
        public Nullable<int> LoaiVBId { get; set; }
        [JsonProperty("NgayTao")]
        public Nullable<System.DateTime> NgayTao { get; set; }
        [JsonProperty("NguoiTao")]
        public Nullable<int> NguoiTao { get; set; }

        [JsonProperty("LoaiVB")]
        public LoaiBieuMauEntity LoaiVB { get; set; }
        //[JsonProperty("SinhVien")]
        //public sinhvien SinhVien { get; set; }
    }
}
