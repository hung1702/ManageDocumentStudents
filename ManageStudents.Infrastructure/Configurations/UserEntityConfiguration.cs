using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Encryption;
using ManageStudents.Infrastructure.EntityConfigurations;
using ManageStudents.Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Configurations
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        private readonly IEncryptor _encryptor;

        public UserEntityConfiguration(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public override void Configure()
        {
            builder.HasKey(a => a.Id);

            this.HasRequiredField(a => a.UserName)
                .HasRequiredField(a => a.Password)
                .HasRequiredField(a => a.Ten);

            builder.HasQueryFilter(f => !f.IsDeleted);

            builder.Property(p => p.Password).Encrypt(_encryptor);

            //builder.HasOne(o => o.GiangVienTB);

            //builder.HasOne(o => o.SinhVienTB);

            //builder.HasOne(o => o.DiaChiTB);
        }
    }
}
