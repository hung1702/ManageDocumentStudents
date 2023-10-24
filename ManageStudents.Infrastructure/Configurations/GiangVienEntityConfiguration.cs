using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace ManageStudents.Infrastructure.Configurations
{
    public class GiangVienEntityConfiguration : BaseEntityConfiguration<GiangVien>
    {
        public GiangVienEntityConfiguration()
        {
        }

        public override void Configure()
        {
            builder.HasKey(a => a.Id);

            this.HasRequiredField(a => a.MaGiangVienId)
                .HasRequiredField(a => a.MaGiangVien);

            builder.HasOne(a => a.KhoaTB).WithMany(q => q.GiangVienTB).HasForeignKey(s => s.KhoaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.UserTB).WithOne(q => q.GiangVienTB).HasForeignKey<GiangVien>(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
