using ManageStudents.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Entities.Users
{
    public class Khoa : IdentifiableEntity<Guid>
    {
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public Guid TruongId { get; set; }
        public virtual Truong TruongTB { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }
        public virtual ICollection<LopSinhVien> LopSinhVienTB { get; set; }
        public virtual ICollection<GiangVien> GiangVienTB { get; set; }
    }
}
