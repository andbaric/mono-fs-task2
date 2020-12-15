using Project.DAL.Entities;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository.Common.Generic
{
    public interface IRepository<TEntity> 
        where TEntity : EntityModel
    {
        Task<TEntity> Create(TEntity entityToCreate);
        Task<TEntity> Update(TEntity entityUpdates);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> DeleteById(Guid id);

        Task SaveAsync();
    }
}
