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
    public class GiangVien : IdentifiableEntity<Guid>
    {
        public int MaGiangVienId { get; set; }
        public string MaGiangVien { get; set; }
        // auditable
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public TrangThaiGV TrangThai { get; set; }
        public Guid KhoaId { get; set; }
        public virtual Khoa KhoaTB { get; set; }
        public Guid UserId { get; set; }
        public virtual User UserTB { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrangThaiGV
    {
        [EnumMember(Value = "DangDay")]
        DangDay = 0,

        [EnumMember(Value = "NgungDay")]
        NgungDay = 1,
    }
}
