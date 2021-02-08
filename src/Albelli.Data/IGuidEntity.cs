using System;
using System.Collections.Generic;
using System.Text;

namespace Albelli.Data
{
    public interface IGuidEntity : IEntity
    {
        Guid Guid { get; }
    }
}
