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
    internal class QuestionEntityConfiguration : BaseEntityConfiguration<Question>
    {
        private readonly IEncryptor _encryptor;

        public QuestionEntityConfiguration(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public override void Configure()
        {
            this
                .HasRequiredField(q => q.Text)
                .HasRequiredField(q => q.AllowOtherAnswer)
                .HasRequiredField(q => q.TemplateId)

            //.Encrypt(o => o.Text, _encryptor)
            ;

            builder.HasOne(q => q.Template).WithMany(t => t.Questions).HasForeignKey(q => q.TemplateId);
            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
