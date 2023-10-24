using ManageStudents.Infrastructure.Abstractions;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Entities.Users
{
    public class SinhVien : IdentifiableEntity<Guid>
    {
        public int MaSinhVienId { get; set; }
        public string MaSinhVien { get; set; }
        public int KhoaSinhVienId { get; set; }
        public string KhoaSinhVien { get; set; }
        // auditable
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public TrangThaiSV TrangThai { get; set; }
        public Guid LopSinhVienId { get; set; }
        public virtual LopSinhVien LopSinhVienTB { get; set; }
        public Guid UserId { get; set; }
        public virtual User UserTB { get; set; }

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrangThaiSV
    {
        [EnumMember(Value = "DangHoc")]
        DangHoc = 0,

        [EnumMember(Value = "DaTotNghiep")]
        DaTotNghiep = 1,

        [EnumMember(Value = "BaoLuu")]
        BaoLuu = 2,

        [EnumMember(Value = "ThoiHoc")]
        ThoiHoc = 3
    }
}
