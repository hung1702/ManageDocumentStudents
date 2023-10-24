using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Configurations
{
    public class TruongEntityConfiguration : BaseEntityConfiguration<Truong>
    {
        public TruongEntityConfiguration()
        {
        }

        public override void Configure()
        {
            builder.HasKey(a => a.Id);

            this.HasRequiredField(a => a.Ten);

            builder.HasMany(x => x.KhoaTB).WithOne(x => x.TruongTB);

            builder.HasQueryFilter(f => !f.IsDeleted);

            builder.HasOne(o => o.DiaChiTB);

        }
    }
}
