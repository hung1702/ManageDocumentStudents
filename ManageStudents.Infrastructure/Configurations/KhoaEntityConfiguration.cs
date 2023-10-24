using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Configurations
{
    public class KhoaEntityConfiguration : BaseEntityConfiguration<Khoa>
    {
        public KhoaEntityConfiguration()
        {
        }

        public override void Configure()
        {
            builder.HasKey(a => a.Id);

            this.HasRequiredField(a => a.Ten);

            builder.HasOne(a => a.TruongTB).WithMany(q => q.KhoaTB).HasForeignKey(s => s.TruongId);

            builder.HasMany(x => x.GiangVienTB)
                    .WithOne(x => x.KhoaTB);

            builder.HasMany(x => x.LopSinhVienTB).WithOne(x => x.KhoaTB);

            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
