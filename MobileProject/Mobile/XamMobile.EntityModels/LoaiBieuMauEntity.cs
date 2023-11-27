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

        /*
1. Sinh viên nộp đơn trực tuyến hoặc trực tiếp tại bộ phận một cửa (phòng CTSV).
2. Phòng CTSV kiểm tra thông tin và lập hồ sơ xác nhận, đồng thời xác nhận xử lý đơn trực tuyến.
3. Phòng CTSV ký và đóng dấu đơn.
4. Sinh viên nhận đơn tại VP một cửa.
         * */
    }
}
