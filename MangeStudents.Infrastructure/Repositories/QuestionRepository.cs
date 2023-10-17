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
    public class QuestionRepository : IQuestionRepository
    {
        private StudentContext _context;

        public IUnitOfWork UnitOfWork
        {
            get => _context;
        }

        public QuestionRepository(StudentContext context)
        {
            _context = context;
        }

        public void Add(Question model) => _context.Questions.Add(model);

        public void Delete(Question question, Guid userId, DateTime now)
        {
            question.IsDeleted= true;
            question.DeletedBy = userId;
            question.DeletedDateTime = now;

            _context.Questions.Update(question);
        }

        public IQueryable<Question> GetQuestionsByTemplateId(Guid templateId)
        {
            return _context.Questions.Where(q => q.TemplateId == templateId);
        }
    }
}
