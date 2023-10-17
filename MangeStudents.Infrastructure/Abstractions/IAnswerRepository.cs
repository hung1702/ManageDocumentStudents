using Microsoft.EntityFrameworkCore;
using ManageStudent.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.Abstractions
{
    public interface IAnswerRepository
    {
        void Add(Answer model);
        IEnumerable<Answer> GetByQuestionId(Guid questionId);
        void Delete(Answer answer, Guid userId, DateTime now);
    }
}
