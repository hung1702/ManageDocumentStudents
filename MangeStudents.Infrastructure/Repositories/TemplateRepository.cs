using Microsoft.EntityFrameworkCore;
using ManageStudent.Infrastructure.Abstractions;
using ManageStudent.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private StudentContext _context;

        public IUnitOfWork UnitOfWork
        {
            get => _context;
        }

        public TemplateRepository(StudentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Template> GetAll()
        {
            var result = _context.Templates.Include(x => x.Locations);
            return result.AsNoTracking();
        }

        public async Task<Template> GetAsync(Guid id)
        {
            return await _context.Templates
                .Include(t => t.Questions)
                    .ThenInclude(t => t.Answers)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Template model)
        {
            await _context.Templates.AddAsync(model);
        }

        public void Update(Template model)
        {
            _context.Templates.Update(model);
        }
    }
}
