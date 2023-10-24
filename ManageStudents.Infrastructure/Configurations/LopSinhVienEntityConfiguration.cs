using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Configurations
{
    public class LopSinhVienEntityConfiguration : BaseEntityConfiguration<LopSinhVien>
    {
        public LopSinhVienEntityConfiguration()
        {
        }

        public override void Configure()
        {
            builder.HasKey(a => a.Id);

            this.HasRequiredField(a => a.TenLop);

            builder.HasOne(a => a.KhoaTB).WithMany(q => q.LopSinhVienTB).HasForeignKey(s => s.KhoaId);

            builder.HasMany(x => x.SinhVienTB).WithOne(x => x.LopSinhVienTB);

            builder.HasQueryFilter(f => !f.IsDeleted);

        }
    }
}
