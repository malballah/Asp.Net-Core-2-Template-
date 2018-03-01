using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ComName.ProjName.Abstraction
{
    /// <summary>
    /// Database access service
    /// </summary>
    /// <typeparam name="TEntity">Model entity</typeparam>
    public interface IDbService<TEntity> 
        where TEntity:class, new()
    {
        /// <summary>
        /// The repository instance of the data model 
        /// </summary>
        IRepository<TEntity> Repository { get; set; }
        /// <summary>
        /// Get all data objects
        /// </summary>
        IQueryable<TEntity> All { get; }
        /// <summary>
        /// Get all data objects without tracking
        /// </summary>
        IQueryable<TEntity> AllWithTrack { get; }
        /// <summary>
        /// Get all data objects after including foreign key fields
        /// </summary>
        /// <param name="includeProperties">Fields to include</param>
        /// <returns></returns>
        IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// Get all data objects after including foreign key fields with no tracking
        /// </summary>
        /// <param name="includeProperties">Fields to include</param>
        /// <returns></returns>
        IQueryable<TEntity> AllWithTrackIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// Find data object with it's keys
        /// </summary>
        /// <param name="keys">The primary key values of the data object</param>
        /// <returns>The found data object </returns>
        TEntity Find(params object[] keys);
        /// <summary>
        /// Find data objects by search condition
        /// </summary>
        /// <param name="predicate">A predicate to filter objects with</param>
        /// /// <param name="withTrack">Whether to track or not track changes on found data objects</param>
        /// <returns>Found data objects</returns>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool withTrack = true);
        /// <summary>
        /// Insert new data objects into the data context
        /// </summary>
        /// <param name="entities">New data objects to insert into the data context </param>
        void Insert(params TEntity[] entities);
        /// <summary>
        /// Delete data objects from the data context
        /// </summary>
        /// <param name="keys">The primary keys of the data objects to delete</param>
        void Delete(params object[] keys);
        /// <summary>
        /// Delete data objects from the data context
        /// </summary>
        /// <param name="entities">Data objects to delete from the data context</param>
        void Delete(params TEntity[] entities);
        /// <summary>
        /// Update data objects
        /// </summary>
        /// <param name="entities">Data objects to be updated</param>
        void Update(params TEntity[] entities);

        #region async actions

        /// <summary>
        /// Find data object with it's keys
        /// </summary>
        /// <param name="keys">The primary key values of the data object</param>
        /// <returns>The found data object </returns>
        Task<TEntity> FindAsync(params object[] keys);
        /// <summary>
        /// Insert new data objects into the data context
        /// </summary>
        /// <param name="entities">New data objects to insert into the data context </param>
        Task InsertAsync(params TEntity[] entities);

        #endregion
    }
}
