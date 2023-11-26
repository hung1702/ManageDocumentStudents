using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamMobile.EntityModels
{
    public class TinTucEntity
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
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
    }
}
