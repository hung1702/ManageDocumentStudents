using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamMobile.EntityModels
{
    public class LopSinhVienEntity
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Ten")]
        public string Ten { get; set; }
        [JsonProperty("MoTa")]
        public string MoTa { get; set; }
        [JsonProperty("MaLop")]
        public string MaLop { get; set; }
        [JsonProperty("IsDeleted")]
        public Nullable<bool> IsDeleted { get; set; }
        [JsonProperty("CreatedDate")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [JsonProperty("CreatedBy")]
        public Nullable<int> CreatedBy { get; set; }
        [JsonProperty("KhoaId")]
        public Nullable<int> KhoaId { get; set; }

        //[JsonProperty("Khoa")]
        //public virtual Khoa Khoa { get; set; }
        //[JsonProperty("SinhViens")]
        //public virtual ICollection<SinhVien> SinhViens { get; set; }

    }
}
