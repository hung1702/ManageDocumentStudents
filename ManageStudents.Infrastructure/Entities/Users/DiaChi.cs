using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Entities.Users
{
    public class DiaChi : IdentifiableEntity<Guid>
    {
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string PhuongXa { get; set; }
        public string QuanHuyen { get; set; }
        public string Tinh { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }
        public Guid TruongId { get; set; }
        public virtual Truong TruongTB { get; set; }
        public virtual User UserTB { get; set; }
    }
}
