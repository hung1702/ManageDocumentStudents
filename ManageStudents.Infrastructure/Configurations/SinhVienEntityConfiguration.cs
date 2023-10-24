using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Configurations
{
    internal class SinhVienEntityConfiguration : BaseEntityConfiguration<SinhVien>
    {
        public SinhVienEntityConfiguration()
        {
        }

        public override void Configure()
        {
            builder.HasKey(a => a.Id);

            this.HasRequiredField(a => a.MaSinhVienId)
                .HasRequiredField(a => a.MaSinhVien);

            builder.HasOne(a => a.LopSinhVienTB).WithMany(q => q.SinhVienTB).HasForeignKey(s => s.LopSinhVienId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.UserTB).WithOne(q => q.SinhVienTB).HasForeignKey<SinhVien>(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
