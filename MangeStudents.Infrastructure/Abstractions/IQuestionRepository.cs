using Microsoft.EntityFrameworkCore;
using ManageStudent.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.Abstractions
{
    public interface IQuestionRepository
    {
        void Add(Question model);
        void Delete(Question model, Guid userId, DateTime now);
        IQueryable<Question> GetQuestionsByTemplateId(Guid templateId);
    }
}
