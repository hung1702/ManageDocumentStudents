using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Entities.Enum;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ManageStudents.Infrastructure.Entities.Users
{
    public class User : IdentifiableEntity<Guid>
    {
        public string Ten { get; set; }
        public string Ho { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public Guid DiaChiId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public DateTime? DeactivatedBy { get; set; }
        public UserType UserType { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool ReviewingProfile { get; set; }
        // auditable
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public virtual DiaChi DiaChiTB { get; set; }
        public virtual SinhVien SinhVienTB { get; set; }
        public virtual GiangVien GiangVienTB { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserType
    {
        [EnumMember(Value = "Admin")]
        Admin = 0,

        [EnumMember(Value = "SinhVien")]
        SinhVien = 1,

        [EnumMember(Value = "GiangVien")]
        GiangVien = 2
    }
}
