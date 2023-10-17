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
    public class AnswerEntityConfiguration : BaseEntityConfiguration<Answer>
    {
        private readonly IEncryptor _encryptor;

        public AnswerEntityConfiguration(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public override void Configure()
        {
            this
                .HasRequiredField(a => a.Text)
                .HasRequiredField(a => a.ActionRequired)
                .HasRequiredField(a => a.QuestionId)

            //.Encrypt(o => o.Text, _encryptor)
            ;

            builder.HasOne(a => a.Question).WithMany(q => q.Answers).HasForeignKey(s => s.QuestionId);

            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
