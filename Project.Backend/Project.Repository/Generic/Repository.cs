using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.Repository.Common.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository.Generic
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityModel
    {

        internal DbContext dbContext;
        internal DbSet<TEntity> dbSet;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async virtual Task<TEntity> Create(TEntity entityToCreate)
        {
            await dbSet.AddAsync(entityToCreate);

            return entityToCreate;
        }
        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            var entityCollection = await dbSet.ToListAsync();

            return entityCollection;
        }

        public async virtual Task<TEntity> GetById(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            if(entity != null)
            {
                dbContext.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async virtual Task<TEntity> Update(TEntity entityUpdates)
        {
            var entityToUpdate = await dbSet.FindAsync(entityUpdates.Id);

            if (entityToUpdate == null) return null;

            dbContext.Entry(entityToUpdate).CurrentValues.SetValues(entityUpdates);

            return entityToUpdate;
        }

        public async virtual Task<TEntity> DeleteById(Guid id)
        {
            var entityToDelete = await dbSet.FindAsync(id);

            if (entityToDelete == null) return entityToDelete;

            dbSet.Attach(entityToDelete);
            dbSet.Remove(entityToDelete);

            return entityToDelete;
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}