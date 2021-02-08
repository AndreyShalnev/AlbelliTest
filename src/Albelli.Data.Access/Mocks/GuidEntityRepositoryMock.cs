using System;
using System.Linq;

namespace Albelli.Data.Access.Mocks
{
    public class GuidEntityRepositoryMock<TGuidEntity> : RepositoryMock<TGuidEntity>, IGuidEntityRepository<TGuidEntity>
        where TGuidEntity : IGuidEntity
    {
        public TGuidEntity GetByGuid(Guid guid)
        {
            return Storage.FirstOrDefault(i => i.Guid == guid);
        }
    }
}
