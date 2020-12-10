using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {

        internal DbContext dbContext;
        internal DbSet<TEntity> dbSet;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async virtual Task Create(TEntity entityToCreate)
        {
            var createdEntry = await dbSet.AddAsync(entityToCreate);

            await dbContext.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async virtual Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task Update(TEntity entityUpdates)
        {
            var entityToUpdate = await dbSet.FindAsync(entityUpdates.Id);
            if (entityToUpdate != null)
            {
                dbContext.Entry(entityToUpdate).CurrentValues.SetValues(entityUpdates);
                await dbContext.SaveChangesAsync();
            }
        }

        public async virtual Task<TEntity> DeleteById(Guid id)
        {

            var entityToDelete = await GetById(id);

            if (entityToDelete == null) return entityToDelete;

            dbSet.Attach(entityToDelete);
            dbSet.Remove(entityToDelete);
            await dbContext.SaveChangesAsync();

            return entityToDelete;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }
    }
}
