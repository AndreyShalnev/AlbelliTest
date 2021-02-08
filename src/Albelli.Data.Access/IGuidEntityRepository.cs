using System;

namespace Albelli.Data.Access
{
    public interface IGuidEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        TEntity GetByGuid(Guid guid);
    }
}
