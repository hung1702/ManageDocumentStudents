using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamMobile.EntityModels
{
    public class LoaiBieuMauEntity
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Ten")]
        public string Ten { get; set; }
        [JsonProperty("MoTa")]
        public string MoTa { get; set; }
        [JsonProperty("IsDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        [JsonProperty("ThoiGianXuLy")]
        public Nullable<int> ThoiGianXuLy { get; set; }
        [JsonProperty("QuyTrinh")]
        public string QuyTrinh { get; set; }
        [JsonProperty("NgayTao")]
        public Nullable<System.DateTime> NgayTao { get; set; }
        [JsonProperty("NguoiTao")]
        public Nullable<int> NguoiTao { get; set; }
    }
}
