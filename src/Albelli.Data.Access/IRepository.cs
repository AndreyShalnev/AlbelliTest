using System.Collections.Generic;

namespace Albelli.Data.Access
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
    }
}
