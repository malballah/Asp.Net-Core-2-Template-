using System.Threading;
using System.Threading.Tasks;

namespace ComName.ProjName.Abstraction
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Dispose(bool disposing);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
