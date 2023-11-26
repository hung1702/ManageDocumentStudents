using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamMobile.EntityModels
{
    public class MuonSachEntity
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("NgayMuon")]
        public DateTime? NgayMuon { get; set; }
        [JsonProperty("NguoiMuon")]
        public int NguoiMuon { get; set; }
        [JsonProperty("TenSach")]
        public string TenSach { get; set; }
        [JsonProperty("MaSach")]
        public string MaSach { get; set; }
        [JsonProperty("DaTra")]
        public bool DaTra { get; set; }
        [JsonProperty("NgayTra")]
        public DateTime? NgayTra { get; set; }
        [JsonProperty("ThoiHanMuon")]
        public int ThoiHanMuon { get; set; }
    }
}
