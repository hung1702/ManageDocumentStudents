using Microsoft.EntityFrameworkCore;
using ManageStudent.Infrastructure.Abstractions;
using ManageStudent.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private StudentContext _context;

        public IUnitOfWork UnitOfWork
        {
            get => _context;
        }

        public AnswerRepository(StudentContext context)
        {
            _context = context;
        }

        public void Add(Answer model) => _context.Answers.Add(model);

        public IEnumerable<Answer> GetByQuestionId(Guid questionId)
        {
            var result = _context.Answers.Where(x => x.QuestionId == questionId);
            return result;
        }

        public void Delete(Answer answer, Guid userId, DateTime now)
        {
            answer.IsDeleted = true;
            answer.DeletedBy = userId;
            answer.DeletedDateTime = now;

            _context.Answers.Update(answer);
        }
    }
}
