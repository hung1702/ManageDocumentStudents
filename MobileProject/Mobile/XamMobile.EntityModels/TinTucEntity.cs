using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamMobile.EntityModels
{
    public class TinTucEntity
    {
        [JsonProperty("TinTucId")]
        public int TinTucId { get; set; }
        [JsonProperty("Ten")]
        public string Ten { get; set; }
        [JsonProperty("NgayTao")]
        public DateTime NgayTao { get; set; }
        [JsonProperty("NguoiTao")]
        public string NguoiTao { get; set; }
        [JsonProperty("NoiDungMo")]
        public string NoiDungMo { get; set; }
        [JsonProperty("NoiDungThan")]
        public string NoiDungThan { get; set; }
        [JsonProperty("NoiDungKet")]
        public string NoiDungKet { get; set; }
        [JsonProperty("TieuDeMo")]
        public string TieuDeMo { get; set; }
        [JsonProperty("TieuDeThan")]
        public string TieuDeThan { get; set; }
        [JsonProperty("TieuDeKet")]
        public string TieuDeKet { get; set; }
        [JsonProperty("AnhMo")]
        public string AnhMo { get; set; }
        [JsonProperty("AnhThan")]
        public string AnhThan { get; set; }
        [JsonProperty("AnhKet")]
        public string AnhKet { get; set; }
        [JsonProperty("NgayKetThuc")]
        public DateTime? NgayKetThuc { get; set; }
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        [JsonProperty("IsNoiBat")]
        public bool IsNoiBat { get; set; }
    }
}
