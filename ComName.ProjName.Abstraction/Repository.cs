

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComName.ProjName.Abstraction
{
    /// <summary>
    /// Repository can be used to make CRUD actions to a database
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly DbContext _dbContext;
        /// <summary>
        /// Data Set of context model
        /// </summary>
        private readonly DbSet<TEntity> _dbSet;
        /// <summary>
        /// Repository constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            
        }
        /// <summary>
        /// Get all data objects
        /// </summary>
        public IQueryable<TEntity> All => _dbSet.AsNoTracking();
        /// <summary>
        /// Get all data objects with tracking
        /// </summary>
        public IQueryable<TEntity> AllWithTrack => _dbSet;
        /// <summary>
        /// Get all data objects after including foreign key fields
        /// </summary>
        /// <param name="includeProperties">Fields to include</param>
        /// <returns></returns>
        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return includeProperties.Aggregate(All, (current, includeProperty) => current.Include(includeProperty));
        }
        /// <summary>
        /// Get all data objects after including foreign key fields with no tracking
        /// </summary>
        /// <param name="includeProperties">Fields to include</param>
        /// <returns></returns>
        public IQueryable<TEntity> AllWithTrackIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return includeProperties.Aggregate(AllWithTrack, (current, includeProperty) => current.Include(includeProperty));
        }
        /// <summary>
        /// Find data object with it's keys
        /// </summary>
        /// <param name="keys">The primary key values of the data object</param>
        /// <returns>The found data object </returns>
        public TEntity Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }
        /// <summary>
        /// Find data objects by search condition
        /// </summary>
        /// <param name="predicate">A predicate to filter objects with</param>
        /// /// <param name="withTrack">Whether to track or not track changes on found data objects</param>
        /// <returns>Found data objects</returns>
        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate,bool withTrack=true)
        {
            return withTrack ? AllWithTrack.Where(predicate) : All.Where(predicate);
        }
        /// <summary>
        /// Insert new data objects into the data context
        /// </summary>
        /// <param name="entities">New data objects to insert into the data context </param>
        public virtual void Insert(params TEntity[] entities)
        {
            _dbSet.AddRange(entities);
        }
        /// <summary>
        /// Delete data objects from the data context
        /// </summary>
        /// <param name="keys">The primary keys of the data objects to delete</param>
        public virtual void Delete(params object[] keys)
        {
            var foundEntities = keys.Select(key => Find(key));
            _dbSet.RemoveRange(foundEntities);
        }
        /// <summary>
        /// Delete data objects from the data context
        /// </summary>
        /// <param name="entities">Data objects to delete from the data context</param>
        public virtual void Delete(params TEntity[] entities)
        {
            _dbSet.RemoveRange(entities);
        }
        /// <summary>
        /// Update data objects
        /// </summary>
        /// <param name="entities">Data objects to be updated</param>
        public virtual void Update(params TEntity[] entities)
        {
            entities.ToList().ForEach(item => {
                if (!_dbSet.Local.Any(e=>e==item))
                    _dbSet.Attach(item);
                _dbSet.Update(item);
            });
        }

        #region async implementation
        /// <summary>
        /// Find data object with it's keys
        /// </summary>
        /// <param name="keys">The primary key values of the data object</param>
        /// <returns>The found data object </returns>
        public async Task<TEntity> FindAsync(params object[] keys)
        {
            return await _dbSet.FindAsync(keys);
        }
        /// <summary>
        /// Insert new data objects into the data context
        /// </summary>
        /// <param name="entities">New data objects to insert into the data context </param>
        public virtual async Task InsertAsync(params TEntity[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
       
        #endregion async implementation

    }

}