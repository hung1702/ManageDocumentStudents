using ManageStudents.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Entities.Users
{
    public class LopSinhVien : IdentifiableEntity<Guid>
    {
        public string TenLop { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }
        public Guid KhoaId { get; set; }
        public virtual Khoa KhoaTB { get; set; }
        public virtual ICollection<SinhVien> SinhVienTB { get; set; }
    }
}
