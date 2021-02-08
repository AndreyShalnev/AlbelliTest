using System.Collections.Generic;
using System.Linq;

namespace Albelli.Data.Access.Mocks
{
    public class RepositoryMock<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        protected static List<TEntity> Storage { get; set; }
        protected object lockObj = new object();

        public RepositoryMock()
        {
            lock (lockObj)
            {
                Storage = new List<TEntity>();
            }
        }

        public TEntity GetById(int id)
        {
            return Storage.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Storage;
        }

        public TEntity Add(TEntity entity)
        {
            lock (lockObj)
            {
                Storage.Add(entity);
            }
            return  entity;
        }
    }
}
