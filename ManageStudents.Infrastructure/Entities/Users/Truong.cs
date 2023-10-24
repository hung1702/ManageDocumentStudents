using ManageStudents.Infrastructure.Abstractions;

namespace ManageStudents.Infrastructure.Entities.Users
{
    public class Truong : IdentifiableEntity<Guid>
    {
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }
        public Guid DiaChiId { get; set; }
        public virtual DiaChi DiaChiTB { get; set; }
        public virtual ICollection<Khoa> KhoaTB { get; set; }
    }
}
