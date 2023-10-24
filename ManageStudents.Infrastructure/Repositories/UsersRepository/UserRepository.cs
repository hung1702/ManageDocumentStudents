using ManageStudents.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Repositories.UsersRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentContext _context;

        public IUnitOfWork UnitOfWork
        {
            get => _context;
        }

        public UserRepository(StudentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


    }
}
