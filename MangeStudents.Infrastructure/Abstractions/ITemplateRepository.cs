using ManageStudent.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.Abstractions
{
    public interface ITemplateRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Template> GetAsync(Guid id);
        Task AddAsync(Template model);
        void Update(Template model);
        IQueryable<Template> GetAll();
    }
}
