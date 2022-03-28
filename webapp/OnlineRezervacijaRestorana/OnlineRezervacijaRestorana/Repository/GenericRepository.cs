using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Online_Rezervacija_Restorana.Extensions;

namespace Online_Rezervacija_Restorana.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Utilities.PagedResult<TEntity> GetPaged(int page)
        {
            return _dbContext.Set<TEntity>().GetPaged(page, 10);
        }

        public TEntity GetById(long id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public TEntity Create(TEntity entity)
        {
            EntityEntry<TEntity> entry = _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();

            return entry.Entity;
        }

        public TEntity Update(long id, TEntity entity)
        {
            EntityEntry<TEntity> entry = _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();

            return entry.Entity;
        }

        public TEntity Delete(long id)
        {
            TEntity entity = GetById(id);
            EntityEntry<TEntity> entry = _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
