

using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Entities.Users;

namespace ManageStudents.Infrastructure.Configurations
{
    public class DiaChiEntityConfiguration : BaseEntityConfiguration<DiaChi>
    {
        public DiaChiEntityConfiguration()
        {
        }

        public override void Configure()
        {
            builder.HasKey(a => a.Id);

            this.HasRequiredField(a => a.Ten);

            builder.HasQueryFilter(f => !f.IsDeleted);

            builder.HasOne(a => a.TruongTB).WithOne(q => q.DiaChiTB).HasForeignKey<DiaChi>(o => o.TruongId);
        }
    }

}
