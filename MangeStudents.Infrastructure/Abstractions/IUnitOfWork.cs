using System.Threading;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

        int SaveChanges();

        int SaveEntities();
    }
}
