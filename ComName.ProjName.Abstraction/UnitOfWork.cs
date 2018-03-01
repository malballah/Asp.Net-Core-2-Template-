using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace ComName.ProjName.Abstraction
{
    public class UnitOfWork:IUnitOfWork
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly DbContext _dbContext;
        /// <summary>
        /// Repository constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Private Fields

        private bool _disposed;
        private IDbContextTransaction _transaction;

        #endregion Private Fields

        #region Constuctor/Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _dbContext?.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        #endregion Constuctor/Dispose

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

       
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }


        #region Unit of Work Transactions

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        #endregion
    }
}
