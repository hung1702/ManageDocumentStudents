using ManageStudent.Infrastructure.Abstractions;
using ManageStudent.Infrastructure.Encryption;
using ManageStudent.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.Configurations
{
    public class TemplateEntityConfiguration : BaseEntityConfiguration<Template>
    {
        private readonly IEncryptor _encryptor;

        public TemplateEntityConfiguration(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public override void Configure()
        {
            this
                .HasRequiredField(o => o.Name)
                .HasRequiredField(o => o.Description)

                //.Encrypt(o => o.Name, _encryptor)
                //.Encrypt(o => o.Description, _encryptor)

            ;
        }
    }
}
