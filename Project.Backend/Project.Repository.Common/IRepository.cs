using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task Create(TEntity entityToCreate);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Update(TEntity entityUpdates);
        Task<TEntity> DeleteById(Guid id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
